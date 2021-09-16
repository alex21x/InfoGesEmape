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


namespace InfoGesRegional.Modules.Forms.Consulta
{
    public partial class frmEjecucionGastoProyectoSnip : System.Web.UI.Page
    {

         #region PageInit
        protected void Page_Init(object sender, EventArgs e)
        {
            //if (Session["baseURL"] == null)
                Session["baseURL"] = "frmInfoGesConsultaEjecutoraExpPopUp.aspx";

        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InfoGesRegional.Modules.MasterPage m = (InfoGesRegional.Modules.MasterPage)Page.Master;
            if (!Page.IsPostBack)
            {
                this.LoadEjecutora();
            }
        }

        #region OnSelectedindexChangedEjecutora
        public void OnSelectedindexChangedEjecutora(object sender, EventArgs e)
        {
            CboPeriodo.SelectedIndex = 0;
            CboProductoProyecto.SelectedIndex = 0;
            this.LoadPeriodo();
        }
        #endregion

        #region OnSelectedindexChangedPeriodo
        public void OnSelectedindexChangedPeriodo(object sender, EventArgs e)
        {
            CboProductoProyecto.SelectedIndex = 0;

            this.LoadProductoProyecto();
        }
        #endregion

        #region OnSelectedindexChangedProductoProyecto
        public void OnSelectedindexChangedProductoProyecto(object sender, EventArgs e)
        {
            this.SearchAllProyectoSnipSiaf();
        }
        #endregion

        #region OnSelectedindexChangedMeta
        public void OnSelectedindexChangedMeta(object sender, EventArgs e)
        {
            this.SearchAllProyectoSnipSiaf();
        }
        #endregion

        #region LoadEjecutora
        protected void LoadEjecutora()
        {
            DataSet ds1 = Code.Logic.Forms.Consulta.Ejecutora.SearchAllEjecutora();
            CboEjecutora.DataSource = ds1.Tables[0];
            CboEjecutora.TextField = ds1.Tables[0].Columns["DESCRIPCION_SEC_EJEC"].Caption.ToString();
            CboEjecutora.ValueField = ds1.Tables[0].Columns["SEC_EJEC"].Caption.ToString();
            CboEjecutora.DataBind();
            CboEjecutora.SelectedIndex = 0;
            ds1.Dispose();
            ds1 = null;
            this.LoadPeriodo();
        }
        #endregion

        #region LoadPeriodo
        protected void LoadPeriodo()
        {
            DataSet ds1 = Code.Logic.Forms.Consulta.Periodo.SearchAllPeriodo2009(CboEjecutora.Value.ToString());
            CboPeriodo.DataSource = ds1.Tables[0];
            CboPeriodo.TextField = ds1.Tables[0].Columns["DESCRIPCION_ANO_EJE"].Caption.ToString();
            CboPeriodo.ValueField = ds1.Tables[0].Columns["ANO_EJE"].Caption.ToString();
            CboPeriodo.DataBind();
            CboPeriodo.SelectedIndex = 0;
            ds1.Dispose();
            ds1 = null;
            this.LoadProductoProyecto();

        }
        #endregion

        #region LoadProductoProyecto
        protected void LoadProductoProyecto()
        {
            DataSet ds1 = Code.Logic.Forms.Consulta.Act_Proy.SearchAllProductoProyectoResumenSolo(CboPeriodo.Value.ToString(), CboEjecutora.Value.ToString());
            CboProductoProyecto.DataSource = ds1.Tables[0];
            CboProductoProyecto.TextField = ds1.Tables[0].Columns["ACT_PROY_NOMBRE"].Caption.ToString();
            CboProductoProyecto.ValueField = ds1.Tables[0].Columns["ACT_PROY"].Caption.ToString();
            CboProductoProyecto.DataBind();
            CboProductoProyecto.SelectedIndex = 0;
            ds1.Dispose();
            ds1 = null;
            SearchAllProyectoSnipSiaf();
        }
        #endregion
  
        #region LoadProyectoSnipSiaf
        protected void LoadProyectoSnipSiaf(object sender, EventArgs e)
        {
            this.SearchAllProyectoSnipSiaf();
        }
        #endregion

        #region SearchAllProyectoSnipSiaf
        protected void SearchAllProyectoSnipSiaf()
        {
            string x;
            if(CboProductoProyecto.Value==null)
                x ="1";

            DataSet ds4 = new DataSet();
            ds4 = Code.Logic.Forms.Consulta.EjecucionGasto.SearchAllEjecucionGastoProyectoSnip2009(
                CboPeriodo.Value.ToString(),
                CboEjecutora.Value.ToString(),
                CboProductoProyecto.Value.ToString());
 
            ASPxGridviewConsultaSnipFinanciero.DataSource = ds4.Tables[0];
            ASPxGridviewConsultaSnipFinanciero.DataBind();

            //ASpxGridGroupSummaryLocal("COMPROMETIDO_ANUAL",sender);
            //ASpxGridGroupSummaryLocal("COMPROMISO", sender);
            //ASpxGridGroupSummaryLocal("DEVENGADO", sender);
            //ASpxGridGroupSummaryLocal("DEVENGADO", sender);
            //ASpxGridGroupSummaryLocal("GIRADO", sender);

            ASPxGridviewConsultaSnipFinanciero.GroupBy(ASPxGridviewConsultaSnipFinanciero.Columns["PROYECTO_SNIP_NOMBRE"]);
            ASPxGridviewConsultaSnipFinanciero.GroupBy(ASPxGridviewConsultaSnipFinanciero.Columns["ANO_EJE"]);
            ASPxGridviewConsultaSnipFinanciero.GroupBy(ASPxGridviewConsultaSnipFinanciero.Columns["FUENTE_FINANC_NOMBRE"]);

            this.ASPxGridviewConsultaSnipFinanciero.ExpandAll();

        }
        #endregion

