using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Marathon.Internal.UI.Startup))]
namespace Marathon.Internal.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
