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
using System.Collections;
using System.Text;
using System.Data.SqlClient;
#endregion

namespace InfogesEmape.Code.Data.Forms.Consulta
{
    public class ConsultaEjecutoraClasificador
    {



        #region SearchConsultaAvanceProyecto
        public static DataSet SearchConsultaAvanceProyecto()
        {

            DataSet ds1 = new DataSet();
            try
            {
                using (SqlConnection conexion = new SqlConnection(Code.ConeccionString2.sql()))
                {
                    string StringSql = "";
                    StringSql += "   Select A.ACT_PROY, A.ACT_PROY_NOMBRE, ";
                    StringSql += "    CASE WHEN B.MONTO_INVERSION IS NULL THEN 0 ELSE B.MONTO_INVERSION END AS MONTO_INVERSION,  ";
                    StringSql += "   SUM(CASE WHEN A.FASE='D' THEN A.PIM ELSE 0 END ) AS EJECUCION_TOTAL, ";
                    StringSql += "   SUM(CASE WHEN A.ano_eje='2014' THEN A.PIM ELSE 0 END) AS gasto_2014, ";
                    StringSql += "   SUM(CASE WHEN A.ano_eje='2014' AND  A.FASE='D' THEN A.EJECUCION ELSE 0 END) AS EJECUCION_2014, ";
                    StringSql += "   SUM(CASE WHEN A.FUENTE_FINANC IN ('18') THEN A.PIM ELSE 0 END) AS PIM_FUENTE_FINANC_RD, ";
                    StringSql += "   SUM(CASE WHEN A.FUENTE_FINANC IN ('00') THEN A.PIM ELSE 0 END)  AS PIM_FUENTE_FINANC_RO, ";
                    StringSql += "   SUM(CASE WHEN A.FUENTE_FINANC IN ('09') THEN A.PIM ELSE 0 END)  AS PIM_FUENTE_FINANC_RDR, ";
                    StringSql += "   SUM(CASE WHEN A.FUENTE_FINANC IN ('13') THEN A.PIM ELSE 0 END) AS PIM_FUENTE_FINANC_DT, ";
                    StringSql += "   SUM(CASE WHEN A.FUENTE_FINANC IN ('18') AND A.FASE='D' THEN A.EJECUCION ELSE 0 END) AS EJE_FUENTE_FINANC_RD, ";
                    StringSql += "   SUM(CASE WHEN A.FUENTE_FINANC IN ('00') AND A.FASE='D' THEN A.EJECUCION ELSE 0 END) AS EJE_FUENTE_FINANC_RO, ";
                    StringSql += "   SUM(CASE WHEN A.FUENTE_FINANC IN ('09') AND A.FASE='D' THEN A.EJECUCION ELSE 0 END) AS EJE_FUENTE_FINANC_RDR, ";
                    StringSql += "   SUM(CASE WHEN A.FUENTE_FINANC IN ('13','13') AND A.FASE='D' THEN A.EJECUCION ELSE 0 END) AS EJE_FUENTE_FINANC_DT ";
                    StringSql += "   from dbo.inforeg_ejecucion_2009 A LEFT JOIN dbo.inforeg_banco_proyecto B ";
                    StringSql += "   on A.ACT_PROY=B.ACT_PROY    where SUBSTRING(A.act_proy,1,1)='2'";
                    StringSql += "   group by A.act_proy,A.act_proy_nombre ,B.MONTO_INVERSION ";
                    SqlDataAdapter adapter = new SqlDataAdapter(StringSql, conexion);
                    adapter.Fill(ds1);
                    int i = ds1.Tables[0].Rows.Count;
                }
            }
            catch (Exception e1) { Trace.Write("Search, Error : " + e1.Message.ToString()); }


            return ds1;
        }
        #endregion

