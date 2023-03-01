using Microsoft.Owin;
using Owin;
//test git 
[assembly: OwinStartupAttribute(typeof(Demo.Web.Startup))]
namespace Demo.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
