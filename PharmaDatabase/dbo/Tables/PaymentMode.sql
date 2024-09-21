CREATE TABLE [dbo].[PaymentMode] (
    [PaymentModeID]     INT           IDENTITY (1, 1) NOT NULL,
    [PaymentModeSymbol] NCHAR (1)     NOT NULL,
    [PaymentModeName]   NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_PaymentMode] PRIMARY KEY CLUSTERED ([PaymentModeID] ASC)
);

