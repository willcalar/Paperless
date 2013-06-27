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
        #region Action Results

        public ActionResult Index()
        {
            ViewData["Message"] = "Bienvenido al Sistema Paperless!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        #endregion
    }
}
