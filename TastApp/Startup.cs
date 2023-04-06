using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TastApp.Startup))]
namespace TastApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
