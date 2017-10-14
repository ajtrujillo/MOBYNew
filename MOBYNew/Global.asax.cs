using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using MOBYNew.App_Start;
using System.Web.Optimization;

namespace MOBYNew
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            MappingConfig.RegisterMaps();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
