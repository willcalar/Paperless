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


namespace Paperless.OutlookPlugin
{
    public partial class FormDetalleDocumento : Form
    {
        #region Atributos
        private int _IdDocumento;
        private Documento _Documento;
        public UserControlRecibirDocumentos _UserControlOwner;
        public int _Estado;
        #endregion

        #region Propiedades
        public DataGridViewRowCollection Filas
        {
            get { return dataGridView1.Rows; }
        }
        #endregion 

        #region Construtor
        /// <summary>
        /// Constructor del objeto
        /// </summary>
        /// <param name="pIdDocumento">Id del Documento</param>
        /// <param name="pUserControlOwner">Form creador</param>
        /// <param name="pEstado">Estado del documento</param>
        /// <param name="pLeido">Indica si el usuario logueado ha leido el documento</param>
        public FormDetalleDocumento(int pIdDocumento, UserControlRecibirDocumentos pUserControlOwner, int pEstado, bool pLeido)
        {
            InitializeComponent();
            _IdDocumento = pIdDocumento;
            _Documento = DataAccess.Instance.ObtenerDocumento(_IdDocumento);
            _Documento.Leido = pLeido;
            Text = _Documento.NombreDocumento;
            _UserControlOwner = pUserControlOwner;
            LlenarDataGrid();
            _Estado = pEstado;
            if ((_Estado == 1) && (_Documento.Leido))
            {
                buttonFirmar.Enabled = true;
            }
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Llena el datagrid con la información necesaria
        /// </summary>
        public void LlenarDataGrid()
        {
            Filas.Clear();
            DocumentoDetalleRecibo[] detalles = DataAccess.Instance.ObtenerDetalleDocumento(_IdDocumento);
            ImageList listaImagenes = new ImageList();
            listaImagenes.Images.Add("R", Properties.Resources.flag_red);
            listaImagenes.Images.Add("Y", Properties.Resources.flag_yellow);
            listaImagenes.Images.Add("G", Properties.Resources.flag_green);
            foreach (DocumentoDetalleRecibo detalle in detalles)
            {
                Filas.Add(detalle.Fecha.ToString(),string.Empty, detalle.Emisor, detalle.Receptor, listaImagenes.Images[detalle.EstadoFirmas - 1]);
                DataGridViewCellStyle style = new DataGridViewCellStyle();
                if ((Filas.Count - 1) % 2 == 0)
                {
                    style.BackColor= Color.AliceBlue;
                }
                else
                {
                    style.BackColor = Color.LightGray;
                }
                Filas[Filas.Count - 1].DefaultCellStyle = style;
            }
            Filas[0].Cells[1].Value = detalles[0].NombreDocumento;
        }

        /// <summary>
        /// Abre el archivo que representa el objeto Documento
        /// </summary>
        /// <param name="pDocumento"> Objeto Documento</param>
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

        /// <summary>
        /// Marca el documento como leído
        /// </summary>
        private void MarcarDocumentoLeido()
        {
            DataAccess.Instance.MarcarLeido(_IdDocumento);
            _UserControlOwner.LlenarListView();
        }
        #endregion

        #region Eventos
        private void buttonVerDocumento_Click_1(object sender, EventArgs e)
        {
            abrirArchivo(_Documento);
            if (!_Documento.Leido)
            {
                MarcarDocumentoLeido();
                _Documento.Leido = true;
            }
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
        #endregion

    }
}
