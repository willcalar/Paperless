using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Paperless.DataAccessPlugins;
using Paperless.DataAccessPlugins.WebService;

namespace Paperless.DataAccessPlugins
{

    public class DataAccess
    {

        
        #region Methods

        

        public Documento[] ObtenerDocumentosDeUsuario(string usuario)
        {
            return _AccesoWS.ObtenerDocumentosDeUsuario(usuario);
        }

        public Documento ObtenerDocumento(int idDocumento)
        {
            return _AccesoWS.ObtenerDocumento(idDocumento);
        }

        public Usuario[] ObtenerListaUsuarios()
        {
            return _AccesoWS.ObtenerUsuario("jalvarez");
        }


        public string LogIn(string nombreUsuario, string password)
        {
            return _AccesoWS.LogIn(nombreUsuario, password);
        }

        public Usuario[] ObtenerTodosUsuarios()
        {
            return _AccesoWS.ObtenerTodosUsuarios();
        }

        public bool EnviarDocumento(List<Usuario> pLstDestinatarios, Documento pDocumento)
        {
            return _AccesoWS.EnviarDocumento(pLstDestinatarios.ToArray(),pDocumento);
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

        #region Attributes
        private static volatile DataAccess instance;
        private static object syncRoot = new Object();
        private ServiceContractClient _AccesoWS;
        #endregion

    }
}
