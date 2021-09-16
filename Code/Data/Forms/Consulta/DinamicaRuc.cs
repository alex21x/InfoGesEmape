#region Using Directives
using System;
using System.Linq;
using System.Web;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using EntLibContrib.Data.MySql;
using MySql.Data.MySqlClient;  
#endregion

namespace InfogesEmape.Code.Data.Forms.Consulta
{
    public class DinamicaRuc
    {


        #region SearchAllRucGrupo
        public static DataSet SearchAllRucGrupoPrueba()
        {


            //string StringSql = " SELECT  RUC, NOMBRE_RUC, ";
            //StringSql += " SUM(IF(ANO_EJE='2013',EJECUCION,0)) AS EJECUCION_2013, ";
            //StringSql += " SUM(IF(ANO_EJE='2014',EJECUCION,0)) AS EJECUCION_2014, ";
            //StringSql += " SUM(IF(ANO_EJE='2015',EJECUCION,0)) AS EJECUCION_2015, ";
            //StringSql += " SUM(IF(ANO_EJE='2016',EJECUCION,0)) AS EJECUCION_2016, ";
            //StringSql += " SUM(IF(ANO_EJE='2017',EJECUCION,0)) AS EJECUCION_2017, ";
            //StringSql += " SUM(IF(ANO_EJE='2018',EJECUCION,0)) AS EJECUCION_2018, ";
            //StringSql += " SUM(IF(ANO_EJE='2019',EJECUCION,0)) AS EJECUCION_2019, ";
            //StringSql += " SUM(EJECUCION) AS EJECUCION_TOTAL  ";
            //StringSql += " FROM "+BaseDeDatos+".INFOREG_EJECUCION_2009   ";
            //StringSql += " WHERE CICLO='G' AND FASE='G' AND RUC<>'00000000000' ";
            //StringSql += " AND sec_ejec='" + psec_ejec + "' ";
            //StringSql += " GROUP BY RUC ";
            //StringSql += " ORDER BY RUC ";
            string StringSql = " SELECT A.CUI,A.NOMBRE_PROYECTO,A.ACTIVIDAD_PROYECTO,A.PAQUETE, ";
            StringSql += " B.EXPEDIENTE,B.RUC,B.NOMBRE_RUC,B.CICLO,B.FASE,SUM(B.EJECUCION) AS EJECUCION ";
            StringSql += " FROM OBRASEMP.view_avance a ";
            StringSql += " JOIN SIAF_500196.inforeg_ejecucion_2009 B ";
            StringSql += " ON A.CUI=B.act_proy ";
            StringSql += " AND B.ANO_EJE='2020' ";
            StringSql += " AND B.CICLO='G' ";
            StringSql += " AND B.FASE='D' ";
            StringSql += " WHERE NOT EXISTS ";
            StringSql += " ( ";
            StringSql += " SELECT C.ACT_PROY ";
            StringSql += " FROM SIAF_500196.inforeg_ejecucion_2009 C ";
            StringSql += " WHERE C.act_proy=A.CUI ";
            StringSql += " AND C.ANO_EJE=B.ANO_EJE ";
            StringSql += " AND C.SEC_EJEC=B.sec_ejec ";
            StringSql += " AND C.CICLO=B.CICLO ";
            StringSql += " AND C.EXPEDIENTE=B.EXPEDIENTE ";
            StringSql += " AND C.secuencia_ANTERIOR=B.EXPEDIENTE_SECUENCIA ";
            StringSql += " AND C.ANO_EJE='2020' ";
            StringSql += " AND C.CICLO='G' ";
            StringSql += " AND C.SEC_EJEC='500196' ";
            StringSql += " AND C.FASE='G' ";
            StringSql += " ) ";
            StringSql += " GROUP BY A.CUI,A.NOMBRE_PROYECTO,A.ACTIVIDAD_PROYECTO,A.PAQUETE, ";
            StringSql += " B.expediente,B.RUC,B.NOMBRE_RUC,B.CICLO,B.FASE; "; 

            return Mysqlquery(StringSql);
        }
        #endregion


        #region SearchAllRucGrupo
        public static DataSet SearchAllRucGrupo(string psec_ejec, string BaseDeDatos)
        {
            string StringSql = " SELECT * FROM " + BaseDeDatos + ".vw_ejecucion_ruc ";
            StringSql += " WHERE sec_ejec='" + psec_ejec + "' ";
            StringSql += " GROUP BY RUC ";
            StringSql += " ORDER BY RUC ";

            return Mysqlquery(StringSql);
        }
        #endregion

        #region SearchAllRucDet
        public static DataSet SearchAllRucDet(string pSec_ejec, string pKey, string BaseDeDatos)
        {
            String Cadena = "";
            Cadena +=" SELECT ANO_EJE,EXPEDIENTE,NUM_DOC,FECHA_DOC,NOTAS,RUC,NOMBRE_RUC,EJECUCION,FASE,CICLO ";
            Cadena += " FROM " + BaseDeDatos + ".INFOREG_EJECUCION_2009 ";
            Cadena +=" WHERE ";
            Cadena +=" SEC_EJEC='"+pSec_ejec+"' AND ";
            Cadena +=" CICLO='G' AND ";
            Cadena +=" FASE='G' AND ";
            Cadena +=" RUC ='"+pKey+"'";

            return Mysqlquery(Cadena);
        }
        #endregion



        public static DataSet Mysqlquery(string Cadena)
        {
            //Database db = DatabaseFactory.CreateDatabase();
            //DbCommand dbCommand = db.GetSqlStringCommand(Cadena);
            //DataSet ds1 = null;
            //try
            //{
            //    ds1 = db.ExecuteDataSet(dbCommand);
            //}
            //catch (Exception ex)
            //{
            //    string Text = "Error: " + ex.Message.ToString();
            //}
            //return ds1;
            DataSet ds1 = new DataSet();
            MySqlConnection Conexion = new MySqlConnection();
            MySqlCommand Query = new MySqlCommand();
            MySqlDataAdapter MySqlDa;
            Conexion.ConnectionString = Code.ConeccionString2.mysql();
            Conexion.Open();
            Query.CommandText = Cadena;
            Query.Connection = Conexion;
            Query.CommandTimeout = 600;
            MySqlDa = new MySqlDataAdapter(Query);
            MySqlDa.Fill(ds1);
            Conexion.Close();
            return ds1;

        }
    }
}
