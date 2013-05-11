using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Tools;
using Office = Microsoft.Office.Core;
using Paperless.DataAccessOutlookPlugin;

namespace Paperless.OutlookPlugin
{
    public partial class RibbonOutlook
    {
        private CustomTaskPane _taskPanel;
        private int _accion;

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


        private void mostrarUserControlRecibirDocumentos()
        {
            if (_taskPanel != null)
                _taskPanel.Visible = false;
            UserControlRecibirDocumentos _userControl = new UserControlRecibirDocumentos();
            _taskPanel= Globals.ThisAddIn.CustomTaskPanes.Add(_userControl, "Paperless");
            mostrarTaskPanel(705);
        }

        private void mostrarUserControlEnviarDocumentos()
        {
            if (_taskPanel != null)
                _taskPanel.Visible = false;
            UserControlEnviarDocumento _userControl = new UserControlEnviarDocumento();
            _taskPanel = Globals.ThisAddIn.CustomTaskPanes.Add(_userControl, "Paperless");
            mostrarTaskPanel(285);
        }

        private void mostrarUserControlLogin()
        {
            if (_taskPanel != null)
                _taskPanel.Visible = false;
            UserControlLogin _userControl = new UserControlLogin(this);
            _taskPanel = Globals.ThisAddIn.CustomTaskPanes.Add(_userControl, "Paperless");
            mostrarTaskPanel(205);
            
        }


        private void mostrarTaskPanel(int width)
        {
            _taskPanel.DockPosition = Office.MsoCTPDockPosition.msoCTPDockPositionRight;
            _taskPanel.Width = width;
            _taskPanel.Visible = true;
        }

        private void ocultarTaskPanel()
        {
            _taskPanel.Visible = false;
        }

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

        
                
    }
}
