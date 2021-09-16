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
using DevExpress.Web;

using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Native;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using DevExpress.Web.ASPxPivotGrid;
using System.Collections.Generic;


namespace InfoGesRegional.Modules.Forms.Consulta
{
    public partial class frmInfoGesConsultaAvanceObra : System.Web.UI.Page
    {

        private string SSId_Operador;


        #region PageInit
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["baseURL"] == null)
                //Session["baseURL"] = "frmInfoGesConsultaExpPopUp.aspx";
                Session["baseURL"] = "frmInfoGesConsultaSnipPopUp.aspx";
            

            LoadEstadoRegistro();


        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {


            SSId_Operador = "1";

            if (!Page.IsPostBack)
            {
                InfoGesRegional.Modules.MasterPage m = (InfoGesRegional.Modules.MasterPage)Page.Master;
                Session["IdProyecto"] = "";

                this.LoadProyecto();

            }



            if (!IsPostBack)
            {
                ViewType[] restrictedTypes = new ViewType[] { ViewType.PolarArea, ViewType.PolarLine, ViewType.SideBySideGantt,
                ViewType.SideBySideRangeBar, ViewType.RangeBar, ViewType.Gantt, ViewType.PolarPoint, ViewType.Stock, ViewType.CandleStick,
                ViewType.Bubble };
                foreach (ViewType type in Enum.GetValues(typeof(ViewType)))
                {
                    if (Array.IndexOf<ViewType>(restrictedTypes, type) >= 0) continue;
                    ChartType.Items.Add(type.ToString());
                }
                ChartType.SelectedItem = ChartType.Items.FindByText(ViewType.Line.ToString());
                SetChartType(ChartType.SelectedItem.Text);
                //PointLabels.Checked = WebChart.SeriesTemplate.LabelsVisibility == DevExpress.Utils.DefaultBoolean.True;

            }
        }


        #region OnSelectedindexChangedEstadoRegistro
        public void OnSelectedindexChangedEstadoRegistro(object sender, EventArgs e)
        {
            Load_Grid();

        }
        #endregion

        #region OnTextChangedGrupoProyecto
        public void OnTextChangedGrupoProyecto(object sender, EventArgs e)
        {
            //CboGrupo.SelectedIndex = 0;
            //CboComponente.SelectedIndex = 0;
            //CboProvincia.SelectedIndex = 0;
            //CboDistrito.SelectedIndex = 0;
            //this.LoadGrupo();

        }
        #endregion

        #region OnSelectedindexChangedGrupo
        public void OnSelectedindexChangedGrupo(object sender, EventArgs e)
        {
            Session["IdProyecto"] = CboProyecto.Value.ToString();
            CboGrupo.SelectedIndex = 0;
            CboComponente.SelectedIndex = 0;
            CboProvincia.SelectedIndex = 0;
            CboDistrito.SelectedIndex = 0;
            this.LoadGrupo();
        }
        #endregion

        #region OnSelectedindexChangedComponente
        public void OnSelectedindexChangedComponente(object sender, EventArgs e)
        {
            CboComponente.SelectedIndex = 0;
            CboProvincia.SelectedIndex = 0;
            CboDistrito.SelectedIndex = 0;
            Session["pIdComponente"] = CboGrupo.Value.ToString();
            this.LoadComponente();
        }
        #endregion

        #region OnSelectedindexChangedProvincia
        public void OnSelectedindexChangedProvincia(object sender, EventArgs e)
        {
            CboProvincia.SelectedIndex = 0;
            CboDistrito.SelectedIndex = 0;

            this.LoadProvincia();
        }
        #endregion

        #region OnSelectedindexChangedDistrito
        public void OnSelectedindexChangedDistrito(object sender, EventArgs e)
        {
            CboDistrito.SelectedIndex = 0;
            this.LoadDistrito();
        }
        #endregion

        #region OnSelectedindexChangedGrid
        public void OnSelectedindexChangedGrid(object sender, EventArgs e)
        {
            this.Load_Grid();
        }
        #endregion


