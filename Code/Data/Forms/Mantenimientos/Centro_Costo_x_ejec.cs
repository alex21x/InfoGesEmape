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
    public class Centro_Costo_x_ejec
    {

        #region SearchAllCentroCostoEjec
        public static DataSet SearchAllCentroCostoEjec(string lcSecEjec)
        {

            DataSet ds1 = new DataSet();
            string StringSql = "";
            try
            {
                using (SqlConnection conexion = new SqlConnection(Code.ConeccionString.sql()))
                {
                    StringSql += "  SELECT A.ID_CENTRO_COSTO_X_EJECUTORA, A.SEC_EJEC, A.ID_CENTRO_COSTO, ";
                    StringSql += "  A.DESCRIPCION,  B.DESCRIPCION_CENTRO_COSTO ";
                    StringSql += "  FROM dbo.InfoReg_Centro_Costo_x_Ejecutora A ";                    
                    StringSql += "  ,dbo.InfoReg_Centro_Costo b ";
                    StringSql += "  ,dbo.ejecutora c ";                    
                    StringSql += "  where a.ID_CENTRO_COSTO=B.ID_CENTRO_COSTO ";
                    StringSql += "  AND A.SEC_EJEC=C.SEC_EJEC ";
                    StringSql += "  AND A.SEC_EJEC='" + lcSecEjec.ToString()+ "'";

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

        #region InsertCentroCostoEjec
        public static string InsertCentroCostoEjec(string[] parameterValues)
        {
            string r = "";
            string cadenaActualizar = " Insert into dbo.InfoReg_Centro_Costo_x_Ejecutora(ID_CENTRO_COSTO,DESCRIPCION,SEC_EJEC)";
            cadenaActualizar += " Values(";
            cadenaActualizar +=  (parameterValues[0].ToString().Length == 0 ? "null" : parameterValues[0].ToString())+",";
            cadenaActualizar += (parameterValues[1].ToString().Length == 0 ? "null" : "'" + parameterValues[1].ToString() + "'") + ",";
            cadenaActualizar += (parameterValues[2].ToString().Length == 0 ? "null" : "'"+parameterValues[2].ToString()+"'");
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

        #region UpdatedCentroCostoEjec
        public static string UpdatedCentroCostoEjec(string[] parameterValues)
        {
            string r = "";
            string cadenaActualizar = " UPDATE dbo.InfoReg_Centro_Costo_x_Ejecutora SET ";
            cadenaActualizar += "ID_CENTRO_COSTO=" + (parameterValues[1].ToString().Length == 0 ? "null" :  parameterValues[1].ToString())+",";
            cadenaActualizar += "DESCRIPCION=" + (parameterValues[2].ToString().Length == 0 ? "null" : "'" + parameterValues[2].ToString() + "' ")+",";
            cadenaActualizar += "SEC_EJEC=" + (parameterValues[3].ToString().Length == 0 ? "null" : "'" + parameterValues[3].ToString() + "' ");
            cadenaActualizar += "WHERE ID_CENTRO_COSTO_X_EJECUTORA=" + parameterValues[0].ToString() + "";
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

        #region DeleteCentroCostoEjec
        public static string DeleteCentroCostoEjec(string id)
        {
            string r = "";
            string cadenaActualizar = " DELETE FROM  dbo.InfoReg_Centro_Costo_x_Ejecutora WHERE ID_CENTRO_COSTO_X_EJECUTORA="+id.ToString()+"";
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
