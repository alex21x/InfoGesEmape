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


using System.Configuration;
namespace InfoGesRegional.Modules.Forms.Consulta
{

    public partial class InfoGesDashBoard : System.Web.UI.Page
    {
        private string pIdAnoEje;
        #region PageInit


        protected void Page_Init(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.LoadXmlEjecutora();
                this.LoadXmlPeriodo();



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
                //ASPxDashboard1.InitialDashboardId = "File1";
                //ASPxDashboard1.DashboardXmlPath = "~/xml/ejemplo_001.xml";

                //string conn = DevExpress.Xpo.DB.MySqlConnectionProvider.GetConnectionString("localhost", "root", "7654321", (string)(Session["IdBaseDeDatos"]));

                //DevExpress.Xpo.Session.DefaultSession.ConnectionString = conn;  

                //DashboardFileStorage dashboardFileStorage = new DashboardFileStorage("~/xml");
                //ASPxDashboard1.SetDashboardStorage(dashboardFileStorage);
                DashboardConfigurator.PassCredentials = true;

                if (!Page.IsPostBack)
                    this.CargarGraficos();

            }
            else
                Response.Redirect("~/Default.aspx");



        }


        protected void ASPxDashboardViewer1_ConfigureDataConnection(object sender, DevExpress.DashboardWeb.ConfigureDataConnectionWebEventArgs e)
        {
            MySqlConnectionParameters mysqlParams = new MySqlConnectionParameters();
            mysqlParams.ServerName = "localhost";
            mysqlParams.DatabaseName = (string)(Session["IdBaseDeDatos"]);
            mysqlParams.UserName = "root";
            mysqlParams.Password = "7654321";
            e.ConnectionParameters = mysqlParams;
        }

        protected void ASPxDashboardViewer1_CustomFilterExpression(object sender, CustomFilterExpressionWebEventArgs e)
        {
            //if (e.ItemComponentName == "gridDashboardItem1") //oJO CON ESTO INTERSANTE EL NIVEL DE EVALUACION
            //if (e.DataSourceName == "SQL Data Source 1" && e.TableName == "Invoices") {
            switch (ASPxDashboard1.DashboardXmlFile.ToString())
            {
                case "~/xml/xmlDashboardPresupuesto.xml":
                    if (e.DataSourceName == "Origen de datos SQL 1")
                        e.FilterExpression = (new BinaryOperator("ANO_EJE", tcDemos.ActiveTab.Name.ToString(), BinaryOperatorType.Equal));
                    if (e.DataSourceName == "Origen de datos SQL 2")
                        e.FilterExpression = (new BinaryOperator("ANO_EJE", tcDemos.ActiveTab.Name.ToString(), BinaryOperatorType.Equal));
                    if (e.DataSourceName == "Origen de datos SQL 3")
                        e.FilterExpression = (new BinaryOperator("ANO_EJE", tcDemos.ActiveTab.Name.ToString(), BinaryOperatorType.Equal));
                    if (e.DataSourceName == "Origen de datos SQL 4")
                        e.FilterExpression = (new BinaryOperator("ANO_EJE", tcDemos.ActiveTab.Name.ToString(), BinaryOperatorType.Equal));
                    if (e.DataSourceName == "Origen de datos SQL 5")
                        e.FilterExpression = (new BinaryOperator("ANO_EJE", tcDemos.ActiveTab.Name.ToString(), BinaryOperatorType.Equal));
                    break;
                case "~/xml/xmlDashboardxGenerica.xml":
                    if (e.DataSourceName == "Origen de datos SQL 1")
                        e.FilterExpression = (new BinaryOperator("ANO_EJE", tcDemos.ActiveTab.Name.ToString(), BinaryOperatorType.Equal));

                    break;
                case "~/xml/xmlDashboardFteFtoxFiltroGauge.xml":
                    //if (e.DataSourceName == "Origen de datos SQL 1")
                    //e.FilterExpression = BinaryOperator.And(new BinaryOperator("ANO_EJE", tcDemos.ActiveTab.Name.ToString(), BinaryOperatorType.Equal));
 
                    //      e.FilterExpression = (new BinaryOperator("CICLO", "G", BinaryOperatorType.Equal));
                     e.FilterExpression = CriteriaOperator.Parse("ANO_EJE== '"+tcDemos.ActiveTab.Name.ToString()+"' AND CICLO='G' AND FUNCION<>'00'"); 
                    break;
                case "~/xml/xmlDashboardxGenericaGrafico.xml":
                     e.FilterExpression = CriteriaOperator.Parse("ANO_EJE== '"+tcDemos.ActiveTab.Name.ToString()+"' AND CICLO='G' AND FUNCION<>'00'"); 
                    break;
                default:
                    break;
            }


            //PARA PASAR PARAMETROS EN LA CABECERA REVISAR 
                //e.FilterExpression = BinaryOperator.And(new BinaryOperator("Parámetro1", tcDemos.ActiveTab.Name.ToString(), BinaryOperatorType.Equal));
                //                new BinaryOperator("Parámetro1", tcDemos.ActiveTab.Name.ToString(), BinaryOperatorType.Equal),
                //new BinaryOperator("Level_ID", loggerLevel, BinaryOperatorType.Equal));

        }
        protected void ASPxPageControl1_ActiveTabChangedDashBoard(object source, DevExpress.Web.TabControlEventArgs e)
        {
            switch (this.ASPxPageControl1.ActiveTabPage.ToString())
            {
                case "PRESUPUESTO":
                    ASPxDashboard1.DashboardXmlFile = "~/xml/xmlDashboardPresupuesto.xml";
                    break;
                //case "GENERICA":
                //    ASPxDashboard1.DashboardXmlFile = "~/xml/xmlDashboardxGenerica.xml";
                //    break;
                case "GENERICA":
                    ASPxDashboard1.DashboardXmlFile = "~/xml/xmlDashboardxGenericaGrafico.xml";
                    break;
                case "FUENTE FINANCIAMIENTO":
                    ASPxDashboard1.DashboardXmlFile = "~/xml/xmlDashboardFteFtoxFiltroGauge.xml";
                    break;
                default:
                    break;
            }

        }

