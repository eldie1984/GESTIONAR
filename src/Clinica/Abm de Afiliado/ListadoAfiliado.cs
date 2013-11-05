using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.Model;

namespace Clinica_Frba.Abm_de_Afiliado
{
    public partial class ListadoAfiliado : Form
    {
        private DataAccessLayer dataAccess;
        private Afiliado selected;

        public ListadoAfiliado()
        {
            this.dataAccess = new DataAccessLayer();
            InitializeComponent();
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.MultiSelect = false;
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
         
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            var listadoAfil = this.dataAccess.GetAfiliados();
            this.dataGridView1.DataSource = listadoAfil;
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                selected = this.dataGridView1.SelectedRows[0].DataBoundItem as Afiliado;
                var ModWindow = new ModificacionAfiliado(selected);

                ModWindow.Show();
            }
            else
            { MessageBox.Show("Debe seleccion un elemento de la lista"); }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                selected = this.dataGridView1.SelectedRows[0].DataBoundItem as Afiliado;
                this.dataAccess.BajaAfiliado(selected);
                buttonBuscar_Click(this, new EventArgs());
                
            }
            else
            { MessageBox.Show("Debe seleccion un elemento de la lista"); }
        }
    }
}
