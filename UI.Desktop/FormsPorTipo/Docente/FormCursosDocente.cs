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

namespace UI.Desktop.FormsPorTipo.Docente
{
    public partial class FormCursosDocente : Form
    {
        private Usuario _Docente;
        private Operacion _Operacion;

        #region Propiedades
        public enum Operacion
        {
            RegistroNotas,
            VerReporteCurso,
            VerReportePlanes
        }

        public Usuario Docente
        {
            get { return _Docente; }
            set { _Docente = value; }
        }

        public Operacion TipoOperacion
        {
            get { return _Operacion; }
            set { _Operacion = value; }
        }

        #endregion

        #region Constructores
        public FormCursosDocente(Usuario usuario)
        {
            InitializeComponent();
            Docente = usuario;
            this.dgvAlumnosCursos.AutoGenerateColumns = false;
        }
        #endregion

        #region Metodos
        public void Listar()
        {
            try
            {
                AlumnoInscripcionLogic inscripciones = new AlumnoInscripcionLogic();
                //Aca voy a tener que crear otro metodo para traer las inscripciones del docente curso
                dgvAlumnosCursos.DataSource = inscripciones.GetAll(Docente);
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private bool itemSeleccionado()
        {
            return (this.dgvAlumnosCursos.SelectedRows.Count > 0);
        }

        #endregion

        #region Eventos
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (itemSeleccionado())
            {
                //Se crea el formulario con la inscripcion seleccionada
                AlumnoInscripcion InsSeleccionada = (AlumnoInscripcion)this.dgvAlumnosCursos.SelectedRows[0].DataBoundItem;
                if (InsSeleccionada.Condicion != "Corregido")
                {
                    new FormIngresoNota(InsSeleccionada).ShowDialog();
                }
                else
                {
                    MessageBox.Show("La inscripcion seleccionada ya se encuentra coregida", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            Listar();
        }

        private void formCursosDocente_Shown(object sender, EventArgs e)
        {
            Listar();
        }
        #endregion
    }
}
