CREATE TABLE [dbo].[BillOutStandings] (
    [BillOutStandingsID]       BIGINT          IDENTITY (1, 1) NOT NULL,
    [PurchaseSaleBookHeaderID] BIGINT          NULL,
    [VoucherNumber]            NVARCHAR (8)    NOT NULL,
    [VoucherTypeCode]          NVARCHAR (50)   NOT NULL,
    [VoucherDate]              DATETIME        NOT NULL,
    [LedgerType]               NVARCHAR (50)   NULL,
    [LedgerTypeCode]           NVARCHAR (10)   NULL,
    [BillAmount]               DECIMAL (18, 2) NOT NULL,
    [OSAmount]                 DECIMAL (18, 2) NOT NULL,
    [IsHold]                   BIT             CONSTRAINT [DF_BillOutStandings_IsHold] DEFAULT ((0)) NOT NULL,
    [HOLDRemarks]              NVARCHAR (100)  NULL,
    [DueDate]                  DATETIME        NULL,
    CONSTRAINT [PK_BillOutStandings] PRIMARY KEY CLUSTERED ([BillOutStandingsID] ASC),
    CONSTRAINT [FK_BillOutStandings_PurchaseSaleBookHeader] FOREIGN KEY ([PurchaseSaleBookHeaderID]) REFERENCES [dbo].[PurchaseSaleBookHeader] ([PurchaseSaleBookHeaderID])
);

