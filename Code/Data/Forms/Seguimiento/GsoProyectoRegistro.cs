using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace InfogesEmape.Code.Data.Forms.Seguimiento
{
	public class GsoProyectoRegistro
	{

		#region SearchByProyecto
		public static DataSet SearchByProyecto(string pIdProyecto)
		{
			DataSet ds1 = new DataSet();
			string StringSql = " SELECT ";
			StringSql += " B.ACT_PROY, A.IDPROYECTO, A.CUI, A.DESCRIPCION, A.ABREVIATURA, A.IDTIPO_PROYECTO, A.IDPAQUETE, A.IDACTIVIDAD_PROYECTO, A.MONTO_TOTAL_PROYECTO, A.MONTO_TOTAL_EXP_TECNICO, A.MONTO_TOTAL_OBRA, ";
			StringSql += " A.MONTO_TOTAL_SUPERVISION, A.MONTO_TOTAL_INTERFERENCIA, A.MONTO_TOTAL_GESTION_PROYECTO, A.MONTO_TOTAL_TERRENO, A.MONTO_TOTAL_MOBILIARIA, A.MONTO_TOTAL_MITIGACION_AMBIENTAL, A.COORDENADA_INICIO_NORTE, ";
			StringSql += " A.COORDENADA_INICIO_ESTE, A.COORDENADA_FIN_NORTE, A.COORDENADA_FIN_ESTE, A.UBIGEO, A.IDCOORDINADOR, A.DEPARTAMENTO, A.PROVINCIA, A.DISTRITO, A.ESTADO, A.CICLO_PROYECTO,A.PCUTILIDADES,A.PCGASTOS_GENERALES,A.PCGASTOS_OTROS,A.PCADELANTODIRECTO,A.PCADELANTOMATERIALES,A.PCADELANTOOTROS, ";
			StringSql += " A.FECHA_INICIO, A.FECHA_FIN FROM OBRASEMP.PROYECTO A, SIAF_500196.inforeg_banco_proyecto B WHERE A.CUI='" + pIdProyecto + "' AND A.CUI=B.ACT_PROy";

			return InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(StringSql);
		}
		#endregion

		#region InsertProyecto
		public static string InsertProyecto(string[] parameterValues)
		{

			string sqlCommand = " INSERT INTO OBRASEMP.PROYECTO( ";
			sqlCommand += " CUI,descripcion,abreviatura,idPaquete,idActividad_Proyecto,idTipo_Proyecto,monto_total_exp_tecnico,monto_total_supervision,monto_total_interferencia,";
			sqlCommand += " monto_total_gestion_proyecto,monto_total_terreno,monto_total_mobiliaria,Coordenada_inicio_norte,Coordenada_inicio_este,coordenada_fin_norte,coordenada_fin_este,DISTRITO,monto_total_obra)";
			sqlCommand += " VALUES ( ";
			sqlCommand += (parameterValues[1].ToString().Length == 0 ? "null" : "'" + parameterValues[1].ToString() + "'") + ",";
			sqlCommand += (parameterValues[2].ToString().Length == 0 ? "null" : "'" + parameterValues[2].ToString() + "'") + ",";
			sqlCommand += (parameterValues[3].ToString().Length == 0 ? "null" : "'" + parameterValues[3].ToString() + "'") + ","; ;
			sqlCommand += (parameterValues[4].ToString().Length == 0 ? "null" : "'" + parameterValues[4].ToString() + "'") + ",";
			sqlCommand += (parameterValues[5].ToString().Length == 0 ? "null" : "'" + parameterValues[5].ToString() + "'") + ",";
			sqlCommand += (parameterValues[6].ToString().Length == 0 ? "null" : "'" + parameterValues[6].ToString() + "'") + ",";
			sqlCommand += (parameterValues[7].ToString().Length == 0 ? "null" : "'" + parameterValues[7].ToString() + "'") + ",";
			sqlCommand += (parameterValues[8].ToString().Length == 0 ? "null" : "'" + parameterValues[8].ToString() + "'") + ",";
			sqlCommand += (parameterValues[9].ToString().Length == 0 ? "null" : "'" + parameterValues[9].ToString() + "'") + ",";
			sqlCommand += (parameterValues[10].ToString().Length == 0 ? "null" : "'" + parameterValues[10].ToString() + "'") + ",";
			sqlCommand += (parameterValues[11].ToString().Length == 0 ? "null" : "'" + parameterValues[11].ToString() + "'") + ",";
			sqlCommand += (parameterValues[12].ToString().Length == 0 ? "null" : "'" + parameterValues[12].ToString() + "'") + ",";
			sqlCommand += (parameterValues[13].ToString().Length == 0 ? "null" : "'" + parameterValues[13].ToString() + "'") + ",";
			sqlCommand += (parameterValues[14].ToString().Length == 0 ? "null" : "'" + parameterValues[14].ToString() + "'") + ",";
			sqlCommand += (parameterValues[15].ToString().Length == 0 ? "null" : "'" + parameterValues[15].ToString() + "'") + ",";
			sqlCommand += (parameterValues[16].ToString().Length == 0 ? "null" : "'" + parameterValues[16].ToString() + "'") + ",";
			sqlCommand += (parameterValues[17].ToString().Length == 0 ? "null" : "'" + parameterValues[17].ToString() + "'") + ",";
			sqlCommand += (parameterValues[18].ToString().Length == 0 ? "null" : "'" + parameterValues[18].ToString() + "'") + "); ";

			DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
			return "1";
		}
		#endregion

		#region UpdatedProyecto
		public static string UpdatedProyecto(string[] parameterValues, string IdProyecto)
		{
			string r = "";
			string sqlCommand = " UPDATE OBRASEMP.PROYECTO SET ";
			sqlCommand += " CUI =" + (parameterValues[1].ToString().Length == 0 ? "null" : "'" + parameterValues[1].ToString() + "'") + ",";
			sqlCommand += " descripcion =" + (parameterValues[2].ToString().Length == 0 ? "null" : "'" + parameterValues[2].ToString() + "'") + ",";
			sqlCommand += " abreviatura =" + (parameterValues[3].ToString().Length == 0 ? "null" : "'" + parameterValues[3].ToString() + "'") + ","; ;
			sqlCommand += " idPaquete =" + (parameterValues[4].ToString().Length == 0 ? "null" : "" + parameterValues[4].ToString() + "") + ",";
			sqlCommand += " idActividad_Proyecto =" + (parameterValues[5].ToString().Length == 0 ? "null" : "" + parameterValues[5].ToString() + "") + ",";
			sqlCommand += " idTipo_Proyecto =" + (parameterValues[6].ToString().Length == 0 ? "null" : "" + parameterValues[6].ToString() + "") + ",";
			sqlCommand += " monto_total_exp_tecnico =" + (parameterValues[7].ToString().Length == 0 ? "null" : "" + parameterValues[7].ToString() + "") + ",";
			sqlCommand += " monto_total_supervision =" + (parameterValues[8].ToString().Length == 0 ? "null" : "" + parameterValues[8].ToString() + "") + ",";
			sqlCommand += " monto_total_interferencia =" + (parameterValues[9].ToString().Length == 0 ? "null" : "" + parameterValues[9].ToString() + "") + ",";
			sqlCommand += " monto_total_gestion_proyecto =" + (parameterValues[10].ToString().Length == 0 ? "null" : "" + parameterValues[10].ToString() + "") + ",";
			sqlCommand += " monto_total_terreno =" + (parameterValues[11].ToString().Length == 0 ? "null" : "" + parameterValues[11].ToString() + "") + ",";
			sqlCommand += " monto_total_mobiliaria =" + (parameterValues[12].ToString().Length == 0 ? "null" : "" + parameterValues[12].ToString() + "") + ",";
			sqlCommand += " Coordenada_inicio_norte =" + (parameterValues[13].ToString().Length == 0 ? "null" : "" + parameterValues[13].ToString() + "") + ",";
			sqlCommand += " Coordenada_inicio_este =" + (parameterValues[14].ToString().Length == 0 ? "null" : "" + parameterValues[14].ToString() + "") + ",";
			sqlCommand += " coordenada_fin_norte =" + (parameterValues[15].ToString().Length == 0 ? "null" : "" + parameterValues[15].ToString() + "") + ",";
			sqlCommand += " coordenada_fin_este =" + (parameterValues[16].ToString().Length == 0 ? "null" : "" + parameterValues[16].ToString() + "") + ",";
			sqlCommand += " DISTRITO =" + (parameterValues[17].ToString().Length == 0 ? "null" : "'" + parameterValues[17].ToString() + "'") + ",";
			sqlCommand += " monto_total_obra=" + (parameterValues[18].ToString().Length == 0 ? "null" : "'" + parameterValues[18].ToString() + "'") + " ";
			sqlCommand += " WHERE CUI=" + parameterValues[0].ToString() + ";  SELECT 1 AS last_id_generate FROM DUAL; ";


			DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);

			return r;
		}
		#endregion

		#region ProyectoMeta

		#region SearchByProyectoMeta
		public static DataSet SearchByProyectoMeta(string IdProyecto)
		{
			DataSet ds1 = new DataSet();
			string StringSql = " SELECT ";
			StringSql += " A.IDPROYECTO, A.IDPROYECTO_DETALLE, A.PERIODO,  A.META_ANUAL,";
			StringSql += " A.META_OBRA, A.META_OBRA_PORCENTAJE,  A.META_SUPERVISION, A.META_SUPERVISION_PORCENTAJE,  A.META_EXP_TECNICO, A.META_EXP_TECNICO_PORCENTAJE, A.META_INTERFERENCIA,  ";
			StringSql += " A.META_INTERFERENCIA_PORCENTAJE, A.META_GESTION_PROYECTO, ";
			StringSql += " A.META_GESTION_PROYECTO_PORCENTAJE, A.META_TERRENO, ";
			StringSql += " A.META_TERRENO_PORCENTAJE, A.META_MOBILIARIO, A.META_MOBILIARIO_PORCENTAJE, ";
			StringSql += " A.META_MITIGACION_AMBIENTAL, A.META_MITIGACION_AMBIENTAL_PORCENTAJE, ";
			StringSql += " A.META_FISICA_PROYECTADA, A.META_AVANCE_PROYECTADO, A.AVANCE_PROYECTADO, ";
			StringSql += " A.UNIDAD_MEDIDA, A.PORCENTAJE ";
			StringSql += " FROM ";
			StringSql += " OBRASEMP.PROYECTO_DETALLE A , OBRASEMP.PROYECTO B ";
			StringSql += " WHERE A.IDPROYECTO=B.IDPROYECTO AND B.CUI= " + IdProyecto + " ";

			return InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(StringSql);
		}
		#endregion

		#region InsertRowProyectoMeta
		public static string InsertRowProyectoMeta(string[] parameterValues)
		{
			string r = "";
			Database db = DatabaseFactory.CreateDatabase();
			string sqlCommand = "";
			sqlCommand += "  SELECT @pIdProyecto:=idproyecto FROM OBRASEMP.proyecto WHERE cui=" + (parameterValues[0].ToString().Length == 0 ? "0" : "'" + parameterValues[0].ToString() + "'") + "; ";
			sqlCommand += " INSERT INTO OBRASEMP.PROYECTO_DETALLE (";
			sqlCommand += " IDPROYECTO,PERIODO, META_OBRA, META_SUPERVISION, META_EXP_TECNICO, META_INTERFERENCIA, META_GESTION_PROYECTO, ";
			sqlCommand += " META_TERRENO, META_MOBILIARIO, META_MITIGACION_AMBIENTAL,META_FISICA_PROYECTADA ";
			sqlCommand += " ) VALUES (";
			sqlCommand += " @pIdProyecto ,";
			sqlCommand += " " + (parameterValues[1].ToString().Length == 0 ? "0" : "'" + parameterValues[1].ToString() + "'") + ",";
			sqlCommand += " " + (parameterValues[2].ToString().Length == 0 ? "0" : "'" + parameterValues[2].ToString() + "'") + ",";
			sqlCommand += " " + (parameterValues[3].ToString().Length == 0 ? "0" : "'" + parameterValues[3].ToString() + "'") + ","; ;
			sqlCommand += " " + (parameterValues[4].ToString().Length == 0 ? "0" : "'" + parameterValues[4].ToString() + "'") + ",";
			sqlCommand += " " + (parameterValues[5].ToString().Length == 0 ? "0" : "'" + parameterValues[5].ToString() + "'") + ",";
			sqlCommand += " " + (parameterValues[6].ToString().Length == 0 ? "0" : "'" + parameterValues[6].ToString() + "'") + ",";
			sqlCommand += " " + (parameterValues[7].ToString().Length == 0 ? "0" : "'" + parameterValues[7].ToString() + "'") + ",";
			sqlCommand += " " + (parameterValues[8].ToString().Length == 0 ? "0" : "'" + parameterValues[8].ToString() + "'") + ",";
			sqlCommand += " " + (parameterValues[9].ToString().Length == 0 ? "0" : "'" + parameterValues[9].ToString() + "'") + ",";
			sqlCommand += " " + (parameterValues[10].ToString().Length == 0 ? "0" : "'" + parameterValues[10].ToString() + "'") + ") ";

			DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
			return "1";
		}
		#endregion

		#region UpdatedRowProyectoMeta
		public static string UpdatedRowProyectoMeta(string[] parameterValues, string IdProyectoDetalle)
		{
			string r = "";
			Database db = DatabaseFactory.CreateDatabase();
			string sqlCommand = " UPDATE OBRASEMP.PROYECTO_DETALLE SET ";
			sqlCommand += " PERIODO =" + (parameterValues[1].ToString().Length == 0 ? "0" : "'" + parameterValues[1].ToString() + "'") + ",";
			sqlCommand += " META_OBRA =" + (parameterValues[2].ToString().Length == 0 ? "0" : "'" + parameterValues[2].ToString() + "'") + ",";
			sqlCommand += " META_SUPERVISION =" + (parameterValues[3].ToString().Length == 0 ? "0" : "'" + parameterValues[3].ToString() + "'") + ","; ;
			sqlCommand += " META_EXP_TECNICO =" + (parameterValues[4].ToString().Length == 0 ? "0" : "'" + parameterValues[4].ToString() + "'") + ",";
			sqlCommand += " META_INTERFERENCIA =" + (parameterValues[5].ToString().Length == 0 ? "0" : "'" + parameterValues[5].ToString() + "'") + ",";
			sqlCommand += " META_GESTION_PROYECTO =" + (parameterValues[6].ToString().Length == 0 ? "0" : "'" + parameterValues[6].ToString() + "'") + ",";
			sqlCommand += " META_TERRENO =" + (parameterValues[7].ToString().Length == 0 ? "0" : "'" + parameterValues[7].ToString() + "'") + ",";
			sqlCommand += " META_MOBILIARIO =" + (parameterValues[8].ToString().Length == 0 ? "0" : "'" + parameterValues[8].ToString() + "'") + ",";
			sqlCommand += " META_MITIGACION_AMBIENTAL =" + (parameterValues[9].ToString().Length == 0 ? "0" : "'" + parameterValues[9].ToString() + "'") + ",";
			sqlCommand += " META_FISICA_PROYECTADA =" + (parameterValues[10].ToString().Length == 0 ? "0" : "'" + parameterValues[10].ToString() + "'") + " ";
			sqlCommand += " WHERE IDPROYECTO_DETALLE=" + IdProyectoDetalle.ToString() + ";  SELECT 1 AS last_id_generate FROM DUAL; ";

			DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
			return "1";
		}
		#endregion

		#endregion

		#region ProyectoContratoCronograma

		#region SearchByProyectoContratoCronograma
		public static DataSet SearchByProyectoContratoCronograma(string IdProyecto)
		{
			DataSet ds1 = new DataSet();
			string StringSql = "  ";
			StringSql += " SELECT A.IDCONTRATOCRONOGRAMA,A.CRONOGRAMA, A.CRONOGRAMA_SEMANA, A.CRONOGRAMA_FECHA,A.AVANCE,FORMAT((B.MONTO_OBRA*A.AVANCE)/100,2) MONTO_OBRA ";
			StringSql += " FROM OBRASEMP.CONTRATO_CRONOGRAMA A, ";
			StringSql += " OBRASEMP.CONTRATO B, ";
			StringSql += " OBRASEMP.PROYECTO_COMPONENTE C, OBRASEMP.PROYECTO D ";
			StringSql += " WHERE ";
			StringSql += " A.IDCONTRATO=B.idcontrato AND ";
			StringSql += " B.idProyectoComponente=C.idProyectoComponente AND";
			StringSql += " C.IDPROYECTO=D.IDPROYECTO AND";
			StringSql += " D.CUI= '" + IdProyecto + "'  ";

			return InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(StringSql);
		}
		public static DataSet SearchByProyectoContratoCronograma(string IdProyecto, string pIdContrato)
		{
			DataSet ds1 = new DataSet();
			string StringSql = "  ";
			StringSql += " SELECT A.IDCONTRATOCRONOGRAMA,A.CRONOGRAMA, A.CRONOGRAMA_SEMANA, A.CRONOGRAMA_FECHA,A.AVANCE,FORMAT((B.MONTO_OBRA*A.AVANCE)/100,2) MONTO_OBRA ";
			StringSql += " FROM OBRASEMP.CONTRATO_CRONOGRAMA A, ";
			StringSql += " OBRASEMP.CONTRATO B, ";
			StringSql += " OBRASEMP.PROYECTO_COMPONENTE C, OBRASEMP.PROYECTO D ";
			StringSql += " WHERE ";
			StringSql += " A.IDCONTRATO=B.idcontrato AND ";
			StringSql += " B.idProyectoComponente=C.idProyectoComponente AND";
			StringSql += " C.IDPROYECTO=D.IDPROYECTO AND";
			StringSql += " D.CUI= '" + IdProyecto + "' AND A.IDCONTRATO=" + pIdContrato + " ";

			return InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(StringSql);
		}
		#endregion

		#region InsertPRowContratoProgramacion
		public static string InsertRowContratoProgramacion(string[] parameterValues)
		{

			string sqlCommand = " ";
			sqlCommand += "  SET @nroValorizacion=0 ;";
			sqlCommand += "  SELECT IFNULL(MAX(CRONOGRAMA),0)+1 INTO @nroValorizacion";
			sqlCommand += "  FROM OBRASEMP.CONTRATO_CRONOGRAMA WHERE IDCONTRATO=" + parameterValues[0].ToString() + ";";
			sqlCommand += " INSERT INTO OBRASEMP.CONTRATO_CRONOGRAMA( ";
			sqlCommand += " IDCONTRATO,CRONOGRAMA_SEMANA,CRONOGRAMA,CRONOGRAMA_FECHA,AVANCE)";
			sqlCommand += " VALUES ( ";
			sqlCommand += (parameterValues[0].ToString().Length == 0 ? "null" : "'" + parameterValues[0].ToString() + "'") + ",";
			sqlCommand += (parameterValues[2].ToString().Length == 0 ? "null" : "week('" + parameterValues[2].ToString() + "',2)") + ",";
			sqlCommand += "@nroValorizacion ,";
			sqlCommand += (parameterValues[2].ToString().Length == 0 ? "null" : "'" + parameterValues[2].ToString() + "'") + ",";
			sqlCommand += (parameterValues[3].ToString().Length == 0 ? "null" : "'" + parameterValues[3].ToString() + "'") + "); ";


			DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
			return "1";
		}
		#endregion

		#region UpdatedRowContratoProgramacion
		public static string UpdatedRowContratoProgramacion(string[] parameterValues, string IdContratoCronograma)
		{
			string r = "";
			Database db = DatabaseFactory.CreateDatabase();
			string sqlCommand = " UPDATE OBRASEMP.CONTRATO_CRONOGRAMA SET ";
			sqlCommand += " IDCONTRATO =" + (parameterValues[0].ToString().Length == 0 ? "0" : "'" + parameterValues[0].ToString() + "'") + ",";
			sqlCommand += " CRONOGRAMA_SEMANA =" + (parameterValues[2].ToString().Length == 0 ? "0" : "week('" + parameterValues[2].ToString() + "',2)") + ",";
			sqlCommand += " CRONOGRAMA =" + (parameterValues[1].ToString().Length == 0 ? "0" : "'" + parameterValues[1].ToString() + "'") + ","; ;
			sqlCommand += " CRONOGRAMA_FECHA =" + (parameterValues[2].ToString().Length == 0 ? "0" : "'" + parameterValues[2].ToString() + "'") + ",";
			sqlCommand += " AVANCE =" + (parameterValues[3].ToString().Length == 0 ? "0" : "'" + parameterValues[3].ToString() + "'") + " ";
			sqlCommand += " WHERE IDCONTRATOCRONOGRAMA=" + IdContratoCronograma.ToString() + ";  SELECT 1 AS last_id_generate FROM DUAL; ";


			DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
			return "1";
		}
		#endregion

		#region DeletedRowContratoProgramacion
		public static string DeletedRowContratoProgramacion(string IdContratoCronograma)
		{
			string r = "";
			Database db = DatabaseFactory.CreateDatabase();
			string sqlCommand = " DELETE FROM  OBRASEMP.CONTRATO_CRONOGRAMA  WHERE IDCONTRATOCRONOGRAMA='" + IdContratoCronograma + "' ;  SELECT 1 AS last_id_generate FROM DUAL; ";


			DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
			return "1";
		}
		#endregion

		#endregion

		#region ProyectoContratoSeguimiento

		#region SearchByProyectoContratoSeguimiento
		public static DataSet SearchByProyectoContratoSeguimiento(string IdProyecto)
		{
			DataSet ds1 = new DataSet();
			string StringSql = "  ";
			StringSql += " SELECT A.IDCONTRATOSEGUIMIENTO,A.SEGUIMIENTO_SEMANA,A.SEGUIMIENTO_CRONOGRAMA, A.SEGUIMIENTO_FECHA,A.AVANCE";
			StringSql += " FROM OBRASEMP.CONTRATO_SEGUIMIENTO A, ";
			StringSql += " OBRASEMP.CONTRATO B, ";
			StringSql += " OBRASEMP.PROYECTO_COMPONENTE C, OBRASEMP.PROYECTO D   ";
			StringSql += " WHERE ";
			StringSql += " A.IDCONTRATO=B.idcontrato AND ";
			StringSql += " B.idProyectoComponente=C.idProyectoComponente AND";
			StringSql += " C.IDPROYECTO=D.IDPROYECTO AND";
			StringSql += " D.CUI= '" + IdProyecto + "' ";


			return InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(StringSql);
		}
		public static DataSet SearchByProyectoContratoSeguimiento(string IdProyecto, string pIdContrato)
		{
			DataSet ds1 = new DataSet();
			string StringSql = "  ";
			StringSql += " SELECT A.IDCONTRATOSEGUIMIENTO,A.SEGUIMIENTO_SEMANA,A.SEGUIMIENTO_CRONOGRAMA, A.SEGUIMIENTO_FECHA,A.AVANCE";
			StringSql += " FROM OBRASEMP.CONTRATO_SEGUIMIENTO A, ";
			StringSql += " OBRASEMP.CONTRATO B, ";
			StringSql += " OBRASEMP.PROYECTO_COMPONENTE C, OBRASEMP.PROYECTO D   ";
			StringSql += " WHERE ";
			StringSql += " A.IDCONTRATO=B.idcontrato AND ";
			StringSql += " B.idProyectoComponente=C.idProyectoComponente AND";
			StringSql += " C.IDPROYECTO=D.IDPROYECTO AND";
			StringSql += " D.CUI= '" + IdProyecto + "' and A.IDCONTRATO=" + pIdContrato + " ";


			return InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(StringSql);
		}
		#endregion

		#region SearchByProyectoContratoSup 
		/*CAMBIO						FECHA			AUTOR
		SELECT	AVANCE DE SUPERVISOR	01-06-2021	    ALEXANDER FERNÁNDEZ 01-06-2021*/
		public static DataSet SearchByProyectoContratoSup(string IdProyecto, string pIdContrato)
		{
			DataSet ds1 = new DataSet();
			string StringSql = "   ";
			StringSql += " SELECT A.IDCONTRATOSEGUIMIENTO,A.SEGUIMIENTO_MES,A.SEGUIMIENTO_CRONOGRAMA,A.SEGUIMIENTO_FECHA,A.AVANCE,FORMAT((B.MONTO_OBRA*A.AVANCE)/100,2) MONTO_OBRA";
			StringSql += " FROM OBRASEMP.CONTRATO_SEGUIMIENTO_SUP A, ";
			StringSql += " OBRASEMP.CONTRATO B, ";
			StringSql += " OBRASEMP.PROYECTO_COMPONENTE C , OBRASEMP.PROYECTO D ";
			StringSql += " WHERE ";
			StringSql += " A.IDCONTRATO = B.idcontrato AND ";
			StringSql += " B.idProyectoComponente = C.idProyectoComponente AND";
			StringSql += " C.IDPROYECTO = D.IDPROYECTO AND";
			StringSql += " D.CUI = '" + IdProyecto + "' AND A.IDCONTRATO =" + pIdContrato + " ";


			return InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(StringSql);
		}
		#endregion

		#region InsertRowProyectoContratoSup
		/*CAMBIO						FECHA			AUTOR
		INSERT	AVANCE DE SUPERVISOR	01-06-2021	    ALEXANDER FERNÁNDEZ 01-06-2021*/
		public static string InsertRowProyectoContratoSup(string[] paramenterValues) {

			string sqlCommand = " ";
			sqlCommand += " SET @nroValorizacion = 0; ";
			sqlCommand += " SELECT IFNULL(MAX(SEGUIMIENTO_CRONOGRAMA),0)+1 INTO @nroValorizacion";
			sqlCommand += " FROM OBRASEMP.CONTRATO_SEGUIMIENTO_SUP WHERE IDCONTRATO = " + paramenterValues[0].ToString() + ";";
			sqlCommand += " INSERT INTO OBRASEMP.CONTRATO_SEGUIMIENTO_SUP( ";
			sqlCommand += " IDCONTRATO,SEGUIMIENTO_MES,SEGUIMIENTO_FECHA,SEGUIMIENTO_CRONOGRAMA,AVANCE)";
			sqlCommand += " VALUES ( ";
			sqlCommand += (paramenterValues[0].ToString().Length == 0 ? "null" : "'" + paramenterValues[0].ToString() + "'") + ",";
			sqlCommand += (paramenterValues[1].ToString().Length == 0 ? "null" : "week('" + paramenterValues[1].ToString() + "',2)") + ",";
			sqlCommand += (paramenterValues[1].ToString().Length == 0 ? "null" : "'" + paramenterValues[1].ToString() + "'") + ",";
			sqlCommand += "@nroValorizacion ,";
			sqlCommand += (paramenterValues[3].ToString().Length == 0 ? "null" : "'" + paramenterValues[3].ToString() + "'") + "); ";

			DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);

			return "1";

		}
		#endregion

		#region UpdateRowProyectoContratoSup
		/*CAMBIO						FECHA			AUTOR
		UPDATE	AVANCE DE SUPERVISOR	01-06-2021	    ALEXANDER FERNÁNDEZ 01-06-2021*/
		public static string UpdateRowProyectoContratoSup(string[] parameterValues, string IdContratoValorizacion)
		{
			string r = "";
			Database db = DatabaseFactory.CreateDatabase();

			string sqlCommand = " UPDATE OBRASEMP.CONTRATO_SEGUIMIENTO_SUP SET";
			sqlCommand += " IDCONTRATO =" + (parameterValues[0].ToString().Length == 0 ? "0" : "'" + parameterValues[0].ToString() + "'") + ",";
			sqlCommand += " SEGUIMIENTO_MES =" + (parameterValues[1].ToString().Length == 0 ? "0" : "week('" + parameterValues[1].ToString() + "',2)") + ",";
			sqlCommand += " SEGUIMIENTO_FECHA =" + (parameterValues[1].ToString().Length == 0 ? "0" : "'" + parameterValues[1].ToString() + "'") + ",";
			sqlCommand += " SEGUIMIENTO_CRONOGRAMA = " + (parameterValues[2].ToString().Length == 0 ? "0" : "'" + parameterValues[2].ToString() + "'") + ",";
			sqlCommand += " AVANCE =" + (parameterValues[3].ToString().Length == 0 ? "0" : "'" + parameterValues[3].ToString() + "'") + " ";
			sqlCommand += " WHERE IDCONTRATOSEGUIMIENTO=" + IdContratoValorizacion.ToString() + "; SELECT 1 AS last_id_generate FROM DUAL;";

			DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
			return "1";
		}
		#endregion

		#region DeleteRowProyectoContratoSup
		/*CAMBIO						FECHA			AUTOR
		DELETE	AVANCE DE SUPERVISOR	01-06-2021	    ALEXANDER FERNÁNDEZ 01-06-2021*/
		public static string DeleteRowProyectoContratoSup(string IdContratoSeguimiento)
		{
			//string r = "";
			Database db = DatabaseFactory.CreateDatabase();
			string sqlCommand = " DELETE FROM  OBRASEMP.CONTRATO_SEGUIMIENTO_SUP  WHERE IDCONTRATOSEGUIMIENTO='" + IdContratoSeguimiento + "' ;  SELECT 1 AS last_id_generate FROM DUAL; ";


			DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
			return "1";
		}
		#endregion


		#region SearchByProyectoContratoCon 
		/*CAMBIO						FECHA			AUTOR
		SELECT	AVANCE DE CONTRATISTA	03-06-2021	    ALEXANDER FERNÁNDEZ 03-06-2021*/
		public static DataSet SearchByProyectoContratoCon(string IdProyecto, string pIdContrato, string pIdContratoSeguimiento,string ejecucion)
		{
			DataSet ds5 = new DataSet();
			string StringSql = "   ";
            string AVANCE,MONTO;


            AVANCE = (ejecucion == "2") ? "A.AVANCESUP AS AVANCE" : "A.AVANCE AS AVANCE";
            MONTO  = (ejecucion == "2") ? "FORMAT(A.MONTOSUP,2) AS MONTO_OBRA" : "FORMAT(A.MONTO,2) AS MONTO_OBRA";

            StringSql += " SELECT A.IDCONTRATOSEGUIMIENTO,A.SEGUIMIENTO_MES,A.SEGUIMIENTO_CRONOGRAMA,A.SEGUIMIENTO_FECHA,"+ AVANCE +",A.APROBADO,"+ MONTO +",A.ADELANTO_DIRECTO,A.ADELANTO_MATERIALES";
            StringSql += " FROM OBRASEMP.CONTRATO_SEGUIMIENTO_CON A, ";
			StringSql += " OBRASEMP.CONTRATO B, ";
			StringSql += " OBRASEMP.PROYECTO_COMPONENTE C , OBRASEMP.PROYECTO D ";
			StringSql += " WHERE ";
			StringSql += " A.IDCONTRATO = B.idcontrato AND ";
			StringSql += " B.idProyectoComponente = C.idProyectoComponente AND";
			StringSql += " C.IDPROYECTO = D.IDPROYECTO AND";
			StringSql += " D.CUI = '" + IdProyecto + "' AND A.IDCONTRATO =" + pIdContrato + " ";

			if (pIdContratoSeguimiento != "") {
				StringSql += " AND A.IDCONTRATOSEGUIMIENTO = " + pIdContratoSeguimiento + " ";
			}
			return InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(StringSql);
		}
		#endregion

		#region InsertRowProyectoContratoCon
		/*CAMBIO						FECHA			AUTOR
		INSERT	AVANCE DE CONTRATISTA	03-06-2021	    ALEXANDER FERNÁNDEZ 03-06-2021*/
		public static string InsertRowProyectoContratoCon(string[] paramenterValues)
		{

			string sqlCommand = " ";
			sqlCommand += " SET @nroValorizacion = 0; ";
			sqlCommand += " SELECT IFNULL(MAX(SEGUIMIENTO_CRONOGRAMA),0)+1 INTO @nroValorizacion";
			sqlCommand += " FROM OBRASEMP.CONTRATO_SEGUIMIENTO_CON WHERE IDCONTRATO = " + paramenterValues[0].ToString() + ";";
			sqlCommand += " INSERT INTO OBRASEMP.CONTRATO_SEGUIMIENTO_CON( ";
			sqlCommand += " IDCONTRATO,SEGUIMIENTO_MES,SEGUIMIENTO_FECHA,SEGUIMIENTO_CRONOGRAMA,AVANCE,APROBADO)";
			sqlCommand += " VALUES ( ";
			sqlCommand += (paramenterValues[0].ToString().Length == 0 ? "null" : "'" + paramenterValues[0].ToString() + "'") + ",";
			sqlCommand += (paramenterValues[1].ToString().Length == 0 ? "null" : "week('" + paramenterValues[1].ToString() + "',2)") + ",";
			sqlCommand += (paramenterValues[1].ToString().Length == 0 ? "null" : "'" + paramenterValues[1].ToString() + "'") + ",";
			sqlCommand += "@nroValorizacion ,";
			sqlCommand += (paramenterValues[3].ToString().Length == 0 ? "null" : "'" + paramenterValues[3].ToString() + "'") + ",";
			sqlCommand += (paramenterValues[4].ToString().Length == 0 ? "null" : "'" + paramenterValues[4].ToString() + "'") + "); ";


			DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
			InsertarValorizacion(paramenterValues);
			InsertarPolinomica(paramenterValues);
			return "1";
		}

		/*CAMBIO						FECHA			AUTOR
		INSERTAR POLINOMICA			24-06-2021	    ALEXANDER FERNÁNDEZ 24-06-2021*/
		#region InsertarValorizacion
		public static string InsertarPolinomica(string[] paramenterValues)
		{
			string sqlCommand = " ";

			sqlCommand += " SET @nroValorizacion = 0;";
			sqlCommand += " SELECT IFNULL(MAX(IDCONTRATOSEGUIMIENTO),1) INTO @nroValorizacion";
			sqlCommand += " FROM OBRASEMP.CONTRATO_SEGUIMIENTO_CON WHERE IDCONTRATO = " + paramenterValues[0].ToString() + ";";
			sqlCommand += " INSERT INTO OBRASEMP.VALORIZACION_POLINOMICA(VAP_CONTRATO_ID, VAP_VAL_ID, VAP_POL_ID, VAP_FACTOR, VAP_INDICE_VALOR)";
			sqlCommand += " SELECT CPL_CONTRATO_ID, @nroValorizacion, CPL_POL_ID, CPL_FACTOR,CPL_INDICE_VALOR";
			sqlCommand += " FROM OBRASEMP.CONTRATO_POLINOMICA";
			sqlCommand += " WHERE CPL_CONTRATO_ID =" + paramenterValues[0].ToString();

			DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
			return "1";
		}
		#endregion

		/*CAMBIO						FECHA			AUTOR
		INSERTAR VALORIACION			21-07-2021	    ALEXANDER FERNÁNDEZ 24-06-2021*/
		#region
		/*public static string InsertarValorizacion(string[] paramenterValues) {
			string sqlCommand = " ";
			sqlCommand += " SET @nroValorizacion = 0;";
			sqlCommand += " SELECT IFNULL(MAX(IDCONTRATOSEGUIMIENTO),1) INTO @nroValorizacion";
			sqlCommand += " FROM OBRASEMP.CONTRATO_SEGUIMIENTO_CON WHERE IDCONTRATO = " + paramenterValues[0].ToString() + ";";
			sqlCommand += " INSERT INTO OBRASEMP.CONTRATO_VALORIZACION_DET(VAD_CONTRATO_ID, VAD_VALORIZACION_ID, VAD_PARTIDA_ID, VAD_PRECIO,VAD_CANTIDADTOTAL)";
			sqlCommand += " SELECT CTP_CONTRATO_ID, @nroValorizacion, CTP_PARTIDA_ID, CTP_PRECIO,CTP_CANTIDAD";
			sqlCommand += " FROM OBRASEMP.CONTRATO_PARTIDA";
			sqlCommand += " WHERE CTP_CONTRATO_ID =" + paramenterValues[0].ToString();

			DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
			return "1";
		}*/
        public static string InsertarValorizacion(string[] paramenterValues)
        {
            string sqlCommand = " ";
            sqlCommand += " SET @nroValorizacion = 0;";
            sqlCommand += " SELECT IFNULL(MAX(IDCONTRATOSEGUIMIENTO),1) INTO @nroValorizacion";
            sqlCommand += " FROM OBRASEMP.CONTRATO_SEGUIMIENTO_CON WHERE IDCONTRATO = " + paramenterValues[0].ToString() + ";";
            sqlCommand += " INSERT INTO OBRASEMP.VALORIZACION(VAD_CONTRATO_PARTIDA_ID,VAD_VALORIZACION_ID)";
            sqlCommand += " SELECT CTP_ID,@nroValorizacion";
            sqlCommand += " FROM OBRASEMP.CONTRATO_PARTIDA";
            sqlCommand += " WHERE CTP_CONTRATO_ID =" + paramenterValues[0].ToString() + " AND CTP_ESTADO = 2";

            DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
            return "1";
        }

        #endregion
        #endregion

        #region UpdateRowProyectoContratoCon
        /*CAMBIO						FECHA			AUTOR
		UPDATE	AVANCE DE CONTRATISTA	03-06-2021	    ALEXANDER FERNÁNDEZ 03-06-2021*/
        public static string UpdateRowProyectoContratoCon(string[] parameterValues, string IdContratoValorizacion)
		{
			string r = "";
			Database db = DatabaseFactory.CreateDatabase();

			string sqlCommand = " UPDATE OBRASEMP.CONTRATO_SEGUIMIENTO_CON SET";
			sqlCommand += " IDCONTRATO =" + (parameterValues[0].ToString().Length == 0 ? "0" : "'" + parameterValues[0].ToString() + "'") + ",";
			sqlCommand += " SEGUIMIENTO_MES =" + (parameterValues[1].ToString().Length == 0 ? "0" : "week('" + parameterValues[1].ToString() + "',2)") + ",";
			sqlCommand += " SEGUIMIENTO_FECHA =" + (parameterValues[1].ToString().Length == 0 ? "0" : "'" + parameterValues[1].ToString() + "'") + ",";
			sqlCommand += " SEGUIMIENTO_CRONOGRAMA = " + (parameterValues[2].ToString().Length == 0 ? "0" : "'" + parameterValues[2].ToString() + "'") + ",";        
            if (parameterValues[3].ToString() != "NCN")
            {
                sqlCommand += " AVANCE =" + (parameterValues[3].ToString().Length == 0 ? "0" : "'" + parameterValues[3].ToString() + "'") + ",";
            }                
			sqlCommand += " ADELANTO_DIRECTO =" + (parameterValues[4].ToString().Length == 0 ? "0" : "'" + parameterValues[4].ToString() + "'") + ",";
			sqlCommand += " ADELANTO_MATERIALES =" + (parameterValues[5].ToString().Length == 0 ? "0" : "'" + parameterValues[5].ToString() + "'") + ",";
			sqlCommand += " APROBADO =" + (parameterValues[6].ToString().Length == 0 ? "0" : "'" + parameterValues[6].ToString() + "'") + " ";
			sqlCommand += " WHERE IDCONTRATOSEGUIMIENTO=" + IdContratoValorizacion.ToString() + "; SELECT 1 AS last_id_generate FROM DUAL;";

			DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
			return "1";
		}
		#endregion

		#region DeleteRowProyectoContratoCon
		/*CAMBIO						FECHA			AUTOR
		DELETE	AVANCE DE CONTRATISTA	03-06-2021	    ALEXANDER FERNÁNDEZ 03-06-2021*/
		public static string DeleteRowProyectoContratoCon(string IdContratoSeguimiento)
		{
			//string r = "";
			Database db = DatabaseFactory.CreateDatabase();
			string sqlCommand = " DELETE FROM  OBRASEMP.CONTRATO_SEGUIMIENTO_CON  WHERE IDCONTRATOSEGUIMIENTO='" + IdContratoSeguimiento + "' ;  SELECT 1 AS last_id_generate FROM DUAL; ";


			DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
			return "1";
		}
		#endregion



		#region InsertRowContratoSeguimiento
		public static string InsertRowContratoSeguimiento(string[] parameterValues)
		{

			string sqlCommand = " ";
			sqlCommand += "  SET @nroValorizacion=0 ;";
			sqlCommand += "  SELECT MAX(SEGUIMIENTO_CRONOGRAMA)+1 INTO @nroValorizacion";
			sqlCommand += "  FROM OBRASEMP.CONTRATO_SEGUIMIENTO WHERE IDCONTRATO=" + parameterValues[0].ToString() + ";";
			sqlCommand += " INSERT INTO OBRASEMP.CONTRATO_SEGUIMIENTO( ";
			sqlCommand += " IDCONTRATO,SEGUIMIENTO_SEMANA,SEGUIMIENTO_FECHA,SEGUIMIENTO_CRONOGRAMA,AVANCE)";
			sqlCommand += " VALUES ( ";
			sqlCommand += (parameterValues[0].ToString().Length == 0 ? "null" : "'" + parameterValues[0].ToString() + "'") + ",";
			sqlCommand += (parameterValues[1].ToString().Length == 0 ? "null" : "week('" + parameterValues[1].ToString() + "',2)") + ",";
			sqlCommand += (parameterValues[1].ToString().Length == 0 ? "null" : "'" + parameterValues[1].ToString() + "'") + ","; ;
			sqlCommand += "@nroValorizacion ,";
			sqlCommand += (parameterValues[3].ToString().Length == 0 ? "null" : "'" + parameterValues[3].ToString() + "'") + "); ";

			DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
			return "1";
		}
		#endregion		

		#region UpdatedRowContratoSeguimiento
		public static string UpdatedRowContratoSeguimiento(string[] parameterValues, string IdContratoValorizacion)
        {
            string r = "";
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = " UPDATE OBRASEMP.CONTRATO_SEGUIMIENTO SET ";
            sqlCommand += " IDCONTRATO =" + (parameterValues[0].ToString().Length == 0 ? "0" : "'" + parameterValues[0].ToString() + "'") + ",";
            sqlCommand += " SEGUIMIENTO_SEMANA =" + (parameterValues[1].ToString().Length == 0 ? "0" : "week('" + parameterValues[1].ToString() + "',2)") + ",";
            sqlCommand += " SEGUIMIENTO_FECHA =" + (parameterValues[1].ToString().Length == 0 ? "0" : "'" + parameterValues[1].ToString() + "'") + ","; ;
            sqlCommand += " SEGUIMIENTO_CRONOGRAMA =" + (parameterValues[2].ToString().Length == 0 ? "0" : "'" + parameterValues[2].ToString() + "'") + ",";
            sqlCommand += " AVANCE =" + (parameterValues[3].ToString().Length == 0 ? "0" : "'" + parameterValues[3].ToString() + "'") + " ";
            sqlCommand += " WHERE IDCONTRATOSEGUIMIENTO=" + IdContratoValorizacion.ToString() + ";  SELECT 1 AS last_id_generate FROM DUAL; ";


            DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
            return "1";
        }
		#endregion		

		#region DeletedRowContratoSeguimiento
		public static string DeletedRowContratoSeguimiento(string IdContratoSeguimiento)
        {
            string r = "";
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = " DELETE FROM  OBRASEMP.CONTRATO_SEGUIMIENTO  WHERE IDCONTRATOSEGUIMIENTO='" + IdContratoSeguimiento + "' ;  SELECT 1 AS last_id_generate FROM DUAL; ";


            DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
            return "1";
        }
		#endregion


		#endregion


		#region ContratoValorizacionDet
		#region SearchByContratoValorizacionDet
		/*CAMBIO						FECHA			AUTOR
		SELECT CONTRATO VALORIZACION	22-06-2021	    ALEXANDER FERNÁNDEZ 22-06-2021*/
		public static DataSet SearchByContratoValorizacionDet(string IdProyecto, string IdContrato,int IdValorizacion,int ejecucion)
		{
			DataSet ds1 = new DataSet();
			string StringSql = "  ";
            string CADENA = " ";
            string SELECT_CANTIDAD;
            string VAD_CANTIDAD;



            SELECT_CANTIDAD = (ejecucion == 2) ? "VAD.VAD_CANTIDADSUP CANTIDAD,VAD.VAD_CANTIDAD CANTIDADSUP" : "VAD.VAD_CANTIDAD CANTIDAD,VAD.VAD_CANTIDADSUP CANTIDADSUP";
            VAD_CANTIDAD = (ejecucion == 2) ? "VAD.VAD_CANTIDADSUP" : "VAD.VAD_CANTIDAD";            

            StringSql += " SELECT A.*,IFNULL(B.ACUMULADO,0) ACUMULADO,IF(B.ACUMULADO IS NULL, A.CANTIDADTOTAL,A.CANTIDADTOTAL - B.ACUMULADO) SALDO_OLD,IF(B.ACUMULADO IS NULL, A.CANTIDADTOTAL,A.CANTIDADTOTAL - B.ACUMULADO) SALDO_OLD_ FROM ";            
            StringSql += " (SELECT VAD.VAD_ID IDCONTRATOVALORIZACIONDET, VAD.VAD_VALORIZACION_ID," + SELECT_CANTIDAD  + ",VAD.VAD_CANTIDADCON CANTIDADCON,VAD.VAD_APROBADO APROBADO,CTP.CTP_ID CTP_ID,CTP.PAR_PRECIO PRECIO, CTP.PAR_CANTIDAD CANTIDADTOTAL,";
            StringSql += " CTP.CTP_CODIGO CODIGO, CTP.PAR_NOMBRE PARTIDA, CTP.PAR_MEDIDA MEDIDA,";
            //StringSql += " FORMAT(("+ VAD_CANTIDAD +" / CTP.PAR_CANTIDAD) * 100, 2) PORCENTAJE,CTP.LEV1,CTP.LEV2 FROM OBRASEMP.VALORIZACION VAD";
            StringSql += " FORMAT(IF(CTP.PAR_CANTIDAD > 0,(" + VAD_CANTIDAD + " / CTP.PAR_CANTIDAD)*100,0), 2) PORCENTAJE,NULL LEV1,NULL LEV2 FROM OBRASEMP.VALORIZACION VAD";

            StringSql += " INNER JOIN OBRASEMP.VIEW_CONTRATO_PARTIDA02 CTP ON CTP.CTP_ID = VAD.VAD_CONTRATO_PARTIDA_ID";           
            StringSql += " WHERE VAD.VAD_VALORIZACION_ID = " + IdValorizacion +") A ";
            StringSql += " LEFT JOIN ";
            StringSql += " (SELECT CTP.CTP_ID CTP_ID,SUM("+ VAD_CANTIDAD +") ACUMULADO FROM OBRASEMP.VALORIZACION VAD";
            StringSql += "  JOIN OBRASEMP.CONTRATO_PARTIDA CTP ON CTP.CTP_ID = VAD.VAD_CONTRATO_PARTIDA_ID";
            StringSql += "  WHERE CTP.CTP_CONTRATO_ID =" + IdContrato + " AND VAD.VAD_VALORIZACION_ID < " + IdValorizacion + " GROUP BY CTP.CTP_ID) B ON A.CTP_ID = B.CTP_ID ORDER BY A.CODIGO";
            StringSql += "    ";
            return InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(StringSql);
		}
		#endregion

		#region UpdateRowContratoValorizacionDet
		/*CAMBIO						FECHA			AUTOR
		UPDATE CONTRATO VALORIZACION	29-06-2021	    ALEXANDER FERNÁNDEZ 29-06-2021*/
		public static string UpdateRowContratoValorizacionDet(string[] parameterValues, string IdContratoValorizacionDet)
		{
			string r = "";
			Database db = DatabaseFactory.CreateDatabase();
			string sqlCommand = " UPDATE OBRASEMP.VALORIZACION SET ";

            if (parameterValues[1].ToString() != "NCN")
            {
                sqlCommand += " VAD_CANTIDAD  =" + (parameterValues[1].ToString().Length == 0 ? "0" : "'" + parameterValues[1].ToString() + "'") + ", ";
            }

            if (parameterValues[2].ToString() != "NCN")
            {
                sqlCommand += " VAD_CANTIDADSUP  =" + (parameterValues[2].ToString().Length == 0 ? "0" : "'" + parameterValues[2].ToString() + "'") + ", ";
            }
            if (parameterValues[3].ToString() != "NCN")
            {
                sqlCommand += " VAD_CANTIDADCON  =" + (parameterValues[3].ToString().Length == 0 ? "0" : "'" + parameterValues[3].ToString() + "'") + ", ";
            }
			if (parameterValues[4].ToString() != "NCN")
			{
				sqlCommand += " VAD_APROBADO  =" + (parameterValues[4].ToString().Length == 0 ? "0" : "'" + parameterValues[4].ToString() + "'") + ", ";
			}
			sqlCommand += " VAD_ESTADO  = 2 ";
            sqlCommand += " WHERE VAD_ID=" + IdContratoValorizacionDet.ToString() + ";  SELECT 1 AS last_id_generate FROM DUAL; ";

			DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
			return "1";
		}

        /*CAMBIO						FECHA			AUTOR
		UPDATE CONTRATOSUP VALORIZACION	07-09-2021	    ALEXANDER FERNÁNDEZ 07-09-2021*/
        public static string UpdateRowContratoSupValorizacionDet(string[] parameterValues, string IdContratoValorizacionDet)
        {
            string r = "";
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = " UPDATE OBRASEMP.VALORIZACION SET ";

            if (parameterValues[1].ToString() != "NCN")
            {
                sqlCommand += " VAD_CANTIDADSUP  =" + (parameterValues[1].ToString().Length == 0 ? "0" : "'" + parameterValues[1].ToString() + "'") + ", ";
            }                        
            sqlCommand += " VAD_ESTADO  = 2 ";
            sqlCommand += " WHERE VAD_ID=" + IdContratoValorizacionDet.ToString() + ";  SELECT 1 AS last_id_generate FROM DUAL; ";

            DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
            return "1";
        }
        #endregion
        #endregion


        public static DataSet SearchByValorizacionContrato(string pIdValorizacion, string pIdContrato)
        {
            string StringSql = " SELECT A.IDCONTRATO, A.IDCONTRATOPRESUPUESTO,A.ITEM,A.DESCRIPCION,A.UNIDAD_MEDIDA,A.METRADO,A.PRECIO,A.TOTAL,A.ESEDITABLE, ";
            string spVal = " (";
            string spVal1 = "";
            int end = Convert.ToInt16(pIdValorizacion);
            for (int k = 1; k < end; k++)
            {
                spVal += "A.VAL" + string.Format("{0:00}", k) + "+ ";
            }
            spVal = spVal.Substring(1, spVal.Length - 1);
            spVal1 += " 0 ) as ACUMULADO, A.VAL" + string.Format("{0:00}", end) + " AS MODIFICADO, A.TOTAL- "+spVal+"0) AS SALDO ";

 
            DataSet ds1 = new DataSet();

            StringSql += spVal+spVal1+" FROM OBRASEMP.CONTRATO_PRESUPUESTO A";
            StringSql += " WHERE A.IDCONTRATO= '" + pIdContrato + "'  ";


            return InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(StringSql);
        }


        #region ProyectoContratoValorizacion

        #region SearchByProyectoContratoValorizacion
        public static DataSet SearchByProyectoContratoValorizacion(string IdProyecto)
        {
            DataSet ds1 = new DataSet();
            string StringSql = "  ";
            StringSql += " SELECT A.IDCONTRATOVALORIZACION,A.CRONOGRAMA, A.VALORIZACION_SEMANA, A.VALORIZACION_FECHA,A.AVANCE, A.VALORIZACION_NUMERO, A.VALORIZACION_IMPORTE";
            StringSql += " FROM OBRASEMP.CONTRATO_VALORIZACION A, ";
            StringSql += " OBRASEMP.CONTRATO B, ";
            StringSql += " OBRASEMP.PROYECTO_COMPONENTE C, OBRASEMP.PROYECTO D ";
            StringSql += " WHERE ";
            StringSql += " A.IDCONTRATO=B.idcontrato AND ";
            StringSql += " B.idProyectoComponente=C.idProyectoComponente AND";
            StringSql += " C.IDPROYECTO=D.IDPROYECTO AND";
            StringSql += " D.CUI= '" + IdProyecto + "' ";


            return InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(StringSql);
        }
        public static DataSet SearchByProyectoContratoValorizacion(string IdProyecto, string pIdcontrato)
        {
            DataSet ds1 = new DataSet();
            string StringSql = "  ";
            StringSql += " SELECT A.IDCONTRATOVALORIZACION,A.CRONOGRAMA, A.VALORIZACION_SEMANA, A.VALORIZACION_FECHA,A.AVANCE, A.VALORIZACION_NUMERO, A.VALORIZACION_IMPORTE";
            StringSql += " FROM OBRASEMP.CONTRATO_VALORIZACION A, ";
            StringSql += " OBRASEMP.CONTRATO B, ";
            StringSql += " OBRASEMP.PROYECTO_COMPONENTE C, OBRASEMP.PROYECTO D ";
            StringSql += " WHERE ";
            StringSql += " A.IDCONTRATO=B.idcontrato AND ";
            StringSql += " B.idProyectoComponente=C.idProyectoComponente AND";
            StringSql += " C.IDPROYECTO=D.IDPROYECTO AND";
            StringSql += " D.CUI= '" + IdProyecto + "' AND A.IDCONTRATO="+pIdcontrato+" ";


            return InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(StringSql);
        }        
        #endregion

        #region InsertRowContratoValorizacion
        public static string InsertRowContratoValorizacion(string[] parameterValues)
        {
            string sqlCommand = "  ";
            sqlCommand += "  SET @nroValorizacion=0 ;";
            sqlCommand += "  SELECT MAX(valorizacion_numero)+1 INTO @nroValorizacion";
            sqlCommand += "  FROM OBRASEMP.CONTRATO_VALORIZACION WHERE IDCONTRATO=" + parameterValues[0].ToString() + ";";
            sqlCommand += "  INSERT INTO OBRASEMP.CONTRATO_VALORIZACION( ";
            sqlCommand += " IDCONTRATO,VALORIZACION_SEMANA,VALORIZACION_FECHA,VALORIZACION_NUMERO,VALORIZACION_IMPORTE,AVANCE)";
            sqlCommand += " VALUES ( ";
            sqlCommand += (parameterValues[0].ToString().Length == 0 ? "null" : "'" + parameterValues[0].ToString() + "'") + ",";
            sqlCommand += (parameterValues[1].ToString().Length == 0 ? "null" : "week('" + parameterValues[1].ToString() + "',2)") + ",";
            sqlCommand += (parameterValues[1].ToString().Length == 0 ? "null" : "'" + parameterValues[1].ToString() + "'") + ","; ;
            sqlCommand += "@nroValorizacion ,";
            sqlCommand += (parameterValues[3].ToString().Length == 0 ? "null" : "'" + parameterValues[3].ToString() + "'") + ",";
            sqlCommand += (parameterValues[4].ToString().Length == 0 ? "null" : "'" + parameterValues[4].ToString() + "'") + "); ";

            DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
            return "1";
        }
        #endregion

        #region UpdatedRowContratoValorizacion
        public static string UpdatedRowContratoValorizacion(string[] parameterValues, string IdContratoValorizacion)
        {
            string r = "";
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = " UPDATE OBRASEMP.CONTRATO_VALORIZACION SET ";
            sqlCommand += " IDCONTRATO =" + (parameterValues[0].ToString().Length == 0 ? "0" : "'" + parameterValues[0].ToString() + "'") + ",";
            sqlCommand += " VALORIZACION_SEMANA =" + (parameterValues[1].ToString().Length == 0 ? "0" : "week('" + parameterValues[1].ToString() + "',2)") + ",";
            sqlCommand += " VALORIZACION_FECHA =" + (parameterValues[1].ToString().Length == 0 ? "0" : "'" + parameterValues[1].ToString() + "'") + ","; ;
            sqlCommand += " VALORIZACION_NUMERO =" + (parameterValues[2].ToString().Length == 0 ? "0" : "'" + parameterValues[2].ToString() + "'") + ",";
            sqlCommand += " VALORIZACION_IMPORTE =" + (parameterValues[3].ToString().Length == 0 ? "0" : "'" + parameterValues[3].ToString() + "'") + ",";
            sqlCommand += " AVANCE =" + (parameterValues[4].ToString().Length == 0 ? "0" : "'" + parameterValues[4].ToString() + "'") + " ";
            sqlCommand += " WHERE IDCONTRATOVALORIZACION=" + IdContratoValorizacion.ToString() + ";  SELECT 1 AS last_id_generate FROM DUAL; ";


            DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
            return "1";
        }
        #endregion

        #region DeletedRowContratoValorizacion
        public static string DeletedRowContratoValorizacion(string IdContratoSeguimiento)
        {
            string r = "";
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = " DELETE FROM  OBRASEMP.CONTRATO_VALORIZACION  WHERE IDCONTRATOVALORIZACION='" + IdContratoSeguimiento + "' ;  SELECT 1 AS last_id_generate FROM DUAL; ";


            DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
            return "1";
        }
        #endregion

        #endregion
        
        #region ProyectoContratoAdelanto

        #region SearchByProyectoContratoAdelanto
        public static DataSet SearchByProyectoContratoAdelanto(string IdProyecto)
        {
            DataSet ds1 = new DataSet();
            string StringSql = "  ";
            StringSql += " SELECT A.IDCONTRATOADELANTO, A.ADELANTO_SEMANA, A.ADELANTO_FECHA,A.TIPO_ADELANTO, A.ADELANTO_NUMERO, A.ADELANTO_IMPORTE";
            StringSql += " FROM OBRASEMP.CONTRATO_ADELANTO A, ";
            StringSql += " OBRASEMP.CONTRATO B, ";
            StringSql += " OBRASEMP.PROYECTO_COMPONENTE C, OBRASEMP.PROYECTO D ";
            StringSql += " WHERE ";
            StringSql += " A.IDCONTRATO=B.idcontrato AND ";
            StringSql += " B.idProyectoComponente=C.idProyectoComponente AND";
            StringSql += " C.IDPROYECTO=D.IDPROYECTO AND";
            StringSql += " D.CUI= '" + IdProyecto + "' ";


            return InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(StringSql);
        }
        public static DataSet SearchByProyectoContratoAdelanto(string IdProyecto, string pIdContrato)
        {
            DataSet ds1 = new DataSet();
            string StringSql = "  ";
            StringSql += " SELECT A.IDCONTRATOADELANTO, A.ADELANTO_SEMANA, A.ADELANTO_FECHA,A.TIPO_ADELANTO, A.ADELANTO_NUMERO, A.ADELANTO_IMPORTE";
            StringSql += " FROM OBRASEMP.CONTRATO_ADELANTO A, ";
            StringSql += " OBRASEMP.CONTRATO B, ";
            StringSql += " OBRASEMP.PROYECTO_COMPONENTE C, OBRASEMP.PROYECTO D ";
            StringSql += " WHERE ";
            StringSql += " A.IDCONTRATO=B.idcontrato AND ";
            StringSql += " B.idProyectoComponente=C.idProyectoComponente AND";
            StringSql += " C.IDPROYECTO=D.IDPROYECTO AND";
            StringSql += " D.CUI= '" + IdProyecto + "' AND A.IDCONTRATO="+pIdContrato+" ";


            return InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(StringSql);
        }

        #endregion

        #region InsertRowContratoAdelanto
        public static string InsertRowContratoAdelanto(string[] parameterValues)
        {
            string sqlCommand = " INSERT INTO OBRASEMP.CONTRATO_ADELANTO( ";
            sqlCommand += " IDCONTRATO,ADELANTO_SEMANA,ADELANTO_FECHA,ADELANTO_NUMERO,ADELANTO_IMPORTE,TIPO_ADELANTO)";
            sqlCommand += " VALUES ( ";
            sqlCommand += (parameterValues[0].ToString().Length == 0 ? "null" : "'" + parameterValues[0].ToString() + "'") + ",";
            sqlCommand += (parameterValues[1].ToString().Length == 0 ? "null" : "week('" + parameterValues[1].ToString() + "',2)") + ",";
            sqlCommand += (parameterValues[1].ToString().Length == 0 ? "null" : "'" + parameterValues[1].ToString() + "'") + ","; ;
            sqlCommand += (parameterValues[2].ToString().Length == 0 ? "null" : "'" + parameterValues[2].ToString() + "'") + ",";
            sqlCommand += (parameterValues[3].ToString().Length == 0 ? "null" : "'" + parameterValues[3].ToString() + "'") + ",";
            sqlCommand += (parameterValues[4].ToString().Length == 0 ? "null" : "'" + parameterValues[4].ToString() + "'") + "); ";

            DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
            return "1";
        }
        #endregion

        #region UpdatedRowContratoAdelanto
        public static string UpdatedRowContratoAdelanto(string[] parameterValues, string IdContratoAdelanto)
        {
            string r = "";
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = " UPDATE OBRASEMP.CONTRATO_ADELANTO SET ";
            sqlCommand += " IDCONTRATO =" + (parameterValues[0].ToString().Length == 0 ? "0" : "'" + parameterValues[0].ToString() + "'") + ",";
            sqlCommand += " ADELANTO_SEMANA =" + (parameterValues[1].ToString().Length == 0 ? "0" : "week('" + parameterValues[1].ToString() + "',2)") + ",";
            sqlCommand += " ADELANTO_FECHA =" + (parameterValues[1].ToString().Length == 0 ? "0" : "'" + parameterValues[1].ToString() + "'") + ","; ;
            sqlCommand += " ADELANTO_NUMERO =" + (parameterValues[2].ToString().Length == 0 ? "0" : "'" + parameterValues[2].ToString() + "'") + ",";
            sqlCommand += " ADELANTO_IMPORTE =" + (parameterValues[3].ToString().Length == 0 ? "0" : "'" + parameterValues[3].ToString() + "'") + ",";
            sqlCommand += " TIPO_aDELANTO =" + (parameterValues[4].ToString().Length == 0 ? "0" : "'" + parameterValues[4].ToString() + "'") + " ";
            sqlCommand += " WHERE IDCONTRATOADELANTO=" + IdContratoAdelanto.ToString() + ";  SELECT 1 AS last_id_generate FROM DUAL; ";


            DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
            return "1";
        }
        #endregion

        #region DeletedRowContratoAdelanto
        public static string DeletedRowContratoAdelanto(string IdContratoSeguimiento)
        {
            string r = "";
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = " DELETE FROM  OBRASEMP.CONTRATO_ADELANTO  WHERE IDCONTRATOAdelanto='" + IdContratoSeguimiento + "' ;  SELECT 1 AS last_id_generate FROM DUAL; ";


            DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
            return "1";
        }
        #endregion

        #endregion


        #region ProyectoComponente

        #region SearchByProyectoComponente
        public static DataSet SearchByProyectoComponente(string IdProyecto)
        {
            DataSet ds1 = new DataSet();
            string StringSql = " SELECT ";
            StringSql += " A.IDPROYECTOCOMPONENTE,  A.TIPO_COMPONENTE, A.IDCOMPONENTE,b.abreviatura AS DESCRIPCION_COMPONENTE, A.NOMENCLATURA, A.IDESTADO_COMPONENTE,C.ABREVIATURA AS DESCRIPCION_ESTADO_COMPONENTE, A.FECHA_CONVOCATORIA, A.FECHA_ESTIMADA_BUENA_PRO, ";
            StringSql += " A.FECHA_CONSENTIMIENTO_BUENA_PRO, A.FECHA_ESTIMADA_CONTRATO, A.FECHA_ESTIMADA_INICIO, A.TIEMPO_EJECUCION, A.FECHA_ENTREGA_TERRENO ,A.ABREVIATURA ";
            StringSql += " FROM ";
            StringSql += " OBRASEMP.PROYECTO_COMPONENTE A,OBRASEMP.MAESTRO_DETALLE B,OBRASEMP.MAESTRO_DETALLE C, OBRASEMP.PROYECTO D";
            StringSql += " WHERE A.IDCOMPONENTE=B.idMaestro_Detalle AND A.idEstado_componente=C.IDMAESTRO_DETALLE AND A.IDPROYECTO=D.IDPROYECTO AND D.CUI= " + IdProyecto + " ";

            return InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(StringSql);
        }
        #endregion

        #region InsertRowProyectoComponente
        public static string InsertRowProyectoComponente(string[] parameterValues)
        {
            string r = "";
            Database db = DatabaseFactory.CreateDatabase();


            string sqlCommand =" ";
            sqlCommand += "  SELECT @pIdProyecto:=idproyecto FROM OBRASEMP.proyecto WHERE cui="+(parameterValues[0].ToString().Length == 0 ? "0" : "'" + parameterValues[0].ToString() + "'") +"; ";

            sqlCommand += " INSERT INTO OBRASEMP.PROYECTO_COMPONENTE (";
            sqlCommand += " IDPROYECTO, IDCOMPONENTE, IDESTADO_COMPONENTE,FECHA_CONVOCATORIA, FECHA_ESTIMADA_BUENA_PRO,";
            sqlCommand += " FECHA_CONSENTIMIENTO_BUENA_PRO, FECHA_ESTIMADA_CONTRATO, FECHA_ESTIMADA_INICIO, FECHA_ENTREGA_TERRENO, TIEMPO_EJECUCION, ABREVIATURA";
            sqlCommand += " ) VALUES (";
            sqlCommand += " @pIdProyecto ,";
            sqlCommand += " " + (parameterValues[1].ToString().Length == 0 ? "0" : "'" + parameterValues[1].ToString() + "'") + ",";
            sqlCommand += " " + (parameterValues[2].ToString().Length == 0 ? "0" : "'" + parameterValues[2].ToString() + "'") + ",";
            sqlCommand += " " + (parameterValues[3].ToString() == "NULL" ? "NULL" : "'" + parameterValues[3].ToString() + "'") + ","; ;
            sqlCommand += " " + (parameterValues[4].ToString() == "NULL" ? "NULL" : "'" + parameterValues[4].ToString() + "'") + ",";
            sqlCommand += " " + (parameterValues[5].ToString() == "NULL" ? "NULL" : "'" + parameterValues[5].ToString() + "'") + ",";
            sqlCommand += " " + (parameterValues[6].ToString() == "NULL" ? "NULL" : "'" + parameterValues[6].ToString() + "'") + ",";
            sqlCommand += " " + (parameterValues[7].ToString() == "NULL" ? "NULL" : "'" + parameterValues[7].ToString() + "'") + ",";
            sqlCommand += " " + (parameterValues[8].ToString() == "NULL" ? "NULL" : "'" + parameterValues[8].ToString() + "'") + ",";
            sqlCommand += " " + (parameterValues[9].ToString().Length == 0 ? "0" : "'" + parameterValues[9].ToString() + "'") + ", ";
            sqlCommand += " " + (parameterValues[10].ToString().Length == 0 ? "0" : "'" + parameterValues[10].ToString() + "'") + ") ";

             DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
            return "1";
        }
        #endregion

        #region UpdatedRowProyectoComponente
        public static string UpdatedRowProyectoComponente(string[] parameterValues, string pId)
        {
            string r = "";
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = " UPDATE OBRASEMP.PROYECTO_COMPONENTE SET ";
            if (parameterValues[1].ToString() != "NCN")
            {
                sqlCommand += " IDCOMPONENTE =" + (parameterValues[1].ToString().Length == 0 ? "0" : "'" + parameterValues[1].ToString() + "'") + ",";
            }
            if (parameterValues[2].ToString() != "NCN")
            {
                sqlCommand += " IDESTADO_COMPONENTE =" + (parameterValues[2].ToString().Length == 0 ? "0" : "'" + parameterValues[2].ToString() + "'") + ",";
            }
            sqlCommand += " FECHA_CONVOCATORIA =" +  parameterValues[3].ToString()  + ","; ;
            sqlCommand += " FECHA_ESTIMADA_BUENA_PRO ="  + parameterValues[4].ToString() + ",";
            sqlCommand += " FECHA_CONSENTIMIENTO_BUENA_PRO =" + parameterValues[5].ToString() + ",";
            sqlCommand += " FECHA_ESTIMADA_CONTRATO =" + parameterValues[6].ToString() +  ",";
            sqlCommand += " FECHA_ESTIMADA_INICIO =" +  parameterValues[7].ToString()  + ",";
            sqlCommand += " FECHA_ENTREGA_TERRENO =" +  parameterValues[8].ToString() + ",";
            sqlCommand += " TIEMPO_EJECUCION =" + "'" + parameterValues[9].ToString() + "', ";
            sqlCommand += " ABREVIATURA =" + "'" + parameterValues[10].ToString() + "' ";
            sqlCommand += " WHERE IDPROYECTOCOMPONENTE=" + pId.ToString() + ";  SELECT 1 AS last_id_generate FROM DUAL; ";

            DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
            return "1";
        }
        #endregion

        #endregion

        #region ProyectoContrato

        #region SearchByProyectoContrato
        public static DataSet SearchByProyectoContrato(string IdProyecto)
        {
            DataSet ds1 = new DataSet();
            string StringSql = " SELECT ";
            StringSql += " A.IDPROYECTOCOMPONENTE, A.IDCONTRATO, A.IDCOMPONENTE, A.CONTRATO_NUMERO,A.RUC, A.EMPRESA,A.RUC_SUPERVISOR,A.RAZON_SOCIAL_SUPERVISOR,A.PORCENTAJE_GANADOR,A.FECHA_CONTRATO,A.MONTO_OBRA, ";
            StringSql += " A.FECHA_ADELANTO_DIRECTO, A.FECHA_ADELANTO_DIRECTO_MAX, A.MONTO_ADELANTO_MATERIALES, A.FECHA_ADELANTO_MAXIMO_MATERIALES, ";
            StringSql += " A.FECHA_ADELANTO_INSTALACION, A.MONTO_ADELANTO_INSTALACION, A.FECHA_ADELANTO_MAXIMO_INSTALACION, A.FECHA_ENTREGA_TERRENO, ";
            StringSql += " A.FECHA_ENTREGA_TERRENO_LIMITE, A.FECHA_INICIO_OBRA, A.FECHA_INICIO_OBRA_MAXIMO, A.PLAZO_EJECUCION_OBRA, A.IDESTADO_CONTRATO, A.IDESTADO_CONTRATO, D.DESCRIPCION DESCRIPCION_ESTADO_CONTRATO,A.RUC_SUPERVISOR,A.RAZON_SOCIAL_SUPERVISOR";
            StringSql += " FROM OBRASEMP.CONTRATO A ";
            StringSql += " JOIN OBRASEMP.PROYECTO_COMPONENTE B ON A.idProyectoComponente=B.idProyectoComponente";
            StringSql += " JOIN OBRASEMP.PROYECTO C ON B.IDPROYECTO=C.IDPROYECTO ";
            StringSql += " LEFT JOIN OBRASEMP.MAESTRO_DETALLE D ON A.IDESTADO_CONTRATO= D.IDMAESTRO_DETALLE";
            StringSql += " WHERE A.idProyectoComponente=B.idProyectoComponente ";
            StringSql += " AND B.IDPROYECTO=C.IDPROYECTO AND C.CUI= " + IdProyecto + " ";

            return InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(StringSql);
        }
        #endregion

        #region SearchByProyectoContrato
        public static DataSet SearchByProyectoContrato(string IdProyecto, string IdPersona)
        {
            DataSet ds1 = new DataSet();
            string StringSql = " SELECT ";
            StringSql += " A.IDPROYECTOCOMPONENTE, A.IDCONTRATO, A.IDCOMPONENTE, A.CONTRATO_NUMERO,A.RUC, A.EMPRESA, A.FECHA_CONTRATO,A.MONTO_OBRA, ";
            StringSql += " A.FECHA_ADELANTO_DIRECTO, A.FECHA_ADELANTO_DIRECTO_MAX, A.MONTO_ADELANTO_MATERIALES, A.FECHA_ADELANTO_MAXIMO_MATERIALES, ";
            StringSql += " A.FECHA_ADELANTO_INSTALACION, A.MONTO_ADELANTO_INSTALACION, A.FECHA_ADELANTO_MAXIMO_INSTALACION, A.FECHA_ENTREGA_TERRENO, ";
            StringSql += " A.FECHA_ENTREGA_TERRENO_LIMITE, A.FECHA_INICIO_OBRA, A.FECHA_INICIO_OBRA_MAXIMO, A.PLAZO_EJECUCION_OBRA, A.IDESTADO_CONTRATO, A.IDESTADO_CONTRATO,C.CUI,C.DESCRIPCION, F.DESCRIPCION DESCRIPCION_ESTADO_CONTRATO, A.RUC_SUPERVISOR, A.RAZON_SOCIAL_SUPERVISOR "; ;
            StringSql += " FROM OBRASEMP.CONTRATO A ";
            StringSql += " JOIN OBRASEMP.PROYECTO_COMPONENTE B ";
            StringSql += " ON A.idProyectoComponente=B.idProyectoComponente "; 
            StringSql += " JOIN OBRASEMP.PROYECTO C ";
            StringSql += " ON B.IDPROYECTO=C.IDPROYECTO AND C.CUI= " + IdProyecto + " ";
            StringSql += " JOIN OBRASEMP.COORDINADOR_CONTRATO D ";
            StringSql += " ON A.IDCONTRATO=D.IDCONTRATO AND C.CUI=D.CUI ";
            StringSql += " JOIN OBRASEMP.PERSONA E";
            StringSql += " ON A.IDCONTRATO=D.IDCONTRATO ";
            StringSql += " LEFT JOIN OBRASEMP.MAESTRO_DETALLE F ON A.IDESTADO_CONTRATO= F.IDMAESTRO_DETALLE";
            StringSql += " WHERE  D.IDPERSONA=E.IDPERSONA AND  E.DOCUMENTO='" + IdPersona + "' ";

            return InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(StringSql);
        }
        #endregion
        public static DataSet SearchByProyectoContratoResumen(string IdProyecto, string IdPersona)
        {
            DataSet ds1 = new DataSet();
           /*string StringSql = " SELECT ";
            StringSql += " A.IDCONTRATOSEGUIMIENTO,A.SEGUIMIENTO_MES,A.SEGUIMIENTO_CRONOGRAMA,A.SEGUIMIENTO_FECHA,A.AVANCE AS AVANCE,A.APROBADO,FORMAT(A.MONTO,2) AS MONTO_OBRA, ";
            StringSql += " A.ADELANTO_DIRECTO,A.ADELANTO_MATERIALES FROM OBRASEMP.CONTRATO_SEGUIMIENTO_CON A,OBRASEMP.CONTRATO B, OBRASEMP.PROYECTO_COMPONENTE C, ";
            StringSql += " OBRASEMP.PROYECTO D WHERE A.IDCONTRATO = B.idcontrato AND B.idProyectoComponente = C.idProyectoComponente AND C.IDPROYECTO = D.IDPROYECTO ";
            StringSql += "  AND D.CUI = '"+IdProyecto+"' AND A.IDCONTRATO ='"+ IdPersona +"' ";*/

            /*  string StringSql = "SELECT";
              StringSql += " * FROM CONTRATO_SEGUIMIENTO_CON CS INNER JOIN  CONTRATO C ON CS.IDCONTRATO = C.idcontrato INNER JOIN CONTRATO_CRONOGRAMA CC ON CC.IDCONTRATO = C.idcontrato ";
              StringSql += "WHERE C.idcontrato = '"+ IdProyecto +"'";*/

            string StringSql = " SELECT ";
            StringSql += " A.IDCONTRATOSEGUIMIENTO,A.SEGUIMIENTO_MES,A.SEGUIMIENTO_CRONOGRAMA,A.SEGUIMIENTO_FECHA,A.AVANCE AS AVANCE,A.APROBADO,FORMAT(A.MONTO,2) AS MONTO_OBRA, ";
            StringSql += " A.ADELANTO_DIRECTO,A.ADELANTO_MATERIALES FROM OBRASEMP.CONTRATO_SEGUIMIENTO_CON A INNER JOIN OBRASEMP.CONTRATO B ON A.`IDCONTRATO`= B.`idcontrato` ";
            StringSql += " INNER JOIN OBRASEMP.PROYECTO_COMPONENTE C ON B.`idProyectoComponente` = C.`idProyectoComponente` ";
            StringSql += " INNER JOIN OBRASEMP.PROYECTO D ON C.`idproyecto` = D.`idProyecto`";
            StringSql += " CONTRATO_CRONOGRAMA E ON B.`idcontrato` = E.`IDCONTRATO`";
            StringSql += "  WHERE D.CUI = '" + IdProyecto + "' AND A.IDCONTRATO ='" + IdPersona + "' ";


            return InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(StringSql);
        }

        #region InsertProyectoContrato
        public static string InsertProyectoContrato(string[] parameterValues)
        {
            string r = "";
            Database db = DatabaseFactory.CreateDatabase();

            string sqlCommand = " ";


            sqlCommand += " INSERT INTO OBRASEMP.Contrato( ";
            sqlCommand += " IDPROYECTOCOMPONENTE, CONTRATO_NUMERO, RUC, EMPRESA, FECHA_CONTRATO, MONTO_OBRA, PLAZO_EJECUCION_OBRA, FECHA_INICIO_OBRA,FECHA_INICIO_OBRA_MAXIMO,FECHA_ADELANTO_DIRECTO,";	
            sqlCommand += " FECHA_ADELANTO_DIRECTO_MAX, MONTO_ADELANTO_MATERIALES,FECHA_ADELANTO_MAXIMO_MATERIALES,MONTO_ADELANTO_INSTALACION,";
            sqlCommand += " FECHA_ADELANTO_MAXIMO_INSTALACION,	FECHA_ENTREGA_TERRENO,FECHA_ENTREGA_TERRENO_LIMITE,IDESTADO_CONTRATO,IDCOMPONENTE,RUC_SUPERVISOR,RAZON_SOCIAL_SUPERVISOR,PORCENTAJE_GANADOR)";
            sqlCommand += " VALUES ( ";
            sqlCommand += (parameterValues[0].ToString().Length == 0 ? "null" : parameterValues[0].ToString()) + ",";
            sqlCommand += (parameterValues[1].ToString().Length == 0 ? "null" : "'" + parameterValues[1].ToString() + "'") + ",";
            sqlCommand += (parameterValues[2].ToString().Length == 0 ? "null" : "'" + parameterValues[2].ToString() + "'") + ",";
            sqlCommand += (parameterValues[3].ToString().Length == 0 ? "null" : "'" + parameterValues[3].ToString() + "'") + ",";
            sqlCommand += (parameterValues[4].ToString().Length == 0 ? "null" : "'" + parameterValues[4].ToString() + "'") + ",";
            sqlCommand += (parameterValues[5].ToString().Length == 0 ? "null" :  parameterValues[5].ToString() ) + ",";
            sqlCommand += (parameterValues[6].ToString().Length == 0 ? "null" : "'" + parameterValues[6].ToString() + "'") + ",";
            sqlCommand += (parameterValues[7].ToString().Length == 0 ? "null" : "'" + parameterValues[7].ToString() + "'") + ",";
            sqlCommand += (parameterValues[8].ToString().Length == 0 ? "null" : "'" + parameterValues[8].ToString() + "'") + ",";
            sqlCommand += (parameterValues[9].ToString().Length == 0 ? "null" : "'" + parameterValues[9].ToString() + "'") + ",";
            sqlCommand += (parameterValues[10].ToString().Length == 0 ? "null" : "'" + parameterValues[10].ToString() + "'") + ",";
            sqlCommand += (parameterValues[11].ToString().Length == 0 ? "null" : parameterValues[11].ToString()) + ",";
            sqlCommand += (parameterValues[12].ToString().Length == 0 ? "null" : "'" + parameterValues[12].ToString() + "'") + ",";
            sqlCommand += (parameterValues[13].ToString().Length == 0 ? "null" :  parameterValues[13].ToString()) + ",";
            sqlCommand += (parameterValues[14].ToString().Length == 0 ? "null" : "'" + parameterValues[14].ToString() + "'") + ",";
            sqlCommand += (parameterValues[15].ToString().Length == 0 ? "null" : "'" + parameterValues[15].ToString() + "'") + ",";
            sqlCommand += (parameterValues[16].ToString().Length == 0 ? "null" : "'" + parameterValues[16].ToString() + "'") + ",";
            sqlCommand += (parameterValues[18].ToString().Length == 0 ? "null" : "'" + parameterValues[18].ToString() + "'") + ",";
            sqlCommand += (parameterValues[17].ToString().Length == 0 ? "null" : parameterValues[17].ToString()) + ",";
            sqlCommand += (parameterValues[19].ToString().Length == 0 ? "null" : "'" + parameterValues[19].ToString() + "'") + ",";
            sqlCommand += (parameterValues[20].ToString().Length == 0 ? "null" : "'" + parameterValues[20].ToString() + "'") + ",";
            sqlCommand += (parameterValues[21].ToString().Length == 0 ? "null" : "'" + parameterValues[21].ToString() + "'") + ");";



            sqlCommand += (" select LAST_INSERT_ID() as last_id_generate from dual; ");

            DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
            return r;
        }
        #endregion

        #region UpdatedProyectoContrato
        public static string UpdatedProyectoContrato(string[] parameterValues)
        {
            string r = "";
            Database db = DatabaseFactory.CreateDatabase();

            string sqlCommand = " ";


            sqlCommand += " UPDATE OBRASEMP.Contrato  ";
            sqlCommand += " SET ";
            sqlCommand += " CONTRATO_NUMERO ="+(parameterValues[1].ToString().Length == 0 ? "null" : "'" + parameterValues[1].ToString() + "'") + ",";
            sqlCommand += " RUC=" + (parameterValues[2].ToString().Length == 0 ? "null" : "'" + parameterValues[2].ToString() + "'") + ",";
            sqlCommand += " EMPRESA="+(parameterValues[3].ToString().Length == 0 ? "null" : "'" + parameterValues[3].ToString() + "'") + ",";
            sqlCommand += " FECHA_CONTRATO="+(parameterValues[4].ToString().Length == 0 ? "null" : "'" + parameterValues[4].ToString() + "'") + ",";
            sqlCommand += " MONTO_OBRA="+(parameterValues[5].ToString().Length == 0 ? "null" : parameterValues[5].ToString()) + ",";
            sqlCommand += " PLAZO_EJECUCION_OBRA="+(parameterValues[6].ToString().Length == 0 ? "null" : "'" + parameterValues[6].ToString() + "'") + ",";
            sqlCommand += " FECHA_INICIO_OBRA="+(parameterValues[7].ToString().Length == 0 ? "null" : "'" + parameterValues[7].ToString() + "'") + ",";
            sqlCommand += " FECHA_INICIO_OBRA_MAXIMO="+(parameterValues[8].ToString().Length == 0 ? "null" : "'" + parameterValues[8].ToString() + "'") + ",";
            sqlCommand += " FECHA_ADELANTO_DIRECTO="+(parameterValues[9].ToString().Length == 0 ? "null" : "'" + parameterValues[9].ToString() + "'") + ",";
            sqlCommand += " FECHA_ADELANTO_DIRECTO_MAX="+(parameterValues[10].ToString().Length == 0 ? "null" : "'" + parameterValues[10].ToString() + "'") + ",";
            sqlCommand += " MONTO_ADELANTO_MATERIALES="+(parameterValues[11].ToString().Length == 0 ? "null" : parameterValues[11].ToString()) + ",";
            sqlCommand += " FECHA_ADELANTO_MAXIMO_MATERIALES="+(parameterValues[12].ToString().Length == 0 ? "null" : "'" + parameterValues[12].ToString() + "'") + ",";
            sqlCommand += " MONTO_ADELANTO_INSTALACION="+(parameterValues[13].ToString().Length == 0 ? "null" : parameterValues[13].ToString()) + ",";
            sqlCommand += " FECHA_ADELANTO_MAXIMO_INSTALACION="+(parameterValues[14].ToString().Length == 0 ? "null" : "'" + parameterValues[14].ToString() + "'") + ",";
            sqlCommand += " FECHA_ENTREGA_TERRENO="+(parameterValues[15].ToString().Length == 0 ? "null" : "'" + parameterValues[15].ToString() + "'") + ",";
            if (parameterValues[17].ToString() != "NCN")
            {
                sqlCommand += " IDESTADO_CONTRATO=" + parameterValues[17].ToString() + ",";
            }

            sqlCommand += " FECHA_ENTREGA_TERRENO_LIMITE ="+(parameterValues[16].ToString().Length == 0 ? "null" : "'" + parameterValues[16].ToString() + "'") + ", ";
            sqlCommand += " RUC_SUPERVISOR =" + (parameterValues[18].ToString().Length == 0 ? "null" : "'" + parameterValues[18].ToString() + "'") + ",";
            sqlCommand += " RAZON_SOCIAL_SUPERVISOR =" + (parameterValues[19].ToString().Length == 0 ? "null" : "'" + parameterValues[19].ToString() + "'") + ",";
            sqlCommand += " PORCENTAJE_GANADOR =" + (parameterValues[20].ToString().Length == 0 ? "null" : "'" + parameterValues[20].ToString() + "'") + " ";

            sqlCommand += " WHERE IDCONTRATO="+ (parameterValues[0].ToString().Length == 0 ? "null" : parameterValues[0].ToString()) + "; ";

            sqlCommand += (" select LAST_INSERT_ID() as last_id_generate from dual; ");

            DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
            return r;
        }
        #endregion

        #region DeletedRowProyectoContrato
        public static string DeletedRowProyectoContrato(string pId)
        {
            string r = "";
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = " DELETE FROM  OBRASEMP.CONTRATO WHERE IDCONTRATO=" + pId + " ;  SELECT 1 AS last_id_generate FROM DUAL; ";


            DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
            return "1";
        }
		#endregion


		#region Partida
		/*CAMBIO						FECHA			AUTOR
		SELECT PARTIDA					22-06-2021	    ALEXANDER FERNÁNDEZ 22-06-2021*/
		#region SearchByPartida
		public static DataSet SearchByPartida()
		{
            DataSet ds2 = new DataSet();
            string StringSql = "SELECT A.PAR_ID IDPARTIDA,A.PAR_NOMBRE,B.MED_CODIGO_UNIDAD PAR_MEDIDA ";
            StringSql += " FROM OBRASEMP.PARTIDA A";
            StringSql += " JOIN OBRASEMP.MEDIDA B ON A.PAR_MEDIDA_ID = B.MED_ID ";
			StringSql += " WHERE A.PAR_ESTADO = 2 ORDER BY A.PAR_NOMBRE";

			return InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(StringSql);
        }
		#endregion

		/*CAMBIO						FECHA			AUTOR
		INSERT PARTIDA					22-06-2021	    ALEXANDER FERNÁNDEZ 22-06-2021*/
		#region InsertRowPartida
		public static string InsertRowPartida(string[] parameterValues)
		{
            string sqlCommand = " INSERT INTO OBRASEMP.PARTIDA( ";
            sqlCommand += " PAR_NOMBRE,PAR_MEDIDA_ID)";
            sqlCommand += " VALUES ( ";
            sqlCommand += (parameterValues[0].ToString().Length == 0 ? "null" : "'" + parameterValues[0].ToString() + "'") + ",";
            sqlCommand += (parameterValues[1].ToString().Length == 0 ? "null" : "'" + parameterValues[1].ToString() + "'") + ");";            
            DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
            return "1";
        }
		#endregion


		/*CAMBIO						FECHA			AUTOR
		UPDATE PARTIDA					24-06-2021	    ALEXANDER FERNÁNDEZ 24-06-2021*/
		#region InsertRowPartida
		public static string UpdateRowPartida(string[] parameterValues,string IdPartida)
		{
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = " UPDATE OBRASEMP.PARTIDA SET ";			
			if (parameterValues[1].ToString() != "NCN")
            {
                sqlCommand += " PAR_MEDIDA_ID =" + (parameterValues[1].ToString().Length == 0 ? "0" : "'" + parameterValues[1].ToString() + "'") + ",";
            }
			sqlCommand += " PAR_NOMBRE =" + (parameterValues[0].ToString().Length == 0 ? "0" : "'" + parameterValues[0].ToString() + "'") + " ";
			sqlCommand += " WHERE PAR_ID =" + IdPartida.ToString() + ";  SELECT 1 AS last_id_generate FROM DUAL; ";
            DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
            return "1";
        }
		#endregion


		/*CAMBIO						FECHA			AUTOR
		DELETE PARTIDA					02-09-2021	    ALEXANDER FERNÁNDEZ 02-09-2021*/
		#region InsertRowPartida
		public static string DeleteRowPartida(string IdPartida)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sqlCommand = " UPDATE OBRASEMP.PARTIDA SET ";			
			sqlCommand += " PAR_ESTADO = -1 ";
			sqlCommand += " WHERE PAR_ID =" + IdPartida.ToString() + ";  SELECT 1 AS last_id_generate FROM DUAL; ";
			DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
			return "1";
		}
		#endregion
		#endregion

		#region ContratoPartida
		/*CAMBIO						FECHA			AUTOR
		SELECT CONTRATO PARTIDA			21-06-2021	    ALEXANDER FERNÁNDEZ 21-06-2021*/
		#region SearchByContratoPartida
		public static DataSet SearchByContratoPartida(string IdContrato)
		{
            DataSet ds2 = new DataSet();

            //string StringSql  = " SELECT A.CTP_ID IDCONTRATOPARTIDA,A.CTP_CODIGO,A.PAR_NOMBRE,A.PAR_PRECIO,A.PAR_CANTIDAD,A.PAR_MEDIDA,A.APROBADO,A.LEV1,A.LEV2";
            string StringSql = " SELECT A.CTP_ID IDCONTRATOPARTIDA,A.CTP_CODIGO,A.PAR_NOMBRE,A.PAR_PRECIO,A.PAR_CANTIDAD,A.PAR_MEDIDA,IF(A.PAR_CANTIDAD=0, 1, A.APROBADO) APROBADO";
            StringSql += " FROM OBRASEMP.VIEW_CONTRATO_PARTIDA02 A";
                    StringSql += " WHERE A.CTP_CONTRATO_ID ="+IdContrato + " AND A.CTP_ESTADO = 2 ORDER BY A.CTP_CODIGO";
            
            return InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(StringSql);
        }
        
        #endregion
        /*CAMBIO						FECHA			AUTOR
		INSERT CONTRATO PARTIDA			22-06-2021	    ALEXANDER FERNÁNDEZ 22-06-2021*/
        #region InsertRowContratoPartida
        public static string InsertRowContratoPartida(string[] parameterValues)
		{
			string sqlCommand = " INSERT INTO OBRASEMP.CONTRATO_PARTIDA( ";
			sqlCommand += " CTP_CONTRATO_ID,CTP_PARTIDA_ID,CTP_PRECIO,CTP_CANTIDAD,CTP_CODIGO)";
			sqlCommand += " VALUES ( ";
			sqlCommand += (parameterValues[0].ToString().Length == 0 ? "null" : "'" + parameterValues[0].ToString() + "'") + ",";
			sqlCommand += (parameterValues[1].ToString().Length == 0 ? "null" : "'" + parameterValues[1].ToString() + "'") + ",";
			sqlCommand += (parameterValues[2].ToString().Length == 0 ? "null" : "'" + parameterValues[2].ToString() + "'") + ",";
			sqlCommand += (parameterValues[3].ToString().Length == 0 ? "null" : "'" + parameterValues[3].ToString() + "'") + ",";
			sqlCommand += (parameterValues[4].ToString().Length == 0 ? "null" : "'" + parameterValues[4].ToString() + "'") + "); ";
			DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
			return "1";
		}
		#endregion

		/*CAMBIO						FECHA			AUTOR
		UPDATE CONTRATO PARTIDA			22-06-2021	    ALEXANDER FERNÁNDEZ 22-06-2021*/
		#region UpdateRowContratoPartida
		public static string UpdateRowContratoPartida(string[] parameterValues,string IdContratoPartida)
		{						
			Database db = DatabaseFactory.CreateDatabase();
			string sqlCommand = " UPDATE OBRASEMP.CONTRATO_PARTIDA SET ";
			sqlCommand += " CTP_CONTRATO_ID =" + (parameterValues[0].ToString().Length == 0 ? "0" : "'" + parameterValues[0].ToString() + "'") + ",";
			if (parameterValues[1].ToString() != "NCN")
			{
				sqlCommand += " CTP_PARTIDA_ID =" + (parameterValues[1].ToString().Length == 0 ? "0" : "'" + parameterValues[1].ToString() + "'") + ",";
			}			
			sqlCommand += " CTP_PRECIO =" + (parameterValues[2].ToString().Length == 0 ? "0" : "'" + parameterValues[2].ToString() + "'") + ",";
			sqlCommand += " CTP_CANTIDAD =" + (parameterValues[3].ToString().Length == 0 ? "0" : "'" + parameterValues[3].ToString() + "'") + ", ";
            sqlCommand += " CTP_CODIGO   =" + (parameterValues[4].ToString().Length == 0 ? "0" : "'" + parameterValues[4].ToString() + "'") + " ";
            sqlCommand += " WHERE CTP_ID =" + IdContratoPartida.ToString() + ";  SELECT 1 AS last_id_generate FROM DUAL; ";
			DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
			return "1";
		}

        public static string UpdateRowContratoPartidaAprobado(string[] parameterValues, string IdContratoPartida)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = " UPDATE OBRASEMP.CONTRATO_PARTIDA SET ";
            sqlCommand += " CTP_CONTRATO_ID =" + (parameterValues[0].ToString().Length == 0 ? "0" : "'" + parameterValues[0].ToString() + "'") + ",";
            sqlCommand += " CTP_APROBADO =" + (parameterValues[1].ToString().Length == 0 ? "0" : "'" + parameterValues[1].ToString() + "'") + " ";
            sqlCommand += " WHERE CTP_ID =" + IdContratoPartida.ToString() + ";  SELECT 1 AS last_id_generate FROM DUAL; ";
            DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
            return "1";
        }
		#endregion
		/*CAMBIO						FECHA			AUTOR
		DELETE CONTRATO PARTIDA			02-09-2021	    ALEXANDER FERNÁNDEZ 02-09-2021*/
		#region
		public static string DeleteRowContratoPartida(string IdContratoPartida)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sqlCommand = " UPDATE OBRASEMP.CONTRATO_PARTIDA SET ";
			sqlCommand += " CTP_ESTADO = -1 ";
			sqlCommand += " WHERE CTP_ID =" + IdContratoPartida.ToString() + ";  SELECT 1 AS last_id_generate FROM DUAL; ";
			DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
			return "1";
		}
	
		#endregion
		#endregion

		#region ContratoTipologia
		#region SearchAllContratoTipologia
		public static DataSet SearchAllContratoTipologia(string IdProyecto, string pIdContrato)
        {
            DataSet ds1 = new DataSet();
            string StringSql = "  ";
            StringSql += " SELECT A.IDCONTRATOTIPOLOGIA,A.IDTIPOLOGIA, E.TIPOLOGIA_DESCRIPCION ";
            StringSql += " FROM OBRASEMP.CONTRATO_TIPOLOGIA A, ";
            StringSql += " OBRASEMP.CONTRATO B, ";
            StringSql += " OBRASEMP.PROYECTO_COMPONENTE C, OBRASEMP.PROYECTO D, OBRASEMP.OBRA_CHECKLIST_TIPOLOGIA E ";
            StringSql += " WHERE ";
            StringSql += " A.IDCONTRATO=B.idcontrato AND ";
            StringSql += " B.idProyectoComponente=C.idProyectoComponente AND";
            StringSql += " C.IDPROYECTO=D.IDPROYECTO AND A.IDTIPOLOGIA=E.IDTIPOLOGIA AND  ";
            StringSql += " D.CUI= '" + IdProyecto + "' AND A.IDCONTRATO=" + pIdContrato + " ";


            return InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(StringSql);
        }
        #endregion

        #region InsertRowContratoTipologia
        public static string InsertRowContratoTipologia(string[] parameterValues)
        {
            string sqlCommand = " INSERT INTO OBRASEMP.CONTRATO_TIPOLOGIA( ";
            sqlCommand += " IDCONTRATO,IDTIPOLOGIA)";
            sqlCommand += " VALUES ( ";
            sqlCommand += (parameterValues[0].ToString().Length == 0 ? "null" : "'" + parameterValues[0].ToString() + "'") + ",";
            sqlCommand += (parameterValues[1].ToString().Length == 0 ? "null" : "'" + parameterValues[1].ToString() + "'") + "); ";
            DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
            return "1";
        }
        #endregion

        #region DeletedRowContratoTipologia
        public static string DeletedRowContratoTipologia(string pId)
        {
            string r = "";
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = " DELETE FROM  OBRASEMP.CONTRATO_TIPOLOGIA  WHERE IDCONTRATOTIPOLOGIA='" + pId + "' ;  SELECT 1 AS last_id_generate FROM DUAL; ";


            DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
            return "1";
        }
        #endregion

        #endregion
        #endregion

        /*CAMBIO						        FECHA			AUTOR
        UPDATE % UTILIDADES, GASTOS GENERALES 	02-07-2021	    ALEXANDER FERNÁNDEZ 02-07-2021*/
        #region
        public static string UpdateRowProyectoContrato02(string[] parametersValues, string IdContrato)
        {
            string sqlCommand = "UPDATE OBRASEMP.PROYECTO SET ";
                   sqlCommand += " PCGASTOS_GENERALES ="+ parametersValues[1]+ ", ";
                   sqlCommand += " PCUTILIDADES =" + parametersValues[0] + ", ";
				   sqlCommand += " PCGASTOS_OTROS =" + parametersValues[2] + ", ";
				   sqlCommand += " PCADELANTODIRECTO =" + parametersValues[3] + ", ";
				   sqlCommand += " PCADELANTOMATERIALES =" + parametersValues[4] + ", ";
				   sqlCommand += " PCADELANTOOTROS =" + parametersValues[5] + " ";
			sqlCommand += " WHERE CUI = "+ IdContrato +"; SELECT 1 AS last_id_generate FROM DUAL;";

            DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
            return "1";
        }
        #endregion

        #region
        public static DataSet SearchContratoById(string IdContrato) {

            DataSet ds1 = new DataSet();

            string StringSql = " SELECT *FROM OBRASEMP.PROYECTO ";
            StringSql += " WHERE CUI =" + IdContrato;
            return InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(StringSql);
        }
		#endregion



		#region ContratoReajuste
		/*CAMBIO						FECHA			AUTOR
		SELECT CONTRATOREAJUSTE			19-07-2021	    ALEXANDER FERNÁNDEZ 19-07-2021*/
		public static DataSet SearchByContratoReajuste(string IdContrato)
		{
			DataSet ds3 = new DataSet();

			string StringSql = " SELECT A.CPL_ID,A.CPL_POL_ID,B.POL_INDICE CPL_INDICE,A.CPL_FACTOR,A.CPL_INDICE_VALOR ";
			StringSql += " FROM OBRASEMP.CONTRATO_POLINOMICA A ";
			StringSql += " JOIN OBRASEMP.POLINOMICA B ON A.CPL_POL_ID = POL_ID ";
			StringSql += " WHERE A.CPL_CONTRATO_ID =" + IdContrato;

			return InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(StringSql);
		}

		/*CAMBIO						FECHA			AUTOR
		INSERT	CONTRATO REAJUSTE		19-07-2021	    ALEXANDER FERNÁNDEZ 19-07-2021*/		
		public static string InsertRowContratoReajuste(string[] parameterValues)
		{
			string sqlCommand = " INSERT INTO OBRASEMP.CONTRATO_POLINOMICA( ";
			sqlCommand += " CPL_CONTRATO_ID,CPL_POL_ID,CPL_FACTOR,CPL_INDICE_VALOR)";
			sqlCommand += " VALUES ( ";
			sqlCommand += (parameterValues[0].ToString().Length == 0 ? "null" : "'" + parameterValues[0].ToString() + "'") + ",";
			sqlCommand += (parameterValues[1].ToString().Length == 0 ? "null" : "'" + parameterValues[1].ToString() + "'") + ",";
			sqlCommand += (parameterValues[2].ToString().Length == 0 ? "null" : "'" + parameterValues[2].ToString() + "'") + ",";			
			sqlCommand += (parameterValues[3].ToString().Length == 0 ? "null" : "'" + parameterValues[3].ToString() + "'") + "); ";

			DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
			return "1";
		}
		
		/*CAMBIO						FECHA			AUTOR
		UPDATE	CONTRATO REAJUSTE		19-07-2021	    ALEXANDER FERNÁNDEZ 19-07-2021*/
		public static string UpdateRowContratoReajuste(string[] parameterValues, string IdContratoReajuste)
		{
			
			Database db = DatabaseFactory.CreateDatabase();
			string sqlCommand = " UPDATE OBRASEMP.CONTRATO_POLINOMICA SET ";	
		
			sqlCommand += " CPL_CONTRATO_ID =" + (parameterValues[0].ToString().Length == 0 ? "0" : "'" + parameterValues[0].ToString() + "'") + ",";
			if (parameterValues[1].ToString() != "NCN")
			{
				sqlCommand += " CPL_POL_ID =" + (parameterValues[1].ToString().Length == 0 ? "0" : "'" + parameterValues[1].ToString() + "'") + ",";
			}						
			sqlCommand += " CPL_FACTOR =" + (parameterValues[2].ToString().Length == 0 ? "0" : "'" + parameterValues[2].ToString() + "'") + ",";
			sqlCommand += " CPL_INDICE_VALOR =" + (parameterValues[3].ToString().Length == 0 ? "0" : "'" +parameterValues[3].ToString() + "'") + " ";
			sqlCommand += " WHERE CPL_ID =" + IdContratoReajuste.ToString() + "; SELECT 1 AS last_id_generate FROM DUAL; ";

			DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
			return "1";
		}
		#endregion



		#region Polinomica
		/*CAMBIO						FECHA			AUTOR
		SELECT POLINOMICA				19-07-2021	    ALEXANDER FERNÁNDEZ 19-07-2021*/
		public static DataSet SearchByPolinomica(string IdContrato)
		{
			DataSet ds3 = new DataSet();

			string StringSql = " SELECT *FROM OBRASEMP.POLINOMICA ";
			//StringSql += " WHERE CPL_CONTRATO_ID =" + IdContrato;

			return InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(StringSql);
		}

		/*CAMBIO						FECHA			AUTOR
		INSERT	POLINOMICA				19-07-2021	    ALEXANDER FERNÁNDEZ 19-07-2021*/
		public static string InsertRowPolinomica(string[] parameterValues)
		{
			string sqlCommand = " INSERT INTO OBRASEMP.POLINOMICA( ";
			sqlCommand += " POL_INDICE,POL_NOMBRE)";
			sqlCommand += " VALUES ( ";
			sqlCommand += (parameterValues[0].ToString().Length == 0 ? "null" : "'" + parameterValues[0].ToString() + "'") + ",";			
			sqlCommand += (parameterValues[1].ToString().Length == 0 ? "null" : "'" + parameterValues[1].ToString() + "'") + "); ";

			DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
			return "1";
		}

		/*CAMBIO						FECHA			AUTOR
		UPDATE	POLINOMICA				19-07-2021	    ALEXANDER FERNÁNDEZ 19-07-2021*/
		public static string UpdateRowPolinomica(string[] parameterValues, string IdPolinomica)
		{

			Database db = DatabaseFactory.CreateDatabase();


			string sqlCommand = " UPDATE OBRASEMP.POLINOMICA SET ";			
			sqlCommand += " POL_INDICE =" + (parameterValues[0].ToString().Length == 0 ? "0" : "'" + parameterValues[0].ToString() + "'") + ",";			
			sqlCommand += " POL_NOMBRE =" + (parameterValues[1].ToString().Length == 0 ? "0" : "'" + parameterValues[1].ToString() + "'") + " ";
			sqlCommand += " WHERE POL_ID =" + IdPolinomica.ToString() + "; SELECT 1 AS last_id_generate FROM DUAL; ";

			DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
			return "1";
		}
		#endregion

		#region
		/*CAMBIO						FECHA			AUTOR
		SELECT VALORIZACION POLINOMIVA	21-07-2021	    ALEXANDER FERNÁNDEZ 21-07-2021*/
		public static DataSet SearchByValorizacionPolinomica(string IdProyecto, string IdValorizacion)
		{
			DataSet ds1 = new DataSet();
			string StringSql = "  ";
			

			StringSql += " SELECT VAP.VAP_ID ,VAP.VAP_POL_ID,VAP.VAP_CONTRATO_ID,VAP.VAP_FACTOR,VAP.VAP_INDICE_VALOR,VAP.VAP_CANTIDAD,FORMAT(((VAP.VAP_CANTIDAD)/VAP.VAP_INDICE_VALOR)*VAP.VAP_FACTOR,3) VAP_TOTAL,POL.POL_INDICE,POL_NOMBRE";
			StringSql += " FROM OBRASEMP.VALORIZACION_POLINOMICA VAP ";
			StringSql += " JOIN OBRASEMP.POLINOMICA POL ON VAP.VAP_POL_ID = POL.POL_ID";		
			StringSql += " WHERE VAP.VAP_VAl_ID = " + IdValorizacion + "";
			//StringSql += " D.CUI= '" + IdProyecto + "' and A.IDCONTRATO=" + pIdContrato + " ";

			return InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(StringSql);
		}


		/*CAMBIO						FECHA			AUTOR
		UPDATE CONTRATO VALORIZACION	29-06-2021	    ALEXANDER FERNÁNDEZ 29-06-2021*/
		public static string UpdateRowValorizacionPolinomica(string[] parameterValues, string IdValorizacionPolinomica)
		{
			string r = "";
			Database db = DatabaseFactory.CreateDatabase();
			string sqlCommand = " UPDATE OBRASEMP.VALORIZACION_POLINOMICA SET ";						
			sqlCommand += " VAP_CANTIDAD =" + (parameterValues[0].ToString().Length == 0 ? "0" : "'" + parameterValues[0].ToString() + "'") + " ";
			sqlCommand += " WHERE VAP_ID=" + IdValorizacionPolinomica.ToString() + ";  SELECT 1 AS last_id_generate FROM DUAL; ";

			DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
			return "1";
		}


		public static string UpdateRowValorizacionPolinomica02(string[] parameterValues, string IdValorizacion)
		{
			string r = "";
			Database db = DatabaseFactory.CreateDatabase();
			string sqlCommand = " UPDATE OBRASEMP.CONTRATO_SEGUIMIENTO_CON SET ";
			sqlCommand += " FACTOR_K =" + (parameterValues[0].ToString().Length == 0 ? "0" : "'" + parameterValues[0].ToString() + "'") + " ";
			sqlCommand += " WHERE IDCONTRATOSEGUIMIENTO=" + IdValorizacion.ToString() + ";  SELECT 1 AS last_id_generate FROM DUAL; ";

			DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
			return "1";
		}


        /*CAMBIO							FECHA			AUTOR
		UPDATE	% DE AVANCE 02				22-07-2021	    ALEXANDER FERNÁNDEZ 22-07-2021*/
        public static string UpdateRowPorcentajeAvance(string[] parameterValues, int IdValorizacion,string ejecucion = "")
		{
            string AVANCE,MONTO;            

            if (ejecucion == "2")
            {
                AVANCE = "AVANCESUP =";
                MONTO = "MONTOSUP =";
            }
            else
            {
                AVANCE = "AVANCE =";
                MONTO = "MONTO =";
            }

			string r = "";
			Database db = DatabaseFactory.CreateDatabase();
			string sqlCommand = " UPDATE OBRASEMP.CONTRATO_SEGUIMIENTO_CON SET ";
			sqlCommand +=  AVANCE + (parameterValues[0].ToString().Length == 0 ? "0" : "'" + parameterValues[0].ToString() + "'") + ", ";
			sqlCommand += MONTO + (parameterValues[1].ToString().Length == 0 ? "0" : "'" + parameterValues[1].ToString() + "'") + " ";
			sqlCommand += " WHERE IDCONTRATOSEGUIMIENTO=" + IdValorizacion.ToString() + ";  SELECT 1 AS last_id_generate FROM DUAL; ";

			DataSet df = InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(sqlCommand);
			return "1";
		}        
        #endregion

        /*
		RESUMEN DE VALORIZACION - ALEXANDER FERNANDEZ 26-08-2021*/
        #region
        public static DataSet SearchResumenValorizacion(string IdProyecto, string IdContrato, int IdValorizacion, string ejecucion)
		{
			DataSet ds1 = new DataSet();
			string StringSql = "  ";
            string AVANCE, MONTO,SUMMONTO;

            if (ejecucion == "2")
            {
                AVANCE = "AVANCESUP AS AVANCE";
                MONTO = "MONTOSUP AS MONTO";
                SUMMONTO = "SUM(MONTOSUP) MONTO";
            }
            else
            {
                AVANCE = "AVANCE AS AVANCE";
                MONTO = "MONTO AS MONTO";
                SUMMONTO = "SUM(MONTO) MONTO";
            }

            StringSql += " SELECT A.AVANCE VALORIZACION_ACUMULADA_PORCENTAJE,A.MONTO VALORIZACION_ACTUAL, A.ADELANTO_DIRECTO ADELANTO_DIRECTO_ACTUAL, A.ADELANTO_MATERIALES ADELANTO_MATERIALES_ACTUAL, ";
			StringSql += " IFNULL(B.MONTO,0) VALORIZACION_ANTERIOR, IFNULL(B.ADELANTO_DIRECTO,0) ADELANTO_DIRECTO_ANTERIOR, IFNULL(B.ADELANTO_MATERIALES,0) ADELANTO_MATERIALES_ANTERIOR FROM ";
			StringSql += " (SELECT IDCONTRATO,"+ AVANCE +","+ MONTO + ", ADELANTO_DIRECTO, ADELANTO_MATERIALES FROM OBRASEMP.CONTRATO_SEGUIMIENTO_CON WHERE IDCONTRATOSEGUIMIENTO = "+ IdValorizacion + ") A LEFT JOIN ";
			StringSql += " (SELECT IDCONTRATO,"+ SUMMONTO + ", SUM(ADELANTO_DIRECTO) ADELANTO_DIRECTO, SUM(ADELANTO_MATERIALES) ADELANTO_MATERIALES FROM "; 
			StringSql += " OBRASEMP.CONTRATO_SEGUIMIENTO_CON WHERE IDCONTRATO = " + IdContrato + " AND IDCONTRATOSEGUIMIENTO < "+ IdValorizacion + " GROUP BY IDCONTRATO) B ON A.IDCONTRATO = B.IDCONTRATO ";

			return InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(StringSql);
		}
		#endregion

		public static DataSet SearchByProyectoContratoCronograma02(string IdProyecto, string pIdContrato, string pIdValorizacion,string pEjecucion = "")
		{
			DataSet ds1 = new DataSet();
			string StringSql = "  ";
            string AVANCE;

            AVANCE = (pEjecucion == "2") ? "AVANCESUP AS AVANCE" : "AVANCE AS AVANCE";
            StringSql += " SELECT A.SEGUIMIENTO_FECHA,A.AVANCE AVANCE_VALORIZACION,B.CRONOGRAMA_FECHA,B.AVANCE AVANCE_CRONOGRAMA FROM ";
            StringSql += " (SELECT " + AVANCE + ",SEGUIMIENTO_FECHA,SEGUIMIENTO_CRONOGRAMA FROM OBRASEMP.CONTRATO_SEGUIMIENTO_CON WHERE IDCONTRATO = " + pIdContrato + " AND IDCONTRATOSEGUIMIENTO <=" + pIdValorizacion + ") A ";
            StringSql += " RIGHT JOIN(SELECT AVANCE,CRONOGRAMA_FECHA,CRONOGRAMA FROM OBRASEMP.CONTRATO_CRONOGRAMA WHERE IDCONTRATO = " + pIdContrato + ") B ";
            StringSql += " ON A.`SEGUIMIENTO_CRONOGRAMA` = B.`CRONOGRAMA` ";

            return InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(StringSql);
		}
        public static DataSet SearchByProyectoContratoCronograma03(string IdProyecto, string pIdContrato, string pIdValorizacion, string pEjecucion = "")
        {
            DataSet ds1 = new DataSet();
            string StringSql = "  ";
            string AVANCE,MONTO;

            AVANCE = (pEjecucion == "2") ? "AVANCESUP AS AVANCE" : "AVANCE AS AVANCE";
            MONTO = (pEjecucion == "2") ? "MONTOSUP AS MONTOVALORIZACION" : "MONTO AS MONTOVALORIZACION";
            StringSql += " SELECT A.SEGUIMIENTO_FECHA,A.AVANCE AVANCE_VALORIZACION,A.MONTOVALORIZACION,B.CRONOGRAMA_FECHA,B.AVANCE AVANCE_CRONOGRAMA,(C.MONTO_OBRA*(B.AVANCE/100)) AS MONTO_OBRA FROM ";
            StringSql += " (SELECT " + AVANCE + "," +MONTO+ ",SEGUIMIENTO_FECHA,SEGUIMIENTO_CRONOGRAMA FROM OBRASEMP.CONTRATO_SEGUIMIENTO_CON WHERE IDCONTRATO = " + pIdContrato + " AND IDCONTRATOSEGUIMIENTO <=" + pIdValorizacion + ") A ";
            StringSql += " RIGHT JOIN(SELECT IDCONTRATO,AVANCE,CRONOGRAMA_FECHA,CRONOGRAMA FROM OBRASEMP.CONTRATO_CRONOGRAMA WHERE IDCONTRATO = " + pIdContrato + ") B ";
            StringSql += " RIGHT JOIN(SELECT IDCONTRATO,MONTO_OBRA FROM OBRASEMP.CONTRATO WHERE IDCONTRATO = 109) C ON C.IDCONTRATO = B.IDCONTRATO";
            StringSql += " ON A.`SEGUIMIENTO_CRONOGRAMA` = B.`CRONOGRAMA` ";

            return InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(StringSql);
        }

    }
}