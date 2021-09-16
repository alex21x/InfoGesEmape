#region Using Directives
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
#endregion

namespace InfoGesRegional.Code.Data.Forms.Input
{
    public class ProgramacionGasto
    {

        #region SearchByProgramacionMeta
        public static DataSet SearchByProgramacionMeta(string pIdEjecutora, string pIdAno_Eje)
        {
            DataSet ds1 = new DataSet();
            string StringSql = "";
            try
            {
                using (SqlConnection conexion = new SqlConnection(Code.ConeccionString.sql()))
                {
                    StringSql += " SELECT ";
                    StringSql += " A.ANO_EJE, ";
                    StringSql += " A.SEC_EJEC, ";
                    StringSql += " A.SEC_FUNC, ";
                    StringSql += " A.DESCRIPCION_META, ";
                    StringSql += " A.UNIDAD_MEDIDA+' '+UNIDAD_MEDIDA_NOMBRE AS UNIDAD_MEDIDA_NOMBRE, ";
                    StringSql += " A.FINALIDAD+' '+A.FINALIDAD_NOMBRE AS FINALIDAD_NOMBRE, ";
                    StringSql += " A.DEPARTAMENTO+' '+A.DEPARTAMENTO_NOMBRE AS DEPARTAMENTO_NOMBRE, ";
                    StringSql += " A.PROVINCIA+' '+A.PROVINCIA_NOMBRE AS PROVINCIA_NOMBRE, ";
                    StringSql += " A.DISTRITO+' '+A.DISTRITO_NOMBRE AS DISTRITO_NOMBRE ";
                    StringSql += " from dbo.INFOREG_META A ";
                    StringSql += " WHERE  ";
                    StringSql += " A.ANO_EJE='" + pIdAno_Eje.ToString() + "' AND A.SEC_EJEC='" + pIdEjecutora.ToString() + "'";
                    StringSql += " ORDER BY ANO_EJE,SEC_FUNC";
                    



                    SqlDataAdapter adapter = new SqlDataAdapter(StringSql, conexion);
                    adapter.Fill(ds1);
                }
            }
            catch (Exception ex)
            {
                string Text = "Error: " + ex.Message;
            }
            return ds1;
        }
        #endregion

        //http://www.esasp.net/2010/12/c-manejo-de-webexception-error-en-el.html

