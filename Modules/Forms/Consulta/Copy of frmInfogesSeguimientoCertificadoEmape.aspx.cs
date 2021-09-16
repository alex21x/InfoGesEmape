using System;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Configuration;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Xpo.DB;
using DevExpress.Web.DemoUtils;
using DevExpress.Web;
using DevExpress.Export;
using DevExpress.XtraPrinting;
using DevExpress.Data.Filtering;


using System.Collections.Generic;



namespace InfoGesRegional.Modules.Forms.Consulta
{
    public partial class frmDinamicaSiaf : System.Web.UI.Page
    {
        Session session1;
        string lcLike1, lcLike2;
         #region PageInit
        protected void Page_Init(object sender, EventArgs e)
        {

            session1 = InfoGesRegional.Code.XpoHelper.GetNewSession((string)(Session["IdBaseDeDatos"]));
            XpoDataSource1.Session = session1;
            XpoDataSource11.Session = session1;
            //XpoDataSource1.TypeName = "PersistenObjectsCertificado.infoges_control_certificado";
            XpoDataSource2.Session = session1;
            //XpoDataSource2.TypeName = "PersistenObjectsCertificado.infoges_control_certificado_meta";
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


        protected void Page_Load(object sender, EventArgs e)
        {
            AspxgridviewCertificadoxIdClasificador.SettingsEditing.BatchEditSettings.EditMode  = GridViewBatchEditMode.Row;
            AspxgridviewCertificadoxIdClasificador.SettingsEditing.BatchEditSettings.StartEditAction  = GridViewBatchStartEditAction.Click;
        }

        protected void chkSingleExpanded_CheckedChanged(object sender, EventArgs e)
        {

                AspxgridviewCertificadoxIdClasificador.DetailRows.ExpandAllRows();
        }

        protected void chkSingleCollapse_CheckedChanged(object sender, EventArgs e)
        {
            AspxgridviewCertificadoxIdClasificador.DetailRows.CollapseAllRows();
        }

        protected void grid_AfterPerformCallback(object sender, ASPxGridViewAfterPerformCallbackEventArgs e)
        {
            //ASPxGridView AspxgridviewCertificadoxIdClasificador = (ASPxGridView)sender;
            XpoDataSource1.Criteria = "[ANO_EJE] = '" + tcDemos.ActiveTab.Name.ToString() + "' And [SEC_EJEC] = '" + ASPxTabControleJEjecutora.ActiveTab.Name.ToString() + "'";
            AspxgridviewCertificadoxIdClasificador.DataBind();

         }
        protected void grid_AfterPerformCallback1(object sender, ASPxGridViewAfterPerformCallbackEventArgs e)
        {
            //ASPxGridView ASPxGridInfoGesxMeta = (ASPxGridView)sender;
            XpoDataSource2.Criteria = "[ANO_EJE] = '" + tcDemos.ActiveTab.Name.ToString() + "' And [SEC_EJEC] = '" + ASPxTabControleJEjecutora.ActiveTab.Name.ToString() + "'";
            ASPxGridInfoGesxMeta.DataBind();
        }

        #region hyperLink_InitPROYECTOSNIP
        protected void hyperLink_InitPROYECTOSNIP(object sender, EventArgs e)
        {
            //ASPxHyperLink link = (ASPxHyperLink)sender;

            //GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;

            //int rowVisibleIndex = templateContainer.VisibleIndex;
            ////string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString().Substring(1, 6);
            //string panoeje = tcDemos.ActiveTab.Name.ToString();
            //string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString();
            ////string contentUrl = string.Format("{0}?pId={1}", Session["baseClasif"], pId);
            ////string contentUrl = (string)Session["baseURL"] + pId + "&tipo=2";
            //string contentUrl = (string)Session["baseURL"] + "?tipo=2&codigo=" + pId; //version anterior  http://ofi5.mef.gob.pe/ssi/Inicio.aspx
            ////string contentUrl = (string)Session["baseURL"]  + templateContainer.Grid.GetRowValues(rowVisibleIndex, "PROYECTO_SNIP").ToString();

            //link.NavigateUrl = "javascript:void(0);";

            ////            link.Text = string.Format("More Info: ID_TIPO_CAMBIO - {0}", pId);
            ////link.Text = string.Format("{0:C}", Convert.ToDecimal(templateContainer.Grid.GetRowValues(rowVisibleIndex, "ENERO").ToString()));
            //link.Text = string.Format("{0}", templateContainer.Grid.GetRowValues(rowVisibleIndex, "CERTIFICADO").ToString());
            //link.ClientSideEvents.Click = string.Format("function(s, e) {{ OnMoreInfoClick('{0}'); }}", contentUrl);
        }
        #endregion

        protected void detailGrid_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["pCertificado"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }

        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
            session1.Dispose();
            session1.Disconnect();
            XpoDefault.Session = null;
            //XpoDefault.DataLayer.Dispose();
            XpoDataSource1.Session.Disconnect();
            XpoDataSource1.Session.Dispose();
            XpoDataSource11.Session.Disconnect();
            XpoDataSource11.Session.Dispose();
            XpoDataSource2.Session.Disconnect();
            XpoDataSource2.Session.Dispose();

        }




