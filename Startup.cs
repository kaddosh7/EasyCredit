using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EasyCredit.Startup))]
namespace EasyCredit
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
