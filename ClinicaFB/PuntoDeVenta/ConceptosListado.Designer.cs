namespace ClinicaFB.PuntoDeVenta
{
    partial class ConceptosListado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConceptosListado));
            this.grdConceptos = new System.Windows.Forms.DataGridView();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEsVenta = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTipos = new System.Windows.Forms.ComboBox();
            this.cmdBorrar = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.cmdModificar = new System.Windows.Forms.Button();
            this.cmdAgregar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdConceptos)).BeginInit();
            this.SuspendLayout();
            // 
            // grdConceptos
            // 
            this.grdConceptos.AllowUserToAddRows = false;
            this.grdConceptos.AllowUserToDeleteRows = false;
            this.grdConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdConceptos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDescripcion,
            this.colEsVenta});
            this.grdConceptos.Location = new System.Drawing.Point(12, 44);
            this.grdConceptos.Name = "grdConceptos";
            this.grdConceptos.ReadOnly = true;
            this.grdConceptos.Size = new System.Drawing.Size(435, 357);
            this.grdConceptos.TabIndex = 24;
            // 
            // colDescripcion
            // 
            this.colDescripcion.DataPropertyName = "Descripcion";
            this.colDescripcion.HeaderText = "Descripción";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;
            this.colDescripcion.Width = 200;
            // 
            // colEsVenta
            // 
            this.colEsVenta.DataPropertyName = "EsVenta";
            this.colEsVenta.HeaderText = "Venta";
            this.colEsVenta.Name = "colEsVenta";
            this.colEsVenta.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 16);
            this.label1.TabIndex = 25;
            this.label1.Text = "Tipo";
            // 
            // cboTipos
            // 
            this.cboTipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipos.FormattingEnabled = true;
            this.cboTipos.Items.AddRange(new object[] {
            "Entradas",
            "Salidas"});
            this.cboTipos.Location = new System.Drawing.Point(60, 9);
            this.cboTipos.Name = "cboTipos";
            this.cboTipos.Size = new System.Drawing.Size(241, 24);
            this.cboTipos.TabIndex = 26;
            this.cboTipos.SelectedIndexChanged += new System.EventHandler(this.cboTipos_SelectedIndexChanged_1);
            this.cboTipos.Validated += new System.EventHandler(this.cboTipos_Validated);
            // 
            // cmdBorrar
            // 
            this.cmdBorrar.Image = ((System.Drawing.Image)(resources.GetObject("cmdBorrar.Image")));
            this.cmdBorrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdBorrar.Location = new System.Drawing.Point(453, 127);
            this.cmdBorrar.Name = "cmdBorrar";
            this.cmdBorrar.Size = new System.Drawing.Size(126, 35);
            this.cmdBorrar.TabIndex = 23;
            this.cmdBorrar.Text = "&Borrar";
            this.cmdBorrar.UseVisualStyleBackColor = true;
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSalir.Location = new System.Drawing.Point(453, 168);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(126, 35);
            this.cmdSalir.TabIndex = 22;
            this.cmdSalir.Text = "&Salir";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // cmdModificar
            // 
            this.cmdModificar.Image = ((System.Drawing.Image)(resources.GetObject("cmdModificar.Image")));
            this.cmdModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdModificar.Location = new System.Drawing.Point(453, 86);
            this.cmdModificar.Name = "cmdModificar";
            this.cmdModificar.Size = new System.Drawing.Size(126, 35);
            this.cmdModificar.TabIndex = 21;
            this.cmdModificar.Text = "&Modificar";
            this.cmdModificar.UseVisualStyleBackColor = true;
            this.cmdModificar.Click += new System.EventHandler(this.cmdModificar_Click);
            // 
            // cmdAgregar
            // 
            this.cmdAgregar.Image = ((System.Drawing.Image)(resources.GetObject("cmdAgregar.Image")));
            this.cmdAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAgregar.Location = new System.Drawing.Point(453, 45);
            this.cmdAgregar.Name = "cmdAgregar";
            this.cmdAgregar.Size = new System.Drawing.Size(126, 35);
            this.cmdAgregar.TabIndex = 20;
            this.cmdAgregar.Text = "&Agregar";
            this.cmdAgregar.UseVisualStyleBackColor = true;
            this.cmdAgregar.Click += new System.EventHandler(this.cmdAgregar_Click);
            // 
            // ConceptosListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 413);
            this.Controls.Add(this.cboTipos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdConceptos);
            this.Controls.Add(this.cmdBorrar);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.cmdModificar);
            this.Controls.Add(this.cmdAgregar);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ConceptosListado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conceptos";
            this.Load += new System.EventHandler(this.ConceptosListado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdConceptos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdConceptos;
        private System.Windows.Forms.Button cmdBorrar;
        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.Button cmdModificar;
        private System.Windows.Forms.Button cmdAgregar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTipos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colEsVenta;
    }
}