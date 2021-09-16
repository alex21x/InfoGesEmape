using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using System.Data;
using System.IO;
using System.Net;
using DevExpress.Spreadsheet;
using QRCoder;
using System.Drawing;
using MessagingToolkit.QRCode.Codec;



namespace InfogesEmape.Modules.Forms.Seguimiento
{
    public partial class frmInfoGesGsoProyectoRegistro : System.Web.UI.Page
    {
        private string pIdOPeracion;
        private string pIdProyecto;
        private Int32 pnContrato=0;


        #region PageInit
        protected void Page_Init(object sender, EventArgs e)
        {
            this.LoadCboEstado();
            this.LoadCboComponente();
            this.LoadCboEstadoContrato();
            this.LoadCboTipoLogia();
			this.LoadCboMedida();
			this.LoadCboPartida();            
			this.LoadCboPolinomica();
            //if (Session["PdfFile"] != null)
            //{
            //    viewer.PdfData = (byte[])Session["PdfFile"];
            //}
        }
        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            InfogesEmape.Modules.MasterPage m = (InfogesEmape.Modules.MasterPage)Page.Master;
            pIdOPeracion = "" + Request.Params["pOpera"];
            pIdProyecto = "" + Request.Params["pId"];
            Session["pIdProyecto"] = pIdProyecto;
            pIdProyecto = (pIdProyecto.ToString().Length == 0 ? "0" : pIdProyecto.ToString());
									
			LBLSUB.Text = "";
			LBLIGV.Text = "";
			LBLTOTAL.Text = "";            

            if (!Page.IsPostBack && !IsCallback)
            {

                //m.SetTitleText = "Registro del Contrato";
                this.LoadCboPaquete();
                this.LoadActividad();
                this.LoadTipoProyecto();
				//this.GridPolinomica();

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

            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.Button1);
            scriptManager.RegisterPostBackControl(this.Button2);
			scriptManager.RegisterPostBackControl(this.Button3);
			scriptManager.RegisterPostBackControl(this.Button4);
			//GridContratoPartida.CollapseAllGroups();

			GridContratoPartida.SettingsBehavior.AutoExpandAllGroups = true;

            this.GridContratoPartida.Columns["LEV2"].Visible = false;
            this.GridContratoPartida.Columns["LEV1"].Visible = false;
        }
        #endregion



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



                    this.TXTUTILIDAD.Text = ds1.Tables[0].Rows[0]["PCUTILIDADES"].ToString();
                    this.TxtGastosGenerales.Text = ds1.Tables[0].Rows[0]["PCGASTOS_GENERALES"].ToString();
					this.TXTGASTOSOTROS.Text = ds1.Tables[0].Rows[0]["PCGASTOS_OTROS"].ToString();
					this.TXTADELANTODIRECTO.Text = ds1.Tables[0].Rows[0]["PCADELANTODIRECTO"].ToString();
					this.TXTADELANTOMATERIALES.Text = ds1.Tables[0].Rows[0]["PCADELANTOMATERIALES"].ToString();
					this.TXTADELANTOOTROS.Text = ds1.Tables[0].Rows[0]["PCADELANTOOTROS"].ToString();


					this.GridProyectoMeta.Visible = true;
                    this.GridProyectoComponente.Visible = true;
                    this.GridProyectoContrato.Visible = true;
                    this.GridProyectoProgramacion.Visible = true;
                    this.GridProyectoSupervision.Visible = true;
                    this.GridProyectoValorizacion.Visible = false;
                    ASPxPageControl1.TabPages.FindByName("Page3").ClientVisible = true;
                    ASPxPageControl1.TabPages.FindByName("Page4").ClientVisible = true;
                    ASPxPageControl1.TabPages.FindByName("Page5").ClientVisible = true;
                    ASPxPageControl1.TabPages.FindByName("Page6").ClientVisible = true;
 
                    
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


					this.TXTUTILIDAD.Text = "0";
					this.TxtGastosGenerales.Text = "0";
					this.TXTADELANTODIRECTO.Text = "0";
					this.TXTADELANTOMATERIALES.Text = "0";
					this.TXTADELANTOOTROS.Text = "0";


					ASPxPageControl1.TabPages.FindByName("Page3").ClientVisible = false; 
                    ASPxPageControl1.TabPages.FindByName("Page4").ClientVisible = false;
                    ASPxPageControl1.TabPages.FindByName("Page5").ClientVisible = false;
                    ASPxPageControl1.TabPages.FindByName("Page6").ClientVisible = false;
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

