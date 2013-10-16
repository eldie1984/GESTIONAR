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
        public DataSet llenaComboBoxRol()
        {
            this.sql = string.Format(@"select rol_id,rol_nombre from GESTIONAR.Rol");
            DataSet ds = new DataSet();
            //indicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter(this.sql, this.cnn);
            //return da;
            da.Fill(ds, "rol_nombre");
            return ds;
        }

    }
}
