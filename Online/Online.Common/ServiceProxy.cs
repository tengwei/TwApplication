using System;
using System.Collections.Generic;
using System.Configuration;
using Online.IServices;

namespace Online.Common {
    /// <summary>
    /// 服务代理类
    /// </summary>
    public class ServiceProxy {

        /// <summary>
        /// WebHost net.tcp 服务的基础地址的Key
        /// </summary>
        private const string SYS_TCPSERVICEURL = "TcpServiceUrl";
        /// <summary>
        /// WebHost http 服务的基础地址的Key
        /// </summary>
        private const string SYS_HTTPSERVICEURL = "HttpServiceUrl";
        private readonly static Dictionary<Type, string> serviceUrlDic;

        static ServiceProxy() {
            serviceUrlDic = new Dictionary<Type, string> {{typeof (IService), "Service.svc"}};
        }

        /// <summary>
        /// 获取net.tcp服务实例
        ///     应用程序配置文件AppSetting节点需要
        ///     <add key="SoasServiceUrl" value="127.0.0.1:8001" />
        /// </summary>
        /// <typeparam name="T">服务接口</typeparam>
        /// <returns></returns>
        public static T GetTcpService<T>() where T : class,IServiceContract {
            return GetService<T>("net.tcp", ConfigurationManager.AppSettings[SYS_TCPSERVICEURL]);
        }

        /// <summary>
        /// 获取http服务实例
        /// 应用程序配置文件AppSetting节点需要
        /// <add key="HttpServiceUrl" value="127.0.0.1:8001" />
        /// </summary>
        /// <typeparam name="T">服务接口</typeparam>
        /// <returns></returns>
        public static T GetHttpService<T>() where T : class,IServiceContract {
            string httpServiceUrl = string.Empty;
            return GetService<T>("http", ConfigurationManager.AppSettings[SYS_HTTPSERVICEURL], httpServiceUrl);
        }

        /// <summary>
        /// 获取服务实例
        /// </summary>
        /// <typeparam name="T">服务接口信息</typeparam>
        /// <param name="protocol">服务的访问协议。 http/net.tcp</param>
        /// <param name="serviceUrl"></param>
        /// <param name="serviceFullUrl">服务全路径,http://127.0.0.1:8081/Service.svc</param>
        /// <returns></returns>
        private static T GetService<T>(string protocol, string serviceUrl, string serviceFullUrl = null) where T : class,IServiceContract {
            T service = default(T);
            if (!string.IsNullOrWhiteSpace(protocol)) {
                protocol = protocol.Trim().ToLower();
                string url;
                if (string.IsNullOrWhiteSpace(serviceFullUrl)) {
                    url = string.Format("{2}://{0}/{1}", serviceUrl, serviceUrlDic[typeof(T)], protocol);
                }
                else {
                    url = serviceFullUrl;
                }
                if (protocol == "http") {
                    service = CreateProxy.GetHttpService<T>(url);
                }
                else {
                    service = CreateProxy.GetTcpService<T>(url);
                }
            }
            return service;
        }
    }
}
