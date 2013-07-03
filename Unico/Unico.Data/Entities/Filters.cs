using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unico.Data.Enum;
using Unico.Data.Interfaces;

namespace Unico.Data.Entities
{
    public class Filter:IEntity
    {
        public virtual int FilterId { get; set; }
        public virtual string ReferenceTable { get; set; }
        public virtual string ReferenceColumn { get; set; }
        public virtual FilterType Type { get; set; }
        public virtual bool IsAvailable { get; set; }
    }
}
