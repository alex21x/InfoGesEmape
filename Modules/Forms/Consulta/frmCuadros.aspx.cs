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



namespace InfoGesRegional.Modules.Forms.Consulta
{
    public partial class frmCuadros : System.Web.UI.Page
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
            ds1 = Code.Logic.Forms.Consulta.Cuadro.SearchAllGenerica(tcDemos.ActiveTab.Name.ToString(), ASPxTabControleJEjecutora.ActiveTab.Name.ToString(), (string)(Session["IdBaseDeDatos"]), true);
            int end = ds1.Tables[0].Rows.Count;
            Series[] series1 = new Series[end];
            for (int k = 0; k < end; k++)
            {
                series1[k] = new Series("Gasto", ViewType.Bar);
                series1[k].Points.Add(new SeriesPoint(Convert.ToString(ds1.Tables[0].Rows[k]["GENERICA"]), Convert.ToInt32(ds1.Tables[0].Rows[k]["EJECUCION"])));
                series1[k].Name = Convert.ToString(ds1.Tables[0].Rows[k]["NOMBRE"]) + " " + Convert.ToInt32(ds1.Tables[0].Rows[k]["EJECUCION"]).ToString("C2");
                //series1[k].Name = Convert.ToString(ds1.Tables[0].Rows[k]["NOMBRE"]);
                series1[k].LegendPointOptions.ValueNumericOptions.Format = NumericFormat.FixedPoint;
                //series1[k].LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                WebChartControlGastoG.Series.Add(series1[k]);
            }

            for (int k = 0; k < end; k++)
            {
                SideBySideBarSeriesLabel label = WebChartControlGastoG.Series[k].Label as SideBySideBarSeriesLabel;

                
                label.LineVisible = true;
                label.PointOptions.ValueNumericOptions.Format = NumericFormat.FixedPoint;
                label.ResolveOverlappingMode = ResolveOverlappingMode.Default;
                label.Position = BarSeriesLabelPosition.Top;

            }

