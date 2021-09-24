using DevExpress.Web;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace InfogesEmape.Modules.Forms.Seguimiento
{
	public partial class frmInfoGesGSOPresupuesto : System.Web.UI.Page
	{
        private string pIdOPeracion;
        private string pIdProyecto;
        private string pIdProyectoo;
        private Int32 pnContrato = 0;

		protected void Page_Load(object sender, EventArgs e)
		{            
            
            //Response.Redirect("~/Default.aspx");
            InfogesEmape.Modules.MasterPage m = (InfogesEmape.Modules.MasterPage)Page.Master;
			pIdOPeracion = "" + Request.Params["pOpera"];
			pIdProyecto = "" + Request.Params["pId"];
            pIdProyectoo = "" + Request.Params["pId"];
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
                        //TXTDATO.Text("123123");
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
            using (MemoryStream ms = new MemoryStream())
            {

                //PrintableComponentLink pcl = new PrintableComponentLink(new PrintingSystem());
                CompositeLink composLink = new CompositeLink(new PrintingSystem());

                //composLink.CreateMarginalHeaderArea += new CreateAreaEventHandler(composLink_CreateMarginalHeaderArea);

                PrintableComponentLink pcLink1 = new PrintableComponentLink(new PrintingSystem());
                PrintableComponentLink pcLink2 = new PrintableComponentLink(new PrintingSystem());

                pcLink1.Component = this.gridExporter01;
                pcLink2.Component = this.gridExporter;

                // Populate the collection of links in the composite link.
                // The order of operations corresponds to the document structure.
                //composLink.Links.Add(linkGrid1Report);
                composLink.Links.Add(pcLink1);
                composLink.BreakSpace = 100;
                composLink.Margins.Top = 30;
                //composLink.Links.Add(linkMainReport);
                //composLink.Links.Add(linkGrid2Report);
                composLink.Links.Add(pcLink2);

                //pcl.Component = gridExporter;

                composLink.Margins.Left = composLink.Margins.Right = 0;
                composLink.Margins.Top = 30;
                composLink.Landscape = true;
               
                composLink.CreateDocument(true);
                composLink.PrintingSystem.Document.AutoFitToPagesWidth = 1;


                /*pcLink2.Margins.Left = pcLink2.Margins.Right = 0;
                pcLink2.Margins.Top = 10;
                pcLink2.Landscape = true;
                pcLink2.CreateDocument(true);
                pcLink2.PrintingSystem.Document.AutoFitToPagesWidth = 1;*/

                PageHeaderFooter phf = composLink.PageHeaderFooter as PageHeaderFooter;
                phf.Header.Content.Clear();
                //phf.Header.Content.AddRange(new string[] { leftColumn, middleColumn, rightColumn });
                phf.Header.LineAlignment = BrickAlignment.Far;
                composLink.ExportToPdf(ms);
                WriteResponse(this.Response, ms.ToArray(), System.Net.Mime.DispositionTypeNames.Attachment.ToString());
            }
        }

  
        public static void WriteResponse(HttpResponse response, byte[] filearray, string type)
        {
            response.ClearContent();
            response.Buffer = true;
            response.Cache.SetCacheability(HttpCacheability.Private);
            response.ContentType = "application/pdf";
            ContentDisposition contentDisposition = new ContentDisposition();
            contentDisposition.FileName = "SaldoDotacao.pdf";
            contentDisposition.DispositionType = type;
            response.AddHeader("Content-Disposition", contentDisposition.ToString());
            response.BinaryWrite(filearray);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
            try
            {
                response.End();
            }
            catch (System.Threading.ThreadAbortException)
            {
            }
        }

        // Inserts a PageInfoBrick into the top margin to display the time.
        void composLink_CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
        {
            e.Graph.DrawPageInfo(PageInfo.DateTime, "{0:hhhh:mmmm:ssss}", Color.Black,
                new RectangleF(0, 0, 200, 50), BorderSide.None);
        }
        void linkGrid1Report_CreateDetailArea(object sender, CreateAreaEventArgs e)
        {
            TextBrick tb = new TextBrick();
            tb.Text = "Northwind Traders";
            tb.Font = new Font("Arial", 15);
            tb.Rect = new RectangleF(0, 0, 300, 25);
            tb.BorderWidth = 0;
            tb.BackColor = Color.Transparent;
            tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Near;
            e.Graph.DrawBrick(tb);
        }

        // Creates an interval between the grids and fills it with color.
        void linkMainReport_CreateDetailArea(object sender, CreateAreaEventArgs e)
        {

            TextBrick tb = new TextBrick();
            tb.Rect = new RectangleF(0, 0, e.Graph.ClientPageSize.Width, 50);
            tb.BackColor = Color.Gray;
            e.Graph.DrawBrick(tb);
        }

        // Creates a text header for the second grid.
        void linkGrid2Report_CreateDetailArea(object sender, CreateAreaEventArgs e)
        {
            TextBrick tb = new TextBrick();
            tb.Text = "Suppliers";
            tb.Font = new Font("Arial", 15);
            tb.Rect = new RectangleF(0, 0, 300, 25);
            tb.BorderWidth = 0;
            tb.BackColor = Color.Transparent;
            tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Near;
            e.Graph.DrawBrick(tb);
        }



        void WriteToResponse(string fileName, bool saveAsFile, string fileFormat, MemoryStream stream)
        {
            if (Page == null || Page.Response == null)
                return;
            string disposition = saveAsFile ? "attachment" : "inline";
            Page.Response.Clear();
            Page.Response.Buffer = false;            
            Page.Response.AppendHeader("Content-Type", string.Format("application/{0}", fileFormat));
            Page.Response.AppendHeader("Content-Transfer-Encoding", "binary");
            Page.Response.AppendHeader("Content-Disposition",
                string.Format("{0}; filename={1}.{2}", disposition, fileName, fileFormat));
            Page.Response.BinaryWrite(stream.GetBuffer());
            Page.Response.End();
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
                //e.Cell.Enabled = false;
                e.Cell.Text = String.Empty;                                
            }            
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
            if (catID <= 0)
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