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
    public partial class medicamentos : Form
    {
        public Form parent;
        private Int32 turno;
        private Int32 bono_id;

        public medicamentos(Int32 turno, Int32 bono)
        {
            InitializeComponent();
            this.turno = turno;
            this.bono_id = bono;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void medicamentos_Load(object sender, EventArgs e)
        {
            
            comboBox2.Items.Add("1");
            comboBox2.Items.Add("2");
            comboBox2.Items.Add("3");
            comboBox3.Items.Add("1");
            comboBox3.Items.Add("2");
            comboBox3.Items.Add("3");
            comboBox5.Items.Add("1");
            comboBox5.Items.Add("2");
            comboBox5.Items.Add("3");
            comboBox7.Items.Add("1");
            comboBox7.Items.Add("2");
            comboBox7.Items.Add("3");
            comboBox9.Items.Add("1");
            comboBox9.Items.Add("2");
            comboBox9.Items.Add("3");

            Formularios datos_med = new Formularios();
            Formularios datos_med1 = new Formularios();
            Formularios datos_med2 = new Formularios();
            Formularios datos_med3 = new Formularios();
            Formularios datos_med4 = new Formularios();
            DataSet medicamentos = datos_med.llenaComboBoxMedic();
            DataSet medicamentos1 = datos_med1.llenaComboBoxMedic();
            DataSet medicamentos2 = datos_med2.llenaComboBoxMedic();
            DataSet medicamentos3 = datos_med3.llenaComboBoxMedic();
            DataSet medicamentos4 = datos_med4.llenaComboBoxMedic();
            comboBox1.DataSource = medicamentos.Tables[0].DefaultView;
            //se especifica el campo de la tabla
            comboBox1.DisplayMember = "medic_descripcion";
            comboBox1.ValueMember = "medic_id";
            comboBox4.DataSource = medicamentos1.Tables[0].DefaultView;
            //se especifica el campo de la tabla
            comboBox4.DisplayMember = "medic_descripcion";
            comboBox4.ValueMember = "medic_id";
            comboBox6.DataSource = medicamentos2.Tables[0].DefaultView;
            //se especifica el campo de la tabla
            comboBox6.DisplayMember = "medic_descripcion";
            comboBox6.ValueMember = "medic_id";
            comboBox8.DataSource = medicamentos3.Tables[0].DefaultView;
            //se especifica el campo de la tabla
            comboBox8.DisplayMember = "medic_descripcion";
            comboBox8.ValueMember = "medic_id";
            comboBox10.DataSource = medicamentos4.Tables[0].DefaultView;
            //se especifica el campo de la tabla
            comboBox10.DisplayMember = "medic_descripcion";
            comboBox10.ValueMember = "medic_id";
            
        }
    }
}
