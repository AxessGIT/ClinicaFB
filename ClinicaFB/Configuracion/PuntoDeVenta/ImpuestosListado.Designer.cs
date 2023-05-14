namespace ClinicaFB.Configuracion.PuntoDeVenta
{
    partial class ImpuestosListado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImpuestosListado));
            this.grdImpuestos = new System.Windows.Forms.DataGridView();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPorcentaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDefault = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.cmdModificar = new System.Windows.Forms.Button();
            this.cmdAgregar = new System.Windows.Forms.Button();
            this.cmdBorrar = new System.Windows.Forms.Button();
            this.cmdImprimir = new System.Windows.Forms.Button();
            this.cmdDefault = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdImpuestos)).BeginInit();
            this.SuspendLayout();
            // 
            // grdImpuestos
            // 
            this.grdImpuestos.AllowUserToAddRows = false;
            this.grdImpuestos.AllowUserToDeleteRows = false;
            this.grdImpuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdImpuestos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDescripcion,
            this.colPorcentaje,
            this.colDefault});
            this.grdImpuestos.Location = new System.Drawing.Point(12, 12);
            this.grdImpuestos.Name = "grdImpuestos";
            this.grdImpuestos.ReadOnly = true;
            this.grdImpuestos.Size = new System.Drawing.Size(497, 439);
            this.grdImpuestos.TabIndex = 8;
            this.grdImpuestos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdImpuestos_CellDoubleClick);
            // 
            // colDescripcion
            // 
            this.colDescripcion.HeaderText = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;
            this.colDescripcion.Width = 200;
            // 
            // colPorcentaje
            // 
            this.colPorcentaje.HeaderText = "Porcentaje";
            this.colPorcentaje.Name = "colPorcentaje";
            this.colPorcentaje.ReadOnly = true;
            // 
            // colDefault
            // 
            this.colDefault.HeaderText = "Default";
            this.colDefault.Name = "colDefault";
            this.colDefault.ReadOnly = true;
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSalir.Location = new System.Drawing.Point(515, 217);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(100, 35);
            this.cmdSalir.TabIndex = 11;
            this.cmdSalir.Text = "&Salir";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // cmdModificar
            // 
            this.cmdModificar.Image = ((System.Drawing.Image)(resources.GetObject("cmdModificar.Image")));
            this.cmdModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdModificar.Location = new System.Drawing.Point(515, 53);
            this.cmdModificar.Name = "cmdModificar";
            this.cmdModificar.Size = new System.Drawing.Size(100, 35);
            this.cmdModificar.TabIndex = 10;
            this.cmdModificar.Text = "&Modificar";
            this.cmdModificar.UseVisualStyleBackColor = true;
            this.cmdModificar.Click += new System.EventHandler(this.cmdModificar_Click);
            // 
            // cmdAgregar
            // 
            this.cmdAgregar.Image = ((System.Drawing.Image)(resources.GetObject("cmdAgregar.Image")));
            this.cmdAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAgregar.Location = new System.Drawing.Point(515, 12);
            this.cmdAgregar.Name = "cmdAgregar";
            this.cmdAgregar.Size = new System.Drawing.Size(100, 35);
            this.cmdAgregar.TabIndex = 9;
            this.cmdAgregar.Text = "&Agregar";
            this.cmdAgregar.UseVisualStyleBackColor = true;
            this.cmdAgregar.Click += new System.EventHandler(this.cmdAgregar_Click);
            // 
            // cmdBorrar
            // 
            this.cmdBorrar.Image = ((System.Drawing.Image)(resources.GetObject("cmdBorrar.Image")));
            this.cmdBorrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdBorrar.Location = new System.Drawing.Point(515, 94);
            this.cmdBorrar.Name = "cmdBorrar";
            this.cmdBorrar.Size = new System.Drawing.Size(100, 35);
            this.cmdBorrar.TabIndex = 12;
            this.cmdBorrar.Text = "&Borrar";
            this.cmdBorrar.UseVisualStyleBackColor = true;
            // 
            // cmdImprimir
            // 
            this.cmdImprimir.Image = ((System.Drawing.Image)(resources.GetObject("cmdImprimir.Image")));
            this.cmdImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdImprimir.Location = new System.Drawing.Point(515, 135);
            this.cmdImprimir.Name = "cmdImprimir";
            this.cmdImprimir.Size = new System.Drawing.Size(100, 35);
            this.cmdImprimir.TabIndex = 13;
            this.cmdImprimir.Text = "&Imprimir";
            this.cmdImprimir.UseVisualStyleBackColor = true;
            this.cmdImprimir.Click += new System.EventHandler(this.cmdImprimir_Click);
            // 
            // cmdDefault
            // 
            this.cmdDefault.Image = ((System.Drawing.Image)(resources.GetObject("cmdDefault.Image")));
            this.cmdDefault.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDefault.Location = new System.Drawing.Point(515, 176);
            this.cmdDefault.Name = "cmdDefault";
            this.cmdDefault.Size = new System.Drawing.Size(100, 35);
            this.cmdDefault.TabIndex = 14;
            this.cmdDefault.Text = "&Default";
            this.cmdDefault.UseVisualStyleBackColor = true;
            this.cmdDefault.Click += new System.EventHandler(this.cmdDefault_Click);
            // 
            // ImpuestosListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 485);
            this.Controls.Add(this.cmdDefault);
            this.Controls.Add(this.cmdImprimir);
            this.Controls.Add(this.cmdBorrar);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.cmdModificar);
            this.Controls.Add(this.cmdAgregar);
            this.Controls.Add(this.grdImpuestos);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImpuestosListado";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Catálogo de impuestos";
            this.Load += new System.EventHandler(this.ImpuestosListado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdImpuestos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.Button cmdModificar;
        private System.Windows.Forms.Button cmdAgregar;
        private System.Windows.Forms.DataGridView grdImpuestos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPorcentaje;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colDefault;
        private System.Windows.Forms.Button cmdBorrar;
        private System.Windows.Forms.Button cmdImprimir;
        private System.Windows.Forms.Button cmdDefault;
    }
}