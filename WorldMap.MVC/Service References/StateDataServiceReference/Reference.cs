﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WorldMap.MVC.StateDataServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="StateDataServiceReference.IStateDataService")]
    public interface IStateDataService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStateDataService/Insert", ReplyAction="http://tempuri.org/IStateDataService/InsertResponse")]
        void Insert(WorldMap.Model.StateData entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStateDataService/Insert", ReplyAction="http://tempuri.org/IStateDataService/InsertResponse")]
        System.Threading.Tasks.Task InsertAsync(WorldMap.Model.StateData entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStateDataService/Delete", ReplyAction="http://tempuri.org/IStateDataService/DeleteResponse")]
        void Delete(WorldMap.Model.StateData entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStateDataService/Delete", ReplyAction="http://tempuri.org/IStateDataService/DeleteResponse")]
        System.Threading.Tasks.Task DeleteAsync(WorldMap.Model.StateData entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStateDataService/Update", ReplyAction="http://tempuri.org/IStateDataService/UpdateResponse")]
        void Update(WorldMap.Model.StateData entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStateDataService/Update", ReplyAction="http://tempuri.org/IStateDataService/UpdateResponse")]
        System.Threading.Tasks.Task UpdateAsync(WorldMap.Model.StateData entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStateDataService/SelectAll", ReplyAction="http://tempuri.org/IStateDataService/SelectAllResponse")]
        WorldMap.Model.StateData[] SelectAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStateDataService/SelectAll", ReplyAction="http://tempuri.org/IStateDataService/SelectAllResponse")]
        System.Threading.Tasks.Task<WorldMap.Model.StateData[]> SelectAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStateDataService/SelectById", ReplyAction="http://tempuri.org/IStateDataService/SelectByIdResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(WorldMap.Model.StateData))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(WorldMap.Model.CityData[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(WorldMap.Model.CityData))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(WorldMap.Model.StateData[]))]
        WorldMap.Model.StateData SelectById(object id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStateDataService/SelectById", ReplyAction="http://tempuri.org/IStateDataService/SelectByIdResponse")]
        System.Threading.Tasks.Task<WorldMap.Model.StateData> SelectByIdAsync(object id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IStateDataServiceChannel : WorldMap.MVC.StateDataServiceReference.IStateDataService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class StateDataServiceClient : System.ServiceModel.ClientBase<WorldMap.MVC.StateDataServiceReference.IStateDataService>, WorldMap.MVC.StateDataServiceReference.IStateDataService {
        
        public StateDataServiceClient() {
        }
        
        public StateDataServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public StateDataServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StateDataServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StateDataServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void Insert(WorldMap.Model.StateData entity) {
            base.Channel.Insert(entity);
        }
        
        public System.Threading.Tasks.Task InsertAsync(WorldMap.Model.StateData entity) {
            return base.Channel.InsertAsync(entity);
        }
        
        public void Delete(WorldMap.Model.StateData entity) {
            base.Channel.Delete(entity);
        }
        
        public System.Threading.Tasks.Task DeleteAsync(WorldMap.Model.StateData entity) {
            return base.Channel.DeleteAsync(entity);
        }
        
        public void Update(WorldMap.Model.StateData entity) {
            base.Channel.Update(entity);
        }
        
        public System.Threading.Tasks.Task UpdateAsync(WorldMap.Model.StateData entity) {
            return base.Channel.UpdateAsync(entity);
        }
        
        public WorldMap.Model.StateData[] SelectAll() {
            return base.Channel.SelectAll();
        }
        
        public System.Threading.Tasks.Task<WorldMap.Model.StateData[]> SelectAllAsync() {
            return base.Channel.SelectAllAsync();
        }
        
        public WorldMap.Model.StateData SelectById(object id) {
            return base.Channel.SelectById(id);
        }
        
        public System.Threading.Tasks.Task<WorldMap.Model.StateData> SelectByIdAsync(object id) {
            return base.Channel.SelectByIdAsync(id);
        }
    }
}
