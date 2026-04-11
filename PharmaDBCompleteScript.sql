USE [PharmaDB]
GO
/****** Object:  UserDefinedTableType [dbo].[TableTypeIds]    Script Date: 11-04-2026 08:40:08 ******/
CREATE TYPE [dbo].[TableTypeIds] AS TABLE(
	[ID] [bigint] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[TableTypePurchaseSaleBookHeader]    Script Date: 11-04-2026 08:40:08 ******/
CREATE TYPE [dbo].[TableTypePurchaseSaleBookHeader] AS TABLE(
	[PurchaseSaleBookHeaderID] [bigint] NULL,
	[VoucherTypeCode] [nvarchar](50) NOT NULL,
	[VoucherDate] [datetime] NOT NULL,
	[DueDate] [datetime] NULL,
	[PurchaseBillNo] [nvarchar](20) NULL,
	[LedgerType] [nvarchar](50) NULL,
	[LedgerTypeCode] [nvarchar](10) NULL,
	[Amount01] [decimal](18, 2) NULL,
	[Amount02] [decimal](18, 2) NULL,
	[Amount03] [decimal](18, 2) NULL,
	[Amount04] [decimal](18, 2) NULL,
	[Amount05] [decimal](18, 2) NULL,
	[Amount06] [decimal](18, 2) NULL,
	[Amount07] [decimal](18, 2) NULL,
	[SGST01] [decimal](18, 2) NULL,
	[SGST02] [decimal](18, 2) NULL,
	[SGST03] [decimal](18, 2) NULL,
	[SGST04] [decimal](18, 2) NULL,
	[SGST05] [decimal](18, 2) NULL,
	[SGST06] [decimal](18, 2) NULL,
	[SGST07] [decimal](18, 2) NULL,
	[IGST01] [decimal](18, 2) NULL,
	[IGST02] [decimal](18, 2) NULL,
	[IGST03] [decimal](18, 2) NULL,
	[IGST04] [decimal](18, 2) NULL,
	[IGST05] [decimal](18, 2) NULL,
	[IGST06] [decimal](18, 2) NULL,
	[IGST07] [decimal](18, 2) NULL,
	[CGST01] [decimal](18, 2) NULL,
	[CGST02] [decimal](18, 2) NULL,
	[CGST03] [decimal](18, 2) NULL,
	[CGST04] [decimal](18, 2) NULL,
	[CGST05] [decimal](18, 2) NULL,
	[CGST06] [decimal](18, 2) NULL,
	[CGST07] [decimal](18, 2) NULL,
	[TotalTaxAmount] [decimal](18, 2) NOT NULL,
	[SurchargeAmount] [decimal](18, 2) NULL,
	[TotalBillAmount] [decimal](18, 2) NULL,
	[TotalCostAmount] [decimal](18, 2) NULL,
	[TotalGrossAmount] [decimal](18, 2) NULL,
	[TotalSchemeAmount] [decimal](18, 2) NULL,
	[TotalDiscountAmount] [decimal](18, 2) NULL,
	[OtherAmount] [decimal](18, 2) NULL,
	[FreshBreakageExcess] [nvarchar](1) NULL,
	[ReturnBillNo] [nvarchar](20) NULL,
	[ReturBillDate] [datetime] NULL,
	[CustomerTypeId] [int] NULL,
	[LocalCentral] [nvarchar](1) NULL,
	[OrderNumber] [nvarchar](500) NULL,
	[ChallanNumber] [nvarchar](500) NULL,
	[Message] [nvarchar](500) NULL,
	[Deliveryddress] [nvarchar](500) NULL,
	[DeliveredBy] [nvarchar](150) NULL,
	[CourierName] [nvarchar](150) NULL,
	[CourierDate] [datetime] NULL,
	[CourierWeight] [decimal](18, 2) NULL,
	[PurchaseEntryFormID] [int] NULL,
	[LastBalance] [decimal](18, 2) NULL,
	[SalesManId] [int] NULL,
	[OldPurchaseSaleBookHeaderID] [bigint] NULL,
	[SaleChallanHeaderID] [bigint] NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[TableTypePurchaseSaleBookLineItem]    Script Date: 11-04-2026 08:40:08 ******/
CREATE TYPE [dbo].[TableTypePurchaseSaleBookLineItem] AS TABLE(
	[PurchaseSaleBookLineItemID] [bigint] NULL,
	[PurchaseSaleBookHeaderID] [bigint] NOT NULL,
	[FifoID] [bigint] NULL,
	[PurchaseBillDate] [datetime] NULL,
	[PurchaseVoucherNumber] [nvarchar](8) NULL,
	[PurchaseSrlNo] [int] NULL,
	[ItemCode] [nvarchar](9) NOT NULL,
	[ItemName] [nvarchar](100) NULL,
	[Batch] [nvarchar](20) NULL,
	[BatchNew] [nvarchar](20) NULL,
	[Quantity] [decimal](18, 2) NOT NULL,
	[FreeQuantity] [decimal](18, 2) NULL,
	[PurchaseSaleRate] [decimal](18, 2) NULL,
	[EffecivePurchaseSaleRate] [decimal](18, 2) NULL,
	[PurchaseSaleTypeCode] [nvarchar](10) NOT NULL,
	[SurCharge] [decimal](18, 2) NULL,
	[PurchaseSaleTax] [decimal](18, 2) NULL,
	[LocalCentral] [nvarchar](1) NOT NULL,
	[SGST] [decimal](18, 2) NULL,
	[IGST] [decimal](18, 2) NULL,
	[CGST] [decimal](18, 2) NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Discount] [decimal](18, 2) NULL,
	[SpecialDiscount] [decimal](18, 2) NULL,
	[DiscountQuantity] [decimal](18, 2) NULL,
	[VolumeDiscount] [decimal](18, 2) NULL,
	[Scheme1] [decimal](18, 2) NULL,
	[Scheme2] [decimal](18, 2) NULL,
	[IsHalfScheme] [bit] NOT NULL,
	[HalfSchemeRate] [decimal](18, 2) NULL,
	[ConversionRate] [decimal](18, 2) NULL,
	[MRP] [decimal](18, 2) NULL,
	[ExpiryDate] [datetime] NULL,
	[SaleRate] [decimal](18, 2) NULL,
	[WholeSaleRate] [decimal](18, 2) NULL,
	[SpecialRate] [decimal](18, 2) NULL,
	[CostAmount] [decimal](18, 2) NULL,
	[GrossAmount] [decimal](18, 2) NULL,
	[SchemeAmount] [decimal](18, 2) NULL,
	[DiscountAmount] [decimal](18, 2) NULL,
	[SurchargeAmount] [decimal](18, 2) NULL,
	[TaxAmount] [decimal](18, 2) NULL,
	[SpecialDiscountAmount] [decimal](18, 2) NULL,
	[VolumeDiscountAmount] [decimal](18, 2) NULL,
	[TotalDiscountAmount] [decimal](18, 2) NULL,
	[UsedQuantity] [decimal](18, 2) NULL,
	[BalanceQuantity] [decimal](18, 2) NULL,
	[OldPurchaseSaleBookLineItemID] [bigint] NULL,
	[MfgDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[LineItemGroupID] [int] NULL
)
GO
/****** Object:  UserDefinedFunction [dbo].[GetFreeQuantity]    Script Date: 11-04-2026 08:40:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetFreeQuantity]
(
	@ItemCode nvarchar(9),
	@Quantity decimal(18,2)
	 
)
RETURNS decimal(18,2)
BEGIN
   
    DECLARE @FreeQuantity decimal(18,2)
	DECLARE @Scheme1 decimal(18,2)
	DECLARE @Scheme2 decimal(18,2)
	DECLARE @IsHalfScheme bit
	
	SET @FreeQuantity = 0

	SELECT @Scheme1 = Scheme1,@Scheme2 = Scheme2,@IsHalfScheme = IsHalfScheme
	FROM ItemMaster	WHERE ItemCode = @ItemCode


	IF @IsHalfScheme = 1 AND @Quantity < @Scheme1 
		BEGIN
			IF @Quantity >= (@Scheme1 * .5)
			BEGIN
				SET @FreeQuantity = 0.5
			END			
		
		END
	ELSE
		BEGIN
		
			IF @Scheme2 > 0
			BEGIN
				SET @FreeQuantity = FLOOR((@Quantity  * @Scheme2) / @Scheme1)
			END
		END		
		
	RETURN @FreeQuantity

END
GO
/****** Object:  UserDefinedFunction [dbo].[UDF_GetAmountWithAllDiscountAmounts]    Script Date: 11-04-2026 08:40:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  UserDefinedFunction [dbo].[udf_GetFinalAmountWithTaxForSale]    Script Date: 11-04-2026 08:40:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  Table [dbo].[AccountLedgerMaster]    Script Date: 11-04-2026 08:40:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountLedgerMaster](
	[AccountLedgerID] [int] IDENTITY(1,1) NOT NULL,
	[AccountLedgerCode] [nvarchar](10) NOT NULL,
	[AccountLedgerName] [nvarchar](100) NOT NULL,
	[AccountLedgerTypeId] [int] NOT NULL,
	[OpeningBalance] [decimal](18, 2) NOT NULL,
	[CreditDebit] [char](1) NOT NULL,
	[AccountTypeId] [int] NOT NULL,
	[DebitControlCodeID] [int] NULL,
	[CreditControlCodeID] [int] NULL,
	[Status] [bit] NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[SalePurchaseTaxType] [decimal](18, 2) NULL,
 CONSTRAINT [PK_AccountLedgerMaster] PRIMARY KEY CLUSTERED 
(
	[AccountLedgerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyMaster]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyMaster](
	[CompanyId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyCode] [nvarchar](6) NOT NULL,
	[CompanyName] [nvarchar](100) NOT NULL,
	[Status] [bit] NOT NULL,
	[IsDirect] [bit] NOT NULL,
	[OrderPreferenceRating] [int] NOT NULL,
	[BillingPreferenceRating] [int] NOT NULL,
	[StockSummaryRequired] [bit] NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_CompanyMaster] PRIMARY KEY CLUSTERED 
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FIFO]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FIFO](
	[FifoID] [bigint] IDENTITY(1,1) NOT NULL,
	[PurchaseSaleBookHeaderID] [bigint] NULL,
	[VoucherNumber] [nvarchar](8) NOT NULL,
	[VoucherDate] [datetime] NOT NULL,
	[SRLNO] [int] NOT NULL,
	[ItemCode] [nvarchar](10) NOT NULL,
	[PurchaseBillNo] [nvarchar](20) NULL,
	[Batch] [nvarchar](20) NOT NULL,
	[ExpiryDate] [datetime] NULL,
	[Quantity] [decimal](18, 2) NOT NULL,
	[BalanceQuanity] [decimal](18, 2) NOT NULL,
	[PurchaseTypeId] [int] NULL,
	[PurchaseRate] [decimal](18, 2) NOT NULL,
	[EffectivePurchaseRate] [decimal](18, 2) NULL,
	[SaleRate] [decimal](18, 2) NOT NULL,
	[WholeSaleRate] [decimal](18, 2) NULL,
	[SpecialRate] [decimal](18, 2) NULL,
	[MRP] [decimal](18, 2) NOT NULL,
	[Scheme1] [decimal](18, 2) NULL,
	[Scheme2] [decimal](18, 2) NULL,
	[IsOnHold] [bit] NULL,
	[OnHoldRemarks] [nvarchar](200) NULL,
	[MfgDate] [datetime] NULL,
	[UPC] [nvarchar](12) NULL,
 CONSTRAINT [PK_FIFO] PRIMARY KEY CLUSTERED 
(
	[FifoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemMaster]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemMaster](
	[ItemID] [int] IDENTITY(1,1) NOT NULL,
	[ItemCode] [nvarchar](9) NOT NULL,
	[ItemName] [nvarchar](30) NULL,
	[CompanyID] [int] NOT NULL,
	[ConversionRate] [decimal](18, 2) NULL,
	[ShortName] [nvarchar](10) NULL,
	[Packing] [nvarchar](10) NULL,
	[PurchaseRate] [decimal](18, 2) NULL,
	[MRP] [decimal](18, 2) NOT NULL,
	[SaleRate] [decimal](18, 2) NULL,
	[SpecialRate] [decimal](18, 2) NULL,
	[WholeSaleRate] [decimal](18, 2) NULL,
	[SaleExcise] [decimal](18, 2) NULL,
	[SurchargeOnSale] [decimal](18, 2) NULL,
	[TaxOnSale] [decimal](18, 2) NULL,
	[Scheme1] [decimal](18, 2) NULL,
	[Scheme2] [decimal](18, 2) NULL,
	[PurchaseExcise] [decimal](18, 2) NULL,
	[UPC] [nvarchar](16) NULL,
	[IsHalfScheme] [bit] NOT NULL,
	[IsQTRScheme] [bit] NOT NULL,
	[SpecialDiscount] [decimal](18, 2) NULL,
	[SpecialDiscountOnQty] [decimal](18, 2) NULL,
	[IsFixedDiscount] [bit] NOT NULL,
	[FixedDiscountRate] [decimal](18, 2) NULL,
	[MaximumQty] [decimal](18, 2) NULL,
	[MaximumDiscount] [decimal](18, 2) NULL,
	[SurchargeOnPurchase] [decimal](18, 2) NULL,
	[TaxOnPurchase] [decimal](18, 2) NULL,
	[DiscountRecieved] [decimal](18, 2) NULL,
	[SpecialDiscountRecieved] [decimal](18, 2) NULL,
	[QtyPerCase] [decimal](18, 2) NULL,
	[Location] [nvarchar](5) NULL,
	[MinimumStock] [int] NULL,
	[MaximumStock] [int] NULL,
	[SaleTypeId] [int] NOT NULL,
	[PurchaseTypeId] [int] NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[BATCH] [nvarchar](20) NULL,
	[ExpiryDate] [datetime] NULL,
	[OpeningQty] [decimal](18, 2) NULL,
	[ClosingQty] [decimal](18, 2) NULL,
	[SaltCode] [nvarchar](50) NULL,
	[SaltName] [nvarchar](100) NULL,
	[HSNCode] [nvarchar](18) NOT NULL,
 CONSTRAINT [PK_ItemMaster_1] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[CompanyItemMapping]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  Table [dbo].[AccountLedgerType]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountLedgerType](
	[AccountLedgerTypeID] [int] NOT NULL,
	[AccountLedgerTypeName] [nvarchar](50) NOT NULL,
	[SystemName] [nvarchar](50) NOT NULL,
	[Status] [bit] NOT NULL,
	[CodeStartWith] [nvarchar](5) NOT NULL,
	[IsUsedInAccountLedgerMasterForm] [bit] NOT NULL,
 CONSTRAINT [PK_AccountLedgerType] PRIMARY KEY CLUSTERED 
(
	[AccountLedgerTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccountType]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountType](
	[AccountTypeID] [int] NOT NULL,
	[AccountTypeName] [nvarchar](50) NOT NULL,
	[AccountTypeShortName] [nvarchar](1) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_AccountType] PRIMARY KEY CLUSTERED 
(
	[AccountTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuditHistory]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditHistory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UserName] [varchar](250) NULL,
	[TableName] [varchar](100) NULL,
	[ColumnName] [varchar](100) NULL,
	[OldValue] [varchar](max) NULL,
	[NewValue] [varchar](max) NULL,
	[Operation] [char](1) NULL,
	[PrimaryKey] [varchar](500) NULL,
 CONSTRAINT [PK__AuditHis__3214EC27477A1A5D] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillOutStandings]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillOutStandings](
	[BillOutStandingsID] [bigint] IDENTITY(1,1) NOT NULL,
	[PurchaseSaleBookHeaderID] [bigint] NULL,
	[VoucherNumber] [nvarchar](8) NOT NULL,
	[VoucherTypeCode] [nvarchar](50) NOT NULL,
	[VoucherDate] [datetime] NOT NULL,
	[LedgerType] [nvarchar](50) NULL,
	[LedgerTypeCode] [nvarchar](10) NULL,
	[BillAmount] [decimal](18, 2) NOT NULL,
	[OSAmount] [decimal](18, 2) NOT NULL,
	[IsHold] [bit] NOT NULL,
	[HOLDRemarks] [nvarchar](100) NULL,
	[DueDate] [datetime] NULL,
 CONSTRAINT [PK_BillOutStandings] PRIMARY KEY CLUSTERED 
(
	[BillOutStandingsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillOutStandingsAudjustment]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillOutStandingsAudjustment](
	[BillOutStandingsAudjustmentID] [bigint] IDENTITY(1,1) NOT NULL,
	[PurchaseSaleBookHeaderID] [bigint] NULL,
	[VoucherNumber] [nvarchar](8) NOT NULL,
	[VoucherTypeCode] [nvarchar](50) NOT NULL,
	[VoucherDate] [datetime] NOT NULL,
	[ReceiptPaymentID] [bigint] NULL,
	[BillOutStandingsID] [bigint] NOT NULL,
	[AdjustmentVoucherNumber] [nvarchar](8) NOT NULL,
	[AdjustmentVoucherTypeCode] [nvarchar](50) NOT NULL,
	[AdjustmentVoucherDate] [datetime] NOT NULL,
	[LedgerType] [nvarchar](50) NULL,
	[LedgerTypeCode] [nvarchar](10) NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[ChequeNumber] [nvarchar](10) NULL,
 CONSTRAINT [PK_BillOutStandingsAudjustment] PRIMARY KEY CLUSTERED 
(
	[BillOutStandingsAudjustmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Configuration]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Configuration](
	[ConfigID] [int] IDENTITY(1,1) NOT NULL,
	[ConfigKey] [nvarchar](50) NOT NULL,
	[ConfigValue] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Configuration] PRIMARY KEY CLUSTERED 
(
	[ConfigKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerCompanyDiscountRef]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerCompanyDiscountRef](
	[CustCompDiscountRefID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerLedgerID] [int] NOT NULL,
	[CompanyID] [int] NOT NULL,
	[ItemID] [int] NULL,
	[Normal] [decimal](18, 2) NULL,
	[Breakage] [decimal](18, 2) NULL,
	[Expired] [decimal](18, 2) NULL,
	[IsLessEcise] [bit] NOT NULL,
 CONSTRAINT [PK_CustomerCompanyDiscountRef] PRIMARY KEY CLUSTERED 
(
	[CustCompDiscountRefID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerLedger]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerLedger](
	[CustomerLedgerId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerLedgerCode] [nvarchar](10) NOT NULL,
	[CustomerLedgerName] [nvarchar](50) NOT NULL,
	[CustomerLedgerShortName] [nvarchar](20) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[ContactPerson] [nvarchar](50) NOT NULL,
	[Mobile] [nvarchar](50) NULL,
	[OfficePhone] [nvarchar](50) NULL,
	[ResidentPhone] [nvarchar](50) NULL,
	[EmailAddress] [nvarchar](100) NULL,
	[OpeningBal] [decimal](15, 2) NULL,
	[CreditDebit] [char](1) NOT NULL,
	[TaxRetail] [char](1) NOT NULL,
	[Status] [bit] NOT NULL,
	[ZSMId] [int] NULL,
	[ASMId] [int] NULL,
	[RSMId] [int] NULL,
	[AreaId] [int] NULL,
	[SalesManId] [int] NULL,
	[RouteId] [int] NULL,
	[DLNo] [nvarchar](20) NOT NULL,
	[GSTNo] [nvarchar](10) NOT NULL,
	[CINNo] [nvarchar](10) NOT NULL,
	[LINNo] [nvarchar](20) NULL,
	[ServiceTaxNo] [nvarchar](20) NULL,
	[PANNo] [nvarchar](20) NULL,
	[CreditLimit] [int] NOT NULL,
	[RateTypeID] [int] NULL,
	[IsLessExcise] [bit] NOT NULL,
	[CustomerTypeID] [int] NOT NULL,
	[InterestTypeID] [int] NOT NULL,
	[MaxOSAmount] [decimal](18, 2) NULL,
	[MaxNumOfOSBill] [int] NULL,
	[MaxBillAmount] [decimal](18, 2) NULL,
	[MaxGracePeriod] [int] NULL,
	[SaleBillFormat] [nvarchar](10) NULL,
	[IsFollowConditionStrictly] [bit] NOT NULL,
	[Discount] [decimal](18, 2) NULL,
	[CentralLocal] [char](1) NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[CustomerLedgerShortDesc] [nvarchar](20) NULL,
	[Telephone] [nvarchar](50) NULL,
 CONSTRAINT [PK_CustomerLedger] PRIMARY KEY CLUSTERED 
(
	[CustomerLedgerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerType]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerType](
	[CustomerTypeId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerType] [nvarchar](50) NOT NULL,
	[CustomerTypeShortName] [char](1) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_CustomerType] PRIMARY KEY CLUSTERED 
(
	[CustomerTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FirmProperties]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FirmProperties](
	[ParamName] [nvarchar](100) NOT NULL,
	[ParamValue] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_FirmProperties] PRIMARY KEY CLUSTERED 
(
	[ParamName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HSNCode]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HSNCode](
	[HSNID] [int] IDENTITY(1,1) NOT NULL,
	[HSNCode] [nvarchar](18) NOT NULL,
	[HSNDescription] [nvarchar](50) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_HSNCode] PRIMARY KEY CLUSTERED 
(
	[HSNCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[MenuID] [int] NOT NULL,
	[MenuKey] [nvarchar](50) NOT NULL,
	[MenuName] [nvarchar](50) NOT NULL,
	[PrivledgeId] [int] NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[MenuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentMode]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentMode](
	[PaymentModeID] [int] IDENTITY(1,1) NOT NULL,
	[PaymentModeSymbol] [nchar](1) NOT NULL,
	[PaymentModeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PaymentMode] PRIMARY KEY CLUSTERED 
(
	[PaymentModeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonalLedger]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonalLedger](
	[PersonalLedgerId] [int] IDENTITY(1,1) NOT NULL,
	[PersonalLedgerCode] [nvarchar](10) NOT NULL,
	[PersonalLedgerName] [nvarchar](50) NOT NULL,
	[PersonalLedgerShortName] [nvarchar](20) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[ContactPerson] [nvarchar](50) NOT NULL,
	[Mobile] [nvarchar](50) NULL,
	[Pager] [nvarchar](50) NULL,
	[Fax] [nvarchar](50) NULL,
	[OfficePhone] [nvarchar](50) NULL,
	[ResidentPhone] [nvarchar](50) NULL,
	[EmailAddress] [nvarchar](100) NULL,
	[Status] [bit] NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[PersonalLedgerShortDesc] [nvarchar](20) NULL,
 CONSTRAINT [PK_PersonalLedger] PRIMARY KEY CLUSTERED 
(
	[PersonalLedgerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonLedgerType]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonLedgerType](
	[PersonTypeId] [int] IDENTITY(1,1) NOT NULL,
	[PersonType] [varchar](20) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_PersonType] PRIMARY KEY CLUSTERED 
(
	[PersonTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonRouteMaster]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonRouteMaster](
	[PersonRouteID] [int] IDENTITY(1,1) NOT NULL,
	[PersonRouteCode] [nvarchar](15) NOT NULL,
	[RecordTypeId] [int] NULL,
	[PersonRouteName] [nvarchar](100) NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_PersonRouteMaster] PRIMARY KEY CLUSTERED 
(
	[PersonRouteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Privledges]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Privledges](
	[PrivledgeId] [int] IDENTITY(1,1) NOT NULL,
	[PriviledgeName] [nvarchar](50) NOT NULL,
	[ControlName] [nvarchar](100) NULL,
	[Status] [bit] NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_Privledges] PRIMARY KEY CLUSTERED 
(
	[PrivledgeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseSaleBookHeader]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseSaleBookHeader](
	[PurchaseSaleBookHeaderID] [bigint] IDENTITY(1,1) NOT NULL,
	[VoucherNumber] [nvarchar](8) NOT NULL,
	[VoucherTypeCode] [nvarchar](50) NOT NULL,
	[VoucherDate] [datetime] NOT NULL,
	[DueDate] [datetime] NULL,
	[PurchaseBillNo] [nvarchar](20) NULL,
	[LedgerType] [nvarchar](50) NULL,
	[LedgerTypeCode] [nvarchar](10) NULL,
	[Amount01] [decimal](18, 2) NULL,
	[Amount02] [decimal](18, 2) NULL,
	[Amount03] [decimal](18, 2) NULL,
	[Amount04] [decimal](18, 2) NULL,
	[Amount05] [decimal](18, 2) NULL,
	[Amount06] [decimal](18, 2) NULL,
	[Amount07] [decimal](18, 2) NULL,
	[SGST01] [decimal](18, 2) NULL,
	[SGST02] [decimal](18, 2) NULL,
	[SGST03] [decimal](18, 2) NULL,
	[SGST04] [decimal](18, 2) NULL,
	[SGST05] [decimal](18, 2) NULL,
	[SGST06] [decimal](18, 2) NULL,
	[SGST07] [decimal](18, 2) NULL,
	[IGST01] [decimal](18, 2) NULL,
	[IGST02] [decimal](18, 2) NULL,
	[IGST03] [decimal](18, 2) NULL,
	[IGST04] [decimal](18, 2) NULL,
	[IGST05] [decimal](18, 2) NULL,
	[IGST06] [decimal](18, 2) NULL,
	[IGST07] [decimal](18, 2) NULL,
	[CGST01] [decimal](18, 2) NULL,
	[CGST02] [decimal](18, 2) NULL,
	[CGST03] [decimal](18, 2) NULL,
	[CGST04] [decimal](18, 2) NULL,
	[CGST05] [decimal](18, 2) NULL,
	[CGST06] [decimal](18, 2) NULL,
	[CGST07] [decimal](18, 2) NULL,
	[TotalTaxAmount] [decimal](18, 2) NOT NULL,
	[SurchargeAmount] [decimal](18, 2) NULL,
	[TotalBillAmount] [decimal](18, 2) NULL,
	[TotalCostAmount] [decimal](18, 2) NULL,
	[TotalGrossAmount] [decimal](18, 2) NULL,
	[TotalSchemeAmount] [decimal](18, 2) NULL,
	[TotalDiscountAmount] [decimal](18, 2) NULL,
	[OtherAmount] [decimal](18, 2) NULL,
	[ZSMId] [int] NULL,
	[ASMId] [int] NULL,
	[RSMId] [int] NULL,
	[AreaId] [int] NULL,
	[SalesManId] [int] NULL,
	[RouteId] [int] NULL,
	[FreshBreakageExcess] [nvarchar](1) NULL,
	[ReturnBillNo] [nvarchar](20) NULL,
	[ReturBillDate] [datetime] NULL,
	[CustomerTypeId] [int] NULL,
	[LocalCentral] [nvarchar](1) NULL,
	[RateTypeId] [int] NULL,
	[OrderNumber] [nvarchar](500) NULL,
	[ChallanNumber] [nvarchar](500) NULL,
	[Message] [nvarchar](500) NULL,
	[Deliveryddress] [nvarchar](500) NULL,
	[DeliveredBy] [nvarchar](150) NULL,
	[CourierName] [nvarchar](150) NULL,
	[CourierDate] [datetime] NULL,
	[CourierWeight] [decimal](18, 2) NULL,
	[PurchaseSaleEntryFormID] [int] NULL,
	[LastBalance] [decimal](18, 2) NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[SaleChallanHeaderID] [bigint] NULL,
 CONSTRAINT [PK_PurchaseSaleBookHeader] PRIMARY KEY CLUSTERED 
(
	[PurchaseSaleBookHeaderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseSaleBookLineItem]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseSaleBookLineItem](
	[PurchaseSaleBookLineItemID] [bigint] IDENTITY(1,1) NOT NULL,
	[PurchaseSaleBookHeaderID] [bigint] NOT NULL,
	[FifoID] [bigint] NULL,
	[PurchaseBillDate] [datetime] NULL,
	[PurchaseVoucherNumber] [nvarchar](8) NULL,
	[PurchaseSrlNo] [int] NULL,
	[ItemCode] [nvarchar](9) NOT NULL,
	[Batch] [nvarchar](20) NOT NULL,
	[BatchNew] [nvarchar](20) NOT NULL,
	[Quantity] [decimal](18, 2) NOT NULL,
	[FreeQuantity] [decimal](18, 2) NULL,
	[PurchaseSaleRate] [decimal](18, 2) NOT NULL,
	[EffecivePurchaseSaleRate] [decimal](18, 2) NULL,
	[PurchaseSaleTypeCode] [nvarchar](10) NOT NULL,
	[SurCharge] [decimal](18, 2) NULL,
	[SalePurchaseTax] [decimal](18, 2) NULL,
	[LocalCentral] [nvarchar](1) NOT NULL,
	[SGST] [decimal](18, 2) NULL,
	[IGST] [decimal](18, 2) NULL,
	[CGST] [decimal](18, 2) NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Discount] [decimal](18, 2) NULL,
	[SpecialDiscount] [decimal](18, 2) NULL,
	[DiscountQuantity] [decimal](18, 2) NULL,
	[VolumeDiscount] [decimal](18, 2) NULL,
	[Scheme1] [decimal](18, 2) NULL,
	[Scheme2] [decimal](18, 2) NULL,
	[IsHalfScheme] [bit] NOT NULL,
	[HalfSchemeRate] [decimal](18, 2) NULL,
	[CostAmount] [decimal](18, 2) NULL,
	[GrossAmount] [decimal](18, 2) NULL,
	[SchemeAmount] [decimal](18, 2) NULL,
	[DiscountAmount] [decimal](18, 2) NULL,
	[SurchargeAmount] [decimal](18, 2) NULL,
	[ConversionRate] [decimal](18, 2) NULL,
	[MRP] [decimal](18, 2) NULL,
	[ExpiryDate] [datetime] NULL,
	[SaleRate] [decimal](18, 2) NULL,
	[WholeSaleRate] [decimal](18, 2) NULL,
	[SpecialRate] [decimal](18, 2) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[TaxAmount] [decimal](18, 2) NULL,
	[SpecialDiscountAmount] [decimal](18, 2) NULL,
	[VolumeDiscountAmount] [decimal](18, 2) NULL,
	[TotalDiscountAmount] [decimal](18, 2) NULL,
	[MfgDate] [datetime] NULL,
 CONSTRAINT [PK_PurchaseSaleBookLineItem] PRIMARY KEY CLUSTERED 
(
	[PurchaseSaleBookLineItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseSaleEntryForm]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseSaleEntryForm](
	[PurchaseSaleEntryFormID] [int] NOT NULL,
	[PurchaseSaleEntryTypeID] [int] NOT NULL,
	[PurchaseSaleFormName] [nvarchar](50) NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_PurchaseSaleEntryForm] PRIMARY KEY CLUSTERED 
(
	[PurchaseSaleEntryFormID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseSaleEntryType]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseSaleEntryType](
	[PurchaseSaleEntryTypeID] [int] NOT NULL,
	[PurchaseSaleTypeCode] [char](1) NOT NULL,
	[PurchaseSaleTypeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PurchaseSaleEntryType] PRIMARY KEY CLUSTERED 
(
	[PurchaseSaleEntryTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RateType]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RateType](
	[RateTypeId] [int] NOT NULL,
	[RateTypeName] [nvarchar](50) NOT NULL,
	[SystemName] [nvarchar](50) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_InterestType] PRIMARY KEY CLUSTERED 
(
	[RateTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReceiptPayment]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReceiptPayment](
	[ReceiptPaymentID] [bigint] IDENTITY(1,1) NOT NULL,
	[VoucherNumber] [nvarchar](8) NOT NULL,
	[VoucherTypeCode] [nvarchar](50) NOT NULL,
	[VoucherDate] [datetime] NOT NULL,
	[LedgerType] [nvarchar](50) NULL,
	[LedgerTypeCode] [nvarchar](10) NULL,
	[PaymentMode] [nchar](1) NOT NULL,
	[Amount] [decimal](18, 2) NULL,
	[BankAccountLedgerTypeCode] [nvarchar](10) NULL,
	[ChequeDate] [datetime] NULL,
	[ChequeClearDate] [datetime] NULL,
	[IsChequeCleared] [bit] NULL,
	[POST] [nvarchar](50) NULL,
	[PISNumber] [nvarchar](50) NULL,
	[ChequeNumber] [nvarchar](10) NULL,
	[LedgerTypeName] [varchar](100) NULL,
	[UnadjustedAmount] [decimal](18, 2) NULL,
	[BankAccountLedgerTypeName] [nvarchar](100) NULL,
 CONSTRAINT [PK_ReceiptPayment] PRIMARY KEY CLUSTERED 
(
	[ReceiptPaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecordType]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecordType](
	[RecordTypeId] [int] IDENTITY(1,1) NOT NULL,
	[RecordType] [nvarchar](50) NOT NULL,
	[SystemName] [nvarchar](50) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_RecordType] PRIMARY KEY CLUSTERED 
(
	[RecordTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolePrivledges]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolePrivledges](
	[RolePrivledgeID] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[PrivledgeId] [int] NOT NULL,
 CONSTRAINT [PK_RolePrivledges] PRIMARY KEY CLUSTERED 
(
	[RolePrivledgeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	[Status] [bit] NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SupplierCompanyDiscountRef]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupplierCompanyDiscountRef](
	[CustCompDiscountRefID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierLedgerID] [int] NOT NULL,
	[CompanyID] [int] NOT NULL,
	[ItemID] [int] NULL,
	[Normal] [decimal](18, 2) NULL,
	[Breakage] [decimal](18, 2) NULL,
	[Expired] [decimal](18, 2) NULL,
	[IsLessEcise] [bit] NOT NULL,
 CONSTRAINT [PK_SupplierCompanyDiscountRef] PRIMARY KEY CLUSTERED 
(
	[CustCompDiscountRefID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SupplierLedger]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupplierLedger](
	[SupplierLedgerId] [int] IDENTITY(1,1) NOT NULL,
	[SupplierLedgerCode] [nvarchar](10) NOT NULL,
	[SupplierLedgerName] [nvarchar](50) NOT NULL,
	[SupplierLedgerShortName] [nvarchar](20) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[ContactPerson] [nvarchar](50) NOT NULL,
	[Mobile] [nvarchar](50) NULL,
	[Pager] [nvarchar](50) NULL,
	[Fax] [nvarchar](50) NULL,
	[OfficePhone] [nvarchar](50) NULL,
	[ResidentPhone] [nvarchar](50) NULL,
	[EmailAddress] [nvarchar](100) NULL,
	[OpeningBal] [decimal](15, 2) NULL,
	[CreditDebit] [char](1) NOT NULL,
	[TaxRetail] [char](1) NOT NULL,
	[Status] [bit] NOT NULL,
	[AreaId] [int] NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[SupplierLedgerShortDesc] [nvarchar](20) NULL,
	[PurchaseTypeID] [int] NOT NULL,
	[DLNo] [nvarchar](20) NULL,
	[GSTNo] [nvarchar](10) NULL,
	[CINNo] [nvarchar](10) NULL,
	[LINNo] [nvarchar](20) NULL,
	[ServiceTaxNo] [nvarchar](20) NULL,
	[PANNo] [nvarchar](20) NULL,
 CONSTRAINT [PK_SupplierLedger] PRIMARY KEY CLUSTERED 
(
	[SupplierLedgerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TableTypePurchaseSaleBookHeader]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableTypePurchaseSaleBookHeader](
	[PurchaseSaleBookHeaderID] [bigint] NULL,
	[VoucherTypeCode] [nvarchar](50) NOT NULL,
	[VoucherDate] [datetime] NOT NULL,
	[DueDate] [datetime] NULL,
	[PurchaseBillNo] [nvarchar](20) NULL,
	[LedgerType] [nvarchar](50) NULL,
	[LedgerTypeCode] [nvarchar](10) NULL,
	[Amount01] [decimal](18, 2) NULL,
	[Amount02] [decimal](18, 2) NULL,
	[Amount03] [decimal](18, 2) NULL,
	[Amount04] [decimal](18, 2) NULL,
	[Amount05] [decimal](18, 2) NULL,
	[Amount06] [decimal](18, 2) NULL,
	[Amount07] [decimal](18, 2) NULL,
	[SGST01] [decimal](18, 2) NULL,
	[SGST02] [decimal](18, 2) NULL,
	[SGST03] [decimal](18, 2) NULL,
	[SGST04] [decimal](18, 2) NULL,
	[SGST05] [decimal](18, 2) NULL,
	[SGST06] [decimal](18, 2) NULL,
	[SGST07] [decimal](18, 2) NULL,
	[IGST01] [decimal](18, 2) NULL,
	[IGST02] [decimal](18, 2) NULL,
	[IGST03] [decimal](18, 2) NULL,
	[IGST04] [decimal](18, 2) NULL,
	[IGST05] [decimal](18, 2) NULL,
	[IGST06] [decimal](18, 2) NULL,
	[IGST07] [decimal](18, 2) NULL,
	[CGST01] [decimal](18, 2) NULL,
	[CGST02] [decimal](18, 2) NULL,
	[CGST03] [decimal](18, 2) NULL,
	[CGST04] [decimal](18, 2) NULL,
	[CGST05] [decimal](18, 2) NULL,
	[CGST06] [decimal](18, 2) NULL,
	[CGST07] [decimal](18, 2) NULL,
	[TotalTaxAmount] [decimal](18, 2) NOT NULL,
	[SurchargeAmount] [decimal](18, 2) NULL,
	[TotalBillAmount] [decimal](18, 2) NULL,
	[TotalCostAmount] [decimal](18, 2) NULL,
	[TotalGrossAmount] [decimal](18, 2) NULL,
	[TotalSchemeAmount] [decimal](18, 2) NULL,
	[TotalDiscountAmount] [decimal](18, 2) NULL,
	[OtherAmount] [decimal](18, 2) NULL,
	[FreshBreakageExcess] [nvarchar](1) NULL,
	[ReturnBillNo] [nvarchar](20) NULL,
	[ReturBillDate] [datetime] NULL,
	[CustomerTypeId] [int] NULL,
	[LocalCentral] [nvarchar](1) NULL,
	[OrderNumber] [nvarchar](500) NULL,
	[ChallanNumber] [nvarchar](500) NULL,
	[Message] [nvarchar](500) NULL,
	[Deliveryddress] [nvarchar](500) NULL,
	[DeliveredBy] [nvarchar](150) NULL,
	[CourierName] [nvarchar](150) NULL,
	[CourierDate] [datetime] NULL,
	[CourierWeight] [decimal](18, 2) NULL,
	[PurchaseEntryFormID] [int] NULL,
	[LastBalance] [decimal](18, 2) NULL,
	[SalesManId] [int] NULL,
	[OldPurchaseSaleBookHeaderID] [bigint] NULL,
	[SaleChallanHeaderID] [bigint] NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TableTypePurchaseSaleBookLineItem]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableTypePurchaseSaleBookLineItem](
	[PurchaseSaleBookLineItemID] [bigint] NULL,
	[PurchaseSaleBookHeaderID] [bigint] NOT NULL,
	[FifoID] [bigint] NULL,
	[PurchaseBillDate] [datetime] NULL,
	[PurchaseVoucherNumber] [nvarchar](8) NULL,
	[PurchaseSrlNo] [int] NULL,
	[ItemCode] [nvarchar](9) NOT NULL,
	[ItemName] [nvarchar](100) NULL,
	[Batch] [nvarchar](20) NULL,
	[BatchNew] [nvarchar](20) NULL,
	[Quantity] [decimal](18, 2) NOT NULL,
	[FreeQuantity] [decimal](18, 2) NULL,
	[PurchaseSaleRate] [decimal](18, 2) NULL,
	[OldPurchaseSaleRate] [decimal](18, 2) NULL,
	[EffecivePurchaseSaleRate] [decimal](18, 2) NULL,
	[PurchaseSaleTypeCode] [nvarchar](10) NOT NULL,
	[SurCharge] [decimal](18, 2) NULL,
	[PurchaseSaleTax] [decimal](18, 2) NULL,
	[LocalCentral] [nvarchar](1) NOT NULL,
	[SGST] [decimal](18, 2) NULL,
	[IGST] [decimal](18, 2) NULL,
	[CGST] [decimal](18, 2) NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Discount] [decimal](18, 2) NULL,
	[SpecialDiscount] [decimal](18, 2) NULL,
	[DiscountQuantity] [decimal](18, 2) NULL,
	[VolumeDiscount] [decimal](18, 2) NULL,
	[Scheme1] [decimal](18, 2) NULL,
	[Scheme2] [decimal](18, 2) NULL,
	[IsHalfScheme] [bit] NOT NULL,
	[HalfSchemeRate] [decimal](18, 2) NULL,
	[ConversionRate] [decimal](18, 2) NULL,
	[MRP] [decimal](18, 2) NULL,
	[ExpiryDate] [datetime] NULL,
	[SaleRate] [decimal](18, 2) NULL,
	[WholeSaleRate] [decimal](18, 2) NULL,
	[SpecialRate] [decimal](18, 2) NULL,
	[CostAmount] [decimal](18, 2) NULL,
	[GrossAmount] [decimal](18, 2) NULL,
	[SchemeAmount] [decimal](18, 2) NULL,
	[DiscountAmount] [decimal](18, 2) NULL,
	[SurchargeAmount] [decimal](18, 2) NULL,
	[TaxAmount] [decimal](18, 2) NULL,
	[SpecialDiscountAmount] [decimal](18, 2) NULL,
	[VolumeDiscountAmount] [decimal](18, 2) NULL,
	[TotalDiscountAmount] [decimal](18, 2) NULL,
	[UsedQuantity] [decimal](18, 2) NULL,
	[BalanceQuantity] [decimal](18, 2) NULL,
	[OldPurchaseSaleBookLineItemID] [bigint] NULL,
	[MfgDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[LineItemGroupID] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TempBillOutStandingsAudjustment]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TempBillOutStandingsAudjustment](
	[BillOutStandingsAudjustmentID] [bigint] IDENTITY(1,1) NOT NULL,
	[PurchaseSaleBookHeaderID] [bigint] NULL,
	[VoucherNumber] [nvarchar](8) NOT NULL,
	[VoucherTypeCode] [nvarchar](50) NOT NULL,
	[VoucherDate] [datetime] NOT NULL,
	[ReceiptPaymentID] [bigint] NULL,
	[BillOutStandingsID] [bigint] NOT NULL,
	[AdjustmentVoucherNumber] [nvarchar](8) NOT NULL,
	[AdjustmentVoucherTypeCode] [nvarchar](50) NOT NULL,
	[AdjustmentVoucherDate] [datetime] NOT NULL,
	[LedgerType] [nvarchar](50) NULL,
	[LedgerTypeCode] [nvarchar](10) NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[ChequeNumber] [nvarchar](10) NULL,
	[OldBillOutStandingsAudjustmentID] [bigint] NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_TempBillOutStandingsAudjustment] PRIMARY KEY CLUSTERED 
(
	[BillOutStandingsAudjustmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TempPurchaseSaleBookHeader]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TempPurchaseSaleBookHeader](
	[PurchaseSaleBookHeaderID] [bigint] IDENTITY(1,1) NOT NULL,
	[VoucherTypeCode] [nvarchar](50) NOT NULL,
	[VoucherDate] [datetime] NOT NULL,
	[DueDate] [datetime] NULL,
	[PurchaseBillNo] [nvarchar](20) NULL,
	[LedgerType] [nvarchar](50) NULL,
	[LedgerTypeCode] [nvarchar](10) NULL,
	[Amount01] [decimal](18, 2) NULL,
	[Amount02] [decimal](18, 2) NULL,
	[Amount03] [decimal](18, 2) NULL,
	[Amount04] [decimal](18, 2) NULL,
	[Amount05] [decimal](18, 2) NULL,
	[Amount06] [decimal](18, 2) NULL,
	[Amount07] [decimal](18, 2) NULL,
	[SGST01] [decimal](18, 2) NULL,
	[SGST02] [decimal](18, 2) NULL,
	[SGST03] [decimal](18, 2) NULL,
	[SGST04] [decimal](18, 2) NULL,
	[SGST05] [decimal](18, 2) NULL,
	[SGST06] [decimal](18, 2) NULL,
	[SGST07] [decimal](18, 2) NULL,
	[IGST01] [decimal](18, 2) NULL,
	[IGST02] [decimal](18, 2) NULL,
	[IGST03] [decimal](18, 2) NULL,
	[IGST04] [decimal](18, 2) NULL,
	[IGST05] [decimal](18, 2) NULL,
	[IGST06] [decimal](18, 2) NULL,
	[IGST07] [decimal](18, 2) NULL,
	[CGST01] [decimal](18, 2) NULL,
	[CGST02] [decimal](18, 2) NULL,
	[CGST03] [decimal](18, 2) NULL,
	[CGST04] [decimal](18, 2) NULL,
	[CGST05] [decimal](18, 2) NULL,
	[CGST06] [decimal](18, 2) NULL,
	[CGST07] [decimal](18, 2) NULL,
	[TotalTaxAmount] [decimal](18, 2) NOT NULL,
	[SurchargeAmount] [decimal](18, 2) NULL,
	[TotalBillAmount] [decimal](18, 2) NULL,
	[TotalCostAmount] [decimal](18, 2) NULL,
	[TotalGrossAmount] [decimal](18, 2) NULL,
	[TotalSchemeAmount] [decimal](18, 2) NULL,
	[TotalDiscountAmount] [decimal](18, 2) NULL,
	[OtherAmount] [decimal](18, 2) NULL,
	[FreshBreakageExcess] [nvarchar](1) NULL,
	[ReturnBillNo] [nvarchar](20) NULL,
	[ReturBillDate] [datetime] NULL,
	[LocalCentral] [nvarchar](1) NULL,
	[OrderNumber] [nvarchar](500) NULL,
	[ChallanNumber] [nvarchar](500) NULL,
	[Message] [nvarchar](500) NULL,
	[Deliveryddress] [nvarchar](500) NULL,
	[DeliveredBy] [nvarchar](150) NULL,
	[CourierName] [nvarchar](150) NULL,
	[CourierDate] [datetime] NULL,
	[CourierWeight] [decimal](18, 2) NULL,
	[PurchaseEntryFormID] [int] NULL,
	[LastBalance] [decimal](18, 2) NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[OldPurchaseSaleBookHeaderID] [bigint] NULL,
	[SaleChallanHeaderID] [bigint] NULL,
 CONSTRAINT [PK_TempPurchaseSaleBookHeader] PRIMARY KEY CLUSTERED 
(
	[PurchaseSaleBookHeaderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TempPurchaseSaleBookLineItem]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TempPurchaseSaleBookLineItem](
	[PurchaseSaleBookLineItemID] [bigint] IDENTITY(1,1) NOT NULL,
	[PurchaseSaleBookHeaderID] [bigint] NOT NULL,
	[FifoID] [bigint] NULL,
	[PurchaseBillDate] [datetime] NULL,
	[PurchaseVoucherNumber] [nvarchar](8) NULL,
	[PurchaseSrlNo] [int] NULL,
	[ItemCode] [nvarchar](9) NOT NULL,
	[Batch] [nvarchar](20) NOT NULL,
	[BatchNew] [nvarchar](20) NOT NULL,
	[Quantity] [decimal](18, 2) NOT NULL,
	[FreeQuantity] [decimal](18, 2) NULL,
	[PurchaseSaleRate] [decimal](18, 2) NOT NULL,
	[EffecivePurchaseSaleRate] [decimal](18, 2) NULL,
	[PurchaseSaleTypeCode] [nvarchar](10) NOT NULL,
	[SurCharge] [decimal](18, 2) NULL,
	[PurchaseSaleTax] [decimal](18, 2) NULL,
	[LocalCentral] [nvarchar](1) NOT NULL,
	[SGST] [decimal](18, 2) NULL,
	[IGST] [decimal](18, 2) NULL,
	[CGST] [decimal](18, 2) NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Discount] [decimal](18, 2) NULL,
	[SpecialDiscount] [decimal](18, 2) NULL,
	[DiscountQuantity] [decimal](18, 2) NULL,
	[VolumeDiscount] [decimal](18, 2) NULL,
	[Scheme1] [decimal](18, 2) NULL,
	[Scheme2] [decimal](18, 2) NULL,
	[IsHalfScheme] [bit] NOT NULL,
	[HalfSchemeRate] [decimal](18, 2) NULL,
	[ConversionRate] [decimal](18, 2) NULL,
	[MRP] [decimal](18, 2) NULL,
	[ExpiryDate] [datetime] NULL,
	[SaleRate] [decimal](18, 2) NULL,
	[WholeSaleRate] [decimal](18, 2) NULL,
	[SpecialRate] [decimal](18, 2) NULL,
	[CostAmount] [decimal](18, 2) NULL,
	[GrossAmount] [decimal](18, 2) NULL,
	[SchemeAmount] [decimal](18, 2) NULL,
	[DiscountAmount] [decimal](18, 2) NULL,
	[SurchargeAmount] [decimal](18, 2) NULL,
	[TaxAmount] [decimal](18, 2) NULL,
	[SpecialDiscountAmount] [decimal](18, 2) NULL,
	[VolumeDiscountAmount] [decimal](18, 2) NULL,
	[TotalDiscountAmount] [decimal](18, 2) NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[UsedQuantity] [decimal](18, 2) NULL,
	[BalanceQuantity] [decimal](18, 2) NULL,
	[OldPurchaseSaleBookLineItemID] [bigint] NULL,
	[MfgDate] [datetime] NULL,
 CONSTRAINT [PK_TempPurchaseSaleBookLineItem] PRIMARY KEY CLUSTERED 
(
	[PurchaseSaleBookLineItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TempReceiptPayment]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TempReceiptPayment](
	[ReceiptPaymentID] [bigint] IDENTITY(1,1) NOT NULL,
	[VoucherNumber] [nvarchar](8) NOT NULL,
	[VoucherTypeCode] [nvarchar](50) NOT NULL,
	[VoucherDate] [datetime] NOT NULL,
	[LedgerType] [nvarchar](50) NULL,
	[LedgerTypeCode] [nvarchar](10) NULL,
	[PaymentMode] [nchar](1) NOT NULL,
	[Ammount] [decimal](18, 2) NULL,
	[BillAmmount] [decimal](18, 2) NULL,
	[BankAccountLedgerTypeCode] [nvarchar](10) NULL,
	[ChequeDate] [datetime] NULL,
	[ChequeClearDate] [datetime] NULL,
	[IsChequeCleared] [bit] NULL,
	[POST] [nvarchar](50) NULL,
	[PISNumber] [nvarchar](50) NULL,
	[ChequeNumber] [nvarchar](10) NULL,
	[UnadjustedAmount] [decimal](18, 2) NULL,
	[OldReceiptPaymentID] [bigint] NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[LedgerTypeName] [varchar](100) NULL,
	[BankAccountLedgerTypeName] [nvarchar](100) NULL,
 CONSTRAINT [PK_TempReceiptPayment] PRIMARY KEY CLUSTERED 
(
	[ReceiptPaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TRN]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TRN](
	[TrnID] [bigint] IDENTITY(1,1) NOT NULL,
	[PurchaseSaleBookHeaderID] [bigint] NOT NULL,
	[VoucherNumber] [nvarchar](8) NOT NULL,
	[VoucherTypeCode] [nvarchar](50) NOT NULL,
	[VoucherDate] [datetime] NOT NULL,
	[LedgerType] [nvarchar](50) NULL,
	[LedgerTypeCode] [nvarchar](10) NULL,
	[NARRATION] [nvarchar](200) NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[DebitCredit] [nvarchar](1) NOT NULL,
	[Status] [nvarchar](1) NULL,
	[IsChequeClear] [bit] NOT NULL,
	[ChequeClearedDate] [datetime] NULL,
	[ChequeNumber] [nvarchar](10) NULL,
 CONSTRAINT [PK_TRN] PRIMARY KEY CLUSTERED 
(
	[TrnID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[Status] [bit] NOT NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[IsSysAdmin] [bit] NOT NULL,
	[RoleID] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VoucherType]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VoucherType](
	[VoucherTypeID] [int] IDENTITY(1,1) NOT NULL,
	[VoucherTypeName] [nvarchar](100) NOT NULL,
	[VoucherTypeCode] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_VoucherType] PRIMARY KEY CLUSTERED 
(
	[VoucherTypeCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AccountLedgerMaster] ON 
GO
INSERT [dbo].[AccountLedgerMaster] ([AccountLedgerID], [AccountLedgerCode], [AccountLedgerName], [AccountLedgerTypeId], [OpeningBalance], [CreditDebit], [AccountTypeId], [DebitControlCodeID], [CreditControlCodeID], [Status], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [SalePurchaseTaxType]) VALUES (1, N'L000001', N'GENERAL CONTROL CODE ', 7, CAST(0.00 AS Decimal(18, 2)), N'C', 3, NULL, NULL, 1, N'admin', CAST(N'2023-09-04T20:37:11.410' AS DateTime), NULL, NULL, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[AccountLedgerMaster] ([AccountLedgerID], [AccountLedgerCode], [AccountLedgerName], [AccountLedgerTypeId], [OpeningBalance], [CreditDebit], [AccountTypeId], [DebitControlCodeID], [CreditControlCodeID], [Status], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [SalePurchaseTaxType]) VALUES (2, N'L000002', N'INCOME LEDGER', 1, CAST(0.00 AS Decimal(18, 2)), N'C', 1, 1, 1, 1, N'admin', CAST(N'2023-09-04T20:38:18.470' AS DateTime), NULL, NULL, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[AccountLedgerMaster] ([AccountLedgerID], [AccountLedgerCode], [AccountLedgerName], [AccountLedgerTypeId], [OpeningBalance], [CreditDebit], [AccountTypeId], [DebitControlCodeID], [CreditControlCodeID], [Status], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [SalePurchaseTaxType]) VALUES (3, N'L000003', N'SALE LEDGER', 6, CAST(0.00 AS Decimal(18, 2)), N'C', 1, 1, 1, 1, N'admin', CAST(N'2023-09-04T20:38:32.560' AS DateTime), NULL, NULL, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[AccountLedgerMaster] ([AccountLedgerID], [AccountLedgerCode], [AccountLedgerName], [AccountLedgerTypeId], [OpeningBalance], [CreditDebit], [AccountTypeId], [DebitControlCodeID], [CreditControlCodeID], [Status], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [SalePurchaseTaxType]) VALUES (4, N'L000004', N'PURCHASE LEDGER', 5, CAST(0.00 AS Decimal(18, 2)), N'C', 1, 1, 1, 1, N'admin', CAST(N'2023-09-04T20:38:58.193' AS DateTime), NULL, NULL, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[AccountLedgerMaster] ([AccountLedgerID], [AccountLedgerCode], [AccountLedgerName], [AccountLedgerTypeId], [OpeningBalance], [CreditDebit], [AccountTypeId], [DebitControlCodeID], [CreditControlCodeID], [Status], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [SalePurchaseTaxType]) VALUES (1001, N'L000005', N'CUSTOMER 1 SALE', 1, CAST(0.00 AS Decimal(18, 2)), N'C', 1, 1, 1, 1, N'admin', CAST(N'2023-09-07T10:05:01.927' AS DateTime), NULL, NULL, CAST(1200.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[AccountLedgerMaster] ([AccountLedgerID], [AccountLedgerCode], [AccountLedgerName], [AccountLedgerTypeId], [OpeningBalance], [CreditDebit], [AccountTypeId], [DebitControlCodeID], [CreditControlCodeID], [Status], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [SalePurchaseTaxType]) VALUES (1002, N'L001002', N'TEST 101', 1, CAST(500.00 AS Decimal(18, 2)), N'C', 2, 1, 1, 1, N'admin', CAST(N'2024-09-21T13:28:15.490' AS DateTime), NULL, NULL, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[AccountLedgerMaster] ([AccountLedgerID], [AccountLedgerCode], [AccountLedgerName], [AccountLedgerTypeId], [OpeningBalance], [CreditDebit], [AccountTypeId], [DebitControlCodeID], [CreditControlCodeID], [Status], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [SalePurchaseTaxType]) VALUES (1003, N'L001003', N'RAM', 1, CAST(0.00 AS Decimal(18, 2)), N'C', 1, 1, 1, 1, N'admin', CAST(N'2024-09-21T13:28:37.667' AS DateTime), NULL, NULL, CAST(0.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[AccountLedgerMaster] OFF
GO
INSERT [dbo].[AccountLedgerType] ([AccountLedgerTypeID], [AccountLedgerTypeName], [SystemName], [Status], [CodeStartWith], [IsUsedInAccountLedgerMasterForm]) VALUES (1, N'Income Ledger', N'IncomeLedger', 1, N'IL', 0)
GO
INSERT [dbo].[AccountLedgerType] ([AccountLedgerTypeID], [AccountLedgerTypeName], [SystemName], [Status], [CodeStartWith], [IsUsedInAccountLedgerMasterForm]) VALUES (2, N'Expenditure Ledger', N'ExpenditureLedger', 1, N'IL', 0)
GO
INSERT [dbo].[AccountLedgerType] ([AccountLedgerTypeID], [AccountLedgerTypeName], [SystemName], [Status], [CodeStartWith], [IsUsedInAccountLedgerMasterForm]) VALUES (3, N'Transaction Books', N'TransactionBooks', 1, N'IL', 0)
GO
INSERT [dbo].[AccountLedgerType] ([AccountLedgerTypeID], [AccountLedgerTypeName], [SystemName], [Status], [CodeStartWith], [IsUsedInAccountLedgerMasterForm]) VALUES (4, N'General Ledger', N'GeneralLedger', 1, N'IL', 0)
GO
INSERT [dbo].[AccountLedgerType] ([AccountLedgerTypeID], [AccountLedgerTypeName], [SystemName], [Status], [CodeStartWith], [IsUsedInAccountLedgerMasterForm]) VALUES (5, N'Purchase Ledger', N'PurchaseLedger', 1, N'IL', 0)
GO
INSERT [dbo].[AccountLedgerType] ([AccountLedgerTypeID], [AccountLedgerTypeName], [SystemName], [Status], [CodeStartWith], [IsUsedInAccountLedgerMasterForm]) VALUES (6, N'Sale Ledger', N'SaleLedger', 1, N'IL', 0)
GO
INSERT [dbo].[AccountLedgerType] ([AccountLedgerTypeID], [AccountLedgerTypeName], [SystemName], [Status], [CodeStartWith], [IsUsedInAccountLedgerMasterForm]) VALUES (7, N'Control Codes', N'ControlCodes', 1, N'IL', 0)
GO
INSERT [dbo].[AccountType] ([AccountTypeID], [AccountTypeName], [AccountTypeShortName], [Status]) VALUES (1, N'Income Account', N'I', 1)
GO
INSERT [dbo].[AccountType] ([AccountTypeID], [AccountTypeName], [AccountTypeShortName], [Status]) VALUES (2, N'Expenditure Account', N'E', 1)
GO
INSERT [dbo].[AccountType] ([AccountTypeID], [AccountTypeName], [AccountTypeShortName], [Status]) VALUES (3, N'Balance Sheet Account', N'B', 1)
GO
SET IDENTITY_INSERT [dbo].[BillOutStandings] ON 
GO
INSERT [dbo].[BillOutStandings] ([BillOutStandingsID], [PurchaseSaleBookHeaderID], [VoucherNumber], [VoucherTypeCode], [VoucherDate], [LedgerType], [LedgerTypeCode], [BillAmount], [OSAmount], [IsHold], [HOLDRemarks], [DueDate]) VALUES (1, 3, N'00000001', N'PURCHASEENTRY', CAST(N'2023-09-06T00:00:00.000' AS DateTime), N'SUPPLIERLEDGER', N'S000001', CAST(1036.00 AS Decimal(18, 2)), CAST(1036.00 AS Decimal(18, 2)), 0, NULL, NULL)
GO
INSERT [dbo].[BillOutStandings] ([BillOutStandingsID], [PurchaseSaleBookHeaderID], [VoucherNumber], [VoucherTypeCode], [VoucherDate], [LedgerType], [LedgerTypeCode], [BillAmount], [OSAmount], [IsHold], [HOLDRemarks], [DueDate]) VALUES (3, 4, N'00000001', N'SALEENTRY', CAST(N'2023-09-07T00:00:00.000' AS DateTime), N'CUSTOMERLEDGER', N'C000001', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, NULL, NULL)
GO
INSERT [dbo].[BillOutStandings] ([BillOutStandingsID], [PurchaseSaleBookHeaderID], [VoucherNumber], [VoucherTypeCode], [VoucherDate], [LedgerType], [LedgerTypeCode], [BillAmount], [OSAmount], [IsHold], [HOLDRemarks], [DueDate]) VALUES (5, 5, N'00000001', N'SALEONCHALLAN', CAST(N'2023-09-07T00:00:00.000' AS DateTime), N'CUSTOMERLEDGER', N'C000001', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, NULL, NULL)
GO
INSERT [dbo].[BillOutStandings] ([BillOutStandingsID], [PurchaseSaleBookHeaderID], [VoucherNumber], [VoucherTypeCode], [VoucherDate], [LedgerType], [LedgerTypeCode], [BillAmount], [OSAmount], [IsHold], [HOLDRemarks], [DueDate]) VALUES (6, 6, N'00000002', N'PURCHASEENTRY', CAST(N'2023-09-07T00:00:00.000' AS DateTime), N'SUPPLIERLEDGER', N'S000001', CAST(13000.00 AS Decimal(18, 2)), CAST(13000.00 AS Decimal(18, 2)), 0, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[BillOutStandings] OFF
GO
SET IDENTITY_INSERT [dbo].[CompanyMaster] ON 
GO
INSERT [dbo].[CompanyMaster] ([CompanyId], [CompanyCode], [CompanyName], [Status], [IsDirect], [OrderPreferenceRating], [BillingPreferenceRating], [StockSummaryRequired], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (1, N'000001', N'SUN PHARMACEUTICAL INDUSTRIES LTD.', 1, 1, 0, 0, 1, N'admin', CAST(N'2023-09-04T20:26:34.337' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[CompanyMaster] ([CompanyId], [CompanyCode], [CompanyName], [Status], [IsDirect], [OrderPreferenceRating], [BillingPreferenceRating], [StockSummaryRequired], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (2, N'000002', N'DR. REDDY''S LABORATORIES LTD.', 1, 1, 0, 0, 1, N'admin', CAST(N'2023-09-04T20:26:45.563' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[CompanyMaster] ([CompanyId], [CompanyCode], [CompanyName], [Status], [IsDirect], [OrderPreferenceRating], [BillingPreferenceRating], [StockSummaryRequired], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (3, N'000003', N'CIPLA LTD.', 1, 1, 0, 0, 1, N'admin', CAST(N'2023-09-04T20:26:53.057' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[CompanyMaster] ([CompanyId], [CompanyCode], [CompanyName], [Status], [IsDirect], [OrderPreferenceRating], [BillingPreferenceRating], [StockSummaryRequired], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (4, N'000004', N'LUPIN LIMITED', 1, 1, 0, 0, 1, N'admin', CAST(N'2023-09-04T20:27:00.970' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[CompanyMaster] ([CompanyId], [CompanyCode], [CompanyName], [Status], [IsDirect], [OrderPreferenceRating], [BillingPreferenceRating], [StockSummaryRequired], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (5, N'000005', N'AUROBINDO PHARMA LTD.', 1, 1, 0, 0, 1, N'admin', CAST(N'2023-09-04T20:27:08.480' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[CompanyMaster] ([CompanyId], [CompanyCode], [CompanyName], [Status], [IsDirect], [OrderPreferenceRating], [BillingPreferenceRating], [StockSummaryRequired], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (6, N'000006', N'BIOCON LIMITED', 1, 1, 0, 0, 1, N'admin', CAST(N'2023-09-04T20:27:16.193' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[CompanyMaster] ([CompanyId], [CompanyCode], [CompanyName], [Status], [IsDirect], [OrderPreferenceRating], [BillingPreferenceRating], [StockSummaryRequired], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (7, N'000007', N'CADILA HEALTHCARE LTD.', 1, 1, 0, 0, 1, N'admin', CAST(N'2023-09-04T20:27:23.887' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[CompanyMaster] ([CompanyId], [CompanyCode], [CompanyName], [Status], [IsDirect], [OrderPreferenceRating], [BillingPreferenceRating], [StockSummaryRequired], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (8, N'000008', N'GLENMARK PHARMACEUTICALS LTD.', 1, 1, 0, 0, 1, N'admin', CAST(N'2023-09-04T20:27:30.660' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[CompanyMaster] ([CompanyId], [CompanyCode], [CompanyName], [Status], [IsDirect], [OrderPreferenceRating], [BillingPreferenceRating], [StockSummaryRequired], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (9, N'000009', N'TORRENT PHARMACEUTICALS LTD.', 1, 1, 0, 0, 1, N'admin', CAST(N'2023-09-04T20:27:37.310' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[CompanyMaster] ([CompanyId], [CompanyCode], [CompanyName], [Status], [IsDirect], [OrderPreferenceRating], [BillingPreferenceRating], [StockSummaryRequired], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (10, N'000010', N'DIVI''S LABORATORIES LTD.', 1, 1, 0, 0, 1, N'admin', CAST(N'2023-09-04T20:27:43.623' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[CompanyMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[CustomerCompanyDiscountRef] ON 
GO
INSERT [dbo].[CustomerCompanyDiscountRef] ([CustCompDiscountRefID], [CustomerLedgerID], [CompanyID], [ItemID], [Normal], [Breakage], [Expired], [IsLessEcise]) VALUES (1, 1, 3, NULL, CAST(10.00 AS Decimal(18, 2)), CAST(30.00 AS Decimal(18, 2)), CAST(70.00 AS Decimal(18, 2)), 0)
GO
INSERT [dbo].[CustomerCompanyDiscountRef] ([CustCompDiscountRefID], [CustomerLedgerID], [CompanyID], [ItemID], [Normal], [Breakage], [Expired], [IsLessEcise]) VALUES (2, 2, 5, NULL, CAST(10.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), 0)
GO
SET IDENTITY_INSERT [dbo].[CustomerCompanyDiscountRef] OFF
GO
SET IDENTITY_INSERT [dbo].[CustomerLedger] ON 
GO
INSERT [dbo].[CustomerLedger] ([CustomerLedgerId], [CustomerLedgerCode], [CustomerLedgerName], [CustomerLedgerShortName], [Address], [ContactPerson], [Mobile], [OfficePhone], [ResidentPhone], [EmailAddress], [OpeningBal], [CreditDebit], [TaxRetail], [Status], [ZSMId], [ASMId], [RSMId], [AreaId], [SalesManId], [RouteId], [DLNo], [GSTNo], [CINNo], [LINNo], [ServiceTaxNo], [PANNo], [CreditLimit], [RateTypeID], [IsLessExcise], [CustomerTypeID], [InterestTypeID], [MaxOSAmount], [MaxNumOfOSBill], [MaxBillAmount], [MaxGracePeriod], [SaleBillFormat], [IsFollowConditionStrictly], [Discount], [CentralLocal], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [CustomerLedgerShortDesc], [Telephone]) VALUES (1, N'C000001', N'MR SUNIL SINGH', N'SUNIL', N'sarnath
', N'', N'', N'', N'', N'', NULL, N'C', N'R', 1, 3, 1, 2, 6, 4, 5, N'', N'', N'', N'', N'', N'', 0, NULL, 0, 1, 1, CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), 0, N'', 0, CAST(0.00 AS Decimal(18, 2)), N'L', N'admin', CAST(N'2023-09-07T09:13:20.797' AS DateTime), NULL, NULL, NULL, N'')
GO
INSERT [dbo].[CustomerLedger] ([CustomerLedgerId], [CustomerLedgerCode], [CustomerLedgerName], [CustomerLedgerShortName], [Address], [ContactPerson], [Mobile], [OfficePhone], [ResidentPhone], [EmailAddress], [OpeningBal], [CreditDebit], [TaxRetail], [Status], [ZSMId], [ASMId], [RSMId], [AreaId], [SalesManId], [RouteId], [DLNo], [GSTNo], [CINNo], [LINNo], [ServiceTaxNo], [PANNo], [CreditLimit], [RateTypeID], [IsLessExcise], [CustomerTypeID], [InterestTypeID], [MaxOSAmount], [MaxNumOfOSBill], [MaxBillAmount], [MaxGracePeriod], [SaleBillFormat], [IsFollowConditionStrictly], [Discount], [CentralLocal], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [CustomerLedgerShortDesc], [Telephone]) VALUES (2, N'C000002', N'VAIBHAV', N'', N'
', N'', N'', N'', N'', N'', CAST(500.00 AS Decimal(15, 2)), N'C', N'R', 1, 3, 1, 2, 6, 7, 5, N'', N'', N'', N'', N'', N'DMZPS6187N', 0, NULL, 0, 1, 1, CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), 0, N'', 0, CAST(10.00 AS Decimal(18, 2)), N'L', N'admin', CAST(N'2023-09-14T13:18:42.100' AS DateTime), NULL, NULL, NULL, N'')
GO
SET IDENTITY_INSERT [dbo].[CustomerLedger] OFF
GO
SET IDENTITY_INSERT [dbo].[CustomerType] ON 
GO
INSERT [dbo].[CustomerType] ([CustomerTypeId], [CustomerType], [CustomerTypeShortName], [Status]) VALUES (1, N'WholeSale', N'W', 1)
GO
INSERT [dbo].[CustomerType] ([CustomerTypeId], [CustomerType], [CustomerTypeShortName], [Status]) VALUES (2, N'Retail', N'R', 1)
GO
INSERT [dbo].[CustomerType] ([CustomerTypeId], [CustomerType], [CustomerTypeShortName], [Status]) VALUES (3, N'Individual', N'I', 1)
GO
SET IDENTITY_INSERT [dbo].[CustomerType] OFF
GO
SET IDENTITY_INSERT [dbo].[FIFO] ON 
GO
INSERT [dbo].[FIFO] ([FifoID], [PurchaseSaleBookHeaderID], [VoucherNumber], [VoucherDate], [SRLNO], [ItemCode], [PurchaseBillNo], [Batch], [ExpiryDate], [Quantity], [BalanceQuanity], [PurchaseTypeId], [PurchaseRate], [EffectivePurchaseRate], [SaleRate], [WholeSaleRate], [SpecialRate], [MRP], [Scheme1], [Scheme2], [IsOnHold], [OnHoldRemarks], [MfgDate], [UPC]) VALUES (1, 3, N'00000001', CAST(N'2023-09-06T00:00:00.000' AS DateTime), 1, N'000002001', N'ABC00011', N'BATCH0011', CAST(N'2023-06-09T00:00:00.000' AS DateTime), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, CAST(127.00 AS Decimal(18, 2)), NULL, CAST(145.00 AS Decimal(18, 2)), CAST(142.00 AS Decimal(18, 2)), CAST(140.00 AS Decimal(18, 2)), CAST(150.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, NULL, NULL, NULL)
GO
INSERT [dbo].[FIFO] ([FifoID], [PurchaseSaleBookHeaderID], [VoucherNumber], [VoucherDate], [SRLNO], [ItemCode], [PurchaseBillNo], [Batch], [ExpiryDate], [Quantity], [BalanceQuanity], [PurchaseTypeId], [PurchaseRate], [EffectivePurchaseRate], [SaleRate], [WholeSaleRate], [SpecialRate], [MRP], [Scheme1], [Scheme2], [IsOnHold], [OnHoldRemarks], [MfgDate], [UPC]) VALUES (2, 3, N'00000001', CAST(N'2023-09-06T00:00:00.000' AS DateTime), 2, N'000003001', N'ABC00011', N'BATCH0012', CAST(N'2023-06-09T00:00:00.000' AS DateTime), CAST(50.00 AS Decimal(18, 2)), CAST(49.00 AS Decimal(18, 2)), NULL, CAST(15.00 AS Decimal(18, 2)), NULL, CAST(23.00 AS Decimal(18, 2)), CAST(22.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)), CAST(25.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, NULL, NULL, NULL)
GO
INSERT [dbo].[FIFO] ([FifoID], [PurchaseSaleBookHeaderID], [VoucherNumber], [VoucherDate], [SRLNO], [ItemCode], [PurchaseBillNo], [Batch], [ExpiryDate], [Quantity], [BalanceQuanity], [PurchaseTypeId], [PurchaseRate], [EffectivePurchaseRate], [SaleRate], [WholeSaleRate], [SpecialRate], [MRP], [Scheme1], [Scheme2], [IsOnHold], [OnHoldRemarks], [MfgDate], [UPC]) VALUES (3, 6, N'00000002', CAST(N'2023-09-07T00:00:00.000' AS DateTime), 1, N'000002001', N'ABC0002', N'BATCH0011', CAST(N'2023-09-06T00:00:00.000' AS DateTime), CAST(100.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), NULL, CAST(127.00 AS Decimal(18, 2)), NULL, CAST(145.00 AS Decimal(18, 2)), CAST(142.00 AS Decimal(18, 2)), CAST(140.00 AS Decimal(18, 2)), CAST(150.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, NULL, NULL, NULL)
GO
INSERT [dbo].[FIFO] ([FifoID], [PurchaseSaleBookHeaderID], [VoucherNumber], [VoucherDate], [SRLNO], [ItemCode], [PurchaseBillNo], [Batch], [ExpiryDate], [Quantity], [BalanceQuanity], [PurchaseTypeId], [PurchaseRate], [EffectivePurchaseRate], [SaleRate], [WholeSaleRate], [SpecialRate], [MRP], [Scheme1], [Scheme2], [IsOnHold], [OnHoldRemarks], [MfgDate], [UPC]) VALUES (4, 6, N'00000002', CAST(N'2023-09-07T00:00:00.000' AS DateTime), 2, N'000003001', N'ABC0002', N'BATCH0012', CAST(N'2023-09-06T00:00:00.000' AS DateTime), CAST(20.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)), NULL, CAST(15.00 AS Decimal(18, 2)), NULL, CAST(23.00 AS Decimal(18, 2)), CAST(22.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)), CAST(25.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[FIFO] OFF
GO
SET IDENTITY_INSERT [dbo].[HSNCode] ON 
GO
INSERT [dbo].[HSNCode] ([HSNID], [HSNCode], [HSNDescription], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (4, N'3002', N'3002- Default Description', N'admin', CAST(N'2023-09-06T11:17:46.857' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[HSNCode] ([HSNID], [HSNCode], [HSNDescription], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (5, N'3004', N'3004- Default Description', N'admin', CAST(N'2023-09-06T11:19:49.490' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[HSNCode] OFF
GO
SET IDENTITY_INSERT [dbo].[ItemMaster] ON 
GO
INSERT [dbo].[ItemMaster] ([ItemID], [ItemCode], [ItemName], [CompanyID], [ConversionRate], [ShortName], [Packing], [PurchaseRate], [MRP], [SaleRate], [SpecialRate], [WholeSaleRate], [SaleExcise], [SurchargeOnSale], [TaxOnSale], [Scheme1], [Scheme2], [PurchaseExcise], [UPC], [IsHalfScheme], [IsQTRScheme], [SpecialDiscount], [SpecialDiscountOnQty], [IsFixedDiscount], [FixedDiscountRate], [MaximumQty], [MaximumDiscount], [SurchargeOnPurchase], [TaxOnPurchase], [DiscountRecieved], [SpecialDiscountRecieved], [QtyPerCase], [Location], [MinimumStock], [MaximumStock], [SaleTypeId], [PurchaseTypeId], [Status], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [BATCH], [ExpiryDate], [OpeningQty], [ClosingQty], [SaltCode], [SaltName], [HSNCode]) VALUES (4, N'000003001', N'PARACETAMOL', 3, CAST(2.00 AS Decimal(18, 2)), N'PCM', N'20TAB', CAST(15.00 AS Decimal(18, 2)), CAST(25.00 AS Decimal(18, 2)), CAST(23.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)), CAST(22.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'6009633542646', 0, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(30.00 AS Decimal(18, 2)), N'RCK01', NULL, NULL, 3, 4, 1, N'admin', CAST(N'2023-09-06T11:17:47.013' AS DateTime), NULL, NULL, N'BATCH0012', CAST(N'2023-09-06T00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, N'3002')
GO
INSERT [dbo].[ItemMaster] ([ItemID], [ItemCode], [ItemName], [CompanyID], [ConversionRate], [ShortName], [Packing], [PurchaseRate], [MRP], [SaleRate], [SpecialRate], [WholeSaleRate], [SaleExcise], [SurchargeOnSale], [TaxOnSale], [Scheme1], [Scheme2], [PurchaseExcise], [UPC], [IsHalfScheme], [IsQTRScheme], [SpecialDiscount], [SpecialDiscountOnQty], [IsFixedDiscount], [FixedDiscountRate], [MaximumQty], [MaximumDiscount], [SurchargeOnPurchase], [TaxOnPurchase], [DiscountRecieved], [SpecialDiscountRecieved], [QtyPerCase], [Location], [MinimumStock], [MaximumStock], [SaleTypeId], [PurchaseTypeId], [Status], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [BATCH], [ExpiryDate], [OpeningQty], [ClosingQty], [SaltCode], [SaltName], [HSNCode]) VALUES (5, N'000002001', N'BENADRYL', 2, CAST(0.00 AS Decimal(18, 2)), N'BND', N'50ML', CAST(127.00 AS Decimal(18, 2)), CAST(150.00 AS Decimal(18, 2)), CAST(145.00 AS Decimal(18, 2)), CAST(140.00 AS Decimal(18, 2)), CAST(142.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'6009633542623', 0, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)), N'RCK15', NULL, NULL, 3, 4, 1, N'admin', CAST(N'2023-09-06T11:19:49.490' AS DateTime), NULL, NULL, N'BATCH0011', CAST(N'2023-09-06T00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, N'3004')
GO
SET IDENTITY_INSERT [dbo].[ItemMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[PersonalLedger] ON 
GO
INSERT [dbo].[PersonalLedger] ([PersonalLedgerId], [PersonalLedgerCode], [PersonalLedgerName], [PersonalLedgerShortName], [Address], [ContactPerson], [Mobile], [Pager], [Fax], [OfficePhone], [ResidentPhone], [EmailAddress], [Status], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [PersonalLedgerShortDesc]) VALUES (1, N'P000001', N'MR INDU KANT SINGH', N'RISHOO', N'SARNATH, VARANASI', N'SELF', N'9838952095', NULL, NULL, N'', N'', N'IKSINGH@GMAIL.COM', 1, N'admin', CAST(N'2023-09-04T23:45:51.093' AS DateTime), N'admin', CAST(N'2023-09-04T23:46:09.670' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[PersonalLedger] OFF
GO
SET IDENTITY_INSERT [dbo].[PersonLedgerType] ON 
GO
INSERT [dbo].[PersonLedgerType] ([PersonTypeId], [PersonType], [Status]) VALUES (1, N'Supplier', 1)
GO
INSERT [dbo].[PersonLedgerType] ([PersonTypeId], [PersonType], [Status]) VALUES (2, N'Customer', 1)
GO
INSERT [dbo].[PersonLedgerType] ([PersonTypeId], [PersonType], [Status]) VALUES (3, N'Personal Diary', 1)
GO
SET IDENTITY_INSERT [dbo].[PersonLedgerType] OFF
GO
SET IDENTITY_INSERT [dbo].[PersonRouteMaster] ON 
GO
INSERT [dbo].[PersonRouteMaster] ([PersonRouteID], [PersonRouteCode], [RecordTypeId], [PersonRouteName], [Status], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (1, N'ASM001', 1, N'VIPIN KUMAR VERMA', 1, N'Admin', CAST(N'2023-09-04T23:56:47.547' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PersonRouteMaster] ([PersonRouteID], [PersonRouteCode], [RecordTypeId], [PersonRouteName], [Status], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (2, N'RSM001', 2, N'VIVEK RANA', 1, N'Admin', CAST(N'2023-09-04T23:57:03.537' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PersonRouteMaster] ([PersonRouteID], [PersonRouteCode], [RecordTypeId], [PersonRouteName], [Status], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (3, N'ZSM001', 3, N'ASHISH CHAUBEY', 1, N'Admin', CAST(N'2023-09-04T23:57:16.240' AS DateTime), N'admin', CAST(N'2023-09-14T13:15:45.953' AS DateTime))
GO
INSERT [dbo].[PersonRouteMaster] ([PersonRouteID], [PersonRouteCode], [RecordTypeId], [PersonRouteName], [Status], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (4, N'AREA001', 5, N'MAYANK DIXIT', 1, N'Admin', CAST(N'2023-09-04T23:59:43.807' AS DateTime), N'admin', CAST(N'2023-09-05T00:01:50.243' AS DateTime))
GO
INSERT [dbo].[PersonRouteMaster] ([PersonRouteID], [PersonRouteCode], [RecordTypeId], [PersonRouteName], [Status], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (5, N'ROUTE001', 6, N'ANKUR RAI', 1, N'Admin', CAST(N'2023-09-04T23:59:57.450' AS DateTime), N'admin', CAST(N'2023-09-05T00:00:32.860' AS DateTime))
GO
INSERT [dbo].[PersonRouteMaster] ([PersonRouteID], [PersonRouteCode], [RecordTypeId], [PersonRouteName], [Status], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (6, N'SALESMAN001', 4, N'ARVIND SINGH', 1, N'Admin', CAST(N'2023-09-05T00:00:14.590' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[PersonRouteMaster] ([PersonRouteID], [PersonRouteCode], [RecordTypeId], [PersonRouteName], [Status], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (7, N'AREA002', 5, N'RATIKESH ', 1, N'Admin', CAST(N'2023-09-05T00:10:40.657' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[PersonRouteMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[Privledges] ON 
GO
INSERT [dbo].[Privledges] ([PrivledgeId], [PriviledgeName], [ControlName], [Status], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (1, N'test', NULL, 1, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Privledges] OFF
GO
SET IDENTITY_INSERT [dbo].[PurchaseSaleBookHeader] ON 
GO
INSERT [dbo].[PurchaseSaleBookHeader] ([PurchaseSaleBookHeaderID], [VoucherNumber], [VoucherTypeCode], [VoucherDate], [DueDate], [PurchaseBillNo], [LedgerType], [LedgerTypeCode], [Amount01], [Amount02], [Amount03], [Amount04], [Amount05], [Amount06], [Amount07], [SGST01], [SGST02], [SGST03], [SGST04], [SGST05], [SGST06], [SGST07], [IGST01], [IGST02], [IGST03], [IGST04], [IGST05], [IGST06], [IGST07], [CGST01], [CGST02], [CGST03], [CGST04], [CGST05], [CGST06], [CGST07], [TotalTaxAmount], [SurchargeAmount], [TotalBillAmount], [TotalCostAmount], [TotalGrossAmount], [TotalSchemeAmount], [TotalDiscountAmount], [OtherAmount], [ZSMId], [ASMId], [RSMId], [AreaId], [SalesManId], [RouteId], [FreshBreakageExcess], [ReturnBillNo], [ReturBillDate], [CustomerTypeId], [LocalCentral], [RateTypeId], [OrderNumber], [ChallanNumber], [Message], [Deliveryddress], [DeliveredBy], [CourierName], [CourierDate], [CourierWeight], [PurchaseSaleEntryFormID], [LastBalance], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [SaleChallanHeaderID]) VALUES (3, N'00000001', N'PURCHASEENTRY', CAST(N'2023-09-06T00:00:00.000' AS DateTime), NULL, N'ABC00011', N'SUPPLIERLEDGER', N'S000001', CAST(1000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(18.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.00 AS Decimal(18, 2)), CAST(18.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, CAST(1036.00 AS Decimal(18, 2)), CAST(1941.50 AS Decimal(18, 2)), CAST(2020.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(78.50 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, NULL, NULL, 7, NULL, NULL, NULL, NULL, NULL, NULL, N'L', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, N'admin', CAST(N'2023-09-06T22:56:49.710' AS DateTime), N'admin', CAST(N'2023-09-07T08:53:57.467' AS DateTime), NULL)
GO
INSERT [dbo].[PurchaseSaleBookHeader] ([PurchaseSaleBookHeaderID], [VoucherNumber], [VoucherTypeCode], [VoucherDate], [DueDate], [PurchaseBillNo], [LedgerType], [LedgerTypeCode], [Amount01], [Amount02], [Amount03], [Amount04], [Amount05], [Amount06], [Amount07], [SGST01], [SGST02], [SGST03], [SGST04], [SGST05], [SGST06], [SGST07], [IGST01], [IGST02], [IGST03], [IGST04], [IGST05], [IGST06], [IGST07], [CGST01], [CGST02], [CGST03], [CGST04], [CGST05], [CGST06], [CGST07], [TotalTaxAmount], [SurchargeAmount], [TotalBillAmount], [TotalCostAmount], [TotalGrossAmount], [TotalSchemeAmount], [TotalDiscountAmount], [OtherAmount], [ZSMId], [ASMId], [RSMId], [AreaId], [SalesManId], [RouteId], [FreshBreakageExcess], [ReturnBillNo], [ReturBillDate], [CustomerTypeId], [LocalCentral], [RateTypeId], [OrderNumber], [ChallanNumber], [Message], [Deliveryddress], [DeliveredBy], [CourierName], [CourierDate], [CourierWeight], [PurchaseSaleEntryFormID], [LastBalance], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [SaleChallanHeaderID]) VALUES (4, N'00000001', N'SALEENTRY', CAST(N'2023-09-07T00:00:00.000' AS DateTime), CAST(N'2023-09-07T00:00:00.000' AS DateTime), NULL, N'CUSTOMERLEDGER', N'C000001', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), NULL, CAST(1450.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(72.50 AS Decimal(18, 2)), NULL, 3, 1, 2, 6, 4, 5, NULL, NULL, NULL, NULL, N'L', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, N'admin', CAST(N'2023-09-07T09:49:15.337' AS DateTime), N'admin', CAST(N'2023-09-07T09:49:17.017' AS DateTime), NULL)
GO
INSERT [dbo].[PurchaseSaleBookHeader] ([PurchaseSaleBookHeaderID], [VoucherNumber], [VoucherTypeCode], [VoucherDate], [DueDate], [PurchaseBillNo], [LedgerType], [LedgerTypeCode], [Amount01], [Amount02], [Amount03], [Amount04], [Amount05], [Amount06], [Amount07], [SGST01], [SGST02], [SGST03], [SGST04], [SGST05], [SGST06], [SGST07], [IGST01], [IGST02], [IGST03], [IGST04], [IGST05], [IGST06], [IGST07], [CGST01], [CGST02], [CGST03], [CGST04], [CGST05], [CGST06], [CGST07], [TotalTaxAmount], [SurchargeAmount], [TotalBillAmount], [TotalCostAmount], [TotalGrossAmount], [TotalSchemeAmount], [TotalDiscountAmount], [OtherAmount], [ZSMId], [ASMId], [RSMId], [AreaId], [SalesManId], [RouteId], [FreshBreakageExcess], [ReturnBillNo], [ReturBillDate], [CustomerTypeId], [LocalCentral], [RateTypeId], [OrderNumber], [ChallanNumber], [Message], [Deliveryddress], [DeliveredBy], [CourierName], [CourierDate], [CourierWeight], [PurchaseSaleEntryFormID], [LastBalance], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [SaleChallanHeaderID]) VALUES (5, N'00000001', N'SALEONCHALLAN', CAST(N'2023-09-07T00:00:00.000' AS DateTime), CAST(N'2023-09-07T00:00:00.000' AS DateTime), NULL, N'CUSTOMERLEDGER', N'C000001', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), NULL, CAST(23.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.46 AS Decimal(18, 2)), NULL, 3, 1, 2, 6, 4, 5, NULL, NULL, NULL, NULL, N'L', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, N'admin', CAST(N'2023-09-07T09:57:54.727' AS DateTime), N'admin', CAST(N'2023-09-07T09:57:56.903' AS DateTime), NULL)
GO
INSERT [dbo].[PurchaseSaleBookHeader] ([PurchaseSaleBookHeaderID], [VoucherNumber], [VoucherTypeCode], [VoucherDate], [DueDate], [PurchaseBillNo], [LedgerType], [LedgerTypeCode], [Amount01], [Amount02], [Amount03], [Amount04], [Amount05], [Amount06], [Amount07], [SGST01], [SGST02], [SGST03], [SGST04], [SGST05], [SGST06], [SGST07], [IGST01], [IGST02], [IGST03], [IGST04], [IGST05], [IGST06], [IGST07], [CGST01], [CGST02], [CGST03], [CGST04], [CGST05], [CGST06], [CGST07], [TotalTaxAmount], [SurchargeAmount], [TotalBillAmount], [TotalCostAmount], [TotalGrossAmount], [TotalSchemeAmount], [TotalDiscountAmount], [OtherAmount], [ZSMId], [ASMId], [RSMId], [AreaId], [SalesManId], [RouteId], [FreshBreakageExcess], [ReturnBillNo], [ReturBillDate], [CustomerTypeId], [LocalCentral], [RateTypeId], [OrderNumber], [ChallanNumber], [Message], [Deliveryddress], [DeliveredBy], [CourierName], [CourierDate], [CourierWeight], [PurchaseSaleEntryFormID], [LastBalance], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [SaleChallanHeaderID]) VALUES (6, N'00000002', N'PURCHASEENTRY', CAST(N'2023-09-07T00:00:00.000' AS DateTime), NULL, N'ABC0002', N'SUPPLIERLEDGER', N'S000001', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, CAST(13000.00 AS Decimal(18, 2)), CAST(12359.00 AS Decimal(18, 2)), CAST(13000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(641.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, NULL, NULL, 7, NULL, NULL, NULL, NULL, NULL, NULL, N'L', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, N'admin', CAST(N'2023-09-07T10:25:14.817' AS DateTime), N'admin', CAST(N'2023-09-07T10:26:54.133' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[PurchaseSaleBookHeader] OFF
GO
SET IDENTITY_INSERT [dbo].[PurchaseSaleBookLineItem] ON 
GO
INSERT [dbo].[PurchaseSaleBookLineItem] ([PurchaseSaleBookLineItemID], [PurchaseSaleBookHeaderID], [FifoID], [PurchaseBillDate], [PurchaseVoucherNumber], [PurchaseSrlNo], [ItemCode], [Batch], [BatchNew], [Quantity], [FreeQuantity], [PurchaseSaleRate], [EffecivePurchaseSaleRate], [PurchaseSaleTypeCode], [SurCharge], [SalePurchaseTax], [LocalCentral], [SGST], [IGST], [CGST], [Amount], [Discount], [SpecialDiscount], [DiscountQuantity], [VolumeDiscount], [Scheme1], [Scheme2], [IsHalfScheme], [HalfSchemeRate], [CostAmount], [GrossAmount], [SchemeAmount], [DiscountAmount], [SurchargeAmount], [ConversionRate], [MRP], [ExpiryDate], [SaleRate], [WholeSaleRate], [SpecialRate], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [TaxAmount], [SpecialDiscountAmount], [VolumeDiscountAmount], [TotalDiscountAmount], [MfgDate]) VALUES (1, 3, NULL, NULL, NULL, 1, N'000002001', N'BATCH0011', N'BATCH0011', CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(127.00 AS Decimal(18, 2)), NULL, N'L000004', NULL, CAST(0.00 AS Decimal(18, 2)), N'L', CAST(0.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), CAST(1270.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, NULL, NULL, CAST(1270.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(63.50 AS Decimal(18, 2)), NULL, NULL, CAST(150.00 AS Decimal(18, 2)), CAST(N'2023-06-09T00:00:00.000' AS DateTime), CAST(145.00 AS Decimal(18, 2)), CAST(142.00 AS Decimal(18, 2)), CAST(140.00 AS Decimal(18, 2)), N'admin', CAST(N'2023-09-06T22:56:52.317' AS DateTime), N'admin', CAST(N'2023-09-06T22:57:20.927' AS DateTime), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(63.50 AS Decimal(18, 2)), NULL)
GO
INSERT [dbo].[PurchaseSaleBookLineItem] ([PurchaseSaleBookLineItemID], [PurchaseSaleBookHeaderID], [FifoID], [PurchaseBillDate], [PurchaseVoucherNumber], [PurchaseSrlNo], [ItemCode], [Batch], [BatchNew], [Quantity], [FreeQuantity], [PurchaseSaleRate], [EffecivePurchaseSaleRate], [PurchaseSaleTypeCode], [SurCharge], [SalePurchaseTax], [LocalCentral], [SGST], [IGST], [CGST], [Amount], [Discount], [SpecialDiscount], [DiscountQuantity], [VolumeDiscount], [Scheme1], [Scheme2], [IsHalfScheme], [HalfSchemeRate], [CostAmount], [GrossAmount], [SchemeAmount], [DiscountAmount], [SurchargeAmount], [ConversionRate], [MRP], [ExpiryDate], [SaleRate], [WholeSaleRate], [SpecialRate], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [TaxAmount], [SpecialDiscountAmount], [VolumeDiscountAmount], [TotalDiscountAmount], [MfgDate]) VALUES (2, 3, NULL, NULL, NULL, 2, N'000003001', N'BATCH0012', N'BATCH0012', CAST(50.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(15.00 AS Decimal(18, 2)), NULL, N'L000004', NULL, CAST(0.00 AS Decimal(18, 2)), N'L', CAST(0.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), CAST(750.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, NULL, NULL, CAST(750.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(15.00 AS Decimal(18, 2)), NULL, NULL, CAST(25.00 AS Decimal(18, 2)), CAST(N'2023-06-09T00:00:00.000' AS DateTime), CAST(23.00 AS Decimal(18, 2)), CAST(22.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)), N'admin', CAST(N'2023-09-06T22:57:25.230' AS DateTime), N'admin', CAST(N'2023-09-06T22:57:41.677' AS DateTime), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(15.00 AS Decimal(18, 2)), NULL)
GO
INSERT [dbo].[PurchaseSaleBookLineItem] ([PurchaseSaleBookLineItemID], [PurchaseSaleBookHeaderID], [FifoID], [PurchaseBillDate], [PurchaseVoucherNumber], [PurchaseSrlNo], [ItemCode], [Batch], [BatchNew], [Quantity], [FreeQuantity], [PurchaseSaleRate], [EffecivePurchaseSaleRate], [PurchaseSaleTypeCode], [SurCharge], [SalePurchaseTax], [LocalCentral], [SGST], [IGST], [CGST], [Amount], [Discount], [SpecialDiscount], [DiscountQuantity], [VolumeDiscount], [Scheme1], [Scheme2], [IsHalfScheme], [HalfSchemeRate], [CostAmount], [GrossAmount], [SchemeAmount], [DiscountAmount], [SurchargeAmount], [ConversionRate], [MRP], [ExpiryDate], [SaleRate], [WholeSaleRate], [SpecialRate], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [TaxAmount], [SpecialDiscountAmount], [VolumeDiscountAmount], [TotalDiscountAmount], [MfgDate]) VALUES (4, 4, 1, CAST(N'2023-09-06T00:00:00.000' AS DateTime), N'00000001', 1, N'000002001', N'BATCH0011', N'BATCH0011', CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(127.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'L000003', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'L', CAST(0.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), CAST(1450.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, CAST(1450.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(72.50 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), CAST(150.00 AS Decimal(18, 2)), CAST(N'2023-06-09T00:00:00.000' AS DateTime), CAST(145.00 AS Decimal(18, 2)), CAST(142.00 AS Decimal(18, 2)), CAST(140.00 AS Decimal(18, 2)), N'admin', CAST(N'2023-09-07T09:49:30.387' AS DateTime), N'admin', CAST(N'2023-09-07T09:57:28.483' AS DateTime), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(72.50 AS Decimal(18, 2)), NULL)
GO
INSERT [dbo].[PurchaseSaleBookLineItem] ([PurchaseSaleBookLineItemID], [PurchaseSaleBookHeaderID], [FifoID], [PurchaseBillDate], [PurchaseVoucherNumber], [PurchaseSrlNo], [ItemCode], [Batch], [BatchNew], [Quantity], [FreeQuantity], [PurchaseSaleRate], [EffecivePurchaseSaleRate], [PurchaseSaleTypeCode], [SurCharge], [SalePurchaseTax], [LocalCentral], [SGST], [IGST], [CGST], [Amount], [Discount], [SpecialDiscount], [DiscountQuantity], [VolumeDiscount], [Scheme1], [Scheme2], [IsHalfScheme], [HalfSchemeRate], [CostAmount], [GrossAmount], [SchemeAmount], [DiscountAmount], [SurchargeAmount], [ConversionRate], [MRP], [ExpiryDate], [SaleRate], [WholeSaleRate], [SpecialRate], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [TaxAmount], [SpecialDiscountAmount], [VolumeDiscountAmount], [TotalDiscountAmount], [MfgDate]) VALUES (6, 5, 2, CAST(N'2023-09-06T00:00:00.000' AS DateTime), N'00000001', 2, N'000003001', N'BATCH0012', N'BATCH0012', CAST(1.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(15.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'L000003', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'L', CAST(0.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), CAST(23.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), NULL, CAST(23.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.46 AS Decimal(18, 2)), NULL, CAST(2.00 AS Decimal(18, 2)), CAST(25.00 AS Decimal(18, 2)), CAST(N'2023-06-09T00:00:00.000' AS DateTime), CAST(23.00 AS Decimal(18, 2)), CAST(22.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)), N'admin', CAST(N'2023-09-07T09:58:19.557' AS DateTime), N'admin', CAST(N'2023-09-07T09:58:30.727' AS DateTime), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.46 AS Decimal(18, 2)), NULL)
GO
INSERT [dbo].[PurchaseSaleBookLineItem] ([PurchaseSaleBookLineItemID], [PurchaseSaleBookHeaderID], [FifoID], [PurchaseBillDate], [PurchaseVoucherNumber], [PurchaseSrlNo], [ItemCode], [Batch], [BatchNew], [Quantity], [FreeQuantity], [PurchaseSaleRate], [EffecivePurchaseSaleRate], [PurchaseSaleTypeCode], [SurCharge], [SalePurchaseTax], [LocalCentral], [SGST], [IGST], [CGST], [Amount], [Discount], [SpecialDiscount], [DiscountQuantity], [VolumeDiscount], [Scheme1], [Scheme2], [IsHalfScheme], [HalfSchemeRate], [CostAmount], [GrossAmount], [SchemeAmount], [DiscountAmount], [SurchargeAmount], [ConversionRate], [MRP], [ExpiryDate], [SaleRate], [WholeSaleRate], [SpecialRate], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [TaxAmount], [SpecialDiscountAmount], [VolumeDiscountAmount], [TotalDiscountAmount], [MfgDate]) VALUES (7, 6, NULL, NULL, NULL, 1, N'000002001', N'BATCH0011', N'BATCH0011', CAST(100.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(127.00 AS Decimal(18, 2)), NULL, N'L000004', NULL, CAST(0.00 AS Decimal(18, 2)), N'L', CAST(0.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), CAST(12700.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, NULL, NULL, CAST(12700.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(635.00 AS Decimal(18, 2)), NULL, NULL, CAST(150.00 AS Decimal(18, 2)), CAST(N'2023-09-06T00:00:00.000' AS DateTime), CAST(145.00 AS Decimal(18, 2)), CAST(142.00 AS Decimal(18, 2)), CAST(140.00 AS Decimal(18, 2)), N'admin', CAST(N'2023-09-07T10:25:21.813' AS DateTime), N'admin', CAST(N'2023-09-07T10:26:04.410' AS DateTime), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(635.00 AS Decimal(18, 2)), NULL)
GO
INSERT [dbo].[PurchaseSaleBookLineItem] ([PurchaseSaleBookLineItemID], [PurchaseSaleBookHeaderID], [FifoID], [PurchaseBillDate], [PurchaseVoucherNumber], [PurchaseSrlNo], [ItemCode], [Batch], [BatchNew], [Quantity], [FreeQuantity], [PurchaseSaleRate], [EffecivePurchaseSaleRate], [PurchaseSaleTypeCode], [SurCharge], [SalePurchaseTax], [LocalCentral], [SGST], [IGST], [CGST], [Amount], [Discount], [SpecialDiscount], [DiscountQuantity], [VolumeDiscount], [Scheme1], [Scheme2], [IsHalfScheme], [HalfSchemeRate], [CostAmount], [GrossAmount], [SchemeAmount], [DiscountAmount], [SurchargeAmount], [ConversionRate], [MRP], [ExpiryDate], [SaleRate], [WholeSaleRate], [SpecialRate], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [TaxAmount], [SpecialDiscountAmount], [VolumeDiscountAmount], [TotalDiscountAmount], [MfgDate]) VALUES (8, 6, NULL, NULL, NULL, 2, N'000003001', N'BATCH0012', N'BATCH0012', CAST(20.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(15.00 AS Decimal(18, 2)), NULL, N'L000004', NULL, CAST(0.00 AS Decimal(18, 2)), N'L', CAST(0.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), CAST(300.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, NULL, NULL, CAST(300.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(6.00 AS Decimal(18, 2)), NULL, NULL, CAST(25.00 AS Decimal(18, 2)), CAST(N'2023-09-06T00:00:00.000' AS DateTime), CAST(23.00 AS Decimal(18, 2)), CAST(22.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)), N'admin', CAST(N'2023-09-07T10:26:08.240' AS DateTime), N'admin', CAST(N'2023-09-07T10:26:16.967' AS DateTime), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(6.00 AS Decimal(18, 2)), NULL)
GO
SET IDENTITY_INSERT [dbo].[PurchaseSaleBookLineItem] OFF
GO
INSERT [dbo].[PurchaseSaleEntryType] ([PurchaseSaleEntryTypeID], [PurchaseSaleTypeCode], [PurchaseSaleTypeName]) VALUES (1, N'L', N'Local')
GO
INSERT [dbo].[PurchaseSaleEntryType] ([PurchaseSaleEntryTypeID], [PurchaseSaleTypeCode], [PurchaseSaleTypeName]) VALUES (2, N'C', N'Central')
GO
INSERT [dbo].[RateType] ([RateTypeId], [RateTypeName], [SystemName], [Status]) VALUES (1, N'Standard Rate', N'SR', 1)
GO
INSERT [dbo].[RateType] ([RateTypeId], [RateTypeName], [SystemName], [Status]) VALUES (2, N'Discounted Rate', N'DR', 1)
GO
INSERT [dbo].[RateType] ([RateTypeId], [RateTypeName], [SystemName], [Status]) VALUES (3, N'Contract Rate', N'CR', 1)
GO
SET IDENTITY_INSERT [dbo].[RecordType] ON 
GO
INSERT [dbo].[RecordType] ([RecordTypeId], [RecordType], [SystemName], [Status]) VALUES (1, N'A.S.M', N'ASM', 1)
GO
INSERT [dbo].[RecordType] ([RecordTypeId], [RecordType], [SystemName], [Status]) VALUES (2, N'R.S.M', N'RSM', 1)
GO
INSERT [dbo].[RecordType] ([RecordTypeId], [RecordType], [SystemName], [Status]) VALUES (3, N'Z.S.M', N'ZSM', 1)
GO
INSERT [dbo].[RecordType] ([RecordTypeId], [RecordType], [SystemName], [Status]) VALUES (4, N'Sales Man', N'SALESMAN', 1)
GO
INSERT [dbo].[RecordType] ([RecordTypeId], [RecordType], [SystemName], [Status]) VALUES (5, N'Area', N'AREA', 1)
GO
INSERT [dbo].[RecordType] ([RecordTypeId], [RecordType], [SystemName], [Status]) VALUES (6, N'Route', N'ROUTE', 1)
GO
SET IDENTITY_INSERT [dbo].[RecordType] OFF
GO
INSERT [dbo].[RolePrivledges] ([RolePrivledgeID], [RoleId], [PrivledgeId]) VALUES (0, 2, 1)
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName], [Status], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (1, N'test', 1, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName], [Status], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (2, N'Role 1', 1, N'admin', CAST(N'2017-05-18T22:36:58.617' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[SupplierCompanyDiscountRef] ON 
GO
INSERT [dbo].[SupplierCompanyDiscountRef] ([CustCompDiscountRefID], [SupplierLedgerID], [CompanyID], [ItemID], [Normal], [Breakage], [Expired], [IsLessEcise]) VALUES (3, 1, 5, NULL, CAST(10.00 AS Decimal(18, 2)), CAST(15.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), 0)
GO
INSERT [dbo].[SupplierCompanyDiscountRef] ([CustCompDiscountRefID], [SupplierLedgerID], [CompanyID], [ItemID], [Normal], [Breakage], [Expired], [IsLessEcise]) VALUES (4, 1, 7, NULL, CAST(20.00 AS Decimal(18, 2)), CAST(35.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), 0)
GO
INSERT [dbo].[SupplierCompanyDiscountRef] ([CustCompDiscountRefID], [SupplierLedgerID], [CompanyID], [ItemID], [Normal], [Breakage], [Expired], [IsLessEcise]) VALUES (5, 1, 3, NULL, CAST(30.00 AS Decimal(18, 2)), CAST(40.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), 0)
GO
INSERT [dbo].[SupplierCompanyDiscountRef] ([CustCompDiscountRefID], [SupplierLedgerID], [CompanyID], [ItemID], [Normal], [Breakage], [Expired], [IsLessEcise]) VALUES (6, 1, 2, NULL, CAST(30.00 AS Decimal(18, 2)), CAST(45.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), 0)
GO
SET IDENTITY_INSERT [dbo].[SupplierCompanyDiscountRef] OFF
GO
SET IDENTITY_INSERT [dbo].[SupplierLedger] ON 
GO
INSERT [dbo].[SupplierLedger] ([SupplierLedgerId], [SupplierLedgerCode], [SupplierLedgerName], [SupplierLedgerShortName], [Address], [ContactPerson], [Mobile], [Pager], [Fax], [OfficePhone], [ResidentPhone], [EmailAddress], [OpeningBal], [CreditDebit], [TaxRetail], [Status], [AreaId], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [SupplierLedgerShortDesc], [PurchaseTypeID], [DLNo], [GSTNo], [CINNo], [LINNo], [ServiceTaxNo], [PANNo]) VALUES (1, N'S000001', N'MR HEMANT SINGH', N'HEMANT', N'POISAR, MUMBAI
', N'', N'', NULL, NULL, N'', N'', N'', CAST(1000.00 AS Decimal(15, 2)), N'C', N'R', 1, 7, N'admin', CAST(N'2023-09-05T00:15:55.343' AS DateTime), N'admin', CAST(N'2023-09-05T00:18:24.470' AS DateTime), NULL, 4, N'', N'', N'', N'', N'', N'')
GO
SET IDENTITY_INSERT [dbo].[SupplierLedger] OFF
GO
SET IDENTITY_INSERT [dbo].[TempPurchaseSaleBookHeader] ON 
GO
INSERT [dbo].[TempPurchaseSaleBookHeader] ([PurchaseSaleBookHeaderID], [VoucherTypeCode], [VoucherDate], [DueDate], [PurchaseBillNo], [LedgerType], [LedgerTypeCode], [Amount01], [Amount02], [Amount03], [Amount04], [Amount05], [Amount06], [Amount07], [SGST01], [SGST02], [SGST03], [SGST04], [SGST05], [SGST06], [SGST07], [IGST01], [IGST02], [IGST03], [IGST04], [IGST05], [IGST06], [IGST07], [CGST01], [CGST02], [CGST03], [CGST04], [CGST05], [CGST06], [CGST07], [TotalTaxAmount], [SurchargeAmount], [TotalBillAmount], [TotalCostAmount], [TotalGrossAmount], [TotalSchemeAmount], [TotalDiscountAmount], [OtherAmount], [FreshBreakageExcess], [ReturnBillNo], [ReturBillDate], [LocalCentral], [OrderNumber], [ChallanNumber], [Message], [Deliveryddress], [DeliveredBy], [CourierName], [CourierDate], [CourierWeight], [PurchaseEntryFormID], [LastBalance], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [OldPurchaseSaleBookHeaderID], [SaleChallanHeaderID]) VALUES (4, N'PURCHASEENTRY', CAST(N'2023-09-06T00:00:00.000' AS DateTime), NULL, N'ABC00011', N'SUPPLIERLEDGER', N'S000001', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'L', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, N'admin', CAST(N'2023-09-06T22:10:38.627' AS DateTime), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[TempPurchaseSaleBookHeader] ([PurchaseSaleBookHeaderID], [VoucherTypeCode], [VoucherDate], [DueDate], [PurchaseBillNo], [LedgerType], [LedgerTypeCode], [Amount01], [Amount02], [Amount03], [Amount04], [Amount05], [Amount06], [Amount07], [SGST01], [SGST02], [SGST03], [SGST04], [SGST05], [SGST06], [SGST07], [IGST01], [IGST02], [IGST03], [IGST04], [IGST05], [IGST06], [IGST07], [CGST01], [CGST02], [CGST03], [CGST04], [CGST05], [CGST06], [CGST07], [TotalTaxAmount], [SurchargeAmount], [TotalBillAmount], [TotalCostAmount], [TotalGrossAmount], [TotalSchemeAmount], [TotalDiscountAmount], [OtherAmount], [FreshBreakageExcess], [ReturnBillNo], [ReturBillDate], [LocalCentral], [OrderNumber], [ChallanNumber], [Message], [Deliveryddress], [DeliveredBy], [CourierName], [CourierDate], [CourierWeight], [PurchaseEntryFormID], [LastBalance], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [OldPurchaseSaleBookHeaderID], [SaleChallanHeaderID]) VALUES (6, N'PURCHASEENTRY', CAST(N'2023-09-06T00:00:00.000' AS DateTime), NULL, N'ABC00011', N'SUPPLIERLEDGER', N'S000001', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'L', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, N'admin', CAST(N'2023-09-06T22:33:06.377' AS DateTime), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[TempPurchaseSaleBookHeader] ([PurchaseSaleBookHeaderID], [VoucherTypeCode], [VoucherDate], [DueDate], [PurchaseBillNo], [LedgerType], [LedgerTypeCode], [Amount01], [Amount02], [Amount03], [Amount04], [Amount05], [Amount06], [Amount07], [SGST01], [SGST02], [SGST03], [SGST04], [SGST05], [SGST06], [SGST07], [IGST01], [IGST02], [IGST03], [IGST04], [IGST05], [IGST06], [IGST07], [CGST01], [CGST02], [CGST03], [CGST04], [CGST05], [CGST06], [CGST07], [TotalTaxAmount], [SurchargeAmount], [TotalBillAmount], [TotalCostAmount], [TotalGrossAmount], [TotalSchemeAmount], [TotalDiscountAmount], [OtherAmount], [FreshBreakageExcess], [ReturnBillNo], [ReturBillDate], [LocalCentral], [OrderNumber], [ChallanNumber], [Message], [Deliveryddress], [DeliveredBy], [CourierName], [CourierDate], [CourierWeight], [PurchaseEntryFormID], [LastBalance], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [OldPurchaseSaleBookHeaderID], [SaleChallanHeaderID]) VALUES (7, N'PURCHASEENTRY', CAST(N'2023-09-06T00:00:00.000' AS DateTime), NULL, N'ABC00011', N'SUPPLIERLEDGER', N'S000001', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'L', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, N'admin', CAST(N'2023-09-06T22:37:10.693' AS DateTime), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[TempPurchaseSaleBookHeader] ([PurchaseSaleBookHeaderID], [VoucherTypeCode], [VoucherDate], [DueDate], [PurchaseBillNo], [LedgerType], [LedgerTypeCode], [Amount01], [Amount02], [Amount03], [Amount04], [Amount05], [Amount06], [Amount07], [SGST01], [SGST02], [SGST03], [SGST04], [SGST05], [SGST06], [SGST07], [IGST01], [IGST02], [IGST03], [IGST04], [IGST05], [IGST06], [IGST07], [CGST01], [CGST02], [CGST03], [CGST04], [CGST05], [CGST06], [CGST07], [TotalTaxAmount], [SurchargeAmount], [TotalBillAmount], [TotalCostAmount], [TotalGrossAmount], [TotalSchemeAmount], [TotalDiscountAmount], [OtherAmount], [FreshBreakageExcess], [ReturnBillNo], [ReturBillDate], [LocalCentral], [OrderNumber], [ChallanNumber], [Message], [Deliveryddress], [DeliveredBy], [CourierName], [CourierDate], [CourierWeight], [PurchaseEntryFormID], [LastBalance], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [OldPurchaseSaleBookHeaderID], [SaleChallanHeaderID]) VALUES (11, N'SALEENTRY', CAST(N'2023-09-07T00:00:00.000' AS DateTime), CAST(N'2023-09-07T00:00:00.000' AS DateTime), NULL, N'CUSTOMERLEDGER', N'C000001', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'L', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, N'admin', CAST(N'2023-09-07T09:20:22.450' AS DateTime), N'admin', CAST(N'2023-09-07T09:20:26.197' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[TempPurchaseSaleBookHeader] ([PurchaseSaleBookHeaderID], [VoucherTypeCode], [VoucherDate], [DueDate], [PurchaseBillNo], [LedgerType], [LedgerTypeCode], [Amount01], [Amount02], [Amount03], [Amount04], [Amount05], [Amount06], [Amount07], [SGST01], [SGST02], [SGST03], [SGST04], [SGST05], [SGST06], [SGST07], [IGST01], [IGST02], [IGST03], [IGST04], [IGST05], [IGST06], [IGST07], [CGST01], [CGST02], [CGST03], [CGST04], [CGST05], [CGST06], [CGST07], [TotalTaxAmount], [SurchargeAmount], [TotalBillAmount], [TotalCostAmount], [TotalGrossAmount], [TotalSchemeAmount], [TotalDiscountAmount], [OtherAmount], [FreshBreakageExcess], [ReturnBillNo], [ReturBillDate], [LocalCentral], [OrderNumber], [ChallanNumber], [Message], [Deliveryddress], [DeliveredBy], [CourierName], [CourierDate], [CourierWeight], [PurchaseEntryFormID], [LastBalance], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [OldPurchaseSaleBookHeaderID], [SaleChallanHeaderID]) VALUES (12, N'SALEENTRY', CAST(N'2023-09-07T00:00:00.000' AS DateTime), CAST(N'2023-09-07T00:00:00.000' AS DateTime), NULL, N'CUSTOMERLEDGER', N'C000001', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'L', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, N'admin', CAST(N'2023-09-07T09:33:14.847' AS DateTime), N'admin', CAST(N'2023-09-07T09:33:17.977' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[TempPurchaseSaleBookHeader] ([PurchaseSaleBookHeaderID], [VoucherTypeCode], [VoucherDate], [DueDate], [PurchaseBillNo], [LedgerType], [LedgerTypeCode], [Amount01], [Amount02], [Amount03], [Amount04], [Amount05], [Amount06], [Amount07], [SGST01], [SGST02], [SGST03], [SGST04], [SGST05], [SGST06], [SGST07], [IGST01], [IGST02], [IGST03], [IGST04], [IGST05], [IGST06], [IGST07], [CGST01], [CGST02], [CGST03], [CGST04], [CGST05], [CGST06], [CGST07], [TotalTaxAmount], [SurchargeAmount], [TotalBillAmount], [TotalCostAmount], [TotalGrossAmount], [TotalSchemeAmount], [TotalDiscountAmount], [OtherAmount], [FreshBreakageExcess], [ReturnBillNo], [ReturBillDate], [LocalCentral], [OrderNumber], [ChallanNumber], [Message], [Deliveryddress], [DeliveredBy], [CourierName], [CourierDate], [CourierWeight], [PurchaseEntryFormID], [LastBalance], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [OldPurchaseSaleBookHeaderID], [SaleChallanHeaderID]) VALUES (13, N'SALEENTRY', CAST(N'2023-09-07T00:00:00.000' AS DateTime), CAST(N'2023-09-07T00:00:00.000' AS DateTime), NULL, N'CUSTOMERLEDGER', N'C000001', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'L', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, N'admin', CAST(N'2023-09-07T09:34:41.880' AS DateTime), N'admin', CAST(N'2023-09-07T09:34:43.173' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[TempPurchaseSaleBookHeader] ([PurchaseSaleBookHeaderID], [VoucherTypeCode], [VoucherDate], [DueDate], [PurchaseBillNo], [LedgerType], [LedgerTypeCode], [Amount01], [Amount02], [Amount03], [Amount04], [Amount05], [Amount06], [Amount07], [SGST01], [SGST02], [SGST03], [SGST04], [SGST05], [SGST06], [SGST07], [IGST01], [IGST02], [IGST03], [IGST04], [IGST05], [IGST06], [IGST07], [CGST01], [CGST02], [CGST03], [CGST04], [CGST05], [CGST06], [CGST07], [TotalTaxAmount], [SurchargeAmount], [TotalBillAmount], [TotalCostAmount], [TotalGrossAmount], [TotalSchemeAmount], [TotalDiscountAmount], [OtherAmount], [FreshBreakageExcess], [ReturnBillNo], [ReturBillDate], [LocalCentral], [OrderNumber], [ChallanNumber], [Message], [Deliveryddress], [DeliveredBy], [CourierName], [CourierDate], [CourierWeight], [PurchaseEntryFormID], [LastBalance], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [OldPurchaseSaleBookHeaderID], [SaleChallanHeaderID]) VALUES (17, N'SALEENTRY', CAST(N'2023-09-07T00:00:00.000' AS DateTime), CAST(N'2023-09-07T00:00:00.000' AS DateTime), NULL, N'CUSTOMERLEDGER', N'C000001', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'L', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, N'admin', CAST(N'2023-09-07T09:49:15.337' AS DateTime), N'admin', CAST(N'2023-09-07T09:49:17.017' AS DateTime), 4, NULL)
GO
INSERT [dbo].[TempPurchaseSaleBookHeader] ([PurchaseSaleBookHeaderID], [VoucherTypeCode], [VoucherDate], [DueDate], [PurchaseBillNo], [LedgerType], [LedgerTypeCode], [Amount01], [Amount02], [Amount03], [Amount04], [Amount05], [Amount06], [Amount07], [SGST01], [SGST02], [SGST03], [SGST04], [SGST05], [SGST06], [SGST07], [IGST01], [IGST02], [IGST03], [IGST04], [IGST05], [IGST06], [IGST07], [CGST01], [CGST02], [CGST03], [CGST04], [CGST05], [CGST06], [CGST07], [TotalTaxAmount], [SurchargeAmount], [TotalBillAmount], [TotalCostAmount], [TotalGrossAmount], [TotalSchemeAmount], [TotalDiscountAmount], [OtherAmount], [FreshBreakageExcess], [ReturnBillNo], [ReturBillDate], [LocalCentral], [OrderNumber], [ChallanNumber], [Message], [Deliveryddress], [DeliveredBy], [CourierName], [CourierDate], [CourierWeight], [PurchaseEntryFormID], [LastBalance], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [OldPurchaseSaleBookHeaderID], [SaleChallanHeaderID]) VALUES (21, N'SALEENTRY', CAST(N'2023-09-07T00:00:00.000' AS DateTime), CAST(N'2023-09-07T00:00:00.000' AS DateTime), NULL, N'CUSTOMERLEDGER', N'C000001', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'L', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, N'admin', CAST(N'2023-09-07T10:06:21.893' AS DateTime), N'admin', CAST(N'2023-09-07T10:06:22.000' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[TempPurchaseSaleBookHeader] OFF
GO
SET IDENTITY_INSERT [dbo].[TempPurchaseSaleBookLineItem] ON 
GO
INSERT [dbo].[TempPurchaseSaleBookLineItem] ([PurchaseSaleBookLineItemID], [PurchaseSaleBookHeaderID], [FifoID], [PurchaseBillDate], [PurchaseVoucherNumber], [PurchaseSrlNo], [ItemCode], [Batch], [BatchNew], [Quantity], [FreeQuantity], [PurchaseSaleRate], [EffecivePurchaseSaleRate], [PurchaseSaleTypeCode], [SurCharge], [PurchaseSaleTax], [LocalCentral], [SGST], [IGST], [CGST], [Amount], [Discount], [SpecialDiscount], [DiscountQuantity], [VolumeDiscount], [Scheme1], [Scheme2], [IsHalfScheme], [HalfSchemeRate], [ConversionRate], [MRP], [ExpiryDate], [SaleRate], [WholeSaleRate], [SpecialRate], [CostAmount], [GrossAmount], [SchemeAmount], [DiscountAmount], [SurchargeAmount], [TaxAmount], [SpecialDiscountAmount], [VolumeDiscountAmount], [TotalDiscountAmount], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [UsedQuantity], [BalanceQuantity], [OldPurchaseSaleBookLineItemID], [MfgDate]) VALUES (1, 7, NULL, NULL, NULL, NULL, N'000002001', N'BATCH0001', N'', CAST(10.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(127.00 AS Decimal(18, 2)), NULL, N'L000004', NULL, CAST(0.00 AS Decimal(18, 2)), N'L', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(1270.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, NULL, NULL, CAST(150.00 AS Decimal(18, 2)), CAST(N'2023-06-09T00:00:00.000' AS DateTime), CAST(145.00 AS Decimal(18, 2)), CAST(142.00 AS Decimal(18, 2)), CAST(140.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'admin', CAST(N'2023-09-06T22:37:13.083' AS DateTime), N'admin', CAST(N'2023-09-06T22:38:53.590' AS DateTime), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[TempPurchaseSaleBookLineItem] ([PurchaseSaleBookLineItemID], [PurchaseSaleBookHeaderID], [FifoID], [PurchaseBillDate], [PurchaseVoucherNumber], [PurchaseSrlNo], [ItemCode], [Batch], [BatchNew], [Quantity], [FreeQuantity], [PurchaseSaleRate], [EffecivePurchaseSaleRate], [PurchaseSaleTypeCode], [SurCharge], [PurchaseSaleTax], [LocalCentral], [SGST], [IGST], [CGST], [Amount], [Discount], [SpecialDiscount], [DiscountQuantity], [VolumeDiscount], [Scheme1], [Scheme2], [IsHalfScheme], [HalfSchemeRate], [ConversionRate], [MRP], [ExpiryDate], [SaleRate], [WholeSaleRate], [SpecialRate], [CostAmount], [GrossAmount], [SchemeAmount], [DiscountAmount], [SurchargeAmount], [TaxAmount], [SpecialDiscountAmount], [VolumeDiscountAmount], [TotalDiscountAmount], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [UsedQuantity], [BalanceQuantity], [OldPurchaseSaleBookLineItemID], [MfgDate]) VALUES (2, 7, NULL, NULL, NULL, NULL, N'000003001', N'BATCH0002', N'', CAST(50.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(15.00 AS Decimal(18, 2)), NULL, N'L000004', NULL, CAST(0.00 AS Decimal(18, 2)), N'L', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(750.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, NULL, NULL, CAST(25.00 AS Decimal(18, 2)), CAST(N'2023-06-09T00:00:00.000' AS DateTime), CAST(23.00 AS Decimal(18, 2)), CAST(22.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'admin', CAST(N'2023-09-06T22:38:59.963' AS DateTime), N'admin', CAST(N'2023-09-06T22:39:29.740' AS DateTime), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[TempPurchaseSaleBookLineItem] ([PurchaseSaleBookLineItemID], [PurchaseSaleBookHeaderID], [FifoID], [PurchaseBillDate], [PurchaseVoucherNumber], [PurchaseSrlNo], [ItemCode], [Batch], [BatchNew], [Quantity], [FreeQuantity], [PurchaseSaleRate], [EffecivePurchaseSaleRate], [PurchaseSaleTypeCode], [SurCharge], [PurchaseSaleTax], [LocalCentral], [SGST], [IGST], [CGST], [Amount], [Discount], [SpecialDiscount], [DiscountQuantity], [VolumeDiscount], [Scheme1], [Scheme2], [IsHalfScheme], [HalfSchemeRate], [ConversionRate], [MRP], [ExpiryDate], [SaleRate], [WholeSaleRate], [SpecialRate], [CostAmount], [GrossAmount], [SchemeAmount], [DiscountAmount], [SurchargeAmount], [TaxAmount], [SpecialDiscountAmount], [VolumeDiscountAmount], [TotalDiscountAmount], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [UsedQuantity], [BalanceQuantity], [OldPurchaseSaleBookLineItemID], [MfgDate]) VALUES (7, 11, 1, CAST(N'2023-09-06T00:00:00.000' AS DateTime), N'00000001', 1, N'000002001', N'BATCH0011', N'BATCH0011', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(127.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'L000003', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'L', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(150.00 AS Decimal(18, 2)), CAST(N'2023-06-09T00:00:00.000' AS DateTime), CAST(145.00 AS Decimal(18, 2)), CAST(142.00 AS Decimal(18, 2)), CAST(140.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'admin', CAST(N'2023-09-07T09:31:36.060' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[TempPurchaseSaleBookLineItem] ([PurchaseSaleBookLineItemID], [PurchaseSaleBookHeaderID], [FifoID], [PurchaseBillDate], [PurchaseVoucherNumber], [PurchaseSrlNo], [ItemCode], [Batch], [BatchNew], [Quantity], [FreeQuantity], [PurchaseSaleRate], [EffecivePurchaseSaleRate], [PurchaseSaleTypeCode], [SurCharge], [PurchaseSaleTax], [LocalCentral], [SGST], [IGST], [CGST], [Amount], [Discount], [SpecialDiscount], [DiscountQuantity], [VolumeDiscount], [Scheme1], [Scheme2], [IsHalfScheme], [HalfSchemeRate], [ConversionRate], [MRP], [ExpiryDate], [SaleRate], [WholeSaleRate], [SpecialRate], [CostAmount], [GrossAmount], [SchemeAmount], [DiscountAmount], [SurchargeAmount], [TaxAmount], [SpecialDiscountAmount], [VolumeDiscountAmount], [TotalDiscountAmount], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [UsedQuantity], [BalanceQuantity], [OldPurchaseSaleBookLineItemID], [MfgDate]) VALUES (8, 12, 1, CAST(N'2023-09-06T00:00:00.000' AS DateTime), N'00000001', 1, N'000002001', N'BATCH0011', N'BATCH0011', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(127.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'L000003', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'L', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(150.00 AS Decimal(18, 2)), CAST(N'2023-06-09T00:00:00.000' AS DateTime), CAST(145.00 AS Decimal(18, 2)), CAST(142.00 AS Decimal(18, 2)), CAST(140.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'admin', CAST(N'2023-09-07T09:33:26.173' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[TempPurchaseSaleBookLineItem] ([PurchaseSaleBookLineItemID], [PurchaseSaleBookHeaderID], [FifoID], [PurchaseBillDate], [PurchaseVoucherNumber], [PurchaseSrlNo], [ItemCode], [Batch], [BatchNew], [Quantity], [FreeQuantity], [PurchaseSaleRate], [EffecivePurchaseSaleRate], [PurchaseSaleTypeCode], [SurCharge], [PurchaseSaleTax], [LocalCentral], [SGST], [IGST], [CGST], [Amount], [Discount], [SpecialDiscount], [DiscountQuantity], [VolumeDiscount], [Scheme1], [Scheme2], [IsHalfScheme], [HalfSchemeRate], [ConversionRate], [MRP], [ExpiryDate], [SaleRate], [WholeSaleRate], [SpecialRate], [CostAmount], [GrossAmount], [SchemeAmount], [DiscountAmount], [SurchargeAmount], [TaxAmount], [SpecialDiscountAmount], [VolumeDiscountAmount], [TotalDiscountAmount], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [UsedQuantity], [BalanceQuantity], [OldPurchaseSaleBookLineItemID], [MfgDate]) VALUES (9, 13, 1, CAST(N'2023-09-06T00:00:00.000' AS DateTime), N'00000001', 1, N'000002001', N'BATCH0011', N'BATCH0011', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(127.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'L000003', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'L', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(150.00 AS Decimal(18, 2)), CAST(N'2023-06-09T00:00:00.000' AS DateTime), CAST(145.00 AS Decimal(18, 2)), CAST(142.00 AS Decimal(18, 2)), CAST(140.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'admin', CAST(N'2023-09-07T09:34:52.927' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[TempPurchaseSaleBookLineItem] ([PurchaseSaleBookLineItemID], [PurchaseSaleBookHeaderID], [FifoID], [PurchaseBillDate], [PurchaseVoucherNumber], [PurchaseSrlNo], [ItemCode], [Batch], [BatchNew], [Quantity], [FreeQuantity], [PurchaseSaleRate], [EffecivePurchaseSaleRate], [PurchaseSaleTypeCode], [SurCharge], [PurchaseSaleTax], [LocalCentral], [SGST], [IGST], [CGST], [Amount], [Discount], [SpecialDiscount], [DiscountQuantity], [VolumeDiscount], [Scheme1], [Scheme2], [IsHalfScheme], [HalfSchemeRate], [ConversionRate], [MRP], [ExpiryDate], [SaleRate], [WholeSaleRate], [SpecialRate], [CostAmount], [GrossAmount], [SchemeAmount], [DiscountAmount], [SurchargeAmount], [TaxAmount], [SpecialDiscountAmount], [VolumeDiscountAmount], [TotalDiscountAmount], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [UsedQuantity], [BalanceQuantity], [OldPurchaseSaleBookLineItemID], [MfgDate]) VALUES (14, 17, 1, CAST(N'2023-09-06T00:00:00.000' AS DateTime), N'00000001', 1, N'000002001', N'BATCH0011', N'BATCH0011', CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(127.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'L000003', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'L', CAST(0.00 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), CAST(1450.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(150.00 AS Decimal(18, 2)), CAST(N'2023-06-09T00:00:00.000' AS DateTime), CAST(145.00 AS Decimal(18, 2)), CAST(142.00 AS Decimal(18, 2)), CAST(140.00 AS Decimal(18, 2)), NULL, CAST(1450.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(72.50 AS Decimal(18, 2)), NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(72.50 AS Decimal(18, 2)), N'admin', CAST(N'2023-09-07T09:49:30.387' AS DateTime), N'admin', CAST(N'2023-09-07T09:49:55.383' AS DateTime), NULL, NULL, 3, NULL)
GO
SET IDENTITY_INSERT [dbo].[TempPurchaseSaleBookLineItem] OFF
GO
SET IDENTITY_INSERT [dbo].[TRN] ON 
GO
INSERT [dbo].[TRN] ([TrnID], [PurchaseSaleBookHeaderID], [VoucherNumber], [VoucherTypeCode], [VoucherDate], [LedgerType], [LedgerTypeCode], [NARRATION], [Amount], [DebitCredit], [Status], [IsChequeClear], [ChequeClearedDate], [ChequeNumber]) VALUES (1, 3, N'00000001', N'PURCHASEENTRY', CAST(N'2023-09-06T00:00:00.000' AS DateTime), N'SUPPLIERLEDGER', N'S000001', N'Purchase Invoice is - ABC00011', CAST(1036.00 AS Decimal(18, 2)), N'C', NULL, 0, NULL, NULL)
GO
INSERT [dbo].[TRN] ([TrnID], [PurchaseSaleBookHeaderID], [VoucherNumber], [VoucherTypeCode], [VoucherDate], [LedgerType], [LedgerTypeCode], [NARRATION], [Amount], [DebitCredit], [Status], [IsChequeClear], [ChequeClearedDate], [ChequeNumber]) VALUES (2, 3, N'00000001', N'PURCHASEENTRY', CAST(N'2023-09-06T00:00:00.000' AS DateTime), N'PURCHASELEDGER', N'PUR0000001', N'Purchase Invoice is - ABC00011', CAST(1000.00 AS Decimal(18, 2)), N'D', NULL, 0, NULL, NULL)
GO
INSERT [dbo].[TRN] ([TrnID], [PurchaseSaleBookHeaderID], [VoucherNumber], [VoucherTypeCode], [VoucherDate], [LedgerType], [LedgerTypeCode], [NARRATION], [Amount], [DebitCredit], [Status], [IsChequeClear], [ChequeClearedDate], [ChequeNumber]) VALUES (3, 3, N'00000001', N'PURCHASEENTRY', CAST(N'2023-09-06T00:00:00.000' AS DateTime), N'GENERALLEDGER', N'SGST000002', N'Purchase Invoice is - ABC00011', CAST(18.00 AS Decimal(18, 2)), N'D', NULL, 0, NULL, NULL)
GO
INSERT [dbo].[TRN] ([TrnID], [PurchaseSaleBookHeaderID], [VoucherNumber], [VoucherTypeCode], [VoucherDate], [LedgerType], [LedgerTypeCode], [NARRATION], [Amount], [DebitCredit], [Status], [IsChequeClear], [ChequeClearedDate], [ChequeNumber]) VALUES (4, 3, N'00000001', N'PURCHASEENTRY', CAST(N'2023-09-06T00:00:00.000' AS DateTime), N'GENERALLEDGER', N'CGST000002', N'Purchase Invoice is - ABC00011', CAST(18.00 AS Decimal(18, 2)), N'D', NULL, 0, NULL, NULL)
GO
INSERT [dbo].[TRN] ([TrnID], [PurchaseSaleBookHeaderID], [VoucherNumber], [VoucherTypeCode], [VoucherDate], [LedgerType], [LedgerTypeCode], [NARRATION], [Amount], [DebitCredit], [Status], [IsChequeClear], [ChequeClearedDate], [ChequeNumber]) VALUES (6, 4, N'00000001', N'SALEENTRY', CAST(N'2023-09-07T00:00:00.000' AS DateTime), N'CUSTOMERLEDGER', N'C000001', N'Sale Invoice is - 00000002', CAST(0.00 AS Decimal(18, 2)), N'C', NULL, 0, NULL, NULL)
GO
INSERT [dbo].[TRN] ([TrnID], [PurchaseSaleBookHeaderID], [VoucherNumber], [VoucherTypeCode], [VoucherDate], [LedgerType], [LedgerTypeCode], [NARRATION], [Amount], [DebitCredit], [Status], [IsChequeClear], [ChequeClearedDate], [ChequeNumber]) VALUES (8, 5, N'00000001', N'SALEONCHALLAN', CAST(N'2023-09-07T00:00:00.000' AS DateTime), N'CUSTOMERLEDGER', N'C000001', N'Sale Invoice is - 00000002', CAST(0.00 AS Decimal(18, 2)), N'C', NULL, 0, NULL, NULL)
GO
INSERT [dbo].[TRN] ([TrnID], [PurchaseSaleBookHeaderID], [VoucherNumber], [VoucherTypeCode], [VoucherDate], [LedgerType], [LedgerTypeCode], [NARRATION], [Amount], [DebitCredit], [Status], [IsChequeClear], [ChequeClearedDate], [ChequeNumber]) VALUES (9, 6, N'00000002', N'PURCHASEENTRY', CAST(N'2023-09-07T00:00:00.000' AS DateTime), N'SUPPLIERLEDGER', N'S000001', N'Purchase Invoice is - ABC0002', CAST(13000.00 AS Decimal(18, 2)), N'C', NULL, 0, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[TRN] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([UserId], [Username], [Password], [FirstName], [LastName], [Status], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [IsSysAdmin], [RoleID]) VALUES (1, N'admin', N'z2FTqPC0zqs=', N'System', N'Admin', 1, N'admin', CAST(N'2017-05-11T00:00:00.000' AS DateTime), NULL, NULL, 1, NULL)
GO
INSERT [dbo].[Users] ([UserId], [Username], [Password], [FirstName], [LastName], [Status], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [IsSysAdmin], [RoleID]) VALUES (2, N'Vandana', N'z2FTqPC0zqs=', N'Vandana', N'Kumra', 1, N'admin', CAST(N'2017-05-18T22:42:53.687' AS DateTime), NULL, NULL, 1, 2)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[BillOutStandings] ADD  CONSTRAINT [DF_BillOutStandings_IsHold]  DEFAULT ((0)) FOR [IsHold]
GO
ALTER TABLE [dbo].[TRN] ADD  CONSTRAINT [DF_TRN_IsChequeClear]  DEFAULT ((0)) FOR [IsChequeClear]
GO
ALTER TABLE [dbo].[AccountLedgerMaster]  WITH CHECK ADD  CONSTRAINT [FK_AccountLedgerMaster_AccountLedgerType] FOREIGN KEY([AccountLedgerTypeId])
REFERENCES [dbo].[AccountLedgerType] ([AccountLedgerTypeID])
GO
ALTER TABLE [dbo].[AccountLedgerMaster] CHECK CONSTRAINT [FK_AccountLedgerMaster_AccountLedgerType]
GO
ALTER TABLE [dbo].[AccountLedgerMaster]  WITH CHECK ADD  CONSTRAINT [FK_AccountLedgerMaster_AccountType] FOREIGN KEY([AccountTypeId])
REFERENCES [dbo].[AccountType] ([AccountTypeID])
GO
ALTER TABLE [dbo].[AccountLedgerMaster] CHECK CONSTRAINT [FK_AccountLedgerMaster_AccountType]
GO
ALTER TABLE [dbo].[AccountLedgerMaster]  WITH CHECK ADD  CONSTRAINT [FK_AccountLedgerMaster_CreditControlCode] FOREIGN KEY([CreditControlCodeID])
REFERENCES [dbo].[AccountLedgerMaster] ([AccountLedgerID])
GO
ALTER TABLE [dbo].[AccountLedgerMaster] CHECK CONSTRAINT [FK_AccountLedgerMaster_CreditControlCode]
GO
ALTER TABLE [dbo].[AccountLedgerMaster]  WITH CHECK ADD  CONSTRAINT [FK_AccountLedgerMaster_DebitControlCode] FOREIGN KEY([DebitControlCodeID])
REFERENCES [dbo].[AccountLedgerMaster] ([AccountLedgerID])
GO
ALTER TABLE [dbo].[AccountLedgerMaster] CHECK CONSTRAINT [FK_AccountLedgerMaster_DebitControlCode]
GO
ALTER TABLE [dbo].[BillOutStandings]  WITH CHECK ADD  CONSTRAINT [FK_BillOutStandings_PurchaseSaleBookHeader] FOREIGN KEY([PurchaseSaleBookHeaderID])
REFERENCES [dbo].[PurchaseSaleBookHeader] ([PurchaseSaleBookHeaderID])
GO
ALTER TABLE [dbo].[BillOutStandings] CHECK CONSTRAINT [FK_BillOutStandings_PurchaseSaleBookHeader]
GO
ALTER TABLE [dbo].[BillOutStandingsAudjustment]  WITH CHECK ADD  CONSTRAINT [FK_BillOutStandingsAudjustment_BillOutStandings] FOREIGN KEY([BillOutStandingsID])
REFERENCES [dbo].[BillOutStandings] ([BillOutStandingsID])
GO
ALTER TABLE [dbo].[BillOutStandingsAudjustment] CHECK CONSTRAINT [FK_BillOutStandingsAudjustment_BillOutStandings]
GO
ALTER TABLE [dbo].[BillOutStandingsAudjustment]  WITH CHECK ADD  CONSTRAINT [FK_BillOutStandingsAudjustment_PurchaseSaleBookHeader] FOREIGN KEY([PurchaseSaleBookHeaderID])
REFERENCES [dbo].[PurchaseSaleBookHeader] ([PurchaseSaleBookHeaderID])
GO
ALTER TABLE [dbo].[BillOutStandingsAudjustment] CHECK CONSTRAINT [FK_BillOutStandingsAudjustment_PurchaseSaleBookHeader]
GO
ALTER TABLE [dbo].[BillOutStandingsAudjustment]  WITH CHECK ADD  CONSTRAINT [FK_BillOutStandingsAudjustment_ReceiptPayment] FOREIGN KEY([ReceiptPaymentID])
REFERENCES [dbo].[ReceiptPayment] ([ReceiptPaymentID])
GO
ALTER TABLE [dbo].[BillOutStandingsAudjustment] CHECK CONSTRAINT [FK_BillOutStandingsAudjustment_ReceiptPayment]
GO
ALTER TABLE [dbo].[BillOutStandingsAudjustment]  WITH CHECK ADD  CONSTRAINT [FK_TempBillOutStandingsAudjustment_BillOutStandings] FOREIGN KEY([BillOutStandingsID])
REFERENCES [dbo].[BillOutStandings] ([BillOutStandingsID])
GO
ALTER TABLE [dbo].[BillOutStandingsAudjustment] CHECK CONSTRAINT [FK_TempBillOutStandingsAudjustment_BillOutStandings]
GO
ALTER TABLE [dbo].[BillOutStandingsAudjustment]  WITH CHECK ADD  CONSTRAINT [FK_TempBillOutStandingsAudjustment_PurchaseSaleBookHeader] FOREIGN KEY([PurchaseSaleBookHeaderID])
REFERENCES [dbo].[PurchaseSaleBookHeader] ([PurchaseSaleBookHeaderID])
GO
ALTER TABLE [dbo].[BillOutStandingsAudjustment] CHECK CONSTRAINT [FK_TempBillOutStandingsAudjustment_PurchaseSaleBookHeader]
GO
ALTER TABLE [dbo].[BillOutStandingsAudjustment]  WITH CHECK ADD  CONSTRAINT [FK_TempBillOutStandingsAudjustment_ReceiptPayment] FOREIGN KEY([ReceiptPaymentID])
REFERENCES [dbo].[ReceiptPayment] ([ReceiptPaymentID])
GO
ALTER TABLE [dbo].[BillOutStandingsAudjustment] CHECK CONSTRAINT [FK_TempBillOutStandingsAudjustment_ReceiptPayment]
GO
ALTER TABLE [dbo].[CustomerCompanyDiscountRef]  WITH CHECK ADD  CONSTRAINT [FK_CustomerCompanyDiscountRef_CompanyMaster] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[CompanyMaster] ([CompanyId])
GO
ALTER TABLE [dbo].[CustomerCompanyDiscountRef] CHECK CONSTRAINT [FK_CustomerCompanyDiscountRef_CompanyMaster]
GO
ALTER TABLE [dbo].[CustomerCompanyDiscountRef]  WITH CHECK ADD  CONSTRAINT [FK_CustomerCompanyDiscountRef_CustomerLedger] FOREIGN KEY([CustomerLedgerID])
REFERENCES [dbo].[CustomerLedger] ([CustomerLedgerId])
GO
ALTER TABLE [dbo].[CustomerCompanyDiscountRef] CHECK CONSTRAINT [FK_CustomerCompanyDiscountRef_CustomerLedger]
GO
ALTER TABLE [dbo].[CustomerCompanyDiscountRef]  WITH CHECK ADD  CONSTRAINT [FK_CustomerCompanyDiscountRef_ItemMaster] FOREIGN KEY([ItemID])
REFERENCES [dbo].[ItemMaster] ([ItemID])
GO
ALTER TABLE [dbo].[CustomerCompanyDiscountRef] CHECK CONSTRAINT [FK_CustomerCompanyDiscountRef_ItemMaster]
GO
ALTER TABLE [dbo].[CustomerLedger]  WITH CHECK ADD  CONSTRAINT [FK_CustomerLedger_CustomerLedger] FOREIGN KEY([ZSMId])
REFERENCES [dbo].[PersonRouteMaster] ([PersonRouteID])
GO
ALTER TABLE [dbo].[CustomerLedger] CHECK CONSTRAINT [FK_CustomerLedger_CustomerLedger]
GO
ALTER TABLE [dbo].[CustomerLedger]  WITH CHECK ADD  CONSTRAINT [FK_CustomerLedger_CustomerType] FOREIGN KEY([CustomerTypeID])
REFERENCES [dbo].[CustomerType] ([CustomerTypeId])
GO
ALTER TABLE [dbo].[CustomerLedger] CHECK CONSTRAINT [FK_CustomerLedger_CustomerType]
GO
ALTER TABLE [dbo].[CustomerLedger]  WITH CHECK ADD  CONSTRAINT [FK_CustomerLedger_InterestType] FOREIGN KEY([InterestTypeID])
REFERENCES [dbo].[RateType] ([RateTypeId])
GO
ALTER TABLE [dbo].[CustomerLedger] CHECK CONSTRAINT [FK_CustomerLedger_InterestType]
GO
ALTER TABLE [dbo].[CustomerLedger]  WITH CHECK ADD  CONSTRAINT [FK_CustomerLedger_SalesPersonMaster] FOREIGN KEY([ASMId])
REFERENCES [dbo].[PersonRouteMaster] ([PersonRouteID])
GO
ALTER TABLE [dbo].[CustomerLedger] CHECK CONSTRAINT [FK_CustomerLedger_SalesPersonMaster]
GO
ALTER TABLE [dbo].[CustomerLedger]  WITH CHECK ADD  CONSTRAINT [FK_CustomerLedger_SalesPersonMaster1] FOREIGN KEY([RSMId])
REFERENCES [dbo].[PersonRouteMaster] ([PersonRouteID])
GO
ALTER TABLE [dbo].[CustomerLedger] CHECK CONSTRAINT [FK_CustomerLedger_SalesPersonMaster1]
GO
ALTER TABLE [dbo].[CustomerLedger]  WITH CHECK ADD  CONSTRAINT [FK_CustomerLedger_SalesPersonMaster2] FOREIGN KEY([SalesManId])
REFERENCES [dbo].[PersonRouteMaster] ([PersonRouteID])
GO
ALTER TABLE [dbo].[CustomerLedger] CHECK CONSTRAINT [FK_CustomerLedger_SalesPersonMaster2]
GO
ALTER TABLE [dbo].[CustomerLedger]  WITH CHECK ADD  CONSTRAINT [FK_CustomerLedger_SalesPersonMaster3] FOREIGN KEY([AreaId])
REFERENCES [dbo].[PersonRouteMaster] ([PersonRouteID])
GO
ALTER TABLE [dbo].[CustomerLedger] CHECK CONSTRAINT [FK_CustomerLedger_SalesPersonMaster3]
GO
ALTER TABLE [dbo].[CustomerLedger]  WITH CHECK ADD  CONSTRAINT [FK_CustomerLedger_SalesPersonMaster4] FOREIGN KEY([RouteId])
REFERENCES [dbo].[PersonRouteMaster] ([PersonRouteID])
GO
ALTER TABLE [dbo].[CustomerLedger] CHECK CONSTRAINT [FK_CustomerLedger_SalesPersonMaster4]
GO
ALTER TABLE [dbo].[FIFO]  WITH CHECK ADD  CONSTRAINT [FK_FIFO_PurchaseSaleBookHeader] FOREIGN KEY([PurchaseSaleBookHeaderID])
REFERENCES [dbo].[PurchaseSaleBookHeader] ([PurchaseSaleBookHeaderID])
GO
ALTER TABLE [dbo].[FIFO] CHECK CONSTRAINT [FK_FIFO_PurchaseSaleBookHeader]
GO
ALTER TABLE [dbo].[ItemMaster]  WITH CHECK ADD  CONSTRAINT [FK_ItemMaster_AccountLedgerMaster] FOREIGN KEY([SaleTypeId])
REFERENCES [dbo].[AccountLedgerMaster] ([AccountLedgerID])
GO
ALTER TABLE [dbo].[ItemMaster] CHECK CONSTRAINT [FK_ItemMaster_AccountLedgerMaster]
GO
ALTER TABLE [dbo].[ItemMaster]  WITH CHECK ADD  CONSTRAINT [FK_ItemMaster_AccountLedgerMasterPurchase] FOREIGN KEY([PurchaseTypeId])
REFERENCES [dbo].[AccountLedgerMaster] ([AccountLedgerID])
GO
ALTER TABLE [dbo].[ItemMaster] CHECK CONSTRAINT [FK_ItemMaster_AccountLedgerMasterPurchase]
GO
ALTER TABLE [dbo].[ItemMaster]  WITH CHECK ADD  CONSTRAINT [FK_ItemMaster_CompanyMaster] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[CompanyMaster] ([CompanyId])
GO
ALTER TABLE [dbo].[ItemMaster] CHECK CONSTRAINT [FK_ItemMaster_CompanyMaster]
GO
ALTER TABLE [dbo].[ItemMaster]  WITH CHECK ADD  CONSTRAINT [FK_ItemMaster_HSNCode] FOREIGN KEY([HSNCode])
REFERENCES [dbo].[HSNCode] ([HSNCode])
GO
ALTER TABLE [dbo].[ItemMaster] CHECK CONSTRAINT [FK_ItemMaster_HSNCode]
GO
ALTER TABLE [dbo].[Menu]  WITH CHECK ADD  CONSTRAINT [FK_Menu_Privledges] FOREIGN KEY([PrivledgeId])
REFERENCES [dbo].[Privledges] ([PrivledgeId])
ON UPDATE SET NULL
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Menu] CHECK CONSTRAINT [FK_Menu_Privledges]
GO
ALTER TABLE [dbo].[PersonRouteMaster]  WITH CHECK ADD  CONSTRAINT [FK_PersonRouteMaster_RecordType] FOREIGN KEY([RecordTypeId])
REFERENCES [dbo].[RecordType] ([RecordTypeId])
GO
ALTER TABLE [dbo].[PersonRouteMaster] CHECK CONSTRAINT [FK_PersonRouteMaster_RecordType]
GO
ALTER TABLE [dbo].[PurchaseSaleBookLineItem]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseSaleBookLineItem_FIFO] FOREIGN KEY([FifoID])
REFERENCES [dbo].[FIFO] ([FifoID])
GO
ALTER TABLE [dbo].[PurchaseSaleBookLineItem] CHECK CONSTRAINT [FK_PurchaseSaleBookLineItem_FIFO]
GO
ALTER TABLE [dbo].[PurchaseSaleBookLineItem]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseSaleBookLineItem_PurchaseSaleBookHeader] FOREIGN KEY([PurchaseSaleBookHeaderID])
REFERENCES [dbo].[PurchaseSaleBookHeader] ([PurchaseSaleBookHeaderID])
GO
ALTER TABLE [dbo].[PurchaseSaleBookLineItem] CHECK CONSTRAINT [FK_PurchaseSaleBookLineItem_PurchaseSaleBookHeader]
GO
ALTER TABLE [dbo].[PurchaseSaleEntryForm]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseSaleEntryForm_PurchaseSaleEntryType] FOREIGN KEY([PurchaseSaleEntryTypeID])
REFERENCES [dbo].[PurchaseSaleEntryType] ([PurchaseSaleEntryTypeID])
GO
ALTER TABLE [dbo].[PurchaseSaleEntryForm] CHECK CONSTRAINT [FK_PurchaseSaleEntryForm_PurchaseSaleEntryType]
GO
ALTER TABLE [dbo].[RolePrivledges]  WITH CHECK ADD  CONSTRAINT [FK_RolePrivledges_Privledges] FOREIGN KEY([PrivledgeId])
REFERENCES [dbo].[Privledges] ([PrivledgeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RolePrivledges] CHECK CONSTRAINT [FK_RolePrivledges_Privledges]
GO
ALTER TABLE [dbo].[RolePrivledges]  WITH CHECK ADD  CONSTRAINT [FK_RolePrivledges_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RolePrivledges] CHECK CONSTRAINT [FK_RolePrivledges_Roles]
GO
ALTER TABLE [dbo].[SupplierCompanyDiscountRef]  WITH CHECK ADD  CONSTRAINT [FK_SupplierCompanyDiscountRef_CompanyMaster] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[CompanyMaster] ([CompanyId])
GO
ALTER TABLE [dbo].[SupplierCompanyDiscountRef] CHECK CONSTRAINT [FK_SupplierCompanyDiscountRef_CompanyMaster]
GO
ALTER TABLE [dbo].[SupplierCompanyDiscountRef]  WITH CHECK ADD  CONSTRAINT [FK_SupplierCompanyDiscountRef_ItemMaster] FOREIGN KEY([ItemID])
REFERENCES [dbo].[ItemMaster] ([ItemID])
GO
ALTER TABLE [dbo].[SupplierCompanyDiscountRef] CHECK CONSTRAINT [FK_SupplierCompanyDiscountRef_ItemMaster]
GO
ALTER TABLE [dbo].[SupplierCompanyDiscountRef]  WITH CHECK ADD  CONSTRAINT [FK_SupplierCompanyDiscountRef_SupplierLedger] FOREIGN KEY([SupplierLedgerID])
REFERENCES [dbo].[SupplierLedger] ([SupplierLedgerId])
GO
ALTER TABLE [dbo].[SupplierCompanyDiscountRef] CHECK CONSTRAINT [FK_SupplierCompanyDiscountRef_SupplierLedger]
GO
ALTER TABLE [dbo].[SupplierLedger]  WITH CHECK ADD  CONSTRAINT [FK_SupplierLedger_PurchaseLedger] FOREIGN KEY([PurchaseTypeID])
REFERENCES [dbo].[AccountLedgerMaster] ([AccountLedgerID])
GO
ALTER TABLE [dbo].[SupplierLedger] CHECK CONSTRAINT [FK_SupplierLedger_PurchaseLedger]
GO
ALTER TABLE [dbo].[SupplierLedger]  WITH CHECK ADD  CONSTRAINT [FK_SupplierLedger_SalesPersonMaster] FOREIGN KEY([AreaId])
REFERENCES [dbo].[PersonRouteMaster] ([PersonRouteID])
GO
ALTER TABLE [dbo].[SupplierLedger] CHECK CONSTRAINT [FK_SupplierLedger_SalesPersonMaster]
GO
ALTER TABLE [dbo].[TempBillOutStandingsAudjustment]  WITH CHECK ADD  CONSTRAINT [FK_TempBillOutStandingsAudjustment_BillOutStandings1] FOREIGN KEY([BillOutStandingsID])
REFERENCES [dbo].[BillOutStandings] ([BillOutStandingsID])
GO
ALTER TABLE [dbo].[TempBillOutStandingsAudjustment] CHECK CONSTRAINT [FK_TempBillOutStandingsAudjustment_BillOutStandings1]
GO
ALTER TABLE [dbo].[TempBillOutStandingsAudjustment]  WITH CHECK ADD  CONSTRAINT [FK_TempBillOutStandingsAudjustment_PurchaseSaleBookHeader1] FOREIGN KEY([PurchaseSaleBookHeaderID])
REFERENCES [dbo].[PurchaseSaleBookHeader] ([PurchaseSaleBookHeaderID])
GO
ALTER TABLE [dbo].[TempBillOutStandingsAudjustment] CHECK CONSTRAINT [FK_TempBillOutStandingsAudjustment_PurchaseSaleBookHeader1]
GO
ALTER TABLE [dbo].[TempBillOutStandingsAudjustment]  WITH CHECK ADD  CONSTRAINT [FK_TempBillOutStandingsAudjustment_TempReceiptPayment] FOREIGN KEY([ReceiptPaymentID])
REFERENCES [dbo].[TempReceiptPayment] ([ReceiptPaymentID])
GO
ALTER TABLE [dbo].[TempBillOutStandingsAudjustment] CHECK CONSTRAINT [FK_TempBillOutStandingsAudjustment_TempReceiptPayment]
GO
ALTER TABLE [dbo].[TempPurchaseSaleBookLineItem]  WITH CHECK ADD  CONSTRAINT [FK_TempPurchaseSaleBookLineItem_FIFO] FOREIGN KEY([FifoID])
REFERENCES [dbo].[FIFO] ([FifoID])
GO
ALTER TABLE [dbo].[TempPurchaseSaleBookLineItem] CHECK CONSTRAINT [FK_TempPurchaseSaleBookLineItem_FIFO]
GO
ALTER TABLE [dbo].[TempPurchaseSaleBookLineItem]  WITH CHECK ADD  CONSTRAINT [FK_TempPurchaseSaleBookLineItem_TempPurchaseSaleBookHeader] FOREIGN KEY([PurchaseSaleBookHeaderID])
REFERENCES [dbo].[TempPurchaseSaleBookHeader] ([PurchaseSaleBookHeaderID])
GO
ALTER TABLE [dbo].[TempPurchaseSaleBookLineItem] CHECK CONSTRAINT [FK_TempPurchaseSaleBookLineItem_TempPurchaseSaleBookHeader]
GO
ALTER TABLE [dbo].[TRN]  WITH CHECK ADD  CONSTRAINT [FK_TRN_PurchaseSaleBookHeader] FOREIGN KEY([PurchaseSaleBookHeaderID])
REFERENCES [dbo].[PurchaseSaleBookHeader] ([PurchaseSaleBookHeaderID])
GO
ALTER TABLE [dbo].[TRN] CHECK CONSTRAINT [FK_TRN_PurchaseSaleBookHeader]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK__Users__RoleID__5C37ACAD] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK__Users__RoleID__5C37ACAD]
GO
/****** Object:  StoredProcedure [dbo].[CheckQuantityIfAvailableForSale]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CheckQuantityIfAvailableForSale]
(
 @PurchaseSaleBookHeaderID BIGINT,
 @PurchaseSaleBookLineItemID BIGINT,
 @ItemCode NVARCHAR(9),
 @Quantity decimal(18,2),
 @FreeQuantity decimal(18,2)
)
AS
BEGIN


	DECLARE @TotalQuantityForItem decimal(18,2)
	DECLARE @OldQuantity decimal(18,2), @NewQuantity decimal
	DECLARE @OldFreeQuantity decimal(18,2),@NewFreeQuantity decimal(18,2)
	DECLARE @BalanceQuantity decimal(18,2)
	
	Select @OldQuantity = Quantity ,@OldFreeQuantity = ISNULL(FreeQuantity,0)
	FROM TempPurchaseSaleBookLineItem 
	WHERE PurchaseSaleBookLineItemID = @PurchaseSaleBookLineItemID
	
	SELECT @BalanceQuantity = SUM(BalanceQuanity) FROM FIFO WHERE ItemCode = @ItemCode


	SELECT @TotalQuantityForItem = SUM(Quantity)
	FROM TempPurchaseSaleBookLineItem 
	WHERE PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID AND ItemCode = @ItemCode

	SET @NewQuantity = @Quantity - @OldQuantity
	SET @TotalQuantityForItem  = @TotalQuantityForItem  + @NewQuantity
			
	SET @FreeQuantity = dbo.GetFreeQuantity(@ItemCode,@TotalQuantityForItem)
			
	SET @NewFreeQuantity = @FreeQuantity  - @OldFreeQuantity

	
	IF @Quantity <> @OldQuantity AND @Quantity < @OldQuantity
	BEGIN
		SELECT 1 AS IsAvailable, @NewFreeQuantity AS FreeQuantity
	END
	ELSE IF @Quantity = @OldQuantity AND @FreeQuantity < @OldFreeQuantity
	BEGIN
		SELECT 1 AS IsAvailable, @NewFreeQuantity AS FreeQuantity
	END
	ELSE IF @Quantity = @OldQuantity AND @FreeQuantity > @OldFreeQuantity AND @BalanceQuantity > (@FreeQuantity - @OldFreeQuantity)
	BEGIN
		SELECT 1 AS IsAvailable, @NewFreeQuantity AS FreeQuantity
	END
	ELSE
	BEGIN
			IF @BalanceQuantity >= (@NewQuantity + @NewFreeQuantity)
			BEGIN
				SELECT 1 AS IsAvailable, @NewFreeQuantity AS FreeQuantity
			END
			ELSE
			BEGIN
				SELECT 0 AS IsAvailable,  @NewFreeQuantity AS FreeQuantity
			END
			
	END
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteInvetoryLineItemInTempTable]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteInvetoryLineItemInTempTable] 
	@PurchaseSaleBookHeaderID BigInt,
	@PurchaseSaleBookLineItemID BigInt
AS
BEGIN

BEGIN TRY	
	BEGIN TRAN
	
	
	DELETE FROM dbo.TempPurchaseSaleBookLineItem WHERE
	PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID
	AND PurchaseSaleBookLineItemID = @PurchaseSaleBookLineItemID
	
	
	DECLARE @TempTableAmountWithAllDiscountAmounts TABLE (
		   PurchaseSaleBookHeaderID BIGINT NOT NULL,
		   PurchaseSaleBookLineItemID BIGINT NOT NULL,
		   FinalAmount FLOAT NOT NULL,
		   GrossAmount FLOAT NOT NULL,
		   SchemeAmount FLOAT NOT NULL,
		   DiscountAmount FLOAT NOT NULL,
		   SpecialDiscountAmount FLOAT NOT NULL,
		   VolumeDiscountAmount FLOAT NOT NULL   
		) ;
		
		
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
		  SELECT PurchaseSaleBookHeaderID
				,PurchaseSaleBookLineItemID
				,FinalAmount
				,GrossAmount
				,SchemeAmount
				,DiscountAmount
				,SpecialDiscountAmount
				,VolumeDiscountAmount
		FROM UDF_GetAmountWithAllDiscountAmounts(@PurchaseSaleBookHeaderID)
	  
		SELECT 
			  Amt4.PurchaseSaleBookHeaderID
			 ,0 AS PurchaseSaleBookLineItemID
			 ,SUM(Amt4.BillAmount) AS BillAmount
			 ,0 AS CostAmount
			 ,SUM(Amt4.TaxAmount) As TaxAmount
			 ,SUM(Amt4.GrossAmount) AS GrossAmount
			 ,SUM(Amt4.SchemeAmount) AS SchemeAmount
			 ,SUM(Amt4.DiscountAmount) AS DiscountAmount
			 ,SUM(Amt4.SpecialDiscountAmount) AS SpecialDiscountAmount
			 ,SUM(Amt4.VolumeDiscountAmount) AS VolumeDiscountAmount
			 ,SUM(Amt4.DiscountAmount + Amt4.SpecialDiscountAmount + Amt4.VolumeDiscountAmount) AS TotalDiscountAmount
		FROM 
		(
			SELECT 
				Amt4.PurchaseSaleBookHeaderID
				,Amt4.PurchaseSaleBookLineItemID
				,Amt4.FinalAmount AS BillAmount		 
				,(Amt4.FinalAmount * .01 * Final.PurchaseSaleTax) As TaxAmount
				,Amt4.GrossAmount
				,Amt4.SchemeAmount
				,Amt4.DiscountAmount
				,Amt4.SpecialDiscountAmount 
				,Amt4.VolumeDiscountAmount
		 FROM @TempTableAmountWithAllDiscountAmounts AS Amt4
		 INNER JOIN dbo.TempPurchaseSaleBookLineItem AS Final
			 ON Amt4.PurchaseSaleBookHeaderID = final.PurchaseSaleBookHeaderID 
		      AND Amt4.PurchaseSaleBookLineItemID = final.PurchaseSaleBookLineItemID
		  WHERE final.PurchaseSaleBookHeaderID  = @PurchaseSaleBookHeaderID
		) Amt4
		GROUP BY Amt4.PurchaseSaleBookHeaderID
		
		
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
GO
/****** Object:  StoredProcedure [dbo].[DeleteSaleEntryData]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[DeleteSaleLineItem]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteSaleLineItem]
(
	@PurchaseSaleBookHeaderID INT,
	@TempPurchaseSaleBookLineItemID INT
)
AS
BEGIN
	
	DECLARE @itemCode VARCHAR(10)

	SELECT @itemCode = ItemCode FROM TempPurchaseSaleBookLineItem WHERE PurchaseSaleBookLineItemID = @TempPurchaseSaleBookLineItemID
	
	DECLARE @tblLineItemsDeleted AS TABLE
	(
		ID INT IDENTITY(1,1),
		LineItemID INT,
		QuantityToBeInsert Decimal(18,2),
		FifoID INT
	)

	IF EXISTS (SELECT ItemCode FROM TempPurchaseSaleBookLineItem WHERE PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID AND ItemCode = @itemCode AND ISNULL(FreeQuantity,0) <> 0.00 )
	BEGIN
		INSERT INTO @tblLineItemsDeleted(LineItemID, FifoID, QuantityToBeInsert)
		SELECT PurchaseSaleBookLineItemID, FifoID, ISNULL(Quantity,0) + ISNULL(FreeQuantity, 0) FROM TempPurchaseSaleBookLineItem 
		WHERE PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID AND ItemCode = @itemCode
	END
	ELSE
	BEGIN
		INSERT INTO @tblLineItemsDeleted(LineItemID, FifoID, QuantityToBeInsert)
		SELECT PurchaseSaleBookLineItemID, FifoID, ISNULL(Quantity,0) + ISNULL(FreeQuantity, 0) FROM TempPurchaseSaleBookLineItem
		WHERE PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID AND PurchaseSaleBookLineItemID = @TempPurchaseSaleBookLineItemID 
	END

	BEGIN TRY	
		BEGIN TRAN
		DECLARE @Count INT = 0, @ID INT = 1, @LineItemID INT, @FifoID INT, @Quantity DECIMAL(18, 2)

		SELECT @Count = Count(*) FROM @tblLineItemsDeleted

		WHILE(@ID <= @Count)
		BEGIN
			SELECT @LineItemID = LineItemID, @Quantity = QuantityToBeInsert, @FifoID = FifoID FROM @tblLineItemsDeleted WHERE ID = @ID
			DELETE FROM TempPurchaseSaleBookLineItem WHERE PurchaseSaleBookLineItemID = @LineItemID

			UPDATE FIFO SET BalanceQuanity = BalanceQuanity + @Quantity WHERE FifoID = @FifoID
			SELECT @ID = @ID + 1
		END

		COMMIT TRAN

		
		DECLARE @TempTableAmountWithAllDiscountAmounts TABLE (
			   PurchaseSaleBookHeaderID BIGINT NOT NULL,
			   PurchaseSaleBookLineItemID BIGINT NOT NULL,
			   BillAmount DECIMAL(18,2) NOT NULL,
			   CostAmount DECIMAL(18,2) NOT NULL,
			   TaxAmount DECIMAL(18,2) NOT NULL,
			   GrossAmount DECIMAL(18,2) NOT NULL,
			   SchemeAmount DECIMAL(18,2) NOT NULL,
			   DiscountAmount DECIMAL(18,2) NOT NULL,
			   SpecialDiscountAmount DECIMAL(18,2) NOT NULL,
			   VolumeDiscountAmount DECIMAL(18,2) NOT NULL ,
			   TotalDiscountAmount DECIMAL(18,2) NOT NULL  
			) ;
	
		INSERT INTO @TempTableAmountWithAllDiscountAmounts 
		   (
				PurchaseSaleBookHeaderID
				,PurchaseSaleBookLineItemID
				,BillAmount
				,CostAmount
				,TaxAmount
				,GrossAmount
				,SchemeAmount
				,DiscountAmount
				,SpecialDiscountAmount
				,VolumeDiscountAmount
				,TotalDiscountAmount
		   )
		   SELECT 
			  Amt4.PurchaseSaleBookHeaderID
			 ,0 AS PurchaseSaleBookLineItemID
			 ,SUM(Amt4.BillAmount) AS BillAmount
			 ,0 AS CostAmount
			 ,SUM(Amt4.TaxAmount) As TaxAmount
			 ,SUM(Amt4.GrossAmount) AS GrossAmount
			 ,SUM(Amt4.SchemeAmount) AS SchemeAmount
			 ,SUM(Amt4.DiscountAmount) AS DiscountAmount
			 ,SUM(Amt4.SpecialDiscountAmount) AS SpecialDiscountAmount
			 ,SUM(Amt4.VolumeDiscountAmount) AS VolumeDiscountAmount
			 ,SUM(Amt4.DiscountAmount + Amt4.SpecialDiscountAmount + Amt4.VolumeDiscountAmount) AS TotalDiscountAmount
			FROM 
			(
				SELECT 
				Amt4.PurchaseSaleBookHeaderID
				,Amt4.PurchaseSaleBookLineItemID
				,FinalAmount AS BillAmount		 
				,(FinalAmount * .01 * PurchaseSaleTax) As TaxAmount
				,Amt4.GrossAmount
				,Amt4.SchemeAmount
				,Amt4.DiscountAmount
				,Amt4.SpecialDiscountAmount 
				,Amt4.VolumeDiscountAmount
				FROM UDF_GetAmountWithAllDiscountAmounts(@PurchaseSaleBookHeaderID) Amt4
			    INNER JOIN dbo.TempPurchaseSaleBookLineItem AS Final
				ON Amt4.PurchaseSaleBookHeaderID = final.PurchaseSaleBookHeaderID 
				AND Amt4.PurchaseSaleBookLineItemID = final.PurchaseSaleBookLineItemID
				WHERE final.PurchaseSaleBookHeaderID  = @PurchaseSaleBookHeaderID
			)Amt4 GROUP BY Amt4.PurchaseSaleBookHeaderID

		SELECT @PurchaseSaleBookHeaderID as PurchaseSaleBookHeaderID,
		LineItemID as PurchaseSaleBookLineItemID,
		0 as SchemeAmount,
		0 as GrossAmount,
		0 as CostAmount,
		0 as DiscountAmount,
		0 as VolumeDiscountAmount,
		0 as SpecialDiscountAmount,
		0 as TotalDiscountAmount,
		0 as BillAmount,
		0 as TaxAmount
		FROM @tblLineItemsDeleted
		UNION ALL
		SELECT PurchaseSaleBookHeaderID,
		PurchaseSaleBookLineItemID,
		SchemeAmount,
		GrossAmount,
		CostAmount,
		DiscountAmount,
		VolumeDiscountAmount,
		SpecialDiscountAmount,
		TotalDiscountAmount,
		BillAmount,
		TaxAmount
	FROM
		@TempTableAmountWithAllDiscountAmounts
	
		

	END TRY
    BEGIN CATCH    
		ROLLBACK TRAN 
		DECLARE @ErrorNumber INT = ERROR_NUMBER();
		DECLARE @ErrorMessage NVARCHAR(1000) = ERROR_MESSAGE() 
		RAISERROR('Error Number-%d : Error Message-%s', 16, 1, 
		@ErrorNumber, @ErrorMessage)   
    END CATCH
	
END
GO
/****** Object:  StoredProcedure [dbo].[GetCustomerLedgerByCode]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCustomerLedgerByCode]
(
 @customerCode VARCHAR(10)
)
AS
BEGIN

 SELECT 
  CL.[CustomerLedgerId] AS [CustomerLedgerId], 
  CL.[CustomerLedgerCode] AS [CustomerLedgerCode], 
  CL.[CustomerLedgerName] AS [CustomerLedgerName], 
  CL.[CustomerLedgerShortName] AS [CustomerLedgerShortName], 
  CL.[Address] AS [Address], 
  CL.[ContactPerson] AS [ContactPerson], 
  CL.[Telephone] AS [Telephone], 
  CL.[Mobile] AS [Mobile], 
  CL.[OfficePhone] AS [OfficePhone], 
  CL.[ResidentPhone] AS [ResidentPhone], 
  CL.[EmailAddress] AS [EmailAddress], 
  CL.[ZSMId] AS [ZSMId], 
  CL.[RSMId] AS [RSMId], 
  CL.[ASMId] AS [ASMId], 
  CL.[SalesManId] AS [SalesManId], 
  SM.[PersonRouteName] AS [SaleManName],
  SM.[PersonRouteCode] AS [SaleManCode], 
  CL.[AreaId] AS [AreaId], 
  CL.[RouteId] AS [RouteId], 
  CL.[CreditDebit] AS [CreditDebit], 
  CL.[DLNo] AS [DLNo], 
  CL.[GSTNo] AS [GSTNo], 
  CL.[CINNo] AS [CINNo], 
  CL.[LINNo] AS [LINNo], 
  CL.[ServiceTaxNo] AS [ServiceTaxNo], 
  CL.[PANNo] AS [PANNo], 
  CL.[OpeningBal] AS [OpeningBal], 
  CL.[TaxRetail] AS [TaxRetail], 
  CL.[Status] AS [Status], 
  CL.[CreditLimit] AS [CreditLimit], 
  CL.[CustomerTypeID] AS [CustomerTypeID], 
  CL.[InterestTypeID] AS [InterestTypeID], 
  CL.[IsLessExcise] AS [IsLessExcise], 
  CL.[RateTypeID] AS [RateTypeID], 
  R.[RateTypeName] AS [RateTypeName], 
  CL.[SaleBillFormat] AS [SaleBillFormat], 
  CL.[MaxOSAmount] AS [MaxOSAmount], 
  CL.[MaxNumOfOSBill] AS [MaxNumOfOSBill], 
  CL.[MaxBillAmount] AS [MaxBillAmount], 
  CL.[MaxGracePeriod] AS [MaxGracePeriod], 
  CL.[IsFollowConditionStrictly] AS [IsFollowConditionStrictly], 
  CL.[Discount] AS [Discount], 
  CL.[CentralLocal] AS [CentralLocal],
  DM.DueAmount AS [DueAmount],
  DM.DueCount
  FROM       [dbo].[CustomerLedger] AS CL
  LEFT OUTER JOIN [dbo].[PersonRouteMaster] AS SM ON CL.[SalesManId] = SM.[PersonRouteID]
  LEFT OUTER JOIN [dbo].RateType AS R ON CL.RateTypeID = R.RateTypeId
  OUTER APPLY ( 
   SELECT Sum(ISNULL(BO.OSAmount,0.00)) AS DueAmount, COUNT(BO.BillOutStandingsID) AS DueCount FROM [dbo].[BillOutStandings] BO 
   WHERE CL.CustomerLedgerCode = BO.LedgerTypeCode AND ISNULL(BO.VoucherTypeCode,'') = 'SALEENTRY' AND ISNULL(BO.OSAmount,'') <> 0
   GROUP BY BO.LedgerTypeCode
  )DM
  WHERE Cl.CustomerLedgerCode = @customerCode
END
GO
/****** Object:  StoredProcedure [dbo].[GetFinalAmountWithTaxForPurchase]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[GetPurchaseSaleBookHeaderForModify]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[GetPurchaseSaleBookLineItemsForModify]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPurchaseSaleBookLineItemsForModify]
	@PurchaseSaleBookHeaderID bigint
AS
BEGIN	
	BEGIN TRY	
	BEGIN TRAN
	
	
	DECLARE @OldPurchaseSaleBookHeaderID Bigint
	DECLARE @VoucherType nvarchar(100)
	
	SELECT @OldPurchaseSaleBookHeaderID  = OldPurchaseSaleBookHeaderID , @VoucherType = VoucherTypeCode
	FROM TempPurchaseSaleBookHeader WHERE PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID	
	
	IF @VoucherType = 'PURCHASEENTRY'
	BEGIN
	
		INSERT INTO TempPurchaseSaleBookLineItem
		(
			   PurchaseSaleBookHeaderID
			  ,FifoID,ItemCode,Batch,BatchNew
			  ,PurchaseSrlNo
			  ,Quantity,FreeQuantity
			  ,PurchaseSaleRate,EffecivePurchaseSaleRate
			  ,PurchaseSaleTypeCode,SurCharge,PurchaseSaleTax
			  ,LocalCentral,SGST,IGST,CGST
			  ,Amount,Discount,SpecialDiscount,DiscountQuantity,VolumeDiscount
			  ,Scheme1,Scheme2,IsHalfScheme,HalfSchemeRate
			  ,CostAmount,GrossAmount,SchemeAmount,DiscountAmount,SurchargeAmount
			  ,ConversionRate,MRP,ExpiryDate
			  ,SaleRate,WholeSaleRate,SpecialRate
			  ,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn
			  ,TaxAmount
			  ,SpecialDiscountAmount
			  ,VolumeDiscountAmount
			  ,TotalDiscountAmount
			  ,OldPurchaseSaleBookLineItemID  
			  ,BalanceQuantity
			  ,UsedQuantity
		)	
		SELECT 
			   @PurchaseSaleBookHeaderID AS PurchaseSaleBookHeaderID
			  ,F.FifoID,I.ItemCode,I.Batch,BatchNew
			  ,I.PurchaseSrlNo
			  ,I.Quantity,FreeQuantity
			  ,PurchaseSaleRate,EffecivePurchaseSaleRate
			  ,PurchaseSaleTypeCode,SurCharge,I.SalePurchaseTax AS PurchaseSaleTax
			  ,LocalCentral,SGST,IGST,CGST
			  ,Amount,Discount,SpecialDiscount,DiscountQuantity,VolumeDiscount
			  ,I.Scheme1,I.Scheme2,IsHalfScheme,HalfSchemeRate
			  ,CostAmount,GrossAmount,SchemeAmount,DiscountAmount,SurchargeAmount
			  ,ConversionRate,I.MRP,I.ExpiryDate
			  ,I.SaleRate,I.WholeSaleRate,I.SpecialRate
			  ,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn
			  ,TaxAmount
			  ,SpecialDiscountAmount
			  ,VolumeDiscountAmount
			  ,TotalDiscountAmount
			  ,PurchaseSaleBookLineItemID AS OldPurchaseSaleBookLineItemID
			  ,F.BalanceQuanity 
			  ,(F.Quantity - F.BalanceQuanity) AS UsedQuantity
		  FROM dbo.PurchaseSaleBookLineItem I
		  INNER JOIN FIFO F ON I.PurchaseSaleBookHeaderID = F.PurchaseSaleBookHeaderID
				AND I.PurchaseSrlNo = F.SRLNO
		  WHERE I.PurchaseSaleBookHeaderID = @OldPurchaseSaleBookHeaderID
      
      END
      ELSE
      BEGIN
      
				INSERT INTO TempPurchaseSaleBookLineItem
				(
					   PurchaseSaleBookHeaderID
					  ,FifoID,ItemCode,Batch,BatchNew
					  ,PurchaseBillDate,PurchaseVoucherNumber,PurchaseSrlNo
					  ,Quantity,FreeQuantity
					  ,PurchaseSaleRate,EffecivePurchaseSaleRate
					  ,PurchaseSaleTypeCode,SurCharge,PurchaseSaleTax
					  ,LocalCentral,SGST,IGST,CGST
					  ,Amount,Discount,SpecialDiscount,DiscountQuantity,VolumeDiscount
					  ,Scheme1,Scheme2,IsHalfScheme,HalfSchemeRate
					  ,CostAmount,GrossAmount,SchemeAmount,DiscountAmount,SurchargeAmount
					  ,ConversionRate,MRP,ExpiryDate
					  ,SaleRate,WholeSaleRate,SpecialRate
					  ,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn
					  ,TaxAmount
					  ,SpecialDiscountAmount
					  ,VolumeDiscountAmount
					  ,TotalDiscountAmount
					  ,OldPurchaseSaleBookLineItemID  
					  --,BalanceQuantity
					  --,UsedQuantity
				)	
				SELECT 
					   @PurchaseSaleBookHeaderID AS PurchaseSaleBookHeaderID
					  ,I.FifoID,I.ItemCode,I.Batch,BatchNew
					   ,I.PurchaseBillDate,I.PurchaseVoucherNumber,I.PurchaseSrlNo
					  ,I.Quantity,FreeQuantity
					  ,PurchaseSaleRate,EffecivePurchaseSaleRate
					  ,PurchaseSaleTypeCode,SurCharge,I.SalePurchaseTax AS PurchaseSaleTax
					  ,LocalCentral,SGST,IGST,CGST
					  ,Amount,Discount,SpecialDiscount,DiscountQuantity,VolumeDiscount
					  ,I.Scheme1,I.Scheme2,IsHalfScheme,HalfSchemeRate
					  ,CostAmount,GrossAmount,SchemeAmount,DiscountAmount,SurchargeAmount
					  ,ConversionRate,I.MRP,I.ExpiryDate
					  ,I.SaleRate,I.WholeSaleRate,I.SpecialRate
					  ,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn
					  ,TaxAmount
					  ,SpecialDiscountAmount
					  ,VolumeDiscountAmount
					  ,TotalDiscountAmount
					  ,PurchaseSaleBookLineItemID AS OldPurchaseSaleBookLineItemID
					  --,F.BalanceQuanity 
					  --,(F.Quantity - F.BalanceQuanity) AS UsedQuantity
				  FROM dbo.PurchaseSaleBookLineItem I
				  --INNER JOIN FIFO F ON I.PurchaseSaleBookHeaderID = F.PurchaseSaleBookHeaderID
						--AND I.PurchaseSrlNo = F.SRLNO
				  WHERE I.PurchaseSaleBookHeaderID = @OldPurchaseSaleBookHeaderID
					
      
      END
      
      SELECT       
		   PurchaseSaleBookHeaderID
		  ,PurchaseSaleBookLineItemID 
		  ,FifoID,I.ItemCode,B.ItemName ,Batch,BatchNew
		   ,PurchaseBillDate,PurchaseVoucherNumber,PurchaseSrlNo
		  ,Quantity,FreeQuantity
		  ,PurchaseSaleRate,EffecivePurchaseSaleRate
		  ,PurchaseSaleTypeCode,SurCharge,PurchaseSaleTax
		  ,LocalCentral,SGST,IGST,CGST
		  ,Amount,Discount,SpecialDiscount,DiscountQuantity,VolumeDiscount
		  ,Scheme1,Scheme2,IsHalfScheme,HalfSchemeRate
		  ,CostAmount,GrossAmount,SchemeAmount,DiscountAmount,SurchargeAmount
		  ,ConversionRate,MRP,ISNULL(ExpiryDate,GETDATE())  ExpiryDate
		  ,SaleRate,WholeSaleRate,SpecialRate
		  ,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn
		  ,TaxAmount
		  ,SpecialDiscountAmount
		  ,VolumeDiscountAmount
		  ,TotalDiscountAmount
		  ,OldPurchaseSaleBookLineItemID  
		  ,ISNULL(BalanceQuantity,0) AS BalanceQuantity
		  ,ISNULL(UsedQuantity,0) AS UsedQuantity
	FROM TempPurchaseSaleBookLineItem I
	INNER JOIN (
		SELECT ItemCode,ItemName  from ItemMaster
	) B ON I.ItemCode = B.ItemCode
	 WHERE PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID
  


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
GO
/****** Object:  StoredProcedure [dbo].[GetSaleLineItemByCode]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[GetSaleLineItemInfo]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateInvetoryHeadersInTempTable]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertUpdateInvetoryHeadersInTempTable]
  @TableTypePurchaseSaleBookHeader TableTypePurchaseSaleBookHeader READONLY
AS
BEGIN

 BEGIN TRY 
  BEGIN TRAN
   
   MERGE INTO dbo.TempPurchaseSaleBookHeader t1
   USING @TableTypePurchaseSaleBookHeader t2 ON t1.PurchaseSaleBookHeaderID = t2.PurchaseSaleBookHeaderID
   WHEN MATCHED THEN 
   UPDATE SET t1.VoucherTypeCode = t2.VoucherTypeCode
    ,t1.VoucherDate=t2.VoucherDate
    ,t1.DueDate=t2.DueDate
    ,t1.PurchaseBillNo=t2.PurchaseBillNo
    ,t1.LedgerType=t2.LedgerType
    ,t1.LedgerTypeCode=t2.LedgerTypeCode
    ,t1.LocalCentral=t2.LocalCentral
    ,t1.PurchaseEntryFormID=t2.PurchaseEntryFormID
    ,t1.Amount01=t2.Amount01
    ,t1.Amount02=t2.Amount02
    ,t1.Amount03=t2.Amount03
    ,t1.Amount04=t2.Amount04
    ,t1.Amount05=t2.Amount05
    ,t1.Amount06=t2.Amount06
    ,t1.Amount07=t2.Amount07
    ,t1.SGST01=t2.SGST01
    ,t1.SGST02=t2.SGST02
    ,t1.SGST03=t2.SGST03
    ,t1.SGST04=t2.SGST04
    ,t1.SGST05=t2.SGST05
    ,t1.SGST06=t2.SGST06
    ,t1.SGST07=t2.SGST07
    ,t1.IGST01=t2.IGST01
    ,t1.IGST02=t2.IGST02
    ,t1.IGST03=t2.IGST03
    ,t1.IGST04=t2.IGST04
    ,t1.IGST05=t2.IGST05
    ,t1.IGST06=t2.IGST06
    ,t1.IGST07=t2.IGST07
    ,t1.CGST01=t2.CGST01
    ,t1.CGST02=t2.CGST02
    ,t1.CGST03=t2.CGST03
    ,t1.CGST04=t2.CGST04
    ,t1.CGST05=t2.CGST05
    ,t1.CGST06=t2.CGST06
    ,t1.CGST07=t2.CGST07
    ,t1.TotalTaxAmount=t2.TotalTaxAmount
    ,t1.SurchargeAmount=t2.SurchargeAmount
    ,t1.TotalBillAmount=t2.TotalBillAmount
    ,t1.TotalCostAmount=t2.TotalCostAmount
    ,t1.TotalGrossAmount=t2.TotalGrossAmount
    ,t1.TotalSchemeAmount=t2.TotalSchemeAmount
    ,t1.TotalDiscountAmount=t2.TotalDiscountAmount
    ,t1.OtherAmount=t2.OtherAmount
    ,t1.FreshBreakageExcess=t2.FreshBreakageExcess
    ,t1.ReturnBillNo=t2.ReturnBillNo
    ,t1.ReturBillDate=t2.ReturBillDate
    ,t1.OrderNumber=t2.OrderNumber
    ,t1.ChallanNumber=t2.ChallanNumber
    ,t1.Message=t2.Message
    ,t1.Deliveryddress=t2.Deliveryddress
    ,t1.DeliveredBy=t2.DeliveredBy
    ,t1.CourierName=t2.CourierName
    ,t1.CourierDate=t2.CourierDate
    ,t1.CourierWeight=t2.CourierWeight
    ,t1.LastBalance=t2.LastBalance
    ,t1.ModifiedBy=t2.ModifiedBy
    ,t1.ModifiedOn=t2.ModifiedOn
   WHEN NOT MATCHED THEN
   INSERT 
      (VoucherTypeCode,VoucherDate
      ,DueDate,PurchaseBillNo
      ,LedgerType,LedgerTypeCode,LocalCentral,PurchaseEntryFormID
      ,Amount01,Amount02,Amount03,Amount04,Amount05,Amount06,Amount07
      ,SGST01,SGST02,SGST03,SGST04,SGST05,SGST06,SGST07
      ,IGST01,IGST02,IGST03,IGST04,IGST05,IGST06,IGST07
      ,CGST01,CGST02,CGST03,CGST04,CGST05,CGST06,CGST07
      ,TotalTaxAmount,SurchargeAmount,TotalBillAmount,TotalCostAmount
      ,TotalGrossAmount,TotalSchemeAmount,TotalDiscountAmount,OtherAmount
      ,FreshBreakageExcess
      ,ReturnBillNo,ReturBillDate           
      ,OrderNumber,ChallanNumber,Message
      ,Deliveryddress,DeliveredBy
      ,CourierName,CourierDate,CourierWeight           
      ,LastBalance
      ,CreatedBy,CreatedOn)
   VALUES ( 
     t2.VoucherTypeCode,t2.VoucherDate
       ,t2.DueDate,t2.PurchaseBillNo
       ,t2.LedgerType,t2.LedgerTypeCode,t2.LocalCentral,t2.PurchaseEntryFormID
       ,t2.Amount01,t2.Amount02,t2.Amount03,t2.Amount04,t2.Amount05,t2.Amount06,t2.Amount07
       ,t2.SGST01,t2.SGST02,t2.SGST03,t2.SGST04,t2.SGST05,t2.SGST06,t2.SGST07
       ,t2.IGST01,t2.IGST02,t2.IGST03,t2.IGST04,t2.IGST05,t2.IGST06,t2.IGST07
       ,t2.CGST01,t2.CGST02,t2.CGST03,t2.CGST04,t2.CGST05,t2.CGST06,t2.CGST07
       ,t2.TotalTaxAmount,t2.SurchargeAmount,t2.TotalBillAmount,t2.TotalCostAmount
       ,t2.TotalGrossAmount,t2.TotalSchemeAmount,t2.TotalDiscountAmount,t2.OtherAmount
       ,t2.FreshBreakageExcess
       ,t2.ReturnBillNo,t2.ReturBillDate           
       ,t2.OrderNumber,t2.ChallanNumber,t2.Message
       ,t2.Deliveryddress,t2.DeliveredBy
       ,t2.CourierName,t2.CourierDate,t2.CourierWeight           
       ,t2.LastBalance
       ,t2.CreatedBy,t2.CreatedOn
      );  
           
    
    DECLARE @PurchaseSaleBookHeaderID AS BIGINT
 
    SELECT @PurchaseSaleBookHeaderID = PurchaseSaleBookHeaderID FROM @TableTypePurchaseSaleBookHeader

    IF @PurchaseSaleBookHeaderID = 0
    BEGIN 
		SELECT @PurchaseSaleBookHeaderID = SCOPE_IDENTITY()
    END
 
    Select @PurchaseSaleBookHeaderID AS PurchaseSaleBookHeaderID 

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
GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateInvetoryLineItemInTempTable]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertUpdateInvetoryLineItemInTempTable]
	@TableTypePurchaseSaleBookLineItem TableTypePurchaseSaleBookLineItem READONLY
AS
BEGIN	
	BEGIN TRY	
	BEGIN TRAN
	
	MERGE INTO dbo.TempPurchaseSaleBookLineItem t1
	USING @TableTypePurchaseSaleBookLineItem t2 
	ON t1.PurchaseSaleBookLineItemID = t2.PurchaseSaleBookLineItemID
	WHEN MATCHED THEN 
	UPDATE SET t1.PurchaseSaleBookHeaderID=t2.PurchaseSaleBookHeaderID
		,t1.PurchaseBillDate=t2.PurchaseBillDate
		,t1.PurchaseVoucherNumber=t2.PurchaseVoucherNumber
		,t1.PurchaseSrlNo=t2.PurchaseSrlNo
		,t1.ItemCode=t2.ItemCode
		,t1.Batch=t2.Batch
		,t1.BatchNew=t2.BatchNew
		,t1.Quantity=t2.Quantity
		,t1.FreeQuantity=t2.FreeQuantity
		,t1.PurchaseSaleRate=t2.PurchaseSaleRate
		,t1.EffecivePurchaseSaleRate=t2.EffecivePurchaseSaleRate
		,t1.PurchaseSaleTypeCode=t2.PurchaseSaleTypeCode
		,t1.SurCharge=t2.SurCharge
		,t1.PurchaseSaleTax=t2.PurchaseSaleTax
		,t1.LocalCentral=t2.LocalCentral
		,t1.SGST=t2.SGST
		,t1.IGST=t2.IGST
		,t1.CGST=t2.CGST
		,t1.Amount=t2.Amount
		,t1.Discount=t2.Discount
		,t1.SpecialDiscount=t2.SpecialDiscount
		,t1.DiscountQuantity=t2.DiscountQuantity
		,t1.VolumeDiscount=t2.VolumeDiscount
		,t1.Scheme1=t2.Scheme1
		,t1.Scheme2=t2.Scheme2
		,t1.IsHalfScheme=t2.IsHalfScheme
		,t1.HalfSchemeRate=t2.HalfSchemeRate
		,t1.ConversionRate=t2.ConversionRate
		,t1.MRP=t2.MRP
		,t1.ExpiryDate=t2.ExpiryDate
		,t1.SaleRate=t2.SaleRate
		,t1.WholeSaleRate=t2.WholeSaleRate
		,t1.SpecialRate=t2.SpecialRate		
		,t1.ModifiedBy=t2.ModifiedBy
		,t1.ModifiedOn=t2.ModifiedOn
	WHEN NOT MATCHED THEN
	INSERT (
		 PurchaseSaleBookHeaderID
		,PurchaseBillDate,PurchaseVoucherNumber,PurchaseSrlNo
		,ItemCode,Batch,BatchNew
		,Quantity,FreeQuantity
		,PurchaseSaleRate,EffecivePurchaseSaleRate
		,PurchaseSaleTypeCode,SurCharge
		,PurchaseSaleTax
		,LocalCentral,SGST,IGST,CGST
		,Amount,Discount,SpecialDiscount,DiscountQuantity,VolumeDiscount
		,Scheme1,Scheme2,IsHalfScheme,HalfSchemeRate		
		,ConversionRate,MRP,ExpiryDate
		,SaleRate,WholeSaleRate,SpecialRate
		,CreatedBy,CreatedOn	
	)
	VALUES
	(
		 t2.PurchaseSaleBookHeaderID
		,t2.PurchaseBillDate,t2.PurchaseVoucherNumber,t2.PurchaseSrlNo
		,t2.ItemCode,t2.Batch,t2.BatchNew
		,t2.Quantity,t2.FreeQuantity
		,t2.PurchaseSaleRate,t2.EffecivePurchaseSaleRate
		,t2.PurchaseSaleTypeCode,t2.SurCharge
		,t2.PurchaseSaleTax
		,t2.LocalCentral,t2.SGST,t2.IGST,t2.CGST
		,t2.Amount,t2.Discount,t2.SpecialDiscount,t2.DiscountQuantity,t2.VolumeDiscount
		,t2.Scheme1,t2.Scheme2,t2.IsHalfScheme,t2.HalfSchemeRate		
		,t2.ConversionRate,t2.MRP,t2.ExpiryDate
		,t2.SaleRate,t2.WholeSaleRate,t2.SpecialRate
		,t2.CreatedBy,t2.CreatedOn
	);	
	
	
	MERGE INTO dbo.ItemMaster t1
	USING @TableTypePurchaseSaleBookLineItem t2 
	ON t1.ItemCode = t2.ItemCode
	WHEN MATCHED THEN 
	UPDATE SET t1.PurchaseRate = t2.PurchaseSaleRate
			,t1.MRP = t2.MRP
			,t1.SaleRate = t2.SaleRate
			,t1.SpecialRate = t2.SpecialRate
			,t1.WholeSaleRate = t2.WholeSaleRate
			,t1.Scheme1 = t2.Scheme1
			,t1.Scheme2 = t2.Scheme2
			,t1.IsHalfScheme = t2.IsHalfScheme
			,t1.DiscountRecieved = t2.Discount
			,t1.SpecialDiscountRecieved =t2.SpecialDiscount
			,t1.BATCH = t2.BATCH
			,t1.ExpiryDate  = t2.ExpiryDate
			;
	
	
	DECLARE @PurchaseSaleBookLineItemID AS BIGINT
	DECLARE @PurchaseSaleBookHeaderID AS BIGINT
	
	SELECT @PurchaseSaleBookLineItemID = PurchaseSaleBookLineItemID 
			,@PurchaseSaleBookHeaderID = PurchaseSaleBookHeaderID
	FROM @TableTypePurchaseSaleBookLineItem

	IF @PurchaseSaleBookLineItemID = 0
	BEGIN	
		SELECT @PurchaseSaleBookLineItemID = SCOPE_IDENTITY()
	END
	
	
		DECLARE @TempTableAmountWithAllDiscountAmounts TABLE (
		   PurchaseSaleBookHeaderID BIGINT NOT NULL,
		   PurchaseSaleBookLineItemID BIGINT NOT NULL,
		   FinalAmount FLOAT NOT NULL,
		   GrossAmount FLOAT NOT NULL,
		   SchemeAmount FLOAT NOT NULL,
		   DiscountAmount FLOAT NOT NULL,
		   SpecialDiscountAmount FLOAT NOT NULL,
		   VolumeDiscountAmount FLOAT NOT NULL   
		) ;
		
		
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
		  SELECT PurchaseSaleBookHeaderID
				,PurchaseSaleBookLineItemID
				,FinalAmount
				,GrossAmount
				,SchemeAmount
				,DiscountAmount
				,SpecialDiscountAmount
				,VolumeDiscountAmount
		FROM UDF_GetAmountWithAllDiscountAmounts(@PurchaseSaleBookHeaderID)


	  
		SELECT 
		  Amt4.PurchaseSaleBookHeaderID
		 ,0 AS PurchaseSaleBookLineItemID
		 ,SUM(Amt4.BillAmount) AS BillAmount
		 ,0 AS CostAmount
		 ,SUM(Amt4.TaxAmount) As TaxAmount
		 ,SUM(Amt4.GrossAmount) AS GrossAmount
		 ,SUM(Amt4.SchemeAmount) AS SchemeAmount
		 ,SUM(Amt4.DiscountAmount) AS DiscountAmount
		 ,SUM(Amt4.SpecialDiscountAmount) AS SpecialDiscountAmount
		 ,SUM(Amt4.VolumeDiscountAmount) AS VolumeDiscountAmount
		 ,SUM(Amt4.DiscountAmount + Amt4.SpecialDiscountAmount + Amt4.VolumeDiscountAmount) AS TotalDiscountAmount
		FROM 
		(
			SELECT 
				Amt4.PurchaseSaleBookHeaderID
				,Amt4.PurchaseSaleBookLineItemID
				,Amt4.FinalAmount AS BillAmount		 
				,(Amt4.FinalAmount * .01 * Final.PurchaseSaleTax) As TaxAmount
				,Amt4.GrossAmount
				,Amt4.SchemeAmount
				,Amt4.DiscountAmount
				,Amt4.SpecialDiscountAmount 
				,Amt4.VolumeDiscountAmount
		 FROM @TempTableAmountWithAllDiscountAmounts AS Amt4
		 INNER JOIN dbo.TempPurchaseSaleBookLineItem AS Final
			 ON Amt4.PurchaseSaleBookHeaderID = final.PurchaseSaleBookHeaderID 
		      AND Amt4.PurchaseSaleBookLineItemID = final.PurchaseSaleBookLineItemID
		  WHERE final.PurchaseSaleBookHeaderID  = @PurchaseSaleBookHeaderID
		) Amt4
		GROUP BY Amt4.PurchaseSaleBookHeaderID
	   
		UNION ALL
		
		SELECT 
			 @PurchaseSaleBookHeaderID AS PurchaseSaleBookHeaderID
			,@PurchaseSaleBookLineItemID AS PurchaseSaleBookLineItemID
			,B.FinalAmount AS BillAmount
			,B.FinalAmount AS CostAmount
			,(B.FinalAmount * .01 * Final.PurchaseSaleTax) As TaxAmount			
			,B.GrossAmount
			,B.SchemeAmount
			,B.DiscountAmount
			,B.SpecialDiscountAmount
			,B.VolumeDiscountAmount
			,(B.DiscountAmount + b.SpecialDiscountAmount + b.VolumeDiscountAmount) AS TotalDiscountAmount
		 FROM dbo.TempPurchaseSaleBookLineItem Final
		 INNER JOIN @TempTableAmountWithAllDiscountAmounts AS B
		    On Final.PurchaseSaleBookHeaderID = B.PurchaseSaleBookHeaderID 
			AND Final.PurchaseSaleBookLineItemID = B.PurchaseSaleBookLineItemID 
		 WHERE Final.PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID
			AND Final.PurchaseSaleBookLineItemID = @PurchaseSaleBookLineItemID

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

GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateInvetoryLineItemInTempTableForSale]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertUpdateInvetoryLineItemInTempTableForSale]
	@TableTypePurchaseSaleBookLineItem TableTypePurchaseSaleBookLineItem READONLY
AS
BEGIN	
	BEGIN TRY	
	BEGIN TRAN
	
	
	DECLARE @LineItems AS TABLE
	(
		PurchaseSaleBookLineItemID BIGINT
	)
	
	DECLARE @LocalCentral NVARCHAR(1)
	
	
	DECLARE @PurchaseSaleBookHeaderID BIGINT
	DECLARE @OldQuantity decimal(18,2), @Quantity decimal(18,2)
	DECLARE @TotalQuantityForItem decimal(18,2)
	DECLARE @OldFreeQuantity decimal(18,2), @FreeQuantity decimal(18,2), @NewFreeQuantity decimal(18,2)
	DECLARE @BalanceQuantity decimal(18,2), @NewQuantity decimal(18,2)
	DECLARE @OldFifoId BIGINT,@OldPurchaseSaleBookLineItemID BIGINT
	DECLARE @ItemCode nvarchar(10)
	
	--GET THE QUANTITY FOR SPECIFIC LINE ITEM
	SELECT @PurchaseSaleBookHeaderID = PurchaseSaleBookHeaderID
		,@OldPurchaseSaleBookLineItemID = PurchaseSaleBookLineItemID
		,@ItemCode = ItemCode
		,@Quantity = ISNULL(Quantity,0)
		,@OldFifoId = FifoID 
		,@FreeQuantity = ISNULL(FreeQuantity,0)
	FROM @TableTypePurchaseSaleBookLineItem		
	
	SELECT @LocalCentral = LocalCentral FROM TempPurchaseSaleBookHeader WHERE PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID
	
	Select @OldQuantity = Quantity 
		   ,@OldFreeQuantity = FreeQuantity
		--,@OldPurchaseSaleBookLineItemID =PurchaseSaleBookLineItemID
	FROM TempPurchaseSaleBookLineItem 
	WHERE PurchaseSaleBookLineItemID = @OldPurchaseSaleBookLineItemID
	
	SELECT @Quantity = ISNULL(@Quantity,0), 
		   @OldFreeQuantity = ISNULL(@OldFreeQuantity,0), 
		   @OldQuantity = ISNULL(@OldQuantity,0),
		   @OldPurchaseSaleBookLineItemID = ISNULL(@OldPurchaseSaleBookLineItemID,0)
	
	IF ( @Quantity < @OldQuantity OR @FreeQuantity < @OldFreeQuantity )
	BEGIN
	
						--SELECT @TotalQuantityForItem = SUM(Quantity)
						--FROM TempPurchaseSaleBookLineItem 
						--WHERE PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID AND ItemCode = @ItemCode
						
						--SET @TotalQuantityForItem  = ISNULL(@TotalQuantityForItem,0) - (@OldQuantity - @Quantity)
						
						--SET @FreeQuantity = dbo.GetFreeQuantity(@ItemCode,@TotalQuantityForItem)
						
						SET @NewFreeQuantity = @OldFreeQuantity - @FreeQuantity
		
						
						MERGE INTO dbo.TempPurchaseSaleBookLineItem t1
						USING @TableTypePurchaseSaleBookLineItem t2 
						ON t1.PurchaseSaleBookLineItemID = t2.PurchaseSaleBookLineItemID
						WHEN MATCHED THEN 
						UPDATE SET t1.PurchaseSaleBookHeaderID=t2.PurchaseSaleBookHeaderID
							,t1.PurchaseBillDate=t2.PurchaseBillDate
							,t1.PurchaseVoucherNumber=t2.PurchaseVoucherNumber
							,t1.PurchaseSrlNo=t2.PurchaseSrlNo
							,t1.Quantity=t2.Quantity
							,t1.FreeQuantity= @FreeQuantity
							,t1.PurchaseSaleRate=t2.PurchaseSaleRate
							,t1.EffecivePurchaseSaleRate=t2.EffecivePurchaseSaleRate
							,t1.PurchaseSaleTypeCode=t2.PurchaseSaleTypeCode
							,t1.SurCharge=t2.SurCharge
							,t1.PurchaseSaleTax=t2.PurchaseSaleTax
							,t1.LocalCentral=@LocalCentral
							,t1.SGST=t2.SGST
							,t1.IGST=t2.IGST
							,t1.CGST=t2.CGST
							,t1.Amount=t2.Amount
							,t1.Discount=t2.Discount
							,t1.SpecialDiscount=t2.SpecialDiscount
							,t1.DiscountQuantity=t2.DiscountQuantity
							,t1.VolumeDiscount=t2.VolumeDiscount
							,t1.Scheme1=t2.Scheme1
							,t1.Scheme2=t2.Scheme2
							,t1.IsHalfScheme=t2.IsHalfScheme
							,t1.HalfSchemeRate=t2.HalfSchemeRate
							,t1.ConversionRate=t2.ConversionRate
							,t1.MRP=t2.MRP
							,t1.ExpiryDate=t2.ExpiryDate
							,t1.SaleRate=t2.SaleRate
							,t1.WholeSaleRate=t2.WholeSaleRate
							,t1.SpecialRate=t2.SpecialRate		
							,t1.ModifiedBy=t2.ModifiedBy
							,t1.ModifiedOn=t2.ModifiedOn;
							
						Update FIFO Set BalanceQuanity = BalanceQuanity + (@OldQuantity - @Quantity) + (@OldFreeQuantity - @FreeQuantity) WHERE FifoID = @OldFifoId
						
						INSERT INTO @LineItems(PurchaseSaleBookLineItemID)
						SELECT @OldPurchaseSaleBookLineItemID
	END
	ELSE 
	BEGIN
	
				--SELECT @TotalQuantityForItem = SUM(Quantity)
				--FROM TempPurchaseSaleBookLineItem 
				--WHERE PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID AND ItemCode = @ItemCode
				
				--SET @TotalQuantityForItem  = ISNULL(@TotalQuantityForItem,0) + (@Quantity - @OldQuantity)
				
				--SET @FreeQuantity = dbo.GetFreeQuantity(@ItemCode,@TotalQuantityForItem)
				
				SET @NewFreeQuantity = @FreeQuantity - @OldFreeQuantity			

				SELECT @BalanceQuantity = ISNULL(@BalanceQuantity,0) FROM FIFO WHERE FifoID = ISNULL(@OldFifoId,0)
				
				SET @NewQuantity = @Quantity  - ISNULL(@OldQuantity,0)				
			
				--SELECT @BalanceQuantity, @NewFreeQuantity, @NewQuantity, @OldFifoId, @OldFreeQuantity, @OldQuantity, @FreeQuantity
				
				IF ISNULL(@OldPurchaseSaleBookLineItemID,0) <> 0 
					AND ISNULL(@OldFifoId ,0) <> 0 
					AND ISNULL(@OldQuantity,0) <> ISNULL(@Quantity,0)
					AND @BalanceQuantity > (@NewQuantity + FLOOR(@NewFreeQuantity))
				BEGIN
					
						MERGE INTO dbo.TempPurchaseSaleBookLineItem t1
						USING @TableTypePurchaseSaleBookLineItem t2 
						ON t1.PurchaseSaleBookLineItemID = t2.PurchaseSaleBookLineItemID
						WHEN MATCHED THEN 
						UPDATE SET t1.PurchaseSaleBookHeaderID=t2.PurchaseSaleBookHeaderID
							,t1.PurchaseBillDate=t2.PurchaseBillDate
							,t1.PurchaseVoucherNumber=t2.PurchaseVoucherNumber
							,t1.PurchaseSrlNo=t2.PurchaseSrlNo
							,t1.Quantity=t2.Quantity
							,t1.FreeQuantity= t1.FreeQuantity + FLOOR(@NewFreeQuantity)
							,t1.PurchaseSaleRate=t2.PurchaseSaleRate
							,t1.EffecivePurchaseSaleRate=t2.EffecivePurchaseSaleRate
							,t1.PurchaseSaleTypeCode=t2.PurchaseSaleTypeCode
							,t1.SurCharge=t2.SurCharge
							,t1.PurchaseSaleTax=t2.PurchaseSaleTax
							,t1.LocalCentral=@LocalCentral
							,t1.SGST=t2.SGST
							,t1.IGST=t2.IGST
							,t1.CGST=t2.CGST
							,t1.Amount=t2.Amount
							,t1.Discount=t2.Discount
							,t1.SpecialDiscount=t2.SpecialDiscount
							,t1.DiscountQuantity=t2.DiscountQuantity
							,t1.VolumeDiscount=t2.VolumeDiscount
							,t1.Scheme1=t2.Scheme1
							,t1.Scheme2=t2.Scheme2
							,t1.IsHalfScheme=t2.IsHalfScheme
							,t1.HalfSchemeRate=t2.HalfSchemeRate
							,t1.ConversionRate=t2.ConversionRate
							,t1.MRP=t2.MRP
							,t1.ExpiryDate=t2.ExpiryDate
							,t1.SaleRate=t2.SaleRate
							,t1.WholeSaleRate=t2.WholeSaleRate
							,t1.SpecialRate=t2.SpecialRate		
							,t1.ModifiedBy=t2.ModifiedBy
							,t1.ModifiedOn=t2.ModifiedOn;
							
						Update FIFO Set BalanceQuanity = BalanceQuanity - @NewQuantity - FLOOR(@NewFreeQuantity) WHERE FifoID = @OldFifoId -- 
						
						INSERT INTO @LineItems(PurchaseSaleBookLineItemID)
						SELECT @OldPurchaseSaleBookLineItemID
					
				END
				ELSE
					BEGIN
					
							IF ((@NewQuantity + FLOOR(@NewFreeQuantity)) > 0)
							BEGIN 
							
								DECLARE @FifoID Bigint
								DECLARE @QtytobeInsert decimal(18,2)
								DECLARE @FreeQtyToBeInsert decimal(18,2)
								
								WHILE ((@NewQuantity + FLOOR(@NewFreeQuantity)) > 0)
								BEGIN

										SELECT TOP 1 @FifoID = FifoID,@BalanceQuantity = BalanceQuanity FROM FIFO
										WHERE ItemCode = @ItemCode AND BalanceQuanity > 0
										ORDER BY FifoID ASC
									
										IF @NewQuantity >= @BalanceQuantity
										BEGIN
											SET @QtytobeInsert = @BalanceQuantity
											SET @FreeQtyToBeInsert = 0
										END
										ELSE IF (@NewQuantity <= @BalanceQuantity AND (@NewQuantity + FLOOR(@NewFreeQuantity)) >= @BalanceQuantity)
										BEGIN
												SET @QtytobeInsert = @NewQuantity
												SET @FreeQtyToBeInsert = @BalanceQuantity - @NewQuantity
										END
										ELSE IF (@NewQuantity <= @BalanceQuantity AND (@NewQuantity + FLOOR(@NewFreeQuantity)) <= @BalanceQuantity)
										BEGIN
												SET @QtytobeInsert = @NewQuantity
												SET @FreeQtyToBeInsert = FLOOR(@NewFreeQuantity)
										END
										--ELSE IF (@NewQuantity = 0 AND (FLOOR(@NewFreeQuantity) > @BalanceQuantity))
										--BEGIN
										--		SET @QtytobeInsert = 0
										--		SET @FreeQtyToBeInsert = @BalanceQuantity
										--END
										--ELSE IF (@NewQuantity = 0 AND (FLOOR(@NewFreeQuantity) < @BalanceQuantity))
										--BEGIN
										--	SET @QtytobeInsert = 0
										--	SET @FreeQtyToBeInsert = FLOOR(@NewFreeQuantity)
										--END
										
										
										IF EXISTS(Select * FROM TempPurchaseSaleBookLineItem Where FifoID = @FifoID AND PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID)
										BEGIN
												IF(ISNULL(@fifoID,0) = ISNULL(@OldfifoID,0))
												BEGIN
														MERGE INTO dbo.TempPurchaseSaleBookLineItem t1
														USING @TableTypePurchaseSaleBookLineItem t2 
														ON t1.PurchaseSaleBookLineItemID = t2.PurchaseSaleBookLineItemID
														WHEN MATCHED THEN 
														UPDATE SET t1.PurchaseSaleBookHeaderID=t2.PurchaseSaleBookHeaderID
															,t1.PurchaseBillDate=t2.PurchaseBillDate
															,t1.PurchaseVoucherNumber=t2.PurchaseVoucherNumber
															,t1.PurchaseSrlNo=t2.PurchaseSrlNo
															,t1.Quantity= t1.Quantity + ISNULL(@QtytobeInsert,0)
															,t1.FreeQuantity=t1.FreeQuantity + @FreeQtyToBeInsert
															,t1.PurchaseSaleRate=t2.PurchaseSaleRate
															,t1.EffecivePurchaseSaleRate=t2.EffecivePurchaseSaleRate
															,t1.PurchaseSaleTypeCode=t2.PurchaseSaleTypeCode
															,t1.SurCharge=t2.SurCharge
															,t1.PurchaseSaleTax=t2.PurchaseSaleTax
															,t1.LocalCentral=@LocalCentral
															,t1.SGST=t2.SGST
															,t1.IGST=t2.IGST
															,t1.CGST=t2.CGST
															,t1.Amount=t2.Amount
															,t1.Discount=t2.Discount
															,t1.SpecialDiscount=t2.SpecialDiscount
															,t1.DiscountQuantity=t2.DiscountQuantity
															,t1.VolumeDiscount=t2.VolumeDiscount
															,t1.Scheme1=t2.Scheme1
															,t1.Scheme2=t2.Scheme2
															,t1.IsHalfScheme=t2.IsHalfScheme
															,t1.HalfSchemeRate=t2.HalfSchemeRate
															,t1.ConversionRate=t2.ConversionRate
															,t1.MRP=t2.MRP
															,t1.ExpiryDate=t2.ExpiryDate
															,t1.SaleRate=t2.SaleRate
															,t1.WholeSaleRate=t2.WholeSaleRate
															,t1.SpecialRate=t2.SpecialRate		
															,t1.ModifiedBy=t2.ModifiedBy
															,t1.ModifiedOn=t2.ModifiedOn;
															
												INSERT Into @LineItems (PurchaseSaleBookLineItemID)
												VALUES (@OldPurchaseSaleBookLineItemID)
										
											END
											ELSE
											BEGIn
												UPDATE TempPurchaseSaleBookLineItem 
													Set Quantity = Quantity + ISNULL(@QtytobeInsert,0) 
													,FreeQuantity  = FreeQuantity + @FreeQtyToBeInsert
												WHERE FifoID = @FifoID AND PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID

												Insert Into  @LineItems (PurchaseSaleBookLineItemID)
												SELECT PurchaseSaleBookLineItemID FROM TempPurchaseSaleBookLineItem WHERE FifoID = @FifoID AND PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID
											END
										END
										ELSE
										BEGIN
											MERGE INTO dbo.TempPurchaseSaleBookLineItem t1
											USING 
											(
												SELECT 
													 @PurchaseSaleBookHeaderID AS PurchaseSaleBookHeaderID
													 ,F.Fifoid
													,F.VoucherDate AS PurchaseBillDate
													,F.VoucherNumber AS PurchaseVoucherNumber
													,F.SRLNO AS  PurchaseSrlNo
													,F.ItemCode,F.Batch,BatchNew
													,@QtytobeInsert AS Quantity,@FreeQtyToBeInsert as FreeQuantity
													,PurchaseSaleRate,EffecivePurchaseSaleRate
													,ALM.AccountLedgerCode AS PurchaseSaleTypeCode,SurCharge
													,L.SalePurchaseTax
													,LocalCentral,SGST,IGST,CGST
													,Amount
													,COALESCE(L.Discount,0) AS Discount
													,COALESCE(L.SpecialDiscount,0) AS SpecialDiscount
													,COALESCE(L.DiscountQuantity,0) AS DiscountQuantity
													,COALESCE(L.VolumeDiscount,0) AS VolumeDiscount
													,F.Scheme1,F.Scheme2
													,0 AS IsHalfScheme
													,0 AS HalfSchemeRate		
													,I.ConversionRate,F.MRP,F.ExpiryDate
													,COALESCE(F.SaleRate,I.SaleRate) AS SaleRate
													,F.WholeSaleRate,F.SpecialRate
													,L.CreatedBy,L.CreatedOn
													,0 AS PurchaseSaleBookLineItemID
												FROM FIFO	F
												INNER JOIN dbo.PurchaseSaleBookLineItem L ON F.PurchaseSaleBookHeaderID = L.PurchaseSaleBookHeaderID
												AND F.ItemCode = L.ItemCode
												AND F.Batch = L.Batch
												INNER JOIN ItemMaster I ON I.ItemCode = F.ItemCode
												INNER JOIN AccountLedgerMaster ALM ON ALM.AccountLedgerID = I.SaleTypeId
												WHERE F.FifoID = @fifoid
										
											) t2 
											ON t1.PurchaseSaleBookLineItemID = t2.PurchaseSaleBookLineItemID
											WHEN NOT MATCHED THEN
											INSERT (
												 PurchaseSaleBookHeaderID
												,Fifoid
												,PurchaseBillDate,PurchaseVoucherNumber,PurchaseSrlNo
												,ItemCode,Batch,BatchNew
												,Quantity,FreeQuantity
												,PurchaseSaleRate,EffecivePurchaseSaleRate
												,PurchaseSaleTypeCode,SurCharge
												,PurchaseSaleTax
												,LocalCentral,SGST,IGST,CGST
												,Amount,Discount,SpecialDiscount,DiscountQuantity,VolumeDiscount
												,Scheme1,Scheme2,IsHalfScheme,HalfSchemeRate		
												,ConversionRate,MRP,ExpiryDate
												,SaleRate,WholeSaleRate,SpecialRate
												,CreatedBy,CreatedOn	
											)
											VALUES
											(
												 t2.PurchaseSaleBookHeaderID
												,@fifoid
												,t2.PurchaseBillDate,t2.PurchaseVoucherNumber,t2.PurchaseSrlNo
												,t2.ItemCode,t2.Batch,t2.BatchNew
												,t2.Quantity,t2.FreeQuantity
												,t2.PurchaseSaleRate,t2.EffecivePurchaseSaleRate
												,t2.PurchaseSaleTypeCode,t2.SurCharge
												,t2.SalePurchaseTax
												,@LocalCentral,t2.SGST,t2.IGST,t2.CGST
												,t2.Amount,t2.Discount,t2.SpecialDiscount,t2.DiscountQuantity,t2.VolumeDiscount
												,t2.Scheme1,t2.Scheme2,t2.IsHalfScheme,t2.HalfSchemeRate		
												,t2.ConversionRate,t2.MRP,t2.ExpiryDate
												,t2.SaleRate,t2.WholeSaleRate,t2.SpecialRate
												,t2.CreatedBy,t2.CreatedOn
											);
					
										INSERT @LineItems (PurchaseSaleBookLineItemID)
										VALUES (SCOPE_IDENTITY())
										
										END					
										SET @NewQuantity = @NewQuantity - @QtytobeInsert 
										SET @NewFreeQuantity = @NewFreeQuantity - @FreeQtyToBeInsert										
										
										Update FIFO Set BalanceQuanity = (BalanceQuanity - @QtytobeInsert - FLOOR(@FreeQtyToBeInsert)) WHERE FifoID = @FifoID

								END
							END
							ELSE IF ((@NewQuantity + FLOOR(@NewFreeQuantity)) = 0)
								BEGIN
								
										MERGE INTO dbo.TempPurchaseSaleBookLineItem t1
										USING @TableTypePurchaseSaleBookLineItem t2 
										ON t1.PurchaseSaleBookLineItemID = t2.PurchaseSaleBookLineItemID
										WHEN MATCHED THEN
											UPDATE SET t1.PurchaseSaleBookHeaderID=t2.PurchaseSaleBookHeaderID
											,t1.PurchaseBillDate=t2.PurchaseBillDate
											,t1.PurchaseVoucherNumber=t2.PurchaseVoucherNumber
											,t1.PurchaseSrlNo=t2.PurchaseSrlNo
											--,t1.Quantity= t1.Quantity + t2.Quantity
											--,t1.FreeQuantity=t1.FreeQuantity + t2.FreeQuantity
											,t1.PurchaseSaleRate=t2.PurchaseSaleRate
											,t1.EffecivePurchaseSaleRate=t2.EffecivePurchaseSaleRate
											,t1.PurchaseSaleTypeCode=t2.PurchaseSaleTypeCode
											,t1.SurCharge=t2.SurCharge
											,t1.PurchaseSaleTax=t2.PurchaseSaleTax
											,t1.LocalCentral=@LocalCentral
											,t1.SGST=t2.SGST
											,t1.IGST=t2.IGST
											,t1.CGST=t2.CGST
											,t1.Amount=t2.Amount
											,t1.Discount=t2.Discount
											,t1.SpecialDiscount=t2.SpecialDiscount
											,t1.DiscountQuantity=t2.DiscountQuantity
											,t1.VolumeDiscount=t2.VolumeDiscount
											,t1.Scheme1=t2.Scheme1
											,t1.Scheme2=t2.Scheme2
											,t1.IsHalfScheme=t2.IsHalfScheme
											,t1.HalfSchemeRate=t2.HalfSchemeRate
											,t1.ConversionRate=t2.ConversionRate
											,t1.MRP=t2.MRP
											,t1.ExpiryDate=t2.ExpiryDate
											,t1.SaleRate=t2.SaleRate
											,t1.WholeSaleRate=t2.WholeSaleRate
											,t1.SpecialRate=t2.SpecialRate		
											,t1.ModifiedBy=t2.ModifiedBy
											,t1.ModifiedOn=t2.ModifiedOn
							
										WHEN NOT MATCHED THEN
										INSERT (
											 PurchaseSaleBookHeaderID
											,PurchaseBillDate,PurchaseVoucherNumber,PurchaseSrlNo,FifoID
											,ItemCode,Batch,BatchNew
											,Quantity,FreeQuantity
											,PurchaseSaleRate,EffecivePurchaseSaleRate
											,PurchaseSaleTypeCode,SurCharge
											,PurchaseSaleTax
											,LocalCentral,SGST,IGST,CGST
											,Amount,Discount,SpecialDiscount,DiscountQuantity,VolumeDiscount
											,Scheme1,Scheme2,IsHalfScheme,HalfSchemeRate		
											,ConversionRate,MRP,ExpiryDate
											,SaleRate,WholeSaleRate,SpecialRate
											,CreatedBy,CreatedOn	
										)
										VALUES
										(
											 t2.PurchaseSaleBookHeaderID
											,t2.PurchaseBillDate,t2.PurchaseVoucherNumber,t2.PurchaseSrlNo, t2.FifoID
											,t2.ItemCode,t2.Batch,t2.BatchNew
											,t2.Quantity,t2.FreeQuantity
											,t2.PurchaseSaleRate,t2.EffecivePurchaseSaleRate
											,t2.PurchaseSaleTypeCode,t2.SurCharge
											,t2.PurchaseSaleTax
											,@LocalCentral,t2.SGST,t2.IGST,t2.CGST
											,t2.Amount,t2.Discount,t2.SpecialDiscount,t2.DiscountQuantity,t2.VolumeDiscount
											,t2.Scheme1,t2.Scheme2,t2.IsHalfScheme,t2.HalfSchemeRate		
											,t2.ConversionRate,t2.MRP,t2.ExpiryDate
											,t2.SaleRate,t2.WholeSaleRate,t2.SpecialRate
											,t2.CreatedBy,t2.CreatedOn
										);
										
										
										
										IF(@OldPurchaseSaleBookLineItemID > 0)
										BEGIN
											INSERT @LineItems (PurchaseSaleBookLineItemID)
											VALUES (@OldPurchaseSaleBookLineItemID)
										END
										ELSE
										BEGIN
												INSERT @LineItems (PurchaseSaleBookLineItemID)
												VALUES (SCOPE_IDENTITY())
										END
								END
					END
	END
	
	
	MERGE INTO dbo.ItemMaster t1
	USING @TableTypePurchaseSaleBookLineItem t2 
	ON t1.ItemCode = t2.ItemCode
	WHEN MATCHED THEN 
	UPDATE SET t1.SaleRate = t2.SaleRate;
			

	COMMIT TRAN 
	
	DECLARE @TempTableAmountWithAllDiscountAmounts TABLE (
	   PurchaseSaleBookHeaderID BIGINT NOT NULL,
	   PurchaseSaleBookLineItemID BIGINT NOT NULL,
	   FinalAmount FLOAT NOT NULL,
	   GrossAmount FLOAT NOT NULL,
	   SchemeAmount FLOAT NOT NULL,
	   DiscountAmount FLOAT NOT NULL,
	   SpecialDiscountAmount FLOAT NOT NULL,
	   VolumeDiscountAmount FLOAT NOT NULL   
	) ;


	--IF EXISTS(Select 1 FROM @LineItems)
	--BEGIN
	--	INSERT INTO @LineItems
	--	SELECT PurchaseSaleBookLineItemID FROM TempPurchaseSaleBookLineItem 
	--	WHERE ItemCode = @ItemCode AND PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID
	--	AND PurchaseSaleBookLineItemID NOT IN (SELECT PurchaseSaleBookLineItemID FROM @LineItems)
	--END
	
		
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
	  SELECT A.PurchaseSaleBookHeaderID
			,A.PurchaseSaleBookLineItemID
			,SUM(ISNULL(FinalAmount,0))
			,SUM(ISNULL(CA.GrossAmount,0))
			,SUM(ISNULL(CA.SchemeAmount,0))
			,SUM(ISNULL(CA.DiscountAmount,0))
			,SUM(ISNULL(CA.SpecialDiscountAmount,0))
			,SUM(ISNULL(CA.VolumeDiscountAmount,0))
		--FROM --UDF_GetAmountWithAllDiscountAmounts(@PurchaseSaleBookHeaderID) CA
		FROM TempPurchaseSaleBookLineItem A
		OUTER APPLY UDF_GetAmountWithAllDiscountAmounts(@PurchaseSaleBookHeaderID) CA
		GROUP BY A.PurchaseSaleBookHeaderID ,A.PurchaseSaleBookLineItemID
		--WHERE A.PurchaseSaleBookLineItemID IN (SELECT PurchaseSaleBookLineItemID FROM @LineItems)
	
	
	   SELECT    DISTINCT   
		   I.PurchaseSaleBookHeaderID
		  ,I.PurchaseSaleBookLineItemID 
		  ,I.FifoID,I.ItemCode,B.ItemName ,I.Batch,BatchNew
		  ,I.Quantity,FreeQuantity
		  ,PurchaseSaleRate,EffecivePurchaseSaleRate
		  ,PurchaseSaleTypeCode,SurCharge
		  ,LocalCentral,SGST,IGST,CGST
		  ,Amount,Discount,SpecialDiscount,DiscountQuantity,VolumeDiscount
		  ,I.Scheme1,I.Scheme2,IsHalfScheme,HalfSchemeRate
		  ,CostAmount
		  ,ConversionRate,I.MRP,I.ExpiryDate
		  ,I.SaleRate,I.WholeSaleRate,I.SpecialRate
		  ,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn
		  ,OldPurchaseSaleBookLineItemID  
		  ,F.BalanceQuanity
		  ,UsedQuantity
		  ,PurchaseBillDate
		  ,PurchaseVoucherNumber
		  ,PurchaseSrlNo
		  ,PurchaseSaleTax AS SalePurchaseTax
		  ,AMT.FinalAmount AS BillAmount
			,0 AS CostAmount
			,(AMT.FinalAmount * .01 * I.PurchaseSaleTax) As TaxAmount			
			,AMT.GrossAmount
			,AMT.SchemeAmount
			,AMT.DiscountAmount
			,AMT.SpecialDiscountAmount
			,AMT.VolumeDiscountAmount
			,(AMT.DiscountAmount + AMT.SpecialDiscountAmount + AMT.VolumeDiscountAmount) AS TotalDiscountAmount
	FROM TempPurchaseSaleBookLineItem I
	INNER JOIN FIFO F on I.FifoID = F.FifoID
	INNER JOIN (
		SELECT ItemCode,ItemName  from ItemMaster
	) B ON I.ItemCode = B.ItemCode
	INNER JOIN @TempTableAmountWithAllDiscountAmounts AMT
	ON I.PurchaseSaleBookHeaderID = AMT.PurchaseSaleBookHeaderID
			AND I.PurchaseSaleBookLineItemID = AMT.PurchaseSaleBookLineItemID
	 WHERE I.PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID
	 AND I.ItemCode = @ItemCode
	
	UNION ALL
	 
	 SELECT 
		  Amt4.PurchaseSaleBookHeaderID
		 ,0 AS PurchaseSaleBookLineItemID
		  ,0 AS FifoID,NULL AS ItemCode,NULL AS ItemName ,NULL AS Batch,NULL AS BatchNew
		  ,0 AS Quantity,0 AS FreeQuantity
		  ,0 AS  PurchaseSaleRate,0 AS EffecivePurchaseSaleRate
		  ,'' AS PurchaseSaleTypeCode,0 AS SurCharge
		  ,NULL AS LocalCentral,0 AS SGST,0 AS IGST,0 AS CGST
		  ,0 AS Amount,0 AS Discount,0 AS SpecialDiscount,0 AS DiscountQuantity,0 AS VolumeDiscount
		  ,0 AS Scheme1,0 AS Scheme2,NULL AS IsHalfScheme,0 AS HalfSchemeRate
		  ,0 AS CostAmount
		  ,0 AS ConversionRate,0 AS MRP,NULL AS ExpiryDate
		  ,0 AS SaleRate,0 AS WholeSaleRate,0 AS SpecialRate
		  ,NULL AS CreatedBy,NULL AS CreatedOn,NULL AS ModifiedBy,NULL AS ModifiedOn
		  ,0 AS OldPurchaseSaleBookLineItemID  
		  ,0 AS BalanceQuanity
		  ,0 AS UsedQuantity
		  ,NULL AS PurchaseBillDate
		  ,NULL AS PurchaseVoucherNumber
		  ,0 AS PurchaseSrlNo
		  ,0 AS SalePurchaseTax
		 ,SUM(Amt4.BillAmount) AS BillAmount
		 ,0 AS CostAmount
		 ,SUM(Amt4.TaxAmount) As TaxAmount
		 ,SUM(Amt4.GrossAmount) AS GrossAmount
		 ,SUM(Amt4.SchemeAmount) AS SchemeAmount
		 ,SUM(Amt4.DiscountAmount) AS DiscountAmount
		 ,SUM(Amt4.SpecialDiscountAmount) AS SpecialDiscountAmount
		 ,SUM(Amt4.VolumeDiscountAmount) AS VolumeDiscountAmount
		 ,SUM(Amt4.DiscountAmount + Amt4.SpecialDiscountAmount + Amt4.VolumeDiscountAmount) AS TotalDiscountAmount
		FROM 
		(
			SELECT 
				Amt4.PurchaseSaleBookHeaderID
				,Amt4.PurchaseSaleBookLineItemID
				,Amt4.FinalAmount AS BillAmount		 
				,(Amt4.FinalAmount * .01 * Final.PurchaseSaleTax) As TaxAmount
				,Amt4.GrossAmount
				,Amt4.SchemeAmount
				,Amt4.DiscountAmount
				,Amt4.SpecialDiscountAmount 
				,Amt4.VolumeDiscountAmount
		 FROM @TempTableAmountWithAllDiscountAmounts AS Amt4
		 INNER JOIN dbo.TempPurchaseSaleBookLineItem AS Final
			 ON Amt4.PurchaseSaleBookHeaderID = final.PurchaseSaleBookHeaderID 
		      AND Amt4.PurchaseSaleBookLineItemID = final.PurchaseSaleBookLineItemID
		  WHERE final.PurchaseSaleBookHeaderID  = @PurchaseSaleBookHeaderID
		) Amt4
		GROUP BY Amt4.PurchaseSaleBookHeaderID

	   
    END TRY
    BEGIN CATCH    
		ROLLBACK TRAN 
		DECLARE @ErrorNumber INT = ERROR_NUMBER();
		DECLARE @ErrorMessage NVARCHAR(1000) = ERROR_MESSAGE() 
		RAISERROR('Error Number-%d : Error Message-%s', 16, 1, 
		@ErrorNumber, @ErrorMessage)   
    END CATCH
	
	
END

GO
/****** Object:  StoredProcedure [dbo].[SaleInvoice]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[SavePurchaseEntryData]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SavePurchaseEntryData] 
	@PurchaseSaleBookHeaderID INT
AS
BEGIN
	SET NOCOUNT ON;

BEGIN TRY	
	BEGIN TRAN
	
		DECLARE @TempTableAmountWithAllDiscountAmounts TABLE (
		   PurchaseSaleBookHeaderID BIGINT NOT NULL,
		   PurchaseSaleBookLineItemID BIGINT NOT NULL,
		   FinalAmount FLOAT NOT NULL,
		   GrossAmount FLOAT NOT NULL,
		   SchemeAmount FLOAT NOT NULL,
		   DiscountAmount FLOAT NOT NULL,
		   SpecialDiscountAmount FLOAT NOT NULL,
		   VolumeDiscountAmount FLOAT NOT NULL   
		) ;			
		
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
		  SELECT PurchaseSaleBookHeaderID
				,PurchaseSaleBookLineItemID
				,FinalAmount
				,GrossAmount
				,SchemeAmount
				,DiscountAmount
				,SpecialDiscountAmount
				,VolumeDiscountAmount
		FROM UDF_GetAmountWithAllDiscountAmounts(@PurchaseSaleBookHeaderID)			
	
		DECLARE @VoucherNumber NVARCHAR(8) = '00000000'		
		DECLARE @MaxVoucher INT = 0
		
		SELECT @MaxVoucher = (ISNULL(COUNT(PurchaseSaleBookHeaderID),0) + 1) FROM dbo.PurchaseSaleBookHeader
		WHERE VoucherTypeCode = (SELECT TOP 1 VoucherTypeCode FROM TempPurchaseSaleBookHeader 
		WHERE PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID)
		
		SET @VoucherNumber = RIGHT((@VoucherNumber + CONVERT(VARCHAR,@MaxVoucher)),8)
		
		MERGE INTO dbo.PurchaseSaleBookHeader t1
		USING 
		(	
			SELECT 
				@VoucherNumber AS VoucherNumber,
				 VoucherTypeCode,VoucherDate
				,DueDate,PurchaseBillNo,LedgerType,LedgerTypeCode
				,Amount01,Amount02,Amount03,Amount04,Amount05,Amount06,Amount07
				,SGST01,SGST02,SGST03,SGST04,SGST05,SGST06,SGST07
				,IGST01,IGST02,IGST03,IGST04,IGST05,IGST06,IGST07
				,CGST01,CGST02,CGST03,CGST04,CGST05,CGST06,CGST07
				,TotalTaxAmount,TotalBillAmount
				,(CA.TotalGrossAmount - CA.TotalSchemeAmount - CA.TotalDiscountAmount) AS TotalCostAmount
				,CA.TotalGrossAmount,CA.TotalSchemeAmount,CA.TotalDiscountAmount,OtherAmount				
				,CL.AreaId
				,FreshBreakageExcess
				,ReturnBillNo,ReturBillDate,LocalCentral
				,OrderNumber,ChallanNumber,Message
				,Deliveryddress,DeliveredBy
				,CourierName,CourierDate,CourierWeight
				,PurchaseEntryFormID,LastBalance
				,A.CreatedBy,A.CreatedOn,A.ModifiedBy,A.ModifiedOn 
				,A.OldPurchaseSaleBookHeaderID
			FROM TempPurchaseSaleBookHeader A
			CROSS APPLY
			(
				SELECT 
					 SUM(B.GrossAmount) AS TotalGrossAmount
					,SUM(B.SchemeAmount) AS TotalSchemeAmount
					,SUM(B.DiscountAmount + B.SpecialDiscountAmount + b.VolumeDiscountAmount) AS TotalDiscountAmount
				 FROM @TempTableAmountWithAllDiscountAmounts B
				WHERE B.PurchaseSaleBookHeaderID = A.PurchaseSaleBookHeaderID 
			
			) CA
			LEFT OUTER JOIN 
			SupplierLedger CL ON A.LedgerTypeCode = CL.SupplierLedgerCode
			WHERE A.PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID
		) AS t2 ON t1.PurchaseSaleBookHeaderID = t2.OldPurchaseSaleBookHeaderID
		WHEN MATCHED THEN 
	    UPDATE SET 
			 t1.VoucherDate	=t2.VoucherDate
			,t1.DueDate	=t2.DueDate,t1.PurchaseBillNo=t2.PurchaseBillNo
			,t1.LedgerType	=t2.LedgerType,t1.LedgerTypeCode=t2.LedgerTypeCode
			,t1.Amount01=t2.Amount01,t1.Amount02=t2.Amount02
			,t1.Amount03=t2.Amount03,t1.Amount04=t2.Amount04
			,t1.Amount05=t2.Amount05,t1.Amount06=t2.Amount06,t1.Amount07=t2.Amount07
			,t1.SGST01=t2.SGST01,t1.SGST02=t2.SGST02
			,t1.SGST03=t2.SGST03,t1.SGST04=t2.SGST04
			,t1.SGST05=t2.SGST05,t1.SGST06=t2.SGST06,t1.SGST07=t2.SGST07
			,t1.IGST01=t2.IGST01,t1.IGST02=t2.IGST02
			,t1.IGST03=t2.IGST03,t1.IGST04=t2.IGST04
			,t1.IGST05=t2.IGST05,t1.IGST06=t2.IGST06,t1.IGST07=t2.IGST07
			,t1.CGST01=t2.CGST01,t1.CGST02=t2.CGST02
			,t1.CGST03=t2.CGST03,t1.CGST04=t2.CGST04
			,t1.CGST05=t2.CGST05,t1.CGST06=t2.CGST06,t1.CGST07=t2.CGST07
			,t1.TotalTaxAmount=t2.TotalTaxAmount,t1.TotalBillAmount=t2.TotalBillAmount
			,t1.TotalCostAmount=t2.TotalCostAmount,t1.TotalGrossAmount=t2.TotalGrossAmount
			,t1.TotalSchemeAmount=t2.TotalSchemeAmount,t1.TotalDiscountAmount=t2.TotalDiscountAmount
			,t1.OtherAmount=t2.OtherAmount
			,t1.AreaId=t2.AreaId,t1.PurchaseSaleEntryFormID=t2.PurchaseEntryFormID				
		WHEN NOT MATCHED THEN
		INSERT
           (VoucherNumber,VoucherTypeCode,VoucherDate
           ,DueDate,PurchaseBillNo,LedgerType,LedgerTypeCode
           ,Amount01,Amount02,Amount03,Amount04,Amount05,Amount06,Amount07
           ,SGST01,SGST02,SGST03,SGST04,SGST05,SGST06,SGST07
           ,IGST01,IGST02,IGST03,IGST04,IGST05,IGST06,IGST07
           ,CGST01,CGST02,CGST03,CGST04,CGST05,CGST06,CGST07
           ,TotalTaxAmount,TotalBillAmount,TotalCostAmount
           ,TotalGrossAmount,TotalSchemeAmount,TotalDiscountAmount,OtherAmount          
           ,AreaId,FreshBreakageExcess
           ,ReturnBillNo,ReturBillDate,LocalCentral
           ,OrderNumber,ChallanNumber,Message
           ,Deliveryddress,DeliveredBy
           ,CourierName,CourierDate,CourierWeight
           ,PurchaseSaleEntryFormID,LastBalance
           ,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn
          )
          VALUES
          (
		 	t2.VoucherNumber ,t2.VoucherTypeCode,t2.VoucherDate
           ,t2.DueDate,t2.PurchaseBillNo,t2.LedgerType,t2.LedgerTypeCode
           ,t2.Amount01,t2.Amount02,t2.Amount03,t2.Amount04,t2.Amount05,t2.Amount06,t2.Amount07
           ,t2.SGST01,t2.SGST02,t2.SGST03,t2.SGST04,t2.SGST05,t2.SGST06,t2.SGST07
           ,t2.IGST01,t2.IGST02,t2.IGST03,t2.IGST04,t2.IGST05,t2.IGST06,t2.IGST07
           ,t2.CGST01,t2.CGST02,t2.CGST03,t2.CGST04,t2.CGST05,t2.CGST06,t2.CGST07
           ,t2.TotalTaxAmount,t2.TotalBillAmount,t2.TotalCostAmount
           ,t2.TotalGrossAmount,t2.TotalSchemeAmount,t2.TotalDiscountAmount,t2.OtherAmount
           ,t2.AreaId,t2.FreshBreakageExcess
           ,t2.ReturnBillNo,t2.ReturBillDate,t2.LocalCentral
           ,t2.OrderNumber,t2.ChallanNumber,t2.Message
           ,t2.Deliveryddress,t2.DeliveredBy
           ,t2.CourierName,t2.CourierDate,t2.CourierWeight
           ,t2.PurchaseEntryFormID,t2.LastBalance
           ,t2.CreatedBy,t2.CreatedOn,t2.ModifiedBy,t2.ModifiedOn
          );
		
		PRINT 'INSRT IN Purchase Header Complete'
		
		DECLARE @NewPurchaseSaleHeaderID bigint
		DECLARE @OldPurchaseSaleHeaderID bigint
		
		SELECT @OldPurchaseSaleHeaderID = OldPurchaseSaleBookHeaderID FROM TempPurchaseSaleBookHeader
		WHERE PurchaseSaleBookHeaderID  = @PurchaseSaleBookHeaderID
		
		IF @OldPurchaseSaleHeaderID IS NULL
		BEGIN
			SET @NewPurchaseSaleHeaderID = SCOPE_IDENTITY()
		END
		
		------------------Header Merge Completed----------------------------------------------
		
		DECLARE @UsedFifoIds AS Table ( FifoId bigint )
		DECLARE @DeleteFifoIds AS Table ( FifoId bigint )
		
		DECLARE @DeletePurchaseSaleBookLineItemIds AS Table ( PurchaseSaleBookLineItemId bigint )
		
		INSERT INTO @UsedFifoIds
		SELECT DISTINCT FifoID FROM TempPurchaseSaleBookLineItem 
		WHERE PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID
		AND FifoID IN (SELECT DIStinct FifoID FROM PurchaseSaleBookLineItem)
						--WHERE PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID))
		
		
		INSERT INTO @DeleteFifoIds 
		SELECT DISTINCT FIFOID FROM FIFO WHERE PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID)
		AND FifoID NOT IN (SELECT DIStinct FifoID FROM TempPurchaseSaleBookLineItem WHERE PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID)
						
		INSERT INTO @DeletePurchaseSaleBookLineItemIds 
		SELECT PurchaseSaleBookLineItemId FROM PurchaseSaleBookLineItem L
		INNER JOIN FIFO F  ON L.PurchaseSaleBookHeaderID = F.PurchaseSaleBookHeaderID AND L.PurchaseSrlNo = F.SRLNO
		WHERE F.PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID)
		AND F.FifoID NOT IN (SELECT DIStinct FifoID FROM TempPurchaseSaleBookLineItem WHERE PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID)			
		
		
		DELETE FROM FIFO WHERE FifoID IN (SELECT FifoID FROM @DeleteFifoIds)
		DELETE FROM PurchaseSaleBookLineItem WHERE PurchaseSaleBookLineItemID IN (SELECT PurchaseSaleBookLineItemID FROM @DeletePurchaseSaleBookLineItemIds)
						
		
		--DELETE FROM dbo.FIFO WHERE PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID)
		
		--DELETE FROM dbo.PurchaseSaleBookLineItem WHERE PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID)
		
				
		DECLARE  @MaxRowNumber INT
		
		SELECT @MaxRowNumber = ISNULL(MAX(PurchaseSrlNo),0) FROM PurchaseSaleBookLineItem WHERE 
					PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID)
		
		MERGE INTO dbo.PurchaseSaleBookLineItem t1
		USING 
		(
			  SELECT COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID) AS PurchaseSaleBookHeaderID
					
				  ,FifoID,PurchaseBillDate,PurchaseVoucherNumber
				  ,@MaxRowNumber + ROW_NUMBER() OVER(Partition By A.PurchaseSaleBookHeaderID ORDER BY A.PurchaseSaleBookLineItemID) 
				  as PurchaseSrlNoNew
				  ,A.PurchaseSrlNo
				  ,ItemCode,Batch,Batch AS BatchNew,Quantity,FreeQuantity
				  ,PurchaseSaleRate,EffecivePurchaseSaleRate,PurchaseSaleTypeCode
				  ,SurCharge,PurchaseSaleTax,LocalCentral
				  ,CA.SGST,CA.IGST,CA.CGST,Amount
				  ,Discount,SpecialDiscount,DiscountQuantity,VolumeDiscount
				  ,Scheme1,Scheme2,IsHalfScheme,HalfSchemeRate
				  ,A.CostAmount,CA.GrossAmount,CA.SchemeAmount,CA.DiscountAmount
				   ,(ISNULL(CA.SGST,0) + ISNULL(CA.IGST,0) + ISNULL(CA.CGST,0)) AS TaxAmount  
				   ,CA.SpecialDiscountAmount,CA.VolumeDiscountAmount,CA.TotalDiscountAmount
				  ,ConversionRate,MRP,ExpiryDate,SaleRate,WholeSaleRate,SpecialRate
				  ,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn
				  ,OldPurchaseSaleBookLineItemID
				--  ,ISNULL(UsedQuantity,0) AS UsedQuantity
			  FROM dbo.TempPurchaseSaleBookLineItem A
			  CROSS APPLY 
			  (
					SELECT 
							 B.GrossAmount
							,B.SchemeAmount
							,B.DiscountAmount
							,B.SpecialDiscountAmount
							,B.VolumeDiscountAmount
							,(B.DiscountAmount + b.SpecialDiscountAmount + b.VolumeDiscountAmount) AS TotalDiscountAmount
							,CASE WHEN A.LocalCentral = 'L' THEN (B.FinalAmount * A.PurchaseSaleTax * 0.01 * 0.5) ELSE NULL END AS SGST
							,CASE WHEN A.LocalCentral = 'L' THEN (B.FinalAmount * A.PurchaseSaleTax * 0.01 * 0.5) ELSE NULL END AS CGST
							,CASE WHEN A.LocalCentral = 'C' THEN (B.FinalAmount * A.PurchaseSaleTax * .01) ELSE NULL END AS IGST				
					 FROM @TempTableAmountWithAllDiscountAmounts B
					WHERE B.PurchaseSaleBookHeaderID = A.PurchaseSaleBookHeaderID
					AND B.PurchaseSaleBookLineItemID = A.PurchaseSaleBookLineItemID
			  ) CA
			  WHERE A.PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID
		) t2 
		
		ON t1.PurchaseSaleBookHeaderID = t2.PurchaseSaleBookHeaderID 
				AND t1.PurchaseSaleBookLineItemID = t2.OldPurchaseSaleBookLineItemID
				--AND t1.FifoID = t2.FifoId
		WHEN MATCHED THEN
			UPDATE SET 
				-- t1.FifoID= t2.FifoID
				--,
				--t1.PurchaseBillDate = t2.PurchaseBillDate
				--,
				t1.Batch=t2.Batch
				,t1.BatchNew=t2.BatchNew
				,t1.Quantity= t2.Quantity
				--,t1.PurchaseSrlNo = COALESCE(t2.PurchaseSrlNo,t2.PurchaseSrlNoNew)
				,t1.FreeQuantity=t2.FreeQuantity
				,t1.PurchaseSaleRate=t2.PurchaseSaleRate
				,t1.EffecivePurchaseSaleRate=t2.EffecivePurchaseSaleRate
				,t1.PurchaseSaleTypeCode=t2.PurchaseSaleTypeCode
				,t1.SurCharge=t2.SurCharge
				,t1.SalePurchaseTax=t2.PurchaseSaleTax
				,t1.LocalCentral=t2.LocalCentral
				,t1.SGST=t2.SGST
				,t1.IGST=t2.IGST
				,t1.CGST=t2.CGST
				,t1.Amount=t2.Amount
				,t1.Discount=t2.Discount
				,t1.SpecialDiscount=t2.SpecialDiscount
				,t1.DiscountQuantity=t2.DiscountQuantity
				,t1.VolumeDiscount=t2.VolumeDiscount
				,t1.Scheme1=t2.Scheme1
				,t1.Scheme2=t2.Scheme2
				,t1.IsHalfScheme=t2.IsHalfScheme
				,t1.HalfSchemeRate=t2.HalfSchemeRate
				,t1.CostAmount=t2.CostAmount
				,t1.GrossAmount=t2.GrossAmount
				,t1.SchemeAmount=t2.SchemeAmount
				,t1.DiscountAmount=t2.DiscountAmount
				,t1.TaxAmount=t2.TaxAmount
				,t1.SpecialDiscountAmount=t2.SpecialDiscountAmount
				,t1.VolumeDiscountAmount=t2.VolumeDiscountAmount
				,t1.TotalDiscountAmount	=t2.TotalDiscountAmount
				,t1.ConversionRate	=t2.ConversionRate
				,t1.MRP=t2.MRP
				,t1.ExpiryDate=t2.ExpiryDate
				,t1.SaleRate=t2.SaleRate
				,t1.WholeSaleRate=t2.WholeSaleRate
				,t1.SpecialRate=t2.SpecialRate
		WHEN NOT MATCHED THEN
			INSERT 
			(
				PurchaseSaleBookHeaderID
			   ,PurchaseVoucherNumber,PurchaseSrlNo
			   ,ItemCode,Batch,BatchNew,Quantity,FreeQuantity
			   ,PurchaseSaleRate,EffecivePurchaseSaleRate,PurchaseSaleTypeCode
			   ,SurCharge,SalePurchaseTax,LocalCentral
			   ,SGST,IGST,CGST,Amount
			   ,Discount,SpecialDiscount,DiscountQuantity,VolumeDiscount
			   ,Scheme1,Scheme2,IsHalfScheme,HalfSchemeRate
			   ,CostAmount,GrossAmount,SchemeAmount,DiscountAmount
			   ,TaxAmount,SpecialDiscountAmount,VolumeDiscountAmount,TotalDiscountAmount
			   ,ConversionRate,MRP,ExpiryDate,SaleRate,WholeSaleRate,SpecialRate
			   ,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn --40
			)
			VALUES
			(
				PurchaseSaleBookHeaderID
			   ,PurchaseVoucherNumber, COALESCE(PurchaseSrlNo,PurchaseSrlNoNew)
			   ,ItemCode,Batch,BatchNew,Quantity,FreeQuantity
			   ,PurchaseSaleRate,EffecivePurchaseSaleRate,PurchaseSaleTypeCode
			   ,SurCharge,PurchaseSaleTax,LocalCentral
			   ,SGST,IGST,CGST,Amount
			   ,Discount,SpecialDiscount,DiscountQuantity,VolumeDiscount
			   ,Scheme1,Scheme2,IsHalfScheme,HalfSchemeRate
			   ,CostAmount,GrossAmount,SchemeAmount,DiscountAmount
			   ,TaxAmount,SpecialDiscountAmount,VolumeDiscountAmount,TotalDiscountAmount
			   ,ConversionRate,MRP,ExpiryDate,SaleRate,WholeSaleRate,SpecialRate
			   ,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn
			)
		;
		
		PRINT 'INSRT IN Purchase LINE ITEM Complete'
	
		--DELETE FROM dbo.FIFO WHERE PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID)
		
		MERGE INTO dbo.FIFO t1
		USING 
		(
			SELECT 
				I.PurchaseSaleBookHeaderID,H.VoucherNumber ,H.VoucherDate         
			  -- ,ROW_NUMBER() OVER(Partition By I.PurchaseSaleBookHeaderID ORDER BY I.PurchaseSaleBookLineItemID) as SRLNO
			   ,I.PurchaseSrlNo AS SRLNO
			   ,I.ItemCode,H.PurchaseBillNo
			   ,I.Batch,I.ExpiryDate
			   ,(I.Quantity + ISNULL(I.FreeQuantity,0)) AS Quantity
			   ,(I.Quantity + ISNULL(I.FreeQuantity,0) - ISNULL(T.UsedQuantity,0)) AS BalanceQuanity
			   ,I.PurchaseSaleRate,I.EffecivePurchaseSaleRate
			   ,I.SaleRate,I.WholeSaleRate,I.SpecialRate,I.MRP
			   ,I.Scheme1,I.Scheme2, 0 as IsOnHold 
			   ,ISNULL(T.FifoID ,0) AS FifoID
		   From PurchaseSaleBookLineItem I
		   Inner JOIN PurchaseSaleBookHeader H ON I.PurchaseSaleBookHeaderID = H.PurchaseSaleBookHeaderID
		   LEFT OUTER JOIN TempPurchaseSaleBookLineItem T ON I.PurchaseSaleBookLineItemID = T.OldPurchaseSaleBookLineItemID
		   WHERE I.PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID)
		) t2 ON t1.PurchaseSaleBookHeaderID = t2.PurchaseSaleBookHeaderID 
				AND t1.FifoID = t2.FifoID
		WHEN MATCHED THEN
		UPDATE SET 
				t1.PurchaseBillNo = t2.PurchaseBillNo,
				t1.Batch = t2.Batch,
				t1.ExpiryDate = t2.ExpiryDate,
				t1.Quantity = t2.Quantity,
				t1.BalanceQuanity = t2.BalanceQuanity,
				t1.PurchaseRate= t2.PurchaseSaleRate,
				t1.EffectivePurchaseRate = t2.EffecivePurchaseSaleRate,
				t1.SaleRate = t2.SaleRate,
				t1.WholeSaleRate = t2.WholeSaleRate,
				t1.SpecialRate= t2.SpecialRate,
				t1.MRP = t2.MRP,
				t1.Scheme1 = t2.Scheme1,
				t1.Scheme2 =  t2.Scheme2,
				t1.IsOnHold = t2.IsOnHold
		--WHEN NOT MATCHED BY SOURCE THEN DELETE
		WHEN NOT MATCHED THEN
			INSERT
			(
				PurchaseSaleBookHeaderID,VoucherNumber,VoucherDate
			   ,SRLNO,ItemCode,PurchaseBillNo
			   ,Batch,ExpiryDate,Quantity
			   ,BalanceQuanity--,PurchaseTypeId
			   ,PurchaseRate,EffectivePurchaseRate
			   ,SaleRate,WholeSaleRate,SpecialRate,MRP
			   ,Scheme1,Scheme2,IsOnHold
				-- ,OnHoldRemarks,MfgDate,UPC
			)
			VALUES
			(
				PurchaseSaleBookHeaderID,VoucherNumber,VoucherDate
			   ,SRLNO,ItemCode,PurchaseBillNo
			   ,Batch,ExpiryDate,Quantity  
			   ,BalanceQuanity--,PurchaseTypeId
			   ,PurchaseSaleRate,EffecivePurchaseSaleRate
			   ,SaleRate,WholeSaleRate,SpecialRate,MRP
			   ,Scheme1,Scheme2,IsOnHold
			);
		  
       
       PRINT 'INSRT IN Purchase FIFO Complete'
       
       
       MERGE INTO dbo.BillOutStandings t1
       USING
       (
			SELECT
			   PurchaseSaleBookHeaderID,VoucherNumber,VoucherTypeCode,VoucherDate
			   ,LedgerType,LedgerTypeCode
			   ,TotalBillAmount as BillAmount,TotalBillAmount AS OSAmount
		   FROM PurchaseSaleBookHeader
		   WHERE PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID)			
       ) t2 ON t1.PurchaseSaleBookHeaderID = t2.PurchaseSaleBookHeaderID
       WHEN MATCHED THEN
			UPDATE SET t1.VoucherDate = t2.VoucherDate,
				t1.BillAmount = t2.BillAmount
		WHEN NOT MATCHED THEN
			INSERT (
				 PurchaseSaleBookHeaderID,VoucherNumber
				,VoucherTypeCode,VoucherDate
				,LedgerType,LedgerTypeCode
				,BillAmount,OSAmount
			)
			VALUES (			
				PurchaseSaleBookHeaderID,VoucherNumber
				,VoucherTypeCode,VoucherDate
				,LedgerType,LedgerTypeCode
				,BillAmount,OSAmount
			);
       
		PRINT 'INSRT IN Purchase BILLOS Complete'
		
		----------------------INSERT IN TRAN STRAT --------------------------------------------------------
		
		
		DELETE FROM dbo.TRN WHERE PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID)			
		
		DECLARE @Narration nvarchar(200) 
		
		SELECT @Narration = ('Purchase Invoice is - ' + CONVERT(varchar,PurchaseBillNo))
		FROM PurchaseSaleBookHeader WHERE PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID)
		
		
		INSERT INTO dbo.TRN
           (    PurchaseSaleBookHeaderID
			   ,VoucherNumber
			   ,VoucherTypeCode
			   ,VoucherDate
			   ,LedgerType
			   ,LedgerTypeCode
			   ,NARRATION
			   ,Amount
			   ,DebitCredit
           )
          SELECT PurchaseSaleBookHeaderID
			   ,VoucherNumber
			   ,VoucherTypeCode
			   ,VoucherDate
			   ,LedgerType
			   ,LedgerTypeCode
			   ,@Narration AS NARRATION
			   ,TotalBillAmount AS Amount
			   ,'C' AS DebitCredit
		  FROM PurchaseSaleBookHeader
		  WHERE PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID)

		INSERT INTO dbo.TRN
		(   PurchaseSaleBookHeaderID
		   ,VoucherNumber
		   ,VoucherTypeCode
		   ,VoucherDate
		   ,LedgerType
		   ,LedgerTypeCode
		   ,NARRATION
		   ,Amount
		   ,DebitCredit
		)		  
		SELECT 
			PurchaseSaleBookHeaderID
			,VoucherNumber
			,VoucherTypeCode
			,VoucherDate
			,'PURCHASELEDGER' AS LedgerType
			,REPLACE(AmountName,'Amount','PUR00000') As LedgerTypeCode
			,@Narration As NARRATION
			,Amount
			,'D' DebitCredit
		FROM dbo.PurchaseSaleBookHeader
		UNPIVOT
		(
			Amount
			FOR AmountName in (Amount01, Amount02, Amount03,Amount04,Amount05,Amount06,Amount07)
		) unpiv
		WHERE PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID) 
		AND Amount > 0;


		INSERT INTO dbo.TRN
		(   PurchaseSaleBookHeaderID
		   ,VoucherNumber
		   ,VoucherTypeCode
		   ,VoucherDate
		   ,LedgerType
		   ,LedgerTypeCode
		   ,NARRATION
		   ,Amount
		   ,DebitCredit
		)		  
		SELECT 
			PurchaseSaleBookHeaderID
			,VoucherNumber
			,VoucherTypeCode
			,VoucherDate
			,'GENERALLEDGER' AS LedgerType
			,REPLACE(AmountName,'IGST','IGST0000') As LedgerTypeCode
			,@Narration As NARRATION
			,Amount
			,'D' DebitCredit
		FROM dbo.PurchaseSaleBookHeader
		UNPIVOT
		(
			Amount
			FOR AmountName in (IGST01, IGST02, IGST03,IGST04,IGST05,IGST06,IGST07)
		) unpiv
		WHERE PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID) AND 
		--LocalCentral = 'L' AND 
		Amount > 0;
		
		
		INSERT INTO dbo.TRN
		(   PurchaseSaleBookHeaderID
		   ,VoucherNumber
		   ,VoucherTypeCode
		   ,VoucherDate
		   ,LedgerType
		   ,LedgerTypeCode
		   ,NARRATION
		   ,Amount
		   ,DebitCredit
		)		  
		SELECT 
			PurchaseSaleBookHeaderID
			,VoucherNumber
			,VoucherTypeCode
			,VoucherDate
			,'GENERALLEDGER' AS LedgerType
			,REPLACE(AmountName,'SGST','SGST0000') As LedgerTypeCode
			,@Narration As NARRATION
			,Amount
			,'D' DebitCredit
		FROM dbo.PurchaseSaleBookHeader
		UNPIVOT
		(
			Amount
			FOR AmountName in (SGST01, SGST02, SGST03,SGST04,SGST05,SGST06,SGST07)
		) unpiv
		WHERE PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID) AND 
		--LocalCentral = 'L' AND 
		Amount > 0;
		
		
		
		INSERT INTO dbo.TRN
		(   PurchaseSaleBookHeaderID
		   ,VoucherNumber
		   ,VoucherTypeCode
		   ,VoucherDate
		   ,LedgerType
		   ,LedgerTypeCode
		   ,NARRATION
		   ,Amount
		   ,DebitCredit
		)		  
		SELECT 
			PurchaseSaleBookHeaderID
			,VoucherNumber
			,VoucherTypeCode
			,VoucherDate
			,'GENERALLEDGER' AS LedgerType
			,REPLACE(AmountName,'CGST','CGST0000') As LedgerTypeCode
			,@Narration As NARRATION
			,Amount
			,'D' DebitCredit
		FROM dbo.PurchaseSaleBookHeader
		UNPIVOT
		(
			Amount
			FOR AmountName in (CGST01, CGST02, CGST03,CGST04,CGST05,CGST06,CGST07)
		) unpiv
		WHERE PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID) AND 
			--LocalCentral = 'C' AND 
			Amount > 0;
		
		
		INSERT INTO dbo.TRN
		(   PurchaseSaleBookHeaderID
		   ,VoucherNumber
		   ,VoucherTypeCode
		   ,VoucherDate
		   ,LedgerType
		   ,LedgerTypeCode
		   ,NARRATION
		   ,Amount
		   ,DebitCredit
		)		 
		SELECT DISTINCT
			A.PurchaseSaleBookHeaderID
		   ,VoucherNumber
		   ,VoucherTypeCode
		   ,VoucherDate
		   ,'INCOMELEDGER' LedgerType
		   ,'ADJ0000001' LedgerTypeCode
		   ,@Narration AS NARRATION
		   ,ABS(B.DebitAmount - C.CreditAmount) AS Amount
		   ,CASE WHEN (DebitAmount - CreditAmount) > 0 THEN 'C' ELSE 'D' END AS DebitCredit 
		FROM TRN A
		INNER JOIN (
			SELECT 
				PurchaseSaleBookHeaderID
			   ,SUM(Amount) DebitAmount
			FROM TRN 
			WHERE PurchaseSaleBookHeaderID=COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID) AND DebitCredit = 'D'
			Group BY PurchaseSaleBookHeaderID
		) B On A.PurchaseSaleBookHeaderID = B.PurchaseSaleBookHeaderID
		INNER JOIN 
		(
			SELECT 
				PurchaseSaleBookHeaderID
			   ,SUM(Amount) CreditAmount
			FROM TRN 
			WHERE PurchaseSaleBookHeaderID=COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID) AND DebitCredit = 'C'
			Group BY PurchaseSaleBookHeaderID
		) C ON A.PurchaseSaleBookHeaderID = C.PurchaseSaleBookHeaderID
		WHERE A.PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID)
		AND ABS(B.DebitAmount - C.CreditAmount) > 0
		
		   
		
		
		----------------------------------------------------------------------------------------------------
		
		DELETE FROM TempPurchaseSaleBookLineItem WHERE PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID
		DELETE FROM TempPurchaseSaleBookHeader WHERE PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID
		
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


/****** Object:  StoredProcedure [dbo].[GetPurchaseSaleBookLineItemsForModify]    Script Date: 06/17/2017 14:32:12 ******/
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[SaveReceiptPaymentData]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[SaveSaleEntryData]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SaveSaleEntryData] 
	@PurchaseSaleBookHeaderID INT
AS
BEGIN
	SET NOCOUNT ON;

BEGIN TRY	
	BEGIN TRAN
	
	
		DECLARE @TempTableAmountWithAllDiscountAmounts TABLE (
		   PurchaseSaleBookHeaderID BIGINT NOT NULL,
		   PurchaseSaleBookLineItemID BIGINT NOT NULL,
		   FinalAmount FLOAT NOT NULL,
		   GrossAmount FLOAT NOT NULL,
		   SchemeAmount FLOAT NOT NULL,
		   DiscountAmount FLOAT NOT NULL,
		   SpecialDiscountAmount FLOAT NOT NULL,
		   VolumeDiscountAmount FLOAT NOT NULL   
		) ;			
		
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
		  SELECT PurchaseSaleBookHeaderID
				,PurchaseSaleBookLineItemID
				,FinalAmount
				,GrossAmount
				,SchemeAmount
				,DiscountAmount
				,SpecialDiscountAmount
				,VolumeDiscountAmount
		FROM UDF_GetAmountWithAllDiscountAmounts(@PurchaseSaleBookHeaderID)			
	
		DECLARE @VoucherNumber NVARCHAR(8) = '00000000'		
		DECLARE @MaxVoucher INT = 0
		
		SELECT @MaxVoucher = (ISNULL(COUNT(PurchaseSaleBookHeaderID),0) + 1) FROM dbo.PurchaseSaleBookHeader
		WHERE VoucherTypeCode = (SELECT TOP 1 VoucherTypeCode FROM TempPurchaseSaleBookHeader 
		WHERE PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID)
		
		SET @VoucherNumber = RIGHT((@VoucherNumber + CONVERT(VARCHAR,@MaxVoucher)),8)
		
		MERGE INTO dbo.PurchaseSaleBookHeader t1
		USING 
		(	
			SELECT 
				@VoucherNumber AS VoucherNumber,
				 VoucherTypeCode,VoucherDate
				,DueDate,PurchaseBillNo,LedgerType,LedgerTypeCode
				,AMT.Amount01,AMT.Amount02,AMT.Amount03,AMT.Amount04,AMT.Amount05,AMT.Amount06,AMT.Amount07
				,AMT.SGST01,AMT.SGST02,AMT.SGST03,AMT.SGST04,AMT.SGST05,AMT.SGST06,AMT.SGST07
				,AMT.IGST01,AMT.IGST02,AMT.IGST03,AMT.IGST04,AMT.IGST05,AMT.IGST06,AMT.IGST07
				,AMT.CGST01,AMT.CGST02,AMT.CGST03,AMT.CGST04,AMT.CGST05,AMT.CGST06,AMT.CGST07
				,ISNULL((AMT.SGST01+AMT.SGST02+AMT.SGST03+AMT.SGST04+AMT.SGST05+AMT.SGST06+AMT.SGST07
				+AMT.IGST01+AMT.IGST02+AMT.IGST03+AMT.IGST04+AMT.IGST05+AMT.IGST06+AMT.IGST07
				+AMT.CGST01+AMT.CGST02+AMT.CGST03+AMT.CGST04+AMT.CGST05+AMT.CGST06+AMT.CGST07),0) AS TotalTaxAmount
				,ROUND((AMT.Amount01+AMT.Amount02+AMT.Amount03+AMT.Amount04+AMT.Amount05+AMT.Amount06+AMT.Amount07
				+AMT.SGST01+AMT.SGST02+AMT.SGST03+AMT.SGST04+AMT.SGST05+AMT.SGST06+AMT.SGST07
				+AMT.IGST01+AMT.IGST02+AMT.IGST03+AMT.IGST04+AMT.IGST05+AMT.IGST06+AMT.IGST07
				+AMT.CGST01+AMT.CGST02+AMT.CGST03+AMT.CGST04+AMT.CGST05+AMT.CGST06+AMT.CGST07),0) AS TotalBillAmount
				
				,TotalCostAmount
				,CA.TotalGrossAmount,CA.TotalSchemeAmount,CA.TotalDiscountAmount,OtherAmount				
				,CL.ZSMId,CL.ASMId,CL.RSMId
			    ,CL.AreaId,CL.SalesManId,CL.RouteId
				,FreshBreakageExcess
				,ReturnBillNo,ReturBillDate,LocalCentral
				,OrderNumber,ChallanNumber,Message
				,Deliveryddress,DeliveredBy
				,CourierName,CourierDate,CourierWeight
				,PurchaseEntryFormID,LastBalance
				,A.CreatedBy,A.CreatedOn,A.ModifiedBy,A.ModifiedOn 
				,A.OldPurchaseSaleBookHeaderID
			FROM TempPurchaseSaleBookHeader A
			CROSS APPLY udf_GetFinalAmountWithTaxForSale(A.PurchaseSaleBookHeaderID) AS AMT
			CROSS APPLY
			(
				SELECT 
					 SUM(B.GrossAmount) AS TotalGrossAmount
					,SUM(B.SchemeAmount) AS TotalSchemeAmount
					,SUM(B.DiscountAmount + B.SpecialDiscountAmount + b.VolumeDiscountAmount) AS TotalDiscountAmount
					,SUM(B.FinalAmount) AS TotalBillAmount
				 FROM @TempTableAmountWithAllDiscountAmounts B
				WHERE B.PurchaseSaleBookHeaderID = A.PurchaseSaleBookHeaderID 
			
			) CA
			LEFT OUTER JOIN 
			CustomerLedger CL ON A.LedgerTypeCode = CL.CustomerLedgerCode
			WHERE A.PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID
		) AS t2 ON t1.PurchaseSaleBookHeaderID = t2.OldPurchaseSaleBookHeaderID
		WHEN MATCHED THEN 
	    UPDATE SET 
			 t1.VoucherDate	=t2.VoucherDate
			,t1.DueDate	=t2.DueDate,t1.PurchaseBillNo=t2.PurchaseBillNo
			,t1.LedgerType	=t2.LedgerType,t1.LedgerTypeCode=t2.LedgerTypeCode
			,t1.Amount01=t2.Amount01,t1.Amount02=t2.Amount02
			,t1.Amount03=t2.Amount03,t1.Amount04=t2.Amount04
			,t1.Amount05=t2.Amount05,t1.Amount06=t2.Amount06,t1.Amount07=t2.Amount07
			,t1.SGST01=t2.SGST01,t1.SGST02=t2.SGST02
			,t1.SGST03=t2.SGST03,t1.SGST04=t2.SGST04
			,t1.SGST05=t2.SGST05,t1.SGST06=t2.SGST06,t1.SGST07=t2.SGST07
			,t1.IGST01=t2.IGST01,t1.IGST02=t2.IGST02
			,t1.IGST03=t2.IGST03,t1.IGST04=t2.IGST04
			,t1.IGST05=t2.IGST05,t1.IGST06=t2.IGST06,t1.IGST07=t2.IGST07
			,t1.CGST01=t2.CGST01,t1.CGST02=t2.CGST02
			,t1.CGST03=t2.CGST03,t1.CGST04=t2.CGST04
			,t1.CGST05=t2.CGST05,t1.CGST06=t2.CGST06,t1.CGST07=t2.CGST07
			,t1.TotalTaxAmount=t2.TotalTaxAmount,t1.TotalBillAmount=t2.TotalBillAmount
			,t1.TotalCostAmount=t2.TotalCostAmount,t1.TotalGrossAmount=t2.TotalGrossAmount
			,t1.TotalSchemeAmount=t2.TotalSchemeAmount,t1.TotalDiscountAmount=t2.TotalDiscountAmount
			,t1.OtherAmount=t2.OtherAmount
			,t1.ZSMId = t2.ZSMId
			,t1.ASMId= t2.ASMId
			,t1.RSMId= t2.RSMId
			,t1.AreaId= t2.AreaId
			,t1.SalesManId= t2.SalesManId
			,t1.RouteId= t2.RouteId
			,t1.PurchaseSaleEntryFormID=t2.PurchaseEntryFormID				
		WHEN NOT MATCHED THEN
		INSERT
           (VoucherNumber,VoucherTypeCode,VoucherDate
           ,DueDate,PurchaseBillNo,LedgerType,LedgerTypeCode
           ,Amount01,Amount02,Amount03,Amount04,Amount05,Amount06,Amount07
           ,SGST01,SGST02,SGST03,SGST04,SGST05,SGST06,SGST07
           ,IGST01,IGST02,IGST03,IGST04,IGST05,IGST06,IGST07
           ,CGST01,CGST02,CGST03,CGST04,CGST05,CGST06,CGST07
           ,TotalTaxAmount,TotalBillAmount,TotalCostAmount
           ,TotalGrossAmount,TotalSchemeAmount,TotalDiscountAmount,OtherAmount          
           ,ZSMId,ASMId,RSMId
		   ,AreaId,SalesManId,RouteId
           ,FreshBreakageExcess
           ,ReturnBillNo,ReturBillDate,LocalCentral
           ,OrderNumber,ChallanNumber,Message
           ,Deliveryddress,DeliveredBy
           ,CourierName,CourierDate,CourierWeight
           ,PurchaseSaleEntryFormID,LastBalance
           ,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn
          )
          VALUES
          (
		 	t2.VoucherNumber ,t2.VoucherTypeCode,t2.VoucherDate
           ,t2.DueDate,t2.PurchaseBillNo,t2.LedgerType,t2.LedgerTypeCode
           ,t2.Amount01,t2.Amount02,t2.Amount03,t2.Amount04,t2.Amount05,t2.Amount06,t2.Amount07
           ,t2.SGST01,t2.SGST02,t2.SGST03,t2.SGST04,t2.SGST05,t2.SGST06,t2.SGST07
           ,t2.IGST01,t2.IGST02,t2.IGST03,t2.IGST04,t2.IGST05,t2.IGST06,t2.IGST07
           ,t2.CGST01,t2.CGST02,t2.CGST03,t2.CGST04,t2.CGST05,t2.CGST06,t2.CGST07
           ,t2.TotalTaxAmount,t2.TotalBillAmount,t2.TotalCostAmount
           ,t2.TotalGrossAmount,t2.TotalSchemeAmount,t2.TotalDiscountAmount,t2.OtherAmount
           ,t2.ZSMId,t2.ASMId,t2.RSMId
		   ,t2.AreaId,t2.SalesManId,t2.RouteId
           ,t2.FreshBreakageExcess
           ,t2.ReturnBillNo,t2.ReturBillDate,t2.LocalCentral
           ,t2.OrderNumber,t2.ChallanNumber,t2.Message
           ,t2.Deliveryddress,t2.DeliveredBy
           ,t2.CourierName,t2.CourierDate,t2.CourierWeight
           ,t2.PurchaseEntryFormID,t2.LastBalance
           ,t2.CreatedBy,t2.CreatedOn,t2.ModifiedBy,t2.ModifiedOn
          );
		
		PRINT 'INSRT IN Purchase Header Complete'
		
		DECLARE @NewPurchaseSaleHeaderID bigint
		DECLARE @OldPurchaseSaleHeaderID bigint
		
		SELECT @OldPurchaseSaleHeaderID = OldPurchaseSaleBookHeaderID FROM TempPurchaseSaleBookHeader
		WHERE PurchaseSaleBookHeaderID  = @PurchaseSaleBookHeaderID
		
		IF @OldPurchaseSaleHeaderID IS NULL
		BEGIN
			SET @NewPurchaseSaleHeaderID = SCOPE_IDENTITY()
		END
		
		------------------Header Merge Completed----------------------------------------------
		
		--DELETE FROM dbo.FIFO WHERE PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID)
		
		DELETE FROM dbo.PurchaseSaleBookLineItem WHERE PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID)
		
		MERGE INTO dbo.PurchaseSaleBookLineItem t1
		USING 
		(
			  --SELECT COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID) AS PurchaseSaleBookHeaderID
				 -- ,FifoID,PurchaseBillDate,PurchaseVoucherNumber,PurchaseSrlNo
				 -- ,ItemCode,Batch,BatchNew,Quantity,FreeQuantity
				 -- ,PurchaseSaleRate,EffecivePurchaseSaleRate,PurchaseSaleTypeCode
				 -- ,SurCharge,PurchaseSaleTax,LocalCentral
				 -- ,SGST,IGST,CGST,Amount
				 -- ,Discount,SpecialDiscount,DiscountQuantity,VolumeDiscount
				 -- ,Scheme1,Scheme2,IsHalfScheme,HalfSchemeRate
				 -- ,A.CostAmount,CA.GrossAmount,CA.SchemeAmount,CA.DiscountAmount
				 --  ,(ISNULL(SGST,0) + ISNULL(IGST,0) + ISNULL(CGST,0)) AS TaxAmount  
				 --  ,CA.SpecialDiscountAmount,CA.VolumeDiscountAmount,CA.TotalDiscountAmount
				 -- ,ConversionRate,MRP,ExpiryDate,SaleRate,WholeSaleRate,SpecialRate
				 -- ,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn
				 -- ,OldPurchaseSaleBookLineItemID
			  --FROM dbo.TempPurchaseSaleBookLineItem A
			  --CROSS APPLY 
			  --(
					--SELECT 
					--		 B.GrossAmount
					--		,B.SchemeAmount
					--		,B.DiscountAmount
					--		,B.SpecialDiscountAmount
					--		,B.VolumeDiscountAmount
					--		,(B.DiscountAmount + b.SpecialDiscountAmount + b.VolumeDiscountAmount) AS TotalDiscountAmount				
					-- FROM @TempTableAmountWithAllDiscountAmounts B
					--WHERE B.PurchaseSaleBookHeaderID = A.PurchaseSaleBookHeaderID
					--AND B.PurchaseSaleBookLineItemID = A.PurchaseSaleBookLineItemID
			  --) CA
			  --WHERE A.PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID
			  
			  
			    SELECT COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID) AS PurchaseSaleBookHeaderID
				  ,FifoID,PurchaseBillDate,PurchaseVoucherNumber
				  ,PurchaseSrlNo
				  ,ItemCode,Batch,BatchNew,Quantity,FreeQuantity
				  ,PurchaseSaleRate,EffecivePurchaseSaleRate,PurchaseSaleTypeCode
				  ,SurCharge,PurchaseSaleTax,LocalCentral
				  ,CA.SGST,CA.IGST,CA.CGST,Amount
				  ,Discount,SpecialDiscount,DiscountQuantity,VolumeDiscount
				  ,Scheme1,Scheme2,IsHalfScheme,HalfSchemeRate
				  ,A.CostAmount,CA.GrossAmount,CA.SchemeAmount,CA.DiscountAmount
				   ,(ISNULL(CA.SGST,0) + ISNULL(CA.IGST,0) + ISNULL(CA.CGST,0)) AS TaxAmount  
				   ,CA.SpecialDiscountAmount,CA.VolumeDiscountAmount,CA.TotalDiscountAmount
				  ,ConversionRate,MRP,ExpiryDate,SaleRate,WholeSaleRate,SpecialRate
				  ,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn
				  ,OldPurchaseSaleBookLineItemID
			  FROM dbo.TempPurchaseSaleBookLineItem A
			  CROSS APPLY 
			  (
					SELECT 
							 B.GrossAmount
							,B.SchemeAmount
							,B.DiscountAmount
							,B.SpecialDiscountAmount
							,B.VolumeDiscountAmount
							,(B.DiscountAmount + b.SpecialDiscountAmount + b.VolumeDiscountAmount) AS TotalDiscountAmount
							,CASE WHEN A.LocalCentral = 'L' THEN (B.FinalAmount * A.PurchaseSaleTax * 0.01 * 0.5) ELSE NULL END AS SGST
							,CASE WHEN A.LocalCentral = 'L' THEN (B.FinalAmount * A.PurchaseSaleTax * 0.01 * 0.5) ELSE NULL END AS CGST
							,CASE WHEN A.LocalCentral = 'C' THEN (B.FinalAmount * A.PurchaseSaleTax * .01) ELSE NULL END AS IGST				
					 FROM @TempTableAmountWithAllDiscountAmounts B
					WHERE B.PurchaseSaleBookHeaderID = A.PurchaseSaleBookHeaderID
					AND B.PurchaseSaleBookLineItemID = A.PurchaseSaleBookLineItemID
			  ) CA
			  WHERE A.PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID
			  
		) t2 ON t1.PurchaseSaleBookHeaderID = t2.PurchaseSaleBookHeaderID 
		AND t1.PurchaseSaleBookLineItemID = t2.OldPurchaseSaleBookLineItemID
		WHEN NOT MATCHED THEN
			INSERT 
			(
				PurchaseSaleBookHeaderID
			   ,FifoID,PurchaseBillDate,PurchaseVoucherNumber,PurchaseSrlNo
			   ,ItemCode,Batch,BatchNew,Quantity,FreeQuantity
			   ,PurchaseSaleRate,EffecivePurchaseSaleRate,PurchaseSaleTypeCode
			   ,SurCharge,SalePurchaseTax,LocalCentral
			   ,SGST,IGST,CGST,Amount
			   ,Discount,SpecialDiscount,DiscountQuantity,VolumeDiscount
			   ,Scheme1,Scheme2,IsHalfScheme,HalfSchemeRate
			   ,CostAmount,GrossAmount,SchemeAmount,DiscountAmount
			   ,TaxAmount,SpecialDiscountAmount,VolumeDiscountAmount,TotalDiscountAmount
			   ,ConversionRate,MRP,ExpiryDate,SaleRate,WholeSaleRate,SpecialRate
			   ,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn
			)
			VALUES
			(
				PurchaseSaleBookHeaderID
			   ,FifoID,PurchaseBillDate,PurchaseVoucherNumber,PurchaseSrlNo
			   ,ItemCode,Batch,BatchNew,Quantity,FreeQuantity
			   ,PurchaseSaleRate,EffecivePurchaseSaleRate,PurchaseSaleTypeCode
			   ,SurCharge,PurchaseSaleTax,LocalCentral
			   ,SGST,IGST,CGST,Amount
			   ,Discount,SpecialDiscount,DiscountQuantity,VolumeDiscount
			   ,Scheme1,Scheme2,IsHalfScheme,HalfSchemeRate
			   ,CostAmount,GrossAmount,SchemeAmount,DiscountAmount
			   ,TaxAmount,SpecialDiscountAmount,VolumeDiscountAmount,TotalDiscountAmount
			   ,ConversionRate,MRP,ExpiryDate,SaleRate,WholeSaleRate,SpecialRate
			   ,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn
			)
		;
		
		PRINT 'INSRT IN Purchase LINE ITEM Complete'
	
		
		DELETE FROM BillOutStandings WHERE PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID)

       
       MERGE INTO dbo.BillOutStandings t1
       USING
       (
			SELECT
			   PurchaseSaleBookHeaderID,VoucherNumber,VoucherTypeCode,VoucherDate
			   ,LedgerType,LedgerTypeCode
			   ,TotalBillAmount as BillAmount,TotalBillAmount AS OSAmount
		   FROM PurchaseSaleBookHeader
		   WHERE PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID)			
       ) t2 ON t1.PurchaseSaleBookHeaderID = t2.PurchaseSaleBookHeaderID
       WHEN MATCHED THEN
			UPDATE SET t1.VoucherDate = t2.VoucherDate,
				t1.BillAmount = t2.BillAmount
		WHEN NOT MATCHED THEN
			INSERT (
				 PurchaseSaleBookHeaderID,VoucherNumber
				,VoucherTypeCode,VoucherDate
				,LedgerType,LedgerTypeCode
				,BillAmount,OSAmount
			)
			VALUES (			
				PurchaseSaleBookHeaderID,VoucherNumber
				,VoucherTypeCode,VoucherDate
				,LedgerType,LedgerTypeCode
				,BillAmount,OSAmount
			);
       
		PRINT 'INSRT IN Purchase BILLOS Complete'
		
		----------------------INSERT IN TRAN STRAT --------------------------------------------------------
		
		
		DELETE FROM dbo.TRN WHERE PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID)			
		
		
		DECLARE @Narration nvarchar(200) 
		
		SET @Narration = 'Sale Invoice is - ' + @VoucherNumber
		--FROM PurchaseSaleBookHeader WHERE PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID)
		
		
		INSERT INTO dbo.TRN
           (    PurchaseSaleBookHeaderID
			   ,VoucherNumber
			   ,VoucherTypeCode
			   ,VoucherDate
			   ,LedgerType
			   ,LedgerTypeCode
			   ,NARRATION
			   ,Amount
			   ,DebitCredit
           )
          SELECT PurchaseSaleBookHeaderID
			   ,VoucherNumber
			   ,VoucherTypeCode
			   ,VoucherDate
			   ,LedgerType
			   ,LedgerTypeCode
			   ,@Narration As NARRATION
			   ,ROUND(TotalBillAmount,0) AS Amount
			   ,'C' AS DebitCredit
		  FROM PurchaseSaleBookHeader
		  WHERE PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID)

		INSERT INTO dbo.TRN
		(   PurchaseSaleBookHeaderID
		   ,VoucherNumber
		   ,VoucherTypeCode
		   ,VoucherDate
		   ,LedgerType
		   ,LedgerTypeCode
		   ,NARRATION
		   ,Amount
		   ,DebitCredit
		)		  
		SELECT 
			PurchaseSaleBookHeaderID
			,VoucherNumber
			,VoucherTypeCode
			,VoucherDate
			,'SALELEDGER' AS LedgerType
			,REPLACE(AmountName,'Amount','SALE0000') As LedgerTypeCode
			,@Narration As NARRATION
			,Amount
			,'D' DebitCredit
		FROM dbo.PurchaseSaleBookHeader
		UNPIVOT
		(
			Amount
			FOR AmountName in (Amount01, Amount02, Amount03,Amount04,Amount05,Amount06,Amount07)
		) unpiv
		WHERE PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID) 
		AND Amount > 0;


		INSERT INTO dbo.TRN
		(   PurchaseSaleBookHeaderID
		   ,VoucherNumber
		   ,VoucherTypeCode
		   ,VoucherDate
		   ,LedgerType
		   ,LedgerTypeCode
		   ,NARRATION
		   ,Amount
		   ,DebitCredit
		)		  
		SELECT 
			PurchaseSaleBookHeaderID
			,VoucherNumber
			,VoucherTypeCode
			,VoucherDate
			,'GENERALLEDGER' AS LedgerType
			,REPLACE(AmountName,'IGST','IGST0000') As LedgerTypeCode
			,@Narration As NARRATION
			,Amount
			,'D' DebitCredit
		FROM dbo.PurchaseSaleBookHeader
		UNPIVOT
		(
			Amount
			FOR AmountName in (IGST01, IGST02, IGST03,IGST04,IGST05,IGST06,IGST07)
		) unpiv
		WHERE PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID) AND 
		--LocalCentral = 'C' AND 
		Amount > 0;
		
		
		INSERT INTO dbo.TRN
		(   PurchaseSaleBookHeaderID
		   ,VoucherNumber
		   ,VoucherTypeCode
		   ,VoucherDate
		   ,LedgerType
		   ,LedgerTypeCode
		   ,NARRATION
		   ,Amount
		   ,DebitCredit
		)		  
		SELECT 
			PurchaseSaleBookHeaderID
			,VoucherNumber
			,VoucherTypeCode
			,VoucherDate
			,'GENERALLEDGER' AS LedgerType
			,REPLACE(AmountName,'SGST','SGST0000') As LedgerTypeCode
			,@Narration As NARRATION
			,Amount
			,'D' DebitCredit
		FROM dbo.PurchaseSaleBookHeader
		UNPIVOT
		(
			Amount
			FOR AmountName in (SGST01, SGST02, SGST03,SGST04,SGST05,SGST06,SGST07)
		) unpiv
		WHERE PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID) AND 
		--LocalCentral = 'C' AND 
		Amount > 0;
		
		
		
		INSERT INTO dbo.TRN
		(   PurchaseSaleBookHeaderID
		   ,VoucherNumber
		   ,VoucherTypeCode
		   ,VoucherDate
		   ,LedgerType
		   ,LedgerTypeCode
		   ,NARRATION
		   ,Amount
		   ,DebitCredit
		)		  
		SELECT 
			PurchaseSaleBookHeaderID
			,VoucherNumber
			,VoucherTypeCode
			,VoucherDate
			,'GENERALLEDGER' AS LedgerType
			,REPLACE(AmountName,'CGST','CGST0000') As LedgerTypeCode
			,@Narration As NARRATION
			,Amount
			,'D' DebitCredit
		FROM dbo.PurchaseSaleBookHeader
		UNPIVOT
		(
			Amount
			FOR AmountName in (CGST01, CGST02, CGST03,CGST04,CGST05,CGST06,CGST07)
		) unpiv
		WHERE PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID) AND 
			--LocalCentral = 'C' AND 
			Amount > 0;
		
		
		INSERT INTO dbo.TRN
		(   PurchaseSaleBookHeaderID
		   ,VoucherNumber
		   ,VoucherTypeCode
		   ,VoucherDate
		   ,LedgerType
		   ,LedgerTypeCode
		   ,NARRATION
		   ,Amount
		   ,DebitCredit
		)		 
		SELECT DISTINCT
			A.PurchaseSaleBookHeaderID
		   ,VoucherNumber
		   ,VoucherTypeCode
		   ,VoucherDate
		   ,'INCOMELEDGER' LedgerType
		   ,'ADJ0000001' LedgerTypeCode
		  ,@Narration As NARRATION
		   ,ABS(B.DebitAmount - C.CreditAmount) AS Amount
		   ,CASE WHEN (DebitAmount - CreditAmount) > 0 THEN 'C' ELSE 'D' END AS DebitCredit 
		FROM TRN A
		INNER JOIN (
			SELECT 
				PurchaseSaleBookHeaderID
			   ,SUM(Amount) DebitAmount
			FROM TRN 
			WHERE PurchaseSaleBookHeaderID=COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID) AND DebitCredit = 'D'
			Group BY PurchaseSaleBookHeaderID
		) B On A.PurchaseSaleBookHeaderID = B.PurchaseSaleBookHeaderID
		INNER JOIN 
		(
			SELECT 
				PurchaseSaleBookHeaderID
			   ,SUM(Amount) CreditAmount
			FROM TRN 
			WHERE PurchaseSaleBookHeaderID=COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID) AND DebitCredit = 'C'
			Group BY PurchaseSaleBookHeaderID
		) C ON A.PurchaseSaleBookHeaderID = C.PurchaseSaleBookHeaderID
		WHERE A.PurchaseSaleBookHeaderID = COALESCE(@OldPurchaseSaleHeaderID,@NewPurchaseSaleHeaderID)
		AND ABS(B.DebitAmount - C.CreditAmount) > 0
		
		   
		
		
		----------------------------------------------------------------------------------------------------
		
		DELETE FROM TempPurchaseSaleBookLineItem WHERE PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID
		DELETE FROM TempPurchaseSaleBookHeader WHERE PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID
		
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
GO
/****** Object:  StoredProcedure [dbo].[sp_Audit_Trail]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Audit_Trail] (@TableName Varchar(128),@columnUpdate varbinary(10))   
AS   
    
DECLARE @flag int   
    
 --SELECT @flag= flag FROM AuditBulkController   
 --IF(@flag=0)   
 --BEGIN   
 -- RETURN   
 --END   
    
DECLARE @bit int ,   
@field int ,   
@maxfield int ,   
@char int ,   
@fieldname varchar(128) ,   
@fielddatatype varchar(128) ,   
@PKCols varchar(1000) ,   
@sql varchar(2000),    
@UpdateDate varchar(21) ,   
@UserName varchar(128) ,   
@Type char(1) ,   
@PKSelect varchar(1000),   
@UpdatedBy varchar(100),   
@result varchar(1000),   
@Audit_Enabled BIT   
     
set @Type='I'   
  
SET NOCOUNT ON; 
  
SELECT ROW_NUMBER() OVER(ORDER BY (SELECT NULL)) AS RowID, * into #insertedRows from #inserted 
SELECT ROW_NUMBER() OVER(ORDER BY (SELECT NULL)) AS RowID, * into #deletedRows from #deleted  
  
DECLARE @RowID INT = 1, @InsertRowCount INT = 0, @DeleteRowCount INT = 0 
  
SELECT @InsertRowCount = COUNT(*) From #insertedRows 
SELECT @DeleteRowCount = COUNT(*) From #deletedRows 
  
WHILE((@RowID <= @InsertRowCount AND @InsertRowCount <> 0) OR (@RowID <= @DeleteRowCount AND @DeleteRowCount <> 0)) 
BEGIN 
  
 if exists (select * from #insertedRows WHERE RowID = @RowID)   
  if exists (select * from #deletedRows WHERE RowID = @RowID)   
  BEGIN   
   select @Type = 'U'   
   select  @UserName = ModifiedBy from #insertedRows WHERE RowID = @RowID  
  end   
  else   
  begin   
   select @Type = 'I'   
   select  @UserName = CreatedBy from #insertedRows WHERE RowID = @RowID   
  end   
 else   
 begin   
  select @Type = 'D'   
  set @UserName = system_user     
 END   
  
 Print @Type 
   
 -- date and user    
      
 select @UpdateDate = convert(varchar(21), GETDATE())  
 -- Get primary key select for insert   
 DECLARE @sqlString VARCHAR(2000)   
 SELECT @PKSelect = NULL, @PKCols = NULL  
   
 IF @type='I'   
 BEGIN    
  print 'Insert PK'   
  DECLARE @sqlstr nvarchar(max)   
  
  select @PKSelect = coalesce(@PKSelect+'+','') + '''<' + COLUMN_NAME + '=''+convert(varchar(100),coalesce(i.' + COLUMN_NAME +',''''))+''>'''    
  from INFORMATION_SCHEMA.TABLE_CONSTRAINTS pk ,   
  INFORMATION_SCHEMA.KEY_COLUMN_USAGE c   
  where  pk.TABLE_NAME = @TableName   
  and CONSTRAINT_TYPE = 'PRIMARY KEY'   
  and c.TABLE_NAME = pk.TABLE_NAME   
  and c.CONSTRAINT_NAME = pk.CONSTRAINT_NAME    
  
  SET @sqlstr='select @x = '+ @PKSelect+ ' from #insertedRows i Where RowID = ' + CONVERT(VARCHAR,@RowID)   
  
  exec sp_executesql @sqlstr, N'@x VARCHAR(max) out', @PKSelect OUT   
 END   
   
 -- Get primary key select for insert   
 IF @type='D'   
 BEGIN   
  select @PKSelect = coalesce(@PKSelect+'+','') + '''<' + COLUMN_NAME + '=''+convert(varchar(100),coalesce(d.' + COLUMN_NAME +',''''))+''>'''    
  from INFORMATION_SCHEMA.TABLE_CONSTRAINTS pk ,   
  INFORMATION_SCHEMA.KEY_COLUMN_USAGE c   
  where  pk.TABLE_NAME = @TableName   
  and CONSTRAINT_TYPE = 'PRIMARY KEY'   
  and c.TABLE_NAME = pk.TABLE_NAME   
  and c.CONSTRAINT_NAME = pk.CONSTRAINT_NAME    
  
  SET @sqlstr='select @x = '+ @PKSelect+ ' from #deletedRows d Where RowID = ' + CONVERT(VARCHAR,@RowID)   
  
  exec sp_executesql @sqlstr, N'@x VARCHAR(max) out', @PKSelect out   
 END   
  
 -- Get primary key select for insert   
 IF @type='U'   
 BEGIN   
  select @PKSelect = coalesce(@PKSelect+'+','') + '''<' + COLUMN_NAME + '=''+convert(varchar(100),coalesce(i.' + COLUMN_NAME +',d.' + COLUMN_NAME + '))+''>'''    
  from INFORMATION_SCHEMA.TABLE_CONSTRAINTS pk ,   
  INFORMATION_SCHEMA.KEY_COLUMN_USAGE c   
  where  pk.TABLE_NAME = @TableName   
  and CONSTRAINT_TYPE = 'PRIMARY KEY'   
  and c.TABLE_NAME = pk.TABLE_NAME   
  and c.CONSTRAINT_NAME = pk.CONSTRAINT_NAME    
 END 
   
 IF @type='I'   
 BEGIN   
  print 'Insert Audit'   
  DECLARE @x1 XML   
  SELECT @x1 = (select * from #insertedRows as RowAuditData WHERE RowID = @RowID for xml AUTO, ELEMENTS)  
    
  IF (@x1 IS NOT NULL AND @x1.exist('/RowAuditData/RowID') = 1) 
   SET @x1.modify('delete /RowAuditData/RowID') 
    
  INSERT INTO  AuditHistory (CreatedAt,UserName,TableName,ColumnName,OldValue,NewValue,Operation,PrimaryKey)   
  VALUES(GETDATE(), @UserName, @TableName,'Insert', NULL, Convert(varchar(max),@x1),@type,@PKSelect)   
  
 END    
   
 IF @type='D'   
 BEGIN   
  DECLARE @x2 XML   
  SELECT @x2 = (select * from #deletedRows as RowAuditData WHERE RowID = @RowID for xml AUTO, ELEMENTS)   
    
  IF (@x2 IS NOT NULL AND @x2.exist('/RowAuditData/RowID') = 1) 
   SET @x2.modify('delete /RowAuditData/RowID') 
    
  INSERT INTO  AuditHistory (CreatedAt,UserName,TableName,ColumnName,OldValue,NewValue,Operation,PrimaryKey)   
  VALUES(GETDATE(), @UserName, @TableName,'Delete', Convert(varchar(max),@x2),null,@type,@PKSelect)     
  
 END    
   
 IF @type='U'   
 BEGIN   
  
  -- Get primary key columns for full outer join   
  select @PKCols = coalesce(@PKCols + ' and', ' on') + ' i.' + c.COLUMN_NAME + ' = d.' + c.COLUMN_NAME   
  from INFORMATION_SCHEMA.TABLE_CONSTRAINTS pk ,   
  INFORMATION_SCHEMA.KEY_COLUMN_USAGE c   
  where  pk.TABLE_NAME = @TableName   
  and CONSTRAINT_TYPE = 'PRIMARY KEY'   
  and c.TABLE_NAME = pk.TABLE_NAME   
  and c.CONSTRAINT_NAME = pk.CONSTRAINT_NAME   
  
  if @PKCols is null   
  begin   
   raiserror('no PK on table %s', 16, -1, @TableName)   
   return   
  END   
  
  
  select @field = 0,  
  @maxfield = max(COLUMNPROPERTY(object_id(table_schema+'.'+table_name),column_name,'columnid'))  
  from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = @TableName   
  
  while @field < @maxfield   
  begin   
   select @field = min(COLUMNPROPERTY(object_id(table_schema+'.'+table_name),column_name,'columnid'))  
   from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = @TableName  
   and COLUMNPROPERTY(object_id(table_schema+'.'+table_name),column_name,'columnid')  > @field 
  
  
   select @bit = (@field - 1 )% 8 + 1   
   select @bit = power(2,@bit - 1)   
   select @char = ((@field - 1) / 8) + 1   
     
   select @fieldname = COLUMN_NAME, 
   @fielddatatype=UPPER(DATA_TYPE)  
   from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = @TableName  
   and COLUMNPROPERTY(object_id(table_schema+'.'+table_name),column_name,'columnid') = @field   
     
   -- check field we want to exclude it for auditing   
   if (substring(@columnUpdate,@char, 1) & @bit > 0 )or @Type in ('I','D')   
   BEGIN  
      
    IF @fielddatatype='TEXT' OR @fielddatatype ='NTEXT' OR @fielddatatype='IMAGE'   
    BEGIN   
     DECLARE @sqlstr1 nvarchar(max)   
     DECLARE @sqlstr2 nvarchar(max)   
  
     SET @PKSelect = REPLACE(@PKSelect,'d.' ,'i.')   
     SET @sqlstr1='select @x = '+ @PKSelect+ ' from #insertedRows i Where RowID = ' + CONVERT(VARCHAR,@RowID)   
  
     exec sp_executesql @sqlstr1, N'@x VARCHAR(max) out', @PKSelect OUT          
  
     INSERT INTO  AuditHistory (CreatedAt,UserName,TableName,ColumnName,OldValue,NewValue,Operation,PrimaryKey)   
     VALUES(GETDATE(), @UserName, @TableName,@fieldname, @fielddatatype,@fielddatatype,@type,@PKSelect)   
    END   
    ELSE   
    BEGIN  
     /* Code for generating UPDATE (or insert and delete) syntaxes */   
     select @sql =   'insert AuditHistory (Operation,TableName,PrimaryKey,ColumnName,OldValue,NewValue,CreatedAt,UserName)'   
     select @sql = @sql +  ' select ''' + @Type + ''''   
     select @sql = @sql +  ',''' + @TableName + ''''   
     select @sql = @sql +  ',' + @PKSelect   
     select @sql = @sql +  ',''' + @fieldname + ''''   
     select @sql = @sql +  ',convert(varchar(1000),d.' + @fieldname + ')'   
     select @sql = @sql +  ',convert(varchar(1000),i.' + @fieldname + ')'   
     select @sql = @sql +  ',''' + @UpdateDate + ''''   
     select @sql = @sql +  ',''' + @UserName + ''''   
     select @sql = @sql +  ' from #insertedRows i full outer join #deletedRows d'   
     select @sql = @sql +  @PKCols    
     select @sql = @sql +  ' where i.' + @fieldname + ' <> d.' + @fieldname    
     select @sql = @sql +  ' or (i.' + @fieldname + ' is null and  d.' + @fieldname + ' is not null)'    
     select @sql = @sql +  ' or (i.' + @fieldname + ' is not null and  d.' + @fieldname + ' is null)'  
     select @sql = @sql +  ' and (i.RowID = ' + CONVERT(VARCHAR,@RowID) + ')'  
     exec (@sql) 
     print @rowID 
     print @PKSelect 
     print @sql 
    end     
   end   
       
  end   
 END 
     
 SET @RowID = @RowID  + 1 
   
END 
SET NOCOUNT OFF;
GO
/****** Object:  StoredProcedure [dbo].[Test1]    Script Date: 11-04-2026 08:40:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Test1]
	@TableTypePurchaseSaleBookLineItem TableTypePurchaseSaleBookLineItem READONLY
AS
BEGIN	
	BEGIN TRY	
	BEGIN TRAN
	
	
	DECLARE @LineItems AS TABLE
	(
		PurchaseSaleBookLineItemID BIGINT
	)
	
	
	DECLARE @OldQuantity decimal(18,2), @Quantity decimal(18,2),@FreeQuantity decimal(18,2)
	DECLARE @BalanceQuantity decimal(18,2), @NewQuantity decimal(18,2)
	DECLARE @OldFifoId BIGINT,@OldPurchaseSaleBookLineItemID BIGINT
	DECLARE @ItemCode nvarchar(10)


	SELECT 
		@OldPurchaseSaleBookLineItemID = PurchaseSaleBookLineItemID
		,@ItemCode = ItemCode
	FROM @TableTypePurchaseSaleBookLineItem	
	
	Select @OldQuantity = Quantity , @OldFifoId = FifoID 
		--,@OldPurchaseSaleBookLineItemID =PurchaseSaleBookLineItemID
	FROM TempPurchaseSaleBookLineItem WHERE PurchaseSaleBookLineItemID = @OldPurchaseSaleBookLineItemID


	SELECT @BalanceQuantity = BalanceQuanity--,@FreeQuantity = FreeQuantity
	FROM FIFO WHERE FifoID = ISNULL(@OldFifoId,0)
	
	SET @NewQuantity = @Quantity - ISNULL(@OldQuantity,0)
	
	SET @BalanceQuantity = ISNULL(@BalanceQuantity,0)
	
	IF ISNULL(@OldPurchaseSaleBookLineItemID,0) <> 0 
		AND ISNULL(@OldFifoId ,0) <> 0 
		AND ISNULL(@OldQuantity,0) <> ISNULL(@Quantity,0)
		AND @BalanceQuantity > @NewQuantity
	BEGIN
		
			MERGE INTO dbo.TempPurchaseSaleBookLineItem t1
			USING @TableTypePurchaseSaleBookLineItem t2 
			ON t1.PurchaseSaleBookLineItemID = t2.PurchaseSaleBookLineItemID
			WHEN MATCHED THEN 
			UPDATE SET t1.PurchaseSaleBookHeaderID=t2.PurchaseSaleBookHeaderID
				,t1.PurchaseBillDate=t2.PurchaseBillDate
				,t1.PurchaseVoucherNumber=t2.PurchaseVoucherNumber
				,t1.PurchaseSrlNo=t2.PurchaseSrlNo
				--,t1.ItemCode=t2.ItemCode
				--,t1.Batch=t2.Batch
				--,t1.BatchNew=t2.BatchNew
				,t1.Quantity=t2.Quantity
				,t1.FreeQuantity=t2.FreeQuantity
				,t1.PurchaseSaleRate=t2.PurchaseSaleRate
				,t1.EffecivePurchaseSaleRate=t2.EffecivePurchaseSaleRate
				,t1.PurchaseSaleTypeCode=t2.PurchaseSaleTypeCode
				,t1.SurCharge=t2.SurCharge
				,t1.PurchaseSaleTax=t2.PurchaseSaleTax
				,t1.LocalCentral=t2.LocalCentral
				,t1.SGST=t2.SGST
				,t1.IGST=t2.IGST
				,t1.CGST=t2.CGST
				,t1.Amount=t2.Amount
				,t1.Discount=t2.Discount
				,t1.SpecialDiscount=t2.SpecialDiscount
				,t1.DiscountQuantity=t2.DiscountQuantity
				,t1.VolumeDiscount=t2.VolumeDiscount
				,t1.Scheme1=t2.Scheme1
				,t1.Scheme2=t2.Scheme2
				,t1.IsHalfScheme=t2.IsHalfScheme
				,t1.HalfSchemeRate=t2.HalfSchemeRate
				,t1.ConversionRate=t2.ConversionRate
				,t1.MRP=t2.MRP
				,t1.ExpiryDate=t2.ExpiryDate
				,t1.SaleRate=t2.SaleRate
				,t1.WholeSaleRate=t2.WholeSaleRate
				,t1.SpecialRate=t2.SpecialRate		
				,t1.ModifiedBy=t2.ModifiedBy
				,t1.ModifiedOn=t2.ModifiedOn;
				
			Update FIFO Set BalanceQuanity = BalanceQuanity- @NewQuantity WHERE FifoID = @OldFifoId
			
			INSERT INTO @LineItems(PurchaseSaleBookLineItemID)
			SELECT @OldPurchaseSaleBookLineItemID
		
	END
	ELSE
		BEGIN
		
				IF @NewQuantity > 0
				BEGIN 
				
					DECLARE @FifoID Bigint
					DECLARE @QtytobeInsert decimal(18,2)
			
					WHILE (@NewQuantity > 0)
					BEGIN
						
							SELECT TOP 1 @FifoID = FifoID, @BalanceQuantity = BalanceQuanity FROM
							FIFO WHERE ItemCode = @ItemCode AND BalanceQuanity  > 0
							ORDER BY VoucherDate DESC
						
							IF @NewQuantity > @BalanceQuantity
							BEGIN
								SET @QtytobeInsert = @BalanceQuantity
							END
							ELSE
							BEGIN
								SET @QtytobeInsert = @NewQuantity
							END
							
							MERGE INTO dbo.TempPurchaseSaleBookLineItem t1
							USING 
							(
								SELECT 
									 F.PurchaseSaleBookHeaderID
									 ,F.Fifoid
									,PurchaseBillDate,PurchaseVoucherNumber,PurchaseSrlNo
									,F.ItemCode,F.Batch,BatchNew
									,@QtytobeInsert AS Quantity,FreeQuantity
									,PurchaseSaleRate,EffecivePurchaseSaleRate
									,PurchaseSaleTypeCode,SurCharge
									,L.SalePurchaseTax
									,LocalCentral,SGST,IGST,CGST
									,Amount,Discount,SpecialDiscount,DiscountQuantity,VolumeDiscount
									,F.Scheme1,F.Scheme2,IsHalfScheme,HalfSchemeRate		
									,ConversionRate,F.MRP,F.ExpiryDate
									,F.SaleRate,F.WholeSaleRate,F.SpecialRate
									,CreatedBy,CreatedOn
									,0 AS PurchaseSaleBookLineItemID
								FROM FIFO	F
								INNER JOIN dbo.PurchaseSaleBookLineItem L
								ON F.PurchaseSaleBookHeaderID = L.PurchaseSaleBookHeaderID
								AND F.ItemCode = L.ItemCode
								AND F.Batch = L.Batch
							
							) t2 
							ON t1.PurchaseSaleBookLineItemID = t2.PurchaseSaleBookLineItemID
							WHEN NOT MATCHED THEN
							INSERT (
								 PurchaseSaleBookHeaderID
								 ,Fifoid
								,PurchaseBillDate,PurchaseVoucherNumber,PurchaseSrlNo
								,ItemCode,Batch,BatchNew
								,Quantity,FreeQuantity
								,PurchaseSaleRate,EffecivePurchaseSaleRate
								,PurchaseSaleTypeCode,SurCharge
								,PurchaseSaleTax
								,LocalCentral,SGST,IGST,CGST
								,Amount,Discount,SpecialDiscount,DiscountQuantity,VolumeDiscount
								,Scheme1,Scheme2,IsHalfScheme,HalfSchemeRate		
								,ConversionRate,MRP,ExpiryDate
								,SaleRate,WholeSaleRate,SpecialRate
								,CreatedBy,CreatedOn	
							)
							VALUES
							(
								 t2.PurchaseSaleBookHeaderID
								,@fifoid
								,t2.PurchaseBillDate,t2.PurchaseVoucherNumber,t2.PurchaseSrlNo
								,t2.ItemCode,t2.Batch,t2.BatchNew
								,t2.Quantity,t2.FreeQuantity
								,t2.PurchaseSaleRate,t2.EffecivePurchaseSaleRate
								,t2.PurchaseSaleTypeCode,t2.SurCharge
								,t2.SalePurchaseTax
								,t2.LocalCentral,t2.SGST,t2.IGST,t2.CGST
								,t2.Amount,t2.Discount,t2.SpecialDiscount,t2.DiscountQuantity,t2.VolumeDiscount
								,t2.Scheme1,t2.Scheme2,t2.IsHalfScheme,t2.HalfSchemeRate		
								,t2.ConversionRate,t2.MRP,t2.ExpiryDate
								,t2.SaleRate,t2.WholeSaleRate,t2.SpecialRate
								,t2.CreatedBy,t2.CreatedOn
							);
							
							SET @NewQuantity = @NewQuantity - @QtytobeInsert
							
							INSERT @LineItems (PurchaseSaleBookLineItemID)
							VALUES (SCOPE_IDENTITY())
							
							Update FIFO Set BalanceQuanity =@QtytobeInsert WHERE FifoID = @FifoID
			
								
					END
				END
				ELSE IF @NewQuantity = 0
					BEGIN
					
							MERGE INTO dbo.TempPurchaseSaleBookLineItem t1
							USING @TableTypePurchaseSaleBookLineItem t2 
							ON t1.PurchaseSaleBookLineItemID = t2.PurchaseSaleBookLineItemID
							WHEN NOT MATCHED THEN
							INSERT (
								 PurchaseSaleBookHeaderID
								,PurchaseBillDate,PurchaseVoucherNumber,PurchaseSrlNo
								,ItemCode,Batch,BatchNew
								,Quantity,FreeQuantity
								,PurchaseSaleRate,EffecivePurchaseSaleRate
								,PurchaseSaleTypeCode,SurCharge
								,PurchaseSaleTax
								,LocalCentral,SGST,IGST,CGST
								,Amount,Discount,SpecialDiscount,DiscountQuantity,VolumeDiscount
								,Scheme1,Scheme2,IsHalfScheme,HalfSchemeRate		
								,ConversionRate,MRP,ExpiryDate
								,SaleRate,WholeSaleRate,SpecialRate
								,CreatedBy,CreatedOn	
							)
							VALUES
							(
								 t2.PurchaseSaleBookHeaderID
								,t2.PurchaseBillDate,t2.PurchaseVoucherNumber,t2.PurchaseSrlNo
								,t2.ItemCode,t2.Batch,t2.BatchNew
								,t2.Quantity,t2.FreeQuantity
								,t2.PurchaseSaleRate,t2.EffecivePurchaseSaleRate
								,t2.PurchaseSaleTypeCode,t2.SurCharge
								,t2.PurchaseSaleTax
								,t2.LocalCentral,t2.SGST,t2.IGST,t2.CGST
								,t2.Amount,t2.Discount,t2.SpecialDiscount,t2.DiscountQuantity,t2.VolumeDiscount
								,t2.Scheme1,t2.Scheme2,t2.IsHalfScheme,t2.HalfSchemeRate		
								,t2.ConversionRate,t2.MRP,t2.ExpiryDate
								,t2.SaleRate,t2.WholeSaleRate,t2.SpecialRate
								,t2.CreatedBy,t2.CreatedOn
							);	
					
							INSERT @LineItems (PurchaseSaleBookLineItemID)
							VALUES (SCOPE_IDENTITY())
					
					END
		END
	
	
	
	
	
	--MERGE INTO dbo.ItemMaster t1
	--USING @TableTypePurchaseSaleBookLineItem t2 
	--ON t1.ItemCode = t2.ItemCode
	--WHEN MATCHED THEN 
	--UPDATE SET t1.PurchaseRate = t2.PurchaseSaleRate
	--		,t1.MRP = t2.MRP
	--		,t1.SaleRate = t2.SaleRate
	--		,t1.SpecialRate = t2.SpecialRate
	--		,t1.WholeSaleRate = t2.WholeSaleRate
	--		,t1.Scheme1 = t2.Scheme1
	--		,t1.Scheme2 = t2.Scheme2
	--		,t1.IsHalfScheme = t2.IsHalfScheme
	--		,t1.DiscountRecieved = t2.Discount
	--		,t1.SpecialDiscountRecieved =t2.SpecialDiscount
	--		,t1.BATCH = t2.BATCH
	--		,t1.ExpiryDate  = t2.ExpiryDate
	--		;
	
	
	
	DECLARE @PurchaseSaleBookHeaderID AS BIGINT
	
	SELECT @PurchaseSaleBookHeaderID = PurchaseSaleBookHeaderID
	FROM @TableTypePurchaseSaleBookLineItem
	
	DECLARE @TempTableAmountWithAllDiscountAmounts TABLE (
	   PurchaseSaleBookHeaderID BIGINT NOT NULL,
	   PurchaseSaleBookLineItemID BIGINT NOT NULL,
	   FinalAmount FLOAT NOT NULL,
	   GrossAmount FLOAT NOT NULL,
	   SchemeAmount FLOAT NOT NULL,
	   DiscountAmount FLOAT NOT NULL,
	   SpecialDiscountAmount FLOAT NOT NULL,
	   VolumeDiscountAmount FLOAT NOT NULL   
	) ;
		
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
	  SELECT CA.PurchaseSaleBookHeaderID
			,CA.PurchaseSaleBookLineItemID
			,FinalAmount
			,CA.GrossAmount
			,CA.SchemeAmount
			,CA.DiscountAmount
			,CA.SpecialDiscountAmount
			,CA.VolumeDiscountAmount
	FROM UDF_GetAmountWithAllDiscountAmounts(@PurchaseSaleBookHeaderID) CA
		--FROM TempPurchaseSaleBookLineItem A
		--CROSS APPLY UDF_GetAmountWithAllDiscountAmounts(A.PurchaseSaleBookLineItemID) CA
		--WHERE A.PurchaseSaleBookLineItemID IN (SELECT PurchaseSaleBookLineItemID FROM @LineItems)

	   SELECT       
		   PurchaseSaleBookHeaderID
		  ,PurchaseSaleBookLineItemID 
		  ,FifoID,I.ItemCode,B.ItemName ,Batch,BatchNew
		  ,Quantity,FreeQuantity
		  ,PurchaseSaleRate,EffecivePurchaseSaleRate
		  ,PurchaseSaleTypeCode,SurCharge
		  ,LocalCentral,SGST,IGST,CGST
		  ,Amount,Discount,SpecialDiscount,DiscountQuantity,VolumeDiscount
		  ,Scheme1,Scheme2,IsHalfScheme,HalfSchemeRate
		  ,CostAmount,GrossAmount,SchemeAmount,DiscountAmount,SurchargeAmount
		  ,ConversionRate,MRP,ExpiryDate
		  ,SaleRate,WholeSaleRate,SpecialRate
		  ,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn
		  ,TaxAmount
		  ,SpecialDiscountAmount
		  ,VolumeDiscountAmount
		  ,TotalDiscountAmount
		  ,OldPurchaseSaleBookLineItemID  
		  ,BalanceQuantity
		  ,UsedQuantity
	FROM TempPurchaseSaleBookLineItem I
	INNER JOIN (
		SELECT ItemCode,ItemName  from ItemMaster
	) B ON I.ItemCode = B.ItemCode
	 WHERE PurchaseSaleBookHeaderID = @PurchaseSaleBookHeaderID
	 AND I.PurchaseSaleBookLineItemID IN (SELECT PurchaseSaleBookLineItemID FROM @LineItems)

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

GO
