using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio_Panamericana.Modelos
{
    public class Kardex
    {
        public int IdKardex { get; set; }
        public bool Natacion { get; set; }
        public bool Comida { get; set; }
        public bool Desayuno { get; set; }
        public string Horario { get; set; }
        public int idAlumno { get; set; }
    }
}
