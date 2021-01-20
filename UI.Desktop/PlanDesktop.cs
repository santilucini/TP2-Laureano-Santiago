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
    public partial class PlanDesktop : UI.Desktop.ApplicationForm
    {
        #region Constructor

        public PlanDesktop()
        {
            InitializeComponent();
            EspecialidadLogic especialidad = new EspecialidadLogic();
            List<Especialidad> esp = especialidad.GetAll();
            foreach (var es in esp)
            {
              this.comboBox1.Items.Add(es.Descripcion);
            }

        }
        public PlanDesktop(ModoForm modo) : this()
        {
            // PASO 10
            // INTERNAMENTE DEBE SETEAR A MODOFORM EN EL MODO ENVIADO COMO PARAMETRO
            // ESTO SERVIRA PARA LAS ALTAS
            this.ModoFormulario = modo;
            
        }
        public PlanDesktop(int ID, ModoForm modo) : this()
        {
            this.ModoFormulario = modo;
            PlanLogic planes = new PlanLogic();
            PlanActual = planes.GetOne(ID);
            MapearDeDatos();
        }
        #endregion

        #region Propiedades

        private Plan _PlanActual;
        public Plan PlanActual
        {
            get { return _PlanActual; }
            set { _PlanActual = value; }
        }

        #endregion

        #region Metodos

        public virtual void MapearDeDatos()
        {
            EspecialidadLogic especialidad = new EspecialidadLogic();
            this.txtID.Text = this.PlanActual.ID.ToString();
            this.txtDescripcion.Text = this.PlanActual.Descripcion.ToString();
            
            this.comboBox1.Text = especialidad.GetOne(this.PlanActual.IDEspecialidad).Descripcion;
            //this.txtIdEspecialidad.Text = this.PlanActual.IDEspecialidad.ToString();
             
        }

        public virtual void MapearADatos()
        {
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
        }

        public virtual void GuardarCambios()
        {
            MapearADatos();
            PlanLogic usuario = new PlanLogic();
            usuario.Save(PlanActual);
        }

        public virtual bool Validar()
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

        private void PlanDesktop_Load(object sender, EventArgs e)
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