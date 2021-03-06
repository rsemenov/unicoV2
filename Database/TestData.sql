USE [unico]
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 09/17/2013 10:04:01 ******/
SET IDENTITY_INSERT [dbo].[Brands] ON
INSERT [dbo].[Brands] ([BrandId], [Name], [Info]) VALUES (1, N'HP', N'hp inc')
INSERT [dbo].[Brands] ([BrandId], [Name], [Info]) VALUES (2, N'Cannon', N'cannon')
SET IDENTITY_INSERT [dbo].[Brands] OFF
/****** Object:  Table [dbo].[Departments]    Script Date: 09/17/2013 10:04:01 ******/
SET IDENTITY_INSERT [dbo].[Departments] ON
INSERT [dbo].[Departments] ([DepartmentId], [Name], [Description]) VALUES (1, N'Картриджи', N'Картриджи')
INSERT [dbo].[Departments] ([DepartmentId], [Name], [Description]) VALUES (2, N'Составляющие', N'ооо')
SET IDENTITY_INSERT [dbo].[Departments] OFF
/****** Object:  Table [dbo].[Categories]    Script Date: 09/17/2013 10:04:01 ******/
SET IDENTITY_INSERT [dbo].[Categories] ON
INSERT [dbo].[Categories] ([CategoryId], [DepartmentId], [Name], [Description]) VALUES (1, 1, N'Заправка картриджей', N'Заправка и регенирация картриджей')
INSERT [dbo].[Categories] ([CategoryId], [DepartmentId], [Name], [Description]) VALUES (2, 1, N'Лазерные картриджи', N'Лазерные картриджи')
INSERT [dbo].[Categories] ([CategoryId], [DepartmentId], [Name], [Description]) VALUES (3, 1, N'Струйные картриджи', N'Струйные')
SET IDENTITY_INSERT [dbo].[Categories] OFF
/****** Object:  Table [dbo].[Products]    Script Date: 09/17/2013 10:04:01 ******/
SET IDENTITY_INSERT [dbo].[Products] ON
INSERT [dbo].[Products] ([ProductId], [ExternalId], [CategoryId], [Name], [Description], [Price], [Brand], [Availability], [Cartridge]) VALUES (1, N'7126d768-f7f0-466c-b202-b32a50c9eb54', 1, N'Заправка', N'Заправка картриджа HP-1925', CAST(40.00 AS Decimal(10, 2)), 1, 1, N'HP-1925')
INSERT [dbo].[Products] ([ProductId], [ExternalId], [CategoryId], [Name], [Description], [Price], [Brand], [Availability], [Cartridge]) VALUES (2, N'7126d768-f7f0-466c-b202-b32a50c9eb55', 1, N'Заправка', N'Заправка картриджа HP-4045', CAST(40.00 AS Decimal(10, 2)), 1, 1, N'HP-4045')
SET IDENTITY_INSERT [dbo].[Products] OFF
