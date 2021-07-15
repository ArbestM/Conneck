using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Conneck.WebMVC.Startup))]
namespace Conneck.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
