namespace ClinicaFB.PuntoDeVenta.Reportes   
{
    partial class ReportesMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportesMenu));
            this.cmdSalir = new System.Windows.Forms.Button();
            this.cmdExistencias = new System.Windows.Forms.Button();
            this.cmdKardex = new System.Windows.Forms.Button();
            this.sfToolTip1 = new Syncfusion.Windows.Forms.SfToolTip(this.components);
            this.cmdRecalcular = new System.Windows.Forms.Button();
            this.cmdFacturas = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSalir.Location = new System.Drawing.Point(517, 64);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(93, 39);
            this.cmdSalir.TabIndex = 24;
            this.cmdSalir.Text = "&Salir";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // cmdExistencias
            // 
            this.cmdExistencias.Image = ((System.Drawing.Image)(resources.GetObject("cmdExistencias.Image")));
            this.cmdExistencias.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdExistencias.Location = new System.Drawing.Point(12, 12);
            this.cmdExistencias.Name = "cmdExistencias";
            this.cmdExistencias.Size = new System.Drawing.Size(84, 91);
            this.cmdExistencias.TabIndex = 25;
            this.cmdExistencias.Text = "&Existencia y valor del inventario";
            this.cmdExistencias.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.sfToolTip1.SetToolTip(this.cmdExistencias, "Existencia y valor del inventario");
            this.cmdExistencias.UseVisualStyleBackColor = true;
            this.cmdExistencias.Click += new System.EventHandler(this.cmdExistencias_Click);
            // 
            // cmdKardex
            // 
            this.cmdKardex.Image = ((System.Drawing.Image)(resources.GetObject("cmdKardex.Image")));
            this.cmdKardex.Location = new System.Drawing.Point(102, 12);
            this.cmdKardex.Name = "cmdKardex";
            this.cmdKardex.Size = new System.Drawing.Size(84, 91);
            this.cmdKardex.TabIndex = 26;
            this.cmdKardex.Text = "&Kardex";
            this.cmdKardex.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.sfToolTip1.SetToolTip(this.cmdKardex, "Kardex");
            this.cmdKardex.UseVisualStyleBackColor = true;
            this.cmdKardex.Click += new System.EventHandler(this.cmdKardex_Click);
            // 
            // cmdRecalcular
            // 
            this.cmdRecalcular.Location = new System.Drawing.Point(427, 39);
            this.cmdRecalcular.Name = "cmdRecalcular";
            this.cmdRecalcular.Size = new System.Drawing.Size(84, 60);
            this.cmdRecalcular.TabIndex = 27;
            this.cmdRecalcular.Text = "+ Recalcular saldos +";
            this.cmdRecalcular.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.sfToolTip1.SetToolTip(this.cmdRecalcular, "Kardex");
            this.cmdRecalcular.UseVisualStyleBackColor = true;
            this.cmdRecalcular.Click += new System.EventHandler(this.cmdRecalcular_Click);
            // 
            // cmdFacturas
            // 
            this.cmdFacturas.Image = ((System.Drawing.Image)(resources.GetObject("cmdFacturas.Image")));
            this.cmdFacturas.Location = new System.Drawing.Point(192, 12);
            this.cmdFacturas.Name = "cmdFacturas";
            this.cmdFacturas.Size = new System.Drawing.Size(84, 91);
            this.cmdFacturas.TabIndex = 28;
            this.cmdFacturas.Text = "&Facturas";
            this.cmdFacturas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.sfToolTip1.SetToolTip(this.cmdFacturas, "Kardex");
            this.cmdFacturas.UseVisualStyleBackColor = true;
            this.cmdFacturas.Click += new System.EventHandler(this.cmdFacturas_Click_1);
            // 
            // button1
            // 
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(304, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 39);
            this.button1.TabIndex = 29;
            this.button1.Text = "&Asignar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ReportesMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 111);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmdFacturas);
            this.Controls.Add(this.cmdRecalcular);
            this.Controls.Add(this.cmdKardex);
            this.Controls.Add(this.cmdExistencias);
            this.Controls.Add(this.cmdSalir);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "ReportesMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes punto de venta";
            this.Load += new System.EventHandler(this.pdvReportes_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.Button cmdExistencias;
        private Syncfusion.Windows.Forms.SfToolTip sfToolTip1;
        private System.Windows.Forms.Button cmdKardex;
        private System.Windows.Forms.Button cmdRecalcular;
        private System.Windows.Forms.Button cmdFacturas;
        private System.Windows.Forms.Button button1;
    }
}