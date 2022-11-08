using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyEShop.WebUi.Startup))]
namespace MyEShop.WebUi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
