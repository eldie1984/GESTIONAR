using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clinica.Model;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Clinica.Model;

namespace Clinica
{
    public class DataAccessLayer
    {
        #region GETS

        public List<Profesional> GetProfesionales(string fNombre, string fApellido, string fDoc)
        {
            List<Profesional> listado = new List<Profesional>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GD2013"].ConnectionString))
            {
                connection.Open();

                System.Text.StringBuilder query = new System.Text.StringBuilder();

                query.Append("SELECT prof_id,prof_nombre, prof_apellido, prof_nro_documento,prof_tipo_documento,prof_dureccion,prof_telefono,prof_mail,prof_fecha_nacimiento,prof_sexo,prof_matricula FROM GESTIONAR.profesional  WHERE prof_baja=0");
                if (fNombre != String.Empty && fNombre != null)
                    query.Append(" and prof_nombre LIKE '%" + fNombre + "%'");
                if (fApellido != String.Empty && fApellido != null)
                    query.Append(" and prof_apellido LIKE '%" + fApellido + "%'");
                if (fDoc != String.Empty && fDoc != null)
                    query.Append(" and prof_nro_documento =" + fDoc);

                SqlCommand command = connection.CreateCommand();
                command.CommandText = query.ToString();


                //SqlCommand command = connection.CreateCommand();
                //command.CommandText = "SELECT prof_id,prof_nombre, prof_apellido, prof_nro_documento,prof_tipo_documento,prof_dureccion,prof_telefono,prof_mail,prof_fecha_nacimiento,prof_sexo,prof_matricula FROM GESTIONAR.profesional  WHERE prof_baja=0";
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

        public List<Afiliado> GetAfiliados(string fNombre,string fApellido, string fDoc)
        {
            List<Afiliado> listado = new List<Afiliado>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GD2013"].ConnectionString))
            {
                connection.Open();

                System.Text.StringBuilder query = new System.Text.StringBuilder();
                
                query.Append("SELECT TOP 200 afi_id,afi_sub_id,afi_nombre, afi_apellido, afi_nro_documento,afi_direccion,afi_tipo_documento,afi_telefono,afi_mail,afi_fecha_nacimiento,afi_sexo,afi_estado_id,afi_cant_hijos,afi_plan FROM GESTIONAR.afiliado WHERE afi_baja=0");
                if (fNombre != String.Empty && fNombre != null)
                    query.Append(" and afi_nombre LIKE '%" + fNombre + "%'");
                if (fApellido != String.Empty && fApellido != null)
                    query.Append(" and afi_apellido LIKE '%" + fApellido + "%'");
                if (fDoc != String.Empty && fDoc != null)
                    query.Append(" and afi_nro_documento =" + fDoc);

                SqlCommand command = connection.CreateCommand();
                command.CommandText = query.ToString();

                //SqlCommand command = connection.CreateCommand();
                //command.CommandText = "SELECT TOP 200 afi_id,afi_sub_id,afi_nombre, afi_apellido, afi_nro_documento,afi_direccion,afi_tipo_documento,afi_telefono,afi_mail,afi_fecha_nacimiento,afi_sexo,afi_estado_id,afi_cant_hijos,afi_plan FROM GESTIONAR.afiliado WHERE afi_baja=0";               
                                
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
                    int plan = (int)AfilReader.GetInt32(13);
                    listado.Add(new Afiliado() { ID = id, Sub_ID = subid, Nombre = nombre, Estado = estado, Hijos = hijos, Plan = plan, Apellido = apellido, Direccion = dire, Documento = nrodoc, Tipo = tipodoc, Mail = mail, FechaNac = fechaNac, Sexo = sexo, Telefono = telefono });
                }
                AfilReader.Close();

                return listado;
            }
        }

        public Afiliado GetAfiliadoByID(int mainID, int subID)
        {
            Afiliado afiliado= null;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GD2013"].ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT afi_id,afi_sub_id,afi_nombre, afi_apellido, afi_nro_documento,afi_direccion,afi_tipo_documento,afi_telefono,afi_mail,afi_fecha_nacimiento,afi_sexo,afi_estado_id,afi_cant_hijos,afi_plan FROM GESTIONAR.afiliado WHERE afi_id=@mainID and afi_sub_id=@subID ", connection);

                SqlParameter mainParameter = new SqlParameter("mainID", mainID);
                mainParameter.SqlDbType = SqlDbType.Int;
                SqlParameter subParameter = new SqlParameter("subID", subID);
                subParameter.SqlDbType = SqlDbType.Int;

                command.Parameters.Add(mainParameter);
                command.Parameters.Add(subParameter);

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
                    int plan = (int)AfilReader.GetInt32(13);
                    afiliado = new Afiliado() { ID = id, Sub_ID = subid, Nombre = nombre, Estado = estado, Hijos = hijos, Plan = plan, Apellido = apellido, Direccion = dire, Documento = nrodoc, Tipo = tipodoc, Mail = mail, FechaNac = fechaNac, Sexo = sexo, Telefono = telefono };
                }
                AfilReader.Close();

