﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica.Model
{
    public class BonoConsulta
    {
        public int ID { get; set; }

        public int compraID { get; set; }

        public int afi_ID { get; set; }

        public int afi_Sub_ID { get; set; }

        public int numConsulta { get; set; }

        public int planID { get; set; }

    }
}
