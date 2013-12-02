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

        public select_profesional(List<Agenda> dias,DateTime desde,DateTime hasta)
        {
            InitializeComponent();
            this.Dias = dias;
            this.Desde = desde;
            this.Hasta = hasta;
            this.dataAccess = new DataAccessLayer();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            QueryResult salida = this.dataAccess.AddAgenda(Dias, Desde, Hasta, Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value.ToString()));

            if (salida.ID == 0)
            {
                this.Close();
                padre.Close();
            }
            else
            {
                MessageBox.Show("Ocurrio un error al generar la agenda", "Error");
            }
             
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Formularios profesional = new Formularios();
            //DataSet profeLista = profesional.listarProfesionales(textBox1.Text);
            //dataGridView1.DataSource = profeLista.Tables[0].DefaultView;
            if (textBox1.Text != string.Empty)
            {
                List<Profesional> profesionales_list = this.dataAccess.GetProfesionales(textBox1.Text, null, null);
                profesionales_list.AddRange(this.dataAccess.GetProfesionales(null, textBox1.Text, null));
                dataGridView1.DataSource = (from profesional in profesionales_list
                                            select new { ID = profesional.ID, Nombre = profesional.Nombre, Apellido = profesional.Apellido }).ToList();
            }
            else
            {
                dataGridView1.DataSource = this.dataAccess.GetProfesionales(null, null, null);
            }
        }
    }
}
