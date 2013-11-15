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
    public partial class Bono_farmacia : Form
    {
        private Int32 turno;
        private Int32 profe_id;
        private Int32 afil_id;

        public Bono_farmacia(Int32 turno,Int32 profesional,Int32 afiliado)
        {
            InitializeComponent();
            this.turno = turno;
            this.profe_id = profesional;
            this.afil_id = afiliado;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            medicamentos medic = new medicamentos(this.turno, this.profe_id, this.afil_id);
            medic.Show();
            medic.parent = this;
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Esta seguro que desea salir?", "Receta", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            switch (result)
            {
                case DialogResult.No:
                    break;
                case DialogResult.Yes:
                    this.Close();
                    break;

            }
        }
    }
}
