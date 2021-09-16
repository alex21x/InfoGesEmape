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
    public partial class frmProgramacionGastoCierre : System.Web.UI.Page
    {

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
            InfoGesRegional.Modules.MasterPage m = (InfoGesRegional.Modules.MasterPage)Page.Master;
            if (!Page.IsPostBack)
            {

            }
        }

        #region LoadProgramacionGastoCierre
        protected void LoadProgramacionGastoCierre(object sender, EventArgs e)
        {
            LoadGastoCierre();
        }
        #endregion

        #region LoadGastoCierre
        protected void LoadGastoCierre()
        {
            DataSet ds3 = new DataSet();

            ds3 = Code.Logic.Forms.Input.ProgramacionGasto.SearchByProgramacionGastoCierre();
            ASPxGridviewProgramacionGastoCierre.DataSource = ds3.Tables[0];
            ASPxGridviewProgramacionGastoCierre.DataBind();


            ReadOnlyTemplate template = new ReadOnlyTemplate();

            (ASPxGridviewProgramacionGastoCierre.Columns["ANO_EJE"] as GridViewDataColumn).EditItemTemplate = template;
            (ASPxGridviewProgramacionGastoCierre.Columns["MES_EJE_DESCRIPCION"] as GridViewDataColumn).EditItemTemplate = template;

        }
        #endregion

        #region EditorInitialize_Programacion_gasto
        protected void EditorInitialize_Programacion_gasto(object sender, ASPxGridViewEditorEventArgs e)
        {

        }
        #endregion

        #region Updated_Programacion_Gasto_Cierre
        protected void Updated_Programacion_Gasto_Cierre(Object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string lvCierreProgramacion = "";
            string lvFechaCierreProgramacion = "";

            if (e.NewValues["CIERRE_PROGRAMACION"] != null)
                lvCierreProgramacion = (e.NewValues["CIERRE_PROGRAMACION"].ToString().Length == 0 ? "0" : e.NewValues["CIERRE_PROGRAMACION"].ToString());

            if (e.NewValues["CIERRE_PROGRAMACION"] != null)
                lvFechaCierreProgramacion = (e.NewValues["CIERRE_PROGRAMACION"].ToString().Length == 0 ? "0" : e.NewValues["CIERRE_PROGRAMACION"].ToString());



            string[] parameters = { lvCierreProgramacion, lvFechaCierreProgramacion };

            string Id = e.Keys["ID_PROGRAMACION"].ToString();

            string Cadena = "";
                Cadena = Code.Logic.Forms.Input.ProgramacionGasto.Updated_Programacion_Gasto(parameters, Id);
            if (Cadena.ToString().Length != 0)
            {
                throw new Exception(Cadena);
            }
            else
            {
                e.Cancel = true;
                ASPxGridviewProgramacionGastoCierre.CancelEdit();
                LoadGastoCierre();
            }

        }
        #endregion

        protected void btnXlsExport_Click(object sender, EventArgs e)
        {
            gridExport.WriteXlsToResponse();
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
