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
using UI.Desktop.FormsPorTipo.Admin;
using UI.Desktop.FormsPorTipo.Alumno;
using UI.Desktop.FormsPorTipo.Docente;

namespace UI.Desktop
{
    public partial class Login : ApplicationForm
    {
        #region Constructores

        public Login()
        {
            InitializeComponent();
        }

        #endregion

        #region Propiedades
        private Usuario _UsuarioActual;

        public Usuario UsuarioActual
        {
            get { return _UsuarioActual; }
            set { _UsuarioActual = value; }
        }

        #endregion

        #region Eventos

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            UsuarioLogic userLogic = new UsuarioLogic();
            try
            {

                if (userLogic.ValidarUser(txtUsuario.Text, txtClave.Text))
                {
                    Usuario usuarioLogeado = new Usuario();

                    usuarioLogeado = userLogic.GetOne(txtUsuario.Text, txtClave.Text);
                    if (usuarioLogeado.Habilitado)
                    {
                        MessageBox.Show("Usted ingresó correctamente al sistema.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        //Se oculta el formulario del logeo y se crea el formulario especifico segun el usuario
                        if (usuarioLogeado.Persona.TipoPersona == Persona.TiposPersonas.Alumno)
                        {
                            new FormAlumno(usuarioLogeado).ShowDialog();
                        }
                        else if (usuarioLogeado.Persona.TipoPersona == Persona.TiposPersonas.Docente)
                        {
                            new FormDocente(usuarioLogeado).ShowDialog();
                        }
                        else if (usuarioLogeado.Persona.TipoPersona == Persona.TiposPersonas.Admin)
                        {
                            new FormAdmin(usuarioLogeado).ShowDialog();
                        }
                        //Se vuelve a mostrar el formulario de logeo y se ponen los txt en nulos
                        this.txtClave.Text = "";
                        this.txtUsuario.Text = "";
                        this.Show();
                        this.txtUsuario.Focus();
                    }
                    else
                    {
                        Notificar("El Usuario no está habilitado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    Notificar("Usuario o contraseña incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtClave.Clear();
                }
            }
            catch (Exception ex)
            {
                Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        private void lnkOlvidoPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Es Ud. un usuario muy descuidado, haga memoria", "Olvidé mi contraseña", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
