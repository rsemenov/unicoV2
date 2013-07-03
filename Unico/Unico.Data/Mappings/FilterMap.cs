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
    public class FilterMap:ClassMap<Filter>
    {
        public FilterMap()
        {
            Table("Filters");
            Schema(DataConfiguration.SchemeName);

            Id(x => x.FilterId);
            Map(x => x.ReferenceTable);
            Map(x => x.ReferenceColumn);
            Map(x => x.Type).CustomType<FilterType>();
			Map(x => x.IsAvailable);

        }
    }
}
