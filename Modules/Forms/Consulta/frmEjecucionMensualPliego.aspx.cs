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
    public partial class frmEjecucionMensualPliego : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            InfoGesRegional.Modules.MasterPage m = (InfoGesRegional.Modules.MasterPage)Page.Master;
            if (!Page.IsPostBack)
            {
                this.LoadPeriodo();
                //ASPxGridviewConsultaSnipFinanciero.BeginUpdate();
                //((GridViewDataColumn)ASPxGridviewConsultaSnipFinanciero.Columns["FUENTE_FINANC_NOMBRE"]).GroupBy();
                //ASPxGridviewConsultaSnipFinanciero.GroupBy(ASPxGridviewConsultaSnipFinanciero.Columns["SEC_FUNC_NOMBRE"], 0);
                //ASPxGridviewConsultaSnipFinanciero.EndUpdate();

            }
        }

        #region OnSelectedindexChangedPeriodo
        public void OnSelectedindexChangedPeriodo(object sender, EventArgs e)
        {
            //CboCentroCosto.SelectedIndex = 0;

            //this.LoadCentroCosto();
            SearchAllSecFunc();
        }
        #endregion

        #region OnSelectedindexChangedActProy
        public void OnSelectedindexChangedActProy(object sender, EventArgs e)
        {
            //CboCentroCosto.SelectedIndex = 0;

            //this.LoadCentroCosto();
            SearchAllSecFunc();
        }
        #endregion


        #region LoadPeriodo
        protected void LoadPeriodo()
        {
            DataSet ds1 = Code.Logic.Forms.Consulta.Periodo.SearchAllPeriodoSolo2009("999999", (string)(Session["IdTipoConexion"]));
            CboPeriodo.DataSource = ds1.Tables[0];
            CboPeriodo.TextField = ds1.Tables[0].Columns["DESCRIPCION_ANO_EJE"].Caption.ToString();
            CboPeriodo.ValueField = ds1.Tables[0].Columns["ANO_EJE"].Caption.ToString();
            CboPeriodo.DataBind();
            CboPeriodo.SelectedIndex = 0;
            ds1.Dispose();
            ds1 = null;
            //this.LoadCentroCosto();
            this.LoadActProy();
        }
        #endregion

        #region LoadActProy
        protected void LoadActProy()
        {
            DataSet ds1 = Code.Logic.Forms.Consulta.Act_Proy.SearchTipoActProy((string)(Session["IdTipoConexion"]));

            CboActividadProyecto.DataSource = ds1.Tables[0];
            CboActividadProyecto.TextField = ds1.Tables[0].Columns["DESCRIPCION_TIPO_ACT_PROY"].Caption.ToString();
            CboActividadProyecto.ValueField = ds1.Tables[0].Columns["TIPO_ACT_PROY"].Caption.ToString();
            CboActividadProyecto.DataBind();
            CboActividadProyecto.SelectedIndex = 0;
            ds1.Dispose();
            ds1 = null;
            //this.LoadCentroCosto();
            SearchAllSecFunc();
        }
        #endregion

        #region LoadEjecucionMensual
        protected void LoadEjecucionMensual(object sender, EventArgs e)
        {
            this.SearchAllSecFunc();
        }
        #endregion

        #region SearchAllSecFunc
        protected void SearchAllSecFunc()
        {


            DataSet ds4 = new DataSet();
            //ds4 = Code.Logic.Forms.Consulta.EjecucionGasto.SearchAllEjecucionMensual(CboPeriodo.Value.ToString());
            ds4 = Code.Logic.Forms.Consulta.EjecucionGasto.SearchAllEjecucionMensual(CboPeriodo.Value.ToString(), CboActividadProyecto.Value.ToString(), (string)(Session["IdTipoConexion"]));
 
            ASPxGridviewConsultaSnipFinanciero.DataSource = ds4.Tables[0];
            ASPxGridviewConsultaSnipFinanciero.DataBind();
 

        }
        #endregion

        #region OnClikVisualizacionMeses
        protected void OnClikVisualizacionMeses(object sender, EventArgs e)
        {
            string lcTitulo="";
            if (ASPxGridviewConsultaSnipFinanciero.Columns["ENERO"].Visible)
            {
                ASPxGridviewConsultaSnipFinanciero.Columns["ENERO"].Visible = false;
                ASPxGridviewConsultaSnipFinanciero.Columns["FEBRERO"].Visible = false;
                ASPxGridviewConsultaSnipFinanciero.Columns["MARZO"].Visible = false;
                ASPxGridviewConsultaSnipFinanciero.Columns["ABRIL"].Visible = false;
                ASPxGridviewConsultaSnipFinanciero.Columns["MAYO"].Visible = false;
                ASPxGridviewConsultaSnipFinanciero.Columns["JUNIO"].Visible = false;
                ASPxGridviewConsultaSnipFinanciero.Columns["JULIO"].Visible = false;
                ASPxGridviewConsultaSnipFinanciero.Columns["AGOSTO"].Visible = false;
                ASPxGridviewConsultaSnipFinanciero.Columns["SETIEMBRE"].Visible = false;
                ASPxGridviewConsultaSnipFinanciero.Columns["OCTUBRE"].Visible = false;
                ASPxGridviewConsultaSnipFinanciero.Columns["NOVIEMBRE"].Visible = false;
                ASPxGridviewConsultaSnipFinanciero.Columns["DICIEMBRE"].Visible = false;
                ASPxGridviewConsultaSnipFinanciero.Columns["SALDO_EJECUCION"].Width= 120;
                ASPxGridviewConsultaSnipFinanciero.Columns["SALDO_PIM_COMPROMETIDO"].Width= 120;
                lcTitulo = "Visualizar";
            }
            else
            {
                ASPxGridviewConsultaSnipFinanciero.Columns["ENERO"].Visible = true;
                ASPxGridviewConsultaSnipFinanciero.Columns["FEBRERO"].Visible = true;
                ASPxGridviewConsultaSnipFinanciero.Columns["MARZO"].Visible = true;
                ASPxGridviewConsultaSnipFinanciero.Columns["ABRIL"].Visible = true;
                ASPxGridviewConsultaSnipFinanciero.Columns["MAYO"].Visible = true;
                ASPxGridviewConsultaSnipFinanciero.Columns["JUNIO"].Visible = true;
                ASPxGridviewConsultaSnipFinanciero.Columns["JULIO"].Visible = true;
                ASPxGridviewConsultaSnipFinanciero.Columns["AGOSTO"].Visible = true;
                ASPxGridviewConsultaSnipFinanciero.Columns["SETIEMBRE"].Visible = true;
                ASPxGridviewConsultaSnipFinanciero.Columns["OCTUBRE"].Visible = true;
                ASPxGridviewConsultaSnipFinanciero.Columns["NOVIEMBRE"].Visible = true;
                ASPxGridviewConsultaSnipFinanciero.Columns["DICIEMBRE"].Visible = true;
                ASPxGridviewConsultaSnipFinanciero.Columns["SALDO_EJECUCION"].Width = 80;
                ASPxGridviewConsultaSnipFinanciero.Columns["SALDO_PIM_COMPROMETIDO"].Width = 80;
                lcTitulo = "Ocultar";
            }
            btnVisualizarMeses.Text = lcTitulo + "la ejecución del gasto mensual a nivel de compromiso";

        }
        #endregion


        protected void btnXlsExport_Click(object sender, EventArgs e)
        {
            gridExport.WriteXlsToResponse();
        }

        protected void gvData_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            if (e.Parameters != string.Empty)
            {
                (sender as ASPxGridView).Columns[e.Parameters].Visible = false;
                (sender as ASPxGridView).Columns[e.Parameters].ShowInCustomizationForm = true;
            }
        }

        #region grid_HtmlDataCellPrepared
        protected void grid_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            //if (e.DataColumn.FieldName != "SALDO_EJECUCION" && e.DataColumn.FieldName != "SALDO_EJECUCION") return;
            if (e.DataColumn.FieldName != "SALDO_EJECUCION" ) return; 
            if (Convert.ToInt32(e.CellValue) < 0)
                e.Cell.ForeColor = Color.Red;
            else
                e.Cell.ForeColor = Color.Black;
        }
        #endregion

    }
}
