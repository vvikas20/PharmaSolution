CREATE TABLE [dbo].[SupplierCompanyDiscountRef] (
    [CustCompDiscountRefID] INT             IDENTITY (1, 1) NOT NULL,
    [SupplierLedgerID]      INT             NOT NULL,
    [CompanyID]             INT             NOT NULL,
    [ItemID]                INT             NULL,
    [Normal]                DECIMAL (18, 2) NULL,
    [Breakage]              DECIMAL (18, 2) NULL,
    [Expired]               DECIMAL (18, 2) NULL,
    [IsLessEcise]           BIT             NOT NULL,
    CONSTRAINT [PK_SupplierCompanyDiscountRef] PRIMARY KEY CLUSTERED ([CustCompDiscountRefID] ASC),
    CONSTRAINT [FK_SupplierCompanyDiscountRef_CompanyMaster] FOREIGN KEY ([CompanyID]) REFERENCES [dbo].[CompanyMaster] ([CompanyId]),
    CONSTRAINT [FK_SupplierCompanyDiscountRef_ItemMaster] FOREIGN KEY ([ItemID]) REFERENCES [dbo].[ItemMaster] ([ItemID]),
    CONSTRAINT [FK_SupplierCompanyDiscountRef_SupplierLedger] FOREIGN KEY ([SupplierLedgerID]) REFERENCES [dbo].[SupplierLedger] ([SupplierLedgerId])
);

