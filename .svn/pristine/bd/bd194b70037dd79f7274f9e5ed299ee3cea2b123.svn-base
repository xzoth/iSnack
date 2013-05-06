using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using iSnack.Web.API;
using iSnack.Web.API.Handlers;
using iSnack.Web.API.Filter;

namespace iSnack.Web.Service
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configuration.Filters.Add(new ValidationActionFilter());
            GlobalConfiguration.Configuration.Filters.Add(new WebApiExceptionFilter());
            //CORS Handler
            GlobalConfiguration.Configuration.MessageHandlers.Add(new CorsHandler());
            //HSTS Handler
            //GlobalConfiguration.Configuration.MessageHandlers.Add(new HSTSHandler());
            //HTTP Method Override Handler
            GlobalConfiguration.Configuration.MessageHandlers.Add(new XHttpMethodOverrideDelegatingHandler());
        }
    }
}