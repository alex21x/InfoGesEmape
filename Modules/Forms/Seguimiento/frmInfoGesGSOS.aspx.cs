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
using DevExpress.XtraCharts.Native;
using System.Collections.Specialized;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Wizard.Services;
using DevExpress.XtraReports.UI;

namespace InfoGesRegional.Modules.Forms.Seguimiento
{
    public partial class frmInfoGesGSOS : System.Web.UI.Page
    {
        Session session1;
        string lcLike1, lcLike2;
        #region PageInit
        protected void Page_Init(object sender, EventArgs e)
        {

            this.LoadCoordinador();
            this.LoadSemana();
            this.CboDescripcion("");


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

        }

        protected void ASPxDashboardViewer1_ConfigureDataConnection(object sender, DevExpress.DashboardWeb.ConfigureDataConnectionWebEventArgs e)
        {
            MySqlConnectionParameters mysqlParams = new MySqlConnectionParameters();
            mysqlParams.ServerName = "localhost";
            mysqlParams.DatabaseName = "OBRAS";
            mysqlParams.UserName = "root";
            mysqlParams.Password = "7654321";
            e.ConnectionParameters = mysqlParams;
        }


        #region LoadASPxPivotGrid
        protected void LoadASPxPivotGrid(object sender, EventArgs e)
        {

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
            this.GetAllObra_Gso_Avance();

        }
        #endregion

        #region OnSelectedindexChangedGrid
        public void OnSelectedindexChangedGrid(object sender, EventArgs e)
        {
            this.GetAllObra_Gso_Avance();
        }
        #endregion

