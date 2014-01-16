using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Glimpse.Mvc5.Sample.Startup))]
namespace Glimpse.Mvc5.Sample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
