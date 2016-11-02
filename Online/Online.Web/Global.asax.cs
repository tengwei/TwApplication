using System;
using System.Reflection;
using log4net;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace Online.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        protected void Application_Start() {

        }


        protected void Application_BeginRequest(object sender, EventArgs e) {
            logger.Debug("MvcApplication_Application_BeginRequest");
            
        }
        protected void Application_EndRequest(object sender, EventArgs e) {
            //logger.Debug("MvcApplication_Application_EndRequest");
        }
       
    }
}
