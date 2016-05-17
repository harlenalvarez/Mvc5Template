using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5Template.Controllers
{
    public class CustomAttributesController : Controller
    {
        // GET: CustomAttributes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Validation()
        {
            return View();
        }
    }
}