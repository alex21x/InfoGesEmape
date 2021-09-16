#region Using Directives
using System;
using System.Data;
using System.Diagnostics;
using System.Data.Common;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EntLibContrib.Data.MySql;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Text;
#endregion

namespace InfogesEmape.Code.Data.Forms.Graficos
{
    public class Curva_S_Avance_Obra
    {

        #region SearchAvanceObra


        #region SearchByCostoObraNew
        public static DataSet SearchByCostoObraNew(string IdPeriodo, string IdProyecto, string IdCategoriaPrograma, string IdComponenteObra, string IdProvincia, string IdDistrito, string IdBaseDeDatos)
        {

            string StringSql = "";
            //StringSql += " SELECT  DISTINCT A.ANO_EJE,A.MES_EJE,SUM(A.EJECUCION) AS EJECUCION, SUM(A.COSTO_DIRECTO1) AS COSTODIRECTO , SUM(A.COSTO_TOTAL1) AS COSTOTOTAL, 0.00 AS COSTODIRECTOT, 0.00 AS COSTOTOTALT ";
            StringSql += " SELECT  DISTINCT A.ANO_EJE,A.MES_EJE,SUM(A.EJECUCION) AS EJECUCION, SUM(A.COSTO_DIRECTO1) AS COSTODIRECTO , SUM(A.COSTO_TOTAL1) AS COSTOTOTAL, 0.00 AS EJECUCIONT, 0.00 AS COSTODIRECTOT, 0.00 AS COSTOTOTALT  ";
            StringSql += " FROM  ";
            StringSql += " ((SELECT  DISTINCT A.ID_PROCESO,A.ID_CONTRATO,A.SEC_EJEC,A.ANO_EJE,A.MES_EJE,SUM(A.EJECUCION) AS EJECUCION, 0.00 AS COSTO_DIRECTO1, 0.00 AS COSTO_TOTAL1 ";
            StringSql += " FROM  " + IdBaseDeDatos + ".INFOREG_EJECUCION_2009 A, " + IdBaseDeDatos + ".OBRA_CONTRATO_DETALLE B ";
            StringSql += " WHERE A.CICLO='G' AND A.FASE='G' AND LENGTH(A.ID_CONTRATO)>3 AND ";
            if (IdProyecto!="0")
                StringSql +=" A.ACT_PROY='"+IdProyecto+"' AND ";

            if (IdCategoriaPrograma != "0")
                StringSql += " B.ID_CATEGORIA_PROGRAMA='" +IdCategoriaPrograma + "' AND ";

            StringSql += " A.SEC_EJEC=B.SEC_EJEC AND ";
            StringSql += " A.ID_PROCESO=B.ID_PROCESO AND ";
            StringSql += " A.ID_CONTRATO=B.ID_CONTRATO  ";
            StringSql += " GROUP BY A.ID_PROCESO,A.ID_CONTRATO,A.SEC_EJEC,A.ANO_EJE,A.MES_EJE)  ";
            StringSql += " UNION ";
            StringSql += " ( ";
            StringSql += " SELECT  DISTINCT E.ID_PROCESO,E.ID_CONTRATO,E.SEC_EJEC,  ";
            StringSql += " A.ANO_EJE, "; 
            StringSql += " A.MES_EJE, 0.00 AS EJECUCION, ";
            StringSql += " SUM(B.COSTO_DIRECTO) AS COSTO_DIRECTO1, "; 
            StringSql += " SUM(B.TOTAL_GENERAL) AS COSTO_TOTAL1 ";
            StringSql += " FROM   " + IdBaseDeDatos + ".OBRA_CONTRATO_DETALLE E, ";
            StringSql += " " + IdBaseDeDatos + ".OBRA_CONTRATO_VALORIZACION A, ";
            StringSql += " " + IdBaseDeDatos + ".OBRA_VALORIZACION_DETALLE1 B, ";
            StringSql += " " + IdBaseDeDatos + ".OBRA_CONTRATO_UBIGEO C, ";
            StringSql += " " + IdBaseDeDatos + ".MAESTRO_VALORIZACION_SUSTENTO D, ";
            StringSql += " (SELECT DISTINCT ID_PROCESO,ID_CONTRATO,SEC_EJEC FROM "+ IdBaseDeDatos +".INFOREG_EJECUCION_2009 ";
            if (IdProyecto != "0")
                StringSql += " WHERE ACT_PROY='" + IdProyecto + "' ";
            StringSql += " GROUP BY ID_PROCESO,ID_CONTRATO,SEC_EJEC ) F "; 
            StringSql += " WHERE E.ID_OBRA_CONTRATO_DETALLE=A.ID_OBRA_CONTRATO_DETALLE ";
            if (IdCategoriaPrograma != "0")
                StringSql += " AND E.ID_CATEGORIA_PROGRAMA='" + IdCategoriaPrograma + "' ";
            StringSql += " AND A.ID_OBRA_CONTRATO_VALORIZACION=B.ID_OBRA_CONTRATO_VALORIZACION  ";
            StringSql += " AND B.ID_OBRA_CONTRATO_UBIGEO=C.ID_OBRA_CONTRATO_UBIGEO  ";
            StringSql += " AND B.ID_TIPO_SUSTENTO_VALORIZACION=D.ID_TIPO_SUSTENTO_VALORIZACION  ";
            StringSql += " AND E.ID_PROCESO=F.ID_PROCESO ";
            StringSql += " AND E.ID_CONTRATO=F.ID_CONTRATO ";
            StringSql += " AND E.SEC_EJEC=F.SEC_EJEC ";
            StringSql += " GROUP BY  E.ID_PROCESO,E.ID_CONTRATO,E.SEC_EJEC,A.ANO_EJE, A.MES_EJE ";
            StringSql += " )) A ";
            StringSql += " GROUP BY  A.ANO_EJE,A.MES_EJE ";
            StringSql += " ORDER BY  A.ANO_EJE ASC ,A.MES_EJE ASC ";
            DataSet ds1 = Mysqlquery(StringSql);
            int end = ds1.Tables[0].Rows.Count;
            decimal COSTOTOTALT = 0;
            decimal COSTODIRECTOT = 0;
            decimal EJECUCIONT = 0;


            if (end != 0)
            {
                for (int k = 0; k < end; k++)
                {

                    ds1.Tables[0].Rows[k]["COSTODIRECTOT"]  = COSTODIRECTOT + Convert.ToDecimal(ds1.Tables[0].Rows[k]["COSTODIRECTO"]);
                    ds1.Tables[0].Rows[k]["COSTOTOTALT"]    = COSTOTOTALT + Convert.ToDecimal(ds1.Tables[0].Rows[k]["COSTOTOTAL"]);
                    ds1.Tables[0].Rows[k]["EJECUCIONT"]     = EJECUCIONT + Convert.ToDecimal(ds1.Tables[0].Rows[k]["EJECUCION"]);
                    COSTODIRECTOT = COSTODIRECTOT + Convert.ToDecimal(ds1.Tables[0].Rows[k]["COSTODIRECTO"]);
                    COSTOTOTALT = COSTOTOTALT + Convert.ToDecimal(ds1.Tables[0].Rows[k]["COSTOTOTAL"]);
                    EJECUCIONT = EJECUCIONT + Convert.ToDecimal(ds1.Tables[0].Rows[k]["EJECUCIONT"]);
                }
            }

            StringSql = " SELECT DISTINCT  A.ANO_EJE,A.MES_EJE, ";
            StringSql +=" SUM(A.COSTO_DIRECTO_PORCENTUAL) AS DIRECTO_PORC,  ";
            StringSql +=" SUM(A.MONTO_CONTRACTUAL_PORCENTUAL) AS CONTRACTUAL_PORC ";
            StringSql +=" FROM ( ";
            StringSql +=" SELECT  ";
            StringSql +=" B.ANO_EJE,B.MES_EJE,B.PORCENTAJE_CRONOGRAMA, ";
            StringSql +=" ROUND(B.PORCENTAJE_CRONOGRAMA*A.MONTO_COSTO_DIRECTO/100, 2) AS COSTO_DIRECTO_PORCENTUAL, ";
            StringSql +=" ROUND(B.PORCENTAJE_CRONOGRAMA*A.MONTO_CONTRACTUAL/100,2) AS   MONTO_CONTRACTUAL_PORCENTUAL, ";
            StringSql +=" A.MONTO_COSTO_DIRECTO,A.MONTO_CONTRACTUAL ";
            StringSql +=" FROM OBRA_CONTRATO_UBIGEO A, OBRA_COSTO_X_MES B, OBRA_CONTRATO_DETALLE C,  ";
            StringSql +=" ( ";
            StringSql +=" SELECT DISTINCT SEC_EJEC,ID_PROCESO,ID_CONTRATO,ACT_PROY  ";
            StringSql += " FROM " + IdBaseDeDatos + ".INFOREG_EJECUCION_2009  ";
            StringSql +=" WHERE LENGTH(ID_CONTRATO)>3 ";
            StringSql +=" GROUP BY  SEC_EJEC,ID_PROCESO,ID_CONTRATO  ";
            StringSql +=" ) D ";
            StringSql +=" WHERE A.ID_OBRA_CONTRATO_DETALLE=C.ID_OBRA_CONTRATO_DETALLE "; 
            StringSql +=" AND A.ID_OBRA_CONTRATO_UBIGEO=B.ID_OBRA_CONTRATO_UBIGEO  ";
            StringSql +=" AND D.SEC_EJEC=C.SEC_EJEC  ";
            StringSql +=" AND D.ID_PROCESO=C.ID_PROCESO ";
            StringSql +=" AND D.ID_CONTRATO=C.ID_CONTRATO ";
            StringSql +=" ) A ";
            StringSql +=" GROUP BY  A.ANO_EJE,A.MES_EJE ";



            return ds1;
        }
        #endregion