        #region SearchByProgramacionGasto
        public static DataSet SearchByProgramacionGasto(string pIdAno_Eje, string pIdEjecutora, string pIdSecFunc)
        {
            DataSet ds1 = new DataSet();
            string StringSql = "";
            try
            {
                using (SqlConnection conexion = new SqlConnection(Code.ConeccionString.sql()))
                {
                    StringSql += " SELECT A.ANO_EJE+A.SEC_EJEC+A.SEC_FUNC+A.FUENTE_FINANC+A.ID_CLASIFICADOR AS IDKEY ";
                    StringSql += " ,A.ANO_EJE,A.SEC_EJEC,A.SEC_FUNC ";
                    StringSql += " ,A.FUENTE_FINANC+' '+C.FUENTE_FINANC_NOMBRE AS FUENTE_FINANC_NOMBRE ";
                    StringSql += " ,A.ID_CLASIFICADOR,B.CATEGORIA_GASTO+' '+B.GENERICA+' '+B.SUBGENERICA+' '+B.SUBGENERICA_DET+' '+B.ESPECIFICA+' '+B.ESPECIFICA_DET+' '+B.ESPECIFICA_DET_NOMBRE ESPECIFICA_DET_NOMBRE ";
                    StringSql += " ,A.PIA,A.PIM,";

                    StringSql += " CASE WHEN D.MES01='S'  THEN A.EJECUCION_01 ELSE A.PROGRAMACION_01 END AS PROGRAMACION_01, ";
                    StringSql += " CASE WHEN D.MES02='S'  THEN A.EJECUCION_02 ELSE A.PROGRAMACION_02 END AS PROGRAMACION_02, ";
                    StringSql += " CASE WHEN D.MES03='S'  THEN A.EJECUCION_03 ELSE A.PROGRAMACION_03 END AS PROGRAMACION_03, ";
                    StringSql += " CASE WHEN D.MES04='S'  THEN A.EJECUCION_04 ELSE A.PROGRAMACION_04 END AS PROGRAMACION_04, ";
                    StringSql += " CASE WHEN D.MES05='S'  THEN A.EJECUCION_05 ELSE A.PROGRAMACION_05 END AS PROGRAMACION_05, ";
                    StringSql += " CASE WHEN D.MES06='S'  THEN A.EJECUCION_06 ELSE A.PROGRAMACION_06 END AS PROGRAMACION_06, ";
                    StringSql += " CASE WHEN D.MES07='S'  THEN A.EJECUCION_07 ELSE A.PROGRAMACION_06 END AS PROGRAMACION_07, ";
                    StringSql += " CASE WHEN D.MES08='S'  THEN A.EJECUCION_08 ELSE A.PROGRAMACION_06 END AS PROGRAMACION_08, ";
                    StringSql += " CASE WHEN D.MES09='S'  THEN A.EJECUCION_09 ELSE A.PROGRAMACION_06 END AS PROGRAMACION_09, ";
                    StringSql += " CASE WHEN D.MES10='S'  THEN A.EJECUCION_10 ELSE A.PROGRAMACION_06 END AS PROGRAMACION_10, ";
                    StringSql += " CASE WHEN D.MES11='S'  THEN A.EJECUCION_11 ELSE A.PROGRAMACION_06 END AS PROGRAMACION_11, ";
                    StringSql += " CASE WHEN D.MES12='S'  THEN A.EJECUCION_12 ELSE A.PROGRAMACION_06 END AS PROGRAMACION_12, ";
                    StringSql += " D.MES01,D.MES02,D.MES03,D.MES04,D.MES05,D.MES06,D.MES07,D.MES08,D.MES09,D.MES10,D.MES11,D.MES12 ";
                    StringSql += " FROM dbo.INFOREG_PROGRAMACION_GASTO A,dbo.INFOREG_ESPECIFICA_DET B, dbo.INFOREG_FUENTE_FINANC c, ";
                    StringSql += " dbo.vw_paropeprogramacion D ";
                    StringSql += " WHERE A.ANO_EJE=B.ANO_EJE  AND A.ID_CLASIFICADOR=B.ID_CLASIFICADOR ";
                    StringSql += " AND A.ANO_EJE=C.ANO_EJE AND A.FUENTE_FINANC=C.FUENTE_FINANC ";
                    StringSql += " AND A.ANO_EJE='" + pIdAno_Eje.ToString() + "' AND A.SEC_EJEC='" + pIdEjecutora.ToString() + "' AND A.SEC_FUNC='" + pIdSecFunc.ToString() + "'";
                    StringSql += " AND D.ANO_EJE=A.ANO_EJE ";
                    StringSql += " ORDER BY A.ANO_EJE ";
                    StringSql += " ,A.SEC_EJEC,A.SEC_FUNC,A.FUENTE_FINANC,A.ID_CLASIFICADOR ";

                    SqlDataAdapter adapter = new SqlDataAdapter(StringSql, conexion);
                    adapter.Fill(ds1);
                }
            }
            catch (Exception ex)
            {
                string Text = "Error: " + ex.Message;
            }
            return ds1;
        }
        #endregion


