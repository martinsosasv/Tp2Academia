using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DD = Data.Database;


namespace Negocio
{
    public class CursoLogic : Negocio
    {
        public CursoLogic()
        {
            this.CursoData = new DD.CursoAdapter();

        }

        DD.CursoAdapter _cursoData;
        public DD.CursoAdapter CursoData
        {
            get { return _cursoData; }
            set { _cursoData = value; }
        }

        public List<Curso> GetAll()
        {
            return this.CursoData.GetAll();
        }

        public Curso GetOne(int id)
        {
            return this.CursoData.GetOne(id);
        }

        public void Delete(int id)
        {
            this.CursoData.Delete(id);
        }

        public void Save(Curso curso)
        {
            this.CursoData.Save(curso);
        }

    }
}