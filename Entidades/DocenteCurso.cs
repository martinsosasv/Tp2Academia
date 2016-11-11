using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DocenteCurso : Entidades
    {
        // CONSULTAR PROFE TiposCargos _cargo;
        int _cargo;
        int _idCurso, _idDocente;

        /*public TiposCargos Cargo
        {
            get
            {
                return _cargo;
            }
            set
            {
                _cargo = value;
            }
        }*/
        public int Cargo
        {
            get
            {
                return _cargo;
            }
            set
            {
                _cargo = value;
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

        public int IdDocente
        {
            get
            {
                return _idDocente;
            }
            set
            {
                _idDocente = value;
            }
        }

        /*public enum TiposCargos
        {
            Titular,
            Auxiliar,
            Asociadoss
        }*/
    }
}
