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
namespace InfoGesRegional.Modules.Forms.Consulta
{

    public partial class InfoGesDashBoardObrasGraf : System.Web.UI.Page
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
            Response.Redirect("~/Modules/Forms/Consulta/InfoGesDashBoardObrasGraf.asp");
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


        #region Load_AcumuladoRuc
        protected void Load_AcumuladoRuc(object sender, EventArgs e)
        {
            this.GetAllAcumuladoRuc(sender);
        }
        #endregion

        #region GetAllAcumuladoRuc
        private void GetAllAcumuladoRuc(object sender)
        {
            ASPxGridView ASPxGridviewRuc = (ASPxGridView)sender;
            DataSet ds3 = new DataSet();
            ds3 = Code.Logic.Forms.Consulta.DinamicaRuc.SearchAllRucGrupoPrueba();
            ASPxGridviewRuc.KeyFieldName = "RUC";
            ASPxGridviewRuc.DataSource = ds3.Tables[0];

            ASPxGridviewRuc.DataBind();
        }
        #endregion

        protected void btnXlsExport_Click(object sender, EventArgs e)
        {
            gridExport.WriteXlsToResponse(new XlsExportOptionsEx { ExportType = ExportType.WYSIWYG });
        }

    }
}