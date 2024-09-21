CREATE TABLE [dbo].[RateType] (
    [RateTypeId]   INT           NOT NULL,
    [RateTypeName] NVARCHAR (50) NOT NULL,
    [SystemName]   NVARCHAR (50) NOT NULL,
    [Status]       BIT           NOT NULL,
    CONSTRAINT [PK_InterestType] PRIMARY KEY CLUSTERED ([RateTypeId] ASC)
);

