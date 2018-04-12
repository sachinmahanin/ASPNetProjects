using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using OnlineWebstore.BusinessLayer.ServiceInterface;
using OnlineWebstore.BusinessLayer.ServiceImplementation;
using OnlineWebstore.Controllers;
using System.Web.Http.Controllers;

namespace OnlineWebstore
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {

        var container = BuildUnityContainer();
  
        DependencyResolver.SetResolver(new UnityDependencyResolver(container));

        return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {

            var container = new UnityContainer();
             
            RegisterTypes(container);

            return container;
   
        }

    public static void RegisterTypes(IUnityContainer container)
    {
            container.RegisterType<IProductManagerService, ProductManagerService>();
            container.RegisterType<IController, ProductController>("Product");
            container.RegisterType<IController, ProductCategoriesController>("ProductCategories");
            // Register controllers
           // container.RegisterType<IHttpController, OnlineWebstore.Controllers.WebAPI.ProductController>("Product");
        }
    }
}