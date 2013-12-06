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
                //this.listadoTurnos = 
            }
            else
            {
                MessageBox.Show("Debe tener rol Profesional o Paciente para acceder a esta funcionalidad");
                this.Close();
            }



            
            
        }
    }
}
