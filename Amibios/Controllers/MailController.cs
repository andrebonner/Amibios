using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Amibios.Controllers
{
    public class MailController : Controller
    {
        // GET: Mail
        public ActionResult Index()
        {
            NameValueCollection nvc = Request.Form;
            string name, email, message, url;
            name = nvc["name"];
            email = nvc["email"];
            message = nvc["message"];
            url = "/";
            try
            {
                SmtpClient smtpClient = new SmtpClient("smtpout.secureserver.net", 587)
                {
                    Credentials = new System.Net.NetworkCredential("info@gamescriptor.com", "Andbon02"),
                    UseDefaultCredentials = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = true,
                    Timeout = 200000000
                };
                //Setting From , To and CC
                MailMessage mail = new MailMessage
                {

                
                    From = new MailAddress("info@amibios.com", "Amibios")
                };
                mail.To.Add(new MailAddress(email,name));
                mail.CC.Add(new MailAddress("andre.s.bonner@gmail.com"));
                mail.IsBodyHtml = false;
                mail.Subject = "Contact Form";
                mail.Body = message;
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.Never;

                smtpClient.Send(mail);
                TempData["status"] = "success";
                TempData["text"] = "Successfully Sent Email";

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                TempData["status"] = "error";
                TempData["text"] = "Error Sending Email";
            }
            

            return Redirect(url);
        }
    }
}