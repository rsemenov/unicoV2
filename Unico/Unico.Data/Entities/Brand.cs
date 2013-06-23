using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unico.Data.Interfaces;

namespace Unico.Data.Entities
{
    public class Brand:IEntity
    {
        public virtual int BrandId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Info { get; set; }
    }
}
