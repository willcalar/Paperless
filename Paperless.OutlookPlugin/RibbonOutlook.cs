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
        private CustomTaskPane _taskPanelRecibirDocumentos;
        private CustomTaskPane _taskPanelLogin;

        private void RibbonOutlook_Load(object sender, RibbonUIEventArgs e)
        {
        }

        private void buttonRecibir_Click(object sender, RibbonControlEventArgs e)
        {
            mostrarUserControlRecibirDocumentos();
        }


        private void mostrarUserControlRecibirDocumentos()
        {
            _taskPanelRecibirDocumentos.DockPosition = Office.MsoCTPDockPosition.msoCTPDockPositionRight;
            _taskPanelRecibirDocumentos.Width = 705;
            _taskPanelRecibirDocumentos.Visible = true;
            
        }

        private void mostrarUserControlLogin()
        {
            _taskPanelLogin.DockPosition = Office.MsoCTPDockPosition.msoCTPDockPositionRight;
            _taskPanelLogin.Width = 105;
            _taskPanelLogin.Visible = true;
            
        }


        private void llenarTaskPanels()
        {
            UserControlLogin _userControl = new UserControlLogin();
            _taskPanelLogin = Globals.ThisAddIn.CustomTaskPanes.Add(_userControl, "Paperless");


            UserControlRecibirDocumentos _userControlD = new UserControlRecibirDocumentos();
            _userControlD.dataGridView1.Rows.Clear();
            _userControlD.dataGridView1.Rows.Add(DateTime.Now.ToString(), "Nuevo Plan", "María Estrada", false, "Firmar", "Ver", "Descargar");
            _userControlD.dataGridView1.Rows.Add(DateTime.Now.ToString(), "Nuevo Curso", "Jaime Solano", true, "Firmar", "Ver", "Descargar");
            _taskPanelRecibirDocumentos = Globals.ThisAddIn.CustomTaskPanes.Add(_userControlD, "Paperless");
        }


        
    }
}
