using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unico.Data.Enum;
using Unico.Data.Interfaces;

namespace Unico.Data.Entities
{
    public class Transaction:IEntity
    {
        public virtual int TransactionId { get; set; }
        public virtual Guid OrderId { get; set; }
        public virtual string Reference { get; set; }
		public virtual TransactionType TransactionType { get; set; }
		public virtual decimal Amount { get; set; }
		public virtual DateTime CreatedOn {get;set;}
    }
}
