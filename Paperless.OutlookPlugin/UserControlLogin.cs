using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Paperless.DataAccessPlugins;

namespace Paperless.OutlookPlugin
{
    public partial class UserControlLogin : UserControl
    {
        #region Atributos
        private RibbonOutlook _parent;
        #endregion

        #region Constructores
        public UserControlLogin(RibbonOutlook parent)
        {
            InitializeComponent();
            _parent = parent;
        }
        #endregion

        #region Eventos
        private void buttonIniciarSesion_Click(object sender, EventArgs e)
        {
            if (validarDatosUsuario())
            {
                String usuario = DataAccess.Instance.LogIn(NombreUsuario, Password);
                if (usuario != null)
                {
                    if (!usuario.Equals(String.Empty))
                    {
                        Login.Instance.LoginUsuario(NombreUsuario);
                        MessageBox.Show(usuario + Environment.NewLine + "Bienvenido a Paperless", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _parent.reintentarOperacion(true);
                    }
                    else
                        MessageBox.Show("El nombre de usuario o la contraseña es incorrecta. Reintente la operación.", "Error al iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Se ha perdido comunicación con el sistema. Reintente la operación.", "Error al iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Verifica que se hayan introducido todos los datos requeridos
        /// </summary>
        /// <returns></returns>
        private bool validarDatosUsuario()
        {
            return ((!NombreUsuario.Equals(String.Empty)) && (!Password.Equals(String.Empty)));
        }
        #endregion

        #region Propiedades
        public String NombreUsuario
        {
            get { return textBoxNombreUsuario.Text; }
        }

        public String Password
        {
            get { return textBoxPassword.Text; }
        }
        #endregion
    }
}
