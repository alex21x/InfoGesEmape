using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace InfoGesRegional.Modules.Forms.Consulta
{
    public partial class frmSeguimientosLiquidacion : System.Web.UI.Page
    {
        private string pIdActProy;
        private string pIdSecEjec;

        protected void Page_Load(object sender, EventArgs e)
        {
            pIdActProy = "" + Request.Params["pId"];
            pIdSecEjec = "" + Request.Params["pIdSec_Ejec"];

        }

        #region LoadASPxGridview
        protected void LoadASPxGridview(object sender, EventArgs e)
        {
            DataSet ds3 = new DataSet();

            ds3 = Code.Logic.Forms.Consulta.EjecucionGasto.SearchEjecutoraExpedienteLiquidacion(pIdSecEjec + pIdActProy, (string)(Session["IdBaseDeDatos"]));
            ASPxGridview1.DataSource = ds3.Tables[0];
            ASPxGridview1.DataBind();
            ASPxGridview1.GroupBy(ASPxGridview1.Columns["ANO_EJE"]);
            ASPxGridview1.ExpandAll();
        }
        #endregion

        protected void btnXlsExport_Click(object sender, EventArgs e)
        {
            gridExport.WriteXlsToResponse();
        }
    }
}
