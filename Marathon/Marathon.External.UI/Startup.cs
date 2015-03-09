using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Marathon.External.UI.Startup))]
namespace Marathon.External.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
