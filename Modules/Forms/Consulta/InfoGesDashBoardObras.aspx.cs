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


using System.Configuration;
namespace InfoGesRegional.Modules.Forms.Consulta
{

    public partial class InfoGesDashBoardObras : System.Web.UI.Page
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
            if (Context.User.Identity.IsAuthenticated)
            {
                DashboardConfigurator.PassCredentials = true;

 
            }
            else
                Response.Redirect("~/Default.aspx");



        }


        protected void btnDashBoard_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Modules/Forms/Consulta/InfoGesDashBoardObrasGraf.aspx");
        }

        protected void ASPxDashboardViewer1_ConfigureDataConnection(object sender, DevExpress.DashboardWeb.ConfigureDataConnectionWebEventArgs e)
        {
            MySqlConnectionParameters mysqlParams = new MySqlConnectionParameters();
            mysqlParams.ServerName = "localhost";
            mysqlParams.DatabaseName = "OBRAS";
            mysqlParams.UserName = "root";
            mysqlParams.Password = "7654321";
            e.ConnectionParameters = mysqlParams;
        }

    }
}