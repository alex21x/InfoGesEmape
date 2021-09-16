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

namespace InfoGesRegional.Code.Logic.Forms.Mantenimientos
{
    public class Centro_Costo_x_ejec
    {

        #region SearchAllCentroCostoEjec
        public static DataSet SearchAllCentroCostoEjec(string lcSecEjec)
        {
            return Code.Data.Forms.Mantenimientos.Centro_Costo_x_ejec.SearchAllCentroCostoEjec(lcSecEjec);
        }
        #endregion

        #region InsertCentroCostoEjec
        public static string InsertCentroCostoEjec(string[] parameterValues)
        {
            return Code.Data.Forms.Mantenimientos.Centro_Costo_x_ejec.InsertCentroCostoEjec(parameterValues);
        }
        #endregion

        #region UpdatedCentroCostoEjec
        public static string UpdatedCentroCostoEjec(string[] parameterValues)
        {
            return Code.Data.Forms.Mantenimientos.Centro_Costo_x_ejec.UpdatedCentroCostoEjec(parameterValues);
        }
        #endregion

        #region DeleteCentroCostoEjec
        public static string DeleteCentroCostoEjec(string Id)
        {
            return Code.Data.Forms.Mantenimientos.Centro_Costo_x_ejec.DeleteCentroCostoEjec(Id);
        }
        #endregion  
    }
}
