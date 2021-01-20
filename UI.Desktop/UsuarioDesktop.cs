using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;
using System.ComponentModel.Design;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : UI.Desktop.ApplicationForm
    {
        #region Constructor

        public UsuarioDesktop()
        {
            InitializeComponent();
        }

        public UsuarioDesktop(ModoForm modo) : this()
        {
            // PASO 10
            // INTERNAMENTE DEBE SETEAR A MODOFORM EN EL MODO ENVIADO COMO PARAMETRO
            // ESTO SERVIRA PARA LAS ALTAS
            this.ModoFormulario = modo;
        }

        public UsuarioDesktop(int ID , ModoForm modo) : this()
        {
            this.ModoFormulario = modo;
            UsuarioLogic usuarios = new UsuarioLogic();
            UsuarioActual = usuarios.GetOne(ID);
            MapearDeDatos();
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

        #region Metodos

        public virtual void MapearDeDatos() 
        {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre.ToString();
            this.txtApellido.Text = this.UsuarioActual.Apellido.ToString();
            this.txtEmail.Text = this.UsuarioActual.Email.ToString();
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario.ToString();
            this.txtClave.Text = this.UsuarioActual.Clave.ToString();
            //this.txtConfirmarClave.Text = this.UsuarioActual.Clave.ToString();
        }

        public virtual void MapearADatos() {

            switch (this.ModoFormulario)
            {
                case ModoForm.Alta:                    
                    Usuario user = new Usuario();
                    this.UsuarioActual = user;
                    this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                    this.UsuarioActual.Nombre = this.txtNombre.Text;
                    this.UsuarioActual.Apellido = this.txtApellido.Text;
                    this.UsuarioActual.Email = this.txtEmail.Text;
                    this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                    // INGRESA LA CLAVE QUE PONGA EN EL APARTADO DE CLAVE
                    // TENDRIA QUE CORROBORAR QUE FUERA LA MISMA QUE LA CONFIRMACION
                    this.UsuarioActual.Clave = this.txtClave.Text;

                    // tiene que estar en new

                    this.UsuarioActual.State = BusinessEntity.States.New;

                    break;
                case ModoForm.Modificacion:
                    this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                    this.UsuarioActual.Nombre = this.txtNombre.Text;
                    this.UsuarioActual.Apellido = this.txtApellido.Text;
                    this.UsuarioActual.Email = this.txtEmail.Text;
                    this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                    // INGRESA LA CLAVE QUE PONGA EN EL APARTADO DE CLAVE
                    // TENDRIA QUE CORROBORAR QUE FUERA LA MISMA QUE LA CONFIRMACION
                    this.UsuarioActual.Clave = this.txtClave.Text;

                    this.UsuarioActual.State = BusinessEntity.States.Modified;

                    break;
                case ModoForm.Baja:                    
                    this.UsuarioActual.State = BusinessEntity.States.Deleted;
                    break;                                   
            }
        }
        public virtual void GuardarCambios() 
        {
            MapearADatos();
            UsuarioLogic usuario = new UsuarioLogic();
            usuario.Save(UsuarioActual);
        }
        public virtual bool Validar() 
        {
            MapearADatos();
            string errores = "";

            if (IsValidString(this.UsuarioActual.Apellido))
            { }
            else
            {
                errores += "Apellido |";
            }
            
            if (IsValidString(this.UsuarioActual.Nombre))
            { }
            else
            {
                errores += " Nombre |";
            }

            if (IsValidString(this.UsuarioActual.NombreUsuario))
            { }
            else
            {
                errores += " NombreUsuario |";          
            }

            if (IsValidString(this.UsuarioActual.Clave))
            { }
            else
            {
                errores += " Clave |";
            }

            if (Validaciones.IsValidEmail(this.UsuarioActual.Email))
            { }
            else
            {
                errores += " Email |";
            }

            if ( this.UsuarioActual.Clave.ToString().Length >= 8)
            { }
            else
            {
                errores += " Contraseña Menor a 8 Caracteres |";
            }

            // Esto no anda
            //(this.UsuarioActual.Clave.ToString() == this.txtConfirmarClave.ToString())
            //this.UsuarioActual.Clave.Equals(this.txtConfirmarClave.ToString())
            if (this.UsuarioActual.Clave.ToString() == this.txtConfirmarClave.Text.ToString())
            { }
            else
            {             
                errores += " Contraseñas No Coinciden |";
            }

            if (IsValidString(errores))
            {
                Notificar("Datos Incorrectos", "Los datos incorrectos son :" + errores, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                Notificar("Datos Correctos", "Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }

        }
        #region ValidarCampos
        bool IsValidPass(string str)
        {
            try
            {
                if (str.Length >= 8)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        bool IsValidString(string str)
        {
            try
            {
                if (String.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        #endregion
        /*
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        

        
        public void Notificar(string titulo, string mensaje, MessageBoxButtons
        botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }
        public void Notificar(string mensaje, MessageBoxButtons botones,
        MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }
        */
        #endregion

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UsuarioDesktop_Load(object sender, EventArgs e)
        {
            switch (this.ModoFormulario)
            {
                case ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;
            }
        }
    }
}
