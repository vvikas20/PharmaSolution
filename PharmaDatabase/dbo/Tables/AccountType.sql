CREATE TABLE [dbo].[AccountType] (
    [AccountTypeID]        INT           NOT NULL,
    [AccountTypeName]      NVARCHAR (50) NOT NULL,
    [AccountTypeShortName] NVARCHAR (1)  NOT NULL,
    [Status]               BIT           NOT NULL,
    CONSTRAINT [PK_AccountType] PRIMARY KEY CLUSTERED ([AccountTypeID] ASC)
);

