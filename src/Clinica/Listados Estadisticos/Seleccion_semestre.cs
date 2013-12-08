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
    public partial class Seleccion_semestre : Form
    {
        private Int32 reporte;
        public Seleccion_semestre(Int32 numeroreporte)
        {
            InitializeComponent();
            this.reporte = numeroreporte;

        }

        private void Seleccion_semestre_Load(object sender, EventArgs e)
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
            Pantalla pantalla = new Pantalla(Convert.ToInt32(comboBox1.SelectedText),Convert.ToInt32(comboBox2.SelectedText)-1,this.reporte);
            pantalla.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
