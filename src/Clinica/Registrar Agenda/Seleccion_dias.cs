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
        List<Int32> dias;
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
            dias = new List<Int32>();
            if (this.checkBox1.Checked)
            {
                dias.Add(1);
            }
            if (this.checkBox2.Checked)
            {
                dias.Add(2);
            }
            if (this.checkBox3.Checked)
            {
                dias.Add(3);
            }
            if (this.checkBox4.Checked)
            {
                dias.Add(4);
            }
            if (this.checkBox5.Checked)
            {
                dias.Add(5);
            }
            if (this.checkBox6.Checked)
            {
                dias.Add(6);
            }
            
            Seleccion_horario horario = new Seleccion_horario(dias);
            horario.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
