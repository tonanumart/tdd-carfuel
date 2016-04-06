using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarFuelWeb.Startup))]
namespace CarFuelWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
