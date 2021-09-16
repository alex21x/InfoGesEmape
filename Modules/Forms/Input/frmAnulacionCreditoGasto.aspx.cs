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
using DevExpress.Web.ASPxClasses;


namespace InfoGesRegional.Modules.Forms.Input
{
    public partial class frmAnulacionCreditoGasto : System.Web.UI.Page
    {
    
        private string psIdSecEjec="";
        private string IdAnoEje;
        private string esCierre01, esCierre02, esCierre03, esCierre04, esCierre05, esCierre06, esCierre07, esCierre08, esCierre09, esCierre10, esCierre11, esCierre12;
        #region PageInit
        protected void Page_Init(object sender, EventArgs e)
        {


            //if (Session["baseURL"] == null)
            //{
                Session["baseURL"] = "http://ofi5.mef.gob.pe/integracion/mosip.aspx?codigo=";
                Session["baseURL"] = "http://ofi5.mef.gob.pe/integracion/mosipResumen.aspx?codigo=";
                Session["baseURL"] = "http://ofi5.mef.gob.pe/sosem2/Inicio.aspx?codigo=";
            //}

            if (Session["baseURL1"] == null)
            {
                Session["baseURL1"] = "frmSeguimientoSnipEjecutora.aspx";

            }


        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            psIdSecEjec = (string)(Session["IdSecEjec"]);
            InfoGesRegional.Modules.MasterPage m = (InfoGesRegional.Modules.MasterPage)Page.Master;
            if (!Page.IsPostBack)
            {
                this.LoadEjecutora();
            }
        }


        #region LoadEjecutora
        protected void LoadEjecutora()
        {


            DataSet ds1 = Code.Logic.Forms.Consulta.Ejecutora.SearchEjecutoraCC(psIdSecEjec.ToString(), (string)(Session["IdTipoConexion"]));
            CboEjecutora.DataSource = ds1.Tables[0];
            CboEjecutora.TextField = ds1.Tables[0].Columns["DESCRIPCION_SEC_EJEC"].Caption.ToString();
            CboEjecutora.ValueField = ds1.Tables[0].Columns["SEC_EJEC"].Caption.ToString();
            CboEjecutora.DataBind();
            CboEjecutora.SelectedIndex = 0;
            CboCentroCosto.SelectedIndex = 0;
            CboSecFunc.SelectedIndex = 0;
            ds1.Dispose();
            ds1 = null;
            this.LoadCentroCosto();
        }
        #endregion


        #region LoadCentroCosto
        protected void LoadCentroCosto()
        {

            DataSet ds1 = Code.Logic.Forms.Consulta.CentroCosto.SearchAllCentroCostoxMeta(CboEjecutora.Value.ToString());
            CboCentroCosto.DataSource = ds1.Tables[0];
            CboCentroCosto.TextField = ds1.Tables[0].Columns["DESCRIPCION"].Caption.ToString();
            CboCentroCosto.ValueField = ds1.Tables[0].Columns["ID_CENTRO_COSTO_X_EJECUTORA"].Caption.ToString();
            CboCentroCosto.DataBind();
            CboCentroCosto.SelectedIndex = 0;
            CboSecFunc.SelectedIndex = 0;
            ds1.Dispose();
            ds1 = null;
            this.LoadSecFunc();
        }
        #endregion

        #region OnSelectedindexChangedEjecutora
        public void OnSelectedindexChangedEjecutora(object sender, EventArgs e)
        {
            this.LoadCentroCosto();
        }
        #endregion

        #region OnSelectedindexChangedCentroCosto
        public void OnSelectedindexChangedCentroCosto(object sender, EventArgs e)
        {
            this.LoadSecFunc();
        }
        #endregion
        

