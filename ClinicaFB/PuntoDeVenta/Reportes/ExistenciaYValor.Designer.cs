namespace ClinicaFB.PuntoDeVenta.Reportes
{
    partial class ExistenciaYValor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExistenciaYValor));
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cboAlmacenes = new Syncfusion.WinForms.ListView.SfComboBox();
            this.lblAlmacen = new System.Windows.Forms.Label();
            this.cmdGenerar = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.pbAvance = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cboAlmacenes)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(98, 49);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(121, 23);
            this.dtpFecha.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Fecha";
            // 
            // cboAlmacenes
            // 
            this.cboAlmacenes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboAlmacenes.AutoCompleteSuggestMode = Syncfusion.WinForms.ListView.Enums.AutoCompleteSuggestMode.Contains;
            this.cboAlmacenes.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.cboAlmacenes.DropDownStyle = Syncfusion.WinForms.ListView.Enums.DropDownStyle.DropDownList;
            this.cboAlmacenes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboAlmacenes.Location = new System.Drawing.Point(98, 12);
            this.cboAlmacenes.Name = "cboAlmacenes";
            this.cboAlmacenes.Size = new System.Drawing.Size(317, 28);
            this.cboAlmacenes.Style.DropDownStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cboAlmacenes.Style.EditorStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboAlmacenes.Style.ReadOnlyEditorStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboAlmacenes.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboAlmacenes.Style.TokenStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboAlmacenes.TabIndex = 10;
            // 
            // lblAlmacen
            // 
            this.lblAlmacen.AutoSize = true;
            this.lblAlmacen.Location = new System.Drawing.Point(35, 18);
            this.lblAlmacen.Name = "lblAlmacen";
            this.lblAlmacen.Size = new System.Drawing.Size(56, 16);
            this.lblAlmacen.TabIndex = 9;
            this.lblAlmacen.Text = "Almacen";
            // 
            // cmdGenerar
            // 
            this.cmdGenerar.Image = ((System.Drawing.Image)(resources.GetObject("cmdGenerar.Image")));
            this.cmdGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGenerar.Location = new System.Drawing.Point(86, 151);
            this.cmdGenerar.Name = "cmdGenerar";
            this.cmdGenerar.Size = new System.Drawing.Size(115, 48);
            this.cmdGenerar.TabIndex = 16;
            this.cmdGenerar.Text = "&Generar";
            this.cmdGenerar.UseVisualStyleBackColor = true;
            this.cmdGenerar.Click += new System.EventHandler(this.cmdGenerar_Click);
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSalir.Location = new System.Drawing.Point(207, 151);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(115, 48);
            this.cmdSalir.TabIndex = 17;
            this.cmdSalir.Text = "&Salir";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // pbAvance
            // 
            this.pbAvance.Location = new System.Drawing.Point(12, 103);
            this.pbAvance.Name = "pbAvance";
            this.pbAvance.Size = new System.Drawing.Size(406, 23);
            this.pbAvance.TabIndex = 19;
            this.pbAvance.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(9, 84);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(41, 16);
            this.lblStatus.TabIndex = 18;
            this.lblStatus.Text = "label3";
            this.lblStatus.Visible = false;
            // 
            // ExistenciaYValor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 211);
            this.Controls.Add(this.pbAvance);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboAlmacenes);
            this.Controls.Add(this.lblAlmacen);
            this.Controls.Add(this.cmdGenerar);
            this.Controls.Add(this.cmdSalir);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ExistenciaYValor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Existencia y valor del inventario";
            this.Load += new System.EventHandler(this.rptExistenciaYValor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboAlmacenes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label1;
        private Syncfusion.WinForms.ListView.SfComboBox cboAlmacenes;
        private System.Windows.Forms.Label lblAlmacen;
        private System.Windows.Forms.Button cmdGenerar;
        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.ProgressBar pbAvance;
        private System.Windows.Forms.Label lblStatus;
    }
}