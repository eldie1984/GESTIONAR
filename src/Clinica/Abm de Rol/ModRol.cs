using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica.Model;

namespace Clinica.Abm_de_Rol
{
    public partial class ModRol : Form
    {
        private Rol rolSeleccionado;
        private DataAccessLayer dataAccess;
        private List<Funcion> funciones;
        public Form padre;

        public ModRol(Rol rol)
        {
            InitializeComponent();
            this.rolSeleccionado = rol;

        }

        private void ModRol_Load(object sender, EventArgs e)
        {
            funciones = new List<Funcion>();
            this.dataAccess = new DataAccessLayer();

            if (rolSeleccionado.id >= 0)
            {
                 this.textBox1.Text = rolSeleccionado.nombre;
                 this.checkBox1.Checked = rolSeleccionado.borrado;

                 funciones = this.dataAccess.getFunc(rolSeleccionado.id);

                 foreach (Funcion funcion in funciones)
                 {
                     dataGridView1.Rows.Add(funcion.id,funcion.nombre,funcion.estado);
                 }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.dataAccess = new DataAccessLayer();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                foreach (Funcion funcion in this.funciones)
                {
                   
                    if (Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value.ToString()) == funcion.id)
                    {
                        funcion.estado = Convert.ToBoolean(dataGridView1.Rows[i].Cells[2].Value.ToString());
                    }
                }
            }
            dataAccess.AddRolFunction(funciones.Where(Funcion => Funcion.estado == true).ToList(), rolSeleccionado.id);
            dataAccess.DelRolFunction(funciones.Where(Funcion => Funcion.estado == false).ToList(), rolSeleccionado.id);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            padre.Show();
        }
        
    }
}
