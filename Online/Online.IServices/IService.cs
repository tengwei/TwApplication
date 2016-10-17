using System.Collections.Generic;
using System.ServiceModel;
using Online.Models;

namespace Online.IServices
{
    // Define a service contract.
    [ServiceContract(Namespace = "http://Microsoft.Samples.NetTcp")]
    //[OperationContract(IsOneWay = true)]
    public interface IService: IServiceContract {
        [OperationContract]
        double Add(double n1, double n2);
        [OperationContract]
        double Subtract(double n1, double n2);
        [OperationContract]
        double Multiply(double n1, double n2);
        [OperationContract]
        double Divide(double n1, double n2);
        [OperationContract]
        List<BaseModel> Get(string typeName);

    }
}
