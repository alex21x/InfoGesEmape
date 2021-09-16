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
    public class Cuadro
    {
        #region SearchAllGenerica
        public static DataSet SearchAllGenerica(string ano_eje,string sec_ejec,string BaseDeDatos, Boolean lcDetalle)
        {

            //BaseDeDatos = "SIAF_301262";
            //sec_ejec = "301262";
            //ano_eje = "2019";
            string StringSql = " select ANO_EJE,CONCAT(CATEGORIA_GASTO,GENERICA) GENERICA, CONCAT(CATEGORIA_GASTO,'.',GENERICA,' ',GENERICA_NOMBRE) AS NOMBRE, sum(ejecucion) as EJECUCION ";
            if (lcDetalle)
                StringSql += " from "+BaseDeDatos+".inforeg_ejecucion_2009 ";
            else
                StringSql += " from " + BaseDeDatos + ".inforeg_ejecucion_2009 ";

            StringSql += " where sec_ejec='" + sec_ejec + "' and LENGTH(ID_CLASIFICADOR)>0 and ";
            if (Convert.ToInt32(ano_eje)<2009)
                ano_eje = "2001";
            if (lcDetalle)
                StringSql += " ano_eje='" + ano_eje + "' and  ";
            StringSql += " fase='D' and ciclo='G' ";
            StringSql += " group by ano_eje,categoria_gasto,generica ";

            return Mysqlquery(StringSql);
        }
        #endregion

        #region SearchAllProgramaPpto
        public static DataSet SearchAllProgramaPpto(string ano_eje, string sec_ejec, string BaseDeDatos)
        {


            string StringSql = " SELECT A.SEC_EJEC, A.TIPO_PROGRAMA_PPTO, A.EJECUCION, B.NOMBRE ";
            StringSql += " FROM ";
            StringSql += " (SELECT A.SEC_EJEC, A.TIPO_PROGRAMA_PPTO,SUM(A.EJECUCION) AS EJECUCION ";
            StringSql += " FROM " + BaseDeDatos + ".inforeg_ejecucion_2009 A ";
            StringSql += " where ano_eje='" + ano_eje + "' and sec_ejec='" + sec_ejec + "' and fase='D' and ciclo='G' ";
            StringSql += " GROUP BY A.SEC_EJEC, A.TIPO_PROGRAMA_PPTO) A, TIPO_PROGRAMA_PPTO_NOMBRE B ";
            StringSql += " WHERE A.TIPO_PROGRAMA_PPTO=B.TIPO_PROGRAMA_PPTO ";

            return Mysqlquery(StringSql);
        }
        #endregion


        #region SearchAllFteFto
        public static DataSet SearchAllFteFto(string ano_eje, string sec_ejec, string BaseDeDatos)
        {


            string StringSql = "SELECT CONCAT(FUENTE_FINANC,' ',FUENTE_FINANC_NOMBRE) AS FUENTE_FINANC,  SUM(EJECUCION) AS EJECUCION ";
            StringSql += " from " + BaseDeDatos + ".inforeg_ejecucion_2009 ";
            StringSql += " where ano_eje='" + ano_eje + "' and sec_ejec='" + sec_ejec + "' and fase='D' and ciclo='G' ";
            StringSql += " GROUP BY FUENTE_FINANC, FUENTE_FINANC_NOMBRE ";

            return Mysqlquery(StringSql);
        }
        #endregion

        #region SearchGastoAcumulado
        public static DataSet SearchGastoAcumulado(string ano_eje, string sec_ejec, string BaseDeDatos)
        {



            string StringSql = " SELECT ANO_EJE,'PIM' AS CAMPO, SUM(PIM) AS MONTO ";
            StringSql += " From " + BaseDeDatos + ".inforeg_ejecucion_2009 ";
            StringSql += " Where ano_eje='" + ano_eje + "' and sec_ejec='" + sec_ejec + "' ";
            StringSql += " AND CICLO='G' AND FASE='M' ";
            StringSql += " Group by ANO_EJE ";
            StringSql += " UNION ";
            StringSql += " SELECT ANO_EJE,'COMPROMISO' AS CAMPO, SUM(EJECUCION) AS MONTO ";
            StringSql += " From " + BaseDeDatos + ".inforeg_ejecucion_2009 ";
            StringSql += " Where ano_eje='" + ano_eje + "' and sec_ejec='" + sec_ejec + "' ";
            StringSql += " AND FASE='C' AND CICLO='G' ";
            StringSql += " Group by ANO_EJE ";
            StringSql += " UNION ";
            StringSql += " SELECT ANO_EJE,'DEVENGADO' AS CAMPO, SUM(EJECUCION) AS MONTO ";
            StringSql += " From " + BaseDeDatos + ".inforeg_ejecucion_2009 ";
            StringSql += " Where ano_eje='" + ano_eje + "' and sec_ejec='" + sec_ejec + "' ";
            StringSql += " AND fase='D' AND CICLO='G' ";
            StringSql += " Group by ANO_EJE ";
            StringSql += " UNION ";
            StringSql += " SELECT ANO_EJE,'GIRADO' AS CAMPO, SUM(EJECUCION) AS MONTO ";
            StringSql += " From " + BaseDeDatos + ".inforeg_ejecucion_2009 ";
            StringSql += " Where ano_eje='" + ano_eje + "' and sec_ejec='" + sec_ejec + "' ";
            StringSql += " AND fase='G' AND CICLO='G' ";
            StringSql += " Group by ANO_EJE ";
            return Mysqlquery(StringSql);

        }
        #endregion   

        #region SearchFuncionAcumulado
        public static DataSet SearchFuncionAcumulado(string ano_eje, string sec_ejec, string BaseDeDatos)
        {


            string StringSql = " select concat(funcion,' ',Funcion_nombre) as NOMBRE, sum(ejecucion) as EJECUCION ";
            StringSql += " from " + BaseDeDatos + ".inforeg_ejecucion_2009 ";
            StringSql += " where ano_eje='" + ano_eje + "' and sec_ejec='" + sec_ejec + "' and fase='D' and ciclo='G' ";
            StringSql += " group by funcion,funcion_nombre ";

            return Mysqlquery(StringSql);
        }
        #endregion

        #region SearchAllUbigeo
        public static DataSet SearchAllUbigeo(string ano_eje, string sec_ejec, string BaseDeDatos)
        {

            string StringSql = " Select departamento, concat(provincia,' ',provincia_nombre) as PROVINCIA ,Sum(ejecucion) AS EJECUCION ";
            StringSql += " from  " + BaseDeDatos + ".inforeg_ejecucion_2009 ";
            StringSql += " where ano_eje='" + ano_eje + "' and sec_ejec='" + sec_ejec + "' and fase='D' and ciclo='G' ";
            StringSql += " group by departamento, provincia,provincia_nombre ";

            return Mysqlquery(StringSql);
        }
        #endregion

        #region SearchAllContrato
        public static DataSet SearchAllContrato(string ano_eje, string sec_ejec, string BaseDeDatos)
        {


            string StringSql = " SELECT ID_PROCESO,TIPO_PROCESO,NUMERO_PROCESO,FECHA_CONTRATO,ANO_CONVOCATORIA,SIGLAS,RUC,NUMERO_CONTRATO,MONTO_CONTRATO,MONTO_COMPROMETIDO, MONTO_ADELANTO,MONTO_DEVENGADO,MONTO_GIRADO,MONTO_PAGADO,CONCAT(SEC_EJEC,ID_PROCESO,ID_CONTRATO) AS KEYCONTRATO ";
            StringSql += " from  " + BaseDeDatos + ".CONTRATO_PS ";
            StringSql += " where ano_CONVOCATORIA='" + ano_eje + "' and sec_ejec='" + sec_ejec + "' ";

            return Mysqlquery(StringSql);
        }
        #endregion


        #region SearchAllContrato1
        public static DataSet SearchAllContrato1(string sec_ejec, string BaseDeDatos)
        {


            string StringSql = " SELECT A.ID_PROCESO,A.TIPO_PROCESO,A.NUMERO_PROCESO,A.FECHA_CONTRATO,A.ANO_CONVOCATORIA,A.SIGLAS,A.RUC,A.NUMERO_CONTRATO,A.MONTO_CONTRATO,A.MONTO_COMPROMETIDO,B.DESCRIPCION_ABREVIADA, ";
            StringSql += " A.MONTO_ADELANTO,A.MONTO_DEVENGADO,A.MONTO_GIRADO,A.MONTO_PAGADO,CONCAT(A.SEC_EJEC,A.ID_PROCESO,A.ID_CONTRATO) AS KEYCONTRATO ";
            StringSql += " from  " + BaseDeDatos + ".CONTRATO_PS A, SIAFEMP.MAESTRO_DETALLE B";
            StringSql += " where a.sec_ejec='" + sec_ejec + "' ";
            StringSql += " AND A.TIPO_PROCESO=B.COD_DETALLE ";
            StringSql += " AND B.COD_MAESTRO='TIPO_PROCESO' ";


            return Mysqlquery(StringSql);
        }
        #endregion
        #region SearchAllFinalidad
        public static DataSet SearchAllFinalidad(string ano_eje, string sec_ejec, string BaseDeDatos)
        {


            string StringSql = " SELECT  FINALIDAD_NOMBRE,UNIDAD_MEDIDA_NOMBRE , sum(pim ) as PIM, sum(ejecucion) as EJECUCION ";
            StringSql += " from  " + BaseDeDatos + ".inforeg_ejecucion_2009 ";
            StringSql += " where ano_eje='" + ano_eje + "' and sec_ejec='" + sec_ejec + "' " ; 
                //and fase='D' and ciclo='G' ";
            StringSql += " and not  ";
            StringSql += " (fase='D' and ciclo='C' and fase='G' and ciclo='D' and fase='G' and ciclo='P') ";
            StringSql += " group by finalidad_nombre,unidad_medida ";
            StringSql += " ORDER BY SUM(EJECUCION) ";

            return Mysqlquery(StringSql);
        }
        #endregion

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

            
            string StringSql = " SELECT SEC_EJEC,NOMBRE,ABREVIATURA FROM  SIAFEMP.ejecutora where sec_ejec_pliego='"+IdSecEjec +"' ORDER BY SEC_EJEC";
            DataSet ds1= Mysqlquery(StringSql);
            if (ds1.Tables[0].Rows.Count==0)
            {
                StringSql = " SELECT SEC_EJEC,NOMBRE,ABREVIATURA FROM  SIAFEMP.ejecutora where sec_ejec='" + IdSecEjec + "' ORDER BY SEC_EJEC";
                ds1 = Mysqlquery(StringSql);
            }
            return ds1;
        }
        #endregion

        #region SearchByPresupuesto
        public static DataSet SearchByPresupuesto(string IdSecEjec, string BaseDeDatos, string IdCadena)
        {
            string StringSql = " SELECT ANO_EJE,SEC_EJEC, SUM(PIA) AS PIA, SUM(MODIFICACION) AS MODIFICACION, SUM(PIM) AS PIM ";
            StringSql += " FROM "+BaseDeDatos+".INFOREG_EJECUCION_2009 ";
            StringSql += " WHERE SEC_EJEC='"+IdSecEjec+"'";
            StringSql += " AND CICLO='G' AND FASE='M'";
            //StringSql += " AND ANO_EJE IN ("+IdCadena+")";
            StringSql += " AND ANO_EJE ='" + IdCadena + "'";
            StringSql += " GROUP BY ANO_EJE";
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
        public static DataSet SearchByGrupoGenerico(string IdSecEjec, string BaseDeDatos, string IdCadena)
        {

            string StringSql = " SELECT ANO_EJE,SEC_EJEC, CONCAT(A.CATEGORIA_GASTO,'.', A.GENERICA,' ',A.GENERICA_NOMBRE) AS GENERICA ,sum(ejecucion) as EJECUCION,";
            StringSql += " sum(ejecucion)/MAX(MES_EJE) as EJECUCIONPROMEDIOMENSUAL, ";
            StringSql += " sum(ejecucion/30) as EJECUCIONPROMEDIO ";
            StringSql += " FROM " + BaseDeDatos + ".INFOREG_EJECUCION_2009 A ";
            StringSql += " WHERE A.SEC_EJEC='" + IdSecEjec + "'";
            StringSql += " AND A.CICLO='G' AND A.FASE='D'";
            //StringSql += " AND ANO_EJE IN ("+IdCadena+")";
            StringSql += " AND ANO_EJE ='" + IdCadena + "'";
            StringSql += " GROUP BY A.ano_eje,A.CATEGORIA_GASTO,A.GENERICA";
            DataSet ds1 = Mysqlquery(StringSql);
            return ds1;
        }
        #endregion

        #region SearchByFuncion
        public static DataSet SearchByFuncion(string IdSecEjec, string BaseDeDatos, string IdCadena)
        {

            string StringSql = " SELECT ANO_EJE,SEC_EJEC, CONCAT(A.FUNCION,' ',A.FUNCION_NOMBRE) AS FUNCION_NOMBRE ,sum(ejecucion) as EJECUCION ";
            StringSql += " FROM " + BaseDeDatos + ".INFOREG_EJECUCION_2009 A ";
            StringSql += " WHERE A.SEC_EJEC='" + IdSecEjec + "'";
            StringSql += " AND A.CICLO='G' AND A.FASE='D'";
            //StringSql += " AND ANO_EJE IN ("+IdCadena+")";
            StringSql += " AND ANO_EJE ='" + IdCadena + "'";
            StringSql += " GROUP BY A.ANO_EJE,A.SEC_EJEC,A.FUNCION,A.FUNCION_NOMBRE";
            DataSet ds1 = Mysqlquery(StringSql);
            return ds1;
        }
        #endregion


        #region SearchByFuenteFinanc
        public static DataSet SearchByFuenteFinanc(string IdSecEjec, string BaseDeDatos, string IdCadena)
        {

            string StringSql = " SELECT ANO_EJE,SEC_EJEC, CONCAT(A.FUENTE_FINANC,' ',A.FUENTE_FINANC_NOMBRE) AS FUENTE_FINANC ,sum(ejecucion) as EJECUCION,";
            StringSql += " sum(ejecucion)/max(mes_eje) as EJECUCIONPROMEDIOMENSUAL, "; 
            StringSql += " sum(ejecucion/30) as EJECUCIONPROMEDIO ";
            StringSql += " FROM " + BaseDeDatos + ".INFOREG_EJECUCION_2009 A ";
            StringSql += " WHERE A.SEC_EJEC='" + IdSecEjec + "'";
            StringSql += " AND A.CICLO='G' AND A.FASE='D'";
            //StringSql += " AND ANO_EJE IN ("+IdCadena+")";
            StringSql += " AND ANO_EJE ='" + IdCadena + "'";
            StringSql += " GROUP BY A.ano_eje,A.FUENTE_FINANC,A.FUENTE_FINANC_NOMBRE";
            DataSet ds1 = Mysqlquery(StringSql);
            return ds1;
        }
        #endregion


        #region SearchByEspecificaGastov
        public static DataSet SearchByEspecificaGasto(string IdSecEjec, string BaseDeDatos, string IdCadena)
        {

            string StringSql = " SELECT A.ANO_EJE,A.SEC_EJEC,A.ID_CLASIFICADOR,A.ESPECIFICA_DET_NOMBRE,SUM(A.EJECUCION) AS EJECUCION, ";
            StringSql += " sum(ejecucion)/MAX(A.MES_EJE) as EJECUCIONPROMEDIOMENSUAL, ";
            StringSql += " sum(ejecucion/30) as EJECUCIONPROMEDIO ";
            StringSql += " FROM " + BaseDeDatos + ".INFOREG_EJECUCION_2009 A, " + BaseDeDatos + ".INFOGES_GRUPO B";
            StringSql += " WHERE A.SEC_EJEC='" + IdSecEjec + "'";
            StringSql += " AND A.CICLO='G' AND A.FASE='D'";
            StringSql += " AND A.ID_CLASIFICADOR=B.ID_CLASIFICADOR ";
            //StringSql += " AND ANO_EJE IN ("+IdCadena+")";
            StringSql += " AND ANO_EJE ='" + IdCadena + "'";
            StringSql += " GROUP BY A.ANO_EJE,A.SEC_EJEC,A.ID_CLASIFICADOR,A.ESPECIFICA_DET_NOMBRE ";
            StringSql += " ORDER BY A.ANO_EJE,A.SEC_EJEC,B.IDGRUPO,B.ID_CLASIFICADOR ";


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
