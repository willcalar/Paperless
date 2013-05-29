using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Paperless.DataAccessPlugins;

namespace Paperless.OutlookPlugin
{
    public partial class FormFirmarDocumento : Form
    {
        #region Atributos
        private int _IdDocumento;
        #endregion

        #region Propiedades
        #endregion 

        #region Constructor
        public FormFirmarDocumento(int idDocumento)
        {
            InitializeComponent();
            _IdDocumento = idDocumento;
        }
        #endregion

        #region Eventos
        private void buttonFirmar_Click(object sender, EventArgs e)
        {
            bool resultado = DataAccess.Instance.FirmarDocumento(_IdDocumento, textBoxPassword.Text);
            if (resultado)
            {
                Cerrar();
            }
            else
            {
                MessageBox.Show("El proceso de firma del documento ha fallado, revise sus datos y reintente la operación.",
                    "Firma del documento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonAbrirFirma_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }


        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Cerrar();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string nombreArchivo = openFileDialog1.FileName;

            textBoxFirmaDigital.Text = openFileDialog1.FileName;
        }
        #endregion

        #region Métodos
        private void Cerrar()
        {
            MessageBox.Show("El proceso de firma del documento se ha realizado con éxito.",
                    "Firma del documento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ((FormDetalleDocumento)this.Owner).LlenarDataGrid();
            ((FormDetalleDocumento)this.Owner)._UserControlOwner.LlenarListView();
            ((FormDetalleDocumento)this.Owner)._UserControlOwner.Enabled = true;
            ((FormDetalleDocumento)this.Owner).buttonFirmar.Enabled = false;
            ((FormDetalleDocumento)this.Owner)._Estado = 2;
            ((FormDetalleDocumento)this.Owner).Visible = true;
            this.Close();
        }
        #endregion

    }
}
