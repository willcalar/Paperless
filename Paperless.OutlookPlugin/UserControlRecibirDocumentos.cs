using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Paperless.DataAccessPlugins;
using Paperless.DataAccessPlugins.WebService;

namespace Paperless.OutlookPlugin
{
    public partial class UserControlRecibirDocumentos : UserControl
    {
        #region Atributos
        public List<int> _idDocumentos;
        public List<Documento> _Documentos;
        public int _PaginaActual;
        public int _NumPaginas;
        #endregion

        #region Propiedades
        #endregion 

        #region Construtor
        public UserControlRecibirDocumentos()
        {
            InitializeComponent();
            _PaginaActual = 1;
            _NumPaginas = DataAccess.Instance.ObtenerNumeroPaginasDocumentosUsuario();
            if (_PaginaActual == _NumPaginas)
            {
                buttonSiguiente.Visible = false;
            }
            LlenarListView();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Llena el listview que muestra la lista de los documentos recibidos por el usuario
        /// </summary>
        public void LlenarListView()
        {
            _idDocumentos = new List<int>();
            _Documentos = new List<Documento>();
            listView1.Items.Clear();
            Documento[] docs = DataAccess.Instance.ObtenerDocumentosDeUsuarioPorPagina( _PaginaActual);
            ImageList listaImagenes = new ImageList();
            listaImagenes.Images.Add("R", Properties.Resources.flag_red);
            listaImagenes.Images.Add("Y", Properties.Resources.flag_yellow);
            listaImagenes.Images.Add("G", Properties.Resources.flag_green);
            listView1.SmallImageList = listaImagenes;
            listView1.StateImageList = listaImagenes;
            foreach (Documento doc in docs)
            {
                ListViewItem item = listView1.Items.Add(doc.IdDocumento.ToString(), doc.Fecha.ToShortDateString() + " - " + doc.NombreDocumento, doc.EstadoFirmas - 1);
                item.Group = listView1.Groups[doc.EstadoFirmas - 1];
                _idDocumentos.Add(doc.IdDocumento);
                _Documentos.Add(doc);
                if (doc.Leido)
                {
                    item.ForeColor = Color.DarkGray;
                }
                else
                {
                    item.ForeColor = Color.Black;
                }
            }
        }
        #endregion

        #region Eventos
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedIndices.Count != 0)
            {
                int indexSeleccionado = listView1.SelectedIndices[0];
                FormDetalleDocumento pantallaDetalle = new FormDetalleDocumento(_idDocumentos[indexSeleccionado], this, _Documentos[indexSeleccionado].EstadoFirmas, _Documentos[indexSeleccionado].Leido);
                pantallaDetalle.Show();
                this.Enabled = false;
            }
        }
        #endregion

        private void buttonSiguiente_Click(object sender, EventArgs e)
        {
            _PaginaActual++;
            LlenarListView();
            if (_PaginaActual == _NumPaginas)
            {
                buttonSiguiente.Visible = false;
            }
            buttonAnterior.Visible = true;
        }

        private void buttonAnterior_Click(object sender, EventArgs e)
        {
            _PaginaActual--;
            LlenarListView();
            if (_PaginaActual == 1)
            {
                buttonAnterior.Visible = false;
            }
            buttonSiguiente.Visible = true;
        }
 

    }
}
