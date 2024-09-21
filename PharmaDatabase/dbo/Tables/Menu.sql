CREATE TABLE [dbo].[Menu] (
    [MenuID]      INT           NOT NULL,
    [MenuKey]     NVARCHAR (50) NOT NULL,
    [MenuName]    NVARCHAR (50) NOT NULL,
    [PrivledgeId] INT           NULL,
    [Status]      BIT           NOT NULL,
    CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED ([MenuID] ASC),
    CONSTRAINT [FK_Menu_Privledges] FOREIGN KEY ([PrivledgeId]) REFERENCES [dbo].[Privledges] ([PrivledgeId]) ON DELETE SET NULL ON UPDATE SET NULL
);

