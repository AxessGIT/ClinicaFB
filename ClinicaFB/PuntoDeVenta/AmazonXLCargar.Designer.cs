namespace ClinicaFB.PuntoDeVenta
{
    partial class AmazonXLCargar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AmazonXLCargar));
            this.label1 = new System.Windows.Forms.Label();
            this.spnRenglonInicial = new System.Windows.Forms.NumericUpDown();
            this.spnRenglonFinal = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdCargar = new System.Windows.Forms.Button();
            this.grdArticulos = new System.Windows.Forms.DataGridView();
            this.colSKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigoBarras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.cmdAceptar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtArchivoXLS = new System.Windows.Forms.TextBox();
            this.pbAvance = new Syncfusion.Windows.Forms.Tools.ProgressBarAdv();
            ((System.ComponentModel.ISupportInitialize)(this.spnRenglonInicial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnRenglonFinal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvance)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Renglón inicial";
            // 
            // spnRenglonInicial
            // 
            this.spnRenglonInicial.Location = new System.Drawing.Point(107, 19);
            this.spnRenglonInicial.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.spnRenglonInicial.Name = "spnRenglonInicial";
            this.spnRenglonInicial.Size = new System.Drawing.Size(68, 23);
            this.spnRenglonInicial.TabIndex = 1;
            this.spnRenglonInicial.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // spnRenglonFinal
            // 
            this.spnRenglonFinal.Location = new System.Drawing.Point(107, 48);
            this.spnRenglonFinal.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.spnRenglonFinal.Name = "spnRenglonFinal";
            this.spnRenglonFinal.Size = new System.Drawing.Size(68, 23);
            this.spnRenglonFinal.TabIndex = 3;
            this.spnRenglonFinal.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Renglón final";
            // 
            // cmdCargar
            // 
            this.cmdCargar.Location = new System.Drawing.Point(181, 30);
            this.cmdCargar.Name = "cmdCargar";
            this.cmdCargar.Size = new System.Drawing.Size(75, 36);
            this.cmdCargar.TabIndex = 4;
            this.cmdCargar.Text = "&Cargar...";
            this.cmdCargar.UseVisualStyleBackColor = true;
            this.cmdCargar.Click += new System.EventHandler(this.cmdCargar_Click);
            // 
            // grdArticulos
            // 
            this.grdArticulos.AllowUserToAddRows = false;
            this.grdArticulos.AllowUserToDeleteRows = false;
            this.grdArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdArticulos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSKU,
            this.colCodigoBarras,
            this.colDescripcion});
            this.grdArticulos.Location = new System.Drawing.Point(16, 102);
            this.grdArticulos.Name = "grdArticulos";
            this.grdArticulos.Size = new System.Drawing.Size(851, 496);
            this.grdArticulos.TabIndex = 5;
            this.grdArticulos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdArticulos_CellEndEdit);
            this.grdArticulos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdArticulos_CellFormatting);
            this.grdArticulos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdArticulos_KeyDown);
            // 
            // colSKU
            // 
            this.colSKU.DataPropertyName = "SKU";
            this.colSKU.HeaderText = "SKU Amazon";
            this.colSKU.Name = "colSKU";
            this.colSKU.ReadOnly = true;
            this.colSKU.Width = 150;
            // 
            // colCodigoBarras
            // 
            this.colCodigoBarras.DataPropertyName = "CodigoBarras";
            this.colCodigoBarras.HeaderText = "Codigo de Barras";
            this.colCodigoBarras.Name = "colCodigoBarras";
            this.colCodigoBarras.Width = 150;
            // 
            // colDescripcion
            // 
            this.colDescripcion.DataPropertyName = "Descripcion";
            this.colDescripcion.HeaderText = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;
            this.colDescripcion.Width = 500;
            // 
            // cmdSalir
            // 
            this.cmdSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.Location = new System.Drawing.Point(454, 604);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(70, 58);
            this.cmdSalir.TabIndex = 26;
            this.cmdSalir.Text = "Salir";
            this.cmdSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdAceptar.Image = ((System.Drawing.Image)(resources.GetObject("cmdAceptar.Image")));
            this.cmdAceptar.Location = new System.Drawing.Point(377, 604);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(71, 58);
            this.cmdAceptar.TabIndex = 27;
            this.cmdAceptar.Text = "Aceptar";
            this.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdAceptar.UseVisualStyleBackColor = true;
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(649, 16);
            this.label3.TabIndex = 28;
            this.label3.Text = "Artículos no registrados en el catálogo (es necesario asignar la clave para agreg" +
    "arlos a la factura)";
            // 
            // txtArchivoXLS
            // 
            this.txtArchivoXLS.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArchivoXLS.Location = new System.Drawing.Point(262, 21);
            this.txtArchivoXLS.Multiline = true;
            this.txtArchivoXLS.Name = "txtArchivoXLS";
            this.txtArchivoXLS.ReadOnly = true;
            this.txtArchivoXLS.Size = new System.Drawing.Size(346, 50);
            this.txtArchivoXLS.TabIndex = 29;
            // 
            // pbAvance
            // 
            this.pbAvance.BackMultipleColors = new System.Drawing.Color[] {
        System.Drawing.Color.Empty};
            this.pbAvance.BackSegments = false;
            this.pbAvance.CustomText = null;
            this.pbAvance.CustomWaitingRender = false;
            this.pbAvance.ForegroundImage = null;
            this.pbAvance.Location = new System.Drawing.Point(623, 30);
            this.pbAvance.MultipleColors = new System.Drawing.Color[] {
        System.Drawing.Color.Empty};
            this.pbAvance.Name = "pbAvance";
            this.pbAvance.SegmentWidth = 12;
            this.pbAvance.Size = new System.Drawing.Size(244, 23);
            this.pbAvance.TabIndex = 30;
            this.pbAvance.Text = "progressBarAdv1";
            this.pbAvance.Visible = false;
            this.pbAvance.WaitingGradientWidth = 400;
            // 
            // AmazonXLCargar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 674);
            this.Controls.Add(this.pbAvance);
            this.Controls.Add(this.txtArchivoXLS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdAceptar);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.grdArticulos);
            this.Controls.Add(this.cmdCargar);
            this.Controls.Add(this.spnRenglonFinal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.spnRenglonInicial);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "AmazonXLCargar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cargar XL Amazon";
            this.Load += new System.EventHandler(this.AmazonXLCargar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spnRenglonInicial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnRenglonFinal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdCargar;
        private System.Windows.Forms.DataGridView grdArticulos;
        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.Button cmdAceptar;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtArchivoXLS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoBarras;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private Syncfusion.Windows.Forms.Tools.ProgressBarAdv pbAvance;
        public System.Windows.Forms.NumericUpDown spnRenglonInicial;
        public System.Windows.Forms.NumericUpDown spnRenglonFinal;
    }
}