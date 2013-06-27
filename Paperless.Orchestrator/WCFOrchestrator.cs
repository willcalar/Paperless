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
        /// <param name="pUsuarioEmisor">Parámetro de búsqueda</param>
        /// <param name="pUsuarioReceptor">Parámetro de búsqueda</param>
        /// <param name="pDepartamento">Parámetro de búsqueda</param>
        /// <param name="pTipoDocumento">Parámetro de búsqueda</param>
        /// <param name="pFechaEmision">Parámetro de búsqueda</param>
        /// <param name="pFechaRecepcion">Parámetro de búsqueda</param>
        /// <returns>Arreglo de Documentos que cumple con los parametros de la búsqueda</returns>
        public Documento[] ObtenerDocumentosAuditoria(string pUsuarioEmisor, string pUsuarioReceptor, string pDepartamento, string pTipoDocumento, DateTime pFechaEmision, DateTime pFechaRecepción)
        {
            return DocumentosImplementor.Instance.ObtenerDocumentosAuditoria(pUsuarioEmisor, pUsuarioReceptor, pDepartamento, pTipoDocumento, pFechaEmision, pFechaRecepción);
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
        /// <param name="pNombreDocumento">nombre del documento</param>
        /// <returns></returns>
        public DocumentoDetalleMovimiento[] ObtenerDetalleDocumentoAuditoria(string pNombreDocumento)
        {
            return DocumentosImplementor.Instance.ObtenerDetalleDocumentoAuditoria(pNombreDocumento);
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
        /// Actualiza el estado de un documento que fue migrado en el sistema
        /// </summary>
        /// <param name="pIdDocumento">id del documento</param>
        /// <returns>Verdadero si actulizo con exito o Falso de lo contrario</returns>
        public bool ActualizarEstadoDocumento(int pIdDocumento)
        {
            return DocumentosImplementor.Instance.ActualizarEstadoDocumento(pIdDocumento);
        }  

        /// <summary>
        /// Obtiene la lista de documentos en que un usuario participó como emisor o receptor
        /// </summary>
        /// <param name="pNombreUsuario">Nombre de usuario</param>
        /// <returns>Lista de documentos del usuario</returns>
        public Documento[] ObtenerDocumentosDeUsuario(string pNombreUsuario)
        {
            return DocumentosImplementor.Instance.ObtenerDocumentosDeUsuario(pNombreUsuario);
        }

        /// <summary>
        /// Obtiene la lista de documentos en que un usuario participó como emisor o receptor
        /// </summary>
        /// <param name="pUsuario">Nombre de usuario</param>
        /// <returns>Lista de documentos del usuario</returns>
        public int ObtenerNumeroPaginasDocumentosUsuario(string pNombreUsuario)
        {
           return DocumentosImplementor.Instance.ObtenerNumeroPaginasDocumentosUsuario(pNombreUsuario);
        }

        /// <summary>
        /// Obtiene la lista de documentos en que un usuario participó como emisor o receptor
        /// </summary>
        /// <param name="pNombreUsuario">Nombre de usuario</param>
        /// <returns>Lista de documentos del usuario</returns>
        public Documento[] ObtenerDocumentosDeUsuarioPorPagina(string pNombreUsuario, int pNumPagina)
        {
            return DocumentosImplementor.Instance.ObtenerDocumentosDeUsuarioPorPagina(pNombreUsuario,pNumPagina);
        }

        /// <summary>
        /// Obtiene el documento asociado al id indicado
        /// </summary>
        /// <param name="pIdDocumento">Id de documento a consultar</param>
        /// <returns>Documento asociado al id indicado</returns>
        public Documento ObtenerDocumento(int pIdDocumento)
        {
            return DocumentosImplementor.Instance.ObtenerDocumento(pIdDocumento);
        }

        /// <summary>
        /// Obtiene el detalle del estado del documento asociado al id indicado
        /// </summary>
        /// <param name="pIdDocumento">Id de documento a consultar</param>
        /// <returns>Lista de estados del documento para los diferentes receptores del mismo</returns>
        public DocumentoDetalleRecibo[] ObtenerDetalleDocumento(int pIdDocumento)
        {
            return DocumentosImplementor.Instance.ObtenerDetalleDocumento(pIdDocumento);
        }

        /// <summary>
        /// Marca como leido el documento por un usuario
        /// </summary>
        /// <param name="pIdDocumento">Id del documento</param>
        /// <param name="pNombreUsuario">Nombre del usuario que leyó el documento</param>
        public void MarcarLeido(int pIdDocumento, string pNombreUsuario)
        {
            DocumentosImplementor.Instance.MarcarLeido(pIdDocumento, pNombreUsuario);
        }

        /// <summary>
        /// Marca como firmado por un usuario un documento
        /// </summary>
        /// <param name="pIdDocumento">id del documento</param>
        /// <param name="pNombreUsuario">username del usuario</param>
        /// <param name="pPassword">password del usuario</param>
        public bool FirmarDocumento(int pIdDocumento, string pNombreUsuario, string pPassword)
        {
            return DocumentosImplementor.Instance.FirmarDocumento(pIdDocumento, pNombreUsuario, pPassword);
        }

        #endregion

        #region Metodos Usuario
        /// <summary>
        /// Verifica el login del usuario
        /// </summary>
        /// <param name="pNombreUsuario">Nombre de usuario</param>
        /// <param name="pContrasena">Contraseña del usuario</param>
        /// <returns>Nombre del funcionario</returns>
        public String LogIn(string pNombreUsuario, string pContrasena)
        {
            return UsuariosImplementor.Instance.LogInUsuario(pNombreUsuario, pContrasena);
        }

        /// <summary>
        /// Obtiene una lista de usuarios con el siguiente nombre de usuario (parcial o no parcial)
        /// </summary>
        /// <param name="pNombreUsuario">Nombre de usuario</param>
        /// <returns>Lista de usuarios que concuerda con el parametro ingresado</returns>
        public Usuario[] ObtenerUsuario(string pNombreUsuario)
        {
            return UsuariosImplementor.Instance.ObtenerUsuario(pNombreUsuario);
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
        /// Obtiene todos los usuarios de un determinado departamento
        /// </summary>
        /// <param name="pDepartamento">Nombre del departamento</param>
        /// <returns>Lista de todos los usuarios del departamento solicitado</returns>
        public Usuario[] ObtenerUsuariosXDepartamento(string pDepartamento)
        {
            return UsuariosImplementor.Instance.ObtenerUsuariosXDepartamento(pDepartamento);
        }


        /// <summary>
        /// Obtiene la lista de movimientos asociados a un usuario
        /// </summary>
        /// <param name="pNombreUsuario">nombre del usuario</param>
        /// <returns></returns>
        public DocumentoDetalleMovimiento[] ObtenerDetalleUsuarioAuditoria(string pNombreUsuario)
        {
            return UsuariosImplementor.Instance.ObtenerDetalleUsuarioAuditoria(pNombreUsuario);
        }

        /// <summary>
        /// Envía un documento a los destinatarios correspondientes
        /// </summary>
        /// <param name="pLstDestinatarios">Lista de destinatarios</param>
        /// <param name="pDocumento">Documento a enviar</param>
        /// <returns></returns>
        public int EnviarDocumento(List<Usuario> pLstDestinatarios, Documento pDocumento)
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
