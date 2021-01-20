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
using Util;

namespace UI.Desktop
{
    public partial class ComisionDesktop : ApplicationForm
    {
        #region Constructores
        public ComisionDesktop()
        {
            InitializeComponent();
        }

        public ComisionDesktop(ModoForm modo) : this()
        {
            this.ModoFormulario = modo;
        }

        public ComisionDesktop(int ID, ModoForm modo) : this()
        {
            this.ModoFormulario = modo;
            ComisionLogic comisiones = new ComisionLogic();
            ComisionActual = comisiones.GetOne(ID);
            MapearDeDatos();
        }
        #endregion

        #region Propiedades

        private Comision _ComisionActual;
        public Comision ComisionActual 
        {
            get { return _ComisionActual; }
            set { _ComisionActual = value; }
        }

        #endregion

        #region Metodos
        public void cargoComboBox()
        {
            cbPlan.DataSource = new PlanLogic().GetAll();
            cbPlan.ValueMember = "ID";
            cbPlan.DisplayMember = "Descripcion";
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
                    cbPlan.Enabled = false;
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
            this.txtID.Text = this.ComisionActual.ID.ToString();
            this.txtAnio.Text = this.ComisionActual.AnioEspecialidad.ToString();
            this.txtDescripcion.Text = this.ComisionActual.Descripcion;
            this.cbPlan.SelectedValue = this.ComisionActual.IDPlan;
            /* Viejo
            this.txtID.Text = this.ComisionActual.ID.ToString();
            this.txtDescripcion.Text = this.ComisionActual.Descripcion.ToString();
            this.txtAnio.Text = this.ComisionActual.AnioEspecialidad.ToString();
            this.txtIDPlan.Text = this.ComisionActual.IDPlan.ToString();
            */
        }
        public void CastearDatosComision()
        {
            this.ComisionActual = new Comision();
            this.ComisionActual.AnioEspecialidad = Convert.ToInt32(this.txtAnio.Text);
            this.ComisionActual.Descripcion = this.txtDescripcion.Text;
            this.ComisionActual.Plan = (Plan)cbPlan.SelectedItem;
        }
        new public virtual void MapearADatos()
        {
            switch (this.ModoFormulario)
            {
                case ApplicationForm.ModoForm.Baja:
                    this.ComisionActual.State = BusinessEntity.States.Deleted;
                    break;
                case ApplicationForm.ModoForm.Alta:
                    CastearDatosComision();
                    ComisionActual.State = BusinessEntity.States.New;
                    break;
                case ApplicationForm.ModoForm.Modificacion:
                    CastearDatosComision();
                    this.ComisionActual.ID = Convert.ToInt32(this.txtID.Text);
                    ComisionActual.State = BusinessEntity.States.Modified;
                    break;
            }
            /* Viejo
            switch (this.ModoFormulario)
            {
                case ModoForm.Alta:
                    Comision com = new Comision();
                    this.ComisionActual = com;

                    this.ComisionActual.Descripcion = this.txtDescripcion.Text;
                    this.ComisionActual.AnioEspecialidad = Convert.ToInt32(this.txtAnio.Text);
                    this.ComisionActual.IDPlan = Convert.ToInt32(this.txtIDPlan.Text);

                    this.ComisionActual.State = BusinessEntity.States.New;

                    break;

                case ModoForm.Modificacion:  
                    this.ComisionActual.Descripcion = this.txtDescripcion.Text;
                    this.ComisionActual.AnioEspecialidad = Convert.ToInt32(this.txtAnio.Text);
                    this.ComisionActual.IDPlan = Convert.ToInt32(this.txtIDPlan.Text);

                    this.ComisionActual.State = BusinessEntity.States.Modified;
                    break;

                case ModoForm.Baja:
                    this.ComisionActual.State = BusinessEntity.States.Deleted;
                    break;

                case ModoForm.Consulta:                    
                    break;
            }*/
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            ComisionLogic com = new ComisionLogic();
            com.Save(ComisionActual);
        }

        public bool ValidoDatos()
        {
            bool validador = true;
            //Valido la descripcion
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
            //Valido el año
            if (Validaciones.EstaVacioCampo(txtAnio.Text))
            {
                if (!Validaciones.EsNumerico(txtAnio.Text))
                {
                    errProvider.SetError(txtAnio, "El campo ingresado no es numerico");
                    validador = false;
                }
            }
            else
            {
                errProvider.SetError(txtAnio, "Este campo no puede estar vacio");
                validador = false;
            }
            return validador;
        }

        new public virtual bool Validar()
        {
            if (ValidoDatos())
            {
                return true;
            }
            else
            {
                Notificar("Existen campos vacios, por favor verifique", MessageBoxButtons.OK, MessageBoxIcon.Error); //concatenar mensajes y llamar a notificar una sola vez al final
                return false;
            }
        }

        new public void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }

        public void limpioErrores()
        {
            errProvider.Clear();
        }
        #endregion

        private void ComisionDesktop_Shown(object sender, EventArgs e)
        {
            IniciarFormulario();
        }
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
                if (MessageBox.Show("Seguro que desea eliminar la comision seleccionada?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    GuardarCambios();
                    this.Close();
                }
            }

            /*Viejo
            GuardarCambios();
            Close();
            */
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ComisionDesktop_Load(object sender, EventArgs e)
        {

        }
    }
}
