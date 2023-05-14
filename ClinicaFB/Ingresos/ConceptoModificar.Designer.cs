namespace ClinicaFB.Ingresos
{
    partial class ConceptoModificar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConceptoModificar));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdGuardar = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.spnCantidad = new System.Windows.Forms.NumericUpDown();
            this.txtPrecio = new Syncfusion.Windows.Forms.Tools.CurrencyEdit();
            this.txtTotal = new Syncfusion.Windows.Forms.Tools.CurrencyEdit();
            this.cmdBuscarArticulo = new System.Windows.Forms.Button();
            this.cboImpuestos = new Syncfusion.WinForms.ListView.SfComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDescripcionUnidad = new System.Windows.Forms.TextBox();
            this.cmdBuscarCveUni = new System.Windows.Forms.Button();
            this.cmdBuscarCveProSer = new System.Windows.Forms.Button();
            this.txtDescripcionProSer = new System.Windows.Forms.TextBox();
            this.txtCveUni = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCveProSer = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spnCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecio.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboImpuestos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Clave";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Descripción";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Cantidad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Precio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(67, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Total";
            // 
            // cmdGuardar
            // 
            this.cmdGuardar.Image = ((System.Drawing.Image)(resources.GetObject("cmdGuardar.Image")));
            this.cmdGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGuardar.Location = new System.Drawing.Point(267, 250);
            this.cmdGuardar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdGuardar.Name = "cmdGuardar";
            this.cmdGuardar.Size = new System.Drawing.Size(129, 43);
            this.cmdGuardar.TabIndex = 18;
            this.cmdGuardar.Text = "&Guardar";
            this.cmdGuardar.UseVisualStyleBackColor = true;
            this.cmdGuardar.Click += new System.EventHandler(this.cmdGuardar_Click);
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSalir.Location = new System.Drawing.Point(403, 250);
            this.cmdSalir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(129, 43);
            this.cmdSalir.TabIndex = 0;
            this.cmdSalir.Text = "&Salir";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // txtClave
            // 
            this.txtClave.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClave.Location = new System.Drawing.Point(109, 15);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(219, 23);
            this.txtClave.TabIndex = 2;
            this.txtClave.Validated += new System.EventHandler(this.txtClave_Validated);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Location = new System.Drawing.Point(109, 51);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(459, 23);
            this.txtDescripcion.TabIndex = 5;
            // 
            // spnCantidad
            // 
            this.spnCantidad.DecimalPlaces = 4;
            this.spnCantidad.Location = new System.Drawing.Point(109, 87);
            this.spnCantidad.Name = "spnCantidad";
            this.spnCantidad.Size = new System.Drawing.Size(80, 23);
            this.spnCantidad.TabIndex = 7;
            this.spnCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.spnCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spnCantidad.ValueChanged += new System.EventHandler(this.spnCantidad_ValueChanged);
            // 
            // txtPrecio
            // 
            this.txtPrecio.BeforeTouchSize = new System.Drawing.Size(133, 24);
            this.txtPrecio.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.Location = new System.Drawing.Point(109, 123);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(133, 24);
            this.txtPrecio.TabIndex = 9;
            // 
            // 
            // 
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
            // txtTotal
            // 
            this.txtTotal.BeforeTouchSize = new System.Drawing.Size(133, 24);
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(109, 160);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ShowCalculator = false;
            this.txtTotal.Size = new System.Drawing.Size(133, 24);
            this.txtTotal.TabIndex = 11;
            // 
            // 
            // 
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
            // cmdBuscarArticulo
            // 
            this.cmdBuscarArticulo.Location = new System.Drawing.Point(334, 15);
            this.cmdBuscarArticulo.Name = "cmdBuscarArticulo";
            this.cmdBuscarArticulo.Size = new System.Drawing.Size(30, 23);
            this.cmdBuscarArticulo.TabIndex = 3;
            this.cmdBuscarArticulo.Text = "...";
            this.cmdBuscarArticulo.UseVisualStyleBackColor = true;
            // 
            // cboImpuestos
            // 
            this.cboImpuestos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboImpuestos.AutoCompleteSuggestMode = Syncfusion.WinForms.ListView.Enums.AutoCompleteSuggestMode.Contains;
            this.cboImpuestos.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.cboImpuestos.Location = new System.Drawing.Point(109, 197);
            this.cboImpuestos.Name = "cboImpuestos";
            this.cboImpuestos.Size = new System.Drawing.Size(234, 28);
            this.cboImpuestos.Style.DropDownStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cboImpuestos.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboImpuestos.TabIndex = 29;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(43, 204);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 16);
            this.label12.TabIndex = 28;
            this.label12.Text = "Impuesto";
            // 
            // txtDescripcionUnidad
            // 
            this.txtDescripcionUnidad.Location = new System.Drawing.Point(454, 153);
            this.txtDescripcionUnidad.Name = "txtDescripcionUnidad";
            this.txtDescripcionUnidad.ReadOnly = true;
            this.txtDescripcionUnidad.Size = new System.Drawing.Size(307, 23);
            this.txtDescripcionUnidad.TabIndex = 37;
            // 
            // cmdBuscarCveUni
            // 
            this.cmdBuscarCveUni.Location = new System.Drawing.Point(418, 153);
            this.cmdBuscarCveUni.Name = "cmdBuscarCveUni";
            this.cmdBuscarCveUni.Size = new System.Drawing.Size(32, 23);
            this.cmdBuscarCveUni.TabIndex = 17;
            this.cmdBuscarCveUni.Text = "...";
            this.cmdBuscarCveUni.UseVisualStyleBackColor = true;
            this.cmdBuscarCveUni.Click += new System.EventHandler(this.cmdBuscarCveUni_Click);
            // 
            // cmdBuscarCveProSer
            // 
            this.cmdBuscarCveProSer.Location = new System.Drawing.Point(418, 110);
            this.cmdBuscarCveProSer.Name = "cmdBuscarCveProSer";
            this.cmdBuscarCveProSer.Size = new System.Drawing.Size(32, 23);
            this.cmdBuscarCveProSer.TabIndex = 16;
            this.cmdBuscarCveProSer.Text = "...";
            this.cmdBuscarCveProSer.UseVisualStyleBackColor = true;
            this.cmdBuscarCveProSer.Click += new System.EventHandler(this.cmdBuscarCveProSer_Click);
            // 
            // txtDescripcionProSer
            // 
            this.txtDescripcionProSer.Location = new System.Drawing.Point(454, 110);
            this.txtDescripcionProSer.Name = "txtDescripcionProSer";
            this.txtDescripcionProSer.ReadOnly = true;
            this.txtDescripcionProSer.Size = new System.Drawing.Size(307, 23);
            this.txtDescripcionProSer.TabIndex = 34;
            // 
            // txtCveUni
            // 
            this.txtCveUni.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCveUni.Location = new System.Drawing.Point(268, 156);
            this.txtCveUni.Name = "txtCveUni";
            this.txtCveUni.Size = new System.Drawing.Size(144, 23);
            this.txtCveUni.TabIndex = 15;
            this.txtCveUni.Validated += new System.EventHandler(this.txtCveUni_Validated);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(268, 135);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(144, 16);
            this.label11.TabIndex = 14;
            this.label11.Text = "Clave unidad de medida";
            // 
            // txtCveProSer
            // 
            this.txtCveProSer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCveProSer.Location = new System.Drawing.Point(268, 110);
            this.txtCveProSer.Name = "txtCveProSer";
            this.txtCveProSer.Size = new System.Drawing.Size(144, 23);
            this.txtCveProSer.TabIndex = 13;
            this.txtCveProSer.Validated += new System.EventHandler(this.txtCveProSer_Validated);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(268, 88);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 16);
            this.label10.TabIndex = 12;
            this.label10.Text = "Clave prod. o serv.";
            // 
            // ConceptoModificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 322);
            this.Controls.Add(this.txtDescripcionUnidad);
            this.Controls.Add(this.cmdBuscarCveUni);
            this.Controls.Add(this.cmdBuscarCveProSer);
            this.Controls.Add(this.txtDescripcionProSer);
            this.Controls.Add(this.txtCveUni);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtCveProSer);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cboImpuestos);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmdBuscarArticulo);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.spnCantidad);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.cmdGuardar);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConceptoModificar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar concepto";
            this.Load += new System.EventHandler(this.ConceptoModificar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spnCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecio.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboImpuestos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmdGuardar;
        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.NumericUpDown spnCantidad;
        private Syncfusion.Windows.Forms.Tools.CurrencyEdit txtPrecio;
        private Syncfusion.Windows.Forms.Tools.CurrencyEdit txtTotal;
        private System.Windows.Forms.Button cmdBuscarArticulo;
        private Syncfusion.WinForms.ListView.SfComboBox cboImpuestos;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDescripcionUnidad;
        private System.Windows.Forms.Button cmdBuscarCveUni;
        private System.Windows.Forms.Button cmdBuscarCveProSer;
        private System.Windows.Forms.TextBox txtDescripcionProSer;
        private System.Windows.Forms.TextBox txtCveUni;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCveProSer;
        private System.Windows.Forms.Label label10;
    }
}