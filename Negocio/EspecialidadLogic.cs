using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DD = Data.Database;


namespace Negocio
{
    public class EspecialidadLogic : Negocio
    {
        public EspecialidadLogic()
        {
            this.EspecialidadData = new DD.EspecialidadAdapter();

        }

        DD.EspecialidadAdapter _especialidadData;
        public DD.EspecialidadAdapter EspecialidadData
        {
            get { return _especialidadData; }
            set { _especialidadData = value; }
        }

        public List<Especialidad> GetAll()
        {
            return this.EspecialidadData.GetAll();
        }

        public Especialidad GetOne(int id)
        {
            return this.EspecialidadData.GetOne(id);
        }

        public void Delete(int id)
        {
            this.EspecialidadData.Delete(id);
        }

        public void Create(Especialidad especialidad)
        {
            this.EspecialidadData.Insert(especialidad);
        }

        public void Update(Especialidad especialidad)
        {
            this.EspecialidadData.Update(especialidad);
        }

    }
}