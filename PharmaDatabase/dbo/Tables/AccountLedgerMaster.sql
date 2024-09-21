CREATE TABLE [dbo].[AccountLedgerMaster] (
    [AccountLedgerID]     INT             IDENTITY (1, 1) NOT NULL,
    [AccountLedgerCode]   NVARCHAR (10)   NOT NULL,
    [AccountLedgerName]   NVARCHAR (100)  NOT NULL,
    [AccountLedgerTypeId] INT             NOT NULL,
    [OpeningBalance]      DECIMAL (18, 2) NOT NULL,
    [CreditDebit]         CHAR (1)        NOT NULL,
    [AccountTypeId]       INT             NOT NULL,
    [DebitControlCodeID]  INT             NULL,
    [CreditControlCodeID] INT             NULL,
    [Status]              BIT             NOT NULL,
    [CreatedBy]           NVARCHAR (50)   NULL,
    [CreatedOn]           DATETIME        NULL,
    [ModifiedBy]          NVARCHAR (50)   NULL,
    [ModifiedOn]          DATETIME        NULL,
    [SalePurchaseTaxType] DECIMAL (18, 2) NULL,
    CONSTRAINT [PK_AccountLedgerMaster] PRIMARY KEY CLUSTERED ([AccountLedgerID] ASC),
    CONSTRAINT [FK_AccountLedgerMaster_AccountLedgerType] FOREIGN KEY ([AccountLedgerTypeId]) REFERENCES [dbo].[AccountLedgerType] ([AccountLedgerTypeID]),
    CONSTRAINT [FK_AccountLedgerMaster_AccountType] FOREIGN KEY ([AccountTypeId]) REFERENCES [dbo].[AccountType] ([AccountTypeID]),
    CONSTRAINT [FK_AccountLedgerMaster_CreditControlCode] FOREIGN KEY ([CreditControlCodeID]) REFERENCES [dbo].[AccountLedgerMaster] ([AccountLedgerID]),
    CONSTRAINT [FK_AccountLedgerMaster_DebitControlCode] FOREIGN KEY ([DebitControlCodeID]) REFERENCES [dbo].[AccountLedgerMaster] ([AccountLedgerID])
);

