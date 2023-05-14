
namespace ClinicaFB.Agenda
{
    partial class FechasDesbloquear
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FechasDesbloquear));
            this.cmdSalir = new System.Windows.Forms.Button();
            this.cmdDesBloquear = new System.Windows.Forms.Button();
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
            this.SuspendLayout();
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSalir.Location = new System.Drawing.Point(228, 228);
            this.cmdSalir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(142, 49);
            this.cmdSalir.TabIndex = 27;
            this.cmdSalir.Text = "&Cerrar";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // cmdDesBloquear
            // 
            this.cmdDesBloquear.Image = ((System.Drawing.Image)(resources.GetObject("cmdDesBloquear.Image")));
            this.cmdDesBloquear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdDesBloquear.Location = new System.Drawing.Point(79, 228);
            this.cmdDesBloquear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdDesBloquear.Name = "cmdDesBloquear";
            this.cmdDesBloquear.Size = new System.Drawing.Size(142, 49);
            this.cmdDesBloquear.TabIndex = 26;
            this.cmdDesBloquear.Text = "&Desbloquear";
            this.cmdDesBloquear.UseVisualStyleBackColor = true;
            this.cmdDesBloquear.Click += new System.EventHandler(this.cmdDesBloquear_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 16);
            this.label6.TabIndex = 24;
            this.label6.Text = "Hora final";
            // 
            // cboHorasFinales
            // 
            this.cboHorasFinales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHorasFinales.FormattingEnabled = true;
            this.cboHorasFinales.Location = new System.Drawing.Point(119, 177);
            this.cboHorasFinales.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cboHorasFinales.Name = "cboHorasFinales";
            this.cboHorasFinales.Size = new System.Drawing.Size(285, 24);
            this.cboHorasFinales.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "Hora inicial";
            // 
            // cboHorasIniciales
            // 
            this.cboHorasIniciales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHorasIniciales.FormattingEnabled = true;
            this.cboHorasIniciales.Location = new System.Drawing.Point(119, 144);
            this.cboHorasIniciales.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cboHorasIniciales.Name = "cboHorasIniciales";
            this.cboHorasIniciales.Size = new System.Drawing.Size(285, 24);
            this.cboHorasIniciales.TabIndex = 23;
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Location = new System.Drawing.Point(119, 112);
            this.dtpFechaFinal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(285, 23);
            this.dtpFechaFinal.TabIndex = 21;
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.Location = new System.Drawing.Point(119, 80);
            this.dtpFechaInicial.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Size = new System.Drawing.Size(285, 23);
            this.dtpFechaInicial.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "Fecha final";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "Fecha inicial";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Recurso";
            // 
            // cboRecursos
            // 
            this.cboRecursos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRecursos.FormattingEnabled = true;
            this.cboRecursos.Location = new System.Drawing.Point(119, 47);
            this.cboRecursos.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cboRecursos.Name = "cboRecursos";
            this.cboRecursos.Size = new System.Drawing.Size(285, 24);
            this.cboRecursos.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 16);
            this.label1.TabIndex = 14;
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
            this.cboTipos.Location = new System.Drawing.Point(119, 14);
            this.cboTipos.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cboTipos.Name = "cboTipos";
            this.cboTipos.Size = new System.Drawing.Size(285, 24);
            this.cboTipos.TabIndex = 15;
            this.cboTipos.SelectedIndexChanged += new System.EventHandler(this.cboTipos_SelectedIndexChanged);
            // 
            // FechasDesbloquear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 301);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.cmdDesBloquear);
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
            this.Name = "FechasDesbloquear";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Desbloquear fechas";
            this.Load += new System.EventHandler(this.FechasDesbloquear_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.Button cmdDesBloquear;
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