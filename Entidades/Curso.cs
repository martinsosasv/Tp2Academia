using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Curso : Entidades
    {
        int _anioCalendario, _cupo, _idComision, _idMateria;
        

        public int AnioCalendario
        {
            get
            {
                return _anioCalendario;
            }
            set
            {
                _anioCalendario = value;
            }
        }

        public int Cupo
        {
            get
            {
                return _cupo;
            }
            set
            {
                _cupo = value;
            }
        }

        public int IdComision
        {
            get
            {
                return _idComision;
            }
            set
            {
                _idComision = value;
            }
        }

        public int IdMateria
        {
            get
            {
                return _idMateria;
            }
            set
            {
                _idMateria = value;
            }
        }

    }
}
