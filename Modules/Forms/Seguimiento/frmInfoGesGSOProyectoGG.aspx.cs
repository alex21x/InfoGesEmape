using System;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Data;
using System.Resources;
using DevExpress.Web;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.ConnectionParameters;

//<dx:GridViewDataTextColumn Caption="ACTIVAR" Name="colAction"  HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" VisibleIndex="0"  CellStyle-HorizontalAlign="Center">
//    <HeaderStyle HorizontalAlign="Center" />
//    <DataItemTemplate>
//        <asp:LinkButton ID="LinkButton1" CommandArgument='<%# Eval("ACT_PROY") %>' CommandName="Select" runat="server">Activar</asp:LinkButton>
//    </DataItemTemplate>
//</dx:GridViewDataTextColumn>
//https://docs.devexpress.com/AspNet/DevExpress.Web.GridConditionIconSetFormat
//https://docs.devexpress.com/AspNet/7830/components/grid-view/concepts/format-data/format-condition-types

namespace InfogesEmape.Modules.Forms.Seguimiento
{
    public partial class frmInfoGesGSOProyectoGG : System.Web.UI.Page
    {

        #region PageInit
        protected void Page_Init(object sender, EventArgs e)
        {
            this.LoadActividad();
            this.LoadTipoProyecto();
            this.LoadDistrito();
            this.LoadProyecto();

            PopulateGridFormatConditions();

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

            this.LoadProyecto();
        }
        #endregion

			private void LoadProyecto()
			{
            
				DataSet ds3 = new DataSet();
				ds3 = Code.Logic.Forms.Seguimiento.GsoProyecto.SearchAllProyectoGG(CboDistrito.Value.ToString(), CboActividad.Value.ToString(), CboTipoProyecto.Value.ToString());
            ASPxGridviewProyecto.KeyFieldName = "ACT_PROY";
            ASPxGridviewProyecto.DataSource = ds3.Tables[0];

            ASPxGridviewProyecto.DataBind();
        }

        protected void image_Init(object sender, EventArgs e)
        {
            ASPxImage image = sender as ASPxImage;
            GridViewDataItemTemplateContainer container = image.NamingContainer as GridViewDataItemTemplateContainer;
            int value = Convert.ToInt32(DataBinder.Eval(container.DataItem, "AVANCE"));
            int measure = Convert.ToInt32(value);
            if (measure < 50 && measure > 30)
                image.EmptyImage.IconID = "actions_about_16x16devav";
            else if (measure <= 30)
                image.EmptyImage.IconID = "actions_apply_16x16office2013";
            else
                image.EmptyImage.IconID = "navigation_backward_16x16office2013";
        }

