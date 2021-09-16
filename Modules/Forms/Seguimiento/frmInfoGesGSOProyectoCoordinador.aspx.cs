using System;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Data;
using DevExpress.Web;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.ConnectionParameters;


namespace InfogesEmape.Modules.Forms.Seguimiento
{
    public partial class frmInfoGesGSOProyectoCoordinador : System.Web.UI.Page
    {
        string lcLike1, lcLike2;
        #region PageInit
        protected void Page_Init(object sender, EventArgs e)
        {



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
            XtraReport report = XtraReport.FromFile(Server.MapPath(@"~\Reports\RptGanttProyecto.repx"), true);




        }

        #region LoadProyecto
        protected void LoadProyecto(object sender, EventArgs e)
        {
            this.SearchAllProyecto(sender);
        }
        #endregion

        #region SearchAllProyecto
        private void SearchAllProyecto(object sender)
        {

            DataSet ds3 = new DataSet();
            ds3 = Code.Logic.Forms.Seguimiento.GsoProyecto.SearchAllCoordinador((string)(Session["IdDni"]));
            ASPxGridviewProyecto.KeyFieldName = "ACT_PROY";
            ASPxGridviewProyecto.DataSource = ds3.Tables[0];

            ASPxGridviewProyecto.DataBind();
        }
        #endregion


        #region hyperLink_InitPROYECTOSNIP
        protected void hyperLink_InitPROYECTOSNIP(object sender, EventArgs e)
        {
            ASPxHyperLink link = (ASPxHyperLink)sender;

            GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;

            int rowVisibleIndex = templateContainer.VisibleIndex;
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString();
            string contentUrl = "frmInfoGesGSOSReports2.aspx" + "?pActProy=" + pId;
            link.NavigateUrl = "javascript:void(0);";
            link.Text = string.Format("{0}", templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString());
            link.ClientSideEvents.Click = string.Format("function(s, e) {{ OnMoreInfoClick('{0}'); }}", contentUrl);
        }
        #endregion



        #region hyperLinkInitAvancePDF
        protected void hyperLinkInitAvancePDF(object sender, EventArgs e)
        {
            ASPxHyperLink link = (ASPxHyperLink)sender;

            GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;

            int rowVisibleIndex = templateContainer.VisibleIndex;
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString();
            string contentUrl = "frmInfoGesGsoProyectoRegistroPdf.aspx" + "?pActProy=" + pId;
            link.NavigateUrl = "javascript:void(0);";
            link.Text = string.Format("{0}", templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString());
            link.ClientSideEvents.Click = string.Format("function(s, e) {{ OnMoreInfoClick1('{0}'); }}", contentUrl);
        }
        #endregion

        #region Delete_ASPxGridviewProyecto
        protected void Delete_ASPxGridviewProyecto(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {

        }
        #endregion

        #region EvtRowCommand
        protected void EvtRowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
        {
            if (e.CommandArgs.CommandName == "Select")
            {
                Response.Redirect("~/Modules/Forms/Seguimiento/frmMenu.aspx");
            }
        }
		#endregion

		protected void ASPxPageControl1_ActiveTabChanged(object source, TabControlEventArgs e)
		{

		}

		protected void ASPxDashboardViewer1_ConfigureDataConnection(object sender, DevExpress.DashboardWeb.ConfigureDataConnectionWebEventArgs e)
        {
            MySqlConnectionParameters mysqlParams = new MySqlConnectionParameters();
            mysqlParams.ServerName = "localhost";
            mysqlParams.DatabaseName = "obras";
            mysqlParams.UserName = "root";
            mysqlParams.Password = "7654321";
            e.ConnectionParameters = mysqlParams;
        }
    }
}
