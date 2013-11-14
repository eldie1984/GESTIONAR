using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.Model;
using Clinica;

namespace Clinica_Frba.Compra_de_Bono
{
    public partial class BonoFarmaciaTicket : Form
    {
        public BonoFarmaciaTicket(BonoFarmacia bono, string PlanNombre)
        {
            InitializeComponent();
            this.labelAfiID.Text = bono.afi_ID.ToString();
            this.labelFechaCompra.Text = Helper.GetFechaNow().ToString("dd/MM/yyyy");

            var venc = Helper.GetFechaNow().AddDays(60);
            this.labelVencimiento.Text = venc.ToString("dd/MM/yyyy");
            this.labelNumero.Text = bono.ID.ToString();
            this.labelPlan.Text = PlanNombre;
        }
    }
}
