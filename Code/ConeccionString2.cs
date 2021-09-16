using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace InfogesEmape.Code
{
    class ConeccionString2
    {

        #region Sql
        public static string sql()
        {

            return ConfigurationManager.ConnectionStrings["ConnectionStringSql"].ConnectionString; 
        }
        #endregion

        #region mySql
        public static string mysql()
        {
            return ConfigurationManager.ConnectionStrings["InfogesEmape.Properties.Settings.stringConnection"].ConnectionString; 
        }
        #endregion

    }

}
