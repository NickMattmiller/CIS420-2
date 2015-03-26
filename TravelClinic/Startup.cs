using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(asp.netmvc5.Startup))]
namespace asp.netmvc5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
