using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Materia : BusinessEntity
    {
        #region Atributos
        private string _Descripcion;
        private int _HSSemanales;
        private int _HSTotales;
        private Plan _Plan;
        #endregion

        #region Constructores
        public Materia()
        {
            Plan = new Plan();
        }
        #endregion

        #region Propiedades

        // Materia
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public int HSSemanales
        {
            get { return _HSSemanales; }
            set { _HSSemanales = value; }
        }

        public int HSTotales
        {
            get { return _HSTotales; }
            set { _HSTotales = value; }
        }

        // Plan

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
    }
}
