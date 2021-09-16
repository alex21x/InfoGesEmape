using System;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Configuration;
using DevExpress.Web.DemoUtils;
using DevExpress.Web;
using DevExpress.Export;
using DevExpress.XtraPrinting;
using DevExpress.Data.Filtering;


using System.IO;
using System.Collections.Generic;
using DevExpress.Spreadsheet;


namespace InfogesEmape.Modules.Forms.Seguimiento
{
    public partial class frmInfoGesObraPrototipo : System.Web.UI.Page
    {
        private string pValorizacion;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            pValorizacion = "" + Request.Params["pIdValorizacion"];

            if (!Page.IsPostBack)
            {
            }
            if (!Context.User.Identity.IsAuthenticated)
                Response.Redirect("~/Default.aspx");



            //Workbook workbook = new Workbook();
            //// Load a workbook from the stream.
            ////using (FileStream stream = new FileStream("C:\\Arturo\\excel\\prueba.xlsx", FileMode.Open))
            //using (FileStream stream = new FileStream(ASPxUploadControl1.UploadedFiles[0].PostedFile.FileName, FileMode.Open))
            //{
            //    workbook.LoadDocument(stream, DocumentFormat.Xlsx);
            //    string x="";
            //    Worksheet worksheet = workbook.Worksheets[0];
            //    Range usedRange = worksheet.GetUsedRange();
            //    for (int i = 1; i <= usedRange.RowCount - 1; i++)
            //    {
            //        for (int j = 0; j <= usedRange.CurrentRegion.ColumnCount - 1; j++)
            //        {
            //            x = worksheet.Cells[i, j].DisplayText;
            //        }
            //    }

            //    //Table Hoja1 = worksheet.Tables[0];
            //    //RangeDataSourceOptions options = new RangeDataSourceOptions();
            //    //options.PreserveFormulas = true;
            //    //options.SkipHiddenRows = true;
            //    //ASPxGridView1.DataSource = Hoja1.DataRange.GetDataSource(options);
            //}


        }




        #region OnLoadValorizacionContrato
        protected void OnLoadValorizacionContrato(object sender, EventArgs e)
        {
            this.SearchByValorizacionContrato();
        }
        #endregion

        #region SearchByValorizacionContrato
        private void SearchByValorizacionContrato()
        {

            DataSet ds3 = new DataSet();
            ds3 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByValorizacionContrato(pValorizacion, (string)(Session["pIdContrato"]));
            AspxgridviewValorizacioncontrato.KeyFieldName = "IDCONTRATOPRESUPUESTO";
            AspxgridviewValorizacioncontrato.DataSource = ds3.Tables[0];
            AspxgridviewValorizacioncontrato.DataBind();
        }
        #endregion


        protected void ASPxGridView1_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            //Data editing is not allowed in the example
            e.Handled = true;
        }




        #region Print

        protected void btnXlsExport_Click(object sender, EventArgs e)
        {
            gridExport.WriteXlsToResponse(new XlsExportOptionsEx { ExportType = ExportType.WYSIWYG });

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



    }
}
