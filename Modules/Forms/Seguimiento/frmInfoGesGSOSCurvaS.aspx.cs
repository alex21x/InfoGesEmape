using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InfogesEmape.Modules.Forms.Seguimiento
{
    public partial class frmInfoGesGSOSCurvaS : System.Web.UI.Page
    {

        private string pIdProyecto;
        private string pIdContrato;
        private string pIdValorizacion;
        private string pEjecucion;
        protected void Page_Load(object sender, EventArgs e)
        {

            pIdProyecto = (string)Session["pIdProyecto"];
            pIdContrato = "" + Request.Params["pIdContrato"];
            pIdValorizacion = "" + Request.Params["pIdValorizacion"];
            pEjecucion = "" + Request.Params["pEjecucion"];

            SearchByProyectoContrato();
            SearchByProyectoContratoResumen();
            DataSet ds1 = new DataSet();
            string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();

            //ds1 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoCronograma((string)(Session["pIdProyecto"]), IdContrato);
            ds1 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoCronograma02((string)(Session["pIdProyecto"]), IdContrato, pIdValorizacion, pEjecucion);

            GridProyectoContratoResumen.DataSource = ds1.Tables[0];
            GridProyectoContratoResumen.DataBind();
                
            //int IdValorizacion = 1;
            //DataSet ds2 = new DataSet();
            //ds2= Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoCon((string)(Session["pIdProyecto"]), IdContrato);
            Series series1 = new Series("PROGRAMACIÓN", ViewType.Line);
			Series series2 = new Series("AVANCE", ViewType.Line);
			series1.ArgumentDataMember = "CRONOGRAMA_FECHA";
			series1.ValueDataMembers[0] = "AVANCE_CRONOGRAMA";

			series2.ArgumentDataMember = "SEGUIMIENTO_FECHA";
			series2.ValueDataMembers[0] = "AVANCE_VALORIZACION";

			WebChartControl2.Series.Add(series1);
			WebChartControl2.Series.Add(series2);
			WebChartControl2.DataSource = ds1.Tables[0];
			WebChartControl2.DataMember = "AVANCE";
			WebChartControl2.DataBind();			
		}


        #region OnLoadProyectoContrato
        protected void OnLoadProyectoContrato(object sender, EventArgs e)
        {
            this.SearchByProyectoContrato();
        }
        #endregion

        #region SearchByProyectoContrato
        private void SearchByProyectoContrato()
        {

            DataSet ds3 = new DataSet();
            ds3 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContrato((string)(Session["pIdProyecto"]), (string)(Session["IdDni"]));
            GridProyectoContrato.KeyFieldName = "IDCONTRATO";
            GridProyectoContrato.DataSource = ds3.Tables[0];
            GridProyectoContrato.DataBind();
        }

        #endregion

        protected void grafico_Load(object sender, EventArgs e)
        {




        }
        private void SearchByProyectoContratoResumen()
        {
            string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();
            DataSet ds4 = new DataSet();
            ds4 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoResumen(pIdProyecto, IdContrato);
            // ds4 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoCronograma02((string)(Session["pIdProyecto"]), IdContrato, pIdValorizacion, pEjecucion);
            GridProyectoContratoResumen.KeyFieldName = "IDCONTRATO";
            GridProyectoContratoResumen.DataSource = ds4.Tables[0];
            GridProyectoContratoResumen.DataBind();
        }



    }
}