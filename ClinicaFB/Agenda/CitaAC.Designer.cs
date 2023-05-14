
namespace ClinicaFB.Agenda
{
    partial class CitaAC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CitaAC));
            this.lblAsistio = new System.Windows.Forms.Label();
            this.lblConfirmado = new System.Windows.Forms.Label();
            this.cmdBorrar = new System.Windows.Forms.Button();
            this.cmdAgregarInstruccion = new System.Windows.Forms.Button();
            this.btnAgregarProcedimiento = new System.Windows.Forms.Button();
            this.cmdDevuelveInstruccion = new System.Windows.Forms.Button();
            this.cmdPasaInstruccion = new System.Windows.Forms.Button();
            this.cmdCerrar = new System.Windows.Forms.Button();
            this.cmdGuardar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.lblFechaHora = new System.Windows.Forms.Label();
            this.lblNombrePaciente = new System.Windows.Forms.Label();
            this.cmdDevuelveProcedimiento = new System.Windows.Forms.Button();
            this.cmdPasaProcedimiento = new System.Windows.Forms.Button();
            this.grdInstruccionesSeleccionadas = new System.Windows.Forms.DataGridView();
            this.grdInstruccionesDisponibles = new System.Windows.Forms.DataGridView();
            this.grdProcedimientosSeleccionados = new System.Windows.Forms.DataGridView();
            this.grdProcedimientosDisponibles = new System.Windows.Forms.DataGridView();
            this.lblUsuarioRegistro = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdInstruccionesSeleccionadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInstruccionesDisponibles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProcedimientosSeleccionados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProcedimientosDisponibles)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAsistio
            // 
            this.lblAsistio.AutoSize = true;
            this.lblAsistio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAsistio.Location = new System.Drawing.Point(117, 40);
            this.lblAsistio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAsistio.Name = "lblAsistio";
            this.lblAsistio.Size = new System.Drawing.Size(45, 13);
            this.lblAsistio.TabIndex = 39;
            this.lblAsistio.Text = "Asistió";
            this.lblAsistio.Visible = false;
            // 
            // lblConfirmado
            // 
            this.lblConfirmado.AutoSize = true;
            this.lblConfirmado.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmado.Location = new System.Drawing.Point(13, 40);
            this.lblConfirmado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConfirmado.Name = "lblConfirmado";
            this.lblConfirmado.Size = new System.Drawing.Size(72, 13);
            this.lblConfirmado.TabIndex = 38;
            this.lblConfirmado.Text = "Confirmado";
            this.lblConfirmado.Visible = false;
            // 
            // cmdBorrar
            // 
            this.cmdBorrar.Image = ((System.Drawing.Image)(resources.GetObject("cmdBorrar.Image")));
            this.cmdBorrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdBorrar.Location = new System.Drawing.Point(229, 580);
            this.cmdBorrar.Margin = new System.Windows.Forms.Padding(4);
            this.cmdBorrar.Name = "cmdBorrar";
            this.cmdBorrar.Size = new System.Drawing.Size(139, 42);
            this.cmdBorrar.TabIndex = 34;
            this.cmdBorrar.Text = "&Borrar";
            this.cmdBorrar.UseVisualStyleBackColor = true;
            this.cmdBorrar.Click += new System.EventHandler(this.cmdBorrar_Click);
            // 
            // cmdAgregarInstruccion
            // 
            this.cmdAgregarInstruccion.Location = new System.Drawing.Point(216, 278);
            this.cmdAgregarInstruccion.Margin = new System.Windows.Forms.Padding(4);
            this.cmdAgregarInstruccion.Name = "cmdAgregarInstruccion";
            this.cmdAgregarInstruccion.Size = new System.Drawing.Size(36, 28);
            this.cmdAgregarInstruccion.TabIndex = 26;
            this.cmdAgregarInstruccion.Text = "+";
            this.cmdAgregarInstruccion.UseVisualStyleBackColor = true;
            this.cmdAgregarInstruccion.Click += new System.EventHandler(this.cmdAgregarInstruccion_Click);
            // 
            // btnAgregarProcedimiento
            // 
            this.btnAgregarProcedimiento.Location = new System.Drawing.Point(216, 57);
            this.btnAgregarProcedimiento.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregarProcedimiento.Name = "btnAgregarProcedimiento";
            this.btnAgregarProcedimiento.Size = new System.Drawing.Size(36, 28);
            this.btnAgregarProcedimiento.TabIndex = 22;
            this.btnAgregarProcedimiento.Text = "+";
            this.btnAgregarProcedimiento.UseVisualStyleBackColor = true;
            this.btnAgregarProcedimiento.Click += new System.EventHandler(this.btnAgregarProcedimiento_Click);
            // 
            // cmdDevuelveInstruccion
            // 
            this.cmdDevuelveInstruccion.Location = new System.Drawing.Point(268, 392);
            this.cmdDevuelveInstruccion.Margin = new System.Windows.Forms.Padding(4);
            this.cmdDevuelveInstruccion.Name = "cmdDevuelveInstruccion";
            this.cmdDevuelveInstruccion.Size = new System.Drawing.Size(56, 28);
            this.cmdDevuelveInstruccion.TabIndex = 28;
            this.cmdDevuelveInstruccion.Text = "<";
            this.cmdDevuelveInstruccion.UseVisualStyleBackColor = true;
            this.cmdDevuelveInstruccion.Click += new System.EventHandler(this.cmdDevuelveInstruccion_Click);
            // 
            // cmdPasaInstruccion
            // 
            this.cmdPasaInstruccion.Location = new System.Drawing.Point(268, 357);
            this.cmdPasaInstruccion.Margin = new System.Windows.Forms.Padding(4);
            this.cmdPasaInstruccion.Name = "cmdPasaInstruccion";
            this.cmdPasaInstruccion.Size = new System.Drawing.Size(56, 28);
            this.cmdPasaInstruccion.TabIndex = 27;
            this.cmdPasaInstruccion.Text = ">";
            this.cmdPasaInstruccion.UseVisualStyleBackColor = true;
            this.cmdPasaInstruccion.Click += new System.EventHandler(this.cmdPasaInstruccion_Click);
            // 
            // cmdCerrar
            // 
            this.cmdCerrar.Image = ((System.Drawing.Image)(resources.GetObject("cmdCerrar.Image")));
            this.cmdCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCerrar.Location = new System.Drawing.Point(376, 580);
            this.cmdCerrar.Margin = new System.Windows.Forms.Padding(4);
            this.cmdCerrar.Name = "cmdCerrar";
            this.cmdCerrar.Size = new System.Drawing.Size(139, 42);
            this.cmdCerrar.TabIndex = 35;
            this.cmdCerrar.Text = "&Cerrar";
            this.cmdCerrar.UseVisualStyleBackColor = true;
            this.cmdCerrar.Click += new System.EventHandler(this.cmdCerrar_Click);
            // 
            // cmdGuardar
            // 
            this.cmdGuardar.Image = ((System.Drawing.Image)(resources.GetObject("cmdGuardar.Image")));
            this.cmdGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGuardar.Location = new System.Drawing.Point(82, 580);
            this.cmdGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.cmdGuardar.Name = "cmdGuardar";
            this.cmdGuardar.Size = new System.Drawing.Size(139, 42);
            this.cmdGuardar.TabIndex = 31;
            this.cmdGuardar.Text = "&Guardar";
            this.cmdGuardar.UseVisualStyleBackColor = true;
            this.cmdGuardar.Click += new System.EventHandler(this.cmdGuardar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(344, 289);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "Instrucciones seleccionadas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 289);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Instrucciones disp.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(336, 75);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Procedimientos seleccionados";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Procedimientos disp.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 496);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Obervaciones";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservaciones.Location = new System.Drawing.Point(15, 513);
            this.txtObservaciones.Margin = new System.Windows.Forms.Padding(4);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(557, 25);
            this.txtObservaciones.TabIndex = 30;
            // 
            // lblFechaHora
            // 
            this.lblFechaHora.AutoSize = true;
            this.lblFechaHora.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaHora.Location = new System.Drawing.Point(13, 24);
            this.lblFechaHora.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechaHora.Name = "lblFechaHora";
            this.lblFechaHora.Size = new System.Drawing.Size(40, 13);
            this.lblFechaHora.TabIndex = 20;
            this.lblFechaHora.Text = "Fecha";
            // 
            // lblNombrePaciente
            // 
            this.lblNombrePaciente.AutoSize = true;
            this.lblNombrePaciente.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombrePaciente.Location = new System.Drawing.Point(13, 8);
            this.lblNombrePaciente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombrePaciente.Name = "lblNombrePaciente";
            this.lblNombrePaciente.Size = new System.Drawing.Size(100, 13);
            this.lblNombrePaciente.TabIndex = 18;
            this.lblNombrePaciente.Text = "NombrePaciente";
            // 
            // cmdDevuelveProcedimiento
            // 
            this.cmdDevuelveProcedimiento.Location = new System.Drawing.Point(268, 161);
            this.cmdDevuelveProcedimiento.Margin = new System.Windows.Forms.Padding(4);
            this.cmdDevuelveProcedimiento.Name = "cmdDevuelveProcedimiento";
            this.cmdDevuelveProcedimiento.Size = new System.Drawing.Size(56, 28);
            this.cmdDevuelveProcedimiento.TabIndex = 25;
            this.cmdDevuelveProcedimiento.Text = "<";
            this.cmdDevuelveProcedimiento.UseVisualStyleBackColor = true;
            this.cmdDevuelveProcedimiento.Click += new System.EventHandler(this.cmdDevuelveProcedimiento_Click);
            // 
            // cmdPasaProcedimiento
            // 
            this.cmdPasaProcedimiento.Location = new System.Drawing.Point(268, 125);
            this.cmdPasaProcedimiento.Margin = new System.Windows.Forms.Padding(4);
            this.cmdPasaProcedimiento.Name = "cmdPasaProcedimiento";
            this.cmdPasaProcedimiento.Size = new System.Drawing.Size(56, 28);
            this.cmdPasaProcedimiento.TabIndex = 24;
            this.cmdPasaProcedimiento.Text = ">";
            this.cmdPasaProcedimiento.UseVisualStyleBackColor = true;
            this.cmdPasaProcedimiento.Click += new System.EventHandler(this.cmdPasaProcedimiento_Click);
            // 
            // grdInstruccionesSeleccionadas
            // 
            this.grdInstruccionesSeleccionadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdInstruccionesSeleccionadas.Location = new System.Drawing.Point(340, 307);
            this.grdInstruccionesSeleccionadas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdInstruccionesSeleccionadas.Name = "grdInstruccionesSeleccionadas";
            this.grdInstruccionesSeleccionadas.RowHeadersWidth = 51;
            this.grdInstruccionesSeleccionadas.RowTemplate.Height = 24;
            this.grdInstruccionesSeleccionadas.Size = new System.Drawing.Size(237, 181);
            this.grdInstruccionesSeleccionadas.TabIndex = 23;
            // 
            // grdInstruccionesDisponibles
            // 
            this.grdInstruccionesDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdInstruccionesDisponibles.Location = new System.Drawing.Point(15, 307);
            this.grdInstruccionesDisponibles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdInstruccionesDisponibles.Name = "grdInstruccionesDisponibles";
            this.grdInstruccionesDisponibles.RowHeadersWidth = 51;
            this.grdInstruccionesDisponibles.RowTemplate.Height = 24;
            this.grdInstruccionesDisponibles.Size = new System.Drawing.Size(237, 181);
            this.grdInstruccionesDisponibles.TabIndex = 21;
            // 
            // grdProcedimientosSeleccionados
            // 
            this.grdProcedimientosSeleccionados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdProcedimientosSeleccionados.Location = new System.Drawing.Point(340, 93);
            this.grdProcedimientosSeleccionados.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdProcedimientosSeleccionados.Name = "grdProcedimientosSeleccionados";
            this.grdProcedimientosSeleccionados.RowHeadersWidth = 51;
            this.grdProcedimientosSeleccionados.RowTemplate.Height = 24;
            this.grdProcedimientosSeleccionados.Size = new System.Drawing.Size(237, 181);
            this.grdProcedimientosSeleccionados.TabIndex = 19;
            // 
            // grdProcedimientosDisponibles
            // 
            this.grdProcedimientosDisponibles.AllowUserToAddRows = false;
            this.grdProcedimientosDisponibles.AllowUserToDeleteRows = false;
            this.grdProcedimientosDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdProcedimientosDisponibles.Location = new System.Drawing.Point(15, 93);
            this.grdProcedimientosDisponibles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdProcedimientosDisponibles.Name = "grdProcedimientosDisponibles";
            this.grdProcedimientosDisponibles.ReadOnly = true;
            this.grdProcedimientosDisponibles.RowHeadersWidth = 51;
            this.grdProcedimientosDisponibles.RowTemplate.Height = 24;
            this.grdProcedimientosDisponibles.Size = new System.Drawing.Size(237, 181);
            this.grdProcedimientosDisponibles.TabIndex = 17;
            // 
            // lblUsuarioRegistro
            // 
            this.lblUsuarioRegistro.AutoSize = true;
            this.lblUsuarioRegistro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarioRegistro.Location = new System.Drawing.Point(15, 549);
            this.lblUsuarioRegistro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsuarioRegistro.Name = "lblUsuarioRegistro";
            this.lblUsuarioRegistro.Size = new System.Drawing.Size(162, 13);
            this.lblUsuarioRegistro.TabIndex = 40;
            this.lblUsuarioRegistro.Text = "Usuario que registró la cita:";
            this.lblUsuarioRegistro.Visible = false;
            // 
            // CitaAC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 632);
            this.Controls.Add(this.lblUsuarioRegistro);
            this.Controls.Add(this.lblAsistio);
            this.Controls.Add(this.lblConfirmado);
            this.Controls.Add(this.cmdBorrar);
            this.Controls.Add(this.cmdAgregarInstruccion);
            this.Controls.Add(this.btnAgregarProcedimiento);
            this.Controls.Add(this.cmdDevuelveInstruccion);
            this.Controls.Add(this.cmdPasaInstruccion);
            this.Controls.Add(this.cmdCerrar);
            this.Controls.Add(this.cmdGuardar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.lblFechaHora);
            this.Controls.Add(this.lblNombrePaciente);
            this.Controls.Add(this.cmdDevuelveProcedimiento);
            this.Controls.Add(this.cmdPasaProcedimiento);
            this.Controls.Add(this.grdInstruccionesSeleccionadas);
            this.Controls.Add(this.grdInstruccionesDisponibles);
            this.Controls.Add(this.grdProcedimientosSeleccionados);
            this.Controls.Add(this.grdProcedimientosDisponibles);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CitaAC";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CitaAC";
            this.Load += new System.EventHandler(this.CitaAC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdInstruccionesSeleccionadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInstruccionesDisponibles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProcedimientosSeleccionados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProcedimientosDisponibles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAsistio;
        private System.Windows.Forms.Label lblConfirmado;
        private System.Windows.Forms.Button cmdBorrar;
        private System.Windows.Forms.Button cmdAgregarInstruccion;
        private System.Windows.Forms.Button btnAgregarProcedimiento;
        private System.Windows.Forms.Button cmdDevuelveInstruccion;
        private System.Windows.Forms.Button cmdPasaInstruccion;
        private System.Windows.Forms.Button cmdCerrar;
        private System.Windows.Forms.Button cmdGuardar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label lblFechaHora;
        private System.Windows.Forms.Label lblNombrePaciente;
        private System.Windows.Forms.Button cmdDevuelveProcedimiento;
        private System.Windows.Forms.Button cmdPasaProcedimiento;
        private System.Windows.Forms.DataGridView grdInstruccionesSeleccionadas;
        private System.Windows.Forms.DataGridView grdInstruccionesDisponibles;
        private System.Windows.Forms.DataGridView grdProcedimientosSeleccionados;
        private System.Windows.Forms.DataGridView grdProcedimientosDisponibles;
        private System.Windows.Forms.Label lblUsuarioRegistro;
    }
}