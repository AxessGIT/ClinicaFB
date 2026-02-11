namespace ClinicaFB.PuntoDeVenta
{
    partial class VentaConceptoModificar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentaConceptoModificar));
            this.txtTotal = new Syncfusion.Windows.Forms.Tools.CurrencyEdit();
            this.txtPrecio = new Syncfusion.Windows.Forms.Tools.CurrencyEdit();
            this.spnCantidad = new System.Windows.Forms.NumericUpDown();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdGuardar = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.txtDescuento = new Syncfusion.Windows.Forms.Tools.CurrencyEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.lblIncluyeIVA = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecio.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescuento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescuento.TextBox)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTotal
            // 
            this.txtTotal.BeforeTouchSize = new System.Drawing.Size(133, 24);
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(87, 179);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ShowCalculator = false;
            this.txtTotal.Size = new System.Drawing.Size(133, 24);
            this.txtTotal.TabIndex = 21;
            // 
            // 
            // 
            this.txtTotal.TextBox.AccessibilityEnabled = true;
            this.txtTotal.TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotal.TextBox.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtTotal.TextBox.Location = new System.Drawing.Point(2, 4);
            this.txtTotal.TextBox.Name = "";
            this.txtTotal.TextBox.Size = new System.Drawing.Size(129, 16);
            this.txtTotal.TextBox.TabIndex = 0;
            this.txtTotal.TextBox.Text = "$0.00";
            this.txtTotal.TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotal.ThemeName = "WindowsXP";
            this.txtTotal.UseVisualStyle = true;
            // 
            // txtPrecio
            // 
            this.txtPrecio.BeforeTouchSize = new System.Drawing.Size(133, 24);
            this.txtPrecio.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.Location = new System.Drawing.Point(87, 111);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(133, 24);
            this.txtPrecio.TabIndex = 19;
            // 
            // 
            // 
            this.txtPrecio.TextBox.AccessibilityEnabled = true;
            this.txtPrecio.TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrecio.TextBox.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtPrecio.TextBox.Location = new System.Drawing.Point(3, 4);
            this.txtPrecio.TextBox.Name = "";
            this.txtPrecio.TextBox.Size = new System.Drawing.Size(103, 16);
            this.txtPrecio.TextBox.TabIndex = 0;
            this.txtPrecio.TextBox.Text = "$0.00";
            this.txtPrecio.Validated += new System.EventHandler(this.txtPrecio_Validated);
            // 
            // spnCantidad
            // 
            this.spnCantidad.DecimalPlaces = 4;
            this.spnCantidad.Location = new System.Drawing.Point(87, 78);
            this.spnCantidad.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.spnCantidad.Name = "spnCantidad";
            this.spnCantidad.Size = new System.Drawing.Size(80, 23);
            this.spnCantidad.TabIndex = 17;
            this.spnCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.spnCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spnCantidad.Validated += new System.EventHandler(this.spnCantidad_Validated);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Location = new System.Drawing.Point(87, 45);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ReadOnly = true;
            this.txtDescripcion.Size = new System.Drawing.Size(459, 23);
            this.txtDescripcion.TabIndex = 15;
            // 
            // txtClave
            // 
            this.txtClave.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClave.Location = new System.Drawing.Point(87, 12);
            this.txtClave.Name = "txtClave";
            this.txtClave.ReadOnly = true;
            this.txtClave.Size = new System.Drawing.Size(219, 23);
            this.txtClave.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "Total";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 18;
            this.label4.Text = "Precio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Cantidad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Descripción";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Clave";
            // 
            // cmdGuardar
            // 
            this.cmdGuardar.Image = ((System.Drawing.Image)(resources.GetObject("cmdGuardar.Image")));
            this.cmdGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGuardar.Location = new System.Drawing.Point(146, 222);
            this.cmdGuardar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdGuardar.Name = "cmdGuardar";
            this.cmdGuardar.Size = new System.Drawing.Size(129, 43);
            this.cmdGuardar.TabIndex = 23;
            this.cmdGuardar.Text = "&Guardar";
            this.cmdGuardar.UseVisualStyleBackColor = true;
            this.cmdGuardar.Click += new System.EventHandler(this.cmdGuardar_Click);
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSalir.Location = new System.Drawing.Point(282, 222);
            this.cmdSalir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(129, 43);
            this.cmdSalir.TabIndex = 22;
            this.cmdSalir.Text = "&Salir";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // txtDescuento
            // 
            this.txtDescuento.BeforeTouchSize = new System.Drawing.Size(133, 24);
            this.txtDescuento.Enabled = false;
            this.txtDescuento.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescuento.Location = new System.Drawing.Point(87, 145);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.ShowCalculator = false;
            this.txtDescuento.Size = new System.Drawing.Size(133, 24);
            this.txtDescuento.TabIndex = 25;
            // 
            // 
            // 
            this.txtDescuento.TextBox.AccessibilityEnabled = true;
            this.txtDescuento.TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescuento.TextBox.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtDescuento.TextBox.Location = new System.Drawing.Point(2, 4);
            this.txtDescuento.TextBox.Name = "";
            this.txtDescuento.TextBox.Size = new System.Drawing.Size(129, 16);
            this.txtDescuento.TextBox.TabIndex = 0;
            this.txtDescuento.TextBox.Text = "$0.00";
            this.txtDescuento.TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDescuento.ThemeName = "WindowsXP";
            this.txtDescuento.UseVisualStyle = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 16);
            this.label6.TabIndex = 24;
            this.label6.Text = "Descuento";
            // 
            // lblIncluyeIVA
            // 
            this.lblIncluyeIVA.AutoSize = true;
            this.lblIncluyeIVA.Location = new System.Drawing.Point(226, 115);
            this.lblIncluyeIVA.Name = "lblIncluyeIVA";
            this.lblIncluyeIVA.Size = new System.Drawing.Size(123, 16);
            this.lblIncluyeIVA.TabIndex = 26;
            this.lblIncluyeIVA.Text = "El precio incluye IVA";
            // 
            // VentaConceptoModificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 278);
            this.Controls.Add(this.lblIncluyeIVA);
            this.Controls.Add(this.txtDescuento);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmdGuardar);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.spnCantidad);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "VentaConceptoModificar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar partida";
            this.Load += new System.EventHandler(this.VentaConceptoModificar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecio.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescuento.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescuento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.CurrencyEdit txtTotal;
        private Syncfusion.Windows.Forms.Tools.CurrencyEdit txtPrecio;
        private System.Windows.Forms.NumericUpDown spnCantidad;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdGuardar;
        private System.Windows.Forms.Button cmdSalir;
        private Syncfusion.Windows.Forms.Tools.CurrencyEdit txtDescuento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblIncluyeIVA;
    }
}