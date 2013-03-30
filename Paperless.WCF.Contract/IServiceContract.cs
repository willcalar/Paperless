using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Paperless.Library;

namespace Paperless.WCF.Contract
{

    [ServiceContract]
    public interface IServiceContract
    {

        #region Metodos Documentos
        [OperationContract]
        Documento[] ObtenerDocumentos(string usuarioEmisor, string usuarioReceptor, string departamento, string tipoDocumento, DateTime fechaEmision, DateTime fechaRecepción);

        [OperationContract]
        Historial[] ObtenerHistorialDocumento(int idDocumento);

        [OperationContract]
        Documento[] ObtenerDocumentosPorMigrar();

        [OperationContract]
        Documento[] ObtenerDocumentosUsuario(string nombreUsuario);
        #endregion

        #region Metodos Usuario
        [OperationContract]
        bool LogOn(string nombreUsuario, string contrasena);

        [OperationContract]
        Usuario[] ObtenerUsuario(String nombreUsuario);

        [OperationContract]
        Historial[] ObtenerHistorialUsuario(string nombreUsuario);
        #endregion

        #region Metodos Eventos
        [OperationContract]
        Evento[] ObtenerEventos();
        #endregion
    }
}
