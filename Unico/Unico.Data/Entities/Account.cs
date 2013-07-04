using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unico.Data.Interfaces;

namespace Unico.Data.Entities
{
    public class Account : IEntity
    {
        public virtual int AccountId { get; set; }
        public virtual Guid ExternalId { get; set; }
        public virtual string Email { get; set; }
        public virtual byte[] Password { get; set; }
        public virtual string Noise { get; set; }
        public virtual DateTime CreatedOn { get; set; }
    }
}
