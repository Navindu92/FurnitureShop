USE [NERP]
GO

/****** Object:  Table [dbo].[ItemSync]    Script Date: 27/07/2018 06:22:45 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ItemSync](
	[IDX] [bigint] IDENTITY(1,1) NOT NULL,
	[ItemID] [bigint] NOT NULL,
	[ItemCode] [nvarchar](20) NULL,
	[BarCode] [nvarchar](50) NULL,
	[ReferenceCode] [nvarchar](50) NULL,
	[ItemName] [nvarchar](60) NULL,
	[NameOnInvoice] [nvarchar](150) NULL,
	[CategoryID] [bigint] NOT NULL,
	[SubCategory1ID] [bigint] NOT NULL,
	[SubCategory2ID] [bigint] NOT NULL,
	[BrandID] [bigint] NOT NULL,
	[ReOrderLevel] [bigint] NOT NULL,
	[ReOrderQty] [bigint] NOT NULL,
	[SellingPrice] [decimal](18, 2) NOT NULL,
	[CostPrice] [decimal](18, 2) NOT NULL,
	[MarginPercentage] [decimal](18, 2) NOT NULL,
	[MaximumPrice] [decimal](18, 2) NOT NULL,
	[MinimumPrice] [decimal](18, 2) NOT NULL,
	[FixedDiscountPercentage] [decimal](18, 2) NOT NULL,
	[ItemImage] [varbinary](max) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[GroupOfCompanyID] [int] NOT NULL,
	[CreatedUser] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedUser] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


