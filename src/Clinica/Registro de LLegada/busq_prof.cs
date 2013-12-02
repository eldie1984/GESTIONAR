using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica.Model;

namespace Clinica.Registro_de_LLegada
{
    public partial class busq_prof : Form
    {
        public Form MiParent;
        private DataAccessLayer dataAccess;

        public busq_prof()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Formularios profesional = new Formularios();
            //DataSet profeLista = profesional.listarProfesionales(textBox1.Text);
            //dataGridView1.DataSource = profeLista.Tables[0].DefaultView;
            this.dataAccess = new DataAccessLayer();
            if (textBox1.Text != string.Empty)
            {
                List<Profesional> profesionales_list = this.dataAccess.GetProfesionales(textBox1.Text, null, null);
                profesionales_list.AddRange(this.dataAccess.GetProfesionales(null, textBox1.Text, null));

                dataGridView1.DataSource = (from profesional in profesionales_list
                                            select new { ID = profesional.ID, Nombre = profesional.Nombre, Apellido = profesional.Apellido }).ToList();
                    ;
            }
            else
            {
                dataGridView1.DataSource = this.dataAccess.GetProfesionales(null, null, null);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CheckTurno turno = new CheckTurno(Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value.ToString()));
            turno.Show();
            turno.parent = this;
            turno.MiParent = this.MiParent;
            this.Hide();
        }
    }
}
