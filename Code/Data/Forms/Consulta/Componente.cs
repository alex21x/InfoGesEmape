#region Using Directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
#endregion

namespace InfogesEmape.Code.Data.Forms.Consulta
{
    public class Componente
    {

        #region SearchAllActividadAccion
        public static DataSet SearchAllActividadAccion(string Periodo, string Sec_ejec, string Funcion, string Programa, string Sub_Programa, string Act_Proy)
        {
            DataSet ds1 = new DataSet();
            try
            {
                using (SqlConnection conexion = new SqlConnection(Code.ConeccionString2.sql()))
                {
                    //string conexion = Code.ConeccionString.sql();
                    string StringSql = "select distinct COMPONENTE, COMPONENTE+' '+COMPONENTE_NOMBRE AS COMPONENTE_NOMBRE  from  dbo.inforeg_ejecucion_2009 ";
                    StringSql += " WHERE 1=1";

                    if (Periodo.ToString() != "9999")
                        StringSql += " and ANO_EJE='" + Periodo.ToString() + "'";

                    if (Sec_ejec.ToString() != "999999")
                        StringSql += " and SEC_EJEC='" + Sec_ejec.ToString() + "'";

                    if (Funcion.ToString() != "99")
                        StringSql += " and FUNCION='" + Funcion.ToString() + "'";

                    if (Programa.ToString() != "999")
                        StringSql += " and PROGRAMA='" + Programa.ToString() + "'";

                    if (Sub_Programa.ToString() != "9999")
                        StringSql += " and SUB_PROGRAMA='" + Sub_Programa.ToString() + "'";

                    if (Act_Proy.ToString() != "9999999")
                        StringSql += " and ACT_PROY='" + Act_Proy.ToString() + "'";

                    StringSql += " UNION";

                    StringSql += " (SELECT '9999999' AS COMPONENTE,'TODOS' AS COMPONENTE_NOMBRE) ";
                    StringSql += " order by COMPONENTE";
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
