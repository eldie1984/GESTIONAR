using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.Model;

namespace Clinica_Frba.Abm_de_Profesional
{
    public partial class AltaProfesional : Form
    {
        private DataAccessLayer dataAccess;
        private List<Especialidad> listadoEspecialidades;
        private Profesional selectedProf;
        bool flagMod = false;

        public AltaProfesional(Profesional selectProf)
        {
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

            //carga opciones especialidades
            this.listadoEspecialidades = dataAccess.GetEspecialidades();
            ((ListBox)this.checkedEspecialidades).DataSource = listadoEspecialidades;
            ((ListBox)this.checkedEspecialidades).DisplayMember = "Descripcion";
            ((ListBox)this.checkedEspecialidades).ValueMember = "Codigo";

            //Modo Modificacion
            if (selectProf != null)
            {
                this.selectedProf = selectProf;
                this.flagMod = true;
                this.buttonLimpiar.Enabled = false;
                //titulo ventana
                this.Text = "Modificacion Profesional";

                //carga campos
                this.textBoxApellido.Text = selectedProf.Apellido;
                this.textBoxNombre.Text = selectedProf.Nombre;
                this.textBoxDir.Text = selectedProf.Direccion;
                this.dateTimePickerFechaNac.Value = selectedProf.FechaNac;
                this.textBoxMail.Text = selectedProf.Mail;
                this.textBoxMatric.Text = selectedProf.Matricula;

                this.comboBoxSexo.SelectedValue = selectedProf.Sexo;

                this.comboBoxDoc.SelectedValue = selectedProf.Tipo;

                this.textBoxDoc.Text = selectedProf.Documento.ToString();

                this.textBoxTel.Text = selectedProf.Telefono.ToString();
               
                //checkea especialidades
                var especialidadesProfesional = dataAccess.GetEspecialidadesProf(selectedProf.ID);

                for (int count = 0; count < this.checkedEspecialidades.Items.Count; count++)
                {
                    if(especialidadesProfesional.Contains((this.checkedEspecialidades.Items[count] as Especialidad).Codigo))
                    {
                         this.checkedEspecialidades.SetItemChecked(count, true);
                    }
                
                }

            }


        }


        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            List<string> erroresValida = new List<string>();
            Profesional prof = new Profesional();
            
            prof.Apellido = this.textBoxApellido.Text;
            prof.Nombre = this.textBoxNombre.Text;
            prof.Direccion = this.textBoxDir.Text;
            prof.FechaNac = this.dateTimePickerFechaNac.Value;
            prof.Mail = this.textBoxMail.Text;
            prof.Matricula = this.textBoxMatric.Text;
            prof.Sexo = this.comboBoxSexo.SelectedValue.ToString();
            prof.Tipo = this.comboBoxDoc.SelectedValue.ToString();
            try
            {
                prof.Documento = Convert.ToInt32(this.textBoxDoc.Text);
            }
            catch
            {
                erroresValida.Add("Documento puede ser solo numerico");
            }
            try
            {
                prof.Telefono = Convert.ToInt32(this.textBoxTel.Text);
            }
            catch
            {
                erroresValida.Add("Telefono puede ser solo numerico");
            }

            List<int> especialidadesSelec = new List<int>();
            foreach (object esp in this.checkedEspecialidades.CheckedItems)
            {
                int cod = (esp as Especialidad).Codigo;
                especialidadesSelec.Add(cod);

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
                if (flagMod)
                {
                    prof.ID = this.selectedProf.ID;
                    this.dataAccess.UpdateProf(prof, especialidadesSelec);
                    this.Close();
                }
                else
                {
                    this.dataAccess.AddProf(prof, especialidadesSelec);
                    LimpiarCampos();
                }
                
              
            }

        }

        public void LimpiarCampos()
        {
            this.textBoxApellido.Clear();
            this.textBoxDir.Clear();
            this.textBoxDoc.Clear();
            this.textBoxMail.Clear();
            this.textBoxMatric.Clear();
            this.textBoxNombre.Clear();
            this.textBoxTel.Clear();

            for (int i = 0; i < this.checkedEspecialidades.Items.Count; i++)
            {

                checkedEspecialidades.SetItemChecked(i, false);

            }


        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

    }
}
