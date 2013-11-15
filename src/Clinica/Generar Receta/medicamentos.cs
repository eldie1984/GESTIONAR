using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Clinica.Generar_Receta
{
    public partial class medicamentos : Form
    {
        public Form parent;
        private Int32 turno;
        private Int32 profe_id;
        private Int32 afil_id;

        public medicamentos(Int32 turno, Int32 profesional, Int32 afiliado)
        {
            InitializeComponent();
            this.turno = turno;
            this.profe_id = profesional;
            this.afil_id = afiliado;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Show();
        }
    }
}
