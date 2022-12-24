using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ERPStandard.WEB.Startup))]
namespace ERPStandard.WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
