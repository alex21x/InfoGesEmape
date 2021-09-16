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
    public class Centro_Costo
    {

        #region SearchAllCentroCosto
        public static DataSet SearchAllCentroCosto()
        {

            DataSet ds1 = new DataSet();
            string StringSql = "";
            try
            {
                using (SqlConnection conexion = new SqlConnection(Code.ConeccionString.sql()))
                {
                    StringSql += " SELECT [ID_CENTRO_COSTO] ";
                    StringSql += " ,[DESCRIPCION_CENTRO_COSTO] ";
                    StringSql += " ,[SEC_EJEC] ";
                    StringSql += " FROM [dbo].[InfoReg_Centro_Costo] ";
                    StringSql += " ORDER BY DESCRIPCION_CENTRO_COSTO ";

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

        #region InsertCentroCosto
        public static string InsertCentroCosto(string[] parameterValues)
        {
            string r = "";
            string cadenaActualizar = " Insert into dbo.InfoReg_Centro_Costo(DESCRIPCION_CENTRO_COSTO)";
            cadenaActualizar += " Values('";
            cadenaActualizar +=  (parameterValues[0].ToString().Length == 0 ? "null" : parameterValues[0].ToString());
            cadenaActualizar += "') ";
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

        #region UpdatedCentroCosto
        public static string UpdatedCentroCosto(string[] parameterValues)
        {
            string r = "";
            string cadenaActualizar = " UPDATE dbo.InfoReg_Centro_Costo SET ";
            cadenaActualizar += "DESCRIPCION_CENTRO_COSTO="+(parameterValues[1].ToString().Length == 0 ? "null" : "'"+parameterValues[1].ToString()+"' ");
            cadenaActualizar += "WHERE ID_CENTRO_COSTO=" + parameterValues[0].ToString() + "";
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

        #region DeleteCentroCosto
        public static string DeleteCentroCosto(string id)
        {
            string r = "";
            string cadenaActualizar = " DELETE FROM  dbo.InfoReg_Centro_Costo WHERE ID_CENTRO_COSTO="+id.ToString()+"";
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
