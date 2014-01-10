using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unico.Email
{
    public enum EmailType
    {
        OrderConfirmation,
        NewOrderCreated,
    }

    public interface IEmailGenerator
    {
        string Generate(EmailType emailType, object model);
    }

    public class EmailGenerator : IEmailGenerator
    {
        public static string GetEmailTemplateFile(EmailType type)
        {
            return Path.Combine("./EmailTemplates/", type.ToString() + ".cshtml");
        }

        public string Generate(EmailType emailType, object model)
        {
            var templateFile = GetEmailTemplateFile(emailType);
            if (!File.Exists(templateFile))
            {
                throw new FileNotFoundException(string.Format("Template file {0} not found", templateFile));
            }

            try
            {
                return RazorEngine.Razor.Parse(templateFile, model);
            }
            catch (Exception e)
            {
                throw new Exception("Razor generation exception", e);
            }
        }
    }


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
