namespace Paperless.OutlookPlugin
{
    partial class FormDetalleDocumento
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonVerDocumento = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEmisor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnReceptor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEstado = new System.Windows.Forms.DataGridViewImageColumn();
            this.buttonFirmar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonVerDocumento
            // 
            this.buttonVerDocumento.Location = new System.Drawing.Point(397, 354);
            this.buttonVerDocumento.Name = "buttonVerDocumento";
            this.buttonVerDocumento.Size = new System.Drawing.Size(94, 23);
            this.buttonVerDocumento.TabIndex = 3;
            this.buttonVerDocumento.Text = "Ver Documento";
            this.buttonVerDocumento.UseVisualStyleBackColor = true;
            this.buttonVerDocumento.Click += new System.EventHandler(this.buttonVerDocumento_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnFecha,
            this.ColumnDocumento,
            this.ColumnEmisor,
            this.ColumnReceptor,
            this.ColumnEstado});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(503, 341);
            this.dataGridView1.TabIndex = 2;
            // 
            // ColumnFecha
            // 
            this.ColumnFecha.HeaderText = "Fecha";
            this.ColumnFecha.Name = "ColumnFecha";
            // 
            // ColumnDocumento
            // 
            this.ColumnDocumento.HeaderText = "Documento";
            this.ColumnDocumento.Name = "ColumnDocumento";
            // 
            // ColumnEmisor
            // 
            this.ColumnEmisor.HeaderText = "Emisor";
            this.ColumnEmisor.Name = "ColumnEmisor";
            // 
            // ColumnReceptor
            // 
            this.ColumnReceptor.HeaderText = "Receptor";
            this.ColumnReceptor.Name = "ColumnReceptor";
            // 
            // ColumnEstado
            // 
            this.ColumnEstado.HeaderText = "Estado";
            this.ColumnEstado.Name = "ColumnEstado";
            // 
            // buttonFirmar
            // 
            this.buttonFirmar.Enabled = false;
            this.buttonFirmar.Location = new System.Drawing.Point(22, 354);
            this.buttonFirmar.Name = "buttonFirmar";
            this.buttonFirmar.Size = new System.Drawing.Size(94, 23);
            this.buttonFirmar.TabIndex = 4;
            this.buttonFirmar.Text = "Firmar";
            this.buttonFirmar.UseVisualStyleBackColor = true;
            this.buttonFirmar.Click += new System.EventHandler(this.buttonFirmar_Click);
            // 
            // FormDetalleDocumento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 385);
            this.Controls.Add(this.buttonFirmar);
            this.Controls.Add(this.buttonVerDocumento);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDetalleDocumento";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle de Documento";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormDetalleDocumento_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonVerDocumento;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEmisor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReceptor;
        private System.Windows.Forms.DataGridViewImageColumn ColumnEstado;
        private System.Windows.Forms.Button buttonFirmar;
    }
}