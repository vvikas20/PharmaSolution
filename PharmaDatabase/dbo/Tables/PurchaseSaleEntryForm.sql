CREATE TABLE [dbo].[PurchaseSaleEntryForm] (
    [PurchaseSaleEntryFormID] INT           NOT NULL,
    [PurchaseSaleEntryTypeID] INT           NOT NULL,
    [PurchaseSaleFormName]    NVARCHAR (50) NOT NULL,
    [Status]                  BIT           NOT NULL,
    [CreatedBy]               NVARCHAR (50) NULL,
    [CreatedOn]               DATETIME      NULL,
    [ModifiedBy]              NVARCHAR (50) NULL,
    [ModifiedOn]              DATETIME      NULL,
    CONSTRAINT [PK_PurchaseSaleEntryForm] PRIMARY KEY CLUSTERED ([PurchaseSaleEntryFormID] ASC),
    CONSTRAINT [FK_PurchaseSaleEntryForm_PurchaseSaleEntryType] FOREIGN KEY ([PurchaseSaleEntryTypeID]) REFERENCES [dbo].[PurchaseSaleEntryType] ([PurchaseSaleEntryTypeID])
);

