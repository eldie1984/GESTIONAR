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
    public partial class select_profesional : Form
    {
        private List<Agenda> Dias;
        private DateTime Desde;
        private DateTime Hasta;
        private DataAccessLayer dataAccess;

        public select_profesional(List<Agenda> dias,DateTime desde,DateTime hasta)
        {
            InitializeComponent();
            this.Dias = dias;
            this.Desde = desde;
            this.Hasta = hasta;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataAccess = new DataAccessLayer();
            for (int i =0 ; i < Dias.Count ; i++)
            {
                this.dataAccess.AddAgenda(Dias, Desde, Hasta, Convert.ToInt32(dataGridView1.CurrentRow.Cells["prof_id"].Value.ToString()));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Formularios profesional = new Formularios();
            DataSet profeLista = profesional.listarProfesionales(textBox1.Text);
            dataGridView1.DataSource = profeLista.Tables[0].DefaultView;
        }
    }
}
