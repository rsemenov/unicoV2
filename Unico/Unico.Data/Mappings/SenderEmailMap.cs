using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unico.Data.Entities;
using Unico.Data.Enum;

namespace Unico.Data.Mappings
{
    public class SenderEmailMap : ClassMap<SenderEmail>
    {
        public SenderEmailMap()
        {
            Table("SenderEmails");
            Schema(DataConfiguration.SchemeName);

            Id(x => x.SenderEmailId);
            Map(x => x.Email);
            Map(x => x.Password);
            Map(x => x.Host);
            Map(x => x.Port);
            Map(x => x.EnableSsl);

        }
    }

    public class EmailMap : ClassMap<Email>
    {
        public EmailMap()
        {
            Table("Emails");
            Schema(DataConfiguration.SchemeName);

            Id(x => x.EmailId);
            Map(x => x.AccountId);
            Map(x => x.EmailContent);
            Map(x => x.EmailTitle).CustomType<Data.Enum.EmailTypeEnum>();
            Map(x => x.SendOn).ReadOnly();
        }
    }

    public class EmailTypeMap : ClassMap<Data.Entities.EmailType>
    {
        public EmailTypeMap()
        {
            Table("EmailTypes");
            Schema(DataConfiguration.SchemeName);

            Id(x => x.EmailTypeId);
            References<SenderEmail>(x => x.Sender, "SenderId").Cascade.All();
        }
    }
}
