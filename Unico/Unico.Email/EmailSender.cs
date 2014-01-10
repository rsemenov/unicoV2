using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unico.Email
{
    public interface IEmailSender
    {
        void Send(string emailsTo, string emailFrom, string content, string title);
    }

    public class EmailSender : IEmailSender
    {  
        public void Send(string emailsTo, string emailFrom, string content, string title)
        {
            
        }
    }

}
