using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica.Model;

namespace Clinica.Listados_Estadisticos
{
    public partial class Pantalla : Form
    {
        Int32 reporte;
        Int32 anio;
        Int32 semestre;
        private DataAccessLayer dataAccess;
        public Form padre;


        public Pantalla(Int32 anio, Int32 semestre, Int32 numero_reporte,string titulo)
        {
            InitializeComponent();
            this.anio = anio;
            this.semestre = semestre;
            this.reporte = numero_reporte;
            this.Text = titulo;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            padre.Close();
        }

        private void Pantalla_Load(object sender, EventArgs e)
        {
            this.dataAccess = new DataAccessLayer();
            int ancho = 0;
            List<estadistica> lista_estadistica = this.dataAccess.Estadistica(this.anio, this.semestre, reporte);
            if (reporte == 1)
            {
                this.dataGridView1.DataSource = (from estadistica in lista_estadistica
                                                 select new { mes = estadistica.mes, dato = estadistica.dato , cantidad =estadistica.cantidad }).ToList();
            }
            else if (reporte == 2)
            {
                this.dataGridView1.DataSource = (from estadistica in lista_estadistica
                                                 select new { Mes_comprado = estadistica.mes_comprado, mes_vencimiento = estadistica.mes_vencimiento, afiliado = estadistica.dato, cantidad = estadistica.cantidad }).ToList();
            }
            else
            {
                this.dataGridView1.DataSource = (from estadistica in lista_estadistica
                                                 select new { Mes = estadistica.mes, Afiliado = estadistica.dato, cantidad = estadistica.cantidad }).ToList();
            }
            for (int i =0; i < this.dataGridView1.ColumnCount ; i++)
            {
                ancho=ancho + this.dataGridView1.Columns[i].Width;
            }
            this.dataGridView1.Width = ancho + 50;
            this.Width= this.dataGridView1.Width +30;
            ancho = 0;
            for (int i = 0; i < this.dataGridView1.RowCount; i++)
            {
                ancho = ancho + this.dataGridView1.Rows[i].Height;
            }
            this.dataGridView1.Height = ancho + 22;
            this.Height = this.dataGridView1.Height + 100;
            this.dataGridView1.Location = new Point(12, 12);
            this.button1.Location = new Point(112, this.dataGridView1.Height + 20);
        }
    }
}
