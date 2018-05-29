using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CommonFrame.Web.Startup))]
namespace CommonFrame.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
