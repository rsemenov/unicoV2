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
    public class ProductOrderMap:ClassMap<ProductOrder>
    {
        public ProductOrderMap()
        {
            Table("ProductOrders");
            Schema(DataConfiguration.SchemeName);

            Id(x => x.ProductOrderId);
            Map(x => x.OrderId);
            Map(x => x.ProductId);
            Map(x => x.Count);
			Map(x => x.Price);
            Map(x => x.WorkType).CustomType<WorkType>();
			Map(x => x.OrderStatus).CustomType<OrderStatus>();
            Map(x => x.LastStatusUpdate);

        }
    }
}
