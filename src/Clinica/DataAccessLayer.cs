﻿using System;
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

                    listado.Add(new Profesional() { ID = id, Nombre = nombre, Apellido = apellido, Direccion = dire, Documento = nrodoc, Tipo = tipodoc, Mail = mail, FechaNac = fechaNac, Sexo = sexo, Matricula = matricula, Telefono = telefono });
                }
                ProfReader.Close();

                return listado;
            }
        }

        public List<Afiliado> GetAfiliados()
        {
            List<Afiliado> listado = new List<Afiliado>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GD2013"].ConnectionString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT TOP 200 afi_id,afi_sub_id,afi_nombre, afi_apellido, afi_nro_documento,afi_direccion,afi_tipo_documento,afi_telefono,afi_mail,afi_fecha_nacimiento,afi_sexo,afi_estado_id,afi_cant_hijos,afi_plan FROM GESTIONAR.afiliado WHERE afi_baja=0";
                SqlDataReader AfilReader = command.ExecuteReader();

                while (AfilReader.Read())
                {
                    int id = AfilReader.GetInt32(0);
                    int subid = AfilReader.GetInt32(1);
                    string nombre = AfilReader.GetString(2);
                    string apellido = AfilReader.GetString(3);
                    decimal nrodoc = AfilReader.GetDecimal(4);
                    string dire = AfilReader.GetString(5);
                    string tipodoc = AfilReader.GetString(6);
                    decimal telefono = AfilReader.GetDecimal(7);
                    string mail = AfilReader.GetString(8);
                    DateTime fechaNac = AfilReader.GetDateTime(9);
                    string sexo = AfilReader.GetString(10);
                    int estado = AfilReader.GetInt32(11);
                    int hijos = AfilReader.GetInt32(12);
                    int plan = (int)AfilReader.GetDecimal(13);
                    listado.Add(new Afiliado() { ID = id, Sub_ID = subid, Nombre = nombre, Estado = estado, Hijos = hijos, Plan = plan, Apellido = apellido, Direccion = dire, Documento = nrodoc, Tipo = tipodoc, Mail = mail, FechaNac = fechaNac, Sexo = sexo, Telefono = telefono });
                }
                AfilReader.Close();

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

        public List<Plan> GetPlanes()
        {
            List<Plan> listado = new List<Plan>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GD2013"].ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT plan_id, plan_nombre FROM GESTIONAR.[Plan]", connection);
                SqlDataReader especReader = command.ExecuteReader();

                while (especReader.Read())
                {

                    int cod = especReader.GetInt32(0);
                    string desc = especReader.GetString(1);

                    listado.Add(new Plan() { Codigo = cod, Descripcion = desc });
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

                SqlParameter nameParameter = new SqlParameter("profID", idProf);
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

        //agrega profesional
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

        //agrega afiliado
        public int AddAfiliado(Afiliado afi)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GD2013"].ConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO GESTIONAR.afiliado(afi_sub_id,afi_nombre, afi_apellido, afi_nro_documento,afi_direccion,afi_tipo_documento,afi_telefono,afi_mail,afi_fecha_nacimiento,afi_sexo,afi_creado,afi_modificado,afi_estado_id,afi_cant_hijos,afi_plan,afi_baja)" +

                "VALUES(@subid,@nombre,@apellido, @doc,@dire,@tipo,@telefono,@mail,@fecNac,@sexo,@creado,@modificado,@estado,@hijos,@plan,@baja)" +
                "SELECT SCOPE_IDENTITY()";

                command.Parameters.Add("@subid", SqlDbType.Int);
                command.Parameters.Add("@nombre", SqlDbType.VarChar, 255);
                command.Parameters.Add("@apellido", SqlDbType.VarChar, 255);
                command.Parameters.Add("@doc", SqlDbType.Int, 18);
                command.Parameters.Add("@dire", SqlDbType.VarChar, 255);
                command.Parameters.Add("@tipo", SqlDbType.VarChar, 3);
                command.Parameters.Add("@telefono", SqlDbType.Int, 18);
                command.Parameters.Add("@mail", SqlDbType.VarChar, 255);
                command.Parameters.Add("@fecNac", SqlDbType.DateTime);
                command.Parameters.Add("@sexo", SqlDbType.Char, 1);
                command.Parameters.Add("@creado", SqlDbType.DateTime);
                command.Parameters.Add("@modificado", SqlDbType.DateTime);
                command.Parameters.Add("@estado", SqlDbType.Int);
                command.Parameters.Add("@hijos", SqlDbType.Int);
                command.Parameters.Add("@plan", SqlDbType.Int);
                command.Parameters.Add("@baja", SqlDbType.Int);

                command.Parameters["@subid"].Value = afi.Sub_ID;
                command.Parameters["@nombre"].Value = afi.Nombre;
                command.Parameters["@apellido"].Value = afi.Apellido;
                command.Parameters["@doc"].Value = afi.Documento;
                command.Parameters["@dire"].Value = afi.Direccion;
                command.Parameters["@tipo"].Value = afi.Tipo;
                command.Parameters["@telefono"].Value = afi.Telefono;
                command.Parameters["@mail"].Value = afi.Mail;
                command.Parameters["@fecNac"].Value = afi.FechaNac;
                command.Parameters["@sexo"].Value = afi.Sexo;
                command.Parameters["@creado"].Value = DateTime.Now;
                command.Parameters["@modificado"].Value = DateTime.Now;
                command.Parameters["@estado"].Value = afi.Estado;
                command.Parameters["@hijos"].Value = afi.Hijos;
                command.Parameters["@plan"].Value = afi.Plan;
                command.Parameters["@baja"].Value = 0;
                connection.Open();

                //int rows = command.ExecuteNonQuery();

                //retorna la PK del nuevo registro
                int nuevoAfiliado = Convert.ToInt32(command.ExecuteScalar());
                return nuevoAfiliado;
            }
        }

        //agrega afiliado de un grupo familiar
        public void AddAfiliadoGrupo(Afiliado afi)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GD2013"].ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("GESTIONAR.AfiliadoGrupoInsert", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter mainIdParameter = new SqlParameter("mainid", afi.ID);
                command.Parameters.Add(mainIdParameter);

                SqlParameter subIdParameter = new SqlParameter("subid", afi.Sub_ID);
                command.Parameters.Add(subIdParameter);

                SqlParameter nombreParameter = new SqlParameter("nombre", afi.Nombre);
                command.Parameters.Add(nombreParameter);

                SqlParameter apellidoParameter = new SqlParameter("apellido", afi.Apellido);
                command.Parameters.Add(apellidoParameter);

                SqlParameter docParameter = new SqlParameter("doc", afi.Documento);
                command.Parameters.Add(docParameter);

                SqlParameter direParameter = new SqlParameter("dire", afi.Direccion);
                command.Parameters.Add(direParameter);

                SqlParameter tipoDocParameter = new SqlParameter("tipo", afi.Tipo);
                command.Parameters.Add(tipoDocParameter);

                SqlParameter telefonoParameter = new SqlParameter("telefono", afi.Telefono);
                command.Parameters.Add(telefonoParameter);

                SqlParameter mailParameter = new SqlParameter("mail", afi.Mail);
                command.Parameters.Add(mailParameter);

                SqlParameter fecNacParameter = new SqlParameter("fecNac", afi.FechaNac);
                command.Parameters.Add(fecNacParameter);

                SqlParameter SexoParameter = new SqlParameter("sexo", afi.Sexo);
                command.Parameters.Add(SexoParameter);

                SqlParameter creadoParameter = new SqlParameter("creado", DateTime.Now);
                command.Parameters.Add(creadoParameter);

                SqlParameter modificadoParameter = new SqlParameter("modificado", DateTime.Now);
                command.Parameters.Add(modificadoParameter);

                SqlParameter estadoParameter = new SqlParameter("estado", afi.Estado);
                command.Parameters.Add(estadoParameter);

                SqlParameter hijosParameter = new SqlParameter("hijos", afi.Hijos);
                command.Parameters.Add(hijosParameter);

                SqlParameter planParameter = new SqlParameter("plan", afi.Plan);
                command.Parameters.Add(planParameter);

                SqlParameter bajaParameter = new SqlParameter("baja", false);
                command.Parameters.Add(bajaParameter);



                command.ExecuteNonQuery();

            }
        }

        #endregion

        #region UPDATES
        public void UpdateProf(Profesional prof, List<int> especialidades)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GD2013"].ConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                // command.CommandText = "UPDATE GESTIONAR.profesional(prof_id,prof_nombre, prof_apellido, prof_nro_documento,prof_dureccion,prof_tipo_documento,prof_telefono,prof_mail,prof_fecha_nacimiento,prof_sexo,prof_matricula,prof_modificado)" +

                // "VALUES(@id,@nombre,@apellido, @doc,@dire,@tipo,@telefono,@mail,@fecNac,@sexo,@matric,@creado,@modificado)";

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

        public void UpdateAfiliado(Afiliado afi)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GD2013"].ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("GESTIONAR.AfiliadoUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter mainIdParameter = new SqlParameter("mainid", afi.ID);
                command.Parameters.Add(mainIdParameter);

                SqlParameter subIdParameter = new SqlParameter("subid", afi.Sub_ID);
                command.Parameters.Add(subIdParameter);

                SqlParameter nombreParameter = new SqlParameter("nombre", afi.Nombre);
                command.Parameters.Add(nombreParameter);

                SqlParameter apellidoParameter = new SqlParameter("apellido", afi.Apellido);
                command.Parameters.Add(apellidoParameter);

                SqlParameter docParameter = new SqlParameter("doc", afi.Documento);
                command.Parameters.Add(docParameter);

                SqlParameter direParameter = new SqlParameter("dire", afi.Direccion);
                command.Parameters.Add(direParameter);

                SqlParameter tipoDocParameter = new SqlParameter("tipo", afi.Tipo);
                command.Parameters.Add(tipoDocParameter);

                SqlParameter telefonoParameter = new SqlParameter("telefono", afi.Telefono);
                command.Parameters.Add(telefonoParameter);

                SqlParameter mailParameter = new SqlParameter("mail", afi.Mail);
                command.Parameters.Add(mailParameter);

                SqlParameter fecNacParameter = new SqlParameter("fecNac", afi.FechaNac);
                command.Parameters.Add(fecNacParameter);

                SqlParameter SexoParameter = new SqlParameter("sexo", afi.Sexo);
                command.Parameters.Add(SexoParameter);

                SqlParameter creadoParameter = new SqlParameter("creado", DateTime.Now);
                command.Parameters.Add(creadoParameter);

                SqlParameter estadoParameter = new SqlParameter("estado", afi.Estado);
                command.Parameters.Add(estadoParameter);

                SqlParameter hijosParameter = new SqlParameter("hijos", afi.Hijos);
                command.Parameters.Add(hijosParameter);

                SqlParameter planParameter = new SqlParameter("plan", afi.Plan);
                command.Parameters.Add(planParameter);


                int rows = command.ExecuteNonQuery();



            }
        }

        #endregion


        #region DELETES
        public void BajaAfiliado(Afiliado afi)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GD2013"].ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("GESTIONAR.AfiliadoBaja", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter mainIdParameter = new SqlParameter("mainid", afi.ID);
                command.Parameters.Add(mainIdParameter);

                SqlParameter subIdParameter = new SqlParameter("subid", afi.Sub_ID);
                command.Parameters.Add(subIdParameter);

                int rows = command.ExecuteNonQuery();
            }
        }

        #endregion
    }
}
