CREATE TABLE [dbo].[RecordType] (
    [RecordTypeId] INT           IDENTITY (1, 1) NOT NULL,
    [RecordType]   NVARCHAR (50) NOT NULL,
    [SystemName]   NVARCHAR (50) NOT NULL,
    [Status]       BIT           NOT NULL,
    CONSTRAINT [PK_RecordType] PRIMARY KEY CLUSTERED ([RecordTypeId] ASC)
);

