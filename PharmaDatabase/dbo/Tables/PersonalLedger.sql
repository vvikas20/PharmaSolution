CREATE TABLE [dbo].[PersonalLedger] (
    [PersonalLedgerId]        INT            IDENTITY (1, 1) NOT NULL,
    [PersonalLedgerCode]      NVARCHAR (10)  NOT NULL,
    [PersonalLedgerName]      NVARCHAR (50)  NOT NULL,
    [PersonalLedgerShortName] NVARCHAR (20)  NOT NULL,
    [Address]                 NVARCHAR (100) NOT NULL,
    [ContactPerson]           NVARCHAR (50)  NOT NULL,
    [Mobile]                  NVARCHAR (50)  NULL,
    [Pager]                   NVARCHAR (50)  NULL,
    [Fax]                     NVARCHAR (50)  NULL,
    [OfficePhone]             NVARCHAR (50)  NULL,
    [ResidentPhone]           NVARCHAR (50)  NULL,
    [EmailAddress]            NVARCHAR (100) NULL,
    [Status]                  BIT            NOT NULL,
    [CreatedBy]               NVARCHAR (50)  NULL,
    [CreatedOn]               DATETIME       NULL,
    [ModifiedBy]              NVARCHAR (50)  NULL,
    [ModifiedOn]              DATETIME       NULL,
    [PersonalLedgerShortDesc] NVARCHAR (20)  NULL,
    CONSTRAINT [PK_PersonalLedger] PRIMARY KEY CLUSTERED ([PersonalLedgerId] ASC)
);

