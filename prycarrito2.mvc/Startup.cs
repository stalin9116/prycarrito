using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(prycarrito2.mvc.Startup))]
namespace prycarrito2.mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
