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

namespace InfoGesRegional.Code.Logic.Forms.Consulta
{
    public class CentroCosto
    {

        #region SearchAllCentroCosto
        public static DataSet SearchAllCentroCosto(string Periodo, string Sec_ejec)
        {
            return Code.Data.Forms.Consulta.CentroCosto.SearchAllCentroCosto(Periodo, Sec_ejec);
        }
        #endregion 

        #region SearchAllCentroCostoxMeta
        public static DataSet SearchAllCentroCostoxMeta(string idSecEjec)
        {
            return Code.Data.Forms.Consulta.CentroCosto.SearchAllCentroCostoxMeta(idSecEjec);
        }
        #endregion 

    }
}
