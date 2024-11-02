using Gallery.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
    public class MailSenderService : IMailSenderService
    {

        public void Send(string sendTo, string subject, string body)
        {
            using (MailMessage mailMessage = new MailMessage(ConfigurationManager.AppSettings["Username"], sendTo))
            {
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                using (SmtpClient smtpClient = new SmtpClient()
                {
                    Host = ConfigurationManager.AppSettings["Host"],
                    Port = int.Parse(ConfigurationManager.AppSettings["Port"]),
                    Credentials = new NetworkCredential(ConfigurationManager.AppSettings["Username"], ConfigurationManager.AppSettings["Password"]),
                    EnableSsl = true,
                })
                {
                    smtpClient.Send(mailMessage);
                }
            }
            //using (var smtpClient = new SmtpClient("smtp.mail.yahoo.com")
            //{
            //    Port = 587,
            //    Credentials = new NetworkCredential("demsona12@gmail.com", "csbaadqncsjggpkc"),
            //    EnableSsl = true
            //})
            //{
            //    smtpClient.Send(mailMessage);
            //}
        }
    }
}
