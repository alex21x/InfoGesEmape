#region Using Directives
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EntLibContrib.Data.MySql;
#endregion

namespace InfogesEmape.Code.Data.Forms.Input
{
    public class GSO_CheckList
    {




        #region CheckList

        #region SeachAllCheckList
        public static DataSet SeachAllCheckList(string lcCadena)
        {
            string sqlCommand = " SELECT A.IDCHECKLIST,A.CHECKLIST_DESCRIPCION, A.IDESTADO ";
            sqlCommand += "FROM OBRASEMP.OBRA_CHECKLIST A ";
            sqlCommand += "ORDER BY A.CHECKLIST_DESCRIPCION";

            return Mysqlquery(sqlCommand);
        }
        #endregion
        #region insertRowCheckList
        public static string insertRowCheckList(string[] parameterValues, string pId)
        {
            string sqlCommand = "";
            sqlCommand += "insert into OBRASEMP.OBRA_CHECKLIST(CHECKLIST_DESCRIPCION) VALUES";
            sqlCommand += "('" + parameterValues[0].ToString()  + "'); Select 1 ;";
            DataSet df = Mysqlquery(sqlCommand);
            return "1";
        }
        #endregion
        #region UpdatedRowCheckList
        public static string UpdatedRowCheckList(string[] parameterValues, string pId)
        {

            string sqlCommand = "";
            sqlCommand += "UPDATE OBRASEMP.OBRA_CHECKLIST SET ";
            sqlCommand += " CHECKLIST_DESCRIPCION='" + parameterValues[0].ToString() + "' ";
            sqlCommand += "WHERE IDCHECKLIST=" + pId + " ; Select 1 ;";
            DataSet df = Mysqlquery(sqlCommand);
            return "1";

        }
        #endregion        
        #region DeletedRowCheckList
        public static string DeletedRowCheckList( string pId)
        {
            string sqlCommand = "";
            sqlCommand += "DELETE  fROM OBRASEMP.OBRA_CHECKLIST  ";
            sqlCommand += "WHERE IDCHECKLIST=" + pId + " ; Select 1 ;";
            DataSet df = Mysqlquery(sqlCommand);
            return "1";
        }
        #endregion

        #endregion

        #region checkList_Actividades

        #region SearchAllCheckListActividades
        public static DataSet SearchAllCheckListActividades(string pIdCheckList)
        {
            string sqlCommand = "  ";
            sqlCommand += " SELECT A.IDCHECKLIST_ACTIVIDAD, A.IDCHECKLIST, A.CHECKLIST_ACTIVIDAD_DESCRIPCION  ";
            sqlCommand += " FROM OBRASEMP.obra_checkList_actividad A  ";
            sqlCommand += " WHERE  ";
            sqlCommand += " A.IDCHECKLIST=" + pIdCheckList + " ";
            sqlCommand += " ORDER BY A.CHECKLIST_ACTIVIDAD_DESCRIPCION ";

            return Mysqlquery(sqlCommand);
        }
        #endregion
        #region insertRowCheckListActividades
        public static string insertRowCheckListActividades(string[] parameterValues)
        {

            string IdCui = parameterValues[0].ToString();
            string sqlCommand = "";
            sqlCommand += "insert into OBRASEMP.Obra_CheckList_Actividad(IDCHECKLIST,CHECKLIST_ACTIVIDAD_DESCRIPCION) VALUES";
            sqlCommand += "(" ;
            sqlCommand += parameterValues[0].ToString() + ", '" + parameterValues[1].ToString().ToUpper() +"' ";
            sqlCommand += "); Select 1 ;";
            DataSet df = Mysqlquery(sqlCommand);
            return "1";
        }
        #endregion
        #region UpdatedRowCheckListActividades
        public static string UpdatedRowCheckListActividades(string[] parameterValues, string pId)
        {
            string sqlCommand = "";
            sqlCommand += "UPDATE OBRASEMP.Obra_CheckList_Actividad SET ";
            sqlCommand += " CHECKLIST_ACTIVIDAD_DESCRIPCION='" + parameterValues[0].ToString().ToUpper() + "' ";
            sqlCommand += "WHERE IDCHECKLIST_ACTIVIDAD=" + pId + " ; Select 1 ;";
  
            DataSet df = Mysqlquery(sqlCommand);
            return "1";

        }
        #endregion
        #region DeletedRowCheckListActividades
        public static string DeletedRowCheckListActividades(string pId)
        {
            string sqlCommand = "";
            sqlCommand += "DELETE  FROM OBRASEMP.Obra_CheckList_Actividad  ";
            sqlCommand += "WHERE IDCHECKLIST_ACTIVIDAD=" + pId + " ; Select 1 ;";
            DataSet df = Mysqlquery(sqlCommand);
            return "1";
        }
        #endregion

