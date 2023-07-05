namespace ClinicaFB.Configuracion
{
    partial class ClientesFFImportar
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.cmdBuscarCarpeta = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmdImportar = new System.Windows.Forms.Button();
            this.cmdCerrar = new System.Windows.Forms.Button();
            this.lblEmisorCliente = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Carpeta de instalación FF";
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(15, 42);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.ReadOnly = true;
            this.txtFolder.Size = new System.Drawing.Size(477, 23);
            this.txtFolder.TabIndex = 1;
            this.txtFolder.Text = "C:\\FACTURAFOX4";
            // 
            // cmdBuscarCarpeta
            // 
            this.cmdBuscarCarpeta.Location = new System.Drawing.Point(498, 42);
            this.cmdBuscarCarpeta.Name = "cmdBuscarCarpeta";
            this.cmdBuscarCarpeta.Size = new System.Drawing.Size(59, 23);
            this.cmdBuscarCarpeta.TabIndex = 2;
            this.cmdBuscarCarpeta.Text = "...";
            this.toolTip1.SetToolTip(this.cmdBuscarCarpeta, "Buscar carpeta");
            this.cmdBuscarCarpeta.UseVisualStyleBackColor = true;
            this.cmdBuscarCarpeta.Click += new System.EventHandler(this.cmdBuscarCarpeta_Click);
            // 
            // cmdImportar
            // 
            this.cmdImportar.Location = new System.Drawing.Point(184, 129);
            this.cmdImportar.Name = "cmdImportar";
            this.cmdImportar.Size = new System.Drawing.Size(97, 34);
            this.cmdImportar.TabIndex = 3;
            this.cmdImportar.Text = "&Importar";
            this.cmdImportar.UseVisualStyleBackColor = true;
            this.cmdImportar.Click += new System.EventHandler(this.cmdImportar_Click);
            // 
            // cmdCerrar
            // 
            this.cmdCerrar.Location = new System.Drawing.Point(287, 129);
            this.cmdCerrar.Name = "cmdCerrar";
            this.cmdCerrar.Size = new System.Drawing.Size(97, 34);
            this.cmdCerrar.TabIndex = 4;
            this.cmdCerrar.Text = "&Cerrar";
            this.cmdCerrar.UseVisualStyleBackColor = true;
            this.cmdCerrar.Click += new System.EventHandler(this.cmdCerrar_Click);
            // 
            // lblEmisorCliente
            // 
            this.lblEmisorCliente.AutoSize = true;
            this.lblEmisorCliente.Location = new System.Drawing.Point(12, 80);
            this.lblEmisorCliente.Name = "lblEmisorCliente";
            this.lblEmisorCliente.Size = new System.Drawing.Size(51, 16);
            this.lblEmisorCliente.TabIndex = 5;
            this.lblEmisorCliente.Text = "Emisor:";
            // 
            // ClientesFFImportar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 175);
            this.Controls.Add(this.lblEmisorCliente);
            this.Controls.Add(this.cmdCerrar);
            this.Controls.Add(this.cmdImportar);
            this.Controls.Add(this.cmdBuscarCarpeta);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClientesFFImportar";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importar Clientes FactuaFox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Button cmdBuscarCarpeta;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button cmdImportar;
        private System.Windows.Forms.Button cmdCerrar;
        private System.Windows.Forms.Label lblEmisorCliente;
    }
}