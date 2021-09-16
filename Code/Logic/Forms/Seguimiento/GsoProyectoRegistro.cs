using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace InfogesEmape.Code.Logic.Forms.Seguimiento
{
	public class GsoProyectoRegistro
	{

		#region SearchByProyecto
		public static DataSet SearchByProyecto(string pIdProyecto)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyecto(pIdProyecto);
		}
		#endregion

		#region InsertProyecto
		public static string InsertProyecto(string[] parameterValues)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.InsertProyecto(parameterValues);
		}
		#endregion

		#region UpdatedProyecto
		public static string UpdatedProyecto(string[] parameterValues, string IdProyecto)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.UpdatedProyecto(parameterValues, IdProyecto);
		}
		#endregion

		#region ProyectoMeta

		#region SearchByProyectoMeta
		public static DataSet SearchByProyectoMeta(string pIdProyecto)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoMeta(pIdProyecto);
		}
		#endregion

		#region InsertRowProyectoMeta
		public static string InsertRowProyectoMeta(string[] parameterValues)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.InsertRowProyectoMeta(parameterValues);
		}
		#endregion

		#region UpdatedRowProyectoMeta
		public static string UpdatedRowProyectoMeta(string[] parameterValues, string pId)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.UpdatedRowProyectoMeta(parameterValues, pId);
		}
		#endregion

		#endregion

		#region ProyectoComponente

		#region SearchByProyectoComponente
		public static DataSet SearchByProyectoComponente(string pIdProyecto)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoComponente(pIdProyecto);
		}
		#endregion

		#region InsertRowProyectoComponente
		public static string InsertRowProyectoComponente(string[] parameterValues)
		{
			string s1 = "", s2 = "", s3 = "";

			if (parameterValues[3].Length == 10)
			{
				s1 = "" + parameterValues[3].Substring(0, parameterValues[3].ToString().IndexOf("/"));
				s2 = "" + parameterValues[3].Substring(parameterValues[3].ToString().IndexOf("/") + 1, 2);
				s3 = "" + parameterValues[3].Substring(parameterValues[3].ToString().IndexOf("/") + 4, 4);
				if (s1.Length > 0)
					parameterValues[3] = s3 + "-" + s2 + "-" + s1;
			}
			else
				parameterValues[3] = "NULL";

			if (parameterValues[4].Length == 10)
			{
				s1 = "" + parameterValues[4].Substring(0, parameterValues[4].ToString().IndexOf("/"));
				s2 = "" + parameterValues[4].Substring(parameterValues[4].ToString().IndexOf("/") + 1, 2);
				s3 = "" + parameterValues[4].Substring(parameterValues[4].ToString().IndexOf("/") + 4, 4);
				if (s1.Length > 0)
					parameterValues[4] = s3 + "-" + s2 + "-" + s1;
			}
			else
				parameterValues[4] = "NULL";


			if (parameterValues[5].Length == 10)
			{
				s1 = "" + parameterValues[5].Substring(0, parameterValues[5].ToString().IndexOf("/"));
				s2 = "" + parameterValues[5].Substring(parameterValues[5].ToString().IndexOf("/") + 1, 2);
				s3 = "" + parameterValues[5].Substring(parameterValues[5].ToString().IndexOf("/") + 4, 4);
				if (s1.Length > 0)
					parameterValues[5] = s3 + "-" + s2 + "-" + s1;
			}
			else
				parameterValues[5] = "NULL";


			if (parameterValues[6].Length == 10)
			{
				s1 = "" + parameterValues[6].Substring(0, parameterValues[6].ToString().IndexOf("/"));
				s2 = "" + parameterValues[6].Substring(parameterValues[6].ToString().IndexOf("/") + 1, 2);
				s3 = "" + parameterValues[6].Substring(parameterValues[6].ToString().IndexOf("/") + 4, 4);
				if (s1.Length > 0)
					parameterValues[6] = s3 + "-" + s2 + "-" + s1;
			}
			else
				parameterValues[6] = "NULL";


			if (parameterValues[7].Length == 10)
			{
				s1 = "" + parameterValues[7].Substring(0, parameterValues[7].ToString().IndexOf("/"));
				s2 = "" + parameterValues[7].Substring(parameterValues[7].ToString().IndexOf("/") + 1, 2);
				s3 = "" + parameterValues[7].Substring(parameterValues[7].ToString().IndexOf("/") + 4, 4);
				if (s1.Length > 0)
					parameterValues[7] = s3 + "-" + s2 + "-" + s1;
			}
			else
				parameterValues[7] = "NULL";


			if (parameterValues[8].Length == 10)
			{
				s1 = "" + parameterValues[8].Substring(0, parameterValues[8].ToString().IndexOf("/"));
				s2 = "" + parameterValues[8].Substring(parameterValues[8].ToString().IndexOf("/") + 1, 2);
				s3 = "" + parameterValues[8].Substring(parameterValues[8].ToString().IndexOf("/") + 4, 4);
				if (s1.Length > 0)
					parameterValues[8] = s3 + "-" + s2 + "-" + s1;
			}
			else
				parameterValues[8] = "NULL";

			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.InsertRowProyectoComponente(parameterValues);
		}
		#endregion

		#region UpdatedRowProyectoComponente
		public static string UpdatedRowProyectoComponente(string[] parameterValues, string pId)
		{
			string s1 = "", s2 = "", s3 = "";

			if (parameterValues[3].Length == 10)
			{
				s1 = "" + parameterValues[3].Substring(0, parameterValues[3].ToString().IndexOf("/"));
				s2 = "" + parameterValues[3].Substring(parameterValues[3].ToString().IndexOf("/") + 1, 2);
				s3 = "" + parameterValues[3].Substring(parameterValues[3].ToString().IndexOf("/") + 4, 4);
				if (s1.Length > 0)
					parameterValues[3] = "'" + s3 + "-" + s2 + "-" + s1 + "'";
			}
			else
				parameterValues[3] = "NULL";

			if (parameterValues[4].Length == 10)
			{
				s1 = "" + parameterValues[4].Substring(0, parameterValues[4].ToString().IndexOf("/"));
				s2 = "" + parameterValues[4].Substring(parameterValues[4].ToString().IndexOf("/") + 1, 2);
				s3 = "" + parameterValues[4].Substring(parameterValues[4].ToString().IndexOf("/") + 4, 4);
				if (s1.Length > 0)
					parameterValues[4] = "'" + s3 + "-" + s2 + "-" + s1 + "'";
			}
			else
				parameterValues[4] = "NULL";


			if (parameterValues[5].Length == 10)
			{
				s1 = "" + parameterValues[5].Substring(0, parameterValues[5].ToString().IndexOf("/"));
				s2 = "" + parameterValues[5].Substring(parameterValues[5].ToString().IndexOf("/") + 1, 2);
				s3 = "" + parameterValues[5].Substring(parameterValues[5].ToString().IndexOf("/") + 4, 4);
				if (s1.Length > 0)
					parameterValues[5] = "'" + s3 + "-" + s2 + "-" + s1 + "'";
			}
			else
				parameterValues[5] = "NULL";


			if (parameterValues[6].Length == 10)
			{
				s1 = "" + parameterValues[6].Substring(0, parameterValues[6].ToString().IndexOf("/"));
				s2 = "" + parameterValues[6].Substring(parameterValues[6].ToString().IndexOf("/") + 1, 2);
				s3 = "" + parameterValues[6].Substring(parameterValues[6].ToString().IndexOf("/") + 4, 4);
				if (s1.Length > 0)
					parameterValues[6] = "'" + s3 + "-" + s2 + "-" + s1 + "'";
			}
			else
				parameterValues[6] = "NULL";


			if (parameterValues[7].Length == 10)
			{
				s1 = "" + parameterValues[7].Substring(0, parameterValues[7].ToString().IndexOf("/"));
				s2 = "" + parameterValues[7].Substring(parameterValues[7].ToString().IndexOf("/") + 1, 2);
				s3 = "" + parameterValues[7].Substring(parameterValues[7].ToString().IndexOf("/") + 4, 4);
				if (s1.Length > 0)
					parameterValues[7] = "'" + s3 + "-" + s2 + "-" + s1 + "'";
			}
			else
				parameterValues[7] = "NULL";


			if (parameterValues[8].Length == 10)
			{
				s1 = "" + parameterValues[8].Substring(0, parameterValues[8].ToString().IndexOf("/"));
				s2 = "" + parameterValues[8].Substring(parameterValues[8].ToString().IndexOf("/") + 1, 2);
				s3 = "" + parameterValues[8].Substring(parameterValues[8].ToString().IndexOf("/") + 4, 4);
				if (s1.Length > 0)
					parameterValues[8] = "'" + s3 + "-" + s2 + "-" + s1 + "'";
			}
			else
				parameterValues[8] = "NULL";

			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.UpdatedRowProyectoComponente(parameterValues, pId);
		}
		#endregion

		#endregion

		#region ProyectoContrato

		#region SearchByProyectoContrato
		public static DataSet SearchByProyectoContrato(string pIdProyecto)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContrato(pIdProyecto);
		}
		#endregion

		#region SearchByProyectoContratoPersona
		public static DataSet SearchByProyectoContrato(string pIdProyecto, string pIdPersona)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContrato(pIdProyecto, pIdPersona);
		}
		#endregion

		#region InsertProyectoContrato
		public static string InsertProyectoContrato(string[] parameterValues)
		{
			string s1 = "", s2 = "", s3 = "";

			if (parameterValues[4].Length >= 10)
			{
				s1 = "" + parameterValues[4].Substring(0, parameterValues[4].ToString().IndexOf("/"));
				s2 = "" + parameterValues[4].Substring(parameterValues[4].ToString().IndexOf("/") + 1, 2);
				s3 = "" + parameterValues[4].Substring(parameterValues[4].ToString().IndexOf("/") + 4, 4);
				if (s1.Length > 0)
					parameterValues[4] = s3 + "-" + s2 + "-" + s1;
			}
			else
				parameterValues[4] = "";

			if (parameterValues[7].Length >= 10)
			{
				s1 = "" + parameterValues[7].Substring(0, parameterValues[7].ToString().IndexOf("/"));
				s2 = "" + parameterValues[7].Substring(parameterValues[7].ToString().IndexOf("/") + 1, 2);
				s3 = "" + parameterValues[7].Substring(parameterValues[7].ToString().IndexOf("/") + 4, 4);
				if (s1.Length > 0)
					parameterValues[7] = s3 + "-" + s2 + "-" + s1;
			}
			else
				parameterValues[7] = "";



			if (parameterValues[8].Length >= 10)
			{
				s1 = "" + parameterValues[8].Substring(0, parameterValues[8].ToString().IndexOf("/"));
				s2 = "" + parameterValues[8].Substring(parameterValues[8].ToString().IndexOf("/") + 1, 2);
				s3 = "" + parameterValues[8].Substring(parameterValues[8].ToString().IndexOf("/") + 4, 4);
				if (s1.Length > 0)
					parameterValues[8] = s3 + "-" + s2 + "-" + s1;
			}
			else
				parameterValues[8] = "";


			if (parameterValues[9].Length >= 10)
			{
				s1 = "" + parameterValues[9].Substring(0, parameterValues[9].ToString().IndexOf("/"));
				s2 = "" + parameterValues[9].Substring(parameterValues[9].ToString().IndexOf("/") + 1, 2);
				s3 = "" + parameterValues[9].Substring(parameterValues[9].ToString().IndexOf("/") + 4, 4);
				if (s1.Length > 0)
					parameterValues[9] = s3 + "-" + s2 + "-" + s1;
			}
			else
				parameterValues[9] = "";


			//if (parameterValues[10].Length >= 10)
			//{
			//    s1 = "" + parameterValues[10].Substring(0, parameterValues[10].ToString().IndexOf("/"));
			//    s2 = "" + parameterValues[10].Substring(parameterValues[10].ToString().IndexOf("/") + 1, 2);
			//    s3 = "" + parameterValues[10].Substring(parameterValues[10].ToString().IndexOf("/") + 4, 4);
			//    if (s1.Length > 0)
			//        parameterValues[10] = s3 + "-" + s2 + "-" + s1;
			//}
			//else
			//    parameterValues[10] = "";


			//if (parameterValues[12].Length >= 10)
			//{
			//    s1 = "" + parameterValues[12].Substring(0, parameterValues[12].ToString().IndexOf("/"));
			//    s2 = "" + parameterValues[12].Substring(parameterValues[12].ToString().IndexOf("/") + 1, 2);
			//    s3 = "" + parameterValues[12].Substring(parameterValues[12].ToString().IndexOf("/") + 4, 4);
			//    if (s1.Length > 0)
			//        parameterValues[12] = s3 + "-" + s2 + "-" + s1;
			//}
			//else
			//    parameterValues[12] = "";



			//if (parameterValues[14].Length >= 10)
			//{
			//    s1 = "" + parameterValues[14].Substring(0, parameterValues[14].ToString().IndexOf("/"));
			//    s2 = "" + parameterValues[14].Substring(parameterValues[14].ToString().IndexOf("/") + 1, 2);
			//    s3 = "" + parameterValues[14].Substring(parameterValues[14].ToString().IndexOf("/") + 4, 4);
			//    if (s1.Length > 0)
			//        parameterValues[14] = s3 + "-" + s2 + "-" + s1;
			//}
			//else
			//    parameterValues[14] = "";


			if (parameterValues[15].Length >= 10)
			{
				s1 = "" + parameterValues[15].Substring(0, parameterValues[15].ToString().IndexOf("/"));
				s2 = "" + parameterValues[15].Substring(parameterValues[15].ToString().IndexOf("/") + 1, 2);
				s3 = "" + parameterValues[15].Substring(parameterValues[15].ToString().IndexOf("/") + 4, 4);
				if (s1.Length > 0)
					parameterValues[15] = s3 + "-" + s2 + "-" + s1;
			}
			else
				parameterValues[15] = "";


			//if (parameterValues[16].Length >= 10)
			//{
			//    s1 = "" + parameterValues[16].Substring(0, parameterValues[16].ToString().IndexOf("/"));
			//    s2 = "" + parameterValues[16].Substring(parameterValues[16].ToString().IndexOf("/") + 1, 2);
			//    s3 = "" + parameterValues[16].Substring(parameterValues[16].ToString().IndexOf("/") + 4, 4);
			//    if (s1.Length > 0)
			//        parameterValues[16] = s3 + "-" + s2 + "-" + s1;
			//}
			//else
			//    parameterValues[16] = "";

			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.InsertProyectoContrato(parameterValues);
		}
		#endregion

		#region UpdatedProyectoContrato
		public static string UpdatedProyectoContrato(string[] parameterValues)
		{


			string s1 = "", s2 = "", s3 = "";

			if (parameterValues[4].Length >= 10)
			{
				s1 = "" + parameterValues[4].Substring(0, parameterValues[4].ToString().IndexOf("/"));
				s2 = "" + parameterValues[4].Substring(parameterValues[4].ToString().IndexOf("/") + 1, 2);
				s3 = "" + parameterValues[4].Substring(parameterValues[4].ToString().IndexOf("/") + 4, 4);
				if (s1.Length > 0)
					parameterValues[4] = s3 + "-" + s2 + "-" + s1;
			}
			else
				parameterValues[4] = "";

			if (parameterValues[7].Length >= 10)
			{
				s1 = "" + parameterValues[7].Substring(0, parameterValues[7].ToString().IndexOf("/"));
				s2 = "" + parameterValues[7].Substring(parameterValues[7].ToString().IndexOf("/") + 1, 2);
				s3 = "" + parameterValues[7].Substring(parameterValues[7].ToString().IndexOf("/") + 4, 4);
				if (s1.Length > 0)
					parameterValues[7] = s3 + "-" + s2 + "-" + s1;
			}
			else
				parameterValues[7] = "";


			if (parameterValues[8].Length >= 10)
			{
				s1 = "" + parameterValues[8].Substring(0, parameterValues[8].ToString().IndexOf("/"));
				s2 = "" + parameterValues[8].Substring(parameterValues[8].ToString().IndexOf("/") + 1, 2);
				s3 = "" + parameterValues[8].Substring(parameterValues[8].ToString().IndexOf("/") + 4, 4);
				if (s1.Length > 0)
					parameterValues[8] = s3 + "-" + s2 + "-" + s1;
			}
			else
				parameterValues[8] = "";


			if (parameterValues[9].Length >= 10)
			{
				s1 = "" + parameterValues[9].Substring(0, parameterValues[9].ToString().IndexOf("/"));
				s2 = "" + parameterValues[9].Substring(parameterValues[9].ToString().IndexOf("/") + 1, 2);
				s3 = "" + parameterValues[9].Substring(parameterValues[9].ToString().IndexOf("/") + 4, 4);
				if (s1.Length > 0)
					parameterValues[9] = s3 + "-" + s2 + "-" + s1;
			}
			else
				parameterValues[9] = "";


			//if (parameterValues[10].Length >= 10)
			//{
			//    s1 = "" + parameterValues[10].Substring(0, parameterValues[10].ToString().IndexOf("/"));
			//    s2 = "" + parameterValues[10].Substring(parameterValues[10].ToString().IndexOf("/") + 1, 2);
			//    s3 = "" + parameterValues[10].Substring(parameterValues[10].ToString().IndexOf("/") + 4, 4);
			//    if (s1.Length > 0)
			//        parameterValues[10] = s3 + "-" + s2 + "-" + s1;
			//}
			//else
			//    parameterValues[10] = "";


			//if (parameterValues[12].Length >= 10)
			//{
			//    s1 = "" + parameterValues[12].Substring(0, parameterValues[12].ToString().IndexOf("/"));
			//    s2 = "" + parameterValues[12].Substring(parameterValues[12].ToString().IndexOf("/") + 1, 2);
			//    s3 = "" + parameterValues[12].Substring(parameterValues[12].ToString().IndexOf("/") + 4, 4);
			//    if (s1.Length > 0)
			//        parameterValues[12] = s3 + "-" + s2 + "-" + s1;
			//}
			//else
			//    parameterValues[12] = "";



			//if (parameterValues[14].Length >= 10)
			//{
			//    s1 = "" + parameterValues[14].Substring(0, parameterValues[14].ToString().IndexOf("/"));
			//    s2 = "" + parameterValues[14].Substring(parameterValues[14].ToString().IndexOf("/") + 1, 2);
			//    s3 = "" + parameterValues[14].Substring(parameterValues[14].ToString().IndexOf("/") + 4, 4);
			//    if (s1.Length > 0)
			//        parameterValues[14] = s3 + "-" + s2 + "-" + s1;
			//}
			//else
			//    parameterValues[14] = "";


			if (parameterValues[15].Length >= 10)
			{
				s1 = "" + parameterValues[15].Substring(0, parameterValues[15].ToString().IndexOf("/"));
				s2 = "" + parameterValues[15].Substring(parameterValues[15].ToString().IndexOf("/") + 1, 2);
				s3 = "" + parameterValues[15].Substring(parameterValues[15].ToString().IndexOf("/") + 4, 4);
				if (s1.Length > 0)
					parameterValues[15] = s3 + "-" + s2 + "-" + s1;
			}
			else
				parameterValues[15] = "";


			//if (parameterValues[16].Length >= 10)
			//{
			//    s1 = "" + parameterValues[16].Substring(0, parameterValues[16].ToString().IndexOf("/"));
			//    s2 = "" + parameterValues[16].Substring(parameterValues[16].ToString().IndexOf("/") + 1, 2);
			//    s3 = "" + parameterValues[16].Substring(parameterValues[16].ToString().IndexOf("/") + 4, 4);
			//    if (s1.Length > 0)
			//        parameterValues[16] = s3 + "-" + s2 + "-" + s1;
			//}
			//else
			//    parameterValues[16] = "";

			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.UpdatedProyectoContrato(parameterValues);
		}
		#endregion

		#region DeletedRowProyectoContrato
		public static string DeletedRowProyectoContrato(string pId)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.DeletedRowProyectoContrato(pId);
		}
		#endregion

		#endregion



		#region Partida
		/*CAMBIO						FECHA			AUTOR
		SELECT PARTIDA					22-06-2021	    ALEXANDER FERNÁNDEZ 22-06-2021*/
		#region SearchByPartida
		public static DataSet SearchByPartida()
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.SearchByPartida();
		}
		#endregion

		/*CAMBIO						FECHA			AUTOR
		INSERT PARTIDA					22-06-2021	    ALEXANDER FERNÁNDEZ 22-06-2021*/
		#region InsertRowPartida
		public static string InsertRowPartida(string[] parameterValues)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.InsertRowPartida(parameterValues);
		}
		#endregion

		/*CAMBIO						FECHA			AUTOR
		UPDATE PARTIDA					24-06-2021	    ALEXANDER FERNÁNDEZ 24-06-2021*/
		#region InsertRowPartida
		public static string UpdateRowPartida(string[] parameterValues, string IdPartida)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.UpdateRowPartida(parameterValues, IdPartida);
		}
		#endregion

		/*CAMBIO						FECHA			AUTOR
		DELETE PARTIDA					02-09-2021	    ALEXANDER FERNÁNDEZ 02-09-2021*/
		#region InsertRowPartida
		public static string DeleteRowPartida(string IdPartida)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.DeleteRowPartida(IdPartida);
		}
		#endregion
		#endregion

		#region ContratoPartida
		/*CAMBIO						FECHA			AUTOR
		SELECT CONTRATO PARTIDA			21-06-2021	    ALEXANDER FERNÁNDEZ 21-06-2021*/
		#region SearchByContratoPartida
		public static DataSet SearchByContratoPartida(string IdContrato)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.SearchByContratoPartida(IdContrato);
		}        
        #endregion

        /*CAMBIO						FECHA			AUTOR
		INSERT PARTIDA					22-06-2021	    ALEXANDER FERNÁNDEZ 22-06-2021*/
        #region InsertRowContratoPartida
        public static string InsertRowContratoPartida(string[] parameterValues)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.InsertRowContratoPartida(parameterValues);
		}
		#endregion

		/*CAMBIO						FECHA			AUTOR
		UPDATE CONTRATO PARTIDA					24-06-2021	    ALEXANDER FERNÁNDEZ 24-06-2021*/
		#region UpdateRowContratoPartida
		public static string UpdateRowContratoPartida(string[] parameterValues, string IdContratoPartida)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.UpdateRowContratoPartida(parameterValues, IdContratoPartida);
		}
        public static string UpdateRowContratoPartidaAprobado(string[] parameterValues, string IdContratoPartida)
        {
            return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.UpdateRowContratoPartidaAprobado(parameterValues, IdContratoPartida);
        }
		#endregion

		/*CAMBIO						FECHA			AUTOR
		DELETE CONTRATO PARTIDA			02-09-2021	    ALEXANDER FERNÁNDEZ 02-09-2021*/
		#region UpdateRowContratoPartida
		public static string DeleteRowContratoPartida(string IdContratoPartida)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.DeleteRowContratoPartida(IdContratoPartida);
		}
		#endregion
		#endregion

		#region ProyectoContratoCronograma

		#region SearchByProyectoContratoCronograma
		public static DataSet SearchByProyectoContratoCronograma(string pIdProyecto)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoCronograma(pIdProyecto);
		}
		#endregion

		#region SearchByProyectoContratoCronograma
		public static DataSet SearchByProyectoContratoCronograma(string pIdProyecto, string pIdContrato)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoCronograma(pIdProyecto, pIdContrato);
		}
		#endregion

		#region InsertRowContratoProgramacion
		public static string InsertRowContratoProgramacion(string[] parameterValues)
		{
			string s1 = "", s2 = "", s3 = "";

			if (parameterValues[2].Length > 10)
			{
				s1 = "" + parameterValues[2].Substring(0, parameterValues[2].ToString().IndexOf("/"));
				s2 = "" + parameterValues[2].Substring(parameterValues[2].ToString().IndexOf("/") + 1, 2);
				s3 = "" + parameterValues[2].Substring(parameterValues[2].ToString().IndexOf("/") + 4, 4);
				if (s1.Length > 0)
					parameterValues[2] = s3 + "-" + s2 + "-" + s1;
			}
			else
				parameterValues[2] = "";

			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.InsertRowContratoProgramacion(parameterValues);
		}
		#endregion

		#region UpdatedRowContratoProgramacion
		public static string UpdatedRowContratoProgramacion(string[] parameterValues, string pId)
		{
			string s1 = "", s2 = "", s3 = "";

			if (parameterValues[2].Length > 10)
			{
				s1 = "" + parameterValues[2].Substring(0, parameterValues[2].ToString().IndexOf("/"));
				s2 = "" + parameterValues[2].Substring(parameterValues[2].ToString().IndexOf("/") + 1, 2);
				s3 = "" + parameterValues[2].Substring(parameterValues[2].ToString().IndexOf("/") + 4, 4);
				if (s1.Length > 0)
					parameterValues[2] = s3 + "-" + s2 + "-" + s1;
			}
			else
				parameterValues[2] = "";

			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.UpdatedRowContratoProgramacion(parameterValues, pId);
		}
		#endregion

		#region DeletedRowContratoProgramacion
		public static string DeletedRowContratoProgramacion(string pId)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.DeletedRowContratoProgramacion(pId);
		}
		#endregion

		#endregion


		#region ContratoValorizacionDet
		#region SearchByContratoValorizacionDet
		/*CAMBIO						FECHA			AUTOR
		SELECT	CONTRATO VALORIZACION	22-06-2021	    ALEXANDER FERNÁNDEZ 22-06-2021*/
		public static DataSet SearchByContratoValorizacionDet(string pIdProyecto, string pIdContrato, int pIdValorizacion,int ejecucion)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.SearchByContratoValorizacionDet(pIdProyecto, pIdContrato, pIdValorizacion, ejecucion);
		}
		#endregion

		#region UpdateRowContratoValorizacionDet
		/*CAMBIO						FECHA			AUTOR
		UPDATE	CONTRATO VALORIZACION	29-06-2021	    ALEXANDER FERNÁNDEZ 29-06-2021*/
		public static string UpdateRowContratoValorizacionDet(string[] parameterValues, string IdContratoValorizacionDet)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.UpdateRowContratoValorizacionDet(parameterValues, IdContratoValorizacionDet);
		}

        #endregion
        #region UpdateRowContratoSupValorizacionDet
        /*CAMBIO						FECHA			AUTOR
		    UPDATE	CONTRATO VALORIZACION	07-09-2021	    ALEXANDER FERNÁNDEZ 07-09-2021*/
            public static string UpdateRowContratoSupValorizacionDet(string[] parameterValues, string IdContratoValorizacionDet)
        {
            return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.UpdateRowContratoSupValorizacionDet(parameterValues, IdContratoValorizacionDet);
        }

        #endregion
        #endregion

        #region ProyectoContratoSeguimiento

        #region SearchByProyectoContratoSeguimiento
        public static DataSet SearchByProyectoContratoSeguimiento(string pIdProyecto)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoSeguimiento(pIdProyecto);
		}
		public static DataSet SearchByProyectoContratoSeguimiento(string pIdProyecto, string pIdContrato)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoSeguimiento(pIdProyecto, pIdContrato);
		}
		#endregion

		#region ProyectoContratoSup
		/*CAMBIO						FECHA			AUTOR
		SELECT	AVANCE DE SUPERVISOR	01-06-2021	    ALEXANDER FERNÁNDEZ 01-06-2021*/
		public static DataSet SearchByProyectoContratoSup(string pIdProyecto, string pIdContrato)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoSup(pIdProyecto, pIdContrato);
		}
		#endregion

		#region ProyectoContratoCon
		/*CAMBIO						FECHA			AUTOR
		SELECT	AVANCE DE CONTRATISTA	03-06-2021	    ALEXANDER FERNÁNDEZ 03-06-2021*/
		public static DataSet SearchByProyectoContratoCon(string pIdProyecto, string pIdContrato, string pIdContratoSeguimiento = "", string ejecucion = "")
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoCon(pIdProyecto, pIdContrato, pIdContratoSeguimiento, ejecucion);
		}   
		#endregion

		#region InsertRowContratoVSeguimiento
		public static string InsertRowContratoSeguimiento(string[] parameterValues)
		{
			string s1 = "", s2 = "", s3 = "";

			if (parameterValues[1].Length > 10)
			{
				s1 = "" + parameterValues[1].Substring(0, parameterValues[1].ToString().IndexOf("/"));
				s2 = "" + parameterValues[1].Substring(parameterValues[1].ToString().IndexOf("/") + 1, 2);
				s3 = "" + parameterValues[1].Substring(parameterValues[1].ToString().IndexOf("/") + 4, 4);
				if (s1.Length > 0)
					parameterValues[1] = s3 + "-" + s2 + "-" + s1;
			}
			else
				parameterValues[1] = "";

			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.InsertRowContratoSeguimiento(parameterValues);
		}
		#endregion

		#region UpdatedRowContratoSeguimiento
		public static string UpdatedRowContratoSeguimiento(string[] parameterValues, string pId)
		{
			string s1 = "", s2 = "", s3 = "";

			if (parameterValues[1].Length > 10)
			{
				s1 = "" + parameterValues[1].Substring(0, parameterValues[1].ToString().IndexOf("/"));
				s2 = "" + parameterValues[1].Substring(parameterValues[1].ToString().IndexOf("/") + 1, 2);
				s3 = "" + parameterValues[1].Substring(parameterValues[1].ToString().IndexOf("/") + 4, 4);
				if (s1.Length > 0)
					parameterValues[1] = s3 + "-" + s2 + "-" + s1;
			}
			else
				parameterValues[1] = "";

			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.UpdatedRowContratoSeguimiento(parameterValues, pId);
		}
		#endregion

		#region DeletedRowContratoSeguimiento
		public static string DeletedRowContratoSeguimiento(string pId)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.DeletedRowContratoSeguimiento(pId);
		}
		#endregion


		#endregion


		#region ProyectoContratoAdelanto

		#region SearchByProyectoContratoAdelanto
		public static DataSet SearchByProyectoContratoAdelanto(string pIdProyecto)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoAdelanto(pIdProyecto);
		}
		public static DataSet SearchByProyectoContratoAdelanto(string pIdProyecto, string pIdContrato)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoAdelanto(pIdProyecto, pIdContrato);
		}
		#endregion

		#region InsertRowContratoAdelanto
		public static string InsertRowContratoAdelanto(string[] parameterValues)
		{
			string s1 = "", s2 = "", s3 = "";

			if (parameterValues[1].Length > 10)
			{
				s1 = "" + parameterValues[1].Substring(0, parameterValues[1].ToString().IndexOf("/"));
				s2 = "" + parameterValues[1].Substring(parameterValues[1].ToString().IndexOf("/") + 1, 2);
				s3 = "" + parameterValues[1].Substring(parameterValues[1].ToString().IndexOf("/") + 4, 4);
				if (s1.Length > 0)
					parameterValues[1] = s3 + "-" + s2 + "-" + s1;
			}
			else
				parameterValues[1] = "";

			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.InsertRowContratoAdelanto(parameterValues);
		}
		#endregion

		#region UpdatedRowContratoAdelanto
		public static string UpdatedRowContratoAdelanto(string[] parameterValues, string pId)
		{
			string s1 = "", s2 = "", s3 = "";

			if (parameterValues[1].Length > 10)
			{
				s1 = "" + parameterValues[1].Substring(0, parameterValues[1].ToString().IndexOf("/"));
				s2 = "" + parameterValues[1].Substring(parameterValues[1].ToString().IndexOf("/") + 1, 2);
				s3 = "" + parameterValues[1].Substring(parameterValues[1].ToString().IndexOf("/") + 4, 4);
				if (s1.Length > 0)
					parameterValues[1] = s3 + "-" + s2 + "-" + s1;
			}
			else
				parameterValues[1] = "";

			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.UpdatedRowContratoAdelanto(parameterValues, pId);
		}
		#endregion

		#region DeletedRowContratoAdelanto
		public static string DeletedRowContratoAdelanto(string pId)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.DeletedRowContratoAdelanto(pId);
		}
		#endregion

		#endregion

		#region ProyectoContratoValorizacion

		public static DataSet SearchByValorizacionContrato(string pIdValorizacion, string pIdContrato)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.SearchByValorizacionContrato(pIdValorizacion, pIdContrato);
		}

		#region SearchByProyectoContratoValorizacion
		public static DataSet SearchByProyectoContratoValorizacion(string pIdProyecto)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoValorizacion(pIdProyecto);
		}
		public static DataSet SearchByProyectoContratoValorizacion(string pIdProyecto, string pIdContrrato)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoValorizacion(pIdProyecto, pIdContrrato);
		}
		#endregion

		#region InsertRowContratoValorizacion
		public static string InsertRowContratoValorizacion(string[] parameterValues)
		{
			string s1 = "", s2 = "", s3 = "";

			if (parameterValues[1].Length > 10)
			{
				s1 = "" + parameterValues[1].Substring(0, parameterValues[1].ToString().IndexOf("/"));
				s2 = "" + parameterValues[1].Substring(parameterValues[1].ToString().IndexOf("/") + 1, 2);
				s3 = "" + parameterValues[1].Substring(parameterValues[1].ToString().IndexOf("/") + 4, 4);
				if (s1.Length > 0)
					parameterValues[1] = s3 + "-" + s2 + "-" + s1;
			}
			else
				parameterValues[1] = "";

			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.InsertRowContratoValorizacion(parameterValues);
		}
		#endregion

		#region UpdatedRowContratoValorizacion
		public static string UpdatedRowContratoValorizacion(string[] parameterValues, string pId)
		{
			string s1 = "", s2 = "", s3 = "";

			if (parameterValues[1].Length > 10)
			{
				s1 = "" + parameterValues[1].Substring(0, parameterValues[1].ToString().IndexOf("/"));
				s2 = "" + parameterValues[1].Substring(parameterValues[1].ToString().IndexOf("/") + 1, 2);
				s3 = "" + parameterValues[1].Substring(parameterValues[1].ToString().IndexOf("/") + 4, 4);
				if (s1.Length > 0)
					parameterValues[1] = s3 + "-" + s2 + "-" + s1;
			}
			else
				parameterValues[1] = "";

			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.UpdatedRowContratoValorizacion(parameterValues, pId);
		}
		#endregion

		#region DeletedRowContratoValorizacion
		public static string DeletedRowContratoValorizacion(string pId)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.DeletedRowContratoValorizacion(pId);
		}
		#endregion

		#endregion

		#region ContratoTipologia
		#region SearchAllContratoTipologia
		public static DataSet SearchAllContratoTipologia(string pIdProyecto, string pIdContrato)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.SearchAllContratoTipologia(pIdProyecto, pIdContrato);
		}
		#endregion
		#region InsertRowContratoATopologia
		public static string InsertRowContratoTipologia(string[] parameterValues)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.InsertRowContratoTipologia(parameterValues);
		}
		#endregion
		#region DeletedRowContratoTipologia
		public static string DeletedRowContratoTipologia(string pId)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.DeletedRowContratoTipologia(pId);
		}
		#endregion
		#endregion

		#region ProyectoContratoSup
		/*CAMBIO						FECHA			AUTOR
		INSERT	AVANCE DE SUPERVISOR	01-06-2021	    ALEXANDER FERNÁNDEZ 01-06-2021*/
		public static string insertRowProyectoContratoSup(string[] parameterValues)
		{
			string s1 = "", s2 = "", s3 = "";

			if (parameterValues[1].Length > 10)
			{

				s1 = "" + parameterValues[1].Substring(0, parameterValues[1].ToString().IndexOf("/"));
				s2 = "" + parameterValues[1].Substring(parameterValues[1].ToString().IndexOf("/") + 1, 2);
				s3 = "" + parameterValues[1].Substring(parameterValues[1].ToString().IndexOf("/") + 4, 4);
				if (s1.Length > 0)
					parameterValues[1] = s3 + "-" + s2 + "-" + s1;
			}
			else
				parameterValues[1] = "";

			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.InsertRowProyectoContratoSup(parameterValues);
		}
		#endregion


		#region
		/*CAMBIO						FECHA			AUTOR
		UPDATE	AVANCE DE SUPERVISOR	01-06-2021	    ALEXANDER FERNÁNDEZ 01-06-2021*/
		public static string UpdateRowProyectoContratoSup(string[] parameterValues, string pId)
		{
			string s1 = "", s2 = "", s3 = "";

			if (parameterValues[1].Length > 10)
			{
				s1 = "" + parameterValues[1].Substring(0, parameterValues[1].ToString().IndexOf("/"));
				s2 = "" + parameterValues[1].Substring(parameterValues[1].ToString().IndexOf("/") + 1, 2);
				s3 = "" + parameterValues[1].Substring(parameterValues[1].ToString().IndexOf("/") + 4, 4);

				if (s1.Length > 0)
					parameterValues[1] = s3 + "-" + s2 + "-" + s1;
			}
			else
				parameterValues[1] = "";
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.UpdateRowProyectoContratoSup(parameterValues, pId);
		}

		#endregion
		#region DeleteRowProyectoContratoSup
		/*CAMBIO						FECHA			AUTOR
		DELETE	AVANCE DE SUPERVISOR	01-06-2021	    ALEXANDER FERNÁNDEZ 01-06-2021*/
		public static string DeleteRowProyectoContratoSup(string pId)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.DeleteRowProyectoContratoSup(pId);
		}
		#endregion


		#region ProyectoContratoCon
		/*CAMBIO						FECHA			AUTOR
		INSERT	AVANCE DE CONTRATISTA	03-06-2021	    ALEXANDER FERNÁNDEZ 03-06-2021*/
		public static string insertRowProyectoContratoCon(string[] parameterValues)
		{
			string s1 = "", s2 = "", s3 = "";

			if (parameterValues[1].Length > 10)
			{

				s1 = "" + parameterValues[1].Substring(0, parameterValues[1].ToString().IndexOf("/"));
				s2 = "" + parameterValues[1].Substring(parameterValues[1].ToString().IndexOf("/") + 1, 2);
				s3 = "" + parameterValues[1].Substring(parameterValues[1].ToString().IndexOf("/") + 4, 4);
				if (s1.Length > 0)
					parameterValues[1] = s3 + "-" + s2 + "-" + s1;
			}
			else
				parameterValues[1] = "";

			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.InsertRowProyectoContratoCon(parameterValues);
		}
		#endregion


		#region
		/*CAMBIO						FECHA			AUTOR
		UPDATE	AVANCE DE CONTRATISTA	03-06-2021	    ALEXANDER FERNÁNDEZ 03-06-2021*/
		public static string UpdateRowProyectoContratoCon(string[] parameterValues, string pId)
		{
			string s1 = "", s2 = "", s3 = "";

			if (parameterValues[1].Length > 10)
			{
				s1 = "" + parameterValues[1].Substring(0, parameterValues[1].ToString().IndexOf("/"));
				s2 = "" + parameterValues[1].Substring(parameterValues[1].ToString().IndexOf("/") + 1, 2);
				s3 = "" + parameterValues[1].Substring(parameterValues[1].ToString().IndexOf("/") + 4, 4);

				if (s1.Length > 0)
					parameterValues[1] = s3 + "-" + s2 + "-" + s1;
			}
			else
				parameterValues[1] = "";
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.UpdateRowProyectoContratoCon(parameterValues, pId);
		}

		#endregion
		#region DeleteRowProyectoContratoCon
		/*CAMBIO						FECHA			AUTOR
		DELETE	AVANCE DE CONTRATISTA	03-06-2021	    ALEXANDER FERNÁNDEZ 03-06-2021*/
		public static string DeleteRowProyectoContratoCon(string pId)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.DeleteRowProyectoContratoCon(pId);
		}
		#endregion



		/*CAMBIO						        FECHA			AUTOR
        UPDATE % UTILIDADES, GASTOS GENERALES 	02-07-2021	    ALEXANDER FERNÁNDEZ 02-07-2021*/
		#region
		public static string UpdateRowProyectoContrato02(string[] parametersValues, string IdContrato)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.UpdateRowProyectoContrato02(parametersValues, IdContrato);
		}
		#endregion

		#region

		/*CAMBIO						        FECHA			AUTOR
		SEARCH CONTRATO BY ID                   05-07-2021	    ALEXANDER FERNÁNDEZ 05-07-2021*/
		public static DataSet SearchContratoById(string IdContrato)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.SearchContratoById(IdContrato);
		}
		#endregion


		#region ContratoReajuste
		/*CAMBIO						FECHA			AUTOR
		SELECT CONTRATOREAJUSTE			19-07-2021	    ALEXANDER FERNÁNDEZ 19-07-2021*/
		public static DataSet SearchByContratoReajuste(string IdContrato)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.SearchByContratoReajuste(IdContrato);

		}


		/*CAMBIO						FECHA			AUTOR
		INSERT	CONTRATO REAJUSTE		19-07-2021	    ALEXANDER FERNÁNDEZ 19-07-2021*/
		public static string InsertRowContratoReajuste(string[] parameterValues)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.InsertRowContratoReajuste(parameterValues);
		}


		/*CAMBIO						FECHA			AUTOR
		UPDATE	CONTRATO REAJUSTE		19-07-2021	    ALEXANDER FERNÁNDEZ 19-07-2021*/	
		public static string UpdateRowContratoReajuste(string[] parameterValues, string IdContratoReajuste)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.UpdateRowContratoReajuste(parameterValues, IdContratoReajuste);
		}

		#endregion


		#region Polinomica
		/*CAMBIO						FECHA			AUTOR
		SELECT POLINOMICA				19-07-2021	    ALEXANDER FERNÁNDEZ 19-07-2021*/
		public static DataSet SearchByPolinomica(string IdContrato)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.SearchByPolinomica(IdContrato);

		}

		/*CAMBIO						FECHA			AUTOR
		INSERT	POLINOMICA				19-07-2021	    ALEXANDER FERNÁNDEZ 19-07-2021*/
		public static string InsertRowPolinomica(string[] parameterValues)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.InsertRowPolinomica(parameterValues);
		}


		/*CAMBIO						FECHA			AUTOR
		UPDATE	POLINOMICA				19-07-2021	    ALEXANDER FERNÁNDEZ 19-07-2021*/
		public static string UpdateRowPolinomica(string[] parameterValues, string IdPolinomica)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.UpdateRowPolinomica(parameterValues, IdPolinomica);
		}
		#endregion

		#region
		/*CAMBIO						FECHA			AUTOR
		SELECT VALORIZACION POLINOMICA	21-07-2021	    ALEXANDER FERNÁNDEZ 21-07-2021*/
		public static DataSet SearchByValorizacionPolinomica(string pIdProyecto, string pIdValorizacion)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.SearchByValorizacionPolinomica(pIdProyecto, pIdValorizacion);
		}


		/*CAMBIO						FECHA			AUTOR
		UPDATE	VALORIZACION POLINOMICA	2-07-2021	    ALEXANDER FERNÁNDEZ 21-07-2021*/
		public static string UpdateRowValorizacionPolinomica(string[] parameterValues, string IdValorizacionPolinomica)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.UpdateRowValorizacionPolinomica(parameterValues, IdValorizacionPolinomica);
		}


		/*CAMBIO							FECHA			AUTOR
		UPDATE	VALORIZACION POLINOMICA02	21-07-2021	    ALEXANDER FERNÁNDEZ 21-07-2021*/
		public static string UpdateRowValorizacionPolinomica02(string[] parameterValues, string IdValorizacion)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.UpdateRowValorizacionPolinomica02(parameterValues, IdValorizacion);
		}


		/*CAMBIO							FECHA			AUTOR
		UPDATE	% DE AVANCE 02				22-07-2021	    ALEXANDER FERNÁNDEZ 22-07-2021*/
		public static string UpdateRowPorcentajeAvance(string[] parameterValues, int IdValorizacion, string ejecucion = "")
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.UpdateRowPorcentajeAvance(parameterValues, IdValorizacion, ejecucion);
		}        
        #endregion
        /*
		RESUMEN DE VALORIZACION */
        #region 

        public static DataSet SearchResumenValorizacion(string pIdProyecto, string pIdContrato, int pIdValorizacion, string ejecucion)
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.SearchResumenValorizacion(pIdProyecto, pIdContrato, pIdValorizacion, ejecucion);
		}
		#endregion


		/*
		GRAFICA S */
		#region 

		public static DataSet SearchByProyectoContratoCronograma02(string pIdProyecto, string pIdContrato, string pIdValorizacion,string pEjecucion = "")
		{
			return Code.Data.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoCronograma02(pIdProyecto, pIdContrato, pIdValorizacion, pEjecucion);
		}
		#endregion
	}
}