        #endregion

        #region Tipologia

        #region SeachAllTipologia
        public static DataSet SeachAllTipologia(string lcCadena)
        {
            string sqlCommand = " SELECT A.IDTIPOLOGIA,A.TIPOLOGIA_DESCRIPCION, A.IDESTADO ";
            sqlCommand += "FROM OBRASEMP.OBRA_CHECKLIST_TIPOLOGIA A ";
            sqlCommand += "ORDER BY A.TIPOLOGIA_DESCRIPCION";

            return Mysqlquery(sqlCommand);
        }
        #endregion
        #region insertRowTipologia
        public static string insertRowTipologia(string[] parameterValues, string pId)
        {
            string sqlCommand = "";
            sqlCommand += "insert into OBRASEMP.OBRA_CHECKLIST_TIPOLOGIA(TIPOLOGIA_DESCRIPCION) VALUES";
            sqlCommand += "('" + parameterValues[0].ToString() + "'); Select 1 ;";
            DataSet df = Mysqlquery(sqlCommand);
            return "1";
        }
        #endregion
        #region UpdatedRowTipologia
        public static string UpdatedRowTipologia(string[] parameterValues, string pId)
        {

            string sqlCommand = "";
            sqlCommand += "UPDATE OBRASEMP.OBRA_CHECKLIST_TIPOLOGIA SET ";
            sqlCommand += " TIPOLOGIA_DESCRIPCION='" + parameterValues[0].ToString() + "' ";
            sqlCommand += "WHERE IDTIPOLOGIA=" + pId + " ; Select 1 ;";
            DataSet df = Mysqlquery(sqlCommand);
            return "1";

        }
        #endregion
        #region DeletedRowTipologia
        public static string DeletedRowTipologia(string pId)
        {
            string sqlCommand = "";
            sqlCommand += "DELETE  fROM OBRASEMP.OBRA_CHECKLIST_TIPOLOGIA  ";
            sqlCommand += "WHERE IDTIPOLOGIA=" + pId + " ; Select 1 ;";
            DataSet df = Mysqlquery(sqlCommand);
            return "1";
        }
		#endregion

		#endregion


		#region Medida
		#region SeachAllMedida
		public static DataSet SeachAllMedida(string lcCadena)
		{
			string sqlCommand = " SELECT A.MED_ID, A.MED_NOMBRE, A.MED_ESTADO ";
			sqlCommand += " FROM OBRASEMP.MEDIDA A ";
			sqlCommand += " ORDER BY A.MED_NOMBRE";

			return Mysqlquery(sqlCommand);
		}
		#endregion
		#endregion


		#region Partida
		#region SeachAllPartida
		public static DataSet SeachAllPartida(string lcCadena)
		{
			string sqlCommand = " SELECT A.PAR_ID, A.PAR_NOMBRE, A.PAR_ESTADO ";
			sqlCommand += " FROM OBRASEMP.PARTIDA A ";
			sqlCommand += " ORDER BY A.PAR_NOMBRE";

			return Mysqlquery(sqlCommand);
		}
		#endregion

		#region		
		public static DataSet SeachAllPolinomica(string lcCadena)
		{
			string sqlCommand = " SELECT A.POL_ID, A.POL_NOMBRE, A.POL_ESTADO ";
			sqlCommand += " FROM OBRASEMP.POLINOMICA A ";
			sqlCommand += " ORDER BY A.POL_NOMBRE";
			return Mysqlquery(sqlCommand);
		}
		#endregion
		#endregion

		#region CheckListxTipo

