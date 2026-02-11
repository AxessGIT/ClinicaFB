namespace ClinicaFB.PuntoDeVenta
{
    partial class CorteReportes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CorteReportes));
            this.cmdSalir = new System.Windows.Forms.Button();
            this.cmdGenerar = new System.Windows.Forms.Button();
            this.chkCorte = new System.Windows.Forms.CheckBox();
            this.chkArticulosVendidos = new System.Windows.Forms.CheckBox();
            this.chkFormasDePago = new System.Windows.Forms.CheckBox();
            this.txtFondoInicial = new Syncfusion.Windows.Forms.Tools.CurrencyEdit();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtFondoInicial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFondoInicial.TextBox)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSalir.Location = new System.Drawing.Point(209, 130);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(171, 40);
            this.cmdSalir.TabIndex = 3;
            this.cmdSalir.Text = "&Salir";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // cmdGenerar
            // 
            this.cmdGenerar.Image = ((System.Drawing.Image)(resources.GetObject("cmdGenerar.Image")));
            this.cmdGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGenerar.Location = new System.Drawing.Point(32, 130);
            this.cmdGenerar.Name = "cmdGenerar";
            this.cmdGenerar.Size = new System.Drawing.Size(171, 40);
            this.cmdGenerar.TabIndex = 2;
            this.cmdGenerar.Text = "&Generar reportes";
            this.cmdGenerar.UseVisualStyleBackColor = true;
            this.cmdGenerar.Click += new System.EventHandler(this.cmdGenerar_Click);
            // 
            // chkCorte
            // 
            this.chkCorte.AutoSize = true;
            this.chkCorte.Checked = true;
            this.chkCorte.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCorte.Location = new System.Drawing.Point(12, 26);
            this.chkCorte.Name = "chkCorte";
            this.chkCorte.Size = new System.Drawing.Size(57, 20);
            this.chkCorte.TabIndex = 4;
            this.chkCorte.Text = "Corte";
            this.chkCorte.UseVisualStyleBackColor = true;
            // 
            // chkArticulosVendidos
            // 
            this.chkArticulosVendidos.AutoSize = true;
            this.chkArticulosVendidos.Checked = true;
            this.chkArticulosVendidos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkArticulosVendidos.Location = new System.Drawing.Point(12, 52);
            this.chkArticulosVendidos.Name = "chkArticulosVendidos";
            this.chkArticulosVendidos.Size = new System.Drawing.Size(129, 20);
            this.chkArticulosVendidos.TabIndex = 5;
            this.chkArticulosVendidos.Text = "Artículos vendidos";
            this.chkArticulosVendidos.UseVisualStyleBackColor = true;
            // 
            // chkFormasDePago
            // 
            this.chkFormasDePago.AutoSize = true;
            this.chkFormasDePago.Checked = true;
            this.chkFormasDePago.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFormasDePago.Location = new System.Drawing.Point(12, 78);
            this.chkFormasDePago.Name = "chkFormasDePago";
            this.chkFormasDePago.Size = new System.Drawing.Size(119, 20);
            this.chkFormasDePago.TabIndex = 6;
            this.chkFormasDePago.Text = "Formas de pago";
            this.chkFormasDePago.UseVisualStyleBackColor = true;
            // 
            // txtFondoInicial
            // 
            this.txtFondoInicial.BeforeTouchSize = new System.Drawing.Size(121, 24);
            this.txtFondoInicial.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFondoInicial.Location = new System.Drawing.Point(280, 22);
            this.txtFondoInicial.Name = "txtFondoInicial";
            this.txtFondoInicial.SelectionLength = 5;
            this.txtFondoInicial.Size = new System.Drawing.Size(121, 24);
            this.txtFondoInicial.TabIndex = 1;
            // 
            // 
            // 
            this.txtFondoInicial.TextBox.AccessibilityEnabled = true;
            this.txtFondoInicial.TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFondoInicial.TextBox.DecimalValue = new decimal(new int[] {
            100,
            0,
            0,
            131072});
            this.txtFondoInicial.TextBox.Location = new System.Drawing.Point(3, 4);
            this.txtFondoInicial.TextBox.Name = "";
            this.txtFondoInicial.TextBox.Size = new System.Drawing.Size(91, 16);
            this.txtFondoInicial.TextBox.TabIndex = 0;
            this.txtFondoInicial.TextBox.Text = "$1.00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(193, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fondo inicial";
            // 
            // CorteReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 186);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFondoInicial);
            this.Controls.Add(this.chkFormasDePago);
            this.Controls.Add(this.chkArticulosVendidos);
            this.Controls.Add(this.chkCorte);
            this.Controls.Add(this.cmdGenerar);
            this.Controls.Add(this.cmdSalir);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimizeBox = false;
            this.Name = "CorteReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes del corte";
            this.Load += new System.EventHandler(this.CorteReportes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtFondoInicial.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFondoInicial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.Button cmdGenerar;
        private System.Windows.Forms.CheckBox chkCorte;
        private System.Windows.Forms.CheckBox chkArticulosVendidos;
        private System.Windows.Forms.CheckBox chkFormasDePago;
        private Syncfusion.Windows.Forms.Tools.CurrencyEdit txtFondoInicial;
        private System.Windows.Forms.Label label1;
    }
}