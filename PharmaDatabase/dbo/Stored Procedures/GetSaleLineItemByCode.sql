--GetSaleLineItemByCode '040000031', 'C001938'
CREATE PROCEDURE [dbo].[GetSaleLineItemByCode]
(
	@ItemCode VARCHAR(10),
	@CustomerCode VARCHAR(10)
)
AS
BEGIN
	DECLARE @CustomerLedgerID INT
	SELECT @CustomerLedgerID = CustomerLedgerId FROM CustomerLedger Where CustomerLedgerName = @CustomerCode
	
	
	SELECT 
		FF.*
		, CASE WHEN IDR.CustCompDiscountRefID IS NULL 
				THEN ISNULL(CDR.Normal,0.00) 
				ELSE ISNULL(IDR.Normal, 0.00) 
			END AS Discount1, FB.BalanceQuantity
	FROM (
		Select TOP 1  
			 0 AS PurchaseSaleBookHeaderID
			,F.Fifoid
			,F.VoucherDate as PurchaseBillDate
			,F.VoucherNumber as PurchaseVoucherNumber
			,F.SrlNo AS PurchaseSrlNo
			,I.ItemName
			,F.ItemCode,F.Batch,BatchNew,0 AS Quantity,0 AS FreeQuantity
			,PurchaseSaleRate,EffecivePurchaseSaleRate
			,ALM.AccountLedgerCode AS PurchaseSaleTypeCode
			,SurCharge
			,COALESCE(L.SalePurchaseTax,I.TaxOnPurchase) AS SalePurchaseTax
			,COALESCE(L.LocalCentral,'L') AS LocalCentral
			,ISNULL(L.SGST,0) AS SGST,ISNULL(L.IGST,0) AS IGST
			,ISNULL(L.CGST,0) AS CGST
			,0 As Amount
			,COALESCE(L.Discount,0) AS Discount
			,COALESCE(L.SpecialDiscount,0) AS SpecialDiscount
			,COALESCE(L.DiscountQuantity,0) AS DiscountQuantity
			,COALESCE(L.VolumeDiscount,0) AS VolumeDiscount
			,I.Scheme1
			,I.Scheme2
			,I.IsHalfScheme
			,0 AS HalfSchemeRate		
			,I.ConversionRate
			,F.MRP
			,F.ExpiryDate
			,COALESCE(F.SaleRate,I.SaleRate) AS SaleRate
			,F.WholeSaleRate
			,F.SpecialRate
			,0 AS PurchaseSaleBookLineItemID	
			,COALESCE(L.Amount,0) AS CostAmount
		FROM FIFO F 
		INNER JOIN ItemMaster I ON I.ItemCode = F.ItemCode
		INNER JOIN AccountLedgerMaster ALM ON ALM.AccountLedgerID = I.SaleTypeId
		LEFT OUTER JOIN PurchaseSaleBookLineItem L 
				ON (F.PurchaseSaleBookHeaderID IS NULL OR (L.PurchaseSaleBookHeaderID = F.PurchaseSaleBookHeaderID  AND F.SRLNO = L.PurchaseSrlNo))
		--LEFT OUTER JOIN PurchaseSaleBookHeader PH on (F.PurchaseSaleBookHeaderID IS NULL OR PH.PurchaseSaleBookHeaderID = F.PurchaseSaleBookHeaderID)
		WHERE F.BalanceQuanity <> 0 AND F.ItemCode = @ItemCode
		ORDER BY F.VoucherDate ASC
	)FF
	INNER JOIN ItemMaster I ON I.ItemCode = FF.ItemCode
	LEFT OUTER JOIN (
		SELECT SUM(BalanceQuanity) as BalanceQuantity, ItemCode  
		FROM FIFO F Group By ItemCode
	)FB ON FB.ItemCode = FF.ItemCode
	LEFT OUTER JOIN CustomerCompanyDiscountRef IDR ON I.CompanyID = IDR.CompanyID and I.ItemID = IDR.ItemID AND IDR.CustomerLedgerID = @CustomerLedgerID
	LEFT OUTER JOIN CustomerCompanyDiscountRef CDR ON I.CompanyID = CDR.CompanyID AND CDR.ItemID IS NULL AND CDR.CustomerLedgerID = @CustomerLedgerID

END