        #region SearchConsultaEjecutoraClasif
        public static DataSet SearchConsultaEjecutoraClasif(string pId)
        {

            DataSet ds1 = new DataSet();
            try
            {
                using (SqlConnection conexion = new SqlConnection(Code.ConeccionString2.sql()))
                {
                    string StringSql = "";
                    StringSql += " SELECT A.ANO_EJE,A.SEC_EJEC,A.ACT_PROY,A.FASE,A.FUENTE_FINANC,A.ID_CLASIFICADOR, ";
                    StringSql += " CONCAT(A.FUENTE_FINANC,' ',A.FUENTE_FINANC_NOMBRE) AS FUENTE_FINANC_NOMBRE, ";
                    StringSql += " CONCAT(A.CATEGORIA_GASTO,' ',A.GENERICA,' ',A.SUBGENERICA,' ',A.SUBGENERICA_DET,' ',A.ESPECIFICA,' ',A.ESPECIFICA_DET,' ',A.ESPECIFICA_DET_NOMBRE) AS ESPECIFICA_DET, ";
                    StringSql += " sum(If(A.mes_eje='01',A.EJECUCION,0)) as ENERO,   sum(If(A.mes_eje='02',A.EJECUCION,0)) as FEBRERO,   sum(If(A.mes_eje='03',A.EJECUCION,0)) as MARZO, ";
                    StringSql += " sum(If(A.mes_eje='04',A.EJECUCION,0)) as ABRIL,   sum(If(A.mes_eje='05',A.EJECUCION,0)) as MAYO,   sum(If(A.mes_eje='06',A.EJECUCION,0)) as JUNIO, ";
                    StringSql += " sum(If(A.mes_eje='07',A.EJECUCION,0)) as JULIO,   sum(If(A.mes_eje='08',A.EJECUCION,0)) as AGOSTO,   sum(If(A.mes_eje='09',A.EJECUCION,0)) as SETIEMBRE, ";
                    StringSql += " sum(If(A.mes_eje='10',A.EJECUCION,0)) as OCTUBRE, sum(If(A.mes_eje='11',A.EJECUCION,0)) as NOVIEMBRE,   sum(If(A.mes_eje='12',A.EJECUCION,0)) as DICIEMBRE , ";
                    StringSql += " sum(EJECUCION) as TOTAL_EJECUTADO  ";
                    StringSql += " FROM SIAF_001335.INFOGES_EJECUCION_MPP_REGION A ";
                    StringSql += " WHERE A.ANO_EJE='" + pId.Substring(0, 4) + "' ";
                    StringSql += " AND A.SEC_EJEC='" + pId.Substring(4, 6) + "' ";
                    StringSql += " AND A.ACT_PROY='" + pId.Substring(10, 7) + "' ";
                    StringSql += " AND A.FASE='G' ";
                    StringSql += " GROUP BY A.ANO_EJE,A.SEC_EJEC,A.ACT_PROY,A.FASE,A.FUENTE_FINANC, A.CATEGORIA_GASTO, A.ID_CLASIFICADOR";

                    SqlDataAdapter adapter = new SqlDataAdapter(StringSql, conexion);
                    adapter.Fill(ds1);
                    int i = ds1.Tables[0].Rows.Count;
                }
            }
            catch (Exception e1) { Trace.Write("Search, Error : " + e1.Message.ToString()); }


            return ds1;
        }
        #endregion

