namespace ClinicaFB.PuntoDeVenta.Procesos
{
    partial class ArticulosAsignar
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
            this.grdArticulosFactura = new System.Windows.Forms.DataGridView();
            this.colArticuloId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValorUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdArticulos = new System.Windows.Forms.DataGridView();
            this.cmdPasarID = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.colArtId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdArticulosFactura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdArticulos)).BeginInit();
            this.SuspendLayout();
            // 
            // grdArticulosFactura
            // 
            this.grdArticulosFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdArticulosFactura.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colArticuloId,
            this.colDescripcion,
            this.colCantidad,
            this.colValorUnitario,
            this.colImporte});
            this.grdArticulosFactura.Location = new System.Drawing.Point(12, 12);
            this.grdArticulosFactura.Name = "grdArticulosFactura";
            this.grdArticulosFactura.Size = new System.Drawing.Size(777, 784);
            this.grdArticulosFactura.TabIndex = 0;
            // 
            // colArticuloId
            // 
            this.colArticuloId.DataPropertyName = "ArticuloId";
            this.colArticuloId.HeaderText = "ArticuloId";
            this.colArticuloId.Name = "colArticuloId";
            this.colArticuloId.Width = 80;
            // 
            // colDescripcion
            // 
            this.colDescripcion.DataPropertyName = "Descripcion";
            this.colDescripcion.HeaderText = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Width = 400;
            // 
            // colCantidad
            // 
            this.colCantidad.DataPropertyName = "Cantidad";
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.Width = 80;
            // 
            // colValorUnitario
            // 
            this.colValorUnitario.DataPropertyName = "ValorUnitario";
            this.colValorUnitario.HeaderText = "Precio";
            this.colValorUnitario.Name = "colValorUnitario";
            this.colValorUnitario.Width = 80;
            // 
            // colImporte
            // 
            this.colImporte.DataPropertyName = "Importe";
            this.colImporte.HeaderText = "Importe";
            this.colImporte.Name = "colImporte";
            this.colImporte.Width = 80;
            // 
            // grdArticulos
            // 
            this.grdArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdArticulos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colArtId,
            this.dataGridViewTextBoxColumn2});
            this.grdArticulos.Location = new System.Drawing.Point(872, 38);
            this.grdArticulos.Name = "grdArticulos";
            this.grdArticulos.Size = new System.Drawing.Size(524, 758);
            this.grdArticulos.TabIndex = 1;
            // 
            // cmdPasarID
            // 
            this.cmdPasarID.Location = new System.Drawing.Point(791, 145);
            this.cmdPasarID.Name = "cmdPasarID";
            this.cmdPasarID.Size = new System.Drawing.Size(75, 23);
            this.cmdPasarID.TabIndex = 2;
            this.cmdPasarID.Text = "Pasar";
            this.cmdPasarID.UseVisualStyleBackColor = true;
            this.cmdPasarID.Click += new System.EventHandler(this.cmdPasarID_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(1174, 12);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(222, 20);
            this.txtBuscar.TabIndex = 3;
            // 
            // colArtId
            // 
            this.colArtId.DataPropertyName = "ArticuloId";
            this.colArtId.HeaderText = "ArticuloId";
            this.colArtId.Name = "colArtId";
            this.colArtId.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Descripcion";
            this.dataGridViewTextBoxColumn2.HeaderText = "Descripcion";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 400;
            // 
            // ArticulosAsignar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1408, 820);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.cmdPasarID);
            this.Controls.Add(this.grdArticulos);
            this.Controls.Add(this.grdArticulosFactura);
            this.Name = "ArticulosAsignar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ArticulosAsignar";
            this.Load += new System.EventHandler(this.ArticulosAsignar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdArticulosFactura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdArticulos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdArticulosFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArticuloId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValorUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImporte;
        private System.Windows.Forms.DataGridView grdArticulos;
        private System.Windows.Forms.Button cmdPasarID;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArtId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}