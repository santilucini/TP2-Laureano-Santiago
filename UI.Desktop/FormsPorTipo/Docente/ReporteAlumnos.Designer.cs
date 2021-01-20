namespace UI.Desktop.FormsPorTipo.Docente
{
    partial class ReporteAlumnos
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.RvInscripciones = new Microsoft.Reporting.WinForms.ReportViewer();
            this.InscripcionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.InscripcionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // RvInscripciones
            // 
            this.RvInscripciones.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DsInscripciones";
            this.RvInscripciones.LocalReport.DataSources.Add(reportDataSource1);
            this.RvInscripciones.LocalReport.ReportEmbeddedResource = "UI.Desktop.FormsPorTipo.Docente.ReporteAlumnos.rdlc";
            this.RvInscripciones.Location = new System.Drawing.Point(0, 0);
            this.RvInscripciones.Name = "RvInscripciones";
            this.RvInscripciones.ServerReport.BearerToken = null;
            this.RvInscripciones.Size = new System.Drawing.Size(800, 450);
            this.RvInscripciones.TabIndex = 1;
            this.RvInscripciones.Load += new System.EventHandler(this.ReporteAlumnoForm_Load);
            // 
            // ReporteAlumnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RvInscripciones);
            this.Name = "ReporteAlumnos";
            this.Text = "ReporteAlumnos";
            this.Load += new System.EventHandler(this.ReporteAlumnos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InscripcionBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer RvInscripciones;
        private System.Windows.Forms.BindingSource InscripcionBindingSource;
    }
}