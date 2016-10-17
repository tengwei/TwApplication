using System;
using System.Collections.Concurrent;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Online.Common
{
    public class CreateProxy
    {
        private static readonly ConcurrentDictionary<string, ICommunicationObject> proxies = new ConcurrentDictionary<string, ICommunicationObject>();
        

        public static T GetHttpService<T>(string url) where T : class {

            //ChannelFactory<T> channelFactory = new ChannelFactory<T>();
            //    UserNamePasswordClientCredential credential = channelFactory.Credentials.UserName;
            //    credential.UserName = "xuyue";
            //    credential.Password = "password01";
            //    T t = channelFactory.CreateChannel();
            
            //return t;
           


            if (proxies.ContainsKey(url))
            {
                ICommunicationObject obj = proxies[url];
                return obj as T;
            }
            Type channelFactoryGenericType = typeof(ChannelFactory<>).MakeGenericType(new Type[] { typeof(T) });
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.MaxBufferSize = int.MaxValue;
            binding.MaxReceivedMessageSize = int.MaxValue;
            //binding.ReaderQuotas.MaxStringContentLength = int.MaxValue;

            MethodInfo method = channelFactoryGenericType.GetMethod("CreateChannel", new Type[] { typeof(Binding), typeof(EndpointAddress) });
            ICommunicationObject iObj = method.Invoke(null, new Object[] { binding, new EndpointAddress(url) }) as ICommunicationObject;
            proxies[url] = iObj;
            return iObj as T;
        }

        public static T GetTcpService<T>(string url, object callbackContract = null) where T : class
        {
            //if (proxies.ContainsKey(url))
            //{
            //    ICommunicationObject obj = proxies[url];
            //    if (obj.State == CommunicationState.Opened)
            //    {
            //        return obj as T;
            //    }
            //}

            //TcpTransportBindingElement tcpTransport = new TcpTransportBindingElement();
            //tcpTransport.MaxReceivedMessageSize = int.MaxValue;
            //tcpTransport.MaxBufferSize = int.MaxValue;
            //BinaryMessageEncodingBindingElement binaryEle = new BinaryMessageEncodingBindingElement();

            // CustomBinding binding = new CustomBinding(binaryEle, tcpTransport);
            NetTcpBinding binding = new NetTcpBinding(SecurityMode.None);
            binding.MaxBufferSize = int.MaxValue;
            binding.MaxReceivedMessageSize = int.MaxValue;
            //System.Xml.XmlDictionaryReaderQuotas readerQuotas = binding.ReaderQuotas;
            //readerQuotas.MaxArrayLength = int.MaxValue;
            //readerQuotas.MaxStringContentLength = int.MaxValue;
            //readerQuotas.MaxBytesPerRead = int.MaxValue;
            //readerQuotas.MaxNameTableCharCount = int.MaxValue;

            EndpointAddress endPointAddress = new EndpointAddress(url);
            if (callbackContract == null)
            {
                T t = DuplexChannelFactory<T>.CreateChannel(binding, endPointAddress);

                // ((IContextChannel)t).OperationTimeout = new TimeSpan(0, 0, 240);
                (t as ICommunicationObject).Open();

                proxies[url] = (t as ICommunicationObject);
                return t;
            }
            else
            {
                T t = DuplexChannelFactory<T>.CreateChannel(new InstanceContext(callbackContract), binding, endPointAddress);
                //  ((IContextChannel)t).OperationTimeout = new TimeSpan(0, 0, 240);
                (t as ICommunicationObject).Open();
                proxies[url] = (t as ICommunicationObject);
                return t;
            }
        }
    }
}
