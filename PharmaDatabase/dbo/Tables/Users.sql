CREATE TABLE [dbo].[Users] (
    [UserId]     INT           IDENTITY (1, 1) NOT NULL,
    [Username]   NVARCHAR (50) NOT NULL,
    [Password]   NVARCHAR (50) NOT NULL,
    [FirstName]  NVARCHAR (50) NOT NULL,
    [LastName]   NVARCHAR (50) NULL,
    [Status]     BIT           NOT NULL,
    [CreatedBy]  NVARCHAR (50) NOT NULL,
    [CreatedOn]  DATETIME      NOT NULL,
    [ModifiedBy] NVARCHAR (50) NULL,
    [ModifiedOn] DATETIME      NULL,
    [IsSysAdmin] BIT           NOT NULL,
    [RoleID]     INT           NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserId] ASC),
    CONSTRAINT [FK__Users__RoleID__5C37ACAD] FOREIGN KEY ([RoleID]) REFERENCES [dbo].[Roles] ([RoleId])
);

