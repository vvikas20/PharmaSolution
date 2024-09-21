CREATE PROCEDURE [dbo].[InsertUpdateInvetoryLineItemInTempTable]
	@TableTypePurchaseSaleBookLineItem TableTypePurchaseSaleBookLineItem READONLY
AS
BEGIN	
	BEGIN TRY	
	BEGIN TRAN
	
	MERGE INTO dbo.TempPurchaseSaleBookLineItem t1
	USING @TableTypePurchaseSaleBookLineItem t2 
	ON t1.PurchaseSaleBookLineItemID = t2.PurchaseSaleBookLineItemID
	WHEN MATCHED THEN 
	UPDATE SET t1.PurchaseSaleBookHeaderID=t2.PurchaseSaleBookHeaderID
		,t1.PurchaseBillDate=t2.PurchaseBillDate
		,t1.PurchaseVoucherNumber=t2.PurchaseVoucherNumber
		,t1.PurchaseSrlNo=t2.PurchaseSrlNo
		,t1.ItemCode=t2.ItemCode
		,t1.Batch=t2.Batch
		,t1.BatchNew=t2.BatchNew
		,t1.Quantity=t2.Quantity
		,t1.FreeQuantity=t2.FreeQuantity
		,t1.PurchaseSaleRate=t2.PurchaseSaleRate
		,t1.EffecivePurchaseSaleRate=t2.EffecivePurchaseSaleRate
		,t1.PurchaseSaleTypeCode=t2.PurchaseSaleTypeCode
		,t1.SurCharge=t2.SurCharge
		,t1.PurchaseSaleTax=t2.PurchaseSaleTax
		,t1.LocalCentral=t2.LocalCentral
		,t1.SGST=t2.SGST
		,t1.IGST=t2.IGST
		,t1.CGST=t2.CGST
		,t1.Amount=t2.Amount
		,t1.Discount=t2.Discount
		,t1.SpecialDiscount=t2.SpecialDiscount
		,t1.DiscountQuantity=t2.DiscountQuantity
		,t1.VolumeDiscount=t2.VolumeDiscount
		,t1.Scheme1=t2.Scheme1
		,t1.Scheme2=t2.Scheme2
		,t1.IsHalfScheme=t2.IsHalfScheme
		,t1.HalfSchemeRate=t2.HalfSchemeRate
		,t1.ConversionRate=t2.ConversionRate
		,t1.MRP=t2.MRP
		,t1.ExpiryDate=t2.ExpiryDate
		,t1.SaleRate=t2.SaleRate
		,t1.WholeSaleRate=t2.WholeSaleRate
		,t1.SpecialRate=t2.SpecialRate		
		,t1.ModifiedBy=t2.ModifiedBy
		,t1.ModifiedOn=t2.ModifiedOn
	WHEN NOT MATCHED THEN
	INSERT (
		 PurchaseSaleBookHeaderID
		,PurchaseBillDate,PurchaseVoucherNumber,PurchaseSrlNo
		,ItemCode,Batch,BatchNew
		,Quantity,FreeQuantity
		,PurchaseSaleRate,EffecivePurchaseSaleRate
		,PurchaseSaleTypeCode,SurCharge
		,PurchaseSaleTax
		,LocalCentral,SGST,IGST,CGST
		,Amount,Discount,SpecialDiscount,DiscountQuantity,VolumeDiscount
		,Scheme1,Scheme2,IsHalfScheme,HalfSchemeRate		
		,ConversionRate,MRP,ExpiryDate
		,SaleRate,WholeSaleRate,SpecialRate
		,CreatedBy,CreatedOn	
	)
	VALUES
	(
		 t2.PurchaseSaleBookHeaderID
		,t2.PurchaseBillDate,t2.PurchaseVoucherNumber,t2.PurchaseSrlNo
		,t2.ItemCode,t2.Batch,t2.BatchNew
		,t2.Quantity,t2.FreeQuantity
		,t2.PurchaseSaleRate,t2.EffecivePurchaseSaleRate
		,t2.PurchaseSaleTypeCode,t2.SurCharge
		,t2.PurchaseSaleTax
		,t2.LocalCentral,t2.SGST,t2.IGST,t2.CGST
		,t2.Amount,t2.Discount,t2.SpecialDiscount,t2.DiscountQuantity,t2.VolumeDiscount
		,t2.Scheme1,t2.Scheme2,t2.IsHalfScheme,t2.HalfSchemeRate		
		,t2.ConversionRate,t2.MRP,t2.ExpiryDate
		,t2.SaleRate,t2.WholeSaleRate,t2.SpecialRate
		,t2.CreatedBy,t2.CreatedOn
	);	
	
	
	MERGE INTO dbo.ItemMaster t1
	USING @TableTypePurchaseSaleBookLineItem t2 
	ON t1.ItemCode = t2.ItemCode
	WHEN MATCHED THEN 
	UPDATE SET t1.PurchaseRate = t2.PurchaseSaleRate
			,t1.MRP = t2.MRP
			,t1.SaleRate = t2.SaleRate
			,t1.SpecialRate = t2.SpecialRate
			,t1.WholeSaleRate = t2.WholeSaleRate
			,t1.Scheme1 = t2.Scheme1
			,t1.Scheme2 = t2.Scheme2
			,t1.IsHalfScheme = t2.IsHalfScheme
			,t1.DiscountRecieved = t2.Discount
			,t1.SpecialDiscountRecieved =t2.SpecialDiscount
			,t1.BATCH = t2.BATCH
			,t1.ExpiryDate  = t2.ExpiryDate
			;
	
	
	DECLARE @PurchaseSaleBookLineItemID AS BIGINT
	DECLARE @PurchaseSaleBookHeaderID AS BIGINT
	
	SELECT @PurchaseSaleBookLineItemID = PurchaseSaleBookLineItemID 
			,@PurchaseSaleBookHeaderID = PurchaseSaleBookHeaderID
	FROM @TableTypePurchaseSaleBookLineItem

	IF @PurchaseSaleBookLineItemID = 0
	BEGIN	
		SELECT @PurchaseSaleBookLineItemID = SCOPE_IDENTITY()
	END
	
	
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
	   
		UNION ALL
		
		SELECT 
			 @PurchaseSaleBookHeaderID AS PurchaseSaleBookHeaderID
			,@PurchaseSaleBookLineItemID AS PurchaseSaleBookLineItemID
			,B.FinalAmount AS BillAmount
			,B.FinalAmount AS CostAmount
			,(B.FinalAmount * .01 * Final.PurchaseSaleTax) As TaxAmount			
			,B.GrossAmount
			,B.SchemeAmount
			,B.DiscountAmount
			,B.SpecialDiscountAmount
			,B.VolumeDiscountAmount
			,(B.DiscountAmount + b.SpecialDiscountAmount + b.VolumeDiscountAmount) AS TotalDiscountAmount
		 FROM dbo.TempPurchaseSaleBookLineItem Final
		 INNER JOIN @TempTableAmountWithAllDiscountAmounts AS B
		    On Final.PurchaseSaleBookHeaderID = B.PurchaseSaleBookHeaderID 
			AND Final.PurchaseSaleBookLineItemID = B.PurchaseSaleBookLineItemID 
		 WHERE Final.PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID
			AND Final.PurchaseSaleBookLineItemID = @PurchaseSaleBookLineItemID

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
