using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EOH.WebUI.Startup))]
namespace EOH.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
