
using System;
using System.Linq;
using System.Threading.Tasks;
using Online.Common;
using Online.IServices;
using Online.Models;

namespace Online.ClientTest {

    class Client {
        static void Main() {
            IService client = null;
            // Create a client
            //CalculatorClient client = new CalculatorClient();
            //var client = WcfServiceClientFactory.CreateClient();
            //var client = ServiceProxy.GetTcpService<IService>();
            //var client = ServiceProxy.GetHttpService<IService>();

            //for (int i = 0; i < 1; i++) {
            //    client = ServiceProxy.GetHttpService<IService>();
            //    var items = client.Get(Consts.OrderServiceTypeName).Select(p => p as TestModel).ToList();
            //    foreach (var item in items) {
            //        Console.WriteLine(item.id);
            //    }
            //}

            for (int i = 0; i < 10000; i++) {
                var i1 = i;
                Task.Factory.StartNew(() => {
                    var clientTest = ServiceProxy.GetTcpService<IService>();
                    var items = clientTest.Get(Consts.OrderServiceTypeName).Select(p => p as TestModel).ToList();
                    foreach (var item in items) {
                        Console.WriteLine(item.id);
                    }
                    Console.WriteLine(string.Format("--------------------------{0}----------------------------",i1));
                });
            }

            client = ServiceProxy.GetHttpService<IService>();

            //t = client.Get((new TestModel() { Id = 100, TypeName = "WcfServiceLibrary1.GoodsService" })) as TestModel;
            //Console.WriteLine("AddModel({0}) = {1}", 100, t.Id);


            // Call the Add service operation.
            double value1 = 100.00D;
            double value2 = 15.99D;
            double result = client.Add(value1, value2);
            Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);

            // Call the Subtract service operation.
            value1 = 145.00D;
            value2 = 76.54D;
            result = client.Subtract(value1, value2);
            Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result);

            // Call the Multiply service operation.
            value1 = 9.00D;
            value2 = 81.25D;
            result = client.Multiply(value1, value2);
            Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result);

            // Call the Divide service operation.
            value1 = 22.00D;
            value2 = 7.00D;
            result = client.Divide(value1, value2);
            Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result);

            //Closing the client gracefully closes the connection and cleans up resources


            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
        }
    }
}