        #region RegistroDeAvance
        #region GetAllObra_Gso_Avance
        private void GetAllObra_Gso_Avance()
        {


            DataSet ds3 = new DataSet();
            string lcPassword = "";
            if (this.txtPassword.Value == null)
                lcPassword = "0";
            else
                lcPassword = this.txtPassword.Value.ToString();

            ds3 = Code.Logic.Forms.Input.GSO_Situacion.GsoSearchAllAvance(this.CboSemana.Value.ToString(), this.CboCoordinador.Value.ToString(), lcPassword);
            AspxGridGsoAvance.KeyFieldName = "IDAVANCE";
            AspxGridGsoAvance.DataSource = ds3.Tables[0];

            AspxGridGsoAvance.DataBind();



        }
        #endregion
        #region AvanceOnRowUpdating
        protected void AvanceOnRowUpdating(Object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {

            string lvObra;
            string lvSupervision;
            string lvGestionProyecto;
            string lvInterferencia;


            if (e.NewValues["OBRA"] == null)
                lvObra = e.OldValues["OBRA"].ToString();
            else
                lvObra = (e.NewValues["OBRA"].ToString().Length == 0 ? "null" : e.NewValues["OBRA"].ToString());

            if (e.NewValues["SUPERVISION"] == null)
                lvSupervision = e.OldValues["SUPERVISION"].ToString();
            else
                lvSupervision = (e.NewValues["SUPERVISION"].ToString().Length == 0 ? "null" : e.NewValues["SUPERVISION"].ToString());

            if (e.NewValues["GESTION_PROYECTO"] == null)
                lvGestionProyecto = e.OldValues["GESTION_PROYECTO"].ToString();
            else
                lvGestionProyecto = (e.NewValues["GESTION_PROYECTO"].ToString().Length == 0 ? "null" : e.NewValues["GESTION_PROYECTO"].ToString());

            if (e.NewValues["INTERFERENCIA"] == null)
                lvInterferencia = e.OldValues["INTERFERENCIA"].ToString();
            else
                lvInterferencia = (e.NewValues["INTERFERENCIA"].ToString().Length == 0 ? "null" : e.NewValues["INTERFERENCIA"].ToString());



            string Id = e.Keys["IDAVANCE"].ToString();


            string[] parameters = { lvObra, lvSupervision, lvGestionProyecto, lvInterferencia };

            String LvCadena = Code.Logic.Forms.Input.GSO_Situacion.UpdatedGsoAvanceRow(parameters, Id);
            AspxGridGsoAvance.CancelEdit();
            e.Cancel = true;
            this.GetAllObra_Gso_Avance();
        }
        #endregion

        #region hyperLink_InitPROYECTOSNIP
        protected void hyperLink_InitPROYECTOSNIP(object sender, EventArgs e)
        {
            ASPxHyperLink link = (ASPxHyperLink)sender;

            GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;

            int rowVisibleIndex = templateContainer.VisibleIndex;
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString();
            string contentUrl = "frmInfoGesGSOSReports.aspx" + "?pActProy=" + pId; 
            link.NavigateUrl = "javascript:void(0);";
            link.Text = string.Format("{0}", templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString());
            link.ClientSideEvents.Click = string.Format("function(s, e) {{ OnMoreInfoClick('{0}'); }}", contentUrl);
        }
        #endregion

        #endregion

        #region Coordinador
        #region SearchAllCoordinador
        protected void OnLoadCoordinador(object sender, EventArgs e)
        {
            this.SearchAllCoordinador();
        }
        
        protected void SearchAllCoordinador()
        {
            DataSet ds3 = new DataSet();
            ds3 = Code.Logic.Forms.Input.GSO_Situacion.SeachAllCoordinadorRegistro((string)(Session["IdBaseDeDatos"]));
            AspxGridGsoCoordinador.DataSource = ds3.Tables[0];
            AspxGridGsoCoordinador.KeyFieldName = "IDPERSONA";
            AspxGridGsoCoordinador.DataBind();
        }
        #endregion
        #region InsertRowCoordinador

        protected void InsertRowCoordinador(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {

            string lcDocCoordinador;
            string lcNombreCoordinador;
            if (e.NewValues["DOCUMENTO"] == null)
                lcDocCoordinador = "";
            else
                lcDocCoordinador = (e.NewValues["DOCUMENTO"].ToString().Length == 0 ? "null" : e.NewValues["DOCUMENTO"].ToString());

            if (e.NewValues["NOMBRE"] == null)
                lcNombreCoordinador = "";
            else
                lcNombreCoordinador = (e.NewValues["NOMBRE"].ToString().Length == 0 ? "null" : e.NewValues["NOMBRE"].ToString());

            string Id = "";


            string[] parameters = { Id, lcDocCoordinador, lcNombreCoordinador.ToString().ToUpper() };
            String LvCadena = Code.Logic.Forms.Input.GSO_Situacion.insertRowCoordinador(parameters, Id);
            AspxGridGsoCoordinador.CancelEdit();
            e.Cancel = true;
            this.SearchAllCoordinador();

        }
        #endregion
        #region UpdatedRowCoordinador
        protected void UpdatedRowCoordinador(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string lcDocCoordinador;
            string lcNombreCoordinador;
            if (e.NewValues["DOCUMENTO"] == null)
                lcDocCoordinador = "";
            else
                lcDocCoordinador = (e.NewValues["DOCUMENTO"].ToString().Length == 0 ? "null" : e.NewValues["DOCUMENTO"].ToString());

            if (e.NewValues["NOMBRE"] == null)
                lcNombreCoordinador = "";
            else
                lcNombreCoordinador = (e.NewValues["NOMBRE"].ToString().Length == 0 ? "null" : e.NewValues["NOMBRE"].ToString());

            string Id = e.Keys["IDPERSONA"].ToString();


            string[] parameters = { Id, lcDocCoordinador, lcNombreCoordinador.ToString().ToUpper() };
            String LvCadena = Code.Logic.Forms.Input.GSO_Situacion.UpdatedRowCoordinador(parameters, Id);
            AspxGridGsoCoordinador.CancelEdit();
            e.Cancel = true;
            this.SearchAllCoordinador();
        }
        #endregion
        #region DeletedRowCoordinador
        protected void DeletedRowCoordinador(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string Id = e.Keys["IDPERSONA"].ToString();
             string[] parameters = { Id };
            String LvCadena = Code.Logic.Forms.Input.GSO_Situacion.DeletedRowCoordinador(parameters, Id);
            AspxGridGsoCoordinador.CancelEdit();
            e.Cancel = true;
            this.SearchAllCoordinador();
        }
        #endregion
        #endregion

        #region ASPxCardView1_BatchUpdate
        protected void ASPxCardView1_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {

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
            int xcontador = 0;

            int visibleRowCount = AspxGridGsoAvance.GetCurrentPageRowValues("IDAVANCE").Count;

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

            }

            //for (int i = 0; i < e.UpdateValues[0].NewValues.Count; i++)
            //{
            //    if (!e.UpdateValues[0].NewValues[i].Equals(e.UpdateValues[0].OldValues[i]))
            //    {
            //        string x = "1";
            //    }
            //}

            foreach (var args in e.UpdateValues)
            {
                xcontador = 1;
                keys = args.Keys;
                newValues = args.NewValues;
                lnObras = 0.00M;
                lnSupervision = 0.00M;
                lnGestion_Proyecto = 0.00M;
                lnInterferencia = 0.00M;
                var id = Convert.ToInt32(keys["IDAVANCE"]);
                lnObras = Convert.ToDecimal(newValues["OBRA"]);
                lnSupervision = Convert.ToDecimal(newValues["SUPERVISION"]);
                lnGestion_Proyecto = Convert.ToDecimal(newValues["GESTION_PROYECTO"]);
                lnInterferencia = Convert.ToDecimal(newValues["INTERFERENCIA"]);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["IDAVANCE"].ToString() == id.ToString())
                    {
                        if (dt.Rows[i]["IDCOMPONENTEOBRA"].ToString() == "36")
                            dt.Rows[i]["PORCENTAJE"] = lnObras.ToString();
                        if (dt.Rows[i]["IDCOMPONENTEOBRA"].ToString() == "37")
                            dt.Rows[i]["PORCENTAJE"] = lnSupervision.ToString();
                        if (dt.Rows[i]["IDCOMPONENTEOBRA"].ToString() == "38")
                            dt.Rows[i]["PORCENTAJE"] = lnGestion_Proyecto.ToString();
                        if (dt.Rows[i]["IDCOMPONENTEOBRA"].ToString() == "39")
                            dt.Rows[i]["PORCENTAJE"] = lnInterferencia.ToString();
                    }
                }
            }
            if (xcontador == 1)
            {
                Code.Logic.Forms.Input.GSO_Situacion.UpdatedGsoAvance(dt, this.CboCoordinador.Value.ToString());
                e.Handled = true;
                //this.GetAllObra_Gso_Avance();
            }
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

