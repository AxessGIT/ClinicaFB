namespace ClinicaFB.PuntoDeVenta
{
    partial class AlmacenesAltasCambios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlmacenesAltasCambios));
            this.label1 = new System.Windows.Forms.Label();
            this.cmdGuardar = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.chkPrincipal = new System.Windows.Forms.CheckBox();
            this.spnFolioFac = new System.Windows.Forms.NumericUpDown();
            this.txtSerieFac = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.spnFolioVentas = new System.Windows.Forms.NumericUpDown();
            this.txtSerieVentas = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.spnFolioNC = new System.Windows.Forms.NumericUpDown();
            this.txtSerieNC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spnFolioFac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnFolioVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnFolioNC)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Almacen";
            // 
            // cmdGuardar
            // 
            this.cmdGuardar.Image = ((System.Drawing.Image)(resources.GetObject("cmdGuardar.Image")));
            this.cmdGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGuardar.Location = new System.Drawing.Point(133, 388);
            this.cmdGuardar.Name = "cmdGuardar";
            this.cmdGuardar.Size = new System.Drawing.Size(110, 43);
            this.cmdGuardar.TabIndex = 16;
            this.cmdGuardar.Text = "&Guardar";
            this.cmdGuardar.UseVisualStyleBackColor = true;
            this.cmdGuardar.Click += new System.EventHandler(this.cmdGuardar_Click);
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSalir.Location = new System.Drawing.Point(249, 388);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(110, 43);
            this.cmdSalir.TabIndex = 17;
            this.cmdSalir.Text = "&Salir";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Location = new System.Drawing.Point(90, 42);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(382, 23);
            this.txtNombre.TabIndex = 1;
            // 
            // chkPrincipal
            // 
            this.chkPrincipal.AutoSize = true;
            this.chkPrincipal.Location = new System.Drawing.Point(18, 356);
            this.chkPrincipal.Name = "chkPrincipal";
            this.chkPrincipal.Size = new System.Drawing.Size(155, 20);
            this.chkPrincipal.TabIndex = 15;
            this.chkPrincipal.Text = "¿Es almacen principal?";
            this.chkPrincipal.UseVisualStyleBackColor = true;
            this.chkPrincipal.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // spnFolioFac
            // 
            this.spnFolioFac.Location = new System.Drawing.Point(165, 212);
            this.spnFolioFac.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.spnFolioFac.Name = "spnFolioFac";
            this.spnFolioFac.Size = new System.Drawing.Size(120, 23);
            this.spnFolioFac.TabIndex = 10;
            // 
            // txtSerieFac
            // 
            this.txtSerieFac.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSerieFac.Location = new System.Drawing.Point(165, 182);
            this.txtSerieFac.Name = "txtSerieFac";
            this.txtSerieFac.Size = new System.Drawing.Size(120, 23);
            this.txtSerieFac.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(77, 215);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 16);
            this.label8.TabIndex = 9;
            this.label8.Text = "Folio factura";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(68, 185);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 16);
            this.label9.TabIndex = 7;
            this.label9.Text = "Serie facturas";
            // 
            // spnFolioVentas
            // 
            this.spnFolioVentas.Location = new System.Drawing.Point(165, 135);
            this.spnFolioVentas.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.spnFolioVentas.Name = "spnFolioVentas";
            this.spnFolioVentas.Size = new System.Drawing.Size(120, 23);
            this.spnFolioVentas.TabIndex = 6;
            // 
            // txtSerieVentas
            // 
            this.txtSerieVentas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSerieVentas.Location = new System.Drawing.Point(165, 105);
            this.txtSerieVentas.Name = "txtSerieVentas";
            this.txtSerieVentas.Size = new System.Drawing.Size(120, 23);
            this.txtSerieVentas.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(80, 138);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 16);
            this.label10.TabIndex = 5;
            this.label10.Text = "Folio ventas";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(77, 108);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 16);
            this.label11.TabIndex = 3;
            this.label11.Text = "Serie ventas";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 16);
            this.label7.TabIndex = 2;
            this.label7.Text = "Punto de Venta";
            // 
            // spnFolioNC
            // 
            this.spnFolioNC.Location = new System.Drawing.Point(165, 290);
            this.spnFolioNC.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.spnFolioNC.Name = "spnFolioNC";
            this.spnFolioNC.Size = new System.Drawing.Size(120, 23);
            this.spnFolioNC.TabIndex = 14;
            // 
            // txtSerieNC
            // 
            this.txtSerieNC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSerieNC.Location = new System.Drawing.Point(165, 260);
            this.txtSerieNC.Name = "txtSerieNC";
            this.txtSerieNC.Size = new System.Drawing.Size(120, 23);
            this.txtSerieNC.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 293);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Folio notas de crédito";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Serie notas de crédito";
            // 
            // AlmacenesAltasCambios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 455);
            this.Controls.Add(this.spnFolioNC);
            this.Controls.Add(this.txtSerieNC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.spnFolioFac);
            this.Controls.Add(this.txtSerieFac);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.spnFolioVentas);
            this.Controls.Add(this.txtSerieVentas);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chkPrincipal);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.cmdGuardar);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "AlmacenesAltasCambios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AlmacenesAltasCambios";
            this.Load += new System.EventHandler(this.AlmacenesAltasCambios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spnFolioFac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnFolioVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnFolioNC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdGuardar;
        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.CheckBox chkPrincipal;
        private System.Windows.Forms.NumericUpDown spnFolioFac;
        private System.Windows.Forms.TextBox txtSerieFac;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown spnFolioVentas;
        private System.Windows.Forms.TextBox txtSerieVentas;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown spnFolioNC;
        private System.Windows.Forms.TextBox txtSerieNC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}