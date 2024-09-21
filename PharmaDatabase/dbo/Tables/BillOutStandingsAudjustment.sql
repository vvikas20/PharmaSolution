CREATE TABLE [dbo].[BillOutStandingsAudjustment] (
    [BillOutStandingsAudjustmentID] BIGINT          IDENTITY (1, 1) NOT NULL,
    [PurchaseSaleBookHeaderID]      BIGINT          NULL,
    [VoucherNumber]                 NVARCHAR (8)    NOT NULL,
    [VoucherTypeCode]               NVARCHAR (50)   NOT NULL,
    [VoucherDate]                   DATETIME        NOT NULL,
    [ReceiptPaymentID]              BIGINT          NULL,
    [BillOutStandingsID]            BIGINT          NOT NULL,
    [AdjustmentVoucherNumber]       NVARCHAR (8)    NOT NULL,
    [AdjustmentVoucherTypeCode]     NVARCHAR (50)   NOT NULL,
    [AdjustmentVoucherDate]         DATETIME        NOT NULL,
    [LedgerType]                    NVARCHAR (50)   NULL,
    [LedgerTypeCode]                NVARCHAR (10)   NULL,
    [Amount]                        DECIMAL (18, 2) NOT NULL,
    [ChequeNumber]                  NVARCHAR (10)   NULL,
    CONSTRAINT [PK_BillOutStandingsAudjustment] PRIMARY KEY CLUSTERED ([BillOutStandingsAudjustmentID] ASC),
    CONSTRAINT [FK_BillOutStandingsAudjustment_BillOutStandings] FOREIGN KEY ([BillOutStandingsID]) REFERENCES [dbo].[BillOutStandings] ([BillOutStandingsID]),
    CONSTRAINT [FK_BillOutStandingsAudjustment_PurchaseSaleBookHeader] FOREIGN KEY ([PurchaseSaleBookHeaderID]) REFERENCES [dbo].[PurchaseSaleBookHeader] ([PurchaseSaleBookHeaderID]),
    CONSTRAINT [FK_BillOutStandingsAudjustment_ReceiptPayment] FOREIGN KEY ([ReceiptPaymentID]) REFERENCES [dbo].[ReceiptPayment] ([ReceiptPaymentID]),
    CONSTRAINT [FK_TempBillOutStandingsAudjustment_BillOutStandings] FOREIGN KEY ([BillOutStandingsID]) REFERENCES [dbo].[BillOutStandings] ([BillOutStandingsID]),
    CONSTRAINT [FK_TempBillOutStandingsAudjustment_PurchaseSaleBookHeader] FOREIGN KEY ([PurchaseSaleBookHeaderID]) REFERENCES [dbo].[PurchaseSaleBookHeader] ([PurchaseSaleBookHeaderID]),
    CONSTRAINT [FK_TempBillOutStandingsAudjustment_ReceiptPayment] FOREIGN KEY ([ReceiptPaymentID]) REFERENCES [dbo].[ReceiptPayment] ([ReceiptPaymentID])
);

