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
    public partial class frmProgramacionGasto : System.Web.UI.Page
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
            Session["IdTipoConexion"] = ConfigurationManager.AppSettings.Get("IdTipoConexion");
            InfoGesRegional.Modules.MasterPage m = (InfoGesRegional.Modules.MasterPage)Page.Master;
            if (!Page.IsPostBack)
            {
                this.LoadEjecutora();
            }
        }


        #region LoadEjecutora
        protected void LoadEjecutora()
        {


            DataSet ds1 = Code.Logic.Forms.Consulta.Ejecutora.SearchEjecutoraCC(psIdSecEjec.ToString(), (string)(Session["IdSecEjec"]));
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
            ds3 = Code.Logic.Forms.Input.ProgramacionGasto.SearchByProgramacionGasto(IdAnoEje, CboEjecutora.Value.ToString(), lcSecFunc);
            ASPxGridviewProgramacionGasto.DataSource = ds3.Tables[0];
            ASPxGridviewProgramacionGasto.DataBind();



            ReadOnlyTemplate template = new ReadOnlyTemplate();

            (ASPxGridviewProgramacionGasto.Columns["FUENTE_FINANC_NOMBRE"] as GridViewDataColumn).EditItemTemplate = template;
            (ASPxGridviewProgramacionGasto.Columns["ESPECIFICA_DET_NOMBRE"] as GridViewDataColumn).EditItemTemplate = template;
            (ASPxGridviewProgramacionGasto.Columns["PIM"] as GridViewDataColumn).EditItemTemplate = template;
            (ASPxGridviewProgramacionGasto.Columns["TOTAL"] as GridViewDataColumn).EditItemTemplate = template;
            (ASPxGridviewProgramacionGasto.Columns["SALDOPROGRAMACION"] as GridViewDataColumn).EditItemTemplate = template;
            


            if (ds3.Tables[0].Rows[0][21].ToString() == "S")
                (ASPxGridviewProgramacionGasto.Columns["PROGRAMACION_01"] as GridViewDataColumn).EditItemTemplate = template;
            if (ds3.Tables[0].Rows[0][22].ToString() == "S")
                (ASPxGridviewProgramacionGasto.Columns["PROGRAMACION_02"] as GridViewDataColumn).EditItemTemplate = template;
            if (ds3.Tables[0].Rows[0][23].ToString() == "S")
                (ASPxGridviewProgramacionGasto.Columns["PROGRAMACION_03"] as GridViewDataColumn).EditItemTemplate = template;
            if (ds3.Tables[0].Rows[0][24].ToString() == "S")
                (ASPxGridviewProgramacionGasto.Columns["PROGRAMACION_04"] as GridViewDataColumn).EditItemTemplate = template;
            if (ds3.Tables[0].Rows[0][25].ToString() == "S")
                (ASPxGridviewProgramacionGasto.Columns["PROGRAMACION_05"] as GridViewDataColumn).EditItemTemplate = template;
            if (ds3.Tables[0].Rows[0][26].ToString() == "S")
                (ASPxGridviewProgramacionGasto.Columns["PROGRAMACION_06"] as GridViewDataColumn).EditItemTemplate = template;
            if (ds3.Tables[0].Rows[0][27].ToString() == "S")
                (ASPxGridviewProgramacionGasto.Columns["PROGRAMACION_07"] as GridViewDataColumn).EditItemTemplate = template;
            if (ds3.Tables[0].Rows[0][28].ToString() == "S")
                (ASPxGridviewProgramacionGasto.Columns["PROGRAMACION_08"] as GridViewDataColumn).EditItemTemplate = template;
            if (ds3.Tables[0].Rows[0][29].ToString() == "S")
                (ASPxGridviewProgramacionGasto.Columns["PROGRAMACION_09"] as GridViewDataColumn).EditItemTemplate = template;
            if (ds3.Tables[0].Rows[0][30].ToString() == "S")
                (ASPxGridviewProgramacionGasto.Columns["PROGRAMACION_10"] as GridViewDataColumn).EditItemTemplate = template;
            if (ds3.Tables[0].Rows[0][31].ToString() == "S")
                (ASPxGridviewProgramacionGasto.Columns["PROGRAMACION_11"] as GridViewDataColumn).EditItemTemplate = template;
            if (ds3.Tables[0].Rows[0][32].ToString() == "S")
                (ASPxGridviewProgramacionGasto.Columns["PROGRAMACION_12"] as GridViewDataColumn).EditItemTemplate = template;
 

            //ASPxGridviewProgramacionGasto.GroupBy(ASPxGridviewProgramacionGasto.Columns["FUENTE_FINANC_NOMBRE"]);
            ASPxGridviewProgramacionGasto.ExpandAll();

        }
        #endregion

        #region ASPxGridAreaOrganico_HtmlRowPrepared
        protected void ASPxGridAreaOrganico_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != DevExpress.Web.ASPxGridView.GridViewRowType.Data) return;

            esCierre01 = (string)e.GetValue("MES01");
            esCierre02 = (string)e.GetValue("MES02");
            esCierre03 = (string)e.GetValue("MES03");
            esCierre04 = (string)e.GetValue("MES04");
            esCierre05 = (string)e.GetValue("MES05");
            esCierre06 = (string)e.GetValue("MES06");
            esCierre07 = (string)e.GetValue("MES07");
            esCierre08 = (string)e.GetValue("MES08");
            esCierre09 = (string)e.GetValue("MES09");
            esCierre10 = (string)e.GetValue("MES10");
            esCierre11 = (string)e.GetValue("MES11");
            esCierre12 = (string)e.GetValue("MES12");


        }
        #endregion

        protected void grvProduct_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableDataCellEventArgs e)
        {

            //if (e.DataColumn.FieldName != "Stock") return;

            //if (Convert.ToInt32(e.CellValue) < 100)

            //    e.Cell.BackColor = System.Drawing.Color.Red;

            switch (e.DataColumn.FieldName)
            {
                case "PROGRAMACION_01":
                        if(esCierre01=="S")
                        e.Cell.BackColor = System.Drawing.Color.Bisque;
                        
                    break;
                case "PROGRAMACION_02":
                    if (esCierre02 == "S")
                        e.Cell.BackColor = System.Drawing.Color.Bisque;
                    break;
                case "PROGRAMACION_03":
                    if (esCierre03 == "S")
                        e.Cell.BackColor = System.Drawing.Color.Bisque;
                    break;
                case "PROGRAMACION_04":
                    if (esCierre04 == "S")
                        e.Cell.BackColor = System.Drawing.Color.Bisque;
                    break;
                case "PROGRAMACION_05":
                    if (esCierre05 == "S")
                        e.Cell.BackColor = System.Drawing.Color.Bisque;
                    break;
                case "PROGRAMACION_06":
                    if (esCierre06 == "S")
                        e.Cell.BackColor = System.Drawing.Color.Bisque;
                    break;
                case "PROGRAMACION_07":
                    if (esCierre07 == "S")
                        e.Cell.BackColor = System.Drawing.Color.Bisque;
                    break;
                case "PROGRAMACION_08":
                    if (esCierre08 == "S")
                        e.Cell.BackColor = System.Drawing.Color.Bisque;
                    break;
                case "PROGRAMACION_09":
                    if (esCierre09 == "S")
                        e.Cell.BackColor = System.Drawing.Color.Bisque;
                    break;
                case "PROGRAMACION_10":
                    if (esCierre10 == "S")
                        e.Cell.BackColor = System.Drawing.Color.Bisque;
                    break;
                case "PROGRAMACION_11":
                    if (esCierre11 == "S")
                        e.Cell.BackColor = System.Drawing.Color.Bisque;
                    break;
                case "PROGRAMACION_12":
                    if (esCierre12 == "S")
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
            string lvMarzo = "0";
            string lvAbril = "0";
            string lvMayo = "0";
            string lvJunio = "0";
            string lvJulio = "0";
            string lvAgosto = "0";
            string lvSetiembre = "0";
            string lvOctubre = "0";
            string lvNoviembre = "0";
            string lvDiciembre = "0";

            if (e.NewValues["PROGRAMACION_01"] != null)
                lvEnero = (e.NewValues["PROGRAMACION_01"].ToString().Length == 0 ? "0" : e.NewValues["PROGRAMACION_01"].ToString());

            if (e.NewValues["PROGRAMACION_02"] != null)
                lvFebrero = (e.NewValues["PROGRAMACION_02"].ToString().Length == 0 ? "0" : e.NewValues["PROGRAMACION_02"].ToString());

            if (e.NewValues["PROGRAMACION_03"] != null)
                lvMarzo = (e.NewValues["PROGRAMACION_03"].ToString().Length == 0 ? "0" : e.NewValues["PROGRAMACION_03"].ToString());

            if (e.NewValues["PROGRAMACION_04"] != null)
                lvAbril = (e.NewValues["PROGRAMACION_04"].ToString().Length == 0 ? "0" : e.NewValues["PROGRAMACION_04"].ToString());

            if (e.NewValues["PROGRAMACION_05"] != null)
                lvMayo = (e.NewValues["PROGRAMACION_05"].ToString().Length == 0 ? "0" : e.NewValues["PROGRAMACION_05"].ToString());

            if (e.NewValues["PROGRAMACION_06"] != null)
                lvJunio = (e.NewValues["PROGRAMACION_06"].ToString().Length == 0 ? "0" : e.NewValues["PROGRAMACION_06"].ToString());

            if (e.NewValues["PROGRAMACION_07"] != null)
                lvJulio = (e.NewValues["PROGRAMACION_07"].ToString().Length == 0 ? "0" : e.NewValues["PROGRAMACION_07"].ToString());

            if (e.NewValues["PROGRAMACION_08"] != null)
                lvAgosto = (e.NewValues["PROGRAMACION_08"].ToString().Length == 0 ? "0" : e.NewValues["PROGRAMACION_08"].ToString());

            if (e.NewValues["PROGRAMACION_09"] != null)
                lvSetiembre = (e.NewValues["PROGRAMACION_09"].ToString().Length == 0 ? "0" : e.NewValues["PROGRAMACION_09"].ToString());

            if (e.NewValues["PROGRAMACION_10"] != null)
                lvOctubre = (e.NewValues["PROGRAMACION_10"].ToString().Length == 0 ? "0" : e.NewValues["PROGRAMACION_10"].ToString());

            if (e.NewValues["PROGRAMACION_11"] != null)
                lvNoviembre = (e.NewValues["PROGRAMACION_11"].ToString().Length == 0 ? "0" : e.NewValues["PROGRAMACION_11"].ToString());

            if (e.NewValues["PROGRAMACION_12"] != null)
                lvDiciembre = (e.NewValues["PROGRAMACION_12"].ToString().Length == 0 ? "0" : e.NewValues["PROGRAMACION_12"].ToString());



            string[] parameters = { lvEnero, lvFebrero, lvMarzo, lvAbril, lvMayo, lvJunio, lvJulio, lvAgosto, lvSetiembre, lvOctubre, lvNoviembre, lvDiciembre };

            string Id = e.Keys["IDKEY"].ToString();

            string Cadena = "";
            //if(Convert.ToDecimal(e.NewValues["PIM"].ToString())<=Convert.ToDecimal(lvEnero)+Convert.ToDecimal(lvFebrero)+Convert.ToDecimal(lvMarzo)+Convert.ToDecimal(lvAbril)+Convert.ToDecimal(lvMayo)+Convert.ToDecimal(lvJunio)+Convert.ToDecimal(lvJulio)+Convert.ToDecimal(lvAgosto)+Convert.ToDecimal(lvSetiembre)+Convert.ToDecimal(lvOctubre)+Convert.ToDecimal(lvNoviembre)+Convert.ToDecimal(lvDiciembre))
            //{
            //    Cadena = "El importe de programaciòn supera el PIM verifique...!!";
            //}
            //if (Cadena.Length == 0)
            //{
                Cadena = Code.Logic.Forms.Input.ProgramacionGasto.Updated_Programacion_Gasto(parameters, Id);
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
            if (e.Column.FieldName == "TOTAL")
            {
                //decimal price = (decimal)e.GetListSourceFieldValue("UnitPrice");
                //int quantity = Convert.ToInt32(e.GetListSourceFieldValue("Quantity"));
                //decimal Total =

                e.Value = (decimal)e.GetListSourceFieldValue("PROGRAMACION_01") +
                            (decimal)e.GetListSourceFieldValue("PROGRAMACION_02") +
                            (decimal)e.GetListSourceFieldValue("PROGRAMACION_03") +
                            (decimal)e.GetListSourceFieldValue("PROGRAMACION_04") +
                            (decimal)e.GetListSourceFieldValue("PROGRAMACION_05") +
                            (decimal)e.GetListSourceFieldValue("PROGRAMACION_06") +
                            (decimal)e.GetListSourceFieldValue("PROGRAMACION_07") +
                            (decimal)e.GetListSourceFieldValue("PROGRAMACION_08") +
                            (decimal)e.GetListSourceFieldValue("PROGRAMACION_09") +
                            (decimal)e.GetListSourceFieldValue("PROGRAMACION_10") +
                            (decimal)e.GetListSourceFieldValue("PROGRAMACION_11") +
                            (decimal)e.GetListSourceFieldValue("PROGRAMACION_12");
            }

            if (e.Column.FieldName == "SALDOPROGRAMACION")
            {
                e.Value = (decimal)e.GetListSourceFieldValue("PIM") -
                            (decimal)e.GetListSourceFieldValue("PROGRAMACION_01") +
                            (decimal)e.GetListSourceFieldValue("PROGRAMACION_02") +
                            (decimal)e.GetListSourceFieldValue("PROGRAMACION_03") +
                            (decimal)e.GetListSourceFieldValue("PROGRAMACION_04") +
                            (decimal)e.GetListSourceFieldValue("PROGRAMACION_05") +
                            (decimal)e.GetListSourceFieldValue("PROGRAMACION_06") +
                            (decimal)e.GetListSourceFieldValue("PROGRAMACION_07") +
                            (decimal)e.GetListSourceFieldValue("PROGRAMACION_08") +
                            (decimal)e.GetListSourceFieldValue("PROGRAMACION_09") +
                            (decimal)e.GetListSourceFieldValue("PROGRAMACION_10") +
                            (decimal)e.GetListSourceFieldValue("PROGRAMACION_11") +
                            (decimal)e.GetListSourceFieldValue("PROGRAMACION_12");
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
