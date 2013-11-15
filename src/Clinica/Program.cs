using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using Clinica.Compra_de_Bono;
using Clinica;

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
           // Application.Run(new ListadoProfesional());
           // Application.Run(new AltaAfiliado());
           // Application.Run(new ListadoAfiliado());
            //Application.Run(new CompraBonos(0,0));
            Application.Run(new Generar_Receta.Bono_farmacia(56566, 23, 6263));
            
            //Application.Run(new Login());

            //ejemplo traer fecha del sistema
           // DateTime a = Helper.GetFechaNow();
            
        }
    }
}
