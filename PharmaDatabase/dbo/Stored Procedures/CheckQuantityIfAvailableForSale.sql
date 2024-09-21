CREATE PROCEDURE [dbo].[CheckQuantityIfAvailableForSale]
(
 @PurchaseSaleBookHeaderID BIGINT,
 @PurchaseSaleBookLineItemID BIGINT,
 @ItemCode NVARCHAR(9),
 @Quantity decimal(18,2),
 @FreeQuantity decimal(18,2)
)
AS
BEGIN


	DECLARE @TotalQuantityForItem decimal(18,2)
	DECLARE @OldQuantity decimal(18,2), @NewQuantity decimal
	DECLARE @OldFreeQuantity decimal(18,2),@NewFreeQuantity decimal(18,2)
	DECLARE @BalanceQuantity decimal(18,2)
	
	Select @OldQuantity = Quantity ,@OldFreeQuantity = ISNULL(FreeQuantity,0)
	FROM TempPurchaseSaleBookLineItem 
	WHERE PurchaseSaleBookLineItemID = @PurchaseSaleBookLineItemID
	
	SELECT @BalanceQuantity = SUM(BalanceQuanity) FROM FIFO WHERE ItemCode = @ItemCode


	SELECT @TotalQuantityForItem = SUM(Quantity)
	FROM TempPurchaseSaleBookLineItem 
	WHERE PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID AND ItemCode = @ItemCode

	SET @NewQuantity = @Quantity - @OldQuantity
	SET @TotalQuantityForItem  = @TotalQuantityForItem  + @NewQuantity
			
	SET @FreeQuantity = dbo.GetFreeQuantity(@ItemCode,@TotalQuantityForItem)
			
	SET @NewFreeQuantity = @FreeQuantity  - @OldFreeQuantity

	
	IF @Quantity <> @OldQuantity AND @Quantity < @OldQuantity
	BEGIN
		SELECT 1 AS IsAvailable, @NewFreeQuantity AS FreeQuantity
	END
	ELSE IF @Quantity = @OldQuantity AND @FreeQuantity < @OldFreeQuantity
	BEGIN
		SELECT 1 AS IsAvailable, @NewFreeQuantity AS FreeQuantity
	END
	ELSE IF @Quantity = @OldQuantity AND @FreeQuantity > @OldFreeQuantity AND @BalanceQuantity > (@FreeQuantity - @OldFreeQuantity)
	BEGIN
		SELECT 1 AS IsAvailable, @NewFreeQuantity AS FreeQuantity
	END
	ELSE
	BEGIN
			IF @BalanceQuantity >= (@NewQuantity + @NewFreeQuantity)
			BEGIN
				SELECT 1 AS IsAvailable, @NewFreeQuantity AS FreeQuantity
			END
			ELSE
			BEGIN
				SELECT 0 AS IsAvailable,  @NewFreeQuantity AS FreeQuantity
			END
			
	END
END
