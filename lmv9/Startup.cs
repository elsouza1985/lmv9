using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(lmv9.Startup))]
namespace lmv9
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