        #region LoadEstadoRegistro
        protected void LoadEstadoRegistro()
        {
            DataSet ds1 = Code.Logic.Forms.Graficos.Curva_S_Avance_Obra.SearchAllEstadoRegistro();

            CboEstadoRegistro.DataSource = ds1.Tables[0];
            CboEstadoRegistro.TextField = ds1.Tables[0].Columns["DESCRIPCION"].Caption.ToString();
            CboEstadoRegistro.ValueField = ds1.Tables[0].Columns["ID_ESTADO_REGISTRO"].Caption.ToString();
            CboEstadoRegistro.DataBind();
            CboEstadoRegistro.SelectedIndex = 0;

            ds1.Dispose();
            ds1 = null;

        }
        #endregion

        #region LoadProyecto
        protected void LoadProyecto()
        {
            SSId_Operador = "1";
            DataSet ds1 = Code.Logic.Forms.Graficos.Curva_S_Avance_Obra.SearchAllProyectoDistinct((string)(Session["IdBaseDeDatos"]));

            CboProyecto.DataSource = ds1.Tables[0];
            CboProyecto.TextField = ds1.Tables[0].Columns["COD_PROYECTO"].Caption.ToString();
            CboProyecto.ValueField = ds1.Tables[0].Columns["ACT_PROY"].Caption.ToString();
            CboProyecto.DataBind();
            CboProyecto.SelectedIndex = 0;
            ds1.Dispose();
            ds1 = null;
            this.LoadGrupo();

        }
        #endregion

        #region LoadGrupo
        protected void LoadGrupo()
        {
            DataSet ds1 = Code.Logic.Forms.Graficos.Curva_S_Avance_Obra.SearchAllGrupoObraDistinct(CboProyecto.Value.ToString(), (string)(Session["IdBaseDeDatos"]));

            CboGrupo.DataSource = ds1.Tables[0];
            CboGrupo.TextField = ds1.Tables[0].Columns["DESCRIPCION_CATEGORIA_PROGRAMA"].Caption.ToString();
            CboGrupo.ValueField = ds1.Tables[0].Columns["ID_CATEGORIA_PROGRAMA"].Caption.ToString();
            CboGrupo.DataBind();
            CboGrupo.SelectedIndex = 0;
            ds1.Dispose();
            ds1 = null;
            this.LoadComponente();
        }
        #endregion
        
        #region LoadComponente
        protected void LoadComponente()
        {
            DataSet ds1 = Code.Logic.Forms.Graficos.Curva_S_Avance_Obra.SearchAllComponenteObraDistinct(CboProyecto.Value.ToString(), CboGrupo.Value.ToString(), (string)(Session["IdBaseDeDatos"]));
            
            CboComponente.DataSource = ds1.Tables[0];
            CboComponente.TextField = ds1.Tables[0].Columns["DESCRIPCION_COMPONENTE"].Caption.ToString();
            CboComponente.ValueField = ds1.Tables[0].Columns["ID_COMPONENTE_OBRA"].Caption.ToString();
            CboComponente.DataBind();
            CboComponente.SelectedIndex = 0;
            ds1.Dispose();
            ds1 = null;
            this.LoadProvincia();
        }
        #endregion

        #region LoadProvincia
        protected void LoadProvincia()
        {
            DataSet ds1 = Code.Logic.Forms.Graficos.Curva_S_Avance_Obra.SearchAllProvinciaDistinct(CboProyecto.Value.ToString(), CboGrupo.Value.ToString(), CboComponente.Value.ToString(), (string)(Session["IdBaseDeDatos"]));
            CboProvincia.DataSource = ds1.Tables[0];
            CboProvincia.TextField = ds1.Tables[0].Columns["NOMBRE_PROVINCIA"].Caption.ToString();
            CboProvincia.ValueField = ds1.Tables[0].Columns["PROVINCIA"].Caption.ToString();
            CboProvincia.DataBind();
            CboProvincia.SelectedIndex = 0; 
            ds1.Dispose();
            ds1 = null;
            
            this.LoadDistrito();


        }
        #endregion

        #region LoadDistrito
        protected void LoadDistrito()
        {
            DataSet ds1 = Code.Logic.Forms.Graficos.Curva_S_Avance_Obra.SearchAllDistritoDistinct(CboProyecto.Value.ToString(), CboGrupo.Value.ToString(), CboComponente.Value.ToString(), CboProvincia.Value.ToString(), (string)(Session["IdBaseDeDatos"]));
            CboDistrito.DataSource = ds1.Tables[0];
            CboDistrito.TextField = ds1.Tables[0].Columns["NOMBRE_DISTRITO"].Caption.ToString();
            CboDistrito.ValueField = ds1.Tables[0].Columns["DISTRITO"].Caption.ToString();
            CboDistrito.DataBind();
            CboDistrito.SelectedIndex = 0;
            ds1.Dispose();
            ds1 = null;
            Load_Grid();
        }
        #endregion

