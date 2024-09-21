CREATE TABLE [dbo].[CustomerType] (
    [CustomerTypeId]        INT           IDENTITY (1, 1) NOT NULL,
    [CustomerType]          NVARCHAR (50) NOT NULL,
    [CustomerTypeShortName] CHAR (1)      NOT NULL,
    [Status]                BIT           NOT NULL,
    CONSTRAINT [PK_CustomerType] PRIMARY KEY CLUSTERED ([CustomerTypeId] ASC)
);

