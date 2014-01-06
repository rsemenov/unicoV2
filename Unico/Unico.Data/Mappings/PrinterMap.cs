using FluentNHibernate.Mapping;
using Unico.Data.Entities;

namespace Unico.Data.Mappings
{
    public class PrinterMap : ClassMap<Printer>
    {
        public PrinterMap()
        {
            Table("Printers");
            Schema(DataConfiguration.SchemeName);

            Id(x => x.PrinterId);
            Map(x => x.Name);
            Map(x => x.Value);

            References(x => x.Brand, "BrandId").Cascade.All();

            HasManyToMany(x => x.Cartriges)
                .Cascade.All()
                .Table("PrinterCartrige")
                .ChildKeyColumn("CartrigeId")
                .ParentKeyColumn("PrinterId");
        }
    }
}