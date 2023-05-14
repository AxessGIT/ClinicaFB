namespace ClinicaFB.Ingresos
{
    partial class IngMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IngMenu));
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cmdCapturaIngreso = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.cmdRazonesSociales = new System.Windows.Forms.Button();
            this.cmdFacturas = new System.Windows.Forms.Button();
            this.cmdListadoIngresos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdCapturaIngreso
            // 
            this.cmdCapturaIngreso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmdCapturaIngreso.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCapturaIngreso.Image = ((System.Drawing.Image)(resources.GetObject("cmdCapturaIngreso.Image")));
            this.cmdCapturaIngreso.Location = new System.Drawing.Point(12, 13);
            this.cmdCapturaIngreso.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdCapturaIngreso.Name = "cmdCapturaIngreso";
            this.cmdCapturaIngreso.Size = new System.Drawing.Size(63, 47);
            this.cmdCapturaIngreso.TabIndex = 12;
            this.cmdCapturaIngreso.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip.SetToolTip(this.cmdCapturaIngreso, "Captura de ingresos");
            this.cmdCapturaIngreso.UseVisualStyleBackColor = false;
            this.cmdCapturaIngreso.Click += new System.EventHandler(this.cmdCapturaIngreso_Click);
            // 
            // cmdSalir
            // 
            this.cmdSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmdSalir.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.Location = new System.Drawing.Point(395, 13);
            this.cmdSalir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(63, 47);
            this.cmdSalir.TabIndex = 11;
            this.cmdSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip.SetToolTip(this.cmdSalir, "Salir");
            this.cmdSalir.UseVisualStyleBackColor = false;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // cmdRazonesSociales
            // 
            this.cmdRazonesSociales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmdRazonesSociales.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRazonesSociales.Image = ((System.Drawing.Image)(resources.GetObject("cmdRazonesSociales.Image")));
            this.cmdRazonesSociales.Location = new System.Drawing.Point(326, 13);
            this.cmdRazonesSociales.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdRazonesSociales.Name = "cmdRazonesSociales";
            this.cmdRazonesSociales.Size = new System.Drawing.Size(63, 47);
            this.cmdRazonesSociales.TabIndex = 13;
            this.cmdRazonesSociales.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip.SetToolTip(this.cmdRazonesSociales, "Razones sociales");
            this.cmdRazonesSociales.UseVisualStyleBackColor = false;
            this.cmdRazonesSociales.Click += new System.EventHandler(this.cmdRazonesSociales_Click);
            // 
            // cmdFacturas
            // 
            this.cmdFacturas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmdFacturas.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFacturas.Image = ((System.Drawing.Image)(resources.GetObject("cmdFacturas.Image")));
            this.cmdFacturas.Location = new System.Drawing.Point(150, 13);
            this.cmdFacturas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdFacturas.Name = "cmdFacturas";
            this.cmdFacturas.Size = new System.Drawing.Size(63, 47);
            this.cmdFacturas.TabIndex = 14;
            this.cmdFacturas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip.SetToolTip(this.cmdFacturas, "Listado de facturas");
            this.cmdFacturas.UseVisualStyleBackColor = false;
            this.cmdFacturas.Click += new System.EventHandler(this.cmdFacturas_Click);
            // 
            // cmdListadoIngresos
            // 
            this.cmdListadoIngresos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmdListadoIngresos.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdListadoIngresos.Image = ((System.Drawing.Image)(resources.GetObject("cmdListadoIngresos.Image")));
            this.cmdListadoIngresos.Location = new System.Drawing.Point(81, 13);
            this.cmdListadoIngresos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdListadoIngresos.Name = "cmdListadoIngresos";
            this.cmdListadoIngresos.Size = new System.Drawing.Size(63, 47);
            this.cmdListadoIngresos.TabIndex = 15;
            this.cmdListadoIngresos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip.SetToolTip(this.cmdListadoIngresos, "Listado de ingresos");
            this.cmdListadoIngresos.UseVisualStyleBackColor = false;
            this.cmdListadoIngresos.Click += new System.EventHandler(this.cmdListadoIngresos_Click);
            // 
            // IngMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 82);
            this.Controls.Add(this.cmdListadoIngresos);
            this.Controls.Add(this.cmdFacturas);
            this.Controls.Add(this.cmdRazonesSociales);
            this.Controls.Add(this.cmdCapturaIngreso);
            this.Controls.Add(this.cmdSalir);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "IngMenu";
            this.Text = "Ingresos";
            this.Load += new System.EventHandler(this.IngMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdCapturaIngreso;
        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button cmdRazonesSociales;
        private System.Windows.Forms.Button cmdFacturas;
        private System.Windows.Forms.Button cmdListadoIngresos;
    }
}