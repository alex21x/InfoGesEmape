using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxEditors;

namespace InfoGesRegional.Modules.Forms.Consulta
{
    public partial class frmInfoGesConsultaEjecutoraClasif : System.Web.UI.Page
    {
        private string pIdEjecucion;

        #region PageInit
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["baseClasif"] == null)
                Session["baseClasif"] = "frmInfoGesConsultaEjecutoraExpPopUp.aspx";

        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            pIdEjecucion = "" + Request.Params["pId"];

        }
        #region LoadASPxGridview
        protected void LoadASPxGridview(object sender, EventArgs e)
        {
            DataSet ds3 = new DataSet();

            ds3 = Code.Logic.Forms.Consulta.ConsultaEjecutoraClasificador.SearchConsultaEjecutoraClasif(pIdEjecucion);
            ASPxGridview1.DataSource = ds3.Tables[0];
            ASPxGridview1.DataBind();
            ASPxGridview1.GroupBy(ASPxGridview1.Columns["FUENTE_FINANC_NOMBRE"]);
            this.ASPxGridview1.ExpandAll();
        }
        #endregion

        protected void btnXlsExport_Click(object sender, EventArgs e)
        {
            gridExport.WriteXlsToResponse();
        }

        #region hyperLink_Init
        protected void hyperLink_InitEnero(object sender, EventArgs e)
        {
            ASPxHyperLink link = (ASPxHyperLink)sender;

            GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;

            int rowVisibleIndex = templateContainer.VisibleIndex;
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ANO_EJE").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "SEC_EJEC").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "FASE").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "FUENTE_FINANC").ToString() + "01"+
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "ID_CLASIFICADOR").ToString();
            string contentUrl = string.Format("{0}?pId={1}", Session["baseClasif"], pId);

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
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ANO_EJE").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "SEC_EJEC").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "FASE").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "FUENTE_FINANC").ToString() + "02"+
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "ID_CLASIFICADOR").ToString();            
            string contentUrl = string.Format("{0}?pId={1}", Session["baseClasif"], pId);

            link.NavigateUrl = "javascript:void(0);";
            link.Text = string.Format("{0:C}", Convert.ToDecimal(templateContainer.Grid.GetRowValues(rowVisibleIndex, "FEBRERO").ToString()));
            link.ClientSideEvents.Click = string.Format("function(s, e) {{ OnMoreInfoClick('{0}'); }}", contentUrl);
        }

        protected void hyperLink_InitMarzo(object sender, EventArgs e)
        {
            ASPxHyperLink link = (ASPxHyperLink)sender;

            GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;

            int rowVisibleIndex = templateContainer.VisibleIndex;
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ANO_EJE").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "SEC_EJEC").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "FASE").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "FUENTE_FINANC").ToString() + "03"+
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "ID_CLASIFICADOR").ToString();            
            string contentUrl = string.Format("{0}?pId={1}", Session["baseClasif"], pId);

            link.NavigateUrl = "javascript:void(0);";
            link.Text = string.Format("{0:C}", Convert.ToDecimal(templateContainer.Grid.GetRowValues(rowVisibleIndex, "MARZO").ToString()));
            link.ClientSideEvents.Click = string.Format("function(s, e) {{ OnMoreInfoClick('{0}'); }}", contentUrl);
        }

        protected void hyperLink_InitAbril(object sender, EventArgs e)
        {
            ASPxHyperLink link = (ASPxHyperLink)sender;

            GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;

            int rowVisibleIndex = templateContainer.VisibleIndex;
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ANO_EJE").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "SEC_EJEC").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "FASE").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "FUENTE_FINANC").ToString() + "04"+
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "ID_CLASIFICADOR").ToString();            
            string contentUrl = string.Format("{0}?pId={1}", Session["baseClasif"], pId);

            link.NavigateUrl = "javascript:void(0);";
            link.Text = string.Format("{0:C}", Convert.ToDecimal(templateContainer.Grid.GetRowValues(rowVisibleIndex, "ABRIL").ToString()));
            link.ClientSideEvents.Click = string.Format("function(s, e) {{ OnMoreInfoClick('{0}'); }}", contentUrl);
        }

        protected void hyperLink_InitMayo(object sender, EventArgs e)
        {
            ASPxHyperLink link = (ASPxHyperLink)sender;

            GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;

            int rowVisibleIndex = templateContainer.VisibleIndex;
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ANO_EJE").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "SEC_EJEC").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "FASE").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "FUENTE_FINANC").ToString() + "05"+
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "ID_CLASIFICADOR").ToString();            
            string contentUrl = string.Format("{0}?pId={1}", Session["baseClasif"], pId);

            link.NavigateUrl = "javascript:void(0);";
            link.Text = string.Format("{0:C}", Convert.ToDecimal(templateContainer.Grid.GetRowValues(rowVisibleIndex, "MAYO").ToString()));
            link.ClientSideEvents.Click = string.Format("function(s, e) {{ OnMoreInfoClick('{0}'); }}", contentUrl);
        }

        protected void hyperLink_InitJunio(object sender, EventArgs e)
        {
            ASPxHyperLink link = (ASPxHyperLink)sender;

            GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;

            int rowVisibleIndex = templateContainer.VisibleIndex;
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ANO_EJE").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "SEC_EJEC").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "FASE").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "FUENTE_FINANC").ToString() + "06"+
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "ID_CLASIFICADOR").ToString();            
            string contentUrl = string.Format("{0}?pId={1}", Session["baseClasif"], pId);

            link.NavigateUrl = "javascript:void(0);";
            link.Text = string.Format("{0:C}", Convert.ToDecimal(templateContainer.Grid.GetRowValues(rowVisibleIndex, "JUNIO").ToString()));
            link.ClientSideEvents.Click = string.Format("function(s, e) {{ OnMoreInfoClick('{0}'); }}", contentUrl);
        }

        protected void hyperLink_InitJulio(object sender, EventArgs e)
        {
            ASPxHyperLink link = (ASPxHyperLink)sender;

            GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;

            int rowVisibleIndex = templateContainer.VisibleIndex;
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ANO_EJE").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "SEC_EJEC").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "FASE").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "FUENTE_FINANC").ToString() + "07"+
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "ID_CLASIFICADOR").ToString();            
            string contentUrl = string.Format("{0}?pId={1}", Session["baseClasif"], pId);

            link.NavigateUrl = "javascript:void(0);";
            link.Text = string.Format("{0:C}", Convert.ToDecimal(templateContainer.Grid.GetRowValues(rowVisibleIndex, "JULIO").ToString()));
            link.ClientSideEvents.Click = string.Format("function(s, e) {{ OnMoreInfoClick('{0}'); }}", contentUrl);
        }

        protected void hyperLink_InitAgosto(object sender, EventArgs e)
        {
            ASPxHyperLink link = (ASPxHyperLink)sender;

            GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;

            int rowVisibleIndex = templateContainer.VisibleIndex;
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ANO_EJE").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "SEC_EJEC").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "FASE").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "FUENTE_FINANC").ToString() + "08"+
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "ID_CLASIFICADOR").ToString();            
            string contentUrl = string.Format("{0}?pId={1}", Session["baseClasif"], pId);

            link.NavigateUrl = "javascript:void(0);";
            link.Text = string.Format("{0:C}", Convert.ToDecimal(templateContainer.Grid.GetRowValues(rowVisibleIndex, "AGOSTO").ToString()));
            link.ClientSideEvents.Click = string.Format("function(s, e) {{ OnMoreInfoClick('{0}'); }}", contentUrl);
        }

        protected void hyperLink_InitSetiembre(object sender, EventArgs e)
        {
            ASPxHyperLink link = (ASPxHyperLink)sender;

            GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;

            int rowVisibleIndex = templateContainer.VisibleIndex;
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ANO_EJE").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "SEC_EJEC").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "FASE").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "FUENTE_FINANC").ToString() + "09"+
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "ID_CLASIFICADOR").ToString();            
            string contentUrl = string.Format("{0}?pId={1}", Session["baseClasif"], pId);

            link.NavigateUrl = "javascript:void(0);";
            link.Text = string.Format("{0:C}", Convert.ToDecimal(templateContainer.Grid.GetRowValues(rowVisibleIndex, "SETIEMBRE").ToString()));
            link.ClientSideEvents.Click = string.Format("function(s, e) {{ OnMoreInfoClick('{0}'); }}", contentUrl);
        }

        protected void hyperLink_InitOctubre(object sender, EventArgs e)
        {
            ASPxHyperLink link = (ASPxHyperLink)sender;

            GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;

            int rowVisibleIndex = templateContainer.VisibleIndex;
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ANO_EJE").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "SEC_EJEC").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "FASE").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "FUENTE_FINANC").ToString() + "10"+
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "ID_CLASIFICADOR").ToString();            
            string contentUrl = string.Format("{0}?pId={1}", Session["baseClasif"], pId);

            link.NavigateUrl = "javascript:void(0);";
            link.Text = string.Format("{0:C}", Convert.ToDecimal(templateContainer.Grid.GetRowValues(rowVisibleIndex, "OCTUBRE").ToString()));
            link.ClientSideEvents.Click = string.Format("function(s, e) {{ OnMoreInfoClick('{0}'); }}", contentUrl);
        }

        protected void hyperLink_InitNoviembre(object sender, EventArgs e)
        {
            ASPxHyperLink link = (ASPxHyperLink)sender;

            GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;

            int rowVisibleIndex = templateContainer.VisibleIndex;
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ANO_EJE").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "SEC_EJEC").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "FASE").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "FUENTE_FINANC").ToString() + "11"+
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "ID_CLASIFICADOR").ToString();            
            string contentUrl = string.Format("{0}?pId={1}", Session["baseClasif"], pId);

            link.NavigateUrl = "javascript:void(0);";
            link.Text = string.Format("{0:C}", Convert.ToDecimal(templateContainer.Grid.GetRowValues(rowVisibleIndex, "NOVIEMBRE").ToString()));
            link.ClientSideEvents.Click = string.Format("function(s, e) {{ OnMoreInfoClick('{0}'); }}", contentUrl);
        }

        protected void hyperLink_InitDiciembre(object sender, EventArgs e)
        {
            ASPxHyperLink link = (ASPxHyperLink)sender;

            GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;

            int rowVisibleIndex = templateContainer.VisibleIndex;
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ANO_EJE").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "SEC_EJEC").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "FASE").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "FUENTE_FINANC").ToString() + "12"+
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "ID_CLASIFICADOR").ToString();            
            string contentUrl = string.Format("{0}?pId={1}", Session["baseClasif"], pId);

            link.NavigateUrl = "javascript:void(0);";
            link.Text = string.Format("{0:C}", Convert.ToDecimal(templateContainer.Grid.GetRowValues(rowVisibleIndex, "DICIEMBRE").ToString()));
            link.ClientSideEvents.Click = string.Format("function(s, e) {{ OnMoreInfoClick('{0}'); }}", contentUrl);
        }

        protected void hyperLink_InitTotal(object sender, EventArgs e)
        {
            ASPxHyperLink link = (ASPxHyperLink)sender;

            GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;

            int rowVisibleIndex = templateContainer.VisibleIndex;
            string pId = templateContainer.Grid.GetRowValues(rowVisibleIndex, "ANO_EJE").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "SEC_EJEC").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "ACT_PROY").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "FASE").ToString() +
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "FUENTE_FINANC").ToString() + "13"+
                            templateContainer.Grid.GetRowValues(rowVisibleIndex, "ID_CLASIFICADOR").ToString();            
            string contentUrl = string.Format("{0}?pId={1}", Session["baseClasif"], pId);

            link.NavigateUrl = "javascript:void(0);";
            //link.Text = string.Format("{0:C}", Convert.ToDecimal(templateContainer.Grid.GetRowValues(rowVisibleIndex, "ANO_EJE").ToString()));
            link.Text = string.Format("{0:C}", Convert.ToDecimal(templateContainer.Grid.GetRowValues(rowVisibleIndex, "TOTAL_EJECUTADO").ToString()));
            link.ClientSideEvents.Click = string.Format("function(s, e) {{ OnMoreInfoClick('{0}'); }}", contentUrl);
        }

        #endregion
    }
}
