using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio_Panamericana.Modelos
{
    public class ConceptoPago
    {
        public int idConcepto { get; set; }
        public int idAlumno { get; set; }
        public double Abono { get; set; }
        public double Total { get; set; }
        public int No_Pago { get; set; }
    }
}
