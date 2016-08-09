using System.ServiceModel;

namespace Contract
{
	[ServiceContract(SessionMode = SessionMode.Allowed)]
	public interface IAdd
	{
		[OperationContract]
		void Add(int x, int y);
	}
}