        #region SearchByAnulacionCreditoGasto
        public static DataSet SearchByAnulacionCreditoGasto(string pIdAno_Eje, string pIdEjecutora, string pIdSecFunc)
        {
            DataSet ds1 = new DataSet();
            string StringSql = "";
            try
            {
                using (SqlConnection conexion = new SqlConnection(Code.ConeccionString.sql()))
                {
                    StringSql += " SELECT A.ANO_EJE+A.SEC_EJEC+A.SEC_FUNC+A.FUENTE_FINANC+A.ID_CLASIFICADOR AS IDKEY ";
                    StringSql += " ,A.ANO_EJE,A.SEC_EJEC,A.SEC_FUNC ";
                    StringSql += " ,A.FUENTE_FINANC+' '+C.FUENTE_FINANC_NOMBRE AS FUENTE_FINANC_NOMBRE ";
                    StringSql += " ,A.ID_CLASIFICADOR,B.CATEGORIA_GASTO+' '+B.GENERICA+' '+B.SUBGENERICA+' '+B.SUBGENERICA_DET+' '+B.ESPECIFICA+' '+B.ESPECIFICA_DET+' '+B.ESPECIFICA_DET_NOMBRE ESPECIFICA_DET_NOMBRE ";
                    StringSql += " ,A.PIA,A.PIM,";

                    StringSql += " CASE WHEN D.MES01='S'  THEN A.CREDITO ELSE A.CREDITO END AS CREDITO, ";
                    StringSql += " CASE WHEN D.MES02='S'  THEN A.ANULACION ELSE A.ANULACION END AS ANULACION  ";
                    StringSql += " FROM dbo.INFOREG_PROGRAMACION_GASTO A,dbo.INFOREG_ESPECIFICA_DET B, dbo.INFOREG_FUENTE_FINANC c, ";
                    StringSql += " dbo.vw_paropeprogramacion D ";
                    StringSql += " WHERE A.ANO_EJE=B.ANO_EJE  AND A.ID_CLASIFICADOR=B.ID_CLASIFICADOR ";
                    StringSql += " AND A.ANO_EJE=C.ANO_EJE AND A.FUENTE_FINANC=C.FUENTE_FINANC ";
                    StringSql += " AND A.ANO_EJE='" + pIdAno_Eje.ToString() + "' AND A.SEC_EJEC='" + pIdEjecutora.ToString() + "' AND A.SEC_FUNC='" + pIdSecFunc.ToString() + "'";
                    StringSql += " AND D.ANO_EJE=A.ANO_EJE ";
                    StringSql += " ORDER BY A.ANO_EJE ";
                    StringSql += " ,A.SEC_EJEC,A.SEC_FUNC,A.FUENTE_FINANC,A.ID_CLASIFICADOR ";

                    SqlDataAdapter adapter = new SqlDataAdapter(StringSql, conexion);
                    adapter.Fill(ds1);
                }
            }
            catch (Exception ex)
            {
                string Text = "Error: " + ex.Message;
            }
            return ds1;
        }
        #endregion


        #region SearchByProgramacionGastoId
        public static string SearchByProgramacionGastoId(string pIdAno_Eje, string pIdEjecutora, string pIdSecFunc, string pIdFuente_financ, string pIdId_Clasificador)
        {
            DataSet ds1 = new DataSet();
            string StringSql = "";
            try
            {
                using (SqlConnection conexion = new SqlConnection(Code.ConeccionString.sql()))
                {
                    StringSql += " SELECT A.PIM ";
                    StringSql += " FROM dbo.INFOREG_PROGRAMACION_GASTO A ";
                    StringSql += " WHERE ";
                    StringSql += " A.ANO_EJE='" + pIdAno_Eje.ToString() + "' AND A.SEC_EJEC='" + pIdEjecutora.ToString() + "' AND A.SEC_FUNC='" + pIdSecFunc.ToString() + "'";
                    StringSql += " AND A.FUENTE_FINANC='" + pIdFuente_financ.ToString() + "' AND A.ID_CLASIFICADOR='" + pIdId_Clasificador.ToString() + "'";

                    SqlDataAdapter adapter = new SqlDataAdapter(StringSql, conexion);
                    adapter.Fill(ds1);
                }
            }
            catch (Exception ex)
            {
                string Text = "Error: " + ex.Message;
            }

            return ds1.Tables[0].Rows[0]["PIM"].ToString();
        }
        #endregion

