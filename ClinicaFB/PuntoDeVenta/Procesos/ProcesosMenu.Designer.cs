namespace ClinicaFB.PuntoDeVenta.Procesos
{
    partial class ProcesosMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcesosMenu));
            this.sfToolTip1 = new Syncfusion.Windows.Forms.SfToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.cmdCrearDesdeCFdi = new System.Windows.Forms.Button();
            this.cmdCargarDetalle = new System.Windows.Forms.Button();
            this.cmdCostosGenerar = new System.Windows.Forms.Button();
            this.cmdCancelarFacturas = new System.Windows.Forms.Button();
            this.cmdGenerarInventarioInicial = new System.Windows.Forms.Button();
            this.cmdGenerarExistencias = new System.Windows.Forms.Button();
            this.cmdAjustarExistencias = new System.Windows.Forms.Button();
            this.cmdImpresoraTicketSeleccionar = new System.Windows.Forms.Button();
            this.cmdImportar = new System.Windows.Forms.Button();
            this.cmdInicializar = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(282, 163);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 85);
            this.button1.TabIndex = 23;
            this.button1.Text = "Crear desde CFDi";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.sfToolTip1.SetToolTip(this.button1, "Generar últimos costos");
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdCrearDesdeCFdi
            // 
            this.cmdCrearDesdeCFdi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmdCrearDesdeCFdi.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCrearDesdeCFdi.Image = ((System.Drawing.Image)(resources.GetObject("cmdCrearDesdeCFdi.Image")));
            this.cmdCrearDesdeCFdi.Location = new System.Drawing.Point(156, 163);
            this.cmdCrearDesdeCFdi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdCrearDesdeCFdi.Name = "cmdCrearDesdeCFdi";
            this.cmdCrearDesdeCFdi.Size = new System.Drawing.Size(120, 85);
            this.cmdCrearDesdeCFdi.TabIndex = 22;
            this.cmdCrearDesdeCFdi.Text = "Crear desde CFDi";
            this.cmdCrearDesdeCFdi.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.sfToolTip1.SetToolTip(this.cmdCrearDesdeCFdi, "Generar últimos costos");
            this.cmdCrearDesdeCFdi.UseVisualStyleBackColor = false;
            this.cmdCrearDesdeCFdi.Click += new System.EventHandler(this.cmdCrearDesdeCFdi_Click);
            // 
            // cmdCargarDetalle
            // 
            this.cmdCargarDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmdCargarDetalle.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCargarDetalle.Image = ((System.Drawing.Image)(resources.GetObject("cmdCargarDetalle.Image")));
            this.cmdCargarDetalle.Location = new System.Drawing.Point(30, 163);
            this.cmdCargarDetalle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdCargarDetalle.Name = "cmdCargarDetalle";
            this.cmdCargarDetalle.Size = new System.Drawing.Size(120, 85);
            this.cmdCargarDetalle.TabIndex = 21;
            this.cmdCargarDetalle.Text = "Cargar detalle";
            this.cmdCargarDetalle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.sfToolTip1.SetToolTip(this.cmdCargarDetalle, "Generar últimos costos");
            this.cmdCargarDetalle.UseVisualStyleBackColor = false;
            this.cmdCargarDetalle.Click += new System.EventHandler(this.cmdCargarDetalle_Click);
            // 
            // cmdCostosGenerar
            // 
            this.cmdCostosGenerar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmdCostosGenerar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCostosGenerar.Image = ((System.Drawing.Image)(resources.GetObject("cmdCostosGenerar.Image")));
            this.cmdCostosGenerar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdCostosGenerar.Location = new System.Drawing.Point(408, 88);
            this.cmdCostosGenerar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdCostosGenerar.Name = "cmdCostosGenerar";
            this.cmdCostosGenerar.Size = new System.Drawing.Size(120, 67);
            this.cmdCostosGenerar.TabIndex = 20;
            this.cmdCostosGenerar.Text = "Generar capas de  costos";
            this.cmdCostosGenerar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.sfToolTip1.SetToolTip(this.cmdCostosGenerar, "Generar capas de costos");
            this.cmdCostosGenerar.UseVisualStyleBackColor = false;
            this.cmdCostosGenerar.Click += new System.EventHandler(this.cmdCostosGenerar_Click);
            // 
            // cmdCancelarFacturas
            // 
            this.cmdCancelarFacturas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmdCancelarFacturas.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancelarFacturas.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancelarFacturas.Image")));
            this.cmdCancelarFacturas.Location = new System.Drawing.Point(282, 88);
            this.cmdCancelarFacturas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdCancelarFacturas.Name = "cmdCancelarFacturas";
            this.cmdCancelarFacturas.Size = new System.Drawing.Size(120, 67);
            this.cmdCancelarFacturas.TabIndex = 19;
            this.cmdCancelarFacturas.Text = "Cancelar fac.";
            this.cmdCancelarFacturas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.sfToolTip1.SetToolTip(this.cmdCancelarFacturas, "Inicializa los movimientos del inventario");
            this.cmdCancelarFacturas.UseVisualStyleBackColor = false;
            this.cmdCancelarFacturas.Click += new System.EventHandler(this.cmdCancelarFacturas_Click);
            // 
            // cmdGenerarInventarioInicial
            // 
            this.cmdGenerarInventarioInicial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmdGenerarInventarioInicial.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGenerarInventarioInicial.Image = ((System.Drawing.Image)(resources.GetObject("cmdGenerarInventarioInicial.Image")));
            this.cmdGenerarInventarioInicial.Location = new System.Drawing.Point(156, 88);
            this.cmdGenerarInventarioInicial.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdGenerarInventarioInicial.Name = "cmdGenerarInventarioInicial";
            this.cmdGenerarInventarioInicial.Size = new System.Drawing.Size(120, 67);
            this.cmdGenerarInventarioInicial.TabIndex = 18;
            this.cmdGenerarInventarioInicial.Text = "Gen. ini.";
            this.cmdGenerarInventarioInicial.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.sfToolTip1.SetToolTip(this.cmdGenerarInventarioInicial, "Inicializa los movimientos del inventario");
            this.cmdGenerarInventarioInicial.UseVisualStyleBackColor = false;
            this.cmdGenerarInventarioInicial.Click += new System.EventHandler(this.cmdGenerarInventarioInicial_Click);
            // 
            // cmdGenerarExistencias
            // 
            this.cmdGenerarExistencias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmdGenerarExistencias.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGenerarExistencias.Image = ((System.Drawing.Image)(resources.GetObject("cmdGenerarExistencias.Image")));
            this.cmdGenerarExistencias.Location = new System.Drawing.Point(30, 88);
            this.cmdGenerarExistencias.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdGenerarExistencias.Name = "cmdGenerarExistencias";
            this.cmdGenerarExistencias.Size = new System.Drawing.Size(120, 67);
            this.cmdGenerarExistencias.TabIndex = 17;
            this.cmdGenerarExistencias.Text = "Gen. exi.";
            this.cmdGenerarExistencias.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.sfToolTip1.SetToolTip(this.cmdGenerarExistencias, "Inicializa los movimientos del inventario");
            this.cmdGenerarExistencias.UseVisualStyleBackColor = false;
            this.cmdGenerarExistencias.Click += new System.EventHandler(this.cmdGenerarExistencias_Click);
            // 
            // cmdAjustarExistencias
            // 
            this.cmdAjustarExistencias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmdAjustarExistencias.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAjustarExistencias.Image = ((System.Drawing.Image)(resources.GetObject("cmdAjustarExistencias.Image")));
            this.cmdAjustarExistencias.Location = new System.Drawing.Point(408, 13);
            this.cmdAjustarExistencias.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdAjustarExistencias.Name = "cmdAjustarExistencias";
            this.cmdAjustarExistencias.Size = new System.Drawing.Size(120, 67);
            this.cmdAjustarExistencias.TabIndex = 16;
            this.cmdAjustarExistencias.Text = "Ajustar exi.";
            this.cmdAjustarExistencias.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.sfToolTip1.SetToolTip(this.cmdAjustarExistencias, "Inicializa los movimientos del inventario");
            this.cmdAjustarExistencias.UseVisualStyleBackColor = false;
            this.cmdAjustarExistencias.Click += new System.EventHandler(this.cmdAjustarExistencias_Click);
            // 
            // cmdImpresoraTicketSeleccionar
            // 
            this.cmdImpresoraTicketSeleccionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmdImpresoraTicketSeleccionar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdImpresoraTicketSeleccionar.Image = ((System.Drawing.Image)(resources.GetObject("cmdImpresoraTicketSeleccionar.Image")));
            this.cmdImpresoraTicketSeleccionar.Location = new System.Drawing.Point(282, 13);
            this.cmdImpresoraTicketSeleccionar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdImpresoraTicketSeleccionar.Name = "cmdImpresoraTicketSeleccionar";
            this.cmdImpresoraTicketSeleccionar.Size = new System.Drawing.Size(120, 67);
            this.cmdImpresoraTicketSeleccionar.TabIndex = 15;
            this.cmdImpresoraTicketSeleccionar.Text = "Impresora tickets";
            this.cmdImpresoraTicketSeleccionar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.sfToolTip1.SetToolTip(this.cmdImpresoraTicketSeleccionar, "Inicializa los movimientos del inventario");
            this.cmdImpresoraTicketSeleccionar.UseVisualStyleBackColor = false;
            this.cmdImpresoraTicketSeleccionar.Click += new System.EventHandler(this.cmdImpresoraTicketSeleccionar_Click);
            // 
            // cmdImportar
            // 
            this.cmdImportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmdImportar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdImportar.Image = ((System.Drawing.Image)(resources.GetObject("cmdImportar.Image")));
            this.cmdImportar.Location = new System.Drawing.Point(156, 13);
            this.cmdImportar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdImportar.Name = "cmdImportar";
            this.cmdImportar.Size = new System.Drawing.Size(120, 67);
            this.cmdImportar.TabIndex = 14;
            this.cmdImportar.Text = "Importar arts.";
            this.cmdImportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.sfToolTip1.SetToolTip(this.cmdImportar, "Importa artícuos con existencias claves y precios");
            this.cmdImportar.UseVisualStyleBackColor = false;
            this.cmdImportar.Click += new System.EventHandler(this.cmdImportar_Click);
            // 
            // cmdInicializar
            // 
            this.cmdInicializar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmdInicializar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdInicializar.Image = ((System.Drawing.Image)(resources.GetObject("cmdInicializar.Image")));
            this.cmdInicializar.Location = new System.Drawing.Point(30, 13);
            this.cmdInicializar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdInicializar.Name = "cmdInicializar";
            this.cmdInicializar.Size = new System.Drawing.Size(120, 67);
            this.cmdInicializar.TabIndex = 13;
            this.cmdInicializar.Text = "Inicializar PDV";
            this.cmdInicializar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.sfToolTip1.SetToolTip(this.cmdInicializar, "Inicializa los movimientos del inventario");
            this.cmdInicializar.UseVisualStyleBackColor = false;
            this.cmdInicializar.Click += new System.EventHandler(this.cmdInicializar_Click);
            // 
            // cmdSalir
            // 
            this.cmdSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmdSalir.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.Location = new System.Drawing.Point(424, 220);
            this.cmdSalir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(120, 67);
            this.cmdSalir.TabIndex = 12;
            this.cmdSalir.Text = "Salir";
            this.cmdSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.sfToolTip1.SetToolTip(this.cmdSalir, "Termina el módulo");
            this.cmdSalir.UseVisualStyleBackColor = false;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // ProcesosMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 300);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmdCrearDesdeCFdi);
            this.Controls.Add(this.cmdCargarDetalle);
            this.Controls.Add(this.cmdCostosGenerar);
            this.Controls.Add(this.cmdCancelarFacturas);
            this.Controls.Add(this.cmdGenerarInventarioInicial);
            this.Controls.Add(this.cmdGenerarExistencias);
            this.Controls.Add(this.cmdAjustarExistencias);
            this.Controls.Add(this.cmdImpresoraTicketSeleccionar);
            this.Controls.Add(this.cmdImportar);
            this.Controls.Add(this.cmdInicializar);
            this.Controls.Add(this.cmdSalir);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ProcesosMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Procesos de punto de venta";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.Button cmdInicializar;
        private System.Windows.Forms.Button cmdImportar;
        private Syncfusion.Windows.Forms.SfToolTip sfToolTip1;
        private System.Windows.Forms.Button cmdImpresoraTicketSeleccionar;
        private System.Windows.Forms.Button cmdAjustarExistencias;
        private System.Windows.Forms.Button cmdGenerarExistencias;
        private System.Windows.Forms.Button cmdGenerarInventarioInicial;
        private System.Windows.Forms.Button cmdCancelarFacturas;
        private System.Windows.Forms.Button cmdCostosGenerar;
        private System.Windows.Forms.Button cmdCargarDetalle;
        private System.Windows.Forms.Button cmdCrearDesdeCFdi;
        private System.Windows.Forms.Button button1;
    }
}