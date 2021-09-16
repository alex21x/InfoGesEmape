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
    public class ConsultaAmigable
    {

        #region SearchAllSeleccion
        public static DataSet SearchAllSeleccion(string SqlQuery)
        {
            DataSet ds1 = new DataSet();
            try
            {
                using (SqlConnection conexion = new SqlConnection(Code.ConeccionString2.sql()))
                {
                    //string conexion = Code.ConeccionString.sql();
                    string StringSql = SqlQuery;
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
