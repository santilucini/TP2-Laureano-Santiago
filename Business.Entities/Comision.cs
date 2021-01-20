using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Comision : BusinessEntity
    {
        #region Atributos

        private int _AnioEspecialidad;
        private string _Descripcion;
        private Plan _Plan;

        #endregion

        #region Constructores
        public Comision()
        {
            Plan = new Plan();
        }
        #endregion

        // Comision
        #region Propiedades
        public int AnioEspecialidad
        {
            get { return _AnioEspecialidad;  }
            set { _AnioEspecialidad = value; }
        }

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        // Plan
        #region Plan
        public Plan Plan
        {
            get { return _Plan; }
            set { _Plan = value; }
        }

        public int IDPlan
        {
            get { return Plan.ID; }
            set { Plan.ID = value; }
            
        }

        public string DescPlan
        {
            get { return Plan.Descripcion; }
           
        }
        #endregion

        #endregion
    }
}
