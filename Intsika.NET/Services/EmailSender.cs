using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Intsika.NET.Services
{
    public class EmailSender : IEmailSender
    {

        public EmailSender()
        {

        }
        public Task SendEmail(string email, string subject, string message, string name)
        {

            //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
            string apiKey = "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";
            return Execute(apiKey, subject, message, email, name);
        }

        public Task Execute(string apiKey, string subject, string message, string email, string name)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                //senders email needs to added here
                From = new EmailAddress("xodusdr@gmail.com", "Test"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress("xodusdr@gmail.com"));
            client.SendEmailAsync(msg);

            var msg2 = new SendGridMessage()
            {
                //senders email needs to added here
                From = new EmailAddress("xodusdr@gmail.com", "test"),
                Subject = "Confirmation Message Get In Touch",
                PlainTextContent = "<p>Hi " + name + "," + "</p> <p>Thank you for contacting us! We will get in contact with you shortly.</p><p>Regards</p><p>Hope Academy</p>",
                HtmlContent = "<p>Hi " + name + "," + "</p><p>Thank you for contacting us! We will get in contact with you shortly.</p><p>Regards</p><p>Insika</p>"
            };
            msg2.AddTo(new EmailAddress(email));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg2.SetClickTracking(false, false);



            return client.SendEmailAsync(msg2);
        }

    }
}