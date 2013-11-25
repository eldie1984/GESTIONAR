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
        private DataAccessLayer dataAccess;

        public SelectHora(Int32 profesional)
        {
            InitializeComponent();
            this.profe_id = profesional;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.dataAccess = new DataAccessLayer();
            Int32 turno = this.dataAccess.getTurnoId(this.profe_id, dateTimePicker1.Value);
            Int32 bono = this.dataAccess.getBono(turno);
            if (turno > 0)
            {
                Sintomas sintomas = new Sintomas(this.profe_id, turno,bono);
                sintomas.parent = this;
                sintomas.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("No existe ningun turno en el horario ingresado para el profesional actual o no fue cargada la llegada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SelectHora_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = Helper.GetFechaNow();
        }
    }
}