        #region Updated_Programacion_Gasto
        public static string Updated_Programacion_Gasto(string[] parameterValues, string Id)
        {
            string lvPim = SearchByProgramacionGastoId(Id.Substring(0, 4), Id.Substring(4, 6), Id.Substring(10, 4), Id.Substring(14, 2), Id.Substring(16, 7));
            string lvmensaje= "";


            if(Convert.ToDecimal(lvPim)<=Convert.ToDecimal(parameterValues[0].ToString())+
                                        Convert.ToDecimal(parameterValues[1].ToString())+
                                        Convert.ToDecimal(parameterValues[2].ToString())+
                                        Convert.ToDecimal(parameterValues[3].ToString())+
                                        Convert.ToDecimal(parameterValues[4].ToString())+
                                        Convert.ToDecimal(parameterValues[5].ToString())+
                                        Convert.ToDecimal(parameterValues[6].ToString())+
                                        Convert.ToDecimal(parameterValues[7].ToString())+
                                        Convert.ToDecimal(parameterValues[8].ToString())+
                                        Convert.ToDecimal(parameterValues[9].ToString())+
                                        Convert.ToDecimal(parameterValues[10].ToString())+
                                        Convert.ToDecimal(parameterValues[11].ToString()))
            {
                lvmensaje =" Programación supera el marco presupuestal verifique...!!";
            }
            else
            {
                string cadenaActualizar = "";
                cadenaActualizar += " UPDATE dbo.inforeg_Programacion_gasto SET ";
                cadenaActualizar += " PROGRAMACION_01 = @lvProgramacion01";
                cadenaActualizar += " ,PROGRAMACION_02= @lvProgramacion02";
                cadenaActualizar += " ,PROGRAMACION_03= @lvProgramacion03";
                cadenaActualizar += " ,PROGRAMACION_04= @lvProgramacion04";
                cadenaActualizar += " ,PROGRAMACION_05= @lvProgramacion05";
                cadenaActualizar += " ,PROGRAMACION_06= @lvProgramacion06";
                cadenaActualizar += " ,PROGRAMACION_07= @lvProgramacion07";
                cadenaActualizar += " ,PROGRAMACION_08= @lvProgramacion08";
                cadenaActualizar += " ,PROGRAMACION_09= @lvProgramacion09";
                cadenaActualizar += " ,PROGRAMACION_10= @lvProgramacion10";
                cadenaActualizar += " ,PROGRAMACION_11= @lvProgramacion11";
                cadenaActualizar += " ,PROGRAMACION_12= @lvProgramacion12";
                cadenaActualizar += " where ";
                cadenaActualizar += " ANO_EJE = @lvAno_Eje";
                cadenaActualizar += " AND SEC_EJEC = @lvSec_Ejec";
                cadenaActualizar += " AND SEC_FUNC = @lvSec_Func";
                cadenaActualizar += " AND FUENTE_FINANC = @lvFuente_financ";
                cadenaActualizar += " AND ID_CLASIFICADOR =@lvId_Clasificador";
                int t = 0;
                using (SqlConnection conexion = new SqlConnection(Code.ConeccionString.sql()))
                {
                    SqlCommand comando = new SqlCommand(cadenaActualizar, conexion);
                    conexion.Open();
                    comando.Parameters.AddWithValue("@lvAno_eje", Id.Substring(0,4));
                    comando.Parameters.AddWithValue("@lvSec_Ejec", Id.Substring(4,6));
                    comando.Parameters.AddWithValue("@lvSec_Func", Id.Substring(10,4));
                    comando.Parameters.AddWithValue("@lvFuente_Financ", Id.Substring(14,2));
                    comando.Parameters.AddWithValue("@lvId_Clasificador", Id.Substring(16,7));
                    comando.Parameters.AddWithValue("@lvProgramacion01", parameterValues[0].ToString());
                    comando.Parameters.AddWithValue("@lvProgramacion02", parameterValues[1].ToString());
                    comando.Parameters.AddWithValue("@lvProgramacion03", parameterValues[2].ToString());
                    comando.Parameters.AddWithValue("@lvProgramacion04", parameterValues[3].ToString());
                    comando.Parameters.AddWithValue("@lvProgramacion05", parameterValues[4].ToString());
                    comando.Parameters.AddWithValue("@lvProgramacion06", parameterValues[5].ToString());
                    comando.Parameters.AddWithValue("@lvProgramacion07", parameterValues[6].ToString());
                    comando.Parameters.AddWithValue("@lvProgramacion08", parameterValues[7].ToString());
                    comando.Parameters.AddWithValue("@lvProgramacion09", parameterValues[8].ToString());
                    comando.Parameters.AddWithValue("@lvProgramacion10", parameterValues[9].ToString());
                    comando.Parameters.AddWithValue("@lvProgramacion11", parameterValues[10].ToString());
                    comando.Parameters.AddWithValue("@lvProgramacion12", parameterValues[11].ToString());
                    t = comando.ExecuteNonQuery();
                    conexion.Close();
                }

            }

            return lvmensaje;
        }
        #endregion


