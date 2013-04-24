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


        private void DescargarArchivo(Documento documento)
        {
            saveFileDialogDescargar.FileName = documento.NombreDocumento;
            saveFileDialogDescargar.AddExtension = true;
            saveFileDialogDescargar.DefaultExt = documento.Formato;
            saveFileDialogDescargar.ShowDialog();
            Stream file = saveFileDialogDescargar.OpenFile();
            file.Write(documento.Archivo, 0, documento.Archivo.Length);
            file.Close();
            MessageBox.Show("El archivo se ha descargado de manera exitosa.", "Descarga Finalizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridViewDocumentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                Documento doc = DataAccess.Instance.ObtenerDocumento((int)dataGridViewDocumentos.Rows[0].Cells[0].Value);
                DescargarArchivo(doc);
            }
        }
    }
}
