﻿using System;
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


        public Pantalla(Int32 anio, Int32 semestre, Int32 numero_reporte)
        {
            InitializeComponent();
            this.anio = anio;
            this.semestre = semestre;
            this.reporte = numero_reporte;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Pantalla_Load(object sender, EventArgs e)
        {
            this.dataAccess = new DataAccessLayer();
            this.dataGridView1.DataSource = this.dataAccess.Estadistica(this.anio, this.semestre, reporte);
        }
    }
}
