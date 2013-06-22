using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unico.Data.Interfaces;

namespace Unico.Data.Entities
{
    public class Product:IEntity
    {
        public virtual int ProductId { get; set; }
        public virtual Guid ExternalId { get; set; }
        public virtual string Name { get; set; }
    }
}
