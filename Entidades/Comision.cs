using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Comision : Entidades
    {
        int _anioEspecialidad;
        string _descripcion;
        int _IDPlan;

        public int AnioEspecialidad
        {
            get { return _anioEspecialidad; }
            set { _anioEspecialidad = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public int IDPlan
        {
            get { return _IDPlan; }
            set { _IDPlan = value; }
        }
    }
}
