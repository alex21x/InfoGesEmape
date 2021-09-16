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
    public partial class frmCentro_Costo : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            InfoGesRegional.Modules.MasterPage m = (InfoGesRegional.Modules.MasterPage)Page.Master;
            if (Context.User.Identity.IsAuthenticated)
            { }
            else
                Response.Redirect("~/Default.aspx");
            if (!Page.IsPostBack)
            {

            }
        }


        #region GetAllCentroCosto
        private void GetAllCentroCosto()
        {
            DataSet ds3 = new DataSet();
            ds3 = Code.Logic.Forms.Mantenimientos.Centro_Costo.SearchAllCentroCosto();
            ASPxGridviewCentroCosto.KeyFieldName = "ID_CENTRO_COSTO";
            ASPxGridviewCentroCosto.DataSource = ds3.Tables[0];
            ASPxGridviewCentroCosto.DataBind();
        }
        #endregion

        #region LoadCentroCosto
        protected void LoadCentroCosto(object sender, EventArgs e)
        {
            this.GetAllCentroCosto();
        }
        #endregion

        #region InsertCentroCosto
        protected void InsertCentroCosto(Object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {

            string LcDescripcionCentroCosto;


            if (e.NewValues["DESCRIPCION_CENTRO_COSTO"] == null)
                LcDescripcionCentroCosto = "";
            else
                LcDescripcionCentroCosto = (e.NewValues["DESCRIPCION_CENTRO_COSTO"].ToString().Length == 0 ? "null" : e.NewValues["DESCRIPCION_CENTRO_COSTO"].ToString());

            string[] parameters = { LcDescripcionCentroCosto };

            string Cadena = Code.Logic.Forms.Mantenimientos.Centro_Costo.InsertCentroCosto(parameters);

            if (Cadena.ToString().Length != 0)
            {
                throw new Exception(Cadena);
            }
            else
            {
                e.Cancel = true;
                ASPxGridviewCentroCosto.CancelEdit();
                this.GetAllCentroCosto();

            }

        }

        #endregion

        #region UpdatedCentroCosto
        protected void UpdatedCentroCosto(Object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string LcDescripcionCentroCosto;

            string Id = e.Keys["ID_CENTRO_COSTO"].ToString();
            if (e.NewValues["DESCRIPCION_CENTRO_COSTO"] == null)
                LcDescripcionCentroCosto = "";
            else
                LcDescripcionCentroCosto = (e.NewValues["DESCRIPCION_CENTRO_COSTO"].ToString().Length == 0 ? "null" : e.NewValues["DESCRIPCION_CENTRO_COSTO"].ToString());

            string[] parameters = { Id, LcDescripcionCentroCosto };

            string Cadena = Code.Logic.Forms.Mantenimientos.Centro_Costo.UpdatedCentroCosto(parameters);

            if (Cadena.ToString().Length != 0)
            {
                throw new Exception(Cadena);
            }
            else
            {
                e.Cancel = true;
                ASPxGridviewCentroCosto.CancelEdit();
                this.GetAllCentroCosto();

            }

        }
        #endregion

        #region DeleteCentrocosto
        protected void DeleteCentrocosto(Object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string Id = e.Keys["ID_CENTRO_COSTO"].ToString(); ;
            string Cadena = Code.Logic.Forms.Mantenimientos.Centro_Costo.DeleteCentroCosto(Id);

            if (Cadena.ToString().Length != 0)
            {
                throw new Exception(Cadena);
            }
            else
            {
                e.Cancel = true;
                ASPxGridviewCentroCosto.CancelEdit();
                this.GetAllCentroCosto();
            }

        }
        #endregion



 
    }
}
