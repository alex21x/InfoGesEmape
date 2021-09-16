#region Using Directives
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.XtraPivotGrid;
using DevExpress.Web.ASPxPivotGrid;
using System.IO;
using System.Drawing;
using DevExpress.Utils;

#endregion

namespace InfoGesConsultas.Modules.Forms.Consulta
{
    public partial class frmConsultasClasificadorxActProy : System.Web.UI.Page
    {


        #region Load
        protected void Page_Load(object sender, EventArgs e)
        {
            InfoGesConsultas.Modules.MasterPage m = (InfoGesConsultas.Modules.MasterPage)Page.Master;
            //flagOperacion = "" + Request.Params["pOpera"];


            if (!Page.IsPostBack)   
            {

                if (!IsPostBack)
                {

                }

            }
        }
        #endregion

        #region LoadAvanceDeObra
        protected void LoadAvanceDeObra(object sender, EventArgs e)
        {
            DataSet ds2 = new DataSet();
            ds2 = Code.Logic.Forms.Consulta.ConsultasAvanceDeObras.SearchAvanceObra1();
            pivotGrid.DataSource = ds2.Tables[0];
            pivotGrid.DataBind();
            ds2.Dispose();
            ds2 = null;
        }
        #endregion

        #region GroupsExpandCollapse
        void GroupsExpandCollapse(bool expand)
        {
            foreach (PivotGridGroup group in pivotGrid.Groups)
                foreach (PivotGridFieldBase field in group)
                    field.ExpandedInFieldsGroup = expand;
        }
        #endregion

        #region buttonExpandAll_Click
        protected void buttonExpandAll_Click(object sender, EventArgs e)
        {
            GroupsExpandCollapse(true);
        }
        #endregion

        #region buttonCollapseAll_Click
        protected void buttonCollapseAll_Click(object sender, EventArgs e)
        {
            GroupsExpandCollapse(false);
        }
        #endregion


        protected void ASPxPageControl1_ActiveTabChanged(object source, DevExpress.Web.ASPxTabControl.TabControlEventArgs e)
        {

        }

        protected void ASPxPivotGrid1_CustomCellDisplayText(object sender,
        DevExpress.Web.ASPxPivotGrid.PivotCellDisplayTextEventArgs e)
        {

            //if(e.DataField.FieldName != "Custom") return
            if (Convert.ToDecimal(e.Value.ToString()) > 0 && Convert.ToDecimal(e.Value.ToString()) <= 100)
                 e.DisplayText = string.Format("{0:p0}", e.Value.ToString()+"%");
        }


        protected void CustomCellStyle(object sender,
                    PivotCustomCellStyleEventArgs e)
        {
            if (e.ColumnValueType != PivotGridValueType.Value ||
                e.RowValueType != PivotGridValueType.Value) return;
            if (Convert.ToInt32(e.Value) < 0 &&
              e.DataField.FieldName == "MONTO")
            {
                e.CellStyle.BackColor = Color.Orange;
                e.CellStyle.Font.Bold = true;
            }
        }

        #region Print
        void Export(bool saveAs)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                ASPxPivotGridExporter1.OptionsPrint.PrintHeadersOnEveryPage = checkPrintHeadersOnEveryPage.Checked;
                ASPxPivotGridExporter1.OptionsPrint.PrintFilterHeaders = checkPrintFilterHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;
                ASPxPivotGridExporter1.OptionsPrint.PrintColumnHeaders = checkPrintColumnHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;
                ASPxPivotGridExporter1.OptionsPrint.PrintRowHeaders = checkPrintRowHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;
                ASPxPivotGridExporter1.OptionsPrint.PrintDataHeaders = checkPrintDataHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;

                string contentType = "", fileName = "";
                switch (listExportFormat.SelectedIndex)
                {
                    case 0:
                        contentType = "application/pdf";
                        fileName = "PivotGrid.pdf";
                        ASPxPivotGridExporter1.ExportToPdf(stream);
                        break;
                    case 1:
                        contentType = "application/ms-excel";
                        fileName = "PivotGrid.xls";
                        ASPxPivotGridExporter1.ExportToXls(stream);
                        break;
                    case 2:
                        contentType = "multipart/related";
                        fileName = "PivotGrid.mht";
                        ASPxPivotGridExporter1.ExportToMht(stream, "utf-8", "ASPxPivotGrid Printing Sample", true);
                        break;
                    case 3:
                        contentType = "text/enriched";
                        fileName = "PivotGrid.rtf";
                        ASPxPivotGridExporter1.ExportToRtf(stream);
                        break;
                    case 4:
                        contentType = "text/plain";
                        fileName = "PivotGrid.txt";
                        ASPxPivotGridExporter1.ExportToText(stream);
                        break;
                    case 5:	// TODO
                        contentType = "text/html";
                        fileName = "PivotGrid.htm";
                        ASPxPivotGridExporter1.ExportToHtml(stream, "utf-8", "ASPxPivotGrid Printing Sample", true);
                        break;
                }

                byte[] buffer = stream.GetBuffer();

                string disposition = saveAs ? "attachment" : "inline";
                Response.Clear();
                Response.Buffer = false;
                Response.AppendHeader("Content-Type", contentType);
                Response.AppendHeader("Content-Transfer-Encoding", "binary");
                Response.AppendHeader("Content-Disposition", disposition + "; filename=" + fileName);
                Response.BinaryWrite(buffer);
                Response.End();
            }
        }

        protected void buttonOpen_Click(object sender, EventArgs e)
        {
            Export(false);
        }
        protected void buttonSaveAs_Click(object sender, EventArgs e)
        {
            Export(true);
        }

        #endregion
    }
}

