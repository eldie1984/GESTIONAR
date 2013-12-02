using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica.Model;

namespace Clinica.Generar_Receta
{
    public partial class SelectHora : Form
    {
        private Int32 profe_id;
        private DataAccessLayer dataAccess;

        public SelectHora(Int32 profesional)
        {
            InitializeComponent();
            this.profe_id = profesional;
            this.dataAccess = new DataAccessLayer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Int32 turno = this.dataAccess.getTurnoId(this.profe_id, dateTimePicker1.Value);

            Int32 bono = this.dataAccess.getBono(Convert.ToInt32(this.comboBox1.SelectedValue.ToString()));
            //if (turno > 0)
            //{
            Sintomas sintomas = new Sintomas(this.profe_id, Convert.ToInt32(this.comboBox1.SelectedValue.ToString()), bono);
                sintomas.parent = this;
                sintomas.Show();
                this.Hide();
            //}
            //else
            //{
            //    MessageBox.Show("No existe ningun turno en el horario ingresado para el profesional actual o no fue cargada la llegada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SelectHora_Load(object sender, EventArgs e)
        {
            this.comboBox1.DataSource = (from turno in this.dataAccess.getTurno(this.profe_id, true)
                                         select new { ID = turno.Codigo, Horario = turno.HoraInicio.ToString("HH:mm") }).ToList(); ;
            comboBox1.DisplayMember = "Horario";
            comboBox1.ValueMember = "ID";
        }
    }
}
