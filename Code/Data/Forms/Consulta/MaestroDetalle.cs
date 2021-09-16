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
    public class MaestroDetalle
    {

        #region SearchByMaestroDetalle
        public static DataSet SearchByMaestroDetalle(string pIdMaestro)
        {
               
            string StringSql = "  ";
            StringSql += " SELECT IDMAESTRO_DETALLE,DESCRIPCION,ABREVIATURA FROM OBRASEMP.MAESTRO_DETALLE WHERE IDMAESTRO="+pIdMaestro+" AND ESTADO='A'";
            return InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(StringSql);
        }
        #endregion

        #region SearchByDistrito
        public static DataSet SearchByDistrito()
        {

            string StringSql = "  ";
            StringSql += "SELECT 'TODOS' AS DISTRITO UNION  (SELECT DISTINCT  DISTRITO FROM OBRASEMP.PROYECTO  ORDER BY DISTRITO)";

            return InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(StringSql);
        }
        #endregion

        #region SearchByMaestroDetalle
        public static DataSet SearchByMaestroDetalle(string pIdMaestro, string pIdUnion)
        {

            string StringSql = "  ";
            StringSql += " SELECT '0000' AS IDMAESTRO_DETALLE, 'TODOS' AS DESCRIPCION,'TODOS' AS ABREVIATURA ";
            StringSql += " UNION ";
            StringSql += " (SELECT IDMAESTRO_DETALLE,DESCRIPCION,ABREVIATURA FROM OBRASEMP.MAESTRO_DETALLE WHERE IDMAESTRO=" + pIdMaestro + " ORDER BY ABREVIATURA)";
             return InfogesEmape.Code.Data.Forms.Consulta.DinamicaSiaf.Mysqlquery(StringSql);
        }
        #endregion

 
    }
}
