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
using Util;

namespace UI.Desktop
{
    public partial class PersonaDesktop : ApplicationForm
    {   

        #region Constructor

        public PersonaDesktop()
        {
            InitializeComponent();
        }

        public PersonaDesktop(ModoForm modo) : this()
        {            
            this.ModoFormulario = modo;
        }

        public PersonaDesktop(int ID, ModoForm modo) : this()
        {
            this.ModoFormulario = modo;
            PersonasLogic usuarios = new PersonasLogic();
            PersonaActual = usuarios.GetOne(ID);
            MapearDeDatos();
        }

        #endregion

        #region Propiedades

        private Persona _personaActual;
        public Persona PersonaActual
        {
            get { return _personaActual; }
            set { _personaActual = value; }
        }

        #endregion

        #region Metodos

        public override void MapearDeDatos()
        {
            txtID.Text = PersonaActual.ID.ToString();
            txtNombre.Text = PersonaActual.Nombre.ToString();
            txtApellido.Text = PersonaActual.Apellido.ToString();
            txtEmail.Text = PersonaActual.Email.ToString();
            txtDireccion.Text = PersonaActual.Direccion;
            txtFechaNac.Text = PersonaActual.FechaNacimiento.ToString();
            txtLegajo.Text = PersonaActual.Legajo.ToString();
            txtTelefono.Text = PersonaActual.Telefono;
            cbxIdPlan.Text = PersonaActual.IDPlan.ToString();
            cbxTipoPersona.Text = ((int)PersonaActual.TipoPersona).ToString();
        }

        public override void MapearADatos()
        {

            switch (this.ModoFormulario)
            {
                case ModoForm.Alta:
                    Persona persona = new Persona();
                    PersonaActual = persona;
                    PersonaActual.Nombre = txtNombre.Text;
                    PersonaActual.Apellido = txtApellido.Text;
                    PersonaActual.Email = txtEmail.Text;
                    PersonaActual.IDPlan = Convert.ToInt32(cbxIdPlan.Text);
                    PersonaActual.Direccion = txtDireccion.Text;
                    PersonaActual.FechaNacimiento = Convert.ToDateTime(txtFechaNac.Text);
                    PersonaActual.Legajo = Convert.ToInt32(txtLegajo.Text);
                    PersonaActual.Telefono = txtTelefono.Text;
                    PersonaActual.TipoPersona = (Persona.TiposPersonas)Convert.ToInt32(cbxTipoPersona.Text);

                    PersonaActual.State = BusinessEntity.States.New;

                    break;
                case ModoForm.Modificacion:
                    PersonaActual.Nombre = txtNombre.Text;
                    PersonaActual.Apellido = txtApellido.Text;
                    PersonaActual.Email = txtEmail.Text;
                    PersonaActual.IDPlan = Convert.ToInt32(cbxIdPlan.Text);
                    PersonaActual.Direccion = txtDireccion.Text;
                    PersonaActual.FechaNacimiento = Convert.ToDateTime(txtFechaNac.Text);
                    PersonaActual.Legajo = Convert.ToInt32(txtLegajo.Text);
                    PersonaActual.Telefono = txtTelefono.Text;
                    PersonaActual.TipoPersona = (Persona.TiposPersonas)Convert.ToInt32(cbxTipoPersona.Text);

                    PersonaActual.State = BusinessEntity.States.Modified;

                    break;
                case ModoForm.Baja:
                    PersonaActual.State = BusinessEntity.States.Deleted;
                    break;
            }
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            PersonasLogic personasLogic = new PersonasLogic();
            personasLogic.Save(PersonaActual);
        }
        public override bool Validar()
        {
            MapearADatos();
            string errores = "";

            if (IsValidString(PersonaActual.Apellido))
            { }
            else
            {
                errores += "Apellido |";
            }

            if (IsValidString(PersonaActual.Nombre))
            { }
            else
            {
                errores += " Nombre |";
            }

            if (Validaciones.IsValidEmail(PersonaActual.Email))
            { }
            else
            {
                errores += " Email |";
            }

            if (IsValidString(PersonaActual.Direccion))
            { }
            else
            {
                errores += "Direccion |";
            }

            if (IsValidString(PersonaActual.Telefono))
            { }
            else
            {
                errores += "Telefono |";
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

        private void PersonaDesktop_Load(object sender, EventArgs e)
        {
            PlanLogic planLogic = new PlanLogic();
            List<Plan> planes = planLogic.GetAll();
            foreach(var pl in planes)
            {
                cbxIdPlan.Items.Add(pl.ID.ToString());
            }

            for(int i=0; i<4; i++)
            {
                cbxTipoPersona.Items.Add(i.ToString());
            }

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
