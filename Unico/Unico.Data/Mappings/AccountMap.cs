using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Unico.Data.Entities;

namespace Unico.Data.Mappings
{
    public class AccountMap:ClassMap<Account>
    {
        public AccountMap()
        {
            Table("Accounts");
            Schema(DataConfiguration.SchemeName);

            Id(x => x.AccountId);
            Map(x => x.Email);
            Map(x => x.Password);
            Map(x => x.Noise);
            Map(x => x.CreatedOn).ReadOnly();            
        }
    }
}
