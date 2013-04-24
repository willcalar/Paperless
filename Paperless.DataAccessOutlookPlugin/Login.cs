using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Paperless.DataAccessOutlookPlugin
{
    public class Login
    {
        #region Methods      

        public void LoginUsuario(string usuario)
        {
            _NombreUsuario = usuario;
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

        #region Attributes
        private static volatile Login instance;
        private static object syncRoot = new Object();
        private String _NombreUsuario;
        #endregion


        #region Properties
        public String NombreUsuario
        {
            get { return _NombreUsuario; }
            set { _NombreUsuario = value; }
        }
        #endregion

    }
}
