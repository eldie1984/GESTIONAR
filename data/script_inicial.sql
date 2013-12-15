USE [GD2C2013]
GO

Select 'Creo el esquema'

GO

CREATE SCHEMA [GESTIONAR] AUTHORIZATION [gd]
GO

Select 'Creo la tabla estado Civil'

CREATE TABLE [GESTIONAR].[estado_civil](
    esta_id [int] IDENTITY(0,1) NOT NULL,
    esta_nombre [varchar](30) NULL,
    esta_creado [datetime] NULL,
    esta_modificado [datetime] NULL
  CONSTRAINT [PK_GESTIONAR.estado] PRIMARY KEY CLUSTERED 
  (
    [esta_id] ASC
  )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]
  GO
  
Select 'Populo la tabla estado Civil'

insert into [GD2C2013].[GESTIONAR].[estado_civil]
    ([esta_nombre],
  [esta_creado],
  [esta_modificado])
    values
    ('Soltero/a',SYSDATETIME(),SYSDATETIME()),
    ('Casado/a',SYSDATETIME(),SYSDATETIME()),
    ('Viudo/a',SYSDATETIME(),SYSDATETIME()),
    ('Concubinato',SYSDATETIME(),SYSDATETIME()),
    ('Divorciado/a',SYSDATETIME(),SYSDATETIME());
    GO

  Select 'Creo la Tabla plan_medico'

