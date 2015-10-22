using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BirthdaySystem.Web.Startup))]
namespace BirthdaySystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
