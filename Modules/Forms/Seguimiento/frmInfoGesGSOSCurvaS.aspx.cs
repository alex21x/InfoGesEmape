using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
//using System;
//using System.Collections.Generic;
//using System.Data;
using System.Drawing;
using System.IO;
//using System.Linq;
using System.Net.Mime;
using DevExpress.XtraCharts.Native;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;



namespace InfogesEmape.Modules.Forms.Seguimiento
{
    public partial class frmInfoGesGSOSCurvaS : System.Web.UI.Page
    {

        private string pIdProyecto;
        private string pIdContrato;
        private string pIdValorizacion;
        private string pEjecucion;
        protected void Page_Load(object sender, EventArgs e)
        {


            pIdProyecto = (string)Session["pIdProyecto"];
            pIdContrato = "" + Request.Params["pIdContrato"];
            pIdValorizacion = "" + Request.Params["pIdValorizacion"];
            pEjecucion = "" + Request.Params["pEjecucion"];

            SearchByProyectoContrato();
            SearchByProyectoContratoResumen();
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();
            string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();

            //ds1 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoCronograma((string)(Session["pIdProyecto"]), IdContrato);
            ds1 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoCronograma02((string)(Session["pIdProyecto"]), IdContrato, pIdValorizacion, pEjecucion);
            //comparacin en soles
            ds2 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoCronograma03((string)(Session["pIdProyecto"]), IdContrato, pIdValorizacion, pEjecucion);
            //PARA PASAR DATOS AL GRID
            GridProyectoContratoResumen.DataSource = ds2.Tables[0];
            GridProyectoContratoResumen.DataBind();
                
            //int IdValorizacion = 1;
            //DataSet ds2 = new DataSet();
            //ds2= Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoCon((string)(Session["pIdProyecto"]), IdContrato);
            Series series1 = new Series("PROGRAMACIÓN", ViewType.Line);
			Series series2 = new Series("AVANCE", ViewType.Line);
			series1.ArgumentDataMember = "CRONOGRAMA_FECHA";
			series1.ValueDataMembers[0] = "AVANCE_CRONOGRAMA";

			series2.ArgumentDataMember = "SEGUIMIENTO_FECHA";
			series2.ValueDataMembers[0] = "AVANCE_VALORIZACION";

			WebChartControl2.Series.Add(series1);
			WebChartControl2.Series.Add(series2);
			WebChartControl2.DataSource = ds1.Tables[0];
			WebChartControl2.DataMember = "AVANCE";
			WebChartControl2.DataBind();

            Series series3 = new Series("PROGRAMACIÓN S/.", ViewType.Line);
            Series series4 = new Series("AVANCE S/.", ViewType.Line);
            series3.ArgumentDataMember = "CRONOGRAMA_FECHA";
            series3.ValueDataMembers[0] = "MONTO_OBRA";

            series4.ArgumentDataMember = "SEGUIMIENTO_FECHA";
            series4.ValueDataMembers[0] = "MONTOVALORIZACION";

            WebChartControl3.Series.Add(series3);
            WebChartControl3.Series.Add(series4);
            WebChartControl3.DataSource = ds2.Tables[0];
            WebChartControl3.DataMember = "AVANCE";
            WebChartControl3.DataBind();

        }


        #region OnLoadProyectoContrato
        protected void OnLoadProyectoContrato(object sender, EventArgs e)
        {
            this.SearchByProyectoContrato();
        }
        #endregion

        #region SearchByProyectoContrato
        private void SearchByProyectoContrato()
        {

            DataSet ds3 = new DataSet();
            ds3 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContrato((string)(Session["pIdProyecto"]), (string)(Session["IdDni"]));
            GridProyectoContrato.KeyFieldName = "IDCONTRATO";
            GridProyectoContrato.DataSource = ds3.Tables[0];
            GridProyectoContrato.DataBind();
        }

        #endregion

