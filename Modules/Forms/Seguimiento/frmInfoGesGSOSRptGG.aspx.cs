using System;
using System.IO;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using DevExpress.Web;
using DevExpress.XtraReports.UI;


namespace InfogesEmape.Modules.Forms.Seguimiento
{
    public partial class frmInfoGesGSOSRptGG : System.Web.UI.Page
    {
        private string pIdActProy;


        protected void Page_Load(object sender, EventArgs e)
        {
            InfogesEmape.Modules.SecondMasterPage m = (InfogesEmape.Modules.SecondMasterPage)Page.Master;
            if (Context.User.Identity.IsAuthenticated)
            { }
            else
                Response.Redirect("~/Default.aspx");

            if (Request.Params["pActProy"].Substring(7) == "1")
            {
                XtraReport report = XtraReport.FromFile(Server.MapPath(@"~\Reports\rpt_EstadoSituacional1.repx"), true);
                report.Parameters["pActProy"].Value = Request.Params["pActProy"].Substring(0, 7);
                documentViewer.Report = report;
            }
            else
            {
                XtraReport report = XtraReport.FromFile(Server.MapPath(@"~\Reports\rpt_EstadoSituacional.repx"), true);
                report.Parameters["pActProy"].Value = Request.Params["pActProy"].Substring(0, 7);
                documentViewer.Report = report;

            }
        }


    }
}
