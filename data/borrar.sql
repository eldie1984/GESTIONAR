USE [GD1C2013]
GO

IF OBJECT_ID (N'transportados.SemYear', N'FN') IS NOT NULL
    DROP FUNCTION transportados.SemYear;
GO

/****** Object:  View [transportados].[destino_view]    Script Date: 07/21/2013 09:44:52 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[transportados].[destino_view]'))
DROP VIEW [transportados].[destino_view]
GO



IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[obtener_premios]') AND type in (N'P', N'PC'))
DROP PROCEDURE [transportados].[obtener_premios]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[actualizar_puntos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [transportados].[actualizar_puntos]
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[bajaRol]') AND type in (N'P', N'PC'))
DROP PROCEDURE [transportados].[bajaRol]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[devuelvePasajes]') AND type in (N'P', N'PC'))
DROP PROCEDURE [transportados].[devuelvePasajes]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[cargarMicro]') AND type in (N'P', N'PC'))
DROP PROCEDURE  [transportados].[cargarMicro]
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[buscaViajes]') AND type in (N'P', N'PC'))
DROP PROCEDURE [transportados].[buscaViajes]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[existe]') AND type in (N'P', N'PC'))
DROP PROCEDURE [transportados].[existe]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[microAlterno]') AND  type in (N'P', N'PC'))
DROP PROCEDURE [transportados].[microAlterno]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[pasajesVendidos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [transportados].[pasajesVendidos]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[devolucionPersonal]') AND type in (N'P', N'PC'))
DROP PROCEDURE [transportados].[devolucionPersonal]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[reemplaza_micro]') AND type in (N'P', N'PC'))
DROP PROCEDURE [transportados].[reemplaza_micro]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[compra]') AND type in (N'P', N'PC'))
DROP procedure [transportados].[compra]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[Compra_pasaje]') AND type in (N'P', N'PC'))
DROP PROCEDURE [transportados].[Compra_pasaje]
GO

/****** Object:  Table [transportados].[puntos_pas_frecuente]    Script Date: 05/21/2013 22:23:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[puntos_pas_frecuente]') AND type in (N'U'))
DROP TABLE [transportados].[puntos_pas_frecuente]
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[pasajes]') AND type in (N'U'))
DROP TABLE [transportados].[pasajes]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[Rol_funcionalidad]') AND type in (N'U'))
DROP TABLE [transportados].[Rol_funcionalidad]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[rol_usuario]') AND type in (N'U'))
DROP TABLE [transportados].[rol_usuario]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[usuario]') AND type in (N'U'))
DROP TABLE [transportados].[usuario]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[funcionalidad]') AND type in (N'U'))
DROP TABLE [transportados].[funcionalidad]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[Rol]') AND type in (N'U'))
DROP TABLE [transportados].[Rol]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[facturas]') AND type in (N'U'))
DROP TABLE [transportados].[facturas]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[butaca]') AND type in (N'U'))
DROP TABLE [transportados].[butaca]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[premios_obtenidos]') AND type in (N'U'))
DROP TABLE [transportados].[premios_obtenidos]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[voucher_de_compra]') AND type in (N'U'))
DROP TABLE [transportados].[voucher_de_compra]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[viajes]') AND type in (N'U'))
DROP TABLE [transportados].[viajes]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[recorrido]') AND type in (N'U'))
DROP TABLE [transportados].[recorrido]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[ciudad]') AND type in (N'U'))
DROP TABLE [transportados].[ciudad]
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[premios]') AND type in (N'U'))
DROP TABLE [transportados].[premios]
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[micros]') AND type in (N'U'))
DROP TABLE [transportados].[micros]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[clientes]') AND type in (N'U'))
DROP TABLE [transportados].[clientes]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[transportados].[tipo_servicio]') AND type in (N'U'))
DROP TABLE [transportados].[tipo_servicio]
GO

IF  EXISTS (SELECT * FROM sys.schemas WHERE name = 'transportados')
DROP SCHEMA [transportados]
GO