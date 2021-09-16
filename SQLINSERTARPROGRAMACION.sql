/*INSERTAR META*/

INSERT INTO dbo.INFOREG_META(
[ANO_EJE],[SEC_EJEC],[SEC_FUNC],[META],[DESCRIPCION_META]
      ,[UNIDAD_MEDIDA],[UNIDAD_MEDIDA_NOMBRE],[FINALIDAD],[FINALIDAD_NOMBRE]
      ,[DEPARTAMENTO],[DEPARTAMENTO_NOMBRE],[PROVINCIA],[PROVINCIA_NOMBRE],[DISTRITO]
      ,[DISTRITO_NOMBRE],[FUNCION],[FUNCION_NOMBRE],[PROGRAMA],[PROGRAMA_NOMBRE]
      ,[SUB_PROGRAMA],[SUB_PROGRAMA_NOMBRE],[ACT_PROY],[ACT_PROY_NOMBRE],[COMPONENTE]
      ,[COMPONENTE_NOMBRE],[PROYECTO_SNIP],[PROYECTO_SNIP_NOMBRE],[PROGRAMA_PPTO]
      ,[PROGRAMA_PPTO_NOMBRE])
SELECT DISTINCT [ANO_EJE],[SEC_EJEC],[SEC_FUNC],[META],[DESCRIPCION_META]
      ,[UNIDAD_MEDIDA],[UNIDAD_MEDIDA_NOMBRE],[FINALIDAD],[FINALIDAD_NOMBRE]
      ,[DEPARTAMENTO],[DEPARTAMENTO_NOMBRE],[PROVINCIA],[PROVINCIA_NOMBRE],[DISTRITO]
      ,[DISTRITO_NOMBRE],[FUNCION],[FUNCION_NOMBRE],[PROGRAMA],[PROGRAMA_NOMBRE]
      ,[SUB_PROGRAMA],[SUB_PROGRAMA_NOMBRE],[ACT_PROY],[ACT_PROY_NOMBRE],[COMPONENTE]
      ,[COMPONENTE_NOMBRE],[PROYECTO_SNIP],[PROYECTO_SNIP_NOMBRE],[PROGRAMA_PPTO]
      ,[PROGRAMA_PPTO_NOMBRE] FROM [dbo].[INFOREG_EJECUCION_2009]
/*INSERTAR FUENTE FINANC*/

INSERT INTO dbo.INFOREG_FUENTE_FINANC(
[ANO_EJE]
      ,[FUENTE_FINANC]
      ,[FUENTE_FINANC_NOMBRE])
SELECT DISTINCT [ANO_EJE]
      ,[FUENTE_FINANC]
      ,[FUENTE_FINANC_NOMBRE]
  FROM [dbo].[INFOREG_EJECUCION_2009]
/*FUENTE_FINANC_EJEC*/

/****** Script para el comando SelectTopNRows de SSMS  ******/
INSERT INTO [INFOREG_FUENTE_FINANC_EJEC](
ANO_EJE,SEC_EJEC,FUENTE_FINANC)
SELECT DISTINCT [ANO_EJE]
      ,[SEC_EJEC]
      ,[FUENTE_FINANC]
  FROM [dbo].[INFOREG_EJECUCION_2009]
  
/*SCRIPT META*/

INSERT INTO [dbo].[INFOREG_META]
		( [ANO_EJE]
      ,[SEC_EJEC]
      ,[SEC_FUNC]
      ,[META]
      ,[DESCRIPCION_META]
      ,[UNIDAD_MEDIDA]
      ,[UNIDAD_MEDIDA_NOMBRE]
      ,[FINALIDAD]
      ,[FINALIDAD_NOMBRE]
      ,[DEPARTAMENTO]
      ,[DEPARTAMENTO_NOMBRE]
      ,[PROVINCIA]
      ,[PROVINCIA_NOMBRE]
      ,[DISTRITO]
      ,[DISTRITO_NOMBRE]
      ,[FUNCION]
      ,[FUNCION_NOMBRE]
      ,[PROGRAMA]
      ,[PROGRAMA_NOMBRE]
      ,[SUB_PROGRAMA]
      ,[SUB_PROGRAMA_NOMBRE]
      ,[ACT_PROY]
      ,[ACT_PROY_NOMBRE]
      ,[COMPONENTE]
      ,[COMPONENTE_NOMBRE]
      ,[PROYECTO_SNIP]
      ,[PROYECTO_SNIP_NOMBRE]
      ,[PROGRAMA_PPTO]
      ,[PROGRAMA_PPTO_NOMBRE])
