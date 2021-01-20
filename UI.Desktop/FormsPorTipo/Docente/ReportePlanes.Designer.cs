namespace UI.Desktop.FormsPorTipo.Docente
{
    partial class ReportePlanes
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
            this.RvPlanes = new Microsoft.Reporting.WinForms.ReportViewer();
            this.PlanesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PlanesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // RvPlanes
            // 
            this.RvPlanes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RvPlanes.LocalReport.ReportEmbeddedResource = "UI.Desktop.FormsPorTipo.Docente.ReportePlanes.rdlc";
            this.RvPlanes.Location = new System.Drawing.Point(0, 0);
            this.RvPlanes.Name = "RvPlanes";
            this.RvPlanes.ServerReport.BearerToken = null;
            this.RvPlanes.Size = new System.Drawing.Size(800, 450);
            this.RvPlanes.TabIndex = 0;
            // 
            // PlanesBindingSource
            // 
            this.PlanesBindingSource.DataSource = typeof(Business.Entities.Plan);
            // 
            // ReportePlanes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RvPlanes);
            this.Name = "ReportePlanes";
            this.Text = "ReportePlanes";
            this.Load += new System.EventHandler(this.ReportePlanes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PlanesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer RvPlanes;
        private System.Windows.Forms.BindingSource PlanesBindingSource;
    }
}