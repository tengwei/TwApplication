using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using log4net;
using Log4Net.Ex;


namespace Log4NetEx {
    public class MvcApplication : System.Web.HttpApplication {
        //readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //InitQueue();
            //InitRedis();
            LogManager.Init("TEST", Enum.GetNames(typeof(ModuleEnum)).ToList());
        }

        private void InitQueue() {
            string filePath = Server.MapPath("~/Logs/");
            ThreadPool.QueueUserWorkItem(o => {
                while (true) {
                    if (QueueErrorAttribute.ExceptionQueue.Count > 0) {
                        Exception ex = QueueErrorAttribute.ExceptionQueue.Dequeue();
                        if (ex != null) {
                            string fileName = filePath + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                            if (!Directory.Exists(filePath)) {
                                Directory.CreateDirectory(filePath);
                            }
                            if (!File.Exists(fileName)) {
                                File.Create(fileName);
                                
                            }
                            File.AppendAllText(fileName, ex.Message);
                        }
                        else {
                            Thread.Sleep(50);
                        }
                    }
                    else {
                        Thread.Sleep(50);
                    }
                }
            });
        }

        private void InitRedis() {
            string filePath = Server.MapPath("~/Logs/");
            ThreadPool.QueueUserWorkItem(o => {
                while (true) {
                    RedisHelper redis = new RedisHelper(1);
                    if (redis.ListLength("errorMsg") > 0) {
                        string ex = redis.ListRightPop<string>("errorMsg");
                        if (ex != null) {
                            //logger.Debug(ex);
                        }
                        else {
                            Thread.Sleep(50);
                        }
                    }
                    else {
                        Thread.Sleep(50);
                    }
                }
            });
        }
    }
}
