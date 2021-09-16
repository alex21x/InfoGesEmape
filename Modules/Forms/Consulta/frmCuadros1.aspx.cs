using System;
using System.Text;
using System.IO;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Web;
using System.Web.Security;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Native;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxTabControl;
using DevExpress.Web.ASPxEditors;



namespace InfoGesRegional.Modules.Forms.Consulta
{
    public partial class frmCuadros1 : System.Web.UI.Page
    {

        //string lcAno_eje ;
        //string lcSec_ejec;
        #region PageInit


        protected void Page_Init(object sender, EventArgs e)
        {
///*https://agorapub.net/jubilacion-suiza-adw-peru/?gclid=EAIaIQobChMIv9rZg-T23wIVwyaHCh2UugTUEAEYASAAEgJYFvD_BwE */
///
                this.LoadXmlEjecutora();
                this.LoadXmlPeriodo();
                this.CargarGraficos();

        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InfoGesRegional.Modules.MasterPage m = (InfoGesRegional.Modules.MasterPage)Page.Master;


            if (!IsPostBack)
            {
                ViewType[] restrictedTypes = new ViewType[] { ViewType.PolarArea, ViewType.PolarLine, ViewType.SideBySideGantt,
                ViewType.SideBySideRangeBar, ViewType.RangeBar, ViewType.Gantt, ViewType.PolarPoint, ViewType.Stock, ViewType.CandleStick,
                ViewType.Bubble };
                foreach (ViewType type in Enum.GetValues(typeof(ViewType)))
                {
                    if (Array.IndexOf<ViewType>(restrictedTypes, type) >= 0) continue;
                    ChartType.Items.Add(type.ToString());
                }
                ChartType.SelectedItem = ChartType.Items.FindByText(ViewType.Line.ToString());
                SetChartType(ChartType.SelectedItem.Text);
                //PointLabels.Checked = WebChart.SeriesTemplate.LabelsVisibility == DevExpress.Utils.DefaultBoolean.True;

            }

            if (Context.User.Identity.IsAuthenticated)
            {

            }
            else
             Response.Redirect("~/Default.aspx");

        }




        #region LoadCuadroFteFto

        protected void WebChartControl1_ObjectSelected(object sender, HotTrackEventArgs e)
        {
            Series series = e.Object as Series;
            if (series != null)
            {
                ExplodedSeriesPointCollection explodedPoints = ((PieSeriesViewBase)series.View).ExplodedPoints;
                SeriesPoint point = (SeriesPoint)e.AdditionalObject;
                explodedPoints.ToggleExplodedState(point);
            }
            e.Cancel = series == null;
        }
        #endregion


        #region Load_Acumulado
        protected void Load_Acumulado(object sender, EventArgs e)
        {
            this.GetAllAcumulado();
        }
        #endregion

        #region GetAllAcumulado
        private void GetAllAcumulado()
        {
            ASPxLbPresupuesto.Text = "0,00";
            ASPxLbCompromiso.Text = "0,00";
            ASPxLbDevengado.Text = "0,00";
            ASPxLbGirado.Text = "0,00";
            DataSet ds3 = new DataSet();
            string lcCampo="";
            decimal lPorcentaje = 0;
            ds3 = Code.Logic.Forms.Consulta.Cuadro.SearchGastoAcumulado(tcDemos.ActiveTab.Name.ToString(), ASPxTabControleJEjecutora.ActiveTab.Name.ToString(), (string)(Session["IdBaseDeDatos"]));
            int end = ds3.Tables[0].Rows.Count;

            ASPxLbPresupuesto.Text = "";
            ASPxLbCompromiso.Text = "";
            ASPxLbDevengado.Text = "";
            ASPxLbGirado.Text = "";
            ASPxPorcentaje.Text = "";

            for (int k = 0; k < end; k++)
            {
                //Series seriesG = new Series("Side-by-Side Bar Series 1", ViewType.Pie);
                //ASPxLbPresupuesto.Text = Convert.ToInt32(ds3.Tables[0].Rows[0]["MONTO"]).ToString("C");
                //ASPxLbCompromiso.Text = Convert.ToInt32(ds3.Tables[0].Rows[1]["MONTO"]).ToString("C");
                //ASPxLbDevengado.Text = Convert.ToInt32(ds3.Tables[0].Rows[2]["MONTO"]).ToString("C");
                //ASPxLbGirado.Text = Convert.ToInt32(ds3.Tables[0].Rows[3]["MONTO"]).ToString("C");
                //ASPxPorcentaje.Text = "(" + lPorcentaje.ToString("N") + ")";

                lcCampo=ds3.Tables[0].Rows[k]["CAMPO"].ToString();
                switch (lcCampo) 
                {
                    case "PIM": 
                        ASPxLbPresupuesto.Text = Convert.ToInt32(ds3.Tables[0].Rows[k]["MONTO"]).ToString("C");
                        break;
                    case "COMPROMISO": 
                        ASPxLbCompromiso.Text = Convert.ToInt32(ds3.Tables[0].Rows[k]["MONTO"]).ToString("C");
                        break;
                    case "DEVENGADO":
                        ASPxLbDevengado.Text = Convert.ToInt32(ds3.Tables[0].Rows[k]["MONTO"]).ToString("C");
                        lPorcentaje = (Convert.ToDecimal(ds3.Tables[0].Rows[k]["MONTO"]) / Convert.ToDecimal(ds3.Tables[0].Rows[0]["MONTO"])) * 100;
                        ASPxPorcentaje.Text = "(" + lPorcentaje.ToString("N") + ")";
                        break;
                    case "GIRADO":
                        ASPxLbGirado.Text = Convert.ToInt32(ds3.Tables[0].Rows[k]["MONTO"]).ToString("C");
                        break;
                }
            }

        }
        #endregion


