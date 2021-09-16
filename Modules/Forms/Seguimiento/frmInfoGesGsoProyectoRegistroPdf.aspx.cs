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
    public partial class frmInfoGesGsoProyectoRegistroPdf : System.Web.UI.Page
    {
        private string pIdActProy;

        #region PageInit
        protected void Page_Init(object sender, EventArgs e)
        {

        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InfogesEmape.Modules.SecondMasterPage m = (InfogesEmape.Modules.SecondMasterPage)Page.Master;
            if (Context.User.Identity.IsAuthenticated)
            { }
            else
                Response.Redirect("~/Default.aspx");

            //System.Diagnostics.Process proc = new System.Diagnostics.Process();
            //proc.StartInfo.FileName = "C:\\Dev\\InfogesEmapeD17 - 2013\\pdf\\2433556_conttraot10_RS_08.pdf";
            //proc.Start();
            //proc.Close();

            //Response.ClearHeaders();

            //Response.ContentType = "application / pdf";

            //Response.Clear();

            //Response.AppendHeader("Content-Disposition", "C:\\Dev\\InfogesEmapeD17 - 2013\\pdf\\2433556_conttraot10_RS_08.pdf");

            //Response.End();

            //this.ASPxWebDocumentViewer1.L.LoadDocument(@"C:\\Dev\\InfogesEmapeD17 - 2013\\pdf\\2433556_conttraot10_RS_08.pdf");

            //pIdActProy = "" + Request.Params["pActProy"];


            //XtraReport report = XtraReport.FromFile(Server.MapPath(@"~\Reports\ReportCurvaS.repx"), true);
            //report.Parameters["pActProy"].Value = Request.Params["pActProy"]; 
            //documentViewer.Report = report;

        }


    }
}
