using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Clinica.Abm_de_Rol
{
    public partial class Elec_rol : Form
    {
        public Elec_rol()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            llenacombobox();
        }
        public void llenacombobox()
        {
            Formularios combos = new Formularios();
            DataSet rol = combos.llenaComboBoxRol();

            rolCombo.DataSource = rol.Tables[0].DefaultView;
            //se especifica el campo de la tabla
            rolCombo.DisplayMember = "rol_nombre";
            rolCombo.ValueMember = "rol_id";
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ModRol modificarRol = new ModRol();
            modificarRol.rol_id = Convert.ToInt32(this.rolCombo.SelectedValue);
            modificarRol.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
