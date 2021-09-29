using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DevExpress.Web;


namespace InfogesEmape.Modules.Forms.Seguimiento
{
    public partial class frmInfoGesGsoProyectoRegistroCoordinador_2 : System.Web.UI.Page
    {
        private string pIdOPeracion;
        private string pIdProyecto;
        
        #region PageInit
        protected void Page_Init(object sender, EventArgs e)
        {

        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InfogesEmape.Modules.MasterPage m = (InfogesEmape.Modules.MasterPage)Page.Master;
            pIdOPeracion = "" + Request.Params["pOpera"];
            pIdProyecto = "" + Request.Params["pId"];
            Session["pIdProyecto"] = pIdProyecto;
            pIdProyecto = (pIdProyecto.ToString().Length == 0 ? "0" : pIdProyecto.ToString());
            if (!Page.IsPostBack && !IsCallback)
            {
                if (pIdOPeracion == "edit")
                {
                    if (pIdProyecto == "-1")
                    {
                    }
                    else
                    {
                        SearchByProyecto();
                    }
                }
            }

        }
        #region SearchByProyecto
        public void SearchByProyecto()
        {
            if (pIdProyecto != null)
            {
                DataSet ds1 = new DataSet();

                ds1 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyecto(pIdProyecto);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    pIdProyecto = ds1.Tables[0].Rows[0]["IDPROYECTO"].ToString();
                    DataSet ds2 = new DataSet();


                    ds2 = Code.Logic.Forms.Input.GSO_Situacion.SearchCoordinadorContrato((string)(Session["IdDni"]), ds1.Tables[0].Rows[0]["ACT_PROY"].ToString());

                    if (Convert.ToBoolean(ds2.Tables[0].Rows[0]["CIERRE"]) ? true : false)
                    {
                        GridProyectoProgramacion.SettingsDataSecurity.AllowInsert = false;
                        GridProyectoProgramacion.SettingsDataSecurity.AllowEdit = false;
                        GridProyectoProgramacion.SettingsDataSecurity.AllowDelete = false;

                        GridProyectoSupervision.SettingsDataSecurity.AllowInsert = false;
                        GridProyectoSupervision.SettingsDataSecurity.AllowEdit = false;
                        GridProyectoSupervision.SettingsDataSecurity.AllowDelete = false;

                        GridProyectoValorizacion.SettingsDataSecurity.AllowInsert = false;
                        GridProyectoValorizacion.SettingsDataSecurity.AllowEdit = false;
                        GridProyectoValorizacion.SettingsDataSecurity.AllowDelete = false;

                        GridProyectoAdelanto.SettingsDataSecurity.AllowInsert = false;
                        GridProyectoAdelanto.SettingsDataSecurity.AllowEdit = false;
                        GridProyectoAdelanto.SettingsDataSecurity.AllowDelete = false;

                    }
                    else
                    {
                        GridProyectoProgramacion.SettingsDataSecurity.AllowInsert = Convert.ToBoolean(ds2.Tables[0].Rows[0]["INSERTAR"]) ? true : false;
                        GridProyectoProgramacion.SettingsDataSecurity.AllowEdit = Convert.ToBoolean(ds2.Tables[0].Rows[0]["ACTUALIZAR"]) ? true : false;
                        GridProyectoProgramacion.SettingsDataSecurity.AllowDelete = Convert.ToBoolean(ds2.Tables[0].Rows[0]["ELIMINAR"]) ? true : false;

                        GridProyectoSupervision.SettingsDataSecurity.AllowInsert = Convert.ToBoolean(ds2.Tables[0].Rows[0]["INSERTAR"]) ? true : false;
                        GridProyectoSupervision.SettingsDataSecurity.AllowEdit = Convert.ToBoolean(ds2.Tables[0].Rows[0]["ACTUALIZAR"]) ? true : false;
                        GridProyectoSupervision.SettingsDataSecurity.AllowDelete = Convert.ToBoolean(ds2.Tables[0].Rows[0]["ELIMINAR"]) ? true : false;

                        GridProyectoValorizacion.SettingsDataSecurity.AllowInsert = Convert.ToBoolean(ds2.Tables[0].Rows[0]["INSERTAR"]) ? true : false;
                        GridProyectoValorizacion.SettingsDataSecurity.AllowEdit = Convert.ToBoolean(ds2.Tables[0].Rows[0]["ACTUALIZAR"]) ? true : false;
                        GridProyectoValorizacion.SettingsDataSecurity.AllowDelete = Convert.ToBoolean(ds2.Tables[0].Rows[0]["ELIMINAR"]) ? true : false;

                        GridProyectoAdelanto.SettingsDataSecurity.AllowInsert = Convert.ToBoolean(ds2.Tables[0].Rows[0]["INSERTAR"]) ? true : false;
                        GridProyectoAdelanto.SettingsDataSecurity.AllowEdit = Convert.ToBoolean(ds2.Tables[0].Rows[0]["ACTUALIZAR"]) ? true : false;
                        GridProyectoAdelanto.SettingsDataSecurity.AllowDelete = Convert.ToBoolean(ds2.Tables[0].Rows[0]["ELIMINAR"]) ? true : false;

                    }

                    this.ASPxMemo1.Text = ds1.Tables[0].Rows[0]["ACT_PROY"].ToString() + " " + ds1.Tables[0].Rows[0]["DESCRIPCION"].ToString();


                    this.GridProyectoContrato.Visible = true;
                    this.GridProyectoProgramacion.Visible = true;
                    this.GridProyectoSupervision.Visible = true;
                    this.GridProyectoValorizacion.Visible = true;
                    this.GridProyectoAdelanto.Visible = true;
                }
                else
                {
                    pIdProyecto = "0";
                    pIdOPeracion = "New";

                    this.GridProyectoContrato.Visible = false;
                    this.GridProyectoProgramacion.Visible = false;
                    this.GridProyectoSupervision.Visible = false;
                    this.GridProyectoValorizacion.Visible = false;
                    this.GridProyectoAdelanto.Visible = false;

                }
            }
        }
        #endregion
        #region  btnClose_Click
        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Modules/Forms/Seguimiento/frmInfoGesGSOProyectoCoordinador.aspx");

        }
        #endregion
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
        #region hyperLink_InitPROYECTOSNIP
        protected void hyperLink_InitPROYECTOSNIP(object sender, EventArgs e)
        {
            Session["baseURL"] = "frmInfoGesGsoProyectoRegistroPdf.aspx";

            ASPxHyperLink link = (ASPxHyperLink)sender;

            GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;

            int rowVisibleIndex = templateContainer.VisibleIndex;
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString();
            string contentUrl = (string)Session["baseURL"] + "?tipo=2&codigo=" + pId;

            link.NavigateUrl = "javascript:void(0);";

            link.Text = string.Format("{0}", templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString());
            link.ClientSideEvents.Click = string.Format("function(s, e) {{ OnMoreInfoClick('{0}'); }}", contentUrl);
        }
        #endregion

        #region OnLoadContratoProgramacion
        protected void OnLoadContratoProgramacion(object sender, EventArgs e)
        {
            this.SearchByContratoProgramacion();
        }
        #endregion

        #region SearchByContratoProgramacion
        private void SearchByContratoProgramacion()
        {
            DataSet ds3 = new DataSet();
            string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();
            ds3 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoCronograma((string)(Session["pIdProyecto"]), IdContrato);
            GridProyectoProgramacion.KeyFieldName = "IDCONTRATOCRONOGRAMA";
            GridProyectoProgramacion.DataSource = ds3.Tables[0];
            GridProyectoProgramacion.DataBind();
        }
        #endregion
        #region OnRowInsertingContratoProgramacion
        protected void OnRowInsertingContratoProgramacion(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {

            string pCronograma, pCronogramaFecha, pAvance;

            if (e.NewValues["CRONOGRAMA"] == null)
                pCronograma = "";
            else
                pCronograma = (e.NewValues["CRONOGRAMA"].ToString().Length == 0 ? "null" : e.NewValues["CRONOGRAMA"].ToString());

            if (e.NewValues["CRONOGRAMA_FECHA"] == null)
                pCronogramaFecha = "";
            else
                pCronogramaFecha = (e.NewValues["CRONOGRAMA_FECHA"].ToString().Length == 0 ? "null" : e.NewValues["CRONOGRAMA_FECHA"].ToString());

            if (e.NewValues["AVANCE"] == null)
                pAvance = "";
            else
                pAvance = (e.NewValues["AVANCE"].ToString().Length == 0 ? "null" : e.NewValues["AVANCE"].ToString());



            string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();

            string[] parameters = { IdContrato, pCronograma, pCronogramaFecha, pAvance };
            string LvCadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.InsertRowContratoProgramacion(parameters);
            GridProyectoProgramacion.CancelEdit();
            e.Cancel = true;
            this.SearchByContratoProgramacion();
        }
        #endregion
        #region OnRowUpdatingContratoProgramacion
        protected void OnRowUpdatingContratoProgramacion(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {

            string pCronograma, pCronogramaFecha, pAvance;

            if (e.NewValues["CRONOGRAMA"] == null)
                pCronograma = "";
            else
                pCronograma = (e.NewValues["CRONOGRAMA"].ToString().Length == 0 ? "null" : e.NewValues["CRONOGRAMA"].ToString());

            if (e.NewValues["CRONOGRAMA_FECHA"] == null)
                pCronogramaFecha = "";
            else
                pCronogramaFecha = (e.NewValues["CRONOGRAMA_FECHA"].ToString().Length == 0 ? "null" : e.NewValues["CRONOGRAMA_FECHA"].ToString());

            if (e.NewValues["AVANCE"] == null)
                pAvance = "";
            else
                pAvance = (e.NewValues["AVANCE"].ToString().Length == 0 ? "null" : e.NewValues["AVANCE"].ToString());


            string Id = e.Keys["IDCONTRATOCRONOGRAMA"].ToString();
            string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();

            string[] parameters = { IdContrato, pCronograma, pCronogramaFecha, pAvance };
            string LvCadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.UpdatedRowContratoProgramacion(parameters, Id);
            GridProyectoProgramacion.CancelEdit();
            e.Cancel = true;
            this.SearchByContratoProgramacion();
        }
        #endregion
        #region OnRowDeletingContratoProgramacion
        protected void OnRowDeletingContratoProgramacion(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string Id = e.Keys["IDCONTRATOCRONOGRAMA"].ToString();
            string Cadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.DeletedRowContratoProgramacion(Id);
            GridProyectoProgramacion.CancelEdit();
            e.Cancel = true;
            this.SearchByContratoProgramacion();
        }
        #endregion
        protected void GridProyectoProgramacion_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            foreach (GridViewColumn column in GridProyectoProgramacion.Columns)
            {
                GridViewDataColumn dataColumn = column as GridViewDataColumn;
                if (dataColumn == null) continue;
                if (e.NewValues[dataColumn.FieldName] == null && dataColumn.FieldName != "CRONOGRAMA")
                {
                    e.Errors[dataColumn] = "Valores no pueden ser nulos.";
                }
            }
            if (e.Errors.Count > 0) e.RowError = "Por favor, llenar todos los campos...";
            if (e.NewValues["CRONOGRAMA_FECHA"] != null && e.NewValues["CRONOGRAMA_FECHA"].ToString().Length < 10)
            {
                AddError(e.Errors, GridProyectoProgramacion.Columns["CRONOGRAMA_FECHA"], "Registrar correctamente la Fecha del cronograma.");
            }

            decimal Avance = e.NewValues["AVANCE"] != null ? Convert.ToDecimal(e.NewValues["AVANCE"]) : 0;
            if (Avance == 0)
            {
                AddError(e.Errors, GridProyectoProgramacion.Columns["AVANCE"], "Avance, debe ser > 0.");
            }
            if (Convert.ToDecimal(e.NewValues["AVANCE"]) > 100)
            {
                AddError(e.Errors, GridProyectoProgramacion.Columns["AVANCE"], "Avance, No puede ser mayor al 100%.");
            }

            if (string.IsNullOrEmpty(e.RowError) && e.Errors.Count > 0) e.RowError = "Por favor, corregir los errores.";
        }
        void AddError(Dictionary<GridViewColumn, string> errors, GridViewColumn column, string errorText)
        {
            if (errors.ContainsKey(column)) return;
            errors[column] = errorText;
        }
        protected void GridProyectoProgramacion_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            if (!object.Equals(e.RowType, GridViewRowType.Data)) return;

            bool hasError = string.IsNullOrEmpty(e.GetValue("CRONOGRAMA_FECHA").ToString());

            hasError = hasError || e.GetValue("AVANCE").ToString() == "0";
            if (hasError)
            {
                e.Row.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void GridProyectoProgramacion_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {

            GridProyectoProgramacion.DoRowValidation();
        }

        #region OnLoadContratoSupervision
        protected void OnLoadContratoSupervision(object sender, EventArgs e)
        {
            this.SearchByContratoSupervision();
        }
        #endregion
        #region SearchByContratoSupervision
        private void SearchByContratoSupervision()
        {

            DataSet ds3 = new DataSet();
            string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();
            ds3 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoSeguimiento((string)(Session["pIdProyecto"]), IdContrato);
            GridProyectoSupervision.KeyFieldName = "IDCONTRATOSEGUIMIENTO";
            GridProyectoSupervision.DataSource = ds3.Tables[0];
            GridProyectoSupervision.DataBind();
        }
        #endregion
        #region OnRowInsertingContratoSupervision
        protected void OnRowInsertingContratoSupervision(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {

            string pValorizaconFecha, pValorizacionNumero, pAvance;

            if (e.NewValues["SEGUIMIENTO_FECHA"] == null)
                pValorizaconFecha = "";
            else
                pValorizaconFecha = (e.NewValues["SEGUIMIENTO_FECHA"].ToString().Length == 0 ? "null" : e.NewValues["SEGUIMIENTO_FECHA"].ToString());

            if (e.NewValues["SEGUIMIENTO_CRONOGRAMA"] == null)
                pValorizacionNumero = "";
            else
                pValorizacionNumero = (e.NewValues["SEGUIMIENTO_CRONOGRAMA"].ToString().Length == 0 ? "null" : e.NewValues["SEGUIMIENTO_CRONOGRAMA"].ToString());

            if (e.NewValues["AVANCE"] == null)
                pAvance = "";
            else
                pAvance = (e.NewValues["AVANCE"].ToString().Length == 0 ? "null" : e.NewValues["AVANCE"].ToString());




            string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();

            string[] parameters = { IdContrato, pValorizaconFecha, pValorizacionNumero, pAvance };
            string LvCadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.InsertRowContratoSeguimiento(parameters);
            GridProyectoSupervision.CancelEdit();
            e.Cancel = true;
            this.SearchByContratoSupervision();
        }
        #endregion
        #region OnRowUpdatingContratoSupervision
        protected void OnRowUpdatingContratoSupervision(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {

            string pValorizaconFecha, pValorizacionNumero, pAvance;

            if (e.NewValues["SEGUIMIENTO_FECHA"] == null)
                pValorizaconFecha = "";
            else
                pValorizaconFecha = (e.NewValues["SEGUIMIENTO_FECHA"].ToString().Length == 0 ? "null" : e.NewValues["SEGUIMIENTO_FECHA"].ToString());

            if (e.NewValues["SEGUIMIENTO_CRONOGRAMA"] == null)
                pValorizacionNumero = "";
            else
                pValorizacionNumero = (e.NewValues["SEGUIMIENTO_CRONOGRAMA"].ToString().Length == 0 ? "null" : e.NewValues["SEGUIMIENTO_CRONOGRAMA"].ToString());

            if (e.NewValues["AVANCE"] == null)
                pAvance = "";
            else
                pAvance = (e.NewValues["AVANCE"].ToString().Length == 0 ? "null" : e.NewValues["AVANCE"].ToString());

            string Id = e.Keys["IDCONTRATOSEGUIMIENTO"].ToString();
            string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();

            string[] parameters = { IdContrato, pValorizaconFecha, pValorizacionNumero, pAvance };
            string LvCadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.UpdatedRowContratoSeguimiento(parameters, Id);
            GridProyectoSupervision.CancelEdit();
            e.Cancel = true;
            this.SearchByContratoSupervision();
        }
        #endregion
        #region OnRowDeletingContratoSupervision
        protected void OnRowDeletingContratoSupervision(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string Id = e.Keys["IDCONTRATOSEGUIMIENTO"].ToString();
            string Cadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.DeletedRowContratoSeguimiento(Id);
            GridProyectoSupervision.CancelEdit();
            e.Cancel = true;
            this.SearchByContratoSupervision();
        }
        #endregion
        protected void GridProyectoSupervision_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            foreach (GridViewColumn column in GridProyectoSupervision.Columns)
            {
                GridViewDataColumn dataColumn = column as GridViewDataColumn;
                if (dataColumn == null) continue;
                if (e.NewValues[dataColumn.FieldName] == null && dataColumn.FieldName != "SEGUIMIENTO_CRONOGRAMA")
                {
                    e.Errors[dataColumn] = "Valores no pueden ser nulos.";
                }
            }
            if (e.Errors.Count > 0) e.RowError = "Por favor, llenar todos los campos...";
            if (e.NewValues["SEGUIMIENTO_FECHA"] != null && e.NewValues["SEGUIMIENTO_FECHA"].ToString().Length < 10)
            {
                AddError(e.Errors, GridProyectoSupervision.Columns["SEGUIMIENTO_FECHA"], "Registrar correctamente la Fecha del cronograma.");
            }
            decimal Avance = e.NewValues["AVANCE"] != null ? Convert.ToDecimal(e.NewValues["AVANCE"]) : 0;
            if (Avance == 0)
            {
                AddError(e.Errors, GridProyectoProgramacion.Columns["AVANCE"], "Avance, debe ser > 0.");
            }
            if (Convert.ToDecimal(e.NewValues["AVANCE"]) > 100)
            {
                AddError(e.Errors, GridProyectoProgramacion.Columns["AVANCE"], "Avance, No puede ser mayor al 100%.");
            }
            if (string.IsNullOrEmpty(e.RowError) && e.Errors.Count > 0) e.RowError = "Por favor, corregir los errores.";
        }
        protected void GridProyectoSupervision_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            if (!object.Equals(e.RowType, GridViewRowType.Data)) return;

            bool hasError = string.IsNullOrEmpty(e.GetValue("SEGUIMIENTO_FECHA").ToString());
            hasError = hasError || e.GetValue("AVANCE").ToString() == "0";
            if (hasError)
            {
                e.Row.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void GridProyectoSupervision_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            GridProyectoSupervision.DoRowValidation();
        }
        #region ContratoValorizacion

        #region OnLoadContratoValorizacion
        protected void OnLoadContratoValorizacion(object sender, EventArgs e)
        {
            this.SearchByContratoValorizacion();
        }
        #endregion
        #region SearchByContratoValorizacion
        private void SearchByContratoValorizacion()
        {

            string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();
            DataSet ds3 = new DataSet();
            ds3 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoValorizacion((string)(Session["pIdProyecto"]), IdContrato);
            GridProyectoValorizacion.KeyFieldName = "IDCONTRATOVALORIZACION";
            GridProyectoValorizacion.DataSource = ds3.Tables[0];
            GridProyectoValorizacion.DataBind();
        }
        #endregion
        #region OnRowInsertingContratoValorizacion
        protected void OnRowInsertingContratoValorizacion(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {

            string pValorizaconFecha, pValorizacionNumero, pValorizacionImporte, pAvance;

            if (e.NewValues["VALORIZACION_FECHA"] == null)
                pValorizaconFecha = "";
            else
                pValorizaconFecha = (e.NewValues["VALORIZACION_FECHA"].ToString().Length == 0 ? "null" : e.NewValues["VALORIZACION_FECHA"].ToString());

            if (e.NewValues["VALORIZACION_NUMERO"] == null)
                pValorizacionNumero = "";
            else
                pValorizacionNumero = (e.NewValues["VALORIZACION_NUMERO"].ToString().Length == 0 ? "null" : e.NewValues["VALORIZACION_NUMERO"].ToString());

            if (e.NewValues["AVANCE"] == null)
                pAvance = "";
            else
                pAvance = (e.NewValues["AVANCE"].ToString().Length == 0 ? "null" : e.NewValues["AVANCE"].ToString());

            if (e.NewValues["VALORIZACION_IMPORTE"] == null)
                pValorizacionImporte = "";
            else
                pValorizacionImporte = (e.NewValues["VALORIZACION_IMPORTE"].ToString().Length == 0 ? "null" : e.NewValues["VALORIZACION_IMPORTE"].ToString());



            string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();

            string[] parameters = { IdContrato, pValorizaconFecha, pValorizacionNumero, pValorizacionImporte, pAvance };
            string LvCadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.InsertRowContratoValorizacion(parameters);
            GridProyectoValorizacion.CancelEdit();
            e.Cancel = true;
            this.SearchByContratoValorizacion();
        }
        #endregion
        #region OnRowUpdatingContratoValorizacion
        protected void OnRowUpdatingContratoValorizacion(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {

            string pValorizaconFecha, pValorizacionNumero, pValorizacionImporte, pAvance;

            if (e.NewValues["VALORIZACION_FECHA"] == null)
                pValorizaconFecha = "";
            else
                pValorizaconFecha = (e.NewValues["VALORIZACION_FECHA"].ToString().Length == 0 ? "null" : e.NewValues["VALORIZACION_FECHA"].ToString());

            if (e.NewValues["VALORIZACION_NUMERO"] == null)
                pValorizacionNumero = "";
            else
                pValorizacionNumero = (e.NewValues["VALORIZACION_NUMERO"].ToString().Length == 0 ? "null" : e.NewValues["VALORIZACION_NUMERO"].ToString());

            if (e.NewValues["AVANCE"] == null)
                pAvance = "";
            else
                pAvance = (e.NewValues["AVANCE"].ToString().Length == 0 ? "null" : e.NewValues["AVANCE"].ToString());

            if (e.NewValues["VALORIZACION_IMPORTE"] == null)
                pValorizacionImporte = "";
            else
                pValorizacionImporte = (e.NewValues["VALORIZACION_IMPORTE"].ToString().Length == 0 ? "null" : e.NewValues["VALORIZACION_IMPORTE"].ToString());


            string Id = e.Keys["IDCONTRATOVALORIZACION"].ToString();
            string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();

            string[] parameters = { IdContrato, pValorizaconFecha, pValorizacionNumero, pValorizacionImporte, pAvance };
            string LvCadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.UpdatedRowContratoValorizacion(parameters, Id);
            GridProyectoValorizacion.CancelEdit();
            e.Cancel = true;
            this.SearchByContratoValorizacion();
        }
        #endregion
        #region OnRowDeletingContratoValorizacion
        protected void OnRowDeletingContratoValorizacion(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string Id = e.Keys["IDCONTRATOVALORIZACION"].ToString();
            string Cadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.DeletedRowContratoValorizacion(Id);
            GridProyectoValorizacion.CancelEdit();
            e.Cancel = true;
            this.SearchByContratoValorizacion();
        }
        #endregion
        protected void GridProyectoValorizacion_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            foreach (GridViewColumn column in GridProyectoValorizacion.Columns)
            {
                GridViewDataColumn dataColumn = column as GridViewDataColumn;
                if (dataColumn == null) continue;
                if (e.NewValues[dataColumn.FieldName] == null && dataColumn.FieldName != "VALORIZACION_NUMERO")
                {
                    e.Errors[dataColumn] = "Valores no pueden ser nulos.";
                }
            }
            if (e.Errors.Count > 0) e.RowError = "Por favor, llenar todos los campos...";
            if (e.NewValues["VALORIZACION_FECHA"] != null && e.NewValues["VALORIZACION_FECHA"].ToString().Length < 10)
            {
                AddError(e.Errors, GridProyectoValorizacion.Columns["VALORIZACION_FECHA"], "Registrar correctamente la Fecha del cronograma.");
            }
            decimal Avance = e.NewValues["VALORIZACION_IMPORTE"] != null ? Convert.ToDecimal(e.NewValues["VALORIZACION_IMPORTE"]) : 0;
            if (Avance == 0)
            {
                AddError(e.Errors, GridProyectoValorizacion.Columns["VALORIZACION_IMPORTE"], "Avance, debe ser > 0.");
            }
            if (string.IsNullOrEmpty(e.RowError) && e.Errors.Count > 0) e.RowError = "Por favor, corregir los errores.";
        }
        protected void GridProyectoValorizacion_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            if (!object.Equals(e.RowType, GridViewRowType.Data)) return;

            bool hasError = string.IsNullOrEmpty(e.GetValue("VALORIZACION_FECHA").ToString());
            hasError = hasError || e.GetValue("VALORIZACION_IMPORTE").ToString() == "0";
            if (hasError)
            {
                e.Row.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void GridProyectoValorizacion_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            GridProyectoValorizacion.DoRowValidation();
        }
        #endregion
        #region OnLoadContratoAdelanto
        protected void OnLoadContratoAdelanto(object sender, EventArgs e)
        {
            this.SearchByContratoAdelanto();
        }
        #endregion
        #region SearchByContratoAdelanto
        private void SearchByContratoAdelanto()
        {
            string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();

            DataSet ds3 = new DataSet();
            ds3 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoAdelanto((string)(Session["pIdProyecto"]), IdContrato);
            GridProyectoAdelanto.KeyFieldName = "IDCONTRATOADELANTO";
            GridProyectoAdelanto.DataSource = ds3.Tables[0];
            GridProyectoAdelanto.DataBind();
        }
        #endregion
        #region OnRowInsertingContratoAdelanto
        protected void OnRowInsertingContratoAdelanto(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {

            string pValorizaconFecha, pAdelantoNumero, pAdelantoImporte, pAvance;

            if (e.NewValues["ADELANTO_FECHA"] == null)
                pValorizaconFecha = "";
            else
                pValorizaconFecha = (e.NewValues["ADELANTO_FECHA"].ToString().Length == 0 ? "null" : e.NewValues["ADELANTO_FECHA"].ToString());

            if (e.NewValues["ADELANTO_NUMERO"] == null)
                pAdelantoNumero = "";
            else
                pAdelantoNumero = (e.NewValues["ADELANTO_NUMERO"].ToString().Length == 0 ? "null" : e.NewValues["ADELANTO_NUMERO"].ToString());

            if (e.NewValues["TIPO_ADELANTO"] == null)
                pAvance = "";
            else
                pAvance = (e.NewValues["TIPO_ADELANTO"].ToString().Length == 0 ? "null" : e.NewValues["TIPO_ADELANTO"].ToString().ToUpper());

            if (e.NewValues["ADELANTO_IMPORTE"] == null)
                pAdelantoImporte = "";
            else
                pAdelantoImporte = (e.NewValues["ADELANTO_IMPORTE"].ToString().Length == 0 ? "null" : e.NewValues["ADELANTO_IMPORTE"].ToString());



            string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();

            string[] parameters = { IdContrato, pValorizaconFecha, pAdelantoNumero, pAdelantoImporte, pAvance };
            string LvCadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.InsertRowContratoAdelanto(parameters);
            GridProyectoAdelanto.CancelEdit();
            e.Cancel = true;
            this.SearchByContratoAdelanto();
        }
        #endregion
        #region OnRowUpdatingContratoAdelanto
        protected void OnRowUpdatingContratoAdelanto(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {

            string pValorizaconFecha, pAdelantoNumero, pAdelantoImporte, pAvance;

            if (e.NewValues["ADELANTO_FECHA"] == null)
                pValorizaconFecha = "";
            else
                pValorizaconFecha = (e.NewValues["ADELANTO_FECHA"].ToString().Length == 0 ? "null" : e.NewValues["ADELANTO_FECHA"].ToString());

            if (e.NewValues["ADELANTO_NUMERO"] == null)
                pAdelantoNumero = "";
            else
                pAdelantoNumero = (e.NewValues["ADELANTO_NUMERO"].ToString().Length == 0 ? "null" : e.NewValues["ADELANTO_NUMERO"].ToString());

            if (e.NewValues["TIPO_ADELANTO"] == null)
                pAvance = "";
            else
                pAvance = (e.NewValues["TIPO_ADELANTO"].ToString().Length == 0 ? "null" : e.NewValues["TIPO_ADELANTO"].ToString().ToUpper());

            if (e.NewValues["ADELANTO_IMPORTE"] == null)
                pAdelantoImporte = "";
            else
                pAdelantoImporte = (e.NewValues["ADELANTO_IMPORTE"].ToString().Length == 0 ? "null" : e.NewValues["ADELANTO_IMPORTE"].ToString());


            string Id = e.Keys["IDCONTRATOADELANTO"].ToString();
            string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();

            string[] parameters = { IdContrato, pValorizaconFecha, pAdelantoNumero, pAdelantoImporte, pAvance };
            string LvCadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.UpdatedRowContratoAdelanto(parameters, Id);
            GridProyectoAdelanto.CancelEdit();
            e.Cancel = true;
            this.SearchByContratoAdelanto();
        }
        #endregion
        #region OnRowDeletingContratoAdelanto
        protected void OnRowDeletingContratoAdelanto(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string Id = e.Keys["IDCONTRATOADELANTO"].ToString();
            string Cadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.DeletedRowContratoAdelanto(Id);
            GridProyectoAdelanto.CancelEdit();
            e.Cancel = true;
            this.SearchByContratoAdelanto();
        }
        #endregion
        protected void GridProyectoAdelanto_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            foreach (GridViewColumn column in GridProyectoAdelanto.Columns)
            {
                GridViewDataColumn dataColumn = column as GridViewDataColumn;
                if (dataColumn == null) continue;
                if (e.NewValues[dataColumn.FieldName] == null && dataColumn.FieldName != "ADELANTO_NUMERO")
                {
                    e.Errors[dataColumn] = "Valores no pueden ser nulos.";
                }
            }
            if (e.Errors.Count > 0) e.RowError = "Por favor, llenar todos los campos...";
            if (e.NewValues["ADELANTO_FECHA"] != null && e.NewValues["ADELANTO_FECHA"].ToString().Length < 10)
            {
                AddError(e.Errors, GridProyectoAdelanto.Columns["ADELANTO_FECHA"], "Registrar correctamente la Fecha del cronograma.");
            }
            decimal Avance = e.NewValues["ADELANTO_IMPORTE"] != null ? Convert.ToDecimal(e.NewValues["ADELANTO_IMPORTE"]) : 0;
            if (Avance == 0)
            {
                AddError(e.Errors, GridProyectoAdelanto.Columns["ADELANTO_IMPORTE"], "Avance, debe ser > 0.");
            }
            if (e.NewValues["TIPO_ADELANTO"] == null)
                AddError(e.Errors, GridProyectoAdelanto.Columns["TIPO_ADELANTO"], "El Tipo de Adelanto no puede ser nulo...");
            else
                if (!e.NewValues["TIPO_ADELANTO"].ToString().ToUpper().Contains("A") && !e.NewValues["TIPO_ADELANTO"].ToString().ToUpper().Contains("M"))
            {
                AddError(e.Errors, GridProyectoAdelanto.Columns["TIPO_ADELANTO"], "Registro invalido. A=ADELANTO O M=MATERIALES");
            }
            if (string.IsNullOrEmpty(e.RowError) && e.Errors.Count > 0) e.RowError = "Por favor, corregir los errores.";
        }
        protected void GridProyectoAdelanto_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            if (!object.Equals(e.RowType, GridViewRowType.Data)) return;

            bool hasError = string.IsNullOrEmpty(e.GetValue("ADELANTO_FECHA").ToString());
            hasError = hasError || string.IsNullOrEmpty(e.GetValue("TIPO_ADELANTO").ToString());
            hasError = hasError || e.GetValue("ADELANTO_FECHA").ToString() == "0";
            if (hasError)
            {
                e.Row.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void GridProyectoAdelanto_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            GridProyectoAdelanto.DoRowValidation();
        }
        protected void GridProyectoProgramacion_CellEditorInitialize(object sender,
            DevExpress.Web.ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName == "CRONOGRAMA")
            {
                e.Editor.Visible = false;
                e.Editor.ReadOnly = true;
            }
        }

    }
}