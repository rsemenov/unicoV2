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
        public virtual string Image { get; set; }
        public virtual ProductAvailability Availability { get; set; }
        public virtual string Cartridge { get; set; }
        public virtual IList<Cartrige> Cartriges { get; set; }
    }

    public class Cartrige:IEntity
    {
        public virtual int CartrigeId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Value { get; set; }
        public virtual IList<Product> Products { get; set; }
        public virtual IList<Printer> Printers { get; set; }
    }

    public class Printer : IEntity
    {
        public virtual int PrinterId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Value { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual IList<Cartrige> Cartriges { get; set; }
    }

}
