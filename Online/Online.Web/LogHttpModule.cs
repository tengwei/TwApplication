using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using log4net;

namespace Online.Web {

    public class LogHttpModule : IHttpModule {
        ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public LogHttpModule() {
        }

        public String ModuleName {
            get { return "LogHttpModule"; }
        }

        public void Init(HttpApplication application) {
            application.BeginRequest +=
                (new EventHandler(this.Application_BeginRequest));
            application.EndRequest +=
                (new EventHandler(this.Application_EndRequest));
        }

        private void Application_BeginRequest(Object source,
            EventArgs e) {
          
            HttpApplication application = (HttpApplication) source;
            //logger.Debug("LogHttpModule_Application_BeginRequest");
            
        }

        private void Application_EndRequest(Object source, EventArgs e) {
            HttpApplication application = (HttpApplication) source;
            //logger.Debug("LogHttpModule_Application_EndRequest");
            
        }

        public void Dispose() {
        }
    }
}

