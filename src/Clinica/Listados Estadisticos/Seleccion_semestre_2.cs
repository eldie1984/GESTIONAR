using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Clinica.Listados_Estadisticos
{
    public partial class Seleccion_semestre_2 : Form
    {
        public Seleccion_semestre_2()
        {
            InitializeComponent();
        }

        private void Seleccion_semestre_2_Load(object sender, EventArgs e)
        {
            comboBox2.Items.Add("1");
            comboBox2.Items.Add("2");
            comboBox1.Items.Add("2009");
            comboBox1.Items.Add("2010");
            comboBox1.Items.Add("2011");
            comboBox1.Items.Add("2012");
            comboBox1.Items.Add("2013");
            comboBox1.Items.Add("2014");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pantalla2 pantalla = new Pantalla2();
            pantalla.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
