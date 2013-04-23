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
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Emisor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Firmado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Firmar = new System.Windows.Forms.DataGridViewLinkColumn();
            this.VerOtrasFirmas = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Descargar = new System.Windows.Forms.DataGridViewLinkColumn();
            this.buttonCerrar = new System.Windows.Forms.Button();
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
            this.Fecha,
            this.Documento,
            this.Emisor,
            this.Firmado,
            this.Firmar,
            this.VerOtrasFirmas,
            this.Descargar});
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(712, 329);
            this.dataGridView1.TabIndex = 0;
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            // 
            // Documento
            // 
            this.Documento.HeaderText = "Documento";
            this.Documento.Name = "Documento";
            // 
            // Emisor
            // 
            this.Emisor.HeaderText = "Emisor";
            this.Emisor.Name = "Emisor";
            // 
            // Firmado
            // 
            this.Firmado.HeaderText = "Firmado";
            this.Firmado.Name = "Firmado";
            // 
            // Firmar
            // 
            this.Firmar.HeaderText = "Firmar";
            this.Firmar.Name = "Firmar";
            this.Firmar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // VerOtrasFirmas
            // 
            this.VerOtrasFirmas.HeaderText = "Ver otras firmas";
            this.VerOtrasFirmas.Name = "VerOtrasFirmas";
            // 
            // Descargar
            // 
            this.Descargar.HeaderText = "Descargar";
            this.Descargar.Name = "Descargar";
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
            // UserControlOutlook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonCerrar);
            this.Controls.Add(this.dataGridView1);
            this.Name = "UserControlOutlook";
            this.Size = new System.Drawing.Size(718, 369);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Emisor;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Firmado;
        private System.Windows.Forms.DataGridViewLinkColumn Firmar;
        private System.Windows.Forms.DataGridViewLinkColumn VerOtrasFirmas;
        private System.Windows.Forms.DataGridViewLinkColumn Descargar;
        private System.Windows.Forms.Button buttonCerrar;
        public System.Windows.Forms.DataGridView dataGridView1;
    }
}
