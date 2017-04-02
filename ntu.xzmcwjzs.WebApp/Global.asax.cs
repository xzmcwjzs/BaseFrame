using Autofac;
using Autofac.Integration.Mvc;
using ntu.xzmcwjzs.Core;
using ntu.xzmcwjzs.WebApp.Common.LuceneHelper;
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
            //从配置文件读取log4net的配置，然后进行一个初始化工作。
            log4net.Config.XmlConfigurator.Configure();
            //开启线程扫描 Lucene队列数据
            IndexManager.GetInstance().StartThread();


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

            builder.RegisterControllers(Assembly.GetExecutingAssembly());//注册mvc容器的实现  

            var container = builder.Build();//Build()方法是表示：创建一个容器
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));//注册MVC容器
        }
    }
}
