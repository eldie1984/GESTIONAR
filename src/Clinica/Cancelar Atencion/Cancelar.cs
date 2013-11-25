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

        public Cancelar(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }
    }
}
