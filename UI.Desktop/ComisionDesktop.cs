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

        public Comision ComisionActual { get; set; }

        #endregion

        #region Metodos

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.ComisionActual.ID.ToString();
            this.txtDescripcion.Text = this.ComisionActual.Descripcion.ToString();
            this.txtAnio.Text = this.ComisionActual.AnioEspecialidad.ToString();
            this.txtIDPlan.Text = this.ComisionActual.IDPlan.ToString();
        }
        public override void MapearADatos()
        {
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
            }
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            ComisionLogic com = new ComisionLogic();
            com.Save(ComisionActual);
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

        private void ComisionDesktop_Load(object sender, EventArgs e)
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
