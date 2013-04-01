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
        /// Obtiene documentos filtrado por alguno(s) de los siguientes paramentros
        /// </summary>
        /// <param name="usuarioEmisor">Usuario emisor</param>
        /// <param name="usuarioReceptor">Usuario receptor</param>
        /// <param name="departamento">Departamento</param>
        /// <param name="tipoDocumento">Tipo de documento</param>
        /// <param name="fechaEmision">Fecha de emisión</param>
        /// <param name="fechaRecepción">Fecha de recepción</param>
        /// <returns>Lista de documentos que cumple con los filtros</returns>
        public Documento[] ObtenerDocumentos(string usuarioEmisor, string usuarioReceptor, string departamento, string tipoDocumento, DateTime fechaEmision, DateTime fechaRecepción)
        {
            return DocumentosImplementor.Instance.ObtenerDocumentos(usuarioEmisor,usuarioReceptor,departamento,tipoDocumento,fechaEmision,fechaRecepción);
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
        /// Obtiene el historial de un documento específico
        /// </summary>
        /// <param name="idDocumento">Id único del documento</param>
        /// <returns>Historial del documento</returns>
        public Historial[] ObtenerHistorialDocumento(int idDocumento)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Obtiene la lista de documentos en que un usuario participó como emisor o receptor
        /// </summary>
        /// <param name="nombreUsuario">Nombre de usuario</param>
        /// <returns>Lista de documentos del usuario</returns>
        public Documento[] ObtenerDocumentosUsuario(string nombreUsuario)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Metodos Usuario
        /// <summary>
        /// Verifica el login del usuario
        /// </summary>
        /// <param name="nombreUsuario">Nombre de usuario</param>
        /// <param name="contrasena">Contraseña del usuario</param>
        /// <returns>True si se logueo correctamente</returns>
        public bool LogOn(string nombreUsuario, string contrasena)
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
        /// Obtiene el historial de un usuario específico
        /// </summary>
        /// <param name="nombreUsuario">Nombre de usuario</param>
        /// <returns>Historial del usuario</returns>
        public Historial[] ObtenerHistorialUsuario(string nombreUsuario)
        {
            return UsuariosImplementor.Instance.ObtenerHistorialUsuario(nombreUsuario);
        }
        #endregion

        #region Metodos Evento
        /// <summary>
        /// Obtiene la lista de eventos del sistema
        /// </summary>
        /// <returns>Lista de eventos en el sistema sin revisar</returns>
        public Evento[] ObtenerEventos()
        {
            return EventosImplementor.Instance.ObtenerEventos();
        }

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