       //Generacion de Combos

        #region SearchAllPeriodoDistinct
        public static DataSet SearchAllPeriodoDistinct(string IdOperador)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = " (SELECT distinct year(fecha_inicio) as ID_PERIODO , year(fecha_inicio) AS DESCRIPCION_PERIODO from SIAF_001335.proyecto where ID_OPERADOR="+IdOperador.ToString()+") ";
            sqlCommand       += " UNION (SELECT 0 ID_PERIODO, 'TODAS' AS DESCRIPCION_PERIODO) ORDER BY ID_PERIODO";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            DataSet ds1 = null;
            try
            {
                ds1 = db.ExecuteDataSet(dbCommand);
            }
            catch (Exception e1) { Trace.Write("Search, Error : " + e1.Message.ToString()); }
            return ds1;
        }
        #endregion

        #region SearchAllEstadoRegistro
        public static DataSet SearchAllEstadoRegistro()
        {
            string sqlCommand = " (Select A.ID_ESTADO_REGISTRO, A.DESCRIPCION from SIAF_MAESTROS_OBRAS.MAESTRO_ESTADO_REGISTRO A order by A.descripcion ) ";
            sqlCommand += " UNION ";
            sqlCommand += " ( SELECT 0 AS ID_ESTADO_REGISTRO, 'TODAS' AS DESCRIPCION)";
            sqlCommand += " ORDER BY ID_ESTADO_REGISTRO ";

            return Mysqlquery(sqlCommand);
        }
        #endregion

