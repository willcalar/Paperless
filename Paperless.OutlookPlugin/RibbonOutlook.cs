using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Tools;
using Office = Microsoft.Office.Core;
using Paperless.DataAccessPlugins;
using Outlook = Microsoft.Office.Interop.Outlook;
using Word = Microsoft.Office.Interop.Word;

namespace Paperless.OutlookPlugin
{
    public partial class RibbonOutlook
    {
        #region Atributos
        private CustomTaskPane _taskPanel;
        private int _accion;
        #endregion 

        #region eventos
        private void RibbonOutlook_Load(object sender, RibbonUIEventArgs e)
        {
            
        }

        private void buttonRecibir_Click(object sender, RibbonControlEventArgs e)
        {
            if (Login.Instance.EstaLogueado())
                mostrarUserControlRecibirDocumentos();
            else
            {
                _accion = 1;
                mostrarUserControlLogin();
            }
        }

        private void btnEnviarDocumento_Click(object sender, RibbonControlEventArgs e)
        {
            if (Login.Instance.EstaLogueado())
                mostrarUserControlEnviarDocumentos();
            else
            {
                _accion = 1;
                mostrarUserControlLogin();
            }
        }

        private void buttonIniciarSesion_Click(object sender, RibbonControlEventArgs e)
        {
            mostrarUserControlLogin();
        }

        private void buttonCerrarSesion_Click(object sender, RibbonControlEventArgs e)
        {
            buttonCerrarSesion.Visible = false;
            buttonIniciarSesion.Visible = true;
            Login.Instance.LogoutUsuario();
            ocultarTaskPanel();
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Abre la región donde se muestran los doucumentos recibidos por el usuario
        /// </summary>
        private void mostrarUserControlRecibirDocumentos()
        {
            if (_taskPanel != null)
                _taskPanel.Visible = false;
            UserControlRecibirDocumentos _userControl = new UserControlRecibirDocumentos();
            _taskPanel= Globals.ThisAddIn.CustomTaskPanes.Add(_userControl, "Paperless");
            mostrarTaskPanel(260);
        }

        /// <summary>
        /// Muestra la region para enviar un documento
        /// </summary>
        private void mostrarUserControlEnviarDocumentos()
        {   
            if (_taskPanel != null)
                _taskPanel.Visible = false;
            UserControlEnviarDocumento _userControl = new UserControlEnviarDocumento();
            _taskPanel = Globals.ThisAddIn.CustomTaskPanes.Add(_userControl, "Paperless");
            mostrarTaskPanel(240);
        }

        /// <summary>
        /// Muestra la región para realizar el login
        /// </summary>
        private void mostrarUserControlLogin()
        {
            if (_taskPanel != null)
                _taskPanel.Visible = false;
            UserControlLogin _userControl = new UserControlLogin(this);
            _taskPanel = Globals.ThisAddIn.CustomTaskPanes.Add(_userControl, "Paperless");
            mostrarTaskPanel(220);
            
        }

        /// <summary>
        /// Brinda las propiedades de la región
        /// </summary>
        /// <param name="width">Ancho deseado de la región</param>
        private void mostrarTaskPanel(int width)
        {
            _taskPanel.DockPosition = Office.MsoCTPDockPosition.msoCTPDockPositionRight;
            _taskPanel.Width = width;
            _taskPanel.Visible = true;
        }

        /// <summary>
        /// Oculta ela región que se muestra actualmente
        /// </summary>
        private void ocultarTaskPanel()
        {
            _taskPanel.Visible = false;
        }

        /// <summary>
        /// Reintenta la operación que se intentaba realizar previo a realizar el login
        /// </summary>
        /// <param name="loguear"></param>
        public void reintentarOperacion(bool loguear)
        {
            if (loguear)
            {
                buttonCerrarSesion.Visible = true;
                buttonIniciarSesion.Visible = false;
            }
            switch (_accion)
            {
                case 0:
                    ocultarTaskPanel();
                    return;
                case 1:
                    mostrarUserControlRecibirDocumentos();
                    return;
            }
            _accion = 0;
        }

        #endregion

    }
}
