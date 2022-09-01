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
            // lauras key=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
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
                From = new EmailAddress("info@intsikacommunityprojects.org.za", "Contact"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress("info@intsikacommunityprojects.org.za"));
           

            var msg2 = new SendGridMessage()
            {
                //senders email needs to added here
                From = new EmailAddress("info@intsikacommunityprojects.org.za", "Confirmation"),
                Subject = "Confirmation Message Get In Touch",
                PlainTextContent = "<p>Hi " + name + "," + "</p> <p>Thank you for contacting us! We will get in contact with you shortly.</p><p>Regards</p><p>Hope Academy</p>",
                HtmlContent = "<p>Hi " + name + "," + "</p><p>Thank you for contacting us! We will get in contact with you shortly.</p><p>Regards</p><p>Intsika</p>"
            };
            msg2.AddTo(new EmailAddress(email));
            client.SendEmailAsync(msg2);

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg2.SetClickTracking(false, false);



            return client.SendEmailAsync(msg);
        }

    }
}