using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VidlyApplication.Startup))]
namespace VidlyApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
