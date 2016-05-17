using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5Template.Controllers
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

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult QuickSearch()
        {
            var artists = new { };
            //var artists = siteDB.Albums.Where(x => x.Artist.Name.Contains(q)).ToList().Select(x => x.Artist.Name);
            //TODO: Uncoment this when database has been stablished
            return Json(artists, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GettingStarted()
        {
            return View();
        }
    }
}