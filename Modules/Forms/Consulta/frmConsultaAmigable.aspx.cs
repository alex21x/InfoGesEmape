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
using DevExpress.Web.Data;


namespace InfoGesRegional.Modules.Forms.Consulta
{
    public partial class frmConsultaAmigable : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            InfoGesRegional.Modules.MasterPage m = (InfoGesRegional.Modules.MasterPage)Page.Master;


            if (!Page.IsPostBack)
            {
                DataTable ds2 = new DataTable();

                ds2.Columns.Add("CONDICION", Type.GetType("System.String"));
                ds2.Columns.Add("DESCRIPCION", Type.GetType("System.String"));
                ds2.Columns.Add("PIA", Type.GetType("System.Decimal"));
                ds2.Columns.Add("PIM", Type.GetType("System.Decimal"));
                ds2.Columns.Add("COMPROMISOANUAL", Type.GetType("System.Decimal"));
                ds2.Columns.Add("COMPROMISO", Type.GetType("System.Decimal"));
                ds2.Columns.Add("DEVENGADO", Type.GetType("System.Decimal"));
                ds2.Columns.Add("GIRADO", Type.GetType("System.Decimal"));
                ds2.Columns.Add("AVANCE", Type.GetType("System.Decimal"));
                ds2.Columns.Add("NIVEL", Type.GetType("System.String"));


                Session["DataTable"] = ds2;
            }
            Session["FocusedRow"] = ASPxGridSeleccion.GetRowValues(ASPxGridSeleccion.FocusedRowIndex, new string[] { ASPxGridSeleccion.KeyFieldName });
        }

        #region btnProcesarClick1
        protected void btnProcesarClick1(object sender, EventArgs e)
        {

            string Cadena=" Select  distinct A.SEC_EJEC, a.sec_ejec+' '+b.nombre  as DESCRIPCION , ";
            Cadena += " 'AND A.SEC_EJEC=%'+A.SEC_EJEC+'%' AS CONDICION, ";
            Cadena += " sum(a.PIA) as PIA, ";
            Cadena += " sum(a.PIM) as PIM, ";
            Cadena += " sum(a.Comprometido_anual) as COMPROMISOANUAL, ";
            Cadena += " Sum(CASE WHEN a.Ciclo='G' and a.Fase='C' THEN a.ejecucion ELSE 0 END) as COMPROMISO, ";
            Cadena += " Sum(CASE WHEN a.Ciclo='G' and a.Fase='D' THEN a.ejecucion ELSE 0 END) as DEVENGADO, ";
            Cadena += " Sum(CASE WHEN a.Ciclo='G' and a.Fase='G' THEN a.ejecucion ELSE 0 END) as GIRADO, ";
            Cadena += " sum(a.pim)/Sum(CASE WHEN a.Ciclo='G' and a.Fase='C' THEN a.ejecucion ELSE 0 END)*100 AS AVANCE ";
            Cadena += " from dbo.inforeg_ejecucion_2009 a, ejecutora b ";
            Cadena +=" where a.sec_ejec=b.sec_ejec ";
            Cadena += " group by a.sec_ejec,b.nombre ";
            this.SearchAllSeleccion(Cadena);
        }
        #endregion

        #region btnProcesarClick2
        protected void btnProcesarClick2(object sender, EventArgs e)
        {
            this.RecorrerGrid();
        }
        #endregion

        #region btnProcesarClick3
        protected void btnProcesarClick3(object sender, EventArgs e)
        {

        }
        #endregion

        #region GetFieldValue
        public virtual string GetFieldValue(object item)
        {
            WebDescriptorRowBase row = item as WebDescriptorRowBase;
            return ASPxGridSeleccion.GetRowValues(row.VisibleIndex, ASPxGridSeleccion.KeyFieldName).ToString();
        }
        #endregion

        #region GetFieldChecked
        public virtual string GetFieldChecked(object item)
        {
            WebDescriptorRowBase row = item as WebDescriptorRowBase;
            object o = ASPxGridSeleccion.GetRowValues(row.VisibleIndex, ASPxGridSeleccion.KeyFieldName);
            return Session["FocusedRow"] == o ? "CHECKED" : "";
        }
        #endregion

        #region SearchAllSeleccion
        protected void SearchAllSeleccion(string SqlQuery)
        {
            DataSet ds1 = Code.Logic.Forms.Consulta.ConsultaAmigable.SearchAllSeleccion(SqlQuery);
            
            //Session["DataSet"] = ds1;
            ASPxGridSeleccion.DataSource = ds1.Tables[0];
            ASPxGridSeleccion.KeyFieldName = "CONDICION";
            ASPxGridSeleccion.DataBind();
            ds1.Dispose();
            ds1 = null;
        }
        #endregion
        
        #region RecorrerGrid
        protected void RecorrerGrid()
        {

            DataTable ds1 = (DataTable)Session["DataTable"];
            int end = ds1.Rows.Count;
            DataRow row1;
            foreach (DataRow row in ds1.Rows)
            {
                if((string)Session["FocusedRow"] == row[0].ToString())
                {
                    row1 = ds1.Rows[0];
                    ds1.Rows.Remove(row1);

                }
            }

            for (int i = ASPxGridSeleccion.VisibleStartIndex; i < ASPxGridSeleccion.VisibleStartIndex + ASPxGridSeleccion.VisibleRowCount; i++)
            {
                if ((string)Session["FocusedRow"] == ASPxGridSeleccion.GetRowValues(i, ASPxGridSeleccion.KeyFieldName).ToString())
                {
                    ds1.Rows.Add( ASPxGridSeleccion.GetRowValues(i, ASPxGridSeleccion.KeyFieldName).ToString(),
                        ASPxGridSeleccion.GetRowValues(i, "DESCRIPCION").ToString(),
                        ASPxGridSeleccion.GetRowValues(i, "PIA").ToString(),
                        ASPxGridSeleccion.GetRowValues(i, "PIM").ToString(),
                        ASPxGridSeleccion.GetRowValues(i, "COMPROMISOANUAL").ToString(),
                        ASPxGridSeleccion.GetRowValues(i, "COMPROMISO").ToString(),
                        ASPxGridSeleccion.GetRowValues(i, "DEVENGADO").ToString(),
                        ASPxGridSeleccion.GetRowValues(i, "GIRADO").ToString(),
                        ASPxGridSeleccion.GetRowValues(i, "AVANCE").ToString(),"1");
                    ds1.AcceptChanges();
                }
            }

            ASPxGridConsulta.DataSource = ds1;
            ASPxGridConsulta.DataBind();
            ds1.Dispose();
            ds1 = null;

        }
        #endregion



    }
}
