CREATE TABLE [dbo].[CustomerCompanyDiscountRef] (
    [CustCompDiscountRefID] INT             IDENTITY (1, 1) NOT NULL,
    [CustomerLedgerID]      INT             NOT NULL,
    [CompanyID]             INT             NOT NULL,
    [ItemID]                INT             NULL,
    [Normal]                DECIMAL (18, 2) NULL,
    [Breakage]              DECIMAL (18, 2) NULL,
    [Expired]               DECIMAL (18, 2) NULL,
    [IsLessEcise]           BIT             NOT NULL,
    CONSTRAINT [PK_CustomerCompanyDiscountRef] PRIMARY KEY CLUSTERED ([CustCompDiscountRefID] ASC),
    CONSTRAINT [FK_CustomerCompanyDiscountRef_CompanyMaster] FOREIGN KEY ([CompanyID]) REFERENCES [dbo].[CompanyMaster] ([CompanyId]),
    CONSTRAINT [FK_CustomerCompanyDiscountRef_CustomerLedger] FOREIGN KEY ([CustomerLedgerID]) REFERENCES [dbo].[CustomerLedger] ([CustomerLedgerId]),
    CONSTRAINT [FK_CustomerCompanyDiscountRef_ItemMaster] FOREIGN KEY ([ItemID]) REFERENCES [dbo].[ItemMaster] ([ItemID])
);

