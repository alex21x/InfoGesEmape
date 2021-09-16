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
	public partial class frmInfoGesGSOPresupuesto : System.Web.UI.Page
	{
        private string pIdOPeracion;
        private string pIdProyecto;
        private Int32 pnContrato = 0;

		protected void Page_Load(object sender, EventArgs e)
		{            
            
            //Response.Redirect("~/Default.aspx");
            InfogesEmape.Modules.MasterPage m = (InfogesEmape.Modules.MasterPage)Page.Master;
			pIdOPeracion = "" + Request.Params["pOpera"];
			pIdProyecto = "" + Request.Params["pId"];
			Session["pIdProyecto"] = pIdProyecto;

			if (pIdProyecto != null)
            {
                DataSet ds1 = new DataSet();

                ds1 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyecto(pIdProyecto);
                if (ds1.Tables[0].Rows.Count > 0)
                {
					//VISTA DE SUPERVISOR 09-08-2021
					DataSet ds4 = new DataSet();
					ds4 = Code.Logic.Forms.Input.GSO_Situacion.SearchCoordinadorContrato((string)(Session["IdDni"]), ds1.Tables[0].Rows[0]["ACT_PROY"].ToString());
					if (Convert.ToString(ds4.Tables[0].Rows[0]["ROLE_ID"]) == "8")
					{
						Response.Redirect("frmInfoGesGsoProyectoRegistroCoordinador.aspx?pOpera=edit&amp&pId=" + pIdProyecto + "");
					}

					pIdProyecto = ds1.Tables[0].Rows[0]["IDPROYECTO"].ToString();                    
                    this.TXTUTILIDAD.Text = ds1.Tables[0].Rows[0]["PCUTILIDADES"].ToString();
                    this.TxtGastosGenerales.Text = ds1.Tables[0].Rows[0]["PCGASTOS_GENERALES"].ToString();
					this.TXTGASTOSOTROS.Text = ds1.Tables[0].Rows[0]["PCGASTOS_OTROS"].ToString();
					this.TXTADELANTODIRECTO.Text = ds1.Tables[0].Rows[0]["PCADELANTODIRECTO"].ToString();
                    this.TXTADELANTOMATERIALES.Text = ds1.Tables[0].Rows[0]["PCADELANTOMATERIALES"].ToString();
                    this.TXTADELANTOOTROS.Text = ds1.Tables[0].Rows[0]["PCADELANTOOTROS"].ToString();                
                }
                else
                {
                    pIdProyecto = "0";
                    pIdOPeracion = "New";
                }               
            }
            GridContratoPartida.SettingsBehavior.AutoExpandAllGroups = true;           
            PopulateGridFormatConditions();
        }


        #region ProyectoContrato

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
        #endregion


        /*CAMBIO						FECHA			AUTOR
		SELECT	CONTRATO PARTIDA		21-06-2021	    ALEXANDER FERNÁNDEZ 21-06-2021*/
        #region ContratoPartida
        #region OnLoadContratoPartida
        protected void OnLoadContratoPartida(object sender, EventArgs e)
        {
            this.SearchContratoPartida();
            //SearchContratoById();
        }
        #endregion

        #region SearchContratoPartida
        private void SearchContratoPartida()
        {
            //if (pnContrato != 0)
            //{
                DataSet ds4 = new DataSet();
                string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();
                ds4 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByContratoPartida(IdContrato);
                
                GridContratoPartida.KeyFieldName = "IDCONTRATOPARTIDA";
                GridContratoPartida.DataSource = ds4.Tables[0];
                GridContratoPartida.DataBind();
                Calcular();
            //}
        }
        #endregion

        /*CAMBIO						FECHA			AUTOR
		UPDATE CONTRATO PARTIDA			22-06-2021	    ALEXANDER FERNÁNDEZ 22-06-2021*/
        #region OnRowUpdatingContratoPartida
        protected void OnRowUpdatingContratoPartida(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string pAprobado;
            if (e.NewValues["APROBADO"] == null)
                pAprobado = "0";
            else
                pAprobado = (e.NewValues["APROBADO"].ToString().Length == 0 ? "null" : e.NewValues["APROBADO"].ToString());

            string Id = e.Keys["IDCONTRATOPARTIDA"].ToString();
            string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();

            string[] parameters = { IdContrato, pAprobado };

            string LvCadena = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.UpdateRowContratoPartidaAprobado(parameters, Id);
            GridContratoPartida.CancelEdit();
            e.Cancel = true;
            this.SearchContratoPartida();
        }
        #endregion
        #endregion

        protected void Calcular()
        {
            decimal gastos_generales_total, sub, tot, igv_total;
            decimal gastos_generales = Convert.ToDecimal(TxtGastosGenerales.Text);
            decimal subtotal = Convert.ToDecimal(LBLSUBTOTAL.Text);

            gastos_generales_total = subtotal * gastos_generales / 100;
			//LBLGASTOSGENERALES.Text = gastos_generales_total.ToString("0.##");

			decimal gastos_otros_total;
			decimal gastos_otros = Convert.ToDecimal(TXTGASTOSOTROS.Text);
			gastos_otros_total = subtotal * gastos_otros / 100;

			decimal utilidad_total;
            decimal utilidad = Convert.ToDecimal(TXTUTILIDAD.Text);

            utilidad_total = subtotal * utilidad / 100;
            //LBLUTILIDAD.Text = utilidad_total.ToString("0.##");


            sub = subtotal + utilidad_total + gastos_generales_total;
            igv_total = sub * 18 / 100;
            LBLIGV.Text = igv_total.ToString("0.##");

            tot = sub + igv_total;
            LBLSUB.Text = sub.ToString("0.##");
            LBLTOTAL.Text = tot.ToString("0.##");


            decimal adelantoDirecto_total;
            decimal adelantoDirecto = Convert.ToDecimal(TXTADELANTODIRECTO.Text);

            adelantoDirecto_total = tot * adelantoDirecto / 100;
            //LBLADELANTODIRECTO.Text = adelantoDirecto_total.ToString("0.##");

            decimal adelantoMateriales_total;
            decimal adelantoMateriales = Convert.ToDecimal(TXTADELANTOMATERIALES.Text);

            adelantoMateriales_total = tot * adelantoMateriales / 100;
            //LBLADELANTOMATERIALES.Text = adelantoMateriales_total.ToString("0.##");

            decimal adelantoOtros_total;
            decimal adelantoOtros = Convert.ToDecimal(TXTADELANTOOTROS.Text);

            adelantoOtros_total = tot * adelantoOtros / 100;
            //LBLADELANTOOTROS.Text = adelantoOtros_total.ToString("0.##");

            //UPDATE % UTILIDADES, GASTOS GENERALES
            //string IdContrato = GridProyectoContrato.GetRowValues(GridProyectoContrato.FocusedRowIndex, "IDCONTRATO").ToString();
            string[] parameters = { utilidad.ToString(), gastos_generales.ToString(), gastos_otros.ToString(), adelantoDirecto.ToString(), adelantoMateriales.ToString(), adelantoOtros.ToString() };
            Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.UpdateRowProyectoContrato02(parameters, pIdProyecto);
            //SearchContratoById();
        }

        /*CAMBIO							FECHA			AUTOR
        SUM TOTAL CONTRATO PARTIDA			22-06-2021	    ALEXANDER FERNÁNDEZ 22-06-2021*/
        protected void GridContratoPartida_CustomUnboundColumnData(object sender, ASPxGridViewColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "TOTAL")
            {                
				decimal price = (decimal)e.GetListSourceFieldValue("PAR_PRECIO");
				decimal cantidad = (decimal)(e.GetListSourceFieldValue("PAR_CANTIDAD"));
				e.Value = (price * cantidad).ToString("n2");
			}
        }

		int totalSum;
		protected void GridContratoPartida_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            DataSet ds1 = new DataSet();
            //ds1 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyecto(pIdProyecto);

            decimal utilidad, gastos_generales, adelantoDirecto, gastos_otros, adelantoMateriales, adelantoOtros, igv;

            //TRAER IGV DE LA BD
            utilidad = Convert.ToDecimal(TXTUTILIDAD.Text);
            gastos_generales = Convert.ToDecimal(TxtGastosGenerales.Text);
			gastos_otros = Convert.ToDecimal(TXTGASTOSOTROS.Text);
			adelantoDirecto = Convert.ToDecimal(TXTADELANTODIRECTO.Text);
            adelantoMateriales = Convert.ToDecimal(TXTADELANTOMATERIALES.Text);
			adelantoOtros = Convert.ToDecimal(TXTADELANTOOTROS.Text);
			igv = Convert.ToDecimal(0.18);
            ds1 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyecto(pIdProyecto);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                utilidad = Convert.ToDecimal(ds1.Tables[0].Rows[0]["PCUTILIDADES"].ToString());
                gastos_generales = Convert.ToDecimal(ds1.Tables[0].Rows[0]["PCGASTOS_GENERALES"].ToString());
				gastos_otros = Convert.ToDecimal(ds1.Tables[0].Rows[0]["PCGASTOS_OTROS"].ToString());
				adelantoDirecto = Convert.ToDecimal(ds1.Tables[0].Rows[0]["PCADELANTODIRECTO"].ToString());
                adelantoMateriales = Convert.ToDecimal(ds1.Tables[0].Rows[0]["PCADELANTOMATERIALES"].ToString());
				adelantoOtros = Convert.ToDecimal(ds1.Tables[0].Rows[0]["PCADELANTOOTROS"].ToString());				
			}

			if ((e.Item as ASPxSummaryItem).Tag == "2")
			{
				ASPxSummaryItem incomeSummary = (sender as ASPxGridView).TotalSummary["TOTAL"];
				//ASPxSummaryItem expenseSummary = (sender as ASPxGridView).TotalSummary["Expense"];
				Decimal income = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary));
				//Decimal expense = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(expenseSummary));				
				LBLSUBTOTAL.Text = income.ToString();
				e.TotalValue = income * utilidad / 100;
			}
			else if ((e.Item as ASPxSummaryItem).Tag == "1")
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
				e.TotalValue = income * gastos_otros / 100;
			}
			else if ((e.Item as ASPxSummaryItem).Tag == "4")
			{
				ASPxSummaryItem incomeSummary = (sender as ASPxGridView).TotalSummary["TOTAL"];
				//ASPxSummaryItem expenseSummary = (sender as ASPxGridView).TotalSummary["Expense"];
				Decimal income = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary));
				//Decimal expense = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(expenseSummary));
				e.TotalValue = income + income * utilidad / 100 + income * gastos_generales / 100 + income * gastos_otros / 100;
			}
			else if ((e.Item as ASPxSummaryItem).Tag == "5")
			{
				ASPxSummaryItem incomeSummary = (sender as ASPxGridView).TotalSummary["TOTAL"];
				//ASPxSummaryItem expenseSummary = (sender as ASPxGridView).TotalSummary["Expense"];
				Decimal income = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary));
				//Decimal expense = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(expenseSummary));
				e.TotalValue = (income + income * utilidad / 100 + income * gastos_generales / 100 + income * gastos_otros / 100) * igv;
			}
			else if ((e.Item as ASPxSummaryItem).Tag == "6")
			{
				ASPxSummaryItem incomeSummary = (sender as ASPxGridView).TotalSummary["TOTAL"];
				//ASPxSummaryItem expenseSummary = (sender as ASPxGridView).TotalSummary["Expense"];
				Decimal income = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary));
				//Decimal expense = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(expenseSummary));
				e.TotalValue = (income + income * utilidad / 100 + income * gastos_generales / 100 + income * gastos_otros / 100) * (1 + igv);
			}
			else if ((e.Item as ASPxSummaryItem).Tag == "7")
			{
				ASPxSummaryItem incomeSummary = (sender as ASPxGridView).TotalSummary["TOTAL"];
				//ASPxSummaryItem expenseSummary = (sender as ASPxGridView).TotalSummary["Expense"];
				Decimal income = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary));
				//Decimal expense = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(expenseSummary));

				Decimal sub = (income + income * utilidad / 100 + income * gastos_generales / 100 + income * gastos_otros / 100) * (1 + igv);

				e.TotalValue = sub - sub * adelantoDirecto / 100 - sub * adelantoMateriales / 100;
			}
			else
			{


				//DevExpress.Web.ASPxGridView.ASPxSummaryItem item = e.Item as DevExpress.Web.ASPxGridView.ASPxSummaryItem;			
				ASPxSummaryItem item = (sender as ASPxGridView).TotalSummary["APROBADO"];
				if (item.FieldName == "APROBADO")
				{
					// start  
					if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
						totalSum = 0;
					// Calculation.  
					if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
						if (!Convert.ToBoolean(e.FieldValue))
							totalSum++;
					// Finalization.  
					if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
						e.TotalValue = totalSum;

					if (totalSum == 0)
					{
						e.TotalValue = "<a id='LinkButton1'  href='frmInfoGesGsoProyectoRegistroCoordinador.aspx?pOpera=edit&amp;pId=" + Session["pIdProyecto"] + "'>IR A VALORIZACIÓN</a>";
					}
					else
					{
						e.TotalValue = "VALIDAR TODOS LOS PRECIOS Y CANTIDADES";
					}

				}				
			}
		}

        protected void GridContratoPartida_SummaryDisplayText(object sender, ASPxGridViewSummaryDisplayTextEventArgs e)
        {

            DataSet ds1 = new DataSet();
            //ds1 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyecto(pIdProyecto);
            decimal utilidad, gastos_generales, gastos_otros, igv;

            //TRAER IGV DE LA BD
            utilidad = Convert.ToDecimal(TXTUTILIDAD.Text);
            gastos_generales = Convert.ToDecimal(TxtGastosGenerales.Text);
			gastos_otros = Convert.ToDecimal(TXTGASTOSOTROS.Text);
			igv = Convert.ToDecimal(0.18);
            ds1 = Code.Logic.Forms.Seguimiento.GsoProyectoRegistro.SearchByProyecto(pIdProyecto);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                utilidad = Convert.ToDecimal(ds1.Tables[0].Rows[0]["PCUTILIDADES"].ToString());
                gastos_generales = Convert.ToDecimal(ds1.Tables[0].Rows[0]["PCGASTOS_GENERALES"].ToString());
				gastos_otros = Convert.ToDecimal(ds1.Tables[0].Rows[0]["PCGASTOS_OTROS"].ToString());
			}

            if ((e.Item as ASPxSummaryItem).Tag == "2")
            {
                e.Text = string.Format("Utilidad (" + utilidad + "%) = {0:c}", Convert.ToDecimal(e.Value));
            }
            else if ((e.Item as ASPxSummaryItem).Tag == "1")
            {
                e.Text = string.Format("G. Generales (" + gastos_generales + "%) = {0:c}", Convert.ToDecimal(e.Value));
            }
			else if ((e.Item as ASPxSummaryItem).Tag == "3")
			{
				e.Text = string.Format("G. Otros (" + gastos_otros + "%) = {0:c}", Convert.ToDecimal(e.Value));
			}
			else if ((e.Item as ASPxSummaryItem).Tag == "4")
            {
                e.Text = string.Format("Igv (" + igv * 100 + "%) = {0:c}", Convert.ToDecimal(e.Value));
            }
        }

        /*CAMBIO						        FECHA			AUTOR
		UPDATE % UTILIDADES, GASTOS GENERALES 	01-07-2021	    ALEXANDER FERNÁNDEZ 01-07-2021*/
        protected void TxtGastosGenerales_TextChanged(object sender, EventArgs e)
        {
            Calcular();
            this.SearchContratoPartida();
        }
		protected void TXTGASTOSOTROS_TextChanged(object sender, EventArgs e)
		{
			Calcular();
			this.SearchContratoPartida();
		}
		protected void TXTUTILIDAD_TextChanged(object sender, EventArgs e)
        {
            decimal total;
            decimal utilidad = Convert.ToDecimal(TXTUTILIDAD.Text);
            decimal subtotal = Convert.ToDecimal(LBLSUBTOTAL.Text);

            total = subtotal * utilidad / 100;
            //UTILIDAD.Text = total.ToString();
        }
        protected void TXTADELANTOMATERIALES_TextChanged(object sender, EventArgs e)
        {
            Calcular();
            this.SearchContratoPartida();
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            gridExporter.Landscape = true;
            gridExporter.RightMargin = 0;
            gridExporter.LeftMargin = 0;
            gridExporter.WritePdfToResponse();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            gridExporter.WriteXlsxToResponse();
        }


        int contador = 0;
        protected void APROBADO_Init(object sender, EventArgs e)
        {
            CheckBox check = sender as CheckBox;
            GridViewDataItemTemplateContainer gridContainer = check.NamingContainer as GridViewDataItemTemplateContainer;

            if (contador > 0)
            {
                check.Enabled = false;
                contador++;
            }
            else
            {
                contador++;
            }
        }
        protected void APROBADO_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox check = sender as CheckBox;
            GridViewDataItemTemplateContainer gridContainer = check.NamingContainer as GridViewDataItemTemplateContainer;

        }


        protected void GridContratoPartida_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            if (!object.Equals(e.RowType, GridViewRowType.Data)) return;
            //bool hasError = string.IsNullOrEmpty(e.GetValue("SEGUIMIENTO_FECHA").ToString());
            string metrado = e.GetValue("PAR_CANTIDAD").ToString();
            if (metrado == "0.00")
            {
                e.Row.BackColor = Color.FromArgb(144, 223, 203);
                //e.Row.BackColor = System.Drawing.Color.Red;
            }            
        }

        protected void GridContratoPartida_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {            
             if (e.DataColumn.FieldName == "PAR_CANTIDAD" && Convert.ToInt32(e.CellValue) == 0)
                 e.Cell.Text = String.Empty;

            if (e.DataColumn.FieldName == "PAR_PRECIO" && Convert.ToInt32(e.CellValue) == 0)
                e.Cell.Text = String.Empty;

            if (e.DataColumn.FieldName == "TOTAL" && Convert.ToString(e.CellValue) == "0.00")
                e.Cell.Text = String.Empty;

            if (Convert.ToInt32(e.GetValue("PAR_CANTIDAD")) == 0 && e.DataColumn.FieldName == "APROBADO") {
                //e.DataColumn.ReadOnly = true;
                //GridContratoPartida.Columns["APROBADO"].Visible = false;

                //DataColumn
                e.Cell.Text = String.Empty;                                
            }            
        }



        protected void PopulateGridFormatConditions()
        {
            //const string IconSetSpriteResourceName = "DevExpress.Web.Css.FCISprite.css";

            //ASPxGridviewProyecto.FormatConditions.Clear();


            //var condition1 = new GridViewFormatConditionHighlight
            //{
            //    Rule = GridConditionRule.GreaterOrEqual,
            //    Value1 = 50,
            //    FieldName = "AVANCE"
            //};
            //condition1.Format = GridConditionHighlightFormat.Custom;
            //condition1.CellStyle.CssClass = "dxFCRule dxWeb_fcIcons_Arrows5_4";
            //ASPxGridviewProyecto.FormatConditions.Add(condition1);



            //var condition2 = new GridViewFormatConditionHighlight { Rule = GridConditionRule.Between, Value1 = 20, Value2 = 50, FieldName = "AVANCE" };
            //condition2.Format = GridConditionHighlightFormat.Custom;
            //condition2.CellStyle.CssClass = "dxFCRule dxWeb_fcIcons_Arrows5_3";
            //ASPxGridviewProyecto.FormatConditions.Add(condition2);

            //var condition3 = new GridViewFormatConditionHighlight { Rule = GridConditionRule.Less, Value1 = 20, FieldName = "AVANCE" };
            //condition3.Format = GridConditionHighlightFormat.Custom;
            //condition3.CellStyle.CssClass = "dxFCRule dxWeb_fcIcons_Arrows5_5";
            //ASPxGridviewProyecto.FormatConditions.Add(condition3);

            ////var condition3 = new GridViewFormatConditionHighlight { Rule = GridConditionRule.Less, Value1 = 20, FieldName = "UnitsInStock" };
            ////condition3.Format = GridConditionHighlightFormat.Custom;
            ////condition3.CellStyle.CssClass = "dxFCRule dxWeb_fcIcons_Arrows5_5";
            ////ASPxGridviewProyecto.FormatConditions.Add(condition3);

            ////ResourceManager.RegisterCssResource(Page, typeof(ASPxWebControl), IconSetSpriteResourceName);
            ////ResourceManager.RegisterCssResource(Page, typeof(ASPxWebControl), IconSetSpriteResourceName);

            /*GridViewFormatConditionIconSet Rule = new GridViewFormatConditionIconSet();
            Rule.FieldName = "SALDO";
            Rule.MinimumValue = 0;
            Rule.MaximumValue = 20000000;
            Rule.Format = GridConditionIconSetFormat.Ratings5;
            GridContratoPartida.FormatConditions.Add(Rule);*/



            /*var condition3 = new GridViewFormatConditionHighlight { Rule = GridConditionRule.Less, Value1 = 0, FieldName = "PAR_CANTIDAD" };
            condition3.Format = GridConditionHighlightFormat.Custom;
            condition3.CellStyle.CssClass = "dxFCRule dxWeb_fcIcons_Arrows5_5";
            GridContratoPartida.FormatConditions.Add(condition3);*/

            /*GridViewFormatConditionIconSet Rule1 = new GridViewFormatConditionIconSet();            
            Rule1.FieldName = "PAR_CANTIDAD";

                       
            //Rule1.MinimumValue = 0;
            Rule1.MaximumValue = 0;
            Rule1.Format = GridConditionIconSetFormat.Arrows4Colored;
            GridContratoPartida.FormatConditions.Add(Rule1);*/

            //CardViewFormatConditionIconSet Format4 = new CardViewFormatConditionIconSet();
            //Format4.FieldName = "SALDO";
            //Format4.Format = GridConditionIconSetFormat.Arrows3Colored;
            //Format4.MinimumValue = 0;
            //Format4.MaximumValue = 2000000000;
            //ASPxGridviewProyecto.FormatConditions.Add(Format4);

        }

        protected void GridContratoPartida_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
        {
            int catID = Convert.ToInt32(GridContratoPartida.GetRowValues(e.VisibleIndex, "PAR_CANTIDAD"));
            /*if (catID > 0)
            {
                e.Row.Enabled = false;
                e.Row.ForeColor = System.Drawing.Color.Red;
            }*/
            /*string Status = (e.GetValue("PAR_CANTIDAD")).ToString();*/
            if (catID == 0)
            {
                foreach (var cell in e.Row.Cells)
                {
                    if (cell.GetType() == typeof(DevExpress.Web.Rendering.GridViewTableDataCell))
                    {
                        DevExpress.Web.Rendering.GridViewTableDataCell cel = (DevExpress.Web.Rendering.GridViewTableDataCell)cell;
                        cel.Attributes.Add("onclick", "event.cancelBubble = true");
                        //cel.Attributes.Add("style", "color:red");
                    }
                }
            }
        }
    }
}