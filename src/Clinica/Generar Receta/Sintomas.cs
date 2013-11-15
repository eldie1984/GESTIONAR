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
        private Int32 profe_id;

        public Sintomas(Int32 profesional,Int32 turno)
        {
            InitializeComponent();
            this.profe_id = profesional;
            this.turno = turno;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty && textBox2.Text != string.Empty)
            {
                DialogResult result = MessageBox.Show("Desea crear una receta?", "Receta", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                Funciones func = new Funciones();
                switch (result)
                {
                    case DialogResult.Yes:
                        func.completeConsul(this.turno, textBox1.Text, textBox2.Text);
                        Bono_farmacia farmacia = new Bono_farmacia(turno, profe_id, 0);
                        farmacia.Show();


                        this.Hide();
                        break;
                    case DialogResult.No:
                        func.completeConsul(this.turno, textBox1.Text, textBox2.Text);
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
