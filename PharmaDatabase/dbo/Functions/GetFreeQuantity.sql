CREATE FUNCTION [dbo].[GetFreeQuantity]
(
	@ItemCode nvarchar(9),
	@Quantity decimal(18,2)
	 
)
RETURNS decimal(18,2)
BEGIN
   
    DECLARE @FreeQuantity decimal(18,2)
	DECLARE @Scheme1 decimal(18,2)
	DECLARE @Scheme2 decimal(18,2)
	DECLARE @IsHalfScheme bit
	
	SET @FreeQuantity = 0

	SELECT @Scheme1 = Scheme1,@Scheme2 = Scheme2,@IsHalfScheme = IsHalfScheme
	FROM ItemMaster	WHERE ItemCode = @ItemCode


	IF @IsHalfScheme = 1 AND @Quantity < @Scheme1 
		BEGIN
			IF @Quantity >= (@Scheme1 * .5)
			BEGIN
				SET @FreeQuantity = 0.5
			END			
		
		END
	ELSE
		BEGIN
		
			IF @Scheme2 > 0
			BEGIN
				SET @FreeQuantity = FLOOR((@Quantity  * @Scheme2) / @Scheme1)
			END
		END		
		
	RETURN @FreeQuantity

END
