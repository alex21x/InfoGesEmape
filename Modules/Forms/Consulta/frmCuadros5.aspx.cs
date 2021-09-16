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
    public partial class frmCuadros5 : System.Web.UI.Page
    {

        //string lcAno_eje ;
        //string lcSec_ejec;
        #region PageInit


        protected void Page_Init(object sender, EventArgs e)
        {
///*https://agorapub.net/jubilacion-suiza-adw-peru/?gclid=EAIaIQobChMIv9rZg-T23wIVwyaHCh2UugTUEAEYASAAEgJYFvD_BwE */
///
                this.LoadXmlEjecutora();
                this.LoadXmlPeriodo();
                this.CargarGraficos();

        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InfoGesRegional.Modules.MasterPage m = (InfoGesRegional.Modules.MasterPage)Page.Master;

            if (Context.User.Identity.IsAuthenticated)
            {
            }
            else
             Response.Redirect("~/Default.aspx");

        }

        private void CargarGraficos()
        {
            this.LoadPresupuesto();
            this.LoadPorRubro();
            this.LoadPorConcepto();
            this.LoadPorFuncion();
            this.LoadPorComparativo();
            this.LoadExpxGasto();

        }

        #region Load Periodo

        protected void Load_Xml_Periodo(object sender, EventArgs e)
        {
            this.LoadXmlPeriodo();
         }
        protected void LoadXmlPeriodo()
        {
            this.XmlDataSource1.Data = "";
            this.XmlDataSource1.DataBind();
            this.XmlDataSource1.Data = CreateXmlMenuPeriodo(Code.Logic.Forms.Consulta.Cuadro2.SearchAllPeriodo(""));
            this.XmlDataSource1.DataBind();
            tcDemos.DataBind();
        }

        protected void ASPxPageControl1_ActiveTabChanged(object sender, TabControlEventArgs e)
        {
            //lcAno_eje = tcDemos.ActiveTab.Name;
            this.CargarGraficos();
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

        #endregion

        #region ASPxGridviewPresupuesto
        protected void LoadPresupuesto()
        {
            DataSet ds3 = new DataSet();
            string IdCadena = "2018,2019";
            ds3 = Code.Logic.Forms.Consulta.Cuadro3.SearchByPresupuesto((string)(Session["SecEjecId"]), (string)(Session["IdBaseDeDatos"]), tcDemos.ActiveTab.Name.ToString());
            ASPxGridviewPresupuesto.DataSource = ds3.Tables[0];
            ASPxGridviewPresupuesto.DataBind();
        }
        #endregion

        #region ASPxGridviewPorConcepto
        protected void LoadPorConcepto()
        {
            DataSet ds3 = new DataSet();
            string IdCadena = "2018,2019";
            ds3 = Code.Logic.Forms.Consulta.Cuadro3.SearchByGrupoGenerico((string)(Session["SecEjecId"]), (string)(Session["IdBaseDeDatos"]), tcDemos.ActiveTab.Name.ToString());
            ASPxGridviewPorGenerica.DataSource = ds3.Tables[0];
            ASPxGridviewPorGenerica.DataBind();
        }
        #endregion

        #region ASPxGridviewPorRubro
        protected void LoadPorRubro()
        {
            DataSet ds3 = new DataSet();
            string IdCadena = "2018,2019";
            ds3 = Code.Logic.Forms.Consulta.Cuadro3.SearchByFuenteFinanc((string)(Session["SecEjecId"]), (string)(Session["IdBaseDeDatos"]), tcDemos.ActiveTab.Name.ToString());
            ASPxGridviewPorRubro.DataSource = ds3.Tables[0];
            ASPxGridviewPorRubro.DataBind();
        }
        #endregion


        #region ASPxGridviewPorfuncion
        protected void LoadPorFuncion()
        {
            DataSet ds3 = new DataSet();
            string IdCadena = "2018,2019";
            ds3 = Code.Logic.Forms.Consulta.Cuadro3.SearchByFuncion((string)(Session["SecEjecId"]), (string)(Session["IdBaseDeDatos"]), tcDemos.ActiveTab.Name.ToString());
            ASPxGridviewPorFuncion.DataSource = ds3.Tables[0];
            ASPxGridviewPorFuncion.DataBind();
        }
        #endregion



        #region ASPxGridviewPorComparativo
        protected void LoadPorComparativo()
        {
            DataSet ds3 = new DataSet();
            string IdCadena = "2018,2019";
            ds3 = Code.Logic.Forms.Consulta.Cuadro3.SearchAllGenericaComparativo((string)(Session["SecEjecId"]), (string)(Session["IdBaseDeDatos"]), tcDemos.ActiveTab.Name.ToString());
            ASPxPivotGridEjecucionAcumulada.DataSource = ds3.Tables[0];
            ASPxPivotGridEjecucionAcumulada.DataBind();
        }
        #endregion

        #region LoadInfo_Exp_x_Gasto
        protected void LoadInfo_Exp_x_Gasto(object sender, EventArgs e)
        {
            LoadExpxGasto();
        }

        protected void LoadExpxGasto()
        {

            DataSet ds2 = new DataSet();
            ds2 = Code.Logic.Forms.Consulta.Cuadro3.SearchAllExpedienteFechas((string)(Session["SecEjecId"]), (string)(Session["IdBaseDeDatos"]), tcDemos.ActiveTab.Name.ToString());
            ASPxGridInfoGes.DataSource = ds2.Tables[0];
            ASPxGridInfoGes.DataBind();
            //}

        }
        #endregion

        #region ASPxPivotGridEjecucion
        protected void LoadASPxPivotGridEjecucion(object sender, EventArgs e)
        {
            this.LoadEjecucion();
        }

        protected void LoadEjecucion()
        {
            DataSet ds3 = new DataSet();
            string IdCadena = "2018,2019";
            ds3 = Code.Logic.Forms.Consulta.Cuadro2.SearchByEjecucion((string)(Session["SecEjecId"]), (string)(Session["IdBaseDeDatos"]), tcDemos.ActiveTab.Name.ToString());
            ASPxPivotGridEjecucion.DataSource = ds3.Tables[0];
            ASPxPivotGridEjecucion.DataBind();
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
            ds2 = Code.Logic.Forms.Consulta.Cuadro2.SearchAllEjecutora((string)(Session["SecEjecId"]));
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
            this.CargarGraficos();
        }        

        public static string CreateXmlMenuEjecutora(DataSet ds1)
        {
            //Format XML data stream for menu tree
            StringBuilder o1 = new StringBuilder();
            o1.Clear();
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

