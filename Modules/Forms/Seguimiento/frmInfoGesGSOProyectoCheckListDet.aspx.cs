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
    public partial class frmInfoGesGSOProyectoCheckListDet : System.Web.UI.Page
    {

        private string pIdContrato;
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
            pIdContrato = "" + Request.Params["pIdContrato"];

        }



        #region OnLoadContratoCheckList
        protected void OnLoadContratoCheckList(object sender, EventArgs e)
        {
            this.SearchAllContratoCheckList();
        }
        #endregion

        #region SearchAllContratoCheckList
        private void SearchAllContratoCheckList()
        {

            DataSet ds3 = new DataSet();
            ds3 = Code.Logic.Forms.Seguimiento.GsoProyectoCheckList.SearchAllContratoCheckList(pIdContrato);
            ASPxGridViewContratoCheckList.KeyFieldName = "IDCONTRATOCHEKLIST";
            ASPxGridViewContratoCheckList.DataSource = ds3.Tables[0];
            ASPxGridViewContratoCheckList.DataBind();

        }
        #endregion

        #region OnLoadContratoTipologia
        protected void OnLoadContratoTipologia(object sender, EventArgs e)
        {
            this.SearchAllContratoTipologia();
        }
        #endregion

        #region SearchAllContratoTipologia
        private void SearchAllContratoTipologia()
        {

            //DataSet ds3 = new DataSet();
            //ds3 = Code.Logic.Forms.Seguimiento.GsoProyectoCheckList.SearchAllContratoTipologia(pIdContrato);
            //ASPxGridViewContratoActividad.KeyFieldName = "IDCHECKLIST";
            //ASPxGridViewContratoActividad.DataSource = ds3.Tables[0];
            //ASPxGridViewContratoActividad.DataBind();
        }
        #endregion

        #region OnLoadContratoCheckListDet
        protected void OnLoadContratoCheckListDet(object sender, EventArgs e)
        {
            this.SearchAllContratoCheckListDet();
        }
        #endregion

        protected void gvDetail_CustomCallbackGD(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            this.SearchAllContratoCheckListDet();
        }


        #region SearchAllContratoCheckListDet
        private void SearchAllContratoCheckListDet()
        {

            DataSet ds3 = new DataSet();


            //ds3 = Code.Logic.Forms.Seguimiento.GsoProyectoCheckList.SearchAllContratoCheckListDet(ASPxGridViewContratoActividad.GetMasterRowKeyValue().ToString());
            //string IdContrato = ASPxGridViewContratoActividad.GetRowValues(ASPxGridViewContratoActividad.FocusedRowIndex, "IDCHECKLIST").ToString();

            ds3 = Code.Logic.Forms.Seguimiento.GsoProyectoCheckList.SearchAllContratoCheckListDet(ASPxGridViewContratoCheckList.GetRowValues(ASPxGridViewContratoActividad.FocusedRowIndex, "IDCHECKLIST").ToString());
            //ds3 = Code.Logic.Forms.Seguimiento.GsoProyectoCheckList.SearchAllContratoCheckListDet("912");
            ASPxGridViewContratoCheckListDet.KeyFieldName = "IDCONTRATOCHECKLISTDET";
            ASPxGridViewContratoCheckListDet.DataSource = ds3.Tables[0];
            ASPxGridViewContratoCheckListDet.DataBind();
            ASPxGridViewContratoCheckListDet.GroupBy(ASPxGridViewContratoCheckListDet.Columns["CHECKLIST_DESCRIPCION"]);
            ASPxGridViewContratoCheckListDet.ExpandAll();
        }
        #endregion
    }
}
