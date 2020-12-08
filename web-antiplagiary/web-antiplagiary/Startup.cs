using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(web_antiplagiary.Startup))]
namespace web_antiplagiary
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
