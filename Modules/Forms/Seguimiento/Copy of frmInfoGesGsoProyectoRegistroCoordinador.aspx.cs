using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using System.Data;

namespace InfoGesRegional.Modules.Forms.Seguimiento
{
    public partial class frmInfoGesGsoProyectoRegistroCoordinador : System.Web.UI.Page
    {
        private string pIdOPeracion;
        private string pIdProyecto;


        #region PageInit
        protected void Page_Init(object sender, EventArgs e)
        {
            this.LoadCboEstado();
            this.LoadCboComponente();

        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InfoGesRegional.Modules.MasterPage m = (InfoGesRegional.Modules.MasterPage)Page.Master;
            pIdOPeracion = "" + Request.Params["pOpera"];
            pIdProyecto = "" + Request.Params["pId"];
            Session["pIdProyecto"] = pIdProyecto;
            pIdProyecto = (pIdProyecto.ToString().Length == 0 ? "0" : pIdProyecto.ToString());
             if (!Page.IsPostBack && !IsCallback)
            {

                //m.SetTitleText = "Registro del Contrato";
                this.LoadCboPaquete();
                this.LoadActividad();
                this.LoadTipoProyecto();

                if (pIdOPeracion == "edit")
                {
                    if (pIdProyecto == "-1")
                    {
                    }
                    else
                    {
                        //m.SetTitleText = "Actualizando datos de Contrato";
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
                    //if (Session["pIdProyecto"] == null)
                    //{
                    pIdProyecto = ds1.Tables[0].Rows[0]["IDPROYECTO"].ToString();
                    //Session["pIdProyecto"] = pIdProyecto; 

                    //}
                    this.txtCUI.Text = ds1.Tables[0].Rows[0]["ACT_PROY"].ToString();
                    this.txtDescripcion.Text = ds1.Tables[0].Rows[0]["DESCRIPCION"].ToString();
                    this.txtAbreviatura.Text = ds1.Tables[0].Rows[0]["ABREVIATURA"].ToString();
                    this.txtExpedienteTecnico.Text = ds1.Tables[0].Rows[0]["MONTO_TOTAL_EXP_TECNICO"].ToString();
                    this.txtObra.Text = ds1.Tables[0].Rows[0]["MONTO_TOTAL_OBRA"].ToString();
                    this.txtSupervision.Text = ds1.Tables[0].Rows[0]["MONTO_TOTAL_SUPERVISION"].ToString();
                    this.txtInterferencia.Text = ds1.Tables[0].Rows[0]["MONTO_TOTAL_INTERFERENCIA"].ToString();
                    this.txtGestionProyecto.Text = ds1.Tables[0].Rows[0]["MONTO_TOTAL_GESTION_PROYECTO"].ToString();
                    this.txtTerreno.Text = ds1.Tables[0].Rows[0]["MONTO_TOTAL_TERRENO"].ToString();
                    this.txtMobiliario.Text = ds1.Tables[0].Rows[0]["MONTO_TOTAL_MOBILIARIA"].ToString();
                    this.txtCoorInicionorte.Text = ds1.Tables[0].Rows[0]["COORDENADA_INICIO_NORTE"].ToString();
                    this.txtcoorInicioEste.Text = ds1.Tables[0].Rows[0]["COORDENADA_INICIO_ESTE"].ToString();
                    this.txtCoorFinNorte.Text = ds1.Tables[0].Rows[0]["COORDENADA_FIN_NORTE"].ToString();
                    this.txtCoorFinEste.Text = ds1.Tables[0].Rows[0]["COORDENADA_FIN_ESTE"].ToString();
                    this.CboActividad.Value = ds1.Tables[0].Rows[0]["IDACTIVIDAD_PROYECTO"].ToString();
                    this.CboPaquete.Value = ds1.Tables[0].Rows[0]["IDPAQUETE"].ToString();
                    this.CboTipoProyecto.Value = ds1.Tables[0].Rows[0]["IDTIPO_PROYECTO"].ToString();
                    this.txtDistrito.Text = ds1.Tables[0].Rows[0]["DISTRITO"].ToString();

                    this.GridProyectoMeta.Visible = true;
                    this.GridProyectoComponente.Visible = true;
                    this.GridProyectoContrato.Visible = true;
                    this.GridProyectoProgramacion.Visible = true;
                    this.GridProyectoSupervision.Visible = true;
                    this.GridProyectoValorizacion.Visible = true;
                }
                else
                {
                    pIdProyecto = "0";
                    pIdOPeracion = "New";
                    //Session["pIdProyecto"] = pIdProyecto; 
                    this.txtCUI.Text = "";
                    this.txtDescripcion.Text = "";
                    this.txtAbreviatura.Text = "";
                    this.txtExpedienteTecnico.Text = "";
                    this.txtSupervision.Text ="";
                    this.txtInterferencia.Text = "";
                    this.txtGestionProyecto.Text = "";
                    this.txtTerreno.Text = "";
                    this.txtMobiliario.Text = "";
                    this.txtCoorInicionorte.Text = "";
                    this.txtcoorInicioEste.Text = "";
                    this.txtCoorFinNorte.Text = "";
                    this.txtCoorFinEste.Text = "";
                    this.CboActividad.Value = 0;
                    this.CboPaquete.Value = 0;
                    this.CboTipoProyecto.Value = 0;

                    this.GridProyectoMeta.Visible = false;
                    this.GridProyectoComponente.Visible = false;
                    this.GridProyectoContrato.Visible = false;
                    this.GridProyectoProgramacion.Visible = false;
                    this.GridProyectoSupervision.Visible = false;
                    this.GridProyectoValorizacion.Visible = false;
                    this.txtDistrito.Text = "";
                }
                //this.txtDistrito.Text = ds1.Tables[0].Rows[0]["DISTRITO"].ToString();
                /*Id_Obra = ds1.Tables[0].Rows[0]["ID_OBRA"].ToString();
                LoadCboFuenteCrediticia();*/


            //        this.CboPaquete.Value=ds1.Tables[0].Rows[0]["IDPAQUETE"];


            //    ds1 = new DataSet();
            //    ds1 = Code.Logic.Forms.Seguimiento.Contrato.SearchByBloqueoComponente(Id_Obra_Contrato.ToString());
            //    if (ds1.Tables[0].Rows[0]["MONTO"].ToString().Length != 0)
            //        this.drpCategoria.Enabled = false;
            }
        }
        #endregion

        #region btnSave_Click
        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveValues();
        }
        #endregion

