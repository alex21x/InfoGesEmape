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


namespace InfoGesRegional.Modules.Forms.Mantenimientos
{
    public partial class frmCc_x_ejecutora : System.Web.UI.Page
    {
        private string psIdSecEjec = "";
        #region PageInit
        protected void Page_Init(object sender, EventArgs e)
        {
            LoadCboCentroCosto();

        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InfoGesRegional.Modules.MasterPage m = (InfoGesRegional.Modules.MasterPage)Page.Master;
            if (Context.User.Identity.IsAuthenticated)
            { }
            else
                Response.Redirect("~/Default.aspx");
            psIdSecEjec = (string)(Session["IdSecEjec"]);
            Session["IdTipoConexion"] = ConfigurationManager.AppSettings.Get("IdTipoConexion");
            if (psIdSecEjec==null)
                Response.Redirect("~/Modules/Forms/Seguimiento/frmMenu.aspx");
            if (!Page.IsPostBack)
            {
                this.LoadEjecutora();
            }
        }


        #region GetAllCentroCostoEjec
        private void GetAllCentroCostoEjec()
        {
            DataSet ds3 = new DataSet();
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

        #region InsertCentroCostoEjec
        protected void InsertCentroCostoEjec(Object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {

            string LcDescripcionCentroCostoEjec;
            string lcDescripcion;


            if (e.NewValues["DESCRIPCION_CENTRO_COSTO"] == null)
                LcDescripcionCentroCostoEjec = "";
            else
                LcDescripcionCentroCostoEjec = (e.NewValues["DESCRIPCION_CENTRO_COSTO"].ToString().Length == 0 ? "null" : e.NewValues["DESCRIPCION_CENTRO_COSTO"].ToString());

            if (e.NewValues["DESCRIPCION"] == null)
                lcDescripcion = "";
            else
                lcDescripcion = (e.NewValues["DESCRIPCION"].ToString().Length == 0 ? "null" : e.NewValues["DESCRIPCION"].ToString());

            string[] parameters = { LcDescripcionCentroCostoEjec, lcDescripcion, CboEjecutora.Value.ToString() };

            string Cadena = Code.Logic.Forms.Mantenimientos.Centro_Costo_x_ejec.InsertCentroCostoEjec(parameters);

            if (Cadena.ToString().Length != 0)
            {
                throw new Exception(Cadena);
            }
            else
            {
                e.Cancel = true;
                ASPxGridviewCentroCostoEjec.CancelEdit();
                this.GetAllCentroCostoEjec();

            }

        }

        #endregion

        #region UpdatedCentroCostoEjec
        protected void UpdatedCentroCostoEjec(Object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {

            string LcDescripcionCentroCostoEjec;
            string lcDescripcion;

            string Id = e.Keys["ID_CENTRO_COSTO_X_EJECUTORA"].ToString();

            if (e.NewValues["DESCRIPCION_CENTRO_COSTO"] == null)
                LcDescripcionCentroCostoEjec = "";
            else
                LcDescripcionCentroCostoEjec = (e.NewValues["DESCRIPCION_CENTRO_COSTO"].ToString().Length == 0 ? "null" : e.NewValues["DESCRIPCION_CENTRO_COSTO"].ToString());

            if (e.NewValues["DESCRIPCION"] == null)
                lcDescripcion = "";
            else
                lcDescripcion = (e.NewValues["DESCRIPCION"].ToString().Length == 0 ? "null" : e.NewValues["DESCRIPCION"].ToString());

            string[] parameters = { Id,LcDescripcionCentroCostoEjec, lcDescripcion, CboEjecutora.Value.ToString() };

            string Cadena = Code.Logic.Forms.Mantenimientos.Centro_Costo_x_ejec.UpdatedCentroCostoEjec(parameters);

            if (Cadena.ToString().Length != 0)
            {
                throw new Exception(Cadena);
            }
            else
            {
                e.Cancel = true;
                ASPxGridviewCentroCostoEjec.CancelEdit();
                this.GetAllCentroCostoEjec();

            }

        }
        #endregion

        #region DeleteCentroCostoEjec
        protected void DeleteCentroCostoEjec(Object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string Id = e.Keys["ID_CENTRO_COSTO_X_EJECUTORA"].ToString(); ;
            string Cadena = Code.Logic.Forms.Mantenimientos.Centro_Costo_x_ejec.DeleteCentroCostoEjec(Id);

            if (Cadena.ToString().Length != 0)
            {
                throw new Exception(Cadena);
            }
            else
            {
                e.Cancel = true;
                ASPxGridviewCentroCostoEjec.CancelEdit();
                this.GetAllCentroCostoEjec();
            }

        }
        #endregion

        #region LoadEjecutora
        protected void LoadEjecutora()
        {
            //DataSet ds1 = Code.Logic.Forms.Consulta.Ejecutora.SearchAllEjecutora();
            DataSet ds1 = Code.Logic.Forms.Consulta.Ejecutora.SearchEjecutoraCC(psIdSecEjec.ToString(), (string)(Session["IdSecEjec"]));
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

        #region EditorInitializeCentroCostoejec
        protected void EditorInitializeCentroCostoejec(object sender, ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName == "DESCRIPCION_CENTRO_COSTO")
            {
                ASPxComboBox combo = (ASPxComboBox)e.Editor;
                combo.DataBind();
            }
        }
        #endregion

        #region LoadCboCentroCosto
        private void LoadCboCentroCosto()
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
 
    }
}
