﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Paperless.UI.WebService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Documento", Namespace="http://schemas.datacontract.org/2004/07/Paperless.Library")]
    [System.SerializableAttribute()]
    public partial class Documento : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime FechaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreDocumentoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreUsuarioEmisorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreUsuarioReceptorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TipoDocumentoField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Fecha {
            get {
                return this.FechaField;
            }
            set {
                if ((this.FechaField.Equals(value) != true)) {
                    this.FechaField = value;
                    this.RaisePropertyChanged("Fecha");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NombreDocumento {
            get {
                return this.NombreDocumentoField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreDocumentoField, value) != true)) {
                    this.NombreDocumentoField = value;
                    this.RaisePropertyChanged("NombreDocumento");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NombreUsuarioEmisor {
            get {
                return this.NombreUsuarioEmisorField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreUsuarioEmisorField, value) != true)) {
                    this.NombreUsuarioEmisorField = value;
                    this.RaisePropertyChanged("NombreUsuarioEmisor");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NombreUsuarioReceptor {
            get {
                return this.NombreUsuarioReceptorField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreUsuarioReceptorField, value) != true)) {
                    this.NombreUsuarioReceptorField = value;
                    this.RaisePropertyChanged("NombreUsuarioReceptor");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TipoDocumento {
            get {
                return this.TipoDocumentoField;
            }
            set {
                if ((object.ReferenceEquals(this.TipoDocumentoField, value) != true)) {
                    this.TipoDocumentoField = value;
                    this.RaisePropertyChanged("TipoDocumento");
                }
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Historial", Namespace="http://schemas.datacontract.org/2004/07/Paperless.Library")]
    [System.SerializableAttribute()]
    public partial class Historial : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Usuario", Namespace="http://schemas.datacontract.org/2004/07/Paperless.Library")]
    [System.SerializableAttribute()]
    public partial class Usuario : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DepartamentoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreUsuarioField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PrimerApellidoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SegundoApellidoField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Departamento {
            get {
                return this.DepartamentoField;
            }
            set {
                if ((object.ReferenceEquals(this.DepartamentoField, value) != true)) {
                    this.DepartamentoField = value;
                    this.RaisePropertyChanged("Departamento");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NombreUsuario {
            get {
                return this.NombreUsuarioField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreUsuarioField, value) != true)) {
                    this.NombreUsuarioField = value;
                    this.RaisePropertyChanged("NombreUsuario");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PrimerApellido {
            get {
                return this.PrimerApellidoField;
            }
            set {
                if ((object.ReferenceEquals(this.PrimerApellidoField, value) != true)) {
                    this.PrimerApellidoField = value;
                    this.RaisePropertyChanged("PrimerApellido");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SegundoApellido {
            get {
                return this.SegundoApellidoField;
            }
            set {
                if ((object.ReferenceEquals(this.SegundoApellidoField, value) != true)) {
                    this.SegundoApellidoField = value;
                    this.RaisePropertyChanged("SegundoApellido");
                }
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Evento", Namespace="http://schemas.datacontract.org/2004/07/Paperless.Library")]
    [System.SerializableAttribute()]
    public partial class Evento : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescripcionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime FechaHoraField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreDocumentoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreUsuarioField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TipoEventoField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Descripcion {
            get {
                return this.DescripcionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescripcionField, value) != true)) {
                    this.DescripcionField = value;
                    this.RaisePropertyChanged("Descripcion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime FechaHora {
            get {
                return this.FechaHoraField;
            }
            set {
                if ((this.FechaHoraField.Equals(value) != true)) {
                    this.FechaHoraField = value;
                    this.RaisePropertyChanged("FechaHora");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NombreDocumento {
            get {
                return this.NombreDocumentoField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreDocumentoField, value) != true)) {
                    this.NombreDocumentoField = value;
                    this.RaisePropertyChanged("NombreDocumento");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NombreUsuario {
            get {
                return this.NombreUsuarioField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreUsuarioField, value) != true)) {
                    this.NombreUsuarioField = value;
                    this.RaisePropertyChanged("NombreUsuario");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TipoEvento {
            get {
                return this.TipoEventoField;
            }
            set {
                if ((object.ReferenceEquals(this.TipoEventoField, value) != true)) {
                    this.TipoEventoField = value;
                    this.RaisePropertyChanged("TipoEvento");
                }
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WebService.IServiceContract")]
    public interface IServiceContract {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/ObtenerDocumentos", ReplyAction="http://tempuri.org/IServiceContract/ObtenerDocumentosResponse")]
        Paperless.UI.WebService.Documento[] ObtenerDocumentos(string usuarioEmisor, string usuarioReceptor, string departamento, string tipoDocumento, System.DateTime fechaEmision, System.DateTime fechaRecepción);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/ObtenerHistorialDocumento", ReplyAction="http://tempuri.org/IServiceContract/ObtenerHistorialDocumentoResponse")]
        Paperless.UI.WebService.Historial[] ObtenerHistorialDocumento(int idDocumento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/ObtenerDocumentosPorMigrar", ReplyAction="http://tempuri.org/IServiceContract/ObtenerDocumentosPorMigrarResponse")]
        Paperless.UI.WebService.Documento[] ObtenerDocumentosPorMigrar();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/ObtenerDocumentosUsuario", ReplyAction="http://tempuri.org/IServiceContract/ObtenerDocumentosUsuarioResponse")]
        Paperless.UI.WebService.Documento[] ObtenerDocumentosUsuario(string nombreUsuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/LogOn", ReplyAction="http://tempuri.org/IServiceContract/LogOnResponse")]
        bool LogOn(string nombreUsuario, string contrasena);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/ObtenerUsuario", ReplyAction="http://tempuri.org/IServiceContract/ObtenerUsuarioResponse")]
        Paperless.UI.WebService.Usuario[] ObtenerUsuario(string nombreUsuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/ObtenerHistorialUsuario", ReplyAction="http://tempuri.org/IServiceContract/ObtenerHistorialUsuarioResponse")]
        Paperless.UI.WebService.Historial[] ObtenerHistorialUsuario(string nombreUsuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/ObtenerEventos", ReplyAction="http://tempuri.org/IServiceContract/ObtenerEventosResponse")]
        Paperless.UI.WebService.Evento[] ObtenerEventos();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/ObtenerEventosIrregulares", ReplyAction="http://tempuri.org/IServiceContract/ObtenerEventosIrregularesResponse")]
        Paperless.UI.WebService.Evento[] ObtenerEventosIrregulares();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/ObtenerDepartamentos", ReplyAction="http://tempuri.org/IServiceContract/ObtenerDepartamentosResponse")]
        string[] ObtenerDepartamentos();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/ObtenerTiposDocumento", ReplyAction="http://tempuri.org/IServiceContract/ObtenerTiposDocumentoResponse")]
        string[] ObtenerTiposDocumento();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceContractChannel : Paperless.UI.WebService.IServiceContract, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceContractClient : System.ServiceModel.ClientBase<Paperless.UI.WebService.IServiceContract>, Paperless.UI.WebService.IServiceContract {
        
        public ServiceContractClient() {
        }
        
        public ServiceContractClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceContractClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceContractClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceContractClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Paperless.UI.WebService.Documento[] ObtenerDocumentos(string usuarioEmisor, string usuarioReceptor, string departamento, string tipoDocumento, System.DateTime fechaEmision, System.DateTime fechaRecepción) {
            return base.Channel.ObtenerDocumentos(usuarioEmisor, usuarioReceptor, departamento, tipoDocumento, fechaEmision, fechaRecepción);
        }
        
        public Paperless.UI.WebService.Historial[] ObtenerHistorialDocumento(int idDocumento) {
            return base.Channel.ObtenerHistorialDocumento(idDocumento);
        }
        
        public Paperless.UI.WebService.Documento[] ObtenerDocumentosPorMigrar() {
            return base.Channel.ObtenerDocumentosPorMigrar();
        }
        
        public Paperless.UI.WebService.Documento[] ObtenerDocumentosUsuario(string nombreUsuario) {
            return base.Channel.ObtenerDocumentosUsuario(nombreUsuario);
        }
        
        public bool LogOn(string nombreUsuario, string contrasena) {
            return base.Channel.LogOn(nombreUsuario, contrasena);
        }
        
        public Paperless.UI.WebService.Usuario[] ObtenerUsuario(string nombreUsuario) {
            return base.Channel.ObtenerUsuario(nombreUsuario);
        }
        
        public Paperless.UI.WebService.Historial[] ObtenerHistorialUsuario(string nombreUsuario) {
            return base.Channel.ObtenerHistorialUsuario(nombreUsuario);
        }
        
        public Paperless.UI.WebService.Evento[] ObtenerEventos() {
            return base.Channel.ObtenerEventos();
        }
        
        public Paperless.UI.WebService.Evento[] ObtenerEventosIrregulares() {
            return base.Channel.ObtenerEventosIrregulares();
        }
        
        public string[] ObtenerDepartamentos() {
            return base.Channel.ObtenerDepartamentos();
        }
        
        public string[] ObtenerTiposDocumento() {
            return base.Channel.ObtenerTiposDocumento();
        }
    }
}
