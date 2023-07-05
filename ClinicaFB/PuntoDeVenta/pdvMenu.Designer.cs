namespace ClinicaFB.PuntoDeVenta
{
    partial class pdvMenu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pdvMenu));
            this.cmdArticulos = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.cmdPuntoDeVenta = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cmdAlmacenes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdArticulos
            // 
            this.cmdArticulos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmdArticulos.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdArticulos.Image = ((System.Drawing.Image)(resources.GetObject("cmdArticulos.Image")));
            this.cmdArticulos.Location = new System.Drawing.Point(81, 13);
            this.cmdArticulos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdArticulos.Name = "cmdArticulos";
            this.cmdArticulos.Size = new System.Drawing.Size(63, 47);
            this.cmdArticulos.TabIndex = 5;
            this.cmdArticulos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip.SetToolTip(this.cmdArticulos, "Artículos");
            this.cmdArticulos.UseVisualStyleBackColor = false;
            this.cmdArticulos.Click += new System.EventHandler(this.cmdArticulos_Click);
            // 
            // cmdSalir
            // 
            this.cmdSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmdSalir.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.Location = new System.Drawing.Point(359, 13);
            this.cmdSalir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(63, 47);
            this.cmdSalir.TabIndex = 7;
            this.cmdSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdSalir.UseVisualStyleBackColor = false;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // cmdPuntoDeVenta
            // 
            this.cmdPuntoDeVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmdPuntoDeVenta.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPuntoDeVenta.Image = ((System.Drawing.Image)(resources.GetObject("cmdPuntoDeVenta.Image")));
            this.cmdPuntoDeVenta.Location = new System.Drawing.Point(12, 13);
            this.cmdPuntoDeVenta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdPuntoDeVenta.Name = "cmdPuntoDeVenta";
            this.cmdPuntoDeVenta.Size = new System.Drawing.Size(63, 47);
            this.cmdPuntoDeVenta.TabIndex = 10;
            this.cmdPuntoDeVenta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip.SetToolTip(this.cmdPuntoDeVenta, "Ventas");
            this.cmdPuntoDeVenta.UseVisualStyleBackColor = false;
            this.cmdPuntoDeVenta.Click += new System.EventHandler(this.cmdPuntoDeVenta_Click);
            // 
            // cmdAlmacenes
            // 
            this.cmdAlmacenes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmdAlmacenes.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAlmacenes.Image = ((System.Drawing.Image)(resources.GetObject("cmdAlmacenes.Image")));
            this.cmdAlmacenes.Location = new System.Drawing.Point(150, 13);
            this.cmdAlmacenes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdAlmacenes.Name = "cmdAlmacenes";
            this.cmdAlmacenes.Size = new System.Drawing.Size(63, 47);
            this.cmdAlmacenes.TabIndex = 11;
            this.cmdAlmacenes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip.SetToolTip(this.cmdAlmacenes, "Almacenes");
            this.cmdAlmacenes.UseVisualStyleBackColor = false;
            this.cmdAlmacenes.Click += new System.EventHandler(this.cmdAlmacenes_Click);
            // 
            // pdvMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 67);
            this.Controls.Add(this.cmdAlmacenes);
            this.Controls.Add(this.cmdPuntoDeVenta);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.cmdArticulos);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "pdvMenu";
            this.ShowInTaskbar = false;
            this.Text = "Punto de venta";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdArticulos;
        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.Button cmdPuntoDeVenta;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button cmdAlmacenes;
    }
}