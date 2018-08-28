using ForumSystem.Common.Constants;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ForumSystem.Common.Mapping;

namespace ForumSystem.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //var autoMapperConfig = new AutoMapperConfig();
            //autoMapperConfig.Execute(Assembly.GetExecutingAssembly());

            AutoMapperConfig.RegisterMappings(
               Assembly.Load(AssemblyConstants.Web),
               Assembly.Load(AssemblyConstants.WebInfrastructure));
        }
    }
}
