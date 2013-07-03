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
    public class OrderMap:ClassMap<Order>
    {
        public OrderMap()
        {
            Table("Orders");
            Schema(DataConfiguration.SchemeName);

            Id(x => x.OrderId);
            Map(x => x.ExternalId);
            Map(x => x.AccountId);
            Map(x => x.CreatedOn);
			Map(x => x.ClosedOn).Nullable();

        }
    }
}
