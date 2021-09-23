using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using System.Data;


using DevExpress.XtraReports.UI;
using DevExpress.Utils;
using System.Drawing;
using DevExpress.XtraPrinting;
using DevExpress.Export;
using DevExpress.CodeParser;

namespace InfogesEmape.Modules.Forms.Seguimiento
{
    public partial class frmInfoGesGsoProyectoRegistroCoordinador : System.Web.UI.Page
    {
        private string pIdOPeracion;
        private string pIdProyecto;
		private Int32 pnContrato = 0;

        public ExportType ExportType { get; private set; }


        #region PageInit
        protected void Page_Init(object sender, EventArgs e)
        {
			if (Session["baseURL"] == null)
				Session["baseURL"] = "frmInfoGesGsoProyectoRegistroPolinomica.aspx";
		}
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InfogesEmape.Modules.MasterPage m = (InfogesEmape.Modules.MasterPage)Page.Master;
            pIdOPeracion = "" + Request.Params["pOpera"];
            pIdProyecto = "" + Request.Params["pId"];
            Session["pIdProyecto"] = pIdProyecto;
            Session["pEjecucion_"] = "1";
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

            //ASPxGridView GridContratoValorizacionDet = (ASPxGridView)sender;
            //GridContratoValorizacionDet.SettingsDetail.ExportMode = GridViewDetailExportMode.All;

            //GridContratoValorizacionDet.ExpandAll();
            GridProyectoContratoCon.ExpandAll();
            //GridProyectoContratoCon.SettingsBehavior.AutoExpandAllGroups = true;
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.Button1);
            scriptManager.RegisterPostBackControl(this.Button2);
            scriptManager.RegisterPostBackControl(this.Button3);			
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

                    Session["ROLE"] = ds2.Tables[0].Rows[0]["ROLE_ID"];


                    if (Session["ROLE"].ToString() == "9") {

                        LBLHIPER.Text = "";
                    }

                    if (Convert.ToBoolean(ds2.Tables[0].Rows[0]["CIERRE"]) ? true : false)
                    {
                        GridProyectoProgramacion.SettingsDataSecurity.AllowInsert = false;
                        GridProyectoProgramacion.SettingsDataSecurity.AllowEdit = false;
                        GridProyectoProgramacion.SettingsDataSecurity.AllowDelete = false;

						GridProyectoContratoSup.SettingsDataSecurity.AllowInsert = false;
						GridProyectoContratoSup.SettingsDataSecurity.AllowEdit = false;
						GridProyectoContratoSup.SettingsDataSecurity.AllowDelete = false;

						GridProyectoContratoCon.SettingsDataSecurity.AllowInsert = false;
						GridProyectoContratoCon.SettingsDataSecurity.AllowEdit = false;
						GridProyectoContratoCon.SettingsDataSecurity.AllowDelete = false;

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
						if (Convert.ToString(ds2.Tables[0].Rows[0]["ROLE_ID"]) == "8")
						{

                            //Button1.Style.Add("display", "none");
                            //ButtonAssociateRules.Style.Add("display", "none");
                            GridProyectoProgramacion.SettingsDataSecurity.AllowInsert = false;
							GridProyectoProgramacion.SettingsDataSecurity.AllowEdit = false;
							GridProyectoProgramacion.SettingsDataSecurity.AllowDelete = false;

							GridProyectoContratoSup.SettingsDataSecurity.AllowInsert = Convert.ToBoolean(ds2.Tables[0].Rows[0]["INSERTAR"]) ? true : false;
							GridProyectoContratoSup.SettingsDataSecurity.AllowEdit = Convert.ToBoolean(ds2.Tables[0].Rows[0]["ACTUALIZAR"]) ? true : false;
							GridProyectoContratoSup.SettingsDataSecurity.AllowDelete = Convert.ToBoolean(ds2.Tables[0].Rows[0]["ELIMINAR"]) ? true : false;

							GridProyectoContratoCon.SettingsDataSecurity.AllowInsert = false;
							GridProyectoContratoCon.SettingsDataSecurity.AllowEdit = Convert.ToBoolean(ds2.Tables[0].Rows[0]["ACTUALIZAR"]) ? true : false;
							GridProyectoContratoCon.SettingsDataSecurity.AllowDelete = Convert.ToBoolean(ds2.Tables[0].Rows[0]["ELIMINAR"]) ? true : false;

                            GridProyectoContratoSup.SettingsDataSecurity.AllowInsert = false;
                            GridProyectoContratoSup.SettingsDataSecurity.AllowEdit = false;
                            GridProyectoContratoSup.SettingsDataSecurity.AllowDelete = false;

                            GridProyectoSupervision.SettingsDataSecurity.AllowInsert = false;
							GridProyectoSupervision.SettingsDataSecurity.AllowEdit = false;
							GridProyectoSupervision.SettingsDataSecurity.AllowDelete = false;

							GridProyectoValorizacion.SettingsDataSecurity.AllowInsert = false;
							GridProyectoValorizacion.SettingsDataSecurity.AllowEdit = false;
							GridProyectoValorizacion.SettingsDataSecurity.AllowDelete = false;

							GridProyectoAdelanto.SettingsDataSecurity.AllowInsert = false;
							GridProyectoAdelanto.SettingsDataSecurity.AllowEdit = false;
							GridProyectoAdelanto.SettingsDataSecurity.AllowDelete = false;

							this.GridProyectoProgramacion.Columns["myCommandColumn"].Visible = false;
							this.GridProyectoSupervision.Columns["myCommandColumn"].Visible = false;
							this.GridProyectoAdelanto.Columns["myCommandColumn"].Visible = false;
							//this.GridProyectoContratoCon.Columns["APROBADO"].Visible = true;

							this.GridProyectoContratoSup.Visible = true;
							this.GridProyectoSupervision.Visible = false;
							this.GridProyectoValorizacion.Visible = false;
							this.GridProyectoAdelanto.Visible = false;

						}
						else if (Convert.ToString(ds2.Tables[0].Rows[0]["ROLE_ID"]) == "9") {

                            Button3.Style.Add("display", "none");
                            //ButtonAssociateRules.Style.Add("display", "none");

                            GridProyectoProgramacion.SettingsDataSecurity.AllowInsert = false;
							GridProyectoProgramacion.SettingsDataSecurity.AllowEdit = false;
							GridProyectoProgramacion.SettingsDataSecurity.AllowDelete = false;

							GridProyectoContratoSup.SettingsDataSecurity.AllowInsert = false;
							GridProyectoContratoSup.SettingsDataSecurity.AllowEdit = false;
							GridProyectoContratoSup.SettingsDataSecurity.AllowDelete = false;

							GridProyectoContratoCon.SettingsDataSecurity.AllowInsert = Convert.ToBoolean(ds2.Tables[0].Rows[0]["INSERTAR"]) ? true : false;
							GridProyectoContratoCon.SettingsDataSecurity.AllowEdit = Convert.ToBoolean(ds2.Tables[0].Rows[0]["ACTUALIZAR"]) ? true : false;
							GridProyectoContratoCon.SettingsDataSecurity.AllowDelete = Convert.ToBoolean(ds2.Tables[0].Rows[0]["ELIMINAR"]) ? true : false;

							GridProyectoSupervision.SettingsDataSecurity.AllowInsert = false;
							GridProyectoSupervision.SettingsDataSecurity.AllowEdit = false;
							GridProyectoSupervision.SettingsDataSecurity.AllowDelete = false;

							GridProyectoValorizacion.SettingsDataSecurity.AllowInsert = false;
							GridProyectoValorizacion.SettingsDataSecurity.AllowEdit = false;
							GridProyectoValorizacion.SettingsDataSecurity.AllowDelete = false;

							GridProyectoAdelanto.SettingsDataSecurity.AllowInsert = false;
							GridProyectoAdelanto.SettingsDataSecurity.AllowEdit = false;
							GridProyectoAdelanto.SettingsDataSecurity.AllowDelete = false;						

							this.GridProyectoProgramacion.Columns["myCommandColumn"].Visible = false;
							this.GridProyectoProgramacion.Columns["myCommandColumn"].Visible = false;
							//this.GridProyectoContratoSup.Columns["myCommandColumn"].Visible = false;
							this.GridProyectoSupervision.Columns["myCommandColumn"].Visible = false;
							this.GridProyectoAdelanto.Columns["myCommandColumn"].Visible = false;
							this.GridProyectoContratoCon.Columns["APROBADO"].Visible = false;
							
							this.GridProyectoContratoSup.Visible = false;
							this.GridProyectoSupervision.Visible = false;
							this.GridProyectoValorizacion.Visible = false;
							this.GridProyectoAdelanto.Visible = false;                         

                        }
                        else {
							GridProyectoProgramacion.SettingsDataSecurity.AllowInsert = Convert.ToBoolean(ds2.Tables[0].Rows[0]["INSERTAR"]) ? true : false;
							GridProyectoProgramacion.SettingsDataSecurity.AllowEdit = Convert.ToBoolean(ds2.Tables[0].Rows[0]["ACTUALIZAR"]) ? true : false;
							GridProyectoProgramacion.SettingsDataSecurity.AllowDelete = Convert.ToBoolean(ds2.Tables[0].Rows[0]["ELIMINAR"]) ? true : false;

							GridProyectoContratoSup.SettingsDataSecurity.AllowInsert = Convert.ToBoolean(ds2.Tables[0].Rows[0]["INSERTAR"]) ? true : false;
							GridProyectoContratoSup.SettingsDataSecurity.AllowEdit = Convert.ToBoolean(ds2.Tables[0].Rows[0]["ACTUALIZAR"]) ? true : false;
							GridProyectoContratoSup.SettingsDataSecurity.AllowDelete = Convert.ToBoolean(ds2.Tables[0].Rows[0]["ELIMINAR"]) ? true : false;

							GridProyectoContratoCon.SettingsDataSecurity.AllowInsert = Convert.ToBoolean(ds2.Tables[0].Rows[0]["INSERTAR"]) ? true : false;
							GridProyectoContratoCon.SettingsDataSecurity.AllowEdit = Convert.ToBoolean(ds2.Tables[0].Rows[0]["ACTUALIZAR"]) ? true : false;
							GridProyectoContratoCon.SettingsDataSecurity.AllowDelete = Convert.ToBoolean(ds2.Tables[0].Rows[0]["ELIMINAR"]) ? true : false;

							GridProyectoValorizacion.SettingsDataSecurity.AllowInsert = Convert.ToBoolean(ds2.Tables[0].Rows[0]["INSERTAR"]) ? true : false;
							GridProyectoValorizacion.SettingsDataSecurity.AllowEdit = Convert.ToBoolean(ds2.Tables[0].Rows[0]["ACTUALIZAR"]) ? true : false;
							GridProyectoValorizacion.SettingsDataSecurity.AllowDelete = Convert.ToBoolean(ds2.Tables[0].Rows[0]["ELIMINAR"]) ? true : false;

							GridProyectoAdelanto.SettingsDataSecurity.AllowInsert = Convert.ToBoolean(ds2.Tables[0].Rows[0]["INSERTAR"]) ? true : false;
							GridProyectoAdelanto.SettingsDataSecurity.AllowEdit = Convert.ToBoolean(ds2.Tables[0].Rows[0]["ACTUALIZAR"]) ? true : false;
							GridProyectoAdelanto.SettingsDataSecurity.AllowDelete = Convert.ToBoolean(ds2.Tables[0].Rows[0]["ELIMINAR"]) ? true : false;
						}						
                    }                    