            if (end > 0)
            {

                WebChartControlGastoG.BorderOptions.Visible = false;
                //Ocultar la leyenda (si es necesario).
                WebChartControlGastoG.Legend.Visible = true;
                WebChartControlGastoG.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
                WebChartControlGastoG.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside;


                ((XYDiagram)WebChartControlGastoG.Diagram).AxisY.Label.NumericOptions.Format = NumericFormat.Number;

                ((XYDiagram)WebChartControlGastoG.Diagram).Rotated = true;

                // Añadir un título al gráfico (si es necesario).
                ChartTitle chartTitle1 = new ChartTitle();
                chartTitle1.Text = "Gasto por Genérica(Devengado)";
                WebChartControlGastoG.Titles.Add(chartTitle1);

            }
        }
        #endregion



        #region LoadCuadroFteFto
        protected void LoadCuadroFteFto()
        {


            DataSet ds1 = new DataSet();

            ds1 = Code.Logic.Forms.Consulta.Cuadro.SearchAllFteFto(tcDemos.ActiveTab.Name.ToString(), ASPxTabControleJEjecutora.ActiveTab.Name.ToString(), (string)(Session["IdBaseDeDatos"]));
            int end = ds1.Tables[0].Rows.Count;
            WebChartControlFteFto.Series.Clear();
            WebChartControlFteFto.Titles.Clear();


            Series seriesG = new Series("Side-by-Side Bar Series 1", ViewType.Pie);
            for (int k = 0; k < end; k++)
            {
                seriesG.Points.Add(new SeriesPoint(Convert.ToString(ds1.Tables[0].Rows[k]["FUENTE_FINANC"]).Substring(0, 12)+" "+ Convert.ToInt32(ds1.Tables[0].Rows[k]["EJECUCION"]).ToString("C2"), Convert.ToInt32(ds1.Tables[0].Rows[k]["EJECUCION"])));

                //seriesG.Name = Convert.ToString(ds1.Tables[0].Rows[k]["FUENTE_FINANC"]).Substring(0,12) + " " + Convert.ToInt32(ds1.Tables[0].Rows[k]["EJECUCION"]).ToString("C2");
                //series1[k].Name = Convert.ToString(ds1.Tables[0].Rows[k]["NOMBRE"]);
                seriesG.LegendPointOptions.ValueNumericOptions.Format = NumericFormat.Percent;
                seriesG.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            }

            if (end > 0)
            {

                WebChartControlFteFto.Series.Add(seriesG);
                WebChartControlFteFto.ToolTipEnabled = DevExpress.Utils.DefaultBoolean.False;
                WebChartControlFteFto.Legend.Visible = true;
                WebChartControlFteFto.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
                WebChartControlFteFto.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside;
                WebChartControlFteFto.BorderOptions.Visible = false;
                
                Series Series = WebChartControlFteFto.Series[0];
                PieSeriesLabel Label = (PieSeriesLabel)Series.Label;
                PiePointOptions PointOptions = (PiePointOptions)Series.Label.PointOptions;
                PieSeriesViewBase View = (PieSeriesViewBase)Series.View;



                Series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

                Label.Position = PieSeriesLabelPosition.Outside;
                Label.ColumnIndent = 20;
                Label.LineVisible = true;

                Label.PointOptions.ValueNumericOptions.Format = NumericFormat.FixedPoint;
                Label.ResolveOverlappingMode = ResolveOverlappingMode.Default;

                PointOptions.PointView = PointView.ArgumentAndValues;
                PointOptions.ValueNumericOptions.Format = NumericFormat.Percent;
                //PointOptions.ArgumentNumericOptions.Format = NumericFormat.Percent;
                //PointOptions.ValueNumericOptions.Precision = 0;
                WebChartControlFteFto.SeriesTemplate.Label.TextAlignment = StringAlignment.Near;
                ChartTitle chartTitle1 = new ChartTitle();
                chartTitle1.Text = "Gasto por Fuente de Fto.(Devengado)";
                WebChartControlFteFto.Titles.Add(chartTitle1);

            }

        }

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

        #region LoadCuadroFuncion
        protected void LoadCuadroFuncion()
        {
            DataSet ds1 = new DataSet();
            WebChartControlFuncion.Series.Clear();
            WebChartControlFuncion.Titles.Clear(); 

            ds1 = Code.Logic.Forms.Consulta.Cuadro.SearchFuncionAcumulado(tcDemos.ActiveTab.Name.ToString(), ASPxTabControleJEjecutora.ActiveTab.Name.ToString(),(string)(Session["IdBaseDeDatos"]));
            int end = ds1.Tables[0].Rows.Count;
            Series seriesI = new Series("Side-by-Side Bar Series 1", ViewType.Bar);
            for (int k = 0; k < end; k++)
            {
                seriesI.Points.Add(new SeriesPoint(Convert.ToString(ds1.Tables[0].Rows[k]["NOMBRE"]) + " " + Convert.ToInt32(ds1.Tables[0].Rows[k]["EJECUCION"]).ToString("C2"), Convert.ToInt32(ds1.Tables[0].Rows[k]["EJECUCION"])));
                //seriesI.Name= Convert.ToString(ds1.Tables[0].Rows[k]["NOMBRE"]) + " " + Convert.ToInt32(ds1.Tables[0].Rows[k]["EJECUCION"]).ToString("C2");
            }
            if (end > 0)
            {
                //Agregar la Serie al gráfico
                WebChartControlFuncion.Series.Add(seriesI);
                WebChartControlFuncion.BorderOptions.Visible = false;
                WebChartControlFuncion.Legend.Visible =  false;
                //WebChartControlFuncion.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
                //WebChartControlFuncion.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside;
                WebChartControlFuncion.ToolTipEnabled = DevExpress.Utils.DefaultBoolean.False;


                SideBySideBarSeriesLabel label = WebChartControlFuncion.Series[0].Label as SideBySideBarSeriesLabel;
                label.PointOptions.PointView = PointView.ArgumentAndValues;
                label.LineVisible = true;
                label.PointOptions.ValueNumericOptions.Format = NumericFormat.FixedPoint;
                label.ResolveOverlappingMode = ResolveOverlappingMode.Default;
                label.Position = BarSeriesLabelPosition.Top;


                ((XYDiagram)WebChartControlFuncion.Diagram).AxisY.Label.NumericOptions.Format = NumericFormat.Number;

                ((XYDiagram)WebChartControlFuncion.Diagram).Rotated = true;

                // Añadir un título al gráfico (si es necesario).
                ChartTitle chartTitle1 = new ChartTitle();
                chartTitle1.Text = "Gasto por Función(Devengado)";
                WebChartControlFuncion.Titles.Add(chartTitle1);
            }

        }
        #endregion

        #region LoadCuadroPieUbigeo
        protected void LoadCuadroPieUbigeo()
        {
            DataSet ds1 = new DataSet();
            ds1 = Code.Logic.Forms.Consulta.Cuadro.SearchAllUbigeo(tcDemos.ActiveTab.Name.ToString(), ASPxTabControleJEjecutora.ActiveTab.Name.ToString(), (string)(Session["IdBaseDeDatos"]));
            WebChartControlPieUbigeo.Series.Clear();
            WebChartControlPieUbigeo.Titles.Clear(); 
            int end = ds1.Tables[0].Rows.Count;
            Series seriesP = new Series("Area", ViewType.Pie);
            for (int k = 0; k < end; k++)
            {
                seriesP.Points.Add(new SeriesPoint(Convert.ToString(ds1.Tables[0].Rows[k]["PROVINCIA"]) + " " + Convert.ToInt32(ds1.Tables[0].Rows[k]["EJECUCION"]).ToString("C2"), Convert.ToInt32(ds1.Tables[0].Rows[k]["EJECUCION"])));
                //seriesP.Name = Convert.ToString(ds1.Tables[0].Rows[k]["PROVINCIA"]) + " " + Convert.ToInt32(ds1.Tables[0].Rows[k]["EJECUCION"]).ToString("C2");
                seriesP.LegendPointOptions.ValueNumericOptions.Format = NumericFormat.Percent;
                seriesP.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            }
            if (end > 0)
            {


                WebChartControlPieUbigeo.Series.Add(seriesP);
                WebChartControlPieUbigeo.ToolTipEnabled = DevExpress.Utils.DefaultBoolean.False;
                WebChartControlPieUbigeo.Legend.Visible = false;
                WebChartControlPieUbigeo.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
                WebChartControlPieUbigeo.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside;
                WebChartControlPieUbigeo.BorderOptions.Visible = false;

                Series Series = WebChartControlPieUbigeo.Series[0];
                PieSeriesLabel Label = (PieSeriesLabel)Series.Label;
                PiePointOptions PointOptions = (PiePointOptions)Series.Label.PointOptions;
                PieSeriesViewBase View = (PieSeriesViewBase)Series.View;



                Series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

                Label.Position = PieSeriesLabelPosition.Outside;
                Label.ColumnIndent = 20;
                Label.LineVisible = true;

                Label.PointOptions.ValueNumericOptions.Format = NumericFormat.FixedPoint;
                Label.ResolveOverlappingMode = ResolveOverlappingMode.Default;

                PointOptions.PointView = PointView.ArgumentAndValues;
                PointOptions.ValueNumericOptions.Format = NumericFormat.Percent;
                //PointOptions.ArgumentNumericOptions.Format = NumericFormat.Percent;
                //PointOptions.ValueNumericOptions.Precision = 0;
                WebChartControlPieUbigeo.SeriesTemplate.Label.TextAlignment = StringAlignment.Near;
                ChartTitle chartTitle1 = new ChartTitle();
                chartTitle1.Text = "Gasto por Ubigeo(Devengado)";
                WebChartControlPieUbigeo.Titles.Add(chartTitle1);
            }

        }
        #endregion

        #region LoadCuadroProramaPpto
        protected void LoadCuadroProramaPpto()
        {

            DataSet ds1 = new DataSet();
            WebChartControlProgramaPpto.Series.Clear();
            WebChartControlProgramaPpto.Titles.Clear();
            ds1 = Code.Logic.Forms.Consulta.Cuadro.SearchAllProgramaPpto(tcDemos.ActiveTab.Name.ToString(), ASPxTabControleJEjecutora.ActiveTab.Name.ToString(), (string)(Session["IdBaseDeDatos"]));
            int end = ds1.Tables[0].Rows.Count;
            Series seriesG = new Series("Side-by-Side Bar Series 1", ViewType.Pie);

            for (int k = 0; k < end; k++)
            {
                seriesG.Points.Add(new SeriesPoint(Convert.ToString(ds1.Tables[0].Rows[k]["NOMBRE"]).ToString().Trim() + " " + Convert.ToInt32(ds1.Tables[0].Rows[k]["EJECUCION"]).ToString("C2"), Convert.ToInt32(ds1.Tables[0].Rows[k]["EJECUCION"])));
            }
            if (end > 0)
            {
                //Agregar la Serie al gráfico
                WebChartControlProgramaPpto.Series.Add(seriesG);
                WebChartControlProgramaPpto.ToolTipEnabled = DevExpress.Utils.DefaultBoolean.False;
                WebChartControlProgramaPpto.Legend.Visible = true;
                WebChartControlProgramaPpto.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
                WebChartControlProgramaPpto.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside;
                WebChartControlProgramaPpto.BorderOptions.Visible = false;

                Series Series = WebChartControlProgramaPpto.Series[0];
                PieSeriesLabel Label = (PieSeriesLabel)Series.Label;
                PiePointOptions PointOptions = (PiePointOptions)Series.Label.PointOptions;
                PieSeriesViewBase View = (PieSeriesViewBase)Series.View;



                Series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

                Label.Position = PieSeriesLabelPosition.Outside;
                Label.ColumnIndent = 20;
                Label.LineVisible = true;

                Label.PointOptions.ValueNumericOptions.Format = NumericFormat.FixedPoint;
                Label.ResolveOverlappingMode = ResolveOverlappingMode.Default;

                PointOptions.PointView = PointView.ArgumentAndValues;
                PointOptions.ValueNumericOptions.Format = NumericFormat.Percent;
                //PointOptions.ArgumentNumericOptions.Format = NumericFormat.Percent;
                //PointOptions.ValueNumericOptions.Precision = 0;
                WebChartControlProgramaPpto.SeriesTemplate.Label.TextAlignment = StringAlignment.Near;
                // Añadir un título al gráfico (si es necesario).
                ChartTitle chartTitle1 = new ChartTitle();
                chartTitle1.Text = "Programa por Resultados.(Devengado)";
                WebChartControlProgramaPpto.Titles.Add(chartTitle1);
            }

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



        //#region Load_AcumuladoContrato
        //protected void Load_AcumuladoContrato(object sender, EventArgs e)
        //{
        //    //this.GetAllAcumuladoContrato();
        //}
        //#endregion

        //#region GetAllAcumuladoContrato
        //private void GetAllAcumuladoContrato()
        //{
        //    DataSet ds3 = new DataSet();
        //    ds3 = Code.Logic.Forms.Consulta.Cuadro.SearchAllContrato(tcDemos.ActiveTab.Name.ToString(), ASPxTabControleJEjecutora.ActiveTab.Name.ToString(), (string)(Session["IdBaseDeDatos"]));
        //    ASPxGridviewContrato.KeyFieldName = "ID_PROCESO";
        //    ASPxGridviewContrato.DataSource = ds3.Tables[0];
        //    ASPxGridviewContrato.DataBind();
        //}
        //#endregion
        
        //#region Load_AcumuladoFinalidad
        //protected void Load_AcumuladoFinalidad(object sender, EventArgs e)
        //{
        //    this.GetAllAcumuladoFinalidad();
        //}
        //#endregion
        
        //#region GetAllAcumuladoFinalidad
        //private void GetAllAcumuladoFinalidad()
        //{
        //    DataSet ds3 = new DataSet();
        //    ds3 = Code.Logic.Forms.Consulta.Cuadro.SearchAllFinalidad(tcDemos.ActiveTab.Name.ToString(), ASPxTabControleJEjecutora.ActiveTab.Name.ToString(), (string)(Session["IdBaseDeDatos"]));
        //    ASPxGridviewFinalidadMeta.KeyFieldName = "FINALIDAD_NOMBRE";
        //    ASPxGridviewFinalidadMeta.DataSource = ds3.Tables[0];
        //    ASPxGridviewFinalidadMeta.DataBind();
        //}
        //#endregion

        private void CargarGraficos()
        {
            this.LoadCuadroGastoG();
            this.LoadCuadroFuncion();
            this.LoadCuadroPieUbigeo();
            this.LoadCuadroProramaPpto();
            this.LoadCuadroFteFto();
            this.GetAllAcumulado();

            this.LoadPresupuesto();
            this.LoadEjecucion();
            this.SearchByGrupoGenerico();
            this.SearchByFuncion();
            this.SearchByFuenteFinanc();
            this.SearchByEspecificaGasto();
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

        #region ASPxGridviewGrupoGenerico
        protected void LoadAspxGridGrupoGenerico(object sender, EventArgs e)
        {
            //this.SearchByGrupoGenerico();
        }

        protected void SearchByGrupoGenerico()
        {
            DataSet ds3 = new DataSet();
            string IdCadena = "2019";
            ds3 = Code.Logic.Forms.Consulta.Cuadro.SearchByGrupoGenerico((string)(Session["SecEjecId"]), (string)(Session["IdBaseDeDatos"]), tcDemos.ActiveTab.Name.ToString());
            ASPxGridviewGrupoGenerico.DataSource = ds3.Tables[0];
            ASPxGridviewGrupoGenerico.DataBind();
        }
        #endregion

        #region ASPxGridviewFuncion
        protected void LoadAspxGridFuncion(object sender, EventArgs e)
        {
            //this.SearchByFuncion();
        }

        protected void SearchByFuncion()
        {
            DataSet ds3 = new DataSet();
            string IdCadena = "2019";
            ds3 = Code.Logic.Forms.Consulta.Cuadro.SearchByFuncion((string)(Session["SecEjecId"]), (string)(Session["IdBaseDeDatos"]), tcDemos.ActiveTab.Name.ToString());
            ASPxGridviewFuncion.DataSource = ds3.Tables[0];
            ASPxGridviewFuncion.DataBind();
        }
        #endregion

        #region ASPxGridviewFuenteFinanc
        protected void LoadAspxGridFuenteFinanc(object sender, EventArgs e)
        {
            //this.SearchByFuenteFinanc();
        }

        protected void SearchByFuenteFinanc()
        {
            DataSet ds3 = new DataSet();
            string IdCadena = "2019";
            ds3 = Code.Logic.Forms.Consulta.Cuadro.SearchByFuenteFinanc((string)(Session["SecEjecId"]), (string)(Session["IdBaseDeDatos"]), tcDemos.ActiveTab.Name.ToString());
            ASPxGridviewFuenteFinanc.DataSource = ds3.Tables[0];
            ASPxGridviewFuenteFinanc.DataBind();
        }
        #endregion

        #region ASPxGridviewEspGasto
        protected void LoadAspxGridEspGasto(object sender, EventArgs e)
        {
            //this.SearchByEspecificaGasto();
        }

        protected void SearchByEspecificaGasto()
        {
            //DataSet ds3 = new DataSet();
            //string IdCadena = "2019";
            //ds3 = Code.Logic.Forms.Consulta.Cuadro.SearchByEspecificaGasto((string)(Session["SecEjecId"]), (string)(Session["IdBaseDeDatos"]), tcDemos.ActiveTab.Name.ToString());
            //ASPxGridviewEspGasto.DataSource = ds3.Tables[0];
            //ASPxGridviewEspGasto.DataBind();
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

