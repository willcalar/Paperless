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
            this.dataGridViewDocumentos = new System.Windows.Forms.DataGridView();
            this.IdDocumentoC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentoC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmisorC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirmadoC = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FirmarC = new System.Windows.Forms.DataGridViewLinkColumn();
            this.VerOtrasFirmasC = new System.Windows.Forms.DataGridViewLinkColumn();
            this.DescargarC = new System.Windows.Forms.DataGridViewLinkColumn();
            this.saveFileDialogDescargar = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocumentos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewDocumentos
            // 
            this.dataGridViewDocumentos.AllowUserToAddRows = false;
            this.dataGridViewDocumentos.AllowUserToDeleteRows = false;
            this.dataGridViewDocumentos.AllowUserToOrderColumns = true;
            this.dataGridViewDocumentos.AllowUserToResizeColumns = false;
            this.dataGridViewDocumentos.AllowUserToResizeRows = false;
            this.dataGridViewDocumentos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDocumentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdDocumentoC,
            this.FechaC,
            this.DocumentoC,
            this.EmisorC,
            this.FirmadoC,
            this.FirmarC,
            this.VerOtrasFirmasC,
            this.DescargarC});
            this.dataGridViewDocumentos.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewDocumentos.Name = "dataGridViewDocumentos";
            this.dataGridViewDocumentos.RowHeadersVisible = false;
            this.dataGridViewDocumentos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewDocumentos.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridViewDocumentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDocumentos.Size = new System.Drawing.Size(712, 507);
            this.dataGridViewDocumentos.TabIndex = 0;
            this.dataGridViewDocumentos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDocumentos_CellContentClick);
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
            this.Controls.Add(this.dataGridViewDocumentos);
            this.Name = "UserControlRecibirDocumentos";
            this.Size = new System.Drawing.Size(718, 513);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocumentos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridViewDocumentos;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdDocumentoC;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaC;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentoC;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmisorC;
        private System.Windows.Forms.DataGridViewCheckBoxColumn FirmadoC;
        private System.Windows.Forms.DataGridViewLinkColumn FirmarC;
        private System.Windows.Forms.DataGridViewLinkColumn VerOtrasFirmasC;
        private System.Windows.Forms.DataGridViewLinkColumn DescargarC;
        private System.Windows.Forms.SaveFileDialog saveFileDialogDescargar;
    }
}
