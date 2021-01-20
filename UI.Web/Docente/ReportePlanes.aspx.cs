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
    public partial class ReportePlanes : System.Web.UI.Page
    {
        Usuario Usuario { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario = (Usuario)Session["usuario"];
            if (Usuario.Persona.TipoPersona == Persona.TiposPersonas.Docente)
            {
                if (!Page.IsPostBack)
                {
                    //Master.MuestroMenu();
                    LoadReport();
                }
            }
        }

        public void LoadReport()
        {
            rvPlanes.LocalReport.ReportPath = @"D:\Facultad\3ero\.Net Tecnologias de Desarrollo de Software IDE\TP2\TP2-V10\TP2-master - copia\UI.Web\Docente\ReportePlanes.rdlc";
            ReportDataSource reportDataSource = new ReportDataSource("DsPlanes", new PlanLogic().GetAll());
            rvPlanes.LocalReport.DataSources.Clear();
            rvPlanes.LocalReport.DataSources.Add(reportDataSource);
            rvPlanes.LocalReport.Refresh();
}

    }
}