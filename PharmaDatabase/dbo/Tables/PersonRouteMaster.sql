CREATE TABLE [dbo].[PersonRouteMaster] (
    [PersonRouteID]   INT            IDENTITY (1, 1) NOT NULL,
    [PersonRouteCode] NVARCHAR (15)  NOT NULL,
    [RecordTypeId]    INT            NULL,
    [PersonRouteName] NVARCHAR (100) NOT NULL,
    [Status]          BIT            NOT NULL,
    [CreatedBy]       NVARCHAR (50)  NULL,
    [CreatedOn]       DATETIME       NULL,
    [ModifiedBy]      NVARCHAR (50)  NULL,
    [ModifiedOn]      DATETIME       NULL,
    CONSTRAINT [PK_PersonRouteMaster] PRIMARY KEY CLUSTERED ([PersonRouteID] ASC),
    CONSTRAINT [FK_PersonRouteMaster_RecordType] FOREIGN KEY ([RecordTypeId]) REFERENCES [dbo].[RecordType] ([RecordTypeId])
);

