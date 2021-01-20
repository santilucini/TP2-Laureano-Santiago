using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class EspecialidadDesktop : UI.Desktop.ApplicationForm
    {
        #region Constructores
        public EspecialidadDesktop()
        {
            InitializeComponent();
        }
        public EspecialidadDesktop(ModoForm modo) : this()
        {
            this.ModoFormulario = modo;
        }

        public EspecialidadDesktop(int ID , ModoForm modo) : this()
        {
            this.ModoFormulario = modo;
            EspecialidadLogic especialidades = new EspecialidadLogic();
            EspecialidadActual = especialidades.GetOne(ID);
            MapearDeDatos();
        }
        #endregion

        #region Propiedades

        private Especialidad _EspecialidadActual;
        public Especialidad EspecialidadActual
        {
            get { return _EspecialidadActual; }
            set { _EspecialidadActual = value; }
        }

        #endregion

        #region Metodos

        public virtual void MapearDeDatos()
        {
            this.txtID.Text = this.EspecialidadActual.ID.ToString();
            this.txtDescripcion.Text = this.EspecialidadActual.Descripcion.ToString();
        }

        public virtual void MapearADatos()
        {
            switch (this.ModoFormulario)
            {
                case ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";
                    Especialidad esp = new Especialidad();
                    this.EspecialidadActual = esp;

                    this.EspecialidadActual.Descripcion = this.txtDescripcion.Text;

                    this.EspecialidadActual.State = BusinessEntity.States.New;

                    break;

                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";

                    this.EspecialidadActual.Descripcion = this.txtDescripcion.Text;

                    this.EspecialidadActual.State = BusinessEntity.States.Modified;
                    break;

                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    this.EspecialidadActual.State = BusinessEntity.States.Deleted;
                    break;

                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;
            }
        }

        public virtual void GuardarCambios()
        {
            MapearADatos();
            EspecialidadLogic esp = new EspecialidadLogic();
            esp.Save(EspecialidadActual);
        }


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

        private void EspecialidadDesktop_Load(object sender, EventArgs e)
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
