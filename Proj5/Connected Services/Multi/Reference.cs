﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proj5.Multi {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Multi.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetTimezone", ReplyAction="http://tempuri.org/IService1/GetTimezoneResponse")]
        string GetTimezone(string zipcode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetTimezone", ReplyAction="http://tempuri.org/IService1/GetTimezoneResponse")]
        System.Threading.Tasks.Task<string> GetTimezoneAsync(string zipcode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/newsFinder", ReplyAction="http://tempuri.org/IService1/newsFinderResponse")]
        string newsFinder(string news);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/newsFinder", ReplyAction="http://tempuri.org/IService1/newsFinderResponse")]
        System.Threading.Tasks.Task<string> newsFinderAsync(string news);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/storeFinder", ReplyAction="http://tempuri.org/IService1/storeFinderResponse")]
        string storeFinder(string zipcode, string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/storeFinder", ReplyAction="http://tempuri.org/IService1/storeFinderResponse")]
        System.Threading.Tasks.Task<string> storeFinderAsync(string zipcode, string name);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : Proj5.Multi.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<Proj5.Multi.IService1>, Proj5.Multi.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetTimezone(string zipcode) {
            return base.Channel.GetTimezone(zipcode);
        }
        
        public System.Threading.Tasks.Task<string> GetTimezoneAsync(string zipcode) {
            return base.Channel.GetTimezoneAsync(zipcode);
        }
        
        public string newsFinder(string news) {
            return base.Channel.newsFinder(news);
        }
        
        public System.Threading.Tasks.Task<string> newsFinderAsync(string news) {
            return base.Channel.newsFinderAsync(news);
        }
        
        public string storeFinder(string zipcode, string name) {
            return base.Channel.storeFinder(zipcode, name);
        }
        
        public System.Threading.Tasks.Task<string> storeFinderAsync(string zipcode, string name) {
            return base.Channel.storeFinderAsync(zipcode, name);
        }
    }
}
