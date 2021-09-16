#region Using Directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
#endregion

namespace InfoGesRegional.Code.Data.Forms.Consulta
{
    public class CentroCosto
    {

        #region SearchAllCentroCosto
        public static DataSet SearchAllCentroCosto(string Periodo, string Sec_ejec)
        {
            DataSet ds1 = new DataSet();
            try
            {
                using (SqlConnection conexion = new SqlConnection(Code.ConeccionString.sql()))
                {
                    //string conexion = Code.ConeccionString.sql();
                    string StringSql = "select DISTINCT A.ANO_EJE+A.SEC_EJEC+A.CENTRO_COSTO AS CENTRO_COSTO, NOMBRE_DEPEND AS  CENTRO_COSTO_NOMBRE  from  dbo.META_CENTRO_COSTO A,";
                    StringSql += "(SELECT DISTINCT ANO_EJE,SEC_EJEC, SEC_FUNC FROM  dbo.inforeg_ejecucion_2009 GROUP BY ANO_EJE,SEC_EJEC, SEC_FUNC ) B ";
                    StringSql += " WHERE 1=1 AND  A.ANO_EJE=B.ANO_EJE AND A.SEC_EJEC=B.SEC_EJEC AND A.SEC_FUNC=B.SEC_FUNC ";

                    if (Periodo.ToString() != "9999")
                        StringSql += " and A.ANO_EJE='" + Periodo.ToString() + "'";

                    if (Sec_ejec.ToString() != "999999")
                        StringSql += " and A.SEC_EJEC='" + Sec_ejec.ToString() + "'";


                    StringSql += " UNION";

                    StringSql += " (SELECT '9999999999999999999999999' AS CENTRO_COSTO,'TODOS' AS CENTRO_COSTO_NOMBRE) ";

                    StringSql += " order by NOMBRE_DEPEND";
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

        #region SearchAllCentroCostoxMeta
        public static DataSet SearchAllCentroCostoxMeta(string idSecEjec)
        {
            DataSet ds1 = new DataSet();
            try
            {
                using (SqlConnection conexion = new SqlConnection(Code.ConeccionString.sql()))
                {
                    //string StringSql = "select ID_CC_X_EJEC_X_META, ";
                    //StringSql += " CASE WHEN LEN(B.DESCRIPCION)<5 THEN C.DESCRIPCION_CENTRO_COSTO ELSE B.DESCRIPCION END AS DESCRIPCION  from ";
                    //StringSql += " dbo.InfoReg_Centro_Costo_x_Ejecutora B, ";
                    //StringSql += " dbo.InfoReg_Centro_Costo C, ";
                    //StringSql += " dbo.Par_Ope_transmision D ";
                    //StringSql += " WHERE A.ID_CENTRO_COSTO_X_EJECUTORA=B.ID_CENTRO_COSTO_X_EJECUTORA ";
                    //StringSql += " AND B.ID_CENTRO_COSTO=C.ID_CENTRO_COSTO ";
                    //StringSql += " AND A.ANO_EJE=D.ANO_EJE ";
                    //StringSql += " AND A.SEC_EJEC=D.SEC_EJEC ";
                    //StringSql += " AND B.SEC_EJEC='"+idSecEjec.ToString()+"'";

                    //string conexion = Code.ConeccionString.sql();
                    string StringSql = "select B.ID_CENTRO_COSTO_X_EJECUTORA, ";
                    StringSql += " CASE WHEN LEN(B.DESCRIPCION)<5 THEN A.DESCRIPCION_CENTRO_COSTO ELSE B.DESCRIPCION END AS DESCRIPCION ";
                    StringSql += " from dbo.InfoReg_Centro_Costo A, ";
                    StringSql += " dbo.InfoReg_Centro_Costo_x_Ejecutora B ";
                    StringSql += " WHERE  ";
                    StringSql += " A.ID_CENTRO_COSTO=B.ID_CENTRO_COSTO ";
                    StringSql += " AND B.ID_CENTRO_COSTO_X_EJECUTORA  ";
                    StringSql += " IN (SELECT DISTINCT ID_CENTRO_COSTO_X_EJECUTORA  ";
                    StringSql += " FROM dbo.InfoReg_CENTRO_COSTO_x_Meta ";
                    //StringSql += " WHERE ANO_EJE='"++"') ";
                    StringSql += " where B.SEC_EJEC='"+idSecEjec.ToString()+"')";


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
 
    }
}
