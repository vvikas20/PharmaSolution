CREATE TABLE [dbo].[FirmProperties] (
    [ParamName]  NVARCHAR (100) NOT NULL,
    [ParamValue] NVARCHAR (200) NOT NULL,
    CONSTRAINT [PK_FirmProperties] PRIMARY KEY CLUSTERED ([ParamName] ASC)
);

