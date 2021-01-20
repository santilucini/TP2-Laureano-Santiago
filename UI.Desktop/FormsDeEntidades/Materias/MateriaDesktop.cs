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
    public partial class MateriaDesktop : UI.Desktop.ApplicationForm
    {
        #region Constructor
        public MateriaDesktop()
        {
            InitializeComponent();
        }

        public void cargoComboBox()
        {
            cbPlan.DataSource = new PlanLogic().GetAll();
            cbPlan.ValueMember = "ID";
            cbPlan.DisplayMember = "Descripcion";
        }

        /* Viejo
        public MateriaDesktop()
        {
            InitializeComponent();
            PlanLogic plan = new PlanLogic();
            List<Plan> pln = plan.GetAll();
            foreach (var es in pln)
            {
                this.cbxPlan.Items.Add(es.Descripcion);
            }
        }

        public MateriaDesktop(ModoForm modo) : this()
        {
            // PASO 10
            // INTERNAMENTE DEBE SETEAR A MODOFORM EN EL MODO ENVIADO COMO PARAMETRO
            // ESTO SERVIRA PARA LAS ALTAS
            this.ModoFormulario = modo;
        }

        public MateriaDesktop(int ID, ModoForm modo) : this()
        {
            this.ModoFormulario = modo;
            MateriaLogic materias = new MateriaLogic();
            MateriaActual = materias.GetOne(ID);
            MapearDeDatos();
        }
        */

        #endregion

        #region Propiedades

        private Materia _MateriaActual;
        public Materia MateriaActual
        {
            get { return _MateriaActual; }
            set { _MateriaActual = value; }
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
        public void limpioErrores()
        {
            errProvider.Clear();
        }
        #endregion

        #region Metodos
        new public virtual void MapearDeDatos()
        {
            this.txtID.Text = this.MateriaActual.ID.ToString();
            this.txtDescripcion.Text = this.MateriaActual.Descripcion.ToString();
            this.txtHsemanales.Text = this.MateriaActual.HSSemanales.ToString();
            this.txtHtotales.Text = this.MateriaActual.HSTotales.ToString();
            this.cbPlan.SelectedValue = this.MateriaActual.IDPlan;
        }
        /* Viejo
        public override void MapearDeDatos()
        {
            PlanLogic plan= new PlanLogic();
            this.txtID.Text = this.MateriaActual.ID.ToString();
            this.txtDescripcion.Text = this.MateriaActual.Descripcion.ToString();
            this.txtHsemanales.Text = this.MateriaActual.HSSemanales.ToString();
            this.txtHtotales.Text = this.MateriaActual.HSTotales.ToString();

            this.cbxPlan.Text = plan.GetOne(this.MateriaActual.IDPlan).Descripcion;
            //this.txtIdEspecialidad.Text = this.PlanActual.IDEspecialidad.ToString();

        }*/
        public void CastearDatosMateria()
        {
            this.MateriaActual = new Materia();
            this.MateriaActual.Descripcion = this.txtDescripcion.Text;
            this.MateriaActual.HSSemanales = Convert.ToInt32(this.txtHsemanales.Text);
            this.MateriaActual.HSTotales = Convert.ToInt32(this.txtHtotales.Text);
            this.MateriaActual.Plan = (Plan)cbPlan.SelectedItem;
        }

        public override void MapearADatos()
        {
            switch (this.ModoFormulario)
            {
                case ApplicationForm.ModoForm.Baja:
                    MateriaActual.State = Usuario.States.Deleted;
                    break;
                case ApplicationForm.ModoForm.Alta:
                    CastearDatosMateria();
                    this.MateriaActual.State = Usuario.States.New;
                    break;
                case ApplicationForm.ModoForm.Modificacion:
                    CastearDatosMateria();
                    this.MateriaActual.ID = Convert.ToInt32(this.txtID.Text);
                    this.MateriaActual.State = Usuario.States.Modified;
                    break;
            }
            /* Viejo
            PlanLogic plan = new PlanLogic();
            switch (this.ModoFormulario)
            {
                case ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";
                    Materia mat = new Materia();
                    this.MateriaActual = mat;

                    this.MateriaActual.Descripcion = this.txtDescripcion.Text;
                    this.MateriaActual.HSSemanales = Convert.ToInt32(this.txtHsemanales.Text);
                    this.MateriaActual.HSTotales = Convert.ToInt32(this.txtHtotales.Text);

                    //DEBERIA MOSTRAR EL NOMBRE DEl PLAN EN VEZ DE EL ID
                    this.MateriaActual.IDPlan = plan.GetOneByDesc(this.cbxPlan.Text); //Int32.Parse(this.txtIdEspecialidad.Text);


                    // tiene que estar en new

                    this.MateriaActual.State = BusinessEntity.States.New;

                    break;
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";

                    this.MateriaActual.Descripcion = this.txtDescripcion.Text;
                    this.MateriaActual.HSSemanales = Convert.ToInt32(this.txtHsemanales.Text);
                    this.MateriaActual.HSTotales = Convert.ToInt32(this.txtHtotales.Text);

                    this.MateriaActual.IDPlan = plan.GetOneByDesc(this.cbxPlan.Text); //Int32.Parse(this.txtIdEspecialidad.Text);

                    this.MateriaActual.State = BusinessEntity.States.Modified;

                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    this.MateriaActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;
            }
            */
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
            //Valido las HsTotales
            if (Validaciones.EstaVacioCampo(txtHtotales.Text))
            {
                if (!Validaciones.EsNumerico(txtHtotales.Text))
                {
                    errProvider.SetError(txtHtotales, "El campo ingresado no es numerico");
                    validador = false;
                }
            }
            else
            {
                errProvider.SetError(txtHtotales, "Este campo no puede estar vacio");
                validador = false;
            }
            //Valido las HsSemanales
            if (Validaciones.EstaVacioCampo(txtHsemanales.Text))
            {
                if (!Validaciones.EsNumerico(txtHsemanales.Text))
                {
                    errProvider.SetError(txtHsemanales, "El campo ingresado no es numerico");
                    validador = false;
                }
            }
            else
            {
                errProvider.SetError(txtHsemanales, "Este campo no puede estar vacio");
                validador = false;
            }
            return validador;
        }
        /* Viejo
        public override void GuardarCambios()
        {
            MapearADatos();
            MateriaLogic materia = new MateriaLogic();
            materia.Save(MateriaActual);
        }
        */

        public override bool Validar()
        {
            if (ValidoDatos())
            {
                return true;
            }
            else
            {
                Notificar("Existen campos vacios, por favor verifique", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            /* Viejo
            MapearADatos();
            string errores = "";

            if (IsValidString(this.MateriaActual.Descripcion))
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
            */
        }
        new public virtual void GuardarCambios()
        {
            MapearADatos();
            new MateriaLogic().Save(MateriaActual);
        }
        #region ValidarCampos

        new public void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }
        /* Viejo
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

        #endregion

        #endregion

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
                if (MessageBox.Show("Seguro que desea eliminar la materia seleccionada?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    GuardarCambios();
                    this.Close();
                }
            }
            /* Viejo
            GuardarCambios();
            Close();*/
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void MateriaDesktop_Shown(object sender, EventArgs e)
        {
            IniciarFormulario();
        }
        private void MateriaDesktop_Load(object sender, EventArgs e)
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
