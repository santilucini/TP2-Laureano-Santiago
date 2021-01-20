using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using System.Windows.Forms;
using Util;

namespace UI.Web
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //btnHome.ServerClick += new System.EventHandler(this.btnHome_Click);
            //btnLogout.ServerClick += new System.EventHandler(this.btnLogout_Click);
            //btnContacto.ServerClick += new System.EventHandler(this.btnContacto_Click);
            
        }

        public void MuestroMenu()
        {
            Usuario usu = (Usuario)Session["usuario"];
            if (usu != null)
            {
                switch (usu.Persona.TipoPersona)
                {
                    case Persona.TiposPersonas.Admin:
                        MenuAdmin.Visible = true;
                        break;
                    case Persona.TiposPersonas.Alumno:
                        MenuAlumno.Visible = true;
                        break;
                    case Persona.TiposPersonas.Docente:
                        MenuDocente.Visible = true;
                        break;
                }

                this.btnLogout.Visible = true;
                this.btnHome.Visible = true;
            }
        }

        protected void MenuAdmin_MenuItemClick(object sender, MenuEventArgs e)
        {

        }
        protected void MenuAlumno_MenuItemClick(object sender, MenuEventArgs e)
        {

        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            if ((Usuario)Session["usuario"] != null)
            {
                Usuario usu = (Usuario)Session["usuario"];
                switch (usu.Persona.TipoPersona)
                {
                    case Persona.TiposPersonas.Admin:
                        Response.Redirect("~/Admin/HomeAdmin.aspx", false);
                        // Falta crearlo usa la MasterPage
                        break;
                    case Persona.TiposPersonas.Alumno:
                        Response.Redirect("~/Alumno/HomeAlumno", false);
                        // Falta crearlo usa la MasterPage
                        break;
                    case Persona.TiposPersonas.Docente:
                        Response.Redirect("~/Docente/HomeDocente", false);
                        // Falta crearlo usa la MasterPage
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Response.Redirect("~/Basico/login.aspx", false);
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["usuario"] = null;
            Response.Redirect("~/Basico/login.aspx", false);
        }
    }
}