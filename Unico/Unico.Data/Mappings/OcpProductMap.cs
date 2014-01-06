using FluentNHibernate.Mapping;
using Unico.Data.Entities;

namespace Unico.Data.Mappings
{
    public class OcpProductMap : SubclassMap<OcpProduct>
    {
        public OcpProductMap()
        {
            Table("OcpProducts");
            Schema(DataConfiguration.SchemeName);

            KeyColumn("ProductId");
            Map(x => x.Color);
            Map(x => x.Key).Column("[Key]");
            Map(x => x.Weight);
        }
    }
}