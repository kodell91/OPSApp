using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OPSA.Startup))]
namespace OPSA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