        #region  btnClose_Click
        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Modules/Forms/Seguimiento/frmInfoGesGSOProyecto.aspx");

        }
        #endregion

        #region SaveValues
        private void SaveValues()
        {
            string IdProyecto;
            string Cadena;
            IdProyecto = "ACA SE PONE  LA KEY";
            string[] parameters = { 
            (string)(Session["pIdProyecto"]),
            this.txtCUI.Text,
            this.txtDescripcion.Text,
            this.txtAbreviatura.Text,
            this.CboPaquete.Value.ToString(),
            this.CboActividad.Value.ToString(),
            this.CboTipoProyecto.Value.ToString(),
            this.txtExpedienteTecnico.Text,
            this.txtSupervision.Text,
            this.txtInterferencia.Text,
            this.txtGestionProyecto.Text,
            this.txtTerreno.Text,
            this.txtMobiliario.Text,
            this.txtCoorInicionorte.Text,
            this.txtcoorInicioEste.Text,
            this.txtCoorFinNorte.Text,
            this.txtCoorFinEste.Text,
            this.txtDistrito.Text,
            this.txtObra.Text};

                DataSet ds1 = new DataSet();

                ds1 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyecto(pIdProyecto);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    Cadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.UpdatedProyecto(parameters, (string)(Session["IdProyecto"]));
                    if (Cadena.ToString().Length != 0)
                    {
                        throw new Exception(Cadena);
                    }
                }
                else
                {
                    Cadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.InsertProyecto(parameters);
                    if (Cadena.ToString().Length > 5)
                        throw new Exception(Cadena);
                    else
                        Response.Redirect("frmInfoGesGsoProyectoRegistro.aspx?pOpera=edit&pId=" + pIdProyecto);
                    //Response.Redirect("frmInfoGesGsoProyectoRegistro.aspx?pOpera=edit&pId=" + (string)(Session["IdProyecto"]));

                }


        }
        #endregion


        #region ProyectoMeta
        #region OnLoadProyectoMeta
        protected void OnLoadProyectoMeta(object sender, EventArgs e)
        {
            this.SearchByProyectoMeta();
        }
        #endregion


        #region OnRowInsertingProyectoMeta
        protected void OnRowInsertingProyectoMeta(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            string pPeriodo, pMetaObra, pMetaSupervision, pMetaExpTecnico, pMetaInterferencia, pMetaGestionProyecto, pMetaTerreno, pMetaMobiliario, pMetaMitigacionAmbiental, pMetaFisicaProyectada;
            if (e.NewValues["PERIODO"] == null)
                pPeriodo = "";
            else
                pPeriodo = (e.NewValues["PERIODO"].ToString().Length == 0 ? "null" : e.NewValues["PERIODO"].ToString());

            if (e.NewValues["META_OBRA"] == null)
                pMetaObra = "";
            else
                pMetaObra = (e.NewValues["META_OBRA"].ToString().Length == 0 ? "null" : e.NewValues["META_OBRA"].ToString());

            if (e.NewValues["META_SUPERVISION"] == null)
                pMetaSupervision = "";
            else
                pMetaSupervision = (e.NewValues["META_SUPERVISION"].ToString().Length == 0 ? "null" : e.NewValues["META_SUPERVISION"].ToString());

            if (e.NewValues["META_EXP_TECNICO"] == null)
                pMetaExpTecnico = "";
            else
                pMetaExpTecnico = (e.NewValues["META_EXP_TECNICO"].ToString().Length == 0 ? "null" : e.NewValues["META_EXP_TECNICO"].ToString());

            if (e.NewValues["META_INTERFERENCIA"] == null)
                pMetaInterferencia = "";
            else
                pMetaInterferencia = (e.NewValues["META_INTERFERENCIA"].ToString().Length == 0 ? "null" : e.NewValues["META_INTERFERENCIA"].ToString());

            if (e.NewValues["META_GESTION_PROYECTO"] == null)
                pMetaGestionProyecto = "";
            else
                pMetaGestionProyecto = (e.NewValues["META_GESTION_PROYECTO"].ToString().Length == 0 ? "null" : e.NewValues["META_GESTION_PROYECTO"].ToString());

            if (e.NewValues["META_TERRENO"] == null)
                pMetaTerreno = "";
            else
                pMetaTerreno = (e.NewValues["META_TERRENO"].ToString().Length == 0 ? "null" : e.NewValues["META_TERRENO"].ToString());

            if (e.NewValues["META_MOBILIARIO"] == null)
                pMetaMobiliario = "";
            else
                pMetaMobiliario = (e.NewValues["META_MOBILIARIO"].ToString().Length == 0 ? "null" : e.NewValues["META_MOBILIARIO"].ToString());

            if (e.NewValues["META_MITIGACION_AMBIENTAL"] == null)
                pMetaMitigacionAmbiental = "";
            else
                pMetaMitigacionAmbiental = (e.NewValues["META_MITIGACION_AMBIENTAL"].ToString().Length == 0 ? "null" : e.NewValues["META_MITIGACION_AMBIENTAL"].ToString());

            if (e.NewValues["META_FISICA_PROYECTADA"] == null)
                pMetaFisicaProyectada = "";
            else
                pMetaFisicaProyectada = (e.NewValues["META_FISICA_PROYECTADA"].ToString().Length == 0 ? "null" : e.NewValues["META_FISICA_PROYECTADA"].ToString());



            //string Id = e.Keys["IDPROYECTO_DETALLE"].ToString();


            string[] parameters = { (string)(Session["pIdProyecto"]), pPeriodo, pMetaObra, pMetaSupervision, pMetaExpTecnico, pMetaInterferencia, pMetaGestionProyecto, pMetaTerreno, pMetaMobiliario, pMetaMitigacionAmbiental, pMetaFisicaProyectada };
            String LvCadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.InsertRowProyectoMeta(parameters);
            GridProyectoMeta.CancelEdit();
            e.Cancel = true;
            this.SearchByProyectoMeta();
        }
        #endregion

        #region OnRowUpdatingProyectoMeta
        protected void OnRowUpdatingProyectoMeta(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {


            string pPeriodo, pMetaObra, pMetaSupervision, pMetaExpTecnico, pMetaInterferencia, pMetaGestionProyecto, pMetaTerreno, pMetaMobiliario, pMetaMitigacionAmbiental, pMetaFisicaProyectada;
            string lcNombreCoordinador;
            if (e.NewValues["PERIODO"] == null)
                pPeriodo = "";
            else
                pPeriodo = (e.NewValues["PERIODO"].ToString().Length == 0 ? "null" : e.NewValues["PERIODO"].ToString());

            if (e.NewValues["META_OBRA"] == null)
                pMetaObra = "";
            else
                pMetaObra = (e.NewValues["META_OBRA"].ToString().Length == 0 ? "null" : e.NewValues["META_OBRA"].ToString());

            if (e.NewValues["META_SUPERVISION"] == null)
                pMetaSupervision = "";
            else
                pMetaSupervision = (e.NewValues["META_SUPERVISION"].ToString().Length == 0 ? "null" : e.NewValues["META_SUPERVISION"].ToString());

            if (e.NewValues["META_EXP_TECNICO"] == null)
                pMetaExpTecnico = "";
            else
                pMetaExpTecnico = (e.NewValues["META_EXP_TECNICO"].ToString().Length == 0 ? "null" : e.NewValues["META_EXP_TECNICO"].ToString());

            if (e.NewValues["META_INTERFERENCIA"] == null)
                pMetaInterferencia = "";
            else
                pMetaInterferencia = (e.NewValues["META_INTERFERENCIA"].ToString().Length == 0 ? "null" : e.NewValues["META_INTERFERENCIA"].ToString());

            if (e.NewValues["META_GESTION_PROYECTO"] == null)
                pMetaGestionProyecto = "";
            else
                pMetaGestionProyecto = (e.NewValues["META_GESTION_PROYECTO"].ToString().Length == 0 ? "null" : e.NewValues["META_GESTION_PROYECTO"].ToString());

            if (e.NewValues["META_TERRENO"] == null)
                pMetaTerreno = "";
            else
                pMetaTerreno = (e.NewValues["META_TERRENO"].ToString().Length == 0 ? "null" : e.NewValues["META_TERRENO"].ToString());

            if (e.NewValues["META_MOBILIARIO"] == null)
                pMetaMobiliario = "";
            else
                pMetaMobiliario = (e.NewValues["META_MOBILIARIO"].ToString().Length == 0 ? "null" : e.NewValues["META_MOBILIARIO"].ToString());

            if (e.NewValues["META_MITIGACION_AMBIENTAL"] == null)
                pMetaMitigacionAmbiental = "";
            else
                pMetaMitigacionAmbiental = (e.NewValues["META_MITIGACION_AMBIENTAL"].ToString().Length == 0 ? "null" : e.NewValues["META_MITIGACION_AMBIENTAL"].ToString());

            if (e.NewValues["META_FISICA_PROYECTADA"] == null)
                pMetaFisicaProyectada = "";
            else
                pMetaFisicaProyectada = (e.NewValues["META_FISICA_PROYECTADA"].ToString().Length == 0 ? "null" : e.NewValues["META_FISICA_PROYECTADA"].ToString());



            string Id = e.Keys["IDPROYECTO_DETALLE"].ToString();


            string[] parameters = { Id, pPeriodo, pMetaObra, pMetaSupervision, pMetaExpTecnico, pMetaInterferencia, pMetaGestionProyecto, pMetaTerreno, pMetaMobiliario, pMetaMitigacionAmbiental, pMetaFisicaProyectada };
            String LvCadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.UpdatedRowProyectoMeta(parameters, Id);
            GridProyectoMeta.CancelEdit();
            e.Cancel = true;
            this.SearchByProyectoMeta();
        }
        #endregion

        #region SearchByProyectoMeta
        private void SearchByProyectoMeta()
        {

            DataSet ds3 = new DataSet();
            ds3 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoMeta((string)(Session["pIdProyecto"]));
            GridProyectoMeta.KeyFieldName = "IDPROYECTO_DETALLE";
            GridProyectoMeta.DataSource = ds3.Tables[0];
            GridProyectoMeta.DataBind();
        }
        #endregion

        #endregion

        #region ProyectoComponente
        
        #region OnLoadProyectoComponente
        protected void OnLoadProyectoComponente(object sender, EventArgs e)
        {
            this.SearchByProyectoComponente();
        }
        #endregion

        #region SearchByProyectoComponente
        private void SearchByProyectoComponente()
        {

            DataSet ds3 = new DataSet();
            ds3 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoComponente((string)(Session["pIdProyecto"]));
            GridProyectoComponente.KeyFieldName = "IDPROYECTOCOMPONENTE";
            GridProyectoComponente.DataSource = ds3.Tables[0];
            GridProyectoComponente.DataBind();
        }
        #endregion

        #region OnRowInsertingProyectoComponente
        protected void OnRowInsertingProyectoComponente(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            string  pIdComponente, pIdEstadoComponente, pFechaConvocatoria, pFechaEstimadaBuenaPro, pFechaConsentimientoBuenaPro, pFechaEstimadaContrato, pfecha_estimada_inicio, pTiempoEjecucion, pFechaEntregaTerreno;

            if (e.NewValues["DESCRIPCION_COMPONENTE"] == null)
                pIdComponente = "";
            else
                pIdComponente = (e.NewValues["DESCRIPCION_COMPONENTE"].ToString().Length == 0 ? "null" : e.NewValues["DESCRIPCION_COMPONENTE"].ToString());

            if (e.NewValues["DESCRIPCION_ESTADO_COMPONENTE"] == null)
                pIdEstadoComponente = "";
            else
                pIdEstadoComponente = (e.NewValues["DESCRIPCION_ESTADO_COMPONENTE"].ToString().Length == 0 ? "null" : e.NewValues["DESCRIPCION_ESTADO_COMPONENTE"].ToString());

            if (e.NewValues["FECHA_CONVOCATORIA"] == null)
                pFechaConvocatoria = "";
            else
                pFechaConvocatoria = (e.NewValues["FECHA_CONVOCATORIA"].ToString().Length == 0 ? "null" : e.NewValues["FECHA_CONVOCATORIA"].ToString()).Substring(0, 10);
            
            if (e.NewValues["FECHA_ESTIMADA_BUENA_PRO"] == null)
                pFechaEstimadaBuenaPro = "";
            else
                pFechaEstimadaBuenaPro = (e.NewValues["FECHA_ESTIMADA_BUENA_PRO"].ToString().Length == 0 ? "null" : e.NewValues["FECHA_ESTIMADA_BUENA_PRO"].ToString()).Substring(0, 10);

            if (e.NewValues["FECHA_CONSENTIMIENTO_BUENA_PRO"] == null)
                pFechaConsentimientoBuenaPro = "";
            else
                pFechaConsentimientoBuenaPro = (e.NewValues["FECHA_CONSENTIMIENTO_BUENA_PRO"].ToString().Length == 0 ? "null" : e.NewValues["FECHA_CONSENTIMIENTO_BUENA_PRO"].ToString()).Substring(0, 10);

            if (e.NewValues["FECHA_ESTIMADA_CONTRATO"] == null)
                pFechaEstimadaContrato = "";
            else
                pFechaEstimadaContrato = (e.NewValues["FECHA_ESTIMADA_CONTRATO"].ToString().Length == 0 ? "null" : e.NewValues["FECHA_ESTIMADA_CONTRATO"].ToString()).Substring(0, 10);

            if (e.NewValues["FECHA_ESTIMADA_INICIO"] == null)
                pfecha_estimada_inicio = "";
            else
                pfecha_estimada_inicio = (e.NewValues["FECHA_ESTIMADA_INICIO"].ToString().Length == 0 ? "null" : e.NewValues["FECHA_ESTIMADA_INICIO"].ToString()).Substring(0, 10);

            if (e.NewValues["FECHA_ENTREGA_TERRENO"] == null)
                pFechaEntregaTerreno = "";
            else
                pFechaEntregaTerreno = (e.NewValues["FECHA_ENTREGA_TERRENO"].ToString().Length == 0 ? "null" : e.NewValues["FECHA_ENTREGA_TERRENO"].ToString()).Substring(0, 10);

            if (e.NewValues["TIEMPO_EJECUCION"] == null)
                pTiempoEjecucion = "";
            else
                pTiempoEjecucion = (e.NewValues["TIEMPO_EJECUCION"].ToString().Length == 0 ? "null" : e.NewValues["TIEMPO_EJECUCION"].ToString());

            //string Id = e.Keys["IDPROYECTO_DETALLE"].ToString();

            string[] parameters = { (string)(Session["pIdProyecto"]), pIdComponente, pIdEstadoComponente, pFechaConvocatoria, pFechaEstimadaBuenaPro, pFechaConsentimientoBuenaPro, pFechaEstimadaContrato, pfecha_estimada_inicio, pFechaEntregaTerreno, pTiempoEjecucion };
            String LvCadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.InsertRowProyectoComponente(parameters);
            GridProyectoComponente.CancelEdit();
            e.Cancel = true;
            this.SearchByProyectoComponente();
        }

        #region OnRowProyectoComponenteValidating
        protected void OnRowProyectoComponenteValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            foreach (GridViewColumn column in GridProyectoComponente.Columns)
            {
                GridViewDataColumn dataColumn = column as GridViewDataColumn;
                if (dataColumn == null) continue;
                if (e.NewValues[dataColumn.FieldName] == null)
                {
                    e.Errors[dataColumn] = "El valor no puede ser nulo.";
                }
            }
            if (e.Errors.Count > 0) e.RowError = "Por favor, llenar todos los campos.";
            if (e.NewValues["IDESTADO_COMPONENTE"] != null && e.NewValues["IDESTADO_COMPONENTE"].ToString().Length < 1)
            {
                AddErrorProyectoComponente(e.Errors, GridProyectoComponente.Columns["DESCRIPCION_COMPONENTE"], "Debe seleccionar un Componente...");
            }

            if (e.NewValues["IDESTADO_COMPONENTE"] != null && e.NewValues["IDESTADO_COMPONENTE"].ToString().Length < 1)
            {
                AddErrorProyectoComponente(e.Errors, GridProyectoComponente.Columns["IDESTADO_COMPONENTE"], "Debe seleccionar un estado del Componente...");
            }

            if (e.NewValues["TIEMPO_EJECUCION"] != null && e.NewValues["TIEMPO_EJECUCION"].ToString().Length < 1)
            {
                AddErrorProyectoComponente(e.Errors, GridProyectoComponente.Columns["TIEMPO_EJECUCION"], "Tiempo de ejecución debe ser > 0 ...");
            }

            if (string.IsNullOrEmpty(e.RowError) && e.Errors.Count > 0) e.RowError = "Por favor, corrija los errores.";
        }
        void AddErrorProyectoComponente(Dictionary<GridViewColumn, string> errors, GridViewColumn column, string errorText)
        {
            if (errors.ContainsKey(column)) return;
            errors[column] = errorText;
        }
        protected void grid_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            if (!object.Equals(e.RowType, GridViewRowType.Data)) return;

            bool hasError = string.IsNullOrEmpty(e.GetValue("DESCRIPCION_COMPONENTE").ToString());
            hasError = string.IsNullOrEmpty(e.GetValue("DESCRIPCION_ESTADO_COMPONENTE").ToString());
            hasError = hasError || (int)e.GetValue("DESCRIPCION_COMPONENTE") < 1;
            //hasError = hasError || (int)e.GetValue("DESCRIPCION_COMPONENTE") < 18;
            if (hasError)
            {
                e.Row.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void OnStartRowEditingProyectoComponente(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            if (!GridProyectoComponente.IsNewRowEditing)
            {
                GridProyectoComponente.DoRowValidation();
            }
        }
        #endregion

        #endregion

        #region OnRowUpdatingProyectoComponente
        protected void OnRowUpdatingProyectoComponente(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string pIdComponente, pIdEstadoComponente, pFechaConvocatoria, pFechaEstimadaBuenaPro, pFechaConsentimientoBuenaPro, pFechaEstimadaContrato, pfecha_estimada_inicio, pTiempoEjecucion, pFechaEntregaTerreno;

            if (e.NewValues["DESCRIPCION_COMPONENTE"] == null)
                pIdComponente = "";
            else
                pIdComponente = (e.NewValues["DESCRIPCION_COMPONENTE"].ToString().Length == 0 ? "null" : e.NewValues["DESCRIPCION_COMPONENTE"].ToString());

            if (e.NewValues["DESCRIPCION_ESTADO_COMPONENTE"] == null)
                pIdEstadoComponente = "";
            else
                pIdEstadoComponente = (e.NewValues["DESCRIPCION_ESTADO_COMPONENTE"].ToString().Length == 0 ? "null" : e.NewValues["DESCRIPCION_ESTADO_COMPONENTE"].ToString());

            if (e.NewValues["FECHA_CONVOCATORIA"] == null)
                pFechaConvocatoria = "";
            else
                pFechaConvocatoria = (e.NewValues["FECHA_CONVOCATORIA"].ToString().Length == 0 ? "null" : e.NewValues["FECHA_CONVOCATORIA"].ToString()).Substring(0, 10);

            if (e.NewValues["FECHA_ESTIMADA_BUENA_PRO"] == null)
                pFechaEstimadaBuenaPro = "";
            else
                pFechaEstimadaBuenaPro = (e.NewValues["FECHA_ESTIMADA_BUENA_PRO"].ToString().Length == 0 ? "null" : e.NewValues["FECHA_ESTIMADA_BUENA_PRO"].ToString()).Substring(0, 10);

            if (e.NewValues["FECHA_CONSENTIMIENTO_BUENA_PRO"] == null)
                pFechaConsentimientoBuenaPro = "";
            else
                pFechaConsentimientoBuenaPro = (e.NewValues["FECHA_CONSENTIMIENTO_BUENA_PRO"].ToString().Length == 0 ? "null" : e.NewValues["FECHA_CONSENTIMIENTO_BUENA_PRO"].ToString()).Substring(0, 10);

            if (e.NewValues["FECHA_ESTIMADA_CONTRATO"] == null)
                pFechaEstimadaContrato = "";
            else
                pFechaEstimadaContrato = (e.NewValues["FECHA_ESTIMADA_CONTRATO"].ToString().Length == 0 ? "null" : e.NewValues["FECHA_ESTIMADA_CONTRATO"].ToString()).Substring(0, 10);

            if (e.NewValues["FECHA_ESTIMADA_INICIO"] == null)
                pfecha_estimada_inicio = "";
            else
                pfecha_estimada_inicio = (e.NewValues["FECHA_ESTIMADA_INICIO"].ToString().Length == 0 ? "null" : e.NewValues["FECHA_ESTIMADA_INICIO"].ToString()).Substring(0, 10);

            if (e.NewValues["FECHA_ENTREGA_TERRENO"] == null)
                pFechaEntregaTerreno = "";
            else
                pFechaEntregaTerreno = (e.NewValues["FECHA_ENTREGA_TERRENO"].ToString().Length == 0 ? "null" : e.NewValues["FECHA_ENTREGA_TERRENO"].ToString()).Substring(0, 10);

            if (e.NewValues["TIEMPO_EJECUCION"] == null)
                pTiempoEjecucion = "";
            else
                pTiempoEjecucion = (e.NewValues["TIEMPO_EJECUCION"].ToString().Length == 0 ? "null" : e.NewValues["TIEMPO_EJECUCION"].ToString());

            string Id = e.Keys["IDPROYECTOCOMPONENTE"].ToString();

            string[] parameters = { (string)(Session["pIdProyecto"]), pIdComponente, pIdEstadoComponente, pFechaConvocatoria, pFechaEstimadaBuenaPro, pFechaConsentimientoBuenaPro, pFechaEstimadaContrato, pfecha_estimada_inicio, pFechaEntregaTerreno, pTiempoEjecucion };
            String LvCadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.UpdatedRowProyectoComponente(parameters, Id);
            GridProyectoComponente.CancelEdit();
            e.Cancel = true;
            this.SearchByProyectoComponente();
        }
        #endregion

        #region LoadCboComponente
        private void LoadCboComponente()
        {
            //if (Session["IdProyecto"] != null)
            //{
                DataSet ds2 = Code.Logic.Forms.Consulta.MaestroDetalle.SearchByMaestroDetalle("13");
                ((GridViewDataComboBoxColumn)GridProyectoComponente.Columns["DESCRIPCION_COMPONENTE"]).PropertiesComboBox.DataSource = ds2.Tables[0];
                ((GridViewDataComboBoxColumn)GridProyectoComponente.Columns["DESCRIPCION_COMPONENTE"]).PropertiesComboBox.TextField = ds2.Tables[0].Columns["ABREVIATURA"].Caption.ToString();
                ((GridViewDataComboBoxColumn)GridProyectoComponente.Columns["DESCRIPCION_COMPONENTE"]).PropertiesComboBox.ValueField = ds2.Tables[0].Columns["IDMAESTRO_DETALLE"].Caption.ToString();
                ds2.Dispose();
                ds2 = null;
            //}
        }
        #endregion

        #region LoadCboEstado
        private void LoadCboEstado()
        {
            //if (Session["IdProyecto"] != null)
            //{
                DataSet ds2 = Code.Logic.Forms.Consulta.MaestroDetalle.SearchByMaestroDetalle("11");
                ((GridViewDataComboBoxColumn)GridProyectoComponente.Columns["DESCRIPCION_ESTADO_COMPONENTE"]).PropertiesComboBox.DataSource = ds2.Tables[0];
                ((GridViewDataComboBoxColumn)GridProyectoComponente.Columns["DESCRIPCION_ESTADO_COMPONENTE"]).PropertiesComboBox.TextField = ds2.Tables[0].Columns["ABREVIATURA"].Caption.ToString();
                ((GridViewDataComboBoxColumn)GridProyectoComponente.Columns["DESCRIPCION_ESTADO_COMPONENTE"]).PropertiesComboBox.ValueField = ds2.Tables[0].Columns["IDMAESTRO_DETALLE"].Caption.ToString();
                ds2.Dispose();
                ds2 = null;
            //}
        }
        #endregion

        #region EditorInitializeProyectoComponente
        protected void EditorInitializeProyectoComponente(object sender, ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName == "DESCRIPCION_COMPONENTE")
            {
                ASPxComboBox combo = (ASPxComboBox)e.Editor;
                combo.DataBind();
            }
            if (e.Column.FieldName == "DESCRIPCION_ESTADO_COMPONENTE")
            {
                ASPxComboBox combo = (ASPxComboBox)e.Editor;
                combo.DataBind();
            }
        }
        #endregion

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
            ds3 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContrato((string)(Session["pIdProyecto"]));
            GridProyectoContrato.KeyFieldName = "IDCONTRATO";
            GridProyectoContrato.DataSource = ds3.Tables[0];
            GridProyectoContrato.DataBind();
        }
        #endregion

        #region OnRowInsertingProyectoContrato
        protected void OnRowInsertingProyectoContrato(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            string pNumeroContrato, pRuc, pEmpresa, pFechaContrato, pMontoObra, pPlazoEjecucionObra, pFechaInicioObra, pFechaInicioObraMaximo, pFechaAdelantoDirecto,
            pFechaAdelantoDirectoMax, pMontoAdelantoMateriales, pFechaAdelantoMaximoMateriales, pMontoAdelantoInstalacion, pFechaAdelantoMaximoInstalacion, pFechaEntregaTerreno, pFechaEntregaTerrenoLimite;


            if (e.NewValues["CONTRATO_NUMERO"] == null)
                pNumeroContrato = "";
            else
                pNumeroContrato = (e.NewValues["CONTRATO_NUMERO"].ToString().Length == 0 ? "null" : e.NewValues["CONTRATO_NUMERO"].ToString());

            if (e.NewValues["RUC"] == null)
                pRuc = "";
            else
                pRuc = (e.NewValues["RUC"].ToString().Length == 0 ? "null" : e.NewValues["RUC"].ToString());

            if (e.NewValues["EMPRESA"] == null)
                pEmpresa = "";
            else
                pEmpresa = (e.NewValues["EMPRESA"].ToString().Length == 0 ? "null" : e.NewValues["EMPRESA"].ToString());

            if (e.NewValues["FECHA_CONTRATO"] == null)
                pFechaContrato = "";
            else
                pFechaContrato = (e.NewValues["FECHA_CONTRATO"].ToString().Length == 0 ? "null" : e.NewValues["FECHA_CONTRATO"].ToString());

            if (e.NewValues["MONTO_OBRA"] == null)
                pMontoObra = "";
            else
                pMontoObra = (e.NewValues["MONTO_OBRA"].ToString().Length == 0 ? "null" : e.NewValues["MONTO_OBRA"].ToString());

            if (e.NewValues["PLAZO_EJECUCION_OBRA"] == null)
                pPlazoEjecucionObra = "";
            else
                pPlazoEjecucionObra = (e.NewValues["PLAZO_EJECUCION_OBRA"].ToString().Length == 0 ? "null" : e.NewValues["PLAZO_EJECUCION_OBRA"].ToString());

            if (e.NewValues["FECHA_INICIO_OBRA"] == null)
                pFechaInicioObra = "";
            else
                pFechaInicioObra = (e.NewValues["FECHA_INICIO_OBRA"].ToString().Length == 0 ? "null" : e.NewValues["FECHA_INICIO_OBRA"].ToString());

            if (e.NewValues["FECHA_INICIO_OBRA_MAXIMO"] == null)
                pFechaInicioObraMaximo = "";
            else
                pFechaInicioObraMaximo = (e.NewValues["FECHA_INICIO_OBRA_MAXIMO"].ToString().Length == 0 ? "null" : e.NewValues["FECHA_INICIO_OBRA_MAXIMO"].ToString());



            if (e.NewValues["FECHA_ADELANTO_DIRECTO"] == null)
                pFechaAdelantoDirecto= "";
            else
                pFechaAdelantoDirecto = (e.NewValues["FECHA_ADELANTO_DIRECTO"].ToString().Length == 0 ? "null" : e.NewValues["FECHA_ADELANTO_DIRECTO"].ToString());


            if (e.NewValues["FECHA_ADELANTO_DIRECTO_MAX"] == null)
                pFechaAdelantoDirectoMax = "";
            else
                pFechaAdelantoDirectoMax = (e.NewValues["FECHA_ADELANTO_DIRECTO_MAX"].ToString().Length == 0 ? "null" : e.NewValues["FECHA_ADELANTO_DIRECTO_MAX"].ToString());

            if (e.NewValues["MONTO_ADELANTO_MATERIALES"] == null)
                pMontoAdelantoMateriales = "";
            else
                pMontoAdelantoMateriales  = (e.NewValues["MONTO_ADELANTO_MATERIALES"].ToString().Length == 0 ? "null" : e.NewValues["MONTO_ADELANTO_MATERIALES"].ToString());

            if (e.NewValues["FECHA_ADELANTO_MAXIMO_MATERIALES"] == null)
                pFechaAdelantoMaximoMateriales = "";
            else
                pFechaAdelantoMaximoMateriales = (e.NewValues["FECHA_ADELANTO_MAXIMO_MATERIALES"].ToString().Length == 0 ? "null" : e.NewValues["FECHA_ADELANTO_MAXIMO_MATERIALES"].ToString());



            if (e.NewValues["MONTO_ADELANTO_INSTALACION"] == null)
                pMontoAdelantoInstalacion = "";
            else
                pMontoAdelantoInstalacion = (e.NewValues["MONTO_ADELANTO_INSTALACION"].ToString().Length == 0 ? "null" : e.NewValues["MONTO_ADELANTO_INSTALACION"].ToString());

            if (e.NewValues["FECHA_ADELANTO_MAXIMO_INSTALACION"] == null)
                pFechaAdelantoMaximoInstalacion = "";
            else
                pFechaAdelantoMaximoInstalacion = (e.NewValues["FECHA_ADELANTO_MAXIMO_INSTALACION"].ToString().Length == 0 ? "null" : e.NewValues["FECHA_ADELANTO_MAXIMO_INSTALACION"].ToString());

            if (e.NewValues["FECHA_ENTREGA_TERRENO"] == null)
                pFechaEntregaTerreno = "";
            else
                pFechaEntregaTerreno = (e.NewValues["FECHA_ENTREGA_TERRENO"].ToString().Length == 0 ? "null" : e.NewValues["FECHA_ENTREGA_TERRENO"].ToString());

            if (e.NewValues["FECHA_ENTREGA_TERRENO_LIMITE"] == null)
                pFechaEntregaTerrenoLimite = "";
            else
                pFechaEntregaTerrenoLimite = (e.NewValues["FECHA_ENTREGA_TERRENO_LIMITE"].ToString().Length == 0 ? "null" : e.NewValues["FECHA_ENTREGA_TERRENO_LIMITE"].ToString());

            string IdProyectoComponente = GridProyectoComponente.GetRowValues(GridProyectoComponente.FocusedRowIndex, "IDPROYECTOCOMPONENTE").ToString();

            //string Id = e.Keys["IDPROYECTO_DETALLE"].ToString();
            string IdComponente = GridProyectoComponente.GetRowValues(GridProyectoComponente.FocusedRowIndex, "IDCOMPONENTE").ToString();
            string[] parameters = { IdProyectoComponente, pNumeroContrato, pRuc, pEmpresa, pFechaContrato, pMontoObra, pPlazoEjecucionObra, pFechaInicioObra, pFechaInicioObraMaximo, pFechaAdelantoDirecto,
            pFechaAdelantoDirectoMax, pMontoAdelantoMateriales, pFechaAdelantoMaximoMateriales, pMontoAdelantoInstalacion, pFechaAdelantoMaximoInstalacion, pFechaEntregaTerreno, pFechaEntregaTerrenoLimite,IdComponente};
            String LvCadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.InsertProyectoContrato(parameters);
            GridProyectoContrato.CancelEdit();
            e.Cancel = true;
            this.SearchByProyectoContrato();
        }
        #endregion

        #region OnRowUpdatingProyectoContrato
        protected void OnRowUpdatingProyectoContrato(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string pNumeroContrato, pRuc, pEmpresa, pFechaContrato, pMontoObra, pPlazoEjecucionObra, pFechaInicioObra, pFechaInicioObraMaximo, pFechaAdelantoDirecto,
            pFechaAdelantoDirectoMax, pMontoAdelantoMateriales, pFechaAdelantoMaximoMateriales, pMontoAdelantoInstalacion, pFechaAdelantoMaximoInstalacion, pFechaEntregaTerreno, pFechaEntregaTerrenoLimite;


            if (e.NewValues["CONTRATO_NUMERO"] == null)
                pNumeroContrato = "";
            else
                pNumeroContrato = (e.NewValues["CONTRATO_NUMERO"].ToString().Length == 0 ? "null" : e.NewValues["CONTRATO_NUMERO"].ToString());

            if (e.NewValues["RUC"] == null)
                pRuc = "";
            else
                pRuc = (e.NewValues["RUC"].ToString().Length == 0 ? "null" : e.NewValues["RUC"].ToString());

            if (e.NewValues["EMPRESA"] == null)
                pEmpresa = "";
            else
                pEmpresa = (e.NewValues["EMPRESA"].ToString().Length == 0 ? "null" : e.NewValues["EMPRESA"].ToString());

            if (e.NewValues["FECHA_CONTRATO"] == null)
                pFechaContrato = "";
            else
                pFechaContrato = (e.NewValues["FECHA_CONTRATO"].ToString().Length == 0 ? "null" : e.NewValues["FECHA_CONTRATO"].ToString());

            if (e.NewValues["MONTO_OBRA"] == null)
                pMontoObra = "";
            else
                pMontoObra = (e.NewValues["MONTO_OBRA"].ToString().Length == 0 ? "null" : e.NewValues["MONTO_OBRA"].ToString());

            if (e.NewValues["PLAZO_EJECUCION_OBRA"] == null)
                pPlazoEjecucionObra = "";
            else
                pPlazoEjecucionObra = (e.NewValues["PLAZO_EJECUCION_OBRA"].ToString().Length == 0 ? "null" : e.NewValues["PLAZO_EJECUCION_OBRA"].ToString());

            if (e.NewValues["FECHA_INICIO_OBRA"] == null)
                pFechaInicioObra = "";
            else
                pFechaInicioObra = (e.NewValues["FECHA_INICIO_OBRA"].ToString().Length == 0 ? "null" : e.NewValues["FECHA_INICIO_OBRA"].ToString());

            if (e.NewValues["FECHA_INICIO_OBRA_MAXIMO"] == null)
                pFechaInicioObraMaximo = "";
            else
                pFechaInicioObraMaximo = (e.NewValues["FECHA_INICIO_OBRA_MAXIMO"].ToString().Length == 0 ? "null" : e.NewValues["FECHA_INICIO_OBRA_MAXIMO"].ToString());



            if (e.NewValues["FECHA_ADELANTO_DIRECTO"] == null)
                pFechaAdelantoDirecto = "";
            else
                pFechaAdelantoDirecto = (e.NewValues["FECHA_ADELANTO_DIRECTO"].ToString().Length == 0 ? "null" : e.NewValues["FECHA_ADELANTO_DIRECTO"].ToString());


            if (e.NewValues["FECHA_ADELANTO_DIRECTO_MAX"] == null)
                pFechaAdelantoDirectoMax = "";
            else
                pFechaAdelantoDirectoMax = (e.NewValues["FECHA_ADELANTO_DIRECTO_MAX"].ToString().Length == 0 ? "null" : e.NewValues["FECHA_ADELANTO_DIRECTO_MAX"].ToString());

            if (e.NewValues["MONTO_ADELANTO_MATERIALES"] == null)
                pMontoAdelantoMateriales = "";
            else
                pMontoAdelantoMateriales = (e.NewValues["MONTO_ADELANTO_MATERIALES"].ToString().Length == 0 ? "null" : e.NewValues["MONTO_ADELANTO_MATERIALES"].ToString());

            if (e.NewValues["FECHA_ADELANTO_MAXIMO_MATERIALES"] == null)
                pFechaAdelantoMaximoMateriales = "";
            else
                pFechaAdelantoMaximoMateriales = (e.NewValues["FECHA_ADELANTO_MAXIMO_MATERIALES"].ToString().Length == 0 ? "null" : e.NewValues["FECHA_ADELANTO_MAXIMO_MATERIALES"].ToString());



            if (e.NewValues["MONTO_ADELANTO_INSTALACION"] == null)
                pMontoAdelantoInstalacion = "";
            else
                pMontoAdelantoInstalacion = (e.NewValues["MONTO_ADELANTO_INSTALACION"].ToString().Length == 0 ? "null" : e.NewValues["MONTO_ADELANTO_INSTALACION"].ToString());

            if (e.NewValues["FECHA_ADELANTO_MAXIMO_INSTALACION"] == null)
                pFechaAdelantoMaximoInstalacion = "";
            else
                pFechaAdelantoMaximoInstalacion = (e.NewValues["FECHA_ADELANTO_MAXIMO_INSTALACION"].ToString().Length == 0 ? "null" : e.NewValues["FECHA_ADELANTO_MAXIMO_INSTALACION"].ToString());

            if (e.NewValues["FECHA_ENTREGA_TERRENO"] == null)
                pFechaEntregaTerreno = "";
            else
                pFechaEntregaTerreno = (e.NewValues["FECHA_ENTREGA_TERRENO"].ToString().Length == 0 ? "null" : e.NewValues["FECHA_ENTREGA_TERRENO"].ToString());

            if (e.NewValues["FECHA_ENTREGA_TERRENO_LIMITE"] == null)
                pFechaEntregaTerrenoLimite = "";
            else
                pFechaEntregaTerrenoLimite = (e.NewValues["FECHA_ENTREGA_TERRENO_LIMITE"].ToString().Length == 0 ? "null" : e.NewValues["FECHA_ENTREGA_TERRENO_LIMITE"].ToString());

            string IdProyectoComponente = GridProyectoComponente.GetRowValues(GridProyectoComponente.FocusedRowIndex, "IDPROYECTOCOMPONENTE").ToString();
            string IdComponente = GridProyectoComponente.GetRowValues(GridProyectoComponente.FocusedRowIndex, "IDCOMPONENTE").ToString();
            string Id = e.Keys["IDCONTRATO"].ToString();
            string[] parameters = { Id, pNumeroContrato, pRuc, pEmpresa, pFechaContrato, pMontoObra, pPlazoEjecucionObra, pFechaInicioObra, pFechaInicioObraMaximo, pFechaAdelantoDirecto,
            pFechaAdelantoDirectoMax, pMontoAdelantoMateriales, pFechaAdelantoMaximoMateriales, pMontoAdelantoInstalacion, pFechaAdelantoMaximoInstalacion, pFechaEntregaTerreno, pFechaEntregaTerrenoLimite};
            String LvCadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.UpdatedProyectoContrato(parameters);
            GridProyectoContrato.CancelEdit();
            e.Cancel = true;
            this.SearchByProyectoContrato();
        }
        #endregion

        #region OnRowDeletingProyectoContrato
        protected void OnRowDeletingProyectoContrato(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string Id = e.Keys["IDCONTRATO"].ToString();
            string Cadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.DeletedRowProyectoContrato(Id);
            GridProyectoContrato.CancelEdit();
            e.Cancel = true;
            this.SearchByProyectoContrato();
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
            string contentUrl = (string)Session["baseURL"] + "?tipo=2&codigo=" + pId; //version anterior  http://ofi5.mef.gob.pe/ssi/Inicio.aspx
 
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
            ds3 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoCronograma((string)(Session["pIdProyecto"]));
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
                pCronogramaFecha= "";
            else
                pCronogramaFecha= (e.NewValues["CRONOGRAMA_FECHA"].ToString().Length == 0 ? "null" : e.NewValues["CRONOGRAMA_FECHA"].ToString());

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
            ds3 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoSeguimiento((string)(Session["pIdProyecto"]));
            GridProyectoSupervision.KeyFieldName = "IDCONTRATOSEGUIMIENTO";
            GridProyectoSupervision.DataSource = ds3.Tables[0];
            GridProyectoSupervision.DataBind();
        }
        #endregion


        #region OnRowInsertingContratoSupervision
        protected void OnRowInsertingContratoSupervision(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {

            string pValorizaconFecha, pValorizacionNumero,  pAvance;

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

            string[] parameters = { IdContrato, pValorizaconFecha, pValorizacionNumero,  pAvance };
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
            string Cadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.DeletedRowContratoValorizacion(Id);
            GridProyectoSupervision.CancelEdit();
            e.Cancel = true;
            this.SearchByContratoSupervision();
        }
        #endregion

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

            DataSet ds3 = new DataSet();
            ds3 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoValorizacion((string)(Session["pIdProyecto"]));
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

            DataSet ds3 = new DataSet();
            ds3 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoAdelanto((string)(Session["pIdProyecto"]));
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

            if (e.NewValues["TIPOADELANTO"] == null)
                pAvance = "";
            else
                pAvance = (e.NewValues["TIPOADELANTO"].ToString().Length == 0 ? "null" : e.NewValues["TIPOADELANTO"].ToString());

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

            if (e.NewValues["TIPOADELANTO"] == null)
                pAvance = "";
            else
                pAvance = (e.NewValues["TIPOADELANTO"].ToString().Length == 0 ? "null" : e.NewValues["TIPOADELANTO"].ToString());

            if (e.NewValues["ADELANTO_IMPORTE"] == null)
                pAdelantoImporte = "";
            else
                pAdelantoImporte = (e.NewValues["Adelanto_IMPORTE"].ToString().Length == 0 ? "null" : e.NewValues["ADELANTO_IMPORTE"].ToString());


            string Id = e.Keys["IDCONTRATOAdelanto"].ToString();
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
            string Id = e.Keys["IDCONTRATOAdelanto"].ToString();
            string Cadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.DeletedRowContratoAdelanto(Id);
            GridProyectoAdelanto.CancelEdit();
            e.Cancel = true;
            this.SearchByContratoAdelanto();
        }
        #endregion

        #endregion


        #region LoadCboPaquete
        protected void LoadCboPaquete()
        {
            DataSet ds1 = Code.Logic.Forms.Consulta.MaestroDetalle.SearchByMaestroDetalle("8");

            CboPaquete.DataSource = ds1.Tables[0];
            CboPaquete.TextField = ds1.Tables[0].Columns["ABREVIATURA"].Caption.ToString();
            CboPaquete.ValueField = ds1.Tables[0].Columns["IDMAESTRO_DETALLE"].Caption.ToString();
            CboPaquete.DataBind();
            ds1.Dispose();
            ds1 = null;
        }
        #endregion

        #region LoadActividad
        protected void LoadActividad()
        {
            DataSet ds1 = Code.Logic.Forms.Consulta.MaestroDetalle.SearchByMaestroDetalle("9");

            CboActividad.DataSource = ds1.Tables[0];
            CboActividad.TextField = ds1.Tables[0].Columns["ABREVIATURA"].Caption.ToString();
            CboActividad.ValueField = ds1.Tables[0].Columns["IDMAESTRO_DETALLE"].Caption.ToString();
            CboActividad.DataBind();
            ds1.Dispose();
            ds1 = null;
        }
        #endregion

        #region LoadTipoProyecto
        protected void LoadTipoProyecto()
        {
            DataSet ds1 = Code.Logic.Forms.Consulta.MaestroDetalle.SearchByMaestroDetalle("7");

            CboTipoProyecto.DataSource = ds1.Tables[0];
            CboTipoProyecto.TextField = ds1.Tables[0].Columns["ABREVIATURA"].Caption.ToString();
            CboTipoProyecto.ValueField = ds1.Tables[0].Columns["IDMAESTRO_DETALLE"].Caption.ToString();
            CboTipoProyecto.DataBind();
            ds1.Dispose();
            ds1 = null;
        }
        #endregion
    }
}