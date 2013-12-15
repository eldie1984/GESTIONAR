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
        public Form padre;
        public Usuario profesional;

        public select_profesional(List<Agenda> dias,DateTime desde,DateTime hasta)
        {
            InitializeComponent();
            this.Dias = dias;
            this.Desde = desde;
            this.Hasta = hasta;
            this.dataAccess = new DataAccessLayer();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            this.dataAccess = new DataAccessLayer();
            string nombre = null;
            string apellido = null;
            string dni = null;
            if (textBoxNombre.Text != string.Empty)
            {
                nombre = textBoxNombre.Text;
            }
            if (textBoxApellido.Text != string.Empty)
            {
                apellido = textBoxApellido.Text;
            }

            if (textBoxDocumento.Text != string.Empty)
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            QueryResult salida = this.dataAccess.AddAgenda(Dias, Desde, Hasta, Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value.ToString()));

            if (salida.ID == 0)
            {
                MessageBox.Show("Se creo la agenda correctamente", "Info");
                this.Close();
                padre.Close();
            }
            else
            {
                MessageBox.Show("Ocurrio un error al generar la agenda", "Error");
            }
        }

        private void select_profesional_Load(object sender, EventArgs e)
        {
            if (profesional != null)
            {
                QueryResult salida = this.dataAccess.AddAgenda(Dias, Desde, Hasta, Convert.ToInt32(profesional.user_rel));

                if (salida.ID == 0)
                {
                    MessageBox.Show("Se creo la agenda correctamente", "Info");
                    this.Close();
                    padre.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al generar la agenda", "Error");
                }
            }
        }
    }
}
