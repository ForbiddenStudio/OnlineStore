using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Microsoft.Practices.Unity;
using OnlineStoreDomain;
using OnlineStoreRepository;

namespace OnlineStoreWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();


            container.RegisterType<DbContext, Store>(new HierarchicalLifetimeManager());
            container.RegisterType<IProductsRepository, ProductsRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ITypesRepository, TypeRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IRoleRepository, RoleRepository>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
            // Конфигурация и службы веб-API

            // Маршруты веб-API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
