using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica.Model;

namespace Clinica
{
    public partial class Perfil : Form
    {
        private Int32 user_id;
        public Form parent;
        private DataAccessLayer dataAccess;

        public Perfil(Int32 usuario)
        {
            InitializeComponent();
            this.user_id = usuario;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Close();
        }

        private void Perfil_Load(object sender, EventArgs e)
        {
            //Formularios dataPerfil = new Formularios();
            //DataSet ds_perfil = dataPerfil.llenaComboboxPerfil(user_id);
            //comboBox1.DataSource = ds_perfil.Tables[0].DefaultView;
            ////se especifica el campo de la tabla
            //comboBox1.DisplayMember = "rol_nombre";
            //comboBox1.ValueMember = "rol_id";

            this.dataAccess = new DataAccessLayer();
            comboBox1.DataSource = dataAccess.getRol(this.user_id);
            comboBox1.DisplayMember = "nombre";
            comboBox1.ValueMember = "id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Main principal = new Main(Convert.ToInt32(comboBox1.SelectedValue), this.user_id);
            Main principal = new Main(this.dataAccess.getUser(this.user_id,Convert.ToInt32(comboBox1.SelectedValue)));
            principal.Show();
            principal.parentForm = parent;
            this.Hide();
        }

       
    }
}