		#region SearchCheckListxTipo
		public static DataSet SearchCheckListxTipo(string pId)
        {

            string sqlCommand = " SELECT A.IDSEC, A.IDTIPOLOGIA,B.IDCHECKLIST,B.CHECKLIST_DESCRIPCION ";
            sqlCommand += " FROM OBRASEMP.OBRA_CHECKLIST_X_TIPO A ";
            sqlCommand += " JOIN OBRASEMP.OBRA_CHECKLIST B ";
            sqlCommand += " ON A.IDCHECKLIST=B.IDCHECKLIST ";
            sqlCommand += " WHERE A.IDTIPOLOGIA=" + pId + " ";
            return Mysqlquery(sqlCommand);
        }
        #endregion
        #region SearchDescripcion
        public static DataSet SearchDescripcion()
        {
            string sqlCommand = " SELECT A.IDCHECKLIST,A.CHECKLIST_DESCRIPCION ";
            sqlCommand += " FROM OBRASEMP.OBRA_CHECKLIST A ";
            sqlCommand += " ORDER BY A.CHECKLIST_DESCRIPCION  ";
            return Mysqlquery(sqlCommand);
        }
        #endregion

        #region insertRowCheckListxTipo
        public static string insertRowCheckListxTipo(string[] parameterValues)
        {

            string IdCui = parameterValues[0].ToString();
            string sqlCommand = "";
            sqlCommand += "insert into OBRASEMP.OBRA_CHECKLIST_X_TIPO(IDTIPOLOGIA,IDCHECKLIST) VALUES";
            sqlCommand += "(";
            sqlCommand += parameterValues[0].ToString() + ", " + parameterValues[1].ToString() +" ";
            sqlCommand += "); Select 1 ;";
            DataSet df = Mysqlquery(sqlCommand);
            return "1";
        }
        #endregion
        #region UpdatedRowCheckListxTipo
        public static string UpdatedRowCheckListxTipo(string[] parameterValues, string pId)
        {
            string sqlCommand = "";
            if (parameterValues[0].ToString() != "NCN")
            {
                sqlCommand += "UPDATE OBRASEMP.OBRA_CHECKLIST_X_TIPO SET ";
                sqlCommand += " IDCHECKLIST= " + parameterValues[0].ToString() + " ";
                sqlCommand += "WHERE IDSEC=" + pId + " ; Select 1 ;";
                DataSet df = Mysqlquery(sqlCommand);
            }
            return "1";

        }
        #endregion
        #region DeletedRowCheckListxTipo
        public static string DeletedRowCheckListxTipo(string pId)
        {
            string sqlCommand = "";
            sqlCommand += "DELETE  FROM OBRASEMP.OBRA_CHECKLIST_X_TIPO  ";
            sqlCommand += "WHERE IDSEC=" + pId + " ; Select 1 ;";
            DataSet df = Mysqlquery(sqlCommand);
            return "1";
        }
        #endregion

        #endregion

        public static DataSet Mysqlquery(string Cadena)
        {
            //DataSet ds1 = new DataSet();
            //MySqlConnection Conexion = new MySqlConnection();
            //MySqlCommand Query = new MySqlCommand();
            //MySqlDataAdapter MySqlDa;
            //Conexion.ConnectionString = Code.ConeccionString2.mysql();
            //Conexion.Open();
            //Query.CommandText = Cadena;
            //Query.Connection = Conexion;
            //Query.CommandTimeout = 600;
            //MySqlDa = new MySqlDataAdapter(Query);
            //MySqlDa.Fill(ds1);
            //Conexion.Close();
            //return ds1;
            DataSet ds1 = new DataSet();
            MySqlConnection Conexion = new MySqlConnection();
            MySqlCommand Query = new MySqlCommand();
            MySqlDataAdapter MySqlDa;
            Conexion.ConnectionString = Code.ConeccionString2.mysql();
            Conexion.Open();
            Query.CommandText = Cadena;
            Query.Connection = Conexion;
            Query.CommandTimeout = 1200;
            MySqlDa = new MySqlDataAdapter(Query);
            MySqlDa.Fill(ds1);
            Conexion.Close();
            return ds1;
        }
    }
}
