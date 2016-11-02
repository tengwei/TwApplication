
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Online.ClientTest.ServiceReference1;
using Online.ClientTest.ServiceReference3;
using Online.Common;
using Online.Models;
using IService = Online.IServices.IService;

namespace Online.ClientTest {

    class Client {
        static void Main() {
            //using (var client = new ServiceClient()) {
            //    double value1 = 100.00D;
            //    double value2 = 15.99D;
            //    double result = client.Subtract(value1, value2);
            //    Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);
            //    Console.WriteLine("Press <ENTER> to terminate client.");
            //    Console.ReadLine();
            //}
            Test1();
           
        }

        static void Test2() {
            //IService client = null;
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
            using (var client =new ServiceClient()) {

                client.Subtract(1, 1);
                Console.WriteLine("Add({0},{1}) = {2}", 1, 1, 2);
                Console.WriteLine("Press <ENTER> to terminate client.");
                Console.ReadLine();
            }
                double value1 = 100.00D;
                double value2 = 15.99D;
                double result1 = ServiceProxy.GetTcpService<IService>().Subtract(value1, value2);
                Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result1);
                Console.WriteLine("Press <ENTER> to terminate client.");
                Console.ReadLine();
           
            for (int i = 0; i < 100; i++) {
                var i1 = i;
                Task.Factory.StartNew(() => {
                    Console.WriteLine(string.Format("-------------开始-------------{0}-{1}----------------------------", i1, DateTime.Now));
                    var client = ServiceProxy.GetTcpService<IService>();
                    double result = client.Add(1, 1);
                    Console.WriteLine(string.Format("--------------结束------------{0}-{1}-----{2}-----------------------", i1, DateTime.Now, result));
                });
            }
            Console.ReadLine();
            //for (int i = 0; i < 100; i++) {
            //    var i1 = i;
            //    Task.Factory.StartNew(() => {
            //        var client = ServiceProxy.GetHttpService<IService>();
            //        double value1 = 100.00D;
            //        double value2 = 15.99D;
            //        double result = client.Add(value1, value2);
                  
            //        Console.WriteLine(string.Format("--------------------------{0}----------------------------", i1));
            //    });
                
            //}
            
            //client = ServiceProxy.GetHttpService<IService>();

            //t = client.Get((new TestModel() { Id = 100, TypeName = "WcfServiceLibrary1.GoodsService" })) as TestModel;
            //Console.WriteLine("AddModel({0}) = {1}", 100, t.Id);


            // Call the Add service operation.
            //double value1 = 100.00D;
            //double value2 = 15.99D;
            //double result = client.Add(value1, value2);
            //Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);

            // Call the Subtract service operation.
            //value1 = 145.00D;
            //value2 = 76.54D;
            ////result = client.Subtract(value1, value2);
            //Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result);

            // Call the Multiply service operation.
            //value1 = 9.00D;
            //value2 = 81.25D;
            ////result = client.Multiply(value1, value2);
            //Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result);

            // Call the Divide service operation.
            //value1 = 22.00D;
            //value2 = 7.00D;
            //result = client.Divide(value1, value2);
            //Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result);

            //Closing the client gracefully closes the connection and cleans up resources


            //Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
        }

        static void Test1() {
            var client = new ServiceClient();
            for (int i = 0; i < 3; i++) {

                var i1 = i;
                Task.Factory.StartNew(() => {
                    Console.WriteLine(string.Format("-------------开始-------------{0}-{1}----------------------------", i1, DateTime.Now));
                    //using () {
                        double value1 = 100.00D;
                        double value2 = 15.99D;
                        double result = client.Add(value1, value2);
                        Console.WriteLine(string.Format("--------------结束------------{0}-{1}-----{2}-----------------------", i1, DateTime.Now, result));
                        //client.Close();
                    //}


                });

            }
            Thread.Sleep(9000);
            using (var client1 = new Online.ClientTest.ServiceReference2.Service1Client()) {
                double value1 = 100.00D;
                double value2 = 15.99D;
                Console.WriteLine(string.Format("-------------开始01-------------{0}-{1}----------------------------", "1111", DateTime.Now));
                double result = client1.Subtract(value1, value2);
                Console.WriteLine(string.Format("--------------结束01------------{0}-{1}-----{2}-----------------------", result, DateTime.Now, result));
                client.Close();
            }
            //for (int i = 0; i < 100; i++) {
            //    var i1 = i;
            //    Task.Factory.StartNew(() => {
            //        Console.WriteLine(string.Format("-------------开始-------------{0}-{1}----------------------------", i1, DateTime.Now));
            //        using (var client = new OauthClient()) {
            //            double value1 = 100.00D;
            //            double value2 = 15.99D;
            //            var result = client.Code("2345");
            //            Console.WriteLine(string.Format("--------------结束------------{0}-{1}-----{2}-----------------------", i1, DateTime.Now, result));
            //        }


            //    });

            //}
            
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
            //using (var client = new ServiceClient()) {
            //    double value1 = 100.00D;
            //    double value2 = 15.99D;
            //    double result = client.Add(value1, value2);
            //    Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);
            //    Console.WriteLine("Press <ENTER> to terminate client.");
            //    Console.ReadLine();
            //}
        }
    }
}
