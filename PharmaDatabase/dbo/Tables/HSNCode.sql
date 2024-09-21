CREATE TABLE [dbo].[HSNCode] (
    [HSNID]          INT           IDENTITY (1, 1) NOT NULL,
    [HSNCode]        NVARCHAR (18) NOT NULL,
    [HSNDescription] NVARCHAR (50) NULL,
    [CreatedBy]      NVARCHAR (50) NULL,
    [CreatedOn]      DATETIME      NULL,
    [ModifiedBy]     NVARCHAR (50) NULL,
    [ModifiedOn]     DATETIME      NULL,
    CONSTRAINT [PK_HSNCode] PRIMARY KEY CLUSTERED ([HSNCode] ASC)
);

