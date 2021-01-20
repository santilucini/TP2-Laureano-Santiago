using Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class MateriaLogic : BusinessLogic
    {
        private Data.Database.MateriaAdapter _MateriaData;
        public Data.Database.MateriaAdapter MateriaData
        {
            get { return _MateriaData; }
            set { _MateriaData = value; }
        }
        public MateriaLogic()
        {
            MateriaData = new Data.Database.MateriaAdapter();
        }

        public List<Materia> GetAll()
        {
            return MateriaData.GetAll();
        }

        public int GetOneByDesc(string descripcion)
        {
            return MateriaData.GetOneByDesc(descripcion);
        }

        public Business.Entities.Materia GetOne(int ID)
        {
            return MateriaData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            MateriaData.Delete(ID);
        }

        public void Save(Business.Entities.Materia materia)
        {
            MateriaData.Save(materia);
        }
    }



}