        private void CargarGraficos()
        {
            string IdCadena = "";
            //IdCadena = Code.Logic.Forms.Consulta.Cuadro3.SearchByPresupuestoGraf((string)(Session["SecEjecId"]), (string)(Session["IdBaseDeDatos"]), Request.Params["pIdAnoEje"]);
            IdCadena = Code.Logic.Forms.Consulta.Cuadro3.SearchByPresupuestoGraf((string)(Session["SecEjecId"]), (string)(Session["IdBaseDeDatos"]), "2019");

        }
        #region Manejo de Graficos
        //    private void Viewer_DashboardItemControlUpdated(object sender, DevExpress.DashboardWin.DashboardItemControlEventArgs e) {
        //if (e.DashboardItemName == "pieDashboardItem1") {
        //    var viewer = (DashboardViewer)sender;
        //    var chart = e.ChartControl;

        //    var data = viewer.GetItemData(e.DashboardItemName);
        //    var measure = data.GetMeasures()[0];

        //    foreach (Series series in chart.Series) {
        //        var axisPoint = series.Tag as AxisPoint;
        //        if (axisPoint != null) {
        //            var total = data.GetSlice(axisPoint).GetValue(measure).DisplayText;
        //            var view = series.View as PieSeriesView;
        //            if (view != null)
        //                view.Titles[0].Text = string.Format("{0} - {1}", series.Name, total);
        //        }
        //    }
        //}

        //private void Viewer_DashboardItemControlUpdated(object sender, DevExpress.DashboardWin.DashboardItemControlEventArgs e)
        //{
        //    if (e.DashboardItemName == "pieDashboardItem1")
        //    {
        //        var viewer = (DashboardViewer)sender;
        //        var chart = e.ChartControl;

        //        var data = viewer.GetItemData(e.DashboardItemName);
        //        var measure = data.GetMeasures()[0];

        //        foreach (Series series in chart.Series)
        //        {
        //            var axisPoint = series.Tag as AxisPoint;
        //            if (axisPoint != null)
        //            {
        //                var total = data.GetSlice(axisPoint).GetValue(measure).DisplayText;
        //                var view = series.View as PieSeriesView;
        //                if (view != null)
        //                    view.Titles[0].Text = string.Format("{0} - {1}", series.Name, total);
        //                view.Titles[0].Font.Size= 
        //                    view.t
        //            }
        //        }
        //    }
        //}
        #endregion

        #region Pasar parameters revisar
        //public DashboardState InitializeDashboardState()
        //{
        //    DashboardState dashboardState = new DashboardState();
        //    DashboardParameterState parameterState =
        //        new DashboardParameterState("Parámetro1", "XXXX", typeof(string));
        //    dashboardState.Parameters.Add(parameterState);
        //    return dashboardState;
        //}
        //protected void ASPxDashboardViewer1_CustomParameters(object sender, CustomParametersWebEventArgs e)
        //{
        //    var custIDParameter = e.Parameters.FirstOrDefault(p => p.Name == "Parámetro1");  
        //    if (custIDParameter != null)  
        //    {
        //        custIDParameter.Value = tcDemos.ActiveTab.Name.ToString();
        //    }
        //    var custIDParameter =

