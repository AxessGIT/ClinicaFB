
namespace ClinicaFB.Agenda
{
    partial class FechasBloquear
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FechasBloquear));
            this.cmdSalir = new System.Windows.Forms.Button();
            this.cmdBloquear = new System.Windows.Forms.Button();
            this.btnAgregarMotivoBloqueo = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.grdMotivos = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.cboHorasFinales = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboHorasIniciales = new System.Windows.Forms.ComboBox();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboRecursos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTipos = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdMotivos)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSalir.Location = new System.Drawing.Point(308, 238);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(122, 40);
            this.cmdSalir.TabIndex = 33;
            this.cmdSalir.Text = "&Cerrar";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // cmdBloquear
            // 
            this.cmdBloquear.Image = ((System.Drawing.Image)(resources.GetObject("cmdBloquear.Image")));
            this.cmdBloquear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdBloquear.Location = new System.Drawing.Point(180, 238);
            this.cmdBloquear.Name = "cmdBloquear";
            this.cmdBloquear.Size = new System.Drawing.Size(122, 40);
            this.cmdBloquear.TabIndex = 32;
            this.cmdBloquear.Text = "&Bloquear";
            this.cmdBloquear.UseVisualStyleBackColor = true;
            this.cmdBloquear.Click += new System.EventHandler(this.cmdBloquear_Click);
            // 
            // btnAgregarMotivoBloqueo
            // 
            this.btnAgregarMotivoBloqueo.Location = new System.Drawing.Point(561, 0);
            this.btnAgregarMotivoBloqueo.Name = "btnAgregarMotivoBloqueo";
            this.btnAgregarMotivoBloqueo.Size = new System.Drawing.Size(27, 23);
            this.btnAgregarMotivoBloqueo.TabIndex = 31;
            this.btnAgregarMotivoBloqueo.Text = "+";
            this.btnAgregarMotivoBloqueo.UseVisualStyleBackColor = true;
            this.btnAgregarMotivoBloqueo.Click += new System.EventHandler(this.btnAgregarMotivoBloqueo_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(410, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Razón del bloqueo";
            // 
            // grdMotivos
            // 
            this.grdMotivos.AllowUserToAddRows = false;
            this.grdMotivos.AllowUserToDeleteRows = false;
            this.grdMotivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMotivos.Location = new System.Drawing.Point(410, 29);
            this.grdMotivos.Margin = new System.Windows.Forms.Padding(2);
            this.grdMotivos.Name = "grdMotivos";
            this.grdMotivos.ReadOnly = true;
            this.grdMotivos.RowHeadersWidth = 51;
            this.grdMotivos.RowTemplate.Height = 24;
            this.grdMotivos.Size = new System.Drawing.Size(178, 147);
            this.grdMotivos.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 16);
            this.label6.TabIndex = 27;
            this.label6.Text = "Hora final";
            // 
            // cboHorasFinales
            // 
            this.cboHorasFinales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHorasFinales.FormattingEnabled = true;
            this.cboHorasFinales.Location = new System.Drawing.Point(116, 181);
            this.cboHorasFinales.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboHorasFinales.Name = "cboHorasFinales";
            this.cboHorasFinales.Size = new System.Drawing.Size(245, 24);
            this.cboHorasFinales.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 16);
            this.label5.TabIndex = 25;
            this.label5.Text = "Hora inicial";
            // 
            // cboHorasIniciales
            // 
            this.cboHorasIniciales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHorasIniciales.FormattingEnabled = true;
            this.cboHorasIniciales.Location = new System.Drawing.Point(116, 147);
            this.cboHorasIniciales.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboHorasIniciales.Name = "cboHorasIniciales";
            this.cboHorasIniciales.Size = new System.Drawing.Size(245, 24);
            this.cboHorasIniciales.TabIndex = 26;
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Location = new System.Drawing.Point(116, 114);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(245, 23);
            this.dtpFechaFinal.TabIndex = 24;
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.Location = new System.Drawing.Point(116, 81);
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Size = new System.Drawing.Size(245, 23);
            this.dtpFechaInicial.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 16);
            this.label4.TabIndex = 23;
            this.label4.Text = "Fecha final";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 16);
            this.label3.TabIndex = 21;
            this.label3.Text = "Fecha inicial";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "Recurso";
            // 
            // cboRecursos
            // 
            this.cboRecursos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRecursos.FormattingEnabled = true;
            this.cboRecursos.Location = new System.Drawing.Point(116, 47);
            this.cboRecursos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboRecursos.Name = "cboRecursos";
            this.cboRecursos.Size = new System.Drawing.Size(245, 24);
            this.cboRecursos.TabIndex = 20;
            this.cboRecursos.SelectedIndexChanged += new System.EventHandler(this.cboRecursos_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Tipo de recurso";
            // 
            // cboTipos
            // 
            this.cboTipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipos.FormattingEnabled = true;
            this.cboTipos.Items.AddRange(new object[] {
            "Doctor",
            "Equipo",
            "Cuarto"});
            this.cboTipos.Location = new System.Drawing.Point(116, 13);
            this.cboTipos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboTipos.Name = "cboTipos";
            this.cboTipos.Size = new System.Drawing.Size(245, 24);
            this.cboTipos.TabIndex = 18;
            this.cboTipos.SelectedIndexChanged += new System.EventHandler(this.cboTipos_SelectedIndexChanged);
            // 
            // FechasBloquear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 319);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.cmdBloquear);
            this.Controls.Add(this.btnAgregarMotivoBloqueo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.grdMotivos);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboHorasFinales);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboHorasIniciales);
            this.Controls.Add(this.dtpFechaFinal);
            this.Controls.Add(this.dtpFechaInicial);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboRecursos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboTipos);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FechasBloquear";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bloquear fechas";
            this.Load += new System.EventHandler(this.FechasBloquear_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdMotivos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.Button cmdBloquear;
        private System.Windows.Forms.Button btnAgregarMotivoBloqueo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView grdMotivos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboHorasFinales;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboHorasIniciales;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.DateTimePicker dtpFechaInicial;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboRecursos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTipos;
    }
}