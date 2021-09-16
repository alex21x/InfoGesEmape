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
    public class DinamicaSiaf
    {

        public static DataSet Mysqlquery(string Cadena)
        {
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
