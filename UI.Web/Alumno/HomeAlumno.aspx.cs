using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web.Alumno
{
    public partial class HomeAlumno : System.Web.UI.Page
    {
        Usuario Usu
        {
            get; set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Usu = (Usuario)Session["usuario"];
            lblNombreUsuario.Text = Usu.Nombre + ","+ Usu.Apellido;
            Master.MuestroMenu();
        }

    }
}