#region Using Directives
using System;
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

namespace InfogesEmape.Code.Data.Forms.Consulta
{
    public class ConfiguracionTransmision
    {

        #region SearchByParOpeTransmision
        public static DataSet SearchByParOpeTransmision(string IdSecEjec)
        {
            DataSet ds1 = new DataSet();
            try
            {
                using (SqlConnection conexion = new SqlConnection(Code.ConeccionString2.sql()))
                {
                    //string conexion = Code.ConeccionString.sql();
                    string StringSql = "SELECT A.ANO_EJE ";
                    StringSql += ",A.SEC_EJEC ";
                    StringSql += ",B.NOMBRE ";
                    StringSql += ",A.UBICACION_SIAF ";
                    StringSql += ",A.FECHA_TRANSMISION_INICIO ";
                    StringSql += ",A.FECHA_TRANSMISION_FIN ";
                    StringSql += ",A.INTERVALO  ";
                    StringSql += "FROM DBO.PAR_OPE_TRANSMISION A, DBO.EJECUTORA B ";
                    StringSql += "WHERE A.SEC_EJEC=B.SEC_EJEC AND B.SEC_EJEC='"+IdSecEjec.ToString()+"'";


                    SqlDataAdapter adapter = new SqlDataAdapter(StringSql, conexion);
                    adapter.Fill(ds1);
                    int i = ds1.Tables[0].Rows.Count;
                }
            }
            catch (Exception ex)
            {
                string Text = "Error: " + ex.Message;
            }
            return ds1;
        }
        #endregion

        #region SearchAllParOpeTransmision
        public static DataSet SearchAllParOpeTransmision()
        {
            DataSet ds1 = new DataSet();
            //string conexion = Code.ConeccionString.sql();

            string StringSql = " SELECT A.ID_PAR_OPE ,A.SEC_EJEC ,B.NOMBRE ,A.UBICACION_SIAF ,A.FECHA_TRANSMISION_INICIO ,A.FECHA_TRANSMISION_FIN ,A.INTERVALO, ";
            StringSql += "substring(A.INTERVALOCONFIG,1,1)*1440+substring(A.INTERVALOCONFIG,3,2)*60+substring(A.INTERVALOCONFIG,6,2) INTERVALOPAROPE_SPINNER, ";
            StringSql += "substring(A.INTERVALO,1,1)*1440+substring(A.INTERVALO,3,2)*60+substring(A.INTERVALO,6,2) INTERVALO_SPINNER , ";
            StringSql += "substring(A.INTERVALOGASTO,1,1)*1440+substring(A.INTERVALOGASTO,3,2)*60+substring(A.INTERVALOGASTO,6,2) INTERVALOGASTO_SPINNER  ";
            StringSql += "FROM PAR_OPE_TRANSMISION A, EJECUTORA B WHERE A.SEC_EJEC=B.SEC_EJEC ORDER BY  A.SEC_EJEC  ";

            //string StringSql = "SELECT A.ID_PAR_OPE ";
            //StringSql += ",A.SEC_EJEC ";
            //StringSql += ",B.NOMBRE ";
            //StringSql += ",A.UBICACION_SIAF ";
            //StringSql += ",A.FECHA_TRANSMISION_INICIO ";
            //StringSql += ",A.FECHA_TRANSMISION_FIN ";
            //StringSql += ",A.INTERVALO  ";
            //StringSql += ",(CAST(substring(ISNULL(A.INTERVALOCONFIG,'0') ,1,1) AS INT)*1440+CAST(substring(ISNULL(A.INTERVALOCONFIG,'0') ,3,2) AS INT)*60+CAST(substring(ISNULL(A.INTERVALOCONFIG,'0') ,6,2) AS INT)) INTERVALOPAROPE_SPINNER ";
            //StringSql += ",(CAST(substring(ISNULL(A.INTERVALO,'0') ,1,1) AS INT)*1440+CAST(substring(ISNULL(A.INTERVALO,'0') ,3,2) AS INT)*60+CAST(substring(ISNULL(A.INTERVALO,'0') ,6,2) AS INT)) INTERVALO_SPINNER ";
            //StringSql += ",(CAST(substring(ISNULL(A.INTERVALOGASTO,'0') ,1,1) AS INT)*1440+CAST(substring(ISNULL(A.INTERVALOGASTO,'0') ,3,2) AS INT)*60+CAST(substring(ISNULL(A.INTERVALOGASTO,'0') ,6,2) AS INT)) INTERVALOGASTO_SPINNER ";
            //StringSql += "FROM DBO.PAR_OPE_TRANSMISION A, DBO.EJECUTORA B ";
            //StringSql += "WHERE A.SEC_EJEC=B.SEC_EJEC ";
            //StringSql += "ORDER BY  A.SEC_EJEC "; 
            try
            {
                MySqlConnection Conexion = new MySqlConnection();
                MySqlCommand Query = new MySqlCommand();
                MySqlDataAdapter MySqlDa;
                Conexion.ConnectionString = Code.ConeccionString2.mysql();
                Conexion.Open();
                Query.CommandText = StringSql;
                Query.Connection = Conexion;
                MySqlDa = new MySqlDataAdapter(Query);
                MySqlDa.Fill(ds1);
                Conexion.Close();
            }
            catch (Exception ex)
            {
                string Text = "Error: " + ex.Message;
            }
            return ds1;
        }
        #endregion

