CREATE TABLE [dbo].[PersonLedgerType] (
    [PersonTypeId] INT          IDENTITY (1, 1) NOT NULL,
    [PersonType]   VARCHAR (20) NOT NULL,
    [Status]       BIT          NOT NULL,
    CONSTRAINT [PK_PersonType] PRIMARY KEY CLUSTERED ([PersonTypeId] ASC)
);

