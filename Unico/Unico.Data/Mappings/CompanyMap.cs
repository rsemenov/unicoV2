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
    public class CompanyMap:ClassMap<Company>
    {
        public CompanyMap()
        {
            Table("Companies");
            Schema(DataConfiguration.SchemeName);

            Id(x => x.CompanyId);
            Map(x => x.Address);
            Map(x => x.CompanyName);
            Map(x => x.ContactName);
            Map(x => x.CreatedOn).ReadOnly();
            Map(x => x.EDRPOU);
            Map(x => x.Email);
            Map(x => x.INN);
            Map(x => x.Phone);
            Map(x => x.SecondPhone);
            Map(x => x.SertificateNumber);
        }
    }
}
