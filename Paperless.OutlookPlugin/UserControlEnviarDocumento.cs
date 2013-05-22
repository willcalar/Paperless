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
        public UserControlEnviarDocumento()
        {
            InitializeComponent();
            //LlenarListaDestinatarios();
            LlenarListaDepartamentos();
        }

        private void LlenarListaDepartamentos()
        {
            String[] arrDepartamentos = DataAccess.Instance.ObtenerDepartamentos();
            foreach (String m in arrDepartamentos)
            {
                lstDepartamentos.Items.Add(m);
            }
        }

        private void LlenarListaDestinatarios(List<Usuario> arrUsuarios)
        {
            //Usuario[] arrUsuarios = DataAccess.Instance.ObtenerTodosUsuarios();
            //int i = 15;
            foreach (Usuario m in arrUsuarios)
            {
                /*CheckBox newCheckBox = new CheckBox();
                newCheckBox.ThreeState = true;
                newCheckBox.Text = m.NombreUsuario + " " + m.PrimerApellido;
                newCheckBox.Name = m.Username;
                newCheckBox.Location = new System.Drawing.Point(grpUsuarios.Location.X * i, grpUsuarios.Location.Y+5);
                grpUsuarios.Controls.Add(newCheckBox);*/
                lstUsuarios.Items.Add(m.NombreUsuario + " " + m.PrimerApellido + " " + m.SegundoApellido);
                _UsuariosDestinatarios.Add(m);
            }
        }

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
            if (File.Exists(txtFilePath.Text)&& lstUsuarios.SelectedItems.Count>0)
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
                for (int i = 0; i < lstUsuarios.Items.Count; i++)
                {
                    if (lstUsuarios.GetItemChecked(i))
                    {
                        string str = (string)lstUsuarios.Items[i];

                        lstDestinatarios.Add(new Usuario { Username = BuscarUsername(str),  });

                    }
                }
                int idDocumento = DataAccess.Instance.EnviarDocumento(lstDestinatarios, documentoEnviar);
                if (idDocumento!=-1)
                {
                    if (chkFirmado.Checked)
                    {
                        new FormFirmarDocumento(idDocumento).Show(this);
                        this.Visible = false;
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

        private string BuscarUsername(string pNombreCompleto)
        {
            string []nombreTokens = pNombreCompleto.Split(' ');
            return (from users in _UsuariosDestinatarios
                    where users.NombreUsuario == nombreTokens[0]
                    && users.PrimerApellido == nombreTokens[1]
                    && users.SegundoApellido == nombreTokens[2]
                    select users).First().Username;
        }

        private void lstDepartamentos_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            LlenarListaDestinatarios(DataAccess.Instance.ObtenerUsuarioPorDepartamento(lstDepartamentos.Items[e.Index].ToString()));
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {

        }


        #region Variables
        List<Usuario> _UsuariosDestinatarios = new List<Usuario>();
        #endregion
    }
}
