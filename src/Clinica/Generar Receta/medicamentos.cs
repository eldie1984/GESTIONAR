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
        private Int32 consulta;
        private Int32 bono_id;
        private Int32 afil_id;
        public List<Int32> medic_list = new List<Int32>();
        public List<Int32> medic_hist = new List<Int32>();
        public List<Int32> medic_cant = new List<Int32>();
        private DataAccessLayer dataAccess;
        int[] arr = new int[5];

        public medicamentos(Int32 consulta, Int32 bono, Int32 afiliado)
        {
            InitializeComponent();
            this.consulta = consulta;
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
            this.dataAccess = new DataAccessLayer();
            if (Convert.ToInt32(comboBox1.SelectedValue) != -1 && comboBox2.SelectedItem != null)
            {
                if (arr[0] == 0 && check_lista(Convert.ToInt32(comboBox1.SelectedValue)))
                {
                    this.medic_list.Add(Convert.ToInt32(comboBox1.SelectedValue));
                    this.medic_hist.Add(Convert.ToInt32(comboBox1.SelectedValue));
                    this.medic_cant.Add(Convert.ToInt32(comboBox2.SelectedItem));
                    comboBox1.Enabled = false;
                    comboBox2.Enabled = false;
                    arr[0] = 1;
                }
                else if (arr[0] == 0)
                {
                    return;
                }
            }
            else if ((Convert.ToInt32(comboBox1.SelectedValue) != -1 && comboBox2.SelectedItem == null) || (Convert.ToInt32(comboBox1.SelectedValue) == -1 && comboBox2.SelectedItem != null))
            {
                MessageBox.Show("El campo medicamento o el de cantidad esta vacio", "Error");
                return;
            }

            if (Convert.ToInt32(comboBox4.SelectedValue) != -1 && comboBox3.SelectedItem != null)
            {
                if (arr[1] == 0 && check_lista(Convert.ToInt32(comboBox4.SelectedValue)))
                {
                    this.medic_list.Add(Convert.ToInt32(comboBox4.SelectedValue));
                    this.medic_hist.Add(Convert.ToInt32(comboBox4.SelectedValue));
                    this.medic_cant.Add(Convert.ToInt32(comboBox3.SelectedItem));
                    comboBox4.Enabled = false;
                    comboBox3.Enabled = false;
                    arr[1] = 1;
                }
                else if (arr[1] == 0)
                {
                    return;
                }
            }
            else if ((comboBox3.SelectedItem != null && Convert.ToInt32(comboBox4.SelectedValue) == -1) || (comboBox3.SelectedItem == null && Convert.ToInt32(comboBox4.SelectedValue) != -1))
            {
                MessageBox.Show("El campo medicamento o el de cantidad esta vacio", "Error");
                return;
            }

            if (Convert.ToInt32(comboBox6.SelectedValue) != -1 && comboBox5.SelectedItem != null)
            {
                if (arr[2] == 0 && check_lista(Convert.ToInt32(comboBox6.SelectedValue)))
                {
                    this.medic_list.Add(Convert.ToInt32(comboBox6.SelectedValue));
                    this.medic_hist.Add(Convert.ToInt32(comboBox6.SelectedValue));
                    this.medic_cant.Add(Convert.ToInt32(comboBox5.SelectedItem));
                    comboBox6.Enabled = false;
                    comboBox5.Enabled = false;
                    arr[2] = 1;
                }
                else if (arr[2] == 0)
                {
                    return;
                }
            }
            else if ((comboBox5.SelectedItem != null && Convert.ToInt32(comboBox6.SelectedValue) == -1) || (comboBox5.SelectedItem == null && Convert.ToInt32(comboBox6.SelectedValue) != -1))
            {
                MessageBox.Show("El campo medicamento o el de cantidad esta vacio", "Error");
                return;
            }
            if (comboBox7.SelectedItem != null && Convert.ToInt32(comboBox8.SelectedValue) != -1)
            {
                if (arr[3] == 0 && check_lista(Convert.ToInt32(comboBox8.SelectedValue)))
                {
                    this.medic_list.Add(Convert.ToInt32(comboBox8.SelectedValue));
                    this.medic_hist.Add(Convert.ToInt32(comboBox8.SelectedValue));
                    this.medic_cant.Add(Convert.ToInt32(comboBox7.SelectedItem));
                    comboBox8.Enabled = false;
                    comboBox7.Enabled = false;
                    arr[3] = 1;
                }
                else if (arr[3] == 0)
                {
                    return;
                }
            }
            else if ((comboBox7.SelectedItem != null && Convert.ToInt32(comboBox8.SelectedValue) == -1) || (comboBox7.SelectedItem == null && Convert.ToInt32(comboBox8.SelectedValue) != -1))
            {
                MessageBox.Show("El campo medicamento o el de cantidad esta vacio", "Error");
                return;
            }
            if (comboBox9.SelectedItem != null && Convert.ToInt32(comboBox10.SelectedValue) != -1)
            {
                if (arr[4] == 0 && check_lista(Convert.ToInt32(comboBox10.SelectedValue)))
                {
                    this.medic_list.Add(Convert.ToInt32(comboBox10.SelectedValue));
                    this.medic_hist.Add(Convert.ToInt32(comboBox10.SelectedValue));
                    this.medic_cant.Add(Convert.ToInt32(comboBox9.SelectedItem));
                    comboBox10.Enabled = false;
                    comboBox9.Enabled = false;
                    arr[4] = 1;
                }
                else if (arr[4] == 0)
                {
                    return;
                }
            }
            else if ((comboBox9.SelectedItem != null && Convert.ToInt32(comboBox10.SelectedValue) == -1) || (comboBox9.SelectedItem == null && Convert.ToInt32(comboBox10.SelectedValue) != -1))
            {
                MessageBox.Show("El campo medicamento o el de cantidad esta vacio", "Error");
                return;
            }

            if (medic_list.Count % 5 == 0)
            {
                DialogResult result = MessageBox.Show("Necesita agregar otra orden?", "Receta", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
           
                switch (result)
                {
                    case DialogResult.Yes:
                        this.dataAccess.persistir_medic(medic_list, medic_cant, afil_id, bono_id, consulta);
                        Bono_farmacia farmacia = new Bono_farmacia(consulta, afil_id);
                        farmacia.padre = this.parent;
                        farmacia.medic_hist = this.medic_hist;
                        farmacia.Show();


                        this.Hide();
                        break;
                    case DialogResult.No:
                        this.dataAccess.persistir_medic(medic_list, medic_cant, afil_id, bono_id, consulta);
                        this.Close();
                        parent.Close();
                        break;
                }
            }
            else
            {
                this.dataAccess.persistir_medic(medic_list, medic_cant, afil_id, bono_id, consulta);
                this.Close();
                parent.Close();
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
            for (int i=0; i< 5; i++)
            {arr[i]=0;}
            
        }

        private bool check_lista (int valor)
        {
            foreach (Int32 lista in this.medic_hist)
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
