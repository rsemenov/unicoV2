SELECT p.Image
  FROM [unico].[dbo].[OcpProducts] op inner join unico.dbo.Products p on op.ProductId = p.ProductId 
  
  UPDATE unico.dbo.Products
  SET [Image] = REPLACE([Image],'stmb','tmb')
  