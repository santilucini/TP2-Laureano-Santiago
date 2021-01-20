using Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web.Admin
{
    public partial class HomeAdmin : System.Web.UI.Page
    {
        public Usuario Usuario
        {
            get; set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario = (Usuario)Session["usuario"];
            if (Usuario.Persona.TipoPersona == Persona.TiposPersonas.Admin)
            {
                Master.MuestroMenu();
            }
        }
    }
}