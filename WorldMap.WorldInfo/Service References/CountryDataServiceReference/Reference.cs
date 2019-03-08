﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WorldMap.WorldInfo.CountryDataServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CountryDataServiceReference.ICountryDataService")]
    public interface ICountryDataService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICountryDataService/Insert", ReplyAction="http://tempuri.org/ICountryDataService/InsertResponse")]
        void Insert(WorldMap.Model.CountryData entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICountryDataService/Insert", ReplyAction="http://tempuri.org/ICountryDataService/InsertResponse")]
        System.Threading.Tasks.Task InsertAsync(WorldMap.Model.CountryData entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICountryDataService/Delete", ReplyAction="http://tempuri.org/ICountryDataService/DeleteResponse")]
        void Delete(WorldMap.Model.CountryData entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICountryDataService/Delete", ReplyAction="http://tempuri.org/ICountryDataService/DeleteResponse")]
        System.Threading.Tasks.Task DeleteAsync(WorldMap.Model.CountryData entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICountryDataService/Update", ReplyAction="http://tempuri.org/ICountryDataService/UpdateResponse")]
        void Update(WorldMap.Model.CountryData entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICountryDataService/Update", ReplyAction="http://tempuri.org/ICountryDataService/UpdateResponse")]
        System.Threading.Tasks.Task UpdateAsync(WorldMap.Model.CountryData entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICountryDataService/SelectAll", ReplyAction="http://tempuri.org/ICountryDataService/SelectAllResponse")]
        WorldMap.Model.CountryData[] SelectAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICountryDataService/SelectAll", ReplyAction="http://tempuri.org/ICountryDataService/SelectAllResponse")]
        System.Threading.Tasks.Task<WorldMap.Model.CountryData[]> SelectAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICountryDataService/SelectById", ReplyAction="http://tempuri.org/ICountryDataService/SelectByIdResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(WorldMap.Model.CountryData))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(WorldMap.Model.OverseasTerritoriesData[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(WorldMap.Model.OverseasTerritoriesData))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(WorldMap.Model.StateData[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(WorldMap.Model.StateData))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(WorldMap.Model.CityData[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(WorldMap.Model.CityData))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(WorldMap.Model.CountryData[]))]
        WorldMap.Model.CountryData SelectById(object id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICountryDataService/SelectById", ReplyAction="http://tempuri.org/ICountryDataService/SelectByIdResponse")]
        System.Threading.Tasks.Task<WorldMap.Model.CountryData> SelectByIdAsync(object id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICountryDataServiceChannel : WorldMap.WorldInfo.CountryDataServiceReference.ICountryDataService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CountryDataServiceClient : System.ServiceModel.ClientBase<WorldMap.WorldInfo.CountryDataServiceReference.ICountryDataService>, WorldMap.WorldInfo.CountryDataServiceReference.ICountryDataService {
        
        public CountryDataServiceClient() {
        }
        
        public CountryDataServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CountryDataServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CountryDataServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CountryDataServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void Insert(WorldMap.Model.CountryData entity) {
            base.Channel.Insert(entity);
        }
        
        public System.Threading.Tasks.Task InsertAsync(WorldMap.Model.CountryData entity) {
            return base.Channel.InsertAsync(entity);
        }
        
        public void Delete(WorldMap.Model.CountryData entity) {
            base.Channel.Delete(entity);
        }
        
        public System.Threading.Tasks.Task DeleteAsync(WorldMap.Model.CountryData entity) {
            return base.Channel.DeleteAsync(entity);
        }
        
        public void Update(WorldMap.Model.CountryData entity) {
            base.Channel.Update(entity);
        }
        
        public System.Threading.Tasks.Task UpdateAsync(WorldMap.Model.CountryData entity) {
            return base.Channel.UpdateAsync(entity);
        }
        
        public WorldMap.Model.CountryData[] SelectAll() {
            return base.Channel.SelectAll();
        }
        
        public System.Threading.Tasks.Task<WorldMap.Model.CountryData[]> SelectAllAsync() {
            return base.Channel.SelectAllAsync();
        }
        
        public WorldMap.Model.CountryData SelectById(object id) {
            return base.Channel.SelectById(id);
        }
        
        public System.Threading.Tasks.Task<WorldMap.Model.CountryData> SelectByIdAsync(object id) {
            return base.Channel.SelectByIdAsync(id);
        }
    }
}
