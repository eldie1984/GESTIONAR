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
        private Int32 afil_id;
        public List<Int32> medic_list = new List<Int32>();
        public List<Int32> medic_cant = new List<Int32>();

        public medicamentos(Int32 turno, Int32 bono,Int32 afiliado)
        {
            InitializeComponent();
            this.turno = turno;
            this.bono_id = bono;
            this.afil_id=afiliado;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             if (check_lista(Convert.ToInt32(comboBox1.SelectedValue)))
             {
             this.medic_list.Add(Convert.ToInt32(comboBox1.SelectedValue));
             this.medic_cant.Add(Convert.ToInt32(comboBox2.SelectedValue));
                 comboBox1.Enabled=false;
                 comboBox2.Enabled=false;
             }
            else
             {
                 return;
             }
            if (check_lista(Convert.ToInt32(comboBox4.SelectedValue)))
             {
             this.medic_list.Add(Convert.ToInt32(comboBox4.SelectedValue));
             this.medic_cant.Add(Convert.ToInt32(comboBox3.SelectedValue));
                 comboBox4.Enabled=false;
                 comboBox3.Enabled=false;
             }
            else
             {
                 return;
             }
            if (check_lista(Convert.ToInt32(comboBox6.SelectedValue)))
             {
             this.medic_list.Add(Convert.ToInt32(comboBox6.SelectedValue));
             this.medic_cant.Add(Convert.ToInt32(comboBox5.SelectedValue));
                 comboBox6.Enabled=false;
                 comboBox5.Enabled=false;
             }
            else
             {
                 return;
             }
            if (check_lista(Convert.ToInt32(comboBox8.SelectedValue)))
             {
             this.medic_list.Add(Convert.ToInt32(comboBox8.SelectedValue));
             this.medic_cant.Add(Convert.ToInt32(comboBox7.SelectedValue));
                 comboBox8.Enabled=false;
                 comboBox7.Enabled=false;
             }
            else
             {
                 return;
             }
            if (check_lista(Convert.ToInt32(comboBox10.SelectedValue)))
             {
             this.medic_list.Add(Convert.ToInt32(comboBox10.SelectedValue));
             this.medic_cant.Add(Convert.ToInt32(comboBox9.SelectedValue));
                 comboBox10.Enabled=false;
                 comboBox9.Enabled=false;
             }
            else
             {
                 return;
             }


             DialogResult result = MessageBox.Show("Necesita agregar otra orden?", "Receta", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
             Funciones func = new Funciones();
            switch (result)
            {
                case DialogResult.Yes:

                    Bono_farmacia farmacia = new Bono_farmacia(turno, afil_id);
                    farmacia.Show();


                    this.Hide();
                    break;
                case DialogResult.No:
                    this.Close();
                    parent.Close();
                    break;
            }
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

        private bool check_lista (int valor)
        {
            foreach (Int32 lista in this.medic_list)
            {
                if (lista == valor)
                {
                    MessageBox.Show("Existen medicamentos que ya han sido elegidos, por favor corrijalos", "Error");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return true;
        }       

    }
}
