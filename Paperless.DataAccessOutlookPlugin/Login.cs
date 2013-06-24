using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Paperless.DataAccessPlugins
{
    public class Login
    {
        #region Métodos

        public void LoginUsuario(string pUsuario)
        {
            _NombreUsuario = pUsuario;
        }

        public void LogoutUsuario()
        {
            _NombreUsuario = String.Empty;
        }

        public bool EstaLogueado()
        {
            return (!_NombreUsuario.Equals(String.Empty));
        }

        
        #endregion

        #region Singleton
        private Login() { }

        public static Login Instance
        {
            get 
            {
                if (instance == null) 
                {
                lock (syncRoot) 
                {
                    if (instance == null)
                    {
                        instance = new Login();
                        instance._NombreUsuario = String.Empty;
                    }
                }
                }

                return instance;
            }
        }

        #endregion

        #region Atributos
        private static volatile Login instance;
        private static object syncRoot = new Object();
        private String _NombreUsuario;
        #endregion

        #region Propiedades
        public String NombreUsuario
        {
            get { return _NombreUsuario; }
            set { _NombreUsuario = value; }
        }
        #endregion

    }
}
