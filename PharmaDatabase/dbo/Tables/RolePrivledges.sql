CREATE TABLE [dbo].[RolePrivledges] (
    [RolePrivledgeID] INT NOT NULL,
    [RoleId]          INT NOT NULL,
    [PrivledgeId]     INT NOT NULL,
    CONSTRAINT [PK_RolePrivledges] PRIMARY KEY CLUSTERED ([RolePrivledgeID] ASC),
    CONSTRAINT [FK_RolePrivledges_Privledges] FOREIGN KEY ([PrivledgeId]) REFERENCES [dbo].[Privledges] ([PrivledgeId]) ON DELETE CASCADE,
    CONSTRAINT [FK_RolePrivledges_Roles] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([RoleId]) ON DELETE CASCADE
);

