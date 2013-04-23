using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Paperless.OutlookPlugin
{
    public partial class UserControlLogin : UserControl
    {

        public UserControlLogin( )
        {
            InitializeComponent();
        }

        private void buttonIniciarSesion_Click(object sender, EventArgs e)
        {
            if (validarDatosUsuario())
                return;
                
        }

        private bool validarDatosUsuario()
        {
            return ((!textBoxNombreUsuario.Text.Equals(String.Empty)) && (!textBoxPassword.Text.Equals(String.Empty)));
        }

    }
}
