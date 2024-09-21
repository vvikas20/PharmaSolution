CREATE PROCEDURE [dbo].[DeleteInvetoryLineItemInTempTable] 
	@PurchaseSaleBookHeaderID BigInt,
	@PurchaseSaleBookLineItemID BigInt
AS
BEGIN

BEGIN TRY	
	BEGIN TRAN
	
	
	DELETE FROM dbo.TempPurchaseSaleBookLineItem WHERE
	PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID
	AND PurchaseSaleBookLineItemID = @PurchaseSaleBookLineItemID
	
	
	DECLARE @TempTableAmountWithAllDiscountAmounts TABLE (
		   PurchaseSaleBookHeaderID BIGINT NOT NULL,
		   PurchaseSaleBookLineItemID BIGINT NOT NULL,
		   FinalAmount FLOAT NOT NULL,
		   GrossAmount FLOAT NOT NULL,
		   SchemeAmount FLOAT NOT NULL,
		   DiscountAmount FLOAT NOT NULL,
		   SpecialDiscountAmount FLOAT NOT NULL,
		   VolumeDiscountAmount FLOAT NOT NULL   
		) ;
		
		
		INSERT INTO @TempTableAmountWithAllDiscountAmounts 
		   (
				PurchaseSaleBookHeaderID
				,PurchaseSaleBookLineItemID
				,FinalAmount
				,GrossAmount
				,SchemeAmount
				,DiscountAmount
				,SpecialDiscountAmount
				,VolumeDiscountAmount
		   )
		  SELECT PurchaseSaleBookHeaderID
				,PurchaseSaleBookLineItemID
				,FinalAmount
				,GrossAmount
				,SchemeAmount
				,DiscountAmount
				,SpecialDiscountAmount
				,VolumeDiscountAmount
		FROM UDF_GetAmountWithAllDiscountAmounts(@PurchaseSaleBookHeaderID)
	  
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
				,Amt4.FinalAmount AS BillAmount		 
				,(Amt4.FinalAmount * .01 * Final.PurchaseSaleTax) As TaxAmount
				,Amt4.GrossAmount
				,Amt4.SchemeAmount
				,Amt4.DiscountAmount
				,Amt4.SpecialDiscountAmount 
				,Amt4.VolumeDiscountAmount
		 FROM @TempTableAmountWithAllDiscountAmounts AS Amt4
		 INNER JOIN dbo.TempPurchaseSaleBookLineItem AS Final
			 ON Amt4.PurchaseSaleBookHeaderID = final.PurchaseSaleBookHeaderID 
		      AND Amt4.PurchaseSaleBookLineItemID = final.PurchaseSaleBookLineItemID
		  WHERE final.PurchaseSaleBookHeaderID  = @PurchaseSaleBookHeaderID
		) Amt4
		GROUP BY Amt4.PurchaseSaleBookHeaderID
		
		
	COMMIT TRAN    
    END TRY
    BEGIN CATCH    
		ROLLBACK TRAN 
		DECLARE @ErrorNumber INT = ERROR_NUMBER();
		DECLARE @ErrorMessage NVARCHAR(1000) = ERROR_MESSAGE() 
		RAISERROR('Error Number-%d : Error Message-%s', 16, 1, 
		@ErrorNumber, @ErrorMessage)   
    END CATCH	
	
END
