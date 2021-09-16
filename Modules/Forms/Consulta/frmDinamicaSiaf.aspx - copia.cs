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
    public partial class frmDinamicaSiaf : System.Web.UI.Page
    {

         #region PageInit
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.LoadXmlEjecutora();
                this.LoadXmlPeriodo();
                this.LoadMetaxGasto();
            }
            if (Context.User.Identity.IsAuthenticated)
            { }
            else
                Response.Redirect("~/Default.aspx");


        }
        #endregion


        #region LoadInfo_Meta_x_Gasto
        protected void LoadInfo_Meta_x_Gasto(object sender, EventArgs e)
        {

            LoadMetaxGasto();


        }
        #endregion

        #region LoadMetaxGasto
        protected void LoadMetaxGasto()
        {

            DataSet ds2 = new DataSet();
            ds2 = Code.Logic.Forms.Consulta.DinamicaSiaf.SearchAllMetaxGenerica(ASPxTabControleJEjecutora.ActiveTab.Name.ToString(), tcDemos.ActiveTab.Name.ToString(), (string)(Session["BaseDeDatos"]));
            ASPxGridInfoGes.DataSource = ds2.Tables[0];
            ASPxGridInfoGes.GroupBy(ASPxGridInfoGes.Columns["SEC_FUNC"]);
            ASPxGridInfoGes.DataBind();
            //ASPxGridInfoGes.ExpandAll();
            ds2.Dispose();
            ds2 = null;        }
        #endregion
        
        #region grid_CustomUnboundColumnData
        protected void grid_CustomUnboundColumnData(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "PIM")
            {
                decimal pim = (decimal)e.GetListSourceFieldValue("PRESUPUESTO");
                decimal asignado = (decimal)e.GetListSourceFieldValue("MODIFICACION");
                // int quantity = Convert.ToInt32(e.GetListSourceFieldValue("monto_asignado"));
                e.Value = pim + asignado;
            }
        }
        #endregion

        #region grid_HeaderFilterFillItems
        protected void grid_HeaderFilterFillItems(object sender, ASPxGridViewHeaderFilterEventArgs e)
        {
            if (object.Equals(e.Column, ASPxGridInfoGes.Columns["PIM"]))
            {
                PrepareTotalFilterItems(e);
                return;
            }
            if (object.Equals(e.Column, ASPxGridInfoGes.Columns["PIM"]))
            {
                //PrepareQuantityFilterItems(e);
                return;
            }
        }
        #endregion

        #region PrepareTotalFilterItems
            protected virtual void PrepareTotalFilterItems(ASPxGridViewHeaderFilterEventArgs e)
        {
            e.Values.Clear();
            e.AddShowAll();

            for (int i = 0; i < 1000000; i += 100000)

            {
                double start = i;
                double end = i + 100000;
                e.AddValue(string.Format("from {0:c} to {1:c}", start, end), string.Empty, string.Format("[PIM] >= {0} and [PIM] <= {1}", start, end));
            }
            e.AddValue(string.Format("> {0:c}", 1000000), string.Empty, "[PIM] > 1000000");
        }
        #endregion


        #region Load Periodo

        protected void Load_Xml_Periodo(object sender, EventArgs e)
        {
            this.LoadXmlPeriodo();

        }

        protected void LoadXmlPeriodo()
        {
            this.XmlDataSource1.Data = "";
            this.XmlDataSource1.DataBind();
            this.XmlDataSource1.Data = CreateXmlMenuPeriodo(Code.Logic.Forms.Consulta.Cuadro.SearchAllPeriodo());
            this.XmlDataSource1.DataBind();
            tcDemos.DataBind();
        }
        protected void ASPxPageControl1_ActiveTabChanged(object sender, TabControlEventArgs e)
        {
            //lcAno_eje = tcDemos.ActiveTab.Name;
                this.LoadMetaxGasto();
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

        #endregion

        #region Load_Xml_Ejecutora
        protected void Load_Xml_Ejecutora(object sender, EventArgs e)
        {
            this.LoadXmlEjecutora();

        }
        protected void LoadXmlEjecutora()
        {
            DataSet ds2 = new DataSet();
            ds2 = Code.Logic.Forms.Consulta.Cuadro.SearchAllEjecutora((string)(Session["IdSecEjec"]));
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
            this.LoadMetaxGasto();
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

        #endregion

        #region Print

        protected void btnXlsExport_Click(object sender, EventArgs e)
        {
            gridExport.WriteXlsToResponse();
        }

        //void Export(bool saveAs)
        //{
            

        //    using (MemoryStream stream = new MemoryStream())
        //    {
        //        //if (this.ASPxPageControl2.ActiveTabPage.ToString() == "1")
        //        //{
        //        //ASPxPivotGridExporter1.OptionsPrint.PrintHeadersOnEveryPage = checkPrintHeadersOnEveryPage.Checked;
        //        //ASPxPivotGridExporter1.OptionsPrint.PrintFilterHeaders = checkPrintFilterHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;
        //        //ASPxPivotGridExporter1.OptionsPrint.PrintColumnHeaders = checkPrintColumnHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;
        //        //ASPxPivotGridExporter1.OptionsPrint.PrintRowHeaders = checkPrintRowHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;
        //        //ASPxPivotGridExporter1.OptionsPrint.PrintDataHeaders = checkPrintDataHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;

        //        string contentType = "", fileName = "";
        //        switch (listExportFormat.SelectedIndex)
        //        {
        //            case 0:
        //                contentType = "application/ms-excel";
        //                fileName = "PivotGrid.xls";
        //                ASPxPivotGridExporter1.ExportToXls(stream);
        //                break;
        //        }

        //        byte[] buffer = stream.GetBuffer();

        //        string disposition = saveAs ? "attachment" : "inline";
        //        Response.Clear();
        //        Response.Buffer = false;
        //        Response.AppendHeader("Content-Type", contentType);
        //        Response.AppendHeader("Content-Transfer-Encoding", "binary");
        //        Response.AppendHeader("Content-Disposition", disposition + "; filename=" + fileName);
        //        Response.BinaryWrite(buffer);
        //        Response.End();


        //    }
        //}

        //protected void buttonOpen_Click(object sender, EventArgs e)
        //{
        //    Export(false);
        //}
        //protected void buttonSaveAs_Click(object sender, EventArgs e)
        //{
        //    Export(true);
        //}

        #endregion

        #region LoadCuadroGastoG
        protected void LoadCuadroGastoG(object sender, EventArgs e)
        {
            LoadSnip();
        }
        #endregion


        #region LoadSnip
        protected void LoadSnip()
        {

            WebChartControlGastoG.Series.Clear();
            WebChartControlGastoG.Titles.Clear();

            DataSet ds1 = new DataSet();
            ds1 = Code.Logic.Forms.Consulta.DinamicaSiaf.SearchAllGenerica();
            int end = ds1.Tables[0].Rows.Count;
            Series[] series1 = new Series[end];
            for (int k = 0; k < end; k++)
            {
                series1[k] = new Series("Side-by-Side Bar Series 1", ViewType.Bar);
                series1[k].Points.Add(new SeriesPoint(Convert.ToString(ds1.Tables[0].Rows[k]["GENERICA"]), Convert.ToInt32(ds1.Tables[0].Rows[k]["EJECUCION"])));
                series1[k].Name = Convert.ToString(ds1.Tables[0].Rows[k]["NOMBRE"]) + " " + Convert.ToInt32(ds1.Tables[0].Rows[k]["EJECUCION"]).ToString("C2");
                //series1[k].Label.
                //WebChartControlGastoG.Series.Add(series1[k]);
            }

            if (end > 0)
            {
                //Series seriesG = new Series("Side-by-Side Bar Series 1", ViewType.Bar);

                //for (int k = 0; k < end; k++)
                //{
                //    seriesG.Points.Add(new SeriesPoint(Convert.ToString(ds1.Tables[0].Rows[k]["GENERICA"]), Convert.ToInt32(ds1.Tables[0].Rows[k]["EJECUCION"])));

                //} 

                ////Agregar la Serie al gráfico
                //WebChartControlGastoG.Series.Add(seriesG);


                //WebChartControlGastoG.ToolTipEnabled = DevExpress.Utils.DefaultBoolean.True;
                WebChartControlGastoG.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                WebChartControlGastoG.ToolTipEnabled = DevExpress.Utils.DefaultBoolean.False;
                WebChartControlGastoG.ToolTipOptions.ShowForPoints = false;
                WebChartControlGastoG.ToolTipOptions.ShowForSeries = false;


                SideBySideBarSeriesLabel label = WebChartControlGastoG.Series[0].Label as SideBySideBarSeriesLabel;
                label.Position = DevExpress.XtraCharts.BarSeriesLabelPosition.Top;
                label.PointOptions.PointView = PointView.ArgumentAndValues;
                label.PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;


                //Ocultar la leyenda (si es necesario).
                WebChartControlGastoG.Legend.Visible = true;
                WebChartControlGastoG.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
                WebChartControlGastoG.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside;

                //Cualquiera de las 2 formas funciona
                XYDiagram diagram = WebChartControlGastoG.Diagram as XYDiagram;
                diagram.AxisY.Label.NumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
                diagram.AxisX.Range.Auto = false;
                diagram.AxisX.Label.NumericOptions.Format = NumericFormat.Number;

                //((XYDiagram)WebChartControlGastoG.Diagram).AxisY.Label.NumericOptions.Format = NumericFormat.Number;
                //((XYDiagram)WebChartControlGastoG.Diagram).AxisX.Range.Auto = false;
                //Cualquiera de las 2 formas funciona

                // Rotate the diagram (if necessary).
                ((XYDiagram)WebChartControlGastoG.Diagram).Rotated = true;

                // Añadir un título al gráfico (si es necesario).
                ChartTitle chartTitle1 = new ChartTitle();
                chartTitle1.Text = "Ejecución Gasto x Genérica(Girado)";
                WebChartControlGastoG.Titles.Add(chartTitle1);

            }
        }
        #endregion

    }
}
