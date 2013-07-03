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
    public class CartItemMap:ClassMap<CartItem>
    {
        public CartItemMap()
        {
            Table("CartItems");
            Schema(DataConfiguration.SchemeName);

            Id(x => x.CartItemId);
            Map(x => x.OrderId);
            Map(x => x.ProductId);
            Map(x => x.Count);		

        }
    }
}
