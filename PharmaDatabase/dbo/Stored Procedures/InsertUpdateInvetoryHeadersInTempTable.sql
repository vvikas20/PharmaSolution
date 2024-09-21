CREATE PROCEDURE [dbo].[InsertUpdateInvetoryHeadersInTempTable]
  @TableTypePurchaseSaleBookHeader TableTypePurchaseSaleBookHeader READONLY
AS
BEGIN

 BEGIN TRY 
  BEGIN TRAN
   
   MERGE INTO dbo.TempPurchaseSaleBookHeader t1
   USING @TableTypePurchaseSaleBookHeader t2 ON t1.PurchaseSaleBookHeaderID = t2.PurchaseSaleBookHeaderID
   WHEN MATCHED THEN 
   UPDATE SET t1.VoucherTypeCode = t2.VoucherTypeCode
    ,t1.VoucherDate=t2.VoucherDate
    ,t1.DueDate=t2.DueDate
    ,t1.PurchaseBillNo=t2.PurchaseBillNo
    ,t1.LedgerType=t2.LedgerType
    ,t1.LedgerTypeCode=t2.LedgerTypeCode
    ,t1.LocalCentral=t2.LocalCentral
    ,t1.PurchaseEntryFormID=t2.PurchaseEntryFormID
    ,t1.Amount01=t2.Amount01
    ,t1.Amount02=t2.Amount02
    ,t1.Amount03=t2.Amount03
    ,t1.Amount04=t2.Amount04
    ,t1.Amount05=t2.Amount05
    ,t1.Amount06=t2.Amount06
    ,t1.Amount07=t2.Amount07
    ,t1.SGST01=t2.SGST01
    ,t1.SGST02=t2.SGST02
    ,t1.SGST03=t2.SGST03
    ,t1.SGST04=t2.SGST04
    ,t1.SGST05=t2.SGST05
    ,t1.SGST06=t2.SGST06
    ,t1.SGST07=t2.SGST07
    ,t1.IGST01=t2.IGST01
    ,t1.IGST02=t2.IGST02
    ,t1.IGST03=t2.IGST03
    ,t1.IGST04=t2.IGST04
    ,t1.IGST05=t2.IGST05
    ,t1.IGST06=t2.IGST06
    ,t1.IGST07=t2.IGST07
    ,t1.CGST01=t2.CGST01
    ,t1.CGST02=t2.CGST02
    ,t1.CGST03=t2.CGST03
    ,t1.CGST04=t2.CGST04
    ,t1.CGST05=t2.CGST05
    ,t1.CGST06=t2.CGST06
    ,t1.CGST07=t2.CGST07
    ,t1.TotalTaxAmount=t2.TotalTaxAmount
    ,t1.SurchargeAmount=t2.SurchargeAmount
    ,t1.TotalBillAmount=t2.TotalBillAmount
    ,t1.TotalCostAmount=t2.TotalCostAmount
    ,t1.TotalGrossAmount=t2.TotalGrossAmount
    ,t1.TotalSchemeAmount=t2.TotalSchemeAmount
    ,t1.TotalDiscountAmount=t2.TotalDiscountAmount
    ,t1.OtherAmount=t2.OtherAmount
    ,t1.FreshBreakageExcess=t2.FreshBreakageExcess
    ,t1.ReturnBillNo=t2.ReturnBillNo
    ,t1.ReturBillDate=t2.ReturBillDate
    ,t1.OrderNumber=t2.OrderNumber
    ,t1.ChallanNumber=t2.ChallanNumber
    ,t1.Message=t2.Message
    ,t1.Deliveryddress=t2.Deliveryddress
    ,t1.DeliveredBy=t2.DeliveredBy
    ,t1.CourierName=t2.CourierName
    ,t1.CourierDate=t2.CourierDate
    ,t1.CourierWeight=t2.CourierWeight
    ,t1.LastBalance=t2.LastBalance
    ,t1.ModifiedBy=t2.ModifiedBy
    ,t1.ModifiedOn=t2.ModifiedOn
   WHEN NOT MATCHED THEN
   INSERT 
      (VoucherTypeCode,VoucherDate
      ,DueDate,PurchaseBillNo
      ,LedgerType,LedgerTypeCode,LocalCentral,PurchaseEntryFormID
      ,Amount01,Amount02,Amount03,Amount04,Amount05,Amount06,Amount07
      ,SGST01,SGST02,SGST03,SGST04,SGST05,SGST06,SGST07
      ,IGST01,IGST02,IGST03,IGST04,IGST05,IGST06,IGST07
      ,CGST01,CGST02,CGST03,CGST04,CGST05,CGST06,CGST07
      ,TotalTaxAmount,SurchargeAmount,TotalBillAmount,TotalCostAmount
      ,TotalGrossAmount,TotalSchemeAmount,TotalDiscountAmount,OtherAmount
      ,FreshBreakageExcess
      ,ReturnBillNo,ReturBillDate           
      ,OrderNumber,ChallanNumber,Message
      ,Deliveryddress,DeliveredBy
      ,CourierName,CourierDate,CourierWeight           
      ,LastBalance
      ,CreatedBy,CreatedOn)
   VALUES ( 
     t2.VoucherTypeCode,t2.VoucherDate
       ,t2.DueDate,t2.PurchaseBillNo
       ,t2.LedgerType,t2.LedgerTypeCode,t2.LocalCentral,t2.PurchaseEntryFormID
       ,t2.Amount01,t2.Amount02,t2.Amount03,t2.Amount04,t2.Amount05,t2.Amount06,t2.Amount07
       ,t2.SGST01,t2.SGST02,t2.SGST03,t2.SGST04,t2.SGST05,t2.SGST06,t2.SGST07
       ,t2.IGST01,t2.IGST02,t2.IGST03,t2.IGST04,t2.IGST05,t2.IGST06,t2.IGST07
       ,t2.CGST01,t2.CGST02,t2.CGST03,t2.CGST04,t2.CGST05,t2.CGST06,t2.CGST07
       ,t2.TotalTaxAmount,t2.SurchargeAmount,t2.TotalBillAmount,t2.TotalCostAmount
       ,t2.TotalGrossAmount,t2.TotalSchemeAmount,t2.TotalDiscountAmount,t2.OtherAmount
       ,t2.FreshBreakageExcess
       ,t2.ReturnBillNo,t2.ReturBillDate           
       ,t2.OrderNumber,t2.ChallanNumber,t2.Message
       ,t2.Deliveryddress,t2.DeliveredBy
       ,t2.CourierName,t2.CourierDate,t2.CourierWeight           
       ,t2.LastBalance
       ,t2.CreatedBy,t2.CreatedOn
      );  
           
    
    DECLARE @PurchaseSaleBookHeaderID AS BIGINT
 
    SELECT @PurchaseSaleBookHeaderID = PurchaseSaleBookHeaderID FROM @TableTypePurchaseSaleBookHeader

    IF @PurchaseSaleBookHeaderID = 0
    BEGIN 
		SELECT @PurchaseSaleBookHeaderID = SCOPE_IDENTITY()
    END
 
    Select @PurchaseSaleBookHeaderID AS PurchaseSaleBookHeaderID 

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
