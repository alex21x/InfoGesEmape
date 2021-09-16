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
    public partial class frmInfoGesGSOCheckList : System.Web.UI.Page
    {
        Session session1;
        string lcLike1, lcLike2;
        #region PageInit
        protected void Page_Init(object sender, EventArgs e)
        {
            this.CboDescripcionCheckList("");
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




        #region CheckList
        #region SearchAllCheckList
        protected void OnLoadCheckList(object sender, EventArgs e)
        {
            this.SearchAllCheckList();
        }
        
        protected void SearchAllCheckList()
        {
            DataSet ds3 = new DataSet();
            ds3 = Code.Logic.Forms.Input.GSO_CheckList.SeachAllCheckList((string)(Session["IdBaseDeDatos"]));
            AspxGridGsoCheckList.DataSource = ds3.Tables[0];
            AspxGridGsoCheckList.KeyFieldName = "IDCHECKLIST";
            AspxGridGsoCheckList.DataBind();
        }
        #endregion

        #region InsertRowCheckList
        protected void InsertRowCheckList(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {

            string lcNombreCheckList = (e.NewValues["CHECKLIST_DESCRIPCION"].ToString().Length == 0 ? "null" : e.NewValues["CHECKLIST_DESCRIPCION"].ToString());

            string Id = "";


            string[] parameters = { lcNombreCheckList.ToString().ToUpper() };
            String LvCadena = Code.Logic.Forms.Input.GSO_CheckList.insertRowCheckList(parameters, Id);
            AspxGridGsoCheckList.CancelEdit();
            e.Cancel = true;
            this.SearchAllCheckList();

        }
        #endregion

        #region UpdatedRowCheckList
        protected void UpdatedRowCheckList(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {

            string lcNombreCheckList = (e.NewValues["CHECKLIST_DESCRIPCION"].ToString().Length == 0 ? "null" : e.NewValues["CHECKLIST_DESCRIPCION"].ToString());
            string[] parameters = { lcNombreCheckList };
            String LvCadena = Code.Logic.Forms.Input.GSO_CheckList.UpdatedRowCheckList(parameters, e.Keys["IDCHECKLIST"].ToString());
            AspxGridGsoCheckList.CancelEdit();
            e.Cancel = true;
            this.SearchAllCheckList();
        }
        #endregion

        #region DeletedRowCheckList
        protected void DeletedRowCheckList(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            String LvCadena = Code.Logic.Forms.Input.GSO_CheckList.DeletedRowCheckList(e.Keys["IDCHECKLIST"].ToString());
            AspxGridGsoCheckList.CancelEdit();
            e.Cancel = true;
            this.SearchAllCheckList();
        }
        #endregion

        #region Validacion

        protected void grid_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            foreach (GridViewColumn column in AspxGridGsoCheckList.Columns)
            {
                GridViewDataColumn dataColumn = column as GridViewDataColumn;
                if (dataColumn == null) continue;
                if (e.NewValues[dataColumn.FieldName] == null)
                {
                    e.Errors[dataColumn] = "El valor no puede ser nulo.";
                }
            }
            if (e.Errors.Count > 0) e.RowError = "Por favor, llenar todos los campos.";
            if (e.NewValues["CHECKLIST_DESCRIPCION"] != null && e.NewValues["CHECKLIST_DESCRIPCION"].ToString().Length < 10)
            {
                AddError(e.Errors, AspxGridGsoCheckList.Columns["CHECKLIST_DESCRIPCION"], "El nombre debe tener al menos 5 caracteres.");
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

            bool hasError = string.IsNullOrEmpty(e.GetValue("CHECKLIST_DESCRIPCION").ToString());
            if (hasError)
            {
                e.Row.ForeColor = System.Drawing.Color.Red;
            }

            hasError = string.IsNullOrEmpty(e.GetValue("TIPOLOGIA_DESCRIPCION").ToString());
            if (hasError)
            {
                e.Row.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void grid_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            if (!AspxGridGsoCheckList.IsNewRowEditing)
            {
                AspxGridGsoCheckList.DoRowValidation();
            }
        }
        #endregion

        #endregion

        #region CheckListActividades



        protected void OnLoadCheckListActividades(object sender, EventArgs e)
        {
            this.LoadCheckListActividades();
        }

        protected void LoadCheckListActividades()
        {
            string IdCheckList = AspxGridGsoCheckList.GetRowValues(AspxGridGsoCheckList.FocusedRowIndex, "IDCHECKLIST").ToString();

            //string IdCheckList = AspxGridGsoCheckList.GetMasterRowKeyValue().ToString();
            DataSet ds2 = Code.Logic.Forms.Input.GSO_CheckList.SearchAllCheckListActividades(IdCheckList);
            AspxGridViewCheckListActividad.DataSource = ds2.Tables[0];
            AspxGridViewCheckListActividad.DataBind();
            //ASPxGridviewFEGasto.ExpandAll();
            ds2.Dispose();
            ds2 = null;
        }
        #region InsertRowCheckListActividades
        protected void InsertRowCheckListActividades(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            string lcNombreCheckListActividad = (e.NewValues["CHECKLIST_ACTIVIDAD_DESCRIPCION"].ToString().Length == 0 ? "null" : e.NewValues["CHECKLIST_ACTIVIDAD_DESCRIPCION"].ToString());

            string[] parameters = { AspxGridGsoCheckList.GetRowValues(AspxGridGsoCheckList.FocusedRowIndex, "IDCHECKLIST").ToString(), lcNombreCheckListActividad };
            String LvCadena = Code.Logic.Forms.Input.GSO_CheckList.insertRowCheckListActividades(parameters);
            AspxGridViewCheckListActividad.CancelEdit();
            e.Cancel = true;
            this.LoadCheckListActividades();

        }
        #endregion

        #region UpdatedRowCheckListActividades
        protected void UpdatedRowCheckListActividades(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string lcNombreCheckListActividad = (e.NewValues["CHECKLIST_ACTIVIDAD_DESCRIPCION"].ToString().Length == 0 ? "null" : e.NewValues["CHECKLIST_ACTIVIDAD_DESCRIPCION"].ToString());

            string Id = e.Keys["IDCHECKLIST_ACTIVIDAD"].ToString();
            string[] parameters = { lcNombreCheckListActividad };
            String LvCadena = Code.Logic.Forms.Input.GSO_CheckList.UpdatedRowCheckListActividades(parameters, Id);
            AspxGridViewCheckListActividad.CancelEdit();
            e.Cancel = true;
            this.LoadCheckListActividades();
        }
        #endregion

        #region DeletedRowCheckListActividades
        protected void DeletedRowCheckListActividades(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string Id = e.Keys["IDCHECKLIST_ACTIVIDAD"].ToString();
            String LvCadena = Code.Logic.Forms.Input.GSO_CheckList.DeletedRowCheckListActividades(Id);
            AspxGridViewCheckListActividad.CancelEdit();
            e.Cancel = true;
            this.LoadCheckListActividades();
        }
        #endregion

        #endregion


        #region Tipologia
        #region SearchAllTipologia
        protected void OnLoadTipologia(object sender, EventArgs e)
        {
            this.SearchAllTipologia();
        }

        protected void SearchAllTipologia()
        {
            DataSet ds3 = new DataSet();
            ds3 = Code.Logic.Forms.Input.GSO_CheckList.SeachAllTipologia((string)(Session["IdBaseDeDatos"]));
            AspxGridGsoTipologia.DataSource = ds3.Tables[0];
            AspxGridGsoTipologia.KeyFieldName = "IDTIPOLOGIA";
            AspxGridGsoTipologia.DataBind();
        }
        #endregion

        #region InsertRowTipologia
        protected void InsertRowTipologia(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {

            string lcNombreTipologia = (e.NewValues["TIPOLOGIA_DESCRIPCION"].ToString().Length == 0 ? "null" : e.NewValues["TIPOLOGIA_DESCRIPCION"].ToString());

            string Id = "";


            string[] parameters = { lcNombreTipologia.ToString().ToUpper() };
            String LvCadena = Code.Logic.Forms.Input.GSO_CheckList.insertRowTipologia(parameters, Id);
            AspxGridGsoTipologia.CancelEdit();
            e.Cancel = true;
            this.SearchAllTipologia();

        }
        #endregion

        #region UpdatedRowTipologia
        protected void UpdatedRowTipologia(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {

            string lcNombreTipologia = (e.NewValues["TIPOLOGIA_DESCRIPCION"].ToString().Length == 0 ? "null" : e.NewValues["TIPOLOGIA_DESCRIPCION"].ToString());
            string[] parameters = { lcNombreTipologia };
            String LvCadena = Code.Logic.Forms.Input.GSO_CheckList.UpdatedRowTipologia(parameters, e.Keys["IDTIPOLOGIA"].ToString());
            AspxGridGsoTipologia.CancelEdit();
            e.Cancel = true;
            this.SearchAllTipologia();
        }
        #endregion

        #region DeletedRowTipologia
        protected void DeletedRowTipologia(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            String LvCadena = Code.Logic.Forms.Input.GSO_CheckList.DeletedRowTipologia(e.Keys["IDTIPOLOGIA"].ToString());
            AspxGridGsoTipologia.CancelEdit();
            e.Cancel = true;
            this.SearchAllTipologia();
        }
        #endregion

        #region Validacion

        protected void grid_RowValidatingTipologia(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            foreach (GridViewColumn column in AspxGridGsoTipologia.Columns)
            {
                GridViewDataColumn dataColumn = column as GridViewDataColumn;
                if (dataColumn == null) continue;
                if (e.NewValues[dataColumn.FieldName] == null)
                {
                    e.Errors[dataColumn] = "El valor no puede ser nulo.";
                }
            }
            if (e.Errors.Count > 0) e.RowError = "Por favor, llenar todos los campos.";
            if (e.NewValues["TIPOLOGIA_DESCRIPCION"] != null && e.NewValues["TIPOLOGIA_DESCRIPCION"].ToString().Length < 10)
            {
                AddError(e.Errors, AspxGridGsoTipologia.Columns["TIPOLOGIA_DESCRIPCION"], "El nombre debe tener al menos 5 caracteres.");
            }

            if (string.IsNullOrEmpty(e.RowError) && e.Errors.Count > 0) e.RowError = "Por favor, corrija los errores.";
        }
        //void AddError(Dictionary<GridViewColumn, string> errors, GridViewColumn column, string errorText)
        //{
        //    if (errors.ContainsKey(column)) return;
        //    errors[column] = errorText;
        //}
        //protected void grid_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        //{
        //    if (!object.Equals(e.RowType, GridViewRowType.Data)) return;

        //    bool hasError = string.IsNullOrEmpty(e.GetValue("TIPO_CHECKLIST_DESCRIPCION").ToString());
        //    if (hasError)
        //    {
        //        e.Row.ForeColor = System.Drawing.Color.Red;
        //    }
        //}
        protected void grid_StartRowEditingTipologia(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            if (!AspxGridGsoTipologia.IsNewRowEditing)
            {
                AspxGridGsoTipologia.DoRowValidation();
            }
        }
        #endregion

        #endregion

        #region CheckListxTipo



        protected void OnLoadCheckListxTipo(object sender, EventArgs e)
        {
            this.LoadCheckListxTipo();
        }

        protected void LoadCheckListxTipo()
        {
            string IdPersona = AspxGridGsoTipologia.GetRowValues(AspxGridGsoTipologia.FocusedRowIndex, "IDTIPOLOGIA").ToString();
            DataSet ds2 = Code.Logic.Forms.Input.GSO_CheckList.SearchCheckListxTipo(IdPersona);
            AspxGridViewCheckListxTipo.DataSource = ds2.Tables[0];
            AspxGridViewCheckListxTipo.DataBind();
            ds2.Dispose();
            ds2 = null;
        }

        #region InsertRowCheckListxTipo
        protected void InsertRowCheckListxTipo(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {

            string lcAbreviatura;

            if (e.NewValues["CHECKLIST_DESCRIPCION"] == null)
                lcAbreviatura = "0";
            else
                lcAbreviatura = (e.NewValues["CHECKLIST_DESCRIPCION"].ToString().Length == 0 ? "null" : e.NewValues["CHECKLIST_DESCRIPCION"].ToString());

            string[] parameters = { AspxGridGsoTipologia.GetRowValues(AspxGridGsoTipologia.FocusedRowIndex, "IDTIPOLOGIA").ToString(), lcAbreviatura };
            String LvCadena = Code.Logic.Forms.Input.GSO_CheckList.insertRowCheckListxTipo(parameters);
            AspxGridViewCheckListxTipo.CancelEdit();
            e.Cancel = true;
            this.LoadCheckListxTipo();

        }
        #endregion

        #region UpdatedRowCheckListxTipo
        protected void UpdatedRowCheckListxTipo(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string lcAbreviatura;

            if (e.NewValues["CHECKLIST_DESCRIPCION"].ToString() != e.OldValues["CHECKLIST_DESCRIPCION"].ToString())
                if (e.NewValues["CHECKLIST_DESCRIPCION"] == null)
                    lcAbreviatura = "";
                else
                    lcAbreviatura = (e.NewValues["CHECKLIST_DESCRIPCION"].ToString().Length == 0 ? "null" : e.NewValues["CHECKLIST_DESCRIPCION"].ToString());
            else
                lcAbreviatura = "NCN";

            string Id = e.Keys["IDSEC"].ToString();
            string[] parameters = { lcAbreviatura };
            String LvCadena = Code.Logic.Forms.Input.GSO_CheckList.UpdatedRowCheckListxTipo(parameters, Id);
            AspxGridViewCheckListxTipo.CancelEdit();
            e.Cancel = true;
            this.LoadCheckListxTipo();
        }
        #endregion

        #region DeletedRowCheckListxTipo
        protected void DeletedRowCheckListxTipo(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string Id = e.Keys["IDSEC"].ToString();
            String LvCadena = Code.Logic.Forms.Input.GSO_CheckList.DeletedRowCheckListxTipo(Id);
            AspxGridViewCheckListxTipo.CancelEdit();
            e.Cancel = true;
            this.LoadCheckListxTipo();
        }
        #endregion
        #region CboDescripcionCheckList
        private void CboDescripcionCheckList(string IdPersona)
        {
            DataSet ds2 = Code.Logic.Forms.Input.GSO_CheckList.SearchDescripcion();
            ((GridViewDataComboBoxColumn)AspxGridViewCheckListxTipo.Columns["CHECKLIST_DESCRIPCION"]).PropertiesComboBox.DataSource = ds2.Tables[0];
            ((GridViewDataComboBoxColumn)AspxGridViewCheckListxTipo.Columns["CHECKLIST_DESCRIPCION"]).PropertiesComboBox.TextField = ds2.Tables[0].Columns["CHECKLIST_DESCRIPCION"].Caption.ToString();
            ((GridViewDataComboBoxColumn)AspxGridViewCheckListxTipo.Columns["CHECKLIST_DESCRIPCION"]).PropertiesComboBox.ValueField = ds2.Tables[0].Columns["IDCHECKLIST"].Caption.ToString();
            ds2.Dispose();
            ds2 = null;

        }
        #endregion

        protected void EditorInitialize_Combo(object sender, ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName == "CHECKLIST_DESCRIPCION")
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
