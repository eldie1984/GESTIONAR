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
    public partial class CompraBonos : Form
    {
        private int AfiliadoID;
        private int AfiliadoSubID;
        private Afiliado selectedAfiliado;
        private Plan currentPlan;
        private bool ADMINMode = true;
        private DataAccessLayer dataAccess;
        private bool error=false;
        private Compra currentCompra;

        public CompraBonos(int userid,int rolid)
        {


            InitializeComponent();
            this.currentCompra = new Compra();
            this.dataAccess = new DataAccessLayer();
            //rol usuario afiliado
            if (rolid == 1)
            {
                ADMINMode = false;
                this.groupBoxAfiliado.Hide();
                
                //get Afiliado asociado al usuario y rol
                this.AfiliadoID = 33;
                this.AfiliadoSubID = 01;
            }


        }

        private void buttonConfirmCantidad_Click(object sender, EventArgs e)
        {
            if (ADMINMode)
            {
                try
                {
                    this.AfiliadoID = Convert.ToInt32(this.textBoxafiID.Text);
                    this.AfiliadoSubID = Convert.ToInt32(this.textBoxafiSubID.Text);
                    this.error = false;
                    this.currentCompra.afi_ID = this.AfiliadoID;
                    this.currentCompra.afi_Sub_ID = this.AfiliadoSubID;
                }
                catch
                {
                    MessageBox.Show("Ingrese un numero de afiliado correcto");
                    this.error = true;
                }
            }
            if (!error)
            {
                this.selectedAfiliado = this.dataAccess.GetAfiliadoByID(this.AfiliadoID, this.AfiliadoSubID);
                if (this.selectedAfiliado == null)
                { MessageBox.Show("El numero ingresado no pertenece a la cartilla de afiliados"); }
                else
                {
                    this.currentPlan = this.dataAccess.GetPlanByID(this.selectedAfiliado.Plan);
                    var CantidadBonoConsulta = (int)this.numericUpDownConsulta.Value;
                    var CantidadBonoFarmacia = (int)this.numericUpDownFarmacia.Value;

                    this.currentCompra.PlanID = this.currentPlan.Codigo;
                    this.currentCompra.CanConsulta = CantidadBonoConsulta;
                    this.currentCompra.CantFarmacia = CantidadBonoFarmacia;

                    this.textBoxPlan.Text = this.currentPlan.Descripcion;
                    this.textBoxPrecioConsulta.Text ="$" + this.currentPlan.PrecioConsulta.ToString();
                    this.textBoxPrecioFarmacia.Text ="$" + this.currentPlan.PrecioFarmacia.ToString();

                    int total = CantidadBonoConsulta * this.currentPlan.PrecioConsulta + CantidadBonoFarmacia * this.currentPlan.PrecioFarmacia;

                    this.currentCompra.Suma = total;

                    this.textBoxTotal.Text = "$" + total.ToString();

                    this.groupBoxTotal.Visible = true;


                }


            }
    
        }

        private void buttonComprar_Click(object sender, EventArgs e)
        {
            var cantconsultas = this.numericUpDownConsulta.Value;
            var cantfarmacia = this.numericUpDownFarmacia.Value;
            
            if (cantconsultas > 0 || cantfarmacia > 0)
            {
                var CompraRealizada = this.dataAccess.AddCompra(this.currentCompra);
                if (CompraRealizada != 0)
                {
                    MessageBox.Show("Los siguientes Bonos fueron comprados con exito:");
                    for (int i = 0; i < cantconsultas; i++)
                    {
                        BonoConsulta bono = new BonoConsulta();
                        bono.afi_ID=this.AfiliadoID;
                        bono.afi_Sub_ID=this.AfiliadoSubID;
                        bono.compraID=CompraRealizada;
                        bono.planID=this.currentCompra.PlanID;
                        bono.ID= this.dataAccess.AddBonoConsulta(bono);

                        var ticket = new BonoConsultaTicket(bono, this.currentPlan.Descripcion);
                        ticket.ShowDialog();
                    }

                    for (int i = 0; i < cantfarmacia; i++)
                    {
                        BonoFarmacia bono = new BonoFarmacia();
                        bono.afi_ID = this.AfiliadoID;
                        bono.afi_Sub_ID = this.AfiliadoSubID;
                        bono.compraID = CompraRealizada;
                        bono.planID = this.currentCompra.PlanID;
                        bono.ID = this.dataAccess.AddBonoFarmacia(bono);

                        var ticket = new BonoFarmaciaTicket(bono, this.currentPlan.Descripcion);
                        ticket.ShowDialog();
                    }
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar por lo menos un bono para realizar la compra");
            }

        }
    }
}
