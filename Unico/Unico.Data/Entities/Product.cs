using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unico.Data.Enum;
using Unico.Data.Interfaces;

namespace Unico.Data.Entities
{
    public class Product:IEntity
    {
        public virtual int ProductId { get; set; }
        public virtual Guid ExternalId { get; set; }
        public virtual Category Category { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual decimal Price { get; set; }
        public virtual ProductAvailability Availability { get; set; }
        public virtual string Cartridge { get; set; }
    }
}
