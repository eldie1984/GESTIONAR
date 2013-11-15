using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Clinica
{
    class Funciones:Conexion1
    {
        public Int32 getTurnoId(Int32 profesional,DateTime fecha)
        {
            Int32 Resultado = 0;
            this.sql = string.Format(@"
                select turn_id 
                from GESTIONAR.turno 
                where turn_profe_id=0
                and turn_baja=0
                and turn_hora_inicio >= DATEADD(minute,-15,CONVERT(datetime,'{1}',120)) 
                and turn_hora_inicio<DATEADD(minute,15,CONVERT(datetime,'{1}',120)) ;
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
            this.sql = string.Format(@"select rf.rolf_func_id,fu.func_name from GESTIONAR.Rol_funcionalidad rf ,GESTIONAR.funcionalidad fu  
where ru.rolf_rol_id = {1}
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
    }
}
