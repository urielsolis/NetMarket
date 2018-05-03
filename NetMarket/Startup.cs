using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NetMarket.Startup))]
namespace NetMarket
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
