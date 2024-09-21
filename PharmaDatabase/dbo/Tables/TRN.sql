CREATE TABLE [dbo].[TRN] (
    [TrnID]                    BIGINT          IDENTITY (1, 1) NOT NULL,
    [PurchaseSaleBookHeaderID] BIGINT          NOT NULL,
    [VoucherNumber]            NVARCHAR (8)    NOT NULL,
    [VoucherTypeCode]          NVARCHAR (50)   NOT NULL,
    [VoucherDate]              DATETIME        NOT NULL,
    [LedgerType]               NVARCHAR (50)   NULL,
    [LedgerTypeCode]           NVARCHAR (10)   NULL,
    [NARRATION]                NVARCHAR (200)  NULL,
    [Amount]                   DECIMAL (18, 2) NOT NULL,
    [DebitCredit]              NVARCHAR (1)    NOT NULL,
    [Status]                   NVARCHAR (1)    NULL,
    [IsChequeClear]            BIT             CONSTRAINT [DF_TRN_IsChequeClear] DEFAULT ((0)) NOT NULL,
    [ChequeClearedDate]        DATETIME        NULL,
    [ChequeNumber]             NVARCHAR (10)   NULL,
    CONSTRAINT [PK_TRN] PRIMARY KEY CLUSTERED ([TrnID] ASC),
    CONSTRAINT [FK_TRN_PurchaseSaleBookHeader] FOREIGN KEY ([PurchaseSaleBookHeaderID]) REFERENCES [dbo].[PurchaseSaleBookHeader] ([PurchaseSaleBookHeaderID])
);

