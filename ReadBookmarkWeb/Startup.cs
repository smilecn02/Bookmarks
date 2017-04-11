using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReadBookmarkWeb.Startup))]
namespace ReadBookmarkWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
