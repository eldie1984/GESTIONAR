using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica.Model
{
    public class Profesional
    {
        public int ID { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Tipo { get; set; }

        public decimal Documento { get; set; }

        public string Direccion { get; set; }

        public decimal Telefono { get; set; }

        public string Mail { get; set; }

        public DateTime FechaNac { get; set; }

        public string Sexo { get; set; }

        public string Matricula { get; set; }

        public List<int> Especialidades { get; set; }

        
    }
}
