using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Clinica.Registrar_Agenda
{
    public partial class Seleccion_horario : Form
    {
        List<Int32> dias;

        public Seleccion_horario(List<Int32> semana)
        {
            InitializeComponent();
            this.dias = semana;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Seleccion_fecha fecha = new Seleccion_fecha();
            fecha.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
