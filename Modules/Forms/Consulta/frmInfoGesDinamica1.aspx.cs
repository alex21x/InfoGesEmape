using System;
using System.Diagnostics;
using System.IO;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Web;
using System.Net;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

using DevExpress.Web.ASPxPivotGrid;
using System.Web.Services;
using System.Collections.Specialized;
using System.Text;





//http://ofi5.mef.gob.pe/ssi/wsSosem.asmx


namespace InfoGesRegional.Modules.Forms.Consulta
{
    public partial class frmInfoGesDinamica1 : System.Web.UI.Page
    {

        #region PageInit
        protected void Page_Init(object sender, EventArgs e)
        {

            this.LoadXmlEjecutora();
            //this.CargaData();
            if (Context.User.Identity.IsAuthenticated)
            { }
            else
                Response.Redirect("~/Default.aspx");


        }
        #endregion

        #region btnProcesarClick
        protected void btnProcesarClick(object sender, EventArgs e)
        {
            Session["btnProcesarClick"] = "0";
            this.CargaData();
            Session["btnProcesarClick"] = "1";

        }
        #endregion

        #region LoadASPxPivotGrid
                protected void  LoadASPxPivotGrid(object sender, EventArgs e)
        {
            this.CargaData();
        }
        #endregion

        #region CargaData
        protected void CargaData()
        {

            string[,] CheckBox = new string[17, 2]{ 
            { ASPxCheckPeriodo.Text,        ASPxCheckPeriodo.Checked.ToString().ToUpper() }, 
            { ASPxCheckMes.Text,            ASPxCheckMes.Checked.ToString().ToUpper() }, 
            { ASPxCheckFuncion.Text,        ASPxCheckFuncion.Checked.ToString().ToUpper()}, 
            { ASPxCheckDFuncional.Text,     ASPxCheckDFuncional.Checked.ToString().ToUpper()}, 
            { ASPxCheckGFuncional.Text,     ASPxCheckGFuncional.Checked.ToString().ToUpper()}, 
            { ASPxCheckCFuncional.Text,     ASPxCheckCFuncional.Checked.ToString().ToUpper()}, 
            { ASPxCheckPProyecto.Text,      ASPxCheckPProyecto.Checked.ToString().ToUpper()}, 
            { ASPxCheckAAObra.Text,         ASPxCheckAAObra.Checked.ToString().ToUpper()}, 
            { ASPxCheckRubro.Text,          ASPxCheckRubro.Checked.ToString().ToUpper()}, 
            { ASPxCheckGenerica.Text,       ASPxCheckGenerica.Checked.ToString().ToUpper()}, 
            { ASPxCheckSGenerica.Text,      ASPxCheckSGenerica.Checked.ToString().ToUpper()}, 
            { ASPxCheckSGenericaDet.Text,   ASPxCheckSGenericaDet.Checked.ToString().ToUpper()}, 
            { ASPxCheckEspecifica.Text,     ASPxCheckEspecifica.Checked.ToString().ToUpper()}, 
            { ASPxCheckEspecificaD.Text,    ASPxCheckEspecificaD.Checked.ToString().ToUpper()}, 
            { ASPxCheckDepartamento.Text,   ASPxCheckDepartamento.Checked.ToString().ToUpper()}, 
            { ASPxCheckProvincia.Text,      ASPxCheckProvincia.Checked.ToString().ToUpper()}, 
            { ASPxCheckDistrito.Text,       ASPxCheckDistrito.Checked.ToString().ToUpper()}};

            string pFase = "";
            for (int i = 0; i < RadioButtonList1.Items.Count; i++)
            {

                if (RadioButtonList1.Items[i].Selected)
                {

                    pFase = RadioButtonList1.Items[i].Value;

                }

            }
            string pTipo = "";
            switch (this.ASPxPageControl1.ActiveTabPage.ToString())
            {
                case "GASTOS":
                    pTipo="E";
                    break;
                case "INGRESOS":
                    pTipo = "E";
                    pFase = "R";
                    break;
                default:
                    pFase = "M";
                    pTipo  ="E";
                    break;
            }
            DataSet ds1 = Code.Logic.Forms.Consulta.InfoGesConsulta2009.InfoGesRegDinamicaQuery(CheckBox, "0000", ASPxTabControleJEjecutora.ActiveTab.Name.ToString(), (string)(Session["IdBaseDeDatos"]), pFase, pTipo);

            string[,] ArrayCubo = (string[,])Code.Logic.Forms.Consulta.InfoGesConsulta2009.InfoGesRegDinamicaArray(CheckBox, pTipo).Clone();

            //int end = (ArrayCubo.Length / ArrayCubo.Rank);
            int end = ArrayCubo.Length / ArrayCubo.Rank;
            int x1 = 0;

        ///*https://www.devexpress.com/Support/Center/Question/Details/T406857/how-to-define-and-remove-data-fields-dynamically-on-custom-callback-using-the-client*/

            if ((string)(Session["btnProcesarClick"]) == "0")
            {
                while (ASPxPivotGridDinamica.GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.ColumnArea).Count > 0)
                {
                    ASPxPivotGridDinamica.Fields.Remove(ASPxPivotGridDinamica.GetFieldByArea(DevExpress.XtraPivotGrid.PivotArea.ColumnArea, 0));
                }
                while (ASPxPivotGridDinamica.GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.RowArea).Count > 0)
                {
                    ASPxPivotGridDinamica.Fields.Remove(ASPxPivotGridDinamica.GetFieldByArea(DevExpress.XtraPivotGrid.PivotArea.RowArea, 0));
                }
                while (ASPxPivotGridDinamica.GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.DataArea).Count > 0)
                {
                    ASPxPivotGridDinamica.Fields.Remove(ASPxPivotGridDinamica.GetFieldByArea(DevExpress.XtraPivotGrid.PivotArea.DataArea, 0));
                }

