CREATE TABLE [dbo].[VoucherType] (
    [VoucherTypeID]   INT            IDENTITY (1, 1) NOT NULL,
    [VoucherTypeName] NVARCHAR (100) NOT NULL,
    [VoucherTypeCode] NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_VoucherType] PRIMARY KEY CLUSTERED ([VoucherTypeCode] ASC)
);

