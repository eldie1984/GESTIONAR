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
    public partial class SelectHora : Form
    {
        private Int32 profe_id;

        public SelectHora(Int32 profesional)
        {
            InitializeComponent();
            this.profe_id = profesional;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Funciones func = new Funciones();
            Int32 turno = func.getTurnoId(this.profe_id, dateTimePicker1.Value);
            Sintomas sintomas = new Sintomas(this.profe_id,turno);
            sintomas.parent=this;
            sintomas.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
