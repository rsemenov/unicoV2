using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Unico.Data.Entities;

namespace Unico.Data.Mappings
{
    public class BrandMap:ClassMap<Brand>
    {
        public BrandMap()
        {
            Table("Brands");
            Schema(DataConfiguration.SchemeName);

            Id(x => x.BrandId);
            Map(x => x.Info);
            Map(x => x.Name);

            HasMany<Product>(x => x.Products).KeyColumn("BrandId");

        }
    }
}