                return afiliado;
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

        public Plan GetPlanByID(int planID)
        {
            Plan plan=null;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GD2013"].ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT plan_id, plan_nombre, plan_consulta, plan_farmacia FROM GESTIONAR.[plan_medico] where plan_id=@planid ", connection);

                SqlParameter mainParameter = new SqlParameter("planid", planID);
                mainParameter.SqlDbType = SqlDbType.Int;
             
                command.Parameters.Add(mainParameter);
                                              
                SqlDataReader planReader = command.ExecuteReader();

                while (planReader.Read())
                {

                    int cod = planReader.GetInt32(0);
                    string desc = planReader.GetString(1);
                    int consulta = planReader.GetInt32(2);
                    int farmacia = planReader.GetInt32(3);

                    plan= new Plan() { Codigo = cod, Descripcion = desc,PrecioConsulta=consulta,PrecioFarmacia=farmacia };
                }
                planReader.Close();

                return plan;
            }

        }

        public List<Plan> GetPlanes()
        {
            List<Plan> listado = new List<Plan>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GD2013"].ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT plan_id, plan_nombre FROM GESTIONAR.[plan_medico]", connection);
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

        public Int32 getTurnoId(Int32 profesional, DateTime fecha)
        {
            Int32 Resultado = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GD2013"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"select turn_id  " +
                "from GESTIONAR.turno , GESTIONAR.consulta " +
                "where turn_profe_id=@profesional " +
                "and turn_baja=0 " +
                "and turn_hora_inicio >= DATEADD(minute,-15,@ahora)  " +
                "and turn_hora_inicio<DATEADD(minute,15,@ahora)  " +
                "and consul_turno_id=turn_id " +
                "and consul_sintomas is null " +
                "and consul_enfermedades is null;";


                command.Parameters.Add("@profesional", SqlDbType.Int);
                command.Parameters.Add("@ahora", SqlDbType.DateTime);

                command.Parameters["@profesional"].Value = profesional;
                command.Parameters["@ahora"].Value = fecha;
                SqlDataReader Reg = command.ExecuteReader();
                if (Reg.HasRows)
                {
                    Reg.Read();
                    Resultado = Convert.ToInt32(Reg[0].ToString());
                }
            }
            return Resultado;
        }

        public List<string> getFuncID(Int32 rol_id)
        {
            List <string> funcion = new List <string>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GD2013"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"select fu.func_name from GESTIONAR.Rol_funcionalidad rf ,GESTIONAR.funcionalidad fu  " +
                                      "where rf.rolf_rol_id = @rol_id  " +
                                      "and fu.func_id=rf.rolf_func_id  " +
                                      "order by rf.rolf_func_id desc";
                command.Parameters.Add("@rol_id", SqlDbType.Int);
                command.Parameters["@rol_id"].Value = rol_id;
                SqlDataReader especReader = command.ExecuteReader();
                while (especReader.Read())
                {

                    string cod = especReader.GetString(0);

                    funcion.Add(cod);
                }
                especReader.Close();
            }
            return funcion;

        }

        public Usuario getUser(Int32 user_id, Int32 rol_id)
        {

            Usuario result = new Usuario();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GD2013"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"select rol_relacion,rol_relacion_sub from GESTIONAR.rol_usuario ru where ru.rolu_rol_id=@rol_id and ru.rolu_user_id=@user_id";


                command.Parameters.Add("@rol_id", SqlDbType.Int);
                command.Parameters.Add("@user_id", SqlDbType.Int);

                command.Parameters["@rol_id"].Value = rol_id;
                command.Parameters["@user_id"].Value = user_id;
                SqlDataReader Reg = command.ExecuteReader();

                if (Reg.Read())
                {
                    int cod = Reg.GetInt32(0);
                    int cod_sub;
                    if (!Reg.IsDBNull(1))
                    {
                       cod_sub = Reg.GetInt32(1);
                    }
                    else
                    {
                        cod_sub = -1;
                    }


                    result = new Usuario() { id = user_id, rol=rol_id, user_rel=cod, user_rel_sub=cod_sub };
                }
            }
            return result;
        }

        public Int32 getBono(Int32 turno)
        {
            Int32 Resultado = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GD2013"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"select consul_bono_id from GESTIONAR.consulta where consul_turno_id=@turno;";


                command.Parameters.Add("@turno", SqlDbType.Int);
                
                command.Parameters["@turno"].Value = turno;
               
                SqlDataReader Reg = command.ExecuteReader();
                if (Reg.HasRows)
                {
                    Reg.Read();
                    Resultado = Convert.ToInt32(Reg[0].ToString());
                }
            }
            return Resultado;
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
                command.Parameters["@creado"].Value = Helper.GetFechaNow();
                command.Parameters["@modificado"].Value = Helper.GetFechaNow();

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
                command.Parameters["@creado"].Value = Helper.GetFechaNow();
                command.Parameters["@modificado"].Value = Helper.GetFechaNow();
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

                SqlParameter creadoParameter = new SqlParameter("creado", Helper.GetFechaNow());
                command.Parameters.Add(creadoParameter);

                SqlParameter modificadoParameter = new SqlParameter("modificado", Helper.GetFechaNow());
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

        //inserta nueva compra
        public int AddCompra(Compra comp)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GD2013"].ConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO GESTIONAR.Compra(compra_afi_id,compra_afi_sub_id,compra_suma,compra_cant_farmacia,compra_cant_consulta,compra_plan_id,compra_creado,compra_modificado)" +

                "VALUES(@afi_id,@afi_subid,@suma,@cantfarmacia,@cantconsulta,@planid,@creado,@modificado)" +
                "SELECT SCOPE_IDENTITY()";

                command.Parameters.Add("@afi_id", SqlDbType.Int);
                command.Parameters.Add("@afi_subid", SqlDbType.Int);
                command.Parameters.Add("@suma", SqlDbType.Int);
                command.Parameters.Add("@cantfarmacia", SqlDbType.Int);
                command.Parameters.Add("@cantconsulta", SqlDbType.Int);
                command.Parameters.Add("@planid", SqlDbType.Int);
                command.Parameters.Add("@creado", SqlDbType.DateTime);
                command.Parameters.Add("@modificado", SqlDbType.DateTime);

                command.Parameters["@afi_id"].Value = comp.afi_ID;
                command.Parameters["@afi_subid"].Value = comp.afi_Sub_ID;
                command.Parameters["@suma"].Value = comp.Suma;
                command.Parameters["@cantfarmacia"].Value = comp.CantFarmacia;
                command.Parameters["@cantconsulta"].Value = comp.CanConsulta;
                command.Parameters["@planid"].Value = comp.PlanID;
                command.Parameters["@creado"].Value = Helper.GetFechaNow();
                command.Parameters["@modificado"].Value = Helper.GetFechaNow();
                connection.Open();

                //int rows = command.ExecuteNonQuery();

                //retorna la PK del nuevo registro
                int nuevaCompra = Convert.ToInt32(command.ExecuteScalar());
                return nuevaCompra;
            }
        }

        public int AddBonoFarmacia(BonoFarmacia bonoFar)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GD2013"].ConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO GESTIONAR.bono_farmacia(bofa_compra_id,bofa_afi_id,bofa_afi_sub_id,bofa_plan_id,bofa_creado,bofa_modificado)" +

                "VALUES(@compraid,@afi_id,@afi_subid,@planid,@creado,@modificado)" +
                "SELECT SCOPE_IDENTITY()";

                command.Parameters.Add("@compraid", SqlDbType.Int);
                command.Parameters.Add("@afi_id", SqlDbType.Int);
                command.Parameters.Add("@afi_subid", SqlDbType.Int);
                command.Parameters.Add("@planid", SqlDbType.Int);
                command.Parameters.Add("@creado", SqlDbType.DateTime);
                command.Parameters.Add("@modificado", SqlDbType.DateTime);

                command.Parameters["@compraid"].Value = bonoFar.compraID;
                command.Parameters["@afi_id"].Value = bonoFar.afi_ID;
                command.Parameters["@afi_subid"].Value = bonoFar.afi_Sub_ID;
                command.Parameters["@planid"].Value = bonoFar.planID;
                command.Parameters["@creado"].Value = Helper.GetFechaNow();
                command.Parameters["@modificado"].Value = Helper.GetFechaNow();
                connection.Open();

                int nuevoBono = Convert.ToInt32(command.ExecuteScalar());
                return nuevoBono;

            }
        }

        public int AddBonoConsulta(BonoConsulta bonoCon)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GD2013"].ConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO GESTIONAR.bono_consulta(boco_compra_id,boco_afi_id,boco_afi_sub_id,boco_plan_id,boco_creado,boco_modificado)" +

                "VALUES(@compraid,@afi_id,@afi_subid,@planid,@creado,@modificado)"+
                "SELECT SCOPE_IDENTITY()";

                command.Parameters.Add("@compraid", SqlDbType.Int);
                command.Parameters.Add("@afi_id", SqlDbType.Int);
                command.Parameters.Add("@afi_subid", SqlDbType.Int);
                command.Parameters.Add("@planid", SqlDbType.Int);
                command.Parameters.Add("@creado", SqlDbType.DateTime);
                command.Parameters.Add("@modificado", SqlDbType.DateTime);

                command.Parameters["@compraid"].Value = bonoCon.compraID;
                command.Parameters["@afi_id"].Value = bonoCon.afi_ID;
                command.Parameters["@afi_subid"].Value = bonoCon.afi_Sub_ID;
                command.Parameters["@planid"].Value = bonoCon.planID;
                command.Parameters["@creado"].Value = Helper.GetFechaNow();
                command.Parameters["@modificado"].Value = Helper.GetFechaNow();
                connection.Open();

                int nuevoBono = Convert.ToInt32(command.ExecuteScalar());
                return nuevoBono;

            }
        }

        public QueryResult AddConsulta(int bono, int turno, int afiliado, int miembro)
        {
            QueryResult nuevaConsulta= new QueryResult();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GD2013"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;
                transaction = connection.BeginTransaction("Crear consulta");

                command.Connection = connection;
                command.Transaction = transaction;
                try
                {
                    command.CommandText = @"INSERT INTO [GD2C2013].[GESTIONAR].[consulta] " +
                                        "([consul_turno_id],[consul_bono_id],[consul_afi_id],[consul_afi_sub_id],[consul_creado],[consul_modificado]) " +
                                        "values" +
                                        "(@turno,@bono,@afiliado,@miembro,@creado,@modificado);" +
                                         "SELECT SCOPE_IDENTITY()";

                    command.Parameters.Add("@turno", SqlDbType.Int);
                    command.Parameters.Add("@bono", SqlDbType.Int);
                    command.Parameters.Add("@afiliado", SqlDbType.Int);
                    command.Parameters.Add("@miembro", SqlDbType.Int);
                    command.Parameters.Add("@creado", SqlDbType.DateTime);
                    command.Parameters.Add("@modificado", SqlDbType.DateTime);

                    command.Parameters["@turno"].Value = turno;
                    command.Parameters["@bono"].Value = bono;
                    command.Parameters["@afiliado"].Value = afiliado;
                    command.Parameters["@miembro"].Value = miembro;
                    command.Parameters["@creado"].Value = Helper.GetFechaNow();
                    command.Parameters["@modificado"].Value = Helper.GetFechaNow();

                    nuevaConsulta.ID = Convert.ToInt32(command.ExecuteScalar());
                    
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                    Console.WriteLine("  Message: {0}", ex.Message);
                    nuevaConsulta.mensaje = nuevaConsulta.mensaje + "Commit Exception Type: " + ex.GetType() + "\n" + "  Message: " + ex.Message;
                    nuevaConsulta.ID = -1;
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                        Console.WriteLine("  Message: {0}", ex2.Message);
                        nuevaConsulta.mensaje = nuevaConsulta.mensaje + "\n" + "Rollback Exception Type: " + ex.GetType() + "\n" + "  Message: " + ex.Message; 
                    }

                }
            }
            return nuevaConsulta;
        }

        #endregion
        
        #region Consulta
        public string persistir_medic(List<int> medic_list, List<int> medic_cant, int afil_id, int bono_id, int consulta)
        {
            string resultado = string.Empty;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GD2013"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;
                transaction = connection.BeginTransaction("Transaccion_medicamento");

                command.Connection = connection;
                command.Transaction = transaction;
                try
                {
                    command.CommandText = "update GESTIONAR.bono_farmacia" +
                                           " set bofa_bono_consulta_id=@consulta," +
                                           "bofa_modificado=@modificado " +
                                           "where bofa_id=@bono";


                    command.Parameters.Add("@consulta", SqlDbType.Int);
                    command.Parameters.Add("@bono", SqlDbType.Int);
                    command.Parameters.Add("@modificado", SqlDbType.DateTime);

                    command.Parameters["@consulta"].Value = consulta;
                    command.Parameters["@bono"].Value = bono_id;
                    command.Parameters["@modificado"].Value = Helper.GetFechaNow();
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO [GD2C2013].[GESTIONAR].[medicamento_bono] " +
                                           "([mebo_bofa_id],[mebo_medic_id],[mebo_cant],[mebo_creado],[mebo_modificado]) " +
                                           "values " +
                                           "(@bono,@medicamento,@cantidad,@modificado,@modificado)";
                    command.Parameters.Add("@medicamento", SqlDbType.Int);
                    command.Parameters.Add("@cantidad", SqlDbType.Int);

                    for (int i = 0; i < medic_list.Count; i++)
                    {
                        command.Parameters["@medicamento"].Value = medic_list[i];
                        command.Parameters["@cantidad"].Value = medic_cant[i];
                        command.Parameters["@modificado"].Value = Helper.GetFechaNow();
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                    Console.WriteLine("  Message: {0}", ex.Message);
                    resultado = resultado + "Commit Exception Type: " + ex.GetType() + "\n" + "  Message: " + ex.Message; 
                  
                    // Attempt to roll back the transaction. 
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        // This catch block will handle any errors that may have occurred 
                        // on the server that would cause the rollback to fail, such as 
                        // a closed connection.
                        Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                        Console.WriteLine("  Message: {0}", ex2.Message);
                        resultado = resultado +"\n" + "Rollback Exception Type: " + ex.GetType() + "\n" + "  Message: " + ex.Message; 
                    }
                    
                }
            }
            return resultado;
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
                command.Parameters["@modificado"].Value = Helper.GetFechaNow();

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

                SqlParameter creadoParameter = new SqlParameter("creado", Helper.GetFechaNow());
                command.Parameters.Add(creadoParameter);

                SqlParameter estadoParameter = new SqlParameter("estado", afi.Estado);
                command.Parameters.Add(estadoParameter);

                SqlParameter hijosParameter = new SqlParameter("hijos", afi.Hijos);
                command.Parameters.Add(hijosParameter);

                SqlParameter planParameter = new SqlParameter("plan", afi.Plan);
                command.Parameters.Add(planParameter);

                SqlParameter modificadoParameter = new SqlParameter("modificado", Helper.GetFechaNow());
                command.Parameters.Add(modificadoParameter);


                int rows = command.ExecuteNonQuery();



            }
        }

        public string updateConsul(Int32 id_turno, string sintoma, string enfermedad)
        {
            string resultado = string.Empty;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GD2013"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;
                transaction = connection.BeginTransaction("Crear consulta");

                command.Connection = connection;
                command.Transaction = transaction;
                try
                {
                    command.CommandText = @"UPDATE [GESTIONAR].[consulta] " +
                                        "SET " +
                                        "consul_sintomas = @Sintoma, " +
                                        "consul_enfermedades=@Enfermedad, " +
                                        "consul_modificado=@modificado " +
                                        "where consul_turno_id =@turno_id";


                    command.Parameters.Add("@turno_id", SqlDbType.Int);
                    command.Parameters.Add("@Sintoma", SqlDbType.Text);
                    command.Parameters.Add("@Enfermedad", SqlDbType.Text);
                    command.Parameters.Add("@modificado", SqlDbType.DateTime);

                    command.Parameters["@turno_id"].Value = id_turno;
                    command.Parameters["@Sintoma"].Value = sintoma;
                    command.Parameters["@Enfermedad"].Value = enfermedad;
                    command.Parameters["@modificado"].Value = Helper.GetFechaNow();
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                    Console.WriteLine("  Message: {0}", ex.Message);
                    resultado = resultado + "Commit Exception Type: " + ex.GetType() + "\n" + "  Message: " + ex.Message;
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                        Console.WriteLine("  Message: {0}", ex2.Message);
                        resultado = resultado + "\n" + "Rollback Exception Type: " + ex.GetType() + "\n" + "  Message: " + ex.Message;
                    }

                }

            }
            return resultado;

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

                SqlParameter modParameter = new SqlParameter("modificado", Helper.GetFechaNow());
                command.Parameters.Add(modParameter);

                int rows = command.ExecuteNonQuery();
            }
        }

        public void BajaProfesional(Profesional prof)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GD2013"].ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("GESTIONAR.ProfesionalBaja", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter profidParameter = new SqlParameter("profid", prof.ID);
                command.Parameters.Add(profidParameter);

                SqlParameter modParameter = new SqlParameter("modificado", Helper.GetFechaNow());
                command.Parameters.Add(modParameter);

                int rows = command.ExecuteNonQuery();
            }
        }

        #endregion

        #region CHECK

        public bool checkBono(Int32 bono)
        {
            bool Resultado = false;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GD2013"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"select * from GESTIONAR.bono_farmacia " +
                                        "where bofa_id=@bono " +
                                        "and bofa_bono_consulta_id is null " +
                                        "and dateadd(day,60,bofa_creado) >= @ahora " +
                                        "and bofa_id not in (select mebo_bofa_id from GESTIONAR.medicamento_bono)";

                command.Parameters.Add("@bono", SqlDbType.Int);
                command.Parameters.Add("@ahora", SqlDbType.DateTime);

                command.Parameters["@bono"].Value = bono;
                command.Parameters["@ahora"].Value = Helper.GetFechaNow();
                SqlDataReader Reg = command.ExecuteReader();
                if (Reg.HasRows)
                {
                    Resultado = true;
                }
            }
            return Resultado;

        }

        public bool checkTurno(Int32 turno, Int32 afil_id, Int32 afi_sub_id)
        {
            bool Resultado = false;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GD2013"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"select * from GESTIONAR.turno " +
                                        "where turn_id=@turno " +
                                        "and turn_afil_id=@afil_id " +
                                        "and turn_afi_sub_id=@afi_sub_id";

                command.Parameters.Add("@turno", SqlDbType.Int);
                command.Parameters.Add("@afil_id", SqlDbType.Int);
                command.Parameters.Add("@afi_sub_id", SqlDbType.Int);

                command.Parameters["@turno"].Value = turno;
                command.Parameters["@afil_id"].Value = afil_id;
                command.Parameters["@afi_sub_id"].Value = afi_sub_id;

                SqlDataReader Reg = command.ExecuteReader();
                if (Reg.HasRows)
                {
                    Resultado = true;
                }

            }

            
            return Resultado;
        }

        public bool checkBonoConsulta(Int32 bono, int afiliado)
        {
            bool Resultado = false;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GD2013"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"select * from GESTIONAR.bono_consulta " +
                                        "where boco_id=@bono " +
                                        "and boco_afi_id = @afil_id " +
                                        "and boco_id  in (select consul_bono_id " +
                                        "from GESTIONAR.consulta " +
                                        "where consul_afi_id=@afil_id)";

                command.Parameters.Add("@bono", SqlDbType.Int);
                command.Parameters.Add("@afil_id", SqlDbType.Int);
                //command.Parameters.Add("@afi_sub_id", SqlDbType.Int);

                command.Parameters["@bono"].Value = bono;
                command.Parameters["@afil_id"].Value = afiliado;
                //command.Parameters["@afi_sub_id"].Value = afi_sub_id;

                SqlDataReader Reg = command.ExecuteReader();
                if (!Reg.HasRows)
                {
                    Resultado = true;
                }

            }
            return Resultado;
        }

        #endregion
    }
}
