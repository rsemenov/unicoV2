using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unico.Data.Interfaces;

namespace Unico.Data.Entities
{
    public class AccountProfile : Account
    {
        public virtual int ProfileId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
        public virtual string Phone { get; set; }
        public virtual string SecondPhone { get; set; }
        public virtual Company Company { get; set; }
    }
}
