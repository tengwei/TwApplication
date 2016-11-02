using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using log4net;
using Online.IServices;
using Online.Models;
using Online.Services;

namespace Online.Web {
    // Service class which implements the service contract.
    // Added code to write output to the console window
    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Single)]
    public class Service1 : IService1 {

        ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public double Add(double n1, double n2) {
            double result = n1 + n2;
            Console.WriteLine("Received Add({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
            logger.Debug("开始Service1");
            Thread.Sleep(1000 * 60 * 20);
            logger.Debug("结束Service1");
            return result;
        }

        public double Subtract(double n1, double n2) {
            double result = n1 - n2;
            logger.Debug("开始Service1");
            Console.WriteLine("Received Subtract({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
            return result;
        }

        public double Multiply(double n1, double n2) {
            double result = n1 * n2;
            Console.WriteLine("Received Multiply({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
            return result;
        }

        public double Divide(double n1, double n2) {
            double result = n1 / n2;
            Console.WriteLine("Received Divide({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
            return result;
        }

        public List<BaseModel> Get(string typeName) {

            return CreateService.CreateIService(typeName).Get(typeName);
        }
    }
}
