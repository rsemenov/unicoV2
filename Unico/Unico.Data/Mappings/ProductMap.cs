using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Unico.Data.Entities;
using Unico.Data.Enum;

namespace Unico.Data.Mappings
{
    public class ProductMap:ClassMap<Product>
    {
        public ProductMap()
        {
            Table("Products");
            Schema(DataConfiguration.SchemeName);

            Id(x => x.ProductId);
            Map(x => x.Description).Nullable();
            Map(x => x.Name);
            Map(x => x.Price);
            Map(x => x.ExternalId);
            Map(x => x.Availability).CustomType<ProductAvailability>();
            Map(x => x.Cartridge).Nullable();

            References<Category>(x => x.Category, "CategoryId");

            References<Brand>(x => x.Brand, "Brand").Cascade.All();
        }
    }
}
