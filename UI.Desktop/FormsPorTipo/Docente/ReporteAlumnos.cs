using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;
using Microsoft.Reporting.WinForms;

namespace UI.Desktop.FormsPorTipo.Docente
{
    public partial class ReporteAlumnos : Form
    {
        Usuario Usuario { get; set; }
        public ReporteAlumnos(Usuario user)
        {
            InitializeComponent();
            Usuario = user;
        }

        private void ReporteAlumnoForm_Load(object sender, EventArgs e)
        {
            RvInscripciones.LocalReport.ReportPath = @"D:\Facultad\3ero\.Net Tecnologias de Desarrollo de Software IDE\TP2\TP2-V10\TP2-master\UI.Desktop\FormsPorTipo\Docente\ReporteAlumnos.rdlc";
            RvInscripciones.ProcessingMode = ProcessingMode.Local;

            InscripcionBindingSource.DataSource = new AlumnoInscripcionLogic().GetAll();

            //ReportDataSource reportDataSource = new ReportDataSource("DsInscripciones", AlumnoInscripcionBindingSource);
            this.RvInscripciones.LocalReport.DataSources.Clear();
            RvInscripciones.LocalReport.DataSources.Add(new ReportDataSource("DsInscripciones", InscripcionBindingSource));

            RvInscripciones.LocalReport.Refresh();
            this.RvInscripciones.RefreshReport();

        }

        private void ReporteAlumnos_Load(object sender, EventArgs e)
        {

        }
    }
}
