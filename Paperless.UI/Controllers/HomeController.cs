using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Paperless.UI.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Bienvenido al Sistema Paperless!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
