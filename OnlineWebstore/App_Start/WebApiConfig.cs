using CacheCow.Server;
using Microsoft.Practices.Unity;
using Newtonsoft.Json.Serialization;
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
            //Enabling CORS
            var objEnableCorsAttribute = new System.Web.Http.Cors.EnableCorsAttribute("*","*","*");
            config.EnableCors(objEnableCorsAttribute);
            // if you want to indent the JSON DATA 
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            //if you want to have a camel case in property names then
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //Configure HTTP Caching using Entity Tags (ETags)
            GlobalConfiguration.Configuration.MessageHandlers.Add(new  CachingHandler(GlobalConfiguration.Configuration));
        }
    }
}
