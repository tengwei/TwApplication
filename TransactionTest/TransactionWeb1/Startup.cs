using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TransactionWeb1.Startup))]
namespace TransactionWeb1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
