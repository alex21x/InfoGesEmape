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
    public class Centro_Costo_x_ejec_x_Meta
    {

        #region SearchAllCentroCostoEjecMeta
        public static DataSet SearchAllCentroCostoEjecMeta(string Id)
        {
            return Code.Data.Forms.Mantenimientos.Centro_Costo_x_ejec_x_Meta.SearchAllCentroCostoEjecMeta(Id);
        }
        #endregion

        #region InsertCentroCostoEjecMeta
        public static string InsertCentroCostoEjecMeta(string[] parameterValues)
        {
            return Code.Data.Forms.Mantenimientos.Centro_Costo_x_ejec_x_Meta.InsertCentroCostoEjecMeta(parameterValues);
        }
        #endregion

        #region UpdatedCentroCostoEjecMeta
        public static string UpdatedCentroCostoEjecMeta(string[] parameterValues)
        {
            return Code.Data.Forms.Mantenimientos.Centro_Costo_x_ejec_x_Meta.UpdatedCentroCostoEjecMeta(parameterValues);
        }
        #endregion  

        #region DeleteCentroCostoEjecMeta
        public static string DeleteCentroCostoEjecMeta(string Id)
        {
            return Code.Data.Forms.Mantenimientos.Centro_Costo_x_ejec_x_Meta.DeleteCentroCostoEjecMeta(Id);
        }
        #endregion  
    }
}
