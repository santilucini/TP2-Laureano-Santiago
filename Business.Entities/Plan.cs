using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Plan:BusinessEntity
    {
        #region Atributos
        private string _Descripcion;
        private Especialidad _Especialidad;
        #endregion

        #region Constructores
        public Plan()
        {
            Especialidad = new Especialidad();
        }
        #endregion

        #region Propiedades

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        // Especialidad
        public Especialidad Especialidad
        {
            get { return _Especialidad; }
            set { _Especialidad = value; }
        }
        
        public int IDEspecialidad
        {
            get { return Especialidad.ID; }
            set { Especialidad.ID = value; }
        }

        public string DescEspecialidad
        {
            get { return Especialidad.Descripcion; }
            set { Especialidad.Descripcion = value; }
        }

        #endregion
    }
}
