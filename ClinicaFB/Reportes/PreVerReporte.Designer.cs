namespace ClinicaFB.Reportes
{
    partial class PreVerReporte
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
            this.Viewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // Viewer
            // 
            this.Viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Viewer.Location = new System.Drawing.Point(0, 0);
            this.Viewer.Name = "Viewer";
            this.Viewer.ServerReport.BearerToken = null;
            this.Viewer.Size = new System.Drawing.Size(726, 573);
            this.Viewer.TabIndex = 0;
            // 
            // PreVerReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 573);
            this.Controls.Add(this.Viewer);
            this.Name = "PreVerReporte";
            this.Text = "PreVerReporte";
            this.Load += new System.EventHandler(this.PreVerReporte_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer Viewer;
    }
}