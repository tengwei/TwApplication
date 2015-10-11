using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TransactionWeb2.Startup))]
namespace TransactionWeb2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
