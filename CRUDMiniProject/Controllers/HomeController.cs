using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDMiniProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Message = "Index";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact";
            return View();
        }
    }
}