        #region LoadExpedienteSiafxCertificado
        protected void LoadExpedienteSiafxCertificado(object sender, EventArgs e)
        {

            ASPxGridView AspxgridviewCertificadoxIdClasificador= (ASPxGridView)sender;
            ASPxGridView AspxgridviewExpedienteXCertificado = (ASPxGridView)sender;
            string Key = AspxgridviewCertificadoxIdClasificador.GetMasterRowFieldValues("").ToString();
            DataSet ds3 = new DataSet();
            ds3 = Code.Logic.Forms.Consulta.DinamicaExpediente.SearchByExpedientexCertificado(ASPxTabControleJEjecutora.ActiveTab.Name.ToString(), tcDemos.ActiveTab.Name.ToString(), (string)(Session["IdBaseDeDatos"]), Convert.ToString(AspxgridviewCertificadoxIdClasificador.GetMasterRowKeyValue()));
            AspxgridviewExpedienteXCertificado.DataSource = ds3.Tables[0];
            AspxgridviewExpedienteXCertificado.DataBind();
        }
        #endregion

        #region LoadMetaxGasto
        protected void LoadMetaxGasto()
        {
            //Session["pAnoEje"] = tcDemos.ActiveTab.Name.ToString();
            //Session["pSecEjec"] = ASPxTabControleJEjecutora.ActiveTab.Name.ToString();
            switch (this.ASPxPageControl1.ActiveTabPage.ToString())
            {
                case "CONTROL DE CERTIFICADOS PRESUPUESTARIOS":
                    XpoDataSource1.Criteria = "[ANO_EJE] = '" + tcDemos.ActiveTab.Name.ToString() + "' And [SEC_EJEC] = '" + ASPxTabControleJEjecutora.ActiveTab.Name.ToString() + "'";       
                    AspxgridviewCertificadoxIdClasificador.DataBind();
                    break;
                default:
                    XpoDataSource2.Criteria = "[ANO_EJE] = '" + tcDemos.ActiveTab.Name.ToString() + "' And [SEC_EJEC] = '" + ASPxTabControleJEjecutora.ActiveTab.Name.ToString() + "'";
                    ASPxGridInfoGesxMeta.DataBind();
                    break;
            }



          }
        #endregion

        private static string GetSQLFilterExpression(object filterExpression)
        {
            string expression = "";
            if (filterExpression != null)
            {
                CriteriaOperator op = CriteriaOperator.Parse(filterExpression.ToString());
                expression = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetMsSqlWhere(op);
            }
            return expression;
        }  


        protected void gridView2_BeforeGetCallbackResult(object sender, EventArgs e)
        {


            int start = -1;

            List<string> fields = new List<string>();
            List<string> fields1 = new List<string>();

            for (int i = 0; i < ASPxGridInfoGesxMeta.FilterExpression.Length; i++)
            {
                if (ASPxGridInfoGesxMeta.FilterExpression[i] == '[')
                    start = i;
                if (ASPxGridInfoGesxMeta.FilterExpression[i] == ']')
                {
                    fields.Add(ASPxGridInfoGesxMeta.FilterExpression.Substring(start + 1, i - start - 1));
                    start = -1;
                }

                if (ASPxGridInfoGesxMeta.FilterExpression[i] == ',')
                    start = i;
                if (ASPxGridInfoGesxMeta.FilterExpression[i] == ')')
                {
                    fields1.Add(ASPxGridInfoGesxMeta.FilterExpression.Substring(start + 3, i - start - 4));
                    start = -1;
                }
            }
            lcLike1 = fields.ToString();
            lcLike2 = fields1.ToString();
            if (fields.Count() > 0)
            {
                Session["IdExpedienteCondicion"] = "";

                for (int i = 0; i < fields.Count(); i++)
                {
                    Session["IdExpedienteCondicion"] += "AND " + fields[i] + " LIKE '%" + fields1[i] + "%' ";
                }
                string X2EEQ = XpoDataSource1.Criteria.ToString();
            }
            else
                Session["IdExpedienteCondicion"] = "";



        }


        #region grid_CustomUnboundColumnData
        protected void grid_CustomUnboundColumnData(object sender, DevExpress.Web.ASPxGridViewColumnDataEventArgs e)
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
            if (object.Equals(e.Column, ASPxGridInfoGesxMeta.Columns["PIM"]))
            {
                PrepareTotalFilterItems(e);
                return;
            }
            if (object.Equals(e.Column, ASPxGridInfoGesxMeta.Columns["PIM"]))
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
            this.XmlDataSource1.Data = CreateXmlMenuPeriodo(Code.Logic.Forms.Consulta.Cuadro.SearchAllPeriodo((string)(Session["SecEjecId"])));
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
            gridExport.WriteXlsToResponse(new XlsExportOptionsEx { ExportType = ExportType.WYSIWYG });

        }
        protected void btnXlsExport_Click1(object sender, EventArgs e)
        {
            gridExport1.WriteXlsToResponse(new XlsExportOptionsEx { ExportType = ExportType.WYSIWYG });
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
