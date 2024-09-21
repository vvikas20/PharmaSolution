CREATE PROCEDURE [dbo].[GetSaleLineItemInfo]
(
	@ItemCode VARCHAR(10),
	@FifoID INT
)
AS
BEGIN
	--DECLARE @Balance DECIMAL(12,2)
	--SELECT @Balance = BalanceQuanity FROM FIFO WHERE FifoID = @FifoID

	
	SELECT F.BalanceQuantity as Balance, LB.ItemCode, LB.Batch, LB.Discount, LB.SpecialDiscount, LB.DueDate, LB.Scheme1, LB.Scheme2, LB.SaleRate,
	IM.Packing, AM.AccountLedgerName, IM.QtyPerCase, F1.Scheme1, IM.Scheme1, IM.IsHalfScheme, IM.TaxOnSale, IM.SurchargeOnSale
	FROM ItemMaster IM INNER JOIN FIFO F1 ON IM.ItemCode = F1.ItemCode AND F1.FifoID = @FifoID 
	LEFT OUTER JOIN AccountLedgerMaster AM ON   
	IM.SaleTypeId = AM.AccountLedgerID
	LEFT OUTER JOIN 
	(
		SELECt SUM(BalanceQuanity) as BalanceQuantity, ItemCode  FROM FIFO F Group By ItemCode
	)F ON F.ItemCode = IM.ItemCode
	LEFT OUTER JOIN
	(
		--TODO SELECT TAX
		SELECT TOP 1 PL.ItemCode, PL.Batch, PL.Discount, PL.SpecialDiscount, PH.DueDate, PL.Scheme1, PL.Scheme2, PL.SaleRate FROM PurchaseSaleBookHeader PH 
		INNER JOIN PurchaseSaleBookLineItem PL 
		ON PH.PurchaseSaleBookHeaderID = PL.PurchaseSaleBookHeaderID 
		WHERE VoucherTypeCode = 'SALEENTRY' AND PL.ItemCode = @ItemCode ORDER BY VoucherDate DESC
	)LB ON IM.ItemCode = LB.ItemCode
	WHERE IM.ItemCode = @ItemCode
END
