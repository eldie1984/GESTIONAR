﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Clinica
{
    public partial class Main : Form
    {
        private Int32 User_id;
        private Int32 Rol_id;
        private Int32 Usuario_relacional;
        public Form parentForm;

        public Main(Int32 rol , Int32 usuario)
        {
            InitializeComponent();
            Funciones func =new Funciones();
            this.User_id = usuario;
            this.Rol_id = rol;
            this.Usuario_relacional = func.getUserRel(usuario, rol);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Funciones Func = new Funciones();
            SqlDataReader list_func = Func.getFuncID(Rol_id);
            while (list_func.Read())
            {
                string menu = list_func.GetString(1);
                var m = menuStrip1.Items.Find(menu, true);
                var consulta = consultaToolStripMenuItem.DropDownItems.Find(menu, true);
                var rol = aBMToolStripMenuItem.DropDownItems.Find(menu, true);
                var usuario = usuarioToolStripMenuItem.DropDownItems.Find(menu, true);
                var afiliado = afiliadoToolStripMenuItem.DropDownItems.Find(menu, true);
                var profesional = profesionalToolStripMenuItem.DropDownItems.Find(menu, true);
                var especialidad = especialidadesToolStripMenuItem.DropDownItems.Find(menu, true);
                var plan = planToolStripMenuItem.DropDownItems.Find(menu, true);
                var turno = agendaToolStripMenuItem.DropDownItems.Find(menu, true);
                var bonos = bonosToolStripMenuItem.DropDownItems.Find(menu, true);
                var estadisticas = estadisticasToolStripMenuItem.DropDownItems.Find(menu, true);

                if (consulta.Count() > 0)
                {
                    m = consulta;
                }
                else if (rol.Count() > 0)
                {
                    m = rol;
                }
                else if (usuario.Count() > 0)
                {
                    m = usuario;
                }
                else if (afiliado.Count() > 0)
                {
                    m = afiliado;
                }
                else if (profesional.Count() > 0)
                {
                    m = profesional;
                }
                else if (especialidad.Count() > 0)
                {
                    m = especialidad;
                }
                else if (plan.Count() > 0)
                {
                    m = plan;
                }
                else if (turno.Count() > 0)
                {
                    m = turno;
                }
                else if (bonos.Count() > 0)
                {
                    m = bonos;
                }
                else if (estadisticas.Count() > 0)
                {
                    m = estadisticas;
                }
                
                var o = m.ToList();
                foreach (var p in o)
                {
                    p.Visible = true;
                }
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown)
            {
                parentForm.Close();
                return;
            }

            // Confirm user wants to close
            switch (MessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    parentForm.Close();
                    break;
            }
        }

        

        private void registrarResultadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Generar_Receta.SelectHora resultado = new Clinica.Generar_Receta.SelectHora(this.Usuario_relacional);
            resultado.Show();
            resultado.MdiParent = this;
        }

        private void registrarLlegadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registro_de_LLegada.llegada Llegada = new Clinica.Registro_de_LLegada.llegada();
            Llegada.Show();
            Llegada.MdiParent = this;
        }

        private void altaRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcion no implementrada en el TP", "Informacion",MessageBoxButtons.OK ,MessageBoxIcon.Information);
        }

        private void bajaRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcion no implementrada en el TP", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void modificarRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abm_de_Rol.Elec_rol modRol = new Clinica.Abm_de_Rol.Elec_rol();
            modRol.Show();
            modRol.MdiParent = this;
        }

        private void listarRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcion no implementrada en el TP", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void altaUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcion no implementrada en el TP", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bajaUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcion no implementrada en el TP", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcion no implementrada en el TP", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void listarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcion no implementrada en el TP", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void altaAfiliadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abm_de_Afiliado.AltaAfiliado alta = new Clinica.Abm_de_Afiliado.AltaAfiliado();
            alta.Show();
            alta.MdiParent = this;
        }

        private void bajaAfiliadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abm_de_Afiliado.ListadoAfiliado modAfil = new Clinica.Abm_de_Afiliado.ListadoAfiliado();
            modAfil.Show();
            modAfil.MdiParent = this;
        }

        private void modificarAfiliadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abm_de_Afiliado.ListadoAfiliado modAfil = new Clinica.Abm_de_Afiliado.ListadoAfiliado();
            modAfil.Show();
            modAfil.MdiParent = this;
        }

        private void listarAfiliadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abm_de_Afiliado.ListadoAfiliado modAfil = new Clinica.Abm_de_Afiliado.ListadoAfiliado();
            modAfil.Show();
            modAfil.MdiParent = this;
        }

        private void altaProfesionalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abm_de_Profesional.AltaProfesional altaProf = new Clinica.Abm_de_Profesional.AltaProfesional(null);
            altaProf.Show();
            altaProf.MdiParent = this;
        }

        private void bajaProfesionalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abm_de_Profesional.ListadoProfesional modProf = new Clinica.Abm_de_Profesional.ListadoProfesional();
            modProf.Show();
            modProf.MdiParent = this;
        }

        private void modificarProfesionalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abm_de_Profesional.ListadoProfesional modProf = new Clinica.Abm_de_Profesional.ListadoProfesional();
            modProf.Show();
            modProf.MdiParent = this;
        }

        private void listarProfesionalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abm_de_Profesional.ListadoProfesional modProf = new Clinica.Abm_de_Profesional.ListadoProfesional();
            modProf.Show();
            modProf.MdiParent = this;
        }

        private void altaEspecialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcion no implementrada en el TP", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bajaEspecialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcion no implementrada en el TP", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void modificarEspecialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcion no implementrada en el TP", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void listarEspecialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcion no implementrada en el TP", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void altaPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcion no implementrada en el TP", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bajaPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcion no implementrada en el TP", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcion no implementrada en el TP", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void listarPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcion no implementrada en el TP", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registrar_Agenda.Seleccion_dias agenda = new Clinica.Registrar_Agenda.Seleccion_dias(this.Usuario_relacional);
            agenda.Show();
            agenda.MdiParent = this;
        }

        private void pedidoTurnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pedir_Turno.Turno turno = new Clinica.Pedir_Turno.Turno(this.Usuario_relacional, this.Rol_id);
            turno.Show();
            turno.MdiParent = this;
        }

        private void cancelarAtencionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cancelar_Atencion.Cancelar cancelar = new Clinica.Cancelar_Atencion.Cancelar(this.Usuario_relacional, this.Rol_id);
            cancelar.Show();
            cancelar.MdiParent = this;
        }

        private void comprarBonosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Compra_de_Bono.CompraBonos bono = new Clinica.Compra_de_Bono.CompraBonos(this.Usuario_relacional,this.Rol_id);
            bono.Show();
            bono.MdiParent = this;
        }


        

       
    }
}