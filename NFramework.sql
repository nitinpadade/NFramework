
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 19-09-2019 12:22:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[MiddleName] [nvarchar](50) NULL,
	[Email] [nvarchar](150) NULL,
	[Mobile] [nvarchar](50) NULL,
	[UserName] [nvarchar](150) NULL,
	[Password] [nvarchar](150) NULL,
	[RoleId] [int] NULL,
	[DateOfBirth] [datetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Role] ON 

GO
INSERT [dbo].[Role] ([Id], [Name]) VALUES (1, N'Administrator')
GO
INSERT [dbo].[Role] ([Id], [Name]) VALUES (2, N'Employee')
GO
INSERT [dbo].[Role] ([Id], [Name]) VALUES (3, N'Accounts')
GO
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

GO
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [MiddleName], [Email], [Mobile], [UserName], [Password], [RoleId], [DateOfBirth]) VALUES (1, N'Nitin', N'Padade', N'L', N'abc.com', N'1007009001', N'abc.com', N'abc@1234', 1, CAST(N'1981-09-09T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [MiddleName], [Email], [Mobile], [UserName], [Password], [RoleId], [DateOfBirth]) VALUES (2, N'Bhooshan', N'Sane', N'', N'pqr.com', N'1241241414', N'pqr.com', N'pqr@123', 2, CAST(N'1987-07-09T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER DATABASE [School] SET  READ_WRITE 
GO
