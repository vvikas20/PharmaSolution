CREATE PROCEDURE [dbo].[SaveReceiptPaymentData]
(
	@ReceiptPaymentIDs TableTypeIds READONLY
)
AS 
BEGIN



BEGIN TRY	
	BEGIN TRAN
	
	
	DECLARE @MyCursor CURSOR;
	DECLARE @ReceiptPaymentID BIGINT;
	BEGIN
		SET @MyCursor = CURSOR FOR
		select ID  from @ReceiptPaymentIDs		 

		OPEN @MyCursor 
		FETCH NEXT FROM @MyCursor 
		INTO @ReceiptPaymentID

		WHILE @@FETCH_STATUS = 0
		BEGIN
		
		
					DECLARE @OldReceiptPaymentID BIGINT
					
					SELECT @OldReceiptPaymentID = OldReceiptPaymentID FROM TempReceiptPayment WHERE ReceiptPaymentID = @ReceiptPaymentID
					
					IF @OldReceiptPaymentID IS NOT NULL
					BEGIN
					
						DELETE FROM BillOutStandingsAudjustment WHERE ReceiptPaymentID = @OldReceiptPaymentID
						DELETE FROM ReceiptPayment WHERE ReceiptPaymentID = @OldReceiptPaymentID
					
					END
		
					
					DECLARE @VoucherNumber NVARCHAR(8) = '00000000'		
					DECLARE @MaxVoucher INT = 0
					
					SELECT @MaxVoucher = (ISNULL(COUNT(ReceiptPaymentID),0) + 1) FROM dbo.ReceiptPayment
					WHERE VoucherTypeCode = (SELECT TOP 1 VoucherTypeCode FROM TempReceiptPayment 
					WHERE ReceiptPaymentID = @ReceiptPaymentID)

					SET @VoucherNumber = RIGHT((@VoucherNumber + CONVERT(VARCHAR,@MaxVoucher)),8)


					INSERT INTO dbo.ReceiptPayment
					   (VoucherNumber,VoucherTypeCode
					   ,VoucherDate,LedgerType,LedgerTypeCode,LedgerTypeName
					   ,PaymentMode,Amount,UnadjustedAmount
					   ,BankAccountLedgerTypeCode,BankAccountLedgerTypeName,ChequeDate
					   ,ChequeClearDate,IsChequeCleared
					   ,POST,PISNumber,ChequeNumber)
					 SELECT @VoucherNumber AS VoucherNumber,VoucherTypeCode
						   ,VoucherDate,LedgerType,LedgerTypeCode,LedgerTypeName
						   ,PaymentMode,Ammount,UnadjustedAmount
						   ,BankAccountLedgerTypeCode,BankAccountLedgerTypeName,ChequeDate
						   ,ChequeClearDate,IsChequeCleared
						   ,POST,PISNumber,ChequeNumber
					 FROM TempReceiptPayment WHERE ReceiptPaymentID = @ReceiptPaymentID
				

				DECLARE @NewReceiptPaymentID BIGINT
				
				SET @NewReceiptPaymentID  = SCOPE_IDENTITY()
				
				
				INSERT INTO dbo.BillOutStandingsAudjustment
					   (
					    PurchaseSaleBookHeaderID
					   ,VoucherNumber
					   ,VoucherTypeCode
					   ,VoucherDate
					   ,ReceiptPaymentID
					   ,BillOutStandingsID
					   ,AdjustmentVoucherNumber
					   ,AdjustmentVoucherTypeCode
					   ,AdjustmentVoucherDate
					   ,LedgerType
					   ,LedgerTypeCode
					   ,Amount
					   ,ChequeNumber)
				 SELECT       
				        PurchaseSaleBookHeaderID
						,@VoucherNumber AS VoucherNumber
					   ,VoucherTypeCode
					   ,VoucherDate
					   ,@NewReceiptPaymentID AS ReceiptPaymentID
					   ,BillOutStandingsID
					   ,AdjustmentVoucherNumber
					   ,AdjustmentVoucherTypeCode
					   ,AdjustmentVoucherDate
					   ,LedgerType
					   ,LedgerTypeCode
					   ,Amount
					   ,ChequeNumber
				   FROM TempBillOutStandingsAudjustment WHERE ReceiptPaymentID = @ReceiptPaymentID
				
				
				DELETE FROM TempBillOutStandingsAudjustment WHERE ReceiptPaymentID = @ReceiptPaymentID
				DELETE FROM TempReceiptPayment WHERE ReceiptPaymentID = @ReceiptPaymentID
	
		  FETCH NEXT FROM @MyCursor 
		  INTO @ReceiptPaymentID 
		END; 

		CLOSE @MyCursor ;
		DEALLOCATE @MyCursor;
	END;
	
	
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
