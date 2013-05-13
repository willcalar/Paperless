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
using Word = Microsoft.Office.Interop.Word;
using System.Configuration;

namespace Paperless.OutlookPlugin
{
    public partial class UserControlRecibirDocumentos : UserControl
    {
        public List<int> _idDocumentos;

        public UserControlRecibirDocumentos()
        {
            InitializeComponent();
            _idDocumentos = new List<int>();
            LlenarListView();
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

        public void LlenarListView()
        {
            Documento[] docs = DataAccess.Instance.ObtenerDocumentosDeUsuario(Login.Instance.NombreUsuario);
            ImageList listaImagenes = new ImageList();
            listaImagenes.Images.Add("R", Properties.Resources.flag_red);
            listaImagenes.Images.Add("G", Properties.Resources.flag_green);
            listView1.SmallImageList = listaImagenes;
            listView1.StateImageList = listaImagenes;
            foreach (Documento doc in docs)
            {
                int firmado = 0;
                if (doc.Firmado)
                    firmado = 1;
                ListViewItem item = listView1.Items.Add(doc.IdDocumento.ToString(),doc.Fecha.ToShortDateString() + " - " + doc.NombreDocumento, firmado);
                _idDocumentos.Add(doc.IdDocumento);
                if (doc.Leido)
                    item.ForeColor = Color.Gray;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void abrirArchivoWord(Documento pDocumento)
        {
            String nombreArchivo  = ConfigurationSettings.AppSettings["folderDocumentos"]+pDocumento.NombreDocumento + "." + pDocumento.Formato;
            Stream file = File.Open(nombreArchivo, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
            file.Write(pDocumento.Archivo, 0, pDocumento.Archivo.Length);
            file.Close();
            Word.Application app = new Word.Application();
            app.Visible = true;
            app.Documents.Open(nombreArchivo,ReadOnly: false);
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedIndices.Count != 0)
            {
                int indexSeleccionado = listView1.SelectedIndices[0];
                Documento doc = DataAccess.Instance.ObtenerDocumento(_idDocumentos[listView1.SelectedIndices[0]]);
                abrirArchivoWord(doc);
            }
        }

    }
}
