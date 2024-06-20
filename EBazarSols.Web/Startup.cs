using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EBazarSols.Web.Startup))]
namespace EBazarSols.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
