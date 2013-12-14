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

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            //Formularios profesional = new Formularios();
            //DataSet profeLista = profesional.listarProfesionales(textBox1.Text);
            //dataGridView1.DataSource = profeLista.Tables[0].DefaultView;
            this.dataAccess = new DataAccessLayer();
            string nombre = null;
            string apellido = null;
            string dni = null;
            if (textBoxNombre.Text != string.Empty)
            {
                nombre = textBoxNombre.Text;
            }
             if (textBoxNombre.Text != string.Empty)
            {
                apellido = textBoxApellido.Text;
            }

            if ( textBoxDocumento.Text != string.Empty)
            {
                dni = textBoxDocumento.Text;
            }

            List<Profesional> profesionales_list = this.dataAccess.GetProfesionales(nombre, apellido, dni);

                dataGridView1.DataSource = (from profesional in profesionales_list
                                            select new { ID = profesional.ID, Nombre = profesional.Nombre, Apellido = profesional.Apellido }).ToList();
                ;
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            this.textBoxApellido.Text = string.Empty;
            this.textBoxNombre.Text = string.Empty;
            this.textBoxDocumento.Text = string.Empty;
        }
    }
}
