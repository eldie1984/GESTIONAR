﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Clinica.Registro_de_LLegada
{
    public partial class CheckTurno : Form
    {
        private Int32 profe_id;
        public Form parent;
        public Form MiParent;

        public CheckTurno(Int32 profesional)
        {
            InitializeComponent();
            this.profe_id = profesional;
        }

        private void CheckTurno_Load(object sender, EventArgs e)
        {
            Formularios datos_turn = new Formularios();
            DataSet turnos = datos_turn.llenaComboBoxTurno(this.profe_id);

            comboBox1.DataSource = turnos.Tables[0].DefaultView;
            //se especifica el campo de la tabla
            comboBox1.DisplayMember = "Turno";
            comboBox1.ValueMember = "turn_id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Funciones func = new Funciones();
            if (func.checkTurno(Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(maskedTextBox1.Text), Convert.ToInt32(maskedTextBox2.Text)))
            {
                Ingreso_bono bono_consulta = new Ingreso_bono(Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(maskedTextBox1.Text), Convert.ToInt32(maskedTextBox2.Text));
                bono_consulta.Show();
                bono_consulta.parent = this.parent;
                bono_consulta.MiParent = this.MiParent;
                this.Hide();
            }
            else
            {
                MessageBox.Show("No existe ningun turno para el usuario indicado en el horario indicado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Show();
        }
    }
}
