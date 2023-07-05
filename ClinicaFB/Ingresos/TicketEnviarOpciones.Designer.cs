namespace ClinicaFB.Ingresos
{
    partial class TicketEnviarOpciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TicketEnviarOpciones));
            this.txtCorreos = new System.Windows.Forms.TextBox();
            this.chkMandarCorreo = new System.Windows.Forms.CheckBox();
            this.cboImpresoras = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkImprimir = new System.Windows.Forms.CheckBox();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.cmdAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCorreos
            // 
            this.txtCorreos.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtCorreos.Location = new System.Drawing.Point(12, 41);
            this.txtCorreos.Name = "txtCorreos";
            this.txtCorreos.Size = new System.Drawing.Size(441, 23);
            this.txtCorreos.TabIndex = 1;
            // 
            // chkMandarCorreo
            // 
            this.chkMandarCorreo.AutoSize = true;
            this.chkMandarCorreo.Checked = true;
            this.chkMandarCorreo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMandarCorreo.Location = new System.Drawing.Point(7, 12);
            this.chkMandarCorreo.Name = "chkMandarCorreo";
            this.chkMandarCorreo.Size = new System.Drawing.Size(167, 20);
            this.chkMandarCorreo.TabIndex = 0;
            this.chkMandarCorreo.Text = "Mandar ticket por correo";
            this.chkMandarCorreo.UseVisualStyleBackColor = true;
            // 
            // cboImpresoras
            // 
            this.cboImpresoras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboImpresoras.FormattingEnabled = true;
            this.cboImpresoras.Location = new System.Drawing.Point(81, 103);
            this.cboImpresoras.Name = "cboImpresoras";
            this.cboImpresoras.Size = new System.Drawing.Size(372, 24);
            this.cboImpresoras.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Impresora";
            // 
            // chkImprimir
            // 
            this.chkImprimir.AutoSize = true;
            this.chkImprimir.Location = new System.Drawing.Point(7, 78);
            this.chkImprimir.Name = "chkImprimir";
            this.chkImprimir.Size = new System.Drawing.Size(109, 20);
            this.chkImprimir.TabIndex = 2;
            this.chkImprimir.Text = "Imprimir ticket";
            this.chkImprimir.UseVisualStyleBackColor = true;
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancelar.Image")));
            this.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancelar.Location = new System.Drawing.Point(245, 140);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(120, 54);
            this.cmdCancelar.TabIndex = 6;
            this.cmdCancelar.Text = "&Cancelar";
            this.cmdCancelar.UseVisualStyleBackColor = true;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.Image = ((System.Drawing.Image)(resources.GetObject("cmdAceptar.Image")));
            this.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAceptar.Location = new System.Drawing.Point(119, 140);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(120, 54);
            this.cmdAceptar.TabIndex = 5;
            this.cmdAceptar.Text = "&Aceptar";
            this.cmdAceptar.UseVisualStyleBackColor = true;
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // TicketEnviarOpciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 219);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdAceptar);
            this.Controls.Add(this.txtCorreos);
            this.Controls.Add(this.chkMandarCorreo);
            this.Controls.Add(this.cboImpresoras);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkImprimir);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TicketEnviarOpciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generar ticket";
            this.Load += new System.EventHandler(this.TicketEnviarOpciones_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.CheckBox chkMandarCorreo;
        public System.Windows.Forms.ComboBox cboImpresoras;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.CheckBox chkImprimir;
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.Button cmdAceptar;
        public System.Windows.Forms.TextBox txtCorreos;
    }
}