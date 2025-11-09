USE [NERP]
GO

/****** Object:  UserDefinedTableType [dbo].[UserPrivilegesType]    Script Date: 03/05/2017 9:31:12 PM ******/
CREATE TYPE [dbo].[UserPrivilegesType] AS TABLE(
	[UserPrivilegesID] [bigint] NULL,
	[UserID] [bigint] NOT NULL,
	[FormInfoID] [bigint] NOT NULL,
	[FormText] [nvarchar](20) NULL,
	[IsAccess] [bit] NOT NULL,
	[IsSave] [bit] NOT NULL,
	[IsRemove] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[GroupOfCompanyID] [int] NOT NULL,
	[CreatedUser] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedUser] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NOT NULL
)
GO


