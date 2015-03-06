using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Amibios.Startup))]
namespace Amibios
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
