using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Clinica_Frba.Abm_de_Profesional;
using Clinica_Frba.Abm_de_Afiliado;

namespace Clinica
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            //Application.Run(new AltaProfesional(null));
            //Application.Run(new ListadoProfesional());
            // Application.Run(new AltaAfiliado());
            Application.Run(new ListadoAfiliado());
        }
    }
}
