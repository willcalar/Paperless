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
using System.IO;


namespace Paperless.OutlookPlugin
{
    public partial class UserControlEnviarDocumento : UserControl
    {
        #region Constructores
        /// <summary>
        /// Constructuor del objeto
        /// </summary>
        public UserControlEnviarDocumento()
        {
            InitializeComponent();
            LlenarListaDepartamentos();
        }
        #endregion 

        #region Métodos
        /// <summary>
        /// Llena la lista de departamentos para seleccionar los destinaarios
        /// </summary>
        private void LlenarListaDepartamentos()
        {
            String[] arrDepartamentos = DataAccess.Instance.ObtenerDepartamentos();
            foreach (String m in arrDepartamentos)
            {
                lstDepartamentos.Items.Add(m);
            }
        }
        
        /// <summary>
        /// Llena la lista de los posibles destinaarios
        /// </summary>
        /// <param name="arrUsuarios"></param>
        private void LlenarListaDestinatarios(List<Usuario> arrUsuarios)
        {
            int i = 0;
            foreach (Usuario m in arrUsuarios)
            {
                grdViewUsuarios.Rows.Add();
                DataGridViewRow row = (DataGridViewRow)grdViewUsuarios.Rows[i];
                row.Cells["Username"].Value = m.Username;
                row.Cells["Nombre"].Value = m.NombreUsuario + " " + m.PrimerApellido + " " + m.SegundoApellido;
                i++;
            }
        }
    
        /// <summary>
        /// Busca el usuario
        /// </summary>
        /// <param name="pNombreCompleto">Nombre completo del usuario</param>
        /// <returns></returns>
        private string BuscarUsername(string pNombreCompleto)
        {
            string []nombreTokens = pNombreCompleto.Split(' ');
            return (from users in _UsuariosDestinatarios
                    where users.NombreUsuario == nombreTokens[0]
                    && users.PrimerApellido == nombreTokens[1]
                    && users.SegundoApellido == nombreTokens[2]
                    select users).First().Username;
        }
        #endregion

        #region eventos
        private void btnAbrir_Click(object sender, EventArgs e)
        {
            OpenFileDialog oFileDialog = new OpenFileDialog();
            oFileDialog.Filter = "Documentos (*.doc;*.docx;*.xls;*xlsx)|*.DOC;*.DOCX;*.XLS;*.XLSX";
            if (oFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = oFileDialog.FileName;
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (File.Exists(txtFilePath.Text))
            {
                Documento documentoEnviar = new Documento()
                {
                    NombreDocumento = Path.GetFileName(txtFilePath.Text),
                    Fecha = DateTime.Now,
                    TipoDocumento = Path.GetExtension(txtFilePath.Text),
                    NombreUsuarioEmisor = Login.Instance.NombreUsuario,
                    Archivo = File.ReadAllBytes(txtFilePath.Text)
                };
                byte[] documento = File.ReadAllBytes(txtFilePath.Text);
                List<Usuario> lstDestinatarios = new List<Usuario>();
                Usuario destinatario;
                foreach (DataGridViewRow item in grdViewUsuarios.Rows)
                {
                    if (item.Cells["IsFirma"].Value == null ? false : (bool)item.Cells["IsFirma"].Value)
                    {
                        destinatario = new Usuario();
                        destinatario.Username = item.Cells["Username"].Value.ToString();
                        destinatario.TipoEnvio = Usuario.TipoEnvioEnum.Firma;
                        lstDestinatarios.Add(destinatario);
                    }
                    else if (item.Cells["IsLectura"].Value == null ? false : (bool)item.Cells["IsLectura"].Value)
                    {
                        destinatario = new Usuario();
                        destinatario.Username = item.Cells["Username"].Value.ToString();
                        destinatario.TipoEnvio = Usuario.TipoEnvioEnum.Lectura;
                        lstDestinatarios.Add(destinatario);
                    }
                }
                int idDocumento = DataAccess.Instance.EnviarDocumento(lstDestinatarios, documentoEnviar);
                if (idDocumento != -1)
                {
                    if (chkFirmado.Checked)
                    {
                        new FormFirmarDocumento(idDocumento).Show(this);
                        this.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Documento enviado correctamente");
                    }
                }
                else
                {
                    MessageBox.Show("Error enviando documento");
                }
            }
            else
            {
                MessageBox.Show("El archivo seleccionado no existe o no ha seleccionado un destinatario");
            }
        }

        private void lstDepartamentos_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            LlenarListaDestinatarios(DataAccess.Instance.ObtenerUsuarioPorDepartamento(lstDepartamentos.Items[e.Index].ToString()));
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region Atributos
        List<Usuario> _UsuariosDestinatarios = new List<Usuario>();
        #endregion

    }
}