        #region SearchAllProyectoDistinct
        public static DataSet SearchAllProyectoDistinct(string IdBaseDeDatos)
        {

            string sqlCommand = " ( SELECT DISTINCT D.ACT_PROY,CONCAT(D.ACT_PROY,' ',D.NOMBRE_BANCO_PROYECTO) AS COD_PROYECTO ";
            sqlCommand += " FROM " + IdBaseDeDatos + ".INFOREG_EJECUCION_2009 B," + IdBaseDeDatos + ".CONTRATO_PS C, " + IdBaseDeDatos + ".OBRA_CONTRATO_DETALLE A, " + IdBaseDeDatos + ".INFOREG_BANCO_PROYECTO D ";
            sqlCommand += " WHERE  ";
            sqlCommand += " B.SEC_EJEC=C.SEC_EJEC ";
            sqlCommand += " AND B.ID_PROCESO=C.ID_PROCESO ";
            sqlCommand += " AND B.ID_CONTRATO=C.ID_CONTRATO ";
            sqlCommand += " AND A.ID_PROCESO=C.ID_PROCESO ";
            sqlCommand += " AND A.ID_CONTRATO=C.ID_CONTRATO ";
            sqlCommand += " AND B.ACT_PROY=D.ACT_PROY ";
            sqlCommand += " GROUP BY D.ACT_PROY,D.NOMBRE_BANCO_PROYECTO )";
            sqlCommand += " UNION (SELECT 0 AS ACT_PROY,'TODOS' AS COD_PROYECTO) ORDER BY ACT_PROY ";

            return Mysqlquery(sqlCommand);
        }
        #endregion

