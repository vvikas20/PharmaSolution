CREATE TABLE [dbo].[AuditHistory] (
    [ID]         INT           IDENTITY (1, 1) NOT NULL,
    [CreatedAt]  DATETIME      NOT NULL,
    [UserName]   VARCHAR (250) NULL,
    [TableName]  VARCHAR (100) NULL,
    [ColumnName] VARCHAR (100) NULL,
    [OldValue]   VARCHAR (MAX) NULL,
    [NewValue]   VARCHAR (MAX) NULL,
    [Operation]  CHAR (1)      NULL,
    [PrimaryKey] VARCHAR (500) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