                    this.GridProyectoContrato.Visible = true;
                    this.GridProyectoProgramacion.Visible = true;
					this.GridProyectoContratoSup.Visible = false;
					//this.GridProyectoSupervision.Visible = true;
					//this.GridProyectoValorizacion.Visible = false;
					//this.GridProyectoAdelanto.Visible = true;
					//this.GridProyectoContratoSup.Visible = true;
					this.GridProyectoContratoCon.Visible = true;
					
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
					this.GridProyectoContratoSup.Visible = true;
					this.GridProyectoContratoCon.Visible = false;

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

        #region ProyectoContrato

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

        #endregion

        #region ContratoProgramacion

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
                if (e.NewValues[dataColumn.FieldName] == null && dataColumn.FieldName!="CRONOGRAMA" && dataColumn.FieldName != "MONTO_OBRA")
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

        #endregion

        #region ContratoSupervision

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


        #endregion

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

        #region ContratoAdelanto

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

		#endregion



		/*private void ContratoValorizacionDet_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			GridView view = sender as GridView;
			// rowHandle the meaning acquired in the cell being edited positioning the first few lines, understood as the Y-coordinate            
			int rowIndex = e.RowHandle;
			// Get the edited cell in the first few columns, understood as the X coordinate
			int columnindex = e.Column.AbsoluteIndex;
			// Get the field name to bind to the cell
			string changeFiled = e.Column.FieldName;
			// get a cell header to be edited
			string caption = e.Column.Caption;
			// Get the value of the new input
			string newValue = e.Value.ToString();
			// Then there is the business logic ...  

			e.Column.ACUMULADO = "1";
		}*/



		#region ContratoValorizacionDet
		/*CAMBIO						FECHA			AUTOR
		SELECT	CONTRATO VALORIZACION	22-06-2021	    ALEXANDER FERNÁNDEZ 22-06-2021*/
		#region OnloadContratoValorizacion
		protected void OnloadContratoValorizacionDet(object sender, EventArgs e)
		{
			//this.SearchByContratoValorizacionDet();
			DataSet ds4 = new DataSet();
			string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();
			//string IdValorizacion = GridProyectoContratoCon.GetRowValues(GridProyectoContratoCon.FocusedRowIndex, "IDCONTRATOSEGUIMIENTO").ToString();
			//txtMensaje.Text = "1";
			//MessageBox.Show('hola');
			ASPxGridView detailGrid = (ASPxGridView)sender;
			int IdValorizacion = (int)detailGrid.GetMasterRowKeyValue();

			ds4 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByContratoValorizacionDet((string)(Session["pIdProyecto"]), IdContrato, IdValorizacion,1);

			ASPxGridView GridContratoValorizacionDet = (ASPxGridView)sender;			

			GridContratoValorizacionDet.KeyFieldName = "IDCONTRATOVALORIZACIONDET";
			GridContratoValorizacionDet.DataSource = ds4.Tables[0];
			GridContratoValorizacionDet.DataBind();
			
			
		}
        #endregion

