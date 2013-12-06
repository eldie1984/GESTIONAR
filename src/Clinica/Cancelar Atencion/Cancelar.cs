using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica.Model;

namespace Clinica.Cancelar_Atencion
{
    public partial class Cancelar : Form
    {
        private Usuario usuario;
        private DataAccessLayer dataAccess;
        private List<Turno> listadoTurnos;

        public Cancelar(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.dataAccess = new DataAccessLayer();
            
            //rol Profesional
            if (this.usuario.rol == 0)
            {
                splitContainer1.Panel1Collapsed = true;

            }
            //rol paciente
            else if (this.usuario.rol == 2)
            {
                splitContainer1.Panel2Collapsed = true;
                DateTime tomorrow = Helper.GetFechaNow().AddDays(1);
                this.listadoTurnos = this.dataAccess.GetTurnos_Afil(this.usuario.user_rel, this.usuario.user_rel_sub).Where(x => x.HoraInicio.Date>=tomorrow).ToList();

                this.comboBoxTunoAfil.DisplayMember = "HoraInicio";
                this.comboBoxTunoAfil.ValueMember = "Codigo";
                this.comboBoxTunoAfil.DataSource = this.listadoTurnos;

            }
            else
            {
                MessageBox.Show("Debe tener rol Profesional o Paciente para acceder a esta funcionalidad");
                this.Close();
            }



            
            
        }

        private void buttonCancelPac_Click(object sender, EventArgs e)
        {
            if(this.comboBoxTunoAfil.SelectedValue!=null)
            {
            int selTurn = (int)this.comboBoxTunoAfil.SelectedValue;
            this.dataAccess.BajaTurnoAfil(selTurn, this.textBoxMotivoAfil.Text);
            MessageBox.Show("Turno Cancelado exitosamente");
            this.Close();
            }
            else
                {
                    MessageBox.Show("Debe seleccionar un turno");
                }
        }

        private void buttonCancelProf_Click(object sender, EventArgs e)
        {
            DateTime desde = this.dateTimeDesde.Value.Date;
            
            
            DateTime hasta = this.dateTimeHasta.Value.Date;
            
            string motivo = this.textBoxMotivoProf.Text;
            this.dataAccess.BajaTurnosProf(this.usuario.user_rel,desde,hasta,motivo);
            MessageBox.Show("Periodo de turnos Cancelado exitosamente");
            this.Close();
        }
    }
}