        #region SearchAllGrupoObraDistinct
        public static DataSet SearchAllGrupoObraDistinct(string IdProyecto, string IdBaseDeDatos)
        {
            string sqlCommand = " SELECT ID_CATEGORIA_PROGRAMA, DESCRIPCION_CATEGORIA_PROGRAMA FROM (";
            sqlCommand += " SELECT DISTINCT C.ID_CATEGORIA_PROGRAMA, C.DESCRIPCION AS DESCRIPCION_CATEGORIA_PROGRAMA ";
            sqlCommand += " FROM " + IdBaseDeDatos + ".INFOREG_EJECUCION_2009 A,  " + IdBaseDeDatos + ".OBRA_CONTRATO_DETALLE  B,  " + IdBaseDeDatos + ".MAESTRO_CATEGORIA_PROGRAMA C  ";
            sqlCommand += " WHERE A.ACT_PROY='"+IdProyecto+"' AND LENGTH(A.ID_CONTRATO)>3 ";
            sqlCommand += " AND A.ID_PROCESO=B.ID_PROCESO ";
            sqlCommand += " AND A.ID_CONTRATO=B.ID_CONTRATO ";
            sqlCommand += " AND A.SEC_EJEC=B.SEC_EJEC ";
            sqlCommand += " AND B.ID_CATEGORIA_PROGRAMA=C.ID_CATEGORIA_PROGRAMA ";
            sqlCommand += " GROUP BY C.ID_CATEGORIA_PROGRAMA, C.DESCRIPCION ";
            sqlCommand += " UNION ";
            sqlCommand += " SELECT 0 ID_CATEGORIA_PROGRAMA, 'TODAS' AS DESCRIPCION_CATEGORIA_PROGRAMA) A ";
            sqlCommand += " ORDER BY ID_CATEGORIA_PROGRAMA ";
            return Mysqlquery(sqlCommand);
        }
        #endregion

        //#region SearchAllContratoDistinct
        //public static DataSet SearchAllContratoDistinct(string IdProyecto)
        //{
        //    string sqlCommand = "SELECT DISTINCT ";
        //    sqlCommand += " A.ID_COMPONENTE_OBRA, ";
        //    sqlCommand += " D.DESCRIPCION AS DESCRIPCION_COMPONENTE  ";
        //    sqlCommand += " FROM SIAF_001335.OBRA_CONTRATO A,  ";
        //    sqlCommand += " SIAF_001335.PROYECTO_FUENTE_CREDITICIA C, ";
        //    sqlCommand += " SIAF_001335.MAESTRO_COMPONENTE_OBRA D ";
        //    sqlCommand += " WHERE C.ID_OBRA=A.ID_OBRA  ";
        //    sqlCommand += " AND A.ID_COMPONENTE_OBRA=D.ID_COMPONENTE_OBRA  ";
        //    sqlCommand += " AND C.ID_PROYECTO=" + IdProyecto + " ";
        //    sqlCommand += " UNION ";
        //    sqlCommand += " SELECT 0 ID_COMPONENTE_OBRA, 'TODAS' AS DESCRIPCION_COMPONENTE ";

