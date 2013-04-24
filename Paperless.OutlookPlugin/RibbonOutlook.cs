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
        public int _accion;

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


        public void mostrarUserControlRecibirDocumentos()
        {
            if (_taskPanel != null)
                _taskPanel.Visible = false;
            UserControlRecibirDocumentos _userControl = new UserControlRecibirDocumentos();
            _taskPanel= Globals.ThisAddIn.CustomTaskPanes.Add(_userControl, "Paperless");
            mostrarTaskPanel(705);
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
        
                
    }
}
