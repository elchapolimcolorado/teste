using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SharedToolBox.Web.Startup))]
namespace SharedToolBox.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
