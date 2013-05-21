using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Paperless.Library;
using Paperless.Implementor;
using Paperless.WCF.Contract;

namespace Paperless.Orchestrator
{
    public class WCFOrchestrator:IServiceContract
    {
        #region Metodos Documento

        /// <summary>
        /// Obtiene los documentos para la pantalla de Auditoía de Documentos
        /// </summary>
        /// <param name="usuarioEmisor">Parámetro de búsqueda</param>
        /// <param name="usuarioReceptor">Parámetro de búsqueda</param>
        /// <param name="departamento">Parámetro de búsqueda</param>
        /// <param name="tipoDocumento">Parámetro de búsqueda</param>
        /// <param name="fechaEmision">Parámetro de búsqueda</param>
        /// <param name="fechaRecepcion">Parámetro de búsqueda</param>
        /// <returns>Arreglo de Documentos que cumple con los parametros de la búsqueda</returns>
        public Documento[] ObtenerDocumentosAuditoria(string usuarioEmisor, string usuarioReceptor, string departamento, string tipoDocumento, DateTime fechaEmision, DateTime fechaRecepción)
        {
            return DocumentosImplementor.Instance.ObtenerDocumentosAuditoria(usuarioEmisor, usuarioReceptor, departamento, tipoDocumento, fechaEmision, fechaRecepción);
        }  

        /// <summary>
        /// Obtiene documentos para auditoria
        /// </summary>
        /// <returns>Lista de todos los documentos ingresados en el sistema</returns>
        public Documento[] ObtenerTodosDocumentosAuditoria()
        {
            return DocumentosImplementor.Instance.ObtenerDocumentosAuditoria();
        }

        /// <summary>
        /// Obtiene la lista de movimientos asociados a un documento
        /// </summary>
        /// <param name="nombreDocumento">nombre del documento</param>
        /// <returns></returns>
        public DocumentoDetalleMovimiento[] ObtenerDetalleDocumentoAuditoria(string nombreDocumento)
        {
            return DocumentosImplementor.Instance.ObtenerDetalleDocumentoAuditoria(nombreDocumento);
        }

        /// <summary>
        /// Obtiene documentos por migrar del sistema
        /// </summary>
        /// <returns>Lista de documentos que deberían migrarse</returns>
        public Documento[] ObtenerDocumentosPorMigrar()
        {
            return DocumentosImplementor.Instance.ObtenerDocumentosPorMigrar();
        }      

        /// <summary>
        /// Obtiene la lista de documentos en que un usuario participó como emisor o receptor
        /// </summary>
        /// <param name="nombreUsuario">Nombre de usuario</param>
        /// <returns>Lista de documentos del usuario</returns>
        public Documento[] ObtenerDocumentosDeUsuario(string nombreUsuario)
        {
            return DocumentosImplementor.Instance.ObtenerDocumentosDeUsuario(nombreUsuario);
        }

        /// <summary>
        /// Obtiene el documento asociado al id indicado
        /// </summary>
        /// <param name="idDocumento">Id de documento a consultar</param>
        /// <returns>Documento asociado al id indicado</returns>
        public Documento ObtenerDocumento(int idDocumento)
        {
            return DocumentosImplementor.Instance.ObtenerDocumento(idDocumento);
        }

        /// <summary>
        /// Obtiene el detalle del estado del documento asociado al id indicado
        /// </summary>
        /// <param name="idDocumento">Id de documento a consultar</param>
        /// <returns>Lista de estados del documento para los diferentes receptores del mismo</returns>
        public DocumentoDetalleRecibo[] ObtenerDetalleDocumento(int idDocumento)
        {
            return DocumentosImplementor.Instance.ObtenerDetalleDocumento(idDocumento);
        }

        /// <summary>
        /// Obtiene el documento asociado al id indicado
        /// </summary>
        /// <param name="idDocumento">Id de documento a consultar</param>
        /// <returns>Documento asociado al id indicado</returns>
        public void MarcarLeido(int idDocumento, string nombreUsuario)
        {
            DocumentosImplementor.Instance.MarcarLeido(idDocumento, nombreUsuario);
        }

        /// <summary>
        /// Marca como firmado por un usuario un documento
        /// </summary>
        /// <param name="idDocumento">id del documento</param>
        /// <param name="nombreUsuario">username del usuario</param>
        /// <param name="password">password del usuario</param>
        public bool FirmarDocumento(int idDocumento, string nombreUsuario, string password)
        {
            return DocumentosImplementor.Instance.FirmarDocumento(idDocumento, nombreUsuario, password);
        }

        #endregion

        #region Metodos Usuario
        /// <summary>
        /// Verifica el login del usuario
        /// </summary>
        /// <param name="nombreUsuario">Nombre de usuario</param>
        /// <param name="contrasena">Contraseña del usuario</param>
        /// <returns>Nombre del funcionario</returns>
        public String LogIn(string nombreUsuario, string contrasena)
        {
            return UsuariosImplementor.Instance.LogInUsuario(nombreUsuario, contrasena);
        }

        /// <summary>
        /// Obtiene una lista de usuarios con el siguiente nombre de usuario (parcial o no parcial)
        /// </summary>
        /// <param name="nombreUsuario">Nombre de usuario</param>
        /// <returns>Lista de usuarios que concuerda con el parametro ingresado</returns>
        public Usuario[] ObtenerUsuario(string nombreUsuario)
        {
            return UsuariosImplementor.Instance.ObtenerUsuario(nombreUsuario);
        }

        /// <summary>
        /// Obtiene todos los usuarios activo
        /// </summary>
        /// <returns>Lista de usuarios que concuerda con el parametro ingresado</returns>
        public Usuario[] ObtenerTodosUsuarios()
        {
            return UsuariosImplementor.Instance.ObtenerTodosUsuarios();
        }


        /// <summary>
        /// Obtiene la lista de movimientos asociados a un usuario
        /// </summary>
        /// <param name="nombreUsuario">nombre del usuario</param>
        /// <returns></returns>
        public DocumentoDetalleMovimiento[] ObtenerDetalleUsuarioAuditoria(string nombreUsuario)
        {
            return UsuariosImplementor.Instance.ObtenerDetalleUsuarioAuditoria(nombreUsuario);
        }

        /// <summary>
        /// Envía un documento a los destinatarios correspondientes
        /// </summary>
        /// <param name="pLstDestinatarios">Lista de destinatarios</param>
        /// <param name="pDocumento">Documento a enviar</param>
        /// <returns></returns>
        public bool EnviarDocumento(List<Usuario> pLstDestinatarios, Documento pDocumento)
        {
            return DocumentosImplementor.Instance.EnviarDocumento(pLstDestinatarios, pDocumento);
        }
        #endregion

        #region Metodos Evento

        /// <summary>
        /// Obtiene la lista de eventos irregulares del sistema
        /// </summary>
        /// <returns>Lista de eventos en el sistema sin revisar</returns>
        public Evento[] ObtenerEventosIrregulares()
        {
            return EventosImplementor.Instance.ObtenerEventosIrregulares();
        }
        #endregion        

        #region Varios
        /// <summary>
        /// Obtiene departamentos registrados en el sistema
        /// </summary>
        public String[] ObtenerDepartamentos()
        {
            return OrganizacionImplementor.Instance.ObtenerDepartamentos();
        }

        /// <summary>
        /// Obtiene los tipos de documento registrados en el sistema
        /// </summary>
        public String[] ObtenerTiposDocumento()
        {
            return SistemaImplementor.Instance.ObtenerTiposDocumento();
        }
        #endregion
    }
}
