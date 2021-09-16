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
using DevExpress.XtraPrinting;
using DevExpress.Web;
using DevExpress.Export;




namespace InfoGesRegional.Modules.Forms.Consulta
{
    public partial class frmDinamicaRuc : System.Web.UI.Page
    {

         #region PageInit
        protected void Page_Init(object sender, EventArgs e)
        {
            ASPxGridviewRuc.SettingsPager.PageSize = GridPageSize;
            if (Context.User.Identity.IsAuthenticated)
            { }
            else
                Response.Redirect("~/Default.aspx");

        }
        #endregion

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
            ds3 = Code.Logic.Forms.Consulta.DinamicaRuc.SearchAllRucGrupo(ASPxTabControleJEjecutora.ActiveTab.Name.ToString(), (string)(Session["IdBaseDeDatos"]));
            ASPxGridviewRuc.KeyFieldName = "RUC";
            ASPxGridviewRuc.DataSource = ds3.Tables[0];

            ASPxGridviewRuc.DataBind();
        }
        #endregion


        protected void detailGrid_DataSelect(object sender, EventArgs e)
        {
            //Session["CustomerID"] = (sender as ASPxGridView).GetMasterRowKeyValue();OnBeforePerformDataSelect="detailGrid_DataSelect"

            ASPxGridView ASPxGridviewRucDet = (ASPxGridView)sender;
            ASPxGridviewRucDet.DataSource = Code.Logic.Forms.Consulta.DinamicaRuc.SearchAllRucDet(ASPxTabControleJEjecutora.ActiveTab.Name.ToString(), Convert.ToString((sender as ASPxGridView).GetMasterRowKeyValue()), (string)(Session["IdBaseDeDatos"]));
            ASPxGridviewRucDet.DataBind();
        }

        #region LoadRucDet
        protected void LoadRucDet(object sender, EventArgs e)
        {
            //


            ASPxGridView ASPxGridviewRuc = (ASPxGridView)sender;
            ASPxGridView ASPxGridviewRucDet = (ASPxGridView)sender;
            DataSet ds3 = new DataSet();
            ds3 = Code.Logic.Forms.Consulta.DinamicaRuc.SearchAllRucDet(ASPxTabControleJEjecutora.ActiveTab.Name.ToString(), Convert.ToString(ASPxGridviewRuc.GetMasterRowKeyValue()), (string)(Session["IdBaseDeDatos"]));
            ASPxGridviewRucDet.DataSource = ds3.Tables[0];
            ASPxGridviewRucDet.DataBind();
        }
        #endregion

        #region Load_Xml_Ejecutora
        protected void Load_Xml_Ejecutora(object sender, EventArgs e)
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
            this.GetAllAcumuladoRuc(sender);
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

        const string PageSizeSessionKey = "ed5e843d-cff7-47a7-815e-832923f7fb09";

        protected int GridPageSize
        {
            get
            {
                if (Session[PageSizeSessionKey] == null)
                    return ASPxGridviewRuc.SettingsPager.PageSize;
                return (int)Session[PageSizeSessionKey];
            }
            set { Session[PageSizeSessionKey] = value; }
        }



        protected void Grid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            GridPageSize = int.Parse(e.Parameters);
            ASPxGridviewRuc.SettingsPager.PageSize = GridPageSize;
            ASPxGridviewRuc.DataBind();
        }

        protected void PagerCombo_Load(object sender, EventArgs e)
        {
            (sender as ASPxComboBox).Value = ASPxGridviewRuc.SettingsPager.PageSize;
        }

    }
}
