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
            UsuarioLogic user = new UsuarioLogic();
            try
            {

                if (user.ValidarUser(txtUsuario.Text, txtClave.Text))
                {
                    UsuarioActual = user.GetOneByNombreUsuario(txtUsuario.Text);
                    if (UsuarioActual.Habilitado)
                    {
                        DialogResult = DialogResult.OK;
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


    }
}
