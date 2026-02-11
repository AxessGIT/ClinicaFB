namespace ClinicaFB.PuntoDeVenta
{
    partial class ArticulosListado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArticulosListado));
            this.grdArticulos = new System.Windows.Forms.DataGridView();
            this.cmdExistencias = new System.Windows.Forms.Button();
            this.cmdImportar = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.cmdModificar = new System.Windows.Forms.Button();
            this.cmdAgregar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdArticulos)).BeginInit();
            this.SuspendLayout();
            // 
            // grdArticulos
            // 
            this.grdArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdArticulos.Location = new System.Drawing.Point(6, 81);
            this.grdArticulos.Name = "grdArticulos";
            this.grdArticulos.Size = new System.Drawing.Size(656, 489);
            this.grdArticulos.TabIndex = 7;
            this.grdArticulos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdArticulos_CellDoubleClick);
            // 
            // cmdExistencias
            // 
            this.cmdExistencias.Image = ((System.Drawing.Image)(resources.GetObject("cmdExistencias.Image")));
            this.cmdExistencias.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdExistencias.Location = new System.Drawing.Point(668, 206);
            this.cmdExistencias.Name = "cmdExistencias";
            this.cmdExistencias.Size = new System.Drawing.Size(114, 35);
            this.cmdExistencias.TabIndex = 5;
            this.cmdExistencias.Text = "&Existencias";
            this.cmdExistencias.UseVisualStyleBackColor = true;
            this.cmdExistencias.Click += new System.EventHandler(this.cmdExistencias_Click);
            // 
            // cmdImportar
            // 
            this.cmdImportar.Image = ((System.Drawing.Image)(resources.GetObject("cmdImportar.Image")));
            this.cmdImportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdImportar.Location = new System.Drawing.Point(668, 163);
            this.cmdImportar.Name = "cmdImportar";
            this.cmdImportar.Size = new System.Drawing.Size(114, 35);
            this.cmdImportar.TabIndex = 4;
            this.cmdImportar.Text = "&Importar";
            this.cmdImportar.UseVisualStyleBackColor = true;
            this.cmdImportar.Click += new System.EventHandler(this.cmdImportar_Click);
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSalir.Location = new System.Drawing.Point(668, 247);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(114, 35);
            this.cmdSalir.TabIndex = 6;
            this.cmdSalir.Text = "&Salir";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // cmdModificar
            // 
            this.cmdModificar.Image = ((System.Drawing.Image)(resources.GetObject("cmdModificar.Image")));
            this.cmdModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdModificar.Location = new System.Drawing.Point(668, 122);
            this.cmdModificar.Name = "cmdModificar";
            this.cmdModificar.Size = new System.Drawing.Size(114, 35);
            this.cmdModificar.TabIndex = 3;
            this.cmdModificar.Text = "&Modificar";
            this.cmdModificar.UseVisualStyleBackColor = true;
            this.cmdModificar.Click += new System.EventHandler(this.cmdModificar_Click);
            // 
            // cmdAgregar
            // 
            this.cmdAgregar.Image = ((System.Drawing.Image)(resources.GetObject("cmdAgregar.Image")));
            this.cmdAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAgregar.Location = new System.Drawing.Point(668, 81);
            this.cmdAgregar.Name = "cmdAgregar";
            this.cmdAgregar.Size = new System.Drawing.Size(114, 35);
            this.cmdAgregar.TabIndex = 2;
            this.cmdAgregar.Text = "&Agregar";
            this.cmdAgregar.UseVisualStyleBackColor = true;
            this.cmdAgregar.Click += new System.EventHandler(this.cmdAgregar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscar.Location = new System.Drawing.Point(12, 52);
            this.txtBuscar.MaxLength = 50;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(591, 23);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(340, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar (por descripción, por clave o por código de barras)";
            // 
            // ArticulosListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 582);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdExistencias);
            this.Controls.Add(this.cmdImportar);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.cmdModificar);
            this.Controls.Add(this.cmdAgregar);
            this.Controls.Add(this.grdArticulos);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "ArticulosListado";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Catálogo de articulos";
            this.Load += new System.EventHandler(this.ArticulosListado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdArticulos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.Button cmdModificar;
        private System.Windows.Forms.Button cmdAgregar;
        private System.Windows.Forms.DataGridView grdArticulos;
        private System.Windows.Forms.Button cmdImportar;
        private System.Windows.Forms.Button cmdExistencias;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label1;
    }
}