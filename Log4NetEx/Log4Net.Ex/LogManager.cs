using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using log4net.Config;

namespace Log4Net.Ex {
    /// <summary>
    /// 自定义log4net
    /// </summary>
    public  static class LogManager {
        private static string systemName = string.Empty;
        /// <summary>
        /// 初始化 配置log4net
        /// </summary>
        /// <param name="systemName">系统名称</param>
        /// <param name="moduleList">模块列表</param>
        public static void Init(string systemName,List<string> moduleList=null) {
            LogManager.systemName = systemName;
            XElement log4NetXElement = new XElement("log4net");

            string path = string.Empty;
            if (HttpContext.Current != null) {
                path = HttpContext.Current.Server.MapPath("~/log4net.config");
            }
            else {
                path = AppDomain.CurrentDomain.BaseDirectory + "log4net.config";
            }
            var doc = XDocument.Load(path);
            var loggers = new string[] { "DebugLogger", "InfoLogger", "WarnLogger", "ErrorLogger", "FatalLogger" };
            var appenders = new string[] { "RollingFileAppenderDEBUG", "RollingFileAppenderINFO", "RollingFileAppenderWARN", "RollingFileAppenderERROR", "RollingFileAppenderFATAL" };
            string logpath = string.Empty;
            if (moduleList != null && moduleList.Any()) {
                logpath = "公共日志\\\\";
                foreach (var module in moduleList) {
                    for (int i = 0; i < loggers.Length; i++) {
                        string loggerXpath = string.Format("/log4net/logger[@name='{0}']", loggers[i]);
                        string appenderXpath = string.Format("/log4net/appender[@name='{0}']", appenders[i]);
                        var loggerXElement = doc.XPathSelectElement(loggerXpath);
                        var appenderXElement = doc.XPathSelectElement(appenderXpath);
                        if (loggerXElement != null && appenderXElement != null) {
                            Setting(loggers[i], appenders[i], module, loggerXElement, appenderXElement, log4NetXElement);
                        }
                    }
                }
            }

            foreach (var xmlElement in doc.Element("log4net").Elements()) {
                var appenderFile = xmlElement.XPathSelectElement("file");
                if (appenderFile != null) {
                    appenderFile.SetAttributeValue("value", appenderFile.Attribute("value").Value + logpath);
                }

                log4NetXElement.Add(XElement.Parse(xmlElement.ToString()));
            }

            //XmlConfigurator.Configure(new System.IO.FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config"));
            XmlConfigurator.Configure(ToXmlElement(log4NetXElement));
        }
        /// <summary>
        /// 获取写日志对象ILog
        /// </summary>
        /// <param name="module">模块名称</param>
        /// <returns></returns>
        public static ILog GetLogger(string module = "") {
            return new LogImpl(systemName,module);
        }
        
        private static void Setting(string logger, string appender, string module, XElement loggerXmlElement, XElement appenderXmlElement, XElement log4NetXElement) {
            var loggerXElement = XElement.Parse(loggerXmlElement.ToString());
            loggerXElement.SetAttributeValue("name", logger + module);
            var appenderRef = loggerXElement.XPathSelectElement("/appender-ref");
            appenderRef.SetAttributeValue("ref", appender + module);
            log4NetXElement.Add(loggerXElement);

            var appenderXElement = XElement.Parse(appenderXmlElement.ToString());
            appenderXElement.SetAttributeValue("name", appender + module);
            var appenderFile = appenderXElement.XPathSelectElement("/file");
            appenderFile.SetAttributeValue("value", appenderFile.Attribute("value").Value + module + "\\\\");
            log4NetXElement.Add(appenderXElement);
        }

        #region XElement与XmlElement的转换

        /// <summary>  
        /// XElement转换为XmlElement  
        /// </summary>  
        private static XmlElement ToXmlElement(XElement xElement) {
            if (xElement == null) return null;

            XmlElement xmlElement = null;
            XmlReader xmlReader = null;
            try {
                xmlReader = xElement.CreateReader();
                var doc = new XmlDocument();
                xmlElement = doc.ReadNode(xElement.CreateReader()) as XmlElement;
            }
            catch {
            }
            finally {
                if (xmlReader != null) xmlReader.Close();
            }

            return xmlElement;
        }

        /// <summary>  
        /// XmlElement转换为XElement  
        /// </summary>  
        private static XElement ToXElement(XmlElement xmlElement) {
            if (xmlElement == null) return null;

            XElement xElement = null;
            try {
                var doc = new XmlDocument();
                doc.AppendChild(doc.ImportNode(xmlElement, true));
                xElement = XElement.Parse(doc.InnerXml);
            }
            catch { }

            return xElement;
        }

        #endregion
    }
    /// <summary>
    /// 日志模型
    /// </summary>
    public class Log4NetMessageModel {
        /// <summary>
        /// 系统名称
        /// </summary>
        public string systemName { get; set; }

        /// <summary>
        /// 信息
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 模块
        /// </summary>
        public string module { get; set; }

        /// <summary>
        /// 执行时间 毫秒
        /// </summary>
        public double? executionTime { get; set; }

        public DateTime? startTime { get; set; }

        public DateTime? endTime { get; set; }

        public string serverIP { get; set; }

        public string clientIP { get; set; }

        public string parameters { get; set; }

        public string url { get; set; }
    }

}
