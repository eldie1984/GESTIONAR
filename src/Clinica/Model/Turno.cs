using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica.Model
{
    public class Turno
    {
        public int Codigo { get; set; }
        public int Prof_ID { get; set; }
        public int AFIL_ID { get; set; }
        public int AFIL_SUBID { get; set; }
        public DateTime HoraInicio { get; set; }
    }
}