        #region Update_ParOpeTransmision
        public static string Update_ParOpeTransmision(string[] parameterValues)
        {

            DataSet ds1 = new DataSet();
            //string conexion = Code.ConeccionString.sql();

            string cadenaActualizar = "UPDATE PAR_OPE_TRANSMISION SET";
            cadenaActualizar += "   Intervalo='" + parameterValues[1].ToString() + "'";
            cadenaActualizar += "   ,IntervaloGasto='" + parameterValues[2].ToString() + "'";
            cadenaActualizar += "   ,IntervaloConfig='" + parameterValues[6].ToString() + "'";
            cadenaActualizar += "   ,Fecha_Transmision_inicio=STR_TO_DATE('" + parameterValues[3].ToString().Substring(0, 6) + parameterValues[3].ToString().Substring(8,2) + "', '%d/%m/%y')";
            cadenaActualizar += "   ,Fecha_Transmision_Fin=STR_TO_DATE('" + parameterValues[4].ToString().Substring(0, 6) + parameterValues[4].ToString().Substring(8, 2) + "', '%d/%m/%y')";
            cadenaActualizar += "   ,Ubicacion_Siaf='" + parameterValues[5].ToString()+"'";
            cadenaActualizar += " where  SEC_EJEC='" + parameterValues[0].ToString()+"'";
            try
            {
                MySqlConnection Conexion = new MySqlConnection();
                MySqlCommand Query = new MySqlCommand();
                Conexion.ConnectionString = Code.ConeccionString2.mysql();
                Conexion.Open();
                Query.CommandText = cadenaActualizar;
                Query.Connection = Conexion;
                Query.ExecuteNonQuery();
                Conexion.Close();

            }
            catch (Exception ex)
            {
                string Text = "Error: " + ex.Message;
            }

            return "";
        }
        #endregion

        #region SearchAllRegistroAnoEjeMes
        public static DataSet SearchAllRegistroAnoEjeMes(string lcSecEjec)
        {
            DataSet ds1 = new DataSet();
            string StringSql = " Select A.SEC_EJEC,A.ANO_EJE ";
            StringSql += " ,SUM(CASE WHEN A.MES_EJE='00' THEN 1 ELSE 0 END) AS  MES00 ";
            StringSql += " ,SUM(CASE WHEN A.MES_EJE='01' THEN 1 ELSE 0 END) AS  MES01 ";
            StringSql += " ,SUM(CASE WHEN A.MES_EJE='02' THEN 1 ELSE 0 END) AS  MES02 ";
            StringSql += " ,SUM(CASE WHEN A.MES_EJE='03' THEN 1 ELSE 0 END) AS  MES03 ";
            StringSql += " ,SUM(CASE WHEN A.MES_EJE='04' THEN 1 ELSE 0 END) AS  MES04 ";
            StringSql += " ,SUM(CASE WHEN A.MES_EJE='05' THEN 1 ELSE 0 END) AS  MES05 ";
            StringSql += " ,SUM(CASE WHEN A.MES_EJE='06' THEN 1 ELSE 0 END) AS  MES06 ";
            StringSql += " ,SUM(CASE WHEN A.MES_EJE='07' THEN 1 ELSE 0 END) AS  MES07 ";
            StringSql += " ,SUM(CASE WHEN A.MES_EJE='08' THEN 1 ELSE 0 END) AS  MES08 ";
            StringSql += " ,SUM(CASE WHEN A.MES_EJE='09' THEN 1 ELSE 0 END) AS  MES09 ";
            StringSql += " ,SUM(CASE WHEN A.MES_EJE='10' THEN 1 ELSE 0 END) AS  MES10 ";
            StringSql += " ,SUM(CASE WHEN A.MES_EJE='11' THEN 1 ELSE 0 END) AS  MES11 ";
            StringSql += " ,SUM(CASE WHEN A.MES_EJE='12' THEN 1 ELSE 0 END) AS  MES12 ";
            StringSql += " from inforeg_ejecucion_2009 A ";
            StringSql += " Where A.Sec_ejec= " + lcSecEjec.ToString() + "";
            StringSql += " Group by A.SEC_EJEC,A.ANO_EJE ";
            StringSql += " ORDER BY A.SEC_EJEC,A.ANO_EJE ";

            try
            {
                MySqlConnection Conexion = new MySqlConnection();
                MySqlCommand Query = new MySqlCommand();
                MySqlDataAdapter MySqlDa;
                Conexion.ConnectionString = Code.ConeccionString2.mysql();
                Conexion.Open();
                Query.CommandText = StringSql;
                Query.Connection = Conexion;
                MySqlDa = new MySqlDataAdapter(Query);
                MySqlDa.Fill(ds1);
                Conexion.Close();
            }
            catch (Exception ex)
            {
                string Text = "Error: " + ex.Message;
            }
            return ds1;
        }
        #endregion

    }
}
