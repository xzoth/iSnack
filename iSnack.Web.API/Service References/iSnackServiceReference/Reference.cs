﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.17929
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace iSnack.Web.API.iSnackServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProductEntity", Namespace="http://schemas.datacontract.org/2004/07/iSnack.Service.Data.Demo")]
    [System.SerializableAttribute()]
    public partial class ProductEntity : iSnack.Web.API.iSnackServiceReference.iSnackEntity {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CategoryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid IDField;
        
        private string NameField;
        
        private decimal PriceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RemarkField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Category {
            get {
                return this.CategoryField;
            }
            set {
                if ((object.ReferenceEquals(this.CategoryField, value) != true)) {
                    this.CategoryField = value;
                    this.RaisePropertyChanged("Category");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid ID {
            get {
                return this.IDField;
            }
            set {
                if ((this.IDField.Equals(value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public decimal Price {
            get {
                return this.PriceField;
            }
            set {
                if ((this.PriceField.Equals(value) != true)) {
                    this.PriceField = value;
                    this.RaisePropertyChanged("Price");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Remark {
            get {
                return this.RemarkField;
            }
            set {
                if ((object.ReferenceEquals(this.RemarkField, value) != true)) {
                    this.RemarkField = value;
                    this.RaisePropertyChanged("Remark");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="iSnackEntity", Namespace="http://schemas.datacontract.org/2004/07/iSnack.Service.Data")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(iSnack.Web.API.iSnackServiceReference.ProductEntity))]
    public partial class iSnackEntity : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="iSnackServiceReference.IProductService")]
    public interface IProductService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetAll", ReplyAction="http://tempuri.org/IProductService/GetAllResponse")]
        System.Collections.Generic.List<iSnack.Web.API.iSnackServiceReference.ProductEntity> GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetByID", ReplyAction="http://tempuri.org/IProductService/GetByIDResponse")]
        iSnack.Web.API.iSnackServiceReference.ProductEntity GetByID(System.Guid id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetByCategory", ReplyAction="http://tempuri.org/IProductService/GetByCategoryResponse")]
        System.Collections.Generic.List<iSnack.Web.API.iSnackServiceReference.ProductEntity> GetByCategory(string strCategory);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/Update", ReplyAction="http://tempuri.org/IProductService/UpdateResponse")]
        bool Update(iSnack.Web.API.iSnackServiceReference.ProductEntity entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/Create", ReplyAction="http://tempuri.org/IProductService/CreateResponse")]
        bool Create(iSnack.Web.API.iSnackServiceReference.ProductEntity entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/Delete", ReplyAction="http://tempuri.org/IProductService/DeleteResponse")]
        bool Delete(System.Guid id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IProductServiceChannel : iSnack.Web.API.iSnackServiceReference.IProductService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ProductServiceClient : System.ServiceModel.ClientBase<iSnack.Web.API.iSnackServiceReference.IProductService>, iSnack.Web.API.iSnackServiceReference.IProductService {
        
        public ProductServiceClient() {
        }
        
        public ProductServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ProductServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<iSnack.Web.API.iSnackServiceReference.ProductEntity> GetAll() {
            return base.Channel.GetAll();
        }
        
        public iSnack.Web.API.iSnackServiceReference.ProductEntity GetByID(System.Guid id) {
            return base.Channel.GetByID(id);
        }
        
        public System.Collections.Generic.List<iSnack.Web.API.iSnackServiceReference.ProductEntity> GetByCategory(string strCategory) {
            return base.Channel.GetByCategory(strCategory);
        }
        
        public bool Update(iSnack.Web.API.iSnackServiceReference.ProductEntity entity) {
            return base.Channel.Update(entity);
        }
        
        public bool Create(iSnack.Web.API.iSnackServiceReference.ProductEntity entity) {
            return base.Channel.Create(entity);
        }
        
        public bool Delete(System.Guid id) {
            return base.Channel.Delete(id);
        }
    }
}
