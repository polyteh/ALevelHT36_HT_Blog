using BlogWebApi.App_Start;
using LightInject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BlogWebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            //вот это взял с https://www.lightinject.net/webapi/
            var container = new ServiceContainer();
            container.RegisterApiControllers();
            //register other services
            container.EnablePerWebRequestScope();
            container.EnableWebApi(GlobalConfiguration.Configuration);

            LightInjectConfig.Congigurate();
        }
    }
}
