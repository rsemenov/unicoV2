USE [unico]
GO

ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Departments] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([DepartmentId])
GO

ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_Departments]
GO

-----------------------
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Brands] FOREIGN KEY([Brand])
REFERENCES [dbo].[Brands] ([BrandId])
GO

ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Brands]
GO

------------------------
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
GO

ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories]
GO


