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
using Exceptions;


namespace Paperless.WordPlugin
{
    public partial class FormDetalleDocumento : Form
    {
        private int _IdDocumento;
        private Documento _Documento;
        public UserControlRecibirDocumentos _UserControlOwner;
        public int _Estado;


        public FormDetalleDocumento(int pIdDocumento, UserControlRecibirDocumentos pUserControlOwner, int pEstado)
        {
            InitializeComponent();
            _IdDocumento = pIdDocumento;
            _Documento = DataAccess.Instance.ObtenerDocumento(_IdDocumento);
            Text = _Documento.NombreDocumento;
            _UserControlOwner = pUserControlOwner;
            LlenarDataGrid();
            _Estado = pEstado;
            if ((_Estado == 1) && (_Documento.Leido))
            {
                buttonFirmar.Enabled = true;
            }
        }



        public void LlenarDataGrid()
        {
            dataGridView1.Rows.Clear();
            DocumentoDetalleRecibo[] detalles = DataAccess.Instance.ObtenerDetalleDocumento(_IdDocumento);
            ImageList listaImagenes = new ImageList();
            listaImagenes.Images.Add("R", Properties.Resources.flag_red);
            listaImagenes.Images.Add("Y", Properties.Resources.flag_yellow);
            listaImagenes.Images.Add("G", Properties.Resources.flag_green);
            foreach (DocumentoDetalleRecibo detalle in detalles)
            {
                dataGridView1.Rows.Add(detalle.Fecha.ToString(),string.Empty, detalle.Emisor, detalle.Receptor, listaImagenes.Images[detalle.EstadoFirmas - 1]);
                if ((dataGridView1.Rows.Count - 1) % 2 == 0)
                {
                    DataGridViewCellStyle style = new DataGridViewCellStyle();
                    style.BackColor= Color.AliceBlue;
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle = style;
                        
                }
            }
            dataGridView1.Rows[0].Cells[1].Value = detalles[0].NombreDocumento;
        }

        public bool FirmarDocumento()
        {
            return true;
        }

        private void abrirArchivo(Documento pDocumento)
        {
            try
            {
                String nombreArchivo = ConfigurationManager.AppSettings["folderDocumentos"] + pDocumento.NombreDocumento + "." + pDocumento.Formato;
                Stream file = File.Open(nombreArchivo, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                file.Write(pDocumento.Archivo, 0, pDocumento.Archivo.Length);
                file.Close();
                System.Diagnostics.Process.Start(nombreArchivo);
            }
            catch (Exception e)
            {
                ExceptionManager.HandleException(e, Policy.CLIENT_GENERAL_LOGIC, e.GetType(), (int) ErrorCode.ERROR_CREATING_FILE, ExceptionMessages.Instance[ErrorCode.ERROR_CREATING_FILE],false);
            }

        }

        private void buttonVerDocumento_Click_1(object sender, EventArgs e)
        {
            if (!_Documento.Leido)
            {
                MarcarDocumentoLeido();
                _Documento.Leido = true;
            }
            abrirArchivo(_Documento);
            if (_Estado == 1)
            {
                buttonFirmar.Enabled = true;
            }
        }

        private void FormDetalleDocumento_FormClosed(object sender, FormClosedEventArgs e)
        {
            _UserControlOwner.Enabled = true;
        }

        private void buttonFirmar_Click(object sender, EventArgs e)
        {
            new FormFirmarDocumento(_IdDocumento).Show(this);
            this.Visible = false;
        }

        private void MarcarDocumentoLeido()
        {
            DataAccess.Instance.MarcarLeido(_IdDocumento);
            _UserControlOwner.LlenarListView();
        }
    }
}
