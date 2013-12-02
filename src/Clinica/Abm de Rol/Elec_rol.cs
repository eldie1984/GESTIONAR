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
    public partial class Elec_rol : Form
    {
        private DataAccessLayer dataAccess;
        private List<Rol> roles;

        public Elec_rol()
        {
            InitializeComponent();
            this.dataAccess = new DataAccessLayer();
            roles=dataAccess.getRol();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            rolCombo.DataSource = roles;
            rolCombo.DisplayMember = "nombre";
            rolCombo.ValueMember = "id";
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ModRol modificarRol = new ModRol(roles.Where(Rol => Rol.id == Convert.ToInt32(this.rolCombo.SelectedValue)).ToList()[0]);
            modificarRol.padre = this;
            modificarRol.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