        private void CargarGraficos()
        {
            this.GetAllAcumulado();

            this.LoadPresupuesto();
            this.LoadEjecucion();
        }


        #region Load Periodo

        protected void Load_Xml_Periodo(object sender, EventArgs e)
        {
            this.LoadXmlPeriodo();
         }
        protected void LoadXmlPeriodo()
        {
            this.XmlDataSource1.Data = "";
            this.XmlDataSource1.DataBind();
            this.XmlDataSource1.Data = CreateXmlMenuPeriodo(Code.Logic.Forms.Consulta.Cuadro.SearchAllPeriodo(""));
            this.XmlDataSource1.DataBind();
            tcDemos.DataBind();
        }

        protected void ASPxPageControl1_ActiveTabChanged(object sender, TabControlEventArgs e)
        {
            //lcAno_eje = tcDemos.ActiveTab.Name;
            this.CargarGraficos();
        }

        public static string CreateXmlMenuPeriodo(DataSet ds1)
        {
            //Format XML data stream for menu tree
            StringBuilder o1 = new StringBuilder();
            o1.Clear();
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

        #endregion

        #region ASPxPivotGridPresupuesto

        protected void LoadASPxPivotGridPresupuesto(object sender, EventArgs e)
        {
            this.LoadPresupuesto();
        }

        protected void LoadPresupuesto()
        {
            DataSet ds3 = new DataSet();
            string IdCadena = "2018,2019";
            ds3 = Code.Logic.Forms.Consulta.Cuadro.SearchByPresupuesto((string)(Session["SecEjecId"]), (string)(Session["IdBaseDeDatos"]), tcDemos.ActiveTab.Name.ToString());
            ASPxPivotGridPresupuesto.DataSource = ds3.Tables[0];
            ASPxPivotGridPresupuesto.DataBind();
        }
        #endregion

        #region ASPxPivotGridEjecucion
        protected void LoadASPxPivotGridEjecucion(object sender, EventArgs e)
        {
            this.LoadEjecucion();
        }

        protected void LoadEjecucion()
        {
            DataSet ds3 = new DataSet();
            string IdCadena = "2018,2019";
            ds3 = Code.Logic.Forms.Consulta.Cuadro.SearchByEjecucion((string)(Session["SecEjecId"]), (string)(Session["IdBaseDeDatos"]), tcDemos.ActiveTab.Name.ToString());
            ASPxPivotGridEjecucion.DataSource = ds3.Tables[0];
            ASPxPivotGridEjecucion.DataBind();
        }
        #endregion

        #region LoadGenerica


        protected void LoadGenerica(object sender, EventArgs e)
        {
            this.Generica();

        }

        protected void Generica()
        {
            DataSet ds3 = new DataSet();
            string IdCadena = "2018,2019";
            ds3 = Code.Logic.Forms.Consulta.Cuadro.SearchByGrupoGenerico((string)(Session["SecEjecId"]), (string)(Session["IdBaseDeDatos"]), tcDemos.ActiveTab.Name.ToString());
            ASPxPivotGenerica.DataSource = ds3.Tables[0];
            ASPxPivotGenerica.DataBind();
        }
        #endregion

        #region Load_Xml_Ejecutora
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
   
        protected void ASPxPageControl1_ActiveTabChanged1(object sender, TabControlEventArgs e)
        {
            //lcSec_ejec = ASPxTabControleJEjecutora.ActiveTab.Name;
            this.CargarGraficos();
        }        

        public static string CreateXmlMenuEjecutora(DataSet ds1)
        {
            //Format XML data stream for menu tree
            StringBuilder o1 = new StringBuilder();
            o1.Clear();
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

        #endregion


        void SetChartType(string text)
        {
            WebChart.SeriesTemplate.ChangeView((ViewType)Enum.Parse(typeof(ViewType), text));
            //if (WebChart.SeriesTemplate.Label != null)
            //{
            //    PointLabels.Enabled = true;
            //    WebChart.SeriesTemplate.LabelsVisibility = PointLabels.Checked ? DevExpress.Utils.DefaultBoolean.True : DevExpress.Utils.DefaultBoolean.False;
            //}
            //else
            //    PointLabels.Enabled = false;
        }

        protected void ChartTypeChangedGenerica(object sender, EventArgs e)
        {
            SetChartType(ChartType.SelectedItem.Text);
        }



        protected void ASPxPageControl1_ActiveTabChanged2(object source, TabControlEventArgs e)
        {

        }
    }
}

