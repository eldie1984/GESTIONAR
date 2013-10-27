using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clinica_Frba.Model;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Clinica_Frba
{
    public class DataAccessLayer
    {
        #region GETS

        public List<Profesional> GetProfesionales()
        {
            List<Profesional> listado = new List<Profesional>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GD2013"].ConnectionString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT prof_id,prof_nombre, prof_apellido, prof_nro_documento,prof_tipo_documento,prof_dureccion,prof_telefono,prof_mail,prof_fecha_nacimiento,prof_sexo,prof_matricula FROM GESTIONAR.profesional";
                SqlDataReader ProfReader = command.ExecuteReader();

                while (ProfReader.Read())
                {
                    int id = ProfReader.GetInt32(0);
                    string nombre = ProfReader.GetString(1);
                    string apellido = ProfReader.GetString(2);
                    decimal nrodoc = ProfReader.GetDecimal(3);
                    string tipodoc = ProfReader.GetString(4);
                    string dire = ProfReader.GetString(5);
                    decimal telefono = ProfReader.GetDecimal(6);
                    string mail = ProfReader.GetString(7);
                    DateTime fechaNac = ProfReader.GetDateTime(8);
                    string sexo = ProfReader.GetString(9);
                    string matricula = ProfReader.GetString(10);

                    listado.Add(new Profesional() { ID=id, Nombre = nombre, Apellido=apellido,Direccion=dire,Documento=nrodoc,Tipo=tipodoc,Mail=mail,FechaNac=fechaNac,Sexo=sexo,Matricula=matricula,Telefono=telefono });
                }
                ProfReader.Close();

                return listado;
            }
        }

        public List<Especialidad> GetEspecialidades()
        {
            List<Especialidad> listado = new List<Especialidad>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GD2013"].ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT Espe_Codigo, Espe_Descripcion FROM GESTIONAR.Especialidad", connection);
                SqlDataReader especReader = command.ExecuteReader();

                while (especReader.Read())
                {

                    int cod = especReader.GetInt32(0);
                    string desc = especReader.GetString(1);

                    listado.Add(new Especialidad() { Codigo = cod, Descripcion = desc });
                }
                especReader.Close();

                return listado;
            }

        }

        public List<int> GetEspecialidadesProf(int idProf)
        {
            List<int> listado = new List<int>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GD2013"].ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT espr_especialidad_id FROM GESTIONAR.profesional_especialidad WHERE espr_prof_id = @profID ", connection);

                SqlParameter nameParameter = new SqlParameter("profID",idProf);
                nameParameter.SqlDbType = SqlDbType.Int;

                command.Parameters.Add(nameParameter);



                SqlDataReader especReader = command.ExecuteReader();

                while (especReader.Read())
                {

                    int cod = especReader.GetInt32(0);
                    
                    listado.Add(cod);
                }
                especReader.Close();

                return listado;
            }

        }

        #endregion

        #region ADDS
        public void AddProf(Profesional prof, List<int> especialidades)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GD2013"].ConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO GESTIONAR.profesional(prof_nombre, prof_apellido, prof_nro_documento,prof_dureccion,prof_tipo_documento,prof_telefono,prof_mail,prof_fecha_nacimiento,prof_sexo,prof_matricula,prof_creado,prof_modificado)" +

                "VALUES(@nombre,@apellido, @doc,@dire,@tipo,@telefono,@mail,@fecNac,@sexo,@matric,@creado,@modificado)" +
                "SELECT SCOPE_IDENTITY()";

                command.Parameters.Add("@nombre", SqlDbType.VarChar, 255);
                command.Parameters.Add("@apellido", SqlDbType.VarChar, 255);
                command.Parameters.Add("@doc", SqlDbType.Int, 18);
                command.Parameters.Add("@dire", SqlDbType.VarChar, 255);
                command.Parameters.Add("@tipo", SqlDbType.VarChar, 3);
                command.Parameters.Add("@telefono", SqlDbType.Int, 18);
                command.Parameters.Add("@mail", SqlDbType.VarChar, 255);
                command.Parameters.Add("@fecNac", SqlDbType.DateTime);
                command.Parameters.Add("@sexo", SqlDbType.Char, 1);
                command.Parameters.Add("@matric", SqlDbType.VarChar, 8);
                command.Parameters.Add("@creado", SqlDbType.DateTime);
                command.Parameters.Add("@modificado", SqlDbType.DateTime);

                command.Parameters["@nombre"].Value = prof.Nombre;
                command.Parameters["@apellido"].Value = prof.Apellido;
                command.Parameters["@doc"].Value = prof.Documento;
                command.Parameters["@dire"].Value = prof.Direccion;
                command.Parameters["@tipo"].Value = prof.Tipo;
                command.Parameters["@telefono"].Value = prof.Telefono;
                command.Parameters["@mail"].Value = prof.Mail;
                command.Parameters["@fecNac"].Value = prof.FechaNac;
                command.Parameters["@sexo"].Value = prof.Sexo;
                command.Parameters["@matric"].Value = prof.Matricula;
                command.Parameters["@creado"].Value = DateTime.Now;
                command.Parameters["@modificado"].Value = DateTime.Now;

                connection.Open();

                //int rows = command.ExecuteNonQuery();

                //retorna la PK del nuevo registro
                int nuevoProfesional = Convert.ToInt32(command.ExecuteScalar());

                foreach (int cod in especialidades)
                {
                    SqlCommand commandEspc = connection.CreateCommand();
                    commandEspc.CommandText = "INSERT INTO GESTIONAR.profesional_especialidad(espr_prof_id,espr_especialidad_id)" +
                    "VALUES(@idprof,@idespecialidad)";

                    commandEspc.Parameters.Add("@idprof", SqlDbType.Int);
                    commandEspc.Parameters.Add("@idespecialidad", SqlDbType.Int);

                    commandEspc.Parameters["@idprof"].Value = nuevoProfesional;
                    commandEspc.Parameters["@idespecialidad"].Value = cod;

                    commandEspc.ExecuteNonQuery();
                }

            }
        }
        #endregion

        #region UPDATES
        public void UpdateProf(Profesional prof, List<int> especialidades)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GD2013"].ConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE GESTIONAR.profesional(prof_id,prof_nombre, prof_apellido, prof_nro_documento,prof_dureccion,prof_tipo_documento,prof_telefono,prof_mail,prof_fecha_nacimiento,prof_sexo,prof_matricula,prof_modificado)" +

                "VALUES(@id,@nombre,@apellido, @doc,@dire,@tipo,@telefono,@mail,@fecNac,@sexo,@matric,@creado,@modificado)";

                command.CommandText = "UPDATE GESTIONAR.profesional SET prof_nombre = @nombre, prof_apellido = @apellido,prof_nro_documento=@doc,prof_dureccion=@dire,prof_tipo_documento=@tipo,prof_telefono=@telefono,prof_mail=@mail,prof_fecha_nacimiento=@fecNac,prof_sexo=@sexo,prof_matricula=@matric,prof_modificado=@modificado " +
                "WHERE prof_id = @id";

                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters.Add("@nombre", SqlDbType.VarChar, 255);
                command.Parameters.Add("@apellido", SqlDbType.VarChar, 255);
                command.Parameters.Add("@doc", SqlDbType.Int, 18);
                command.Parameters.Add("@dire", SqlDbType.VarChar, 255);
                command.Parameters.Add("@tipo", SqlDbType.VarChar, 3);
                command.Parameters.Add("@telefono", SqlDbType.Int, 18);
                command.Parameters.Add("@mail", SqlDbType.VarChar, 255);
                command.Parameters.Add("@fecNac", SqlDbType.DateTime);
                command.Parameters.Add("@sexo", SqlDbType.Char, 1);
                command.Parameters.Add("@matric", SqlDbType.VarChar, 8);
                //command.Parameters.Add("@creado", SqlDbType.DateTime);
                command.Parameters.Add("@modificado", SqlDbType.DateTime);

                command.Parameters["@id"].Value = prof.ID;
                command.Parameters["@nombre"].Value = prof.Nombre;
                command.Parameters["@apellido"].Value = prof.Apellido;
                command.Parameters["@doc"].Value = prof.Documento;
                command.Parameters["@dire"].Value = prof.Direccion;
                command.Parameters["@tipo"].Value = prof.Tipo;
                command.Parameters["@telefono"].Value = prof.Telefono;
                command.Parameters["@mail"].Value = prof.Mail;
                command.Parameters["@fecNac"].Value = prof.FechaNac;
                command.Parameters["@sexo"].Value = prof.Sexo;
                command.Parameters["@matric"].Value = prof.Matricula;
                //command.Parameters["@creado"].Value = DateTime.Now;
                command.Parameters["@modificado"].Value = DateTime.Now;

                connection.Open();

                int rows = command.ExecuteNonQuery();

                SqlCommand limpiarEspCom = new SqlCommand("DELETE FROM GESTIONAR.profesional_especialidad WHERE espr_prof_id = @profID", connection);

                // limpio las especialidades antes de agregar las seleccionadas
                limpiarEspCom.Parameters.Add("@profID", SqlDbType.Int);
                limpiarEspCom.Parameters["@profID"].Value = prof.ID;

                limpiarEspCom.ExecuteNonQuery();
                
                foreach (int cod in especialidades)
                {
                    SqlCommand commandEspc = connection.CreateCommand();
                    commandEspc.CommandText = "INSERT INTO GESTIONAR.profesional_especialidad(espr_prof_id,espr_especialidad_id)" +
                    "VALUES(@idprof,@idespecialidad)";

                    commandEspc.Parameters.Add("@idprof", SqlDbType.Int);
                    commandEspc.Parameters.Add("@idespecialidad", SqlDbType.Int);

                    commandEspc.Parameters["@idprof"].Value = prof.ID;
                    commandEspc.Parameters["@idespecialidad"].Value = cod;

                    commandEspc.ExecuteNonQuery();
                }

            }
        }

        #endregion
    }
}
