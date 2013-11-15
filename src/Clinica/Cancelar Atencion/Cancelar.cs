using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Clinica.Cancelar_Atencion
{
    public partial class Cancelar : Form
    {
        private Int32 user_id;
        private Int32 rol_id;

        public Cancelar(Int32 user, Int32 rol)
        {
            InitializeComponent();
            this.user_id = user;
            this.rol_id = rol;
        }
    }
}
