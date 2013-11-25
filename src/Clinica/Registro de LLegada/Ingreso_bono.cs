using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica.Model;

namespace Clinica.Registro_de_LLegada
{
    public partial class Ingreso_bono : Form
    {
        private Int32 turno_id;
        private Int32 afil_id;
        private Int32 afil_sub_id;
        public Form parent;
        public Form MiParent;
        private DataAccessLayer dataAccess;


        public Ingreso_bono(Int32 turno , Int32 afiliado, Int32 miembro)
        {
            InitializeComponent();
            this.turno_id = turno;
            this.afil_id = afiliado;
            this.afil_sub_id = miembro;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
            QueryResult consulta = new QueryResult();
            this.dataAccess = new DataAccessLayer();
            try
            {
                Convert.ToInt32(maskedTextBox1.Text);
            }
            catch
            {
                
                MessageBox.Show("El bono puede ser solo numerico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.dataAccess.checkBonoConsulta(Convert.ToInt32(maskedTextBox1.Text),this.afil_id))
            {
                consulta = this.dataAccess.AddConsulta(Convert.ToInt32(maskedTextBox1.Text), this.turno_id, this.afil_id, this.afil_sub_id);
                if (consulta.ID != -1)
                {
                    MessageBox.Show("El numero de consulta creado es " + "\n"+ consulta.ID.ToString(), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    this.parent.Close();
                }
                else
                {
                    MessageBox.Show("Hubo un error al crear la consulta" + consulta.mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No existe el bono o el mismo se encuentra usado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
