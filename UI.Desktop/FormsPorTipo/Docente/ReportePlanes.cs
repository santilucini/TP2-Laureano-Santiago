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
    public partial class ReportePlanes : Form
    {
        public ReportePlanes()
        {
            InitializeComponent();
        }

        private void ReportePlanes_Load(object sender, EventArgs e)
        {

            RvPlanes.LocalReport.ReportPath = @"C:\Users\Laureano\source\repos\TP2-Laureano-Santiago\UI.Desktop\FormsPorTipo\Docente\ReportePlanes.rdlc";//@"D:\Facultad\3ero\.Net Tecnologias de Desarrollo de Software IDE\TP2\TP2-V10\TP2-master\UI.Desktop\FormsPorTipo\Docente\ReportePlanes.rdlc";
            RvPlanes.ProcessingMode = ProcessingMode.Local;

            PlanesBindingSource.DataSource = new PlanLogic().GetAll();

            //ReportDataSource reportDataSource = new ReportDataSource("DsInscripciones", AlumnoInscripcionBindingSource);
            this.RvPlanes.LocalReport.DataSources.Clear();
            RvPlanes.LocalReport.DataSources.Add(new ReportDataSource("DsPlanes", PlanesBindingSource));

            RvPlanes.LocalReport.Refresh();
            this.RvPlanes.RefreshReport();
        }
    }
}
