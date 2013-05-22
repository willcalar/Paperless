namespace Paperless.WordPlugin
{
    partial class FormFirmarDocumento
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBoxFirmaDigital = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonFirmar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonAbrirFirma = new System.Windows.Forms.Button();
            this.labelFirmaDigital = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "frm";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "\"Firma Digital|*.frm|All filles|*.*\"";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // textBoxFirmaDigital
            // 
            this.textBoxFirmaDigital.Location = new System.Drawing.Point(12, 36);
            this.textBoxFirmaDigital.Name = "textBoxFirmaDigital";
            this.textBoxFirmaDigital.Size = new System.Drawing.Size(249, 20);
            this.textBoxFirmaDigital.TabIndex = 0;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(12, 92);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(249, 20);
            this.textBoxPassword.TabIndex = 1;
            // 
            // buttonFirmar
            // 
            this.buttonFirmar.Location = new System.Drawing.Point(64, 125);
            this.buttonFirmar.Name = "buttonFirmar";
            this.buttonFirmar.Size = new System.Drawing.Size(75, 23);
            this.buttonFirmar.TabIndex = 2;
            this.buttonFirmar.Text = "Firmar";
            this.buttonFirmar.UseVisualStyleBackColor = true;
            this.buttonFirmar.Click += new System.EventHandler(this.buttonFirmar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(164, 125);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 3;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonAbrirFirma
            // 
            this.buttonAbrirFirma.Location = new System.Drawing.Point(264, 34);
            this.buttonAbrirFirma.Name = "buttonAbrirFirma";
            this.buttonAbrirFirma.Size = new System.Drawing.Size(30, 23);
            this.buttonAbrirFirma.TabIndex = 4;
            this.buttonAbrirFirma.Text = "...";
            this.buttonAbrirFirma.UseVisualStyleBackColor = true;
            this.buttonAbrirFirma.Click += new System.EventHandler(this.buttonAbrirFirma_Click);
            // 
            // labelFirmaDigital
            // 
            this.labelFirmaDigital.AutoSize = true;
            this.labelFirmaDigital.Location = new System.Drawing.Point(13, 13);
            this.labelFirmaDigital.Name = "labelFirmaDigital";
            this.labelFirmaDigital.Size = new System.Drawing.Size(64, 13);
            this.labelFirmaDigital.TabIndex = 5;
            this.labelFirmaDigital.Text = "Firma Digital";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(13, 67);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(61, 13);
            this.labelPassword.TabIndex = 6;
            this.labelPassword.Text = "Contraseña";
            // 
            // FormFirmarDocumento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 160);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelFirmaDigital);
            this.Controls.Add(this.buttonAbrirFirma);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonFirmar);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxFirmaDigital);
            this.Name = "FormFirmarDocumento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Firmar Documento";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFirmaDigital;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonFirmar;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonAbrirFirma;
        private System.Windows.Forms.Label labelFirmaDigital;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}