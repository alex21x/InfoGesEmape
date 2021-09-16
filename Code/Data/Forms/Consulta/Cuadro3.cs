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
    public class Cuadro3
    {

        #region SearchByPresupuesto
        public static DataSet SearchByPresupuesto(string IdSecEjec, string BaseDeDatos, string IdAnoEje)
        {

            string StringSql = " ";
            string StringSql1 ="";
            ////StringSql += " SET @mes_eje =LPAD((SELECT MONTH(NOW())),2,'0'); ";
            //StringSql += " SET @mes_eje =(SELECT MONTH(NOW())); ";
            //StringSql += " SELECT ";
            //StringSql += " SUM(IF(A.CICLO='G' AND A.FASE='M',PIA,0)) AS PIA, ";
            //StringSql += " SUM(IF(A.CICLO='G' AND A.FASE='M',MODIFICACION,0)) AS MODIFICACION, ";
            //StringSql += " SUM(IF(A.CICLO='G' AND A.FASE='M',PIM,0)) AS PIM,";
            //StringSql += " SUM(IF(A.CICLO='G' AND A.FASE='C',EJECUCION,0)) AS COMPROMISO,";
            //StringSql += " SUM(IF(A.CICLO='G' AND A.FASE='D',EJECUCION,0)) AS DEVENGADO,";
            //StringSql += " ROUND(SUM(IF(A.CICLO='G' AND A.FASE='D',EJECUCION,0))/SUM(IF(A.CICLO='G' AND A.FASE='M',PIM,0))*100,2) AS PORCENTAJE_EJECUCION,";
            //StringSql += " SUM(IF(A.CICLO='G' AND A.FASE='G',EJECUCION,0)) AS GIRADO,";
            //StringSql += " SUM(IF(A.CICLO='G' AND A.FASE='M',PIM,0))-SUM(IF(A.CICLO='G' AND A.FASE='D',EJECUCION,0)) AS SALDO_PIM,";
            //StringSql += " ROUND((1-SUM(IF(A.CICLO='G' AND A.FASE='D',EJECUCION,0))/SUM(IF(A.CICLO='G' AND A.FASE='M',PIM,0)))*100,2) AS PORCENTAJE_PIM,";
            //StringSql += " ROUND(SUM(IF(A.CICLO='G' AND A.FASE='D',EJECUCION,0))/(MAX(A.MES_EJE)-1),2) AS PROMEDIO_MENSUAL,";
            //StringSql += " ROUND(ROUND(SUM(IF(A.CICLO='G' AND A.FASE='D',EJECUCION,0))/(MAX(A.MES_EJE)-1),2)/SUM(IF(A.CICLO='G' AND A.FASE='M',PIM,0))*100,2) AS PORCENTAJE_MENSUAL,";
            ////StringSql += " ROUND(SUM(IF(A.FASE='M',PIM,0))-SUM(IF(A.FASE='D',EJECUCION,0))-SUM(IF(A.FASE='D',EJECUCION,0))/12-MAX(MES_EJE),2) AS SALDO_PROYECTADO,";
            //StringSql += " ROUND(SUM(IF(A.CICLO='G' AND A.FASE='M',PIM,0))-SUM(IF(A.CICLO='G' AND A.FASE='D',EJECUCION,0))-ROUND(SUM(IF(A.CICLO='G' AND A.FASE='D',EJECUCION,0))/(MAX(A.MES_EJE)-1),2)) AS SALDO_PROYECTADO,";
            //StringSql += " ROUND((1-(SUM(IF(A.CICLO='G' AND A.FASE='D',EJECUCION,0))+SUM(IF(A.CICLO='G' AND A.FASE='D',EJECUCION,0))/12-MAX(A.MES_EJE))/SUM(IF(A.CICLO='G' AND A.FASE='M',PIM,0)))*100,2) AS PORCENTAJE_PROYECTADO";
            //StringSql += " FROM " + BaseDeDatos + ".INFOREG_EJECUCION_2009 A";
            //StringSql += " WHERE  1=1";
            //StringSql += " AND A.ANO_EJE='" + IdAnoEje + "' ";
            //StringSql += " AND A.SEC_EJEC='" + IdSecEjec + "' ";
            //StringSql += " AND A.TIPO_TRANSACCION+A.GENERICA<>'00'";
            //StringSql += " GROUP BY A.ANO_EJE";
            if (IdAnoEje == "2019")
            {
                if ((IdSecEjec == "001655") || (IdSecEjec == "500196")) 
                {
                    StringSql = " SELECT A.*, 0.00 as DEVENGADO_6,0.00 as PIM_EJECUCION, 0.00 as PORCENTAJE_META, 0.00 as PENDIENTE, 0.00 as IMPORTE_MINIMO  FROM " + BaseDeDatos + ".infoges_dashboard_presupuesto A ";
                    StringSql += " WHERE A.ANO_EJE='" + IdAnoEje + "' AND A.SEC_EJEC='" + IdSecEjec + "' ";
                }
                else
                {
                    if (IdSecEjec == "000770")
                    {

                        //StringSql = " SELECT A.*, B.DEVENGADO_6,B.PIM_EJECUCION, B.PORCENTAJE_META, B.PENDIENTE, B.IMPORTE_MINIMO  FROM " + BaseDeDatos + ".infoges_dashboard_presupuesto A, ";
                        //StringSql += "(";
                        //StringSql += " SELECT a.ano_eje,(A.DEVENGADO+C.DEVENGADO_EJE) AS DEVENGADO_6,B.PIM_EJECUCION, B.PIM_EJECUCION*B.PORCENTAJE/100 AS IMPORTE_MINIMO, IF(((B.PIM_EJECUCION*B.PORCENTAJE/100)-((A.DEVENGADO+C.DEVENGADO_EJE)>0,(B.PIM_EJECUCION*B.PORCENTAJE/100)-(A.DEVENGADO+C.DEVENGADO_EJE),0) AS PENDIENTE, ";
                        //StringSql += " ROUND(A.DEVENGADO/B.PIM_EJECUCION*100,2) AS PORCENTAJE_META ";
                        //StringSql += "FROM  " + BaseDeDatos + ".infoges_dashboard_generica A , SIAFEMP.reconocimiento_ejecucion_2019 B";
                        //StringSql += ") B, ";
                        //StringSql += "(" + StringSql1 + ") C";
                        //StringSql += " WHERE A.ANO_EJE='" + IdAnoEje + "' AND A.SEC_EJEC='" + IdSecEjec + "' AND A.ANO_EJE=B.ANO_EJE ";
                        //StringSql += " AND A.SEC_EJEC=C.SEC_EJEC ";


                        StringSql = "  SELECT A.*, B.DEVENGADO_6,B.PIM_EJECUCION, B.PORCENTAJE_META, B.PENDIENTE, B.IMPORTE_MINIMO  FROM " + BaseDeDatos + ".infoges_dashboard_presupuesto A,";
                        StringSql += " (";
                        StringSql += " SELECT a.ano_eje,(A.DEVENGADO+C.DEVENGADO_EJE) AS DEVENGADO_6,B.PIM_EJECUCION, B.PIM_EJECUCION*B.PORCENTAJE/100 AS IMPORTE_MINIMO, ";
                        StringSql += " IF((B.PIM_EJECUCION*B.PORCENTAJE/100)-(A.DEVENGADO+C.DEVENGADO_EJE)>0,(B.PIM_EJECUCION*B.PORCENTAJE/100)-(A.DEVENGADO+C.DEVENGADO_EJE),0) AS PENDIENTE,";
                        StringSql += " ROUND((A.DEVENGADO+C.DEVENGADO_EJE)/B.PIM_EJECUCION*100,2) AS PORCENTAJE_META ";
                        StringSql += " FROM " + BaseDeDatos + ".infoges_dashboard_generica A , SIAFEMP.reconocimiento_ejecucion_2019 B,";
                        StringSql += " (";
                        StringSql += " SELECT '000770' AS SEC_EJEC,SUM(CERTIFICACION_EJE) AS CERTIFICACION_EJE, ";
                        StringSql += " SUM(COMPROMISO_ANUAL_EJE) AS COMPROMISO_ANUAL_EJE,";
                        StringSql += " SUM(COMPROMISO_EJE) AS COMPROMISO_EJE,";
                        StringSql += " SUM(DEVENGADO_EJE) AS DEVENGADO_EJE,";
                        StringSql += " SUM(GIRADO_EJE) AS GIRADO_EJE";
                        StringSql += " FROM " + BaseDeDatos + ".EJECUTORA_GENERICA ";
                        StringSql += " WHERE SUMA='S'";
                        StringSql += " ) C ";
                        StringSql += " WHERE A.ANO_EJE='" + IdAnoEje + "' ";
                        StringSql += " AND SUBSTR(A.GENERICA,1,1)='6' ";
                        StringSql += " AND A.ANO_EJE=B.ANO_EJE ";
                        StringSql += " AND A.SEC_EJEC=B.SEC_EJEC ";
                        StringSql += " ) B";
                        StringSql += " WHERE A.ANO_EJE='" + IdAnoEje + "' AND A.SEC_EJEC='" + IdSecEjec + "' AND A.ANO_EJE=B.ANO_EJE";
                    }
                    else
                    {
                        if (IdSecEjec == "301262")
                        {
                            StringSql = " SELECT A.*, B.DEVENGADO_6,B.PIM_EJECUCION, B.PORCENTAJE_META, B.PENDIENTE, B.IMPORTE_MINIMO  FROM " + BaseDeDatos + ".infoges_dashboard_presupuesto A, ";
                            StringSql += " (";
                            StringSql += " SELECT a.ano_eje,A.DEVENGADO AS DEVENGADO_6,B.PIM_EJECUCION, B.PIM_EJECUCION*B.PORCENTAJE/100 AS IMPORTE_MINIMO, IF((B.PIM_EJECUCION*B.PORCENTAJE/100)-A.DEVENGADO>0,(B.PIM_EJECUCION*B.PORCENTAJE/100)-A.DEVENGADO,0) AS PENDIENTE, ";
                            StringSql += " ROUND(A.DEVENGADO/B.PIM_EJECUCION*100,2) AS PORCENTAJE_META ";
                            StringSql += " FROM  " + BaseDeDatos + ".infoges_dashboard_generica1 A , SIAFEMP.reconocimiento_ejecucion_2019 B ";
                            StringSql += " WHERE A.ANO_EJE='" + IdAnoEje + "' ";
                            StringSql += " AND SUBSTR(A.GENERICA,1,1)='6' ";
                            StringSql += " AND A.ANO_EJE=B.ANO_EJE ";
                            StringSql += " AND A.SEC_EJEC=B.SEC_EJEC ";
                            StringSql += " ) B";
                            StringSql += " WHERE A.ANO_EJE='" + IdAnoEje + "' AND A.SEC_EJEC='" + IdSecEjec + "' AND A.ANO_EJE=B.ANO_EJE";
                        }
                        else
                        {
                            StringSql = " SELECT A.*, B.DEVENGADO_6,B.PIM_EJECUCION, B.PORCENTAJE_META, B.PENDIENTE, B.IMPORTE_MINIMO  FROM " + BaseDeDatos + ".infoges_dashboard_presupuesto A, ";
                            StringSql += " (";
                            StringSql += " SELECT a.ano_eje,A.DEVENGADO AS DEVENGADO_6,B.PIM_EJECUCION, B.PIM_EJECUCION*B.PORCENTAJE/100 AS IMPORTE_MINIMO, IF((B.PIM_EJECUCION*B.PORCENTAJE/100)-A.DEVENGADO>0,(B.PIM_EJECUCION*B.PORCENTAJE/100)-A.DEVENGADO,0) AS PENDIENTE, ";
                            StringSql += " ROUND(A.DEVENGADO/B.PIM_EJECUCION*100,2) AS PORCENTAJE_META ";
                            StringSql += " FROM  " + BaseDeDatos + ".infoges_dashboard_generica A , SIAFEMP.reconocimiento_ejecucion_2019 B ";
                            StringSql += " WHERE A.ANO_EJE='" + IdAnoEje + "' ";
                            StringSql += " AND SUBSTR(A.GENERICA,1,1)='6' ";
                            StringSql += " AND A.ANO_EJE=B.ANO_EJE ";
                            StringSql += " AND A.SEC_EJEC=B.SEC_EJEC ";
                            StringSql += " ) B";
                            StringSql += " WHERE A.ANO_EJE='" + IdAnoEje + "' AND A.SEC_EJEC='" + IdSecEjec + "' AND A.ANO_EJE=B.ANO_EJE";
                        }
                    }
                }
            }
            else
            {
                StringSql = " SELECT A.*, 0.00 as DEVENGADO_6,0.00 as PIM_EJECUCION, 0.00 as PORCENTAJE_META, 0.00 as PENDIENTE, 0.00 as IMPORTE_MINIMO  FROM " + BaseDeDatos + ".infoges_dashboard_presupuesto A ";
                StringSql += " WHERE A.ANO_EJE='" + IdAnoEje + "' AND A.SEC_EJEC='" + IdSecEjec + "' ";
            }

            

            DataSet ds1 = Mysqlquery(StringSql);
            return ds1;
        }
        #endregion

        #region SearchByPresupuestoGraf
        public static string SearchByPresupuestoGraf(string IdSecEjec, string BaseDeDatos, string IdAnoEje)
        {

            MySqlConnection Conexion = new MySqlConnection();
            MySqlCommand Query = new MySqlCommand();
            Conexion.ConnectionString = Code.ConeccionString2.mysql();
            Conexion.Open();

            string Cadena= " SELECT * FROM  "+BaseDeDatos+".infoges_dashboard_presupuesto WHERE ";
                    Cadena += " ano_eje='" + IdAnoEje + "'";
                    Cadena += " and sec_ejec='" + IdSecEjec + "';";

            Query.CommandText = Cadena;
            Query.Connection = Conexion;
            Query.CommandTimeout = 1200;
            Query.ExecuteNonQuery();
            Conexion.Close();
            return "1";
        }
        #endregion
        #region SearchByGrupoGenerico
        public static DataSet SearchByGrupoGenerico(string IdSecEjec, string BaseDeDatos, string IdAnoEje)
        {

            string StringSql = " ";
            StringSql = " SELECT * FROM " + BaseDeDatos + ".infoges_dashboard_generica WHERE ANO_EJE='" + IdAnoEje + "' AND SEC_EJEC='" + IdSecEjec + "'";
            DataSet ds1 = Mysqlquery(StringSql);
            return ds1;
        }
        #endregion

        #region SearchByFuenteFinanc
        public static DataSet SearchByFuenteFinanc(string IdSecEjec, string BaseDeDatos, string IdAnoEje)
        {

            string StringSql = " ";
            StringSql = " SELECT * FROM " + BaseDeDatos + ".infoges_dashboard_fuentefinanc WHERE ANO_EJE='" + IdAnoEje + "' AND SEC_EJEC='" + IdSecEjec + "'";

            DataSet ds1 = Mysqlquery(StringSql);


            int end = ds1.Tables[0].Rows.Count;
            if (end != 0)
            {
                for (int k = 0; k < end; k++)
                {

                    if (ds1.Tables[0].Rows[k]["FUENTE_FINANC"].ToString() == ("00 RECURSOS ORDINARIOS"))
                        ds1.Tables[0].Rows[k]["SALDO_RECAUDADO"] = 0.00;

                }

            }


            return ds1;
        }
        #endregion

        #region SearchByFuncion
        public static DataSet SearchByFuncion(string IdSecEjec, string BaseDeDatos, string IdAnoEje)
        {
            string StringSql = " ";
            StringSql = " SELECT * FROM " + BaseDeDatos + ".infoges_dashboard_funcion WHERE ANO_EJE='" + IdAnoEje + "' AND SEC_EJEC='" + IdSecEjec + "'";
            DataSet ds1 = Mysqlquery(StringSql);
            return ds1;
        }
        #endregion

        #region SearchAllGenericaComparativo
        public static DataSet SearchAllGenericaComparativo(string pSecEjec, string BaseDeDatos, string pAnoEje)
        {

            string StringSql = "  ";
            //StringSql += " SELECT ";
            //StringSql += " A.ANO_EJE,a.GENERICA,a.GENERICA_NOMBRE, ";
            //StringSql += " SUM(IF(a.ciclo='G' AND a.fase='M',a.pim,0)) AS PIM, ";
            //StringSql += " SUM(IF(a.ciclo='G' AND a.fase='G', a.ejecucion, 0)) AS EJECUCION, ";
            //StringSql += " SUM(IF(a.ciclo='G' AND a.fase='M',a.pim,0))-SUM(IF(a.ciclo='G' AND a.fase='G', a.ejecucion, 0)) AS SALGO_GENERICA, ";
            //StringSql += " ROUND(SUM(IF(a.ciclo='G' AND a.fase='G', a.ejecucion, 0))/11-1,2) AS PROMEDIO_MENSUAL ";
            //StringSql += " FROM  " + BaseDeDatos + ".inforeg_ejecucion_2009 A ";
            //StringSql += " WHERE A.ANO_EJE='" + pAnoEje + "' AND A.SEC_EJEC='" + pSecEjec + "' AND A.GENERICA<>'0' AND LENGTH(A.FUNCION)>0 ";
            //StringSql += " GROUP BY A.FUNCION,A.GENERICA ";

            //StringSql += " SELECT  ";
            //StringSql += " A.ANO_EJE,CONCAT(a.GENERICA,' ',a.GENERICA_NOMBRE) AS GENERICA_NOMBRE , ";
            //StringSql += " SUM(IF(a.ciclo='G' AND a.fase='D', a.ejecucion, 0)) AS EJECUCION ";
            //StringSql += " FROM  " + BaseDeDatos + ".inforeg_ejecucion_2009 A ";
            //StringSql += " WHERE A.SEC_EJEC='" + pSecEjec + "'  AND A.ANO_EJE='" + pAnoEje + "' AND A.TIPO_TRANSACCION<>'1'  AND A.ID_CLASIFICADOR<>'AAAAAAA' ";
            //StringSql += " GROUP BY A.ANO_EJE,A.GENERICA ";
            //StringSql += " UNION ";
            //StringSql += " SELECT  ";
            //StringSql += " A.ANO_EJE,CONCAT(a.GENERICA,' ',a.GENERICA_NOMBRE) AS GENERICA_NOMBRE , ";
            //StringSql += " SUM(IF(a.ciclo='G' AND a.fase='D', a.ejecucion, 0)) AS EJECUCION ";
            //StringSql += " FROM  " + BaseDeDatos + ".inforeg_ejecucion_2009 A ";
            //StringSql += " WHERE A.SEC_EJEC='" + pSecEjec + "'  AND A.ANO_EJE='" + Convert.ToString(Convert.ToInt32(pAnoEje) - 1) + "'  AND A.TIPO_TRANSACCION<>'1' AND A.ID_CLASIFICADOR<>'AAAAAAA' ";
            //StringSql += " GROUP BY A.ANO_EJE,A.GENERICA ";
            //StringSql += " UNION ";
            //StringSql += " SELECT  ";
            //StringSql += " A.ANO_EJE,CONCAT(a.GENERICA,' ',a.GENERICA_NOMBRE) AS GENERICA_NOMBRE , ";
            //StringSql += " SUM(IF(a.ciclo='G' AND a.fase='D', a.ejecucion, 0)) AS EJECUCION ";
            //StringSql += " FROM  " + BaseDeDatos + ".inforeg_ejecucion_2009 A ";
            //StringSql += " WHERE A.SEC_EJEC='" + pSecEjec + "'  AND A.ANO_EJE='" + Convert.ToString(Convert.ToInt32(pAnoEje) - 2) + "'  AND A.TIPO_TRANSACCION<>'1'  AND A.ID_CLASIFICADOR<>'AAAAAAA'";
            //StringSql += " GROUP BY A.ANO_EJE,A.GENERICA ";

            StringSql += " SELECT A.ANO_EJE,";
            StringSql += " a.GENERICA_NOMBRE , ";
            StringSql += " a.EJECUCION ";
            StringSql += " FROM  " + BaseDeDatos + ".infoges_dashboard_genericacomparativo A ";
            StringSql += " WHERE A.SEC_EJEC='" + pSecEjec + "'  AND A.ANO_EJE='" + pAnoEje + "'";
            StringSql += " UNION ";
            StringSql += " SELECT A.ANO_EJE,  ";
            StringSql += " a.GENERICA_NOMBRE , ";
            StringSql += " a.EJECUCION ";
            StringSql += " FROM  " + BaseDeDatos + ".infoges_dashboard_genericacomparativo A ";
            StringSql += " WHERE A.SEC_EJEC='" + pSecEjec + "'  AND A.ANO_EJE='" + Convert.ToString(Convert.ToInt32(pAnoEje) - 1) + "' ";
            StringSql += " UNION ";
            StringSql += " SELECT  A.ANO_EJE, ";
            StringSql += " a.GENERICA_NOMBRE , ";
            StringSql += " a.EJECUCION ";
            StringSql += " FROM  " + BaseDeDatos + ".infoges_dashboard_genericacomparativo A ";
            StringSql += " WHERE A.SEC_EJEC='" + pSecEjec + "'  AND A.ANO_EJE='" + Convert.ToString(Convert.ToInt32(pAnoEje) - 2) + "' ";
            //StringSql += " SELECT * FROM " + BaseDeDatos + ".infoges_dashboard_genericacomparativo WHERE ANO_EJE='" + pAnoEje + "' AND SEC_EJEC='" + pSecEjec + "'";


            DataSet ds1 = Mysqlquery(StringSql);
            return ds1;
        }
        #endregion

        #region SearchAllExpedienteFechas
        public static DataSet SearchAllExpedienteFechas(string pSecEjec, string BaseDeDatos, string pAnoEje)
        {

            string StringSql = "  ";


            //StringSql += " SELECT DISTINCT A.ANO_EJE,A.SEC_EJEC,A.EXPEDIENTE,A.CICLO,A.COD_DOC,A.NUM_DOC,B.NOTAS, ";
            ////StringSql += " STR_TO_DATE(MAX(A.FECHA_COMPROMISO), '%Y-%m-%d') AS FECHA_COMPROMISO, ";
            ////StringSql += " STR_TO_DATE(MAX(A.FECHA_DEVENGADO), '%Y-%m-%d') AS FECHA_DEVENGADO, ";
            ////StringSql += " STR_TO_DATE(MAX(A.FECHA_GIRADO), '%Y-%m-%d') AS FECHA_GIRADO, ";
            ////StringSql += " STR_TO_DATE(MAX(A.FECHA_PAGADO), '%Y-%m-%d') AS FECHA_PAGADO, A.EJECUCION, ";
            //StringSql += " MAX(A.FECHA_COMPROMISO) AS FECHA_COMPROMISO, ";
            //StringSql += " MAX(A.FECHA_DEVENGADO) AS FECHA_DEVENGADO, ";
            //StringSql += " MAX(A.FECHA_GIRADO) AS FECHA_GIRADO, ";
            //StringSql += " MAX(A.FECHA_PAGADO) AS FECHA_PAGADO, A.EJECUCION, "; 
            //StringSql += " TIMESTAMPDIFF(DAY, STR_TO_DATE(MAX(A.FECHA_COMPROMISO), '%Y-%m-%d'), STR_TO_DATE(MAX(A.FECHA_DEVENGADO), '%Y-%m-%d')) AS DEVENGADO_DEMORA, ";
            //StringSql += " TIMESTAMPDIFF(DAY, STR_TO_DATE(MAX(A.FECHA_DEVENGADO), '%Y-%m-%d'), STR_TO_DATE(MAX(A.FECHA_GIRADO), '%Y-%m-%d')) AS GIRADO_DEMORA ";
            //StringSql += " FROM ";
            //StringSql += " ( ";
            //StringSql += " SELECT DISTINCT A.ANO_EJE,A.SEC_EJEC,A.expediente,A.ciclo,CONCAT(A.COD_DOC,' ',B.ABREVIATURA) AS COD_DOC, A.NUM_DOC, ";
            //StringSql += " MIN(IF(A.CICLO='G' AND A.FASE='C', A.FECHA_DOC,'')) AS FECHA_COMPROMISO, ";
            //StringSql += " MIN(IF(A.CICLO='G' AND A.FASE='D', A.FECHA_DOC,'')) AS FECHA_DEVENGADO, ";
            //StringSql += " MIN(IF(A.CICLO='G' AND A.FASE='G', A.FECHA_DOC,'')) AS FECHA_GIRADO, ";
            //StringSql += " MIN(IF(A.CICLO='G' AND A.FASE='P', A.FECHA_DOC,'')) AS FECHA_PAGADO, SUM(A.EJECUCION) AS EJECUCION ";
            //StringSql += " FROM "+BaseDeDatos+".inforeg_ejecucion_2009 A, SIAFEMP.maestro_documento B ";
            //StringSql += " WHERE  1=1 ";
            //StringSql += " AND A.COD_DOC=B.COD_DOC ";
            //StringSql += " AND A.ano_eje='"+pAnoEje+"'  ";
            //StringSql += " AND A.sec_ejec='"+pSecEjec+"'  ";
            //StringSql += " AND A.ciclo='G'  ";
            //StringSql += " AND A.RUC<>'00000000000' ";
            //StringSql += " GROUP BY A.ANO_EJE,A.SEC_EJEC,A.expediente,A.ciclo,A.FASE ";
            //StringSql += " ) A, "+BaseDeDatos+".INFOREG_EJECUCION_2009 B ";
            //StringSql += " WHERE a.ejecucion>0 ";
            //StringSql += " AND A.ANO_EJE=B.ANO_EJE ";
            //StringSql += " AND A.SEC_EJEC=B.SEC_EJEC ";
            //StringSql += " AND A.EXPEDIENTE=B.EXPEDIENTE ";
            //StringSql += " AND A.CICLO=B.CICLO ";
            //StringSql += " AND B.FASE='C' ";
            //StringSql += " GROUP BY A.ANO_EJE,A.SEC_EJEC,A.expediente,A.ciclo ";


            var seed = Environment.TickCount;

            var random12 = new Random(seed);
            var random22 = new Random(seed);
            var random1 = random12.Next(0, 1000);
            var random2 = random22.Next(1000, 2000);

            ////StringSql += " SET @@SESSION.sql_mode='NO_ZERO_DATE,NO_ZERO_IN_DATE'; ";
            ////StringSql += " CREATE TEMPORARY TABLE " + BaseDeDatos + ".TMP_" + random1.ToString().Trim();
            ////StringSql += " SELECT DISTINCT A.ANO_EJE,A.SEC_EJEC,A.CERTIFICADO,A.EXPEDIENTE,A.CICLO,A.COD_DOC,A.NUM_DOC,A.RUC_NOMBRE,a.FUENTE_FINANC,  ";
            ////StringSql += " DATE_FORMAT(STR_TO_DATE(MAX(A.FECHA_CERTIFICADO),'%Y-%m-%d'),'%d/%m/%Y') AS FECHA_CERTIFICADO,";
            ////StringSql += " DATE_FORMAT(STR_TO_DATE(MAX(A.FECHA_COMPROMISO),'%Y-%m-%d'),'%d/%m/%Y') AS FECHA_COMPROMISO,";
            ////StringSql += " DATE_FORMAT(STR_TO_DATE(MAX(A.FECHA_DEVENGADO),'%Y-%m-%d'),'%d/%m/%Y') AS FECHA_DEVENGADO,";
            ////StringSql += " DATE_FORMAT(STR_TO_DATE(MAX(A.FECHA_GIRADO),'%Y-%m-%d'),'%d/%m/%Y') AS FECHA_GIRADO,  ";
            ////StringSql += " DATE_FORMAT(STR_TO_DATE(MAX(A.FECHA_PAGADO),'%Y-%m-%d'),'%d/%m/%Y') AS FECHA_PAGADO, A.EJECUCION,  ";
            ////StringSql += " TIMESTAMPDIFF(DAY, STR_TO_DATE(MAX(A.FECHA_CERTIFICADO), '%Y-%m-%d'), STR_TO_DATE(MAX(A.FECHA_COMPROMISO), '%Y-%m-%d')) AS COMPROMISO_DEMORA,";
            ////StringSql += " TIMESTAMPDIFF(DAY, STR_TO_DATE(MAX(A.FECHA_COMPROMISO), '%Y-%m-%d'), STR_TO_DATE(MAX(A.FECHA_DEVENGADO), '%Y-%m-%d')) AS DEVENGADO_DEMORA,";
            ////StringSql += " TIMESTAMPDIFF(DAY, STR_TO_DATE(MAX(A.FECHA_DEVENGADO), '%Y-%m-%d'), STR_TO_DATE(MAX(A.FECHA_GIRADO), '%Y-%m-%d')) AS GIRADO_DEMORA ";
            ////StringSql += " FROM  (  SELECT DISTINCT A.ANO_EJE,A.SEC_EJEC,A.CERTIFICADO,A.expediente,A.ciclo,CONCAT(A.COD_DOC,' ',B.ABREVIATURA) AS COD_DOC, A.NUM_DOC,CONCAT(a.ruc,' ',a.nombre_ruc) AS RUC_NOMBRE,CONCAT(a.fuente_financ,' ',a.fuente_financ_nombre) AS FUENTE_FINANC,";
            ////StringSql += " MAX(IF(A.CICLO='G' AND A.FASE='E', A.FECHA_DOC,'')) AS FECHA_CERTIFICADO,  ";
            ////StringSql += " MIN(IF(A.CICLO='G' AND A.FASE='C', A.FECHA_DOC,'')) AS FECHA_COMPROMISO,  MIN(IF(A.CICLO='G' AND A.FASE='D', A.FECHA_DOC,'')) AS FECHA_DEVENGADO, ";
            ////StringSql += " MIN(IF(A.CICLO='G' AND A.FASE='G', A.FECHA_DOC,'')) AS FECHA_GIRADO,  MIN(IF(A.CICLO='G' AND A.FASE='P', A.FECHA_DOC,'')) AS FECHA_PAGADO, SUM(A.EJECUCION) AS EJECUCION  ";
            ////StringSql += " FROM " + BaseDeDatos + ".inforeg_ejecucion_2009 A, SIAFEMP.maestro_documento B  WHERE  1=1  AND A.COD_DOC=B.COD_DOC  AND A.ano_eje='" + pAnoEje + "'   AND A.sec_ejec='" + pSecEjec + "'   AND A.ciclo='G'   AND A.RUC<>'00000000000' ";
            ////StringSql += " GROUP BY A.ANO_EJE,A.SEC_EJEC,A.expediente,A.ciclo,A.FASE  ) A";
            ////StringSql += " WHERE a.ejecucion>0   ";
            ////StringSql += " GROUP BY A.ANO_EJE,A.SEC_EJEC,A.expediente,A.ciclo;";
            ////StringSql += " CREATE TEMPORARY TABLE " + BaseDeDatos + ".TMP_" + random2.ToString().Trim();
            ////StringSql += " select DISTINCT A.ANO_EJE,A.SEC_EJEC,A.CICLO,A.EXPEDIENTE,A.NOTAS";
            ////StringSql += " FROM " + BaseDeDatos + ".INFOREG_EJECUCION_2009 A WHERE A.ANO_EJE='" + pAnoEje + "' AND A.SEC_EJEC='" + pSecEjec + "' AND A.CICLO='G' AND A.FASE='C' AND A.RUC<>'00000000000' GROUP BY  A.ANO_EJE,A.SEC_EJEC,A.EXPEDIENTE ;";
            ////StringSql += " SELECT A.*,B.NOTAS";
            ////StringSql += " FROM  " + BaseDeDatos + ".TMP_" + random1.ToString().Trim() + " A, ";
            ////StringSql += " " + BaseDeDatos + ".TMP_" + random2.ToString().Trim() + "  B";
            ////StringSql += " WHERE 1=1 AND A.ANO_EJE=B.ANO_EJE  AND A.SEC_EJEC=B.SEC_EJEC  ";
            ////StringSql += " AND A.EXPEDIENTE=B.EXPEDIENTE  AND A.CICLO=B.CICLO;";
            //StringSql += " SET @@SESSION.sql_mode='NO_ZERO_DATE,NO_ZERO_IN_DATE'; ";
            //StringSql += " CREATE TEMPORARY TABLE " + BaseDeDatos + ".TMP_" + random1.ToString().Trim();
            //StringSql += " SELECT DISTINCT A.ANO_EJE,A.SEC_EJEC,A.CERTIFICADO,A.EXPEDIENTE,A.CICLO,A.COD_DOC,A.NUM_DOC,A.RUC_NOMBRE,a.FUENTE_FINANC,  ";
            //StringSql += " DATE_FORMAT(STR_TO_DATE(MAX(A.FECHA_COMPROMISO),'%Y-%m-%d'),'%d/%m/%Y') AS FECHA_COMPROMISO,";
            //StringSql += " DATE_FORMAT(STR_TO_DATE(MAX(A.FECHA_DEVENGADO),'%Y-%m-%d'),'%d/%m/%Y') AS FECHA_DEVENGADO,";
            //StringSql += " DATE_FORMAT(STR_TO_DATE(MAX(A.FECHA_GIRADO),'%Y-%m-%d'),'%d/%m/%Y') AS FECHA_GIRADO,  ";
            //StringSql += " DATE_FORMAT(STR_TO_DATE(MAX(A.FECHA_PAGADO),'%Y-%m-%d'),'%d/%m/%Y') AS FECHA_PAGADO, A.EJECUCION,  ";
            //StringSql += " TIMESTAMPDIFF(DAY, STR_TO_DATE(MAX(A.FECHA_COMPROMISO), '%Y-%m-%d'), STR_TO_DATE(MAX(A.FECHA_DEVENGADO), '%Y-%m-%d')) AS DEVENGADO_DEMORA,";
            //StringSql += " TIMESTAMPDIFF(DAY, STR_TO_DATE(MAX(A.FECHA_DEVENGADO), '%Y-%m-%d'), STR_TO_DATE(MAX(A.FECHA_GIRADO), '%Y-%m-%d')) AS GIRADO_DEMORA ";
            //StringSql += " FROM  (  SELECT DISTINCT A.ANO_EJE,A.SEC_EJEC,A.CERTIFICADO,A.expediente,A.ciclo,CONCAT(A.COD_DOC,' ',B.ABREVIATURA) AS COD_DOC, A.NUM_DOC,CONCAT(a.ruc,' ',a.nombre_ruc) AS RUC_NOMBRE,CONCAT(a.fuente_financ,' ',a.fuente_financ_nombre) AS FUENTE_FINANC,";
            //StringSql += " MAX(IF(A.CICLO='G' AND A.FASE='E', A.FECHA_DOC,'')) AS FECHA_CERTIFICADO,  ";
            //StringSql += " MIN(IF(A.CICLO='G' AND A.FASE='C', A.FECHA_DOC,'')) AS FECHA_COMPROMISO,  MIN(IF(A.CICLO='G' AND A.FASE='D', A.FECHA_DOC,'')) AS FECHA_DEVENGADO, ";
            //StringSql += " MIN(IF(A.CICLO='G' AND A.FASE='G', A.FECHA_DOC,'')) AS FECHA_GIRADO,  MIN(IF(A.CICLO='G' AND A.FASE='P', A.FECHA_DOC,'')) AS FECHA_PAGADO, SUM(A.EJECUCION) AS EJECUCION  ";
            //StringSql += " FROM " + BaseDeDatos + ".inforeg_ejecucion_2009 A, SIAFEMP.maestro_documento B  WHERE  1=1  AND A.COD_DOC=B.COD_DOC  AND A.ano_eje='" + pAnoEje + "'   AND A.sec_ejec='" + pSecEjec + "'   AND A.ciclo='G'   AND A.RUC<>'00000000000' ";
            //StringSql += " GROUP BY A.ANO_EJE,A.SEC_EJEC,A.expediente,A.ciclo,A.FASE  ) A";
            //StringSql += " WHERE a.ejecucion>0   ";
            //StringSql += " GROUP BY A.ANO_EJE,A.SEC_EJEC,A.expediente,A.ciclo;";
            //StringSql += " CREATE TEMPORARY TABLE " + BaseDeDatos + ".TMP_" + random2.ToString().Trim();
            //StringSql += " select DISTINCT A.ANO_EJE,A.SEC_EJEC,A.CICLO,A.EXPEDIENTE,A.NOTAS";
            //StringSql += " FROM " + BaseDeDatos + ".INFOREG_EJECUCION_2009 A WHERE A.ANO_EJE='" + pAnoEje + "' AND A.SEC_EJEC='" + pSecEjec + "' AND A.CICLO='G' AND A.FASE='C' AND A.RUC<>'00000000000' GROUP BY  A.ANO_EJE,A.SEC_EJEC,A.EXPEDIENTE ;";
            //StringSql += " SELECT A.*,B.NOTAS";
            //StringSql += " FROM  " + BaseDeDatos + ".TMP_" + random1.ToString().Trim() + " A, ";
            //StringSql += " " + BaseDeDatos + ".TMP_" + random2.ToString().Trim() + "  B";
            //StringSql += " WHERE 1=1 AND A.ANO_EJE=B.ANO_EJE  AND A.SEC_EJEC=B.SEC_EJEC  ";
            //StringSql += " AND A.EXPEDIENTE=B.EXPEDIENTE  AND A.CICLO=B.CICLO;";

            ////StringSql += " DROP TABLE "+ BaseDeDatos+".TMP_"+random1.ToString().Trim()+";";
            ////StringSql += " DROP TABLE " + BaseDeDatos + ".TMP_" + random2.ToString().Trim() + ";";


            //if ((pSecEjec == "000770") || (pSecEjec == "301262"))
            //{
                StringSql = " SELECT * FROM " + BaseDeDatos + ".infoges_dashboard_exp_gest_plazo WHERE ANO_EJE='" + pAnoEje + "' AND SEC_EJEC='" + pSecEjec + "'";
            //}




            DataSet ds1 = Mysqlquery(StringSql);

            int end = ds1.Tables[0].Rows.Count;
            if (end != 0)
            {
                for (int k = 0; k < end; k++)
                {

                    if ((ds1.Tables[0].Rows[k]["FECHA_DEVENGADO"].ToString()) == ("00/00/0000"))
                    {
                        if (ds1.Tables[0].Rows[k]["FECHA_COMPROMISO"].ToString() != ("00/00/0000"))
                        {
                            //string iDate = "2005-05-05";
                            //DateTime oDate = DateTime.Parse(iDate);
                            string iDate = ds1.Tables[0].Rows[k]["FECHA_COMPROMISO"].ToString().Substring(8, 2) + "/" + ds1.Tables[0].Rows[k]["FECHA_COMPROMISO"].ToString().Substring(5, 2) + "/" + ds1.Tables[0].Rows[k]["FECHA_COMPROMISO"].ToString().Substring(0, 4);
                            DateTime oDate = Convert.ToDateTime(ds1.Tables[0].Rows[k]["FECHA_COMPROMISO"].ToString());

                            DateTime newDate = DateTime.Now;

                            // Difference in days, hours, and minutes.
                            TimeSpan ts = newDate - oDate;

                            // Difference in days.
                            //int differenceInDays = ts.Days;
                            ds1.Tables[0].Rows[k]["DEVENGADO_DEMORA"] = ts.Days.ToString();

                        }
                    }
                    else
                        if ((ds1.Tables[0].Rows[k]["FECHA_GIRADO"].ToString()) == ("00/00/0000"))
                            if (ds1.Tables[0].Rows[k]["FECHA_DEVENGADO"].ToString() != ("00/00/0000"))
                            {
                                //string iDate = "2005-05-05";
                                //DateTime oDate = DateTime.Parse(iDate);
                                string iDate = ds1.Tables[0].Rows[k]["FECHA_DEVENGADO"].ToString().Substring(8, 2) + "/" + ds1.Tables[0].Rows[k]["FECHA_DEVENGADO"].ToString().Substring(5, 2) + "/" + ds1.Tables[0].Rows[k]["FECHA_DEVENGADO"].ToString().Substring(0, 4);
                                DateTime oDate = Convert.ToDateTime(ds1.Tables[0].Rows[k]["FECHA_DEVENGADO"].ToString());

                                DateTime newDate = DateTime.Now;

                                // Difference in days, hours, and minutes.
                                TimeSpan ts = newDate - oDate;

                                // Difference in days.
                                //int differenceInDays = ts.Days;
                                ds1.Tables[0].Rows[k]["GIRADO_DEMORA"] = ts.Days.ToString();
                            }
                            //else
                            //{
                            //    if ((ds1.Tables[0].Rows[k]["FECHA_COMPROMISO"].ToString()) == ("00/00/0000"))
                            //        if (ds1.Tables[0].Rows[k]["FECHA_CERTIFICADO"].ToString() != ("00/00/0000"))
                            //        {
                            //            //string iDate = "2005-05-05";
                            //            //DateTime oDate = DateTime.Parse(iDate);
                            //            string iDate = ds1.Tables[0].Rows[k]["FECHA_CERTIFICADO"].ToString().Substring(8, 2) + "/" + ds1.Tables[0].Rows[k]["FECHA_DEVENGADO"].ToString().Substring(5, 2) + "/" + ds1.Tables[0].Rows[k]["FECHA_DEVENGADO"].ToString().Substring(0, 4);
                            //            DateTime oDate = Convert.ToDateTime(ds1.Tables[0].Rows[k]["FECHA_CERTIFICADO"].ToString());

                            //            DateTime newDate = DateTime.Now;

                            //            // Difference in days, hours, and minutes.
                            //            TimeSpan ts = newDate - oDate;

                            //            // Difference in days.
                            //            //int differenceInDays = ts.Days;
                            //            ds1.Tables[0].Rows[k]["COMPROMISO_DEMORA"] = ts.Days.ToString();
                            //        }

                            //}
                }

            }
            return ds1;
        }
        #endregion


        #region SearchByPresupuestoEte
        public static DataSet SearchByPresupuestoEte(string IdSecEjec, string BaseDeDatos, string IdAnoEje)
        {

            string StringSql = " ";

            StringSql = " SELECT A.*, 0.00 as DEVENGADO_6,0.00 as PIM_EJECUCION, 0.00 as PORCENTAJE_META, 0.00 as PENDIENTE, 0.00 as IMPORTE_MINIMO  FROM " + BaseDeDatos + ".infoges_dashboard_presupuesto A ";
            StringSql += " WHERE A.ANO_EJE='" + IdAnoEje + "' AND A.SEC_EJEC='" + IdSecEjec + "' ";
            DataSet ds1 = Mysqlquery(StringSql);

            int end = ds1.Tables[0].Rows.Count;
            if (end != 0)
            {
                for (int k = 0; k < end; k++)
                {
                    ds1.Tables[0].Rows[k]["PIM"] = Convert.ToDecimal(ds1.Tables[0].Rows[k]["ENCARGO"]) + Convert.ToDecimal(ds1.Tables[0].Rows[k]["PIM"]);
                    ds1.Tables[0].Rows[k]["SALDO_PIM"] = Convert.ToDecimal(ds1.Tables[0].Rows[k]["PIM"]) - Convert.ToDecimal(ds1.Tables[0].Rows[k]["DEVENGADO"]);
                    ds1.Tables[0].Rows[k]["PORCENTAJE_PIM"] = Decimal.Round((Convert.ToDecimal(ds1.Tables[0].Rows[k]["PIM"]) - Convert.ToDecimal(ds1.Tables[0].Rows[k]["DEVENGADO"])) / Convert.ToDecimal(ds1.Tables[0].Rows[k]["PIM"]) * 100, 2);
                    ds1.Tables[0].Rows[k]["PORCENTAJE_EJECUCION"] = Decimal.Round(Convert.ToDecimal(ds1.Tables[0].Rows[k]["DEVENGADO"]) / Convert.ToDecimal(ds1.Tables[0].Rows[k]["PIM"]) * 100, 2);

                }

            }
            return ds1;
        }
        #endregion
        #region SearchByEncargoEte
        public static DataSet SearchByEncargoEte(string IdSecEjec, string BaseDeDatos, string IdAnoEje)
        {

            string StringSql = " ";
            // SE MODIFICO POR OBSERVACION DE SANDRA A.ENCARGO-A.DEVOLUCION-A.GIRADO
            //StringSql = " SELECT A.*,A.ENCARGO-A.DEVOLUCION AS MONTO_NETO,A.ENCARGO-A.DEVOLUCION-A.GIRADO AS MONTO_SALDO, 0.00 AS COMPROMISO_PORCENTAJE,0.00 AS DEVENGADO_PORCENTAJE,0.00 AS GIRADO_PORCENTAJE, 0.00 AS PAGADO_PORCENTAJE  FROM " + BaseDeDatos + ".infoges_dashboard_resumen_encargo A ";
            StringSql = " SELECT A.*,A.ENCARGO-A.DEVOLUCION AS MONTO_NETO,A.ENCARGO-A.DEVOLUCION-A.DEVENGADO AS MONTO_SALDO, 0.00 AS COMPROMISO_PORCENTAJE,0.00 AS DEVENGADO_PORCENTAJE,0.00 AS GIRADO_PORCENTAJE, 0.00 AS PAGADO_PORCENTAJE  FROM " + BaseDeDatos + ".infoges_dashboard_resumen_encargo A ";
            StringSql += " WHERE A.ANO_EJE='" + IdAnoEje + "' AND A.SEC_EJEC='" + IdSecEjec + "' ";
            DataSet ds1 = Mysqlquery(StringSql);
            int end = ds1.Tables[0].Rows.Count;
            if (end != 0)
            {
                for (int k = 0; k < end; k++)
                {
                    if (Convert.ToDecimal(ds1.Tables[0].Rows[k]["ENCARGO"]) > 0)
                    {
                        ds1.Tables[0].Rows[k]["COMPROMISO_PORCENTAJE"] = Decimal.Round(Convert.ToDecimal(ds1.Tables[0].Rows[k]["COMPROMISO"]) / Convert.ToDecimal(ds1.Tables[0].Rows[k]["MONTO_NETO"]) * 100, 2);
                        ds1.Tables[0].Rows[k]["DEVENGADO_PORCENTAJE"] = Decimal.Round(Convert.ToDecimal(ds1.Tables[0].Rows[k]["DEVENGADO"]) / Convert.ToDecimal(ds1.Tables[0].Rows[k]["MONTO_NETO"]) * 100, 2);
                        ds1.Tables[0].Rows[k]["GIRADO_PORCENTAJE"] = Decimal.Round(Convert.ToDecimal(ds1.Tables[0].Rows[k]["GIRADO"]) / Convert.ToDecimal(ds1.Tables[0].Rows[k]["MONTO_NETO"]) * 100, 2);
                        ds1.Tables[0].Rows[k]["PAGADO_PORCENTAJE"] = Decimal.Round(Convert.ToDecimal(ds1.Tables[0].Rows[k]["PAGADO"]) / Convert.ToDecimal(ds1.Tables[0].Rows[k]["MONTO_NETO"]) * 100, 2);

                    }
                    else
                    {
                        ds1.Tables[0].Rows[k]["COMPROMISO_PORCENTAJE"] = 0;
                        ds1.Tables[0].Rows[k]["DEVENGADO_PORCENTAJE"] = 0;
                        ds1.Tables[0].Rows[k]["GIRADO_PORCENTAJE"] = 0;
                        ds1.Tables[0].Rows[k]["PAGADO_PORCENTAJE"] = 0;
                    }
 
                }

            }
            return ds1;
        }
        #endregion

        #region SearchByGrupoGenericoEte

        public static DataSet SearchByGrupoGenericoEte(string IdSecEjec, string BaseDeDatos, string IdAnoEje)
        {

            string StringSql = " ";
            StringSql = " SELECT * FROM " + BaseDeDatos + ".infoges_dashboard_generica WHERE ANO_EJE='" + IdAnoEje + "' AND SEC_EJEC='" + IdSecEjec + "'";
            DataSet ds1 = Mysqlquery(StringSql);
            int end = ds1.Tables[0].Rows.Count;
            if (end != 0)
            {
                for (int k = 0; k < end; k++)
                {
                    ds1.Tables[0].Rows[k]["PIM"] = Convert.ToDecimal(ds1.Tables[0].Rows[k]["ENCARGO"]) + Convert.ToDecimal(ds1.Tables[0].Rows[k]["PIM"]);
                    ds1.Tables[0].Rows[k]["SALDO_PIM"] = Convert.ToDecimal(ds1.Tables[0].Rows[k]["PIM"]) - Convert.ToDecimal(ds1.Tables[0].Rows[k]["DEVENGADO"]);
                    ds1.Tables[0].Rows[k]["PORCENTAJE_PIM"] = Decimal.Round((Convert.ToDecimal(ds1.Tables[0].Rows[k]["PIM"]) - Convert.ToDecimal(ds1.Tables[0].Rows[k]["DEVENGADO"])) / Convert.ToDecimal(ds1.Tables[0].Rows[k]["PIM"]) * 100, 2);
                    ds1.Tables[0].Rows[k]["PORCENTAJE_EJECUCION"] = Decimal.Round(Convert.ToDecimal(ds1.Tables[0].Rows[k]["DEVENGADO"]) / Convert.ToDecimal(ds1.Tables[0].Rows[k]["PIM"]) * 100, 2);

                }

            }
            return ds1;
        }
        #endregion
        #region SearchByFuenteFinancEte
        public static DataSet SearchByFuenteFinancEte(string IdSecEjec, string BaseDeDatos, string IdAnoEje)
        {

            string StringSql = " ";
            StringSql = " SELECT * FROM " + BaseDeDatos + ".infoges_dashboard_fuentefinanc WHERE ANO_EJE='" + IdAnoEje + "' AND SEC_EJEC='" + IdSecEjec + "'";

            DataSet ds1 = Mysqlquery(StringSql);


            int end = ds1.Tables[0].Rows.Count;
            if (end != 0)
            {
                for (int k = 0; k < end; k++)
                {
                    ds1.Tables[0].Rows[k]["PIM"]            = Convert.ToDecimal(ds1.Tables[0].Rows[k]["ENCARGO"]) + Convert.ToDecimal(ds1.Tables[0].Rows[k]["PIM"]);
                    ds1.Tables[0].Rows[k]["SALDO_RECAUDADO"] = Convert.ToDecimal(ds1.Tables[0].Rows[k]["PIM"]) - Convert.ToDecimal(ds1.Tables[0].Rows[k]["GIRADO"]) ;
                    ds1.Tables[0].Rows[k]["PORCENTAJE_PROYECTADO"] = Decimal.Round( Convert.ToDecimal(ds1.Tables[0].Rows[k]["SALDO_RECAUDADO"]) / Convert.ToDecimal(ds1.Tables[0].Rows[k]["PIM"])*100,2);

                }

            }


            return ds1;
        }
        #endregion

        #region SearchByFuncionEte
        public static DataSet SearchByFuncionEte(string IdSecEjec, string BaseDeDatos, string IdAnoEje)
        {
            string StringSql = " ";
            StringSql = " SELECT * FROM " + BaseDeDatos + ".infoges_dashboard_funcion WHERE ANO_EJE='" + IdAnoEje + "' AND SEC_EJEC='" + IdSecEjec + "'";
            DataSet ds1 = Mysqlquery(StringSql);
            
            int end = ds1.Tables[0].Rows.Count;
            if (end != 0)
            {
                for (int k = 0; k < end; k++)
                {
                    ds1.Tables[0].Rows[k]["PIM"] = Convert.ToDecimal(ds1.Tables[0].Rows[k]["ENCARGO"]) + Convert.ToDecimal(ds1.Tables[0].Rows[k]["PIM"]);
                    ds1.Tables[0].Rows[k]["SALDO_PIM"] = Convert.ToDecimal(ds1.Tables[0].Rows[k]["PIM"]) - Convert.ToDecimal(ds1.Tables[0].Rows[k]["DEVENGADO"]);
                    ds1.Tables[0].Rows[k]["PORCENTAJE_EJECUCION"] = Decimal.Round(Convert.ToDecimal(ds1.Tables[0].Rows[k]["DEVENGADO"]) / Convert.ToDecimal(ds1.Tables[0].Rows[k]["PIM"]) * 100, 2);
                    ds1.Tables[0].Rows[k]["SALDO_PIM"] = Convert.ToDecimal(ds1.Tables[0].Rows[k]["ENCARGO"]) + Convert.ToDecimal(ds1.Tables[0].Rows[k]["SALDO_PIM"]);
                    ds1.Tables[0].Rows[k]["SALDO_PROYECTADO"] = Convert.ToDecimal(ds1.Tables[0].Rows[k]["ENCARGO"]) + Convert.ToDecimal(ds1.Tables[0].Rows[k]["SALDO_PROYECTADO"]);
                    ds1.Tables[0].Rows[k]["PORCENTAJE_PIM"] = Decimal.Round((Convert.ToDecimal(ds1.Tables[0].Rows[k]["PIM"]) - Convert.ToDecimal(ds1.Tables[0].Rows[k]["DEVENGADO"])) / Convert.ToDecimal(ds1.Tables[0].Rows[k]["PIM"]) * 100, 2);

                }

            }

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
