namespace ClinicaFB.Configuracion.Facturacion
{
    partial class SeriesConceptosAltasCambios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeriesConceptosAltasCambios));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmdGuardar = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtUDM = new System.Windows.Forms.TextBox();
            this.txtCveProSer = new System.Windows.Forms.TextBox();
            this.txtCveUni = new System.Windows.Forms.TextBox();
            this.cmdBuscarArticulo = new System.Windows.Forms.Button();
            this.txtPrecio = new Syncfusion.Windows.Forms.Tools.CurrencyTextBox();
            this.txtPorceRetISR = new Syncfusion.Windows.Forms.Tools.PercentTextBox();
            this.txtPorceRetIVA = new Syncfusion.Windows.Forms.Tools.PercentTextBox();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.chkAgregarNombrePaciente = new System.Windows.Forms.CheckBox();
            this.txtImpuesto = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPorceRetISR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPorceRetIVA)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Clave del artículo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descripción";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Precio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tipo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Clave SAT Prod. Serv.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Clave SAT Unidad";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 270);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "Porcentaje retención ISR";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 299);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(149, 16);
            this.label8.TabIndex = 17;
            this.label8.Text = "Porcentaje retención IVA";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 154);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 16);
            this.label9.TabIndex = 9;
            this.label9.Text = "Unidad de medida";
            // 
            // cmdGuardar
            // 
            this.cmdGuardar.Image = ((System.Drawing.Image)(resources.GetObject("cmdGuardar.Image")));
            this.cmdGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGuardar.Location = new System.Drawing.Point(179, 379);
            this.cmdGuardar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdGuardar.Name = "cmdGuardar";
            this.cmdGuardar.Size = new System.Drawing.Size(129, 43);
            this.cmdGuardar.TabIndex = 20;
            this.cmdGuardar.Text = "&Guardar";
            this.cmdGuardar.UseVisualStyleBackColor = true;
            this.cmdGuardar.Click += new System.EventHandler(this.cmdGuardar_Click);
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSalir.Location = new System.Drawing.Point(315, 379);
            this.cmdSalir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(129, 43);
            this.cmdSalir.TabIndex = 21;
            this.cmdSalir.Text = "&Salir";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(194, 35);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(183, 23);
            this.txtClave.TabIndex = 1;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(194, 64);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ReadOnly = true;
            this.txtDescripcion.Size = new System.Drawing.Size(411, 23);
            this.txtDescripcion.TabIndex = 4;
            // 
            // txtUDM
            // 
            this.txtUDM.Location = new System.Drawing.Point(194, 151);
            this.txtUDM.Name = "txtUDM";
            this.txtUDM.ReadOnly = true;
            this.txtUDM.Size = new System.Drawing.Size(130, 23);
            this.txtUDM.TabIndex = 10;
            // 
            // txtCveProSer
            // 
            this.txtCveProSer.Location = new System.Drawing.Point(194, 180);
            this.txtCveProSer.Name = "txtCveProSer";
            this.txtCveProSer.ReadOnly = true;
            this.txtCveProSer.Size = new System.Drawing.Size(247, 23);
            this.txtCveProSer.TabIndex = 12;
            // 
            // txtCveUni
            // 
            this.txtCveUni.Location = new System.Drawing.Point(194, 209);
            this.txtCveUni.Name = "txtCveUni";
            this.txtCveUni.ReadOnly = true;
            this.txtCveUni.Size = new System.Drawing.Size(130, 23);
            this.txtCveUni.TabIndex = 14;
            // 
            // cmdBuscarArticulo
            // 
            this.cmdBuscarArticulo.Location = new System.Drawing.Point(383, 35);
            this.cmdBuscarArticulo.Name = "cmdBuscarArticulo";
            this.cmdBuscarArticulo.Size = new System.Drawing.Size(32, 23);
            this.cmdBuscarArticulo.TabIndex = 2;
            this.cmdBuscarArticulo.Text = "...";
            this.cmdBuscarArticulo.UseVisualStyleBackColor = true;
            this.cmdBuscarArticulo.Click += new System.EventHandler(this.cmdBuscarArticulo_Click);
            // 
            // txtPrecio
            // 
            this.txtPrecio.BeforeTouchSize = new System.Drawing.Size(100, 23);
            this.txtPrecio.DecimalValue = new decimal(new int[] {
            100,
            0,
            0,
            131072});
            this.txtPrecio.Location = new System.Drawing.Point(194, 93);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.ReadOnly = true;
            this.txtPrecio.Size = new System.Drawing.Size(100, 23);
            this.txtPrecio.TabIndex = 6;
            this.txtPrecio.Text = "$1.00";
            // 
            // txtPorceRetISR
            // 
            this.txtPorceRetISR.BeforeTouchSize = new System.Drawing.Size(100, 23);
            this.txtPorceRetISR.Location = new System.Drawing.Point(194, 267);
            this.txtPorceRetISR.Name = "txtPorceRetISR";
            this.txtPorceRetISR.PercentDecimalDigits = 6;
            this.txtPorceRetISR.Size = new System.Drawing.Size(100, 23);
            this.txtPorceRetISR.TabIndex = 16;
            this.txtPorceRetISR.Text = "0.000000 %";
            // 
            // txtPorceRetIVA
            // 
            this.txtPorceRetIVA.BeforeTouchSize = new System.Drawing.Size(100, 23);
            this.txtPorceRetIVA.Location = new System.Drawing.Point(194, 296);
            this.txtPorceRetIVA.Name = "txtPorceRetIVA";
            this.txtPorceRetIVA.PercentDecimalDigits = 6;
            this.txtPorceRetIVA.Size = new System.Drawing.Size(100, 23);
            this.txtPorceRetIVA.TabIndex = 18;
            this.txtPorceRetIVA.Text = "0.000000 %";
            // 
            // txtTipo
            // 
            this.txtTipo.Location = new System.Drawing.Point(194, 122);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.ReadOnly = true;
            this.txtTipo.Size = new System.Drawing.Size(216, 23);
            this.txtTipo.TabIndex = 8;
            // 
            // chkAgregarNombrePaciente
            // 
            this.chkAgregarNombrePaciente.AutoSize = true;
            this.chkAgregarNombrePaciente.Location = new System.Drawing.Point(15, 338);
            this.chkAgregarNombrePaciente.Name = "chkAgregarNombrePaciente";
            this.chkAgregarNombrePaciente.Size = new System.Drawing.Size(193, 20);
            this.chkAgregarNombrePaciente.TabIndex = 19;
            this.chkAgregarNombrePaciente.Text = "Agregar nombre del paciente";
            this.chkAgregarNombrePaciente.UseVisualStyleBackColor = true;
            // 
            // txtImpuesto
            // 
            this.txtImpuesto.Location = new System.Drawing.Point(194, 238);
            this.txtImpuesto.Name = "txtImpuesto";
            this.txtImpuesto.ReadOnly = true;
            this.txtImpuesto.Size = new System.Drawing.Size(247, 23);
            this.txtImpuesto.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 241);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 16);
            this.label10.TabIndex = 22;
            this.label10.Text = "Impuesto";
            // 
            // SeriesConceptosAltasCambios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 448);
            this.Controls.Add(this.txtImpuesto);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.chkAgregarNombrePaciente);
            this.Controls.Add(this.txtTipo);
            this.Controls.Add(this.txtPorceRetIVA);
            this.Controls.Add(this.txtPorceRetISR);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.cmdBuscarArticulo);
            this.Controls.Add(this.txtCveUni);
            this.Controls.Add(this.txtCveProSer);
            this.Controls.Add(this.txtUDM);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.cmdGuardar);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "SeriesConceptosAltasCambios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SeriesConceptosAltasCambios";
            this.Load += new System.EventHandler(this.SeriesConceptosAltasCambios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPorceRetISR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPorceRetIVA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button cmdGuardar;
        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtUDM;
        private System.Windows.Forms.TextBox txtCveProSer;
        private System.Windows.Forms.TextBox txtCveUni;
        private System.Windows.Forms.Button cmdBuscarArticulo;
        private Syncfusion.Windows.Forms.Tools.CurrencyTextBox txtPrecio;
        private Syncfusion.Windows.Forms.Tools.PercentTextBox txtPorceRetISR;
        private Syncfusion.Windows.Forms.Tools.PercentTextBox txtPorceRetIVA;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.CheckBox chkAgregarNombrePaciente;
        private System.Windows.Forms.TextBox txtImpuesto;
        private System.Windows.Forms.Label label10;
    }
}