        #region Updated_AnulacionCredito_Gasto
        public static string Updated_AnulacionCredito_Gasto(string[] parameterValues, string Id)
        {
            string lvPim = SearchByProgramacionGastoId(Id.Substring(0, 4), Id.Substring(4, 6), Id.Substring(10, 4), Id.Substring(14, 2), Id.Substring(16, 7));
            string lvmensaje = "";


            if (Convert.ToDecimal(parameterValues[0].ToString()) > 0 &&  Convert.ToDecimal(parameterValues[1].ToString())>0)
            {
                lvmensaje = " Registra Anulacion o Credito no Ambos...!!";
            }
            else
            {
                string cadenaActualizar = "";
                cadenaActualizar += " UPDATE dbo.inforeg_Programacion_gasto SET ";
                cadenaActualizar += " ANULACION = @lvProgramacion01";
                cadenaActualizar += " ,CREDITO= @lvProgramacion02";
                cadenaActualizar += " where ";
                cadenaActualizar += " ANO_EJE = @lvAno_Eje";
                cadenaActualizar += " AND SEC_EJEC = @lvSec_Ejec";
                cadenaActualizar += " AND SEC_FUNC = @lvSec_Func";
                cadenaActualizar += " AND FUENTE_FINANC = @lvFuente_financ";
                cadenaActualizar += " AND ID_CLASIFICADOR =@lvId_Clasificador";
                int t = 0;
                using (SqlConnection conexion = new SqlConnection(Code.ConeccionString.sql()))
                {
                    SqlCommand comando = new SqlCommand(cadenaActualizar, conexion);
                    conexion.Open();
                    comando.Parameters.AddWithValue("@lvAno_eje", Id.Substring(0, 4));
                    comando.Parameters.AddWithValue("@lvSec_Ejec", Id.Substring(4, 6));
                    comando.Parameters.AddWithValue("@lvSec_Func", Id.Substring(10, 4));
                    comando.Parameters.AddWithValue("@lvFuente_Financ", Id.Substring(14, 2));
                    comando.Parameters.AddWithValue("@lvId_Clasificador", Id.Substring(16, 7));
                    comando.Parameters.AddWithValue("@lvProgramacion01", parameterValues[0].ToString());
                    comando.Parameters.AddWithValue("@lvProgramacion02", parameterValues[1].ToString());
                    t = comando.ExecuteNonQuery();
                    conexion.Close();
                }

            }

            return lvmensaje;
        }
        #endregion

        #region SearchByProgramacionGastoCierre
        public static DataSet SearchByProgramacionGastoCierre()
        {
            DataSet ds1 = new DataSet();
            string StringSql = "";
            try
            {
                using (SqlConnection conexion = new SqlConnection(Code.ConeccionString.sql()))
                {
                    StringSql += " SELECT ID_PROGRAMACION, ANO_EJE,MES_EJE,CIERRE_PROGRAMACION_ESTADO_PROGRAMACION ";
                    StringSql += " FROM dbo.INFOREG_PAR_OPE_PROGRAMACION ";
                    StringSql += " WHERE ";
                    StringSql += " ANO_EJE=(SELECT MAX(ANO_EJE) FROM dbo.INFOREG_PAR_OPE_PROGRAMACION) ";

                    SqlDataAdapter adapter = new SqlDataAdapter(StringSql, conexion);
                    adapter.Fill(ds1);
                }
            }
            catch (Exception ex)
            {
                string Text = "Error: " + ex.Message;
            }
            return ds1;
        }
        #endregion

        #region Updated_Programacion_Gasto_Cierre
        public static string Updated_Programacion_Gasto_Cierre(string[] parameterValues, string Id)
        {
                string lvmensaje = "";

                string cadenaActualizar = "";
                cadenaActualizar += " UPDATE dbo.INFOREG_PAR_OPE_PROGRAMACION SET ";
                cadenaActualizar += " CIERRE_PROGRAMACION = @IdCierreProgramacion";
                cadenaActualizar += " where ";
                cadenaActualizar += " ID_PROGRAMACION = @IdProgramacion";
                int t = 0;
                using (SqlConnection conexion = new SqlConnection(Code.ConeccionString.sql()))
                {
                    SqlCommand comando = new SqlCommand(cadenaActualizar, conexion);
                    conexion.Open();
                    comando.Parameters.AddWithValue("@IdCierreProgramacion", parameterValues[0].ToString());
                    comando.Parameters.AddWithValue("@IdProgramacion", Id.ToString());
                    t = comando.ExecuteNonQuery();
                    conexion.Close();
                }


            return lvmensaje;
        }
        #endregion
    }
}
