CREATE PROCEDURE [dbo].[SavePurchaseEntryData] 
	@PurchaseSaleBookHeaderID INT
AS
BEGIN
	SET NOCOUNT ON;

BEGIN TRY	
	BEGIN TRAN
	
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
	
		DECLARE @VoucherNumber NVARCHAR(8) = '00000000'		
		DECLARE @MaxVoucher INT = 0
		
		SELECT @MaxVoucher = (ISNULL(COUNT(PurchaseSaleBookHeaderID),0) + 1) FROM dbo.PurchaseSaleBookHeader
		WHERE VoucherTypeCode = (SELECT TOP 1 VoucherTypeCode FROM TempPurchaseSaleBookHeader 
		WHERE PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID)
		
		SET @VoucherNumber = RIGHT((@VoucherNumber + CONVERT(VARCHAR,@MaxVoucher)),8)
		
		MERGE INTO dbo.PurchaseSaleBookHeader t1
		USING 
		(	
			SELECT 
				@VoucherNumber AS VoucherNumber,
				 VoucherTypeCode,VoucherDate
				,DueDate,PurchaseBillNo,LedgerType,LedgerTypeCode
				,Amount01,Amount02,Amount03,Amount04,Amount05,Amount06,Amount07
				,SGST01,SGST02,SGST03,SGST04,SGST05,SGST06,SGST07
				,IGST01,IGST02,IGST03,IGST04,IGST05,IGST06,IGST07
				,CGST01,CGST02,CGST03,CGST04,CGST05,CGST06,CGST07
				,TotalTaxAmount,TotalBillAmount
				,(CA.TotalGrossAmount - CA.TotalSchemeAmount - CA.TotalDiscountAmount) AS TotalCostAmount
				,CA.TotalGrossAmount,CA.TotalSchemeAmount,CA.TotalDiscountAmount,OtherAmount				
				,CL.AreaId
				,FreshBreakageExcess
				,ReturnBillNo,ReturBillDate,LocalCentral
				,OrderNumber,ChallanNumber,Message
				,Deliveryddress,DeliveredBy
				,CourierName,CourierDate,CourierWeight
				,PurchaseEntryFormID,LastBalance
				,A.CreatedBy,A.CreatedOn,A.ModifiedBy,A.ModifiedOn 
				,A.OldPurchaseSaleBookHeaderID
			FROM TempPurchaseSaleBookHeader A
			CROSS APPLY
			(
				SELECT 
					 SUM(B.GrossAmount) AS TotalGrossAmount
					,SUM(B.SchemeAmount) AS TotalSchemeAmount
					,SUM(B.DiscountAmount + B.SpecialDiscountAmount + b.VolumeDiscountAmount) AS TotalDiscountAmount
				 FROM @TempTableAmountWithAllDiscountAmounts B
				WHERE B.PurchaseSaleBookHeaderID = A.PurchaseSaleBookHeaderID 
			
			) CA
			LEFT OUTER JOIN 
			SupplierLedger CL ON A.LedgerTypeCode = CL.SupplierLedgerCode
			WHERE A.PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID
		) AS t2 ON t1.PurchaseSaleBookHeaderID = t2.OldPurchaseSaleBookHeaderID
		WHEN MATCHED THEN 
	    UPDATE SET 
			 t1.VoucherDate	=t2.VoucherDate
			,t1.DueDate	=t2.DueDate,t1.PurchaseBillNo=t2.PurchaseBillNo
			,t1.LedgerType	=t2.LedgerType,t1.LedgerTypeCode=t2.LedgerTypeCode
			,t1.Amount01=t2.Amount01,t1.Amount02=t2.Amount02
			,t1.Amount03=t2.Amount03,t1.Amount04=t2.Amount04
			,t1.Amount05=t2.Amount05,t1.Amount06=t2.Amount06,t1.Amount07=t2.Amount07
			,t1.SGST01=t2.SGST01,t1.SGST02=t2.SGST02
			,t1.SGST03=t2.SGST03,t1.SGST04=t2.SGST04
			,t1.SGST05=t2.SGST05,t1.SGST06=t2.SGST06,t1.SGST07=t2.SGST07
			,t1.IGST01=t2.IGST01,t1.IGST02=t2.IGST02
			,t1.IGST03=t2.IGST03,t1.IGST04=t2.IGST04
			,t1.IGST05=t2.IGST05,t1.IGST06=t2.IGST06,t1.IGST07=t2.IGST07
			,t1.CGST01=t2.CGST01,t1.CGST02=t2.CGST02
			,t1.CGST03=t2.CGST03,t1.CGST04=t2.CGST04
			,t1.CGST05=t2.CGST05,t1.CGST06=t2.CGST06,t1.CGST07=t2.CGST07
			,t1.TotalTaxAmount=t2.TotalTaxAmount,t1.TotalBillAmount=t2.TotalBillAmount
			,t1.TotalCostAmount=t2.TotalCostAmount,t1.TotalGrossAmount=t2.TotalGrossAmount
			,t1.TotalSchemeAmount=t2.TotalSchemeAmount,t1.TotalDiscountAmount=t2.TotalDiscountAmount
			,t1.OtherAmount=t2.OtherAmount
			,t1.AreaId=t2.AreaId,t1.PurchaseSaleEntryFormID=t2.PurchaseEntryFormID				
		WHEN NOT MATCHED THEN
		INSERT
           (VoucherNumber,VoucherTypeCode,VoucherDate
           ,DueDate,PurchaseBillNo,LedgerType,LedgerTypeCode
           ,Amount01,Amount02,Amount03,Amount04,Amount05,Amount06,Amount07
           ,SGST01,SGST02,SGST03,SGST04,SGST05,SGST06,SGST07
           ,IGST01,IGST02,IGST03,IGST04,IGST05,IGST06,IGST07
           ,CGST01,CGST02,CGST03,CGST04,CGST05,CGST06,CGST07
           ,TotalTaxAmount,TotalBillAmount,TotalCostAmount
           ,TotalGrossAmount,TotalSchemeAmount,TotalDiscountAmount,OtherAmount          
           ,AreaId,FreshBreakageExcess
           ,ReturnBillNo,ReturBillDate,LocalCentral
           ,OrderNumber,ChallanNumber,Message
           ,Deliveryddress,DeliveredBy
           ,CourierName,CourierDate,CourierWeight
           ,PurchaseSaleEntryFormID,LastBalance
           ,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn
          )
          VALUES
          (
		 	t2.VoucherNumber ,t2.VoucherTypeCode,t2.VoucherDate
           ,t2.DueDate,t2.PurchaseBillNo,t2.LedgerType,t2.LedgerTypeCode
           ,t2.Amount01,t2.Amount02,t2.Amount03,t2.Amount04,t2.Amount05,t2.Amount06,t2.Amount07
           ,t2.SGST01,t2.SGST02,t2.SGST03,t2.SGST04,t2.SGST05,t2.SGST06,t2.SGST07
           ,t2.IGST01,t2.IGST02,t2.IGST03,t2.IGST04,t2.IGST05,t2.IGST06,t2.IGST07
           ,t2.CGST01,t2.CGST02,t2.CGST03,t2.CGST04,t2.CGST05,t2.CGST06,t2.CGST07
           ,t2.TotalTaxAmount,t2.TotalBillAmount,t2.TotalCostAmount
           ,t2.TotalGrossAmount,t2.TotalSchemeAmount,t2.TotalDiscountAmount,t2.OtherAmount
           ,t2.AreaId,t2.FreshBreakageExcess
           ,t2.ReturnBillNo,t2.ReturBillDate,t2.LocalCentral
           ,t2.OrderNumber,t2.ChallanNumber,t2.Message
           ,t2.Deliveryddress,t2.DeliveredBy
           ,t2.CourierName,t2.CourierDate,t2.CourierWeight
           ,t2.PurchaseEntryFormID,t2.LastBalance
           ,t2.CreatedBy,t2.CreatedOn,t2.ModifiedBy,t2.ModifiedOn
          );
		
		PRINT 'INSRT IN Purchase Header Complete'
		
		DECLARE @NewPurchaseSaleHeaderID bigint
		DECLARE @OldPurchaseSaleHeaderID bigint
		
		SELECT @OldPurchaseSaleHeaderID = OldPurchaseSaleBookHeaderID FROM TempPurchaseSaleBookHeader
		WHERE PurchaseSaleBookHeaderID  = @PurchaseSaleBookHeaderID
		
		IF @OldPurchaseSaleHeaderID IS NULL
		BEGIN
			SET @NewPurchaseSaleHeaderID = SCOPE_IDENTITY()
		END
		
		------------------Header Merge Completed----------------------------------------------
		
		DECLARE @UsedFifoIds AS Table ( FifoId bigint )
		DECLARE @DeleteFifoIds AS Table ( FifoId bigint )
		
		DECLARE @DeletePurchaseSaleBookLineItemIds AS Table ( PurchaseSaleBookLineItemId bigint )
		
		INSERT INTO @UsedFifoIds
		SELECT DISTINCT FifoID FROM TempPurchaseSaleBookLineItem 
		WHERE PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID
		AND FifoID IN (SELECT DIStinct FifoID FROM PurchaseSaleBookLineItem)
						--WHERE PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID))
		
		
		INSERT INTO @DeleteFifoIds 
		SELECT DISTINCT FIFOID FROM FIFO WHERE PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID)
		AND FifoID NOT IN (SELECT DIStinct FifoID FROM TempPurchaseSaleBookLineItem WHERE PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID)
						
		INSERT INTO @DeletePurchaseSaleBookLineItemIds 
		SELECT PurchaseSaleBookLineItemId FROM PurchaseSaleBookLineItem L
		INNER JOIN FIFO F  ON L.PurchaseSaleBookHeaderID = F.PurchaseSaleBookHeaderID AND L.PurchaseSrlNo = F.SRLNO
		WHERE F.PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID)
		AND F.FifoID NOT IN (SELECT DIStinct FifoID FROM TempPurchaseSaleBookLineItem WHERE PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID)			
		
		
		DELETE FROM FIFO WHERE FifoID IN (SELECT FifoID FROM @DeleteFifoIds)
		DELETE FROM PurchaseSaleBookLineItem WHERE PurchaseSaleBookLineItemID IN (SELECT PurchaseSaleBookLineItemID FROM @DeletePurchaseSaleBookLineItemIds)
						
		
		--DELETE FROM dbo.FIFO WHERE PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID)
		
		--DELETE FROM dbo.PurchaseSaleBookLineItem WHERE PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID)
		
				
		DECLARE  @MaxRowNumber INT
		
		SELECT @MaxRowNumber = ISNULL(MAX(PurchaseSrlNo),0) FROM PurchaseSaleBookLineItem WHERE 
					PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID)
		
		MERGE INTO dbo.PurchaseSaleBookLineItem t1
		USING 
		(
			  SELECT COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID) AS PurchaseSaleBookHeaderID
					
				  ,FifoID,PurchaseBillDate,PurchaseVoucherNumber
				  ,@MaxRowNumber + ROW_NUMBER() OVER(Partition By A.PurchaseSaleBookHeaderID ORDER BY A.PurchaseSaleBookLineItemID) 
				  as PurchaseSrlNoNew
				  ,A.PurchaseSrlNo
				  ,ItemCode,Batch,Batch AS BatchNew,Quantity,FreeQuantity
				  ,PurchaseSaleRate,EffecivePurchaseSaleRate,PurchaseSaleTypeCode
				  ,SurCharge,PurchaseSaleTax,LocalCentral
				  ,CA.SGST,CA.IGST,CA.CGST,Amount
				  ,Discount,SpecialDiscount,DiscountQuantity,VolumeDiscount
				  ,Scheme1,Scheme2,IsHalfScheme,HalfSchemeRate
				  ,A.CostAmount,CA.GrossAmount,CA.SchemeAmount,CA.DiscountAmount
				   ,(ISNULL(CA.SGST,0) + ISNULL(CA.IGST,0) + ISNULL(CA.CGST,0)) AS TaxAmount  
				   ,CA.SpecialDiscountAmount,CA.VolumeDiscountAmount,CA.TotalDiscountAmount
				  ,ConversionRate,MRP,ExpiryDate,SaleRate,WholeSaleRate,SpecialRate
				  ,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn
				  ,OldPurchaseSaleBookLineItemID
				--  ,ISNULL(UsedQuantity,0) AS UsedQuantity
			  FROM dbo.TempPurchaseSaleBookLineItem A
			  CROSS APPLY 
			  (
					SELECT 
							 B.GrossAmount
							,B.SchemeAmount
							,B.DiscountAmount
							,B.SpecialDiscountAmount
							,B.VolumeDiscountAmount
							,(B.DiscountAmount + b.SpecialDiscountAmount + b.VolumeDiscountAmount) AS TotalDiscountAmount
							,CASE WHEN A.LocalCentral = 'L' THEN (B.FinalAmount * A.PurchaseSaleTax * 0.01 * 0.5) ELSE NULL END AS SGST
							,CASE WHEN A.LocalCentral = 'L' THEN (B.FinalAmount * A.PurchaseSaleTax * 0.01 * 0.5) ELSE NULL END AS CGST
							,CASE WHEN A.LocalCentral = 'C' THEN (B.FinalAmount * A.PurchaseSaleTax * .01) ELSE NULL END AS IGST				
					 FROM @TempTableAmountWithAllDiscountAmounts B
					WHERE B.PurchaseSaleBookHeaderID = A.PurchaseSaleBookHeaderID
					AND B.PurchaseSaleBookLineItemID = A.PurchaseSaleBookLineItemID
			  ) CA
			  WHERE A.PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID
		) t2 ON t1.PurchaseSaleBookHeaderID = t2.PurchaseSaleBookHeaderID 
				AND t1.PurchaseSaleBookLineItemID = t2.OldPurchaseSaleBookLineItemID
				--AND t1.FifoID = t2.FifoId
		WHEN MATCHED THEN
			UPDATE SET 
				-- t1.FifoID= t2.FifoID
				--,
				--t1.PurchaseBillDate = t2.PurchaseBillDate
				--,
				t1.Batch=t2.Batch
				,t1.BatchNew=t2.BatchNew
				,t1.Quantity= t2.Quantity
				--,t1.PurchaseSrlNo = COALESCE(t2.PurchaseSrlNo,t2.PurchaseSrlNoNew)
				,t1.FreeQuantity=t2.FreeQuantity
				,t1.PurchaseSaleRate=t2.PurchaseSaleRate
				,t1.EffecivePurchaseSaleRate=t2.EffecivePurchaseSaleRate
				,t1.PurchaseSaleTypeCode=t2.PurchaseSaleTypeCode
				,t1.SurCharge=t2.SurCharge
				,t1.SalePurchaseTax=t2.PurchaseSaleTax
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
				,t1.CostAmount=t2.CostAmount
				,t1.GrossAmount=t2.GrossAmount
				,t1.SchemeAmount=t2.SchemeAmount
				,t1.DiscountAmount=t2.DiscountAmount
				,t1.TaxAmount=t2.TaxAmount
				,t1.SpecialDiscountAmount=t2.SpecialDiscountAmount
				,t1.VolumeDiscountAmount=t2.VolumeDiscountAmount
				,t1.TotalDiscountAmount	=t2.TotalDiscountAmount
				,t1.ConversionRate	=t2.ConversionRate
				,t1.MRP=t2.MRP
				,t1.ExpiryDate=t2.ExpiryDate
				,t1.SaleRate=t2.SaleRate
				,t1.WholeSaleRate=t2.WholeSaleRate
				,t1.SpecialRate=t2.SpecialRate
		WHEN NOT MATCHED THEN
			INSERT 
			(
				PurchaseSaleBookHeaderID
			   ,PurchaseVoucherNumber,PurchaseSrlNo
			   ,ItemCode,Batch,BatchNew,Quantity,FreeQuantity
			   ,PurchaseSaleRate,EffecivePurchaseSaleRate,PurchaseSaleTypeCode
			   ,SurCharge,SalePurchaseTax,LocalCentral
			   ,SGST,IGST,CGST,Amount
			   ,Discount,SpecialDiscount,DiscountQuantity,VolumeDiscount
			   ,Scheme1,Scheme2,IsHalfScheme,HalfSchemeRate
			   ,CostAmount,GrossAmount,SchemeAmount,DiscountAmount
			   ,TaxAmount,SpecialDiscountAmount,VolumeDiscountAmount,TotalDiscountAmount
			   ,ConversionRate,MRP,ExpiryDate,SaleRate,WholeSaleRate,SpecialRate
			   ,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn
			)
			VALUES
			(
				PurchaseSaleBookHeaderID
			   ,PurchaseVoucherNumber, COALESCE(PurchaseSrlNo,PurchaseSrlNoNew)
			   ,PurchaseSaleRate,EffecivePurchaseSaleRate,PurchaseSaleTypeCode
			   ,SurCharge,PurchaseSaleTax,LocalCentral
			   ,SGST,IGST,CGST,Amount
			   ,Discount,SpecialDiscount,DiscountQuantity,VolumeDiscount
			   ,Scheme1,Scheme2,IsHalfScheme,HalfSchemeRate
			   ,CostAmount,GrossAmount,SchemeAmount,DiscountAmount
			   ,TaxAmount,SpecialDiscountAmount,VolumeDiscountAmount,TotalDiscountAmount
			   ,ConversionRate,MRP,ExpiryDate,SaleRate,WholeSaleRate,SpecialRate
			   ,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn
			)
		;
		
		PRINT 'INSRT IN Purchase LINE ITEM Complete'
	
		--DELETE FROM dbo.FIFO WHERE PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID)
		
		MERGE INTO dbo.FIFO t1
		USING 
		(
			SELECT 
				I.PurchaseSaleBookHeaderID,H.VoucherNumber ,H.VoucherDate         
			  -- ,ROW_NUMBER() OVER(Partition By I.PurchaseSaleBookHeaderID ORDER BY I.PurchaseSaleBookLineItemID) as SRLNO
			   ,I.PurchaseSrlNo AS SRLNO
			   ,I.ItemCode,H.PurchaseBillNo
			   ,I.Batch,I.ExpiryDate
			   ,(I.Quantity + ISNULL(I.FreeQuantity,0)) AS Quantity
			   ,(I.Quantity + ISNULL(I.FreeQuantity,0) - ISNULL(T.UsedQuantity,0)) AS BalanceQuanity
			   ,I.PurchaseSaleRate,I.EffecivePurchaseSaleRate
			   ,I.SaleRate,I.WholeSaleRate,I.SpecialRate,I.MRP
			   ,I.Scheme1,I.Scheme2, 0 as IsOnHold 
			   ,ISNULL(T.FifoID ,0) AS FifoID
		   From PurchaseSaleBookLineItem I
		   Inner JOIN PurchaseSaleBookHeader H ON I.PurchaseSaleBookHeaderID = H.PurchaseSaleBookHeaderID
		   LEFT OUTER JOIN TempPurchaseSaleBookLineItem T ON I.PurchaseSaleBookLineItemID = T.OldPurchaseSaleBookLineItemID
		   WHERE I.PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID)
		) t2 ON t1.PurchaseSaleBookHeaderID = t2.PurchaseSaleBookHeaderID 
				AND t1.FifoID = t2.FifoID
		WHEN MATCHED THEN
		UPDATE SET 
				t1.PurchaseBillNo = t2.PurchaseBillNo,
				t1.Batch = t2.Batch,
				t1.ExpiryDate = t2.ExpiryDate,
				t1.Quantity = t2.Quantity,
				t1.BalanceQuanity = t2.BalanceQuanity,
				t1.PurchaseRate= t2.PurchaseSaleRate,
				t1.EffectivePurchaseRate = t2.EffecivePurchaseSaleRate,
				t1.SaleRate = t2.SaleRate,
				t1.WholeSaleRate = t2.WholeSaleRate,
				t1.SpecialRate= t2.SpecialRate,
				t1.MRP = t2.MRP,
				t1.Scheme1 = t2.Scheme1,
				t1.Scheme2 =  t2.Scheme2,
				t1.IsOnHold = t2.IsOnHold
		--WHEN NOT MATCHED BY SOURCE THEN DELETE
		WHEN NOT MATCHED THEN
			INSERT
			(
				PurchaseSaleBookHeaderID,VoucherNumber,VoucherDate
			   ,SRLNO,ItemCode,PurchaseBillNo
			   ,Batch,ExpiryDate,Quantity
			   ,BalanceQuanity--,PurchaseTypeId
			   ,PurchaseRate,EffectivePurchaseRate
			   ,SaleRate,WholeSaleRate,SpecialRate,MRP
			   ,Scheme1,Scheme2,IsOnHold
				-- ,OnHoldRemarks,MfgDate,UPC
			)
			VALUES
			(
				PurchaseSaleBookHeaderID,VoucherNumber,VoucherDate
			   ,SRLNO,ItemCode,PurchaseBillNo
			   ,Batch,ExpiryDate,Quantity  
			   ,BalanceQuanity--,PurchaseTypeId
			   ,PurchaseSaleRate,EffecivePurchaseSaleRate
			   ,SaleRate,WholeSaleRate,SpecialRate,MRP
			   ,Scheme1,Scheme2,IsOnHold
			);
		  
       
       PRINT 'INSRT IN Purchase FIFO Complete'
       
       
       MERGE INTO dbo.BillOutStandings t1
       USING
       (
			SELECT
			   PurchaseSaleBookHeaderID,VoucherNumber,VoucherTypeCode,VoucherDate
			   ,LedgerType,LedgerTypeCode
			   ,TotalBillAmount as BillAmount,TotalBillAmount AS OSAmount
		   FROM PurchaseSaleBookHeader
		   WHERE PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID)			
       ) t2 ON t1.PurchaseSaleBookHeaderID = t2.PurchaseSaleBookHeaderID
       WHEN MATCHED THEN
			UPDATE SET t1.VoucherDate = t2.VoucherDate,
				t1.BillAmount = t2.BillAmount
		WHEN NOT MATCHED THEN
			INSERT (
				 PurchaseSaleBookHeaderID,VoucherNumber
				,VoucherTypeCode,VoucherDate
				,LedgerType,LedgerTypeCode
				,BillAmount,OSAmount
			)
			VALUES (			
				PurchaseSaleBookHeaderID,VoucherNumber
				,VoucherTypeCode,VoucherDate
				,LedgerType,LedgerTypeCode
				,BillAmount,OSAmount
			);
       
		PRINT 'INSRT IN Purchase BILLOS Complete'
		
		----------------------INSERT IN TRAN STRAT --------------------------------------------------------
		
		
		DELETE FROM dbo.TRN WHERE PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID)			
		
		DECLARE @Narration nvarchar(200) 
		
		SELECT @Narration = ('Purchase Invoice is - ' + CONVERT(varchar,PurchaseBillNo))
		FROM PurchaseSaleBookHeader WHERE PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID)
		
		
		INSERT INTO dbo.TRN
           (    PurchaseSaleBookHeaderID
			   ,VoucherNumber
			   ,VoucherTypeCode
			   ,VoucherDate
			   ,LedgerType
			   ,LedgerTypeCode
			   ,NARRATION
			   ,Amount
			   ,DebitCredit
           )
          SELECT PurchaseSaleBookHeaderID
			   ,VoucherNumber
			   ,VoucherTypeCode
			   ,VoucherDate
			   ,LedgerType
			   ,LedgerTypeCode
			   ,@Narration AS NARRATION
			   ,TotalBillAmount AS Amount
			   ,'C' AS DebitCredit
		  FROM PurchaseSaleBookHeader
		  WHERE PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID)

		INSERT INTO dbo.TRN
		(   PurchaseSaleBookHeaderID
		   ,VoucherNumber
		   ,VoucherTypeCode
		   ,VoucherDate
		   ,LedgerType
		   ,LedgerTypeCode
		   ,NARRATION
		   ,Amount
		   ,DebitCredit
		)		  
		SELECT 
			PurchaseSaleBookHeaderID
			,VoucherNumber
			,VoucherTypeCode
			,VoucherDate
			,'PURCHASELEDGER' AS LedgerType
			,REPLACE(AmountName,'Amount','PUR00000') As LedgerTypeCode
			,@Narration As NARRATION
			,Amount
			,'D' DebitCredit
		FROM dbo.PurchaseSaleBookHeader
		UNPIVOT
		(
			Amount
			FOR AmountName in (Amount01, Amount02, Amount03,Amount04,Amount05,Amount06,Amount07)
		) unpiv
		WHERE PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID) 
		AND Amount > 0;


		INSERT INTO dbo.TRN
		(   PurchaseSaleBookHeaderID
		   ,VoucherNumber
		   ,VoucherTypeCode
		   ,VoucherDate
		   ,LedgerType
		   ,LedgerTypeCode
		   ,NARRATION
		   ,Amount
		   ,DebitCredit
		)		  
		SELECT 
			PurchaseSaleBookHeaderID
			,VoucherNumber
			,VoucherTypeCode
			,VoucherDate
			,'GENERALLEDGER' AS LedgerType
			,REPLACE(AmountName,'IGST','IGST0000') As LedgerTypeCode
			,@Narration As NARRATION
			,Amount
			,'D' DebitCredit
		FROM dbo.PurchaseSaleBookHeader
		UNPIVOT
		(
			Amount
			FOR AmountName in (IGST01, IGST02, IGST03,IGST04,IGST05,IGST06,IGST07)
		) unpiv
		WHERE PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID) AND 
		--LocalCentral = 'L' AND 
		Amount > 0;
		
		
		INSERT INTO dbo.TRN
		(   PurchaseSaleBookHeaderID
		   ,VoucherNumber
		   ,VoucherTypeCode
		   ,VoucherDate
		   ,LedgerType
		   ,LedgerTypeCode
		   ,NARRATION
		   ,Amount
		   ,DebitCredit
		)		  
		SELECT 
			PurchaseSaleBookHeaderID
			,VoucherNumber
			,VoucherTypeCode
			,VoucherDate
			,'GENERALLEDGER' AS LedgerType
			,REPLACE(AmountName,'SGST','SGST0000') As LedgerTypeCode
			,@Narration As NARRATION
			,Amount
			,'D' DebitCredit
		FROM dbo.PurchaseSaleBookHeader
		UNPIVOT
		(
			Amount
			FOR AmountName in (SGST01, SGST02, SGST03,SGST04,SGST05,SGST06,SGST07)
		) unpiv
		WHERE PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID) AND 
		--LocalCentral = 'L' AND 
		Amount > 0;
		
		
		
		INSERT INTO dbo.TRN
		(   PurchaseSaleBookHeaderID
		   ,VoucherNumber
		   ,VoucherTypeCode
		   ,VoucherDate
		   ,LedgerType
		   ,LedgerTypeCode
		   ,NARRATION
		   ,Amount
		   ,DebitCredit
		)		  
		SELECT 
			PurchaseSaleBookHeaderID
			,VoucherNumber
			,VoucherTypeCode
			,VoucherDate
			,'GENERALLEDGER' AS LedgerType
			,REPLACE(AmountName,'CGST','CGST0000') As LedgerTypeCode
			,@Narration As NARRATION
			,Amount
			,'D' DebitCredit
		FROM dbo.PurchaseSaleBookHeader
		UNPIVOT
		(
			Amount
			FOR AmountName in (CGST01, CGST02, CGST03,CGST04,CGST05,CGST06,CGST07)
		) unpiv
		WHERE PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID) AND 
			--LocalCentral = 'C' AND 
			Amount > 0;
		
		
		INSERT INTO dbo.TRN
		(   PurchaseSaleBookHeaderID
		   ,VoucherNumber
		   ,VoucherTypeCode
		   ,VoucherDate
		   ,LedgerType
		   ,LedgerTypeCode
		   ,NARRATION
		   ,Amount
		   ,DebitCredit
		)		 
		SELECT DISTINCT
			A.PurchaseSaleBookHeaderID
		   ,VoucherNumber
		   ,VoucherTypeCode
		   ,VoucherDate
		   ,'INCOMELEDGER' LedgerType
		   ,'ADJ0000001' LedgerTypeCode
		   ,@Narration AS NARRATION
		   ,ABS(B.DebitAmount - C.CreditAmount) AS Amount
		   ,CASE WHEN (DebitAmount - CreditAmount) > 0 THEN 'C' ELSE 'D' END AS DebitCredit 
		FROM TRN A
		INNER JOIN (
			SELECT 
				PurchaseSaleBookHeaderID
			   ,SUM(Amount) DebitAmount
			FROM TRN 
			WHERE PurchaseSaleBookHeaderID=COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID) AND DebitCredit = 'D'
			Group BY PurchaseSaleBookHeaderID
		) B On A.PurchaseSaleBookHeaderID = B.PurchaseSaleBookHeaderID
		INNER JOIN 
		(
			SELECT 
				PurchaseSaleBookHeaderID
			   ,SUM(Amount) CreditAmount
			FROM TRN 
			WHERE PurchaseSaleBookHeaderID=COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID) AND DebitCredit = 'C'
			Group BY PurchaseSaleBookHeaderID
		) C ON A.PurchaseSaleBookHeaderID = C.PurchaseSaleBookHeaderID
		WHERE A.PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID)
		AND ABS(B.DebitAmount - C.CreditAmount) > 0
		
		   
		
		
		----------------------------------------------------------------------------------------------------
		
		DELETE FROM TempPurchaseSaleBookLineItem WHERE PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID
		DELETE FROM TempPurchaseSaleBookHeader WHERE PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID
		
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


/****** Object:  StoredProcedure [dbo].[GetPurchaseSaleBookLineItemsForModify]    Script Date: 06/17/2017 14:32:12 ******/
SET ANSI_NULLS ON
