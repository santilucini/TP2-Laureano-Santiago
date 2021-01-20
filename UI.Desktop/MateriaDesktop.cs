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
    public partial class MateriaDesktop : UI.Desktop.ApplicationForm
    {
        #region Constructor
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

        #endregion

        #region Propiedades

        private Materia _MateriaActual;
        public Materia MateriaActual
        {
            get { return _MateriaActual; }
            set { _MateriaActual = value; }
        }


        #endregion

        #region Metodos
        public virtual void MapearDeDatos()
        {
            PlanLogic plan= new PlanLogic();
            this.txtID.Text = this.MateriaActual.ID.ToString();
            this.txtDescripcion.Text = this.MateriaActual.Descripcion.ToString();
            this.txtHsemanales.Text = this.MateriaActual.HSSemanales.ToString();
            this.txtHtotales.Text = this.MateriaActual.HSTotales.ToString();

            this.cbxPlan.Text = plan.GetOne(this.MateriaActual.IDPlan).Descripcion;
            //this.txtIdEspecialidad.Text = this.PlanActual.IDEspecialidad.ToString();

        }

        public virtual void MapearADatos()
        {
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
        }

        public virtual void GuardarCambios()
        {
            MapearADatos();
            MateriaLogic materia = new MateriaLogic();
            materia.Save(MateriaActual);
        }

        public virtual bool Validar()
        {
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
            GuardarCambios();
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
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
