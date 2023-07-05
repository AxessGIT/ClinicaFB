namespace ClinicaFB.Ingresos
{
    partial class IngresoFacturarOpciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IngresoFacturarOpciones));
            this.label1 = new System.Windows.Forms.Label();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.txtRFC = new System.Windows.Forms.TextBox();
            this.cmdBuscarCveFOP = new System.Windows.Forms.Button();
            this.txtDescripcionFOP = new System.Windows.Forms.TextBox();
            this.txtCveFOP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdBuscarCveMEP = new System.Windows.Forms.Button();
            this.txtDescripcionMEP = new System.Windows.Forms.TextBox();
            this.txtCveMEP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdBuscarCveUSO = new System.Windows.Forms.Button();
            this.txtDescripcionUSO = new System.Windows.Forms.TextBox();
            this.txtCveUSO = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkImprimir = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboImpresoras = new System.Windows.Forms.ComboBox();
            this.chkMandarCorreo = new System.Windows.Forms.CheckBox();
            this.txtCorreos = new System.Windows.Forms.TextBox();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.cmdAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Razon social";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(286, 40);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.ReadOnly = true;
            this.txtRazonSocial.Size = new System.Drawing.Size(358, 23);
            this.txtRazonSocial.TabIndex = 2;
            this.txtRazonSocial.Text = "PUBLICO EN GENERAL";
            // 
            // txtRFC
            // 
            this.txtRFC.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRFC.Location = new System.Drawing.Point(124, 40);
            this.txtRFC.Name = "txtRFC";
            this.txtRFC.ReadOnly = true;
            this.txtRFC.Size = new System.Drawing.Size(156, 23);
            this.txtRFC.TabIndex = 1;
            this.txtRFC.Text = "XAXX010101000";
            // 
            // cmdBuscarCveFOP
            // 
            this.cmdBuscarCveFOP.Location = new System.Drawing.Point(273, 86);
            this.cmdBuscarCveFOP.Name = "cmdBuscarCveFOP";
            this.cmdBuscarCveFOP.Size = new System.Drawing.Size(32, 23);
            this.cmdBuscarCveFOP.TabIndex = 5;
            this.cmdBuscarCveFOP.Text = "...";
            this.cmdBuscarCveFOP.UseVisualStyleBackColor = true;
            this.cmdBuscarCveFOP.Click += new System.EventHandler(this.cmdBuscarCveFOP_Click);
            // 
            // txtDescripcionFOP
            // 
            this.txtDescripcionFOP.Location = new System.Drawing.Point(309, 86);
            this.txtDescripcionFOP.Name = "txtDescripcionFOP";
            this.txtDescripcionFOP.ReadOnly = true;
            this.txtDescripcionFOP.Size = new System.Drawing.Size(307, 23);
            this.txtDescripcionFOP.TabIndex = 6;
            this.txtDescripcionFOP.Text = "Efectivo";
            // 
            // txtCveFOP
            // 
            this.txtCveFOP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCveFOP.Location = new System.Drawing.Point(123, 86);
            this.txtCveFOP.Name = "txtCveFOP";
            this.txtCveFOP.Size = new System.Drawing.Size(144, 23);
            this.txtCveFOP.TabIndex = 3;
            this.txtCveFOP.Text = "01";
            this.txtCveFOP.Validated += new System.EventHandler(this.txtCveFOP_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Forma de  pago";
            // 
            // cmdBuscarCveMEP
            // 
            this.cmdBuscarCveMEP.Enabled = false;
            this.cmdBuscarCveMEP.Location = new System.Drawing.Point(274, 132);
            this.cmdBuscarCveMEP.Name = "cmdBuscarCveMEP";
            this.cmdBuscarCveMEP.Size = new System.Drawing.Size(32, 23);
            this.cmdBuscarCveMEP.TabIndex = 9;
            this.cmdBuscarCveMEP.Text = "...";
            this.cmdBuscarCveMEP.UseVisualStyleBackColor = true;
            this.cmdBuscarCveMEP.Click += new System.EventHandler(this.cmdBuscarCveMEP_Click);
            // 
            // txtDescripcionMEP
            // 
            this.txtDescripcionMEP.Location = new System.Drawing.Point(310, 132);
            this.txtDescripcionMEP.Name = "txtDescripcionMEP";
            this.txtDescripcionMEP.ReadOnly = true;
            this.txtDescripcionMEP.Size = new System.Drawing.Size(307, 23);
            this.txtDescripcionMEP.TabIndex = 10;
            this.txtDescripcionMEP.Text = "Pago en una exhibición";
            // 
            // txtCveMEP
            // 
            this.txtCveMEP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCveMEP.Enabled = false;
            this.txtCveMEP.Location = new System.Drawing.Point(124, 132);
            this.txtCveMEP.Name = "txtCveMEP";
            this.txtCveMEP.Size = new System.Drawing.Size(144, 23);
            this.txtCveMEP.TabIndex = 5;
            this.txtCveMEP.Text = "PUE";
            this.txtCveMEP.Validated += new System.EventHandler(this.txtCveMEP_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Método de pago";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // cmdBuscarCveUSO
            // 
            this.cmdBuscarCveUSO.Enabled = false;
            this.cmdBuscarCveUSO.Location = new System.Drawing.Point(274, 178);
            this.cmdBuscarCveUSO.Name = "cmdBuscarCveUSO";
            this.cmdBuscarCveUSO.Size = new System.Drawing.Size(32, 23);
            this.cmdBuscarCveUSO.TabIndex = 13;
            this.cmdBuscarCveUSO.Text = "...";
            this.cmdBuscarCveUSO.UseVisualStyleBackColor = true;
            this.cmdBuscarCveUSO.Click += new System.EventHandler(this.cmdBuscarCveUSO_Click);
            // 
            // txtDescripcionUSO
            // 
            this.txtDescripcionUSO.Location = new System.Drawing.Point(310, 178);
            this.txtDescripcionUSO.Name = "txtDescripcionUSO";
            this.txtDescripcionUSO.ReadOnly = true;
            this.txtDescripcionUSO.Size = new System.Drawing.Size(307, 23);
            this.txtDescripcionUSO.TabIndex = 14;
            this.txtDescripcionUSO.Text = "Sin efectos fiscales";
            // 
            // txtCveUSO
            // 
            this.txtCveUSO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCveUSO.Enabled = false;
            this.txtCveUSO.Location = new System.Drawing.Point(124, 178);
            this.txtCveUSO.Name = "txtCveUSO";
            this.txtCveUSO.Size = new System.Drawing.Size(144, 23);
            this.txtCveUSO.TabIndex = 7;
            this.txtCveUSO.Text = "S01";
            this.txtCveUSO.Validated += new System.EventHandler(this.txtCveUSO_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Uso Cfdi";
            // 
            // chkImprimir
            // 
            this.chkImprimir.AutoSize = true;
            this.chkImprimir.Checked = true;
            this.chkImprimir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkImprimir.Location = new System.Drawing.Point(23, 232);
            this.chkImprimir.Name = "chkImprimir";
            this.chkImprimir.Size = new System.Drawing.Size(119, 20);
            this.chkImprimir.TabIndex = 8;
            this.chkImprimir.Text = "Imprimir factura";
            this.chkImprimir.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Impresora";
            // 
            // cboImpresoras
            // 
            this.cboImpresoras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboImpresoras.FormattingEnabled = true;
            this.cboImpresoras.Location = new System.Drawing.Point(97, 257);
            this.cboImpresoras.Name = "cboImpresoras";
            this.cboImpresoras.Size = new System.Drawing.Size(372, 24);
            this.cboImpresoras.TabIndex = 10;
            // 
            // chkMandarCorreo
            // 
            this.chkMandarCorreo.AutoSize = true;
            this.chkMandarCorreo.Checked = true;
            this.chkMandarCorreo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMandarCorreo.Location = new System.Drawing.Point(24, 288);
            this.chkMandarCorreo.Name = "chkMandarCorreo";
            this.chkMandarCorreo.Size = new System.Drawing.Size(177, 20);
            this.chkMandarCorreo.TabIndex = 11;
            this.chkMandarCorreo.Text = "Mandar factura por correo";
            this.chkMandarCorreo.UseVisualStyleBackColor = true;
            // 
            // txtCorreos
            // 
            this.txtCorreos.Location = new System.Drawing.Point(23, 314);
            this.txtCorreos.Name = "txtCorreos";
            this.txtCorreos.Size = new System.Drawing.Size(441, 23);
            this.txtCorreos.TabIndex = 12;
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancelar.Image")));
            this.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancelar.Location = new System.Drawing.Point(333, 379);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(120, 54);
            this.cmdCancelar.TabIndex = 14;
            this.cmdCancelar.Text = "&Cancelar";
            this.cmdCancelar.UseVisualStyleBackColor = true;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.Image = ((System.Drawing.Image)(resources.GetObject("cmdAceptar.Image")));
            this.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAceptar.Location = new System.Drawing.Point(207, 379);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(120, 54);
            this.cmdAceptar.TabIndex = 13;
            this.cmdAceptar.Text = "&Aceptar";
            this.cmdAceptar.UseVisualStyleBackColor = true;
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // IngresoFacturarOpciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 448);
            this.Controls.Add(this.txtCorreos);
            this.Controls.Add(this.chkMandarCorreo);
            this.Controls.Add(this.cboImpresoras);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkImprimir);
            this.Controls.Add(this.cmdBuscarCveUSO);
            this.Controls.Add(this.txtDescripcionUSO);
            this.Controls.Add(this.txtCveUSO);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdBuscarCveMEP);
            this.Controls.Add(this.txtDescripcionMEP);
            this.Controls.Add(this.txtCveMEP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdBuscarCveFOP);
            this.Controls.Add(this.txtDescripcionFOP);
            this.Controls.Add(this.txtCveFOP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdAceptar);
            this.Controls.Add(this.txtRazonSocial);
            this.Controls.Add(this.txtRFC);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimizeBox = false;
            this.Name = "IngresoFacturarOpciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Especifique datos factura";
            this.Load += new System.EventHandler(this.ClavesSATSeleccionar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.TextBox txtRFC;
        private System.Windows.Forms.Button cmdAceptar;
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.Button cmdBuscarCveFOP;
        private System.Windows.Forms.TextBox txtDescripcionFOP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdBuscarCveMEP;
        private System.Windows.Forms.TextBox txtDescripcionMEP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdBuscarCveUSO;
        private System.Windows.Forms.TextBox txtDescripcionUSO;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtCveFOP;
        public System.Windows.Forms.TextBox txtCveMEP;
        public System.Windows.Forms.TextBox txtCveUSO;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.CheckBox chkImprimir;
        public System.Windows.Forms.ComboBox cboImpresoras;
        public System.Windows.Forms.CheckBox chkMandarCorreo;
        public System.Windows.Forms.TextBox txtCorreos;
    }
}