using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Unico.Data.Entities;

namespace Unico.Data.Mappings
{
    public class CategoryMap:ClassMap<Category>
    {
        public CategoryMap()
        {
            Table("Categories");
            Schema(DataConfiguration.SchemeName);

            Id(x => x.CategoryId);
            Map(x => x.Description).Nullable();
            Map(x => x.Name);
            
            References<Department>(x => x.Department, "DepartmentId").Cascade.All();

            HasMany<Product>(x => x.Products).KeyColumn("CategoryId");
        }
    }
}
