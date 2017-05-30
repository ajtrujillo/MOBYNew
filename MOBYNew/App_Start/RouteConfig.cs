using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MOBYNew
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //this line enables attribute routing in the controllers
            routes.MapMvcAttributeRoutes();

            //custom route for testing; the attribute route is in ItemController
            //routes.MapRoute(
            //    name: "ItemByReleaseDate",
            //    url: "item/release/{year}/{month}/{day}",
            //    defaults: new {controller = "Item", action = "ByReleaseDate"});

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}
