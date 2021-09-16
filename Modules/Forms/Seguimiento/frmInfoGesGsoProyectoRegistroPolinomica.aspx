	<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmInfoGesGsoProyectoRegistroPolinomica.aspx.cs" Inherits="InfogesEmape.Modules.Forms.Seguimiento.frmInfoGesGsoProyectoRegistroPolinomica" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

			<dx:ASPxGridView ID="GridValorizacionPolinomica" runat="server" AutoGenerateColumns="False" OnLoad="GridValorizacionPolinomica_Load" KeyFieldName="VAP_FACTOR" OnRowUpdating="GridValorizacionPolinomica_RowUpdating" OnCustomUnboundColumnData="GridValorizacionPolinomica_CustomUnboundColumnData" OnCustomSummaryCalculate="GridValorizacionPolinomica_CustomSummaryCalculate" Theme="Office2010Blue">
				<Settings ShowTitlePanel="True" />
				<SettingsText Title="FÓRMULA POLINÓMICA" />
				<Columns>
					<dx:GridViewDataTextColumn Caption="N#" FieldName="VAP_ID" VisibleIndex="0" ShowInCustomizationForm="True">
						<EditFormSettings Visible="False" />
					</dx:GridViewDataTextColumn>
					<dx:GridViewDataTextColumn Caption="Descripcion" FieldName="POL_NOMBRE" VisibleIndex="2" ShowInCustomizationForm="True">
						<EditFormSettings Visible="False" />
					</dx:GridViewDataTextColumn>
					<dx:GridViewDataTextColumn Caption="Factor" FieldName="VAP_FACTOR" VisibleIndex="3" ShowInCustomizationForm="True">
						<EditFormSettings Visible="False" />
					</dx:GridViewDataTextColumn>
					<dx:GridViewDataTextColumn Caption="Valor Presupuesto" FieldName="VAP_INDICE_VALOR" VisibleIndex="4" ShowInCustomizationForm="True">
						<EditFormSettings Visible="False" />
					</dx:GridViewDataTextColumn>
					<dx:GridViewDataTextColumn Caption="Valor" FieldName="VAP_CANTIDAD" VisibleIndex="5" ShowInCustomizationForm="True">
					</dx:GridViewDataTextColumn>
					<dx:GridViewDataTextColumn Caption="Indice" FieldName="POL_INDICE" ShowInCustomizationForm="True" VisibleIndex="1">
						<EditFormSettings Visible="False" />
					</dx:GridViewDataTextColumn>
					<dx:GridViewDataTextColumn Caption="Total" FieldName="VAP_TOTAL" VisibleIndex="6">
						<EditFormSettings Visible="False" />
					</dx:GridViewDataTextColumn>
				</Columns>
					<Settings VerticalScrollableHeight="594" />
					<SettingsEditing Mode="Batch" />
					<Settings ShowFooter="True" />
					<TotalSummary>                        
                        <dx:ASPxSummaryItem FieldName="VAP_TOTAL" ShowInColumn="VAP_TOTAL"  SummaryType="Sum" DisplayFormat="Factor K = {0:n3}"/>																		
						<dx:ASPxSummaryItem FieldName="VAP_TOTAL" ShowInColumn="VAP_TOTAL"  SummaryType="Custom" DisplayFormat="Factor K = {0:c}" Tag="1" Visible="False"/>
                    </TotalSummary>
			</dx:ASPxGridView>

        </div>
    </form>
</body>
</html>
