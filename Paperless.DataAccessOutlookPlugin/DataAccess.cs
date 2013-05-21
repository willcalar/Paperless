﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Paperless.DataAccessPlugins.WebService;
using Paperless.Caching;

namespace Paperless.DataAccessPlugins
{

    public class DataAccess
    {
     
        #region Methods

        /// <summary>
        /// Obtiene la lista de documentos en que un usuario participó como emisor o receptor
        /// </summary>
        /// <param name="usuario">Nombre de usuario</param>
        /// <returns>Lista de documentos del usuario</returns>
        public Documento[] ObtenerDocumentosDeUsuario(string usuario)
        {
            return _AccesoWS.ObtenerDocumentosDeUsuario(usuario);
        }

        /// <summary>
        /// Obtiene el documento asociado al id indicado
        /// </summary>
        /// <param name="idDocumento">Id de documento a consultar</param>
        /// <returns>Documento asociado al id indicado</returns>
        public Documento ObtenerDocumento(int idDocumento)
        {
            return _AccesoWS.ObtenerDocumento(idDocumento);
        }

        /// <summary>
        /// Obtiene el detalle del estado del documento asociado al id indicado
        /// </summary>
        /// <param name="idDocumento">Id de documento a consultar</param>
        /// <returns>Lista de estados del documento para los diferentes receptores del mismo</returns>
        public DocumentoDetalleRecibo[] ObtenerDetalleDocumento(int idDocumento)
        {
            return _AccesoWS.ObtenerDetalleDocumento(idDocumento);
        }

        // Qué es esto xD?
        public Usuario[] ObtenerListaUsuarios()
        {
            return _AccesoWS.ObtenerUsuario("jalvarez");
        }

        /// <summary>
        /// Verifica el login del usuario
        /// </summary>
        /// <param name="nombreUsuario">Nombre de usuario</param>
        /// <param name="contrasena">Contraseña del usuario</param>
        /// <returns>Nombre del funcionario</returns>
        public string LogIn(string nombreUsuario, string password)
        {
            return _AccesoWS.LogIn(nombreUsuario, password);
        }

        /// <summary>
        /// Obtiene todos los usuarios activo
        /// </summary>
        /// <returns>Lista de usuarios que concuerda con el parametro ingresado</returns>
        public Usuario[] ObtenerTodosUsuarios()
        {
            return _AccesoWS.ObtenerTodosUsuarios();
        }

        public List<Usuario> ObtenerUsuarioPorDepartamento(string pDepartamento)
        {
            List<Usuario> lstUsuario = (List<Usuario>)_CacheManager.GetItem(_CACHE_PREFIX+pDepartamento);
            if (lstUsuario == null)
            {
                lstUsuario = _AccesoWS.ObtenerUsuariosXDepartamento(pDepartamento).ToList();
                _CacheManager.AddItems(_CACHE_PREFIX + pDepartamento,lstUsuario,new TimeSpan(24,0,0));
            }
            return lstUsuario;
        }

        /// <summary>
        /// Envía un documento a los destinatarios correspondientes
        /// </summary>
        /// <param name="pLstDestinatarios">Lista de destinatarios</param>
        /// <param name="pDocumento">Documento a enviar</param>
        /// <returns></returns>
        public bool EnviarDocumento(List<Usuario> pLstDestinatarios, Documento pDocumento)
        {
            return _AccesoWS.EnviarDocumento(pLstDestinatarios.ToArray(),pDocumento);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String[] ObtenerDepartamentos()
        {
            return _AccesoWS.ObtenerDepartamentos();
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
                        instance._CacheManager = new CacheManager();
                    }
                }
                }

                return instance;
            }
        }

        #endregion

        #region Attributes
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
