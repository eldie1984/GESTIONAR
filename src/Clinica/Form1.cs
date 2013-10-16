using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Clinica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuarios1 Usuario0b = new Usuarios1();
            Usuario0b.Usuario = this.text1.Text;
            Usuario0b.Contraseña = Usuario0b.getHashSha256(this.text2.Text);
            if (Usuario0b.Buscar() == true)
            {
                MessageBox.Show(Usuario0b.Mensaje, "Login");
                Usuario0b.reset_login();
            }
            else
            {
                MessageBox.Show(Usuario0b.Mensaje, "Error");
                Usuario0b.fail_login();
                text2.Text = string.Empty;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
