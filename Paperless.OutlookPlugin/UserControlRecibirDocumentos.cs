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
using System.IO;

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
            Documento[] docs = DataAccess.Instance.ObtenerDocumentosDeUsuario(Login.Instance.NombreUsuario);
            foreach (Documento doc in docs)
            {
                dataGridViewDocumentos.Rows.Add(doc.IdDocumento, doc.Fecha, doc.NombreDocumento, doc.NombreUsuarioEmisor, doc.Firmado, "Firmar", "Ver", "Descargar");
            }
        }

        private void dataGridViewDocumentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                Documento doc = DataAccess.Instance.ObtenerDocumento((int)dataGridViewDocumentos.Rows[0].Cells[0].Value);
                saveFileDialogDescargar.FileName = doc.NombreDocumento;
                saveFileDialogDescargar.AddExtension = true;
                saveFileDialogDescargar.DefaultExt = doc.Formato;
                saveFileDialogDescargar.ShowDialog();

                Stream file = saveFileDialogDescargar.OpenFile();
                file.Write(doc.Archivo, 0, doc.Archivo.Length);
                file.Close();
                
            }
        }
    }
}
