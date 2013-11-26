using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica.Model;

namespace Clinica.Registrar_Agenda
{
    public partial class Seleccion_fecha : Form
    {
        List<Agenda> dias;
        DateTime Desde;
        DateTime Hasta;

        public Seleccion_fecha(List<Agenda> Dias)
        {
            InitializeComponent();
            this.dias = Dias;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Desde = Convert.ToDateTime(this.dateTimePicker1.Value.ToString("yyyy/MM/dd"));
            Hasta = Convert.ToDateTime(this.dateTimePicker2.Value.ToString("yyyy/MM/dd"));

            if (Desde < Helper.GetFechaNow().AddDays(120) || Hasta <= Helper.GetFechaNow().AddDays(120) || Desde != Hasta)
            {
                select_profesional profesional = new select_profesional(dias,Desde,Hasta);
                profesional.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Las fechas Desde y Hasta de la jornada no pueden ser mayores a 120 dias ni ser iguales", "Error");
            }
        }
    }
}
