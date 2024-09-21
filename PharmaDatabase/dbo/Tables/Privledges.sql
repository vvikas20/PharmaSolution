CREATE TABLE [dbo].[Privledges] (
    [PrivledgeId]    INT            IDENTITY (1, 1) NOT NULL,
    [PriviledgeName] NVARCHAR (50)  NOT NULL,
    [ControlName]    NVARCHAR (100) NULL,
    [Status]         BIT            NOT NULL,
    [CreatedBy]      NVARCHAR (50)  NULL,
    [CreatedOn]      DATETIME       NULL,
    [ModifiedBy]     NVARCHAR (50)  NULL,
    [ModifiedOn]     DATETIME       NULL,
    CONSTRAINT [PK_Privledges] PRIMARY KEY CLUSTERED ([PrivledgeId] ASC)
);

