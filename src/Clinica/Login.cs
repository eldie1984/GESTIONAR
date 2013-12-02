using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using Clinica.Model;

namespace Clinica
{
    public partial class Login : Form
    {
        private DataAccessLayer dataAccess;

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.dataAccess = new DataAccessLayer();
            QueryResult resultado;
            resultado=this.dataAccess.Buscar(this.text1.Text,getHashSha256(this.text2.Text));
            if ( resultado.correct == true)
            {
                MessageBox.Show(resultado.mensaje, "Login");
                Perfil perfil = new Perfil(resultado.ID);
                perfil.Show();
                perfil.parent = this;
                this.Hide();
            }
            else
            {
                MessageBox.Show(resultado.mensaje, "Error");
                text2.Text = string.Empty;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public string getHashSha256(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }
    }
}
