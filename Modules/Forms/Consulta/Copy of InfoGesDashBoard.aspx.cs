using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using DevExpress.Web;
using DevExpress.DataAccess.ConnectionParameters;
namespace InfoGesRegional.Modules.Forms.Consulta
{

    public partial class InfoGesDashBoard : System.Web.UI.Page
    {
        private string pIdAnoEje;
        #region PageInit


        protected void Page_Init(object sender, EventArgs e)
        {
            this.CargarGraficos();

        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.User.Identity.IsAuthenticated)
            {
            }
            else
                Response.Redirect("~/Default.aspx");

        }
        protected void ASPxDashboardViewer1_ConfigureDataConnection(object sender, DevExpress.DashboardWeb.ConfigureDataConnectionWebEventArgs e)
        {

            MySqlConnectionParameters mysqlParams = e.ConnectionParameters as MySqlConnectionParameters;
            mysqlParams.ServerName = "localhost";
            mysqlParams.DatabaseName = (string)(Session["IdBaseDeDatos"]);
            mysqlParams.UserName = "root";
            mysqlParams.Password = "7654321";
            e.ConnectionParameters = mysqlParams;
            //ASPxDashboard1.DashboardXmlPath = "~/xml/xmlDashboard17.xml";
            //ASPxDashboardViewer1.DashboardXmlFile = "~/xml/xmlDashboard17.xml";


            ////SqlServerConnectionParametersBase s = (SqlServerConnectionParametersBase)e.ConnectionParameters;

            ////s.DatabaseName = "DB_NAME";
            ////s.UserName = "user_id";
            ////s.Password = "pass";
            ////e.ConnectionParameters = s;

            //MySqlConnection s = (MySqlConnection)e.ConnectionParameters;
            //e.ConnectionParameters

            ////if (e.ConnectionName == "localhost_NorthwindConnection")
            ////{
            ////    e.ConnectionParameters = new MsSqlConnectionParameters(".", "Northwind", "", "", MsSqlAuthorizationType.Windows);
            ////}
            ////if (e.ConnectionName == "connection")
            ////{
            ////    e.ConnectionParameters = new Access97ConnectionParameters() { FileName = Server.MapPath("~/App_Data/Nwind.mdb") };
            ////}
        }
        protected void ASPxPageControl1auc(object sender, DevExpress.Web.TabControlEventArgs e)
        {
            //pAccion = "0";
            //this.LoadExpxGasto1();
        }

        private void CargarGraficos()
        {
            string IdCadena = "";
            IdCadena = Code.Logic.Forms.Consulta.Cuadro3.SearchByPresupuestoGraf((string)(Session["SecEjecId"]), (string)(Session["IdBaseDeDatos"]), Request.Params["pIdAnoEje"]);

        }

    }
}