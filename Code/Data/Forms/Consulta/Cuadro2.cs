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
    public class Cuadro2
    {


        #region SearchAllPeriodo
        public static DataSet SearchAllPeriodo(string Sec_Ejec)
        {
            string StringSql="";
            //if(Sec_Ejec=="301262")
                StringSql = " SELECT ANO_EJE FROM PERIODO ORDER BY ANO_EJE DESC";
            //else
            //    StringSql = " SELECT ANO_EJE FROM PERIODO where ano_eje>'2012' ORDER BY ANO_EJE DESC";

            return Mysqlquery(StringSql);
        }
        #endregion

        #region SearchAllEjecutora
        public static DataSet SearchAllEjecutora(string IdSecEjec)
        {

            
            string StringSql = " SELECT SEC_EJEC,NOMBRE,ABREVIATURA FROM  ejecutora where sec_ejec_pliego='"+IdSecEjec +"' ORDER BY SEC_EJEC";
            DataSet ds1= Mysqlquery(StringSql);
            if (ds1.Tables[0].Rows.Count==0)
            {
                StringSql = " SELECT SEC_EJEC,NOMBRE,ABREVIATURA FROM  ejecutora where sec_ejec='" + IdSecEjec + "' ORDER BY SEC_EJEC";
                ds1 = Mysqlquery(StringSql);
            }
            return ds1;
        }
        #endregion

        #region SearchByPresupuesto
        public static DataSet SearchByPresupuesto(string IdSecEjec, string BaseDeDatos, string IdAnoEje)
        {
            string StringSql = " SELECT ";
            StringSql += " SUM(IF(A.FASE='M',PIA,0)) AS PIA, ";
            StringSql += " SUM(IF(A.FASE='M',MODIFICACION,0)) AS MODIFICACION, ";
            StringSql += " SUM(IF(A.FASE='M',PIM,0)) AS PIM,";
            StringSql += " SUM(IF(A.FASE='C',EJECUCION,0)) AS COMPROMISO,";
            StringSql += " SUM(IF(A.FASE='D',EJECUCION,0)) AS DEVENGADO,";
            StringSql += " ROUND(SUM(IF(A.FASE='D',EJECUCION,0))/SUM(IF(A.FASE='M',PIM,0))*100,2) AS PORCENTAJE_EJECUCION,"; 
            StringSql += " SUM(IF(A.FASE='G',EJECUCION,0)) AS GIRADO,";
            StringSql += " SUM(IF(A.FASE='M',PIM,0))-SUM(IF(A.FASE='D',EJECUCION,0)) AS SALDO_PIM,";
            StringSql += " ROUND((1-SUM(IF(A.FASE='D',EJECUCION,0))/SUM(IF(A.FASE='M',PIM,0)))*100,2) AS PORCENTAJE_PIM,";
            StringSql += " ROUND(SUM(IF(A.FASE='D',EJECUCION,0))/MAX(MES_EJE)-1,2) AS PROMEDIO_MENSUAL,";
            StringSql += " ROUND(ROUND(SUM(IF(A.FASE='D',EJECUCION,0))/MAX(MES_EJE)-1,2)/SUM(IF(A.FASE='M',PIM,0))*100,2) AS PORCENTAJE_MENSUAL,";
            StringSql += " ROUND(SUM(IF(A.FASE='M',PIM,0))-SUM(IF(A.FASE='D',EJECUCION,0))-SUM(IF(A.FASE='D',EJECUCION,0))/12-MAX(MES_EJE),2) AS SALDO_PROYECTADO,";
            StringSql += " ROUND((1-(SUM(IF(A.FASE='D',EJECUCION,0))+SUM(IF(A.FASE='D',EJECUCION,0))/12-MAX(MES_EJE))/SUM(IF(A.FASE='M',PIM,0)))*100,2) AS PORCENTAJE_PROYECTADO";
            StringSql += " FROM " + BaseDeDatos + ".INFOREG_EJECUCION_2009 A";
            StringSql += " WHERE  1=1";
            StringSql += " AND A.ANO_EJE='"+IdAnoEje+"' ";
            StringSql += " AND A.SEC_EJEC='"+IdSecEjec+"' AND LENGTH(a.funcion)>0 ";
            StringSql += " AND A.CICLO='G' AND A.TIPO_TRANSACCION+A.GENERICA<>'00'";
            StringSql += " GROUP BY A.ANO_EJE";
            DataSet ds1 = Mysqlquery(StringSql);
            return ds1;
        }
        #endregion

        #region SearchByPorConcepto
        public static DataSet SearchByPorConcepto(string IdSecEjec, string BaseDeDatos, string IdAnoEje)
        {
            string StringSql = " SELECT A.ESPECIFICA_DET_NOMBRE, ";
            StringSql += " SUM(IF(A.FASE='M',PIA,0)) AS PIA, ";
            StringSql += " SUM(IF(A.FASE='M',MODIFICACION,0)) AS MODIFICACION, ";
            StringSql += " SUM(IF(A.FASE='M',PIM,0)) AS PIM,";
            StringSql += " SUM(IF(A.FASE='C',EJECUCION,0)) AS COMPROMISO,";
            StringSql += " SUM(IF(A.FASE='D',EJECUCION,0)) AS DEVENGADO,";
            StringSql += " ROUND(SUM(IF(A.FASE='D',EJECUCION,0))/SUM(IF(A.FASE='M',PIM,0))*100,2) AS PORCENTAJE_EJECUCION,";
            StringSql += " SUM(IF(A.FASE='G',EJECUCION,0)) AS GIRADO,";
            StringSql += " SUM(IF(A.FASE='M',PIM,0))-SUM(IF(A.FASE='D',EJECUCION,0)) AS SALDO_PIM,";
            StringSql += " ROUND((1-SUM(IF(A.FASE='D',EJECUCION,0))/SUM(IF(A.FASE='M',PIM,0)))*100,2) AS PORCENTAJE_PIM,";
            StringSql += " ROUND(SUM(IF(A.FASE='D',EJECUCION,0))/MAX(MES_EJE)-1,2) AS PROMEDIO_MENSUAL,";
            StringSql += " ROUND(ROUND(SUM(IF(A.FASE='D',EJECUCION,0))/MAX(MES_EJE)-1,2)/SUM(IF(A.FASE='M',PIM,0))*100,2) AS PORCENTAJE_MENSUAL,";
            StringSql += " ROUND(SUM(IF(A.FASE='M',PIM,0))-SUM(IF(A.FASE='D',EJECUCION,0))-SUM(IF(A.FASE='D',EJECUCION,0))/12-MAX(MES_EJE),2) AS SALDO_PROYECTADO,";
            StringSql += " ROUND((1-(SUM(IF(A.FASE='D',EJECUCION,0))+SUM(IF(A.FASE='D',EJECUCION,0))/12-MAX(MES_EJE))/SUM(IF(A.FASE='M',PIM,0)))*100,2) AS PORCENTAJE_PROYECTADO";
            StringSql += " FROM " + BaseDeDatos + ".INFOREG_EJECUCION_2009 A, " + BaseDeDatos + ".INFOGES_GRUPO B ";
            StringSql += " WHERE  1=1";
            StringSql += " AND A.ANO_EJE='" + IdAnoEje + "' AND A.ID_CLASIFICADOR=B.ID_CLASIFICADOR  ";
            StringSql += " AND A.SEC_EJEC='" + IdSecEjec + "' AND LENGTH(a.funcion)>0 ";
            StringSql += " AND A.CICLO='G' AND A.TIPO_TRANSACCION+A.GENERICA<>'00'";
            StringSql += " GROUP BY A.ESPECIFICA_DET_NOMBRE";
            DataSet ds1 = Mysqlquery(StringSql);
            return ds1;
        }
        #endregion

        #region SearchByEjecucion
        public static DataSet SearchByEjecucion(string IdSecEjec, string BaseDeDatos, string IdCadena)
        {

            string StringSql = " SELECT ANO_EJE,SEC_EJEC, CONCAT(A.MES_EJE,' ', B.DESCRIPCION) AS MES_EJE,sum(ejecucion) as EJECUCION ";
            StringSql += " FROM " + BaseDeDatos + ".INFOREG_EJECUCION_2009 A, SIAFEMP.MES B ";
            StringSql += " WHERE A.SEC_EJEC='" + IdSecEjec + "'";
            StringSql += " AND A.CICLO='G' AND A.FASE='D'";
            StringSql += " AND A.MES_EJE=B.MES ";
            //StringSql += " AND ANO_EJE IN ("+IdCadena+")";
            StringSql += " AND ANO_EJE ='" + IdCadena + "'";
            StringSql += " GROUP BY A.ANO_EJE,A.SEC_EJEC,A.MES_EJE";
            DataSet ds1 = Mysqlquery(StringSql);
            return ds1;
        }
        #endregion

        #region SearchByGrupoGenerico
        public static DataSet SearchByGrupoGenerico(string IdSecEjec, string BaseDeDatos, string IdAnoEje)
        {

            string StringSql = " SELECT CONCAT(A.CATEGORIA_GASTO,'.', A.GENERICA,' ',A.GENERICA_NOMBRE) AS GENERICA , ";
            StringSql += " SUM(IF(A.FASE='M',PIA,0)) AS PIA, ";
            StringSql += " SUM(IF(A.FASE='M',MODIFICACION,0)) AS MODIFICACION, ";
            StringSql += " SUM(IF(A.FASE='M',PIM,0)) AS PIM,";
            StringSql += " SUM(IF(A.FASE='C',EJECUCION,0)) AS COMPROMISO,";
            StringSql += " SUM(IF(A.FASE='D',EJECUCION,0)) AS DEVENGADO,";
            StringSql += " ROUND(SUM(IF(A.FASE='D',EJECUCION,0))/SUM(IF(A.FASE='M',PIM,0))*100,2) AS PORCENTAJE_EJECUCION,";
            StringSql += " SUM(IF(A.FASE='G',EJECUCION,0)) AS GIRADO,";
            StringSql += " SUM(IF(A.FASE='M',PIM,0))-SUM(IF(A.FASE='D',EJECUCION,0)) AS SALDO_PIM,";
            StringSql += " ROUND((1-SUM(IF(A.FASE='D',EJECUCION,0))/SUM(IF(A.FASE='M',PIM,0)))*100,2) AS PORCENTAJE_PIM,";
            StringSql += " ROUND(SUM(IF(A.FASE='D',EJECUCION,0))/MAX(MES_EJE)-1,2) AS PROMEDIO_MENSUAL,";
            StringSql += " ROUND(ROUND(SUM(IF(A.FASE='D',EJECUCION,0))/MAX(MES_EJE)-1,2)/SUM(IF(A.FASE='M',PIM,0))*100,2) AS PORCENTAJE_MENSUAL,";
            StringSql += " ROUND(SUM(IF(A.FASE='M',PIM,0))-SUM(IF(A.FASE='D',EJECUCION,0))-SUM(IF(A.FASE='D',EJECUCION,0))/12-MAX(MES_EJE),2) AS SALDO_PROYECTADO,";
            StringSql += " ROUND((1-(SUM(IF(A.FASE='D',EJECUCION,0))+SUM(IF(A.FASE='D',EJECUCION,0))/12-MAX(MES_EJE))/SUM(IF(A.FASE='M',PIM,0)))*100,2) AS PORCENTAJE_PROYECTADO";
            StringSql += " FROM " + BaseDeDatos + ".INFOREG_EJECUCION_2009 A  ";
            StringSql += " WHERE  1=1";
            StringSql += " AND A.ANO_EJE='" + IdAnoEje + "'  ";
            StringSql += " AND A.SEC_EJEC='" + IdSecEjec + "' AND LENGTH(a.funcion)>0 ";
            StringSql += " AND A.CICLO='G' AND A.TIPO_TRANSACCION+A.GENERICA<>'00'";
            StringSql += " GROUP BY A.CATEGORIA_GASTO,A.GENERICA";
            DataSet ds1 = Mysqlquery(StringSql);
            return ds1;
        }
        #endregion

        #region SearchByFuncion
        public static DataSet SearchByFuncion(string IdSecEjec, string BaseDeDatos, string IdPAnoEje)
        {

            string StringSql = " SELECT  CONCAT(A.FUNCION,' ',A.FUNCION_NOMBRE) AS FUNCION_NOMBRE, ";
            StringSql += " SUM(IF(A.FASE='M',PIA,0)) AS PIA, ";
            StringSql += " SUM(IF(A.FASE='M',MODIFICACION,0)) AS MODIFICACION, ";
            StringSql += " SUM(IF(A.FASE='M',PIM,0)) AS PIM,";
            StringSql += " SUM(IF(A.FASE='C',EJECUCION,0)) AS COMPROMISO,";
            StringSql += " SUM(IF(A.FASE='D',EJECUCION,0)) AS DEVENGADO,";
            StringSql += " ROUND(SUM(IF(A.FASE='D',EJECUCION,0))/SUM(IF(A.FASE='M',PIM,0))*100,2) AS PORCENTAJE_EJECUCION,";
            StringSql += " SUM(IF(A.FASE='G',EJECUCION,0)) AS GIRADO,";
            StringSql += " SUM(IF(A.FASE='M',PIM,0))-SUM(IF(A.FASE='D',EJECUCION,0)) AS SALDO_PIM,";
            StringSql += " ROUND((1-SUM(IF(A.FASE='D',EJECUCION,0))/SUM(IF(A.FASE='M',PIM,0)))*100,2) AS PORCENTAJE_PIM,";
            StringSql += " ROUND(SUM(IF(A.FASE='D',EJECUCION,0))/MAX(MES_EJE)-1,2) AS PROMEDIO_MENSUAL,";
            StringSql += " ROUND(ROUND(SUM(IF(A.FASE='D',EJECUCION,0))/MAX(MES_EJE)-1,2)/SUM(IF(A.FASE='M',PIM,0))*100,2) AS PORCENTAJE_MENSUAL,";
            StringSql += " ROUND(SUM(IF(A.FASE='M',PIM,0))-SUM(IF(A.FASE='D',EJECUCION,0))-SUM(IF(A.FASE='D',EJECUCION,0))/12-MAX(MES_EJE),2) AS SALDO_PROYECTADO,";
            StringSql += " ROUND((1-(SUM(IF(A.FASE='D',EJECUCION,0))+SUM(IF(A.FASE='D',EJECUCION,0))/12-MAX(MES_EJE))/SUM(IF(A.FASE='M',PIM,0)))*100,2) AS PORCENTAJE_PROYECTADO";
            StringSql += " FROM " + BaseDeDatos + ".INFOREG_EJECUCION_2009 A ";
            StringSql += " WHERE A.SEC_EJEC='" + IdSecEjec + "'";
            StringSql += " AND A.CICLO='G' AND A.TIPO_TRANSACCION+A.GENERICA<>'00' AND LENGTH(a.funcion)>0 ";
            StringSql += " AND ANO_EJE ='" + IdPAnoEje + "'";
            StringSql += " GROUP BY A.FUNCION_NOMBRE";
            DataSet ds1 = Mysqlquery(StringSql);
            return ds1;
        }
        #endregion

        #region SearchByFuenteFinanc
        public static DataSet SearchByFuenteFinanc(string IdSecEjec, string BaseDeDatos, string IdAnoEje)
        {

            string StringSql = " SELECT ANO_EJE,SEC_EJEC, CONCAT(A.FUENTE_FINANC,' ',A.FUENTE_FINANC_NOMBRE) AS FUENTE_FINANC  , ";
            StringSql += " SUM(IF(A.FASE='M',PIA,0)) AS PIA, ";
            StringSql += " SUM(IF(A.FASE='M',MODIFICACION,0)) AS MODIFICACION, ";
            StringSql += " SUM(IF(A.FASE='M',PIM,0)) AS PIM,";
            StringSql += " SUM(IF(A.FASE='C',EJECUCION,0)) AS COMPROMISO,";
            StringSql += " SUM(IF(A.FASE='D',EJECUCION,0)) AS DEVENGADO,";
            StringSql += " ROUND(SUM(IF(A.FASE='D',EJECUCION,0))/SUM(IF(A.FASE='M',PIM,0))*100,2) AS PORCENTAJE_EJECUCION,";
            StringSql += " SUM(IF(A.FASE='G',EJECUCION,0)) AS GIRADO,";
            StringSql += " SUM(IF(A.FASE='M',PIM,0))-SUM(IF(A.FASE='D',EJECUCION,0)) AS SALDO_PIM,";
            StringSql += " ROUND((1-SUM(IF(A.FASE='D',EJECUCION,0))/SUM(IF(A.FASE='M',PIM,0)))*100,2) AS PORCENTAJE_PIM,";
            StringSql += " ROUND(SUM(IF(A.FASE='D',EJECUCION,0))/MAX(MES_EJE)-1,2) AS PROMEDIO_MENSUAL,";
            StringSql += " ROUND(ROUND(SUM(IF(A.FASE='D',EJECUCION,0))/MAX(MES_EJE)-1,2)/SUM(IF(A.FASE='M',PIM,0))*100,2) AS PORCENTAJE_MENSUAL,";
            StringSql += " ROUND(SUM(IF(A.FASE='M',PIM,0))-SUM(IF(A.FASE='D',EJECUCION,0))-SUM(IF(A.FASE='D',EJECUCION,0))/12-MAX(MES_EJE),2) AS SALDO_PROYECTADO,";
            StringSql += " ROUND((1-(SUM(IF(A.FASE='D',EJECUCION,0))+SUM(IF(A.FASE='D',EJECUCION,0))/12-MAX(MES_EJE))/SUM(IF(A.FASE='M',PIM,0)))*100,2) AS PORCENTAJE_PROYECTADO";
            StringSql += " FROM " + BaseDeDatos + ".INFOREG_EJECUCION_2009 A  ";
            StringSql += " WHERE  1=1";
            StringSql += " AND A.ANO_EJE='" + IdAnoEje + "'  ";
            StringSql += " AND A.SEC_EJEC='" + IdSecEjec + "' AND LENGTH(a.funcion)>0 ";
            StringSql += " AND A.CICLO='G' AND A.TIPO_TRANSACCION+A.GENERICA<>'00'";
            StringSql += " GROUP BY A.ANO_EJE,A.FUENTE_FINANC";
            DataSet ds1 = Mysqlquery(StringSql);
            return ds1;
        }
        #endregion

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
            Query.CommandTimeout = 1200;
            MySqlDa = new MySqlDataAdapter(Query);
            MySqlDa.Fill(ds1);
            Conexion.Close();
            return ds1;

        }
    }
}
