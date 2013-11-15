using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.Model;

namespace Clinica.Abm_de_Afiliado
{
    public partial class ModificacionAfiliado : Form
    {
        private DataAccessLayer dataAccess;
        private List<Plan> listadoPlanes;
        private int subid = 1;
        private int idGrupoFamiliar;
        private Afiliado afiliadoSelected;

        public ModificacionAfiliado(Afiliado Selected)
        {
            this.afiliadoSelected = Selected;
            this.dataAccess = new DataAccessLayer();
            InitializeComponent();

            //carga opciones de sexo
            this.comboBoxSexo.DisplayMember = "Key";
            this.comboBoxSexo.ValueMember = "Value";
            this.comboBoxSexo.DataSource = new[] { new KeyValuePair<string, string>("Masculino", "M"), new KeyValuePair<string, string>("Femenino", "F") };

            //carga opciones tipo documento
            this.comboBoxDoc.DisplayMember = "Key";
            this.comboBoxDoc.ValueMember = "Value";
            this.comboBoxDoc.DataSource = new[] { new KeyValuePair<string, string>("DNI", "DNI"), new KeyValuePair<string, string>("Libreta", "LIB") };

            //carga opciones estado
            this.comboBoxEstado.DisplayMember = "Key";
            this.comboBoxEstado.ValueMember = "Value";
            this.comboBoxEstado.DataSource = new[] { new KeyValuePair<string, int>("Soltero/a", 1), new KeyValuePair<string, int>("Casado/a", 2), new KeyValuePair<string, int>("Viudo/a", 3), new KeyValuePair<string, int>("Concubinato", 4), new KeyValuePair<string, int>("Divorciado/a", 5) };

            //carga listado planes
            this.listadoPlanes = dataAccess.GetPlanes();
            this.comboBoxPlan.DisplayMember = "Descripcion";
            this.comboBoxPlan.ValueMember = "Codigo";
            this.comboBoxPlan.DataSource = listadoPlanes;

            //carga modificacion
            //
            this.buttonLimpiar.Enabled = false;
            //titulo ventana
            this.Text = "Modificacion Afiliado";

            //carga campos
            this.textBoxApellido.Text = afiliadoSelected.Apellido;
            this.textBoxNombre.Text = afiliadoSelected.Nombre;
            this.textBoxDir.Text = afiliadoSelected.Direccion;
            this.dateTimePickerFechaNac.Value = afiliadoSelected.FechaNac;
            this.textBoxMail.Text = afiliadoSelected.Mail;
            
            this.comboBoxSexo.SelectedValue = afiliadoSelected.Sexo;

            this.comboBoxDoc.SelectedValue = afiliadoSelected.Tipo;

            this.textBoxDoc.Text = afiliadoSelected.Documento.ToString();

            this.textBoxTel.Text = afiliadoSelected.Telefono.ToString();

            this.comboBoxEstado.SelectedValue = afiliadoSelected.Estado;

            this.numericUpDownHijos.Value = afiliadoSelected.Hijos;

            this.comboBoxPlan.SelectedValue = afiliadoSelected.Plan;

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            List<string> erroresValida = new List<string>();
            Afiliado afiliado = new Afiliado();

            afiliado.Apellido = this.textBoxApellido.Text;
            afiliado.Nombre = this.textBoxNombre.Text;
            afiliado.Direccion = this.textBoxDir.Text;
            afiliado.FechaNac = this.dateTimePickerFechaNac.Value;
            afiliado.Mail = this.textBoxMail.Text;
            afiliado.Sexo = this.comboBoxSexo.SelectedValue.ToString();
            afiliado.Tipo = this.comboBoxDoc.SelectedValue.ToString();
            afiliado.Estado = (int)this.comboBoxEstado.SelectedValue;
            afiliado.Hijos = (int)this.numericUpDownHijos.Value;
            afiliado.Plan = (int)this.comboBoxPlan.SelectedValue;
            afiliado.Sub_ID = this.subid;
            afiliado.ID = this.idGrupoFamiliar;

            try
            {
                afiliado.Documento = Convert.ToInt32(this.textBoxDoc.Text);
            }
            catch
            {
                erroresValida.Add("Documento puede ser solo numerico");
            }
            try
            {
                afiliado.Telefono = Convert.ToInt32(this.textBoxTel.Text);
            }
            catch
            {
                erroresValida.Add("Telefono puede ser solo numerico");
            }




            if (erroresValida.Count > 0)
            {
                StringBuilder error = new StringBuilder();
                error.AppendLine("Error de carga por favor corrija los campos:");
                foreach (var i in erroresValida)
                {
                    error.AppendLine(i);
                }

                MessageBox.Show(error.ToString());
            }
            else
            {
                
          
                   // prof.ID = this.selectedProf.ID;
                    this.dataAccess.UpdateAfiliado(afiliado);
                    this.Close();
                
                }
            
        }

        public void LimpiarCampos()
        {
            this.textBoxApellido.Clear();
            this.textBoxDir.Clear();
            this.textBoxDoc.Clear();
            this.textBoxMail.Clear();
            this.textBoxNombre.Clear();
            this.textBoxTel.Clear();
            this.numericUpDownHijos.Value = 0;
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}
