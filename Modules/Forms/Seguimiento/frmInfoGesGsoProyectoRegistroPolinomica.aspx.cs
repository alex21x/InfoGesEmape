using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InfogesEmape.Modules.Forms.Seguimiento
{
	public partial class frmInfoGesGsoProyectoRegistroPolinomica : System.Web.UI.Page
	{

		private string pIdProyecto;
		private string pIdContrato;
		private string pIdValorizacion;
		
		

		protected void Page_Load(object sender, EventArgs e)
		{

			InfogesEmape.Modules.MasterPage m = (InfogesEmape.Modules.MasterPage)Page.Master;


			pIdProyecto = (string)Session["pIdProyecto"];
			pIdContrato = "" + Request.Params["pIdContrato"];
			pIdValorizacion = "" + Request.Params["pIdValorizacion"];
			
		
			//pIdOPeracion = "" + Request.Params["pOpera"];

			Session["pIdProyecto"] = pIdProyecto;
			//Session["pIdContrato"] = pIdContrato;
			Session["pIdValorizacion"] = pIdValorizacion;
			pIdProyecto = (pIdProyecto.ToString().Length == 0 ? "0" : pIdProyecto.ToString());
			//pIdContrato = (pIdContrato.ToString().Length == 0 ? "0" : pIdContrato.ToString());
		}


		/*CAMBIO						FECHA			AUTOR
		SELECT VALORIZACION POLINOMICA	21-07-2021	    ALEXANDER FERNÁNDEZ 21-07-2021*/
		protected void GridValorizacionPolinomica_Load(object sender, EventArgs e)
		{
			this.SearchByValorizacionPolinomica();
		}


		private void SearchByValorizacionPolinomica() {

			DataSet ds1 = new DataSet();
			//string IdContrato = GridValorizacionPolinomica.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();

			ds1 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByValorizacionPolinomica((string)(Session["pIdProyecto"]), (string)(Session["pIdValorizacion"]));
			GridValorizacionPolinomica.KeyFieldName = "VAP_ID";
			GridValorizacionPolinomica.DataSource = ds1.Tables[0];
			GridValorizacionPolinomica.DataBind();
		}


		/*CAMBIO						FECHA			AUTOR
		UPDATE VALORIZACION POLINOMICA	21-07-2021	    ALEXANDER FERNÁNDEZ 21-07-2021*/
		protected void GridValorizacionPolinomica_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
		{
			string pCantidad;		
			if (e.NewValues["VAP_CANTIDAD"] == null)
				pCantidad = "0";
			else
				pCantidad = (e.NewValues["VAP_CANTIDAD"].ToString().Length == 0 ? "null" : e.NewValues["VAP_CANTIDAD"].ToString());

								
			string Id = e.Keys["VAP_ID"].ToString();
			//string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();

			string[] parameters = {pCantidad };

			string LvCadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.UpdateRowValorizacionPolinomica(parameters, Id);

			GridValorizacionPolinomica.CancelEdit();
			e.Cancel = true;
			this.SearchByValorizacionPolinomica();
			//GridContratoValorizacionDet.CancelEdit();
			//e.Cancel = true;

			//GridProyectoContratoCon.DetailRows.ExpandRow(0);
			//DataSet ds4 = new DataSet();
			//string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();
			//string IdValorizacion = GridProyectoContratoCon.GetRowValues(GridProyectoContratoCon.FocusedRowIndex, "IDCONTRATOSEGUIMIENTO").ToString();
			//txtMensaje.Text = "1";
			//MessageBox.Show('hola');			
			//ds4 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByContratoValorizacionDet((string)(Session["pIdProyecto"]), IdValorizacion);
		
			//GridValorizacionPolinomica.KeyFieldName = "IDCONTRATOVALORIZACIONDET";
			//GridValorizacionPolinomica.DataSource = ds4.Tables[0];
			//GridValorizacionPolinomica.DataBind();
		}

		protected void GridValorizacionPolinomica_CustomUnboundColumnData(object sender, DevExpress.Web.ASPxGridViewColumnDataEventArgs e)
		{
			if (e.Column.FieldName == "VAP_TOTAL")
			{
				decimal factor = (decimal)e.GetListSourceFieldValue("VAP_FACTOR");
				decimal valor_0 = Convert.ToDecimal(e.GetListSourceFieldValue("VAP_INDICE_VALOR"));
				decimal valor_r = Convert.ToDecimal(e.GetListSourceFieldValue("VAP_CANTIDAD"));
				e.Value = factor*(valor_r/ valor_0);
			}
		}

		protected void GridValorizacionPolinomica_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
		{
			if ((e.Item as ASPxSummaryItem).Tag == "1")
			{
				ASPxSummaryItem incomeSummary = (sender as ASPxGridView).TotalSummary["VAP_TOTAL"];
				//ASPxSummaryItem expenseSummary = (sender as ASPxGridView).TotalSummary["Expense"];
				Decimal factor_k = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary));
				//Decimal expense = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(expenseSummary));				
				e.TotalValue = factor_k/100;
				//string[] parameters = { factor_k.ToString() };				
				//Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.UpdateRowValoriza02(parameters, (string)(Session["pIdValorizacion"]));

				string[] parameters = { factor_k.ToString() };
				string LvCadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.UpdateRowValorizacionPolinomica02(parameters, (string)(Session["pIdValorizacion"]));

				//GridProyectoContratoCon.CancelEdit();
				//e.Cancel = true;
				//this.SearchByProyectoContratoCon();
			}
		}
	}
}