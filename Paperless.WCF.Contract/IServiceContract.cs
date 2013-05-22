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
        Documento[] ObtenerDocumentosAuditoria(string usuarioEmisor, string usuarioReceptor, string departamento, string tipoDocumento, DateTime fechaEmision, DateTime fechaRecepción);

        [OperationContract]
        DocumentoDetalleMovimiento[] ObtenerDetalleDocumentoAuditoria(string nombreDocumento);

        [OperationContract]
        Documento[] ObtenerTodosDocumentosAuditoria();

        [OperationContract]
        Documento[] ObtenerDocumentosPorMigrar();

        [OperationContract]
        bool ActualizarEstadoDocumento(int idDocumento);

        [OperationContract]
        Documento[] ObtenerDocumentosDeUsuario(string nombreUsuario);

        [OperationContract]
        Documento ObtenerDocumento(int idDocumento);

        [OperationContract]
        DocumentoDetalleRecibo[] ObtenerDetalleDocumento(int idDocumento);

        [OperationContract]
        void MarcarLeido(int idDocumento, string nombreUsuario);

        [OperationContract]
        bool FirmarDocumento(int idDocumento, string nombreUsuario, string password);
        #endregion

        #region Metodos Usuario
        [OperationContract]
        String LogIn(string nombreUsuario, string contrasena);

        [OperationContract]
        Usuario[] ObtenerUsuario(String nombreUsuario);

        [OperationContract]
        Usuario[] ObtenerTodosUsuarios();

        [OperationContract]
        Usuario[] ObtenerUsuariosXDepartamento(string pDepartamento);

        [OperationContract]
        DocumentoDetalleMovimiento[] ObtenerDetalleUsuarioAuditoria(string nombreUsuario);

        [OperationContract]
        int EnviarDocumento(List<Usuario> pLstDestinatarios, Documento pDocumento);
        #endregion

        #region Metodos Eventos

        [OperationContract]
        Evento[] ObtenerEventosIrregulares();
        #endregion

        #region Metodos Varios
        [OperationContract]
        String[] ObtenerDepartamentos();

        [OperationContract]
        String[] ObtenerTiposDocumento();
        #endregion
    }
}
