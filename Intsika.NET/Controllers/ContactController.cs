using Intsika.NET.Models;
using Intsika.NET.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SendGrid.Helpers.Mail;
using SendGrid;

namespace Intsika.NET.Controllers
{
    public class ContactController : Controller
    {
        public IEmailSender emailSender { get; }
        public ContactController()
        {
            emailSender = new EmailSender();
        }
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }
       
        [HttpPost]
        public async Task<ActionResult> SendEmail(ContactForm contactForm)
        {
            #region
            var variable = "" +
            "<tbody>" +
            "      <tr style=\"vertical-align:top\" valign=\"top\">" +
            "        <td style=\"word-break:break-word;vertical-align:top\" valign=\"top\">" +
            "          " +
            "          <div style=\"background-color:transparent\">" +
            "            <div class=\"m_-6869419450811405362block-grid\" style=\"min-width:320px;max-width:600px;word-wrap:break-word;word-break:break-word;Margin:0 auto;background-color:#ffffff\">" +
            "              <div style=\"border-collapse:collapse;display:table;width:100%;background-color:#ffffff\">" +
            "                " +
            "                " +
            "                <div class=\"m_-6869419450811405362col\" style=\"min-width:320px;max-width:600px;display:table-cell;vertical-align:top;width:600px\">" +
            "                  <div class=\"m_-6869419450811405362col_cont\" style=\"width:100%!important\">" +
            "                    " +
            "                    <div style=\"border-top:0px solid transparent;border-left:0px solid transparent;border-bottom:0px solid transparent;border-right:0px solid transparent;padding-top:5px;padding-bottom:5px;padding-right:0px;padding-left:0px\">" +
            "                      " +
            "                      " +
            "                      <div style=\"color:#555555;font-family:Open Sans,Helvetica Neue,Helvetica,Arial,sans-serif;line-height:1.2;padding-top:30px;padding-right:25px;padding-bottom:0px;padding-left:25px\">" +
            "                        <div style=\"line-height:1.2;font-size:12px;color:#555555;font-family:Open Sans,Helvetica Neue,Helvetica,Arial,sans-serif\">" +
            "                          <p style=\"margin:0;font-size:24px;line-height:1.2;word-break:break-word;margin-top:0;margin-bottom:0\">" +
            "                            <span style=\"font-size:24px\"><strong>New form submission</strong></span>" +
            "                          </p>" +
            "                        </div>" +
            "                      </div>" +
            "                      <div style=\"color:#000000;font-family:Open Sans,Helvetica Neue,Helvetica,Arial,sans-serif;line-height:1.5;padding-top:10px;padding-right:25px;padding-bottom:10px;padding-left:25px\">" +
            "                        <div style=\"line-height:1.5;font-size:12px;color:#000000;font-family:Open Sans,Helvetica Neue,Helvetica,Arial,sans-serif\">" +
            "                          <p style=\"margin:0;font-size:14px;line-height:1.5;word-break:break-word;margin-top:0;margin-bottom:0\">" +
            "                            <span style=\"color:#999999\">name</span>" +
            "                          </p>" +
            "                          <span style=\"margin:0;font-size:16px;line-height:1.5;word-break:break-word;margin-top:0;margin-bottom:0;font-size:16px\">" +
            "                            " +
            "                              " +
            $"                                {contactForm.FirstName} {contactForm.LastName}" +
            "                              " +
            "                            " +
            "                          </span>" +
            "                        </div>" +
            "                      </div>" +
            "                      " +
            "                      " +
            "                      " +
            "                      <div style=\"color:#000000;font-family:Open Sans,Helvetica Neue,Helvetica,Arial,sans-serif;line-height:1.5;padding-top:10px;padding-right:25px;padding-bottom:10px;padding-left:25px\">" +
            "                        <div style=\"line-height:1.5;font-size:12px;color:#000000;font-family:Open Sans,Helvetica Neue,Helvetica,Arial,sans-serif\">" +
            "                          <p style=\"margin:0;font-size:14px;line-height:1.5;word-break:break-word;margin-top:0;margin-bottom:0\">" +
            "                            <span style=\"color:#999999\">Email</span>" +
            "                          </p>" +
            "                          <span style=\"margin:0;font-size:16px;line-height:1.5;word-break:break-word;margin-top:0;margin-bottom:0;font-size:16px\">" +
            "                            " +
            "                              " +
            $"                                <a href=\"mailto:{contactForm.Email}\" target=\"_blank\">{contactForm.Email}</a>" +
            "                              " +
            "                            " +
            "                          </span>" +
            "                        </div>" +
            "                      </div>" +
            "                      " +
            "                      " +
            "                      " +
            "                      <div style=\"color:#000000;font-family:Open Sans,Helvetica Neue,Helvetica,Arial,sans-serif;line-height:1.5;padding-top:5px;padding-right:25px;padding-bottom:5px;padding-left:25px\">" +
            "                        <div style=\"line-height:1.5;font-size:12px;color:#000000;font-family:Open Sans,Helvetica Neue,Helvetica,Arial,sans-serif\">" +
            "                          <p style=\"margin:0;font-size:14px;line-height:1.5;word-break:break-word;margin-top:0;margin-bottom:0\">" +
            "                            <span style=\"color:#999999\">Phone Number</span>" +
            "                          </p>" +
            "                          <span style=\"margin:0;font-size:16px;line-height:1.5;word-break:break-word;margin-top:0;margin-bottom:0;font-size:16px\">" +
            "                            " +
            "                              " +
            $"                                {contactForm.Phone}" +
            "                              " +
            "                            " +
            "                          </span>" +
            "                        </div>" +
            "                      </div>" +
            "                      " +
            "                      " +
            "                      " +
            "                      <div style=\"color:#000000;font-family:Open Sans,Helvetica Neue,Helvetica,Arial,sans-serif;line-height:1.5;padding-top:10px;padding-right:25px;padding-bottom:10px;padding-left:25px\">" +
            "                        <div style=\"line-height:1.5;font-size:12px;color:#000000;font-family:Open Sans,Helvetica Neue,Helvetica,Arial,sans-serif\">" +
            "                          <p style=\"margin:0;font-size:14px;line-height:1.5;word-break:break-word;margin-top:0;margin-bottom:0\">" +
            "                            <span style=\"color:#999999\">message</span>" +
            "                          </p>" +
            "                          <span style=\"margin:0;font-size:16px;line-height:1.5;word-break:break-word;margin-top:0;margin-bottom:0;font-size:16px\">" +
            "                            " +
            "                              " +
            $"                                {contactForm.Message}" +
            "                              " +
            "                            " +
            "                          </span>" +
            "                        </div>" +
            "                      </div>" +
            "                      " +
            "                      " +
            "" +
            "                      " +
            "                    </div>" +
            "                    " +
            "                  </div>" +
            "                </div>" +
            "                " +
            "                " +
            "              </div>" +
            "            </div>" +
            "          </div>" +
            "          <div style=\"background-color:transparent\">" +
            "            <div class=\"m_-6869419450811405362block-grid\" style=\"min-width:320px;max-width:600px;word-wrap:break-word;word-break:break-word;Margin:0 auto;background-color:#ffffff\">" +
            "              <div style=\"border-collapse:collapse;display:table;width:100%;background-color:#ffffff\">" +
            "                " +
            "                " +
            "                <div class=\"m_-6869419450811405362col m_-6869419450811405362num8\" style=\"display:table-cell;vertical-align:top;max-width:320px;min-width:400px;width:400px\">" +
            "                  <div class=\"m_-6869419450811405362col_cont\" style=\"width:100%!important\">" +
            "                    " +
            "                    <div style=\"border-top:0px solid transparent;border-left:0px solid transparent;border-bottom:0px solid transparent;border-right:0px solid transparent;padding-top:15px;padding-bottom:5px;padding-right:15px;padding-left:15px\">" +
            "                      " +
            "                      " +
            "                      <div style=\"color:#999;font-family:Open Sans,Helvetica Neue,Helvetica,Arial,sans-serif;line-height:1.2;padding-top:10px;padding-right:10px;padding-bottom:10px;padding-left:10px\">" +
            "                        <div style=\"line-height:1.2;font-size:12px;color:#999;font-family:Open Sans,Helvetica Neue,Helvetica,Arial,sans-serif\">" +
            "                          <p style=\"margin:0;font-size:14px;line-height:1.2;word-break:break-word;margin-top:0;margin-bottom:0\">" +
            $"                            Submitted {DateTime.Now}</p>" +
            "                        </div>" +
            "                      </div>" +
            "                      " +
            "                      " +
            "                    </div>" +
            "                    " +
            "                  </div>" +
            "                </div>" +
            "              </div>" +
            "            </div>" +
            "          </div>" +
            "          <div style=\"background-color:transparent\">" +
            "            <div class=\"m_-6869419450811405362block-grid\" style=\"min-width:320px;max-width:600px;word-wrap:break-word;word-break:break-word;Margin:0 auto;background-color:#ffffff\">" +
            "              <div style=\"border-collapse:collapse;display:table;width:100%;background-color:#ffffff\">" +
            "                " +
            "                " +
            "                <div class=\"m_-6869419450811405362col\" style=\"min-width:320px;max-width:600px;display:table-cell;vertical-align:top;width:600px\">" +
            "                  <div class=\"m_-6869419450811405362col_cont\" style=\"width:100%!important\">" +
            "                    " +
            "                    <div style=\"border-top:0px solid transparent;border-left:0px solid transparent;border-bottom:0px solid transparent;border-right:0px solid transparent;padding-top:25px;padding-bottom:5px;padding-right:0px;padding-left:0px\">" +
            "                      " +
            "                      <div align=\"left\" style=\"padding-right:25px;padding-left:25px\">" +
            "                        " +
            /*"                        <div style=\"font-size:1px;line-height:10px\">&nbsp;</div><a href=\"https://formspree.io\" style=\"outline:none\" target=\"_blank\" data-saferedirecturl=\"images/logo.png\"><img alt=\"Formspree logo\" border=\"0\" src=\"~images/logo.png\" style=\"text-decoration:none;height:auto;border:0;width:100%;max-width:180px;display:block\" title=\"Formspree logo\" width=\"180\" class=\"CToWUd\"></a>" +*/
            "                        <div style=\"font-size:1px;line-height:10px\">&nbsp;</div>" +
            "                        " +
            "                      </div>" +
            "                      " +
            "                    </div>" +
            "                    " +
            "                  </div>" +
            "                </div>" +
            "                " +
            "                " +
            "              </div>" +
            "            </div>" +
            "          </div>" +
            "        </td>" +
            "      </tr>" +
            "    </tbody></center>" +
            "";
            #endregion
            await emailSender.SendEmail(contactForm.Email, "New Submission From Contact Form", variable, contactForm.FirstName);
            return RedirectToAction("Index");
        }
    }
}