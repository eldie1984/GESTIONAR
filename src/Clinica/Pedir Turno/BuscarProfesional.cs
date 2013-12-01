using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica.Model;

namespace Clinica.Pedir_Turno
{
    public partial class BuscarProfesional : Form
    {
        private DataAccessLayer dataAccess;
        private Profesional selected;
        private Form formParent;
        private List<Profesional> listadoProf;
        private int espec=0;

        public BuscarProfesional(Form parent, int especialidad)
        {
            if (especialidad > 0)
                this.espec = especialidad;

            this.formParent = parent;
            this.dataAccess = new DataAccessLayer();
            InitializeComponent();
            Buscar();
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.MultiSelect = false;
        }

        private void buttonSelec_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                selected = this.dataGridView1.SelectedRows[0].DataBoundItem as Profesional;

                ((PedirTurno)this.formParent).callWhenChildProfClick(selected);

                this.Close();

            }
            else
            { MessageBox.Show("Debe seleccion un elemento de la lista"); }
        }


        private void Buscar()
        {

            if (this.espec > 0)
                this.listadoProf = this.dataAccess.GetProfesionales(this.espec);
            else
                this.listadoProf = this.dataAccess.GetProfesionales(null, null, null);
            
            
            this.dataGridView1.DataSource = listadoProf;

        }


        //private void buttonModificar_Click(object sender, EventArgs e)
        //{


        //    if (this.dataGridView1.SelectedRows.Count > 0)
        //    {
        //        selected = this.dataGridView1.SelectedRows[0].DataBoundItem as Profesional;
        //        var ModWindow = new AltaProfesional(selected);

        //        ModWindow.ShowDialog();
        //        buttonBuscar_Click(this, new EventArgs());
        //    }
        //    else
        //    { MessageBox.Show("Debe seleccion un elemento de la lista"); }
        //}

        //private void buttonDelete_Click(object sender, EventArgs e)
        //{
        //    if (this.dataGridView1.SelectedRows.Count > 0)
        //    { selected = this.dataGridView1.SelectedRows[0].DataBoundItem as Profesional;
        //    this.dataAccess.BajaProfesional(selected);
        //    buttonBuscar_Click(this, new EventArgs());
        //    }
        //    else
        //    { MessageBox.Show("Debe seleccion un elemento de la lista"); }
        //}

        //private void buttonLimpiar_Click(object sender, EventArgs e)
        //{
        //    this.textBoxApellido.Clear();
        //    this.textBoxNombre.Clear();
        //    this.textBoxDocumento.Clear();
        //}
    }
       
}
