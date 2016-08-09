using System;
using System.ServiceModel;
using System.Threading;
using Contract;

namespace Client
{
	internal class Program
	{
		private static int index = 0;

		private static void Main(string[] args)
		{
			InvokeWithSameProxy();
			//InvokeWithDiffrentProxy();
			Console.ReadLine();
		}

		static void InvokeWithSameProxy()
		{
			ChannelFactory<IAdd> factory=new ChannelFactory<IAdd>("AddService");
			IAdd proxy = factory.CreateChannel();
			if (null != proxy as ICommunicationObject)
			{
				(proxy as ICommunicationObject).Open();
			}
		    var datatime = DateTime.Now;
            Console.WriteLine(datatime);
		    int num = 100;
            for (int i = 0; i < num; i++)
			{
				
				ThreadPool.QueueUserWorkItem(delegate
				                             	{
													int clientId = Interlocked.Increment(ref index);
				                             		using (
				                             			OperationContextScope contextScope =
				                             				new OperationContextScope(proxy as IContextChannel))
				                             		{
                                                         Console.WriteLine(i);
                                                         MessageHeader<int> header = new MessageHeader<int>(clientId);
				                             			System.ServiceModel.Channels.MessageHeader messageHeader =
				                             				header.GetUntypedHeader(MessageWrapper.headerClientId,
				                             				                        MessageWrapper.headerNamespace);
				                             			OperationContext.Current.OutgoingMessageHeaders.Add(messageHeader);
				                             			proxy.Add(1, 2);
				                             		    if (i == num-1) {
                                                             Console.WriteLine((DateTime.Now - datatime).Seconds);
                                                         }
				                             		}
				                             	});
			}
		}

		static void InvokeWithDiffrentProxy()
		{
			ChannelFactory<IAdd> factory = new ChannelFactory<IAdd>("AddService");

			for (int i = 0; i < 5; i++)
			{
				IAdd proxy = factory.CreateChannel();
				ThreadPool.QueueUserWorkItem(delegate
				                             	{
				                             		int clientId = Interlocked.Increment(ref index);
				                             		using (
				                             			OperationContextScope contextScope =
				                             				new OperationContextScope(proxy as IContextChannel))
				                             		{
				                             			MessageHeader<int> header = new MessageHeader<int>(clientId);
				                             			System.ServiceModel.Channels.MessageHeader messageHeader =
				                             				header.GetUntypedHeader(MessageWrapper.headerClientId,
				                             				                        MessageWrapper.headerNamespace);
				                             			OperationContext.Current.OutgoingMessageHeaders.Add(messageHeader);
				                             			proxy.Add(1, 2);
				                             		}
				                             	});
			}
		}

	}
}