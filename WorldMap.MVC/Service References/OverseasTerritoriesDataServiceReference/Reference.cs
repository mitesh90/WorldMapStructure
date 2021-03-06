﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WorldMap.MVC.OverseasTerritoriesDataServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="OverseasTerritoriesDataServiceReference.IOverseasTerritoriesDataService")]
    public interface IOverseasTerritoriesDataService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOverseasTerritoriesDataService/Insert", ReplyAction="http://tempuri.org/IOverseasTerritoriesDataService/InsertResponse")]
        void Insert(WorldMap.Model.OverseasTerritoriesData entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOverseasTerritoriesDataService/Insert", ReplyAction="http://tempuri.org/IOverseasTerritoriesDataService/InsertResponse")]
        System.Threading.Tasks.Task InsertAsync(WorldMap.Model.OverseasTerritoriesData entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOverseasTerritoriesDataService/Delete", ReplyAction="http://tempuri.org/IOverseasTerritoriesDataService/DeleteResponse")]
        void Delete(WorldMap.Model.OverseasTerritoriesData entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOverseasTerritoriesDataService/Delete", ReplyAction="http://tempuri.org/IOverseasTerritoriesDataService/DeleteResponse")]
        System.Threading.Tasks.Task DeleteAsync(WorldMap.Model.OverseasTerritoriesData entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOverseasTerritoriesDataService/Update", ReplyAction="http://tempuri.org/IOverseasTerritoriesDataService/UpdateResponse")]
        void Update(WorldMap.Model.OverseasTerritoriesData entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOverseasTerritoriesDataService/Update", ReplyAction="http://tempuri.org/IOverseasTerritoriesDataService/UpdateResponse")]
        System.Threading.Tasks.Task UpdateAsync(WorldMap.Model.OverseasTerritoriesData entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOverseasTerritoriesDataService/SelectAll", ReplyAction="http://tempuri.org/IOverseasTerritoriesDataService/SelectAllResponse")]
        WorldMap.Model.OverseasTerritoriesData[] SelectAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOverseasTerritoriesDataService/SelectAll", ReplyAction="http://tempuri.org/IOverseasTerritoriesDataService/SelectAllResponse")]
        System.Threading.Tasks.Task<WorldMap.Model.OverseasTerritoriesData[]> SelectAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOverseasTerritoriesDataService/SelectById", ReplyAction="http://tempuri.org/IOverseasTerritoriesDataService/SelectByIdResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(WorldMap.Model.OverseasTerritoriesData))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(WorldMap.Model.OverseasTerritoriesData[]))]
        WorldMap.Model.OverseasTerritoriesData SelectById(object id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOverseasTerritoriesDataService/SelectById", ReplyAction="http://tempuri.org/IOverseasTerritoriesDataService/SelectByIdResponse")]
        System.Threading.Tasks.Task<WorldMap.Model.OverseasTerritoriesData> SelectByIdAsync(object id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IOverseasTerritoriesDataServiceChannel : WorldMap.MVC.OverseasTerritoriesDataServiceReference.IOverseasTerritoriesDataService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OverseasTerritoriesDataServiceClient : System.ServiceModel.ClientBase<WorldMap.MVC.OverseasTerritoriesDataServiceReference.IOverseasTerritoriesDataService>, WorldMap.MVC.OverseasTerritoriesDataServiceReference.IOverseasTerritoriesDataService {
        
        public OverseasTerritoriesDataServiceClient() {
        }
        
        public OverseasTerritoriesDataServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public OverseasTerritoriesDataServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OverseasTerritoriesDataServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OverseasTerritoriesDataServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void Insert(WorldMap.Model.OverseasTerritoriesData entity) {
            base.Channel.Insert(entity);
        }
        
        public System.Threading.Tasks.Task InsertAsync(WorldMap.Model.OverseasTerritoriesData entity) {
            return base.Channel.InsertAsync(entity);
        }
        
        public void Delete(WorldMap.Model.OverseasTerritoriesData entity) {
            base.Channel.Delete(entity);
        }
        
        public System.Threading.Tasks.Task DeleteAsync(WorldMap.Model.OverseasTerritoriesData entity) {
            return base.Channel.DeleteAsync(entity);
        }
        
        public void Update(WorldMap.Model.OverseasTerritoriesData entity) {
            base.Channel.Update(entity);
        }
        
        public System.Threading.Tasks.Task UpdateAsync(WorldMap.Model.OverseasTerritoriesData entity) {
            return base.Channel.UpdateAsync(entity);
        }
        
        public WorldMap.Model.OverseasTerritoriesData[] SelectAll() {
            return base.Channel.SelectAll();
        }
        
        public System.Threading.Tasks.Task<WorldMap.Model.OverseasTerritoriesData[]> SelectAllAsync() {
            return base.Channel.SelectAllAsync();
        }
        
        public WorldMap.Model.OverseasTerritoriesData SelectById(object id) {
            return base.Channel.SelectById(id);
        }
        
        public System.Threading.Tasks.Task<WorldMap.Model.OverseasTerritoriesData> SelectByIdAsync(object id) {
            return base.Channel.SelectByIdAsync(id);
        }
    }
}