CREATE TABLE [GESTIONAR].[plan_medico](
  [plan_id] [int] IDENTITY(555560,1) NOT NULL ,
  [plan_nombre] [varchar](255) NULL,
  [plan_consulta] [int] NOT NULL,
  [plan_farmacia] [int] NOT NULL,
  [plan_creado] [datetime] NULL,
  [plan_modificado] [datetime] NULL
  CONSTRAINT [PK_GESTIONAR.plan] PRIMARY KEY CLUSTERED 
(
  [plan_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT  [GD2C2013].[GESTIONAR].[plan_medico] ON

select ' Populo la tabla plan_medico '

insert into [GESTIONAR].[plan_medico](
[plan_id],
[plan_nombre],
[plan_consulta],
[plan_farmacia],
[plan_creado],
[plan_modificado])
(select 
  Plan_Med_Codigo
  ,Plan_Med_Descripcion
  ,min(Plan_Med_Precio_Bono_Consulta) 
  , min(Plan_Med_Precio_Bono_Farmacia) 
  ,SYSDATETIME()
  ,SYSDATETIME()
from gd_esquema.Maestra
group by Plan_Med_Codigo,Plan_Med_Descripcion);



SET IDENTITY_INSERT  [GD2C2013].[GESTIONAR].[plan_medico] OFF

select 'creo tabla afiliado'

GO

CREATE TABLE [GESTIONAR].[afiliado](
    afi_id [int] IDENTITY(0,1) NOT NULL,
    afi_sub_id [int] NOT NULL,
    afi_nombre [varchar](255) NULL,
    afi_apellido [varchar](255) NULL,
    afi_tipo_documento [varchar](3) NULL,
    afi_nro_documento  [numeric](18, 0) NULL unique,
    afi_direccion [varchar](255) NULL,
    afi_telefono [numeric](18, 0) NULL,
    afi_mail [varchar](255) NULL,
    afi_fecha_nacimiento [datetime] NULL,
    afi_sexo [char] (1),
    afi_estado_id [int] NOT NULL REFERENCES GESTIONAR.estado_civil (esta_id),
    afi_cant_hijos [int],
    afi_plan [int] NOT NULL REFERENCES GESTIONAR.plan_medico (plan_id),
    afi_baja [bit] NULL,
    afi_creado [datetime] NULL,
    afi_modificado [datetime] NULL, 
PRIMARY KEY CLUSTERED 
(
  [afi_id] ASC,
  [afi_sub_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
  GO

CREATE TABLE [GESTIONAR].[Hist_Plan_Afiliado](
    hist_id [int] IDENTITY(0,1) NOT NULL,
    hist_fecha [datetime] NOT NULL,
    hist_afi_id [int] NOT NULL,
    hist_afi_sub_id [int] NOT NULL,
    hist_motivo [varchar] (255)  NULL,
    hist_plan_id int NULL references GESTIONAR.[plan_medico] (plan_id),
    foreign key (hist_afi_id,hist_afi_sub_id) references GESTIONAR.afiliado (afi_id,afi_sub_id),
  CONSTRAINT [PK_GESTIONAR.Hist_Plan_Afiliado] PRIMARY KEY CLUSTERED 
  (
    [hist_id] ASC
  )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]
  GO
  
select 'Populo la tabla Afiliado'

INSERT INTO [GESTIONAR].[afiliado](
	afi_sub_id,
    afi_nombre ,
    afi_apellido ,
    afi_tipo_documento ,
    afi_nro_documento,
    afi_direccion ,
    afi_telefono ,
    afi_mail,
    afi_fecha_nacimiento ,
    afi_sexo,
    afi_estado_id ,
    afi_cant_hijos ,
    afi_plan ,
    afi_baja ,
    afi_creado,
    afi_modificado)
(SELECT 1
	  ,[Paciente_Nombre]
      ,[Paciente_Apellido]
      ,'DNI'
      ,[Paciente_Dni]
      ,[Paciente_Direccion]
      ,[Paciente_Telefono]
      ,[Paciente_Mail]
      ,[Paciente_Fecha_Nac]
      ,'M'
      ,1
      ,0
      ,[Plan_Med_Codigo]
      ,0
      ,SYSDATETIME()
      ,SYSDATETIME()
  FROM [GD2C2013].[gd_esquema].[Maestra] m
  group by [Paciente_Nombre]
      ,[Paciente_Apellido]
      ,[Paciente_Dni]
      ,[Paciente_Direccion]
      ,[Paciente_Telefono]
      ,[Paciente_Mail]
      ,[Paciente_Fecha_Nac]
      ,[Plan_Med_Codigo]);
GO

select 'Creo la tabla Profesional'

CREATE TABLE [GESTIONAR].[profesional](
    prof_id [int] IDENTITY(0,1) NOT NULL,
    prof_nombre [varchar](255) NULL,
    prof_apellido [varchar](255) NULL,
    prof_tipo_documento [varchar] (3) NULL,
    prof_nro_documento [numeric](18, 0) NOT NULL unique,
    prof_dureccion [varchar](255) NULL,
    prof_telefono [numeric](18, 0) NULL,
    prof_mail [varchar](255) NULL,
    prof_fecha_nacimiento [datetime] NULL,
    prof_sexo [char] (1),
    prof_matricula [varchar](8) NULL unique,
    prof_creado [datetime] NULL,
    prof_modificado[datetime] NULL,
	prof_baja [bit] NULL
  CONSTRAINT [PK_GESTIONAR.profesional] PRIMARY KEY CLUSTERED 
  (
    [prof_id] ASC
  )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]

  GO

select 'Populo la tabla profesional'

insert into [GESTIONAR].[profesional](
    prof_nombre,
    prof_apellido,
    prof_tipo_documento,
    prof_nro_documento,
    prof_dureccion,
    prof_telefono,
    prof_mail,
    prof_fecha_nacimiento,
    prof_sexo,
    prof_matricula,
    prof_creado,
    prof_modificado,
	  prof_baja)
    (SELECT m.Medico_Nombre,
     m.Medico_Apellido,
     'DNI',
       m.Medico_Dni,
       m.Medico_Direccion,
       m.Medico_Telefono,
       m.Medico_Mail,
       m.Medico_Fecha_Nac,
       'M'
       ,LEFT( NEWID(), 8 )
       ,SYSDATETIME()
       ,SYSDATETIME()
	   ,0
    FROM gd_esquema.Maestra m
    WHERE m.Medico_Apellido IS NOT NULL
    GROUP BY m.Medico_Apellido,
         m.Medico_Direccion,
         m.Medico_Dni,
         m.Medico_Fecha_Nac,
         m.Medico_Mail,
         m.Medico_Nombre,
         m.Medico_Telefono)
GO

select 'Creo la tabla tipo especialidad'

CREATE TABLE [GESTIONAR].[tipo_especialidad](
  [tipoe_Codigo] [int] IDENTITY(10049,1) NOT NULL ,
  [tipoe_Descripcion] [varchar](255) NULL,
  tipoe_creado [datetime] NULL,
  tipoe_modificado [datetime] NULL
CONSTRAINT [PK_GESTIONAR.tipo_especialidad] PRIMARY KEY CLUSTERED 
  (
    [tipoe_codigo] ASC
  )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]
GO

SET IDENTITY_INSERT  [GD2C2013].[GESTIONAR].[tipo_especialidad] ON
GO

select 'Populo la tabla tipo especialidad'

INSERT INTO [GD2C2013].[GESTIONAR].[tipo_especialidad]
           (tipoe_Codigo
           ,[tipoe_Descripcion]
           ,[tipoe_creado]
           ,[tipoe_modificado])
     (select tipo_especialidad_Codigo,tipo_especialidad_Descripcion 
     ,SYSDATETIME()
       ,SYSDATETIME()
     from gd_esquema.Maestra
     where tipo_especialidad_Codigo is not null
group by tipo_especialidad_Codigo,tipo_especialidad_Descripcion)

GO

SET IDENTITY_INSERT  [GD2C2013].[GESTIONAR].[tipo_especialidad] OFF
GO

select 'Creo la tabla especialidad'

CREATE TABLE [GESTIONAR].[especialidad](
  [espe_Codigo] [int] IDENTITY(10049,1) NOT NULL ,
  [espe_Descripcion] [varchar](255) NULL,
  [espe_tipo_id] [int] NOT NULL REFERENCES GESTIONAR.tipo_especialidad (tipoe_codigo),
  [espe_creado] [datetime] NULL,
  [espe_modificado] [datetime] NULL
CONSTRAINT [PK_GESTIONAR.especialidad] PRIMARY KEY CLUSTERED 
  (
    [espe_Codigo] ASC
  )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]
  GO

SET IDENTITY_INSERT  [GD2C2013].[GESTIONAR].[especialidad] ON
GO

select 'Populo la tabla especialidad'

  INSERT INTO [GD2C2013].[GESTIONAR].[especialidad]
           ([espe_Codigo]
           ,[espe_Descripcion]
           ,[espe_tipo_id]
           ,[espe_creado]
           ,[espe_modificado])
     (select especialidad_codigo,especialidad_Descripcion,tipo_especialidad_Codigo
      ,SYSDATETIME()
       ,SYSDATETIME()
      from gd_esquema.Maestra
where especialidad_Codigo is not null
group by especialidad_codigo,especialidad_Descripcion,tipo_especialidad_Codigo)

GO
SET IDENTITY_INSERT  [GD2C2013].[GESTIONAR].[especialidad] OFF
GO

Select 'Creo la tabla de relacion profesional especialidad'

CREATE TABLE [GESTIONAR].[profesional_especialidad](
  [espr_id] [int] IDENTITY(0,1) NOT NULL ,
  [espr_prof_id] [int] NOT NULL REFERENCES GESTIONAR.profesional (prof_id),
  [espr_especialidad_id] [int] NOT NULL REFERENCES GESTIONAR.especialidad (espe_Codigo),
  [espr_creado] [datetime] NULL,
  [espr_modificado] [datetime] NULL
CONSTRAINT [PK_GESTIONAR.prof_especialidad] PRIMARY KEY CLUSTERED 
  (
    [espr_id] ASC
  )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]
  GO
  
select 'Creo las relaciones de la tabla profesional especialidad'

INSERT INTO [GD2C2013].[GESTIONAR].[profesional_especialidad]
           ([espr_prof_id]
           ,[espr_especialidad_id]
           ,[espr_creado]
           ,[espr_modificado])
     (select prof_id,Espe_Codigo,SYSDATETIME(),SYSDATETIME() from gd_esquema.Maestra,GESTIONAR.profesional,GESTIONAR.Especialidad
where prof_nro_documento=Medico_Dni
and Espe_Codigo=Especialidad_Codigo
group by prof_id,Espe_Codigo)
GO


Select 'Creo tabla funcionalidad'
GO
CREATE TABLE [GESTIONAR].[funcionalidad](
      [func_id] [int] IDENTITY(0,1) NOT NULL,
      [func_name] [nvarchar](255) NULL,
      [func_creado] [datetime] NULL,
      [func_modificado] [datetime] NULL
      CONSTRAINT [PK_GESTIONAR.funcionalidad] PRIMARY KEY CLUSTERED 
(
  [func_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

Select 'Creo las funcionalidades'
GO
INSERT INTO [GESTIONAR].[funcionalidad]([func_name],[func_creado],[func_modificado])
  VALUES
 ('consultaToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('registrarResultadoToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('aBMToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('altaRolToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('bajaRolToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('modificarRolToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('usuarioToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('altaUsuarioToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('bajaUsuarioToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('modificarToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('afiliadoToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('altaAfiliadoToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('bajaAfiliadoToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('modificarAfiliadoToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('profesionalToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('altaProfesionalToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('bajaProfesionalToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('modificarProfesionalToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('especialidadesToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('altaEspecialidadesToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('bajaEspecialidadesToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('modificarEspecialidadesToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('planToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('altaPlanToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('bajaPlanToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('mToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('registrarLlegadaToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('listarRolesToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('listarUsuariosToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('listarAfiliadosToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('listarProfesionalToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('listarEspecialidadesToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('listarPlanToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('agendaToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('registrarToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('pedidoTurnoToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('cancelarAtencionToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('bonosToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('comprarBonosToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('toolStripMenuItem1',SYSDATETIME(),SYSDATETIME()) ,
 ('estadisticasToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('bonosFarmaciaVencidosToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('especialidadesConCancelacionesToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('bonosFarmaciaRecetadosToolStripMenuItem',SYSDATETIME(),SYSDATETIME()) ,
 ('afiliadosQueUsaronPeroNoCompraronToolStripMenuItem',SYSDATETIME(),SYSDATETIME())


Select 'Creo tabla rol'

GO

CREATE TABLE [GESTIONAR].[rol](
      [rol_id] [int] IDENTITY(0,1) NOT NULL,
      [rol_nombre] [nvarchar](255) NULL,
      [rol_creado] [datetime] NULL,
      [rol_modificado] [datetime] NULL,
      [rol_borrado] [bit] NULL
      CONSTRAINT [PK_GESTIONAR.rol] PRIMARY KEY CLUSTERED 
(
  [rol_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
Select 'Creo los roles'
GO
insert into GESTIONAR.rol (rol_nombre,rol_creado,rol_modificado,rol_borrado)
values
('Profesional',SYSDATETIME(),SYSDATETIME(),0),
('Administrativo',SYSDATETIME(),SYSDATETIME(),0),
('Afiliado',SYSDATETIME(),SYSDATETIME(),0)

GO
Select 'Creo tabla rol funcionalidad'
GO
CREATE TABLE [GESTIONAR].[rol_funcionalidad](
      [rolf_id] [int] IDENTITY(0,1) NOT NULL,
      [rolf_rol_id] [int] NOT NULL REFERENCES GESTIONAR.rol (rol_id),
      [rolf_func_id] [int] NOT NULL REFERENCES GESTIONAR.funcionalidad (func_id),
      [rolf_creado] [datetime] NULL
CONSTRAINT [PK_GESTIONAR.rol_funcionalidad] PRIMARY KEY CLUSTERED 
(
  [rolf_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

Select 'Creo la relacion entre el rol y la funcionalidad'
GO

insert into [GESTIONAR].[rol_funcionalidad]
 ([rolf_rol_id],[rolf_func_id],[rolf_creado])
 values
(1,0,SYSDATETIME()),
(1,2,SYSDATETIME()),
(1,3,SYSDATETIME()),
(1,4,SYSDATETIME()),
(1,5,SYSDATETIME()),
(1,6,SYSDATETIME()),
(1,7,SYSDATETIME()),
(1,8,SYSDATETIME()),
(1,9,SYSDATETIME()),
(1,10,SYSDATETIME()),
(1,11,SYSDATETIME()),
(1,12,SYSDATETIME()),
(1,13,SYSDATETIME()),
(1,14,SYSDATETIME()),
(1,15,SYSDATETIME()),
(1,16,SYSDATETIME()),
(1,17,SYSDATETIME()),
(1,18,SYSDATETIME()),
(1,19,SYSDATETIME()),
(1,20,SYSDATETIME()),
(1,21,SYSDATETIME()),
(1,22,SYSDATETIME()),
(1,23,SYSDATETIME()),
(1,24,SYSDATETIME()),
(1,25,SYSDATETIME()),
(1,26,SYSDATETIME()),
(1,27,SYSDATETIME()),
(1,28,SYSDATETIME()),
(1,29,SYSDATETIME()),
(1,30,SYSDATETIME()),
(1,31,SYSDATETIME()),
(1,32,SYSDATETIME()),
(1,33,SYSDATETIME()),
(1,34,SYSDATETIME()),
(1,35,SYSDATETIME()),
(1,36,SYSDATETIME()),
(1,37,SYSDATETIME()),
(1,38,SYSDATETIME()),
(1,39,SYSDATETIME()),
(1,40,SYSDATETIME()),
(1,41,SYSDATETIME()),
(1,42,SYSDATETIME()),
(1,43,SYSDATETIME()),
(1,44,SYSDATETIME()),
(0,0,SYSDATETIME()),
(0,1,SYSDATETIME()),
(0,33,SYSDATETIME()),
(0,36,SYSDATETIME()),
(2,33,SYSDATETIME()),
(2,35,SYSDATETIME()),
(2,36,SYSDATETIME())



GO

Select 'Creo tabla Usuarios'
GO
CREATE TABLE [GESTIONAR].[usuario](
  [usua_id] [int] IDENTITY(0,1) NOT NULL,
  [usua_username] [nvarchar](255) NOT NULL,
  [usua_password] [nvarchar](255) NOT NULL,
  [usua_creado] [datetime] NULL,
  [usua_modificado] [datetime] NULL,
  [usua_habilitado] [bit] NULL,
  [usua_logins] [smallint] NULL
CONSTRAINT [PK_GESTIONAR.usuario] PRIMARY KEY CLUSTERED 
(
  [usua_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [GESTIONAR].[usuario] ADD  CONSTRAINT [DF_usuario_usua_logins]  DEFAULT ((0)) FOR [usua_logins]
GO

Select 'Creo los usuarios'

INSERT INTO [GESTIONAR].[usuario]
           ([usua_username]
           ,[usua_password]
           ,[usua_creado]
           ,[usua_modificado]
           ,[usua_habilitado])
     VALUES
           ('Agustin'
           ,'e8fd3b177583c5e1ff6d09068f75bf02a76576dca567e0e96fa3229fb4448533'
           ,SYSDATETIME()
           ,SYSDATETIME()
           ,1)
           ,('Daniel'
           ,'e8fd3b177583c5e1ff6d09068f75bf02a76576dca567e0e96fa3229fb4448533'
           ,SYSDATETIME()
           ,SYSDATETIME()
           ,1)
           ,('Martin'
           ,'e8fd3b177583c5e1ff6d09068f75bf02a76576dca567e0e96fa3229fb4448533'
           ,SYSDATETIME()
           ,SYSDATETIME()
           ,1)
           ,('Diego'
           ,'e8fd3b177583c5e1ff6d09068f75bf02a76576dca567e0e96fa3229fb4448533'
           ,SYSDATETIME()
           ,SYSDATETIME()
           ,1)
GO
Select 'Creo tabla Relacion rol usuario'
GO
CREATE TABLE [GESTIONAR].[rol_usuario](
      [rolu_id] [int] IDENTITY(0,1) NOT NULL,
      [rolu_user_id] [int] NOT NULL REFERENCES GESTIONAR.usuario (usua_id),
      [rolu_rol_id] [int] NOT NULL REFERENCES GESTIONAR.rol (rol_id),
      [rol_relacion] [int] NULL,
      [rol_relacion_sub] [int] NULL,
      [rolu_creado] [datetime] NULL
) ON [PRIMARY]

GO
Select 'Creo las relaciones entre el usuario y el rol'


  insert into [GESTIONAR].[rol_usuario]
  ([rolu_user_id],[rolu_rol_id],[rolu_creado],rol_relacion,rol_relacion_sub)
  values
  (0,1,SYSDATETIME(),null,null),
  (0,0,SYSDATETIME(),23,null),
  (1,1,SYSDATETIME(),null,null),
  (1,2,SYSDATETIME(),1,1),
  (2,0,SYSDATETIME(),13,null),
  (2,2,SYSDATETIME(),2,1),
  (3,1,SYSDATETIME(),3,null)

 
  
  
  GO
  


select 'Creo la tabla agenda'

CREATE TABLE [GESTIONAR].[agenda](
  [agen_id] [int] IDENTITY(0,1) NOT NULL ,
  [agen_profe_id] [int] NOT NULL REFERENCES GESTIONAR.profesional (prof_id),
  [agen_fecha] [date] null,
  [agen_hora_inicio] [time] null,
  [agen_hora_fin] [time] null,
  [agen_baja] [bit] NULL,
  [agen_creado] [datetime] NULL,
  [agen_modificado] [datetime] NULL,
  CONSTRAINT [PK_GESTIONAR.agenda] PRIMARY KEY CLUSTERED 
  (
    [agen_id] ASC
  )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]
GO

select 'Populo la tabla agenda'

-- insert into GESTIONAR.agenda (
-- [agen_profe_id],
-- [agen_afil_id],
-- [agend_afil_sub_id],
-- [agen_hora_inicio],
-- [agen_baja],
-- [agen_creado],
-- [agen_modificado])
-- (select p.prof_id,af.afi_id,af.afi_sub_id, m.turno_fecha,0,SYSDATETIME(),SYSDATETIME()
-- from gd_esquema.Maestra m
-- inner join GESTIONAR.afiliado af on af.afi_nro_documento = m.Paciente_Dni
-- inner join GESTIONAR.profesional p on p.prof_nro_documento=m.Medico_Dni
-- )
-- GO

INSERT INTO [GD2C2013].[GESTIONAR].[agenda]
           ([agen_profe_id]
           ,[agen_fecha]
           ,[agen_hora_inicio]
           ,[agen_hora_fin]
           ,[agen_baja]
           ,[agen_creado]
           ,[agen_modificado])
     (select p.prof_id,convert( date , m.Turno_Fecha ),min(convert( time , m.Turno_Fecha )),DATEADD(minute,30,MAX(convert( time , m.Turno_Fecha ))),case DATEPART( WEEKDAY , convert( date , m.Turno_Fecha ) )
when 7  then 1
ELSE 0 end ,SYSDATETIME(),SYSDATETIME()
from gd_esquema.Maestra m
inner join GESTIONAR.profesional p on p.prof_nro_documento=m.Medico_Dni
where DATEADD(minute,30,convert( time , m.Turno_Fecha )) < convert( time , '18:01:00')
and DATEPART( WEEKDAY , convert( date , m.Turno_Fecha ) ) <> 6
and convert( time , m.Turno_Fecha ) > convert( time , '07:59:00')
group by p.prof_id,convert( date , m.Turno_Fecha )
)
GO




Select 'Creo la tabla Turno '

CREATE TABLE [GESTIONAR].[turno](
  [turn_id] [int] IDENTITY(0,1) NOT NULL ,
  [turn_profe_id] [int] NOT NULL REFERENCES GESTIONAR.profesional (prof_id),
  [turn_afil_id] [int]  NULL ,
  [turn_afi_sub_id] [int]  NULL ,
  [turn_agen_id] [int] NOT NULL REFERENCES GESTIONAR.agenda (agen_id),
  [turn_hora_inicio] [datetime] null,
  [turn_baja] [bit] NULL,
  [turn_creado] [datetime] NULL,
  [turn_modificado] [datetime] NULL,
  foreign key (turn_afil_id,turn_afi_sub_id) references GESTIONAR.afiliado (afi_id,afi_sub_id),
  CONSTRAINT [PK_GESTIONAR.turno] PRIMARY KEY CLUSTERED 
  (
    [turn_id] ASC
  )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]
GO


SET IDENTITY_INSERT  [GD2C2013].[GESTIONAR].[turno] ON
select 'populo la tabla turno'
insert into GESTIONAR.turno (
[turn_id],
[turn_profe_id],
[turn_afil_id],
[turn_afi_sub_id],
[turn_agen_id],
[turn_hora_inicio],
[turn_baja],
[turn_creado],
[turn_modificado])
(select Turno_Numero,p.prof_id,af.afi_id,af.afi_sub_id, agen_id ,m.turno_fecha , case DATEPART( WEEKDAY , m.Turno_Fecha )
when 7  then 1
ELSE 0 end ,SYSDATETIME(),SYSDATETIME()
from gd_esquema.Maestra m
inner join GESTIONAR.afiliado af on af.afi_nro_documento = m.Paciente_Dni
inner join GESTIONAR.profesional p on p.prof_nro_documento=m.Medico_Dni
inner join GESTIONAR.agenda on agen_profe_id = p.prof_id
where consulta_sintomas is null
and consulta_enfermedades is null
and Turno_Numero is not null
and CONVERT(time, m.turno_fecha) >= agen_hora_inicio
and CONVERT(time, m.turno_fecha) <= agen_hora_fin
and CONVERT(date, m.turno_fecha) = agen_fecha
)






-- (select Turno_Numero,p.prof_id,af.afi_id,af.afi_sub_id, m.turno_fecha , case DATEPART( WEEKDAY , m.Turno_Fecha )
-- when 7  then 1
-- ELSE 0 end ,SYSDATETIME(),SYSDATETIME()
-- from gd_esquema.Maestra m
-- inner join GESTIONAR.afiliado af on af.afi_nro_documento = m.Paciente_Dni
-- inner join GESTIONAR.profesional p on p.prof_nro_documento=m.Medico_Dni
-- where consulta_sintomas is null
-- and consulta_enfermedades is null
-- and Turno_Numero is not null
-- )
SET IDENTITY_INSERT  [GD2C2013].[GESTIONAR].[turno] OFF



select 'Creo la tabla compra'

CREATE TABLE [GESTIONAR].[compra](
  [compra_id] [int] IDENTITY(384069,1) NOT NULL ,
  [compra_afi_id] [int] NOT NULL ,
  [compra_afi_sub_id] [int] NOT NULL,
  [compra_suma] [int] NULL,
  [compra_cant_farmacia] [int] NOT NULL ,
  [compra_cant_consulta] [int] NOT NULL,
  [compra_plan_id] [int] NOT NULL REFERENCES GESTIONAR.plan_medico (plan_id),
  [compra_creado] [datetime] NULL,
  [compra_modificado] [datetime] NULL,
  foreign key (compra_afi_id,compra_afi_sub_id) references GESTIONAR.afiliado (afi_id,afi_sub_id),
  CONSTRAINT [PK_GESTIONAR.compra] PRIMARY KEY CLUSTERED 
  (
    [compra_id] ASC
  )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]

GO

select 'Populo la tabla compra'

SET IDENTITY_INSERT  [GD2C2013].[GESTIONAR].[compra] ON

INSERT INTO [GD2C2013].[GESTIONAR].[compra]
           ([compra_id]
           ,[compra_afi_id]
           ,[compra_afi_sub_id]
           ,[compra_cant_farmacia]
           ,[compra_cant_consulta]
           ,[compra_plan_id]
           ,[compra_creado]
           ,[compra_modificado])
            ((select
  Bono_Consulta_Numero
      ,afi_id
      ,afi_sub_id
      ,0
      ,1
       ,afi_plan
        ,Compra_Bono_Fecha,Compra_Bono_Fecha
      from gd_esquema.Maestra,GESTIONAR.afiliado 
      where Compra_Bono_Fecha is not null
      and Bono_Consulta_Numero is not null
      and Paciente_Dni=afi_nro_documento
      group by Bono_Consulta_Numero
      ,afi_id
      ,afi_sub_id
       ,afi_plan
        ,Compra_Bono_Fecha,Compra_Bono_Fecha)
     union 
      (select
  Bono_Farmacia_Numero+200000
      ,afi_id
      ,afi_sub_id
      ,1
      ,0
       ,afi_plan
        ,Compra_Bono_Fecha,Compra_Bono_Fecha
      from gd_esquema.Maestra,GESTIONAR.afiliado 
      where Compra_Bono_Fecha is not null
      and Paciente_Dni=afi_nro_documento
      and Bono_Farmacia_Numero is not null
      group by Bono_Farmacia_Numero
      ,afi_id
      ,afi_sub_id
       ,afi_plan
        ,Compra_Bono_Fecha,Compra_Bono_Fecha)
      )

SET IDENTITY_INSERT  [GD2C2013].[GESTIONAR].[compra] OFF





      --       (select 
      -- afi_id
      -- ,afi_sub_id
      -- ,(select COUNT(*) 
      --   from gd_esquema.Maestra g2
      --   where g2.Compra_Bono_Fecha is not null 
      --   and g2.Bono_Consulta_Numero is null
      --   and g2.Paciente_Dni=g1.Paciente_Dni
      --   and g2.Compra_Bono_Fecha=g1.Compra_Bono_Fecha)
      --    ,COUNT(*)
      --    ,afi_plan
      --   ,g1.Compra_Bono_Fecha,g1.Compra_Bono_Fecha
      -- from gd_esquema.Maestra g1,GESTIONAR.afiliado 
      -- where g1.Compra_Bono_Fecha is not null
      -- and g1.Bono_Farmacia_Numero is null
      -- and g1.Paciente_Dni=afi_nro_documento
      -- group by afi_id ,afi_sub_id,afi_plan,g1.Paciente_Dni,g1.Compra_Bono_Fecha)

-- INSERT INTO [GD2C2013].[GESTIONAR].[compra]
--            ([compra_afi_id]
--            ,[compra_afi_sub_id]
--            ,[compra_cant_farmacia]
--            ,[compra_cant_consulta]
--            ,[compra_plan_id]
--            ,[compra_creado]
--            ,[compra_modificado])
--             (
-- select 
--       afi_id
--       ,afi_sub_id
--       ,COUNT(*) 
--          ,0
--          ,afi_plan
--         ,g1.Compra_Bono_Fecha,g1.Compra_Bono_Fecha
--       from gd_esquema.Maestra g1,GESTIONAR.afiliado 
--       where g1.Compra_Bono_Fecha is not null
--       and g1.Bono_Consulta_Numero is null
--       and g1.Paciente_Dni=afi_nro_documento
--      -- and not exists  (select * from GESTIONAR.compra
--      --   where compra_afi_id=afi_id
--      --   and compra_afi_sub_id=afi_sub_id
--      --   and compra_creado=Compra_Bono_Fecha)
--       group by afi_id ,afi_sub_id,afi_plan,g1.Paciente_Dni,g1.Compra_Bono_Fecha)

select 'Creo la tabla bono_consulta'

CREATE TABLE [GESTIONAR].[bono_consulta](
  [boco_id] [int] IDENTITY(181694,1) NOT NULL ,
  [boco_compra_id] [int] NULL REFERENCES GESTIONAR.compra (compra_id),
  [boco_afi_id] [int] NOT NULL ,
  [boco_afi_sub_id] [int] NOT NULL,
  [boco_plan_id] [int] NOT NULL REFERENCES GESTIONAR.plan_medico (plan_id),
  [boco_numero_consulta] [int] null,
  [boco_creado] [datetime] NULL,
  [boco_modificado] [datetime] NULL,
  foreign key (boco_afi_id,boco_afi_sub_id) references GESTIONAR.afiliado (afi_id,afi_sub_id),
  CONSTRAINT [PK_GESTIONAR.bono_consulta] PRIMARY KEY CLUSTERED 
  (
    [boco_id] ASC
  )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]

GO
select 'Populo la tabla bono_consulta'

SET IDENTITY_INSERT  [GD2C2013].[GESTIONAR].[bono_consulta] ON

INSERT INTO [GD2C2013].[GESTIONAR].[bono_consulta]
           ([boco_id]
           ,[boco_compra_id]
           ,[boco_afi_id]
           ,[boco_afi_sub_id]
           ,[boco_plan_id]
           ,[boco_numero_consulta]
           ,[boco_creado]
           ,[boco_modificado]) 
           (select Bono_Consulta_Numero,compra_id, afi_id,afi_sub_id,afi_plan,0,Compra_Bono_Fecha,Bono_Consulta_Fecha_Impresion
from gd_esquema.Maestra,GESTIONAR.compra c, GESTIONAR.afiliado
where c.compra_id=Bono_Consulta_Numero
and c.compra_creado=Compra_Bono_Fecha
and Paciente_Dni=afi_nro_documento)

SET IDENTITY_INSERT  [GD2C2013].[GESTIONAR].[bono_consulta] OFF



select 'Creo la tabla consulta'

CREATE TABLE [GESTIONAR].[consulta](
  [consul_id] [int] IDENTITY(0,1) NOT NULL ,
  [consul_sintomas] varchar(255) NULL ,
  [consul_enfermedades] varchar(255) NULL,
  [consul_turno_id] [int] NOT NULL REFERENCES GESTIONAR.turno (turn_id),
  [consul_bono_id] [int] NULL REFERENCES GESTIONAR.bono_consulta (boco_id),
  [consul_afi_id] [int] NOT NULL ,
  [consul_afi_sub_id] [int] NOT NULL,
  [consul_creado] [datetime] NULL,
  [consul_modificado] [datetime] NULL,
  foreign key (consul_afi_id,consul_afi_sub_id) references GESTIONAR.afiliado (afi_id,afi_sub_id),
  CONSTRAINT [PK_GESTIONAR.consulta] PRIMARY KEY CLUSTERED 
  (
    [consul_id] ASC
  )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]

GO



select 'Populo la tabla consulta'

INSERT INTO [GD2C2013].[GESTIONAR].[consulta]
           ([consul_sintomas]
           ,[consul_enfermedades]
           ,[consul_turno_id]
           ,[consul_bono_id]
           ,[consul_afi_id]
           ,[consul_afi_sub_id]
           ,[consul_creado]
           ,[consul_modificado])
           (select Consulta_Sintomas,Consulta_Enfermedades,Turno_Numero,Bono_Consulta_Numero,boco_afi_id,boco_afi_sub_id,Turno_Fecha,Turno_Fecha
from gd_esquema.Maestra,GESTIONAR.bono_consulta 
where boco_id=Bono_Consulta_Numero
and Consulta_Enfermedades is not null
and Consulta_Sintomas is not null)

GO



select 'Creo la tabla tipo cancelacion'

CREATE TABLE [GESTIONAR].[tipo_cancelacion](
  [tica_id] [int] IDENTITY(0,1) NOT NULL ,
  [tica_descripcion] varchar(255) NULL,
  [tica_creado] [datetime] NULL,
  [tica_modificado] [datetime] NULL,
  CONSTRAINT [PK_GESTIONAR.tipo_cancelacion] PRIMARY KEY CLUSTERED 
  (
    [tica_id] ASC
  )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]

GO

select 'Populo la tabla tipo_cancelacion'

insert into [GD2C2013].[GESTIONAR].[tipo_cancelacion](
    [tica_descripcion]
    ,[tica_creado]
    ,[tica_modificado])
  values
  ('Migracion',SYSDATETIME(),SYSDATETIME()),
  ('Afiliado',SYSDATETIME(),SYSDATETIME()),
  ('Profesional',SYSDATETIME(),SYSDATETIME())



select 'Creo la tabla cancelacion'

CREATE TABLE [GESTIONAR].[cancelacion](
  [cancel_id] [int] IDENTITY(0,1) NOT NULL ,
  [cancel_tipo] [int] NOT NULL REFERENCES GESTIONAR.tipo_cancelacion (tica_id),
  [cancel_descripcion] varchar(255) NULL,
  [cancel_turno_id] [int] NOT NULL REFERENCES GESTIONAR.turno (turn_id),
  [cancel_afil_id] [int] NULL,
  [cancel_afil_sub_id] [int] NULL,
  [cancel_creado] [datetime] NULL,
  [cancel_modificado] [datetime] NULL,
  CONSTRAINT [PK_GESTIONAR.cancelacion] PRIMARY KEY CLUSTERED 
  (
    [cancel_id] ASC
  )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]

GO


Select 'Populo la tabla cancelacion'


INSERT INTO [GD2C2013].[GESTIONAR].[cancelacion]
           ([cancel_tipo]
           ,[cancel_descripcion]
           ,[cancel_turno_id]
           ,[cancel_afil_id]
           ,[cancel_afil_sub_id]
           ,[cancel_creado]
           ,[cancel_modificado])
     (select 0,'Turnos borrados en la migracion',turn_id,turn_afil_id,turn_afi_sub_id,SYSDATETIME(),SYSDATETIME() from GESTIONAR.turno where turn_baja=1)
GO



select 'Creo la tabla bono_farmacia'

CREATE TABLE [GESTIONAR].[bono_farmacia](
  [bofa_id] [int] IDENTITY(0,1) NOT NULL ,
  [bofa_compra_id] [int]  NULL REFERENCES GESTIONAR.compra (compra_id),
  [bofa_afi_id] [int] NOT NULL ,
  [bofa_afi_sub_id] [int] NOT NULL,
  [bofa_consulta_id] [int] NULL REFERENCES GESTIONAR.consulta (consul_id),
  [bofa_plan_id] [int] NOT NULL REFERENCES GESTIONAR.plan_medico (plan_id),
  [bofa_creado] [datetime] NULL,
  [bofa_modificado] [datetime] NULL,
  foreign key (bofa_afi_id,bofa_afi_sub_id) references GESTIONAR.afiliado (afi_id,afi_sub_id),
  CONSTRAINT [PK_GESTIONAR.bono_farmacia] PRIMARY KEY CLUSTERED 
  (
    [bofa_id] ASC
  )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]

GO


select 'Populo la tabla bono_farmacia'

SET IDENTITY_INSERT  [GD2C2013].[GESTIONAR].[bono_farmacia] ON

INSERT INTO [GD2C2013].[GESTIONAR].[bono_farmacia]
           ([bofa_id]
           ,[bofa_compra_id]
           ,[bofa_afi_id]
           ,[bofa_afi_sub_id]
           ,[bofa_consulta_id]
           ,[bofa_plan_id]
           ,[bofa_creado]
           ,[bofa_modificado])
           (select Bono_Farmacia_Numero,(Bono_Farmacia_Numero+200000), afi_id,afi_sub_id,consul_id,afi_plan,Bono_Farmacia_Fecha_Impresion,Bono_Farmacia_Fecha_Impresion
from gd_esquema.Maestra,GESTIONAR.afiliado,GESTIONAR.consulta
where Bono_Farmacia_Numero is not null
and Bono_Consulta_Numero is not null
and afi_nro_documento=Paciente_Dni
and consul_bono_id=Bono_Consulta_Numero)

--           (select Bono_Farmacia_Numero,(Bono_Farmacia_Numero+200000), afi_id,afi_sub_id,Bono_Consulta_Numero,afi_plan,Bono_Farmacia_Fecha_Impresion, SYSDATETIME()
--from gd_esquema.Maestra,GESTIONAR.afiliado
--where Bono_Farmacia_Numero is not null
--and Bono_Consulta_Numero is not null
--and afi_nro_documento=Paciente_Dni)
           

SET IDENTITY_INSERT  [GD2C2013].[GESTIONAR].[bono_farmacia] OFF

GO


select 'Creo la tabla medicamento'

CREATE TABLE [GESTIONAR].[medicamento](
  [medic_id] [int] IDENTITY(0,1) NOT NULL ,
  [medic_descripcion] varchar(264) ,
  [medic_creado] [datetime] NULL,
  [medic_modificado] [datetime] NULL,
  CONSTRAINT [PK_GESTIONAR.medicamento] PRIMARY KEY CLUSTERED 
  (
    [medic_id] ASC
  )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]

GO
select 'Populo la tabla medicamento'

INSERT INTO [GD2C2013].[GESTIONAR].[medicamento]
           ([medic_descripcion]
           ,[medic_creado]
           ,[medic_modificado])
     select distinct(Bono_Farmacia_Medicamento),SYSDATETIME(),SYSDATETIME() from gd_esquema.Maestra
where Bono_Farmacia_Fecha_Impresion is not null
and Bono_Farmacia_Medicamento is not null

select 'Creo la tabla medicamento_bono'


CREATE TABLE [GESTIONAR].[medicamento_bono](
  [mebo_id] [int] IDENTITY(0,1) NOT NULL ,
  [mebo_bofa_id] [int] NOT NULL REFERENCES GESTIONAR.bono_farmacia (bofa_id),
  [mebo_medic_id] [int] NOT NULL REFERENCES GESTIONAR.medicamento (medic_id),
  [mebo_cant] [int] NOT NULL ,
  [mebo_creado] [datetime] NULL,
  [mebo_modificado] [datetime] NULL,
  CONSTRAINT [PK_GESTIONAR.medicamento_bono] PRIMARY KEY CLUSTERED 
  (
    [mebo_id] ASC
  )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]

GO
select 'Populo la tabla medicamento_bono'

INSERT INTO [GD2C2013].[GESTIONAR].[medicamento_bono]
           ([mebo_bofa_id]
           ,[mebo_medic_id]
           ,[mebo_cant]
           ,[mebo_creado]
           ,[mebo_modificado])
           (select Bono_Farmacia_Numero,medic_id,COUNT(*),SYSDATETIME(),SYSDATETIME() from gd_esquema.Maestra,GESTIONAR.bono_farmacia,GESTIONAR.medicamento
where Bono_Farmacia_Numero=bofa_id
and Bono_Farmacia_Medicamento=medic_descripcion
group by Bono_Farmacia_Numero,medic_id)








GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:    <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE TRIGGER GESTIONAR.afilado_tracker 
   ON  GESTIONAR.afiliado 
   AFTER UPDATE
AS 
BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON;

    -- Insert statements for trigger here

    insert into Hist_Plan_Afiliado (hist_fecha,hist_afi_id,hist_afi_sub_id,hist_plan_id)
   select SYSDATETIME(),d.afi_id,d.afi_sub_id,d.afi_plan  from deleted d
   left join inserted i on d.afi_id=i.afi_id and d.afi_sub_id = i.afi_sub_id
   where i.afi_plan <> d.afi_plan

END
GO


--PROCEDURES
GO
CREATE PROCEDURE GESTIONAR.AfiliadoUpdate 
    @mainid int,
    @subid int,
    @nombre varchar(255),
    @apellido varchar(255),
    @doc numeric(18,0),
    @dire varchar(255),
    @tipo varchar(3),
    @telefono numeric(18,0),
    @mail varchar(255),
    @fecNac datetime,
    @sexo char(1),
    @creado datetime,
    @estado int,
    @hijos int,
    @plan numeric(18,0),
	@modificado datetime
    
AS 

    SET NOCOUNT ON;
   
    UPDATE GESTIONAR.afiliado
    SET afi_nombre = @nombre,
     afi_apellido = @apellido,
     afi_nro_documento=@doc,
     afi_direccion=@dire,
     afi_tipo_documento=@tipo,
     afi_telefono=@telefono,
     afi_mail=@mail,
     afi_fecha_nacimiento=@fecNac,
     afi_sexo=@sexo,
     afi_modificado=@modificado,
     afi_estado_id = @estado,
     afi_cant_hijos = @hijos,
     afi_plan = @plan
     WHERE afi_id = @mainid and afi_sub_id=@subid
		
		
GO

CREATE PROCEDURE GESTIONAR.AfiliadoBaja 
    @mainid int,
    @subid int,
	@modificado datetime
    
AS 

    SET NOCOUNT ON;
   
    UPDATE GESTIONAR.afiliado
    SET afi_baja = 1,
    afi_modificado=@modificado
    WHERE afi_id = @mainid and afi_sub_id=@subid
		
		
GO

CREATE PROCEDURE GESTIONAR.ProfesionalBaja 
    @profid int,
	@modificado datetime
    
AS 

    SET NOCOUNT ON;
   
    UPDATE GESTIONAR.profesional
    SET prof_baja = 1,
    prof_modificado=@modificado
    WHERE prof_id = @profid
		
		
GO


CREATE PROCEDURE GESTIONAR.AfiliadoGrupoInsert 
    @mainid int,
    @subid int,
    @nombre varchar(255),
    @apellido varchar(255),
    @doc numeric(18,0),
    @dire varchar(255),
    @tipo varchar(3),
    @telefono numeric(18,0),
    @mail varchar(255),
    @fecNac datetime,
    @sexo char(1),
    @creado datetime,
    @modificado datetime,
    @estado int,
    @hijos int,
    @plan numeric(18,0),
    @baja bit
    
AS 

    SET NOCOUNT ON;
    SET IDENTITY_INSERT  [GD2C2013].[GESTIONAR].[afiliado] ON
    
    INSERT INTO GESTIONAR.afiliado(afi_id,afi_sub_id,afi_nombre, afi_apellido, afi_nro_documento,afi_direccion,afi_tipo_documento,afi_telefono,afi_mail,afi_fecha_nacimiento,afi_sexo,afi_creado,afi_modificado,afi_estado_id,afi_cant_hijos,afi_plan,afi_baja)
		VALUES(@mainid,@subid,@nombre,@apellido, @doc,@dire,@tipo,@telefono,@mail,@fecNac,@sexo,@creado,@modificado,@estado,@hijos,@plan,@baja)
		
		SET IDENTITY_INSERT  [GD2C2013].[GESTIONAR].[plan_medico] OFF
GO


create procedure GESTIONAR.generar_agenda (@fecha_desde date ,@fecha_hasta date, @hora_desde time, @hora_hasta time ,@profesional int,@modificado datetime)
as
SET NOCOUNT ON
begin
declare @fecha date
declare @hora time
declare @agenda int

set @fecha=@fecha_desde
while DATEDIFF(day,@fecha,@fecha_hasta) > 0
  begin
  INSERT INTO [GD2C2013].[GESTIONAR].[agenda]
           ([agen_profe_id]
           ,[agen_fecha]
           ,[agen_hora_inicio]
           ,[agen_hora_fin]
           ,[agen_baja]
           ,[agen_creado]
           ,[agen_modificado])
  values(@profesional,@fecha,@hora_desde,@hora_hasta,0,@modificado,@modificado);
  
  set @agenda = @@IDENTITY

  set @hora=@hora_desde
  while DATEDIFF(minute,@hora,@hora_hasta) > 29
    begin
    insert into GESTIONAR.turno (turn_profe_id,turn_hora_inicio,turn_baja,turn_creado,turn_modificado,turn_agen_id)
    values
    (@profesional,@fecha+CONVERT(datetime, @hora),0,@modificado,@modificado,@agenda)
    
    set @hora = DATEADD(minute,30,@hora)
    select @hora, DATEDIFF(minute,@hora,@hora_hasta)
    end
    set @fecha = DATEADD(week,1,@fecha)
    select @fecha
  end
end
go


-- CREATE TRIGGER GESTIONAR.rol_func_checker 
--    ON  GESTIONAR.rol_funcionalidad
--    instead of  INSERT
-- AS 
-- BEGIN
--   -- SET NOCOUNT ON added to prevent extra result sets from
--   -- interfering with SELECT statements.
--   SET NOCOUNT ON;

--     -- Insert statements for trigger here
--     declare @rol int, @func int , @creado datetime
--     declare cur_inserted cursor for select * from inserted;

-- open cur_inserted

-- fetch next from cur_inserted into @rol,@func,@creado

-- WHILE @@FETCH_STATUS = 0
-- BEGIN
--   if not exists ( select * from GESTIONAR.rol_funcionalidad where rolf_rol_id = @rol
--   and rolf_func_id = @func)
--   BEGIN
--     insert into [GESTIONAR].[rol_funcionalidad]
--       ([rolf_rol_id],[rolf_func_id],[rolf_creado])
--     values
--            (@rol,@func,@creado);
    
--      end
     
--      fetch next from cur_inserted into @rol,@func,@creado
     
-- end

-- close  cur_inserted

-- deallocate cur_inserted


-- END

-- go


create procedure [GESTIONAR].[estadisticas] (@semestre bit,@anio int,@informe int, @fecha datetime)
as 
begin
if @informe = 1
  begin 
    select DATEPART(MONTH, t.turn_hora_inicio) as 'Mes' ,e.Espe_Descripcion , COUNT(*)
    from 
      GESTIONAR.profesional_especialidad pe
      ,GESTIONAR.Especialidad e
      ,GESTIONAR.turno t
      ,GESTIONAR.cancelacion ca
    where 
      cancel_turno_id=turn_id
      and turn_profe_id=espr_prof_id
      and espr_especialidad_id=espe_Codigo
      and (DATEPART(YEAR, t.turn_hora_inicio)) = @anio  and ((datepart(MONTH, t.turn_hora_inicio) in (1, 2, 3, 4, 5, 6)  and @semestre = 0 ) or (datepart(MONTH, t.turn_hora_inicio) in (7, 8, 9, 10, 11, 12) and @semestre = 1 ))
      and espe_Codigo in (select  top 5 espr_especialidad_id
    from 
      GESTIONAR.profesional_especialidad pe
      ,GESTIONAR.turno t
      ,GESTIONAR.cancelacion ca
    where 
      cancel_turno_id=turn_id
      and turn_profe_id=espr_prof_id
      and (DATEPART(YEAR, t.turn_hora_inicio)) = @anio  and ((datepart(MONTH, t.turn_hora_inicio) in (1, 2, 3, 4, 5, 6)  and @semestre = 0 ) or (datepart(MONTH, t.turn_hora_inicio) in (7, 8, 9, 10, 11, 12) and @semestre = 1 ))
    group by espr_especialidad_id
    order by COUNT(*) desc)
    group by Espe_Descripcion, DATEPART(MONTH, t.turn_hora_inicio)
    order by COUNT(*) desc
end
else
  if @informe = 2
  begin
    select DATEPART(MONTH, bofa_creado) as 'Mes comprado', DATEPART(MONTH, DATEADD(DAY,60,bofa_creado)) as 'Mes Vencido',afi_apellido+' '+afi_nombre, count(bf.bofa_id) as 'Cantidad'
    from GESTIONAR.afiliado a
    , GESTIONAR.bono_farmacia bf
    where 
      a.afi_id = bf.bofa_afi_id 
      and DATEDIFF(D,bf.bofa_creado,@fecha) > 60 
      and bf.bofa_consulta_id is null
      and DATEPART(YEAR, DATEADD(DAY,60,bofa_creado)) = @anio  and ((datepart(MONTH, DATEADD(DAY,60,bofa_creado)) in (1, 2, 3, 4, 5, 6)  and @semestre = 0 ) or (datepart(MONTH, DATEADD(DAY,60,bofa_creado)) in (7, 8, 9, 10, 11, 12) and @semestre = 1 ))
      and (afi_id*10+afi_sub_id) in (select top 5 afi_id*10+afi_sub_id
    from GESTIONAR.afiliado a
    , GESTIONAR.bono_farmacia bf
    where 
      a.afi_id = bf.bofa_afi_id 
      and DATEDIFF(D,bf.bofa_creado,@fecha) > 60 
      and bf.bofa_consulta_id is null
      and DATEPART(YEAR, DATEADD(DAY,60,bofa_creado)) = @anio  and ((datepart(MONTH, DATEADD(DAY,60,bofa_creado)) in (1, 2, 3, 4, 5, 6)  and @semestre = 0 ) or (datepart(MONTH, DATEADD(DAY,60,bofa_creado)) in (7, 8, 9, 10, 11, 12) and @semestre = 1 ))
    group by afi_id*10+afi_sub_id
    order by COUNT(*) desc)
    group by afi_apellido+' '+afi_nombre, DATEPART(MONTH, DATEADD(DAY,60,bofa_creado)),DATEPART(MONTH, bofa_creado)
    order by COUNT(*) desc
  end
  else
    if @informe = 3
    begin
      select DATEPART(MONTH, consul_modificado),e.Espe_Descripcion, COUNT(*) 
      from 
        GESTIONAR.bono_farmacia bf
        , GESTIONAR.profesional_especialidad pe
        , GESTIONAR.Especialidad e
        , GESTIONAR.turno t
        ,GESTIONAR.consulta
      where 
        bofa_consulta_id = consul_id
        and consul_turno_id=turn_id
        and turn_profe_id=espr_prof_id
        and espr_especialidad_id=espe_Codigo
        and espe_Codigo in (select top 5 espr_especialidad_id
      from 
        GESTIONAR.bono_farmacia bf
        , GESTIONAR.profesional_especialidad pe
        , GESTIONAR.turno t
        ,GESTIONAR.consulta
      where 
        bofa_consulta_id = consul_id
        and consul_turno_id=turn_id
        and turn_profe_id=espr_prof_id
        and DATEPART(YEAR, consul_modificado) = @anio and ((datepart(MONTH, consul_modificado) in (1, 2, 3, 4, 5, 6) and @semestre = 0 ) or (datepart(MONTH, consul_modificado) in (7, 8, 9, 10, 11, 12) and @semestre = 1 ))
      group by espr_especialidad_id
      order by COUNT(*) desc)
        and DATEPART(YEAR, consul_modificado) = @anio and ((datepart(MONTH, consul_modificado) in (1, 2, 3, 4, 5, 6) and @semestre = 0 ) or (datepart(MONTH, consul_modificado) in (7, 8, 9, 10, 11, 12) and @semestre = 1 ))
      group by e.Espe_Descripcion, DATEPART(MONTH, consul_modificado)
      order by COUNT(*) desc
    end
    else
      select afi_nombre+' '+afi_apellido,DATEPART(MONTH, boco_modificado),COUNT(*) from GESTIONAR.afiliado,
GESTIONAR.compra cp
  , GESTIONAR.bono_consulta bc
where 
compra_afi_id=boco_afi_id
  and compra_afi_sub_id != boco_afi_sub_id
and boco_numero_consulta is not null
and boco_afi_id = afi_id
and boco_afi_sub_id=afi_sub_id
and DATEPART(YEAR, boco_modificado) = @anio and ((datepart(MONTH, boco_modificado) in (1, 2, 3, 4, 5, 6) and @semestre = 0 ) or (datepart(MONTH, boco_modificado) in (7, 8, 9, 10, 11, 12) and @semestre = 1 ))
and (afi_id*10+afi_sub_id) in (
select top 10 boco_afi_id*10+boco_afi_sub_id as 'afiliado'
from 
   GESTIONAR.compra cp
  , GESTIONAR.bono_consulta bc
where 
  compra_afi_id=boco_afi_id
  and compra_afi_sub_id != boco_afi_sub_id
and boco_numero_consulta is not null
and DATEPART(YEAR, boco_modificado) = @anio and ((datepart(MONTH, boco_modificado) in (1, 2, 3, 4, 5, 6) and @semestre = 0 ) or (datepart(MONTH, boco_modificado) in (7, 8, 9, 10, 11, 12) and @semestre = 1 ))
group by boco_afi_id*10+boco_afi_sub_id
order by count(boco_numero_consulta) desc)
group by afi_nombre+' '+afi_apellido,DATEPART(MONTH, boco_modificado)
order by count(boco_numero_consulta) desc

end 
GO

CREATE PROCEDURE GESTIONAR.CancelarTurnoAfil 
    @turnoID int,
	@motivo varchar(255),
    @fecha DateTime
AS 

    SET NOCOUNT ON;
   
	Declare @AFIID int;
	Declare @SUBID int;
   
	SET @AFIID = (select turn_afil_id from GESTIONAR.turno WHERE turn_id = @turnoID)
   	SET @SUBID = (select turn_afi_sub_id from GESTIONAR.turno WHERE turn_id = @turnoID)
   	
	INSERT INTO [GD2C2013].[GESTIONAR].[cancelacion] (cancel_tipo,cancel_descripcion,cancel_turno_id,cancel_afil_id,cancel_afil_sub_id,cancel_creado)
	VALUES (1,@motivo,@turnoID,@AFIID,@SUBID,@fecha)
   
   
    UPDATE GESTIONAR.turno
    SET turn_afil_id = NULL , turn_afi_sub_id = NULL
    WHERE turn_id = @turnoID
		
		
GO


CREATE PROCEDURE GESTIONAR.CancelarTurnoProf 
	@profID int,
    @desde Date,
	@hasta Date,
	@motivo varchar(255),
	@fecha DateTime
    
AS 

    SET NOCOUNT ON;
   
      INSERT INTO [GD2C2013].[GESTIONAR].[cancelacion]
           (cancel_tipo,cancel_descripcion,cancel_turno_id,cancel_afil_id,cancel_afil_sub_id,cancel_creado)
           (select 2,@motivo, turn_id,turn_afil_id,turn_afi_sub_id,@fecha
from GESTIONAR.turno 
where turn_profe_id = @profID and CAST(turn_hora_inicio AS DATE) >= @desde and CAST(turn_hora_inicio AS DATE)  <= @hasta)
   
   
   
    UPDATE GESTIONAR.turno
    SET turn_baja = 1
    WHERE turn_profe_id = @profID and CAST(turn_hora_inicio AS DATE) >= @desde and CAST(turn_hora_inicio AS DATE)  <= @hasta
		
		
GO