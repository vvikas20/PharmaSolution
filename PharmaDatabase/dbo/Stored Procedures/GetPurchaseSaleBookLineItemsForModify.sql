CREATE PROCEDURE [dbo].[GetPurchaseSaleBookLineItemsForModify]
	@PurchaseSaleBookHeaderID bigint
AS
BEGIN	
	BEGIN TRY	
	BEGIN TRAN
	
	
	DECLARE @OldPurchaseSaleBookHeaderID Bigint
	DECLARE @VoucherType nvarchar(100)
	
	SELECT @OldPurchaseSaleBookHeaderID  = OldPurchaseSaleBookHeaderID , @VoucherType = VoucherTypeCode
	FROM TempPurchaseSaleBookHeader WHERE PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID	
	
	IF @VoucherType = 'PURCHASEENTRY'
	BEGIN
	
		INSERT INTO TempPurchaseSaleBookLineItem
		(
			   PurchaseSaleBookHeaderID
			  ,FifoID,ItemCode,Batch,BatchNew
			  ,PurchaseSrlNo
			  ,Quantity,FreeQuantity
			  ,PurchaseSaleRate,EffecivePurchaseSaleRate
			  ,PurchaseSaleTypeCode,SurCharge,PurchaseSaleTax
			  ,LocalCentral,SGST,IGST,CGST
			  ,Amount,Discount,SpecialDiscount,DiscountQuantity,VolumeDiscount
			  ,Scheme1,Scheme2,IsHalfScheme,HalfSchemeRate
			  ,CostAmount,GrossAmount,SchemeAmount,DiscountAmount,SurchargeAmount
			  ,ConversionRate,MRP,ExpiryDate
			  ,SaleRate,WholeSaleRate,SpecialRate
			  ,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn
			  ,TaxAmount
			  ,SpecialDiscountAmount
			  ,VolumeDiscountAmount
			  ,TotalDiscountAmount
			  ,OldPurchaseSaleBookLineItemID  
			  ,BalanceQuantity
			  ,UsedQuantity
		)	
		SELECT 
			   @PurchaseSaleBookHeaderID AS PurchaseSaleBookHeaderID
			  ,F.FifoID,I.ItemCode,I.Batch,BatchNew
			  ,I.PurchaseSrlNo
			  ,I.Quantity,FreeQuantity
			  ,PurchaseSaleRate,EffecivePurchaseSaleRate
			  ,PurchaseSaleTypeCode,SurCharge,I.SalePurchaseTax AS PurchaseSaleTax
			  ,LocalCentral,SGST,IGST,CGST
			  ,Amount,Discount,SpecialDiscount,DiscountQuantity,VolumeDiscount
			  ,I.Scheme1,I.Scheme2,IsHalfScheme,HalfSchemeRate
			  ,CostAmount,GrossAmount,SchemeAmount,DiscountAmount,SurchargeAmount
			  ,ConversionRate,I.MRP,I.ExpiryDate
			  ,I.SaleRate,I.WholeSaleRate,I.SpecialRate
			  ,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn
			  ,TaxAmount
			  ,SpecialDiscountAmount
			  ,VolumeDiscountAmount
			  ,TotalDiscountAmount
			  ,PurchaseSaleBookLineItemID AS OldPurchaseSaleBookLineItemID
			  ,F.BalanceQuanity 
			  ,(F.Quantity - F.BalanceQuanity) AS UsedQuantity
		  FROM dbo.PurchaseSaleBookLineItem I
		  INNER JOIN FIFO F ON I.PurchaseSaleBookHeaderID = F.PurchaseSaleBookHeaderID
				AND I.PurchaseSrlNo = F.SRLNO
		  WHERE I.PurchaseSaleBookHeaderID = @OldPurchaseSaleBookHeaderID
      
      END
      ELSE
      BEGIN
      
				INSERT INTO TempPurchaseSaleBookLineItem
				(
					   PurchaseSaleBookHeaderID
					  ,FifoID,ItemCode,Batch,BatchNew
					  ,PurchaseBillDate,PurchaseVoucherNumber,PurchaseSrlNo
					  ,Quantity,FreeQuantity
					  ,PurchaseSaleRate,EffecivePurchaseSaleRate
					  ,PurchaseSaleTypeCode,SurCharge,PurchaseSaleTax
					  ,LocalCentral,SGST,IGST,CGST
					  ,Amount,Discount,SpecialDiscount,DiscountQuantity,VolumeDiscount
					  ,Scheme1,Scheme2,IsHalfScheme,HalfSchemeRate
					  ,CostAmount,GrossAmount,SchemeAmount,DiscountAmount,SurchargeAmount
					  ,ConversionRate,MRP,ExpiryDate
					  ,SaleRate,WholeSaleRate,SpecialRate
					  ,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn
					  ,TaxAmount
					  ,SpecialDiscountAmount
					  ,VolumeDiscountAmount
					  ,TotalDiscountAmount
					  ,OldPurchaseSaleBookLineItemID  
					  --,BalanceQuantity
					  --,UsedQuantity
				)	
				SELECT 
					   @PurchaseSaleBookHeaderID AS PurchaseSaleBookHeaderID
					  ,I.FifoID,I.ItemCode,I.Batch,BatchNew
					   ,I.PurchaseBillDate,I.PurchaseVoucherNumber,I.PurchaseSrlNo
					  ,I.Quantity,FreeQuantity
					  ,PurchaseSaleRate,EffecivePurchaseSaleRate
					  ,PurchaseSaleTypeCode,SurCharge,I.SalePurchaseTax AS PurchaseSaleTax
					  ,LocalCentral,SGST,IGST,CGST
					  ,Amount,Discount,SpecialDiscount,DiscountQuantity,VolumeDiscount
					  ,I.Scheme1,I.Scheme2,IsHalfScheme,HalfSchemeRate
					  ,CostAmount,GrossAmount,SchemeAmount,DiscountAmount,SurchargeAmount
					  ,ConversionRate,I.MRP,I.ExpiryDate
					  ,I.SaleRate,I.WholeSaleRate,I.SpecialRate
					  ,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn
					  ,TaxAmount
					  ,SpecialDiscountAmount
					  ,VolumeDiscountAmount
					  ,TotalDiscountAmount
					  ,PurchaseSaleBookLineItemID AS OldPurchaseSaleBookLineItemID
					  --,F.BalanceQuanity 
					  --,(F.Quantity - F.BalanceQuanity) AS UsedQuantity
				  FROM dbo.PurchaseSaleBookLineItem I
				  --INNER JOIN FIFO F ON I.PurchaseSaleBookHeaderID = F.PurchaseSaleBookHeaderID
						--AND I.PurchaseSrlNo = F.SRLNO
				  WHERE I.PurchaseSaleBookHeaderID = @OldPurchaseSaleBookHeaderID
					
      
      END
      
      SELECT       
		   PurchaseSaleBookHeaderID
		  ,PurchaseSaleBookLineItemID 
		  ,FifoID,I.ItemCode,B.ItemName ,Batch,BatchNew
		   ,PurchaseBillDate,PurchaseVoucherNumber,PurchaseSrlNo
		  ,Quantity,FreeQuantity
		  ,PurchaseSaleRate,EffecivePurchaseSaleRate
		  ,PurchaseSaleTypeCode,SurCharge,PurchaseSaleTax
		  ,LocalCentral,SGST,IGST,CGST
		  ,Amount,Discount,SpecialDiscount,DiscountQuantity,VolumeDiscount
		  ,Scheme1,Scheme2,IsHalfScheme,HalfSchemeRate
		  ,CostAmount,GrossAmount,SchemeAmount,DiscountAmount,SurchargeAmount
		  ,ConversionRate,MRP,ISNULL(ExpiryDate,GETDATE())  ExpiryDate
		  ,SaleRate,WholeSaleRate,SpecialRate
		  ,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn
		  ,TaxAmount
		  ,SpecialDiscountAmount
		  ,VolumeDiscountAmount
		  ,TotalDiscountAmount
		  ,OldPurchaseSaleBookLineItemID  
		  ,ISNULL(BalanceQuantity,0) AS BalanceQuantity
		  ,ISNULL(UsedQuantity,0) AS UsedQuantity
	FROM TempPurchaseSaleBookLineItem I
	INNER JOIN (
		SELECT ItemCode,ItemName  from ItemMaster
	) B ON I.ItemCode = B.ItemCode
	 WHERE PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID
  


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
