USE [unico]
GO
/****** Object:  Table [dbo].[SenderEmails]    Script Date: 01/13/2014 18:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SenderEmails](
	[SenderEmailId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](500) NOT NULL,
	[Host] [nvarchar](500) NOT NULL,
	[Port] [int] NOT NULL,
	[EnableSsl] [bit] NOT NULL,
	[Password] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_SenderEmail] PRIMARY KEY CLUSTERED 
(
	[SenderEmailId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[SenderEmails] ON
INSERT [dbo].[SenderEmails] ([SenderEmailId], [Email], [Host], [Port], [EnableSsl], [Password]) VALUES (2, N'ocp.org.ua@gmail.com', N'smtp.gmail.com', 587, 1, N'dbrnjhbz1203')
SET IDENTITY_INSERT [dbo].[SenderEmails] OFF
/****** Object:  Table [dbo].[Orders]    Script Date: 01/13/2014 18:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[ExternalId] [uniqueidentifier] NOT NULL,
	[AccountId] [uniqueidentifier] NOT NULL,
	[Number] [varchar](30) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ClosedOn] [datetime] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmailTypes]    Script Date: 01/13/2014 18:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmailTypes](
	[EmailTypeId] [int] IDENTITY(1,1) NOT NULL,
	[SenderId] [int] NOT NULL,
 CONSTRAINT [PK_EmailType] PRIMARY KEY CLUSTERED 
(
	[EmailTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[EmailTypes] ON
INSERT [dbo].[EmailTypes] ([EmailTypeId], [SenderId]) VALUES (1, 2)
INSERT [dbo].[EmailTypes] ([EmailTypeId], [SenderId]) VALUES (2, 2)
SET IDENTITY_INSERT [dbo].[EmailTypes] OFF
/****** Object:  Table [dbo].[Emails]    Script Date: 01/13/2014 18:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Emails](
	[EmailId] [int] IDENTITY(1,1) NOT NULL,
	[AccountId] [uniqueidentifier] NOT NULL,
	[EmailContent] [nvarchar](max) NOT NULL,
	[EmailTitle] [nvarchar](max) NOT NULL,
	[SendOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Emails] PRIMARY KEY CLUSTERED 
(
	[EmailId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_SendOn_CreatedOn]    Script Date: 01/13/2014 18:16:50 ******/
ALTER TABLE [dbo].[Emails] ADD  CONSTRAINT [DF_SendOn_CreatedOn]  DEFAULT (getutcdate()) FOR [SendOn]
GO
/****** Object:  Default [DF_Orders_CreatedOn]    Script Date: 01/13/2014 18:16:50 ******/
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF_Orders_CreatedOn]  DEFAULT (getutcdate()) FOR [CreatedOn]
GO
