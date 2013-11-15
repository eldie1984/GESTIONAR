using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Clinica.Registro_de_LLegada
{
    public partial class busq_prof : Form
    {
        public Form MiParent;

        public busq_prof()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Formularios profesional = new Formularios();
            DataSet profeLista = profesional.listarProfesionales(textBox1.Text);
            dataGridView1.DataSource = profeLista.Tables[0].DefaultView;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CheckTurno turno = new CheckTurno(Convert.ToInt32(dataGridView1.CurrentRow.Cells["prof_id"].Value.ToString()));
            turno.Show();
            turno.parent = this;
            turno.MiParent = this.MiParent;
            this.Hide();
        }
    }
}
