using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RedisSessionWebApplication.Startup))]
namespace RedisSessionWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
