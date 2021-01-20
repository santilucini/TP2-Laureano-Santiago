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
    public partial class CursosDesktop : ApplicationForm
    {        

        #region Constructor
        public CursosDesktop()
        {
            InitializeComponent();    
            /* Viejo
            MateriaLogic materiaLogic = new MateriaLogic();
            List<Materia> materias = materiaLogic.GetAll();
            foreach(var mt in materias)
            {
                cbxMateria.Items.Add(mt.ID);
            }
            ComisionLogic comisionLogic = new ComisionLogic();
            List<Comision> comisiones = comisionLogic.GetAll();
            foreach (var cm in comisiones)
            {
                cbxComision.Items.Add(cm.ID);
            }
            */
        }

        public CursosDesktop(ModoForm modo) : this()
        {
            this.ModoFormulario = modo;
        }

        public CursosDesktop(ModoForm modo, int ID ) : this()
        {
            this.ModoFormulario = modo;
            CursoLogic cursoLogic = new CursoLogic();
            CursoActual = cursoLogic.GetOne(ID);
            MapearDeDatos();
        }

        #endregion

        #region Propiedades

        private Curso _cursoActual;
        public Curso CursoActual
        {
            get { return _cursoActual; }
            set { _cursoActual = value; }
        }

        #endregion

        #region Metodos

        public void cargoComboBox()
        {
            cbComision.DataSource = new ComisionLogic().GetAll();
            cbComision.DisplayMember = "Descripcion";
            cbComision.ValueMember = "ID";
            cbMateria.DataSource = new MateriaLogic().GetAll();
            cbMateria.DisplayMember = "Descripcion";
            cbMateria.ValueMember = "ID";
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
                    cbMateria.Enabled = false;
                    cbComision.Enabled = false;
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
            this.txtID.Text = this.CursoActual.ID.ToString();
            this.cbMateria.SelectedValue = this.CursoActual.IDMateria;
            this.cbComision.SelectedValue = this.CursoActual.IDComision;
            this.txtAñoCalendario.Text = this.CursoActual.AnioCalendario.ToString();
            this.txtCupo.Text = this.CursoActual.Cupo.ToString();
            /*
            PlanLogic plan = new PlanLogic();
            txtID.Text = this.CursoActual.ID.ToString();
            cbxComision.Text = this.CursoActual.IDMateria.ToString();
            cbxMateria.Text = CursoActual.IDMateria.ToString();
            txtAnioCalendario.Text = CursoActual.AnioCalendario.ToString();
            txtCupo.Text = CursoActual.Cupo.ToString();
            */

        }
        public void CastearDatosCurso()
        {
            this.CursoActual = new Curso();
            this.CursoActual.AnioCalendario = Convert.ToInt32(this.txtAñoCalendario.Text);
            this.CursoActual.Materia = (Materia)cbMateria.SelectedItem;
            this.CursoActual.Comision = (Comision)cbComision.SelectedItem;
            this.CursoActual.Cupo = Convert.ToInt32(this.txtCupo.Text);
        }

        public override void MapearADatos()
        {
            switch (this.ModoFormulario)
            {
                case ApplicationForm.ModoForm.Baja:
                    this.CursoActual.State = BusinessEntity.States.Deleted;
                    break;
                case ApplicationForm.ModoForm.Alta:
                    CastearDatosCurso();
                    CursoActual.State = BusinessEntity.States.New;
                    break;
                case ApplicationForm.ModoForm.Modificacion:
                    CastearDatosCurso();
                    this.CursoActual.ID = Convert.ToInt32(this.txtID.Text);
                    CursoActual.State = BusinessEntity.States.Modified;
                    break;
            }
            /* Viejo
            switch (this.ModoFormulario)
            {
                case ModoForm.Alta:

                    Curso cur = new Curso();
                    CursoActual = cur;

                    CursoActual.IDMateria = Convert.ToInt32(cbxMateria.Text);
                    CursoActual.IDComision = Convert.ToInt32(cbxComision.Text);
                    CursoActual.Cupo = Convert.ToInt32(txtCupo.Text);
                    CursoActual.AnioCalendario = Convert.ToInt32(txtAnioCalendario.Text);

                    CursoActual.State = BusinessEntity.States.New;

                    break;
                case ModoForm.Modificacion:

                    CursoActual.IDMateria = Convert.ToInt32(cbxMateria.Text);
                    CursoActual.IDComision = Convert.ToInt32(cbxComision.Text);
                    CursoActual.Cupo = Convert.ToInt32(txtCupo.Text);
                    CursoActual.AnioCalendario = Convert.ToInt32(txtAnioCalendario.Text);

                    CursoActual.State = BusinessEntity.States.Modified;

                    break;
                case ModoForm.Baja:
                    CursoActual.State = BusinessEntity.States.Deleted;
                    break;
            }
            */
        }

        public bool ValidoDatos()
        {
            bool validador = true;
            //Valido el año calendario
            if (Validaciones.EstaVacioCampo(txtAñoCalendario.Text))
            {
                if (!Validaciones.EsNumerico(txtAñoCalendario.Text))
                {
                    errProvider.SetError(txtAñoCalendario, "El campo ingresado no es numerico");
                    validador = false;
                }
            }
            else
            {
                errProvider.SetError(txtAñoCalendario, "Este campo no puede estar vacio");
                validador = false;
            }
            //Valido el cupo
            if (Validaciones.EstaVacioCampo(txtCupo.Text))
            {
                if (!Validaciones.EsNumerico(txtCupo.Text))
                {
                    errProvider.SetError(txtCupo, "El campo ingresado no es numerico");
                    validador = false;
                }
            }
            else
            {
                errProvider.SetError(txtCupo, "Este campo no puede estar vacio");
                validador = false;
            }
            return validador;
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            CursoLogic cursoLogic = new CursoLogic();
            cursoLogic.Save(CursoActual);
        }
        new public virtual bool Validar()
        {
            if (ValidoDatos())
            {
                return true;
            }
            else
            {
                Notificar("Algun Campo ingresado estaba vacio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        /*
        public override bool Validar()
        {
            //Metodo sin correcta implementacion
            MapearADatos();
            string errores = "";            


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

        public void limpioErrores()
        {
            errProvider.Clear();
        }

        #region ValidarCampos
        /*
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

        #region Eventos
        private void CursoDesktop_Shown(object sender, EventArgs e)
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
                GuardarCambios();
                this.Close();
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

        private void CursosDesktop_Load(object sender, EventArgs e)
        {

        }

        #endregion        
    }
}
