using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Mvc5Template
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name:"Home",
                url:"home",
                defaults: new {controller = "Home", action="Index"}
                );
            routes.MapRoute(
                name: "About",
                url: "about",
                defaults: new {controller = "Home", action = "About"}
                );
            routes.MapRoute(
                name: "Contact",
                url: "contact",
                defaults: new {controller = "Home", action = "Contact"}
                );
            routes.MapRoute(
                name: "Getting Started",
                url:"aspnet/gettingstarted",
                defaults: new {controller="Home",action="GettingStarted"}
                );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
