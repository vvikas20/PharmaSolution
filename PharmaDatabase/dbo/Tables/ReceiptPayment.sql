CREATE TABLE [dbo].[ReceiptPayment] (
    [ReceiptPaymentID]          BIGINT          IDENTITY (1, 1) NOT NULL,
    [VoucherNumber]             NVARCHAR (8)    NOT NULL,
    [VoucherTypeCode]           NVARCHAR (50)   NOT NULL,
    [VoucherDate]               DATETIME        NOT NULL,
    [LedgerType]                NVARCHAR (50)   NULL,
    [LedgerTypeCode]            NVARCHAR (10)   NULL,
    [PaymentMode]               NCHAR (1)       NOT NULL,
    [Amount]                    DECIMAL (18, 2) NULL,
    [BankAccountLedgerTypeCode] NVARCHAR (10)   NULL,
    [ChequeDate]                DATETIME        NULL,
    [ChequeClearDate]           DATETIME        NULL,
    [IsChequeCleared]           BIT             NULL,
    [POST]                      NVARCHAR (50)   NULL,
    [PISNumber]                 NVARCHAR (50)   NULL,
    [ChequeNumber]              NVARCHAR (10)   NULL,
    [LedgerTypeName]            VARCHAR (100)   NULL,
    [UnadjustedAmount]          DECIMAL (18, 2) NULL,
    [BankAccountLedgerTypeName] NVARCHAR (100)  NULL,
    CONSTRAINT [PK_ReceiptPayment] PRIMARY KEY CLUSTERED ([ReceiptPaymentID] ASC)
);

