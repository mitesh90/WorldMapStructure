﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WorldMap.MVC.UserDataServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UserDataServiceReference.IUserDataService")]
    public interface IUserDataService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserDataService/Insert", ReplyAction="http://tempuri.org/IUserDataService/InsertResponse")]
        void Insert(WorldMap.Model.UserData entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserDataService/Insert", ReplyAction="http://tempuri.org/IUserDataService/InsertResponse")]
        System.Threading.Tasks.Task InsertAsync(WorldMap.Model.UserData entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserDataService/Delete", ReplyAction="http://tempuri.org/IUserDataService/DeleteResponse")]
        void Delete(WorldMap.Model.UserData entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserDataService/Delete", ReplyAction="http://tempuri.org/IUserDataService/DeleteResponse")]
        System.Threading.Tasks.Task DeleteAsync(WorldMap.Model.UserData entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserDataService/Update", ReplyAction="http://tempuri.org/IUserDataService/UpdateResponse")]
        void Update(WorldMap.Model.UserData entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserDataService/Update", ReplyAction="http://tempuri.org/IUserDataService/UpdateResponse")]
        System.Threading.Tasks.Task UpdateAsync(WorldMap.Model.UserData entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserDataService/SelectAll", ReplyAction="http://tempuri.org/IUserDataService/SelectAllResponse")]
        WorldMap.Model.UserData[] SelectAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserDataService/SelectAll", ReplyAction="http://tempuri.org/IUserDataService/SelectAllResponse")]
        System.Threading.Tasks.Task<WorldMap.Model.UserData[]> SelectAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserDataService/SelectById", ReplyAction="http://tempuri.org/IUserDataService/SelectByIdResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(WorldMap.Model.UserData))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(WorldMap.Model.UserRoleMapping[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(WorldMap.Model.UserRoleMapping))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(WorldMap.Model.UserData[]))]
        WorldMap.Model.UserData SelectById(object id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserDataService/SelectById", ReplyAction="http://tempuri.org/IUserDataService/SelectByIdResponse")]
        System.Threading.Tasks.Task<WorldMap.Model.UserData> SelectByIdAsync(object id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserDataServiceChannel : WorldMap.MVC.UserDataServiceReference.IUserDataService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserDataServiceClient : System.ServiceModel.ClientBase<WorldMap.MVC.UserDataServiceReference.IUserDataService>, WorldMap.MVC.UserDataServiceReference.IUserDataService {
        
        public UserDataServiceClient() {
        }
        
        public UserDataServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserDataServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserDataServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserDataServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void Insert(WorldMap.Model.UserData entity) {
            base.Channel.Insert(entity);
        }
        
        public System.Threading.Tasks.Task InsertAsync(WorldMap.Model.UserData entity) {
            return base.Channel.InsertAsync(entity);
        }
        
        public void Delete(WorldMap.Model.UserData entity) {
            base.Channel.Delete(entity);
        }
        
        public System.Threading.Tasks.Task DeleteAsync(WorldMap.Model.UserData entity) {
            return base.Channel.DeleteAsync(entity);
        }
        
        public void Update(WorldMap.Model.UserData entity) {
            base.Channel.Update(entity);
        }
        
        public System.Threading.Tasks.Task UpdateAsync(WorldMap.Model.UserData entity) {
            return base.Channel.UpdateAsync(entity);
        }
        
        public WorldMap.Model.UserData[] SelectAll() {
            return base.Channel.SelectAll();
        }
        
        public System.Threading.Tasks.Task<WorldMap.Model.UserData[]> SelectAllAsync() {
            return base.Channel.SelectAllAsync();
        }
        
        public WorldMap.Model.UserData SelectById(object id) {
            return base.Channel.SelectById(id);
        }
        
        public System.Threading.Tasks.Task<WorldMap.Model.UserData> SelectByIdAsync(object id) {
            return base.Channel.SelectByIdAsync(id);
        }
    }
}
