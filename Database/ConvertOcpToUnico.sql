create table #temp (
ExternalId uniqueidentifier, 
CategoryId int, 
Name nvarchar(MAX), 
[Description] nvarchar(MAX), 
Price decimal(10,2), 
Brand int, 
Availability int, 
Cartridge nvarchar(MAX), 
[Image] nvarchar(MAX),
[Key] nvarchar(100),
Color nvarchar(100),
[Weight] int)

create table #carts (OcpProductId int, Cartridges nvarchar(max))

insert into #carts (OcpProductId, Cartridges) 
SELECT p.OcpProductId,
    STUFF
    ((
            SELECT 
                '; ' +c.Name
            FROM
                OCP.dbo.Cartriges c inner join OCP.dbo.OcpProductCartrige pc
                on c.CartrigeId = pc.CartrigeId
            WHERE
                pc.OcpProductId = p.OcpProductId
            FOR XML PATH('')
        )
    ,1,1,'') AS Cartridges
FROM OCP.dbo.OcpProduct p
order by p.OcpProductId

insert into #temp
select ExternalId, 4 as CategoryId, Name, [Description], Price, 
7 as Brand, 1 as Availability, #carts.Cartridges as Cartridge, [Image], 
ocp.[Key], ocp.Color, p.[Weight]
from OCP.dbo.Product p 
inner join OCP.dbo.OcpProduct ocp on p.OcpProduct = ocp.OcpProductId
inner join #carts on p.OcpProduct = #carts.OcpProductId

insert into unico.dbo.Products
select ExternalId, CategoryId, Name, [Description], Price, 
Brand, Availability, Cartridge, [Image] 
from #temp

insert into unico.dbo.OcpProducts
select p.[ProductId], [Key], [Color], [Weight]
from #temp inner join unico.dbo.Products p on #temp.ExternalId = p.ExternalId

drop table #carts
drop table #temp

select * from unico.dbo.Products p inner join unico.dbo.OcpProducts op on p.ProductId = op.ProductId

Insert into unico.dbo.ProductCartrige
  Select up.ProductId, opc.CartrigeId
  From OCP.dbo.OcpProductCartrige opc
  inner join OCP.dbo.OcpProduct op on opc.OcpProductId=op.OcpProductId
  inner join OCP.dbo.Product p on p.OcpProduct = op.OcpProductId
  inner join unico.dbo.Products up on p.ExternalId=up.ExternalId
  Order by up.ProductId
  
