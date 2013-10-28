USE [GD2C2013]
GO

Select 'Creo el esquema'

GO

CREATE SCHEMA [GESTIONAR] AUTHORIZATION [gd]
GO

CREATE TABLE [GESTIONAR].[estado_civil](
    esta_id [int] IDENTITY(1,1) NOT NULL,
    esta_nombre [varchar](30) NULL,
    esta_creado [datetime] NULL,
    esta_modificado [datetime] NULL
  CONSTRAINT [PK_GESTIONAR.estado] PRIMARY KEY CLUSTERED 
  (
    [esta_id] ASC
  )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]
  GO

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



select 'creo tabla afiliado'

GO

CREATE TABLE [GESTIONAR].[afiliado](
    afi_id [int] IDENTITY(1,1) NOT NULL,
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
    afi_plan [numeric](18, 0) NULL,
    afi_baja [bit] NULL,
    afi_creado [datetime] NULL,
    afi_modificado [datetime] NULL
  CONSTRAINT [PK_GESTIONAR.afiliado] PRIMARY KEY CLUSTERED 
  (
    [afi_id] ASC
  )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]
  GO

CREATE TABLE [GESTIONAR].[Hist_Plan_Afiliado](
    hist_id [int] IDENTITY(1,1) NOT NULL,
    hist_fecha [datetime] NOT NULL,
    hist_afi_id [int] NOT NULL REFERENCES GESTIONAR.afiliado (afi_id),
    hist_motivo [varchar] (255) NOT NULL
  CONSTRAINT [PK_GESTIONAR.Hist_Plan_Afiliado] PRIMARY KEY CLUSTERED 
  (
    [hist_id] ASC
  )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]
  GO

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


CREATE TABLE [GESTIONAR].[profesional](
    prof_id [int] IDENTITY(1,1) NOT NULL,
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
    prof_modificado[datetime] NULL
  CONSTRAINT [PK_GESTIONAR.profesional] PRIMARY KEY CLUSTERED 
  (
    [prof_id] ASC
  )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]

  GO



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
    prof_modificado)
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

CREATE TABLE [GESTIONAR].[Tipo_Especialidad](
  [tipoe_Codigo] [int] IDENTITY(10049,1) NOT NULL ,
  [tipoe_Descripcion] [varchar](255) NULL,
  tipoe_creado [datetime] NULL,
  tipoe_modificado [datetime] NULL
CONSTRAINT [PK_GESTIONAR.Tipo_Especialidad] PRIMARY KEY CLUSTERED 
  (
    [tipoe_codigo] ASC
  )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]
GO

SET IDENTITY_INSERT  [GD2C2013].[GESTIONAR].[Tipo_Especialidad] ON
GO
INSERT INTO [GD2C2013].[GESTIONAR].[Tipo_Especialidad]
           (tipoe_Codigo
           ,[tipoe_Descripcion]
           ,[tipoe_creado]
           ,[tipoe_modificado])
     (select Tipo_Especialidad_Codigo,Tipo_Especialidad_Descripcion 
     ,SYSDATETIME()
       ,SYSDATETIME()
     from gd_esquema.Maestra
     where Tipo_Especialidad_Codigo is not null
group by Tipo_Especialidad_Codigo,Tipo_Especialidad_Descripcion)

GO

SET IDENTITY_INSERT  [GD2C2013].[GESTIONAR].[Tipo_Especialidad] OFF
GO


CREATE TABLE [GESTIONAR].[Especialidad](
  [Espe_Codigo] [int] IDENTITY(10049,1) NOT NULL ,
  [Espe_Descripcion] [varchar](255) NULL,
  espe_tipo_id [int] NOT NULL REFERENCES GESTIONAR.Tipo_Especialidad (tipoe_codigo),
  Espe_creado [datetime] NULL,
  Espe_modificado[datetime] NULL
CONSTRAINT [PK_GESTIONAR.Especialidad] PRIMARY KEY CLUSTERED 
  (
    [Espe_Codigo] ASC
  )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]
  GO

SET IDENTITY_INSERT  [GD2C2013].[GESTIONAR].[Especialidad] ON
GO
  INSERT INTO [GD2C2013].[GESTIONAR].[Especialidad]
           ([Espe_Codigo]
           ,[Espe_Descripcion]
           ,espe_tipo_id
           ,[Espe_creado]
           ,[Espe_modificado])
     (select especialidad_codigo,Especialidad_Descripcion,Tipo_Especialidad_Codigo
      ,SYSDATETIME()
       ,SYSDATETIME()
      from gd_esquema.Maestra
where Especialidad_Codigo is not null
group by especialidad_codigo,Especialidad_Descripcion,Tipo_Especialidad_Codigo)

