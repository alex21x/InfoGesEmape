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
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxPivotGrid;
using System.Web.Services;
using System.Collections.Specialized;
using System.Text;
using DevExpress.Web.ASPxTabControl;




//http://ofi5.mef.gob.pe/ssi/wsSosem.asmx


namespace InfoGesRegional.Modules.Forms.Consulta
{
    public partial class frmInfoGesDinamica : System.Web.UI.Page
    {

        #region PageInit
        protected void Page_Init(object sender, EventArgs e)
        {

            this.LoadXmlEjecutora();
            this.LoadXmlPeriodo();
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

            this.CargaData();

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

            DataSet ds1 = Code.Logic.Forms.Consulta.InfoGesConsulta2009.InfoGesRegDinamicaQuery(CheckBox, tcDemos.ActiveTab.Name.ToString(), ASPxTabControleJEjecutora.ActiveTab.Name.ToString(), (string)(Session["BaseDeDatos"]));


            string[,] ArrayCubo = (string[,])Code.Logic.Forms.Consulta.InfoGesConsulta2009.InfoGesRegDinamicaArray(CheckBox).Clone();

            //int end = (ArrayCubo.Length / ArrayCubo.Rank);
            int end = ArrayCubo.Length / ArrayCubo.Rank;
            int x1 = 0;

        ///*https://www.devexpress.com/Support/Center/Question/Details/T406857/how-to-define-and-remove-data-fields-dynamically-on-custom-callback-using-the-client*/

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
                    ASPxPivotGridDinamica.Fields.Add(ArrayCubo[x1, 0].ToString(),DevExpress.XtraPivotGrid.PivotArea.ColumnArea);
                }
                else
                {
                    ASPxPivotGridDinamica.Fields.Add(ArrayCubo[x1, 0].ToString(),DevExpress.XtraPivotGrid.PivotArea.RowArea);
                }
                x1 = x1 + 1;

            }

            ASPxPivotGridDinamica.Fields.Add("EJECUCION", DevExpress.XtraPivotGrid.PivotArea.DataArea);
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

        #region Load Periodo

        protected void Load_Xml_Periodo(object sender, EventArgs e)
        {
            this.LoadXmlPeriodo();

        }

        protected void LoadXmlPeriodo()
        {
            this.XmlDataSource1.Data = "";
            this.XmlDataSource1.DataBind();
            this.XmlDataSource1.Data = CreateXmlMenuPeriodo(Code.Logic.Forms.Consulta.Cuadro.SearchAllPeriodo());
            this.XmlDataSource1.DataBind();
            tcDemos.DataBind();
        }
        protected void ASPxPageControl1_ActiveTabChanged(object sender, TabControlEventArgs e)
        {
            this.CargaData();

        }

        public static string CreateXmlMenuPeriodo(DataSet ds1)
        {
            //Format XML data stream for menu tree
            StringBuilder o1 = new StringBuilder();
            o1.Append("<?xml version='1.0' encoding='utf-8' ?><products>");
            int i = 0;
            while (i < ds1.Tables[0].Rows.Count)
            {
                o1.Append("<product name='" + ds1.Tables[0].Rows[i]["ANO_EJE"].ToString() + "' text='" + ds1.Tables[0].Rows[i]["ANO_EJE"].ToString() + "' id='" + ds1.Tables[0].Rows[i]["ANO_EJE"].ToString() + "'></product>");
                i++;
            }
            o1.Append("</products>");
            return o1.ToString();
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
            ds2 = Code.Logic.Forms.Consulta.Cuadro.SearchAllEjecutora((string)(Session["IdSecEjec"]));
            if (ds2.Tables[0].Rows.Count == 1)
                ASPxTabControleJEjecutora.Visible = false;

            this.XmlDataSource2.Data = "";
            this.XmlDataSource2.DataBind();
            this.XmlDataSource2.Data = CreateXmlMenuEjecutora(ds2);
            this.XmlDataSource2.DataBind();
            ASPxTabControleJEjecutora.DataBind();
        }
   
        protected void ASPxPageControl1_ActiveTabChanged1(object sender, TabControlEventArgs e)
        {
            //lcSec_ejec = ASPxTabControleJEjecutora.ActiveTab.Name;
            this.CargaData();

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
