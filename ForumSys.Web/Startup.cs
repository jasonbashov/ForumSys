using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ForumSys.Web.Startup))]
namespace ForumSys.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
