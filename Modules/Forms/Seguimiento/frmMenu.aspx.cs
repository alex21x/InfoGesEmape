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
using DevExpress.Web;



namespace InfoGesRegional.Modules.Forms.Seguimiento
{
    public partial class frmMenu : System.Web.UI.Page
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


        #region LoadASPxGridviewEjecutora
        protected void LoadASPxGridviewEjecutora(object sender, EventArgs e)
        {

               Get_ASPxGridViewEjecutora();
        }
        #endregion

        #region Get_ASPxGridViewEjecutora
        public void Get_ASPxGridViewEjecutora()
        {
            DataSet ds1 = Code.Logic.Forms.Consulta.Ejecutora.SearchEjecutoraUser((string)(Session["IdPersonal"]));
            this.ASPxGridviewEjecutora.DataSource = ds1.Tables[0];
            ASPxGridviewEjecutora.KeyFieldName = "SEC_EJEC";
            this.ASPxGridviewEjecutora.DataBind();
        }
        #endregion


        protected void EvtRowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
        {
            if (e.CommandArgs.CommandName == "Select")
            {
                int id = Convert.ToInt32(e.CommandArgs.CommandArgument);
                //Aqui se pone el codigo de cache
                DataSet ds1 = new DataSet();
                ds1 = Code.Data.Accounts.User.Validate2((string)(Session["IdPersonal"]), id.ToString());
                Session["SecEjecId"]        = ds1.Tables[0].Rows[0][0].ToString();
                Session["IdSecEjecDesc"]    = ds1.Tables[0].Rows[0][1].ToString();
                try
                {
                    /*                    Cache.Remove("");*/
                }
                catch { }
                Response.Redirect("~/Modules/Forms/Seguimiento/frmMenu.aspx");
            }
        }




    }
}
