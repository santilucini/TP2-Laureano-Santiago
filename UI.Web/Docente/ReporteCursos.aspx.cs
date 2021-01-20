using Business.Entities;
using Business.Logic;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web.Docente
{
    public partial class ReporteCursos : System.Web.UI.Page
    {
        Usuario Usuario
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario = (Usuario)Session["usuario"];
            if (Usuario.Persona.TipoPersona == Persona.TiposPersonas.Docente)
            {
                if (!Page.IsPostBack)
                {
                    Master.MuestroMenu();
                    LoadReport();
                }
            }
        }
        /*
        private void LoadReport()
        {
            RvInscripciones.LocalReport.ReportPath = @"D:\Facultad\3ero\.Net Tecnologias de Desarrollo de Software IDE\TP2\TP2-V10\TP2-master\UI.Desktop\FormsPorTipo\Docente\ReporteCursos.rdlc";
            RvInscripciones.ProcessingMode = ProcessingMode.Local;

            CursosBindingSource.DataSource = new CursoLogic().GetAll();

            //ReportDataSource reportDataSource = new ReportDataSource("DsInscripciones", AlumnoInscripcionBindingSource);
            this.rvCursos.LocalReport.DataSources.Clear();
            rvCursos.LocalReport.DataSources.Add(new ReportDataSource("DsCursos", CursosBindingSource));

            RvInscripciones.LocalReport.Refresh();
            this.RvInscripciones.RefreshReport();
        }
        */
        
        public void LoadReport()
        {
            RvInscripciones.LocalReport.ReportPath = @"D:\Facultad\3ero\.Net Tecnologias de Desarrollo de Software IDE\TP2\TP2-V10\TP2-master - copia\UI.Web\Docente\ReporteCursos.rdlc";
            ReportDataSource reportDataSource = new ReportDataSource("DsInscripciones", new CursoLogic().GetAll());
            RvInscripciones.LocalReport.DataSources.Add(reportDataSource);
            RvInscripciones.LocalReport.Refresh();
        }
        
    }
}