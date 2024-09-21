CREATE TABLE [dbo].[Configuration] (
    [ConfigID]    INT            IDENTITY (1, 1) NOT NULL,
    [ConfigKey]   NVARCHAR (50)  NOT NULL,
    [ConfigValue] NVARCHAR (500) NOT NULL,
    CONSTRAINT [PK_Configuration] PRIMARY KEY CLUSTERED ([ConfigKey] ASC)
);

