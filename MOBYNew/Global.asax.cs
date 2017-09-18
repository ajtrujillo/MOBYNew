﻿using System.Web.Mvc;
using System.Data.Entity;
using System.Web.Optimization;
using System.Web.Routing;
using MOBYNew.Models;
using MOBYNew.App_Start;

namespace MOBYNew
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            MappingConfig.RegisterMaps();
        }
    }
}
