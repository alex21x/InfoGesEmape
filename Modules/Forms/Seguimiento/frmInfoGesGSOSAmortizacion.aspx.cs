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
    public partial class frmInfoGesGSOSAmortizacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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



        #region OnloadProyectoContratoCon
        /*CAMBIO						FECHA			AUTOR
		SELECT	AVANCE DE CONTRATISTA	03-06-2021	    ALEXANDER FERNÁNDEZ 03-06-2021*/
        protected void OnloadProyectoContratoCon(object sender, EventArgs e)
        {
            this.SearchByProyectoContratoCon();
        }
        #endregion


        #region  SearchByProyectoContratoCon
        /*CAMBIO						FECHA			AUTOR
		SELECT	AVANCE DE CONTRATISTA	01-06-2021	    ALEXANDER FERNÁNDEZ 01-06-2021*/
        private void SearchByProyectoContratoCon()
        {
            //if (pnContrato != 0)
            //{
            DataSet ds5 = new DataSet();
            string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();

            ds5 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoCon((string)(Session["pIdProyecto"]), IdContrato,"", (string)(Session["pEjecucion_"]));

            GridProyectoContratoCon.KeyFieldName = "IDCONTRATOSEGUIMIENTO";
            GridProyectoContratoCon.DataSource = ds5.Tables[0];
            GridProyectoContratoCon.DataBind();
            //}
        }
        #endregion


        #region UpdateRowProyectoContratoCon
        /*CAMBIO						FECHA			AUTOR
		UPDATE	AVANCE DE CONTRATISTA	03-06-2021	    ALEXANDER FERNÁNDEZ 03-06-2021*/
        protected void OnRowUpdatingProyectoContratoCon(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string pValorizaconFecha, pValorizacionNumero, pAvance, lcAprobado, pAdelantoDirecto, pAdelantoMateriales;

            lcAprobado = (Convert.ToBoolean(e.NewValues["APROBADO"]) ? "1" : "0");

            if (e.NewValues["SEGUIMIENTO_FECHA"] == null)
                pValorizaconFecha = "";
            else
                pValorizaconFecha = (e.NewValues["SEGUIMIENTO_FECHA"].ToString().Length == 0 ? "null" : e.NewValues["SEGUIMIENTO_FECHA"].ToString());


            if (e.NewValues["SEGUIMIENTO_CRONOGRAMA"] == null)
                pValorizacionNumero = "";
            else
                pValorizacionNumero = (e.NewValues["SEGUIMIENTO_CRONOGRAMA"].ToString().Length == 0 ? "null" : e.NewValues["SEGUIMIENTO_CRONOGRAMA"].ToString());

            if (e.NewValues["AVANCE"] == null)
                pAvance = "NCN";
            else
                pAvance = (e.NewValues["AVANCE"].ToString().Length == 0 ? "null" : e.NewValues["AVANCE"].ToString());


			if (e.NewValues["ADELANTO_DIRECTO"] == null)
				pAdelantoDirecto = "NCN";
			else
				pAdelantoDirecto = (e.NewValues["ADELANTO_DIRECTO"].ToString().Length == 0 ? "null" : e.NewValues["ADELANTO_DIRECTO"].ToString());


			if (e.NewValues["ADELANTO_MATERIALES"] == null)
				pAdelantoMateriales = "NCN";
			else
				pAdelantoMateriales = (e.NewValues["ADELANTO_MATERIALES"].ToString().Length == 0 ? "null" : e.NewValues["ADELANTO_MATERIALES"].ToString());

			string Id = e.Keys["IDCONTRATOSEGUIMIENTO"].ToString();
            string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();

            string[] parameters = { IdContrato, pValorizaconFecha, pValorizacionNumero, pAvance, pAdelantoDirecto, pAdelantoMateriales, lcAprobado };
            string LvCadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.UpdateRowProyectoContratoCon(parameters, Id);

            GridProyectoContratoCon.CancelEdit();
            e.Cancel = true;
            this.SearchByProyectoContratoCon();
        }
        #endregion



        #region GridProyectoProyectoContratoCon_RowValidating
        /*CAMBIO						FECHA			AUTOR
		VALIDACIÓN AVANCE CONTRATISTA	09-06-2021	    ALEXANDER FERNÁNDEZ 03-06-2021*/
        protected void GridProyectoProyectoContratoCon_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {         
            if (e.NewValues["SEGUIMIENTO_FECHA"] != null && e.NewValues["SEGUIMIENTO_FECHA"].ToString().Length < 10)
            {
                AddError(e.Errors, GridProyectoContratoCon.Columns["SEGUIMIENTO_FECHA"], "Registrar correctamente la Fecha del cronograma.");
            }            
            if (string.IsNullOrEmpty(e.RowError) && e.Errors.Count > 0) e.RowError = "Por favor, corregir los errores.";
        }
        void AddError(Dictionary<GridViewColumn, string> errors, GridViewColumn column, string errorText)
        {
            if (errors.ContainsKey(column)) return;
            errors[column] = errorText;
        }
        protected void GridProyectoContratoCon_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            if (!object.Equals(e.RowType, GridViewRowType.Data)) return;

            bool hasError = string.IsNullOrEmpty(e.GetValue("SEGUIMIENTO_FECHA").ToString());            
        }
        protected void GridProyectoContratoCon_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            GridProyectoContratoCon.DoRowValidation();
        }
        #endregion


        protected void comando(object sender, ASPxGridViewTableCommandCellEventArgs e)
        {
            bool bVisible = InfoVisibleCriteria((ASPxGridView)sender, e.VisibleIndex);            
            ASPxGridView GridContratoValorizacionDet = (ASPxGridView)sender;            

            if (!bVisible)
            {
                e.Cell.Controls[0].Visible = false;  // hide the New button
                e.Cell.Controls[1].Visible = false;                         
            }
        }

        private bool InfoVisibleCriteria(ASPxGridView grid, int visibleIndex)
        {
            object row = grid.GetRow(visibleIndex);
            return ((DataRowView)row)["APROBADO"].ToString().Contains("0");
        }
    }
}