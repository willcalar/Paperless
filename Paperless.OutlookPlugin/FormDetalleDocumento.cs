using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Paperless.DataAccessPlugins.WebService;
using Paperless.DataAccessPlugins;
using System.IO;
using Word = Microsoft.Office.Interop.Word;
using System.Configuration;


namespace Paperless.OutlookPlugin
{
    public partial class FormDetalleDocumento : Form
    {
        private int _IdDocumento;
        private Documento _Documento;
        private UserControlRecibirDocumentos _UserControlOwner;


        public FormDetalleDocumento(int pIdDocumento, UserControlRecibirDocumentos pUserControlOwner)
        {
            InitializeComponent();
            _IdDocumento = pIdDocumento;
            _Documento = DataAccess.Instance.ObtenerDocumento(_IdDocumento);
            Text = _Documento.NombreDocumento;
            _UserControlOwner = pUserControlOwner;
            LlenarDataGrid();
        }

        public void LlenarDataGrid()
        {
            DocumentoDetalleRecibo[] detalles = DataAccess.Instance.ObtenerDetalleDocumento(_IdDocumento);
            ImageList listaImagenes = new ImageList();
            listaImagenes.Images.Add("R", Properties.Resources.flag_red);
            listaImagenes.Images.Add("Y", Properties.Resources.flag_yellow);
            listaImagenes.Images.Add("G", Properties.Resources.flag_green);
            foreach (DocumentoDetalleRecibo detalle in detalles)
            {
                dataGridView1.Rows.Add(detalle.Fecha.ToString(),string.Empty, detalle.Emisor, detalle.Receptor, listaImagenes.Images[detalle.EstadoFirmas - 1]);
            }
            dataGridView1.Rows[0].Cells[1].Value = detalles[0].NombreDocumento;
        }

        private void abrirArchivoWord(Documento pDocumento)
        {
            String nombreArchivo = ConfigurationManager.AppSettings["folderDocumentos"] + pDocumento.NombreDocumento + "." + pDocumento.Formato;
            Stream file = File.Open(nombreArchivo, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
            file.Write(pDocumento.Archivo, 0, pDocumento.Archivo.Length);
            file.Close();
            Word.Application app = new Word.Application();
            app.Visible = true;
            app.Documents.Open(nombreArchivo, ReadOnly: false);
        }

        private void buttonVerDocumento_Click_1(object sender, EventArgs e)
        {
            abrirArchivoWord(_Documento);
        }

        private void FormDetalleDocumento_FormClosed(object sender, FormClosedEventArgs e)
        {
            _UserControlOwner.Enabled = true;
        }
    }
}
