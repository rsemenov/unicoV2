using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unico.Data.Interfaces;

namespace Unico.Data.Entities
{
    public class SenderEmail : IEntity
    {
        public virtual int SenderEmailId { get; set; }
        public virtual string Email { get; set; }
        public virtual string Host { get; set; }
        public virtual int Port { get; set; }
        public virtual bool EnableSsl { get; set; }
        public virtual string Password { get; set; }
    }

    public class Email : IEntity
    {
        public virtual int EmailId { get; set; }
        public virtual Guid AccountId { get; set; }
        public virtual string EmailContent { get; set; }
        public virtual int EmailTitle { get; set; }
        public virtual DateTime SendOn { get; set; }
    }
}
