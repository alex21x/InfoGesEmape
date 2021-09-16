using System;
using System.IO;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxEditors;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Native;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;



namespace InfoGesRegional.Modules.Forms.Consulta
{
    public partial class frmInfoGesConsultaActividadProyecto : System.Web.UI.Page
    {

        private string SSId_Operador;


        #region PageInit
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["baseURL"] == null)
                Session["baseURL"] = "frmInfoGesConsultaExpPopUp.aspx";
                                        

        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InfoGesRegional.Modules.MasterPage m = (InfoGesRegional.Modules.MasterPage)Page.Master;
            SSId_Operador = "1";
            Session["IdProyecto"] = "";
            if (!Page.IsPostBack)
            {
                //LoadEstadoRegistro();
                //this.LoadProyecto();

            }
        }

        #region LoadActProySiaf
        protected void LoadActProySiaf(object sender, EventArgs e)
        {
            this.SearchAllProyectoSnipSiaf();
        }
        #endregion

        #region hyperLink_InitEnero
        protected void hyperLink_InitEnero(object sender, EventArgs e)
        {
            ASPxHyperLink link = (ASPxHyperLink)sender;

            GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;

            int rowVisibleIndex = templateContainer.VisibleIndex;
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ANO_EJE").ToString() + "01" + templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString();
            string contentUrl = string.Format("{0}?pId={1}", Session["baseURL"], pId);

            link.NavigateUrl = "javascript:void(0);";

//            link.Text = string.Format("More Info: ID_TIPO_CAMBIO - {0}", pId);
            link.Text = string.Format("{0:C}", Convert.ToDecimal(templateContainer.Grid.GetRowValues(rowVisibleIndex, "ENERO").ToString())) ;
            link.ClientSideEvents.Click = string.Format("function(s, e) {{ OnMoreInfoClick('{0}'); }}", contentUrl);
        }

        protected void hyperLink_InitFebrero(object sender, EventArgs e)
        {
            ASPxHyperLink link = (ASPxHyperLink)sender;

            GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;

            int rowVisibleIndex = templateContainer.VisibleIndex;
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ANO_EJE").ToString() + "02" + templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString();
            string contentUrl = string.Format("{0}?pId={1}", Session["baseURL"], pId);

            link.NavigateUrl = "javascript:void(0);";
             link.Text = string.Format("{0:C}", Convert.ToDecimal(templateContainer.Grid.GetRowValues(rowVisibleIndex, "FEBRERO").ToString()));
            link.ClientSideEvents.Click = string.Format("function(s, e) {{ OnMoreInfoClick('{0}'); }}", contentUrl);
        }

        protected void hyperLink_InitMarzo(object sender, EventArgs e)
        {
            ASPxHyperLink link = (ASPxHyperLink)sender;

            GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;

            int rowVisibleIndex = templateContainer.VisibleIndex;
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ANO_EJE").ToString() + "03" + templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString();
            string contentUrl = string.Format("{0}?pId={1}", Session["baseURL"], pId);

            link.NavigateUrl = "javascript:void(0);";
             link.Text = string.Format("{0:C}", Convert.ToDecimal(templateContainer.Grid.GetRowValues(rowVisibleIndex, "MARZO").ToString()));
            link.ClientSideEvents.Click = string.Format("function(s, e) {{ OnMoreInfoClick('{0}'); }}", contentUrl);
        }

        protected void hyperLink_InitAbril(object sender, EventArgs e)
        {
            ASPxHyperLink link = (ASPxHyperLink)sender;

            GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;

            int rowVisibleIndex = templateContainer.VisibleIndex;
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ANO_EJE").ToString() + "04" + templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString();
            string contentUrl = string.Format("{0}?pId={1}", Session["baseURL"], pId);

            link.NavigateUrl = "javascript:void(0);";
             link.Text = string.Format("{0:C}", Convert.ToDecimal(templateContainer.Grid.GetRowValues(rowVisibleIndex, "ABRIL").ToString()));
            link.ClientSideEvents.Click = string.Format("function(s, e) {{ OnMoreInfoClick('{0}'); }}", contentUrl);
        }

        protected void hyperLink_InitMayo(object sender, EventArgs e)
        {
            ASPxHyperLink link = (ASPxHyperLink)sender;

            GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;

            int rowVisibleIndex = templateContainer.VisibleIndex;
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ANO_EJE").ToString() + "05" + templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString();
            string contentUrl = string.Format("{0}?pId={1}", Session["baseURL"], pId);

            link.NavigateUrl = "javascript:void(0);";
             link.Text = string.Format("{0:C}", Convert.ToDecimal(templateContainer.Grid.GetRowValues(rowVisibleIndex, "MAYO").ToString()));
            link.ClientSideEvents.Click = string.Format("function(s, e) {{ OnMoreInfoClick('{0}'); }}", contentUrl);
        }

        protected void hyperLink_InitJunio(object sender, EventArgs e)
        {
            ASPxHyperLink link = (ASPxHyperLink)sender;

            GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;

            int rowVisibleIndex = templateContainer.VisibleIndex;
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ANO_EJE").ToString() + "06" + templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString();
            string contentUrl = string.Format("{0}?pId={1}", Session["baseURL"], pId);

            link.NavigateUrl = "javascript:void(0);";
             link.Text = string.Format("{0:C}", Convert.ToDecimal(templateContainer.Grid.GetRowValues(rowVisibleIndex, "JUNIO").ToString()));
            link.ClientSideEvents.Click = string.Format("function(s, e) {{ OnMoreInfoClick('{0}'); }}", contentUrl);
        }

        protected void hyperLink_InitJulio(object sender, EventArgs e)
        {
            ASPxHyperLink link = (ASPxHyperLink)sender;

            GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;

            int rowVisibleIndex = templateContainer.VisibleIndex;
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ANO_EJE").ToString() + "07" + templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString();
            string contentUrl = string.Format("{0}?pId={1}", Session["baseURL"], pId);

            link.NavigateUrl = "javascript:void(0);";
             link.Text = string.Format("{0:C}", Convert.ToDecimal(templateContainer.Grid.GetRowValues(rowVisibleIndex, "JULIO").ToString()));
            link.ClientSideEvents.Click = string.Format("function(s, e) {{ OnMoreInfoClick('{0}'); }}", contentUrl);
        }

        protected void hyperLink_InitAgosto(object sender, EventArgs e)
        {
            ASPxHyperLink link = (ASPxHyperLink)sender;

            GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;

            int rowVisibleIndex = templateContainer.VisibleIndex;
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ANO_EJE").ToString() + "08" + templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString();
            string contentUrl = string.Format("{0}?pId={1}", Session["baseURL"], pId);

            link.NavigateUrl = "javascript:void(0);";
             link.Text = string.Format("{0:C}", Convert.ToDecimal(templateContainer.Grid.GetRowValues(rowVisibleIndex, "AGOSTO").ToString()));
            link.ClientSideEvents.Click = string.Format("function(s, e) {{ OnMoreInfoClick('{0}'); }}", contentUrl);
        }

        protected void hyperLink_InitSetiembre(object sender, EventArgs e)
        {
            ASPxHyperLink link = (ASPxHyperLink)sender;

            GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;

            int rowVisibleIndex = templateContainer.VisibleIndex;
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ANO_EJE").ToString() + "09" + templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString();
            string contentUrl = string.Format("{0}?pId={1}", Session["baseURL"], pId);

            link.NavigateUrl = "javascript:void(0);";
             link.Text = string.Format("{0:C}", Convert.ToDecimal(templateContainer.Grid.GetRowValues(rowVisibleIndex, "SETIEMBRE").ToString()));
            link.ClientSideEvents.Click = string.Format("function(s, e) {{ OnMoreInfoClick('{0}'); }}", contentUrl);
        }

        protected void hyperLink_InitOctubre(object sender, EventArgs e)
        {
            ASPxHyperLink link = (ASPxHyperLink)sender;

            GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;

            int rowVisibleIndex = templateContainer.VisibleIndex;
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ANO_EJE").ToString() + "10" + templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString();
            string contentUrl = string.Format("{0}?pId={1}", Session["baseURL"], pId);

            link.NavigateUrl = "javascript:void(0);";
             link.Text = string.Format("{0:C}", Convert.ToDecimal(templateContainer.Grid.GetRowValues(rowVisibleIndex, "OCTUBRE").ToString()));
            link.ClientSideEvents.Click = string.Format("function(s, e) {{ OnMoreInfoClick('{0}'); }}", contentUrl);
        }

        protected void hyperLink_InitNoviembre(object sender, EventArgs e)
        {
            ASPxHyperLink link = (ASPxHyperLink)sender;

            GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;

            int rowVisibleIndex = templateContainer.VisibleIndex;
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ANO_EJE").ToString() + "11" + templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString();
            string contentUrl = string.Format("{0}?pId={1}", Session["baseURL"], pId);

            link.NavigateUrl = "javascript:void(0);";
             link.Text = string.Format("{0:C}", Convert.ToDecimal(templateContainer.Grid.GetRowValues(rowVisibleIndex, "NOVIEMBRE").ToString()));
            link.ClientSideEvents.Click = string.Format("function(s, e) {{ OnMoreInfoClick('{0}'); }}", contentUrl);
        }

        protected void hyperLink_InitDiciembre(object sender, EventArgs e)
        {
            ASPxHyperLink link = (ASPxHyperLink)sender;

            GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;

            int rowVisibleIndex = templateContainer.VisibleIndex;
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ANO_EJE").ToString() + "12" + templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString();
            string contentUrl = string.Format("{0}?pId={1}", Session["baseURL"], pId);

            link.NavigateUrl = "javascript:void(0);";
             link.Text = string.Format("{0:C}", Convert.ToDecimal(templateContainer.Grid.GetRowValues(rowVisibleIndex, "DICIEMBRE").ToString()));
            link.ClientSideEvents.Click = string.Format("function(s, e) {{ OnMoreInfoClick('{0}'); }}", contentUrl);
        }
        protected void hyperLink_InitTotal(object sender, EventArgs e)
        {
            ASPxHyperLink link = (ASPxHyperLink)sender;

            GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;

            int rowVisibleIndex = templateContainer.VisibleIndex;
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ANO_EJE").ToString() + "13" + templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString();
            string contentUrl = string.Format("{0}?pId={1}", Session["baseURL"], pId);

            link.NavigateUrl = "javascript:void(0);";
            link.Text = string.Format("{0:C}", Convert.ToDecimal(templateContainer.Grid.GetRowValues(rowVisibleIndex, "TOTAL_EJECUTADO").ToString()));
            link.ClientSideEvents.Click = string.Format("function(s, e) {{ OnMoreInfoClick('{0}'); }}", contentUrl);
        }

        #endregion

        #region SearchAllProyectoSnipSiaf
        protected void SearchAllProyectoSnipSiaf()
        {
            DataSet ds4 = new DataSet();
            ds4 = Code.Logic.Forms.Consulta.EjecucionxActProy.SearchEjecucionGastoxMesTotal();

            ASPxGridviewConsultaSnipFinanciero.DataSource = ds4.Tables[0];
            ASPxGridviewConsultaSnipFinanciero.DataBind();

            //ASpxGridGroupSummaryLocal("COMPROMETIDO_ANUAL",sender);
            //ASpxGridGroupSummaryLocal("COMPROMISO", sender);
            //ASpxGridGroupSummaryLocal("DEVENGADO", sender);
            //ASpxGridGroupSummaryLocal("DEVENGADO", sender);
            //ASpxGridGroupSummaryLocal("GIRADO", sender);

            ASPxGridviewConsultaSnipFinanciero.GroupBy(ASPxGridviewConsultaSnipFinanciero.Columns["ACT_PROY_NOMBRE"]);
            ASPxGridviewConsultaSnipFinanciero.ExpandAll();
            
        }
        #endregion
    }
}
