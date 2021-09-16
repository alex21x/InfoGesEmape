using System;
//using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Collections.Generic;

using DevExpress.Web;
using DevExpress.DashboardWeb;
using DevExpress.DashboardCommon;

using System.Web.Hosting;
using System.Xml.Linq;

using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.Data.Filtering;
using System.Drawing;

using DevExpress.DashboardWin;

using DevExpress.XtraCharts;
using DevExpress.XtraTreeMap;
using DevExpress.XtraPrinting;
using DevExpress.Export;

using System.Configuration;

using DevExpress.XtraReports.UI;


namespace InfogesEmape.Modules.Forms.Consulta
{

    public partial class InfoGesDashBoardObrasGG : System.Web.UI.Page
    {
        private string pIdAnoEje;
        #region PageInit


        protected void Page_Init(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {



            }
            if (Context.User.Identity.IsAuthenticated)
            { }
            else
                Response.Redirect("~/Default.aspx");

        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            XtraReport report = XtraReport.FromFile(Server.MapPath(@"~\Reports\RPT_Pmo1.repx"), true);
            //report.Parameters["pActProy"].Value = Request.Params["pActProy"];
            documentViewer.Report = report;

            //XtraReport report1 = XtraReport.FromFile(Server.MapPath(@"~\Reports\rpt_transferencia.repx"), true);
            ////report.Parameters["pActProy"].Value = Request.Params["pActProy"];
            //documentViewer1.Report = report1;

            XtraReport report2 = XtraReport.FromFile(Server.MapPath(@"~\Reports\Geso_rpt_AdvanceToDay.repx"), true);
            ////report.Parameters["pActProy"].Value = Request.Params["pActProy"];
            documentViewer2.Report = report2;

            //XtraReport report3 = XtraReport.FromFile(Server.MapPath(@"~\Reports\rpt_Seguimiento_x_Actividades.repx"), true);
            //////report.Parameters["pActProy"].Value = Request.Params["pActProy"];
            //documentViewer3.Report = report3;
            if (Context.User.Identity.IsAuthenticated)
            {
                DashboardConfigurator.PassCredentials = true;

 
            }
            else
                Response.Redirect("~/Default.aspx");



        }
        protected void btnDashBoard_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Modules/Forms/Consulta/InfoGesDashBoardObrasGraf.asp");
        }

        protected void ASPxDashboardViewer1_ConfigureDataConnection(object sender, DevExpress.DashboardWeb.ConfigureDataConnectionWebEventArgs e)
        {
            MySqlConnectionParameters mysqlParams = new MySqlConnectionParameters();
            mysqlParams.ServerName = "localhost";
            mysqlParams.DatabaseName = "OBRASEMP";
            mysqlParams.UserName = "root";
            mysqlParams.Password = "7654321";
            e.ConnectionParameters = mysqlParams;
        }

        

    }
}