        #region LoadCoordinador
        protected void LoadCoordinador()
        {
            DataSet ds1 = Code.Logic.Forms.Input.GSO_Situacion.SeachAllCoordinador("");

            CboCoordinador.DataSource = ds1.Tables[0];
            CboCoordinador.TextField = ds1.Tables[0].Columns["NOMBRE"].Caption.ToString();
            CboCoordinador.ValueField = ds1.Tables[0].Columns["IDPERSONA"].Caption.ToString();
            CboCoordinador.DataBind();
            ds1.Dispose();
            ds1 = null;
        }
        #endregion

        #region Validacion
            protected void grid_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
            {
                foreach (GridViewColumn column in AspxGridGsoCoordinador.Columns)
                {
                    GridViewDataColumn dataColumn = column as GridViewDataColumn;
                    if (dataColumn == null) continue;
                    if (e.NewValues[dataColumn.FieldName] == null)
                    {
                        e.Errors[dataColumn] = "El valor no puede ser nulo.";
                    }
                }
                if (e.Errors.Count > 0) e.RowError = "Por favor, llenar todos los campos.";
                if (e.NewValues["NOMBRE"] != null && e.NewValues["NOMBRE"].ToString().Length < 10)
                {
                    AddError(e.Errors, AspxGridGsoCoordinador.Columns["NOMBRE"], "El nombre debe tener al menos diez caracteres.");
                }

                if (e.NewValues["DOCUMENTO"] != null && e.NewValues["DOCUMENTO"].ToString().Length < 8)
                {
                    AddError(e.Errors, AspxGridGsoCoordinador.Columns["DOCUMENTO"], "Registre correctamente el Doc. de Identidad.");
                }


                if (string.IsNullOrEmpty(e.RowError) && e.Errors.Count > 0) e.RowError = "Por favor, corrija los errores.";
            }
            void AddError(Dictionary<GridViewColumn, string> errors, GridViewColumn column, string errorText)
            {
                if (errors.ContainsKey(column)) return;
                errors[column] = errorText;
            }
            protected void grid_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
            {
                if (!object.Equals(e.RowType, GridViewRowType.Data)) return;

                bool hasError = string.IsNullOrEmpty(e.GetValue("NOMBRE").ToString());
                hasError = hasError || (int)e.GetValue("DOCUMENTO") < 18;
                if (hasError)
                {
                    e.Row.ForeColor = System.Drawing.Color.Red;
                }
            }
            protected void grid_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
            {
                if (!AspxGridGsoCoordinador.IsNewRowEditing)
                {
                    AspxGridGsoCoordinador.DoRowValidation();
                }
            }
        #endregion

