using System.Configuration;
using System.Threading;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Future3.Services;

namespace Future3
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var shouldRun = ConfigurationManager.AppSettings["run-service"];
            if (shouldRun != null && shouldRun.ToLower() == "true")
            {
                var service = new TimeMachineService();
                ThreadPool.QueueUserWorkItem(x => service.Run());
            }
        }
    }
}