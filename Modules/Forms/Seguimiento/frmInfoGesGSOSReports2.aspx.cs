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
    public partial class frmInfoGesGSOSReports2 : System.Web.UI.Page
    {
        private string pIdActProy;

        #region PageInit
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["baseURLfrmInfoGesConsultaEjecutoraExpPopUp"] == null)
                Session["baseURLfrmInfoGesConsultaEjecutoraExpPopUp"] = "frmInfoGesConsultaEjecutoraExpPopUp.aspx";

        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InfogesEmape.Modules.SecondMasterPage m = (InfogesEmape.Modules.SecondMasterPage)Page.Master;
            if (Context.User.Identity.IsAuthenticated)
            { }
            else
                Response.Redirect("~/Default.aspx");

            //pIdActProy = "" + Request.Params["pActProy"];


            XtraReport report = XtraReport.FromFile(Server.MapPath(@"~\Reports\ReportCurvaS1.repx"), true);
            report.Parameters["pActProy"].Value = Request.Params["pActProy"]; 
            documentViewer.Report = report;

        }


    }
}
