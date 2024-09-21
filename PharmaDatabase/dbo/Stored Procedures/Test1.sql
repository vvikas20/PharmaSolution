CREATE PROCEDURE [dbo].[Test1]
	@TableTypePurchaseSaleBookLineItem TableTypePurchaseSaleBookLineItem READONLY
AS
BEGIN	
	BEGIN TRY	
	BEGIN TRAN
	
	
	DECLARE @LineItems AS TABLE
	(
		PurchaseSaleBookLineItemID BIGINT
	)
	
	
	DECLARE @OldQuantity decimal(18,2), @Quantity decimal(18,2),@FreeQuantity decimal(18,2)
	DECLARE @BalanceQuantity decimal(18,2), @NewQuantity decimal(18,2)
	DECLARE @OldFifoId BIGINT,@OldPurchaseSaleBookLineItemID BIGINT
	DECLARE @ItemCode nvarchar(10)


	SELECT 
		@OldPurchaseSaleBookLineItemID = PurchaseSaleBookLineItemID
		,@ItemCode = ItemCode
	FROM @TableTypePurchaseSaleBookLineItem	
	
	Select @OldQuantity = Quantity , @OldFifoId = FifoID 
		--,@OldPurchaseSaleBookLineItemID =PurchaseSaleBookLineItemID
	FROM TempPurchaseSaleBookLineItem WHERE PurchaseSaleBookLineItemID = @OldPurchaseSaleBookLineItemID


	SELECT @BalanceQuantity = BalanceQuanity--,@FreeQuantity = FreeQuantity
	FROM FIFO WHERE FifoID = ISNULL(@OldFifoId,0)
	
	SET @NewQuantity = @Quantity - ISNULL(@OldQuantity,0)
	
	SET @BalanceQuantity = ISNULL(@BalanceQuantity,0)
	
	IF ISNULL(@OldPurchaseSaleBookLineItemID,0) <> 0 
		AND ISNULL(@OldFifoId ,0) <> 0 
		AND ISNULL(@OldQuantity,0) <> ISNULL(@Quantity,0)
		AND @BalanceQuantity > @NewQuantity
	BEGIN
		
			MERGE INTO dbo.TempPurchaseSaleBookLineItem t1
			USING @TableTypePurchaseSaleBookLineItem t2 
			ON t1.PurchaseSaleBookLineItemID = t2.PurchaseSaleBookLineItemID
			WHEN MATCHED THEN 
			UPDATE SET t1.PurchaseSaleBookHeaderID=t2.PurchaseSaleBookHeaderID
				,t1.PurchaseBillDate=t2.PurchaseBillDate
				,t1.PurchaseVoucherNumber=t2.PurchaseVoucherNumber
				,t1.PurchaseSrlNo=t2.PurchaseSrlNo
				--,t1.ItemCode=t2.ItemCode
				--,t1.Batch=t2.Batch
				--,t1.BatchNew=t2.BatchNew
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
				,t1.ModifiedOn=t2.ModifiedOn;
				
			Update FIFO Set BalanceQuanity = BalanceQuanity- @NewQuantity WHERE FifoID = @OldFifoId
			
			INSERT INTO @LineItems(PurchaseSaleBookLineItemID)
			SELECT @OldPurchaseSaleBookLineItemID
		
	END
	ELSE
		BEGIN
		
				IF @NewQuantity > 0
				BEGIN 
				
					DECLARE @FifoID Bigint
					DECLARE @QtytobeInsert decimal(18,2)
			
					WHILE (@NewQuantity > 0)
					BEGIN
						
							SELECT TOP 1 @FifoID = FifoID, @BalanceQuantity = BalanceQuanity FROM
							FIFO WHERE ItemCode = @ItemCode AND BalanceQuanity  > 0
							ORDER BY VoucherDate DESC
						
							IF @NewQuantity > @BalanceQuantity
							BEGIN
								SET @QtytobeInsert = @BalanceQuantity
							END
							ELSE
							BEGIN
								SET @QtytobeInsert = @NewQuantity
							END
							
							MERGE INTO dbo.TempPurchaseSaleBookLineItem t1
							USING 
							(
								SELECT 
									 F.PurchaseSaleBookHeaderID
									 ,F.Fifoid
									,PurchaseBillDate,PurchaseVoucherNumber,PurchaseSrlNo
									,F.ItemCode,F.Batch,BatchNew
									,@QtytobeInsert AS Quantity,FreeQuantity
									,PurchaseSaleRate,EffecivePurchaseSaleRate
									,PurchaseSaleTypeCode,SurCharge
									,L.SalePurchaseTax
									,LocalCentral,SGST,IGST,CGST
									,Amount,Discount,SpecialDiscount,DiscountQuantity,VolumeDiscount
									,F.Scheme1,F.Scheme2,IsHalfScheme,HalfSchemeRate		
									,ConversionRate,F.MRP,F.ExpiryDate
									,F.SaleRate,F.WholeSaleRate,F.SpecialRate
									,CreatedBy,CreatedOn
									,0 AS PurchaseSaleBookLineItemID
								FROM FIFO	F
								INNER JOIN dbo.PurchaseSaleBookLineItem L
								ON F.PurchaseSaleBookHeaderID = L.PurchaseSaleBookHeaderID
								AND F.ItemCode = L.ItemCode
								AND F.Batch = L.Batch
							
							) t2 
							ON t1.PurchaseSaleBookLineItemID = t2.PurchaseSaleBookLineItemID
							WHEN NOT MATCHED THEN
							INSERT (
								 PurchaseSaleBookHeaderID
								 ,Fifoid
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
								,@fifoid
								,t2.PurchaseBillDate,t2.PurchaseVoucherNumber,t2.PurchaseSrlNo
								,t2.ItemCode,t2.Batch,t2.BatchNew
								,t2.Quantity,t2.FreeQuantity
								,t2.PurchaseSaleRate,t2.EffecivePurchaseSaleRate
								,t2.PurchaseSaleTypeCode,t2.SurCharge
								,t2.SalePurchaseTax
								,t2.LocalCentral,t2.SGST,t2.IGST,t2.CGST
								,t2.Amount,t2.Discount,t2.SpecialDiscount,t2.DiscountQuantity,t2.VolumeDiscount
								,t2.Scheme1,t2.Scheme2,t2.IsHalfScheme,t2.HalfSchemeRate		
								,t2.ConversionRate,t2.MRP,t2.ExpiryDate
								,t2.SaleRate,t2.WholeSaleRate,t2.SpecialRate
								,t2.CreatedBy,t2.CreatedOn
							);
							
							SET @NewQuantity = @NewQuantity - @QtytobeInsert
							
							INSERT @LineItems (PurchaseSaleBookLineItemID)
							VALUES (SCOPE_IDENTITY())
							
							Update FIFO Set BalanceQuanity =@QtytobeInsert WHERE FifoID = @FifoID
			
								
					END
				END
				ELSE IF @NewQuantity = 0
					BEGIN
					
							MERGE INTO dbo.TempPurchaseSaleBookLineItem t1
							USING @TableTypePurchaseSaleBookLineItem t2 
							ON t1.PurchaseSaleBookLineItemID = t2.PurchaseSaleBookLineItemID
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
					
							INSERT @LineItems (PurchaseSaleBookLineItemID)
							VALUES (SCOPE_IDENTITY())
					
					END
		END
	
	
	
	
	
	--MERGE INTO dbo.ItemMaster t1
	--USING @TableTypePurchaseSaleBookLineItem t2 
	--ON t1.ItemCode = t2.ItemCode
	--WHEN MATCHED THEN 
	--UPDATE SET t1.PurchaseRate = t2.PurchaseSaleRate
	--		,t1.MRP = t2.MRP
	--		,t1.SaleRate = t2.SaleRate
	--		,t1.SpecialRate = t2.SpecialRate
	--		,t1.WholeSaleRate = t2.WholeSaleRate
	--		,t1.Scheme1 = t2.Scheme1
	--		,t1.Scheme2 = t2.Scheme2
	--		,t1.IsHalfScheme = t2.IsHalfScheme
	--		,t1.DiscountRecieved = t2.Discount
	--		,t1.SpecialDiscountRecieved =t2.SpecialDiscount
	--		,t1.BATCH = t2.BATCH
	--		,t1.ExpiryDate  = t2.ExpiryDate
	--		;
	
	
	
	DECLARE @PurchaseSaleBookHeaderID AS BIGINT
	
	SELECT @PurchaseSaleBookHeaderID = PurchaseSaleBookHeaderID
	FROM @TableTypePurchaseSaleBookLineItem
	
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
	  SELECT CA.PurchaseSaleBookHeaderID
			,CA.PurchaseSaleBookLineItemID
			,FinalAmount
			,CA.GrossAmount
			,CA.SchemeAmount
			,CA.DiscountAmount
			,CA.SpecialDiscountAmount
			,CA.VolumeDiscountAmount
	FROM UDF_GetAmountWithAllDiscountAmounts(@PurchaseSaleBookHeaderID) CA
		--FROM TempPurchaseSaleBookLineItem A
		--CROSS APPLY UDF_GetAmountWithAllDiscountAmounts(A.PurchaseSaleBookLineItemID) CA
		--WHERE A.PurchaseSaleBookLineItemID IN (SELECT PurchaseSaleBookLineItemID FROM @LineItems)

	   SELECT       
		   PurchaseSaleBookHeaderID
		  ,PurchaseSaleBookLineItemID 
		  ,FifoID,I.ItemCode,B.ItemName ,Batch,BatchNew
		  ,Quantity,FreeQuantity
		  ,PurchaseSaleRate,EffecivePurchaseSaleRate
		  ,PurchaseSaleTypeCode,SurCharge
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
	FROM TempPurchaseSaleBookLineItem I
	INNER JOIN (
		SELECT ItemCode,ItemName  from ItemMaster
	) B ON I.ItemCode = B.ItemCode
	 WHERE PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID
	 AND I.PurchaseSaleBookLineItemID IN (SELECT PurchaseSaleBookLineItemID FROM @LineItems)

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
