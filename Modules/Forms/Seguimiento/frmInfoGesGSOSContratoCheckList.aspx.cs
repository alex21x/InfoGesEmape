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
    public partial class frmInfoGesGSOSContratoCheckList : System.Web.UI.Page
    {
        Session session1;
        string lcLike1, lcLike2;
        #region PageInit
        protected void Page_Init(object sender, EventArgs e)
        {
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
            //this.LoadCoordinador();
            //this.LoadSemana();
            XtraReport report = XtraReport.FromFile(Server.MapPath(@"~\Reports\rpt_coordinadores_obras.repx"), true);
            //report.Parameters["pActProy"].Value = Request.Params["pActProy"];
            documentViewer.Report = report;

        }

        protected void detailGrid_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["pCertificado"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }

        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
        }


         protected void ASPxPageControl1_ActiveTabChanged(object source, TabControlEventArgs e)
        {

        }


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


 
        protected void OnLoadCoordinadorContrato(object sender, EventArgs e)
        {
            this.LoadCoordinacionContrato();
        }

        #region InsertRowCoordinadorContrato
        protected void InsertRowCoordinadorContrato(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {

            string lcAbreviatura, lcInsert, lcUpdate, lcDelete, lcQuery, lcCierre, lcSupervision, lcEsResponsable;


                lcInsert = (Convert.ToBoolean(e.NewValues["INSERTAR"]) ? "1" : "0");
                lcUpdate = (Convert.ToBoolean(e.NewValues["ACTUALIZAR"]) ? "1" : "0");
                lcDelete = (Convert.ToBoolean(e.NewValues["ELIMINAR"]) ? "1" : "0");
                lcQuery = (Convert.ToBoolean(e.NewValues["CONSULTA"]) ? "1" : "0");
                lcCierre = (Convert.ToBoolean(e.NewValues["CIERRE"]) ? "1" : "0");
                lcSupervision = (Convert.ToBoolean(e.NewValues["SUPERVISION"]) ? "1" : "0");
                lcEsResponsable= (Convert.ToBoolean(e.NewValues["ESRESPONSABLE"]) ? "1" : "0");

            if (e.NewValues["ABREVIATURA"] == null)
                lcAbreviatura = "0";
            else
                lcAbreviatura = (e.NewValues["ABREVIATURA"].ToString().Length == 0 ? "null" : e.NewValues["ABREVIATURA"].ToString());



            string[] parameters = { lcAbreviatura, lcInsert, lcUpdate, lcDelete, lcQuery, lcCierre, lcSupervision, lcEsResponsable };
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
            string lcInsert = (Convert.ToBoolean(e.NewValues["INSERTAR"]) ? "1" : "0");
            string lcUpdate = (Convert.ToBoolean(e.NewValues["ACTUALIZAR"]) ? "1" : "0");
            string lcDelete = (Convert.ToBoolean(e.NewValues["ELIMINAR"]) ? "1" : "0");
            string lcQuery = (Convert.ToBoolean(e.NewValues["CONSULTA"]) ? "1" : "0");
            string lcCierre = (Convert.ToBoolean(e.NewValues["CIERRE"]) ? "1" : "0");
            string lcSupervision = (Convert.ToBoolean(e.NewValues["SUPERVISION"]) ? "1" : "0");
            string lcEsResponsable = (Convert.ToBoolean(e.NewValues["ESRESPONSABLE"]) ? "1" : "0");

            if (e.NewValues["ABREVIATURA"].ToString() != e.OldValues["ABREVIATURA"].ToString())
                if (e.NewValues["ABREVIATURA"] == null)
                    lcAbreviatura = "";
                else
                    lcAbreviatura = (e.NewValues["ABREVIATURA"].ToString().Length == 0 ? "null" : e.NewValues["ABREVIATURA"].ToString());
            else
                lcAbreviatura = "NCN";

            string Id = e.Keys["IDCOORDINADORCONTRATO"].ToString();
            string[] parameters = { lcAbreviatura, lcInsert, lcUpdate, lcDelete, lcQuery, lcCierre, lcSupervision, lcEsResponsable };
            String LvCadena = Code.Logic.Forms.Input.GSO_Situacion.UpdatedRowCoordinadorContrato(parameters, AspxGridGsoCoordinador.GetRowValues(AspxGridGsoCoordinador.FocusedRowIndex, "IDPERSONA").ToString(), Id);
            AspxGridViewCoordinadorContrato.CancelEdit();
            e.Cancel = true;
            this.LoadCoordinacionContrato();
        }
        #endregion

        #region DeletedRowCoordinadorContrato
        protected void DeletedRowCoordinadorContrato(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string Id = e.Keys["IDCOORDINADORCONTRATO"].ToString();
            String LvCadena = Code.Logic.Forms.Input.GSO_Situacion.DeletedRowCoordinadorContrato(Id);
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
            if (e.Column.FieldName == "ABREVIATURA")
            {
                //ASPxComboBox combo = (ASPxComboBox)e.Editor;
                ASPxComboBox combo = e.Editor as ASPxComboBox;
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