        //    return Mysqlquery(sqlCommand);
        //}
        //#endregion

        #region SearchAllComponenteObraDistinct
        public static DataSet SearchAllComponenteObraDistinct(string IdProyecto, string IdCategoriaPrograma, string IdBaseDeDatos)
        {

            string sqlCommand = "SELECT ID_COMPONENTE_OBRA, DESCRIPCION_COMPONENTE   FROM ";
            sqlCommand += " (SELECT DISTINCT  ";
            sqlCommand += " A.ID_COMPONENTE_OBRA, "; 
            sqlCommand += " D.DESCRIPCION AS DESCRIPCION_COMPONENTE ";
            sqlCommand += " FROM " + IdBaseDeDatos + ".OBRA_CONTRATO A, "; 
            sqlCommand += " SIAF_MAESTROS_OBRAS.MAESTRO_COMPONENTE_OBRA D, ";
            sqlCommand += " " + IdBaseDeDatos + ".OBRA_CONTRATO_DETALLE E ";
            sqlCommand += " WHERE A.ID_COMPONENTE_OBRA=D.ID_COMPONENTE_OBRA ";
            sqlCommand += " AND A.ID_OBRA_CONTRATO=E.ID_OBRA_CONTRATO ";
            sqlCommand += " AND E.ID_CATEGORIA_PROGRAMA="+IdCategoriaPrograma.ToString()+" ";
            sqlCommand += " AND A.ID_PROYECTO="+IdProyecto.ToString()+" ";
            sqlCommand += " UNION ";
            sqlCommand += " SELECT 0 ID_COMPONENTE_OBRA, 'TODAS' AS DESCRIPCION_COMPONENTE ) A ";
            sqlCommand += " ORDER BY ID_COMPONENTE_OBRA ";

            return Mysqlquery(sqlCommand);
        }
        #endregion

