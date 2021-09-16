#region Using Directives
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
#endregion


namespace InfoGesRegional.Code.Data.Forms.Mantenimientos
{
    public class Centro_Costo_x_ejec_x_Meta
    {

        #region SearchAllCentroCostoEjecMeta
        public static DataSet SearchAllCentroCostoEjecMeta(string Id)
        {

            DataSet ds1 = new DataSet();
            string StringSql = "";
            try
            {
                using (SqlConnection conexion = new SqlConnection(Code.ConeccionString.sql()))
                {
                    StringSql += "  SELECT  ";
                    StringSql += " A.ANO_EJE ";
                    StringSql += " ,A.SEC_EJEC ";
                    StringSql += " ,A.ID_CC_X_EJEC_X_META ";
                    StringSql += " ,A.ID_CENTRO_COSTO_X_EJECUTORA ";
                    StringSql += " ,case WHEN len(B.DESCRIPCION_META)<10 then A.SEC_FUNC+' '+B.FINALIDAD_NOMBRE ELSE B.SEC_FUNC+' '+B.DESCRIPCION_META END AS DESCRIPCION_META ";
                    StringSql += " FROM dbo.InfoReg_CENTRO_COSTO_x_Meta A, ";
                    StringSql += " dbo.INFOREG_META B ";
                    StringSql += " WHERE A.ID_CENTRO_COSTO_X_EJECUTORA="+Id.ToString()+"";
                    StringSql += " AND A.ANO_EJE=B.ANO_EJE ";
                    StringSql += " AND A.SEC_EJEC=B.SEC_EJEC ";
                    StringSql += " AND A.SEC_FUNC=B.SEC_FUNC ";

                    SqlDataAdapter adapter = new SqlDataAdapter(StringSql, conexion);
                    adapter.Fill(ds1);
                }
            }
            catch (Exception ex)
            {
                string Text = "Error: " + ex.Message;
            }

            return ds1;
        }
        #endregion

        #region InsertCentroCostoEjecMeta
        public static string InsertCentroCostoEjecMeta(string[] parameterValues)
        {
            string r = "";
            string cadenaActualizar = " Insert into dbo.InfoReg_CENTRO_COSTO_x_Meta(ANO_EJE,SEC_EJEC,SEC_FUNC,ID_CENTRO_COSTO_X_EJECUTORA)";
            cadenaActualizar += " Values(";
            cadenaActualizar += (parameterValues[0].ToString().Length == 0 ? "null" : "'" + parameterValues[0].ToString() + "'") + ",";
            cadenaActualizar += (parameterValues[1].ToString().Length == 0 ? "null" : "'" + parameterValues[1].ToString() + "'") + ",";
            cadenaActualizar += (parameterValues[2].ToString().Length == 0 ? "null" : "'" + parameterValues[2].Substring(10,4) + "'") + ","; ;
            cadenaActualizar += (parameterValues[3].ToString().Length == 0 ? "null" : parameterValues[3].ToString());
            cadenaActualizar += ") ";
            using (SqlConnection conexion = new SqlConnection(Code.ConeccionString.sql()))
            {
                SqlCommand comando = new SqlCommand(cadenaActualizar, conexion);
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            return r;
        }
        #endregion

        #region UpdatedCentroCostoEjecMeta
        public static string UpdatedCentroCostoEjecMeta(string[] parameterValues)
        {
            string r = "";
            string cadenaActualizar = " UPDATE dbo.InfoReg_CENTRO_COSTO_x_Meta SET ";
            cadenaActualizar += "SEC_FUNC=" + (parameterValues[1].ToString().Length == 0 ? "null" : "'" + parameterValues[1].Substring(10, 4) + "' ") + ",";
            cadenaActualizar += "WHERE ID_CC_X_EJEC_X_META=" + parameterValues[0].ToString() + "";
            using (SqlConnection conexion = new SqlConnection(Code.ConeccionString.sql()))
            {
                SqlCommand comando = new SqlCommand(cadenaActualizar, conexion);
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            return r;
        }
        #endregion

        #region DeleteCentroCostoEjecMeta
        public static string DeleteCentroCostoEjecMeta(string id)
        {
            string r = "";
            string cadenaActualizar = " DELETE FROM  dbo.InfoReg_CENTRO_COSTO_x_Meta WHERE ID_CC_X_EJEC_X_META=" + id.ToString() + "";
            using (SqlConnection conexion = new SqlConnection(Code.ConeccionString.sql()))
            {
                SqlCommand comando = new SqlCommand(cadenaActualizar, conexion);
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            return r;
        }
        #endregion

    }
}
