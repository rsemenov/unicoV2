using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Unico.Data.Entities;

namespace Unico.Data.Mappings
{
    public class ProductMap:ClassMap<Product>
    {
        public ProductMap()
        {
            Table("Product");
            Schema("[unico].[dbo]");

            Id(x => x.ProductId);
            Map(x => x.ExternalId);
            Map(x => x.Name);
        }
    }
}
