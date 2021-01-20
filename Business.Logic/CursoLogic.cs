using Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class CursoLogic : BusinessLogic
    {
        private Data.Database.CursoAdapter _CursoData;
        public Data.Database.CursoAdapter CursoData
        {
            get { return _CursoData; }
            set { _CursoData = value; }
        }
        public CursoLogic()
        {
            CursoData = new Data.Database.CursoAdapter();
        }

        public List<Curso> GetAll()
        {
            return CursoData.GetAll();
        }

        public Business.Entities.Curso GetOne(int ID)
        {
            return CursoData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            CursoData.Delete(ID);
        }

        public void Save(Business.Entities.Curso curso)
        {
            CursoData.Save(curso);
        }

        public void Update(Business.Entities.Curso curso)
        {
            CursoData.ModificarCupoCurso(curso);
        }
    }

}