        #region SearchAllProvinciaDistinct
        public static DataSet SearchAllProvinciaDistinct(string IdProyecto, string IdCategoriaPrograma, string IdComponenteObra, string IdBaseDeDatos)
        {

            string sqlCommand = "SELECT PROVINCIA, NOMBRE_PROVINCIA ";
            sqlCommand += " FROM ";
            sqlCommand += " ((SELECT G.PROVINCIA, G.NOMBRE AS NOMBRE_PROVINCIA ";
            sqlCommand += " from  ";
            sqlCommand += " " + IdBaseDeDatos + ".OBRA_CONTRATO A, ";
            sqlCommand += " " + IdBaseDeDatos + ".OBRA_CONTRATO_DETALLE B, ";
            sqlCommand += " " + IdBaseDeDatos + ".OBRA_CONTRATO_VALORIZACION C, ";
            sqlCommand += " " + IdBaseDeDatos + ".OBRA_VALORIZACION_DETALLE1 D, ";
            sqlCommand += " " + IdBaseDeDatos + ".OBRA_CONTRATO_UBIGEO E, ";
            sqlCommand += " SIAF_MAESTROS.DEPARTAMENTO F, "; 
            sqlCommand += " SIAF_MAESTROS.PROVINCIA G ";
            sqlCommand += " WHERE A.ID_OBRA_CONTRATO=B.ID_OBRA_CONTRATO "; 
            sqlCommand += " AND B.ID_OBRA_CONTRATO_DETALLE=C.ID_OBRA_CONTRATO_DETALLE "; 
            sqlCommand += " AND C.ID_OBRA_CONTRATO_VALORIZACION=D.ID_OBRA_CONTRATO_VALORIZACION  ";
            sqlCommand += " AND D.ID_OBRA_CONTRATO_UBIGEO=E.ID_OBRA_CONTRATO_UBIGEO "; 
            sqlCommand += " AND E.DEPARTAMENTO=F.DEPARTAMENTO "; 
            sqlCommand += " AND E.DEPARTAMENTO=G.DEPARTAMENTO "; 
            sqlCommand += " AND E.PROVINCIA=G.PROVINCIA ";
            sqlCommand += " AND A.ID_COMPONENTE_OBRA="+IdComponenteObra.ToString()+" ";
            sqlCommand += " AND B.ID_CATEGORIA_PROGRAMA="+IdCategoriaPrograma.ToString()+" ";
            sqlCommand += " AND A.ID_PROYECTO="+IdProyecto.ToString()+" ";
            sqlCommand += " AND F.DEPARTAMENTO='22' ";
            sqlCommand += " GROUP BY G.PROVINCIA) ";
            sqlCommand += " UNION ";
            sqlCommand += " (SELECT '00' PROVINCIA, 'TODAS' AS NOMBRE_PROVINCIA)) A ";
            sqlCommand += " ORDER BY PROVINCIA ";

            return Mysqlquery(sqlCommand);
        }
        #endregion

        #region SearchAllDistritoDistinct
        public static DataSet SearchAllDistritoDistinct(string IdProyecto, string IdCategoriaPrograma, string IdComponenteObra, string IdProvincia, string IdBaseDeDatos)
        {
            string sqlCommand = "SELECT DISTRITO, NOMBRE_DISTRITO ";
            sqlCommand += " FROM  ";
            sqlCommand += " ((SELECT F.DISTRITO, ";
            sqlCommand += " CONCAT(F.NOMBRE,IF(E.DESCRIPCION_MULTIDISTRITAL IS NULL,'',CONCAT('(',RTRIM(E.DESCRIPCION_MULTIDISTRITAL),')'))) AS NOMBRE_DISTRITO ";
            sqlCommand += " from   ";
            sqlCommand += " " + IdBaseDeDatos + ".OBRA_CONTRATO A,  ";
            sqlCommand += " " + IdBaseDeDatos + ".OBRA_CONTRATO_DETALLE B,  ";
            sqlCommand += " " + IdBaseDeDatos + ".OBRA_CONTRATO_VALORIZACION C,  ";
            sqlCommand += " " + IdBaseDeDatos + ".OBRA_VALORIZACION_DETALLE1 D,  ";
            sqlCommand += " " + IdBaseDeDatos + ".OBRA_CONTRATO_UBIGEO E,  ";
            sqlCommand += " SIAF_MAESTROS.DISTRITO F ";
            sqlCommand += " WHERE A.ID_OBRA_CONTRATO=B.ID_OBRA_CONTRATO  ";
            sqlCommand += " AND B.ID_OBRA_CONTRATO_DETALLE=C.ID_OBRA_CONTRATO_DETALLE  ";
            sqlCommand += " AND C.ID_OBRA_CONTRATO_VALORIZACION=D.ID_OBRA_CONTRATO_VALORIZACION  ";
            sqlCommand += " AND D.ID_OBRA_CONTRATO_UBIGEO=E.ID_OBRA_CONTRATO_UBIGEO  ";
            sqlCommand += " AND E.DEPARTAMENTO=F.DEPARTAMENTO  ";
            sqlCommand += " AND E.PROVINCIA=F.PROVINCIA  ";
            sqlCommand += " AND E.DISTRITO=F.DISTRITO ";
            sqlCommand += " AND A.ID_COMPONENTE_OBRA=" + IdComponenteObra.ToString() + " ";
            sqlCommand += " AND B.ID_CATEGORIA_PROGRAMA=" + IdCategoriaPrograma.ToString() + " ";
            sqlCommand += " AND A.ID_PROYECTO=" + IdProyecto.ToString() + " ";
            sqlCommand += " AND E.DEPARTAMENTO='22' ";
            sqlCommand += " AND E.PROVINCIA="+IdProvincia.ToString()+" ";
            sqlCommand += " GROUP BY F.DISTRITO) ";
            sqlCommand += " UNION ";
            sqlCommand += " (SELECT '00' DISTRITO, 'TODAS' AS NOMBRE_DISTRITO)) A ";
            sqlCommand += " ORDER BY DISTRITO ";

            return Mysqlquery(sqlCommand);
        }
        #endregion

