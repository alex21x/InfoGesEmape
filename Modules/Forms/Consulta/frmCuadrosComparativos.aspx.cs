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
using DevExpress.Web;
using DevExpress.Web.ASPxTabControl;



namespace InfoGesRegional.Modules.Forms.Consulta
{
    public partial class frmCuadrosComparativos : System.Web.UI.Page
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

            if (Context.User.Identity.IsAuthenticated)
            {

            }
            else
             Response.Redirect("~/Default.aspx");

        }

        #region LoadCuadroGastoG
        protected void LoadCuadroGastoG()
        {

            DataSet ds1 = new DataSet();
            WebChartControlGastoG.Series.Clear();
            WebChartControlGastoG.Titles.Clear();
            ds1 = Code.Logic.Forms.Consulta.Cuadro.SearchAllGenerica(tcDemos.ActiveTab.Name.ToString(), ASPxTabControleJEjecutora.ActiveTab.Name.ToString(), (string)(Session["IdBaseDeDatos"]),false);
            int end = ds1.Tables[0].Rows.Count;
            //string lcAno_eje = "";
            //Series[] series1 = new Series[end];
            //for (int k = 0; k < end; k++)
            //{
            //    if(lcAno_eje!=ds1.Tables[0].Rows[k]["ANO_EJE"])
            //        series1[k] = new Series(Convert.ToString(ds1.Tables[0].Rows[k]["ANO_EJE"]), ViewType.Bar);

            //    series1[k].Points.Add(new SeriesPoint(Convert.ToString(ds1.Tables[0].Rows[k]["NOMBRE"]), Convert.ToInt32(ds1.Tables[0].Rows[k]["EJECUCION"])));
            //    series1[k].LegendPointOptions.ValueNumericOptions.Format = NumericFormat.FixedPoint;
            //    //series1[k].LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            //    WebChartControlGastoG.Series.Add(series1[k]);
            //}
            string lcAno_eje = Convert.ToString(ds1.Tables[0].Rows[0]["ANO_EJE"]);
            Series seriesI = new Series(Convert.ToString(ds1.Tables[0].Rows[0]["ANO_EJE"]), ViewType.Bar);
            for (int k = 0; k < end; k++)
            {
                if (lcAno_eje == ds1.Tables[0].Rows[k]["ANO_EJE"])
                { }
                else
                {
                    WebChartControlGastoG.Series.Add(seriesI);
                     seriesI = new Series(Convert.ToString(ds1.Tables[0].Rows[k]["ANO_EJE"]), ViewType.Bar);
                     lcAno_eje = Convert.ToString(ds1.Tables[0].Rows[k]["ANO_EJE"]);
                }
                seriesI.Points.Add(new SeriesPoint(Convert.ToString(ds1.Tables[0].Rows[k]["NOMBRE"]), Convert.ToInt32(ds1.Tables[0].Rows[k]["EJECUCION"])));
                //seriesI.LegendPointOptions.ValueNumericOptions.Format = NumericFormat.FixedPoint;
                seriesI.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;


            }

            //for (int k = 0; k < end; k++)
            //{
            //    SideBySideBarSeriesLabel label = WebChartControlGastoG.Series[k].Label as SideBySideBarSeriesLabel;
            //    label.LineVisible = true;
            //    label.PointOptions.ValueNumericOptions.Format = NumericFormat.FixedPoint;
            //    label.ResolveOverlappingMode = ResolveOverlappingMode.Default;
            //    label.Position = BarSeriesLabelPosition.Top;
            //}

            if (end > 0)
            {

                foreach( Series series in  WebChartControlGastoG.Series)
                {series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True   ;
                series.ValueScaleType = ScaleType.Numerical;
                }

                WebChartControlGastoG.CrosshairEnabled = DevExpress.Utils.DefaultBoolean.True;


                WebChartControlGastoG.BorderOptions.Visible = false;
                //Ocultar la leyenda (si es necesario).
                WebChartControlGastoG.Legend.Visible = true;
                WebChartControlGastoG.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
                WebChartControlGastoG.Legend.AlignmentVertical = LegendAlignmentVertical.Top;


                ((XYDiagram)WebChartControlGastoG.Diagram).AxisY.Label.NumericOptions.Format = NumericFormat.Number;
                //((XYDiagram)WebChartControlGastoG.Diagram).AxisY.Interlaced = true;
                //((XYDiagram)WebChartControlGastoG.Diagram).AxisY.GridSpacing = 75;
                //((XYDiagram)WebChartControlGastoG.Diagram).AxisY.GridSpacingAuto = false;


                //((XYDiagram)WebChartControlGastoG.Diagram).Rotated = true;

                // Añadir un título al gráfico (si es necesario).
                ChartTitle chartTitle1 = new ChartTitle();
                chartTitle1.Text = "Ejecución Gasto x Genérica(Girado)";
                WebChartControlGastoG.Titles.Add(chartTitle1);

            }
        }
        #endregion



        private void CargarGraficos()
        {
            this.LoadCuadroGastoG();
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
            this.XmlDataSource1.Data = CreateXmlMenuPeriodo(Code.Logic.Forms.Consulta.Cuadro.SearchAllPeriodo((string)(Session["SecEjecId"])));
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
    }
}
