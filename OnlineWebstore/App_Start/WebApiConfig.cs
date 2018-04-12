using CacheCow.Server;
using Microsoft.Practices.Unity;
using OnlineWebstore.BusinessLayer.ServiceImplementation;
using OnlineWebstore.BusinessLayer.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace OnlineWebstore
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            var container = new UnityContainer();
            container.RegisterType<IProductManagerService, ProductManagerService>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
            //Configure HTTP Caching using Entity Tags (ETags)
            GlobalConfiguration.Configuration.MessageHandlers.Add(new  CachingHandler(GlobalConfiguration.Configuration));
        }
    }
}