        //    var custIDParameter = e.Parameters.Where(p => p.Name == "Parámetro1");  
        //    e.Parameters.Where(p => p.Name == "Parámetro1").FirstOrDefault().value = tcDemos.ActiveTab.Name.ToString();
        //}

        //protected void ASPxDashboardViewer1_DashboardLoaded(object sender, DashboardLoadedWebEventArgs e)
        //{
        //    // Specifies default parameter values.
        //    e.Dashboard.Parameters["customerIdParameter"].Value = new List<string>() { "ALFKI", "AROUT", "BONAP" };
        //}

        //private void dashboardViewer1_DashboardItemControlUpdated(object sender,   DashboardItemControlEventArgs e)
        //{
        //    //if (e.DashboardItemName == "gridDashboardItem1")
        //    //{
        //    //    GridView gridView = e.GridControl.MainView as GridView;

        //    //    gridView.Appearance.Row.Font = new Font("Arial", 10);
        //    //}
        //    if (e.DashboardItemName == "pivotDashboardItem1")
        //    {
        //        ChartControl PivotGridControl = e.ChartControl;
        //        ((XYDiagram)chartControl.Diagram).Panes[0].BackColor = Color.AliceBlue;
        //    }
        //}

        //protected void ASPxDashboardViewer1_OnLoad(object sender, EventArgs e)
        //{
        //    //string databasePath = HostingEnvironment.MapPath("~/xml/ejemplo_001.xml");
        //}
        #endregion



   



        #region Manejo de Ejecutora y Periodo
        protected void Load_Xml_Ejecutora(object sender, EventArgs e)
        {
            this.LoadXmlEjecutora();

        }
        protected void LoadXmlEjecutora()
        {
            DataSet ds2 = new DataSet();
            ds2 = Code.Logic.Forms.Consulta.Cuadro.SearchAllEjecutora((string)(Session["SecEjecId"]));
            if (ds2.Tables[0].Rows.Count == 1)
                ASPxTabControleJEjecutora.Visible = false;

            this.XmlDataSource2.Data = "";
            this.XmlDataSource2.DataBind();
            this.XmlDataSource2.Data = CreateXmlMenuEjecutora(ds2);
            this.XmlDataSource2.DataBind();
            ASPxTabControleJEjecutora.DataBind();
        }
        protected void Load_Xml_Periodo(object sender, EventArgs e)
        {
            this.LoadXmlPeriodo();

        }

        protected void LoadXmlPeriodo()
        {
            this.XmlDataSource1.Data = "";
            this.XmlDataSource1.DataBind();
            this.XmlDataSource1.Data = CreateXmlMenuPeriodo(Code.Logic.Forms.Consulta.Cuadro.SearchAllPeriodo((string)(Session["SecEjecId"])));
            this.XmlDataSource1.DataBind();
            tcDemos.DataBind();
        }

        public static string CreateXmlMenuEjecutora(DataSet ds1)
        {
            //Format XML data stream for menu tree
            StringBuilder o1 = new StringBuilder();
            o1.Append("<?xml version='1.0' encoding='utf-8' ?><ejecutoras>");
            int i = 0;
            while (i < ds1.Tables[0].Rows.Count)
            {
                o1.Append("<ejecutora name='" + ds1.Tables[0].Rows[i]["SEC_EJEC"].ToString() + "' text='" + ds1.Tables[0].Rows[i]["ABREVIATURA"].ToString() + "' id='" + ds1.Tables[0].Rows[i]["SEC_EJEC"].ToString() + "'></ejecutora>");
                i++;
            }
            o1.Append("</ejecutoras>");
            return o1.ToString();
        }

        public static string CreateXmlMenuPeriodo(DataSet ds1)
        {
            //Format XML data stream for menu tree
            StringBuilder o1 = new StringBuilder();
            o1.Append("<?xml version='1.0' encoding='utf-8' ?><products>");
            int i = 0;
            while (i < ds1.Tables[0].Rows.Count)
            {
                o1.Append("<product name='" + ds1.Tables[0].Rows[i]["ANO_EJE"].ToString() + "' text='" + ds1.Tables[0].Rows[i]["ANO_EJE"].ToString() + "' id='" + ds1.Tables[0].Rows[i]["ANO_EJE"].ToString() + "'></product>");
                i++;
            }
            o1.Append("</products>");
            return o1.ToString();
        }

        protected void ASPxPageControl1_ActiveTabChanged1(object sender, TabControlEventArgs e)
        {
            //lcSec_ejec = ASPxTabControleJEjecutora.ActiveTab.Name;
            //Aca se coloca el refresh del Dasboard
        }

        protected void ASPxPageControl1_ActiveTabChanged(object sender, TabControlEventArgs e)
        {
            //lcAno_eje = tcDemos.ActiveTab.Name;
            //Aca se coloca el refresh del Dasboard
        }
        #endregion
    }
}