        #region LoadSecFunc
        protected void LoadSecFunc()
        {

            DataSet ds1 = Code.Logic.Forms.Consulta.Meta.SearchAllMetaxCentroCosto(CboCentroCosto.Value.ToString());
            //if(ds1.Tables[0].Rows.Count>0)
            //    IdAnoEje = ds1.Tables[0].Rows[0][0].ToString().Substring(0,4);
            //else
            //    IdAnoEje ="2001";
            //ds1 = null;
            //ds1 = Code.Logic.Forms.Consulta.Meta.SearchByMetaEjecutora(IdAnoEje, CboEjecutora.Value.ToString());
            CboSecFunc.DataSource = ds1.Tables[0];
            CboSecFunc.TextField = ds1.Tables[0].Columns["DESCRIPCION_META"].Caption.ToString();
            CboSecFunc.ValueField = ds1.Tables[0].Columns["SEC_FUNC"].Caption.ToString();
            CboSecFunc.DataBind();
            CboSecFunc.SelectedIndex = 0;
            ds1.Dispose();
            ds1 = null;
            this.LoadGasto();
        }
        #endregion


        #region OnSelectedindexChangedSecFunc
        public void OnSelectedindexChangedSecFunc(object sender, EventArgs e)
        {
            this.LoadGasto();
        }
        #endregion


        #region LoadProgramacionGasto
        protected void LoadProgramacionGasto(object sender, EventArgs e)
        {
            LoadGasto();
            
        }
        #endregion

        #region LoadParOpeProgramacion
        protected void LoadParOpeProgramacion(object sender, EventArgs e)
        {
            DataSet ds3 = Code.Logic.Forms.Consulta.Meta.SearchAllMetaxCentroCosto(CboCentroCosto.Value.ToString());
            if (ds3.Tables[0].Rows.Count > 0)
                IdAnoEje = ds3.Tables[0].Rows[0][0].ToString().Substring(0, 4);
            else
                IdAnoEje = "2001";

            ds3 = Code.Logic.Forms.Consulta.ParOpeProgramacion.SearchAllParOpeProgramacion(IdAnoEje);
            ASPxGridviewParOpeProgramacion.DataSource = ds3.Tables[0];
            ASPxGridviewParOpeProgramacion.DataBind();

        }
        #endregion

        #region LoadGasto
        protected void LoadGasto()
        {

            DataSet ds3 = Code.Logic.Forms.Consulta.Meta.SearchAllMetaxCentroCosto(CboCentroCosto.Value.ToString());
            if (ds3.Tables[0].Rows.Count > 0)
                IdAnoEje = ds3.Tables[0].Rows[0][0].ToString().Substring(0,4);
            else
                IdAnoEje = "2001";
            string lcSecFunc;
            if (CboSecFunc.Items.Count > 0)
                lcSecFunc = CboSecFunc.Value.ToString().Substring(10,4);
            else
                lcSecFunc = "9999";
            ds3 = null;
            ds3 = Code.Logic.Forms.Input.ProgramacionGasto.SearchByAnulacionCreditoGasto(IdAnoEje, CboEjecutora.Value.ToString(), lcSecFunc);
            ASPxGridviewProgramacionGasto.DataSource = ds3.Tables[0];
            ASPxGridviewProgramacionGasto.DataBind();



            ReadOnlyTemplate template = new ReadOnlyTemplate();

            (ASPxGridviewProgramacionGasto.Columns["FUENTE_FINANC_NOMBRE"] as GridViewDataColumn).EditItemTemplate = template;
            (ASPxGridviewProgramacionGasto.Columns["ESPECIFICA_DET_NOMBRE"] as GridViewDataColumn).EditItemTemplate = template;
            (ASPxGridviewProgramacionGasto.Columns["PIM"] as GridViewDataColumn).EditItemTemplate = template;
            (ASPxGridviewProgramacionGasto.Columns["SALDOANULACIONCREDITO"] as GridViewDataColumn).EditItemTemplate = template;
            


            if (ds3.Tables[0].Rows[0][09].ToString() == "S")
                (ASPxGridviewProgramacionGasto.Columns["ANULACION"] as GridViewDataColumn).EditItemTemplate = template;
            if (ds3.Tables[0].Rows[0][10].ToString() == "S")
                (ASPxGridviewProgramacionGasto.Columns["CREDITO"] as GridViewDataColumn).EditItemTemplate = template;
 

            //ASPxGridviewProgramacionGasto.GroupBy(ASPxGridviewProgramacionGasto.Columns["FUENTE_FINANC_NOMBRE"]);
            ASPxGridviewProgramacionGasto.ExpandAll();

        }
        #endregion

