using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRASMIBWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Achivements()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult Vision()
        {
            ViewBag.Message = "Your Vision page.";
            return View();
        }

        public ActionResult Mission()
        {
            ViewBag.Message = "Your Mission page.";
            return View();
        }


        public ActionResult Events()
        {
            ViewBag.Message = "Your Events page.";
            return View();
        }

        public ActionResult Gallery()
        {
            ViewBag.Message = "Your Gallery page.";
            return View();
        }

        public ActionResult NGO()
        {
            ViewBag.Message = "Your NGO page.";
            return View();
        }

        public ActionResult Blogs()
        {
            ViewBag.Message = "Your Blogs Page.";
            return View();
        }
    }
}