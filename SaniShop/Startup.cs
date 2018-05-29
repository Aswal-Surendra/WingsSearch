using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SaniShop.Startup))]
namespace SaniShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
