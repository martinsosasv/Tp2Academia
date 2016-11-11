using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class AlumnoInscripcion : Entidades
    {
        string _condicion;
        int _idAlumno, _idCurso, _nota;

        public string Condicion
        {
            get
            {
                return _condicion;
            }
            set
            {
                _condicion = value;
            }
        }

        public int IdAlumno
        {
            get
            {
                return _idAlumno;
            }
            set
            {
                _idAlumno = value;
            }
        }

        public int IdCurso
        {
            get
            {
                return _idCurso;
            }
            set
            {
                _idCurso = value;
            }
        }

        public int Nota
        {
            get
            {
                return _nota;
            }
            set
            {
                _nota = value;
            }
        }
    }
}
