using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
   public class Curso : BusinessEntity

    {

        #region Atributos

        private int _AnioCalendario;
        private int _Cupo;
        private Comision _Comision;
        private Materia _Materia;

        #endregion

        #region Constructores
        public Curso()
        {
            Comision = new Comision();
            Materia = new Materia();
        }
        #endregion

        #region Propiedades

        // Curso
        public int AnioCalendario
        {
            get { return _AnioCalendario; }
            set { _AnioCalendario = value; }
        }

        public int Cupo
        {
            get { return _Cupo; }
            set { _Cupo = value; }
        }

        // Comision
        public Comision Comision
        {
            get { return _Comision; }
            set { _Comision = value; }
        }

        public int IDComision
        {
            get { return Comision.ID; }
            set { Comision.ID = value; }
            
        }
        public string DescComision
        {
            get { return Comision.Descripcion; }
         
            
        }

        public Materia Materia
        {
            get { return _Materia; }
            set { _Materia = value; }
        }

        public int IDMateria
        {
            get { return Materia.ID; }
            set { Materia.ID = value; }
            
        }

        public string DescMateria
        {
            get { return Materia.Descripcion; }
            set { Materia.Descripcion = value; }
            
        }

        #endregion
    }
}
