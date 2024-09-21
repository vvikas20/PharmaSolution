CREATE TABLE [dbo].[TempBillOutStandingsAudjustment] (
    [BillOutStandingsAudjustmentID]    BIGINT          IDENTITY (1, 1) NOT NULL,
    [PurchaseSaleBookHeaderID]         BIGINT          NULL,
    [VoucherNumber]                    NVARCHAR (8)    NOT NULL,
    [VoucherTypeCode]                  NVARCHAR (50)   NOT NULL,
    [VoucherDate]                      DATETIME        NOT NULL,
    [ReceiptPaymentID]                 BIGINT          NULL,
    [BillOutStandingsID]               BIGINT          NOT NULL,
    [AdjustmentVoucherNumber]          NVARCHAR (8)    NOT NULL,
    [AdjustmentVoucherTypeCode]        NVARCHAR (50)   NOT NULL,
    [AdjustmentVoucherDate]            DATETIME        NOT NULL,
    [LedgerType]                       NVARCHAR (50)   NULL,
    [LedgerTypeCode]                   NVARCHAR (10)   NULL,
    [Amount]                           DECIMAL (18, 2) NOT NULL,
    [ChequeNumber]                     NVARCHAR (10)   NULL,
    [OldBillOutStandingsAudjustmentID] BIGINT          NULL,
    [CreatedBy]                        NVARCHAR (50)   NOT NULL,
    [CreatedOn]                        DATETIME        NOT NULL,
    CONSTRAINT [PK_TempBillOutStandingsAudjustment] PRIMARY KEY CLUSTERED ([BillOutStandingsAudjustmentID] ASC),
    CONSTRAINT [FK_TempBillOutStandingsAudjustment_BillOutStandings1] FOREIGN KEY ([BillOutStandingsID]) REFERENCES [dbo].[BillOutStandings] ([BillOutStandingsID]),
    CONSTRAINT [FK_TempBillOutStandingsAudjustment_PurchaseSaleBookHeader1] FOREIGN KEY ([PurchaseSaleBookHeaderID]) REFERENCES [dbo].[PurchaseSaleBookHeader] ([PurchaseSaleBookHeaderID]),
    CONSTRAINT [FK_TempBillOutStandingsAudjustment_TempReceiptPayment] FOREIGN KEY ([ReceiptPaymentID]) REFERENCES [dbo].[TempReceiptPayment] ([ReceiptPaymentID])
);

