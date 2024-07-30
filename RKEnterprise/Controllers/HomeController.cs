using System.Web.Mvc;
using RKEnterprise.Models;
using System.Net.Mail;
using System.IO;

namespace RKEnterprise.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Career()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Career(CareerModel model)
        {
            if (ModelState.IsValid)
            {
                var fileExtension = Path.GetExtension(model.CV.FileName).ToLower();
                if (fileExtension != ".pdf" && fileExtension != ".doc" && fileExtension != ".docx")
                {
                    ModelState.AddModelError("CV", "Please upload a valid CV file in PDF or Word format.");
                    return View(model);
                }

                // Save the CV file
                var fileName = Path.GetFileName(model.CV.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/Uploads"), fileName);
                model.CV.SaveAs(path);

                // Send email
                SendEmail(model);

                // Redirect to Thank You page
                return RedirectToAction("ThankYou");
            }
            else
            {
                ModelState.AddModelError("CV", "CV is required.");
            }
            return View(model);
        }

        public ActionResult ThankYou()
        {
            return View();
        }

        private void SendEmail(CareerModel model)
        {
            var fromAddress = "justiceforall1897@gmail.com";
            var toAddress = "akashsao2@gmail.com";
            const string subject = "New Career Application";
            string body = $"Name: {model.Name}\nEmail: {model.Email}\nPhone Number: {model.PhoneNumber}\nMessage: {model.Message}";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(fromAddress, "rgkkmtiezhjynvqt")
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                // Attach CV
                if (model.CV != null && model.CV.ContentLength > 0)
                {
                    var stream = model.CV.InputStream;
                    var attachment = new Attachment(stream, model.CV.FileName);
                    message.Attachments.Add(attachment);
                }

                smtp.Send(message);
            }
        }
    }
}
