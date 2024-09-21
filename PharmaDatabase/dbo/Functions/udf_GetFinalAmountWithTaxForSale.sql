CREATE FUNCTION [dbo].[udf_GetFinalAmountWithTaxForSale](@PurchaseSaleBookHeaderID BIGINT)
RETURNS @TempTable TABLE (
   PurchaseSaleBookHeaderID BIGINT NOT NULL,
   Amount01 decimal(18,2),
   Amount02 decimal(18,2),
   Amount03 decimal(18,2),
   Amount04 decimal(18,2),
   Amount05 decimal(18,2),
   Amount06 decimal(18,2),
   Amount07 decimal(18,2),
   SGST01 decimal(18,2),
   SGST02 decimal(18,2),
   SGST03 decimal(18,2),
   SGST04 decimal(18,2),
   SGST05 decimal(18,2),
   SGST06 decimal(18,2),
   SGST07 decimal(18,2),
   CGST01 decimal(18,2),
   CGST02 decimal(18,2),
   CGST03 decimal(18,2),
   CGST04 decimal(18,2),
   CGST05 decimal(18,2),
   CGST06 decimal(18,2),
   CGST07 decimal(18,2),
   IGST01 decimal(18,2),
   IGST02 decimal(18,2),
   IGST03 decimal(18,2),
   IGST04 decimal(18,2),
   IGST05 decimal(18,2),
   IGST06 decimal(18,2),
   IGST07 decimal(18,2)
) 
AS
BEGIN 
	
	INSERT INTO @TempTable
	SELECT 
		A.PurchaseSaleBookHeaderID,
		ISNULL(SUM(CASE WHEN A.PurchaseSaleTypeCode = 'SALE000001' THEN Amount END ),0) AS Amount01,
		ISNULL(SUM(CASE WHEN A.PurchaseSaleTypeCode = 'SALE000002' THEN Amount END),0) AS Amount02,
		ISNULL(SUM(CASE WHEN A.PurchaseSaleTypeCode = 'SALE000003' THEN Amount END ) ,0) AS Amount03,
		ISNULL(SUM(CASE WHEN A.PurchaseSaleTypeCode = 'SALE000004' THEN Amount END ),0)AS Amount04,
		ISNULL(SUM(CASE WHEN A.PurchaseSaleTypeCode = 'SALE000005' THEN Amount END ),0)AS Amount05,
		ISNULL(SUM(CASE WHEN A.PurchaseSaleTypeCode = 'SALE000006' THEN Amount END ),0)AS Amount06,
		ISNULL(SUM(CASE WHEN A.PurchaseSaleTypeCode = 'SALE000007' THEN Amount END ),0) AS Amount07,
		
		ISNULL(SUM(CASE WHEN A.PurchaseSaleTypeCode = 'SALE000001' THEN SGST END ),0) AS SGST01,
		ISNULL(SUM(CASE WHEN A.PurchaseSaleTypeCode = 'SALE000002' THEN SGST END),0) AS SGST02,
		ISNULL(SUM(CASE WHEN A.PurchaseSaleTypeCode = 'SALE000003' THEN SGST END ),0)AS SGST03,
		ISNULL(SUM(CASE WHEN A.PurchaseSaleTypeCode = 'SALE000004' THEN SGST END ),0)AS SGST04,
		ISNULL(SUM(CASE WHEN A.PurchaseSaleTypeCode = 'SALE000005' THEN SGST END ),0)AS SGST05,
		ISNULL(SUM(CASE WHEN A.PurchaseSaleTypeCode = 'SALE000006' THEN SGST END ),0)AS SGST06,
		ISNULL(SUM(CASE WHEN A.PurchaseSaleTypeCode = 'SALE000007' THEN SGST END ),0) AS SGST07,
		
		ISNULL(SUM(CASE WHEN A.PurchaseSaleTypeCode = 'SALE000001' THEN CGST END ),0) AS CGST01,
		ISNULL(SUM(CASE WHEN A.PurchaseSaleTypeCode = 'SALE000002' THEN CGST END),0) AS CGST02,
		ISNULL(SUM(CASE WHEN A.PurchaseSaleTypeCode = 'SALE000003' THEN CGST END ),0)AS CGST03,
		ISNULL(SUM(CASE WHEN A.PurchaseSaleTypeCode = 'SALE000004' THEN CGST END ),0)AS CGST04,
		ISNULL(SUM(CASE WHEN A.PurchaseSaleTypeCode = 'SALE000005' THEN CGST END ),0)AS CGST05,
		ISNULL(SUM(CASE WHEN A.PurchaseSaleTypeCode = 'SALE000006' THEN CGST END ),0)AS CGST06,
		ISNULL(SUM(CASE WHEN A.PurchaseSaleTypeCode = 'SALE000007' THEN CGST END ),0) AS CGST07,
		
		ISNULL(SUM(CASE WHEN A.PurchaseSaleTypeCode = 'SALE000001' THEN IGST END ),0) AS IGST01,
		ISNULL(SUM(CASE WHEN A.PurchaseSaleTypeCode = 'SALE000002' THEN IGST END) ,0)AS IGST02,
		ISNULL(SUM(CASE WHEN A.PurchaseSaleTypeCode = 'SALE000003' THEN IGST END ),0)AS IGST03,
		ISNULL(SUM(CASE WHEN A.PurchaseSaleTypeCode = 'SALE000004' THEN IGST END ),0)AS IGST04,
		ISNULL(SUM(CASE WHEN A.PurchaseSaleTypeCode = 'SALE000005' THEN IGST END ),0)AS IGST05,
		ISNULL(SUM(CASE WHEN A.PurchaseSaleTypeCode = 'SALE000006' THEN IGST END ),0)AS IGST06,
		ISNULL(SUM(CASE WHEN A.PurchaseSaleTypeCode = 'SALE000007' THEN IGST END ),0) AS IGST07

	FROM
	(
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
			WHERE ALT.SystemName = 'SALELEDGER'
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
		  --Order by A.TaxApplicable ASC
	  
	  ) A GROUP BY A.PurchaseSaleBookHeaderID
	  
	  
	  RETURN;
END;