            //SearchContratoById()
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
            if (pIdProyecto != "0")
            {
                DataSet ds3 = new DataSet();
                ds3 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoMeta((string)(Session["pIdProyecto"]));
                GridProyectoMeta.KeyFieldName = "IDPROYECTO_DETALLE";
                GridProyectoMeta.DataSource = ds3.Tables[0];
                GridProyectoMeta.DataBind();
            }
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
            if (pIdProyecto != "0")
            {

                DataSet ds3 = new DataSet();
                ds3 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoComponente((string)(Session["pIdProyecto"]));
                GridProyectoComponente.KeyFieldName = "IDPROYECTOCOMPONENTE";
                GridProyectoComponente.DataSource = ds3.Tables[0];
                GridProyectoComponente.DataBind();
            }
        }
        #endregion

        #region OnRowInsertingProyectoComponente
        protected void OnRowInsertingProyectoComponente(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            string  pIdComponente, pIdEstadoComponente, pFechaConvocatoria, pFechaEstimadaBuenaPro, pFechaConsentimientoBuenaPro, pFechaEstimadaContrato, pfecha_estimada_inicio, pTiempoEjecucion, pFechaEntregaTerreno, pAbreviatura;

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

            if (e.NewValues["ABREVIATURA"] == null)
                pAbreviatura = "";
            else
                pAbreviatura = (e.NewValues["ABREVIATURA"].ToString().Length == 0 ? "null" : e.NewValues["ABREVIATURA"].ToString());

            //string Id = e.Keys["IDPROYECTO_DETALLE"].ToString();

            string[] parameters = { (string)(Session["pIdProyecto"]), pIdComponente, pIdEstadoComponente, pFechaConvocatoria, pFechaEstimadaBuenaPro, pFechaConsentimientoBuenaPro, pFechaEstimadaContrato, pfecha_estimada_inicio, pFechaEntregaTerreno, pTiempoEjecucion, pAbreviatura };
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
            string pAbreviatura,pIdComponente, pIdEstadoComponente, pFechaConvocatoria, pFechaEstimadaBuenaPro, pFechaConsentimientoBuenaPro, pFechaEstimadaContrato, pfecha_estimada_inicio, pTiempoEjecucion, pFechaEntregaTerreno;


            if (e.NewValues["DESCRIPCION_COMPONENTE"].ToString() != e.OldValues["DESCRIPCION_COMPONENTE"].ToString())
                if (e.NewValues["DESCRIPCION_COMPONENTE"] == null)
                    pIdComponente = "";
                else
                    pIdComponente = (e.NewValues["DESCRIPCION_COMPONENTE"].ToString().Length == 0 ? "null" : e.NewValues["DESCRIPCION_COMPONENTE"].ToString());
            else
                pIdComponente = "NCN";


            if (e.NewValues["DESCRIPCION_ESTADO_COMPONENTE"].ToString() != e.OldValues["DESCRIPCION_ESTADO_COMPONENTE"].ToString())
                if (e.NewValues["DESCRIPCION_ESTADO_COMPONENTE"] == null)
                    pIdEstadoComponente = "";
                else
                    pIdEstadoComponente = (e.NewValues["DESCRIPCION_ESTADO_COMPONENTE"].ToString().Length == 0 ? "null" : e.NewValues["DESCRIPCION_ESTADO_COMPONENTE"].ToString());
            else
                pIdEstadoComponente = "NCN";



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

            if (e.NewValues["ABREVIATURA"] == null)
                pAbreviatura = "";
            else
                pAbreviatura = (e.NewValues["ABREVIATURA"].ToString().Length == 0 ? "null" : e.NewValues["ABREVIATURA"].ToString());
            string Id = e.Keys["IDPROYECTOCOMPONENTE"].ToString();

            string[] parameters = { (string)(Session["pIdProyecto"]), pIdComponente, pIdEstadoComponente, pFechaConvocatoria, pFechaEstimadaBuenaPro, pFechaConsentimientoBuenaPro, pFechaEstimadaContrato, pfecha_estimada_inicio, pFechaEntregaTerreno, pTiempoEjecucion, pAbreviatura };
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

        #region LoadCboEstadoContrato
        private void LoadCboEstadoContrato()
        {
            //if (pIdProyecto != null)
            //{
                DataSet ds2 = Code.Logic.Forms.Consulta.MaestroDetalle.SearchByMaestroDetalle("15");
                ((GridViewDataComboBoxColumn)GridProyectoContrato.Columns["DESCRIPCION_ESTADO_CONTRATO"]).PropertiesComboBox.DataSource = ds2.Tables[0];
                ((GridViewDataComboBoxColumn)GridProyectoContrato.Columns["DESCRIPCION_ESTADO_CONTRATO"]).PropertiesComboBox.TextField = ds2.Tables[0].Columns["ABREVIATURA"].Caption.ToString();
                ((GridViewDataComboBoxColumn)GridProyectoContrato.Columns["DESCRIPCION_ESTADO_CONTRATO"]).PropertiesComboBox.ValueField = ds2.Tables[0].Columns["IDMAESTRO_DETALLE"].Caption.ToString();
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

		/*CAMBIO						FECHA			AUTOR
		SELECT	PARTIDA					22-06-2021	    ALEXANDER FERNÁNDEZ 22-06-2021*/
		#region Partida
		#region OnLoadPartida
		protected void OnLoadPartida(object sender, EventArgs e)
		{
			this.SearchPartida();
		}
		#endregion

		#region SearchPartida
		private void SearchPartida()
		{
			DataSet ds3 = new DataSet();

			ds3 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByPartida();
			//pnPartida = ds4.Tables[0].Rows.Count;

			GridPartida.KeyFieldName = "IDPARTIDA";
			GridPartida.DataSource = ds3.Tables[0];
			GridPartida.DataBind();
		}

		#endregion


		/*CAMBIO						FECHA			AUTOR
		INSERT PARTIDA	22-06-2021	    ALEXANDER FERNÁNDEZ 01-06-2021*/
		#region OnRowInsertingPartida
		protected void OnRowInsertingPartida(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
		{
            string pNombre, pMedida;
            

            if (e.NewValues["PAR_NOMBRE"] == null)
                pNombre = "";
            else
                pNombre = (e.NewValues["PAR_NOMBRE"].ToString().Length == 0 ? "null" : e.NewValues["PAR_NOMBRE"].ToString());


            if (e.NewValues["PAR_MEDIDA"] == null)
                pMedida = "0";
            else
                pMedida = (e.NewValues["PAR_MEDIDA"].ToString().Length == 0 ? "null" : e.NewValues["PAR_MEDIDA"].ToString());
            

            //string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();
            string[] parameters = { pNombre, pMedida };

            string LvCadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.InsertRowPartida(parameters);
            GridPartida.CancelEdit();
            e.Cancel = true;
            this.SearchPartida();
        }

		#endregion


		/*CAMBIO						FECHA			AUTOR
		UPDATE PARTIDA	22-06-2021	    ALEXANDER FERNÁNDEZ 01-06-2021*/
		#region OnRowUpdatingPartida
		protected void OnRowUpdatingPartida(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
		{
            string pNombre, pMedida = "";            

            if (e.NewValues["PAR_NOMBRE"] == null)
                pNombre = "";
            else
                pNombre = (e.NewValues["PAR_NOMBRE"].ToString().Length == 0 ? "null" : e.NewValues["PAR_NOMBRE"].ToString());


            if (e.NewValues["PAR_MEDIDA"].ToString() != e.OldValues["PAR_MEDIDA"].ToString())
                if (e.NewValues["PAR_MEDIDA"] == null)
                    pMedida = "";
                else
					pMedida = (e.NewValues["PAR_MEDIDA"].ToString().Length == 0 ? "null" : e.NewValues["PAR_MEDIDA"].ToString());
            else
                pMedida = "NCN";
			
            string Id = e.Keys["IDPARTIDA"].ToString();
            //string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();
            string[] parameters = { pNombre, pMedida };

            string LvCadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.UpdateRowPartida(parameters, Id);
            GridPartida.CancelEdit();
            e.Cancel = true;
            this.SearchPartida();
        }

		#endregion
		#endregion


		/*CAMBIO						FECHA			AUTOR
		DELETE PARTIDA					22-06-2021	    ALEXANDER FERNÁNDEZ 02-09-2021*/
		#region OnRowDeleteRowPartida
		protected void GridPartida_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
		{
			string Id = e.Keys["IDPARTIDA"].ToString();
			string Cadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.DeleteRowPartida(Id);
			GridPartida.CancelEdit();
			e.Cancel = true;
			this.SearchPartida();
		}
		#endregion

		/*CAMBIO						FECHA			AUTOR
		SELECT	CONTRATO PARTIDA		21-06-2021	    ALEXANDER FERNÁNDEZ 21-06-2021*/
		#region ContratoPartida
		#region OnLoadContratoPartida
		protected void OnLoadContratoPartida(object sender, EventArgs e)
		{                       
            this.SearchContratoPartida();            
            //SearchContratoById();
        }
		#endregion

		#region SearchContratoPartida
		private void SearchContratoPartida()
		{

            if (pnContrato != 0)
            {
                DataSet ds4 = new DataSet();
                string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();
                ds4 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByContratoPartida(IdContrato);                

                GridContratoPartida.KeyFieldName = "IDCONTRATOPARTIDA";
                GridContratoPartida.DataSource = ds4.Tables[0];
                GridContratoPartida.DataBind();
                Calcular();
            }
        }        
        #endregion

        /*CAMBIO						FECHA			AUTOR
		INSERT CONTRATO PARTIDA			22-06-2021	    ALEXANDER FERNÁNDEZ 22-06-2021*/
        #region OnRowInsertingPartida
        protected void OnRowInsertingContratoPartida(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
		{
			string pNombre, pPrecio, pCantidad,pCodigo;
			if (e.NewValues["PAR_NOMBRE"] == null)
				pNombre = "";
			else
				pNombre = (e.NewValues["PAR_NOMBRE"].ToString().Length == 0 ? "null" : e.NewValues["PAR_NOMBRE"].ToString());			

			if (e.NewValues["PAR_PRECIO"] == null)
				pPrecio = "0";
			else
				pPrecio = (e.NewValues["PAR_PRECIO"].ToString().Length == 0 ? "null" : e.NewValues["PAR_PRECIO"].ToString());

			if (e.NewValues["PAR_CANTIDAD"] == null)
				pCantidad = "0";
			else
				pCantidad = (e.NewValues["PAR_CANTIDAD"].ToString().Length == 0 ? "null" : e.NewValues["PAR_CANTIDAD"].ToString());

			if (e.NewValues["CTP_CODIGO"] == null)
				pCodigo = "0";
			else
				pCodigo = (e.NewValues["CTP_CODIGO"].ToString().Length == 0 ? "null" : e.NewValues["CTP_CODIGO"].ToString());

			string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();

			String[] parameters = { IdContrato, pNombre, pPrecio , pCantidad, pCodigo };

			string LvCadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.InsertRowContratoPartida(parameters);
			GridContratoPartida.CancelEdit();
			e.Cancel = true;
			this.SearchContratoPartida();
		}
		#endregion

		/*CAMBIO						FECHA			AUTOR
		UPDATE CONTRATO PARTIDA			22-06-2021	    ALEXANDER FERNÁNDEZ 22-06-2021*/
		#region OnRowUpdatingContratoPartida
		protected void OnRowUpdatingContratoPartida(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
		{
			string pNombre, pPrecio, pCantidad, pCodigo;

			if (e.NewValues["PAR_NOMBRE"].ToString() != e.OldValues["PAR_NOMBRE"].ToString())
				if (e.NewValues["PAR_NOMBRE"] == null)
					pNombre = "";
				else
					pNombre = (e.NewValues["PAR_NOMBRE"].ToString().Length == 0 ? "null" : e.NewValues["PAR_NOMBRE"].ToString());
			else
				pNombre = "NCN";			

			if (e.NewValues["PAR_PRECIO"] == null)
				pPrecio = "0";
			else
				pPrecio = (e.NewValues["PAR_PRECIO"].ToString().Length == 0 ? "null" : e.NewValues["PAR_PRECIO"].ToString());

			if (e.NewValues["PAR_CANTIDAD"] == null)
				pCantidad = "0";
			else
				pCantidad = (e.NewValues["PAR_CANTIDAD"].ToString().Length == 0 ? "null" : e.NewValues["PAR_CANTIDAD"].ToString());

			if (e.NewValues["PAR_CANTIDAD"] == null)
				pCodigo = "0";
			else
				pCodigo = (e.NewValues["CTP_CODIGO"].ToString().Length == 0 ? "null" : e.NewValues["CTP_CODIGO"].ToString());

			string Id = e.Keys["IDCONTRATOPARTIDA"].ToString();
			string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();

			string[] parameters = { IdContrato, pNombre, pPrecio, pCantidad, pCodigo };

			string LvCadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.UpdateRowContratoPartida(parameters,Id);
			GridContratoPartida.CancelEdit();
			e.Cancel = true;
			this.SearchContratoPartida();
		}
		#endregion

		/*CAMBIO						FECHA			AUTOR
		DELETE CONTRATO PARTIDA			02-09-2021	    ALEXANDER FERNÁNDEZ 02-09-2021*/
		protected void GridContratoPartida_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
		{
			string Id = e.Keys["IDCONTRATOPARTIDA"].ToString();
			string Cadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.DeleteRowContratoPartida(Id);
			GridContratoPartida.CancelEdit();
			e.Cancel = true;
			this.SearchContratoPartida();
		}

		/*CAMBIO							FECHA			AUTOR
		SUM TOTAL CONTRATO PARTIDA			22-06-2021	    ALEXANDER FERNÁNDEZ 22-06-2021*/
		protected void GridContratoPartida_CustomUnboundColumnData(object sender, ASPxGridViewColumnDataEventArgs e)
		{
			if (e.Column.FieldName == "TOTAL")
			{
				decimal price = (decimal)e.GetListSourceFieldValue("PAR_PRECIO");
				decimal cantidad = (decimal)(e.GetListSourceFieldValue("PAR_CANTIDAD"));
				e.Value = (price * cantidad).ToString("n2");
			}
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
            if (pIdProyecto != "0")
            {

                DataSet ds3 = new DataSet();
                ds3 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContrato((string)(Session["pIdProyecto"]));

                pnContrato = ds3.Tables[0].Rows.Count;
                GridProyectoContrato.KeyFieldName = "IDCONTRATO";
                GridProyectoContrato.DataSource = ds3.Tables[0];
                GridProyectoContrato.DataBind();
            }
        }
		#endregion		

		#region OnRowInsertingProyectoContrato
		protected void OnRowInsertingProyectoContrato(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            string pNumeroContrato, pRuc, pEmpresa, pFechaContrato, pMontoObra, pPlazoEjecucionObra, pFechaInicioObra, pFechaInicioObraMaximo, pFechaAdelantoDirecto,
            pFechaAdelantoDirectoMax, pMontoAdelantoMateriales, pFechaAdelantoMaximoMateriales, pMontoAdelantoInstalacion, pFechaAdelantoMaximoInstalacion, pFechaEntregaTerreno, pFechaEntregaTerrenoLimite, pDescripionEstadoContrato;


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

            if (e.NewValues["DESCRIPCION_ESTADO_CONTRATO"] == null)
                pDescripionEstadoContrato = "";
            else
                pDescripionEstadoContrato = (e.NewValues["DESCRIPCION_ESTADO_CONTRATO"].ToString().Length == 0 ? "null" : e.NewValues["DESCRIPCION_ESTADO_CONTRATO"].ToString());

            string IdProyectoComponente = GridProyectoComponente.GetRowValues(GridProyectoComponente.FocusedRowIndex, "IDPROYECTOCOMPONENTE").ToString();

            //string Id = e.Keys["IDPROYECTO_DETALLE"].ToString();
            string IdComponente = GridProyectoComponente.GetRowValues(GridProyectoComponente.FocusedRowIndex, "IDCOMPONENTE").ToString();
            string[] parameters = { IdProyectoComponente, pNumeroContrato, pRuc, pEmpresa, pFechaContrato, pMontoObra, pPlazoEjecucionObra, pFechaInicioObra, pFechaInicioObraMaximo, pFechaAdelantoDirecto,
            pFechaAdelantoDirectoMax, pMontoAdelantoMateriales, pFechaAdelantoMaximoMateriales, pMontoAdelantoInstalacion, pFechaAdelantoMaximoInstalacion, pFechaEntregaTerreno, pFechaEntregaTerrenoLimite,IdComponente,pDescripionEstadoContrato};
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
            pFechaAdelantoDirectoMax, pMontoAdelantoMateriales, pFechaAdelantoMaximoMateriales, pMontoAdelantoInstalacion, pFechaAdelantoMaximoInstalacion, pFechaEntregaTerreno, pFechaEntregaTerrenoLimite, pDescripionEstadoContrato ;


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

            if (e.NewValues["DESCRIPCION_ESTADO_CONTRATO"].ToString() != e.OldValues["DESCRIPCION_ESTADO_CONTRATO"].ToString())
                if (e.NewValues["DESCRIPCION_ESTADO_CONTRATO"] == null)
                    pDescripionEstadoContrato = "";
                else
                    pDescripionEstadoContrato = (e.NewValues["DESCRIPCION_ESTADO_CONTRATO"].ToString().Length == 0 ? "null" : e.NewValues["DESCRIPCION_ESTADO_CONTRATO"].ToString());
            else
                pDescripionEstadoContrato = "NCN";

            string IdProyectoComponente = GridProyectoComponente.GetRowValues(GridProyectoComponente.FocusedRowIndex, "IDPROYECTOCOMPONENTE").ToString();
            string IdComponente = GridProyectoComponente.GetRowValues(GridProyectoComponente.FocusedRowIndex, "IDCOMPONENTE").ToString();
            string Id = e.Keys["IDCONTRATO"].ToString();
            string[] parameters = { Id, pNumeroContrato, pRuc, pEmpresa, pFechaContrato, pMontoObra, pPlazoEjecucionObra, pFechaInicioObra, pFechaInicioObraMaximo, pFechaAdelantoDirecto,
            pFechaAdelantoDirectoMax, pMontoAdelantoMateriales, pFechaAdelantoMaximoMateriales, pMontoAdelantoInstalacion, pFechaAdelantoMaximoInstalacion, pFechaEntregaTerreno, pFechaEntregaTerrenoLimite,pDescripionEstadoContrato};
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

        #region EditorInitializeProyectoContrato
        protected void EditorInitializeProyectoContrato(object sender, ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName == "DESCRIPCION_ESTADO_CONTRATO")
            {
                ASPxComboBox combo = (ASPxComboBox)e.Editor;
                combo.DataBind();
            }
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
            if (pnContrato != 0)
            {


            DataSet ds3 = new DataSet();
            string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();
            ds3 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoCronograma((string)(Session["pIdProyecto"]),IdContrato);
            GridProyectoProgramacion.KeyFieldName = "IDCONTRATOCRONOGRAMA";
            GridProyectoProgramacion.DataSource = ds3.Tables[0];
            GridProyectoProgramacion.DataBind();
            }
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

		#region SearchByContratoSupervision
		private void SearchByContratoSupervision()
        {

            if (pnContrato != 0)
            {
                DataSet ds3 = new DataSet();
                string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();
                ds3 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoSeguimiento((string)(Session["pIdProyecto"]), IdContrato);
                GridProyectoSupervision.KeyFieldName = "IDCONTRATOSEGUIMIENTO";
                GridProyectoSupervision.DataSource = ds3.Tables[0];
                GridProyectoSupervision.DataBind();
            }
        }
		#endregion


		#region  SearchByProyectoContratoSup
		/*CAMBIO						FECHA			AUTOR
		SELECT	AVANCE DE SUPERVISOR	01-06-2021	    ALEXANDER FERNÁNDEZ 01-06-2021*/
		private void SearchByProyectoContratoSup(){
			if (pnContrato != 0) {
				DataSet ds4 = new DataSet();
				string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();

				ds4 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoSup((string)(Session["pIdProyecto"]), IdContrato);

				GridProyectoContratoSup.KeyFieldName = "IDCONTRATOSEGUIMIENTO";
				GridProyectoContratoSup.DataSource = ds4.Tables[0];
				GridProyectoContratoSup.DataBind();
			}
		}
		#endregion


		#region  SearchByProyectoContratoCon
		/*CAMBIO						FECHA			AUTOR
		SELECT	AVANCE DE CONTRATISTA	01-06-2021	    ALEXANDER FERNÁNDEZ 01-06-2021*/
		private void SearchByProyectoContratoCon()
		{
			if (pnContrato != 0)
			{
				DataSet ds5 = new DataSet();
				string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();

				ds5 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoCon((string)(Session["pIdProyecto"]), IdContrato);

				GridProyectoContratoCon.KeyFieldName = "IDCONTRATOSEGUIMIENTO";
				GridProyectoContratoCon.DataSource = ds5.Tables[0];
				GridProyectoContratoCon.DataBind();
			}
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


        #region hyperLink_IniValContrato
        protected void hyperLink_IniValContrato(object sender, EventArgs e)
        {
            ASPxHyperLink link = (ASPxHyperLink)sender;

            GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;
            int rowVisibleIndex = templateContainer.VisibleIndex;
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "VALORIZACION_NUMERO").ToString();
            string contentUrl = "frmInfoGesObraPrototipo.aspx" + "?pIdValorizacion=" + pId;
            link.NavigateUrl = "javascript:void(0);";
            link.Text = string.Format("{0}", templateContainer.Grid.GetRowValues(rowVisibleIndex, "VALORIZACION_NUMERO").ToString());
            link.ClientSideEvents.Click = string.Format("function(s, e) {{ OnMoreInfoClick('{0}'); }}", contentUrl);
        }
        #endregion

        #region SearchByContratoValorizacion
        private void SearchByContratoValorizacion()
        {
            if (pnContrato != 0)
            {

                DataSet ds3 = new DataSet();
                string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();
                //Sesssion IdContrato
                Session["pIdContrato"] = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString(); 
                ds3 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoValorizacion((string)(Session["pIdProyecto"]), IdContrato);
                GridProyectoValorizacion.KeyFieldName = "IDCONTRATOVALORIZACION";
                GridProyectoValorizacion.DataSource = ds3.Tables[0];
                GridProyectoValorizacion.DataBind();
            }
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
            if (pnContrato != 0)
            {

                DataSet ds3 = new DataSet();
                string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();
                ds3 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoAdelanto((string)(Session["pIdProyecto"]), IdContrato);
                GridProyectoAdelanto.KeyFieldName = "IDCONTRATOADELANTO";
                GridProyectoAdelanto.DataSource = ds3.Tables[0];
                GridProyectoAdelanto.DataBind();
            }
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
            if (pnContrato != 0)
            {

                string Id = e.Keys["IDCONTRATOAdelanto"].ToString();
                string Cadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.DeletedRowContratoAdelanto(Id);
                GridProyectoAdelanto.CancelEdit();
                e.Cancel = true;
                this.SearchByContratoAdelanto();
            }
        }
        #endregion

        #endregion

        #region ContratoTipologia

        #region OnLoadContratoTipologia
        protected void OnLoadContratoTipologia(object sender, EventArgs e)
        {
            this.SearchAllContratoTipologia();
        }
        #endregion

        #region SearchAllContratoTipologia
        private void SearchAllContratoTipologia()
        {
            if (pnContrato != 0)
            {

                DataSet ds3 = new DataSet();
                string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();
                ds3 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchAllContratoTipologia((string)(Session["pIdProyecto"]), IdContrato);
                ASPxGridViewContratoTipologia.KeyFieldName = "IDCONTRATOTIPOLOGIA";
                ASPxGridViewContratoTipologia.DataSource = ds3.Tables[0];
                ASPxGridViewContratoTipologia.DataBind();
            }
        }
        #endregion

        #region OnRowInsertingContratoTipologia
        protected void OnRowInsertingContratoTipologia(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {

            string pTipologiaDescripcion;
            if (e.NewValues["TIPOLOGIA_DESCRIPCION"] == null)
                pTipologiaDescripcion = "";
            else
                pTipologiaDescripcion = (e.NewValues["TIPOLOGIA_DESCRIPCION"].ToString().Length == 0 ? "null" : e.NewValues["TIPOLOGIA_DESCRIPCION"].ToString());

            string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();

            string[] parameters = { IdContrato, pTipologiaDescripcion};
            string LvCadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.InsertRowContratoTipologia(parameters);
            ASPxGridViewContratoTipologia.CancelEdit();
            e.Cancel = true;
            this.SearchAllContratoTipologia();
        }
        #endregion

        #region OnRowDeletingContratoTipologia
        protected void OnRowDeletingContratoTipologia(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string Id = e.Keys["IDCONTRATOTIPOLOGIA"].ToString();
            string Cadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.DeletedRowContratoTipologia(Id);
            GridProyectoAdelanto.CancelEdit();
            e.Cancel = true;
            this.SearchAllContratoTipologia();
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

        #region LoadCboTipoLogia
        private void LoadCboTipoLogia()
        {
            //if (Session["IdProyecto"] != null)
            //{
            DataSet ds2 = Code.Logic.Forms.Input.GSO_CheckList.SeachAllTipologia(""); ;
            ((GridViewDataComboBoxColumn)ASPxGridViewContratoTipologia.Columns["TIPOLOGIA_DESCRIPCION"]).PropertiesComboBox.DataSource = ds2.Tables[0];
            ((GridViewDataComboBoxColumn)ASPxGridViewContratoTipologia.Columns["TIPOLOGIA_DESCRIPCION"]).PropertiesComboBox.TextField = ds2.Tables[0].Columns["TIPOLOGIA_DESCRIPCION"].Caption.ToString();
            ((GridViewDataComboBoxColumn)ASPxGridViewContratoTipologia.Columns["TIPOLOGIA_DESCRIPCION"]).PropertiesComboBox.ValueField = ds2.Tables[0].Columns["IDTIPOLOGIA"].Caption.ToString();
            ds2.Dispose();
            ds2 = null;
            //}
        }
		#endregion


		#region LoadCboMedida
		private void LoadCboMedida()
		{
			DataSet ds3 = Code.Logic.Forms.Input.GSO_CheckList.SeachAllMedida("");

			((GridViewDataComboBoxColumn)GridPartida.Columns["PAR_MEDIDA"]).PropertiesComboBox.DataSource = ds3.Tables[0];
			((GridViewDataComboBoxColumn)GridPartida.Columns["PAR_MEDIDA"]).PropertiesComboBox.TextField = ds3.Tables[0].Columns["MED_NOMBRE"].Caption.ToString();
			((GridViewDataComboBoxColumn)GridPartida.Columns["PAR_MEDIDA"]).PropertiesComboBox.ValueField = ds3.Tables[0].Columns["MED_ID"].Caption.ToString();

			ds3.Dispose();
			ds3 = null;
		}
		#endregion

		#region LoadCboPartida
		private void LoadCboPartida()
		{
			DataSet ds2 = Code.Logic.Forms.Input.GSO_CheckList.SeachAllPartida("");
			((GridViewDataComboBoxColumn)GridContratoPartida.Columns["PAR_NOMBRE"]).PropertiesComboBox.DataSource = ds2.Tables[0];
			((GridViewDataComboBoxColumn)GridContratoPartida.Columns["PAR_NOMBRE"]).PropertiesComboBox.TextField = ds2.Tables[0].Columns["PAR_NOMBRE"].Caption.ToString();
			((GridViewDataComboBoxColumn)GridContratoPartida.Columns["PAR_NOMBRE"]).PropertiesComboBox.ValueField = ds2.Tables[0].Columns["PAR_ID"].Caption.ToString();
			ds2.Dispose();
			ds2 = null;
		}
        #endregion        

		private void LoadCboPolinomica()
		{
			DataSet ds2 = Code.Logic.Forms.Input.GSO_CheckList.SeachAllPolinomica("");
			((GridViewDataComboBoxColumn)GridContratoReajuste.Columns["CPL_POL_ID"]).PropertiesComboBox.DataSource = ds2.Tables[0];
			((GridViewDataComboBoxColumn)GridContratoReajuste.Columns["CPL_POL_ID"]).PropertiesComboBox.TextField = ds2.Tables[0].Columns["POL_NOMBRE"].Caption.ToString();
			((GridViewDataComboBoxColumn)GridContratoReajuste.Columns["CPL_POL_ID"]).PropertiesComboBox.ValueField = ds2.Tables[0].Columns["POL_ID"].Caption.ToString();
			ds2.Dispose();
			ds2 = null;
		}

		//protected void ucUploadPdf_FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
		//{
		//    if (e.IsValid)
		//    {
		//        Session["PdfFile"] = e.UploadedFile.FileBytes;
		//    }
		//}

		protected void btnDescargarArchivo(object sender, EventArgs e)
        {

            try
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFile("~/pdf/", "~/pdf/SuscripcionContrato.pdf");
            }
            catch (Exception ex)
            {
                string Text = "Error: " + ex.Message;
            }
            //webClient.DownloadFileAsync(new Uri("~/pdf/SuscripcionContrato.pdf"), @"c:\SuscripcionContrato.pdf");
        }

		protected void txtCUI_TextChanged(object sender, EventArgs e)
		{

		}

		protected void ASPxPageControl1_ActiveTabChanged(object source, TabControlEventArgs e)
		{

		}

		protected void AS(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
		{

		}



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
			string pValorizaconFecha, pValorizacionNumero, pAvance, lcAprobado;

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

			string Id = e.Keys["IDCONTRATOSEGUIMIENTO"].ToString();
			string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();

			string[] parameters = { IdContrato, pValorizaconFecha, pValorizacionNumero, pAvance, lcAprobado };
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

		protected void GridContratoPartida_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
		{
            DataSet ds1 = new DataSet();
            //ds1 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyecto(pIdProyecto);

            decimal utilidad, gastos_generales,adelantoDirecto, gastos_otros,adelantoMateriales, adelantoOtros,igv;

            //TRAER IGV DE LA BD
            utilidad = Convert.ToDecimal(TXTUTILIDAD.Text);
            gastos_generales = Convert.ToDecimal(TxtGastosGenerales.Text);
			gastos_otros = Convert.ToDecimal(TXTGASTOSOTROS.Text);
			adelantoDirecto = Convert.ToDecimal(TXTADELANTODIRECTO.Text);
			adelantoMateriales = Convert.ToDecimal(TXTADELANTOMATERIALES.Text);
			adelantoOtros = Convert.ToDecimal(TXTADELANTOOTROS.Text);			
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
				//this.TXTADELANTOOTROS.Text = ds1.Tables[0].Rows[0]["PCADELANTOOTROS"].ToString();
			}

            if ((e.Item as ASPxSummaryItem).Tag == "2")
            {
                ASPxSummaryItem incomeSummary = (sender as ASPxGridView).TotalSummary["TOTAL"];
                //ASPxSummaryItem expenseSummary = (sender as ASPxGridView).TotalSummary["Expense"];
                Decimal income = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary));
                //Decimal expense = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(expenseSummary));				
                LBLSUBTOTAL.Text = income.ToString();
                e.TotalValue = income * utilidad / 100;
            }
            else if ((e.Item as ASPxSummaryItem).Tag == "1")
            {
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
                e.TotalValue = (income + income * utilidad / 100 + income * gastos_generales / 100 + income * gastos_otros / 100) * igv;
            }
            else if ((e.Item as ASPxSummaryItem).Tag == "6")
            {
                ASPxSummaryItem incomeSummary = (sender as ASPxGridView).TotalSummary["TOTAL"];
                //ASPxSummaryItem expenseSummary = (sender as ASPxGridView).TotalSummary["Expense"];
                Decimal income = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary));
                //Decimal expense = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(expenseSummary));
                e.TotalValue = (income + income * utilidad / 100 + income * gastos_generales / 100 + income * gastos_otros / 100) * (1 + igv);
            }
			else if ((e.Item as ASPxSummaryItem).Tag == "7")
			{
				ASPxSummaryItem incomeSummary = (sender as ASPxGridView).TotalSummary["TOTAL"];
				//ASPxSummaryItem expenseSummary = (sender as ASPxGridView).TotalSummary["Expense"];
				Decimal income = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary));
				//Decimal expense = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(expenseSummary));

				Decimal sub = (income + income * utilidad / 100 + income * gastos_generales / 100 + income * gastos_otros / 100) * (1 + igv);

				e.TotalValue = sub - sub*adelantoDirecto/100 - sub*adelantoMateriales/100;
			}

		}

        protected void TXTUTILIDAD_TextChanged(object sender, EventArgs e)
		{
			decimal total;
			decimal utilidad = Convert.ToDecimal(TXTUTILIDAD.Text);
			decimal subtotal = Convert.ToDecimal(LBLSUBTOTAL.Text);

			total = subtotal * utilidad / 100;
			//UTILIDAD.Text = total.ToString();
		}

        /*CAMBIO						        FECHA			AUTOR
		UPDATE % UTILIDADES, GASTOS GENERALES 	01-07-2021	    ALEXANDER FERNÁNDEZ 01-07-2021*/
        protected void TxtGastosGenerales_TextChanged(object sender, EventArgs e)
		{
            //Calcular();
            //this.SearchContratoPartida();
        }
		protected void TXTGASTOSOTROS_TextChanged(object sender, EventArgs e)
		{
			Calcular();
			this.SearchContratoPartida();
		}

		protected void TXTADELANTOMATERIALES_TextChanged(object sender, EventArgs e)
		{
			Calcular();
			this.SearchContratoPartida();
		}
		#endregion

		protected void Calcular() {
            decimal gastos_generales_total,sub, tot, igv_total;
            decimal gastos_generales = Convert.ToDecimal(TxtGastosGenerales.Text);
			

			decimal subtotal = Convert.ToDecimal(LBLSUBTOTAL.Text);

            gastos_generales_total = subtotal * gastos_generales / 100;
			
			decimal gastos_otros_total;
			decimal gastos_otros = Convert.ToDecimal(TXTGASTOSOTROS.Text);
			gastos_otros_total = subtotal * gastos_otros / 100;
			//LBLGASTOSGENERALES.Text = gastos_generales_total.ToString("0.##");

			decimal utilidad_total;
            decimal utilidad = Convert.ToDecimal(TXTUTILIDAD.Text);

			utilidad_total = subtotal * utilidad / 100;
			//LBLUTILIDAD.Text = utilidad_total.ToString("0.##");


			sub = subtotal + utilidad_total + gastos_generales_total;
			igv_total = sub * 18 / 100;
			LBLIGV.Text = igv_total.ToString("0.##");

			tot = sub + igv_total;
			LBLSUB.Text = sub.ToString("0.##");
			LBLTOTAL.Text = tot.ToString("0.##");


			decimal adelantoDirecto_total;
			decimal adelantoDirecto = Convert.ToDecimal(TXTADELANTODIRECTO.Text);

			adelantoDirecto_total = tot * adelantoDirecto / 100;
			//LBLADELANTODIRECTO.Text = adelantoDirecto_total.ToString("0.##");

			decimal adelantoMateriales_total;
			decimal adelantoMateriales = Convert.ToDecimal(TXTADELANTOMATERIALES.Text);

			adelantoMateriales_total = tot * adelantoMateriales / 100;
			//LBLADELANTOMATERIALES.Text = adelantoMateriales_total.ToString("0.##");

			decimal adelantoOtros_total;
			decimal adelantoOtros = Convert.ToDecimal(TXTADELANTOOTROS.Text);

			adelantoOtros_total = tot * adelantoOtros / 100;
			//LBLADELANTOOTROS.Text = adelantoOtros_total.ToString("0.##");

			//UPDATE % UTILIDADES, GASTOS GENERALES
			//string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();
			string[] parameters = { utilidad.ToString(), gastos_generales.ToString(), gastos_otros.ToString(), adelantoDirecto.ToString(), adelantoMateriales.ToString(), adelantoOtros.ToString() };
            Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.UpdateRowProyectoContrato02(parameters, pIdProyecto);
            //SearchContratoById();

        }

        #region
        /*CAMBIO						        FECHA			AUTOR
		SEARCH CONTRATO BY ID                     	05-07-2021	    ALEXANDER FERNÁNDEZ 05-07-2021*/
        protected void SearchContratoById() {            
            DataSet ds1 = new DataSet();
            //string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();
            ds1 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchContratoById(pIdProyecto);
            if (ds1.Tables[0].Rows.Count > 0) {
                this.TXTUTILIDAD.Text = ds1.Tables[0].Rows[0]["PCUTILIDADES"].ToString();
                this.TxtGastosGenerales.Text = ds1.Tables[0].Rows[0]["PCGASTOS_GENERALES"].ToString();
				this.TXTGASTOSOTROS.Text = ds1.Tables[0].Rows[0]["PCGASTOS_OTROS"].ToString();
				this.TXTADELANTODIRECTO.Text = ds1.Tables[0].Rows[0]["PCADELANTODIRECTO"].ToString();
				this.TXTADELANTOMATERIALES.Text = ds1.Tables[0].Rows[0]["PCGASTOSGENERALES"].ToString();
				this.TXTADELANTOOTROS.Text = ds1.Tables[0].Rows[0]["PCADELANTOOTROS"].ToString();
			}
            //Calcular();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
			DataSet ds1 = new DataSet();
			string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();
			ds1 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchContratoById(pIdProyecto);



			gridExporter.PageHeader.Center = "CONTRATO "+ ds1.Tables[0].Rows[0]["CUI"].ToString() + " - "+ ds1.Tables[0].Rows[0]["DESCRIPCION"].ToString();						

			//PrintableComponentLinkBase grd1 = new PrintableComponentLinkBase(ps);
			//grd1.Component = grdResponsablesExporter;
			//PrintableComponentLinkBase grd2 = new PrintableComponentLinkBase(ps);
			//grd2.Component = grdInformacionExporter;

			/// gridExporter.Page.
			gridExporter.Landscape = true;
            gridExporter.RightMargin = 0;
            gridExporter.LeftMargin = 0;
            gridExporter.WritePdfToResponse();
			gridExporter02.WritePdfToResponse();



			/*this.txtCUI.Text = ds1.Tables[0].Rows[0]["ACT_PROY"].ToString();
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
			this.txtDistrito.Text = ds1.Tables[0].Rows[0]["DISTRITO"].ToString();}*/
		}

        protected void Button2_Click(object sender, EventArgs e)
        {
            gridExporter.WriteXlsxToResponse();
        }


		#region GridContratoReajuste
		/*CAMBIO						FECHA			AUTOR
		SELECT	CONTRATO REAJUSTE		19-07-2021	    ALEXANDER FERNÁNDEZ 19-07-2021*/
		protected void GridContratoReajuste_Load(object sender, EventArgs e)
		{
			this.SearchContratoReajuste();
		}

		private void SearchContratoReajuste() {

			if (pnContrato != 0) {

				DataSet ds3 = new DataSet();
				string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();
				ds3 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByContratoReajuste(IdContrato);

				GridContratoReajuste.KeyFieldName = "CPL_ID";
				GridContratoReajuste.DataSource = ds3.Tables[0];
				GridContratoReajuste.DataBind();
			}			
		}

		/*CAMBIO						FECHA			AUTOR
		INSERT	CONTRATO REAJUSTE		19-07-2021	    ALEXANDER FERNÁNDEZ 19-07-2021*/
		protected void GridContratoReajuste_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
		{

			string pPolinomicaId, pFactor, pIndiceValor;			

			if (e.NewValues["CPL_POL_ID"] == null)
				pPolinomicaId = "";
			else
				pPolinomicaId = (e.NewValues["CPL_POL_ID"].ToString().Length == 0 ? "null" : e.NewValues["CPL_POL_ID"].ToString());

			if (e.NewValues["CPL_POL_ID"] == null)
				pFactor = "";
			else
				pFactor = (e.NewValues["CPL_FACTOR"].ToString().Length == 0 ? "null" : e.NewValues["CPL_FACTOR"].ToString());

			if (e.NewValues["CPL_INDICE_VALOR"] == null)
				pIndiceValor = "";
			else
				pIndiceValor = (e.NewValues["CPL_INDICE_VALOR"].ToString().Length == 0 ? "null" : e.NewValues["CPL_INDICE_VALOR"].ToString());


			string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();

			string[] parameters = { IdContrato, pPolinomicaId, pFactor, pIndiceValor };

			string LvCadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.InsertRowContratoReajuste(parameters);

			GridContratoReajuste.CancelEdit();
			e.Cancel = true;
			this.SearchContratoReajuste();
		}


		/*CAMBIO						FECHA			AUTOR
		UPDATE	CONTRATO REAJUSTE		19-07-2021	    ALEXANDER FERNÁNDEZ 19-07-2021*/
		protected void GridContratoReajuste_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
		{

			string pPolinomicaId, pFactor, pIndiceValor;		

			if (e.NewValues["CPL_POL_ID"].ToString() != e.OldValues["CPL_POL_ID"].ToString())
				if (e.NewValues["CPL_POL_ID"] == null)
					pPolinomicaId = "";
				else
					pPolinomicaId = (e.NewValues["CPL_POL_ID"].ToString().Length == 0 ? "null" : e.NewValues["CPL_POL_ID"].ToString());
			else
				pPolinomicaId = "NCN";

			if (e.NewValues["CPL_FACTOR"] == null)
				pFactor = "";
			else
				pFactor = (e.NewValues["CPL_FACTOR"].ToString().Length == 0 ? "null" : e.NewValues["CPL_FACTOR"].ToString());

			if (e.NewValues["CPL_INDICE_VALOR"] == null)
				pIndiceValor = "";
			else
				pIndiceValor = (e.NewValues["CPL_INDICE_VALOR"].ToString().Length == 0 ? "null" : e.NewValues["CPL_INDICE_VALOR"].ToString());


			string Id = e.Keys["CPL_ID"].ToString();
			string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();

			string[] parameters = { IdContrato, pPolinomicaId, pFactor, pIndiceValor };

			string LvCadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.UpdateRowContratoReajuste(parameters, Id);

			GridContratoReajuste.CancelEdit();
			e.Cancel = true;
			this.SearchContratoReajuste();
		}

		#region

		/*CAMBIO						FECHA			AUTOR
		SELECT	CONTRATO POLINOMICA		19-07-2021	    ALEXANDER FERNÁNDEZ 19-07-2021*/
		protected void GridPolinomica_Load(object sender, EventArgs e)
		{
			this.SearchPolinomica();
		}

		private void SearchPolinomica()
		{
			if (pnContrato != 0)
			{
				DataSet ds3 = new DataSet();
				string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();
				ds3 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByPolinomica(IdContrato);

				GridPolinomica.KeyFieldName = "POL_ID";
				GridPolinomica.DataSource = ds3.Tables[0];
				GridPolinomica.DataBind();
			}
		}
					
		/*CAMBIO						FECHA			AUTOR
		INSERT	CONTRATO POLINOMICA		19-07-2021	    ALEXANDER FERNÁNDEZ 19-07-2021*/
		protected void GridPolinomica_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
		{
			string pIndice, pNombre;

			if (e.NewValues["POL_INDICE"] == null)
				pIndice = "";
			else
				pIndice = (e.NewValues["POL_INDICE"].ToString().Length == 0 ? "null" : e.NewValues["POL_INDICE"].ToString());


			if (e.NewValues["POL_NOMBRE"] == null)
				pNombre = "";
			else
				pNombre = (e.NewValues["POL_NOMBRE"].ToString().Length == 0 ? "null" : e.NewValues["POL_NOMBRE"].ToString());			
			

			string[] parameters = { pIndice, pNombre };

			string LvCadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.InsertRowPolinomica(parameters);

			GridPolinomica.CancelEdit();
			e.Cancel = true;
			this.SearchPolinomica();
		}


		/*CAMBIO						FECHA			AUTOR
		UPDATE	CONTRATO POLINOMICA		19-07-2021	    ALEXANDER FERNÁNDEZ 19-07-2021*/
		protected void GridPolinomica_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
		{
			string pIndice, pNombre;

			if (e.NewValues["POL_INDICE"] == null)
				pIndice = "";
			else
				pIndice = (e.NewValues["POL_INDICE"].ToString().Length == 0 ? "null" : e.NewValues["POL_INDICE"].ToString());


			if (e.NewValues["POL_NOMBRE"] == null)
				pNombre = "";
			else
				pNombre = (e.NewValues["POL_NOMBRE"].ToString().Length == 0 ? "null" : e.NewValues["POL_NOMBRE"].ToString());
			

			string Id = e.Keys["POL_ID"].ToString();			

			string[] parameters = { pIndice, pNombre};

			string LvCadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.UpdateRowPolinomica(parameters, Id);

			GridPolinomica.CancelEdit();
			e.Cancel = true;
			this.SearchPolinomica();
		}

		protected void Button3_Click(object sender, EventArgs e)
		{
			gridExporter02.RightMargin = 0;
			gridExporter02.LeftMargin = 0;
			gridExporter02.WritePdfToResponse();
		}

		protected void Button4_Click(object sender, EventArgs e)
		{
			gridExporter02.WriteXlsxToResponse();
		}

        protected void GridContratoPartida_SummaryDisplayText(object sender, ASPxGridViewSummaryDisplayTextEventArgs e)
        {

            DataSet ds1 = new DataSet();
            //ds1 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyecto(pIdProyecto);

            decimal utilidad, gastos_generales, gastos_otros, igv;

            //TRAER IGV DE LA BD
            utilidad = Convert.ToDecimal(TXTUTILIDAD.Text);
            gastos_generales = Convert.ToDecimal(TxtGastosGenerales.Text);
			gastos_otros = Convert.ToDecimal(TXTGASTOSOTROS.Text);
			igv = Convert.ToDecimal(0.18);
            ds1 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyecto(pIdProyecto);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                utilidad = Convert.ToDecimal(ds1.Tables[0].Rows[0]["PCUTILIDADES"].ToString());
                gastos_generales = Convert.ToDecimal(ds1.Tables[0].Rows[0]["PCGASTOS_GENERALES"].ToString());
				gastos_otros = Convert.ToDecimal(ds1.Tables[0].Rows[0]["PCGASTOS_OTROS"].ToString());

			}

            if ((e.Item as ASPxSummaryItem).Tag == "2")
            {
                e.Text = string.Format("Utilidad (" + utilidad + "%) = {0:c}", Convert.ToDecimal(e.Value));
            }
            else if ((e.Item as ASPxSummaryItem).Tag == "1")
            {
                e.Text = string.Format("G. Generales (" + gastos_generales + "%) = {0:c}", Convert.ToDecimal(e.Value));
            }
			else if ((e.Item as ASPxSummaryItem).Tag == "3")
			{
				e.Text = string.Format("G. Otros (" + gastos_otros + "%) = {0:c}", Convert.ToDecimal(e.Value));
			}
			else if ((e.Item as ASPxSummaryItem).Tag == "4")
            {
                e.Text = string.Format("Igv (" + igv * 100 + "%) = {0:c}", Convert.ToDecimal(e.Value));
            }
        }

		#endregion

		#endregion

		#endregion

		protected void Button5_Click(object sender, EventArgs e)
		{
			QRCodeEncoder encoder = new QRCodeEncoder();
			Bitmap img = encoder.Encode(txtCode.Text);
			System.Drawing.Image QR = (System.Drawing.Image)img;

			using (MemoryStream ms = new MemoryStream())
			{
				QR.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
				byte[] imageBytes = ms.ToArray();
				imgCtrl.Src = "data:image/gif;base64," + Convert.ToBase64String(imageBytes);
				imgCtrl.Height = 200;
				imgCtrl.Width = 200;
			}
		}        

        protected void GridContratoPartida_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            if (!object.Equals(e.RowType, GridViewRowType.Data)) return;

            //bool hasError = string.IsNullOrEmpty(e.GetValue("SEGUIMIENTO_FECHA").ToString());
            string metrado = e.GetValue("PAR_CANTIDAD").ToString();            
            if (metrado == "0.00")
            {                
                e.Row.BackColor = Color.FromArgb(144, 223, 203);
                //e.Row.BackColor = System.Drawing.Color.Red;
            }
        }

        protected void GridContratoPartida_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {            
            if (e.GetValue("PAR_CANTIDAD").ToString() == "0.00" && e.DataColumn.FieldName == "PAR_CANTIDAD")
            e.Cell.Text = String.Empty;

            if (e.GetValue("PAR_CANTIDAD").ToString() == "0.00" && e.DataColumn.FieldName == "PAR_PRECIO")
                e.Cell.Text = String.Empty;

            if (e.GetValue("PAR_CANTIDAD").ToString() == "0.00" && e.DataColumn.FieldName == "PAR_MEDIDA")
                e.Cell.Text = String.Empty;

            if (e.GetValue("PAR_CANTIDAD").ToString() == "0.00" && e.DataColumn.FieldName == "TOTAL")
                e.Cell.Text = String.Empty;

            if (e.GetValue("PAR_CANTIDAD").ToString() == "0.00" && e.DataColumn.FieldName == "APROBADO")
                e.Cell.Text = String.Empty;
            
        }
    }
}
 