        protected void grafico_Load(object sender, EventArgs e)
        {




        }
        private void SearchByProyectoContratoResumen()
        {
           /* string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();
            DataSet ds4 = new DataSet();
            ds4 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoResumen(pIdProyecto, IdContrato);
            // ds4 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoCronograma02((string)(Session["pIdProyecto"]), IdContrato, pIdValorizacion, pEjecucion);
            GridProyectoContratoResumen.KeyFieldName = "IDCONTRATO";
            GridProyectoContratoResumen.DataSource = ds4.Tables[0];
            GridProyectoContratoResumen.DataBind();*/
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            using (MemoryStream ms = new MemoryStream())
            {

                //PrintableComponentLink pcl = new PrintableComponentLink(new PrintingSystem());
                CompositeLink composLink = new CompositeLink(new PrintingSystem());

                //composLink.CreateMarginalHeaderArea += new CreateAreaEventHandler(composLink_CreateMarginalHeaderArea);

                PrintableComponentLink pcLink1 = new PrintableComponentLink(new PrintingSystem());
                PrintableComponentLink pcLink2 = new PrintableComponentLink(new PrintingSystem());
                PrintableComponentLink pcLink3 = new PrintableComponentLink(new PrintingSystem());
                WebChartControl2.DataBind();
                pcLink3.Component = ((IChartContainer)WebChartControl2).Chart;
                //pcLink3.PrintingSystem = ps;

                pcLink1.Component = this.ASPxGridViewExporter1;
                pcLink2.Component = this.ASPxGridViewExporter2;


               // pcLink3.Component = WebChartControl2;
                // Populate the collection of links in the composite link.
                // The order of operations corresponds to the document structure.
               
                //composLink.Links.Add(linkMainReport);
                //composLink.Links.Add(linkGrid2Report);
                composLink.Links.Add(pcLink2);
                // composLink.Links.Add(WebChartControl2);
                //pcl.Component = gridExporter;
                composLink.Links.Add(pcLink3);

                //composLink.Links.Add(linkGrid1Report);
                composLink.Links.Add(pcLink1);
                composLink.BreakSpace = 100;
                composLink.Margins.Top = 30;

                composLink.Margins.Left = composLink.Margins.Right = 0;
                composLink.Margins.Top = 30;
                composLink.Landscape = true;

                composLink.CreateDocument(true);
                composLink.PrintingSystem.Document.AutoFitToPagesWidth = 1;


                /*pcLink2.Margins.Left = pcLink2.Margins.Right = 0;
                pcLink2.Margins.Top = 10;
                pcLink2.Landscape = true;
                pcLink2.CreateDocument(true);
                pcLink2.PrintingSystem.Document.AutoFitToPagesWidth = 1;*/

                PageHeaderFooter phf = composLink.PageHeaderFooter as PageHeaderFooter;
                phf.Header.Content.Clear();
                //phf.Header.Content.AddRange(new string[] { leftColumn, middleColumn, rightColumn });
                phf.Header.LineAlignment = BrickAlignment.Far;
                composLink.ExportToPdf(ms);
                WriteResponse(this.Response, ms.ToArray(), System.Net.Mime.DispositionTypeNames.Attachment.ToString());
            }
        }

          public static void WriteResponse(HttpResponse response, byte[] filearray, string type)
        {
            response.ClearContent();
            response.Buffer = true;
            response.Cache.SetCacheability(HttpCacheability.Private);
            response.ContentType = "application/pdf";
            ContentDisposition contentDisposition = new ContentDisposition();
            contentDisposition.FileName = "Curva.pdf";
            contentDisposition.DispositionType = type;
            response.AddHeader("Content-Disposition", contentDisposition.ToString());
            response.BinaryWrite(filearray);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
            try
            {
                response.End();
            }
            catch (System.Threading.ThreadAbortException)
            {
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            PrintingSystem ps = new PrintingSystem();

            PrintableComponentLink link = new PrintableComponentLink();
            link.Component = ASPxGridViewExporter1;
            link.PrintingSystem = ps;

            PrintableComponentLink link1 = new PrintableComponentLink();
            link1.Component = ASPxGridViewExporter2;
            link1.PrintingSystem = ps;
            PrintableComponentLink link2 = new PrintableComponentLink();
            WebChartControl2.DataBind();
            link2.Component = ((IChartContainer)WebChartControl2).Chart;
            link2.PrintingSystem = ps;
            CompositeLink compositeLink = new CompositeLink();
            compositeLink.Links.AddRange(new object[] { link1, link2, link });
            compositeLink.BreakSpace = 100;
            compositeLink.PrintingSystem = ps;
            compositeLink.CreateDocument();
            compositeLink.PrintingSystem.ExportOptions.Pdf.DocumentOptions.Author = "Test";
            using (MemoryStream stream = new MemoryStream())
            {
                compositeLink.PrintingSystem.ExportToXls(stream);
                Response.Clear();
                Response.Buffer = false;
                Response.AppendHeader("Content-Type", "application/xls");
                Response.AppendHeader("Content-Transfer-Encoding", "binary");
                Response.AppendHeader("Content-Disposition", "attachment; filename=test.xls");
                Response.BinaryWrite(stream.GetBuffer());
                Response.End();
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            PrintingSystem ps = new PrintingSystem();

            PrintableComponentLink link1 = new PrintableComponentLink();
            link1.Component = ASPxGridViewExporter2;
            link1.PrintingSystem = ps;
            PrintableComponentLink link2 = new PrintableComponentLink();
            WebChartControl2.DataBind();
            link2.Component = ((IChartContainer)WebChartControl2).Chart;
            link2.PrintingSystem = ps;
            CompositeLink compositeLink = new CompositeLink();
            compositeLink.Links.AddRange(new object[] { link1, link2 });
            compositeLink.PrintingSystem = ps;
            compositeLink.CreateDocument();
            compositeLink.PrintingSystem.ExportOptions.Pdf.DocumentOptions.Author = "Test";
            using (MemoryStream stream = new MemoryStream())
            {
                compositeLink.PrintingSystem.ExportToPdf(stream);
                Response.Clear();
                Response.Buffer = false;
                Response.AppendHeader("Content-Type", "application/pdf");
                Response.AppendHeader("Content-Transfer-Encoding", "binary");
                Response.AppendHeader("Content-Disposition", "attachment; filename=test.pdf");
                Response.BinaryWrite(stream.GetBuffer());
                Response.End();
            }
        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
           
        }
    }
}