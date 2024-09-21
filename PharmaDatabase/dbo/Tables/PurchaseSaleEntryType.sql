CREATE TABLE [dbo].[PurchaseSaleEntryType] (
    [PurchaseSaleEntryTypeID] INT           NOT NULL,
    [PurchaseSaleTypeCode]    CHAR (1)      NOT NULL,
    [PurchaseSaleTypeName]    NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_PurchaseSaleEntryType] PRIMARY KEY CLUSTERED ([PurchaseSaleEntryTypeID] ASC)
);