        #region SearchObraUbigeoTotales
        public static DataSet SearchObraUbigeoTotales()
        {
            DataSet ds1 = new DataSet();


            try
            {           /**Sirve para calcular el acumulado de vance de obra**/
                using (SqlConnection conexion = new SqlConnection(Code.ConeccionString2.sql()))
                {
                    string StringSql = "";
                    StringSql += " SELECT A.COD_PROYECTO, ";
                    StringSql += " I.DESCRIPCION AS DESCRIPCION_CATEGORIA_PROGRAMA, ";
                    StringSql += " J.DESCRIPCION AS DESCRIPCION_CAUSAL_CONTRATO, ";
                    StringSql += " K.DESCRIPCION AS DESCRIPCION_COMPONENTE_OBRA, ";
                    StringSql += " CONCAT(RTRIM(G.NOMBRE),'-',RTRIM(H.NOMBRE)) AS DESCRIPCION_DISTRITO, ";
                    StringSql += " E.MONTO_COSTO_DIRECTO AS COSTO_DIRECTO_TOTAL, ";
                    StringSql += " E.MONTO_CONTRACTUAL AS COSTO_CONTRACTUAL_TOTAL, ";
                    StringSql += " F.COSTO_DIRECTO AS COSTO_DIRECTO_VALORIZADO, ";
                    StringSql += " F.TOTAL_GENERAL AS COSTO_CONTRACTUAL_VALORIZADO, ";
                    StringSql += " (E.MONTO_COSTO_DIRECTO-F.COSTO_DIRECTO) AS COSTO_DIRECTO_SALDO, ";
                    StringSql += " (E.MONTO_CONTRACTUAL-F.TOTAL_GENERAL) AS COSTO_CONTRACTUAL_SALDO ";
                    StringSql += " from  ";
                    StringSql += " SIAF_001335.PROYECTO A, ";
                    StringSql += " SIAF_001335.PROYECTO_FUENTE_CREDITICIA B, ";
                    StringSql += " SIAF_001335.OBRA_CONTRATO C, ";
                    StringSql += " SIAF_001335.OBRA_CONTRATO_DETALLE D, ";
                    StringSql += " SIAF_001335.OBRA_CONTRATO_UBIGEO E LEFT JOIN   ";
                    StringSql += " SIAF_001335.OBRA_VALORIZACION_DETALLE1 F  ON E.ID_OBRA_CONTRATO_UBIGEO=F.ID_OBRA_CONTRATO_UBIGEO, ";
                    StringSql += " SIAF_MAESTROS.PROVINCIA G, ";
                    StringSql += " SIAF_MAESTROS.DISTRITO H, ";
                    StringSql += " SIAF_001335.MAESTRO_CATEGORIA_PROGRAMA I, ";
                    StringSql += " SIAF_001335.MAESTRO_CAUSALES_CONTRATO J, ";
                    StringSql += " SIAF_001335.MAESTRO_COMPONENTE_OBRA K ";
                    StringSql += " WHERE ";
                    StringSql += " A.ID_PROYECTO = B.ID_PROYECTO ";
                    StringSql += " AND B.ID_OBRA=C.ID_OBRA ";
                    StringSql += " AND C.ID_OBRA_CONTRATO=D.ID_OBRA_CONTRATO ";
                    StringSql += " AND D.ID_OBRA_CONTRATO_DETALLE=E.ID_OBRA_CONTRATO_DETALLE ";
                    StringSql += " AND E.DEPARTAMENTO=G.DEPARTAMENTO ";
                    StringSql += " AND E.PROVINCIA=G.PROVINCIA ";
                    StringSql += " AND E.DEPARTAMENTO=H.DEPARTAMENTO ";
                    StringSql += " AND E.PROVINCIA=H.PROVINCIA ";
                    StringSql += " AND E.DISTRITO=H.DISTRITO ";
                    StringSql += " AND (E.MONTO_COSTO_DIRECTO<>0 OR E.MONTO_CONTRACTUAL<>0 OR E.MONTO_CONTRACTUAL<>0 AND F.COSTO_DIRECTO<>0) ";
                    StringSql += " AND D.ID_CATEGORIA_PROGRAMA=I.ID_CATEGORIA_PROGRAMA ";
                    StringSql += " AND D.ID_CAUSAL_CONTRATO=J.ID_CAUSAL_CONTRATO ";
                    StringSql += " AND C.ID_COMPONENTE_OBRA=K.ID_COMPONENTE_OBRA ";
                    StringSql += " GROUP BY A.COD_PROYECTO,I.DESCRIPCION,J.DESCRIPCION,K.DESCRIPCION,G.NOMBRE,H.NOMBRE ";

                    SqlDataAdapter adapter = new SqlDataAdapter(StringSql, conexion);
                    adapter.Fill(ds1);
                    int i = ds1.Tables[0].Rows.Count;
                }
            }
            catch (Exception e1) { Trace.Write("Search, Error : " + e1.Message.ToString()); }



            return ds1;
        }
        #endregion


        //Generacion de Combos

    }
}
