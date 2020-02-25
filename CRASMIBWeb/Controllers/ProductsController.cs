using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRASMIBWeb.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Drugs()
        {
            return View();
        }
        public ActionResult Need_Personal_Assistance()
        {
            return View();
        }
        public ActionResult GOWRI()
        {
            return View();
        }
        public ActionResult Ojasy_Swarn_Prasan()
        {
            return View();
        }
    }
}