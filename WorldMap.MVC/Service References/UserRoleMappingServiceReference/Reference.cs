﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WorldMap.MVC.UserRoleMappingServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UserRoleMappingServiceReference.IUserRoleMappingService")]
    public interface IUserRoleMappingService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserRoleMappingService/Insert", ReplyAction="http://tempuri.org/IUserRoleMappingService/InsertResponse")]
        void Insert(WorldMap.Model.UserRoleMapping entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserRoleMappingService/Insert", ReplyAction="http://tempuri.org/IUserRoleMappingService/InsertResponse")]
        System.Threading.Tasks.Task InsertAsync(WorldMap.Model.UserRoleMapping entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserRoleMappingService/Delete", ReplyAction="http://tempuri.org/IUserRoleMappingService/DeleteResponse")]
        void Delete(WorldMap.Model.UserRoleMapping entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserRoleMappingService/Delete", ReplyAction="http://tempuri.org/IUserRoleMappingService/DeleteResponse")]
        System.Threading.Tasks.Task DeleteAsync(WorldMap.Model.UserRoleMapping entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserRoleMappingService/Update", ReplyAction="http://tempuri.org/IUserRoleMappingService/UpdateResponse")]
        void Update(WorldMap.Model.UserRoleMapping entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserRoleMappingService/Update", ReplyAction="http://tempuri.org/IUserRoleMappingService/UpdateResponse")]
        System.Threading.Tasks.Task UpdateAsync(WorldMap.Model.UserRoleMapping entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserRoleMappingService/SelectAll", ReplyAction="http://tempuri.org/IUserRoleMappingService/SelectAllResponse")]
        WorldMap.Model.UserRoleMapping[] SelectAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserRoleMappingService/SelectAll", ReplyAction="http://tempuri.org/IUserRoleMappingService/SelectAllResponse")]
        System.Threading.Tasks.Task<WorldMap.Model.UserRoleMapping[]> SelectAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserRoleMappingService/SelectById", ReplyAction="http://tempuri.org/IUserRoleMappingService/SelectByIdResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(WorldMap.Model.UserRoleMapping))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(WorldMap.Model.UserRoleMapping[]))]
        WorldMap.Model.UserRoleMapping SelectById(object id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserRoleMappingService/SelectById", ReplyAction="http://tempuri.org/IUserRoleMappingService/SelectByIdResponse")]
        System.Threading.Tasks.Task<WorldMap.Model.UserRoleMapping> SelectByIdAsync(object id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserRoleMappingServiceChannel : WorldMap.MVC.UserRoleMappingServiceReference.IUserRoleMappingService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserRoleMappingServiceClient : System.ServiceModel.ClientBase<WorldMap.MVC.UserRoleMappingServiceReference.IUserRoleMappingService>, WorldMap.MVC.UserRoleMappingServiceReference.IUserRoleMappingService {
        
        public UserRoleMappingServiceClient() {
        }
        
        public UserRoleMappingServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserRoleMappingServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserRoleMappingServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserRoleMappingServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void Insert(WorldMap.Model.UserRoleMapping entity) {
            base.Channel.Insert(entity);
        }
        
        public System.Threading.Tasks.Task InsertAsync(WorldMap.Model.UserRoleMapping entity) {
            return base.Channel.InsertAsync(entity);
        }
        
        public void Delete(WorldMap.Model.UserRoleMapping entity) {
            base.Channel.Delete(entity);
        }
        
        public System.Threading.Tasks.Task DeleteAsync(WorldMap.Model.UserRoleMapping entity) {
            return base.Channel.DeleteAsync(entity);
        }
        
        public void Update(WorldMap.Model.UserRoleMapping entity) {
            base.Channel.Update(entity);
        }
        
        public System.Threading.Tasks.Task UpdateAsync(WorldMap.Model.UserRoleMapping entity) {
            return base.Channel.UpdateAsync(entity);
        }
        
        public WorldMap.Model.UserRoleMapping[] SelectAll() {
            return base.Channel.SelectAll();
        }
        
        public System.Threading.Tasks.Task<WorldMap.Model.UserRoleMapping[]> SelectAllAsync() {
            return base.Channel.SelectAllAsync();
        }
        
        public WorldMap.Model.UserRoleMapping SelectById(object id) {
            return base.Channel.SelectById(id);
        }
        
        public System.Threading.Tasks.Task<WorldMap.Model.UserRoleMapping> SelectByIdAsync(object id) {
            return base.Channel.SelectByIdAsync(id);
        }
    }
}
