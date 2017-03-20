using Autofac;
using Autofac.Integration.Mvc;
using ntu.xzmcwjzs.Ioc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ntu.xzmcwjzs.WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //使用autofac 注入
            RegisterDependency();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
        }
        //依赖注入
        public static void RegisterDependency()
        {
            var builder = new ContainerBuilder();
            IocConfig.SetupResolveRules(builder);
            //builder.RegisterType<TestService>().As<ITestService>();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
