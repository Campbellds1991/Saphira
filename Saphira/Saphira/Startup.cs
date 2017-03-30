using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Saphira.Startup))]
namespace Saphira
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
