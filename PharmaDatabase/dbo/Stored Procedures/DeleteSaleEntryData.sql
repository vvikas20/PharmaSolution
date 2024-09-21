CREATE PROCEDURE [dbo].[DeleteSaleEntryData]
(
	@PurchaseSaleBookHeaderID BIGINT
)
AS
BEGIN

	BEGIN TRY
		BEGIN TRAN
		
		DECLARE @OldPurchaseSaleBookHeaderID BIGINT
		
		UPDATE F SET BalanceQuanity = ISNULL(F.BalanceQuanity, 0) + ISNULL(L.Quantity, 0) - ISNULL(OldQuantity,0)
		FROM
		FIFO F 
		LEFT OUTER JOIN 
		(
			Select FIFOID,SUM(ISNULL(L.Quantity, 0) +ISNULL(L.FreeQuantity, 0)) as Quantity
			FROM TempPurchaseSaleBookLineItem L 
			WHERE L.PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID 
			Group By L.FifoID
		 )L ON F.FifoID = L.FifoID
		LEFT OUTER JOIN 
		(
			Select FIFOID,SUM(ISNULL(L.Quantity, 0) +ISNULL(L.FreeQuantity, 0)) as OldQuantity
			FROM PurchaseSaleBookLineItem L 
			WHERE L.PurchaseSaleBookHeaderID = (SELECT TOP 1 OldPurchaseSaleBookHeaderID FROM TempPurchaseSaleBookHeader WHERE PurchaseSaleBookHeaderID =  @PurchaseSaleBookHeaderID )
			Group By L.FifoID
		)R ON F.FifoID = R.FifoID
		
		

		DELETE FROM TempPurchaseSaleBookLineItem Where PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID
		DELETE FROM TempPurchaseSaleBookHeader Where PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID

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