        #region ASPxGridAreaOrganico_HtmlRowPrepared
        protected void ASPxGridAreaOrganico_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;

            //esCierre01 = (string)e.GetValue("MES01");
            //esCierre02 = (string)e.GetValue("MES02");



        }
        #endregion

        protected void grvProduct_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableDataCellEventArgs e)
        {

            //if (e.DataColumn.FieldName != "Stock") return;

            //if (Convert.ToInt32(e.CellValue) < 100)

            //    e.Cell.BackColor = System.Drawing.Color.Red;

            switch (e.DataColumn.FieldName)
            {
                case "ANULACION":
                        if(esCierre01=="S")
                        e.Cell.BackColor = System.Drawing.Color.Bisque;
                        
                    break;
                case "CREDITO":
                    if (esCierre02 == "S")
                        e.Cell.BackColor = System.Drawing.Color.Bisque;
                    break;

            }
        }

        //#region EditorInitialize_Programacion_gasto
        //protected void EditorInitialize_Programacion_gasto(object sender, ASPxGridViewEditorEventArgs e)
        //{

        //}
        //#endregion

        #region Updated_Programacion_gasto
        protected void Updated_Programacion_gasto(Object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string lvEnero="0";
            string lvFebrero = "0";

            if (e.NewValues["ANULACION"] != null)
                lvEnero = (e.NewValues["ANULACION"].ToString().Length == 0 ? "0" : e.NewValues["ANULACION"].ToString());

            if (e.NewValues["CREDITO"] != null)
                lvFebrero = (e.NewValues["CREDITO"].ToString().Length == 0 ? "0" : e.NewValues["CREDITO"].ToString());





            string[] parameters = { lvEnero, lvFebrero };

            string Id = e.Keys["IDKEY"].ToString();

            string Cadena = "";
            //if(Convert.ToDecimal(e.NewValues["PIM"].ToString())<=Convert.ToDecimal(lvEnero)+Convert.ToDecimal(lvFebrero)+Convert.ToDecimal(lvMarzo)+Convert.ToDecimal(lvAbril)+Convert.ToDecimal(lvMayo)+Convert.ToDecimal(lvJunio)+Convert.ToDecimal(lvJulio)+Convert.ToDecimal(lvAgosto)+Convert.ToDecimal(lvSetiembre)+Convert.ToDecimal(lvOctubre)+Convert.ToDecimal(lvNoviembre)+Convert.ToDecimal(lvDiciembre))
            //{
            //    Cadena = "El importe de programaciòn supera el PIM verifique...!!";
            //}
            //if (Cadena.Length == 0)
            //{
            Cadena = Code.Logic.Forms.Input.ProgramacionGasto.Updated_AnulacionCredito_Gasto(parameters, Id);
            //}


            if (Cadena.ToString().Length != 0)
            {
                throw new Exception(Cadena);
            }
            else
            {
                e.Cancel = true;
                ASPxGridviewProgramacionGasto.CancelEdit();
                LoadGasto();
            }

        }
        #endregion

        protected void grid_CustomUnboundColumnData(object sender, ASPxGridViewColumnDataEventArgs e)
        {

            if (e.Column.FieldName == "SALDOANULACIONCREDITO")
            {
                e.Value = (decimal)e.GetListSourceFieldValue("PIM") -
                            (decimal)e.GetListSourceFieldValue("ANULACION") +
                            (decimal)e.GetListSourceFieldValue("CREDITO") ;
            }

        }




        protected void btnXlsExport_Click(object sender, EventArgs e)
        {
            gridExport.WriteXlsToResponse();
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
                    img =  "~/Images/circulo_amarillo.jpg";
                    break;

                case "-1000": 
                    img= "~/Images/circulo_rojo.jpg";
                    break;

            }
            return img;
        }


        class ReadOnlyTemplate : ITemplate
        {
            public void InstantiateIn(Control _container)
            {
                GridViewEditItemTemplateContainer container = _container as GridViewEditItemTemplateContainer;

                ASPxLabel lbl = new ASPxLabel();
                lbl.ID = "lbl";

                container.Controls.Add(lbl);
                lbl.Text = container.Text;
            }
        }


    }
}
