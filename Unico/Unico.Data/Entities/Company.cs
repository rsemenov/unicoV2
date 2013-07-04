using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unico.Data.Interfaces;

namespace Unico.Data.Entities
{
    public class Company : IEntity
    {
        public virtual int CompanyId { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual string ContactName { get; set; }
        public virtual string EDRPOU { get; set; }
        public virtual string INN { get; set; }
        public virtual string SertificateNumber { get; set; }
        public virtual string Address { get; set; }
        public virtual string Email { get; set; }
        public virtual string Phone { get; set; }
        public virtual string SecondPhone { get; set; }
        public virtual DateTime CreatedOn { get; set; }
    }
}
