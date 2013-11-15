using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Clinica
{
    class Formularios : Conexion1
    {
        private SqlDataReader Reg;
        private DataSet ds=new DataSet();
        private SqlDataAdapter da;

        public Formularios()
        {
            this.cnn.Open();
        }
        public DataSet llenaComboBoxRol()
        {
            this.sql = string.Format(@"select rol_id,rol_nombre from GESTIONAR.Rol");
            
            //indicamos la consulta en SQL
             this.da= new SqlDataAdapter(this.sql, this.cnn);
            //return da;
            this.da.Fill(this.ds, "rol_nombre");
            return this.ds;
        }

        public SqlDataReader datos_rol(Int32 numero)
        {

            this.sql = string.Format(@"select 
                                        rol_nombre
                                        ,rol_borrado 
                                      from GESTIONAR.Rol
                                      where rol_id= {0}", numero);
            this.comandosSql = new SqlCommand(this.sql, this.cnn);
        
             this.Reg= null;
            this.Reg = this.comandosSql.ExecuteReader();
            
            if (this.Reg.HasRows)
            {
                return this.Reg;
            }
            else
            {
                return null;
            }
            
        }
        public DataSet datos_func(Int32 numero)
        {

            this.sql = string.Format(@"(select f.func_id, f.func_name,'True' as 'Habilitado' from GESTIONAR.Rol_funcionalidad rf
                                        left join GESTIONAR.funcionalidad f on rf.rolf_func_id=f.func_id
                                        where rolf_rol_id={0})
                                        union 
                                        (select func_id,func_name,'False' from GESTIONAR.funcionalidad
                                        where func_id not IN (select rolf_func_id from GESTIONAR.Rol_funcionalidad
						                where rolf_rol_id={0}) )", numero);
             
            //indicamos la consulta en SQL
            this.da = new SqlDataAdapter(this.sql, this.cnn);
            this.da.Fill(this.ds, "func_id");
            return this.ds;
            
        }
        public DataSet llenaComboboxPerfil(Int32 user_id)
        {
            this.sql = string.Format(@"select rol_id,rol_nombre from GESTIONAR.rol, GESTIONAR.rol_usuario
            where rolu_rol_id=rol_id
            and rolu_user_id={0}",user_id);
            DataSet ds = new DataSet();
            //indicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter(this.sql, this.cnn);
            //return da;
            da.Fill(ds, "rol");
            return ds;
        }
    }
}
