using INVEON.Business.Abstract;
using INVEON.Business.Concrete;
using INVEON.Core.Entities;
using INVEON.Data.context;
using INVEON.Data.Repository;
using INVEON.Data.UnitOfWork;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Injection;
using Unity.Lifetime;

namespace INVEON.Ioc.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            RegisterTypes(container);
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
        public static void RegisterTypes(IUnityContainer container)
        {
            container.BindInRequestScope<IUnitOfWork, UnitOfWork>();

            container.BindInRequestScope<IRepository<Product>, Repository<Product>>();
            container.BindInRequestScope<IRepository<User>, Repository<User>>();
            container.BindInRequestScope<IRepository<Stock>, Repository<Stock>>();
            container.BindInRequestScope<IRepository<Stock>, Repository<Stock>>();

            container.BindInRequestScope<IProductService, ProductService>();
            container.BindInRequestScope<IUserService, UserService>();

        }


    }

    public static class IOCExtensions
    {
        public static void BindInRequestScope<T1, T2>(this IUnityContainer container) where T2 : T1
        {
            container.RegisterType<T1, T2>(new HierarchicalLifetimeManager());
        }

        public static void BindInSingletonScope<T1, T2>(this IUnityContainer container) where T2 : T1
        {
            container.RegisterType<T1, T2>(new ContainerControlledLifetimeManager());
        }
    }
}
