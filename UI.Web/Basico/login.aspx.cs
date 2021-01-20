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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BtnIngresar.ServerClick += new System.EventHandler(this.BtnIngresar_Click);
        }

        protected void lnkRecordarClave_Click(object sender, EventArgs e)
        {

        }

        private UsuarioLogic _logic;

        public UsuarioLogic Usuariologic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new UsuarioLogic();
                }
                return _logic;
            }
        }

        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            if (Usuariologic.verificoLogin(txtUsuario.Text, txtClave.Text))
            {
                Usuario usu = Usuariologic.GetOne(txtUsuario.Text, txtClave.Text);
                //Se asigna el usuario a la sesion para no perderlo
                Session["usuario"] = usu;
                switch (usu.Persona.TipoPersona)
                {
                    case Persona.TiposPersonas.Admin:
                        Response.Redirect("~/Admin/HomeAdmin.aspx", false);
                        break;
                    case Persona.TiposPersonas.Alumno:
                        Response.Redirect("~/Alumno/HomeAlumno.aspx", false);
                        break;
                    case Persona.TiposPersonas.Docente:
                        Response.Redirect("~/Docente/HomeDocente.aspx", false);
                        break;

                    default:
                        Response.Redirect("~/Login.aspx", false);
                        break;
                }
            }
            else
            {

                MessageBox.Show("Usuario o Contraseña incorrectos");
            }
            return;
        }
    }

}