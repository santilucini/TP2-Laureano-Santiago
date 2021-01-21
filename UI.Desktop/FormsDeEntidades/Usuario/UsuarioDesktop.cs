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
using Util;
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

        public void cargoComboBox()
        {
            cbPlanes.DataSource = new PlanLogic().GetAll();
            cbPlanes.ValueMember = "ID";
            cbPlanes.DisplayMember = "Descripcion";
            cbTiposPersonas.DataSource = Persona.GetAllTipos();
        }
        public override void MapearDeDatos() 
        {
            // Parte de Usuario
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario.ToString();

            // Parte de Persona
            this.txtNombre.Text = this.UsuarioActual.Persona.Nombre.ToString();
            this.txtApellido.Text = this.UsuarioActual.Persona.Apellido.ToString();
            this.txtLegajo.Text = this.UsuarioActual.Persona.Legajo.ToString();
            this.txtDireccion.Text = this.UsuarioActual.Persona.Direccion;
            this.txtEmail.Text = this.UsuarioActual.Persona.Email.ToString();
            this.txtTelefono.Text = this.UsuarioActual.Persona.Telefono;
            this.cbPlanes.SelectedValue = this.UsuarioActual.Persona.IDPlan;
            this.dtpFechaNac.Value = this.UsuarioActual.Persona.FechaNacimiento;
            this.cbTiposPersonas.SelectedItem = this.UsuarioActual.Persona.TipoPersona;

            this.txtClave.Text = this.UsuarioActual.Clave.ToString();
            //this.txtConfirmarClave.Text = this.UsuarioActual.Clave.ToString();
        }

        public void CastearDatosUsuario()
        {
            //Datos Usuario
            this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
            this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
            this.UsuarioActual.Clave = this.txtClave.Text;
            //Datos Persona
            this.UsuarioActual.Persona.Nombre = this.txtNombre.Text;
            this.UsuarioActual.Persona.Apellido = this.txtApellido.Text;
            this.UsuarioActual.Persona.FechaNacimiento = this.dtpFechaNac.Value;
            this.UsuarioActual.Persona.Direccion = this.txtDireccion.Text;
            this.UsuarioActual.Persona.Telefono = this.txtTelefono.Text;
            this.UsuarioActual.Persona.Email = this.txtEmail.Text;
            this.UsuarioActual.Persona.Legajo = Int32.Parse(this.txtLegajo.Text);
            //Se castea a el objeto Plan que se selecciono, ya que el DataSource del ComboBox son objetos
            this.UsuarioActual.Persona.Plan = (Plan)this.cbPlanes.SelectedItem;
            //Se verifica el tipo de persona seleccionada
            this.UsuarioActual.Persona.TipoPersona = (Persona.TiposPersonas)cbTiposPersonas.SelectedItem;
        }

        public override void MapearADatos() {

            switch (this.ModoFormulario)
            {
                case ApplicationForm.ModoForm.Alta:                    
                    Usuario user = new Usuario();
                    this.UsuarioActual = user;
                    CastearDatosUsuario();
                    /* REFORMADO
                    this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                    this.UsuarioActual.Nombre = this.txtNombre.Text;
                    this.UsuarioActual.Apellido = this.txtApellido.Text;
                    this.UsuarioActual.Email = this.txtEmail.Text;
                    this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                    // INGRESA LA CLAVE QUE PONGA EN EL APARTADO DE CLAVE
                    // TENDRIA QUE CORROBORAR QUE FUERA LA MISMA QUE LA CONFIRMACION
                    this.UsuarioActual.Clave = this.txtClave.Text;
                    */
                    // tiene que estar en new
                    this.UsuarioActual.State = Usuario.States.New;

                    break;
                case ApplicationForm.ModoForm.Modificacion:
                    CastearDatosUsuario();
                    /* REFORMADO
                    this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                    this.UsuarioActual.Nombre = this.txtNombre.Text;
                    this.UsuarioActual.Apellido = this.txtApellido.Text;
                    this.UsuarioActual.Email = this.txtEmail.Text;
                    this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                    // INGRESA LA CLAVE QUE PONGA EN EL APARTADO DE CLAVE
                    // TENDRIA QUE CORROBORAR QUE FUERA LA MISMA QUE LA CONFIRMACION
                    this.UsuarioActual.Clave = this.txtClave.Text;
                    */
                    this.UsuarioActual.State = BusinessEntity.States.Modified;

                    break;
                case ApplicationForm.ModoForm.Baja:                    
                    this.UsuarioActual.State = BusinessEntity.States.Deleted;
                    break;
                default:
                    break;
            }
        }
        public override void GuardarCambios() 
        {
            MapearADatos();
            UsuarioLogic usuario = new UsuarioLogic();
            usuario.Save(UsuarioActual);
        }

        /* VALIDAR VIEJO
        public override bool Validar() 
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

        */

        public bool validoDatos()
        {
            bool validador = true;
            //Se valida el nombre de la persona
            if (Validaciones.EstaVacioCampo(txtNombre.Text))
            {
                if (Validaciones.VerificoLongitudCampo(txtNombre.Text))
                {
                    if (!Validaciones.EsCampoValido(txtNombre.Text))
                    {
                        errProvider.SetError(txtNombre, "El nombre ingresado no es valido");
                        validador = false;
                    }
                }
                else
                {
                    errProvider.SetError(txtNombre, "El campo debe contener menos de 50 caracteres");
                    validador = false;
                }
            }
            else
            {
                errProvider.SetError(txtNombre, "Este campo no puede estar vacio");
                validador = false;
            }
            //Valido Apellido
            if (Validaciones.EstaVacioCampo(txtApellido.Text))
            {
                if (Validaciones.VerificoLongitudCampo(txtApellido.Text))
                {
                    if (!Validaciones.EsCampoValido(txtApellido.Text))
                    {
                        errProvider.SetError(txtApellido, "El Apellido ingresado no es valido");
                        validador = false;
                    }
                }
                else
                {
                    errProvider.SetError(txtApellido, "El campo debe contener menos de 50 caracteres");
                    validador = false;
                }
            }
            else
            {
                errProvider.SetError(txtApellido, "Este campo no puede estar vacio");
                validador = false;
            }
            //Valido Clave
            if (Validaciones.EstaVacioCampo(txtClave.Text))
            {
                if (Validaciones.VerificoLongitudCampo(txtClave.Text))
                {
                    if (!Validaciones.EsCampoValido(txtClave.Text))
                    {
                        errProvider.SetError(txtClave, "Clave ingresada no es valida");
                        validador = false;
                    }
                }
                else
                {
                    errProvider.SetError(txtClave, "El campo debe contener menos de 50 caracteres");
                    validador = false;
                }
            }
            else
            {
                errProvider.SetError(txtClave, "Este campo no puede estar vacio");
                validador = false;
            }
            //Valido RepetirClave
            if (Validaciones.EstaVacioCampo(txtConfirmarClave.Text))
            {
                if (Validaciones.VerificoLongitudCampo(txtConfirmarClave.Text))
                {
                    if (!Validaciones.EsCampoValido(txtConfirmarClave.Text))
                    {
                        errProvider.SetError(txtConfirmarClave, "Clave ingresada no es valida");
                        validador = false;
                    }
                }
                else
                {
                    errProvider.SetError(txtConfirmarClave, "El campo debe contener menos de 50 caracteres");
                    validador = false;
                }
            }
            else
            {
                errProvider.SetError(txtConfirmarClave, "Este campo no puede estar vacio");
                validador = false;
            }
            //Valido NombreUsuario
            if (Validaciones.EstaVacioCampo(txtUsuario.Text))
            {
                if (Validaciones.VerificoLongitudCampo(txtUsuario.Text))
                {
                    if (!Validaciones.EsCampoValido(txtUsuario.Text))
                    {
                        errProvider.SetError(txtUsuario, "Nombre de usuario ingresado no es valido");
                        validador = false;
                    }
                }
                else
                {
                    errProvider.SetError(txtUsuario, "El campo debe contener menos de 50 caracteres");
                    validador = false;
                }
            }
            else
            {
                errProvider.SetError(txtUsuario, "Este campo no puede estar vacio");
                validador = false;
            }
            if (!Validaciones.ClavesIguales(txtClave.Text, txtConfirmarClave.Text))
            {
                errProvider.SetError(txtClave, "Las claves no coinciden");
                errProvider.SetError(txtConfirmarClave, "Las claves no coinciden");
                validador = false;
            }
            //Valida Mail
            if (Validaciones.EstaVacioCampo(txtEmail.Text))
            {
                if (Validaciones.VerificoLongitudCampo(txtEmail.Text))
                {
                    if (!Validaciones.EsCampoValido(txtEmail.Text))
                    {
                        errProvider.SetError(txtEmail, "Nombre de usuario ingresado no es valido");
                        validador = false;
                    }
                }
                else
                {
                    errProvider.SetError(txtEmail, "El campo debe contener menos de 50 caracteres");
                    validador = false;
                }
            }
            else
            {
                errProvider.SetError(txtEmail, "Este campo no puede estar vacio");
                validador = false;
            }
            if (!Validaciones.IsValidEmail(txtEmail.Text))
            {
                errProvider.SetError(txtEmail, "El Email no tiene formato valido");
                validador = false;
            }
            return validador;
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

        #region Eventos
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            limpioErrores();
            if (ModoFormulario == ApplicationForm.ModoForm.Alta || ModoFormulario == ApplicationForm.ModoForm.Modificacion)
            {
                if (Validar())
                {
                    GuardarCambios();
                    Close();
                }
            }
            else
            {
                if (MessageBox.Show("Seguro que desea eliminar el usuario seleccionado?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    GuardarCambios();
                    this.Close();
                }
            }

            /* VIEJO
            if (Validar())
            {
                GuardarCambios();
                Close();
            }*/
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void limpioErrores()
        {
            errProvider.Clear();
        }
        new public virtual bool Validar()
        {
            if (validoDatos())
            {
                return true;
            }
            else
            {
                Notificar("Existen campos erroneos, por favor verifique", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void UsuarioDesktop_Load(object sender, EventArgs e)
        {
            cargoComboBox();
            switch (this.ModoFormulario)
            {
                case ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.lbConfirmarClave.Visible = false;
                    this.txtConfirmarClave.Visible = false;
                    this.cbPlanes.Enabled = false;
                    this.btnAceptar.Text = "Eliminar";
                    MapearDeDatos();
                    break;
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    MapearDeDatos();
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;
            }
        }

        #endregion
    }
}
