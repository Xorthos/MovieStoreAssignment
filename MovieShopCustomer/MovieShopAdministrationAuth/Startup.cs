using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieShopAdministrationAuth.Startup))]
namespace MovieShopAdministrationAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
