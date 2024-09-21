CREATE PROCEDURE [dbo].[GetPurchaseSaleBookHeaderForModify]
	@PurchaseSaleBookHeaderID bigint
AS
BEGIN	
	BEGIN TRY	
	BEGIN TRAN
	
	
	  INSERT INTO TempPurchaseSaleBookHeader 
      (
		  VoucherTypeCode,VoucherDate
		  ,DueDate,PurchaseBillNo
		  ,LedgerType,LedgerTypeCode,LocalCentral,PurchaseEntryFormID
		  ,CreatedBy ,CreatedOn
		  ,ModifiedBy ,ModifiedOn
		  , OldPurchaseSaleBookHeaderID
		  ,TotalTaxAmount
      )
      SELECT 
		  VoucherTypeCode,VoucherDate
		  ,DueDate,PurchaseBillNo
		  ,LedgerType,LedgerTypeCode,LocalCentral,PurchaseSaleEntryFormID AS PurchaseEntryFormID
		  ,CreatedBy ,CreatedOn
		  ,ModifiedBy ,ModifiedOn
		  ,@PurchaseSaleBookHeaderID AS OldPurchaseSaleBookHeaderID
		  ,0 as TotalTaxAmount
      FROM PurchaseSaleBookHeader 
      WHERE PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID
  
	DECLARE @NewPurchaseSaleBookHeaderID BIGINT = SCOPE_IDENTITY()
	
	SELECT @NewPurchaseSaleBookHeaderID AS PurchaseSaleBookHeaderID
			,VoucherTypeCode,VoucherDate
			,DueDate,PurchaseBillNo
			,LedgerType,LedgerTypeCode,LocalCentral
			,CreatedBy ,CreatedOn
			,ModifiedBy ,ModifiedOn
			, OldPurchaseSaleBookHeaderID,
			PurchaseEntryFormID
	FROM TempPurchaseSaleBookHeader WHERE PurchaseSaleBookHeaderID  = @NewPurchaseSaleBookHeaderID
	
	
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
