using Business.Logic;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop.FormsPorTipo.Docente
{
    public partial class ReporteCursos : Form
    {
        public ReporteCursos()
        {
            InitializeComponent();
        }

        private void ReporteCursos_Load(object sender, EventArgs e)
        {
            rvCursos.LocalReport.ReportPath = @"C:\Users\Laureano\source\repos\TP2-Laureano-Santiago\UI.Desktop\FormsPorTipo\Docente\ReporteCursos.rdlc";//@"D:\Facultad\3ero\.Net Tecnologias de Desarrollo de Software IDE\TP2\TP2-V10\TP2-master\UI.Desktop\FormsPorTipo\Docente\ReporteCursos.rdlc";
            rvCursos.ProcessingMode = ProcessingMode.Local;

            CursosBindingSource.DataSource = new CursoLogic().GetAll();

            //ReportDataSource reportDataSource = new ReportDataSource("DsInscripciones", AlumnoInscripcionBindingSource);
            this.rvCursos.LocalReport.DataSources.Clear();
            rvCursos.LocalReport.DataSources.Add(new ReportDataSource("DsCursos", CursosBindingSource));

            rvCursos.LocalReport.Refresh();
            this.rvCursos.RefreshReport();
        }
    }
}
