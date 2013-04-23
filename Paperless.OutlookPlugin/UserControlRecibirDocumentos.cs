using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Paperless.DataAccessOutlookPlugin;
using Paperless.DataAccessOutlookPlugin.WebService;

namespace Paperless.OutlookPlugin
{
    public partial class UserControlRecibirDocumentos : UserControl
    {
        public UserControlRecibirDocumentos()
        {
            InitializeComponent();
            LlenarDataGrid();
        }


        public void LlenarDataGrid()
        {
            Documento[] docs = DataAccess.Instance.ObtenerDocumentosDeUsuario("jalvarez");
            foreach (Documento doc in docs)
            {
                dataGridView1.Rows.Add(doc.IdDocumento, doc.Fecha, doc.NombreDocumento, doc.NombreUsuarioEmisor, doc.Firmado, "Firmar", "Ver", "Descargar");
            }
        }
    }
}
