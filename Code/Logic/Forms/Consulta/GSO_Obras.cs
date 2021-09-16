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
    public class GSO_Obras
    {

        #region GSOEstadoSituacional
        public static DataSet GSOEstadoSituacional(string IdBaseDeDatos)
        {
            return Code.Data.Forms.Consulta.GSO_Obras.GSOEstadoSituacional(IdBaseDeDatos);
        }
        #endregion

        #region GSOEstadoSituacionalObraSeguimiento
        public static DataSet GSOEstadoSituacionalObraSeguimiento(string IdBaseDeDatos)
        {
            return Code.Data.Forms.Consulta.GSO_Obras.GSOEstadoSituacionalObraSeguimiento(IdBaseDeDatos);
        }
        #endregion
        #region GSOEstadoSituacionalProyecto
        public static DataSet GSOEstadoSituacionalProyecto(string IdBaseDeDatos)
        {
            return Code.Data.Forms.Consulta.GSO_Obras.GSOEstadoSituacionalProyecto(IdBaseDeDatos);
        }
        #endregion
    }
}
