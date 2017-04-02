using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ntu.xzmcwjzs.Core
{
    public partial class IocConfig
    {
        public static void SetupResolveRules(ContainerBuilder builder)
        {
            //builder.RegisterType<TestService>().As<ITestService>();

            //如果有web类型，请使用如下获取Assenbly方法(获取所有需要用到的程序集，放到list中)   
            //用GetReferencedAssemblies方法获取当前应用程序下所有的程序集  

            /*
            var assemblys = BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToList(); 
            builder.RegisterAssemblyTypes(assemblys.ToArray())
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();
                */
            var assemblyBLL = Assembly.Load("ntu.xzmcwjzs.BLL");

            builder.RegisterAssemblyTypes(assemblyBLL)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();//将找到的类和对应的接口放入IOC容器

            var assemblyDAL = Assembly.Load("ntu.xzmcwjzs.DAL");
            builder.RegisterAssemblyTypes(assemblyDAL)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();

            //builder.RegisterAssemblyTypes(assemblys.ToArray())
            //    .Where(t => t.Name.EndsWith("Repository"))
            //    .AsImplementedInterfaces();


        }

    }
}
