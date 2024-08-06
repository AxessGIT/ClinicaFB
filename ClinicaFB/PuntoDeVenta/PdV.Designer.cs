namespace ClinicaFB.PuntoDeVenta
{
    partial class PdV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdV));
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRFC = new System.Windows.Forms.TextBox();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.cmdClienteBuscar = new System.Windows.Forms.Button();
            this.cmdClienteAgregar = new System.Windows.Forms.Button();
            this.cmdClienteModificar = new System.Windows.Forms.Button();
            this.grdDetalle = new System.Windows.Forms.DataGridView();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.cmdFactura = new System.Windows.Forms.Button();
            this.cmdTicket = new System.Windows.Forms.Button();
            this.cboAlmacenes = new Syncfusion.WinForms.ListView.SfComboBox();
            this.lblAlmacen = new System.Windows.Forms.Label();
            this.spnCantidad = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cmdConceptoBorrar = new System.Windows.Forms.Button();
            this.cmdConceptoModificar = new System.Windows.Forms.Button();
            this.cboDoctores = new Syncfusion.WinForms.ListView.SfComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAlmacenes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDoctores)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(430, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Fecha";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(481, 6);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(100, 23);
            this.dateTimePicker1.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 77);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 16);
            this.label4.TabIndex = 18;
            this.label4.Text = "Cliente";
            // 
            // txtRFC
            // 
            this.txtRFC.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRFC.Location = new System.Drawing.Point(69, 74);
            this.txtRFC.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtRFC.Name = "txtRFC";
            this.txtRFC.ReadOnly = true;
            this.txtRFC.Size = new System.Drawing.Size(138, 23);
            this.txtRFC.TabIndex = 19;
            this.txtRFC.Text = "XAXX010101000";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(210, 74);
            this.txtRazonSocial.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.ReadOnly = true;
            this.txtRazonSocial.Size = new System.Drawing.Size(371, 23);
            this.txtRazonSocial.TabIndex = 20;
            this.txtRazonSocial.Text = "PUBLICO EN GENERAL";
            // 
            // cmdClienteBuscar
            // 
            this.cmdClienteBuscar.Location = new System.Drawing.Point(585, 72);
            this.cmdClienteBuscar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmdClienteBuscar.Name = "cmdClienteBuscar";
            this.cmdClienteBuscar.Size = new System.Drawing.Size(40, 27);
            this.cmdClienteBuscar.TabIndex = 4;
            this.cmdClienteBuscar.Text = "...";
            this.cmdClienteBuscar.UseVisualStyleBackColor = true;
            this.cmdClienteBuscar.Click += new System.EventHandler(this.cmdClienteBuscar_Click);
            // 
            // cmdClienteAgregar
            // 
            this.cmdClienteAgregar.Image = ((System.Drawing.Image)(resources.GetObject("cmdClienteAgregar.Image")));
            this.cmdClienteAgregar.Location = new System.Drawing.Point(629, 72);
            this.cmdClienteAgregar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmdClienteAgregar.Name = "cmdClienteAgregar";
            this.cmdClienteAgregar.Size = new System.Drawing.Size(40, 27);
            this.cmdClienteAgregar.TabIndex = 25;
            this.cmdClienteAgregar.UseVisualStyleBackColor = true;
            // 
            // cmdClienteModificar
            // 
            this.cmdClienteModificar.Image = ((System.Drawing.Image)(resources.GetObject("cmdClienteModificar.Image")));
            this.cmdClienteModificar.Location = new System.Drawing.Point(673, 72);
            this.cmdClienteModificar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmdClienteModificar.Name = "cmdClienteModificar";
            this.cmdClienteModificar.Size = new System.Drawing.Size(40, 27);
            this.cmdClienteModificar.TabIndex = 26;
            this.cmdClienteModificar.UseVisualStyleBackColor = true;
            // 
            // grdDetalle
            // 
            this.grdDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDetalle.Location = new System.Drawing.Point(4, 147);
            this.grdDetalle.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.grdDetalle.Name = "grdDetalle";
            this.grdDetalle.Size = new System.Drawing.Size(848, 233);
            this.grdDetalle.TabIndex = 12;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(730, 392);
            this.textBox4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(122, 23);
            this.textBox4.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(657, 395);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Subtotal";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(688, 424);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "IVA";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(730, 421);
            this.textBox5.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(122, 23);
            this.textBox5.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(680, 453);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Total";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(730, 450);
            this.textBox6.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(122, 23);
            this.textBox6.TabIndex = 15;
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdSalir.Location = new System.Drawing.Point(239, 386);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(112, 58);
            this.cmdSalir.TabIndex = 9;
            this.cmdSalir.Text = "Salir";
            this.cmdSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // cmdFactura
            // 
            this.cmdFactura.Image = ((System.Drawing.Image)(resources.GetObject("cmdFactura.Image")));
            this.cmdFactura.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdFactura.Location = new System.Drawing.Point(121, 386);
            this.cmdFactura.Name = "cmdFactura";
            this.cmdFactura.Size = new System.Drawing.Size(112, 58);
            this.cmdFactura.TabIndex = 8;
            this.cmdFactura.Text = "Factura";
            this.cmdFactura.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdFactura.UseVisualStyleBackColor = true;
            // 
            // cmdTicket
            // 
            this.cmdTicket.Image = ((System.Drawing.Image)(resources.GetObject("cmdTicket.Image")));
            this.cmdTicket.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdTicket.Location = new System.Drawing.Point(3, 386);
            this.cmdTicket.Name = "cmdTicket";
            this.cmdTicket.Size = new System.Drawing.Size(112, 58);
            this.cmdTicket.TabIndex = 7;
            this.cmdTicket.Text = "Ticket";
            this.cmdTicket.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdTicket.UseVisualStyleBackColor = true;
            // 
            // cboAlmacenes
            // 
            this.cboAlmacenes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboAlmacenes.AutoCompleteSuggestMode = Syncfusion.WinForms.ListView.Enums.AutoCompleteSuggestMode.Contains;
            this.cboAlmacenes.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.cboAlmacenes.DropDownStyle = Syncfusion.WinForms.ListView.Enums.DropDownStyle.DropDownList;
            this.cboAlmacenes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboAlmacenes.Location = new System.Drawing.Point(69, 3);
            this.cboAlmacenes.Name = "cboAlmacenes";
            this.cboAlmacenes.Size = new System.Drawing.Size(282, 28);
            this.cboAlmacenes.Style.DropDownStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cboAlmacenes.Style.EditorStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboAlmacenes.Style.ReadOnlyEditorStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboAlmacenes.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboAlmacenes.Style.TokenStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboAlmacenes.TabIndex = 1;
            // 
            // lblAlmacen
            // 
            this.lblAlmacen.AutoSize = true;
            this.lblAlmacen.Location = new System.Drawing.Point(8, 9);
            this.lblAlmacen.Name = "lblAlmacen";
            this.lblAlmacen.Size = new System.Drawing.Size(56, 16);
            this.lblAlmacen.TabIndex = 0;
            this.lblAlmacen.Text = "Almacen";
            // 
            // spnCantidad
            // 
            this.spnCantidad.DecimalPlaces = 4;
            this.spnCantidad.Location = new System.Drawing.Point(687, 113);
            this.spnCantidad.Name = "spnCantidad";
            this.spnCantidad.Size = new System.Drawing.Size(80, 23);
            this.spnCantidad.TabIndex = 22;
            this.spnCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.spnCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(668, 116);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(14, 16);
            this.label20.TabIndex = 21;
            this.label20.Text = "x";
            // 
            // txtConcepto
            // 
            this.txtConcepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConcepto.Location = new System.Drawing.Point(443, 113);
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(219, 23);
            this.txtConcepto.TabIndex = 6;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(377, 116);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(50, 16);
            this.label19.TabIndex = 5;
            this.label19.Text = "Artículo";
            // 
            // cmdConceptoBorrar
            // 
            this.cmdConceptoBorrar.Image = ((System.Drawing.Image)(resources.GetObject("cmdConceptoBorrar.Image")));
            this.cmdConceptoBorrar.Location = new System.Drawing.Point(817, 109);
            this.cmdConceptoBorrar.Name = "cmdConceptoBorrar";
            this.cmdConceptoBorrar.Size = new System.Drawing.Size(35, 31);
            this.cmdConceptoBorrar.TabIndex = 24;
            this.cmdConceptoBorrar.UseVisualStyleBackColor = true;
            // 
            // cmdConceptoModificar
            // 
            this.cmdConceptoModificar.Image = ((System.Drawing.Image)(resources.GetObject("cmdConceptoModificar.Image")));
            this.cmdConceptoModificar.Location = new System.Drawing.Point(776, 109);
            this.cmdConceptoModificar.Name = "cmdConceptoModificar";
            this.cmdConceptoModificar.Size = new System.Drawing.Size(35, 31);
            this.cmdConceptoModificar.TabIndex = 23;
            this.cmdConceptoModificar.UseVisualStyleBackColor = true;
            // 
            // cboDoctores
            // 
            this.cboDoctores.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboDoctores.AutoCompleteSuggestMode = Syncfusion.WinForms.ListView.Enums.AutoCompleteSuggestMode.Contains;
            this.cboDoctores.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.cboDoctores.DropDownStyle = Syncfusion.WinForms.ListView.Enums.DropDownStyle.DropDownList;
            this.cboDoctores.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboDoctores.Location = new System.Drawing.Point(69, 37);
            this.cboDoctores.Name = "cboDoctores";
            this.cboDoctores.Size = new System.Drawing.Size(282, 28);
            this.cboDoctores.Style.DropDownStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cboDoctores.Style.EditorStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboDoctores.Style.ReadOnlyEditorStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboDoctores.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboDoctores.Style.TokenStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboDoctores.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Doctor";
            // 
            // PdV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 494);
            this.Controls.Add(this.cboDoctores);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.spnCantidad);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.txtConcepto);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.cmdConceptoBorrar);
            this.Controls.Add(this.cmdConceptoModificar);
            this.Controls.Add(this.cboAlmacenes);
            this.Controls.Add(this.lblAlmacen);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.cmdFactura);
            this.Controls.Add(this.cmdTicket);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.grdDetalle);
            this.Controls.Add(this.cmdClienteModificar);
            this.Controls.Add(this.cmdClienteAgregar);
            this.Controls.Add(this.cmdClienteBuscar);
            this.Controls.Add(this.txtRazonSocial);
            this.Controls.Add(this.txtRFC);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PdV";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ventas";
            this.Load += new System.EventHandler(this.PdV_Load);
            this.Shown += new System.EventHandler(this.PdV_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.grdDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAlmacenes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDoctores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRFC;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Button cmdClienteBuscar;
        private System.Windows.Forms.Button cmdClienteAgregar;
        private System.Windows.Forms.Button cmdClienteModificar;
        private System.Windows.Forms.DataGridView grdDetalle;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.Button cmdFactura;
        private System.Windows.Forms.Button cmdTicket;
        private Syncfusion.WinForms.ListView.SfComboBox cboAlmacenes;
        private System.Windows.Forms.Label lblAlmacen;
        private System.Windows.Forms.NumericUpDown spnCantidad;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button cmdConceptoBorrar;
        private System.Windows.Forms.Button cmdConceptoModificar;
        private Syncfusion.WinForms.ListView.SfComboBox cboDoctores;
        private System.Windows.Forms.Label label1;
    }
}