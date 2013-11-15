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
    public partial class Seleccion_dias : Form
    {
        private Int32 prof_id;
        public Seleccion_dias(Int32 user)
        {
            InitializeComponent();
            this.prof_id = user;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Seleccion_horario horario = new Seleccion_horario();
            horario.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
