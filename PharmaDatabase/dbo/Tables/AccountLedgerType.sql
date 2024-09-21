CREATE TABLE [dbo].[AccountLedgerType] (
    [AccountLedgerTypeID]             INT           NOT NULL,
    [AccountLedgerTypeName]           NVARCHAR (50) NOT NULL,
    [SystemName]                      NVARCHAR (50) NOT NULL,
    [Status]                          BIT           NOT NULL,
    [CodeStartWith]                   NVARCHAR (5)  NOT NULL,
    [IsUsedInAccountLedgerMasterForm] BIT           NOT NULL,
    CONSTRAINT [PK_AccountLedgerType] PRIMARY KEY CLUSTERED ([AccountLedgerTypeID] ASC)
);