        #region hyperLink_InitPROYECTOSNIP
        protected void hyperLink_InitPROYECTOSNIP(object sender, EventArgs e)
        {
            ASPxHyperLink link = (ASPxHyperLink)sender;

            GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;

            int rowVisibleIndex = templateContainer.VisibleIndex;
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString();
               templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString();
            string contentUrl = "";
            if(Convert.ToInt32(templateContainer.Grid.GetRowValues(rowVisibleIndex, "RESTO"))<0)
                contentUrl = "frmInfoGesGSOSRptGG.aspx" + "?pActProy=" + pId + "1";
            else
                contentUrl = "frmInfoGesGSOSRptGG.aspx" + "?pActProy=" + pId + "0";
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
            //int Id = (int)e.Keys["ID_PROYECTO"];
            //string Cadena = Code.Logic.Forms.Seguimiento.Proyecto.Delete_Proyecto(Id.ToString());

            //if (Cadena.ToString().Length != 0)
            //{
            //    throw new Exception(Cadena);
            //}
            //else
            //{
            //    Get_ASPxGridView_Proyecto();
            //}
            //Response.Redirect("~/Modules/Forms/Seguimiento/frmMenu.aspx");


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

        protected void ASPxDashboardViewer1_ConfigureDataConnection(object sender, DevExpress.DashboardWeb.ConfigureDataConnectionWebEventArgs e)
        {
            MySqlConnectionParameters mysqlParams = new MySqlConnectionParameters();
            mysqlParams.ServerName = "localhost";
            mysqlParams.DatabaseName = "obras";
            mysqlParams.UserName = "root";
            mysqlParams.Password = "7654321";
            e.ConnectionParameters = mysqlParams;
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

        #region LoadActividad
        protected void LoadActividad()
        {
            DataSet ds1 = Code.Logic.Forms.Consulta.MaestroDetalle.SearchByMaestroDetalle("9","0");
            CboActividad.DataSource = ds1.Tables[0];
            CboActividad.TextField = ds1.Tables[0].Columns["ABREVIATURA"].Caption.ToString();
            CboActividad.ValueField = ds1.Tables[0].Columns["ABREVIATURA"].Caption.ToString();
            CboActividad.DataBind();
            ds1.Dispose();
            ds1 = null;
        }
        #endregion

        #region LoadTipoProyecto
        protected void LoadTipoProyecto()
        {
            DataSet ds1 = Code.Logic.Forms.Consulta.MaestroDetalle.SearchByMaestroDetalle("7", "0");

            CboTipoProyecto.DataSource = ds1.Tables[0];
            CboTipoProyecto.TextField = ds1.Tables[0].Columns["ABREVIATURA"].Caption.ToString();
            CboTipoProyecto.ValueField = ds1.Tables[0].Columns["ABREVIATURA"].Caption.ToString();
            CboTipoProyecto.DataBind();
            ds1.Dispose();
            ds1 = null;
        }
        #endregion

        #region LoadDistrito
        protected void LoadDistrito()
        {
            DataSet ds1 = Code.Logic.Forms.Consulta.MaestroDetalle.SearchByDistrito();

            CboDistrito.DataSource = ds1.Tables[0];
            CboDistrito.TextField = ds1.Tables[0].Columns["DISTRITO"].Caption.ToString();
            CboDistrito.ValueField = ds1.Tables[0].Columns["DISTRITO"].Caption.ToString();
            CboDistrito.DataBind();
            ds1.Dispose();
            ds1 = null;
        }
        #endregion

        protected void PopulateGridFormatConditions()
        {
            //const string IconSetSpriteResourceName = "DevExpress.Web.Css.FCISprite.css";

            //ASPxGridviewProyecto.FormatConditions.Clear();


            //var condition1 = new GridViewFormatConditionHighlight
            //{
            //    Rule = GridConditionRule.GreaterOrEqual,
            //    Value1 = 50,
            //    FieldName = "AVANCE"
            //};
            //condition1.Format = GridConditionHighlightFormat.Custom;
            //condition1.CellStyle.CssClass = "dxFCRule dxWeb_fcIcons_Arrows5_4";
            //ASPxGridviewProyecto.FormatConditions.Add(condition1);


    
            //var condition2 = new GridViewFormatConditionHighlight { Rule = GridConditionRule.Between, Value1 = 20, Value2 = 50, FieldName = "AVANCE" };
            //condition2.Format = GridConditionHighlightFormat.Custom;
            //condition2.CellStyle.CssClass = "dxFCRule dxWeb_fcIcons_Arrows5_3";
            //ASPxGridviewProyecto.FormatConditions.Add(condition2);

            //var condition3 = new GridViewFormatConditionHighlight { Rule = GridConditionRule.Less, Value1 = 20, FieldName = "AVANCE" };
            //condition3.Format = GridConditionHighlightFormat.Custom;
            //condition3.CellStyle.CssClass = "dxFCRule dxWeb_fcIcons_Arrows5_5";
            //ASPxGridviewProyecto.FormatConditions.Add(condition3);

            ////var condition3 = new GridViewFormatConditionHighlight { Rule = GridConditionRule.Less, Value1 = 20, FieldName = "UnitsInStock" };
            ////condition3.Format = GridConditionHighlightFormat.Custom;
            ////condition3.CellStyle.CssClass = "dxFCRule dxWeb_fcIcons_Arrows5_5";
            ////ASPxGridviewProyecto.FormatConditions.Add(condition3);

            ////ResourceManager.RegisterCssResource(Page, typeof(ASPxWebControl), IconSetSpriteResourceName);
            ////ResourceManager.RegisterCssResource(Page, typeof(ASPxWebControl), IconSetSpriteResourceName);

            GridViewFormatConditionIconSet Rule = new GridViewFormatConditionIconSet();
            Rule.FieldName = "SALDO";
            Rule.MinimumValue = 0;
            Rule.MaximumValue = 20000000;
            Rule.Format = GridConditionIconSetFormat.Ratings5;
            ASPxGridviewProyecto.FormatConditions.Add(Rule);

            GridViewFormatConditionIconSet Rule1 = new GridViewFormatConditionIconSet();
            Rule1.FieldName = "AVANCE";
            Rule1.MinimumValue = 0;
            Rule1.MaximumValue = 100; 
            Rule1.Format = GridConditionIconSetFormat.Quarters5;
            ASPxGridviewProyecto.FormatConditions.Add(Rule1);

            //CardViewFormatConditionIconSet Format4 = new CardViewFormatConditionIconSet();
            //Format4.FieldName = "SALDO";
            //Format4.Format = GridConditionIconSetFormat.Arrows3Colored;
            //Format4.MinimumValue = 0;
            //Format4.MaximumValue = 2000000000;
            //ASPxGridviewProyecto.FormatConditions.Add(Format4);

        }
    }
}
