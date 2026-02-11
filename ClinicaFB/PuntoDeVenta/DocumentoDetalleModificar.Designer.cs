namespace ClinicaFB.PuntoDeVenta
{
    partial class DocumentoDetalleModificar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentoDetalleModificar));
            this.cmdGuardar = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.spnCantidad = new System.Windows.Forms.NumericUpDown();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotal = new Syncfusion.Windows.Forms.Tools.CurrencyEdit();
            this.txtCosto = new Syncfusion.Windows.Forms.Tools.CurrencyEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spnCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCosto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCosto.TextBox)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdGuardar
            // 
            this.cmdGuardar.Image = ((System.Drawing.Image)(resources.GetObject("cmdGuardar.Image")));
            this.cmdGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGuardar.Location = new System.Drawing.Point(168, 185);
            this.cmdGuardar.Name = "cmdGuardar";
            this.cmdGuardar.Size = new System.Drawing.Size(110, 48);
            this.cmdGuardar.TabIndex = 13;
            this.cmdGuardar.Text = "&Guardar";
            this.cmdGuardar.UseVisualStyleBackColor = true;
            this.cmdGuardar.Click += new System.EventHandler(this.cmdGuardar_Click);
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSalir.Location = new System.Drawing.Point(284, 185);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(110, 48);
            this.cmdSalir.TabIndex = 14;
            this.cmdSalir.Text = "&Salir";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // spnCantidad
            // 
            this.spnCantidad.DecimalPlaces = 4;
            this.spnCantidad.Location = new System.Drawing.Point(97, 80);
            this.spnCantidad.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.spnCantidad.Name = "spnCantidad";
            this.spnCantidad.Size = new System.Drawing.Size(80, 23);
            this.spnCantidad.TabIndex = 6;
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
            this.txtDescripcion.Location = new System.Drawing.Point(97, 46);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ReadOnly = true;
            this.txtDescripcion.Size = new System.Drawing.Size(459, 23);
            this.txtDescripcion.TabIndex = 4;
            // 
            // txtClave
            // 
            this.txtClave.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClave.Location = new System.Drawing.Point(97, 12);
            this.txtClave.Name = "txtClave";
            this.txtClave.ReadOnly = true;
            this.txtClave.Size = new System.Drawing.Size(219, 23);
            this.txtClave.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cantidad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descripción";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Clave";
            // 
            // txtTotal
            // 
            this.txtTotal.BeforeTouchSize = new System.Drawing.Size(133, 24);
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(97, 149);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ShowCalculator = false;
            this.txtTotal.Size = new System.Drawing.Size(133, 24);
            this.txtTotal.TabIndex = 10;
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
            // txtCosto
            // 
            this.txtCosto.BeforeTouchSize = new System.Drawing.Size(133, 24);
            this.txtCosto.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCosto.Location = new System.Drawing.Point(97, 114);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(133, 24);
            this.txtCosto.TabIndex = 8;
            // 
            // 
            // 
            this.txtCosto.TextBox.AccessibilityEnabled = true;
            this.txtCosto.TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCosto.TextBox.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtCosto.TextBox.Location = new System.Drawing.Point(3, 4);
            this.txtCosto.TextBox.Name = "";
            this.txtCosto.TextBox.Size = new System.Drawing.Size(103, 16);
            this.txtCosto.TextBox.TabIndex = 0;
            this.txtCosto.TextBox.Text = "$0.00";
            this.txtCosto.Validated += new System.EventHandler(this.txtCosto_Validated);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Total";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Valor unitario";
            // 
            // DocumentoDetalleModificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 242);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtCosto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.spnCantidad);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdGuardar);
            this.Controls.Add(this.cmdSalir);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "DocumentoDetalleModificar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar artículo";
            this.Load += new System.EventHandler(this.CompraDetalleModificar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spnCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCosto.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCosto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdGuardar;
        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.NumericUpDown spnCantidad;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Syncfusion.Windows.Forms.Tools.CurrencyEdit txtTotal;
        private Syncfusion.Windows.Forms.Tools.CurrencyEdit txtCosto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}