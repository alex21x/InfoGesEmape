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
    public partial class PruebafrmEjecucionGastoPimCertificacion : System.Web.UI.Page
    {

         #region PageInit
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["baseURL"] == null)
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
            CboCentroCosto.SelectedIndex = 0;
            CboCadFuncional.SelectedIndex = 0;
            this.LoadPeriodo();
        }
        #endregion

        #region OnSelectedindexChangedPeriodo
        public void OnSelectedindexChangedPeriodo(object sender, EventArgs e)
        {
            CboCentroCosto.SelectedIndex = 0;
            CboCadFuncional.SelectedIndex = 0;

            this.LoadCentroCosto();
        }
        #endregion

        #region OnSelectedindexChangedCentroCosto
        public void OnSelectedindexChangedCentroCosto(object sender, EventArgs e)
        {
            CboCadFuncional.SelectedIndex = 0;
            this.LoadMeta();
            
        }
        #endregion


        #region OnSelectedindexChangedSec_Func
        public void OnSelectedindexChangedSec_Func(object sender, EventArgs e)
        {
            this.SearchAllSecFunc();
        }
        #endregion

        #region OnSelectedindexChangedMeta
        public void OnSelectedindexChangedMeta(object sender, EventArgs e)
        {
            this.SearchAllSecFunc();
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
            DataSet ds1 = Code.Logic.Forms.Consulta.Periodo.SearchAllPeriodoSolo2009(CboEjecutora.Value.ToString());
            CboPeriodo.DataSource = ds1.Tables[0];
            CboPeriodo.TextField = ds1.Tables[0].Columns["DESCRIPCION_ANO_EJE"].Caption.ToString();
            CboPeriodo.ValueField = ds1.Tables[0].Columns["ANO_EJE"].Caption.ToString();
            CboPeriodo.DataBind();
            CboPeriodo.SelectedIndex = 0;
            ds1.Dispose();
            ds1 = null;
            this.LoadCentroCosto();

        }
        #endregion

        #region LoadCentroCosto
        protected void LoadCentroCosto()
        {
            DataSet ds1 = Code.Logic.Forms.Consulta.CentroCosto.SearchAllCentroCosto(CboPeriodo.Value.ToString(), CboEjecutora.Value.ToString());
            CboCentroCosto.DataSource = ds1.Tables[0];
            CboCentroCosto.TextField = ds1.Tables[0].Columns["CENTRO_COSTO_NOMBRE"].Caption.ToString();
            CboCentroCosto.ValueField = ds1.Tables[0].Columns["CENTRO_COSTO"].Caption.ToString();
            CboCentroCosto.DataBind();
            CboCentroCosto.SelectedIndex = 0;
            ds1.Dispose();
            ds1 = null;
            this.LoadMeta();
        }
        #endregion

        #region LoadMeta
        protected void LoadMeta()
        {
            DataSet ds1 = Code.Logic.Forms.Consulta.Meta.SearchAllCadFuncionalCentroCosto2009(CboPeriodo.Value.ToString(), CboEjecutora.Value.ToString(),CboCentroCosto.Value.ToString());
            CboCadFuncional.DataSource = ds1.Tables[0];
            CboCadFuncional.TextField = ds1.Tables[0].Columns["CADFUNCIONAL_NOMBRE"].Caption.ToString();
            CboCadFuncional.ValueField = ds1.Tables[0].Columns["CADFUNCIONAL"].Caption.ToString();
            CboCadFuncional.DataBind();
            CboCadFuncional.SelectedIndex = 0;
            ds1.Dispose();
            ds1 = null;
            SearchAllSecFunc();
        }
        #endregion
  
        #region LoadProyectoSnipSiaf
        protected void LoadProyectoSnipSiaf(object sender, EventArgs e)
        {
            this.SearchAllSecFunc();
        }
        #endregion

        #region SearchAllSecFunc
        protected void SearchAllSecFunc()
        {
            string x;
            if(CboCadFuncional.Value==null)
                x ="1";

            DataSet ds4 = new DataSet();
            ds4 = Code.Logic.Forms.Consulta.EjecucionGasto.SearchAllCertificacionPim2009(
                CboPeriodo.Value.ToString(),
                CboEjecutora.Value.ToString(),
                CboCentroCosto.Value.ToString(),
                CboCadFuncional.Value.ToString());
 
            ASPxGridviewConsultaSnipFinanciero.DataSource = ds4.Tables[0];
            ASPxGridviewConsultaSnipFinanciero.ExpandToLevel(2);
            ASPxGridviewConsultaSnipFinanciero.DataBind();

        
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
            //gridExport.WriteXlsToResponse();
        }

    }
}
