using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Unico.Data.Entities;
using Unico.Data.Enum;
using Unico.Data.Interfaces;

namespace Unico.Email
{
    public interface IEmailGenerator
    {
        string Title { get; }
        string Body { get; }
        void Generate(EmailTypeEnum emailType, object model);
    }

    public class EmailGenerator : IEmailGenerator
    {
        private const string THEME_BEGIN_STRING = "<!---";
        private const string THEME_END_STRING = "--->";
        public string Title { get; protected set; }
        public string Body { get; protected set; }

        public static string GetEmailTemplateFile(EmailTypeEnum type)
        {
            return Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "bin\\EmailTemplates\\", type.ToString() + ".cshtml");
        }

        public void Generate(EmailTypeEnum emailType, object model)
        {
            var templateFile = GetEmailTemplateFile(emailType);
            var file = new FileInfo(templateFile);
            if (!file.Exists)
            {
                throw new FileNotFoundException(string.Format("Template file {0} not found", templateFile));
            }

            try
            {
                var templateContent = File.ReadAllText(file.FullName);
                int themeStart = templateContent.IndexOf(THEME_BEGIN_STRING);
                int themeEnd = templateContent.IndexOf(THEME_END_STRING, themeStart + THEME_BEGIN_STRING.Length);
                int length = themeEnd - (themeStart + THEME_BEGIN_STRING.Length);
                Title = templateContent.Substring(themeStart + THEME_BEGIN_STRING.Length, length);
                Body = RazorEngine.Razor.Parse(templateContent, model);                
            }
            catch (Exception e)
            {
                throw new Exception("Razor generation exception", e);
            }
        }
    }


    public interface IEmailSender
    {
        void Send(Guid accountId, EmailTypeEnum emailType, Object model);
        void SendInternal(Guid accountId, EmailTypeEnum emailType, Object model);
    }

    public class EmailSender : IEmailSender
    {
        public IRepository<Account> AccountsRepository { get; set; }
        public IRepository<Data.Entities.SenderEmail> EmailSenderRepository { get; set; }
        public IRepository<Data.Entities.EmailType> EmailTypeRepository { get; set; }
        public IRepository<Data.Entities.Email> EmailRepository { get; set; }
        public IEmailGenerator Generator { get; set; }

        public void Send(Guid accountId, EmailTypeEnum emailType, Object model)
        {
            var account = AccountsRepository.Find(x => x.ExternalId == accountId);
            var sender = EmailTypeRepository.Find(x => x.EmailTypeId == (int)emailType).Sender;
            Generator.Generate(emailType, model);
            var smtp = GetSmtpClient(sender);

            using (var message = new MailMessage(sender.Email, account.Email)
            {
                Subject = Generator.Title,
                Body = Generator.Body,
                IsBodyHtml = true
            })
            {
                smtp.Send(message);
            }

            EmailRepository.SaveOrUpdateAll(new Data.Entities.Email() { AccountId = account.ExternalId, EmailContent = Generator.Body, EmailTitle = emailType });
        }

        public void SendInternal(Guid accountId, EmailTypeEnum emailType, Object model)
        {
            var account = AccountsRepository.Find(x => x.ExternalId == accountId);
            var sender = EmailTypeRepository.Find(x => x.EmailTypeId == (int)emailType).Sender;
            Generator.Generate(emailType, model);
            var smtp = GetSmtpClient(sender);

            using (var message = new MailMessage(sender.Email, sender.Email)
            {
                Subject = Generator.Title,
                Body = Generator.Body,
                IsBodyHtml = true
            })
            {
                smtp.Send(message);
            }

            EmailRepository.SaveOrUpdateAll(new Data.Entities.Email() { AccountId = account.ExternalId, EmailContent = Generator.Body, EmailTitle = emailType });
        }

        public SmtpClient GetSmtpClient(SenderEmail sender)
        {             
            return new SmtpClient
            {
                Host = sender.Host,
                Port = sender.Port,
                EnableSsl = sender.EnableSsl,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(sender.Email, sender.Password)
            };
        }
    }

}
