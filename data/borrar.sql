USE [GD2C2013]
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GESTIONAR].[agenda]') AND type in (N'U'))
DROP TABLE [GESTIONAR].[agenda]
GO




IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GESTIONAR].[profesional_especialidad]') AND type in (N'U'))
DROP TABLE [GESTIONAR].[profesional_especialidad]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GESTIONAR].[Rol_funcionalidad]') AND type in (N'U'))
DROP TABLE [GESTIONAR].[Rol_funcionalidad]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GESTIONAR].[rol_usuario]') AND type in (N'U'))
DROP TABLE [GESTIONAR].[rol_usuario]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GESTIONAR].[turno]') AND type in (N'U'))
DROP TABLE [GESTIONAR].[turno]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GESTIONAR].[usuario]') AND type in (N'U'))
DROP TABLE [GESTIONAR].[usuario]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GESTIONAR].[Rol]') AND type in (N'U'))
DROP TABLE [GESTIONAR].[Rol]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GESTIONAR].[profesional]') AND type in (N'U'))
DROP TABLE [GESTIONAR].[profesional]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GESTIONAR].[funcionalidad]') AND type in (N'U'))
DROP TABLE [GESTIONAR].[funcionalidad]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GESTIONAR].[Especialidad]') AND type in (N'U'))
DROP TABLE [GESTIONAR].[Especialidad]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GESTIONAR].[Tipo_Especialidad]') AND type in (N'U'))
DROP TABLE [GESTIONAR].[Tipo_Especialidad]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GESTIONAR].[Hist_Plan_Afiliado]') AND type in (N'U'))
DROP TABLE [GESTIONAR].[Hist_Plan_Afiliado]
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GESTIONAR].[afiliado]') AND type in (N'U'))
DROP TABLE [GESTIONAR].[afiliado]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GESTIONAR].[estado_civil]') AND type in (N'U'))
DROP TABLE [GESTIONAR].[estado_civil]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GESTIONAR].[Plan]') AND type in (N'U'))
DROP TABLE [GESTIONAR].[Plan]
GO

IF  EXISTS (SELECT * FROM sys.schemas WHERE name = 'GESTIONAR')
DROP SCHEMA [GESTIONAR]
GO