using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Intsika.NET.Services
{
    public interface IEmailSender
    {
        Task SendEmail(string email, string subject, string message, string name);

        Task Execute(string apiKey, string subject, string message, string email, string name);
    }
}