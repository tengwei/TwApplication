
using System;
using System.Reflection;
using System.Web;

namespace Log4Net.Ex
{

    public class LogImpl : ILog {
        private string module { get; set; }
        private string systemName { get; set; }
        public LogImpl(string systemName,string module) {
            this.module = module;
            this.systemName = systemName;
        }

        public void Debug(Log4NetMessageModel message, Exception exception=null) {
            var log = SettingProperties(message, LoggerEnum.DebugLogger);
            log.Debug(message.message, exception);
        }

        public void Info(Log4NetMessageModel message, Exception exception=null) {
            var log = SettingProperties(message, LoggerEnum.InfoLogger);
            log.Info(message.message, exception);
        }
        public void Warn(Log4NetMessageModel message, Exception exception) {
            var log = SettingProperties(message, LoggerEnum.WarnLogger);
            log.Warn(message.message, exception);
        }
        public void Error(Log4NetMessageModel message, Exception exception) {
            var log = SettingProperties(message, LoggerEnum.ErrorLogger);
            log.Error(message.message, exception);
        }

        public void Fatal(Log4NetMessageModel message, Exception exception) {
            var log = SettingProperties(message, LoggerEnum.FatalLogger);
            log.Fatal(message.message, exception);
        }

        private log4net.ILog SettingProperties(Log4NetMessageModel message,LoggerEnum loggerEnum) {
            if (!string.IsNullOrEmpty(this.module)) {
                message.module = this.module;
            }
            if (!string.IsNullOrEmpty(this.systemName)) {
                message.systemName = this.systemName;
            }
            
            log4net.ILog log = null;
            log = string.IsNullOrEmpty(message.module) ? log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType) : log4net.LogManager.GetLogger(loggerEnum.ToString() + message.module);
            double executionTime = 0;
            if (message.executionTime == null) {
                if (message.startTime != null && message.endTime != null) {
                    executionTime = message.endTime.Value.Subtract(message.startTime.Value).TotalMilliseconds;
                }
            }
            if (string.IsNullOrEmpty(message.url)) {
                message.url =HttpContext.Current!=null? HttpContext.Current.Request.Url.AbsolutePath:string.Empty;
            }
            if (string.IsNullOrEmpty(message.parameters)) {
                message.parameters = HttpContext.Current != null ? HttpContext.Current.Request.Params.ToString() : string.Empty;
            }
            if (string.IsNullOrEmpty(message.serverIP)) {
                message.serverIP = HttpContext.Current != null ? HttpContext.Current.Request.UserHostAddress : string.Empty;
            }
            if (string.IsNullOrEmpty(message.clientIP) && HttpContext.Current!=null) {
                message.clientIP = GetClientIP();
            }
            log4net.ThreadContext.Properties["module"] = message.module;
            log4net.ThreadContext.Properties["executionTime"] = executionTime;
            log4net.ThreadContext.Properties["systemName"] = message.systemName;
            log4net.ThreadContext.Properties["serverIP"] = message.serverIP;
            log4net.ThreadContext.Properties["clientIP"] = message.clientIP;
            log4net.ThreadContext.Properties["parameters"] = message.parameters;
            log4net.ThreadContext.Properties["url"] = message.url;
            return log;
        }
        private string GetClientIP() {
            string ip = string.Empty;
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.ServerVariables["HTTP_VIA"]))
                ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ip))
                ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            return ip;
        }
    }

    public enum LoggerEnum {
        DebugLogger, InfoLogger, WarnLogger, ErrorLogger, FatalLogger
    }
}
