﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18034
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Paperless.DataAccessPlugins.WebService {
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
        private byte[] ArchivoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int EstadoFirmasField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime FechaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FormatoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdDocumentoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool LeidoField;
        
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
        public byte[] Archivo {
            get {
                return this.ArchivoField;
            }
            set {
                if ((object.ReferenceEquals(this.ArchivoField, value) != true)) {
                    this.ArchivoField = value;
                    this.RaisePropertyChanged("Archivo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int EstadoFirmas {
            get {
                return this.EstadoFirmasField;
            }
            set {
                if ((this.EstadoFirmasField.Equals(value) != true)) {
                    this.EstadoFirmasField = value;
                    this.RaisePropertyChanged("EstadoFirmas");
                }
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
        public string Formato {
            get {
                return this.FormatoField;
            }
            set {
                if ((object.ReferenceEquals(this.FormatoField, value) != true)) {
                    this.FormatoField = value;
                    this.RaisePropertyChanged("Formato");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdDocumento {
            get {
                return this.IdDocumentoField;
            }
            set {
                if ((this.IdDocumentoField.Equals(value) != true)) {
                    this.IdDocumentoField = value;
                    this.RaisePropertyChanged("IdDocumento");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Leido {
            get {
                return this.LeidoField;
            }
            set {
                if ((this.LeidoField.Equals(value) != true)) {
                    this.LeidoField = value;
                    this.RaisePropertyChanged("Leido");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="DocumentoDetalleMovimiento", Namespace="http://schemas.datacontract.org/2004/07/Paperless.Library")]
    [System.SerializableAttribute()]
    public partial class DocumentoDetalleMovimiento : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime FechaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreDocumentoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RutaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TipoAccionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsuarioField;
        
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
        public string Ruta {
            get {
                return this.RutaField;
            }
            set {
                if ((object.ReferenceEquals(this.RutaField, value) != true)) {
                    this.RutaField = value;
                    this.RaisePropertyChanged("Ruta");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TipoAccion {
            get {
                return this.TipoAccionField;
            }
            set {
                if ((object.ReferenceEquals(this.TipoAccionField, value) != true)) {
                    this.TipoAccionField = value;
                    this.RaisePropertyChanged("TipoAccion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Usuario {
            get {
                return this.UsuarioField;
            }
            set {
                if ((object.ReferenceEquals(this.UsuarioField, value) != true)) {
                    this.UsuarioField = value;
                    this.RaisePropertyChanged("Usuario");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="DocumentoDetalleRecibo", Namespace="http://schemas.datacontract.org/2004/07/Paperless.Library")]
    [System.SerializableAttribute()]
    public partial class DocumentoDetalleRecibo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmisorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int EstadoFirmasField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime FechaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreDocumentoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ReceptorField;
        
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
        public string Emisor {
            get {
                return this.EmisorField;
            }
            set {
                if ((object.ReferenceEquals(this.EmisorField, value) != true)) {
                    this.EmisorField = value;
                    this.RaisePropertyChanged("Emisor");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int EstadoFirmas {
            get {
                return this.EstadoFirmasField;
            }
            set {
                if ((this.EstadoFirmasField.Equals(value) != true)) {
                    this.EstadoFirmasField = value;
                    this.RaisePropertyChanged("EstadoFirmas");
                }
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
        public string Receptor {
            get {
                return this.ReceptorField;
            }
            set {
                if ((object.ReferenceEquals(this.ReceptorField, value) != true)) {
                    this.ReceptorField = value;
                    this.RaisePropertyChanged("Receptor");
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
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsernameField;
        
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
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Username {
            get {
                return this.UsernameField;
            }
            set {
                if ((object.ReferenceEquals(this.UsernameField, value) != true)) {
                    this.UsernameField = value;
                    this.RaisePropertyChanged("Username");
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
        private int IDReferenciaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreDocumentoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreUsuarioField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OrigenField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TipoEventoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string _RevisadoField;
        
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
        public int IDReferencia {
            get {
                return this.IDReferenciaField;
            }
            set {
                if ((this.IDReferenciaField.Equals(value) != true)) {
                    this.IDReferenciaField = value;
                    this.RaisePropertyChanged("IDReferencia");
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
        public string Origen {
            get {
                return this.OrigenField;
            }
            set {
                if ((object.ReferenceEquals(this.OrigenField, value) != true)) {
                    this.OrigenField = value;
                    this.RaisePropertyChanged("Origen");
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
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string _Revisado {
            get {
                return this._RevisadoField;
            }
            set {
                if ((object.ReferenceEquals(this._RevisadoField, value) != true)) {
                    this._RevisadoField = value;
                    this.RaisePropertyChanged("_Revisado");
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
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/ObtenerDocumentosAuditoria", ReplyAction="http://tempuri.org/IServiceContract/ObtenerDocumentosAuditoriaResponse")]
        Paperless.DataAccessPlugins.WebService.Documento[] ObtenerDocumentosAuditoria(string usuarioEmisor, string usuarioReceptor, string departamento, string tipoDocumento, System.DateTime fechaEmision, System.DateTime fechaRecepción);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/ObtenerDetalleDocumentoAuditoria", ReplyAction="http://tempuri.org/IServiceContract/ObtenerDetalleDocumentoAuditoriaResponse")]
        Paperless.DataAccessPlugins.WebService.DocumentoDetalleMovimiento[] ObtenerDetalleDocumentoAuditoria(string nombreDocumento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/ObtenerTodosDocumentosAuditoria", ReplyAction="http://tempuri.org/IServiceContract/ObtenerTodosDocumentosAuditoriaResponse")]
        Paperless.DataAccessPlugins.WebService.Documento[] ObtenerTodosDocumentosAuditoria();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/ObtenerDocumentosPorMigrar", ReplyAction="http://tempuri.org/IServiceContract/ObtenerDocumentosPorMigrarResponse")]
        Paperless.DataAccessPlugins.WebService.Documento[] ObtenerDocumentosPorMigrar();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/ObtenerDocumentosDeUsuario", ReplyAction="http://tempuri.org/IServiceContract/ObtenerDocumentosDeUsuarioResponse")]
        Paperless.DataAccessPlugins.WebService.Documento[] ObtenerDocumentosDeUsuario(string nombreUsuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/ObtenerDocumento", ReplyAction="http://tempuri.org/IServiceContract/ObtenerDocumentoResponse")]
        Paperless.DataAccessPlugins.WebService.Documento ObtenerDocumento(int idDocumento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/ObtenerDetalleDocumento", ReplyAction="http://tempuri.org/IServiceContract/ObtenerDetalleDocumentoResponse")]
        Paperless.DataAccessPlugins.WebService.DocumentoDetalleRecibo[] ObtenerDetalleDocumento(int idDocumento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/MarcarLeido", ReplyAction="http://tempuri.org/IServiceContract/MarcarLeidoResponse")]
        void MarcarLeido(int idDocumento, string nombreUsuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/FirmarDocumento", ReplyAction="http://tempuri.org/IServiceContract/FirmarDocumentoResponse")]
        bool FirmarDocumento(int idDocumento, string nombreUsuario, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/LogIn", ReplyAction="http://tempuri.org/IServiceContract/LogInResponse")]
        string LogIn(string nombreUsuario, string contrasena);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/ObtenerUsuario", ReplyAction="http://tempuri.org/IServiceContract/ObtenerUsuarioResponse")]
        Paperless.DataAccessPlugins.WebService.Usuario[] ObtenerUsuario(string nombreUsuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/ObtenerTodosUsuarios", ReplyAction="http://tempuri.org/IServiceContract/ObtenerTodosUsuariosResponse")]
        Paperless.DataAccessPlugins.WebService.Usuario[] ObtenerTodosUsuarios();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/ObtenerUsuariosXDepartamento", ReplyAction="http://tempuri.org/IServiceContract/ObtenerUsuariosXDepartamentoResponse")]
        Paperless.DataAccessPlugins.WebService.Usuario[] ObtenerUsuariosXDepartamento(string pDepartamento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/ObtenerDetalleUsuarioAuditoria", ReplyAction="http://tempuri.org/IServiceContract/ObtenerDetalleUsuarioAuditoriaResponse")]
        Paperless.DataAccessPlugins.WebService.DocumentoDetalleMovimiento[] ObtenerDetalleUsuarioAuditoria(string nombreUsuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/EnviarDocumento", ReplyAction="http://tempuri.org/IServiceContract/EnviarDocumentoResponse")]
        bool EnviarDocumento(Paperless.DataAccessPlugins.WebService.Usuario[] pLstDestinatarios, Paperless.DataAccessPlugins.WebService.Documento pDocumento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/ObtenerEventosIrregulares", ReplyAction="http://tempuri.org/IServiceContract/ObtenerEventosIrregularesResponse")]
        Paperless.DataAccessPlugins.WebService.Evento[] ObtenerEventosIrregulares();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/ObtenerDepartamentos", ReplyAction="http://tempuri.org/IServiceContract/ObtenerDepartamentosResponse")]
        string[] ObtenerDepartamentos();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceContract/ObtenerTiposDocumento", ReplyAction="http://tempuri.org/IServiceContract/ObtenerTiposDocumentoResponse")]
        string[] ObtenerTiposDocumento();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceContractChannel : Paperless.DataAccessPlugins.WebService.IServiceContract, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceContractClient : System.ServiceModel.ClientBase<Paperless.DataAccessPlugins.WebService.IServiceContract>, Paperless.DataAccessPlugins.WebService.IServiceContract {
        
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
        
        public Paperless.DataAccessPlugins.WebService.Documento[] ObtenerDocumentosAuditoria(string usuarioEmisor, string usuarioReceptor, string departamento, string tipoDocumento, System.DateTime fechaEmision, System.DateTime fechaRecepción) {
            return base.Channel.ObtenerDocumentosAuditoria(usuarioEmisor, usuarioReceptor, departamento, tipoDocumento, fechaEmision, fechaRecepción);
        }
        
        public Paperless.DataAccessPlugins.WebService.DocumentoDetalleMovimiento[] ObtenerDetalleDocumentoAuditoria(string nombreDocumento) {
            return base.Channel.ObtenerDetalleDocumentoAuditoria(nombreDocumento);
        }
        
        public Paperless.DataAccessPlugins.WebService.Documento[] ObtenerTodosDocumentosAuditoria() {
            return base.Channel.ObtenerTodosDocumentosAuditoria();
        }
        
        public Paperless.DataAccessPlugins.WebService.Documento[] ObtenerDocumentosPorMigrar() {
            return base.Channel.ObtenerDocumentosPorMigrar();
        }
        
        public Paperless.DataAccessPlugins.WebService.Documento[] ObtenerDocumentosDeUsuario(string nombreUsuario) {
            return base.Channel.ObtenerDocumentosDeUsuario(nombreUsuario);
        }
        
        public Paperless.DataAccessPlugins.WebService.Documento ObtenerDocumento(int idDocumento) {
            return base.Channel.ObtenerDocumento(idDocumento);
        }
        
        public Paperless.DataAccessPlugins.WebService.DocumentoDetalleRecibo[] ObtenerDetalleDocumento(int idDocumento) {
            return base.Channel.ObtenerDetalleDocumento(idDocumento);
        }
        
        public void MarcarLeido(int idDocumento, string nombreUsuario) {
            base.Channel.MarcarLeido(idDocumento, nombreUsuario);
        }
        
        public bool FirmarDocumento(int idDocumento, string nombreUsuario, string password) {
            return base.Channel.FirmarDocumento(idDocumento, nombreUsuario, password);
        }
        
        public string LogIn(string nombreUsuario, string contrasena) {
            return base.Channel.LogIn(nombreUsuario, contrasena);
        }
        
        public Paperless.DataAccessPlugins.WebService.Usuario[] ObtenerUsuario(string nombreUsuario) {
            return base.Channel.ObtenerUsuario(nombreUsuario);
        }
        
        public Paperless.DataAccessPlugins.WebService.Usuario[] ObtenerTodosUsuarios() {
            return base.Channel.ObtenerTodosUsuarios();
        }
        
        public Paperless.DataAccessPlugins.WebService.Usuario[] ObtenerUsuariosXDepartamento(string pDepartamento) {
            return base.Channel.ObtenerUsuariosXDepartamento(pDepartamento);
        }
        
        public Paperless.DataAccessPlugins.WebService.DocumentoDetalleMovimiento[] ObtenerDetalleUsuarioAuditoria(string nombreUsuario) {
            return base.Channel.ObtenerDetalleUsuarioAuditoria(nombreUsuario);
        }
        
        public bool EnviarDocumento(Paperless.DataAccessPlugins.WebService.Usuario[] pLstDestinatarios, Paperless.DataAccessPlugins.WebService.Documento pDocumento) {
            return base.Channel.EnviarDocumento(pLstDestinatarios, pDocumento);
        }
        
        public Paperless.DataAccessPlugins.WebService.Evento[] ObtenerEventosIrregulares() {
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