        #endregion
        internal static DataSet SearchAllGrupoObraDistinct()
        {
            throw new NotImplementedException();
        }


        /*******************************************************/
        /***********************Google Maps*********************/
        /*******************************************************/

        #region SearchAllGmapUbigeo
        public static DataSet SearchAllGmapUbigeo(string IdProyecto)
        {
            Database db = DatabaseFactory.CreateDatabase();
            //string sqlCommand = " (SELECT ID_PROYECTO,COD_PROYECTO from siaf_001335.PROYECTO A, Biolatina.operador B ";
            //sqlCommand += " WHERE A.ID_OPERADOR=B.ID_OPERADOR AND A.ID_OPERADOR= " + IdOperador.ToString() + " order by A.COD_PROYECTO) ";
            //sqlCommand += " UNION (SELECT 0 AS ID_PROYECTO,'TODOS' AS COD_PROYECTO) ORDER BY ID_PROYECTO ";

            string sqlCommand = " ";
            sqlCommand += " SELECT DISTINCT E.DEPARTAMENTO,E.PROVINCIA,E.DISTRITO,F.NOMBRE AS NOMBRE_PROVINCIA, G.NOMBRE AS NOMBRE_DISTRITO, ";
            sqlCommand += " SUM(if(E.MONTO_COSTO_DIRECTO is null,0,E.MONTO_COSTO_DIRECTO)) as MONTO_COSTO_DIRECTO, ";
            sqlCommand += " SUM(if(E.MONTO_CONTRACTUAL is null,0,E.MONTO_CONTRACTUAL)) as MONTO_CONTRACTUAL, ";
            sqlCommand += " if(G.ALTITUD is null,0,G.ALTITUD) as ALTITUD, ";
            sqlCommand += " if(G.LATITUD is null,0,G.LATITUD) as LATITUD ";
            sqlCommand += " FROM ";
            sqlCommand += " SIAF_001335.PROYECTO A, ";
            sqlCommand += " SIAF_001335.PROYECTO_FUENTE_CREDITICIA B, ";
            sqlCommand += " SIAF_001335.OBRA_CONTRATO C, ";
            sqlCommand += " SIAF_001335.OBRA_CONTRATO_DETALLE D, ";
            sqlCommand += " SIAF_001335.OBRA_CONTRATO_UBIGEO E, ";
            sqlCommand += " SIAF_MAESTROS.PROVINCIA F, ";
            sqlCommand += " SIAF_MAESTROS.DISTRITO G ";
            sqlCommand += " WHERE 1=1 ";
            sqlCommand += " AND A.ID_PROYECTO=B.ID_PROYECTO ";
            sqlCommand += " AND B.ID_OBRA=C.ID_OBRA ";
            sqlCommand += " AND C.ID_OBRA_CONTRATO=D.ID_OBRA_CONTRATO ";
            sqlCommand += " AND D.ID_OBRA_CONTRATO_DETALLE=E.ID_OBRA_CONTRATO_DETALLE ";
            sqlCommand += " AND E.DEPARTAMENTO=F.DEPARTAMENTO ";
            sqlCommand += " AND E.PROVINCIA=F.PROVINCIA ";
            sqlCommand += " AND E.DEPARTAMENTO=G.DEPARTAMENTO ";
            sqlCommand += " AND E.PROVINCIA=G.PROVINCIA ";
            sqlCommand += " AND E.DISTRITO=G.DISTRITO ";
            if (IdProyecto.ToString() != "0")
                sqlCommand += " AND A.ID_PROYECTO=" + IdProyecto.ToString() + " ";
            else

            sqlCommand += " GROUP BY A.COD_PROYECTO,E.DEPARTAMENTO,E.PROVINCIA,E.DISTRITO ";
            //sqlCommand += " ORDER BY A.COD_PROYECTO,E.DEPARTAMENTO,E.PROVINCIA,E.DISTRITO ";

            {
            //sqlCommand += " SELECT DISTINCT A.ID_PROYECTO,A.COD_PROYECTO,E.DEPARTAMENTO,E.PROVINCIA,E.DISTRITO, ";
            //sqlCommand += " E.MONTO_COSTO_DIRECTO,E.MONTO_CONTRACTUAL,G.ALTITUD,G.LATITUD ";
            //sqlCommand += " FROM ";
            //sqlCommand += " SIAF_001335.PROYECTO A, ";
            //sqlCommand += " SIAF_001335.PROYECTO_FUENTE_CREDITICIA B, ";
            //sqlCommand += " SIAF_001335.OBRA_CONTRATO C, ";
            //sqlCommand += " SIAF_001335.OBRA_CONTRATO_DETALLE D, ";
            //sqlCommand += " SIAF_001335.OBRA_CONTRATO_UBIGEO E, ";
            //sqlCommand += " SIAF_MAESTROS.PROVINCIA F, ";
            //sqlCommand += " SIAF_MAESTROS.DISTRITO G ";
            //sqlCommand += " WHERE 1=1 ";
            //sqlCommand += " AND A.ID_PROYECTO=B.ID_PROYECTO ";
            //sqlCommand += " AND B.ID_OBRA=C.ID_OBRA ";
            //sqlCommand += " AND C.ID_OBRA_CONTRATO=D.ID_OBRA_CONTRATO ";
            //sqlCommand += " AND D.ID_OBRA_CONTRATO_DETALLE=D.ID_OBRA_CONTRATO_DETALLE ";
            //sqlCommand += " AND E.DEPARTAMENTO=F.DEPARTAMENTO ";
            //sqlCommand += " AND E.PROVINCIA=F.PROVINCIA ";
            //sqlCommand += " AND E.DEPARTAMENTO=G.DEPARTAMENTO ";
            //sqlCommand += " AND E.PROVINCIA=G.PROVINCIA ";
            //sqlCommand += " AND E.DISTRITO=G.DISTRITO ";
            //sqlCommand += " GROUP BY A.COD_PROYECTO,E.DEPARTAMENTO,E.PROVINCIA,E.DISTRITO ";
            //sqlCommand += " ORDER BY A.COD_PROYECTO,E.DEPARTAMENTO,E.PROVINCIA,E.DISTRITO ";
            }
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            DataSet ds1 = null;
            try
            {
                ds1 = db.ExecuteDataSet(dbCommand);
            }
            catch (Exception e1) { Trace.Write("Search, Error : " + e1.Message.ToString()); }
            return ds1;
        }
        #endregion


        /*******************************************************/
        /***********************Google Maps*********************/
        /*******************************************************/



        public static DataSet Mysqlquery(string Cadena)
        {
            //Database db = DatabaseFactory.CreateDatabase();
            //DbCommand dbCommand = db.GetSqlStringCommand(Cadena);
            //DataSet ds1 = null;
            //try
            //{
            //    ds1 = db.ExecuteDataSet(dbCommand);
            //}
            //catch (Exception ex)
            //{
            //    string Text = "Error: " + ex.Message.ToString();
            //}
            //return ds1;
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
