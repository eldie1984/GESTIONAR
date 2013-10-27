using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.Model;

namespace Clinica_Frba.Abm_de_Profesional
{
    public partial class ListadoProfesional : Form
    {
        private DataAccessLayer dataAccess;
        private Profesional selected;

        public ListadoProfesional()
        {
            this.dataAccess = new DataAccessLayer();
            InitializeComponent();
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.MultiSelect = false;
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            var listadoProf = this.dataAccess.GetProfesionales();
            this.dataGridView1.DataSource = listadoProf;
            
        }


        private void buttonModificar_Click(object sender, EventArgs e)
        {


            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                selected = this.dataGridView1.SelectedRows[0].DataBoundItem as Profesional;
                var ModWindow = new AltaProfesional(selected);
                
                ModWindow.Show();
            }
            else
            { MessageBox.Show("Debe seleccion un elemento de la lista"); }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
                selected = this.dataGridView1.SelectedRows[0].DataBoundItem as Profesional;
            else
            { MessageBox.Show("Debe seleccion un elemento de la lista"); }
        }
    }
}
