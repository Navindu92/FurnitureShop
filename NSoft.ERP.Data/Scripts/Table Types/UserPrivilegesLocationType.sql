USE [NERP]
GO

/****** Object:  UserDefinedTableType [dbo].[UserPrivilegesLocationType]    Script Date: 03/05/2017 9:30:55 PM ******/
CREATE TYPE [dbo].[UserPrivilegesLocationType] AS TABLE(
	[UserPrivilegesLocationID] [bigint] NULL,
	[UserID] [bigint] NOT NULL,
	[LocationID] [bigint] NOT NULL,
	[LocationName] [nvarchar](50) NOT NULL,
	[IsAllow] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[GroupOfCompanyID] [int] NOT NULL,
	[CreatedUser] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedUser] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NOT NULL
)
GO


