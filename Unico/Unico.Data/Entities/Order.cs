using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unico.Data.Enum;
using Unico.Data.Interfaces;

namespace Unico.Data.Entities
{
    public class Order:IEntity
    {
        public virtual int OrderId { get; set; }
        public virtual Guid ExternalId { get; set; }
        public virtual Guid AccountId { get; set; }
        public virtual string Number { get; set; }
        public virtual DateTime CreatedOn { get; set; }
        public virtual DateTime? ClosedOn { get; set; }
    }
}
