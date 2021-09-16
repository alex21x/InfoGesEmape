using System;
using System.Text;
using System.IO;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Web;
using System.Web.Security;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Native;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxTabControl;


namespace InfoGesRegional.Modules.Forms.Consulta
{
    public partial class frmEjecucionDiaria : System.Web.UI.Page
    {

         #region PageInit
        protected void Page_Init(object sender, EventArgs e)
        {
            this.LoadXmlEjecutora();
            this.LoadXmlPeriodo();
            this.LoadFechaEjecucion();


        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InfoGesRegional.Modules.MasterPage m = (InfoGesRegional.Modules.MasterPage)Page.Master;

            if (Context.User.Identity.IsAuthenticated)
            { }
            else
                Response.Redirect("~/Default.aspx");            
        }

        #region LoadXmlPeriodo
        protected void LoadXmlPeriodo()
        {
            this.XmlDataSource1.Data = "";
            this.XmlDataSource1.DataBind();
            this.XmlDataSource1.Data = CreateXmlMenuPeriodo(Code.Logic.Forms.Consulta.Cuadro.SearchAllPeriodo((string)(Session["SecEjecId"])));
            this.XmlDataSource1.DataBind();
            tcDemos.DataBind();
        }
        public static string CreateXmlMenuPeriodo(DataSet ds1)
        {
            //Format XML data stream for menu tree
            StringBuilder o1 = new StringBuilder();
            o1.Clear();
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
        protected void ASPxPageControl1_ActiveTabChanged(object sender, TabControlEventArgs e)
        {
            this.LoadFechaEjecucion();
        }
        #endregion

        #region ASPxGridviewFechaEjecucion

            protected void Load_Fecha_Ejecutora(object sender, EventArgs e)
            {
                this.LoadFechaEjecucion();

            }

            protected void LoadFechaEjecucion()
            {
                DataSet ds2 = new DataSet();
                ds2 = Code.Logic.Forms.Consulta.EjecucionDiaria.LoadFechaEjecucion(ASPxTabControleJEjecutora.ActiveTab.Name.ToString(), (string)(Session["IdBaseDeDatos"]), tcDemos.ActiveTab.Name.ToString());
                ASPxGridviewFechaEjecucion.DataSource = ds2.Tables[0];
                ASPxGridviewFechaEjecucion.DataBind();
                ds2.Dispose();
                ds2 = null;
            }

        #endregion

        #region ASPxTabControleJEjecutora

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
            protected void ASPxPageControl1_ActiveTabChanged1(object sender, TabControlEventArgs e)
            {
                //lcSec_ejec = ASPxTabControleJEjecutora.ActiveTab.Name;
                this.LoadXmlEjecutora();
            }

        #endregion

         #region ASPxGridviewFEGasto
            protected void LoadFEGasto(object sender, EventArgs e)
            {
                this.LoadFechaEjecucionExpedienteG();
            }
            protected void gvDetail_CustomCallbackG(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventArgs e)
            {
                this.LoadFechaEjecucionExpedienteG();
            }
            protected void LoadFechaEjecucionExpedienteG()
            {
                string FechaDoc = ASPxGridviewFechaEjecucion.GetRowValues(ASPxGridviewFechaEjecucion.FocusedRowIndex, "FECHA_DOC").ToString();
                string AnoEje = ASPxGridviewFechaEjecucion.GetRowValues(ASPxGridviewFechaEjecucion.FocusedRowIndex, "ANO_EJE").ToString();
                DataSet ds2 = new DataSet();
                ds2 = Code.Logic.Forms.Consulta.EjecucionDiaria.LoadFechaEjecucionExpediente(ASPxTabControleJEjecutora.ActiveTab.Name.ToString(), (string)(Session["IdBaseDeDatos"]), FechaDoc, AnoEje, "GG");
                ASPxGridviewFEGasto.DataSource = ds2.Tables[0];
                ASPxGridviewFEGasto.DataBind();
                //ASPxGridviewFEGasto.ExpandAll();
                ds2.Dispose();
                ds2 = null;
            }
        #endregion



        #region ASPxGridviewFEIngreso
            protected void LoadFEIngreso(object sender, EventArgs e)
            {
                this.LoadFechaEjecucionExpedienteI();

            }
            protected void LoadFechaEjecucionExpedienteI()
            {
                string FechaDoc = ASPxGridviewFechaEjecucion.GetRowValues(ASPxGridviewFechaEjecucion.FocusedRowIndex, "FECHA_DOC").ToString();
                string AnoEje = ASPxGridviewFechaEjecucion.GetRowValues(ASPxGridviewFechaEjecucion.FocusedRowIndex, "ANO_EJE").ToString();
                DataSet ds2 = new DataSet();
                ds2 = Code.Logic.Forms.Consulta.EjecucionDiaria.LoadFechaEjecucionExpediente(ASPxTabControleJEjecutora.ActiveTab.Name.ToString(), (string)(Session["IdBaseDeDatos"]), FechaDoc, AnoEje, "IR");
                ASPxGridviewFEIngreso.DataSource = ds2.Tables[0];
                //ASPxGridviewFEGasto.GroupBy(ASPxGridviewFEGasto.Columns["FUENTE_FINANC"]);
                ASPxGridviewFEIngreso.DataBind();
                //ASPxGridviewFEIngreso.ExpandAll();
                ds2.Dispose();
                ds2 = null;
            }
            protected void gvDetail_CustomCallbackI(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventArgs e)
            {
                this.LoadFechaEjecucionExpedienteI();
            }
        #endregion




        #region ASPxPivotGridEjecucionAcumulada
            protected void LoadEjecuciónAcumulada(object sender, EventArgs e)
        {
            this.Load_Grid();
        }
        protected void Load_Grid()
        {
            DataSet ds3 = new DataSet();

            ds3 = Code.Logic.Forms.Consulta.EjecucionDiaria.LoadFechaEjecucionAcumulado((string)(Session["SecEjecId"]), (string)(Session["IdBaseDeDatos"]), tcDemos.ActiveTab.Name.ToString());
            ASPxPivotGridEjecucionAcumulada.DataSource = ds3.Tables[0];
            ASPxPivotGridEjecucionAcumulada.DataBind();
        }
        #endregion
    }
}
