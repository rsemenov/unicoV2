using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unico.Data.Enum;
using Unico.Data.Interfaces;

namespace Unico.Data.Entities
{
    public class CartItem:IEntity
    {
        public virtual int CartItemId { get; set; }
        public virtual Guid OrderId { get; set; }
        public virtual Guid ProductId { get; set; }
		public virtual int Count { get; set; }
    }
}
