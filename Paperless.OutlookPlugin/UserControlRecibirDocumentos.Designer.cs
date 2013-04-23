namespace Paperless.OutlookPlugin
{
    partial class UserControlRecibirDocumentos
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonCerrar = new System.Windows.Forms.Button();
            this.IdDocumentoC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentoC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmisorC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirmadoC = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FirmarC = new System.Windows.Forms.DataGridViewLinkColumn();
            this.VerOtrasFirmasC = new System.Windows.Forms.DataGridViewLinkColumn();
            this.DescargarC = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdDocumentoC,
            this.FechaC,
            this.DocumentoC,
            this.EmisorC,
            this.FirmadoC,
            this.FirmarC,
            this.VerOtrasFirmasC,
            this.DescargarC});
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(712, 329);
            this.dataGridView1.TabIndex = 0;
            // 
            // buttonCerrar
            // 
            this.buttonCerrar.Location = new System.Drawing.Point(616, 339);
            this.buttonCerrar.Name = "buttonCerrar";
            this.buttonCerrar.Size = new System.Drawing.Size(75, 23);
            this.buttonCerrar.TabIndex = 1;
            this.buttonCerrar.Text = "Cerrar";
            this.buttonCerrar.UseVisualStyleBackColor = true;
            // 
            // IdDocumentoC
            // 
            this.IdDocumentoC.HeaderText = "IdDocumento";
            this.IdDocumentoC.Name = "IdDocumentoC";
            this.IdDocumentoC.ReadOnly = true;
            this.IdDocumentoC.Visible = false;
            // 
            // FechaC
            // 
            this.FechaC.HeaderText = "Fecha";
            this.FechaC.Name = "FechaC";
            // 
            // DocumentoC
            // 
            this.DocumentoC.HeaderText = "Documento";
            this.DocumentoC.Name = "DocumentoC";
            // 
            // EmisorC
            // 
            this.EmisorC.HeaderText = "Emisor";
            this.EmisorC.Name = "EmisorC";
            // 
            // FirmadoC
            // 
            this.FirmadoC.HeaderText = "Firmado";
            this.FirmadoC.Name = "FirmadoC";
            // 
            // FirmarC
            // 
            this.FirmarC.HeaderText = "Firmar";
            this.FirmarC.Name = "FirmarC";
            this.FirmarC.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // VerOtrasFirmasC
            // 
            this.VerOtrasFirmasC.HeaderText = "Ver otras firmas";
            this.VerOtrasFirmasC.Name = "VerOtrasFirmasC";
            // 
            // DescargarC
            // 
            this.DescargarC.HeaderText = "Descargar";
            this.DescargarC.Name = "DescargarC";
            // 
            // UserControlRecibirDocumentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonCerrar);
            this.Controls.Add(this.dataGridView1);
            this.Name = "UserControlRecibirDocumentos";
            this.Size = new System.Drawing.Size(718, 369);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCerrar;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdDocumentoC;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaC;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentoC;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmisorC;
        private System.Windows.Forms.DataGridViewCheckBoxColumn FirmadoC;
        private System.Windows.Forms.DataGridViewLinkColumn FirmarC;
        private System.Windows.Forms.DataGridViewLinkColumn VerOtrasFirmasC;
        private System.Windows.Forms.DataGridViewLinkColumn DescargarC;
    }
}