        #region
        protected void detailGrid_CustomUnboundColumnData(object sender, ASPxGridViewColumnDataEventArgs e)
        {            
            DataSet ds4 = new DataSet();

            ASPxGridView detailGrid = (ASPxGridView)sender;
            int IdValorizacion = (int)detailGrid.GetMasterRowKeyValue();

            string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();
            ds4 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoCon((string)(Session["pIdProyecto"]), IdContrato, IdValorizacion.ToString());

            decimal aprobado = Convert.ToDecimal(ds4.Tables[0].Rows[0]["APROBADO"].ToString());            

            ASPxGridView GridContratoValorizacionDet = (ASPxGridView)sender;
           
            //GridViewFormatConditionHighlight Rule = new GridViewFormatConditionHighlight();
            //Rule.FieldName = "CANTIDAD";
            //Rule.Expression = "[CANTIDAD] > 0";
            //Rule.Format = GridConditionHighlightFormat.GreenFillWithDarkGreenText;
            //GridContratoValorizacionDet.FormatConditions.Add(Rule);

            if (Convert.ToString(Session["ROLE"]) == "8")
			{
				//GridContratoValorizacionDet.DataColumns["CANTIDADSUP"].EditFormSettings.Visible = DefaultBoolean.False;
				GridContratoValorizacionDet.DataColumns["CANTIDAD"].EditFormSettings.Visible = DefaultBoolean.False;
				//GridContratoValorizacionDet.Columns["CANTIDADSUP"].Visible = false;
				//GridContratoValorizacionDet.Columns["CANTIDADCON"].Visible = false;
			} else if (Convert.ToString(Session["ROLE"]) == "9")
			{
				//GridContratoValorizacionDet.DataColumns["CANTIDADSUP"].EditFormSettings.Visible = DefaultBoolean.False;
				//GridContratoValorizacionDet.DataColumns["CANTIDADCON"].EditFormSettings.Visible = DefaultBoolean.False;
				GridContratoValorizacionDet.Columns["CANTIDADSUP"].Visible = false;
				GridContratoValorizacionDet.Columns["CANTIDADCON"].Visible = false;
				GridContratoValorizacionDet.Columns["ACUMULADO"].Visible = true;
				GridContratoValorizacionDet.Columns["ACUMULADO_TOTAL"].Visible = true;

				//args.Column.OptionsColumn.ReadOnly = true;
				//dataTable.Columns[args.Column.FieldName].ReadOnly = true;
				GridContratoValorizacionDet.DataColumns["APROBADO"].ReadOnly = true;
			}

			//if (aprobado == 1 ) {              
                //GridContratoValorizacionDet.DataColumns["CANTIDAD"].EditFormSettings.Visible = DefaultBoolean.False;
            //}

            //ds5 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoCon((string)(Session["pIdProyecto"]), IdContrato);

            //GridContratoValorizacionDet.Columns["SALDO_OLD"].Visible = false;
            GridContratoValorizacionDet.SettingsBehavior.AutoExpandAllGroups = true;

			//GridContratoValorizacionDet.EditFormLayoutProperties.vi
			//GridContratoValorizacionDet.Columns["CANTIDAD"].Visible = false;                        

			//PRESUPUESTO
			if (e.Column.FieldName == "PRESUPUESTO_PARCIAL")
			{
				decimal price = (decimal)e.GetListSourceFieldValue("PRECIO");
				decimal cantidadTotal = Convert.ToDecimal(e.GetListSourceFieldValue("CANTIDADTOTAL"));
				e.Value = (price * cantidadTotal).ToString("n2");
			}

			//ACUMULADO ANTERIOR
			if (e.Column.FieldName == "ACUMULADO_ANTERIOR_PARCIAL")
			{
				decimal price = (decimal)e.GetListSourceFieldValue("PRECIO");
				decimal cantidad = Convert.ToDecimal(e.GetListSourceFieldValue("ACUMULADO"));
				e.Value = (price * cantidad).ToString("n2");
			}

			if (e.Column.FieldName == "ACUMULADO_ANTERIOR_PORCENTAJE")
			{
				decimal acmulado = (decimal)e.GetListSourceFieldValue("ACUMULADO");
				decimal cantidadTotal = Convert.ToDecimal(e.GetListSourceFieldValue("CANTIDADTOTAL"));

                if (cantidadTotal > 0)
                    e.Value = ((acmulado / cantidadTotal) * 100).ToString("n2");
                else
                    e.Value = 0;
            }


			if (e.Column.FieldName == "TOTAL")
			{				
				decimal price = (decimal)e.GetListSourceFieldValue("PRECIO");
				decimal cantidad = Convert.ToDecimal(e.GetListSourceFieldValue("CANTIDAD"));
				e.Value = (price * cantidad).ToString("n2");								
			}

			//ACUMULADO TOTAL
            if (e.Column.FieldName == "ACUMULADO_TOTAL")
            {				
				decimal acumuladoTotal = (decimal)e.GetListSourceFieldValue("ACUMULADO");
                decimal cantidad = Convert.ToDecimal(e.GetListSourceFieldValue("CANTIDAD"));
                e.Value = (acumuladoTotal + cantidad).ToString("n2");
            }

			if (e.Column.FieldName == "ACUMULADO_TOTAL_PARCIAL")
			{
				decimal acumuladoTotal = (decimal)e.GetListSourceFieldValue("ACUMULADO");
				decimal cantidad = Convert.ToDecimal(e.GetListSourceFieldValue("CANTIDAD"));				
				decimal price = (decimal)e.GetListSourceFieldValue("PRECIO");
				e.Value = ((acumuladoTotal + cantidad)* price).ToString("n2");
			}

			if (e.Column.FieldName == "ACUMULADO_TOTALPRECIO")
            {
                //e.NewValues["SEGUIMIENTO_CRONOGRAMA"].ToString().Length == 0 ? "null" : e.NewValues["SEGUIMIENTO_CRONOGRAMA"].ToString()
                string acumulado = (e.GetListSourceFieldValue("ACUMULADO").ToString().Length == 0 ? "0" : e.GetListSourceFieldValue("ACUMULADO").ToString());

                decimal price = (decimal)e.GetListSourceFieldValue("PRECIO");
                decimal acumulado1 = Convert.ToDecimal(acumulado);
                decimal cantidad = Convert.ToDecimal(e.GetListSourceFieldValue("CANTIDAD"));
                e.Value = ((acumulado1 + cantidad)* price).ToString("n2");
            }

			//SALDOS
			if (e.Column.FieldName == "SALDO_POR_EJECUTAR")
			{
				decimal acumuladoTotal = (decimal)e.GetListSourceFieldValue("ACUMULADO");
				decimal cantidad = Convert.ToDecimal(e.GetListSourceFieldValue("CANTIDAD"));
				decimal cantidadTotal = Convert.ToDecimal(e.GetListSourceFieldValue("CANTIDADTOTAL"));				

				e.Value = (cantidadTotal - (acumuladoTotal + cantidad)).ToString("n2");				
			}			
			if (e.Column.FieldName == "SALDO_POR_EJECUTAR_VALORIZADO")
			{
				decimal acumuladoTotal = (decimal)e.GetListSourceFieldValue("ACUMULADO");
				decimal cantidad = Convert.ToDecimal(e.GetListSourceFieldValue("CANTIDAD"));
				decimal cantidadTotal = Convert.ToDecimal(e.GetListSourceFieldValue("CANTIDADTOTAL"));
				decimal price = (decimal)e.GetListSourceFieldValue("PRECIO");

				e.Value = ((cantidadTotal - (acumuladoTotal + cantidad))*price).ToString("n2");
			}

			if (e.Column.FieldName == "ACUMULADO_TOTALPRESUPUESTO")
            {
                decimal price = (decimal)e.GetListSourceFieldValue("PRECIO");
                decimal cantidad = Convert.ToDecimal(e.GetListSourceFieldValue("CANTIDADTOTAL"));
                e.Value = (price * cantidad).ToString("n2");
            }

            if (e.Column.FieldName == "SALDOACUMULADO")
            {
                //e.NewValues["SEGUIMIENTO_CRONOGRAMA"].ToString().Length == 0 ? "null" : e.NewValues["SEGUIMIENTO_CRONOGRAMA"].ToString()
                string acumulado = (e.GetListSourceFieldValue("ACUMULADO").ToString().Length == 0 ? "0" : e.GetListSourceFieldValue("ACUMULADO").ToString());

                decimal acumulado1 = Convert.ToDecimal(acumulado);
                decimal cantidad = Convert.ToDecimal(e.GetListSourceFieldValue("CANTIDAD"));
                decimal cantidadtotal = Convert.ToDecimal(e.GetListSourceFieldValue("CANTIDADTOTAL"));
                if (cantidadtotal > 0)
                    e.Value = (((acumulado1 + cantidad) / cantidadtotal) * 100).ToString("n2");
                else
                    e.Value = 0;                
            }
        }
		#endregion
		#endregion

		#region OnloadProyectoContratoSup
		/*CAMBIO						FECHA			AUTOR
		SELECT	AVANCE DE SUPERVISOR	01-06-2021	    ALEXANDER FERNÁNDEZ 01-06-2021*/
		protected void OnloadProyectoContratoSup(object sender, EventArgs e)
		{
			this.SearchByProyectoContratoSup();
		}
		#endregion

		#region OnloadProyectoContratoCon
		/*CAMBIO						FECHA			AUTOR
		SELECT	AVANCE DE CONTRATISTA	03-06-2021	    ALEXANDER FERNÁNDEZ 03-06-2021*/
		protected void OnloadProyectoContratoCon(object sender, EventArgs e)
		{
			this.SearchByProyectoContratoCon();
		}
		#endregion


		#region  SearchByProyectoContratoSup
		/*CAMBIO						FECHA			AUTOR
		SELECT	AVANCE DE SUPERVISOR	01-06-2021	    ALEXANDER FERNÁNDEZ 01-06-2021*/
		private void SearchByProyectoContratoSup()
		{
			//if (pnContrato != 0)
			//{
				DataSet ds4 = new DataSet();
				string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();

            //ds4 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoSup((string)(Session["pIdProyecto"]), IdContrato);
            ds4 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoCon((string)(Session["pIdProyecto"]), IdContrato);

                GridProyectoContratoSup.KeyFieldName = "IDCONTRATOSEGUIMIENTO";
				GridProyectoContratoSup.DataSource = ds4.Tables[0];
				GridProyectoContratoSup.DataBind();
			//}
		}
		#endregion


		#region  SearchByProyectoContratoCon
		/*CAMBIO						FECHA			AUTOR
		SELECT	AVANCE DE CONTRATISTA	01-06-2021	    ALEXANDER FERNÁNDEZ 01-06-2021*/
		private void SearchByProyectoContratoCon()
		{
			//if (pnContrato != 0)
			//{
				DataSet ds5 = new DataSet();
				string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();

				ds5 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoCon((string)(Session["pIdProyecto"]), IdContrato);

				GridProyectoContratoCon.KeyFieldName = "IDCONTRATOSEGUIMIENTO";
				GridProyectoContratoCon.DataSource = ds5.Tables[0];
				GridProyectoContratoCon.DataBind();
			//}
		}
		#endregion



