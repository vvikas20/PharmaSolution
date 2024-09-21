CREATE PROCEDURE [dbo].[SaleInvoice]
(
@PurchaseSaleBookHeaderID BIGINT
)
AS BEGIN

		SELECT H.PurchaseSaleBookHeaderID 
			  ,H.PurchaseBillNo AS InvoiceNumber
			  ,H.VoucherDate AS InvoiceDate
			  ,(ISNULL(H.IGST01,0) 
				  + ISNULL(H.IGST02,0)
				  + ISNULL(H.IGST03,0)
				  + ISNULL(H.IGST04,0)
				  + ISNULL(H.IGST05,0)
				  + ISNULL(H.IGST06,0)
				  + ISNULL(H.IGST07,0)) TOTALIGSTAMT
			  ,(ISNULL(H.CGST01,0) 
				  + ISNULL(H.CGST02,0)
				  + ISNULL(H.CGST03,0)
				  + ISNULL(H.CGST04,0)
				  + ISNULL(H.CGST05,0)
				  + ISNULL(H.CGST06,0)
				  + ISNULL(H.CGST07,0)) TOTALCGSTAMT
			 ,(ISNULL(H.SGST01,0) 
				  + ISNULL(H.SGST02,0)
				  + ISNULL(H.SGST03,0)
				  + ISNULL(H.SGST04,0)
				  + ISNULL(H.SGST05,0)
				  + ISNULL(H.SGST06,0)
				  + ISNULL(H.SGST07,0)) TOTALSGSTAMT
			  ,L.PurchaseSaleBookLineItemID
			  ,L.PurchaseSrlNo
			  ,L.ItemCode
			  ,L.Batch
			  ,L.Quantity
			  ,L.FreeQuantity
			  ,CASE WHEN L.LocalCentral = 'L' THEN (L.SalePurchaseTax * 0.5) ELSE NULL END AS SGSTPER
			  ,CASE WHEN L.LocalCentral = 'L' THEN (L.SalePurchaseTax * 0.5) ELSE NULL END AS CGSTPER
			  ,CASE WHEN L.LocalCentral = 'C' THEN L.SalePurchaseTax ELSE NULL END AS IGSTPER
			  ,L.SGST AS SGSTAMT
			  ,L.IGST AS IGSTAMT
			  ,L.CGST AS CGSTAMT
			  ,CONVERT(VARCHAR,L.Discount) + ' + '  + CONVERT(VARCHAR,L.SpecialDiscount) AS DISCOUNTPER
			  ,L.GrossAmount
			  ,L.GrossAmount - L.TotalDiscountAmount AS TaxableAmount
			  ,L.MRP
			  ,L.ExpiryDate
			  ,L.SaleRate
			  ,L.MfgDate
			  ,I.Packing
			  ,I.HSNCode
		  FROM PurchaseSaleBookHeader H
		  INNER JOIN dbo.PurchaseSaleBookLineItem L ON L.PurchaseSaleBookHeaderID = H.PurchaseSaleBookHeaderID
		  INNER JOIN ItemMaster I ON I.ItemCode = L.ItemCode
		  WHERE H.PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID
		  ORDER BY 1
END
