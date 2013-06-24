using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Paperless.DataAccessPlugins.WebService;
using Paperless.Caching;

namespace Paperless.DataAccessPlugins
{

    public class DataAccess
    {
     
        #region Métodos

        /// <summary>
        /// Obtiene la lista de documentos en que un usuario participó como emisor o receptor
        /// </summary>
        /// <param name="pUsuario">Nombre de usuario</param>
        /// <returns>Lista de documentos del usuario</returns>
        public Documento[] ObtenerDocumentosDeUsuario(string pUsuario)
        {
            return _AccesoWS.ObtenerDocumentosDeUsuario(pUsuario);
        }

        /// <summary>
        /// Obtiene el documento asociado al id indicado
        /// </summary>
        /// <param name="pIdDocumento">Id de documento a consultar</param>
        /// <returns>Documento asociado al id indicado</returns>
        public Documento ObtenerDocumento(int pIdDocumento)
        {
            return _AccesoWS.ObtenerDocumento(pIdDocumento);
        }

        /// <summary>
        /// Obtiene el documento asociado al id indicado
        /// </summary>
        /// <param name="pIdDocumento">Id de documento a consultar</param>
        /// <returns>Documento asociado al id indicado</returns>
        public void MarcarLeido(int pIdDocumento)
        {
            _AccesoWS.MarcarLeido(pIdDocumento, Login.Instance.NombreUsuario);
        }

        /// <summary>
        /// Obtiene el detalle del estado del documento asociado al id indicado
        /// </summary>
        /// <param name="pIdDocumento">Id de documento a consultar</param>
        /// <returns>Lista de estados del documento para los diferentes receptores del mismo</returns>
        public DocumentoDetalleRecibo[] ObtenerDetalleDocumento(int pIdDocumento)
        {
            return _AccesoWS.ObtenerDetalleDocumento(pIdDocumento);
        }

        /// <summary>
        /// Verifica el login del usuario
        /// </summary>
        /// <param name="pNombreUsuario">Nombre de usuario</param>
        /// <param name="pPassword">Contraseña del usuario</param>
        /// <returns>Nombre del funcionario</returns>
        public string LogIn(string pNombreUsuario, string pPassword)
        {
            return _AccesoWS.LogIn(pNombreUsuario, pPassword);
        }

        /// <summary>
        /// Obtiene todos los usuarios activo
        /// </summary>
        /// <returns>Lista de usuarios que concuerda con el parametro ingresado</returns>
        public Usuario[] ObtenerTodosUsuarios()
        {
            return _AccesoWS.ObtenerTodosUsuarios();
        }       

        /// <summary>
        /// Obtiene la lista de usuarios de un departamento
        /// </summary>
        /// <param name="pDepartamento">Nombre del departamento</param>
        /// <returns>Lista de usuarios del departamento solicitado</returns>
        public List<Usuario> ObtenerUsuarioPorDepartamento(string pDepartamento)
        {
            return _AccesoWS.ObtenerUsuariosXDepartamento(pDepartamento).ToList();
        }

        /// <summary>
        /// Envía un documento a los destinatarios correspondientes
        /// </summary>
        /// <param name="pListaDestinatarios">Lista de destinatarios</param>
        /// <param name="pDocumento">Documento a enviar</param>
        /// <returns></returns>
        public int EnviarDocumento(List<Usuario> pListaDestinatarios, Documento pDocumento)
        {
            return _AccesoWS.EnviarDocumento(pListaDestinatarios.ToArray(), pDocumento);
        }
        
        /// <summary>
        /// Obtiene la lista de departamentos registrados en el sistema
        /// </summary>
        /// <returns></returns>
        public String[] ObtenerDepartamentos()
        {
            return _AccesoWS.ObtenerDepartamentos();
        }

        /// <summary>
        /// Marca como firmado por un usuario un documento
        /// </summary>
        /// <param name="pIdDocumento">id del documento</param>
        /// <param name="pPassword">password del usuario</param>
        public bool FirmarDocumento(int pIdDocumento, string pPassword)
        {
            if (Certificado.ChequearCertificado())
            {
                return _AccesoWS.FirmarDocumento(pIdDocumento, Login.Instance.NombreUsuario, pPassword);
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Singleton
        private DataAccess() { }

        public static DataAccess Instance
        {
            get 
            {
                if (instance == null) 
                {
                lock (syncRoot) 
                {
                    if (instance == null)
                    {
                        instance = new DataAccess();
                        instance._AccesoWS = new ServiceContractClient();
                    }
                }
                }

                return instance;
            }
        }

        #endregion

        #region Atributos
        private static volatile DataAccess instance;
        private static object syncRoot = new Object();
        private ServiceContractClient _AccesoWS;
        private CacheManager _CacheManager;
        #endregion

        #region Constants
        private string _CACHE_PREFIX = "Cache";
        #endregion

    }
}
