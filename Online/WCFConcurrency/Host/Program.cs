using System;
using System.ServiceModel;
using Service;

namespace Host
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			using(ServiceHost host=new ServiceHost(typeof(AddService))) {
			    //System.Net.ServicePointManager.DefaultConnectionLimit = 512;

                host.Open();
				Console.WriteLine("Service Running...");
				Console.ReadLine();
			}
		}
	}
}