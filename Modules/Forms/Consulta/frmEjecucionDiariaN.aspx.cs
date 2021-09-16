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
using DevExpress.Web;




namespace InfoGesRegional.Modules.Forms.Consulta
{
    public partial class frmEjecucionDiariaN : System.Web.UI.Page
    {

         #region PageInit
        protected void Page_Init(object sender, EventArgs e)
        {
            this.LoadXmlEjecutora();
            this.LoadXmlPeriodo();
            this.LoadFechaEjecucion();
            Session["baseURL1"] = "frmEjecucionDiariaN_Det.aspx";

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

        #region hyperLink_InitDetailCaja
        protected void hyperLink_InitDetailCaja(object sender, EventArgs e)
        {
            ASPxHyperLink link = (ASPxHyperLink)sender;

            GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;
            
            int rowVisibleIndex = templateContainer.VisibleIndex;
            string pIdAnoEje = tcDemos.ActiveTab.Name.ToString();
            string pIdSecEjec = (string)(Session["SecEjecId"]);
            string pIdFechaDoc = templateContainer.Grid.GetRowValues(rowVisibleIndex, "FECHA_DOC").ToString();
            //string contentUrl = string.Format("{0}?pId={1}", Session["baseURL1"], pId);
            string contentUrl = string.Format("{0}?pIdAnoEje={1}&pIdSec_Ejec={2}&pIdFechaDoc={3}&pIdBaseDatos={4}", Session["baseURL1"], pIdAnoEje, pIdSecEjec, pIdFechaDoc, (string)(Session["IdBaseDeDatos"]));

            link.NavigateUrl = "javascript:void(0);";

            //            link.Text = string.Format("More Info: ID_TIPO_CAMBIO - {0}", pId);
            link.Text = string.Format("{0}", templateContainer.Grid.GetRowValues(rowVisibleIndex, "FECHA_DOC").ToString());
            link.ClientSideEvents.Click = string.Format("function(s, e) {{ OnMoreInfoClick('{0}'); }}", contentUrl);


        }
        #endregion

    }
}
