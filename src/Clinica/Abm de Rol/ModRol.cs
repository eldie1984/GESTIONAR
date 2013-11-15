using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Clinica.Abm_de_Rol
{
    public partial class ModRol : Form
    {
        public Int32 rol_id = -1 ;
        private SqlDataReader lectura;

        public ModRol()
        {
            InitializeComponent();
        }

        private void ModRol_Load(object sender, EventArgs e)
        {
            if (rol_id >= 0)
            {
                Formularios datos_rol = new Formularios();
                Formularios datos_func = new Formularios();
                lectura = datos_rol.datos_rol(this.rol_id);
                DataSet FuncLista = datos_func.datos_func(this.rol_id);
                if (lectura == null)
                {
                    MessageBox.Show("No hay ningun cliente cargado");

                }
                else
                {
                 lectura.Read();
                 this.textBox1.Text = lectura["rol_nombre"].ToString();
                 this.checkBox1.Checked = Convert.ToBoolean(lectura["rol_borrado"]);

                 
                 dataGridView1.DataSource = FuncLista.Tables[0].DefaultView;
                 //dataGridView1.Columns["Habilitado"].ReadOnly = false;
                 //dataGridView1.Columns[2].ValueType = typeof(CheckBox);
                //    DataGridViewTextBoxColumn colid= new DataGridViewTextBoxColumn();
                
                     
                     //.Columns["Habilitado"].CellType = "DataGridViewCheckBoxCell";
                 
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        
    }
}
