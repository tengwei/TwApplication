﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Online.ClientTest.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://Microsoft.Samples.NetTcp", ConfigurationName="ServiceReference1.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.Samples.NetTcp/IService/Add", ReplyAction="http://Microsoft.Samples.NetTcp/IService/AddResponse")]
        double Add(double n1, double n2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.Samples.NetTcp/IService/Add", ReplyAction="http://Microsoft.Samples.NetTcp/IService/AddResponse")]
        System.Threading.Tasks.Task<double> AddAsync(double n1, double n2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.Samples.NetTcp/IService/Subtract", ReplyAction="http://Microsoft.Samples.NetTcp/IService/SubtractResponse")]
        double Subtract(double n1, double n2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.Samples.NetTcp/IService/Subtract", ReplyAction="http://Microsoft.Samples.NetTcp/IService/SubtractResponse")]
        System.Threading.Tasks.Task<double> SubtractAsync(double n1, double n2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.Samples.NetTcp/IService/Multiply", ReplyAction="http://Microsoft.Samples.NetTcp/IService/MultiplyResponse")]
        double Multiply(double n1, double n2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.Samples.NetTcp/IService/Multiply", ReplyAction="http://Microsoft.Samples.NetTcp/IService/MultiplyResponse")]
        System.Threading.Tasks.Task<double> MultiplyAsync(double n1, double n2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.Samples.NetTcp/IService/Divide", ReplyAction="http://Microsoft.Samples.NetTcp/IService/DivideResponse")]
        double Divide(double n1, double n2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.Samples.NetTcp/IService/Divide", ReplyAction="http://Microsoft.Samples.NetTcp/IService/DivideResponse")]
        System.Threading.Tasks.Task<double> DivideAsync(double n1, double n2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.Samples.NetTcp/IService/Get", ReplyAction="http://Microsoft.Samples.NetTcp/IService/GetResponse")]
        Online.Models.BaseModel[] Get(string typeName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.Samples.NetTcp/IService/Get", ReplyAction="http://Microsoft.Samples.NetTcp/IService/GetResponse")]
        System.Threading.Tasks.Task<Online.Models.BaseModel[]> GetAsync(string typeName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : Online.ClientTest.ServiceReference1.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<Online.ClientTest.ServiceReference1.IService>, Online.ClientTest.ServiceReference1.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public double Add(double n1, double n2) {
            return base.Channel.Add(n1, n2);
        }
        
        public System.Threading.Tasks.Task<double> AddAsync(double n1, double n2) {
            return base.Channel.AddAsync(n1, n2);
        }
        
        public double Subtract(double n1, double n2) {
            return base.Channel.Subtract(n1, n2);
        }
        
        public System.Threading.Tasks.Task<double> SubtractAsync(double n1, double n2) {
            return base.Channel.SubtractAsync(n1, n2);
        }
        
        public double Multiply(double n1, double n2) {
            return base.Channel.Multiply(n1, n2);
        }
        
        public System.Threading.Tasks.Task<double> MultiplyAsync(double n1, double n2) {
            return base.Channel.MultiplyAsync(n1, n2);
        }
        
        public double Divide(double n1, double n2) {
            return base.Channel.Divide(n1, n2);
        }
        
        public System.Threading.Tasks.Task<double> DivideAsync(double n1, double n2) {
            return base.Channel.DivideAsync(n1, n2);
        }
        
        public Online.Models.BaseModel[] Get(string typeName) {
            return base.Channel.Get(typeName);
        }
        
        public System.Threading.Tasks.Task<Online.Models.BaseModel[]> GetAsync(string typeName) {
            return base.Channel.GetAsync(typeName);
        }
    }
}
