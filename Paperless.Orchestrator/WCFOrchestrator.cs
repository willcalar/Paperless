using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Paperless.WCF;
using Paperless.Library;

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
            throw new NotImplementedException();
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
        /// Obtiene una lista de documentos que faltan de migrar
        /// </summary>
        /// <returns>Lista de documentos sin migrar</returns>
        public Documento[] ObtenerDocumentosPorMigrar()
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtiene una lista de usuarios con el siguiente nombre de usuario (parcial o no parcial)
        /// </summary>
        /// <param name="nombreUsuario">Nombre de usuario</param>
        /// <returns>Lista de usuarios que concuerda con el parametro ingresado</returns>
        public Usuario[] ObtenerUsuario(string nombreUsuario)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtiene el historial de un usuario específico
        /// </summary>
        /// <param name="nombreUsuario">Nombre de usuario</param>
        /// <returns>Historial del usuario</returns>
        public Historial[] ObtenerHistorialUsuario(string nombreUsuario)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Metodos Evento
        /// <summary>
        /// Obtiene la lista de eventos del sistema
        /// </summary>
        /// <returns>Lista de eventos en el sistema sin revisar</returns>
        public Evento[] ObtenerEventos()
        {
            throw new NotImplementedException();
        }
        #endregion        
    }
}
