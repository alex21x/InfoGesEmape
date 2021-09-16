using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxCallbackPanel;
using DevExpress.Web.ASPxClasses;


namespace InfoGesRegional.Modules.Forms.Mantenimientos
{
    public partial class frmCc_x_eje_x_meta : System.Web.UI.Page
    {
        private string psIdSecEjec="";
        private string IdAnoEje;

        protected void Page_Load(object sender, EventArgs e)
        {
            psIdSecEjec = (string)(Session["IdSecEjec"]);
            //InfoGesRegional.Modules.MasterPage m = (InfoGesRegional.Modules.MasterPage)Page.Master;
            if (Context.User.Identity.IsAuthenticated)
            { }
            else
                Response.Redirect("~/Default.aspx");
            if (psIdSecEjec == null)
                Response.Redirect("~/Modules/Forms/Seguimiento/frmMenu.aspx");

            if (!Page.IsPostBack)
            {
                //psIdSecEjec = (string)(Session["IdSecEjec"]).ToString();

                this.LoadSecEjec();
            }
        }


        #region PageInit
        protected void Page_Init(object sender, EventArgs e)
        {
            LoadCboMeta();

        }
        #endregion

        #region GetAllCentroCostoEjec
        private void GetAllCentroCostoEjec()
        {
            DataSet ds3 = new DataSet();
            if( CboEjecutora.Items.Count==0)
                ds3 = Code.Logic.Forms.Mantenimientos.Centro_Costo_x_ejec.SearchAllCentroCostoEjec("0");
            else
                ds3 = Code.Logic.Forms.Mantenimientos.Centro_Costo_x_ejec.SearchAllCentroCostoEjec(CboEjecutora.Value.ToString());

            ASPxGridviewCentroCostoEjec.KeyFieldName = "ID_CENTRO_COSTO_X_EJECUTORA";
            ASPxGridviewCentroCostoEjec.DataSource = ds3.Tables[0];
            ASPxGridviewCentroCostoEjec.DataBind();
        }
        #endregion

        #region LoadCentroCostoEjec
        protected void LoadCentroCostoEjec(object sender, EventArgs e)
        {
            this.GetAllCentroCostoEjec();
        }
        #endregion

        #region GetAllCentroCostoEjecMeta
        private void GetAllCentroCostoEjecMeta(object sender)
        {
            ASPxGridView ASPxGridviewCentroCostoEjec = (ASPxGridView)sender;
            int Id = Convert.ToInt32(ASPxGridviewCentroCostoEjec.GetMasterRowKeyValue());
            ASPxGridView ASPxGridviewCentroCostoEjecMeta = (ASPxGridView)sender;
            DataSet ds3 = new DataSet();
            ds3 = Code.Logic.Forms.Mantenimientos.Centro_Costo_x_ejec_x_Meta.SearchAllCentroCostoEjecMeta(Id.ToString());
            ASPxGridviewCentroCostoEjecMeta.KeyFieldName = "ID_CC_X_EJEC_X_META";
            ASPxGridviewCentroCostoEjecMeta.DataSource = ds3.Tables[0];
            ASPxGridviewCentroCostoEjecMeta.DataBind();
        }
        #endregion

        #region LoadCentroCostoEjecMeta
        protected void LoadCentroCostoEjecMeta(object sender, EventArgs e)
        {
            this.GetAllCentroCostoEjecMeta(sender);
        }
        #endregion

