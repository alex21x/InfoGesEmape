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
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Web;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Native;

using System.Collections.Generic;
using System.Collections.Specialized;

namespace InfoGesRegional.Modules.Forms.Seguimiento
{
    public partial class frmInfoGesGSOS : System.Web.UI.Page
    {
        Session session1;
        string lcLike1, lcLike2;
        #region PageInit
        protected void Page_Init(object sender, EventArgs e)
        {

            session1 = InfoGesRegional.Code.XpoHelper.GetNewSession((string)(Session["IdBaseDeDatos"]));
            XpoDataSource1.Session = session1;
            

            if (!Page.IsPostBack)
            {

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
            this.LoadSemana();
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
            AspxgridviewCertificadoxIdClasificador.DataBind();

         }


        #region LoadASPxPivotGrid
        protected void LoadASPxPivotGrid(object sender, EventArgs e)
        {
            WebChartControl1.SeriesTemplate.ChangeView(DevExpress.XtraCharts.ViewType.Line);
            DataSet ds1 = Code.Logic.Forms.Consulta.GSO_Obras.GSOEstadoSituacional((string)(Session["IdBaseDeDatos"]));
            pivotGrid.DataSource = ds1.Tables[0];
            pivotGrid.Visible = true;
            pivotGrid.DataBind();




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
        }


        #region Print

        protected void btnXlsExport_Click(object sender, EventArgs e)
        {
            gridExport.WriteXlsToResponse(new XlsExportOptionsEx { ExportType = ExportType.WYSIWYG });

        }

        #endregion

        protected void ASPxPageControl1_ActiveTabChanged(object source, TabControlEventArgs e)
        {

        }

        #region Load_Gso_Avance
        protected void Load_Gso_Avance(object sender, EventArgs e)
        {
            //if (this.flagOperacion == "edit")
                this.GetAllObra_Gso_Avance();

        }
        #endregion

        #region OnSelectedindexChangedGrid
        public void OnSelectedindexChangedGrid(object sender, EventArgs e)
        {
            this.GetAllObra_Gso_Avance();
        }
        #endregion

        #region GetAllObra_Gso_Avance
        private void GetAllObra_Gso_Avance()
        {

            //string IdPersonal = (string)Session["IdPersonalBiolatina"];
            DataSet ds3 = new DataSet();
            ds3 = Code.Logic.Forms.Input.GSO_Situacion.GsoSearchAllAvance(this.CboSemana.Value.ToString());
            AspxGridGsoAvance.KeyFieldName = "IDAVANCE";
            AspxGridGsoAvance.DataSource = ds3.Tables[0];
            AspxGridGsoAvance.DataBind();


            //ReadOnlyTemplate template = new ReadOnlyTemplate();


            //(AspxGridGsoAvance.Columns["ABREVIATURA"] as GridViewDataColumn).EditItemTemplate = template;
            //(AspxGridGsoAvance.Columns["ACTIVIDAD"] as GridViewDataColumn).EditItemTemplate = template;
            //(AspxGridGsoAvance.Columns["SEMANA"] as GridViewDataColumn).EditItemTemplate = template;

        }
        #endregion

        protected void ASPxCardView1_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            //foreach (var args in e.InsertValues)
            //    InsertNewItem(args.NewValues);
            OrderedDictionary newValues = null;
            OrderedDictionary keys = null;
           decimal lnObras = 0.0M;
           decimal lnSupervision = 0.0M;
           decimal lnGestion_Proyecto = 0.0M;
           decimal lnInterferencia = 0.0M;

           DataTable dt = new DataTable();
           dt.Clear();
           dt.Columns.Add("IDAVANCE");
           dt.Columns.Add("IDGSOSITUACION");
           dt.Columns.Add("IDSEMANA");
           dt.Columns.Add("IDCOMPONENTEOBRA");
           dt.Columns.Add("PORCENTAJE");


            for (int i = 0; i < AspxGridGsoAvance.VisibleRowCount; i++)
            {
                //if (AspxGridGsoAvance.GetRowValues(i, "IDAVANCE") == id.ToString())
                //{

                //}
                //else
                //{
                DataRow row = dt.NewRow();
                row["IDAVANCE"] = AspxGridGsoAvance.GetRowValues(i, "IDAVANCE").ToString();
                row["IDGSOSITUACION"] = AspxGridGsoAvance.GetRowValues(i, "IDGSOSITUACION").ToString();
                row["IDSEMANA"] = AspxGridGsoAvance.GetRowValues(i, "IDSEMANA").ToString();
                row["IDCOMPONENTEOBRA"] = "36";
                row["PORCENTAJE"] = AspxGridGsoAvance.GetRowValues(i, "OBRA").ToString();
                dt.Rows.Add(row);

                row = dt.NewRow();
                row["IDAVANCE"] = AspxGridGsoAvance.GetRowValues(i, "IDAVANCE").ToString();
                row["IDGSOSITUACION"] = AspxGridGsoAvance.GetRowValues(i, "IDGSOSITUACION").ToString();
                row["IDSEMANA"] = AspxGridGsoAvance.GetRowValues(i, "IDSEMANA").ToString();
                row["IDCOMPONENTEOBRA"] = "37";
                row["PORCENTAJE"] = AspxGridGsoAvance.GetRowValues(i, "SUPERVISION").ToString();
                dt.Rows.Add(row);

                row = dt.NewRow();
                row["IDAVANCE"] = AspxGridGsoAvance.GetRowValues(i, "IDAVANCE").ToString();
                row["IDGSOSITUACION"] = AspxGridGsoAvance.GetRowValues(i, "IDGSOSITUACION").ToString();
                row["IDSEMANA"] = AspxGridGsoAvance.GetRowValues(i, "IDSEMANA").ToString();
                row["IDCOMPONENTEOBRA"] = "38";
                row["PORCENTAJE"] = AspxGridGsoAvance.GetRowValues(i, "GESTION_PROYECTO").ToString();
                dt.Rows.Add(row);

                row = dt.NewRow();
                row["IDAVANCE"] = AspxGridGsoAvance.GetRowValues(i, "IDAVANCE").ToString();
                row["IDGSOSITUACION"] = AspxGridGsoAvance.GetRowValues(i, "IDGSOSITUACION").ToString();
                row["IDSEMANA"] = AspxGridGsoAvance.GetRowValues(i, "IDSEMANA").ToString();
                row["IDCOMPONENTEOBRA"] = "39";
                row["PORCENTAJE"] = AspxGridGsoAvance.GetRowValues(i, "INTERFERENCIA").ToString();
                dt.Rows.Add(row);

                //lnObras = Convert.ToDecimal(AspxGridGsoAvance.GetRowValues(i, "OBRA"));
                //var value2 = AspxGridGsoAvance.GetRowValues(i, "");
                //var value3 = AspxGridGsoAvance.GetRowValues(i, "GESTION_PROYECTO");
                //var value4 = AspxGridGsoAvance.GetRowValues(i, "INTERFERENCIA");
            }

            foreach (var args in e.UpdateValues)
            {
                keys = args.Keys;
                newValues = args.NewValues;
                lnObras=0.00M;
                lnSupervision=0.00M;
                lnGestion_Proyecto=0.00M;
                lnInterferencia=0.00M;
                var id = Convert.ToInt32(keys["IDAVANCE"]);
                lnObras = Convert.ToDecimal(newValues["OBRA"]);
                lnSupervision = Convert.ToDecimal(newValues["SUPERVISION"]);
                lnGestion_Proyecto = Convert.ToDecimal(newValues["GESTION_PROYECTO"]);
                lnInterferencia = Convert.ToDecimal(newValues["INTERFERENCIA"]);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["IDAVANCE"].ToString() == id.ToString())
                    {
                        if(dt.Rows[i]["IDCOMPONENTEOBRA"].ToString()=="36")
                            dt.Rows[i]["PORCENTAJE"]=lnObras.ToString();
                        if(dt.Rows[i]["IDCOMPONENTEOBRA"].ToString()=="37")
                            dt.Rows[i]["PORCENTAJE"]=lnSupervision.ToString();
                        if(dt.Rows[i]["IDCOMPONENTEOBRA"].ToString()=="38")
                            dt.Rows[i]["PORCENTAJE"]=lnGestion_Proyecto.ToString();
                        if(dt.Rows[i]["IDCOMPONENTEOBRA"].ToString()=="39")
                            dt.Rows[i]["PORCENTAJE"]=lnInterferencia.ToString();
                    }
                }
            }
            Code.Logic.Forms.Input.GSO_Situacion.UpdatedGsoAvance(dt);
            e.Handled = true;
        }

        #region Updated_Contrato_Detalle
        protected void Updated_Contrato_Detalle(Object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {

            decimal up = 0.00M;
            if (!Convert.ToString(e.NewValues["OBRA"]).Equals(string.Empty))
            {
                up = Convert.ToInt32(Convert.ToString(e.NewValues["OBRA"]));
            }
            decimal up1 = 0.00M;
            if (!Convert.ToString(e.NewValues["SUPERVISION"]).Equals(string.Empty))
            {
                up1 = Convert.ToInt32(Convert.ToString(e.NewValues["SUPERVISION"]));
            }  

            //    string PRUEBA="caDENA";
        //UpdateItem(e.Keys, e.NewValues);
        //    for (int i = 0; i < AspxGridGsoAvance.VisibleRowCount; i++)
        //    {
        //        e.NewValues[
        //        if (AspxGridGsoAvance.GetRowValues(i, "ABREVIATURA") == "UCV 230-Z")
        //        {
        //        var value1 = AspxGridGsoAvance.gE .GetRowValues(i, "OBRA");
        //        var value2 = AspxGridGsoAvance.GetRowValues(i, "SUPERVISION");
        //        var value3 = AspxGridGsoAvance.GetRowValues(i, "GESTION_PROYECTO");
        //        var value4 = AspxGridGsoAvance.GetRowValues(i, "INTERFERENCIA");
        //        }
        //    }  


        }
        #endregion
        #region LoadSemana
        protected void LoadSemana()
        {
            DataSet ds1 = Code.Logic.Forms.Input.GSO_Situacion.SeachAllSemana("");

            CboSemana.DataSource = ds1.Tables[0];
            CboSemana.TextField = ds1.Tables[0].Columns["SEMANA"].Caption.ToString();
            CboSemana.ValueField = ds1.Tables[0].Columns["IDSEMANA"].Caption.ToString();
            CboSemana.DataBind();
            ds1.Dispose();
            ds1 = null;
        }
        #endregion
        class ReadOnlyTemplate : ITemplate
        {
            public void InstantiateIn(Control _container)
            {
                GridViewEditItemTemplateContainer container = _container as GridViewEditItemTemplateContainer;

                ASPxLabel lbl = new ASPxLabel();
                lbl.ID = "lbl";

                container.Controls.Add(lbl);
                lbl.Text = container.Text;
            }
        }
    }
}
