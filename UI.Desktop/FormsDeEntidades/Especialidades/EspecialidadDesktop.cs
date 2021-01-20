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
using Util;

namespace UI.Desktop
{
    public partial class EspecialidadDesktop : UI.Desktop.ApplicationForm
    {
        
        private Especialidad _EspecialidadActual;
        public Especialidad EspecialidadActual
        {
            get { return _EspecialidadActual; }
            set { _EspecialidadActual = value; }
        }
        public EspecialidadDesktop()
        {
            InitializeComponent();
        }

        /* Viejo
        public EspecialidadDesktop(int ID , ModoForm modo) : this()
        {
            this.ModoFormulario = modo;
            EspecialidadLogic especialidades = new EspecialidadLogic();
            EspecialidadActual = especialidades.GetOne(ID);
            MapearDeDatos();
        }*/
        public void IniciarFormulario()
        {
            switch (this.ModoFormulario)
            {
                case ApplicationForm.ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ApplicationForm.ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    MapearDeDatos();
                    break;
                case ApplicationForm.ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    MapearDeDatos();
                    break;
            }
        }

        public void CastearDatosEspecialidad()
        {
            this.EspecialidadActual = new Especialidad();
            this.EspecialidadActual.Descripcion = this.txtDescripcion.Text;
        }
        new public virtual void MapearDeDatos()
        {
            this.txtID.Text = this.EspecialidadActual.ID.ToString();
            this.txtDescripcion.Text = this.EspecialidadActual.Descripcion.ToString();
        }

        new public virtual void MapearADatos()
        {
            switch (this.ModoFormulario)
            {
                case ApplicationForm.ModoForm.Baja:
                    this.EspecialidadActual.State = BusinessEntity.States.Deleted;
                    break;
                case ApplicationForm.ModoForm.Alta:
                    CastearDatosEspecialidad();
                    this.EspecialidadActual.State = BusinessEntity.States.New;
                    break;
                case ApplicationForm.ModoForm.Modificacion:
                    CastearDatosEspecialidad();
                    this.EspecialidadActual.ID = Convert.ToInt32(this.txtID.Text);
                    this.EspecialidadActual.State = BusinessEntity.States.Modified;
                    break;
            }
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
                return false;
            }
        }

        public void limpioErrores()
        {
            errProvider.Clear();
        }

        new public virtual void GuardarCambios()
        {
            MapearADatos();
            new EspecialidadLogic().Save(EspecialidadActual);
        }

        new public void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }
        /* Viejo
        public override void MapearADatos()
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
        }*/

            /* Viejo
        public override void GuardarCambios()
        {
            MapearADatos();
            EspecialidadLogic esp = new EspecialidadLogic();
            esp.Save(EspecialidadActual);
        }
        */

        /*
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            GuardarCambios();
            Close();
        }*/

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void EspecialidadDesktop_Shown(object sender, EventArgs e)
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
                if (MessageBox.Show("Seguro que desea eliminar la especialidad seleccionada?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    GuardarCambios();
                    this.Close();
                }
            }
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
