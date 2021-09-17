using DevExpress.Utils;
using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InfogesEmape.Modules.Forms.Seguimiento
{
    public partial class frmInfogesGSOSSupervisores : System.Web.UI.Page
    {

        private string pIdProyecto;
        private string pIdContrato;
        private string pIdValorizacion;
        protected void Page_Load(object sender, EventArgs e)
        {
            pIdProyecto = (string)Session["pIdProyecto"];
            pIdContrato = "" + Request.Params["pIdContrato"];
            pIdValorizacion = "" + Request.Params["pIdValorizacion"];


            Session["pEjecucion_"] = "2";

            SearchByProyectoContrato();
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

        protected void GridContratoValorizacionDetSup_Load(object sender, EventArgs e)
        {
            //this.SearchByContratoValorizacionDet();
            DataSet ds4 = new DataSet();
            string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();
            //string IdValorizacion = GridProyectoContratoCon.GetRowValues(GridProyectoContratoCon.FocusedRowIndex, "IDCONTRATOSEGUIMIENTO").ToString();
            //txtMensaje.Text = "1";
            //MessageBox.Show('hola');
            ASPxGridView detailGrid = (ASPxGridView)sender;
            int IdValorizacion = (int)detailGrid.GetMasterRowKeyValue();

            ds4 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByContratoValorizacionDet((string)(Session["pIdProyecto"]), IdContrato, IdValorizacion, 2);

            ASPxGridView GridContratoValorizacionDet = (ASPxGridView)sender;

            GridContratoValorizacionDet.KeyFieldName = "IDCONTRATOVALORIZACIONDET";
            GridContratoValorizacionDet.DataSource = ds4.Tables[0];
            GridContratoValorizacionDet.DataBind();
        }



        #region OnloadProyectoContratoSup
        /*CAMBIO						FECHA			AUTOR
		SELECT	AVANCE DE SUPERVISOR	01-06-2021	    ALEXANDER FERNÁNDEZ 01-06-2021*/
        protected void OnloadProyectoContratoSup(object sender, EventArgs e)
        {
            this.SearchByProyectoContratoSup();
        }
        #endregion

        #region  SearchByProyectoContratoSup
        /*CAMBIO						FECHA			AUTOR
		SELECT	AVANCE DE SUPERVISOR	01-06-2021	    ALEXANDER FERNÁNDEZ 01-06-2021*/
        private void SearchByProyectoContratoSup()
        {
            //if (pnContrato != 0)
            //{
            DataSet ds4 = new DataSet();
            string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();

            //ds4 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoSup((string)(Session["pIdProyecto"]), IdContrato);
            ds4 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoCon((string)(Session["pIdProyecto"]), IdContrato, "", "2");

            GridProyectoContratoSup.KeyFieldName = "IDCONTRATOSEGUIMIENTO";
            GridProyectoContratoSup.DataSource = ds4.Tables[0];
            GridProyectoContratoSup.DataBind();
            //}
        }
        #endregion


        protected void GridContratoSupValorizacionDet_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string pCantidad;

            if (e.NewValues["CANTIDAD"] == null)
                pCantidad = "NCN";
            else
                pCantidad = (e.NewValues["CANTIDAD"].ToString().Length == 0 ? "null" : e.NewValues["CANTIDAD"].ToString());


            /*if (e.NewValues["CANTIDADCON"] == null)
				pCantidadCon = "NCN";
			else
				pCantidadCon = (e.NewValues["CANTIDADCON"].ToString().Length == 0 ? "null" : e.NewValues["CANTIDADCON"].ToString());*/

            string Id = e.Keys["IDCONTRATOVALORIZACIONDET"].ToString();
            string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();

            string[] parameters = { IdContrato, pCantidad };

            string LvCadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.UpdateRowContratoSupValorizacionDet(parameters, Id);
            e.Cancel = true;

            //GridProyectoContratoCon.DetailRows.ExpandRow(0);

            DataSet ds4 = new DataSet();
            //string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();
            //string IdValorizacion = GridProyectoContratoCon.GetRowValues(GridProyectoContratoCon.FocusedRowIndex, "IDCONTRATOSEGUIMIENTO").ToString();
            //txtMensaje.Text = "1";
            //MessageBox.Show('hola');
            ASPxGridView detailGrid = (ASPxGridView)sender;
            int IdValorizacion = (int)detailGrid.GetMasterRowKeyValue();

            ds4 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByContratoValorizacionDet((string)(Session["pIdProyecto"]), IdContrato, IdValorizacion, 2);

            ASPxGridView GridContratoValorizacionDet = (ASPxGridView)sender;

            GridContratoValorizacionDet.KeyFieldName = "IDCONTRATOVALORIZACIONDET";
            GridContratoValorizacionDet.DataSource = ds4.Tables[0];
            GridContratoValorizacionDet.DataBind();
        }


        protected void GridContratoValorizacionDet_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {

            if (!object.Equals(e.RowType, GridViewRowType.Data)) return;
            /*
                        //bool hasError = string.IsNullOrEmpty(e.GetValue("SEGUIMIENTO_FECHA").ToString());
                        string cantidad = e.GetValue("CANTIDAD").ToString();

                        //string saldo_old = e.OldValues["SALDO_OLD_"].ToString();

                        string cantidadSup = e.GetValue("CANTIDADSUP").ToString();

                        if (cantidad != cantidadSup)
                        {
                            //e.Row.ForeColor = System.Drawing.Color.Red;
                            e.Row.BackColor = Color.FromArgb(255, 204, 229);
                            //e.Row.BackColor = System.Drawing.Color.Red;
                        }*/
            decimal precio = (decimal)e.GetValue("PRECIO");

            if (precio > 0)
            {
                //e.Row.Cells[10].BackColor = Color.FromArgb(239, 239, 237);
                e.Row.Cells[10].BackColor = System.Drawing.Color.DarkRed;
                e.Row.Cells[1].BackColor = Color.FromArgb(208, 235, 251);
                //e.Row.Cells[2].BackColor = System.Drawing.Color.DarkRed;
            }


            if (precio == 0)
            {
                e.Row.BackColor = Color.FromArgb(144, 223, 203);

                // e.Row.BackColor = System.Drawing.Color.Red;
            }
        }



        protected void hyperLink_Init(object sender, EventArgs e)
        {
            ASPxHyperLink link = (ASPxHyperLink)sender;

            GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;

            int rowVisibleIndex = templateContainer.VisibleIndex;
            string pIdValorizacion = templateContainer.Grid.GetRowValues(rowVisibleIndex, "IDCONTRATOSEGUIMIENTO").ToString();

            //string Id = e.Keys["IDCONTRATOSEGUIMIENTO"].ToString();
            //string pIdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();

            //string contentUrl = string.Format("{0}?EAN13={1}", Session["baseURL"], pIdValorizacion);
            string contentUrl = "frmInfoGesGsoProyectoRegistroPolinomica.aspx" + "?pIdValorizacion=" + pIdValorizacion;

            link.NavigateUrl = "javascript:void(0);";
            //link.Text = string.Format("More Info: EAN13 - {0}", ean13);
            link.Text = string.Format("Polinómica", pIdValorizacion);
            link.ClientSideEvents.Click = string.Format("function(s, e) {{ OnMoreInfoClick('{0}'); }}", contentUrl);

        }

        // RESÚMEN VALORIZACIÓN
        protected void hyperLink_Init_resumen(object sender, EventArgs e)
        {
            ASPxHyperLink link = (ASPxHyperLink)sender;

            GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;

            int rowVisibleIndex = templateContainer.VisibleIndex;
            string pIdValorizacion = templateContainer.Grid.GetRowValues(rowVisibleIndex, "IDCONTRATOSEGUIMIENTO").ToString();

            //string Id = e.Keys["IDCONTRATOSEGUIMIENTO"].ToString();
            //string pIdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();

            //string contentUrl = string.Format("{0}?EAN13={1}", Session["baseURL"], pIdValorizacion);
            string contentUrl = "frmInfoGesGSOSResumen.aspx" + "?pIdValorizacion=" + pIdValorizacion + "&pEjecucion=2";

            link.NavigateUrl = "javascript:void(0);";
            //link.Text = string.Format("More Info: EAN13 - {0}", ean13);
            link.Text = string.Format("Resumen", pIdValorizacion);
            link.ClientSideEvents.Click = string.Format("function(s, e) {{ OnMoreInfoClick('{0}'); }}", contentUrl);

        }

        // CURVA S VALORIZACIÓN
        protected void hyperLink_Init_curva_s(object sender, EventArgs e)
        {
            ASPxHyperLink link = (ASPxHyperLink)sender;

            GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)link.NamingContainer;

            int rowVisibleIndex = templateContainer.VisibleIndex;
            string pIdValorizacion = templateContainer.Grid.GetRowValues(rowVisibleIndex, "IDCONTRATOSEGUIMIENTO").ToString();

            //string contentUrl = string.Format("{0}?EAN13={1}", Session["baseURL"], pIdValorizacion);
            string contentUrl = "frmInfoGesGSOSCurvaS.aspx" + "?pIdValorizacion=" + pIdValorizacion + "&pEjecucion=2";

            link.NavigateUrl = "javascript:void(0);";
            //link.Text = string.Format("More Info: EAN13 - {0}", ean13);
            link.Text = string.Format("Curva S", pIdValorizacion);
            link.ClientSideEvents.Click = string.Format("function(s, e) {{ OnMoreInfoClick('{0}'); }}", contentUrl);
        }


        #region
        protected void detailGrid_CustomUnboundColumnData(object sender, ASPxGridViewColumnDataEventArgs e)
        {
            DataSet ds4 = new DataSet();

            ASPxGridView detailGrid = (ASPxGridView)sender;
            int IdValorizacion = (int)detailGrid.GetMasterRowKeyValue();

            string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();
            ds4 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoCon((string)(Session["pIdProyecto"]), IdContrato, IdValorizacion.ToString());

            decimal aprobado = Convert.ToDecimal(ds4.Tables[0].Rows[0]["APROBADO"].ToString());

            ASPxGridView GridContratoValorizacionDet = (ASPxGridView)sender;


            //GridViewFormatConditionHighlight Rule = new GridViewFormatConditionHighlight();
            //Rule.FieldName = "CANTIDAD";
            //Rule.Expression = "[CANTIDAD] > 0";
            //Rule.Format = GridConditionHighlightFormat.GreenFillWithDarkGreenText;
            //GridContratoValorizacionDet.FormatConditions.Add(Rule);

            if (Convert.ToString(Session["ROLE"]) == "8")
            {
                //GridContratoValorizacionDet.DataColumns["CANTIDADSUP"].EditFormSettings.Visible = DefaultBoolean.False;
                //GridContratoValorizacionDet.DataColumns["CANTIDAD"].EditFormSettings.Visible = DefaultBoolean.False;
                //GridContratoValorizacionDet.Columns["CANTIDADSUP"].Visible = false;
                //GridContratoValorizacionDet.Columns["CANTIDADCON"].Visible = false;
            }
            else if (Convert.ToString(Session["ROLE"]) == "9")
            {
                //GridContratoValorizacionDet.DataColumns["CANTIDADSUP"].EditFormSettings.Visible = DefaultBoolean.False;
                //GridContratoValorizacionDet.DataColumns["CANTIDADCON"].EditFormSettings.Visible = DefaultBoolean.False;
                GridContratoValorizacionDet.Columns["CANTIDADSUP"].Visible = false;
                GridContratoValorizacionDet.Columns["CANTIDADCON"].Visible = false;
                GridContratoValorizacionDet.Columns["ACUMULADO"].Visible = true;
                GridContratoValorizacionDet.Columns["ACUMULADO_TOTAL"].Visible = true;

                //args.Column.OptionsColumn.ReadOnly = true;
                //dataTable.Columns[args.Column.FieldName].ReadOnly = true;
                GridContratoValorizacionDet.DataColumns["APROBADO"].ReadOnly = true;
            }

            if (aprobado == 1)
            {
                GridContratoValorizacionDet.DataColumns["CANTIDAD"].EditFormSettings.Visible = DefaultBoolean.False;
            }

            //ds5 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyectoContratoCon((string)(Session["pIdProyecto"]), IdContrato);

            //GridContratoValorizacionDet.Columns["SALDO_OLD"].Visible = false;
            GridContratoValorizacionDet.SettingsBehavior.AutoExpandAllGroups = true;

            //GridContratoValorizacionDet.EditFormLayoutProperties.vi
            //GridContratoValorizacionDet.Columns["CANTIDAD"].Visible = false;                        

            //PRESUPUESTO
            if (e.Column.FieldName == "PRESUPUESTO_PARCIAL")
            {
                decimal price = (decimal)e.GetListSourceFieldValue("PRECIO");
                decimal cantidadTotal = Convert.ToDecimal(e.GetListSourceFieldValue("CANTIDADTOTAL"));
                e.Value = (price * cantidadTotal).ToString("n2");
            }

            //ACUMULADO ANTERIOR
            if (e.Column.FieldName == "ACUMULADO_ANTERIOR_PARCIAL")
            {
                decimal price = (decimal)e.GetListSourceFieldValue("PRECIO");
                decimal cantidad = Convert.ToDecimal(e.GetListSourceFieldValue("ACUMULADO"));
                e.Value = (price * cantidad).ToString("n2");
            }

            if (e.Column.FieldName == "ACUMULADO_ANTERIOR_PORCENTAJE")
            {
                decimal acmulado = (decimal)e.GetListSourceFieldValue("ACUMULADO");
                decimal cantidadTotal = Convert.ToDecimal(e.GetListSourceFieldValue("CANTIDADTOTAL"));
                if (cantidadTotal > 0)
                    e.Value = ((acmulado / cantidadTotal) * 100).ToString("n2");
                else
                    e.Value = 0;
            }


            if (e.Column.FieldName == "TOTAL")
            {
                decimal price = (decimal)e.GetListSourceFieldValue("PRECIO");
                decimal cantidad = Convert.ToDecimal(e.GetListSourceFieldValue("CANTIDAD"));
                e.Value = (price * cantidad).ToString("n2");
            }

            //ACUMULADO TOTAL
            if (e.Column.FieldName == "ACUMULADO_TOTAL")
            {
                //e.NewValues["SEGUIMIENTO_CRONOGRAMA"].ToString().Length == 0 ? "null" : e.NewValues["SEGUIMIENTO_CRONOGRAMA"].ToString()
                //string acumulado = (e.GetListSourceFieldValue("ACUMULADO").ToString().Length == 0 ? "0" : e.GetListSourceFieldValue("ACUMULADO").ToString());
                decimal acumuladoTotal = (decimal)e.GetListSourceFieldValue("ACUMULADO");
                decimal cantidad = Convert.ToDecimal(e.GetListSourceFieldValue("CANTIDAD"));
                e.Value = (acumuladoTotal + cantidad).ToString("n2");
            }

            if (e.Column.FieldName == "ACUMULADO_TOTAL_PARCIAL")
            {
                decimal acumuladoTotal = (decimal)e.GetListSourceFieldValue("ACUMULADO");
                decimal cantidad = Convert.ToDecimal(e.GetListSourceFieldValue("CANTIDAD"));
                decimal price = (decimal)e.GetListSourceFieldValue("PRECIO");
                e.Value = ((acumuladoTotal + cantidad) * price).ToString("n2");
            }

            if (e.Column.FieldName == "ACUMULADO_TOTALPRECIO")
            {
                //e.NewValues["SEGUIMIENTO_CRONOGRAMA"].ToString().Length == 0 ? "null" : e.NewValues["SEGUIMIENTO_CRONOGRAMA"].ToString()
                string acumulado = (e.GetListSourceFieldValue("ACUMULADO").ToString().Length == 0 ? "0" : e.GetListSourceFieldValue("ACUMULADO").ToString());

                decimal price = (decimal)e.GetListSourceFieldValue("PRECIO");
                decimal acumulado1 = Convert.ToDecimal(acumulado);
                decimal cantidad = Convert.ToDecimal(e.GetListSourceFieldValue("CANTIDAD"));
                e.Value = ((acumulado1 + cantidad) * price).ToString("n2");
            }

            //SALDOS
            if (e.Column.FieldName == "SALDO_POR_EJECUTAR")
            {
                decimal acumuladoTotal = (decimal)e.GetListSourceFieldValue("ACUMULADO");
                decimal cantidad = Convert.ToDecimal(e.GetListSourceFieldValue("CANTIDAD"));
                decimal cantidadTotal = Convert.ToDecimal(e.GetListSourceFieldValue("CANTIDADTOTAL"));

                e.Value = (cantidadTotal - (acumuladoTotal + cantidad)).ToString("n2");
            }
            if (e.Column.FieldName == "SALDO_POR_EJECUTAR_VALORIZADO")
            {
                decimal acumuladoTotal = (decimal)e.GetListSourceFieldValue("ACUMULADO");
                decimal cantidad = Convert.ToDecimal(e.GetListSourceFieldValue("CANTIDAD"));
                decimal cantidadTotal = Convert.ToDecimal(e.GetListSourceFieldValue("CANTIDADTOTAL"));
                decimal price = (decimal)e.GetListSourceFieldValue("PRECIO");

                e.Value = ((cantidadTotal - (acumuladoTotal + cantidad)) * price).ToString("n2");
            }

            if (e.Column.FieldName == "ACUMULADO_TOTALPRESUPUESTO")
            {
                decimal price = (decimal)e.GetListSourceFieldValue("PRECIO");
                decimal cantidad = Convert.ToDecimal(e.GetListSourceFieldValue("CANTIDADTOTAL"));
                e.Value = (price * cantidad).ToString("n2");
            }


            if (e.Column.FieldName == "SALDOACUMULADO")
            {
                //e.NewValues["SEGUIMIENTO_CRONOGRAMA"].ToString().Length == 0 ? "null" : e.NewValues["SEGUIMIENTO_CRONOGRAMA"].ToString()
                string acumulado = (e.GetListSourceFieldValue("ACUMULADO").ToString().Length == 0 ? "0" : e.GetListSourceFieldValue("ACUMULADO").ToString());

                decimal acumulado1 = Convert.ToDecimal(acumulado);
                decimal cantidad = Convert.ToDecimal(e.GetListSourceFieldValue("CANTIDAD"));
                decimal cantidadtotal = Convert.ToDecimal(e.GetListSourceFieldValue("CANTIDADTOTAL"));
                if (cantidadtotal > 0)
                    e.Value = (((acumulado1 + cantidad) / cantidadtotal) * 100).ToString("n2");
                else
                    e.Value = 0;
            }
        }
        #endregion


        protected void GridContratoValorizacionDet_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            DataSet ds1 = new DataSet();
            //ds1 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyecto(pIdProyecto);

            decimal utilidad, gastos_generales, adelantoDirecto, adelantoMateriales, adelantoOtros, igv;
            string subTotal, igvTotal, sumTotal;

            //TRAER IGV DE LA BD            
            utilidad = 10;
            gastos_generales = 20;
            adelantoDirecto = 10;
            adelantoMateriales = 10;
            adelantoOtros = 10;
            igv = Convert.ToDecimal(0.18);
            ds1 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyecto(pIdProyecto);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                utilidad = Convert.ToDecimal(ds1.Tables[0].Rows[0]["PCUTILIDADES"].ToString());
                gastos_generales = Convert.ToDecimal(ds1.Tables[0].Rows[0]["PCGASTOS_GENERALES"].ToString());
                adelantoDirecto = Convert.ToDecimal(ds1.Tables[0].Rows[0]["PCADELANTODIRECTO"].ToString());
                adelantoMateriales = Convert.ToDecimal(ds1.Tables[0].Rows[0]["PCADELANTOMATERIALES"].ToString());
                adelantoOtros = Convert.ToDecimal(ds1.Tables[0].Rows[0]["PCADELANTOOTROS"].ToString());
            }


            if ((e.Item as ASPxSummaryItem).Tag == "1")
            {
                ASPxSummaryItem incomeSummary = (sender as ASPxGridView).TotalSummary["TOTAL"];
                //ASPxSummaryItem expenseSummary = (sender as ASPxGridView).TotalSummary["Expense"];
                Decimal income = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary));
                //Decimal expense = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(expenseSummary));				

                e.TotalValue = income * utilidad / 100;
            }
            else if ((e.Item as ASPxSummaryItem).Tag == "2")
            {
                ASPxSummaryItem incomeSummary = (sender as ASPxGridView).TotalSummary["TOTAL"];
                //ASPxSummaryItem expenseSummary = (sender as ASPxGridView).TotalSummary["Expense"];
                Decimal income = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary));
                //Decimal expense = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(expenseSummary));
                e.TotalValue = income * gastos_generales / 100;
            }
            else if ((e.Item as ASPxSummaryItem).Tag == "3")
            {
                ASPxSummaryItem incomeSummary = (sender as ASPxGridView).TotalSummary["TOTAL"];
                //ASPxSummaryItem expenseSummary = (sender as ASPxGridView).TotalSummary["Expense"];
                Decimal income = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary));
                //Decimal expense = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(expenseSummary));
                e.TotalValue = income + income * utilidad / 100 + income * gastos_generales / 100;
            }
            else if ((e.Item as ASPxSummaryItem).Tag == "4")
            {
                ASPxSummaryItem incomeSummary = (sender as ASPxGridView).TotalSummary["TOTAL"];
                //ASPxSummaryItem expenseSummary = (sender as ASPxGridView).TotalSummary["Expense"];
                Decimal income = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary));
                //Decimal expense = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(expenseSummary));
                Decimal sub = (income + income * utilidad / 100 + income * gastos_generales / 100);
                adelantoDirecto = Convert.ToDecimal((sub * adelantoDirecto / 100).ToString("n2"));
                e.TotalValue = adelantoDirecto;

            }
            else if ((e.Item as ASPxSummaryItem).Tag == "5")
            {
                ASPxSummaryItem incomeSummary = (sender as ASPxGridView).TotalSummary["TOTAL"];
                //ASPxSummaryItem expenseSummary = (sender as ASPxGridView).TotalSummary["Expense"];
                Decimal income = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary));
                //Decimal expense = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(expenseSummary));

                Decimal sub = (income + income * utilidad / 100 + income * gastos_generales / 100);

                adelantoMateriales = Convert.ToDecimal((sub * adelantoMateriales / 100).ToString("n2"));
                e.TotalValue = adelantoMateriales;

            }
            else if ((e.Item as ASPxSummaryItem).Tag == "6")
            {
                ASPxSummaryItem incomeSummary = (sender as ASPxGridView).TotalSummary["TOTAL"];
                //ASPxSummaryItem expenseSummary = (sender as ASPxGridView).TotalSummary["Expense"];
                Decimal income = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary));
                //Decimal expense = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(expenseSummary));

                Decimal sub = (income + income * utilidad / 100 + income * gastos_generales / 100);
                adelantoOtros = Convert.ToDecimal((sub * adelantoOtros / 100).ToString("n2"));
                e.TotalValue = adelantoOtros;

            }
            else if ((e.Item as ASPxSummaryItem).Tag == "7")
            {
                ASPxSummaryItem incomeSummary = (sender as ASPxGridView).TotalSummary["TOTAL"];
                Decimal income = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary));
                Decimal sub = (income + income * utilidad / 100 + income * gastos_generales / 100);

                adelantoDirecto = Convert.ToDecimal((sub * adelantoDirecto / 100).ToString("n2"));
                adelantoMateriales = Convert.ToDecimal((sub * adelantoMateriales / 100).ToString("n2"));
                adelantoOtros = Convert.ToDecimal((sub * adelantoOtros / 100).ToString("n2"));

                e.TotalValue = adelantoDirecto + adelantoMateriales + adelantoOtros;
            }
            else if ((e.Item as ASPxSummaryItem).Tag == "8")
            {
                ASPxSummaryItem incomeSummary = (sender as ASPxGridView).TotalSummary["TOTAL"];
                //ASPxSummaryItem expenseSummary = (sender as ASPxGridView).TotalSummary["Expense"];
                Decimal income = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary));
                //Decimal expense = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(expenseSummary));

                Decimal sub = (income + income * utilidad / 100 + income * gastos_generales / 100);

                e.TotalValue = sub - (sub * adelantoDirecto / 100 + sub * adelantoMateriales / 100 + sub * adelantoOtros / 100);
            }
            else if ((e.Item as ASPxSummaryItem).Tag == "9")
            {
                ASPxSummaryItem incomeSummary = (sender as ASPxGridView).TotalSummary["TOTAL"];
                //ASPxSummaryItem expenseSummary = (sender as ASPxGridView).TotalSummary["Expense"];
                //Decimal income = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary));
                //Decimal expense = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(expenseSummary));
                Decimal income = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary));
                //Decimal expense = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(expenseSummary));

                Decimal sub = (income + income * utilidad / 100 + income * gastos_generales / 100);
                e.TotalValue = (sub - (sub * adelantoDirecto / 100 + sub * adelantoMateriales / 100 + sub * adelantoOtros / 100)) * igv;
            }
            else if ((e.Item as ASPxSummaryItem).Tag == "10")
            {
                ASPxSummaryItem incomeSummary = (sender as ASPxGridView).TotalSummary["TOTAL"];
                //ASPxSummaryItem expenseSummary = (sender as ASPxGridView).TotalSummary["Expense"];
                //Decimal income = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary));
                //Decimal expense = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(expenseSummary));
                Decimal income = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary));
                //Decimal expense = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(expenseSummary));

                Decimal sub = (income + income * utilidad / 100 + income * gastos_generales / 100);
                e.TotalValue = (sub - (sub * adelantoDirecto / 100 + sub * adelantoMateriales / 100 + sub * adelantoOtros / 100)) * (1 + igv);
            }
            else if ((e.Item as ASPxSummaryItem).Tag == "15")
            {
                ASPxSummaryItem incomeSummary = (sender as ASPxGridView).TotalSummary["ACUMULADO_TOTALPRECIO"];
                ASPxSummaryItem incomeSummary1 = (sender as ASPxGridView).TotalSummary["ACUMULADO_TOTALPRESUPUESTO"];
                Decimal income = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary));
                Decimal income1 = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary1));


                //TOTAL VALORIZACIÓN
                ASPxSummaryItem incomeSummary3 = (sender as ASPxGridView).TotalSummary["TOTAL"];
                Decimal income3 = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary3));
                Decimal sub = (income3 + income3 * utilidad / 100 + income3 * gastos_generales / 100);
                //e.TotalValue = sub - (sub * adelantoDirecto / 100 + sub * adelantoMateriales / 100 + sub * adelantoOtros / 100);

                if (income1 > 0)
                {
                    string porcentaje_avance = ((income / income1) * 100).ToString("n2");
                    e.TotalValue = porcentaje_avance;

                    ASPxGridView detailGrid = (ASPxGridView)sender;
                    int IdValorizacion = (int)detailGrid.GetMasterRowKeyValue();

                    string[] parameters = { porcentaje_avance, sub.ToString() };
                    string LvCadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.UpdateRowPorcentajeAvance(parameters, IdValorizacion, "2");
                }
            }
        }


        protected void GridContratoValorizacionDet_SummaryDisplayText(object sender, ASPxGridViewSummaryDisplayTextEventArgs e)
        {

            DataSet ds1 = new DataSet();
            decimal utilidad, gastos_generales, adelantoDirecto, adelantoMateriales, adelantoOtros, igv;

            //TRAER IGV DE LA BD
            utilidad = 10;
            gastos_generales = 20;
            adelantoDirecto = 10;
            adelantoMateriales = 10;
            adelantoOtros = 10;
            igv = Convert.ToDecimal(0.18);
            ds1 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyecto(pIdProyecto);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                utilidad = Convert.ToDecimal(ds1.Tables[0].Rows[0]["PCUTILIDADES"].ToString());
                gastos_generales = Convert.ToDecimal(ds1.Tables[0].Rows[0]["PCGASTOS_GENERALES"].ToString());
                adelantoDirecto = Convert.ToDecimal(ds1.Tables[0].Rows[0]["PCADELANTODIRECTO"].ToString());
                adelantoMateriales = Convert.ToDecimal(ds1.Tables[0].Rows[0]["PCADELANTOMATERIALES"].ToString());
                adelantoOtros = Convert.ToDecimal(ds1.Tables[0].Rows[0]["PCADELANTOOTROS"].ToString());
            }

            if ((e.Item as ASPxSummaryItem).Tag == "1")
            {
                e.Text = string.Format("Utilidad (" + utilidad + "%) = {0:c}", Convert.ToDouble(e.Value));
            }
            else if ((e.Item as ASPxSummaryItem).Tag == "2")
            {
                e.Text = string.Format("G. Generales (" + gastos_generales + "%) = {0:c}", Convert.ToDouble(e.Value));
            }
            else if ((e.Item as ASPxSummaryItem).Tag == "9")
            {
                e.Text = string.Format("Igv (" + igv * 100 + "%) = {0:c}", Convert.ToDouble(e.Value));
            }
            else if ((e.Item as ASPxSummaryItem).Tag == "10")
            {
                e.Text = string.Format("Total a P. = {0:c}", Convert.ToDouble(e.Value));
            }
            else if ((e.Item as ASPxSummaryItem).Tag == "4")
            {
                e.Text = string.Format("Adelanto Dir. (" + adelantoDirecto + "%) = {0:c}", Convert.ToDouble(e.Value));
            }
            else if ((e.Item as ASPxSummaryItem).Tag == "5")
            {
                e.Text = string.Format("Adelanto Mat. (" + adelantoMateriales + "%) = {0:c}", Convert.ToDouble(e.Value));
            }
            else if ((e.Item as ASPxSummaryItem).Tag == "6")
            {
                e.Text = string.Format("Adelanto Otr. (" + adelantoOtros + "%) = {0:c}", Convert.ToDouble(e.Value));
            }

        }


        protected void GridContratoValorizacionDet_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {

            ASPxGridView GridContratoValorizacionDet = (ASPxGridView)sender;
            decimal cantidad = e.NewValues["CANTIDAD"] != null ? Convert.ToDecimal(e.NewValues["CANTIDAD"]) : 0;
            decimal saldo = e.OldValues["SALDO_OLD_"] != null ? Convert.ToDecimal(e.OldValues["SALDO_OLD_"]) : 0;
            if (cantidad > saldo)
            {
                AddError(e.Errors, GridContratoValorizacionDet.Columns["CANTIDAD"], "Cantidad, debe ser menor que CANTIDAD TOTAL .");
            }
            //if (Convert.ToDecimal(e.NewValues["AVANCE"]) > 100)
            //{
            //  AddError(e.Errors, GridProyectoProgramacion.Columns["AVANCE"], "Avance, No puede ser mayor al 100%.");
            //}

            if (string.IsNullOrEmpty(e.RowError) && e.Errors.Count > 0) e.RowError = "Por favor, corregir los errores.";

            //GridContratoValorizacionDet.Columns["SALDO_OLD"].Visible = false;*/
            //string cantidad = e.NewValues["CANTIDAD"].ToString();
            //string saldo_old = e.OldValues["SALDO_OLD_"].ToString();

        }

        void AddError(Dictionary<GridViewColumn, string> errors, GridViewColumn column, string errorText)
        {
            if (errors.ContainsKey(column)) return;
            errors[column] = errorText;
        }


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

        protected void Button3_Click(object sender, EventArgs e)
        {
            exporterValorizacionSup.Landscape = true;
            exporterValorizacionSup.RightMargin = 0;
            exporterValorizacionSup.LeftMargin = 0;
            exporterValorizacionSup.WritePdfToResponse();
        }

        protected void GridContratoValorizacionDet_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            if ((e.DataColumn.FieldName == "MEDIDA" || e.DataColumn.FieldName == "PAR_CANTIDAD" || e.DataColumn.FieldName == "CANTIDADTOTAL" || e.DataColumn.FieldName == "PRECIO" || e.DataColumn.FieldName == "PRESUPUESTO_PARCIAL") && Convert.ToInt32(e.GetValue("PRECIO")) == 0)
                e.Cell.Text = String.Empty;

            if ((e.DataColumn.FieldName == "ACUMULADO" || e.DataColumn.FieldName == "ACUMULADO_ANTERIOR_PARCIAL" || e.DataColumn.FieldName == "ACUMULADO_ANTERIOR_PORCENTAJE") && Convert.ToInt32(e.GetValue("PRECIO")) == 0)
                e.Cell.Text = String.Empty;

            if ((e.DataColumn.FieldName == "CANTIDAD" || e.DataColumn.FieldName == "TOTAL" || e.DataColumn.FieldName == "PORCENTAJE") && Convert.ToInt32(e.GetValue("PRECIO")) == 0)
                e.Cell.Text = String.Empty;


            if ((e.DataColumn.FieldName == "ACUMULADO_TOTAL" || e.DataColumn.FieldName == "METRADO" || e.DataColumn.FieldName == "ACUMULADO_TOTAL_PARCIAL" || e.DataColumn.FieldName == "SALDOACUMULADO") && Convert.ToInt32(e.GetValue("PRECIO")) == 0)
                e.Cell.Text = String.Empty;

            if ((e.DataColumn.FieldName == "SALDO_POR_EJECUTAR" || e.DataColumn.FieldName == "SALDO_POR_EJECUTAR_VALORIZADO" || e.DataColumn.FieldName == "SALDOACUMULADO") && Convert.ToInt32(e.GetValue("PRECIO")) == 0)
                e.Cell.Text = String.Empty;

            if ((e.DataColumn.FieldName == "APROBADO" || e.DataColumn.FieldName == "SALDO_OLD_") && Convert.ToInt32(e.GetValue("PRECIO")) == 0)
                e.Cell.Text = String.Empty;


            //e.Cell.BackColor = System.Drawing.Color.LightYellow;
            if (e.DataColumn.FieldName == "CANTIDADTOTAL" && Convert.ToInt32(e.GetValue("PRECIO")) > 0)
                e.Cell.BackColor = Color.FromArgb(239, 239, 237);

            if ((e.DataColumn.FieldName == "CANTIDAD" || e.DataColumn.FieldName == "SALDOACUMULADO") && Convert.ToInt32(e.GetValue("PRECIO")) > 0)
                e.Cell.BackColor = Color.FromArgb(208, 235, 251);

            //CANTIDAD METRADO Y AVANCE

            if (e.DataColumn.FieldName == "CANTIDADTOTAL" && Convert.ToInt32(e.GetValue("PRECIO")) == 0)
                e.Cell.BackColor = Color.FromArgb(144, 223, 203);

            if ((e.DataColumn.FieldName == "CANTIDAD" || e.DataColumn.FieldName == "SALDOACUMULADO") && Convert.ToInt32(e.GetValue("PRECIO")) == 0)
                e.Cell.BackColor = Color.FromArgb(144, 223, 203);

        }
    }
}