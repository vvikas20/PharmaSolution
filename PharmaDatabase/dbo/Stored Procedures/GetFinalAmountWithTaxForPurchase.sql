CREATE PROCEDURE [dbo].[GetFinalAmountWithTaxForPurchase]
(
@PurchaseSaleBookHeaderID INT
)
AS
BEGIN

  SELECT 
	   A.PurchaseSaleBookHeaderID,
	   A.PurchaseSaleTypeCode,
	   A.PurchaseSaleType AS PurchaseSaleTypeName,
	   B.Amount,
	   B.IGST,
	   B.SGST,
	   B.CGST,
	   A.TaxApplicable
  FROM
  (
	SELECT @PurchaseSaleBookHeaderID AS PurchaseSaleBookHeaderID
		,ALM.AccountLedgerCode AS PurchaseSaleTypeCode
		,ALM.AccountLedgerName AS PurchaseSaleType
		,ALM.SalePurchaseTaxType AS TaxApplicable
	FROM AccountLedgerMaster ALM
	INNER JOIN AccountLedgerType ALT ON ALM.AccountLedgerTypeId = ALT.AccountLedgerTypeID
	WHERE ALT.SystemName = 'PURCHASELEDGER'
  ) A
  LEFT OUTER JOIN 
  (    
   SELECT DISTINCT
    Final1.PurchaseSaleBookHeaderID,
    Final1.PurchaseSaleTypeCode,
    A.Amount,    
    CASE WHEN Final1.LocalCentral = 'L' THEN (A.PurchaseSaleTax * 0.5) ELSE NULL END AS SGST,
    CASE WHEN Final1.LocalCentral = 'L' THEN (A.PurchaseSaleTax * 0.5) ELSE NULL END AS CGST,
    CASE WHEN Final1.LocalCentral = 'C' THEN A.PurchaseSaleTax ELSE NULL END AS IGST
   FROM dbo.TempPurchaseSaleBookLineItem Final1
   INNER JOIN
   (
		SELECT 
		  Final.PurchaseSaleBookHeaderID
		 ,Final.PurchaseSaleTypeCode
		 ,SUM(Amt4.FinalAmount) AS Amount, 
		  SUM(Amt4.FinalAmount * .01 * Final.PurchaseSaleTax) As PurchaseSaleTax
		FROM dbo.TempPurchaseSaleBookLineItem Final
		INNER JOIN UDF_GetAmountWithAllDiscountAmounts(@PurchaseSaleBookHeaderID) AS Amt4
		  On Amt4.PurchaseSaleBookHeaderID = final.PurchaseSaleBookHeaderID 
		  AND Amt4.PurchaseSaleBookLineItemID = final.PurchaseSaleBookLineItemID
		GROUP BY Final.PurchaseSaleBookHeaderID,Final.PurchaseSaleTypeCode
   )A ON Final1.PurchaseSaleBookHeaderID = A.PurchaseSaleBookHeaderID 
			AND Final1.PurchaseSaleTypeCode = A.PurchaseSaleTypeCode    
  ) B ON A.PurchaseSaleBookHeaderID = B.PurchaseSaleBookHeaderID 
		AND A.PurchaseSaleTypeCode = B.PurchaseSaleTypeCode
  Order by A.TaxApplicable ASC

END