        #region ASPxPivotGridEjecucionAcumulada
        protected void LoadEjecuciónAcumulada(object sender, EventArgs e)
        {
            this.Load_Grid();
        }
        #endregion

        #region Load_Grid
        protected void Load_Grid()
        {
            DataSet ds1 = new DataSet();

            ds1 = Code.Logic.Forms.Graficos.Curva_S_Avance_Obra.SearchByCostoObraNew("0", CboProyecto.Value.ToString(), CboGrupo.Value.ToString(), "0", "0", "0", (string)(Session["IdBaseDeDatos"]));

            ASPxPivotGridEjecucionAcumulada.DataSource = ds1.Tables[0];
            ASPxPivotGridEjecucionAcumulada.DataBind();

    

        }
        #endregion


        protected void btnPreviewCurvaS_Click(object sender, EventArgs e)
        {
            Session["pIdproyecto"] =  CboProyecto.Value.ToString();
            //Session["pIdComponente"] = CboGrupo.Value.ToString();
            //Session["pIdGrupo"] = CboComponente.Value.ToString();
            Session["pIdComponente"] = CboComponente.Value.ToString();
            Session["pIdGrupo"] = CboGrupo.Value.ToString();
            Session["pIdProvincia"] = CboProvincia.Value.ToString();
            Session["pIdDistrito"] = CboDistrito.Value.ToString();
            Session["pIdproyectod"] = CboProyecto.Text;
            Session["pIdComponented"] = CboGrupo.Text;
            Session["pIdGrupod"] = CboComponente.Text;
            Session["pIdProvinciad"] = CboProvincia.Text;
            Session["pIdDistritod"] = CboDistrito.Text;

            Response.Redirect("~/Modules/Reports/Consultas/rptAvanceObra.aspx");

        }
        protected void btnPreviewSnipPopUp(object sender, EventArgs e)
        {
            Session["pIdproyecto"] = CboProyecto.Value.ToString();
            //Session["pIdComponente"] = CboGrupo.Value.ToString();
            //Session["pIdGrupo"] = CboComponente.Value.ToString(); 
            Session["pIdComponente"] = CboComponente.Value.ToString();
            Session["pIdGrupo"] = CboGrupo.Value.ToString();
            Session["pIdProvincia"] = CboProvincia.Value.ToString();
            Session["pIdDistrito"] = CboDistrito.Value.ToString();
            Session["pIdproyectod"] = CboProyecto.Text;
            Session["pIdComponented"] = CboGrupo.Text;
            Session["pIdGrupod"] = CboComponente.Text;
            Session["pIdProvinciad"] = CboProvincia.Text;
            Session["pIdDistritod"] = CboDistrito.Text;


        }

        void SetFilter(PivotGridField field, int selectNumber)
        {
            object[] values = field.GetUniqueValues();
            List<object> includedValues = new List<object>(values.Length / selectNumber);
            for (int i = 0; i < values.Length; i++)
                if (i % selectNumber == 0)
                    includedValues.Add(values[i]);
            field.FilterValues.ValuesIncluded = includedValues.ToArray();
        }

        void SetChartType(string text)
        {
            WebChart.SeriesTemplate.ChangeView((ViewType)Enum.Parse(typeof(ViewType), text));
            //if (WebChart.SeriesTemplate.Label != null)
            //{
            //    PointLabels.Enabled = true;
            //    WebChart.SeriesTemplate.LabelsVisibility = PointLabels.Checked ? DevExpress.Utils.DefaultBoolean.True : DevExpress.Utils.DefaultBoolean.False;
            //}
            //else
            //    PointLabels.Enabled = false;
        }

        protected void ChartType_ValueChanged(object sender, EventArgs e)
        {
            SetChartType(ChartType.SelectedItem.Text);
        }

        protected void PointLabels_CheckedChanged(object sender, EventArgs e)
        {
            //WebChart.SeriesTemplate.LabelsVisibility = PointLabels.Checked ? DevExpress.Utils.DefaultBoolean.True : DevExpress.Utils.DefaultBoolean.False;
        }
    }
}
