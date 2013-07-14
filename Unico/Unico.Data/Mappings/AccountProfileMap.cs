using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Unico.Data.Entities;

namespace Unico.Data.Mappings
{
    public class AccountProfileMap : SubclassMap<AccountProfile>
    {
        public AccountProfileMap()
        {
            Table("Profiles");
            Schema(DataConfiguration.SchemeName);

            KeyColumn("AccountId");
            Map(x => x.Address);
            Map(x => x.Name);
            Map(x => x.Phone);
            Map(x => x.SecondPhone);

            References<Company>(x => x.Company, "CompanyId").Cascade.All();

        }
    }
}