GO
SET IDENTITY_INSERT  [GD2C2013].[GESTIONAR].[Especialidad] OFF
GO



CREATE TABLE [GESTIONAR].[profesional_especialidad](
  [espr_Codigo] [int] IDENTITY(10049,1) NOT NULL ,
  [espr_prof_id] [int] NOT NULL REFERENCES GESTIONAR.profesional (prof_id),
  [espr_especialidad_id] [int] NOT NULL REFERENCES GESTIONAR.Especialidad (Espe_Codigo),
  [espr_creado] [datetime] NULL,
  [espr_modificado] [datetime] NULL
CONSTRAINT [PK_GESTIONAR.prof_Especialidad] PRIMARY KEY CLUSTERED 
  (
    [espr_Codigo] ASC
  )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]
  GO

Select 'Creo tabla funcionalidad'
GO
CREATE TABLE [GESTIONAR].[funcionalidad](
      [func_id] [int] IDENTITY(1,1) NOT NULL,
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
('crear_recorrido',SYSDATETIME(),SYSDATETIME()) ,
('listar_recorrido',SYSDATETIME(),SYSDATETIME()) ,
('modificar_recorrido',SYSDATETIME(),SYSDATETIME()), 
('crear_ciudad',SYSDATETIME(),SYSDATETIME()) ,
('listar_ciudad',SYSDATETIME(),SYSDATETIME()) ,
('modificar_ciudad',SYSDATETIME(),SYSDATETIME()), 
('crear_micro',SYSDATETIME(),SYSDATETIME()) ,
('listar_micro',SYSDATETIME(),SYSDATETIME()) ,
('modificar_micro',SYSDATETIME(),SYSDATETIME()), 
('registrar_llegada',SYSDATETIME(),SYSDATETIME()), 
('crear_viaje',SYSDATETIME(),SYSDATETIME()) ,
('modificar_viaje',SYSDATETIME(),SYSDATETIME()), 
('listar_viaje',SYSDATETIME(),SYSDATETIME()) ,
('pasaje_generar',SYSDATETIME(),SYSDATETIME()), 
('pasaje_anular',SYSDATETIME(),SYSDATETIME()) ,
('consulta_puntos',SYSDATETIME(),SYSDATETIME()), 
('listar_roles',SYSDATETIME(),SYSDATETIME()) ,
('listar_funcionalidades',SYSDATETIME(),SYSDATETIME()) ,
('modificar_usuario',SYSDATETIME(),SYSDATETIME()) ,
('Ciudad',SYSDATETIME(),SYSDATETIME()) ,
('Recorrido',SYSDATETIME(),SYSDATETIME()), 
('Micros',SYSDATETIME(),SYSDATETIME()) ,
('Viaje',SYSDATETIME(),SYSDATETIME()), 
('Pasaje',SYSDATETIME(),SYSDATETIME()) ,
('Puntos',SYSDATETIME(),SYSDATETIME()), 
('Usuarios',SYSDATETIME(),SYSDATETIME()) ,
('Estadisticas',SYSDATETIME(),SYSDATETIME()),
('pasajesXDestino',SYSDATETIME(),SYSDATETIME()),
('destinosConMicrosMasVacios',SYSDATETIME(),SYSDATETIME()),
('clientesConMasPuntosAcumuladosALaFecha',SYSDATETIME(),SYSDATETIME()),
('destinosConPasajesCancelados',SYSDATETIME(),SYSDATETIME()),
('microsConMayorCantidadDeDiasFueraDeServicio',SYSDATETIME(),SYSDATETIME())

GO
Select 'Creo tabla Rol'

GO

CREATE TABLE [GESTIONAR].[Rol](
      [rol_id] [int] IDENTITY(1,1) NOT NULL,
      [rol_nombre] [nvarchar](255) NULL,
      [rol_creado] [datetime] NULL,
      [rol_modificado] [datetime] NULL,
      [rol_borrado] [bit] NULL
      CONSTRAINT [PK_GESTIONAR.Rol] PRIMARY KEY CLUSTERED 
(
  [rol_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
Select 'Creo los Roles'
GO
insert into GESTIONAR.Rol (rol_nombre,rol_creado,rol_modificado,rol_borrado)
values
('FULL_ACCESS',SYSDATETIME(),SYSDATETIME(),0),
('Administrativo',SYSDATETIME(),SYSDATETIME(),0)

GO
Select 'Creo tabla rol funcionalidad'
GO
CREATE TABLE [GESTIONAR].[Rol_funcionalidad](
      [rolf_id] [int] IDENTITY(1,1) NOT NULL,
      [rolf_rol_id] [int] NOT NULL REFERENCES GESTIONAR.rol (rol_id),
      [rolf_func_id] [int] NOT NULL REFERENCES GESTIONAR.funcionalidad (func_id),
      [rolf_creado] [datetime] NULL,
      [rolf_modificado] [datetime] NULL
CONSTRAINT [PK_GESTIONAR.Rol_funcionalidad] PRIMARY KEY CLUSTERED 
(
  [rolf_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

Select 'Creo la relacion entre el rol y la funcionalidad'
GO

insert into [GESTIONAR].[Rol_funcionalidad]
 ([rolf_rol_id],[rolf_func_id],[rolf_creado],[rolf_modificado])
 values
(1,1,SYSDATETIME(),SYSDATETIME()),
(1,2,SYSDATETIME(),SYSDATETIME()),
(1,3,SYSDATETIME(),SYSDATETIME()),
(1,4,SYSDATETIME(),SYSDATETIME()),
(1,5,SYSDATETIME(),SYSDATETIME()),
(1,6,SYSDATETIME(),SYSDATETIME()),
(1,7,SYSDATETIME(),SYSDATETIME()),
(1,8,SYSDATETIME(),SYSDATETIME()),
(1,9,SYSDATETIME(),SYSDATETIME()),
(1,10,SYSDATETIME(),SYSDATETIME()),
(1,11,SYSDATETIME(),SYSDATETIME()),
(1,12,SYSDATETIME(),SYSDATETIME()),
(1,13,SYSDATETIME(),SYSDATETIME()),
(1,14,SYSDATETIME(),SYSDATETIME()),
(1,15,SYSDATETIME(),SYSDATETIME()),
(1,16,SYSDATETIME(),SYSDATETIME()),
(1,17,SYSDATETIME(),SYSDATETIME()),
(1,18,SYSDATETIME(),SYSDATETIME()),
(1,19,SYSDATETIME(),SYSDATETIME()),
(1,20,SYSDATETIME(),SYSDATETIME()),
(1,21,SYSDATETIME(),SYSDATETIME()),
(1,22,SYSDATETIME(),SYSDATETIME()),
(1,23,SYSDATETIME(),SYSDATETIME()),
(1,24,SYSDATETIME(),SYSDATETIME()),
(1,25,SYSDATETIME(),SYSDATETIME()),
(1,26,SYSDATETIME(),SYSDATETIME()),
(1,27,SYSDATETIME(),SYSDATETIME()),
(1,28,SYSDATETIME(),SYSDATETIME()),
(1,29,SYSDATETIME(),SYSDATETIME()),
(1,30,SYSDATETIME(),SYSDATETIME()),
(1,31,SYSDATETIME(),SYSDATETIME()),
(1,32,SYSDATETIME(),SYSDATETIME()),
(2,2,SYSDATETIME(),SYSDATETIME()),
(2,5,SYSDATETIME(),SYSDATETIME()),
(2,8,SYSDATETIME(),SYSDATETIME()),
(2,10,SYSDATETIME(),SYSDATETIME()),
(2,13,SYSDATETIME(),SYSDATETIME()),
(2,14,SYSDATETIME(),SYSDATETIME()),
(2,15,SYSDATETIME(),SYSDATETIME()),
(2,16,SYSDATETIME(),SYSDATETIME()),
(2,20,SYSDATETIME(),SYSDATETIME()),
(2,21,SYSDATETIME(),SYSDATETIME()),
(2,22,SYSDATETIME(),SYSDATETIME()),
(2,23,SYSDATETIME(),SYSDATETIME()),
(2,24,SYSDATETIME(),SYSDATETIME()),
(2,25,SYSDATETIME(),SYSDATETIME()),
(2,26,SYSDATETIME(),SYSDATETIME())


GO

Select 'Creo tabla Usuarios'
GO
CREATE TABLE [GESTIONAR].[usuario](
  [usua_id] [int] IDENTITY(1,1) NOT NULL,
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
GO
INSERT INTO [GESTIONAR].[usuario]
           ([usua_username]
           ,[usua_password]
           ,[usua_creado]
           ,[usua_modificado]
           ,[usua_habilitado])
     VALUES
           ('Administrador'
           ,'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7'
           ,SYSDATETIME()
           ,SYSDATETIME()
           ,1)
           ,('Admin'
           ,'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7'
           ,SYSDATETIME()
           ,SYSDATETIME()
           ,1)
           ,('Agustin'
           ,'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7'
           ,SYSDATETIME()
           ,SYSDATETIME()
           ,1)
           ,('Daniel'
           ,'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7'
           ,SYSDATETIME()
           ,SYSDATETIME()
           ,1)
           ,('Martin'
           ,'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7'
           ,SYSDATETIME()
           ,SYSDATETIME()
           ,1)
           ,('Diego'
           ,'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7'
           ,SYSDATETIME()
           ,SYSDATETIME()
           ,1)
GO
Select 'Creo tabla Relacion rol usuario'
GO
CREATE TABLE [GESTIONAR].[rol_usuario](
      [rolu_id] [int] IDENTITY(1,1) NOT NULL,
      [rolu_user_id] [int] NOT NULL REFERENCES GESTIONAR.usuario (usua_id),
      [rolu_rol_id] [int] NOT NULL REFERENCES GESTIONAR.rol (rol_id),
      [rolu_creado] [datetime] NULL,
      [rolu_modificado] [datetime] NULL
) ON [PRIMARY]

GO
Select 'Creo las relaciones entre el usuario y el rol'
GO

  insert into [GESTIONAR].[rol_usuario]
  ([rolu_user_id],[rolu_rol_id],[rolu_creado],[rolu_modificado])
  values
  (1,1,SYSDATETIME(),SYSDATETIME()),
  (2,1,SYSDATETIME(),SYSDATETIME()),
  (3,2,SYSDATETIME(),SYSDATETIME()),
  (4,2,SYSDATETIME(),SYSDATETIME()),
  (5,2,SYSDATETIME(),SYSDATETIME()),
  (6,2,SYSDATETIME(),SYSDATETIME())
  
  GO

CREATE TABLE [GESTIONAR].[Plan](
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

SET IDENTITY_INSERT  [GD2C2013].[GESTIONAR].[Plan] ON

GO

insert into [GESTIONAR].[Plan](
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

GO

SET IDENTITY_INSERT  [GD2C2013].[GESTIONAR].[Plan] ON

GO


CREATE TABLE [GESTIONAR].[turno](
  [turn_id] [int] IDENTITY(1,1) NOT NULL ,
  [turn_profe_id] [int] NOT NULL REFERENCES GESTIONAR.profesional (prof_id),
  [turn_afil_id] [int] NOT NULL REFERENCES GESTIONAR.afiliado (afi_id),
  [turn_hora_inicio] [datetime] null,
  [turn_baja] [bit] NULL,
  [turn_creado] [datetime] NULL,
  [turn_modificado] [datetime] NULL
  CONSTRAINT [PK_GESTIONAR.turnda] PRIMARY KEY CLUSTERED 
  (
    [turnd_id] ASC
  )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]
GO


SET IDENTITY_INSERT  [GD2C2013].[GESTIONAR].[turno] ON

insert into GESTIONAR.turno (
[turn_id],
[turn_profe_id],
[turn_afil_id],
[turn_hora_inicio],
[turn_baja],
[turn_creado],
[turn_modificado])
(select Turno_Numero,p.prof_id,af.afi_id, m.turno_fecha , case DATEPART( WEEKDAY , m.Turno_Fecha )
when 7  then 1
ELSE 0 end ,SYSDATETIME(),SYSDATETIME()
from gd_esquema.Maestra m
inner join GESTIONAR.afiliado af on af.afi_nro_documento = m.Paciente_Dni
inner join GESTIONAR.profesional p on p.prof_nro_documento=m.Medico_Dni
where consulta_sintomas is null
and consulta_enfermedades is null
and Turno_Numero is not null
)
SET IDENTITY_INSERT  [GD2C2013].[GESTIONAR].[turno] OFF

CREATE TABLE [GESTIONAR].[agenda](
  [agend_id] [int] IDENTITY(1,1) NOT NULL ,
  [agen_profe_id] [int] NOT NULL REFERENCES GESTIONAR.profesional (prof_id),
  [agen_afil_id] [int] NOT NULL REFERENCES GESTIONAR.afiliado (afi_id),
  [agen_hora_inicio] [datetime] null,
  [agen_baja] [bit] NULL,
  [agen_creado] [datetime] NULL,
  [agen_modificado] [datetime] NULL
  CONSTRAINT [PK_GESTIONAR.agenda] PRIMARY KEY CLUSTERED 
  (
    [agend_id] ASC
  )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]
GO


insert into GESTIONAR.agenda (
[agen_profe_id],
[agen_afil_id],
[agen_hora_inicio],
[agen_baja],
[plan_creado],
[plan_modificado])
(select p.prof_id,af.afi_id, m.turno_fecha,0,SYSDATETIME(),SYSDATETIME()
from gd_esquema.Maestra m
inner join GESTIONAR.afiliado af on af.afi_nro_documento = m.Paciente_Dni
inner join GESTIONAR.profesional p on p.prof_nro_documento=m.Medico_Dni
)