        #region InsertCentroCostoEjecMeta
        protected void InsertCentroCostoEjecMeta(Object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {


            DataSet ds1 = Code.Logic.Forms.Consulta.ConfiguracionTransmision.SearchByParOpeTransmision(psIdSecEjec);
            IdAnoEje = ds1.Tables[0].Rows[0][0].ToString();
            
            
            string LcDescripcionCentroCostoEjecMeta;
            if (e.NewValues["DESCRIPCION_META"] == null)
                LcDescripcionCentroCostoEjecMeta = "";
            else
                LcDescripcionCentroCostoEjecMeta = (e.NewValues["DESCRIPCION_META"].ToString().Length == 0 ? "null" : e.NewValues["DESCRIPCION_META"].ToString());
            ASPxGridView ASPxGridviewCentroCostoEjec = (ASPxGridView)sender;
            int Id_Cetro_Costo_x_Ejecutora= Convert.ToInt32(ASPxGridviewCentroCostoEjec.GetMasterRowKeyValue());

            string[] parameters = { IdAnoEje, CboEjecutora.Value.ToString(), LcDescripcionCentroCostoEjecMeta, Id_Cetro_Costo_x_Ejecutora.ToString() };

            string Cadena = Code.Logic.Forms.Mantenimientos.Centro_Costo_x_ejec_x_Meta.InsertCentroCostoEjecMeta(parameters);

            if (Cadena.ToString().Length != 0)
            {
                throw new Exception(Cadena);
            }
            else
            {
                e.Cancel = true;
                ASPxGridView ASPxGridviewCentroCostoEjecMeta = (ASPxGridView)sender;
                ASPxGridviewCentroCostoEjecMeta.CancelEdit();
                this.GetAllCentroCostoEjecMeta(sender);

            }

        }

        #endregion

        #region UpdatedCentroCostoEjecMeta
        protected void UpdatedCentroCostoEjecMeta(Object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {

            DataSet ds1 = Code.Logic.Forms.Consulta.ConfiguracionTransmision.SearchByParOpeTransmision(psIdSecEjec);
            IdAnoEje = ds1.Tables[0].Rows[0][0].ToString();

            string LcDescripcionCentroCostoEjecMeta;

            string Id = e.Keys["ID_CC_X_EJEC_X_META"].ToString();

            if (e.NewValues["DESCRIPCION_META"] == null)
                LcDescripcionCentroCostoEjecMeta = "";
            else
                LcDescripcionCentroCostoEjecMeta = (e.NewValues["DESCRIPCION_META"].ToString().Length == 0 ? "null" : e.NewValues["DESCRIPCION_META"].ToString());


            string[] parameters = { Id,LcDescripcionCentroCostoEjecMeta};

            string Cadena = Code.Logic.Forms.Mantenimientos.Centro_Costo_x_ejec_x_Meta.UpdatedCentroCostoEjecMeta(parameters);

            if (Cadena.ToString().Length != 0)
            {
                throw new Exception(Cadena);
            }
            else
            {
                e.Cancel = true;
                ASPxGridView ASPxGridviewCentroCostoEjecMeta = (ASPxGridView)sender;
                ASPxGridviewCentroCostoEjecMeta.CancelEdit();
                this.GetAllCentroCostoEjecMeta(sender);
            }
        }
        #endregion

        #region DeleteCentroCostoEjecMeta
        protected void DeleteCentroCostoEjecMeta(Object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string Id = e.Keys["ID_CC_X_EJEC_X_META"].ToString(); ;
            string Cadena = Code.Logic.Forms.Mantenimientos.Centro_Costo_x_ejec_x_Meta.DeleteCentroCostoEjecMeta(Id);

            if (Cadena.ToString().Length != 0)
            {
                throw new Exception(Cadena);
            }
            else
            {
                e.Cancel = true;
                //ASPxGridviewCentroCostoEjecMeta.CancelEdit();
                this.GetAllCentroCostoEjecMeta(sender);
            }

        }
        #endregion

        #region LoadCboMeta
        private void LoadCboMeta()
        {
            DataSet ds2 = new DataSet();
            ds2 = Code.Logic.Forms.Mantenimientos.Centro_Costo.SearchAllCentroCosto();
            ((GridViewDataComboBoxColumn)ASPxGridviewCentroCostoEjec.Columns["DESCRIPCION_CENTRO_COSTO"]).PropertiesComboBox.DataSource = ds2.Tables[0];
            ((GridViewDataComboBoxColumn)ASPxGridviewCentroCostoEjec.Columns["DESCRIPCION_CENTRO_COSTO"]).PropertiesComboBox.TextField = ds2.Tables[0].Columns["DESCRIPCION_CENTRO_COSTO"].Caption.ToString();
            ((GridViewDataComboBoxColumn)ASPxGridviewCentroCostoEjec.Columns["DESCRIPCION_CENTRO_COSTO"]).PropertiesComboBox.ValueField = ds2.Tables[0].Columns["ID_CENTRO_COSTO"].Caption.ToString();
            ds2.Dispose();
            ds2 = null;

        }
        #endregion

        #region LoadSecEjec
        protected void LoadSecEjec()
        {
            DataSet ds1 = Code.Logic.Forms.Consulta.Ejecutora.SearchEjecutoraCC(psIdSecEjec.ToString(), (string)(Session["IdTipoConexion"]));
            CboEjecutora.DataSource = ds1.Tables[0];
            CboEjecutora.TextField = ds1.Tables[0].Columns["DESCRIPCION_SEC_EJEC"].Caption.ToString();
            CboEjecutora.ValueField = ds1.Tables[0].Columns["SEC_EJEC"].Caption.ToString();
            CboEjecutora.DataBind();
            CboEjecutora.SelectedIndex = 0;
            ds1.Dispose();
            ds1 = null;
            this.GetAllCentroCostoEjec();
        }
        #endregion

        #region OnSelectedindexChangedEjecutora
        public void OnSelectedindexChangedEjecutora(object sender, EventArgs e)
        {
            this.GetAllCentroCostoEjec();
        }
        #endregion

        #region EditorInitializeCentroCostoEjecMeta
        protected void EditorInitializeCentroCostoEjecMeta(object sender, ASPxGridViewEditorEventArgs e)
        {
            switch (e.Column.FieldName)
            {
                case "DESCRIPCION_META":
                    InitializeCombo(e, "DESCRIPCION_META", "SEC_FUNC", cmbComboMeta_OnCallback);
                    break;
            }
        }
        #endregion


        #region InitializeCombo
        protected void InitializeCombo(ASPxGridViewEditorEventArgs e,
            string parentComboName, string source, CallbackEventHandlerBase callBackHandler)
        {
            ASPxGridView ASPxGridContratoUbigeo = new ASPxGridView();
            string id = string.Empty;
            if (!ASPxGridContratoUbigeo.IsNewRowEditing)
            {
                object val = ASPxGridContratoUbigeo.GetRowValuesByKeyValue(e.KeyValue, parentComboName);
                id = (val == null || val == DBNull.Value) ? null : val.ToString();
            }
            ASPxComboBox combo = e.Editor as ASPxComboBox;
            if (combo != null)
            {
                // unbind combo
                combo.DataSource = null;
                FillCombo(combo, id, source);
                combo.Callback += callBackHandler;
            }
            return; 
        }
        #endregion

        #region cmbComboMeta_OnCallback
        private void cmbComboMeta_OnCallback(object source, CallbackEventArgsBase e)
        {
            FillCombo(source as ASPxComboBox, e.Parameter, "SEC_FUNC");
        }
        #endregion

        #region FillCombo
        protected void FillCombo(ASPxComboBox cmb, string id, string source)
        {
            cmb.Items.Clear();
            // trap null selection
            DataSet ds1 = new DataSet();

            if (string.IsNullOrEmpty(id) &&
                    (source != "SEC_FUNC")) return;
            switch (source)
            {
                case "SEC_FUNC":
                    {
                        ds1 = Code.Logic.Forms.Consulta.ConfiguracionTransmision.SearchByParOpeTransmision((string)(Session["IdSecEjec"]).ToString());
                        string IdAnoEje = ds1.Tables[0].Rows[0][0].ToString();
                        ds1 = null;
                        ds1 = Code.Logic.Forms.Consulta.Meta.SearchAllMetaxEjecutora(IdAnoEje,psIdSecEjec);
                        foreach (DataRow dr1 in ds1.Tables[0].Rows)
                        {
                            cmb.Items.Add(dr1["DESCRIPCION_META"].ToString(), dr1["SEC_FUNC"].ToString());
                        }
                        break;
                    }
            }
        }
        #endregion

    }
}
