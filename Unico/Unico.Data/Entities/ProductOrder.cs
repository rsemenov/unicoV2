using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unico.Data.Enum;
using Unico.Data.Interfaces;

namespace Unico.Data.Entities
{
    public class ProductOrder:IEntity
    {
        public virtual int ProductOrderId { get; set; }
        public virtual Guid OrderId { get; set; }
        public virtual Guid ProductId { get; set; }
		public virtual int Count { get; set; }
		public virtual decimal Price { get; set; }
		public virtual WorkType WorkType { get; set; }
		public virtual string Notes { get; set; }
		public virtual OrderStatus Status { get; set; }
        public virtual DateTime LastStatusUpdate { get; set; }
    }
}
