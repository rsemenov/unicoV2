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
    public class TransactionMap:ClassMap<Transaction>
    {
        public TransactionMap()
        {
            Table("Transactions");
            Schema(DataConfiguration.SchemeName);

            Id(x => x.TransactionId);
            Map(x => x.OrderId);
            Map(x => x.Reference);
            Map(x => x.Amount);
            Map(x => x.TransactionType).CustomType<TransactionType>();
            Map(x => x.CreatedOn).ReadOnly();

        }
    }
}
