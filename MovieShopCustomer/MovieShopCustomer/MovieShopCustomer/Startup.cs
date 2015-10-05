using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieShopCustomer.Startup))]
namespace MovieShopCustomer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
