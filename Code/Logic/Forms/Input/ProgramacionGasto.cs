#region Using Directives
using System;
using System.Collections;
using System.Data;
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

namespace InfoGesRegional.Code.Logic.Forms.Input
{
    public class ProgramacionGasto
    {

        #region SearchByProgramacionMeta
        public static DataSet SearchByProgramacionMeta(string pIdEjecutora, string pIdAno_Eje)
        {
            return Code.Data.Forms.Input.ProgramacionGasto.SearchByProgramacionMeta(pIdEjecutora, pIdAno_Eje);
        }
        #endregion

        #region SearchByAnulacionCreditoGasto
        public static DataSet SearchByAnulacionCreditoGasto(string pIdAno_Eje, string pIdEjecutora, string pIdSecFunc)
        {
            return Code.Data.Forms.Input.ProgramacionGasto.SearchByAnulacionCreditoGasto(pIdAno_Eje, pIdEjecutora, pIdSecFunc);
        }
        #endregion


        #region SearchByProgramacionGasto
        public static DataSet SearchByProgramacionGasto(string pIdAno_Eje, string pIdEjecutora, string pIdSecFunc)
        {
            return Code.Data.Forms.Input.ProgramacionGasto.SearchByProgramacionGasto(pIdAno_Eje, pIdEjecutora, pIdSecFunc);
        }
        #endregion

        #region Updated_Programacion_Gasto
        public static string Updated_Programacion_Gasto(string[] parameterValues, string Id)
        {

            return Code.Data.Forms.Input.ProgramacionGasto.Updated_Programacion_Gasto(parameterValues, Id);
        }
        #endregion

        #region Updated_AnulacionCredito_Gasto
        public static string Updated_AnulacionCredito_Gasto(string[] parameterValues, string Id)
        {

            return Code.Data.Forms.Input.ProgramacionGasto.Updated_AnulacionCredito_Gasto(parameterValues, Id);
        }
        #endregion



        #region SearchByProgramacionGastoCierre
        public static DataSet SearchByProgramacionGastoCierre()
        {
            return Code.Data.Forms.Input.ProgramacionGasto.SearchByProgramacionGastoCierre();
        }
        #endregion

        #region Updated_Programacion_Gasto_Cierre
        public static string Updated_Programacion_Gasto_Cierre(string[] parameterValues, string Id)
        {

            return Code.Data.Forms.Input.ProgramacionGasto.Updated_Programacion_Gasto(parameterValues, Id);
        }
        #endregion


    }
}
