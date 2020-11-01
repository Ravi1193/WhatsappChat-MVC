using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhatsappChat.ViewModel;
using WhatsappChat.Models;
using WhatsAppApi;
namespace WhatsappChat.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        [HttpGet]
        public ActionResult Index()
        {
            HomeRepository repository = new HomeRepository();
            ViewBag.Emp = new SelectList(repository.EmpDetails(), "Mobile_NO", "Mobile_NO");
            return View();
        }

        [HttpPost]
        public ActionResult Index(HomeViewModel model)
        {
            HomeRepository repository = new HomeRepository();
            try
            {
                if (model.Mobile_NO != null)
                {
                    ViewBag.Emp = new SelectList(repository.EmpDetails(), "Mobile_NO", "Mobile_NO");
                    string From = "8104032389";
                  //  var link = "https://web.whatsapp.com/send?phone=" + model.Mobile_NO + "&amp;forceIntent=true&amp;load=loadInIOSExternalSafari";
                    WhatsApp wa = new WhatsApp(From, "866946038849", model.Name);

                    wa.OnConnectSuccess += () =>
                     {
                         wa.OnLoginSuccess += (mobileNo, Data) =>
                         {
                             wa.SendMessage(model.Mobile_NO, model.Message);
                         };
                     };

                    TempData["Messaage"] = "Message send";
                    return View();
                }
                else
                {
                    return View();

                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}