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
    public partial class PlanDesktop : UI.Desktop.ApplicationForm
    {

        public PlanDesktop()
        {
            InitializeComponent();
            /* Viejo
            InitializeComponent();
            EspecialidadLogic especialidad = new EspecialidadLogic();
            List<Especialidad> esp = especialidad.GetAll();
            foreach (var es in esp)
            {
              this.comboBox1.Items.Add(es.Descripcion);
            }*/

        }
        public PlanDesktop(ModoForm modo) : this()
        {
            // PASO 10
            // INTERNAMENTE DEBE SETEAR A MODOFORM EN EL MODO ENVIADO COMO PARAMETRO
            // ESTO SERVIRA PARA LAS ALTAS
            this.ModoFormulario = modo;
            
        }
        /* Viejo
        public PlanDesktop(int ID, ModoForm modo) : this()
        {
            this.ModoFormulario = modo;
            PlanLogic planes = new PlanLogic();
            PlanActual = planes.GetOne(ID);
            MapearDeDatos();
        }*/

        public void cargoComboBox()
        {
            this.cbEspecialidad.DataSource = new EspecialidadLogic().GetAll();
            this.cbEspecialidad.ValueMember = "ID";
            this.cbEspecialidad.DisplayMember = "Descripcion";
        }


        private Plan _PlanActual;
        public Plan PlanActual
        {
            get { return _PlanActual; }
            set { _PlanActual = value; }
        }

        public void IniciarFormulario()
        {
            cargoComboBox();
            switch (this.ModoFormulario)
            {
                case ApplicationForm.ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ApplicationForm.ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    this.cbEspecialidad.Enabled = false;
                    MapearDeDatos();
                    break;
                case ApplicationForm.ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    MapearDeDatos();
                    break;
            }
        }

        public override void MapearDeDatos()
        {

            this.txtID.Text = this.PlanActual.ID.ToString();
            this.txtDescripcion.Text = this.PlanActual.Descripcion.ToString();
            this.cbEspecialidad.SelectedValue = this.PlanActual.IDEspecialidad;
            /* Viejo
            EspecialidadLogic especialidad = new EspecialidadLogic();
            this.txtID.Text = this.PlanActual.ID.ToString();
            this.txtDescripcion.Text = this.PlanActual.Descripcion.ToString();
            
            this.comboBox1.Text = especialidad.GetOne(this.PlanActual.IDEspecialidad).Descripcion;
            //this.txtIdEspecialidad.Text = this.PlanActual.IDEspecialidad.ToString();
             */
        }
        public void CastearDatosPlan()
        {
            this.PlanActual = new Plan();
            this.PlanActual.Descripcion = this.txtDescripcion.Text;
            this.PlanActual.Especialidad = (Especialidad)cbEspecialidad.SelectedItem;
        }
        public void limpioErrores()
        {
            errProvider.Clear();
        }
        public override void MapearADatos()
        {
            switch (this.ModoFormulario)
            {
                case ApplicationForm.ModoForm.Baja:
                    this.PlanActual.State = BusinessEntity.States.Deleted;
                    break;
                case ApplicationForm.ModoForm.Alta:
                    CastearDatosPlan();
                    PlanActual.State = BusinessEntity.States.New;
                    break;
                case ApplicationForm.ModoForm.Modificacion:
                    CastearDatosPlan();
                    PlanActual.ID = Convert.ToInt32(this.txtID.Text);
                    PlanActual.State = BusinessEntity.States.Modified;
                    break;
            }
            /* Viejo
            EspecialidadLogic especialidad = new EspecialidadLogic();
            switch (this.ModoFormulario)
            {
                case ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";
                    Plan pln = new Plan();
                    this.PlanActual = pln;

                    this.PlanActual.Descripcion = this.txtDescripcion.Text;
                    //DEBERIA MOSTRAR EL NOMBRE DE LA ESPECIALIDAD EN VEZ DE EL ID
                    this.PlanActual.IDEspecialidad = especialidad.GetOneByDesc(this.comboBox1.Text); //Int32.Parse(this.txtIdEspecialidad.Text);
                    

                    // tiene que estar en new

                    this.PlanActual.State = BusinessEntity.States.New;

                    break;
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";

                    this.PlanActual.Descripcion = this.txtDescripcion.Text;
                    // this.PlanActual.IDEspecialidad = especialidad.GetOneByDesc(this.comboBox1.Text);
                    //DEBERIA MOSTRAR EL NOMBRE DE LA ESPECIALIDAD EN VEZ DE EL ID
                    // this.PlanActual.IDEspecialidad = Int32.Parse(this.txtIdEspecialidad.Text);
                    this.PlanActual.IDEspecialidad = especialidad.GetOneByDesc(this.comboBox1.Text); //Int32.Parse(this.txtIdEspecialidad.Text);

                    this.PlanActual.State = BusinessEntity.States.Modified;

                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    this.PlanActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;
            }
            */
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            PlanLogic usuario = new PlanLogic();
            usuario.Save(PlanActual);
        }

        public bool validoDatos()
        {
            bool validador = true;
            if (Validaciones.EstaVacioCampo(txtDescripcion.Text))
            {
                if (!Validaciones.VerificoLongitudCampo(txtDescripcion.Text))
                {
                    errProvider.SetError(txtDescripcion, "El campo debe contener menos de 50 caracteres");
                    validador = false;
                }
            }
            else
            {
                errProvider.SetError(txtDescripcion, "Este campo no puede estar vacio");
                validador = false;
            }
            return validador;
        }
        new public virtual bool Validar()
        {
            if (validoDatos())
            {
                return true;
            }
            else
            {
                Notificar("Existen campos vacios, por favor verifique", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        /* Viejo
        public override bool Validar()
        {

            
            MapearADatos();
            string errores = "";

            if (IsValidString(this.PlanActual.Descripcion))
            { }
            else
            {
                errores += "Descripcion |";
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
            
        }*/
        new public void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }
        /* Viejas Validaciones
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
        */

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            limpioErrores();
            if (this.ModoFormulario == ApplicationForm.ModoForm.Alta || this.ModoFormulario == ApplicationForm.ModoForm.Modificacion)
            {
                if (Validar())
                {
                    GuardarCambios();
                    this.Close();
                }
            }
            else
            {
                if (MessageBox.Show("Seguro que desea eliminar el plan seleccionado?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    GuardarCambios();
                    this.Close();
                }
            }
            /*
            GuardarCambios();
            Close();
            */
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PlanDesktop_Shown(object sender, EventArgs e)
        {
            IniciarFormulario();
        }
        private void PlanDesktop_Load(object sender, EventArgs e)
        {

        }
    }
}