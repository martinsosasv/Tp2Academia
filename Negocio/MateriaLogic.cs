using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DD = Data.Database;


namespace Negocio
{
    public class MateriaLogic : Negocio
    {
        public MateriaLogic()
        {
            this.MateriaData = new DD.MateriaAdapter();

        }

        DD.MateriaAdapter _materiaData;
        public DD.MateriaAdapter MateriaData
        {
            get { return _materiaData; }
            set { _materiaData = value; }
        }

        public List<Materia> GetAll()
        {
            return this.MateriaData.GetAll();
        }

        public Materia GetOne(int id)
        {
            return this.MateriaData.GetOne(id);
        }

        public void Delete(Materia materia)
        {
            this.MateriaData.Delete(materia);
        }

        public void Update(Materia materia)
        {
            this.MateriaData.Update(materia);
        }

        public void Insert(Materia materia)
        {
            this.MateriaData.Insert(materia);
        }

    }
}