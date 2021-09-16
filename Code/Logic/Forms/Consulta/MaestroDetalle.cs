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

namespace InfogesEmape.Code.Logic.Forms.Consulta
{
    public class MaestroDetalle
    {

        #region SearchByMaestroDetalle
        public static DataSet SearchByMaestroDetalle(string pIdMaestro)
        {
            return Code.Data.Forms.Consulta.MaestroDetalle.SearchByMaestroDetalle(pIdMaestro);
        }
        #endregion

        #region SearchByMaestroDetalle
        public static DataSet SearchByMaestroDetalle(string pIdMaestro, string pIdUnion)
        {
            return Code.Data.Forms.Consulta.MaestroDetalle.SearchByMaestroDetalle(pIdMaestro, pIdUnion);
        }
        #endregion

        #region SearchByDistrito
        public static DataSet SearchByDistrito()
        {
            return Code.Data.Forms.Consulta.MaestroDetalle.SearchByDistrito();
        }
        #endregion
    }
}
