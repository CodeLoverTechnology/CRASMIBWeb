using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRASMIBWeb.Controllers
{
    public class DiseasesController : Controller
    {
        // GET: Diseases
        public ActionResult Cancer()
        {
            return View();
        }
    }
}