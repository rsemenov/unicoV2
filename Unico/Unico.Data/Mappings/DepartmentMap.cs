using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Unico.Data.Entities;

namespace Unico.Data.Mappings
{
    public class DepartmentMap:ClassMap<Department>
    {
        public DepartmentMap()
        {
            Table("Departments");
            Schema(DataConfiguration.SchemeName);

            Id(x => x.DepartmentId);
            Map(x => x.Description);
            Map(x => x.Name);
            HasMany<Category>(x => x.Categories).KeyColumn("DepartmentId");
        }
    }
}
