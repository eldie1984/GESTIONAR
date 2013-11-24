using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;


namespace Clinica
{
    class Funciones : Conexion1
    {
        public Int32 getTurnoId(Int32 profesional, DateTime fecha)
        {
            Int32 Resultado = 0;
            this.sql = string.Format(@"
                select turn_id 
                from GESTIONAR.turno , GESTIONAR.consulta
                where turn_profe_id={0}
                and turn_baja=0
                and turn_hora_inicio >= DATEADD(minute,-15,CONVERT(datetime,'{1}',120)) 
                and turn_hora_inicio<DATEADD(minute,15,CONVERT(datetime,'{1}',120)) 
                and consul_turno_id=turn_id
                and consul_sintomas is null
                and consul_enfermedades is null;
                ", profesional, fecha.ToString("yyyy-MM-dd HH:mm:ss"));
            this.comandosSql = new SqlCommand(this.sql, this.cnn);

            this.cnn.Open();
            SqlDataReader Reg = this.comandosSql.ExecuteReader();
            if (Reg.HasRows)
            {
                Reg.Read();
                Resultado = Convert.ToInt32(Reg[0].ToString());
            }

            this.cnn.Close();
            return Resultado;
        }
        public SqlDataReader getFuncID(Int32 rol_id)
        {
            this.sql = string.Format(@"select fu.func_name from GESTIONAR.Rol_funcionalidad rf ,GESTIONAR.funcionalidad fu  
where rf.rolf_rol_id = {0}
and fu.func_id=rf.rolf_func_id
order by rf.rolf_func_id desc", rol_id);
            this.comandosSql = new SqlCommand(this.sql, this.cnn);
            this.cnn.Open();
            return this.comandosSql.ExecuteReader();
        }


        public Int32 getUserRel(Int32 user_id,Int32 rol_id)
        {

            Int32 result = 0;
            this.sql = string.Format(@"select rol_relacion from GESTIONAR.rol_usuario ru where ru.rolu_rol_id={0} and ru.rolu_user_id={1}", rol_id,user_id);
            this.comandosSql = new SqlCommand(this.sql, this.cnn);
            this.cnn.Open();
            SqlDataReader Reg = null;
            Reg = this.comandosSql.ExecuteReader();
            if (Reg.Read())
            {
                result = Convert.ToInt32(Reg[0]);

            }
            else
            {

                result = -1;
            }
            this.cnn.Close();
            return result;
        }

        public Int32 getUserRel_sub(Int32 user_id, Int32 rol_id)
        {

            Int32 result = 0;
            this.sql = string.Format(@"select rol_relacion_sub from GESTIONAR.rol_usuario ru where ru.rolu_rol_id={0} and ru.rolu_user_id={1}", rol_id, user_id);
            this.comandosSql = new SqlCommand(this.sql, this.cnn);
            this.cnn.Open();
            SqlDataReader Reg = null;
            Reg = this.comandosSql.ExecuteReader();
            if (Reg.Read())
            {
                result = Convert.ToInt32(Reg[0]);

            }
            else
            {

                result = -1;
            }
            this.cnn.Close();
            return result;
        }

        public void completeConsul(Int32 id_turno, string sintoma, string enfermedad)
        {
            this.sql = string.Format(@"UPDATE [GESTIONAR].[consulta]
                                        SET
                                        consul_sintomas = '@Sintoma' ,
                                        consul_enfermedades='@Enfermedad',
                                        consul_modificado=@Ahora
                                        where consul_turno_id =@turno_id");
            this.comandosSql = new SqlCommand(this.sql, this.cnn);
            this.comandosSql.Parameters.Add(new SqlParameter("@turno_id", id_turno));
            this.comandosSql.Parameters.Add(new SqlParameter("@Sintoma", sintoma));
            this.comandosSql.Parameters.Add(new SqlParameter("@Enfermedad", enfermedad));
            this.comandosSql.Parameters.Add(new SqlParameter("@Ahora", Helper.GetFechaNow()));
            this.cnn.Open();
            this.comandosSql.ExecuteNonQuery();
            this.cnn.Close();
        }
        public bool checkBono(Int32 bono)
        {
            bool Resultado = false;
            this.sql = string.Format(@"select * from GESTIONAR.bono_farmacia
                                        where bofa_id={0}
                                        and bofa_bono_consulta_id is null
and dateadd(day,60,bofa_creado) >= CONVERT(datetime, '{1}', 120)", bono, Helper.GetFechaNow().ToString("yyyy-MM-dd HH:mm:ss"));
            this.comandosSql = new SqlCommand(this.sql, this.cnn);

            this.cnn.Open();
            SqlDataReader Reg = this.comandosSql.ExecuteReader();
            if (Reg.HasRows)
            {
                Resultado = true;
            }

            this.cnn.Close();
            return Resultado;

        }

        internal bool checkTurno(Int32 turno, Int32 afil_id, Int32 afi_sub_id)
        {
            bool Resultado = false;
            this.sql = string.Format(@"select * from GESTIONAR.turno
                        where turn_id={0}
                        and turn_afil_id={1}
                        and turn_afi_sub_id={2}", turno, afil_id, afi_sub_id);
            this.comandosSql = new SqlCommand(this.sql, this.cnn);

            this.cnn.Open();
            SqlDataReader Reg = this.comandosSql.ExecuteReader();
            if (Reg.HasRows)
            {
                Resultado = true;
            }

            this.cnn.Close();
            return Resultado;
        }

        

        internal bool checkBonoConsulta(Int32 bono, int afiliado)
        {
            bool Resultado = false;
            this.sql = string.Format(@"select * from GESTIONAR.bono_consulta
                                        where boco_id={0}
                                        and boco_afi_id = {1}
                                        and boco_id not in (select consul_turno_id 
                                        from GESTIONAR.consulta 
                                        where consul_afi_id={1})", bono, afiliado);
            this.comandosSql = new SqlCommand(this.sql, this.cnn);

            this.cnn.Open();
            SqlDataReader Reg = this.comandosSql.ExecuteReader();
            if (!Reg.HasRows)
            {
                Resultado = true;
            }

            this.cnn.Close();
            return Resultado;
        }

        internal void insertar_consulta(int bono, int turno, int afiliado, int miembro)
        {
            this.sql = string.Format(@"INSERT INTO [GD2C2013].[GESTIONAR].[consulta]
           ([consul_tuno_id]
           ,[consul_bono_id]
           ,[consul_afi_id]
           ,[consul_afi_sub_id]
           ,[consul_creado]
           ,[consul_modificado])
            values
            ({0},{1},{2},{3},CONVERT(datetime, '{4}', 120),CONVERT(datetime, '{4}', 120))", turno, bono, afiliado, miembro, Helper.GetFechaNow().ToString("yyyy-MM-dd HH:mm:ss"));
            this.cnn.Open();
            this.comandosSql.ExecuteNonQuery();
            this.cnn.Close();

        }

//        internal void persistir_medic(List<int> medic_list, List<int> medic_cant, int afil_id, int bono_id,int consulta)
//        {
            
//            this.cnn.Open();
            
//            this.sql = string.Format(@"update GESTIONAR.bono_farmacia
//set bofa_bono_consulta_id={0},
//bofa_modificado={1}
//where bofa_id={2}", consulta, Helper.GetFechaNow().ToString("yyyy-MM-dd HH:mm:ss"), bono_id);
//            result = this.comandosSql.ExecuteNonQuery();
//            if (result > 0)
//            {
//                this.cnn.Close();
//                return false;
//            }
//            else
//            {
//                this.cnn.Close(); ;
//                return false;
//            }
//            for (int i = 0; i < medic_list.Count; i++)
//            {
//                this.sql = string.Format(@"INSERT INTO [GD2C2013].[GESTIONAR].[medicamento_bono]
//           ([mebo_bofa_id]
//           ,[mebo_medic_id]
//           ,[mebo_cant]
//           ,[mebo_creado]
//           ,[mebo_modificado])
//            values
//            ({0},{1},{2},{3},CONVERT(datetime, '{4}', 120),CONVERT(datetime, '{4}', 120))", bono_id, medic_list[i], medic_cant[i], Helper.GetFechaNow().ToString("yyyy-MM-dd HH:mm:ss"));
//                this.comandosSql.ExecuteNonQuery();
                
//            }
//            this.cnn.Close();
//        }
    }
}
