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
        public Seleccion_semestre(Int32 numeroreporte, string titular)
        {
            InitializeComponent();
            this.reporte = numeroreporte;
            this.Text = titular;

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
            if (comboBox1.SelectedItem != string.Empty && comboBox2.SelectedItem != string.Empty)
            {
                Pantalla pantalla = new Pantalla(Convert.ToInt32(comboBox1.SelectedItem), Convert.ToInt32(comboBox2.SelectedItem) - 1, this.reporte, this.Text);
                pantalla.padre = this;
                pantalla.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Debe ingresar un año o un semestre para continuar", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
