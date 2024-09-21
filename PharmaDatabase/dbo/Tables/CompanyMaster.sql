CREATE TABLE [dbo].[CompanyMaster] (
    [CompanyId]               INT            IDENTITY (1, 1) NOT NULL,
    [CompanyCode]             NVARCHAR (6)   NOT NULL,
    [CompanyName]             NVARCHAR (100) NOT NULL,
    [Status]                  BIT            NOT NULL,
    [IsDirect]                BIT            NOT NULL,
    [OrderPreferenceRating]   INT            NOT NULL,
    [BillingPreferenceRating] INT            NOT NULL,
    [StockSummaryRequired]    BIT            NOT NULL,
    [CreatedBy]               NVARCHAR (50)  NULL,
    [CreatedOn]               DATETIME       NULL,
    [ModifiedBy]              NVARCHAR (50)  NULL,
    [ModifiedOn]              DATETIME       NULL,
    CONSTRAINT [PK_CompanyMaster] PRIMARY KEY CLUSTERED ([CompanyId] ASC)
);

