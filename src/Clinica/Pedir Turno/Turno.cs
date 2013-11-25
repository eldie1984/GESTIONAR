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
    public partial class Turno : Form
    {
        private Usuario usuario;

        public Turno(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }
    }
}
