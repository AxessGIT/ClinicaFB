namespace ClinicaFB.PuntoDeVenta
{
    partial class ArticuloExistencias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArticuloExistencias));
            this.txtCodigoBarras = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.grdExistencias = new System.Windows.Forms.DataGridView();
            this.colAlmacen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExistencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdExistencias)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCodigoBarras
            // 
            this.txtCodigoBarras.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoBarras.Location = new System.Drawing.Point(116, 35);
            this.txtCodigoBarras.Name = "txtCodigoBarras";
            this.txtCodigoBarras.ReadOnly = true;
            this.txtCodigoBarras.Size = new System.Drawing.Size(328, 23);
            this.txtCodigoBarras.TabIndex = 9;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(2, 38);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(105, 16);
            this.label16.TabIndex = 8;
            this.label16.Text = "Código de barras";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Location = new System.Drawing.Point(116, 64);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ReadOnly = true;
            this.txtDescripcion.Size = new System.Drawing.Size(328, 56);
            this.txtDescripcion.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Descripción";
            // 
            // txtClave
            // 
            this.txtClave.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClave.Location = new System.Drawing.Point(116, 6);
            this.txtClave.Name = "txtClave";
            this.txtClave.ReadOnly = true;
            this.txtClave.Size = new System.Drawing.Size(222, 23);
            this.txtClave.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Clave";
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSalir.Location = new System.Drawing.Point(178, 346);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(122, 48);
            this.cmdSalir.TabIndex = 13;
            this.cmdSalir.Text = "&Salir";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // grdExistencias
            // 
            this.grdExistencias.AllowUserToAddRows = false;
            this.grdExistencias.AllowUserToDeleteRows = false;
            this.grdExistencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdExistencias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAlmacen,
            this.colExistencia});
            this.grdExistencias.Location = new System.Drawing.Point(5, 131);
            this.grdExistencias.Name = "grdExistencias";
            this.grdExistencias.ReadOnly = true;
            this.grdExistencias.Size = new System.Drawing.Size(439, 209);
            this.grdExistencias.TabIndex = 14;
            // 
            // colAlmacen
            // 
            this.colAlmacen.DataPropertyName = "AlmacenNombre";
            this.colAlmacen.HeaderText = "Almacen";
            this.colAlmacen.Name = "colAlmacen";
            this.colAlmacen.ReadOnly = true;
            this.colAlmacen.Width = 250;
            // 
            // colExistencia
            // 
            this.colExistencia.DataPropertyName = "Existencia";
            this.colExistencia.HeaderText = "Existencia";
            this.colExistencia.Name = "colExistencia";
            this.colExistencia.ReadOnly = true;
            this.colExistencia.Width = 130;
            // 
            // ArticuloExistencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 402);
            this.Controls.Add(this.grdExistencias);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.txtCodigoBarras);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "ArticuloExistencias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Existencias";
            this.Load += new System.EventHandler(this.Kardex_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdExistencias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCodigoBarras;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.DataGridView grdExistencias;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAlmacen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExistencia;
    }
}