﻿using System;
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
        private Int32 afil_id;
        public Form padre ;
        private DataAccessLayer dataAccess;
        public List<Int32> medic_hist = new List<Int32>();

        public Bono_farmacia(Int32 turno, Int32 afiliado)
        {
            InitializeComponent();
            this.turno = turno;
            this.afil_id = afiliado;
            this.padre = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool error = false;
            this.dataAccess = new DataAccessLayer();
            Int32 bono_id=0;
            try
            {
                bono_id=Convert.ToInt32(textBox1.Text);
            }
            catch
            {
                error = true;
                MessageBox.Show("El bono puede ser solo numerico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (error == false && this.dataAccess.checkBono(bono_id))
            {
                medicamentos medic = new medicamentos(this.turno, bono_id, this.afil_id);
                medic.medic_hist = this.medic_hist;
                medic.Show();
                this.Hide();
                medic.parent = this.padre;
                
            }

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
