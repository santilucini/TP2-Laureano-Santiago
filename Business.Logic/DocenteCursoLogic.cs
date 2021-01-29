using Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Business.Logic
{
    public class DocenteCursoLogic : BusinessLogic
    {
        private Data.Database.DocenteCursoAdapter _DocenteCursoData;
        public Data.Database.DocenteCursoAdapter DocenteCursoData
        {
            get { return _DocenteCursoData; }
            set { _DocenteCursoData = value; }
        }
        public DocenteCursoLogic()
        {
            DocenteCursoData = new Data.Database.DocenteCursoAdapter();
        }

        public List<DocenteCurso> GetAll()
        {
            return DocenteCursoData.GetAll();
        }

        //public int GetOneByDesc(string descripcion)
        //{
        //    return DocenteCursoData.GetOneByDesc(descripcion);
        //}

        public Business.Entities.DocenteCurso GetOne(int ID)
        {
            return DocenteCursoData.GetOne(ID);
        }

        public List<DocenteCurso> GetAllByCurso(int ID)
        {
            return DocenteCursoData.GetAllByCurso(ID);
        }

        public void Delete(int ID)
        {
            DocenteCursoData.Delete(ID);
        }

        public void Save(Business.Entities.DocenteCurso docentecurso)
        {
            DocenteCursoData.Save(docentecurso);
        }
    }
}
