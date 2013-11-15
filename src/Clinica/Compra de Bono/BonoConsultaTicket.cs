using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica.Model;

namespace Clinica.Compra_de_Bono
{
    public partial class BonoConsultaTicket : Form
    {
        public BonoConsultaTicket(BonoConsulta bono,string PlanNombre)
        {
            InitializeComponent();
            this.labelAfiID.Text = bono.afi_ID.ToString();
            this.labelFechaCompra.Text = Helper.GetFechaNow().ToString("dd/MM/yyyy");
            this.labelNumero.Text = bono.ID.ToString();
            this.labelPlan.Text = PlanNombre;
        }
    }
}
