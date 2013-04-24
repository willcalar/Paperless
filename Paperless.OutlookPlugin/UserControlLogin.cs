using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Paperless.DataAccessOutlookPlugin;

namespace Paperless.OutlookPlugin
{
    public partial class UserControlLogin : UserControl
    {
        private RibbonOutlook _parent;

        public UserControlLogin(RibbonOutlook parent)
        {
            InitializeComponent();
            _parent = parent;

        }

        private void buttonIniciarSesion_Click(object sender, EventArgs e)
        {
            if (validarDatosUsuario())
            {
                Login.Instance.LoginUsuario(NombreUsuario);
                switch(_parent._accion){
                    case 1:
                        _parent.mostrarUserControlRecibirDocumentos();
                        return;
                    default:
                        return;
                }
            }
        }

        private bool validarDatosUsuario()
        {
            return ((!NombreUsuario.Equals(String.Empty)) && (!Password.Equals(String.Empty)));
        }


        public String NombreUsuario
        {
            get { return textBoxNombreUsuario.Text; }
        }

        public String Password
        {
            get { return textBoxPassword.Text; }
        }

    }
}