        #region hyperLink_InitEnero
        protected void hyperLink_InitEnero(object sender, EventArgs e)
        {
            ASPxHyperLink link = (ASPxHyperLink)sender;

            GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;

            int rowVisibleIndex = templateContainer.VisibleIndex;
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ANO_EJE").ToString() + "01"
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "SEC_EJEC").ToString()
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "FUENTE_FINANC").ToString()
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "ID_CLASIFICADOR").ToString()
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString();
            string contentUrl = string.Format("{0}?pId={1}", Session["baseURL"], pId);

            link.NavigateUrl = "javascript:void(0);";

            //            link.Text = string.Format("More Info: ID_TIPO_CAMBIO - {0}", pId);
            link.Text = string.Format("{0:C}", Convert.ToDecimal(templateContainer.Grid.GetRowValues(rowVisibleIndex, "ENERO").ToString()));
            link.ClientSideEvents.Click = string.Format("function(s, e) {{ OnMoreInfoClick('{0}'); }}", contentUrl);
        }

        protected void hyperLink_InitFebrero(object sender, EventArgs e)
        {
            ASPxHyperLink link = (ASPxHyperLink)sender;

            GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;

            int rowVisibleIndex = templateContainer.VisibleIndex;
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ANO_EJE").ToString() + "02" 
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "SEC_EJEC").ToString()
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "FUENTE_FINANC").ToString()
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "ID_CLASIFICADOR").ToString()
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString();

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
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ANO_EJE").ToString() + "03"
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "SEC_EJEC").ToString()
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "FUENTE_FINANC").ToString()
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "ID_CLASIFICADOR").ToString()
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString();

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
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ANO_EJE").ToString() + "04"
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "SEC_EJEC").ToString()
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "FUENTE_FINANC").ToString()
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "ID_CLASIFICADOR").ToString()
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString();

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
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ANO_EJE").ToString() + "05"
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "SEC_EJEC").ToString()
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "FUENTE_FINANC").ToString()
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "ID_CLASIFICADOR").ToString()
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString();

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
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ANO_EJE").ToString() + "06"
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "SEC_EJEC").ToString()
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "FUENTE_FINANC").ToString()
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "ID_CLASIFICADOR").ToString()
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString();

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
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ANO_EJE").ToString() + "07"
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "SEC_EJEC").ToString()
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "FUENTE_FINANC").ToString()
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "ID_CLASIFICADOR").ToString()
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString();

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
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ANO_EJE").ToString() + "08"
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "SEC_EJEC").ToString()
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "FUENTE_FINANC").ToString()
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "ID_CLASIFICADOR").ToString()
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString();

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
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ANO_EJE").ToString() + "09"
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "SEC_EJEC").ToString()
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "FUENTE_FINANC").ToString()
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "ID_CLASIFICADOR").ToString()
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString();

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
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ANO_EJE").ToString() + "10"
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "SEC_EJEC").ToString()
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "FUENTE_FINANC").ToString()
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "ID_CLASIFICADOR").ToString()
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString();

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
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ANO_EJE").ToString() + "11"
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "SEC_EJEC").ToString()
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "FUENTE_FINANC").ToString()
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "ID_CLASIFICADOR").ToString()
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString();

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
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ANO_EJE").ToString() + "12"
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "SEC_EJEC").ToString()
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "FUENTE_FINANC").ToString()
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "ID_CLASIFICADOR").ToString()
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString();

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
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ANO_EJE").ToString() + "13"
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "SEC_EJEC").ToString()
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "FUENTE_FINANC").ToString()
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "ID_CLASIFICADOR").ToString()
                        + templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString();

            string contentUrl = string.Format("{0}?pId={1}", Session["baseURL"], pId);

            link.NavigateUrl = "javascript:void(0);";
            link.Text = string.Format("{0:C}", Convert.ToDecimal(templateContainer.Grid.GetRowValues(rowVisibleIndex, "TOTAL_EJECUTADO").ToString()));
            link.ClientSideEvents.Click = string.Format("function(s, e) {{ OnMoreInfoClick('{0}'); }}", contentUrl);
        }

        #endregion

        protected void btnXlsExport_Click(object sender, EventArgs e)
        {
            gridExport.WriteXlsToResponse();
        }

    }
}
