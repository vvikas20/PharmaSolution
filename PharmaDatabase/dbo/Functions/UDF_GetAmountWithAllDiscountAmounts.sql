CREATE FUNCTION [dbo].[UDF_GetAmountWithAllDiscountAmounts](@PurchaseSaleBookHeaderID BIGINT)
RETURNS @TempTableAmountWithAllDiscountAmounts TABLE (
   PurchaseSaleBookHeaderID BIGINT NOT NULL,
   PurchaseSaleBookLineItemID BIGINT NOT NULL,
   FinalAmount FLOAT NOT NULL,
   GrossAmount FLOAT NOT NULL,
   SchemeAmount FLOAT NOT NULL,
   DiscountAmount FLOAT NOT NULL,
   SpecialDiscountAmount FLOAT NOT NULL,
   VolumeDiscountAmount FLOAT NOT NULL   
) 
AS
BEGIN


	DECLARE @VoucherTypeCode varchar(50)
	SELECT @VoucherTypeCode = VoucherTypeCode FROM TempPurchaseSaleBookHeader WHERE PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID

	INSERT INTO @TempTableAmountWithAllDiscountAmounts 
   (
		PurchaseSaleBookHeaderID
		,PurchaseSaleBookLineItemID
		,FinalAmount
		,GrossAmount
		,SchemeAmount
		,DiscountAmount
		,SpecialDiscountAmount
		,VolumeDiscountAmount
   )
   SELECT 
		AMT3.PurchaseSaleBookHeaderID
		,AMT3.PurchaseSaleBookLineItemID
		,ISNULL((Amt3.Amount3 - (Amt4.Quantity * Amt4.VolumeDiscount)),0) AS FinalAmount
		,ISNULL(Amt3.GrossAmount,0) GrossAmount
		,ISNULL(Amt3.SchemeAmount,0) AS SchemeAmount
		,ISNULL(Amt3.DiscountAmount,0) AS DiscountAmount
		,ISNULL(Amt3.SpecialDiscountAmount,0) AS SpecialDiscountAmount
		,ISNULL((Amt4.Quantity * Amt4.VolumeDiscount),0) AS VolumeDiscountAmount
	FROM dbo.TempPurchaseSaleBookLineItem Amt4
	INNER JOIN
	(
	SELECT 
		 AMT2.PurchaseSaleBookHeaderID
		,AMT2.PurchaseSaleBookLineItemID
		,(Amt2.Amount2 - (Amt2.Amount2 * .01 * Amt3.SpecialDiscount)) AS Amount3
		,Amt2.GrossAmount
		,Amt2.SchemeAmount
		,Amt2.DiscountAmount
		,(Amt2.Amount2 * .01 * Amt3.SpecialDiscount) AS SpecialDiscountAmount							
	FROM dbo.TempPurchaseSaleBookLineItem Amt3
	INNER JOIN 
	(
		SELECT 
			AMT1.PurchaseSaleBookHeaderID, AMT1.PurchaseSaleBookLineItemID 
			,(Amt1.Amount1 - (Amt1.Amount1 * .01 * Amt2.Discount)) As Amount2
			,Amt1.GrossAmount
			,Amt1.SchemeAmount
			,(Amt1.Amount1 * .01 * Amt2.Discount) DiscountAmount
		FROM dbo.TempPurchaseSaleBookLineItem Amt2
		INNER JOIN 
		(
			SELECT 
				 PurchaseSaleBookHeaderID
				,PurchaseSaleBookLineItemID
				,(Quantity * CASE WHEN  @VoucherTypeCode = 'PURCHASEENTRY' THEN PurchaseSaleRate ELSE SaleRate END) GrossAmount
				,(Quantity * CASE WHEN  @VoucherTypeCode = 'PURCHASEENTRY' THEN PurchaseSaleRate ELSE SaleRate END) Amount1
				, 0 AS SchemeAmount 
			FROM dbo.TempPurchaseSaleBookLineItem
			WHERE PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID AND FreeQuantity >= 1
			
			UNION ALL
			
			SELECT 
				PurchaseSaleBookHeaderID
				,PurchaseSaleBookLineItemID
				,(Quantity * CASE WHEN  @VoucherTypeCode = 'PURCHASEENTRY' THEN PurchaseSaleRate ELSE SaleRate END) GrossAmount
				,(Quantity * CASE WHEN  @VoucherTypeCode = 'PURCHASEENTRY' THEN PurchaseSaleRate ELSE SaleRate END) - (FreeQuantity * CASE WHEN  @VoucherTypeCode = 'PURCHASEENTRY' THEN PurchaseSaleRate ELSE SaleRate END)  Amount1
				,(FreeQuantity * CASE WHEN  @VoucherTypeCode = 'PURCHASEENTRY' THEN PurchaseSaleRate ELSE SaleRate END) AS SchemeAmount 
			FROM dbo.TempPurchaseSaleBookLineItem
			WHERE PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID AND FreeQuantity < 1
			
		) AS Amt1 ON Amt1.PurchaseSaleBookHeaderID = Amt2.PurchaseSaleBookHeaderID 
			AND Amt1.PurchaseSaleBookLineItemID = Amt2.PurchaseSaleBookLineItemID							
	) AS Amt2 On Amt2.PurchaseSaleBookHeaderID = Amt3.PurchaseSaleBookHeaderID 
		AND Amt2.PurchaseSaleBookLineItemID = Amt3.PurchaseSaleBookLineItemID

	)AS Amt3 On Amt3.PurchaseSaleBookHeaderID = Amt4.PurchaseSaleBookHeaderID
	AND Amt3.PurchaseSaleBookLineItemID = Amt4.PurchaseSaleBookLineItemID
  
   RETURN;
END;
