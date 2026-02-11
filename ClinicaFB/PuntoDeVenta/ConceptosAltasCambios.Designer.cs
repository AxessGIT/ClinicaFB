namespace ClinicaFB.PuntoDeVenta
{
    partial class ConceptosAltasCambios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConceptosAltasCambios));
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkEsVenta = new System.Windows.Forms.CheckBox();
            this.cmdGuardar = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cboPrecioCosto = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.spnFolio = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.spnFolio)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTipo
            // 
            this.txtTipo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipo.Location = new System.Drawing.Point(84, 12);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.ReadOnly = true;
            this.txtTipo.Size = new System.Drawing.Size(209, 23);
            this.txtTipo.TabIndex = 1;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Location = new System.Drawing.Point(84, 48);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(404, 23);
            this.txtDescripcion.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descripcion";
            // 
            // chkEsVenta
            // 
            this.chkEsVenta.AutoSize = true;
            this.chkEsVenta.Location = new System.Drawing.Point(12, 126);
            this.chkEsVenta.Name = "chkEsVenta";
            this.chkEsVenta.Size = new System.Drawing.Size(147, 20);
            this.chkEsVenta.TabIndex = 6;
            this.chkEsVenta.Text = "Es concepto de venta";
            this.chkEsVenta.UseVisualStyleBackColor = true;
            // 
            // cmdGuardar
            // 
            this.cmdGuardar.Image = ((System.Drawing.Image)(resources.GetObject("cmdGuardar.Image")));
            this.cmdGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGuardar.Location = new System.Drawing.Point(139, 223);
            this.cmdGuardar.Name = "cmdGuardar";
            this.cmdGuardar.Size = new System.Drawing.Size(110, 48);
            this.cmdGuardar.TabIndex = 11;
            this.cmdGuardar.Text = "&Guardar";
            this.cmdGuardar.UseVisualStyleBackColor = true;
            this.cmdGuardar.Click += new System.EventHandler(this.cmdGuardar_Click);
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSalir.Location = new System.Drawing.Point(255, 223);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(110, 48);
            this.cmdSalir.TabIndex = 12;
            this.cmdSalir.Text = "&Salir";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Se da salida por valor unitario";
            // 
            // cboPrecioCosto
            // 
            this.cboPrecioCosto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrecioCosto.FormattingEnabled = true;
            this.cboPrecioCosto.Items.AddRange(new object[] {
            "Último Costo",
            "Precio de venta"});
            this.cboPrecioCosto.Location = new System.Drawing.Point(193, 84);
            this.cboPrecioCosto.Name = "cboPrecioCosto";
            this.cboPrecioCosto.Size = new System.Drawing.Size(282, 24);
            this.cboPrecioCosto.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Serie";
            // 
            // txtSerie
            // 
            this.txtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSerie.Location = new System.Drawing.Point(84, 167);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(123, 23);
            this.txtSerie.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(240, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Folio";
            // 
            // spnFolio
            // 
            this.spnFolio.Location = new System.Drawing.Point(294, 167);
            this.spnFolio.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.spnFolio.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spnFolio.Name = "spnFolio";
            this.spnFolio.Size = new System.Drawing.Size(71, 23);
            this.spnFolio.TabIndex = 10;
            this.spnFolio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.spnFolio.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ConceptosAltasCambios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 283);
            this.Controls.Add(this.spnFolio);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSerie);
            this.Controls.Add(this.cboPrecioCosto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdGuardar);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.chkEsVenta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtTipo);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "ConceptosAltasCambios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conceptos";
            this.Load += new System.EventHandler(this.ConceptosAltasCambios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spnFolio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkEsVenta;
        private System.Windows.Forms.Button cmdGuardar;
        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboPrecioCosto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown spnFolio;
    }
}