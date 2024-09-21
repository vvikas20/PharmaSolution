CREATE TABLE [dbo].[Roles] (
    [RoleId]     INT           IDENTITY (1, 1) NOT NULL,
    [RoleName]   NVARCHAR (50) NOT NULL,
    [Status]     BIT           NOT NULL,
    [CreatedBy]  NVARCHAR (50) NULL,
    [CreatedOn]  DATETIME      NULL,
    [ModifiedBy] NVARCHAR (50) NULL,
    [ModifiedOn] DATETIME      NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED ([RoleId] ASC)
);

