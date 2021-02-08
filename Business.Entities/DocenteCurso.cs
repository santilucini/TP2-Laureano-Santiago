using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
   public class DocenteCurso : BusinessEntity
    {
        #region Atributos
        private TiposCargos _Cargo;
        private Curso _Curso;
        private Persona _Docente;
        #endregion

        #region Constructores
        public DocenteCurso()
        {
            Curso = new Curso();
            Docente = new Persona();
        }
        #endregion


        #region Propiedades
        // DocenteCurso
        public TiposCargos Cargo
        {
            get { return _Cargo; }
            set { _Cargo = value; }
        }

        // Curso
        public Curso Curso
        {
            get { return _Curso; }
            set { _Curso = value; }
        }

        public string DescComisionCurso
        {
            get { return Curso.DescComision; }
            
        }
        
        public string DescMateriaCurso
        {
            get { return Curso.DescMateria; }
            set { Curso.DescMateria = value; }
        }
        public int IDCurso
        {
            get { return Curso.ID; }
            set { Curso.ID = value; }
        }


       

        // Docente

        public Persona Docente
        {
            get { return _Docente; }
            set { _Docente = value; }
        }

        public int IDDocente
        {
            get { return Docente.ID; }
            set { Docente.ID = value; }
        }

        // Si lo usamos hay que ponerlo
        // Concatena el nombre y la Apellido para mostrar por el DropDown
        
        public string NombreApellDocente
        {
            get { return Docente.Apellido + ", " + Docente.Nombre; }
            
        }
        

        #endregion

        public enum TiposCargos
        {
            Profesor,
            JefeDeCatedra,
            Auxiliar
        }

    }
}
