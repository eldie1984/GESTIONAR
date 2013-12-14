using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica.Model;

namespace Clinica.Abm_de_Profesional
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
            var filtronombre = this.textBoxNombre.Text;
            var filtroape = this.textBoxApellido.Text;
            string filtrodoc = String.Empty;

            int n;

            if (int.TryParse(this.textBoxDocumento.Text, out n))
            { filtrodoc = n.ToString(); }
            else if (this.textBoxDocumento.Text != String.Empty)
            {
                MessageBox.Show("El campo de filtro Documento debe ser numerico");
                return;
            }


            var listadoProf = this.dataAccess.GetProfesionales(filtronombre, filtroape, filtrodoc);
            this.dataGridView1.DataSource = listadoProf;
            
        }


        private void buttonModificar_Click(object sender, EventArgs e)
        {


            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                selected = this.dataGridView1.SelectedRows[0].DataBoundItem as Profesional;
                var ModWindow = new AltaProfesional(selected);
                
                ModWindow.ShowDialog();
                buttonBuscar_Click(this, new EventArgs());
            }
            else
            { MessageBox.Show("Debe seleccion un elemento de la lista"); }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            { selected = this.dataGridView1.SelectedRows[0].DataBoundItem as Profesional;
            this.dataAccess.BajaProfesional(selected);
            buttonBuscar_Click(this, new EventArgs());
            }
            else
            { MessageBox.Show("Debe seleccion un elemento de la lista"); }
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            this.textBoxApellido.Clear();
            this.textBoxNombre.Clear();
            this.textBoxDocumento.Clear();
        }
    }
}
