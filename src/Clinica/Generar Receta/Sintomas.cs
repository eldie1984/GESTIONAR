using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Clinica.Generar_Receta
{
    public partial class Sintomas : Form
    {
        public Form parent;
        private Int32 turno;
        private Int32 bono_consulta;
        private Int32 afil_id;
        private DataAccessLayer dataAccess;

        public Sintomas(Int32 afiliado, Int32 turno, Int32 bono_consulta)
        {
            InitializeComponent();
            this.afil_id = afiliado;
            this.turno = turno;
            this.bono_consulta = bono_consulta;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.dataAccess = new DataAccessLayer();
            if (textBox1.Text != string.Empty && textBox2.Text != string.Empty)
            {
                DialogResult result = MessageBox.Show("Desea crear una receta?", "Receta", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                
                switch (result)
                {
                    case DialogResult.Yes:
                        this.dataAccess.updateConsul(this.turno, textBox1.Text, textBox2.Text);
                        Bono_farmacia farmacia = new Bono_farmacia(bono_consulta,afil_id);
                        farmacia.Show();


                        this.Hide();
                        break;
                    case DialogResult.No:
                        this.dataAccess.updateConsul(this.turno, textBox1.Text, textBox2.Text);
                        this.Close();
                        parent.Close();
                        break;
                    case DialogResult.Cancel:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Los campos de Sintoma y enfermedad no pueden estar vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Show();
        }
    }
}