                for (int k = 0; k < end; k++)
                {


                    if (ArrayCubo[x1, 1].ToString() == "COLUMN")
                    {
                        ASPxPivotGridDinamica.Fields.Add(ArrayCubo[x1, 0].ToString(), DevExpress.XtraPivotGrid.PivotArea.ColumnArea);
                    }
                    else
                    {
                        ASPxPivotGridDinamica.Fields.Add(ArrayCubo[x1, 0].ToString(), DevExpress.XtraPivotGrid.PivotArea.RowArea);
                    }
                    x1 = x1 + 1;

                }

                switch (this.ASPxPageControl1.ActiveTabPage.ToString())
                {
                    case "GASTOS":
                        ASPxPivotGridDinamica.Fields.Add("EJECUCION", DevExpress.XtraPivotGrid.PivotArea.DataArea);
                        break;
                    case "INGRESOS":
                        ASPxPivotGridDinamica.Fields.Add("EJECUCION", DevExpress.XtraPivotGrid.PivotArea.DataArea);
                        break;
                    default:
                        ASPxPivotGridDinamica.Fields.Add("PIA", DevExpress.XtraPivotGrid.PivotArea.DataArea);
                        ASPxPivotGridDinamica.Fields.Add("PIM", DevExpress.XtraPivotGrid.PivotArea.DataArea);
                        break;
                }
            }
            ASPxPivotGridDinamica.DataSource = ds1.Tables[0];
            ASPxPivotGridDinamica.Visible = true;
            ASPxPivotGridDinamica.DataBind();



        }
        #endregion

        #region Print
        void Export(bool saveAs)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                //if (this.ASPxPageControl2.ActiveTabPage.ToString() == "1")
                //{
                //ASPxPivotGridExporter1.OptionsPrint.PrintHeadersOnEveryPage = checkPrintHeadersOnEveryPage.Checked;
                //ASPxPivotGridExporter1.OptionsPrint.PrintFilterHeaders = checkPrintFilterHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;
                //ASPxPivotGridExporter1.OptionsPrint.PrintColumnHeaders = checkPrintColumnHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;
                //ASPxPivotGridExporter1.OptionsPrint.PrintRowHeaders = checkPrintRowHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;
                //ASPxPivotGridExporter1.OptionsPrint.PrintDataHeaders = checkPrintDataHeaders.Checked ? DefaultBoolean.True : DefaultBoolean.False;

                string contentType = "", fileName = "";
                switch (listExportFormat.SelectedIndex)
                {
                    case 0:
                        contentType = "application/ms-excel";
                        fileName = "PivotGrid.xls";
                        ASPxPivotGridExporter1.ExportToXls(stream);
                        break;
                }

                byte[] buffer = stream.GetBuffer();

                string disposition = saveAs ? "attachment" : "inline";
                Response.Clear();
                Response.Buffer = false;
                Response.AppendHeader("Content-Type", contentType);
                Response.AppendHeader("Content-Transfer-Encoding", "binary");
                Response.AppendHeader("Content-Disposition", disposition + "; filename=" + fileName);
                Response.BinaryWrite(buffer);
                Response.End();


            }
        }

        protected void buttonOpen_Click(object sender, EventArgs e)
        {
            Export(false);
        }
        protected void buttonSaveAs_Click(object sender, EventArgs e)
        {
            Export(true);
        }

        #endregion


        #region Load_Xml_Ejecutora
        protected void Load_Xml_Ejecutora(object sender, EventArgs e)
        {
            this.LoadXmlEjecutora();

        }
        protected void LoadXmlEjecutora()
        {
            DataSet ds2 = new DataSet();
            ds2 = Code.Logic.Forms.Consulta.Cuadro.SearchAllEjecutora((string)(Session["SecEjecId"]));
            if (ds2.Tables[0].Rows.Count == 1)
                ASPxTabControleJEjecutora.Visible = false;

            this.XmlDataSource2.Data = "";
            this.XmlDataSource2.DataBind();
            this.XmlDataSource2.Data = CreateXmlMenuEjecutora(ds2);
            this.XmlDataSource2.DataBind();
            ASPxTabControleJEjecutora.DataBind();
        }
        protected void ASPxPageControl1auc(object sender, DevExpress.Web.ASPxTabControl.TabControlEventArgs e)
        {

            ASPxCheckPeriodo.Checked = false;
            ASPxCheckMes.Checked = false;
            ASPxCheckFuncion.Checked = false;
            ASPxCheckDFuncional.Checked = false;
            ASPxCheckGFuncional.Checked = false;
            ASPxCheckCFuncional.Checked = false;
            ASPxCheckPProyecto.Checked = false;
            ASPxCheckAAObra.Checked = false;
            ASPxCheckRubro.Checked = false;
            ASPxCheckGenerica.Checked = false;
            ASPxCheckSGenerica.Checked = false;
            ASPxCheckSGenericaDet.Checked = false;
            ASPxCheckEspecifica.Checked = false;
            ASPxCheckEspecificaD.Checked = false;
            ASPxCheckDepartamento.Checked = false;
            ASPxCheckProvincia.Checked = false;
            ASPxCheckDistrito.Checked = false;


             ASPxCheckPeriodo.Enabled = false;
             ASPxCheckMes.Enabled= false;
             ASPxCheckFuncion.Enabled= false;
             ASPxCheckDFuncional.Enabled= false;
             ASPxCheckGFuncional.Enabled= false;
             ASPxCheckCFuncional.Enabled= false;
             ASPxCheckPProyecto.Enabled= false;      
             ASPxCheckAAObra.Enabled= false;
             ASPxCheckRubro.Enabled= false;
             ASPxCheckGenerica.Enabled= false;
             ASPxCheckSGenerica.Enabled= false;
             ASPxCheckSGenericaDet.Enabled= false;
             ASPxCheckEspecifica.Enabled= false;
             ASPxCheckEspecificaD.Enabled= false;
             ASPxCheckDepartamento.Enabled= false;
             ASPxCheckProvincia.Enabled= false;
             ASPxCheckDistrito.Enabled = false;

            switch (this.ASPxPageControl1.ActiveTabPage.ToString())
            {
                case "GASTOS":
                     ASPxCheckPeriodo.Enabled = true;
                     ASPxCheckMes.Enabled= true;
                     ASPxCheckFuncion.Enabled= true;
                     ASPxCheckDFuncional.Enabled= true;
                     ASPxCheckGFuncional.Enabled= true;
                     ASPxCheckCFuncional.Enabled= true;
                     ASPxCheckPProyecto.Enabled= true;      
                     ASPxCheckAAObra.Enabled= true;
                     ASPxCheckRubro.Enabled= true;
                     ASPxCheckGenerica.Enabled= true;
                     ASPxCheckSGenerica.Enabled= true;
                     ASPxCheckSGenericaDet.Enabled= true;
                     ASPxCheckEspecifica.Enabled= true;
                     ASPxCheckEspecificaD.Enabled= true;
                     ASPxCheckDepartamento.Enabled= true;
                     ASPxCheckProvincia.Enabled= true;
                     ASPxCheckDistrito.Enabled = true;
                     break;
                case "INGRESOS":
                     ASPxCheckPeriodo.Enabled = true;
                     ASPxCheckMes.Enabled= true;
                     ASPxCheckRubro.Enabled= true;
                     ASPxCheckGenerica.Enabled= true;
                     ASPxCheckSGenerica.Enabled= true;
                     ASPxCheckSGenericaDet.Enabled= true;
                     ASPxCheckEspecifica.Enabled= true;
                     ASPxCheckEspecificaD.Enabled= true;
                    break;
                default:
                     ASPxCheckPeriodo.Enabled = true;
                     ASPxCheckFuncion.Enabled= true;
                     ASPxCheckDFuncional.Enabled= true;
                     ASPxCheckGFuncional.Enabled= true;
                     ASPxCheckCFuncional.Enabled= true;
                     ASPxCheckPProyecto.Enabled= true;      
                     ASPxCheckAAObra.Enabled= true;
                     ASPxCheckRubro.Enabled= true;
                     ASPxCheckGenerica.Enabled= true;
                     ASPxCheckSGenerica.Enabled= true;
                     ASPxCheckSGenericaDet.Enabled= true;
                     ASPxCheckEspecifica.Enabled= true;
                     ASPxCheckEspecificaD.Enabled= true;
                     ASPxCheckDepartamento.Enabled= true;
                     ASPxCheckProvincia.Enabled= true;
                     ASPxCheckDistrito.Enabled = true;
                     break;
            }

        }


   
        protected void ASPxPageControl1_ActiveTabChanged1(object sender, TabControlEventArgs e)
        {
            Session["btnProcesarClick"] = "0";
            this.CargaData();
            Session["btnProcesarClick"] = "1";
        }
        public static string CreateXmlMenuEjecutora(DataSet ds1)
        {
            //Format XML data stream for menu tree
            StringBuilder o1 = new StringBuilder();
            o1.Append("<?xml version='1.0' encoding='utf-8' ?><ejecutoras>");
            int i = 0;
            while (i < ds1.Tables[0].Rows.Count)
            {
                o1.Append("<ejecutora name='" + ds1.Tables[0].Rows[i]["SEC_EJEC"].ToString() + "' text='" + ds1.Tables[0].Rows[i]["ABREVIATURA"].ToString() + "' id='" + ds1.Tables[0].Rows[i]["SEC_EJEC"].ToString() + "'></ejecutora>");
                i++;
            }
            o1.Append("</ejecutoras>");
            return o1.ToString();
        }

        #endregion

    }
}
