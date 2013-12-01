using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica.Model;

namespace Clinica.Pedir_Turno
{
    public partial class PedirTurno : Form
    {
        private Afiliado currentAfil;
        private Profesional currentProf;
        private Usuario usuario;
        private Form child_form = null;
        private List<Especialidad> listadoEspecialidades;
        private List<Profesional> listadoProfesionales;
        private DataAccessLayer dataAccess;
        private List<Turno> listadoTurnos;


        public PedirTurno(Usuario usuario)
        {
            this.dataAccess = new DataAccessLayer();
            InitializeComponent();
            this.usuario = usuario;
            this.textBoxAfiliado.Enabled = false;
            this.textBoxProf.Enabled = false;
            this.comboBoxTurnos.Enabled = false;
            this.buttonConfirmar.Enabled = false;
                
            //caso afiliado
            if (usuario.rol == 2)
            {
                if (usuario.user_rel == -1 || usuario.user_rel_sub == -1)
                {
                    MessageBox.Show("El usuario debe tener un afiliado asociado al mismo para poder realizar esta operacion");
                    this.Close();
                }

                this.selecAfil.Enabled = false;
                this.currentAfil = dataAccess.GetAfiliadoByID(usuario.user_rel, usuario.user_rel_sub);
                this.textBoxAfiliado.Text = currentAfil.Nombre + " " + currentAfil.Apellido;
            }

            this.listadoEspecialidades = dataAccess.GetEspecialidades();
            this.listadoEspecialidades.Add(new Especialidad(){Codigo=-1,Descripcion="TODAS"});

            this.comboBoxEspecialidad.DisplayMember = "Descripcion";
            this.comboBoxEspecialidad.ValueMember = "Codigo";
            this.comboBoxEspecialidad.DataSource = this.listadoEspecialidades;

            this.comboBoxEspecialidad.SelectedValue = -1;
            
            

        }

     

        private void selecAfil_Click(object sender, EventArgs e)
        {
            child_form = new BuscarAfiliado(this);
            
            child_form.ShowDialog(this);
            
        }

        //cuando selecciona afiliado
        public void callWhenChildClick(Afiliado selected)
        {
            this.currentAfil = selected;
            this.textBoxAfiliado.Text = currentAfil.Nombre + " " + currentAfil.Apellido;
        }

        //llamado cuando selecciona profesional
        public void callWhenChildProfClick(Profesional selected)
        {
            this.currentProf = selected;
            this.textBoxProf.Text = currentProf.Nombre + " " + currentProf.Apellido;
            this.listadoTurnos = dataAccess.GetTurnos_ProfDisp(this.currentProf.ID);

            if (this.listadoTurnos.Count > 0)
            {
                this.comboBoxTurnos.Enabled = true;
                this.buttonConfirmar.Enabled = true;
            }
            else
            {
                this.buttonConfirmar.Enabled = true;
            }
            
            this.comboBoxTurnos.DisplayMember = "HoraInicio";
            this.comboBoxTurnos.ValueMember = "Codigo";
            this.comboBoxTurnos.DataSource = this.listadoTurnos;

        }

        private void buttonSelecProf_Click(object sender, EventArgs e)
        {
            int selespec = (int)this.comboBoxEspecialidad.SelectedValue;
            child_form = new BuscarProfesional(this, selespec);

            child_form.ShowDialog(this);
        }

        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            if (this.currentAfil != null)
            {
                Turno selTurno = (Turno)this.comboBoxTurnos.SelectedItem;
                if (selTurno != null)
                {
                    selTurno.AFIL_ID = this.currentAfil.ID;
                    selTurno.AFIL_SUBID = this.currentAfil.Sub_ID;

                    dataAccess.UpdateTurno(selTurno);
                    MessageBox.Show("Turno confirmado");
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un turno disponible");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un afiliado");
            }
        }

       
    }
}
