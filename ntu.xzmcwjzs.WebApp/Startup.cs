using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ntu.xzmcwjzs.WebApp.Startup))]
namespace ntu.xzmcwjzs.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
