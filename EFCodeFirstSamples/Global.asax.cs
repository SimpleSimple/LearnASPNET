using Autofac;
using Autofac.Integration.Mvc;
using EFCodeFirst.Data;
using EFCodeFirst.Repository;
using EFCodeFirst.Repository.Repository;
using EFCodeFirst.Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace EFCodeFirstSamples
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(Server.MapPath("~/Web.config")));

            var builder =RegisterService();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        //private ContainerBuilder RegisterService()
        //{
        //    ContainerBuilder builder = new ContainerBuilder();
        //    var baseType = typeof(IDependency);
        //    var assemblys = AppDomain.CurrentDomain.GetAssemblies();
        //    var allServices = assemblys.SelectMany(s => s.GetTypes())
        //        .Where(p => baseType.IsAssignableFrom(p) && p != baseType);

        //    builder.RegisterControllers(assemblys.ToArray());

        //    builder.RegisterAssemblyTypes(assemblys.ToArray())
        //        .Where(t => baseType.IsAssignableFrom(t) && t != baseType)
        //        .AsImplementedInterfaces().InstancePerLifetimeScope();
        //    return builder;
        //}

        private ContainerBuilder RegisterService()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<UserService>().As<IUserService>().SingleInstance();
            builder.RegisterType<UserRepository>().As<IUserRepository>().SingleInstance();
            builder.RegisterType<SystemRepository>().As<ISystemRepository>().SingleInstance();
            builder.RegisterType<SystemService>().As<ISystemService>().SingleInstance();

            //builder.RegisterAssemblyTypes(assemblys.ToArray())
            //    .Where(t => baseType.IsAssignableFrom(t) && t != baseType)
            //    .AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //var assemblys = AppDomain.CurrentDomain.GetAssemblies();
            //builder.RegisterControllers(assemblys.ToArray());
            return builder;
        }
    }
}
