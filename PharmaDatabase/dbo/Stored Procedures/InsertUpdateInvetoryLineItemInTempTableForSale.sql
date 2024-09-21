CREATE PROCEDURE [dbo].[InsertUpdateInvetoryLineItemInTempTableForSale]
	@TableTypePurchaseSaleBookLineItem TableTypePurchaseSaleBookLineItem READONLY
AS
BEGIN	
	BEGIN TRY	
	BEGIN TRAN
	
	
	DECLARE @LineItems AS TABLE
	(
		PurchaseSaleBookLineItemID BIGINT
	)
	
	DECLARE @LocalCentral NVARCHAR(1)
	
	
	DECLARE @PurchaseSaleBookHeaderID BIGINT
	DECLARE @OldQuantity decimal(18,2), @Quantity decimal(18,2)
	DECLARE @TotalQuantityForItem decimal(18,2)
	DECLARE @OldFreeQuantity decimal(18,2), @FreeQuantity decimal(18,2), @NewFreeQuantity decimal(18,2)
	DECLARE @BalanceQuantity decimal(18,2), @NewQuantity decimal(18,2)
	DECLARE @OldFifoId BIGINT,@OldPurchaseSaleBookLineItemID BIGINT
	DECLARE @ItemCode nvarchar(10)
	
	--GET THE QUANTITY FOR SPECIFIC LINE ITEM
	SELECT @PurchaseSaleBookHeaderID = PurchaseSaleBookHeaderID
		,@OldPurchaseSaleBookLineItemID = PurchaseSaleBookLineItemID
		,@ItemCode = ItemCode
		,@Quantity = ISNULL(Quantity,0)
		,@OldFifoId = FifoID 
		,@FreeQuantity = ISNULL(FreeQuantity,0)
	FROM @TableTypePurchaseSaleBookLineItem		
	
	SELECT @LocalCentral = LocalCentral FROM TempPurchaseSaleBookHeader WHERE PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID
	
	Select @OldQuantity = Quantity 
		   ,@OldFreeQuantity = FreeQuantity
		--,@OldPurchaseSaleBookLineItemID =PurchaseSaleBookLineItemID
	FROM TempPurchaseSaleBookLineItem 
	WHERE PurchaseSaleBookLineItemID = @OldPurchaseSaleBookLineItemID
	
	SELECT @Quantity = ISNULL(@Quantity,0), 
		   @OldFreeQuantity = ISNULL(@OldFreeQuantity,0), 
		   @OldQuantity = ISNULL(@OldQuantity,0),
		   @OldPurchaseSaleBookLineItemID = ISNULL(@OldPurchaseSaleBookLineItemID,0)
	
	IF ( @Quantity < @OldQuantity OR @FreeQuantity < @OldFreeQuantity )
	BEGIN
	
						--SELECT @TotalQuantityForItem = SUM(Quantity)
						--FROM TempPurchaseSaleBookLineItem 
						--WHERE PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID AND ItemCode = @ItemCode
						
						--SET @TotalQuantityForItem  = ISNULL(@TotalQuantityForItem,0) - (@OldQuantity - @Quantity)
						
						--SET @FreeQuantity = dbo.GetFreeQuantity(@ItemCode,@TotalQuantityForItem)
						
						SET @NewFreeQuantity = @OldFreeQuantity - @FreeQuantity
		
						
						MERGE INTO dbo.TempPurchaseSaleBookLineItem t1
						USING @TableTypePurchaseSaleBookLineItem t2 
						ON t1.PurchaseSaleBookLineItemID = t2.PurchaseSaleBookLineItemID
						WHEN MATCHED THEN 
						UPDATE SET t1.PurchaseSaleBookHeaderID=t2.PurchaseSaleBookHeaderID
							,t1.PurchaseBillDate=t2.PurchaseBillDate
							,t1.PurchaseVoucherNumber=t2.PurchaseVoucherNumber
							,t1.PurchaseSrlNo=t2.PurchaseSrlNo
							,t1.Quantity=t2.Quantity
							,t1.FreeQuantity= @FreeQuantity
							,t1.PurchaseSaleRate=t2.PurchaseSaleRate
							,t1.EffecivePurchaseSaleRate=t2.EffecivePurchaseSaleRate
							,t1.PurchaseSaleTypeCode=t2.PurchaseSaleTypeCode
							,t1.SurCharge=t2.SurCharge
							,t1.PurchaseSaleTax=t2.PurchaseSaleTax
							,t1.LocalCentral=@LocalCentral
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
							
						Update FIFO Set BalanceQuanity = BalanceQuanity + (@OldQuantity - @Quantity) + (@OldFreeQuantity - @FreeQuantity) WHERE FifoID = @OldFifoId
						
						INSERT INTO @LineItems(PurchaseSaleBookLineItemID)
						SELECT @OldPurchaseSaleBookLineItemID
	END
	ELSE 
	BEGIN
	
				--SELECT @TotalQuantityForItem = SUM(Quantity)
				--FROM TempPurchaseSaleBookLineItem 
				--WHERE PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID AND ItemCode = @ItemCode
				
				--SET @TotalQuantityForItem  = ISNULL(@TotalQuantityForItem,0) + (@Quantity - @OldQuantity)
				
				--SET @FreeQuantity = dbo.GetFreeQuantity(@ItemCode,@TotalQuantityForItem)
				
				SET @NewFreeQuantity = @FreeQuantity - @OldFreeQuantity			

				SELECT @BalanceQuantity = ISNULL(@BalanceQuantity,0) FROM FIFO WHERE FifoID = ISNULL(@OldFifoId,0)
				
				SET @NewQuantity = @Quantity  - ISNULL(@OldQuantity,0)				
			
				--SELECT @BalanceQuantity, @NewFreeQuantity, @NewQuantity, @OldFifoId, @OldFreeQuantity, @OldQuantity, @FreeQuantity
				
				IF ISNULL(@OldPurchaseSaleBookLineItemID,0) <> 0 
					AND ISNULL(@OldFifoId ,0) <> 0 
					AND ISNULL(@OldQuantity,0) <> ISNULL(@Quantity,0)
					AND @BalanceQuantity > (@NewQuantity + FLOOR(@NewFreeQuantity))
				BEGIN
					
						MERGE INTO dbo.TempPurchaseSaleBookLineItem t1
						USING @TableTypePurchaseSaleBookLineItem t2 
						ON t1.PurchaseSaleBookLineItemID = t2.PurchaseSaleBookLineItemID
						WHEN MATCHED THEN 
						UPDATE SET t1.PurchaseSaleBookHeaderID=t2.PurchaseSaleBookHeaderID
							,t1.PurchaseBillDate=t2.PurchaseBillDate
							,t1.PurchaseVoucherNumber=t2.PurchaseVoucherNumber
							,t1.PurchaseSrlNo=t2.PurchaseSrlNo
							,t1.Quantity=t2.Quantity
							,t1.FreeQuantity= t1.FreeQuantity + FLOOR(@NewFreeQuantity)
							,t1.PurchaseSaleRate=t2.PurchaseSaleRate
							,t1.EffecivePurchaseSaleRate=t2.EffecivePurchaseSaleRate
							,t1.PurchaseSaleTypeCode=t2.PurchaseSaleTypeCode
							,t1.SurCharge=t2.SurCharge
							,t1.PurchaseSaleTax=t2.PurchaseSaleTax
							,t1.LocalCentral=@LocalCentral
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
							
						Update FIFO Set BalanceQuanity = BalanceQuanity - @NewQuantity - FLOOR(@NewFreeQuantity) WHERE FifoID = @OldFifoId -- 
						
						INSERT INTO @LineItems(PurchaseSaleBookLineItemID)
						SELECT @OldPurchaseSaleBookLineItemID
					
				END
				ELSE
					BEGIN
					
							IF ((@NewQuantity + FLOOR(@NewFreeQuantity)) > 0)
							BEGIN 
							
								DECLARE @FifoID Bigint
								DECLARE @QtytobeInsert decimal(18,2)
								DECLARE @FreeQtyToBeInsert decimal(18,2)
								
								WHILE ((@NewQuantity + FLOOR(@NewFreeQuantity)) > 0)
								BEGIN

										SELECT TOP 1 @FifoID = FifoID,@BalanceQuantity = BalanceQuanity FROM FIFO
										WHERE ItemCode = @ItemCode AND BalanceQuanity > 0
										ORDER BY FifoID ASC
									
										IF @NewQuantity >= @BalanceQuantity
										BEGIN
											SET @QtytobeInsert = @BalanceQuantity
											SET @FreeQtyToBeInsert = 0
										END
										ELSE IF (@NewQuantity <= @BalanceQuantity AND (@NewQuantity + FLOOR(@NewFreeQuantity)) >= @BalanceQuantity)
										BEGIN
												SET @QtytobeInsert = @NewQuantity
												SET @FreeQtyToBeInsert = @BalanceQuantity - @NewQuantity
										END
										ELSE IF (@NewQuantity <= @BalanceQuantity AND (@NewQuantity + FLOOR(@NewFreeQuantity)) <= @BalanceQuantity)
										BEGIN
												SET @QtytobeInsert = @NewQuantity
												SET @FreeQtyToBeInsert = FLOOR(@NewFreeQuantity)
										END
										--ELSE IF (@NewQuantity = 0 AND (FLOOR(@NewFreeQuantity) > @BalanceQuantity))
										--BEGIN
										--		SET @QtytobeInsert = 0
										--		SET @FreeQtyToBeInsert = @BalanceQuantity
										--END
										--ELSE IF (@NewQuantity = 0 AND (FLOOR(@NewFreeQuantity) < @BalanceQuantity))
										--BEGIN
										--	SET @QtytobeInsert = 0
										--	SET @FreeQtyToBeInsert = FLOOR(@NewFreeQuantity)
										--END
										
										
										IF EXISTS(Select * FROM TempPurchaseSaleBookLineItem Where FifoID = @FifoID AND PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID)
										BEGIN
												IF(ISNULL(@fifoID,0) = ISNULL(@OldfifoID,0))
												BEGIN
														MERGE INTO dbo.TempPurchaseSaleBookLineItem t1
														USING @TableTypePurchaseSaleBookLineItem t2 
														ON t1.PurchaseSaleBookLineItemID = t2.PurchaseSaleBookLineItemID
														WHEN MATCHED THEN 
														UPDATE SET t1.PurchaseSaleBookHeaderID=t2.PurchaseSaleBookHeaderID
															,t1.PurchaseBillDate=t2.PurchaseBillDate
															,t1.PurchaseVoucherNumber=t2.PurchaseVoucherNumber
															,t1.PurchaseSrlNo=t2.PurchaseSrlNo
															,t1.Quantity= t1.Quantity + ISNULL(@QtytobeInsert,0)
															,t1.FreeQuantity=t1.FreeQuantity + @FreeQtyToBeInsert
															,t1.PurchaseSaleRate=t2.PurchaseSaleRate
															,t1.EffecivePurchaseSaleRate=t2.EffecivePurchaseSaleRate
															,t1.PurchaseSaleTypeCode=t2.PurchaseSaleTypeCode
															,t1.SurCharge=t2.SurCharge
															,t1.PurchaseSaleTax=t2.PurchaseSaleTax
															,t1.LocalCentral=@LocalCentral
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
															
												INSERT Into @LineItems (PurchaseSaleBookLineItemID)
												VALUES (@OldPurchaseSaleBookLineItemID)
										
											END
											ELSE
											BEGIn
												UPDATE TempPurchaseSaleBookLineItem 
													Set Quantity = Quantity + ISNULL(@QtytobeInsert,0) 
													,FreeQuantity  = FreeQuantity + @FreeQtyToBeInsert
												WHERE FifoID = @FifoID AND PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID

												Insert Into  @LineItems (PurchaseSaleBookLineItemID)
												SELECT PurchaseSaleBookLineItemID FROM TempPurchaseSaleBookLineItem WHERE FifoID = @FifoID AND PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID
											END
										END
										ELSE
										BEGIN
											MERGE INTO dbo.TempPurchaseSaleBookLineItem t1
											USING 
											(
												SELECT 
													 @PurchaseSaleBookHeaderID AS PurchaseSaleBookHeaderID
													 ,F.Fifoid
													,F.VoucherDate AS PurchaseBillDate
													,F.VoucherNumber AS PurchaseVoucherNumber
													,F.SRLNO AS  PurchaseSrlNo
													,F.ItemCode,F.Batch,BatchNew
													,@QtytobeInsert AS Quantity,@FreeQtyToBeInsert as FreeQuantity
													,PurchaseSaleRate,EffecivePurchaseSaleRate
													,ALM.AccountLedgerCode AS PurchaseSaleTypeCode,SurCharge
													,L.SalePurchaseTax
													,LocalCentral,SGST,IGST,CGST
													,Amount
													,COALESCE(L.Discount,0) AS Discount
													,COALESCE(L.SpecialDiscount,0) AS SpecialDiscount
													,COALESCE(L.DiscountQuantity,0) AS DiscountQuantity
													,COALESCE(L.VolumeDiscount,0) AS VolumeDiscount
													,F.Scheme1,F.Scheme2
													,0 AS IsHalfScheme
													,0 AS HalfSchemeRate		
													,I.ConversionRate,F.MRP,F.ExpiryDate
													,COALESCE(F.SaleRate,I.SaleRate) AS SaleRate
													,F.WholeSaleRate,F.SpecialRate
													,L.CreatedBy,L.CreatedOn
													,0 AS PurchaseSaleBookLineItemID
												FROM FIFO	F
												INNER JOIN dbo.PurchaseSaleBookLineItem L ON F.PurchaseSaleBookHeaderID = L.PurchaseSaleBookHeaderID
												AND F.ItemCode = L.ItemCode
												AND F.Batch = L.Batch
												INNER JOIN ItemMaster I ON I.ItemCode = F.ItemCode
												INNER JOIN AccountLedgerMaster ALM ON ALM.AccountLedgerID = I.SaleTypeId
												WHERE F.FifoID = @fifoid
										
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
												,@LocalCentral,t2.SGST,t2.IGST,t2.CGST
												,t2.Amount,t2.Discount,t2.SpecialDiscount,t2.DiscountQuantity,t2.VolumeDiscount
												,t2.Scheme1,t2.Scheme2,t2.IsHalfScheme,t2.HalfSchemeRate		
												,t2.ConversionRate,t2.MRP,t2.ExpiryDate
												,t2.SaleRate,t2.WholeSaleRate,t2.SpecialRate
												,t2.CreatedBy,t2.CreatedOn
											);
					
										INSERT @LineItems (PurchaseSaleBookLineItemID)
										VALUES (SCOPE_IDENTITY())
										
										END					
										SET @NewQuantity = @NewQuantity - @QtytobeInsert 
										SET @NewFreeQuantity = @NewFreeQuantity - @FreeQtyToBeInsert										
										
										Update FIFO Set BalanceQuanity = (BalanceQuanity - @QtytobeInsert - FLOOR(@FreeQtyToBeInsert)) WHERE FifoID = @FifoID

								END
							END
							ELSE IF ((@NewQuantity + FLOOR(@NewFreeQuantity)) = 0)
								BEGIN
								
										MERGE INTO dbo.TempPurchaseSaleBookLineItem t1
										USING @TableTypePurchaseSaleBookLineItem t2 
										ON t1.PurchaseSaleBookLineItemID = t2.PurchaseSaleBookLineItemID
										WHEN MATCHED THEN
											UPDATE SET t1.PurchaseSaleBookHeaderID=t2.PurchaseSaleBookHeaderID
											,t1.PurchaseBillDate=t2.PurchaseBillDate
											,t1.PurchaseVoucherNumber=t2.PurchaseVoucherNumber
											,t1.PurchaseSrlNo=t2.PurchaseSrlNo
											--,t1.Quantity= t1.Quantity + t2.Quantity
											--,t1.FreeQuantity=t1.FreeQuantity + t2.FreeQuantity
											,t1.PurchaseSaleRate=t2.PurchaseSaleRate
											,t1.EffecivePurchaseSaleRate=t2.EffecivePurchaseSaleRate
											,t1.PurchaseSaleTypeCode=t2.PurchaseSaleTypeCode
											,t1.SurCharge=t2.SurCharge
											,t1.PurchaseSaleTax=t2.PurchaseSaleTax
											,t1.LocalCentral=@LocalCentral
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
											,PurchaseBillDate,PurchaseVoucherNumber,PurchaseSrlNo,FifoID
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
											,t2.PurchaseBillDate,t2.PurchaseVoucherNumber,t2.PurchaseSrlNo, t2.FifoID
											,t2.ItemCode,t2.Batch,t2.BatchNew
											,t2.Quantity,t2.FreeQuantity
											,t2.PurchaseSaleRate,t2.EffecivePurchaseSaleRate
											,t2.PurchaseSaleTypeCode,t2.SurCharge
											,t2.PurchaseSaleTax
											,@LocalCentral,t2.SGST,t2.IGST,t2.CGST
											,t2.Amount,t2.Discount,t2.SpecialDiscount,t2.DiscountQuantity,t2.VolumeDiscount
											,t2.Scheme1,t2.Scheme2,t2.IsHalfScheme,t2.HalfSchemeRate		
											,t2.ConversionRate,t2.MRP,t2.ExpiryDate
											,t2.SaleRate,t2.WholeSaleRate,t2.SpecialRate
											,t2.CreatedBy,t2.CreatedOn
										);
										
										
										
										IF(@OldPurchaseSaleBookLineItemID > 0)
										BEGIN
											INSERT @LineItems (PurchaseSaleBookLineItemID)
											VALUES (@OldPurchaseSaleBookLineItemID)
										END
										ELSE
										BEGIN
												INSERT @LineItems (PurchaseSaleBookLineItemID)
												VALUES (SCOPE_IDENTITY())
										END
								END
					END
	END
	
	
	MERGE INTO dbo.ItemMaster t1
	USING @TableTypePurchaseSaleBookLineItem t2 
	ON t1.ItemCode = t2.ItemCode
	WHEN MATCHED THEN 
	UPDATE SET t1.SaleRate = t2.SaleRate;
			

	COMMIT TRAN 
	
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


	--IF EXISTS(Select 1 FROM @LineItems)
	--BEGIN
	--	INSERT INTO @LineItems
	--	SELECT PurchaseSaleBookLineItemID FROM TempPurchaseSaleBookLineItem 
	--	WHERE ItemCode = @ItemCode AND PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID
	--	AND PurchaseSaleBookLineItemID NOT IN (SELECT PurchaseSaleBookLineItemID FROM @LineItems)
	--END
	
		
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
	  SELECT A.PurchaseSaleBookHeaderID
			,A.PurchaseSaleBookLineItemID
			,SUM(ISNULL(FinalAmount,0))
			,SUM(ISNULL(CA.GrossAmount,0))
			,SUM(ISNULL(CA.SchemeAmount,0))
			,SUM(ISNULL(CA.DiscountAmount,0))
			,SUM(ISNULL(CA.SpecialDiscountAmount,0))
			,SUM(ISNULL(CA.VolumeDiscountAmount,0))
		--FROM --UDF_GetAmountWithAllDiscountAmounts(@PurchaseSaleBookHeaderID) CA
		FROM TempPurchaseSaleBookLineItem A
		OUTER APPLY UDF_GetAmountWithAllDiscountAmounts(@PurchaseSaleBookHeaderID) CA
		GROUP BY A.PurchaseSaleBookHeaderID ,A.PurchaseSaleBookLineItemID
		--WHERE A.PurchaseSaleBookLineItemID IN (SELECT PurchaseSaleBookLineItemID FROM @LineItems)
	
	
	   SELECT    DISTINCT   
		   I.PurchaseSaleBookHeaderID
		  ,I.PurchaseSaleBookLineItemID 
		  ,I.FifoID,I.ItemCode,B.ItemName ,I.Batch,BatchNew
		  ,I.Quantity,FreeQuantity
		  ,PurchaseSaleRate,EffecivePurchaseSaleRate
		  ,PurchaseSaleTypeCode,SurCharge
		  ,LocalCentral,SGST,IGST,CGST
		  ,Amount,Discount,SpecialDiscount,DiscountQuantity,VolumeDiscount
		  ,I.Scheme1,I.Scheme2,IsHalfScheme,HalfSchemeRate
		  ,CostAmount
		  ,ConversionRate,I.MRP,I.ExpiryDate
		  ,I.SaleRate,I.WholeSaleRate,I.SpecialRate
		  ,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn
		  ,OldPurchaseSaleBookLineItemID  
		  ,F.BalanceQuanity
		  ,UsedQuantity
		  ,PurchaseBillDate
		  ,PurchaseVoucherNumber
		  ,PurchaseSrlNo
		  ,PurchaseSaleTax AS SalePurchaseTax
		  ,AMT.FinalAmount AS BillAmount
			,0 AS CostAmount
			,(AMT.FinalAmount * .01 * I.PurchaseSaleTax) As TaxAmount			
			,AMT.GrossAmount
			,AMT.SchemeAmount
			,AMT.DiscountAmount
			,AMT.SpecialDiscountAmount
			,AMT.VolumeDiscountAmount
			,(AMT.DiscountAmount + AMT.SpecialDiscountAmount + AMT.VolumeDiscountAmount) AS TotalDiscountAmount
	FROM TempPurchaseSaleBookLineItem I
	INNER JOIN FIFO F on I.FifoID = F.FifoID
	INNER JOIN (
		SELECT ItemCode,ItemName  from ItemMaster
	) B ON I.ItemCode = B.ItemCode
	INNER JOIN @TempTableAmountWithAllDiscountAmounts AMT
	ON I.PurchaseSaleBookHeaderID = AMT.PurchaseSaleBookHeaderID
			AND I.PurchaseSaleBookLineItemID = AMT.PurchaseSaleBookLineItemID
	 WHERE I.PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID
	 AND I.ItemCode = @ItemCode
	
	UNION ALL
	 
	 SELECT 
		  Amt4.PurchaseSaleBookHeaderID
		 ,0 AS PurchaseSaleBookLineItemID
		  ,0 AS FifoID,NULL AS ItemCode,NULL AS ItemName ,NULL AS Batch,NULL AS BatchNew
		  ,0 AS Quantity,0 AS FreeQuantity
		  ,0 AS  PurchaseSaleRate,0 AS EffecivePurchaseSaleRate
		  ,'' AS PurchaseSaleTypeCode,0 AS SurCharge
		  ,NULL AS LocalCentral,0 AS SGST,0 AS IGST,0 AS CGST
		  ,0 AS Amount,0 AS Discount,0 AS SpecialDiscount,0 AS DiscountQuantity,0 AS VolumeDiscount
		  ,0 AS Scheme1,0 AS Scheme2,NULL AS IsHalfScheme,0 AS HalfSchemeRate
		  ,0 AS CostAmount
		  ,0 AS ConversionRate,0 AS MRP,NULL AS ExpiryDate
		  ,0 AS SaleRate,0 AS WholeSaleRate,0 AS SpecialRate
		  ,NULL AS CreatedBy,NULL AS CreatedOn,NULL AS ModifiedBy,NULL AS ModifiedOn
		  ,0 AS OldPurchaseSaleBookLineItemID  
		  ,0 AS BalanceQuanity
		  ,0 AS UsedQuantity
		  ,NULL AS PurchaseBillDate
		  ,NULL AS PurchaseVoucherNumber
		  ,0 AS PurchaseSrlNo
		  ,0 AS SalePurchaseTax
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

	   
    END TRY
    BEGIN CATCH    
		ROLLBACK TRAN 
		DECLARE @ErrorNumber INT = ERROR_NUMBER();
		DECLARE @ErrorMessage NVARCHAR(1000) = ERROR_MESSAGE() 
		RAISERROR('Error Number-%d : Error Message-%s', 16, 1, 
		@ErrorNumber, @ErrorMessage)   
    END CATCH
	
	
END
