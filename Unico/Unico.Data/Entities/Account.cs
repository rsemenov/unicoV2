using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unico.Data.Enum;
using Unico.Data.Interfaces;

namespace Unico.Data.Entities
{
    public class Account : IEntity
    {
        public virtual int AccountId { get; set; }
        public virtual Guid ExternalId { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual AccountRole Role { get; set; }
        public virtual DateTime CreatedOn { get; set; }
    }
}
