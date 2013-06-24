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
        Documento[] ObtenerDocumentosAuditoria(string pUsuarioEmisor, string pUsuarioReceptor, string pDepartamento, string pTipoDocumento, DateTime pFechaEmision, DateTime pFechaRecepción);

        [OperationContract]
        DocumentoDetalleMovimiento[] ObtenerDetalleDocumentoAuditoria(string pNombreDocumento);

        [OperationContract]
        Documento[] ObtenerTodosDocumentosAuditoria();

        [OperationContract]
        Documento[] ObtenerDocumentosPorMigrar();

        [OperationContract]
        bool ActualizarEstadoDocumento(int pIdDocumento);

        [OperationContract]
        Documento[] ObtenerDocumentosDeUsuario(string pNombreUsuario);

        [OperationContract]
        Documento ObtenerDocumento(int idDocumento);

        [OperationContract]
        DocumentoDetalleRecibo[] ObtenerDetalleDocumento(int pIdDocumento);

        [OperationContract]
        void MarcarLeido(int pIdDocumento, string pNombreUsuario);

        [OperationContract]
        bool FirmarDocumento(int pIdDocumento, string pNombreUsuario, string pPassword);
        #endregion

        #region Metodos Usuario
        [OperationContract]
        String LogIn(string pNombreUsuario, string pContrasena);

        [OperationContract]
        Usuario[] ObtenerUsuario(String pNombreUsuario);

        [OperationContract]
        Usuario[] ObtenerTodosUsuarios();

        [OperationContract]
        Usuario[] ObtenerUsuariosXDepartamento(string pDepartamento);

        [OperationContract]
        DocumentoDetalleMovimiento[] ObtenerDetalleUsuarioAuditoria(string pNombreUsuario);

        [OperationContract]
        int EnviarDocumento(List<Usuario> pListaDestinatarios, Documento pDocumento);
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
