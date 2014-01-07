using FluentNHibernate.Mapping;
using Unico.Data.Entities;

namespace Unico.Data.Mappings
{
    public class CartrigeMap : ClassMap<Cartrige>
    {
        public CartrigeMap()
        {
            Table("Cartriges");
            Schema(DataConfiguration.SchemeName);

            Id(x => x.CartrigeId);
            Map(x => x.Name);
            Map(x => x.Value);

            HasManyToMany(x => x.Printers)
                .Cascade.All()
                .Inverse()
                .Table("PrinterCartrige")
                .ParentKeyColumn("CartrigeId")
                .ChildKeyColumn("PrinterId");

            HasManyToMany(x => x.Products)
                .Cascade.All()
                .Inverse()
                .Table("ProductCartrige")
                .ChildKeyColumn("ProductId")
                .ParentKeyColumn("CartrigeId");
        }
    }
}