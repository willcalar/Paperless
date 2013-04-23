using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Tools;
using Office = Microsoft.Office.Core;

namespace Paperless.OutlookPlugin
{
    public partial class RibbonOutlook
    {
        private CustomTaskPane _taskPanel;

        private void RibbonOutlook_Load(object sender, RibbonUIEventArgs e)
        {
            
        }

        private void buttonRecibir_Click(object sender, RibbonControlEventArgs e)
        {
            mostrarUserControlRecibirDocumentos();
        }


        private void mostrarUserControlRecibirDocumentos()
        {
            if (_taskPanel != null)
                _taskPanel.Visible = false;
            UserControlRecibirDocumentos _userControl = new UserControlRecibirDocumentos();
            _taskPanel= Globals.ThisAddIn.CustomTaskPanes.Add(_userControl, "Paperless");
            _taskPanel.DockPosition = Office.MsoCTPDockPosition.msoCTPDockPositionRight;
            _taskPanel.Width = 705;
            _taskPanel.Visible = true;
            
        }

        private void mostrarUserControlLogin()
        {
            if (_taskPanel != null)
                _taskPanel.Visible = false;
            UserControlRecibirDocumentos _userControl = new UserControlRecibirDocumentos();
            _taskPanel = Globals.ThisAddIn.CustomTaskPanes.Add(_userControl, "Paperless");
            _taskPanel.DockPosition = Office.MsoCTPDockPosition.msoCTPDockPositionRight;
            _taskPanel.Width = 205;
            _taskPanel.Visible = true;
            
        }
        
                
    }
}
