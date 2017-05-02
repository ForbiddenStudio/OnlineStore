using System.Data.Entity;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Practices.Unity;
using OnlineStoreDomain;
using OnlineStoreRepository;
using OnlineStoreService;
using Unity.Mvc5;

namespace OnlineStore
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<DbContext, Store>(new HierarchicalLifetimeManager());
            container.RegisterType<IProductsRepository, ProductRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ITypesRepository, TypeRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ITypeService, TypeService>(new HierarchicalLifetimeManager());
            // e.g. container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}