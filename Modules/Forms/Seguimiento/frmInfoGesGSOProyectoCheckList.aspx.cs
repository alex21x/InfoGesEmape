using System;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Data;
using DevExpress.Web;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.ConnectionParameters;

//<dx:GridViewDataTextColumn Caption="ACTIVAR" Name="colAction"  HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" VisibleIndex="0"  CellStyle-HorizontalAlign="Center">
//    <HeaderStyle HorizontalAlign="Center" />
//    <DataItemTemplate>
//        <asp:LinkButton ID="LinkButton1" CommandArgument='<%# Eval("ACT_PROY") %>' CommandName="Select" runat="server">Activar</asp:LinkButton>
//    </DataItemTemplate>
//</dx:GridViewDataTextColumn>

namespace InfoGesRegional.Modules.Forms.Seguimiento
{
    public partial class frmInfoGesGSOProyectoCheckList : System.Web.UI.Page
    {
        string lcLike1, lcLike2;
        #region PageInit
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
            if (Context.User.Identity.IsAuthenticated)
            { 
            }
            else
            Response.Redirect("~/Default.aspx");

        }
        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {
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
            ds3 = Code.Logic.Forms.Seguimiento.GsoProyectoCheckList.SearchAll("");
            ASPxGridviewProyecto.KeyFieldName = "IDCONTRATO";
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
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "IDCONTRATO").ToString();
            string contentUrl = "frmInfoGesGSOProyectoCheckListDet.aspx" + "?pIdContrato=" + pId;
            link.NavigateUrl = "javascript:void(0);";
            link.Text = string.Format("{0}", templateContainer.Grid.GetRowValues(rowVisibleIndex, "CUI").ToString());
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

        #region EvtRowCommand
        protected void EvtRowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
        {
            if (e.CommandArgs.CommandName == "Select")
            {
                //int id = Convert.ToInt32(e.CommandArgs.CommandArgument);
                ////Aqui se pone el codigo de cache
                //DataSet ds1 = new DataSet();
                //ds1 = Code.Logic.Forms.Seguimiento.Proyecto.GetByIdCache(id.ToString(), SSId_Operador.ToString());
                //Session["IdProyecto"] = ds1.Tables[0].Rows[0]["ID_PROYECTO"].ToString();
                //Session["DescProyecto"] = ds1.Tables[0].Rows[0]["COD_PROYECTO"].ToString();
                //try
                //{
                //    /*                    Cache.Remove("");*/
                //}
                //catch { }
                Response.Redirect("~/Modules/Forms/Seguimiento/frmMenu.aspx");
            }
        }
        #endregion



    }
}
