#region Using Directives
using System;
using System.Linq;
using System.Web;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using EntLibContrib.Data.MySql;
#endregion

namespace InfogesEmape.Code.Data.Forms.Consulta
{
    public class Ejecutora
    {

        #region SearchAllEjecutora
        public static DataSet SearchAllEjecutora()
        {
            string StringSql = "SELECT DISTINCT A.SEC_EJEC, A.NOMBRE,  A.SEC_EJEC+' '+A.NOMBRE as DESCRIPCION_SEC_EJEC from EJECUTORA A ,  inforeg_ejecucion_2009 B WHERE A.SEC_EJEC=B.SEC_EJEC  ";
            StringSql += " ORDER BY A.SEC_EJEC";
            return Mysqlquery(StringSql);
        }
        #endregion

        #region SearchAllEjecutoraUnion
        public static DataSet SearchAllEjecutoraUnion(string IdSecejec, string BaseDeDatos)
        {


            string StringSql = " SELECT '000000' AS SEC_EJEC , 'TODOS' AS DESCRIPCION_SEC_EJEC ";
            StringSql += " UNION ";
            StringSql += " (SELECT DISTINCT A.SEC_EJEC, CONCAT(A.SEC_EJEC,' ',A.NOMBRE) as DESCRIPCION_SEC_EJEC from EJECUTORA A ,  " + BaseDeDatos+ ".inforeg_ejecucion_2009 B WHERE A.SEC_EJEC=B.SEC_EJEC AND A.SEC_EJEC_PLIEGO='"+IdSecejec+"' ) ";
            StringSql += " ORDER BY SEC_EJEC ";
            return Mysqlquery(StringSql);
        }
        #endregion

        #region SearchAllEnqueGasta
        public static DataSet SearchAllEnqueGasta(string IdCodicion1, string IdCondicion2)
        {

            string StringSql = "SELECT DISTINCT A.ID_CONDICION, A.DESCRIPCION from maestro_condicion A WHERE a.condicion1=" + IdCodicion1.ToString() + " and a.condicion2=" + IdCondicion2.ToString() + " ";
            StringSql += " ORDER BY A.ID_CONDICION";

            return Mysqlquery(StringSql);
        }
        #endregion


        #region SearchEjecutora
        public static DataSet SearchEjecutora(string IdSec_Ejec)
        {

            string StringSql = "SELECT DISTINCT A.SEC_EJEC, A.SEC_EJEC+' '+A.NOMBRE as DESCRIPCION_SEC_EJEC from EJECUTORA A ,  inforeg_ejecucion_2009 B WHERE A.SEC_EJEC=B.SEC_EJEC AND A.SEC_EJEC='" + IdSec_Ejec.ToString() + "'";
            StringSql += " ORDER BY A.SEC_EJEC";

            return Mysqlquery(StringSql);
        }
        #endregion

        #region SearchEjecutoraCC
        public static DataSet SearchEjecutoraCC(string IdSec_Ejec)
        {

            string StringSql = "SELECT DISTINCT A.SEC_EJEC, A.SEC_EJEC+' '+A.NOMBRE as DESCRIPCION_SEC_EJEC from EJECUTORA A WHERE A.SEC_EJEC='" + IdSec_Ejec.ToString() + "'";
            StringSql += " ORDER BY A.SEC_EJEC";

            return Mysqlquery(StringSql);
        }
        #endregion



        public static DataSet GetUserEjecutora(string userId)
        {

            string StringSql = "SELECT B.SEC_EJEC, B.SEC_EJEC+ ' '+B.NOMBRE AS NOMBRE,BASEDEDATOS FROM InfoReg_user_ejecutora a, ejecutora b WHERE a.sec_ejec = b.sec_ejec AND a.user_id ='" + userId + "' ";

            return Mysqlquery(StringSql);

        }

        #region SearchEjecutora1
        public static DataSet SearchEjecutora1()
        {
            string StringSql = "SELECT DISTINCT A.SEC_EJEC,  A.SEC_EJEC+' '+ A.NOMBRE  AS NOMBRE from EJECUTORA A  ";
            StringSql += " ORDER BY A.SEC_EJEC";
            return Mysqlquery(StringSql);
        }
        #endregion

        #region SearchEjecutoraUser
        public static DataSet SearchEjecutoraUser(string IdSUser)
        {
            string StringSql = "SELECT DISTINCT A.SEC_EJEC,  A.SEC_EJEC+' '+ A.NOMBRE  AS NOMBRE from EJECUTORA A, InfoReg_user_ejecutora B ";
            StringSql += " WHERE A.SEC_EJEC=B.SEC_EJEC AND USER_ID='" + IdSUser.ToString() + "' ORDER BY A.SEC_EJEC";

            return Mysqlquery(StringSql);
        }
        #endregion

        public static DataSet Mysqlquery(string Cadena)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(Cadena);
            DataSet ds1 = null;
            try
            {
                ds1 = db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                string Text = "Error: " + ex.Message.ToString();
            }
            return ds1;
        }

    }
}
