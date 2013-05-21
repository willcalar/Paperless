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
            LlenarListaDestinatarios();
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

        private void LlenarListaDestinatarios()
        {
            Usuario[] arrUsuarios = DataAccess.Instance.ObtenerTodosUsuarios();
            foreach (Usuario m in arrUsuarios)
            {
                //lstUsuarios.Items.Add(m.NombreUsuario + " " + m.PrimerApellido + " " + m.SegundoApellido);
                lstUsuarios.Items.Add(m.Username);
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
                        lstDestinatarios.Add(new Usuario { Username = str });
                    }
                }
                DataAccess.Instance.EnviarDocumento(lstDestinatarios, documentoEnviar);
            }
            else
            {
                MessageBox.Show("El archivo seleccionado no existe o no ha seleccionado un destinatario");
            }
            
        }

    }
}