SELECT DISTINCT 
[ANO_EJE]
      ,[SEC_EJEC]
      ,[SEC_FUNC]
      ,[META]
      ,[DESCRIPCION_META]
      ,[UNIDAD_MEDIDA]
      ,[UNIDAD_MEDIDA_NOMBRE]
      ,[FINALIDAD]
      ,[FINALIDAD_NOMBRE]
      ,[DEPARTAMENTO]
      ,[DEPARTAMENTO_NOMBRE]
      ,[PROVINCIA]
      ,[PROVINCIA_NOMBRE]
      ,[DISTRITO]
      ,[DISTRITO_NOMBRE]
      ,[FUNCION]
      ,[FUNCION_NOMBRE]
      ,[PROGRAMA]
      ,[PROGRAMA_NOMBRE]
      ,[SUB_PROGRAMA]
      ,[SUB_PROGRAMA_NOMBRE]
      ,[ACT_PROY]
      ,[ACT_PROY_NOMBRE]
      ,[COMPONENTE]
      ,[COMPONENTE_NOMBRE]
      ,[PROYECTO_SNIP]
      ,[PROYECTO_SNIP_NOMBRE]
      ,[PROGRAMA_PPTO]
      ,[PROGRAMA_PPTO_NOMBRE]
      FROM [dbo].[INFOREG_EJECUCION_2009]
      
/**/
SELECT ANO_EJE,SEC_EJEC,SEC_FUNC,FUENTE_FINANC,ID_CLASIFICADOR,PIA,PIM,
	ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SETIEMBRE,OCTUBRE,NOVIEMBRE,DICICEMBRE
  FROM [dbo].[INFOREG_PROGRAMACION_GASTO]
      
      
/*PROGRAMACION*/


DELETE FROM dbo.INFOREG_PROGRAMACION_GASTO
INSERT INTO dbo.INFOREG_PROGRAMACION_GASTO(
ANO_EJE,SEC_EJEC,SEC_FUNC,FUENTE_FINANC,ID_CLASIFICADOR,PIA,PIM)
  SELECT DISTINCT ANO_EJE,SEC_EJEC,SEC_FUNC,FUENTE_FINANC,ID_CLASIFICADOR,SUM(PIA) AS PIA,SUM(PIM) AS PIM
  FROM [dbo].[INFOREG_EJECUCION_2009]
  GROUP BY ANO_EJE,SEC_EJEC,SEC_FUNC,FUENTE_FINANC,ID_CLASIFICADOR
  ORDER BY ANO_EJE,SEC_EJEC,SEC_FUNC,FUENTE_FINANC,ID_CLASIFICADOR
  
  
  
/*insertar clasificador*/  
INSERT INTO [dbo].[INFOREG_ESPECIFICA_DET](
		[ANO_EJE]
      ,[CATEGORIA_GASTO]
      ,[GENERICA]
      ,[SUBGENERICA]
      ,[SUBGENERICA_DET]
      ,[ESPECIFICA]
      ,[ESPECIFICA_DET]
      ,[ESPECIFICA_DET_NOMBRE]
      ,[ID_CLASIFICADOR])
SELECT DISTINCT [ANO_EJE]
      ,[CATEGORIA_GASTO]
      ,[GENERICA]
      ,[SUBGENERICA]
      ,[SUBGENERICA_DET]
      ,[ESPECIFICA]
      ,[ESPECIFICA_DET]
      ,[ESPECIFICA_DET_NOMBRE]
      ,[ID_CLASIFICADOR]
  FROM [dbo].[INFOREG_EJECUCION_2009]
  