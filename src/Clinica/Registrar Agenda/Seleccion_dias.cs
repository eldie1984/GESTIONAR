using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica.Model;

namespace Clinica.Registrar_Agenda
{
    public partial class Seleccion_dias : Form
    {
        private Int32 prof_id;
        List<Agenda> dias;
        public Seleccion_dias(Int32 user)
        {
            InitializeComponent();
            this.prof_id = user;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = Helper.GetFechaNow();
            dateTimePicker2.Value = Helper.GetFechaNow();
            dateTimePicker3.Value = Helper.GetFechaNow();
            dateTimePicker4.Value = Helper.GetFechaNow();
            dateTimePicker5.Value = Helper.GetFechaNow();
            dateTimePicker6.Value = Helper.GetFechaNow();
            dateTimePicker7.Value = Helper.GetFechaNow();
            dateTimePicker8.Value = Helper.GetFechaNow();
            dateTimePicker9.Value = Helper.GetFechaNow();
            dateTimePicker10.Value = Helper.GetFechaNow();
            dateTimePicker11.Value = Helper.GetFechaNow();
            dateTimePicker12.Value = Helper.GetFechaNow();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dias = new List<Agenda>();
            int horaDesde;
            int minutosDesde;
            int horaHasta;
            int minutosHasta;
            double  sum_horas =0;
            if (this.checkBox1.Checked)
            {
                horaDesde=Convert.ToInt32(this.dateTimePicker2.Value.ToString("HH"));
                minutosDesde = Convert.ToInt32(this.dateTimePicker2.Value.ToString("mm"));
                horaHasta=Convert.ToInt32(this.dateTimePicker1.Value.ToString("HH"));
                minutosHasta = Convert.ToInt32(this.dateTimePicker1.Value.ToString("mm"));
                if (check_horario(horaDesde, minutosDesde, horaHasta, minutosHasta))
                {
                    dias.Add(new Agenda() { dia = 1, horaInicio = horaDesde + ":" + minutosDesde, horaFin = horaHasta + ":" + minutosHasta });
                    sum_horas = sum_horas + horaHasta - horaDesde;
                    if (minutosHasta - minutosDesde > 0)
                    {
                        sum_horas = sum_horas + 0.5;
                    }
                    else if (minutosHasta - minutosDesde < 0)
                    {
                        sum_horas = sum_horas - 0.5;
                    }
                }
                else
                {
                    MessageBox.Show("Las fechas Inicio y fin de la jornada no pueden estar fuera del rango de 8 a 20 ni ser iguales", "Error");
                    return;
                }
            }
            if (this.checkBox2.Checked)
            {
                horaDesde = Convert.ToInt32(this.dateTimePicker4.Value.ToString("HH"));
                minutosDesde = Convert.ToInt32(this.dateTimePicker4.Value.ToString("mm"));
                horaHasta = Convert.ToInt32(this.dateTimePicker3.Value.ToString("HH"));
                minutosHasta = Convert.ToInt32(this.dateTimePicker3.Value.ToString("mm"));
                if (check_horario(horaDesde, minutosDesde, horaHasta, minutosHasta))
                {
                    dias.Add(new Agenda() { dia = 2, horaInicio = horaDesde + ":" + minutosDesde, horaFin = horaHasta + ":" + minutosHasta });
                    sum_horas = sum_horas + horaHasta - horaDesde;
                    if (minutosHasta - minutosDesde > 0)
                    {
                        sum_horas = sum_horas + 0.5;
                    }
                    else if (minutosHasta - minutosDesde < 0)
                    {
                        sum_horas = sum_horas - 0.5;
                    }
                }
                else
                {
                    MessageBox.Show("Las fechas Inicio y fin de la jornada no pueden estar fuera del rango de 8 a 20 ni ser iguales", "Error");
                    return;
                }
            }
            if (this.checkBox3.Checked)
            {
                horaDesde = Convert.ToInt32(this.dateTimePicker6.Value.ToString("HH"));
                minutosDesde = Convert.ToInt32(this.dateTimePicker6.Value.ToString("mm"));
                horaHasta = Convert.ToInt32(this.dateTimePicker5.Value.ToString("HH"));
                minutosHasta = Convert.ToInt32(this.dateTimePicker5.Value.ToString("mm"));
                if (check_horario(horaDesde, minutosDesde, horaHasta, minutosHasta))
                {
                    dias.Add(new Agenda() { dia = 3, horaInicio = horaDesde + ":" + minutosDesde, horaFin = horaHasta + ":" + minutosHasta });
                    sum_horas = sum_horas + horaHasta - horaDesde;
                    if (minutosHasta - minutosDesde > 0)
                    {
                        sum_horas = sum_horas + 0.5;
                    }
                    else if (minutosHasta - minutosDesde < 0)
                    {
                        sum_horas = sum_horas - 0.5;
                    }
                }
                else
                {
                    MessageBox.Show("Las fechas Inicio y fin de la jornada no pueden estar fuera del rango de 8 a 20 ni ser iguales", "Error");
                    return;
                }
            }
            if (this.checkBox4.Checked)
            {
                horaDesde = Convert.ToInt32(this.dateTimePicker8.Value.ToString("HH"));
                minutosDesde = Convert.ToInt32(this.dateTimePicker8.Value.ToString("mm"));
                horaHasta = Convert.ToInt32(this.dateTimePicker7.Value.ToString("HH"));
                minutosHasta = Convert.ToInt32(this.dateTimePicker7.Value.ToString("mm"));
                if (check_horario(horaDesde, minutosDesde, horaHasta, minutosHasta))
                {
                    dias.Add(new Agenda() { dia = 4, horaInicio = horaDesde + ":" + minutosDesde, horaFin = horaHasta + ":" + minutosHasta });
                    sum_horas = sum_horas + horaHasta - horaDesde;
                    if (minutosHasta - minutosDesde > 0)
                    {
                        sum_horas = sum_horas + 0.5;
                    }
                    else if (minutosHasta - minutosDesde < 0)
                    {
                        sum_horas = sum_horas - 0.5;
                    }
                }
                else
                {
                    MessageBox.Show("Las fechas Inicio y fin de la jornada no pueden estar fuera del rango de 8 a 20 ni ser iguales", "Error");
                    return;
                }
            }
            if (this.checkBox5.Checked)
            {
                horaDesde = Convert.ToInt32(this.dateTimePicker10.Value.ToString("HH"));
                minutosDesde = Convert.ToInt32(this.dateTimePicker10.Value.ToString("mm"));
                horaHasta = Convert.ToInt32(this.dateTimePicker9.Value.ToString("HH"));
                minutosHasta = Convert.ToInt32(this.dateTimePicker9.Value.ToString("mm"));
                if (check_horario(horaDesde, minutosDesde, horaHasta, minutosHasta))
                {
                    dias.Add(new Agenda() { dia = 5, horaInicio = horaDesde + ":" + minutosDesde, horaFin = horaHasta + ":" + minutosHasta });
                    sum_horas = sum_horas + horaHasta - horaDesde;
                    if (minutosHasta - minutosDesde > 0)
                    {
                        sum_horas = sum_horas + 0.5;
                    }
                    else if (minutosHasta - minutosDesde < 0)
                    {
                        sum_horas = sum_horas - 0.5;
                    }
                }
                else
                {
                    MessageBox.Show("Las fechas Inicio y fin de la jornada no pueden estar fuera del rango de 8 a 20 ni ser iguales", "Error");
                    return;
                }
            }
            if (this.checkBox6.Checked)
            {
                horaDesde = Convert.ToInt32(this.dateTimePicker12.Value.ToString("HH"));
                minutosDesde = Convert.ToInt32(this.dateTimePicker12.Value.ToString("mm"));
                horaHasta = Convert.ToInt32(this.dateTimePicker11.Value.ToString("HH"));
                minutosHasta = Convert.ToInt32(this.dateTimePicker11.Value.ToString("mm"));
                if (check_horario(horaDesde, minutosDesde, horaHasta, minutosHasta) && (horaHasta < 16 || (horaHasta == 15 && minutosHasta == 0 )))
                {
                    dias.Add(new Agenda() { dia = 6, horaInicio = horaDesde + ":" + minutosDesde, horaFin = horaHasta + ":" + minutosHasta });
                    sum_horas = sum_horas + horaHasta - horaDesde;
                    if (minutosHasta - minutosDesde > 0)
                    {
                        sum_horas = sum_horas + 0.5;
                    }
                    else if (minutosHasta - minutosDesde < 0)
                    {
                        sum_horas = sum_horas - 0.5;
                    }
                }
                else
                {
                    MessageBox.Show("Las fechas Inicio y fin de la jornada no pueden estar fuera del rango de 8 a 15 ni ser iguales", "Error");
                    return;
                }
            }

            if (sum_horas <= 50)
            {
                Seleccion_fecha horario = new Seleccion_fecha(dias);
                horario.Show();
                horario.padre = this;
                this.Hide();
            }
            else
            {
                MessageBox.Show("Las sumatorias de horas no puede superar las 50 horas", "Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                dateTimePicker2.Enabled = true;
                dateTimePicker1.Enabled = true;
            }
            else
            {
                dateTimePicker2.Enabled = false;
                dateTimePicker1.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                dateTimePicker3.Enabled = true;
                dateTimePicker4.Enabled = true;
            }
            else
            {
                dateTimePicker3.Enabled = false;
                dateTimePicker4.Enabled = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                dateTimePicker5.Enabled = true;
                dateTimePicker6.Enabled = true;
            }
            else
            {
                dateTimePicker5.Enabled = false;
                dateTimePicker6.Enabled = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                dateTimePicker7.Enabled = true;
                dateTimePicker8.Enabled = true;
            }
            else
            {
                dateTimePicker7.Enabled = false;
                dateTimePicker8.Enabled = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                dateTimePicker9.Enabled = true;
                dateTimePicker10.Enabled = true;
            }
            else
            {
                dateTimePicker9.Enabled = false;
                dateTimePicker10.Enabled = false;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                dateTimePicker11.Enabled = true;
                dateTimePicker12.Enabled = true;
            }
            else
            {
                dateTimePicker11.Enabled = false;
                dateTimePicker12.Enabled = false;
            }
        }

        private bool check_horario (int HoraDesde,int MinutoDesde,int HoraHasta,int MinutoHasta)
        {
            if (HoraDesde>20 
                || HoraDesde < 7 
                || HoraHasta > 20 
                || HoraHasta < 7 
                || HoraDesde > HoraHasta 
                || (HoraHasta == 20 && MinutoHasta > 0)
                || (HoraDesde == HoraHasta 
                    && MinutoDesde == MinutoHasta)
                )
            {
                return false;
            }
            else
            {
                return true;
            }
            
        
        }

        
    }
}
