using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amibios.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.status = TempData["status"];
            ViewBag.text = TempData["text"];
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}