        #region ASPxGridviewFEGasto
        protected void LoadFEGasto(object sender, EventArgs e)
        {
            this.LoadCoordinacionContrato();
        }
        protected void gvDetail_CustomCallbackG(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            this.LoadCoordinacionContrato();
        }
        protected void LoadCoordinacionContrato()
        {
            string IdPersona = AspxGridGsoCoordinador.GetRowValues(AspxGridGsoCoordinador.FocusedRowIndex, "IDPERSONA").ToString();

            //string IdPersona = AspxGridGsoCoordinador.GetMasterRowKeyValue().ToString();
            DataSet ds2 = Code.Logic.Forms.Input.GSO_Situacion.SearchCoordinadorContrato(IdPersona);
            AspxGridViewCoordinadorContrato.DataSource = ds2.Tables[0];
            AspxGridViewCoordinadorContrato.DataBind();
            //ASPxGridviewFEGasto.ExpandAll();
            ds2.Dispose();
            ds2 = null;
        }
        #endregion

        #region CoordinadorContrato
        #region InsertRowCoordinadorContrato
        protected void InsertRowCoordinadorContrato(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {

            string lcAbreviatura;
            if (e.NewValues["ABREVIATURA"] == null)
                lcAbreviatura = "";
            else
                lcAbreviatura = (e.NewValues["ABREVIATURA"].ToString().Length == 0 ? "null" : e.NewValues["ABREVIATURA"].ToString());

            string[] parameters = {  lcAbreviatura };
            String LvCadena = Code.Logic.Forms.Input.GSO_Situacion.insertRowCoordinadorContrato(parameters, AspxGridGsoCoordinador.GetRowValues(AspxGridGsoCoordinador.FocusedRowIndex, "IDPERSONA").ToString());
            AspxGridViewCoordinadorContrato.CancelEdit();
            e.Cancel = true;
            this.LoadCoordinacionContrato();

        }
        #endregion
        #region UpdatedRowCoordinadorContrato
        protected void UpdatedRowCoordinadorContrato(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string lcAbreviatura;
            if (e.NewValues["ABREVIATURA"] == null)
                lcAbreviatura = "";
            else
                lcAbreviatura = (e.NewValues["ABREVIATURA"].ToString().Length == 0 ? "null" : e.NewValues["ABREVIATURA"].ToString());
            string[] parameters = {  lcAbreviatura };
            //String LvCadena = Code.Logic.Forms.Input.GSO_Situacion.UpdatedRowCoordinadorContrato(parameters, AspxGridGsoCoordinador.GetRowValues(AspxGridGsoCoordinador.FocusedRowIndex, "IDPERSONA").ToString());
            AspxGridViewCoordinadorContrato.CancelEdit();
            e.Cancel = true;
            this.LoadCoordinacionContrato();
        }
        #endregion
        #region DeletedRowCoordinadorContrato
        protected void DeletedRowCoordinadorContrato(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string Id = e.Keys["ACT_PROY"].ToString();
            string[] parameters = { Id };
            //String LvCadena = Code.Logic.Forms.Input.GSO_Situacion.DeletedRowCoordinadorContrato(parameters, AspxGridGsoCoordinador.GetRowValues(AspxGridGsoCoordinador.FocusedRowIndex, "IDPERSONA").ToString());
            AspxGridViewCoordinadorContrato.CancelEdit();
            e.Cancel = true;
            this.LoadCoordinacionContrato();
        }
        #endregion
        #region CboDescripcion
        private void CboDescripcion(string IdPersona)
        {
            DataSet ds2 = Code.Logic.Forms.Input.GSO_Situacion.SearchDescripcion("");
            ((GridViewDataComboBoxColumn)AspxGridViewCoordinadorContrato.Columns["ABREVIATURA"]).PropertiesComboBox.DataSource = ds2.Tables[0];
            ((GridViewDataComboBoxColumn)AspxGridViewCoordinadorContrato.Columns["ABREVIATURA"]).PropertiesComboBox.TextField = ds2.Tables[0].Columns["ABREVIATURA"].Caption.ToString();
            ((GridViewDataComboBoxColumn)AspxGridViewCoordinadorContrato.Columns["ABREVIATURA"]).PropertiesComboBox.ValueField = ds2.Tables[0].Columns["ACT_PROY"].Caption.ToString();
            ds2.Dispose();
            ds2 = null;

        }
        #endregion
        protected void EditorInitialize_Combo(object sender, ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName == "DESCRIPCION")
            {
                ASPxComboBox combo = (ASPxComboBox)e.Editor;
                combo.DataBind();
            }


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
