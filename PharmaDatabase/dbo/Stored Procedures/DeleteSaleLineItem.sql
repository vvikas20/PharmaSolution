CREATE PROCEDURE [dbo].[DeleteSaleLineItem]
(
	@PurchaseSaleBookHeaderID INT,
	@TempPurchaseSaleBookLineItemID INT
)
AS
BEGIN
	
	DECLARE @itemCode VARCHAR(10)

	SELECT @itemCode = ItemCode FROM TempPurchaseSaleBookLineItem WHERE PurchaseSaleBookLineItemID = @TempPurchaseSaleBookLineItemID
	
	DECLARE @tblLineItemsDeleted AS TABLE
	(
		ID INT IDENTITY(1,1),
		LineItemID INT,
		QuantityToBeInsert Decimal(18,2),
		FifoID INT
	)

	IF EXISTS (SELECT ItemCode FROM TempPurchaseSaleBookLineItem WHERE PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID AND ItemCode = @itemCode AND ISNULL(FreeQuantity,0) <> 0.00 )
	BEGIN
		INSERT INTO @tblLineItemsDeleted(LineItemID, FifoID, QuantityToBeInsert)
		SELECT PurchaseSaleBookLineItemID, FifoID, ISNULL(Quantity,0) + ISNULL(FreeQuantity, 0) FROM TempPurchaseSaleBookLineItem 
		WHERE PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID AND ItemCode = @itemCode
	END
	ELSE
	BEGIN
		INSERT INTO @tblLineItemsDeleted(LineItemID, FifoID, QuantityToBeInsert)
		SELECT PurchaseSaleBookLineItemID, FifoID, ISNULL(Quantity,0) + ISNULL(FreeQuantity, 0) FROM TempPurchaseSaleBookLineItem
		WHERE PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID AND PurchaseSaleBookLineItemID = @TempPurchaseSaleBookLineItemID 
	END

	BEGIN TRY	
		BEGIN TRAN
		DECLARE @Count INT = 0, @ID INT = 1, @LineItemID INT, @FifoID INT, @Quantity DECIMAL(18, 2)

		SELECT @Count = Count(*) FROM @tblLineItemsDeleted

		WHILE(@ID <= @Count)
		BEGIN
			SELECT @LineItemID = LineItemID, @Quantity = QuantityToBeInsert, @FifoID = FifoID FROM @tblLineItemsDeleted WHERE ID = @ID
			DELETE FROM TempPurchaseSaleBookLineItem WHERE PurchaseSaleBookLineItemID = @LineItemID

			UPDATE FIFO SET BalanceQuanity = BalanceQuanity + @Quantity WHERE FifoID = @FifoID
			SELECT @ID = @ID + 1
		END

		COMMIT TRAN

		
		DECLARE @TempTableAmountWithAllDiscountAmounts TABLE (
			   PurchaseSaleBookHeaderID BIGINT NOT NULL,
			   PurchaseSaleBookLineItemID BIGINT NOT NULL,
			   BillAmount DECIMAL(18,2) NOT NULL,
			   CostAmount DECIMAL(18,2) NOT NULL,
			   TaxAmount DECIMAL(18,2) NOT NULL,
			   GrossAmount DECIMAL(18,2) NOT NULL,
			   SchemeAmount DECIMAL(18,2) NOT NULL,
			   DiscountAmount DECIMAL(18,2) NOT NULL,
			   SpecialDiscountAmount DECIMAL(18,2) NOT NULL,
			   VolumeDiscountAmount DECIMAL(18,2) NOT NULL ,
			   TotalDiscountAmount DECIMAL(18,2) NOT NULL  
			) ;
	
		INSERT INTO @TempTableAmountWithAllDiscountAmounts 
		   (
				PurchaseSaleBookHeaderID
				,PurchaseSaleBookLineItemID
				,BillAmount
				,CostAmount
				,TaxAmount
				,GrossAmount
				,SchemeAmount
				,DiscountAmount
				,SpecialDiscountAmount
				,VolumeDiscountAmount
				,TotalDiscountAmount
		   )
		   SELECT 
			  Amt4.PurchaseSaleBookHeaderID
			 ,0 AS PurchaseSaleBookLineItemID
			 ,SUM(Amt4.BillAmount) AS BillAmount
			 ,0 AS CostAmount
			 ,SUM(Amt4.TaxAmount) As TaxAmount
			 ,SUM(Amt4.GrossAmount) AS GrossAmount
			 ,SUM(Amt4.SchemeAmount) AS SchemeAmount
			 ,SUM(Amt4.DiscountAmount) AS DiscountAmount
			 ,SUM(Amt4.SpecialDiscountAmount) AS SpecialDiscountAmount
			 ,SUM(Amt4.VolumeDiscountAmount) AS VolumeDiscountAmount
			 ,SUM(Amt4.DiscountAmount + Amt4.SpecialDiscountAmount + Amt4.VolumeDiscountAmount) AS TotalDiscountAmount
			FROM 
			(
				SELECT 
				Amt4.PurchaseSaleBookHeaderID
				,Amt4.PurchaseSaleBookLineItemID
				,FinalAmount AS BillAmount		 
				,(FinalAmount * .01 * PurchaseSaleTax) As TaxAmount
				,Amt4.GrossAmount
				,Amt4.SchemeAmount
				,Amt4.DiscountAmount
				,Amt4.SpecialDiscountAmount 
				,Amt4.VolumeDiscountAmount
				FROM UDF_GetAmountWithAllDiscountAmounts(@PurchaseSaleBookHeaderID) Amt4
			    INNER JOIN dbo.TempPurchaseSaleBookLineItem AS Final
				ON Amt4.PurchaseSaleBookHeaderID = final.PurchaseSaleBookHeaderID 
				AND Amt4.PurchaseSaleBookLineItemID = final.PurchaseSaleBookLineItemID
				WHERE final.PurchaseSaleBookHeaderID  = @PurchaseSaleBookHeaderID
			)Amt4 GROUP BY Amt4.PurchaseSaleBookHeaderID

		SELECT @PurchaseSaleBookHeaderID as PurchaseSaleBookHeaderID,
		LineItemID as PurchaseSaleBookLineItemID,
		0 as SchemeAmount,
		0 as GrossAmount,
		0 as CostAmount,
		0 as DiscountAmount,
		0 as VolumeDiscountAmount,
		0 as SpecialDiscountAmount,
		0 as TotalDiscountAmount,
		0 as BillAmount,
		0 as TaxAmount
		FROM @tblLineItemsDeleted
		UNION ALL
		SELECT PurchaseSaleBookHeaderID,
		PurchaseSaleBookLineItemID,
		SchemeAmount,
		GrossAmount,
		CostAmount,
		DiscountAmount,
		VolumeDiscountAmount,
		SpecialDiscountAmount,
		TotalDiscountAmount,
		BillAmount,
		TaxAmount
	FROM
		@TempTableAmountWithAllDiscountAmounts
	
		

	END TRY
    BEGIN CATCH    
		ROLLBACK TRAN 
		DECLARE @ErrorNumber INT = ERROR_NUMBER();
		DECLARE @ErrorMessage NVARCHAR(1000) = ERROR_MESSAGE() 
		RAISERROR('Error Number-%d : Error Message-%s', 16, 1, 
		@ErrorNumber, @ErrorMessage)   
    END CATCH
	
END
