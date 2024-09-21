CREATE VIEW [dbo].[CompanyItemMapping]
AS
SELECT ItemID,I.ItemCode,ItemName
      ,I.CompanyID,c.CompanyName,ISNULL(FB.BalanceQuantity,0) AS BalanceQuantity, c.CompanyCode
      ,ConversionRate,ShortName,Packing
      ,PurchaseRate,MRP,SaleRate
      ,SpecialRate,WholeSaleRate,SaleExcise
      ,SurchargeOnSale,TaxOnSale,Scheme1
      ,Scheme2,PurchaseExcise,UPC,IsHalfScheme,IsQTRScheme
      ,SpecialDiscount,SpecialDiscountOnQty,IsFixedDiscount
      ,FixedDiscountRate,MaximumQty,MaximumDiscount
      ,SurchargeOnPurchase,TaxOnPurchase,DiscountRecieved
      ,SpecialDiscountRecieved
      ,QtyPerCase
      ,Location
      ,MinimumStock
      ,MaximumStock
      ,SaleTypeId
      ,PurchaseTypeId
      ,I.Status
      ,I.CreatedBy
      ,I.CreatedOn
      ,I.ModifiedBy
      ,I.ModifiedOn
      ,BATCH
      ,ExpiryDate
      ,OpeningQty
      ,ClosingQty
      ,SaltCode
      ,SaltName
      ,HSNCode
      ,Al.AccountLedgerCode AS PurchaseTypeCode
      ,AL.AccountLedgerName  AS PurchaseTypeName
      ,AL.SalePurchaseTaxType AS PurchaseTypeRate
  FROM ItemMaster AS I
  INNER JOIN CompanyMaster C ON I.CompanyID = c.CompanyId
  INNER JOIN AccountLedgerMaster AL ON I.PurchaseTypeId = AL.AccountLedgerID
  LEFT OUTER JOIN (
		SELECT SUM(BalanceQuanity) as BalanceQuantity, ItemCode  
		FROM FIFO F Group By ItemCode
	)FB ON FB.ItemCode = I.ItemCode
