/****** Script for SelectTopNRows command from SSMS  ******/
SELECT *
  FROM [unico].[dbo].[OcpProducts] op inner join unico.dbo.Products p on op.ProductId = p.ProductId
  where p.Image = '' 
  --and ([Cartridge] = ' PGI-450PGBK; PGI-450PGBK XL' or [Cartridge] = ' CLI-451BK; CLI-451BK XL')
  
  update unico.dbo.Products
  set [Image] = '/images/products/stmb_chernila.jpg'
  where [Cartridge] = ' PGI-450PGBK; PGI-450PGBK XL' or [Cartridge] = ' CLI-451BK; CLI-451BK XL'
  
  update unico.dbo.Products
  set [Image] = '/images/products/stmb_chernila-cyan.jpg'
  where [Cartridge] = ' CLI-451C; CLI-451C XL'
  
  update unico.dbo.Products
  set [Image] = '/images/products/stmb_chernila-magenta.jpg'
  where [Cartridge] = ' CLI-451M; CLI-451M XL'
  
  update unico.dbo.Products
  set [Image] = '/images/products/tmb_chernila-yellow.jpg'
  where [Cartridge] = ' CLI-451Y; CLI-451Y XL'