using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Po_Ne.Startup))]
namespace Po_Ne
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
