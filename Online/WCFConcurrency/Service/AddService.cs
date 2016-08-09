using System;
using System.ServiceModel;
using System.Threading;
using Contract;

namespace Service
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Single)]
	public class AddService : IAdd
	{
		private readonly int counter = 0;

		public AddService()
		{
			counter++;
			Console.ResetColor();
			Console.WriteLine(string.Format("AddService Construction function excute... counter is {0}", counter));
		}

		#region IAdd 成员

		public void Add(int x, int y)
		{
			var clientId = OperationContext.Current.IncomingMessageHeaders.GetHeader<int>(MessageWrapper.headerClientId,
			                                                                              MessageWrapper.headerNamespace);
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(string.Format("Time:{0};ThreadId is :{1}.Request Id is {2} Add Method Invoked,", DateTime.Now,Thread.CurrentThread.ManagedThreadId,clientId));
			Console.WriteLine(string.Format("result is : {0}",x + y));
			Thread.Sleep(5000);
			Console.WriteLine("=========Excute finished=========");			
			Console.WriteLine();
		}

		#endregion
	}
}