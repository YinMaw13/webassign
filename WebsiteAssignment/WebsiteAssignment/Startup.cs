using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebsiteAssignment.Startup))]
namespace WebsiteAssignment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
