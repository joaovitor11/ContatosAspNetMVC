using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Repositorio.WEB.Startup))]
namespace Repositorio.WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