		#region ProyectoContratoSup
		/*CAMBIO						FECHA			AUTOR
		INSERT	AVANCE DE SUPERVISOR	01-06-2021	    ALEXANDER FERNÁNDEZ 01-06-2021*/
		protected void OnRowInsertingProyectoContratoSup(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
		{
			string pValorizacionFecha, pValorizacionNumero, pAvance;

			if (e.NewValues["SEGUIMIENTO_FECHA"] == null)
				pValorizacionFecha = "";
			else
				pValorizacionFecha = (e.NewValues["SEGUIMIENTO_FECHA"].ToString().Length == 0 ? "null" : e.NewValues["SEGUIMIENTO_FECHA"].ToString());

			if (e.NewValues["SEGUIMIENTO_CRONOGRAMA"] == null)
				pValorizacionNumero = "";

			else
				pValorizacionNumero = (e.NewValues["SEGUIMIENTO_CRONOGRAMA"].ToString().Length == 0 ? "null" : e.NewValues["SEGUIMIENTO_CRONOGRAMA"].ToString());

			if (e.NewValues["AVANCE"] == null)
				pAvance = "";
			else
				pAvance = (e.NewValues["AVANCE"].ToString().Length == 0 ? "null" : e.NewValues["AVANCE"].ToString());


			string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();

			string[] parameters = { IdContrato, pValorizacionFecha, pValorizacionNumero, pAvance };

			string LvCadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.insertRowProyectoContratoSup(parameters);
			GridProyectoContratoSup.CancelEdit();
			e.Cancel = true;
			this.SearchByProyectoContratoSup();
		}
		#endregion


		#region UpdateRowProyectoContratoSup
		/*CAMBIO						FECHA			AUTOR
		UPDATE	AVANCE DE SUPERVISOR	02-06-2021	    ALEXANDER FERNÁNDEZ 01-06-2021*/
		protected void OnRowUpdatingProyectoContratoSup(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
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
			string LvCadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.UpdateRowProyectoContratoSup(parameters, Id);

			GridProyectoContratoSup.CancelEdit();
			e.Cancel = true;
			this.SearchByProyectoContratoSup();
		}
		#endregion

		#region OnRowDeletingProyectoContratoSup
		/*CAMBIO						FECHA			AUTOR
		DELETE	AVANCE DE SUPERVISOR	02-06-2021	    ALEXANDER FERNÁNDEZ 01-06-2021*/
		protected void OnRowDeletingProyectoContratoSup(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
		{
			string Id = e.Keys["IDCONTRATOSEGUIMIENTO"].ToString();
			string Cadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.DeleteRowProyectoContratoSup(Id);
			GridProyectoContratoSup.CancelEdit();
			e.Cancel = true;
			this.SearchByProyectoContratoSup();
		}
		#endregion



		#region GridProyectoProyectoContratoSup_RowValidating
		/*CAMBIO						FECHA			AUTOR
		VALIDACIÓN AVANCE SUPERVISOR	09-06-2021	    ALEXANDER FERNÁNDEZ 03-06-2021*/
		protected void GridProyectoProyectoContratoSup_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
		{
			foreach (GridViewColumn column in GridProyectoContratoSup.Columns)
			{
				GridViewDataColumn dataColumn = column as GridViewDataColumn;
				if (dataColumn == null) continue;
				if (e.NewValues[dataColumn.FieldName] == null && dataColumn.FieldName != "SEGUIMIENTO_CRONOGRAMA" && dataColumn.FieldName != "MONTO_OBRA")
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
		protected void GridProyectoContratoSup_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
		{
			/*if (!object.Equals(e.RowType, GridViewRowType.Data)) return;

			bool hasError = string.IsNullOrEmpty(e.GetValue("SEGUIMIENTO_FECHA").ToString());
			hasError = hasError || e.GetValue("AVANCE").ToString() == "0";
			if (hasError)
			{
				e.Row.ForeColor = System.Drawing.Color.Red;
			}*/
		}
		protected void GridProyectoContratoSup_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
		{
			GridProyectoContratoSup.DoRowValidation();
		}
		#endregion


		#region ProyectoContratoCon
		/*CAMBIO						FECHA			AUTOR
		INSERT	AVANCE DE CONTRATISTA	03-06-2021	    ALEXANDER FERNÁNDEZ 03-06-2021*/
		protected void OnRowInsertingProyectoContratoCon(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
		{
			string pValorizacionFecha, pValorizacionNumero, pAvance, lcAprobado;

			lcAprobado = (Convert.ToBoolean(e.NewValues["APROBADO"]) ? "1" : "0");

			if (e.NewValues["SEGUIMIENTO_FECHA"] == null)
				pValorizacionFecha = "";
			else
				pValorizacionFecha = (e.NewValues["SEGUIMIENTO_FECHA"].ToString().Length == 0 ? "null" : e.NewValues["SEGUIMIENTO_FECHA"].ToString());

			if (e.NewValues["SEGUIMIENTO_CRONOGRAMA"] == null)
				pValorizacionNumero = ""; 
			else
				pValorizacionNumero = (e.NewValues["SEGUIMIENTO_CRONOGRAMA"].ToString().Length == 0 ? "null" : e.NewValues["SEGUIMIENTO_CRONOGRAMA"].ToString());

			if (e.NewValues["AVANCE"] == null)
				pAvance = "";
			else
				pAvance = (e.NewValues["AVANCE"].ToString().Length == 0 ? "null" : e.NewValues["AVANCE"].ToString());

			

			string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();

			string[] parameters = { IdContrato, pValorizacionFecha, pValorizacionNumero, pAvance, lcAprobado };

			string LvCadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.insertRowProyectoContratoCon(parameters);
			GridProyectoContratoCon.CancelEdit();
			e.Cancel = true;
			this.SearchByProyectoContratoCon();
		}
		#endregion

		#region UpdateRowProyectoContratoCon
		/*CAMBIO						FECHA			AUTOR
		UPDATE	AVANCE DE CONTRATISTA	03-06-2021	    ALEXANDER FERNÁNDEZ 03-06-2021*/
		protected void OnRowUpdatingProyectoContratoCon(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
		{
			string pValorizaconFecha, pValorizacionNumero, pAvance, lcAprobado, pAdelantoDirecto, pAdelantoMateriales;

			lcAprobado = (Convert.ToBoolean(e.NewValues["APROBADO"]) ? "1" : "0");

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

			if (e.NewValues["ADELANTO_DIRECTO"] == null)
				pAdelantoDirecto = "NCN";
			else
				pAdelantoDirecto = (e.NewValues["ADELANTO_DIRECTO"].ToString().Length == 0 ? "null" : e.NewValues["ADELANTO_DIRECTO"].ToString());

			if (e.NewValues["ADELANTO_MATERIALES"] == null)
				pAdelantoMateriales = "NCN";
			else
				pAdelantoMateriales = (e.NewValues["ADELANTO_MATERIALES"].ToString().Length == 0 ? "null" : e.NewValues["ADELANTO_MATERIALES"].ToString());


			string Id = e.Keys["IDCONTRATOSEGUIMIENTO"].ToString();
			string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();

			string[] parameters = { IdContrato, pValorizaconFecha, pValorizacionNumero, pAvance, pAdelantoDirecto, pAdelantoMateriales, lcAprobado };
			string LvCadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.UpdateRowProyectoContratoCon(parameters, Id);

			GridProyectoContratoCon.CancelEdit();
			e.Cancel = true;
			this.SearchByProyectoContratoCon();
		}
		#endregion

		#region OnRowDeletingProyectoContratoSup
		/*CAMBIO						FECHA			AUTOR
		DELETE	AVANCE DE CONTRATISTA	03-06-2021	    ALEXANDER FERNÁNDEZ 03-06-2021*/
		protected void OnRowDeletingProyectoContratoCon(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
		{
			string Id = e.Keys["IDCONTRATOSEGUIMIENTO"].ToString();
			string Cadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.DeleteRowProyectoContratoCon(Id);
			GridProyectoContratoCon.CancelEdit();
			e.Cancel = true;
			this.SearchByProyectoContratoCon();
		}
		#endregion

		#region GridProyectoProyectoContratoCon_RowValidating
		/*CAMBIO						FECHA			AUTOR
		VALIDACIÓN AVANCE CONTRATISTA	09-06-2021	    ALEXANDER FERNÁNDEZ 03-06-2021*/
		protected void GridProyectoProyectoContratoCon_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
		{
            /*foreach (GridViewColumn column in GridProyectoProgramacion.Columns)
            {
                GridViewDataColumn dataColumn = column as GridViewDataColumn;
                if (dataColumn == null) continue;
                if (e.NewValues[dataColumn.FieldName] == null && dataColumn.FieldName != "CRONOGRAMA" && dataColumn.FieldName != "MONTO_OBRA")
                {
                    e.Errors[dataColumn] = "Valores no pueden ser nulos.";
                }
            }*/
            /*foreach (GridViewColumn column in GridProyectoContratoCon.Columns)
			{
				GridViewDataColumn dataColumn = column as GridViewDataColumn;
				//if (dataColumn == null) continue;
				//if (e.NewValues[dataColumn.FieldName] == null && dataColumn.FieldName != "SEGUIMIENTO_CRONOGRAMA" && dataColumn.FieldName != "MONTO_OBRA")
				if (e.NewValues["CRONOGRAMA"] == null )
					{
					e.Errors[dataColumn] = "Valores no pueden ser nulos.";
				}
			}
            if (e.Errors.Count > 0) e.RowError = "Por favor, llenar todos los campos...";*/
			if (e.NewValues["SEGUIMIENTO_FECHA"] != null && e.NewValues["SEGUIMIENTO_FECHA"].ToString().Length < 10)
			{
				AddError(e.Errors, GridProyectoSupervision.Columns["SEGUIMIENTO_FECHA"], "Registrar correctamente la Fecha del cronograma.");
			}
			//decimal Avance = e.NewValues["AVANCE"] != null ? Convert.ToDecimal(e.NewValues["AVANCE"]) : 0;
			//if (Avance == 0)
			//{
				//AddError(e.Errors, GridProyectoProgramacion.Columns["AVANCE"], "Avance, debe ser > 0.");
			//}
			//if (Convert.ToDecimal(e.NewValues["AVANCE"]) > 100)
			//{
				//AddError(e.Errors, GridProyectoProgramacion.Columns["AVANCE"], "Avance, No puede ser mayor al 100%.");
			//}
			if (string.IsNullOrEmpty(e.RowError) && e.Errors.Count > 0) e.RowError = "Por favor, corregir los errores.";
		}
		protected void GridProyectoContratoCon_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
		{
			if (!object.Equals(e.RowType, GridViewRowType.Data)) return;

			bool hasError = string.IsNullOrEmpty(e.GetValue("SEGUIMIENTO_FECHA").ToString());
			//hasError = hasError || e.GetValue("AVANCE").ToString() == "0";
			//if (hasError)
			//{
			//	e.Row.ForeColor = System.Drawing.Color.Red;
			//}        
		}
		protected void GridProyectoContratoCon_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
		{
			GridProyectoSupervision.DoRowValidation();
		}
		#endregion


		protected void GridProyectoProgramacion_CellEditorInitialize(object sender,
            DevExpress.Web.ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName == "CRONOGRAMA")
            {
                //e.Editor.Visible = false;
                //e.Editor.ReadOnly = true;
            }
        }		

        protected void comando(object sender, ASPxGridViewTableCommandCellEventArgs e)
        {           
                bool bVisible = InfoVisibleCriteria((ASPxGridView)sender, e.VisibleIndex);


            //DataSet ds4 = new DataSet();

            //ASPxGridView detailGrid = (ASPxGridView)sender;
            //int IdValorizacion = (int)detailGrid.GetMasterRowKeyValue();

            //ds4 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByContratoValorizacionDet((string)(Session["pIdProyecto"]), IdValorizacion);

            //decimal aprobado = Convert.ToDecimal(ds4.Tables[0].Rows[0]["APROBADO"].ToString());

            ASPxGridView GridContratoValorizacionDet = (ASPxGridView)sender;
            //if (aprobado == 1)
            //{
                
            //}

            if (!bVisible) {
                    e.Cell.Controls[0].Visible = false;  // hide the New button
                    e.Cell.Controls[1].Visible = false;                
                // hide the New button
                                                                                                                    //e.Cell.BackColor = System.Drawing.Color.LightCyan;                

                //disabling Columns
                //(e.GridContratoValorizacionDet as GridView).Columns["CANTIDAD"].Visible = false;
                //GridContratoValorizacionDet.Columns["CANTIDAD"].Visible = false;

                //ASPxGridView GridContratoValorizacionDet = (ASPxGridView)sender;
                //ASPxGridView GridContratoValorizacionDet = (ASPxGridView)sender;
                //int IdValorizacion = (int)detailGrid.GetMasterRowKeyValue();
                //GridContratoValorizacionDet.Columns["CANTIDAD"].Visible = false;
            }                                
        }        
        
        private bool InfoVisibleCriteria(ASPxGridView grid, int visibleIndex)
        {
            object row = grid.GetRow(visibleIndex);
            return ((DataRowView)row)["APROBADO"].ToString().Contains("0");
        }


		protected string GetImageName(object dataValue)
		{
			string val = string.Empty;
			try
			{
				val = dataValue.ToString();
			}
			catch { }
			string img = "";
			//switch (val)
			switch (val)
			{
				case "1000":
					img = "~/Images/circulo_verde.png";
					break;
				case "999":
					img = "~/Images/circulo_amarillo.jpg";
					break;

				case "-1000":
					img = "~/Images/circulo_rojo.jpg";
					break;

			}
			return img;
		}

		protected void GridContratoValorizacionDet_Load(object sender, EventArgs e)
		{
			//this.SearchByContratoValorizacionDet();
			DataSet ds4 = new DataSet();
			string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();
			//string IdValorizacion = GridProyectoContratoCon.GetRowValues(GridProyectoContratoCon.FocusedRowIndex, "IDCONTRATOSEGUIMIENTO").ToString();
			//txtMensaje.Text = "1";
			//MessageBox.Show('hola');
			ASPxGridView detailGrid = (ASPxGridView)sender;
			int IdValorizacion = (int)detailGrid.GetMasterRowKeyValue();

			ds4 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByContratoValorizacionDet((string)(Session["pIdProyecto"]), IdContrato, IdValorizacion,1);

			ASPxGridView GridContratoValorizacionDet = (ASPxGridView)sender;

			GridContratoValorizacionDet.KeyFieldName = "IDCONTRATOVALORIZACIONDET";
			GridContratoValorizacionDet.DataSource = ds4.Tables[0];
			GridContratoValorizacionDet.DataBind();
		}


        protected void GridContratoValorizacionDetSup_Load(object sender, EventArgs e)
        {
            //this.SearchByContratoValorizacionDet();
            DataSet ds4 = new DataSet();
            string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();
            //string IdValorizacion = GridProyectoContratoCon.GetRowValues(GridProyectoContratoCon.FocusedRowIndex, "IDCONTRATOSEGUIMIENTO").ToString();
            //txtMensaje.Text = "1";
            //MessageBox.Show('hola');
            ASPxGridView detailGrid = (ASPxGridView)sender;
            int IdValorizacion = (int)detailGrid.GetMasterRowKeyValue();

            ds4 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByContratoValorizacionDet((string)(Session["pIdProyecto"]), IdContrato, IdValorizacion, 2);

            ASPxGridView GridContratoValorizacionDet = (ASPxGridView)sender;

            GridContratoValorizacionDet.KeyFieldName = "IDCONTRATOVALORIZACIONDET";
            GridContratoValorizacionDet.DataSource = ds4.Tables[0];
            GridContratoValorizacionDet.DataBind();
        }



        protected void GridContratoValorizacionDet_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
		{
            string pCantidad,pCantidadSup,pCantidadCon,pAprobado;			

			if (e.NewValues["CANTIDAD"] == null)
				pCantidad = "NCN";
			else
				pCantidad = (e.NewValues["CANTIDAD"].ToString().Length == 0 ? "null" : e.NewValues["CANTIDAD"].ToString());


            if (e.NewValues["CANTIDADSUP"] == null)
                pCantidadSup = "NCN";
            else
                pCantidadSup = (e.NewValues["CANTIDADSUP"].ToString().Length == 0 ? "null" : e.NewValues["CANTIDADSUP"].ToString());


            if (e.NewValues["CANTIDADCON"] == null)
                pCantidadCon = "NCN";
            else
                pCantidadCon = (e.NewValues["CANTIDADCON"].ToString().Length == 0 ? "null" : e.NewValues["CANTIDADCON"].ToString());

			if (e.NewValues["APROBADO"] == null)
				pAprobado = "NCN";
			else
				pAprobado = (e.NewValues["APROBADO"].ToString().Length == 0 ? "null" : e.NewValues["APROBADO"].ToString());


			string Id = e.Keys["IDCONTRATOVALORIZACIONDET"].ToString();
			string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();

			string[] parameters = { IdContrato, pCantidad, pCantidadSup, pCantidadCon, pAprobado };
			
			string LvCadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.UpdateRowContratoValorizacionDet(parameters, Id);			
			e.Cancel = true;			

			//GridProyectoContratoCon.DetailRows.ExpandRow(0);

			DataSet ds4 = new DataSet();
			//string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();
			//string IdValorizacion = GridProyectoContratoCon.GetRowValues(GridProyectoContratoCon.FocusedRowIndex, "IDCONTRATOSEGUIMIENTO").ToString();
			//txtMensaje.Text = "1";
			//MessageBox.Show('hola');
			ASPxGridView detailGrid = (ASPxGridView)sender;
			int IdValorizacion = (int)detailGrid.GetMasterRowKeyValue();

			ds4 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByContratoValorizacionDet((string)(Session["pIdProyecto"]), IdContrato, IdValorizacion,1);

			ASPxGridView GridContratoValorizacionDet = (ASPxGridView)sender;

			GridContratoValorizacionDet.KeyFieldName = "IDCONTRATOVALORIZACIONDET";
			GridContratoValorizacionDet.DataSource = ds4.Tables[0];
			GridContratoValorizacionDet.DataBind();
		}

		protected void GridContratoValorizacionDet_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
		{
			DataSet ds1 = new DataSet();
            //ds1 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyecto(pIdProyecto);

            decimal utilidad, gastos_generales, gastos_otros, adelantoDirecto, adelantoMateriales, adelantoOtros, igv;
            string subTotal, igvTotal, sumTotal;

            //TRAER IGV DE LA BD            
            utilidad = 10;
			gastos_generales = 20;
			gastos_otros = 20;
			adelantoDirecto = 10;
			adelantoMateriales = 10;
			adelantoOtros = 10;
			igv = Convert.ToDecimal(0.18);
			ds1 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyecto(pIdProyecto);
			if (ds1.Tables[0].Rows.Count > 0) {
				utilidad = Convert.ToDecimal(ds1.Tables[0].Rows[0]["PCUTILIDADES"].ToString());
				gastos_generales = Convert.ToDecimal(ds1.Tables[0].Rows[0]["PCGASTOS_GENERALES"].ToString());
				gastos_otros = Convert.ToDecimal(ds1.Tables[0].Rows[0]["PCGASTOS_OTROS"].ToString());
				adelantoDirecto = Convert.ToDecimal(ds1.Tables[0].Rows[0]["PCADELANTODIRECTO"].ToString());
				adelantoMateriales = Convert.ToDecimal(ds1.Tables[0].Rows[0]["PCADELANTOMATERIALES"].ToString());
				adelantoOtros = Convert.ToDecimal(ds1.Tables[0].Rows[0]["PCADELANTOOTROS"].ToString());
			}

			adelantoDirecto = 0;
			adelantoMateriales = 0;
			adelantoOtros = 0;

			if ((e.Item as ASPxSummaryItem).Tag == "1")
			{
				ASPxSummaryItem incomeSummary = (sender as ASPxGridView).TotalSummary["TOTAL"];
				//ASPxSummaryItem expenseSummary = (sender as ASPxGridView).TotalSummary["Expense"];
				Decimal income = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary));
				//Decimal expense = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(expenseSummary));				
				
				e.TotalValue = income*utilidad/100;                                
            }
            else if((e.Item as ASPxSummaryItem).Tag == "2"){
				ASPxSummaryItem incomeSummary = (sender as ASPxGridView).TotalSummary["TOTAL"];
				//ASPxSummaryItem expenseSummary = (sender as ASPxGridView).TotalSummary["Expense"];
				Decimal income = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary));
				//Decimal expense = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(expenseSummary));
				e.TotalValue = income * gastos_generales / 100;
			}
			else if ((e.Item as ASPxSummaryItem).Tag == "3")
			{
				ASPxSummaryItem incomeSummary = (sender as ASPxGridView).TotalSummary["TOTAL"];
				//ASPxSummaryItem expenseSummary = (sender as ASPxGridView).TotalSummary["Expense"];
				Decimal income = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary));
				//Decimal expense = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(expenseSummary));
				e.TotalValue = income * gastos_otros / 100;
			}
			else if ((e.Item as ASPxSummaryItem).Tag == "4")
			{
				ASPxSummaryItem incomeSummary = (sender as ASPxGridView).TotalSummary["TOTAL"];
				//ASPxSummaryItem expenseSummary = (sender as ASPxGridView).TotalSummary["Expense"];
				Decimal income = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary));
				//Decimal expense = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(expenseSummary));
				e.TotalValue = income + income * utilidad / 100 + income * gastos_generales / 100 + income * gastos_otros / 100;
			}			
			else if ((e.Item as ASPxSummaryItem).Tag == "5")
			{
				ASPxSummaryItem incomeSummary = (sender as ASPxGridView).TotalSummary["TOTAL"];
				//ASPxSummaryItem expenseSummary = (sender as ASPxGridView).TotalSummary["Expense"];
				Decimal income = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary));
				//Decimal expense = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(expenseSummary));
				Decimal sub = (income + income * utilidad / 100 + income * gastos_generales / 100 + income * gastos_otros / 100);
                adelantoDirecto = Convert.ToDecimal((sub * adelantoDirecto / 100).ToString("n2"));
                e.TotalValue = adelantoDirecto;

            }
			else if ((e.Item as ASPxSummaryItem).Tag == "6")
			{
				ASPxSummaryItem incomeSummary = (sender as ASPxGridView).TotalSummary["TOTAL"];
				//ASPxSummaryItem expenseSummary = (sender as ASPxGridView).TotalSummary["Expense"];
				Decimal income = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary));
				//Decimal expense = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(expenseSummary));

				Decimal sub = (income + income * utilidad / 100 + income * gastos_generales / 100 + income * gastos_otros / 100);

                adelantoMateriales = Convert.ToDecimal((sub * adelantoMateriales/100).ToString("n2"));
                e.TotalValue = adelantoMateriales;

            }
			else if ((e.Item as ASPxSummaryItem).Tag == "7")
			{
				ASPxSummaryItem incomeSummary = (sender as ASPxGridView).TotalSummary["TOTAL"];
				//ASPxSummaryItem expenseSummary = (sender as ASPxGridView).TotalSummary["Expense"];
				Decimal income = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary));
				//Decimal expense = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(expenseSummary));

				Decimal sub = (income + income * utilidad / 100 + income * gastos_generales / 100 + income * gastos_otros / 100) ;
                adelantoOtros = Convert.ToDecimal((sub * adelantoOtros / 100).ToString("n2"));
                e.TotalValue = adelantoOtros;

            }
			else if ((e.Item as ASPxSummaryItem).Tag == "8")
			{
				ASPxSummaryItem incomeSummary = (sender as ASPxGridView).TotalSummary["TOTAL"];				
				Decimal income = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary));                
                Decimal sub = (income + income * utilidad / 100 + income * gastos_generales / 100 + income * gastos_otros / 100);

                adelantoDirecto = Convert.ToDecimal((sub * adelantoDirecto / 100).ToString("n2"));
                adelantoMateriales = Convert.ToDecimal((sub * adelantoMateriales / 100).ToString("n2"));
                adelantoOtros = Convert.ToDecimal((sub * adelantoOtros / 100).ToString("n2"));

                e.TotalValue = adelantoDirecto + adelantoMateriales + adelantoOtros;
			}
			else if ((e.Item as ASPxSummaryItem).Tag == "9")
			{
				ASPxSummaryItem incomeSummary = (sender as ASPxGridView).TotalSummary["TOTAL"];
				//ASPxSummaryItem expenseSummary = (sender as ASPxGridView).TotalSummary["Expense"];
				Decimal income = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary));
				//Decimal expense = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(expenseSummary));

				Decimal sub = (income + income * utilidad / 100 + income * gastos_generales / 100 + income * gastos_otros / 100);

				e.TotalValue = sub - (sub * adelantoDirecto / 100 + sub * adelantoMateriales / 100 + sub * adelantoOtros / 100);
			}
			else if ((e.Item as ASPxSummaryItem).Tag == "10")
			{
				ASPxSummaryItem incomeSummary = (sender as ASPxGridView).TotalSummary["TOTAL"];
				//ASPxSummaryItem expenseSummary = (sender as ASPxGridView).TotalSummary["Expense"];
				//Decimal income = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary));
				//Decimal expense = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(expenseSummary));
				Decimal income = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary));
				//Decimal expense = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(expenseSummary));

				Decimal sub = (income + income * utilidad / 100 + income * gastos_generales / 100 + income * gastos_otros / 100);				 
				e.TotalValue = (sub - (sub * adelantoDirecto / 100 + sub * adelantoMateriales / 100 + sub * adelantoOtros / 100)) * igv;
			}
			else if ((e.Item as ASPxSummaryItem).Tag == "11")
			{
				ASPxSummaryItem incomeSummary = (sender as ASPxGridView).TotalSummary["TOTAL"];
				//ASPxSummaryItem expenseSummary = (sender as ASPxGridView).TotalSummary["Expense"];
				//Decimal income = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary));
				//Decimal expense = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(expenseSummary));
				Decimal income = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary));
				//Decimal expense = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(expenseSummary));

				Decimal sub = (income + income * utilidad / 100 + income * gastos_generales / 100 + income * gastos_otros / 100);
				e.TotalValue = (sub - (sub * adelantoDirecto / 100 + sub * adelantoMateriales / 100 + sub * adelantoOtros / 100)) * (1+igv);
			}
			else if ((e.Item as ASPxSummaryItem).Tag == "16")
			{
				ASPxSummaryItem incomeSummary = (sender as ASPxGridView).TotalSummary["ACUMULADO_TOTALPRECIO"];
				ASPxSummaryItem incomeSummary1 = (sender as ASPxGridView).TotalSummary["ACUMULADO_TOTALPRESUPUESTO"];				
				Decimal income = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary));
				Decimal income1 = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary1));


				//TOTAL VALORIZACIÓN
				ASPxSummaryItem incomeSummary3 = (sender as ASPxGridView).TotalSummary["TOTAL"];
				Decimal income3 = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary3));
				Decimal sub = (income3 + income3 * utilidad / 100 + income3 * gastos_generales / 100 + income * gastos_otros / 100);
				//e.TotalValue = sub - (sub * adelantoDirecto / 100 + sub * adelantoMateriales / 100 + sub * adelantoOtros / 100);

				if (income1 > 0)
				{
					string porcentaje_avance = ((income / income1) * 100).ToString("n2");
					e.TotalValue = porcentaje_avance;

					ASPxGridView detailGrid = (ASPxGridView)sender;
					int IdValorizacion = (int)detailGrid.GetMasterRowKeyValue();

					string[] parameters = { porcentaje_avance, sub.ToString() };
					string LvCadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.UpdateRowPorcentajeAvance(parameters, IdValorizacion);
				}
			}
		}

        protected void GridContratoValorizacionDet_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {            
           
            ASPxGridView GridContratoValorizacionDet = (ASPxGridView)sender;
            decimal cantidad = e.NewValues["CANTIDAD"] != null ? Convert.ToDecimal(e.NewValues["CANTIDAD"]) : 0;
            decimal saldo = e.OldValues["SALDO_OLD_"] != null ? Convert.ToDecimal(e.OldValues["SALDO_OLD_"]) : 0;
            if (cantidad > saldo)
            {
                AddError(e.Errors, GridContratoValorizacionDet.Columns["CANTIDAD"], "Cantidad, debe ser menor que CANTIDAD TOTAL .");
            }
            //if (Convert.ToDecimal(e.NewValues["AVANCE"]) > 100)
            //{
              //  AddError(e.Errors, GridProyectoProgramacion.Columns["AVANCE"], "Avance, No puede ser mayor al 100%.");
            //}

            if (string.IsNullOrEmpty(e.RowError) && e.Errors.Count > 0) e.RowError = "Por favor, corregir los errores.";

			//GridContratoValorizacionDet.Columns["SALDO_OLD"].Visible = false;*/
			//string cantidad = e.NewValues["CANTIDAD"].ToString();
			//string saldo_old = e.OldValues["SALDO_OLD_"].ToString();

		}

		protected void Button1_Click(object sender, EventArgs e)
        {
            exporterValorizacion.Landscape = true;
            exporterValorizacion.RightMargin = 0;
            exporterValorizacion.LeftMargin = 0;
            exporterValorizacion.WritePdfToResponse();
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            exporterValorizacionSup.Landscape = true;
            exporterValorizacionSup.RightMargin = 0;
            exporterValorizacionSup.LeftMargin = 0;
            exporterValorizacionSup.WritePdfToResponse();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {            
            exporterValorizacion.WriteXlsxToResponse(new XlsxExportOptionsEx { ExportType = ExportType.WYSIWYG });
            //exporterValorizacion.WriteXlsxToResponse(New XlsxExportOptionsEx() With {.ExportType = ExportType.WYSIWYG})  
            //exporterValorizacion.WriteXlsxToResponse();
        }

		protected void hyperLink_Init(object sender, EventArgs e)
		{
			ASPxHyperLink link = (ASPxHyperLink)sender;

			GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;

			int rowVisibleIndex = templateContainer.VisibleIndex;
			string pIdValorizacion = templateContainer.Grid.GetRowValues(rowVisibleIndex, "IDCONTRATOSEGUIMIENTO").ToString();

			//string Id = e.Keys["IDCONTRATOSEGUIMIENTO"].ToString();
			//string pIdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();

			//string contentUrl = string.Format("{0}?EAN13={1}", Session["baseURL"], pIdValorizacion);
			string contentUrl = "frmInfoGesGsoProyectoRegistroPolinomica.aspx" + "?pIdValorizacion=" + pIdValorizacion;

			link.NavigateUrl = "javascript:void(0);";
			//link.Text = string.Format("More Info: EAN13 - {0}", ean13);
			link.Text = string.Format("Polinómica", pIdValorizacion);
			link.ClientSideEvents.Click = string.Format("function(s, e) {{ OnMoreInfoClick('{0}'); }}", contentUrl);			

		}

		// RESÚMEN VALORIZACIÓN
		protected void hyperLink_Init_resumen(object sender, EventArgs e)
		{
			ASPxHyperLink link = (ASPxHyperLink)sender;

			GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;

			int rowVisibleIndex = templateContainer.VisibleIndex;
			string pIdValorizacion = templateContainer.Grid.GetRowValues(rowVisibleIndex, "IDCONTRATOSEGUIMIENTO").ToString();

			//string Id = e.Keys["IDCONTRATOSEGUIMIENTO"].ToString();
			//string pIdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();

			//string contentUrl = string.Format("{0}?EAN13={1}", Session["baseURL"], pIdValorizacion);
			string contentUrl = "frmInfoGesGSOSResumen.aspx" + "?pIdValorizacion=" + pIdValorizacion;

			link.NavigateUrl = "javascript:void(0);";
			//link.Text = string.Format("More Info: EAN13 - {0}", ean13);
			link.Text = string.Format("Resumen", pIdValorizacion);
			link.ClientSideEvents.Click = string.Format("function(s, e) {{ OnMoreInfoClick('{0}'); }}", contentUrl);

		}

        // CURVA S VALORIZACIÓN
        protected void hyperLink_Init_curva_s(object sender, EventArgs e)
        {
            ASPxHyperLink link = (ASPxHyperLink)sender;

            GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;

            int rowVisibleIndex = templateContainer.VisibleIndex;
            string pIdValorizacion = templateContainer.Grid.GetRowValues(rowVisibleIndex, "IDCONTRATOSEGUIMIENTO").ToString();

            link.Attributes.Add("onClick", "window.open('frmInfoGesGSOSCurvaS.aspx?pIdValorizacion=" + pIdValorizacion + "','height=200,width=400,status=yes,toolbar=no,menubar=no,location=no');return false");
            link.Text = string.Format("Curva S", pIdValorizacion);
        }


		// CURVA S VALORIZACIÓN
		protected void hyperLink_Sup(object sender, EventArgs e)
		{
			ASPxHyperLink link = (ASPxHyperLink)sender;

			GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;

			int rowVisibleIndex = templateContainer.VisibleIndex;
			string pIdValorizacion = templateContainer.Grid.GetRowValues(rowVisibleIndex, "IDCONTRATOSEGUIMIENTO").ToString();

            //string contentUrl = string.Format("{0}?EAN13={1}", Session["baseURL"], pIdValorizacion);
            //string contentUrl = "frmInfogesGSOSSupervisores.aspx" + "?pIdValorizacion=" + pIdValorizacion;

            //link.Width = "";
            link.NavigateUrl = "javascript:void(0);";


            //link.Attributes.Add("onclick", "window.open('frmInfogesGSOSSupervisores.aspx?pIdValorizacion=" + pIdValorizacion+"',height: 40px; width: 128px)");

            //"= "style ="border - width:1px; border - style:Dotted; height: 40px; width: 128px; Z - INDEX:
            //103; LEFT: 408px; POSITION: absolute; TOP: 208px"
            //link.Controls.Add(hyperLink);


            //link.Text = string.Format("More Info: EAN13 - {0}", ean13);

            link.Attributes.Add("onClick", "window.open('frmInfogesGSOSSupervisores.aspx','height=200,width=400,status=yes,toolbar=no,menubar=no,location=no');return false");


            //this.Button2.Attributes.Add("onclick", "window.open('WebForm154.aspx?id=1&name=bbb',null,'height=200,width=400,status=yes,toolbar=no,menubar=no,location=no'); return false");

            //link.
            link.Text = string.Format("VSUP", pIdValorizacion);
			//link.ClientSideEvents.Click = string.Format("function(s, e) {{ OnMoreInfoClick('{0}'); }}", contentUrl);
		}


		protected void GridContratoValorizacionDet_SummaryDisplayText(object sender, ASPxGridViewSummaryDisplayTextEventArgs e)
        {

            DataSet ds1 = new DataSet();
            decimal utilidad, gastos_generales,gastos_otros, adelantoDirecto, adelantoMateriales, adelantoOtros, igv;

            //TRAER IGV DE LA BD
            utilidad = 10;
            gastos_generales = 20;
			gastos_otros = 20;
			adelantoDirecto = 10;
            adelantoMateriales = 10;
            adelantoOtros = 10;
            igv = Convert.ToDecimal(0.18);
            ds1 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyecto(pIdProyecto);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                utilidad = Convert.ToDecimal(ds1.Tables[0].Rows[0]["PCUTILIDADES"].ToString());
                gastos_generales = Convert.ToDecimal(ds1.Tables[0].Rows[0]["PCGASTOS_GENERALES"].ToString());
				gastos_otros = Convert.ToDecimal(ds1.Tables[0].Rows[0]["PCGASTOS_OTROS"].ToString());
				adelantoDirecto = Convert.ToDecimal(ds1.Tables[0].Rows[0]["PCADELANTODIRECTO"].ToString());
                adelantoMateriales = Convert.ToDecimal(ds1.Tables[0].Rows[0]["PCADELANTOMATERIALES"].ToString());
                adelantoOtros = Convert.ToDecimal(ds1.Tables[0].Rows[0]["PCADELANTOOTROS"].ToString());
            }

            if ((e.Item as ASPxSummaryItem).Tag == "1")
            {                		
                e.Text = string.Format("Utilidad (" + utilidad+ "%) = {0:c}", Convert.ToDouble(e.Value));
            }
            else if ((e.Item as ASPxSummaryItem).Tag == "2")
            {
                e.Text = string.Format("G. Generales (" + gastos_generales + "%) = {0:c}", Convert.ToDouble(e.Value));
            }
			else if ((e.Item as ASPxSummaryItem).Tag == "3")
			{
				e.Text = string.Format("G. Otros (" + gastos_otros + "%) = {0:c}", Convert.ToDouble(e.Value));
			}
			else if ((e.Item as ASPxSummaryItem).Tag == "10")
            {
                e.Text = string.Format("Igv (" + igv*100 + "%) = {0:c}", Convert.ToDouble(e.Value));
            }
			else if ((e.Item as ASPxSummaryItem).Tag == "11")
			{
				e.Text = string.Format("Total a P. = {0:c}", Convert.ToDouble(e.Value));
			}
			else if ((e.Item as ASPxSummaryItem).Tag == "5")
            {
                e.Text = string.Format("Adelanto Dir. (" + adelantoDirecto + "%) = {0:c}", Convert.ToDouble(e.Value));
            }
            else if ((e.Item as ASPxSummaryItem).Tag == "6")
            {
                e.Text = string.Format("Adelanto Mat. (" + adelantoMateriales + "%) = {0:c}", Convert.ToDouble(e.Value));
            }
            else if ((e.Item as ASPxSummaryItem).Tag == "7")
            {
                e.Text = string.Format("Adelanto Otr. (" + adelantoOtros + "%) = {0:c}", Convert.ToDouble(e.Value));
            }

        }

		protected void GridContratoValorizacionDet_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
		{
			if (!object.Equals(e.RowType, GridViewRowType.Data)) return;                     
            decimal precio = (decimal)e.GetValue("PRECIO");

            if (precio > 0) {
                //e.Row.Cells[10].BackColor = Color.FromArgb(239, 239, 237);
                e.Row.Cells[10].BackColor = System.Drawing.Color.DarkRed;
                e.Row.Cells[1].BackColor = Color.FromArgb(208, 235, 251);
                //e.Row.Cells[2].BackColor = System.Drawing.Color.DarkRed;
            }
                

            if (precio == 0)
            {
                e.Row.BackColor = Color.FromArgb(144, 223, 203);
                //e.Row.BackColor = System.Drawing.Color.Red;
            }

        }

        protected void GridContratoValorizacionDet_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {

            if ((e.DataColumn.FieldName == "MEDIDA" || e.DataColumn.FieldName == "PAR_CANTIDAD" || e.DataColumn.FieldName == "CANTIDADTOTAL" || e.DataColumn.FieldName == "PRECIO" || e.DataColumn.FieldName == "PRESUPUESTO_PARCIAL") && Convert.ToInt32(e.GetValue("PRECIO")) == 0)
                e.Cell.Text = String.Empty;            

            if ((e.DataColumn.FieldName == "ACUMULADO" || e.DataColumn.FieldName == "ACUMULADO_ANTERIOR_PARCIAL" || e.DataColumn.FieldName == "ACUMULADO_ANTERIOR_PORCENTAJE") && Convert.ToInt32(e.GetValue("PRECIO")) == 0)
                e.Cell.Text = String.Empty;

            if ((e.DataColumn.FieldName == "CANTIDAD" || e.DataColumn.FieldName == "TOTAL" || e.DataColumn.FieldName == "PORCENTAJE") && Convert.ToInt32(e.GetValue("PRECIO")) == 0)
                e.Cell.Text = String.Empty;


            if ((e.DataColumn.FieldName == "ACUMULADO_TOTAL" || e.DataColumn.FieldName == "METRADO" || e.DataColumn.FieldName == "ACUMULADO_TOTAL_PARCIAL" || e.DataColumn.FieldName == "SALDOACUMULADO") && Convert.ToInt32(e.GetValue("PRECIO")) == 0)
                e.Cell.Text = String.Empty;

            if ((e.DataColumn.FieldName == "SALDO_POR_EJECUTAR" || e.DataColumn.FieldName == "SALDO_POR_EJECUTAR_VALORIZADO" || e.DataColumn.FieldName == "SALDOACUMULADO")   && Convert.ToInt32(e.GetValue("PRECIO")) == 0)
                e.Cell.Text = String.Empty;

            if ((e.DataColumn.FieldName == "APROBADO" || e.DataColumn.FieldName == "SALDO_OLD_") && Convert.ToInt32(e.GetValue("PRECIO")) == 0)
                e.Cell.Text = String.Empty;


            //e.Cell.BackColor = System.Drawing.Color.LightYellow;
            if (e.DataColumn.FieldName == "CANTIDADTOTAL" && Convert.ToInt32(e.GetValue("PRECIO")) > 0)                
                e.Cell.BackColor = Color.FromArgb(239, 239, 237);

                if ((e.DataColumn.FieldName == "CANTIDAD" || e.DataColumn.FieldName == "SALDOACUMULADO") && Convert.ToInt32(e.GetValue("PRECIO")) > 0)
                e.Cell.BackColor = Color.FromArgb(208, 235, 251);
        }

        protected void GridContratoValorizacionDet_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
        {
            ASPxGridView GridContratoValorizacionDet = (ASPxGridView)sender;
            decimal precio = Convert.ToDecimal(GridContratoValorizacionDet.GetRowValues(e.VisibleIndex, "PRECIO"));            
            if (precio == 0)
            {
                foreach (var cell in e.Row.Cells)
                {
                    if (cell.GetType() == typeof(DevExpress.Web.Rendering.GridViewTableDataCell))
                    {
                        DevExpress.Web.Rendering.GridViewTableDataCell cel = (DevExpress.Web.Rendering.GridViewTableDataCell)cell;
                        cel.Attributes.Add("onclick", "event.cancelBubble = true");                        
                    }
                }
            }
        }
    }	
}