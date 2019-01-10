using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebStatisticSales.Startup))]
namespace WebStatisticSales
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
