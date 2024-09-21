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
