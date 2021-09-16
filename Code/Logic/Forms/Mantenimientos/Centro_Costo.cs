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
    public class Centro_Costo
    {

        #region SearchAllCentroCosto
        public static DataSet SearchAllCentroCosto()
        {
            return Code.Data.Forms.Mantenimientos.Centro_Costo.SearchAllCentroCosto();
        }
        #endregion

        #region InsertCentroCosto
        public static string InsertCentroCosto(string[] parameterValues)
        {
            return Code.Data.Forms.Mantenimientos.Centro_Costo.InsertCentroCosto(parameterValues);
        }
        #endregion

        #region UpdatedCentroCosto
        public static string UpdatedCentroCosto(string[] parameterValues)
        {
            return Code.Data.Forms.Mantenimientos.Centro_Costo.UpdatedCentroCosto(parameterValues);
        }
        #endregion

        #region DeleteCentroCosto
        public static string DeleteCentroCosto(string Id)
        {
            return Code.Data.Forms.Mantenimientos.Centro_Costo.DeleteCentroCosto(Id);
        }
        #endregion  
    }
}
