using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Clinica
{
	class Conexion1
	{
        public string cadenaConexion;
        protected string sql;
        protected Int32 resultado;
        protected SqlConnection cnn;
        protected SqlCommand comandosSql;
        protected string mensaje;

        public Conexion1()
        {
            this.cadenaConexion = (@"Data Source=WXPX86BE-133\GD2C2013;Initial Catalog =GD2C2013; integrated security =true;User Id=gd;Password=gd2013;");
            //this.cadenaConexion = ConfigurationSettings.AppSettings["conexionBD"];

            this.cnn = new SqlConnection(this.cadenaConexion);

        }
        public string Mensaje
        {
            get
            {
                return this.mensaje;
            }

        }
	}
}
