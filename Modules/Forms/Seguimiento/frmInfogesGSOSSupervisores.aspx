<%@ Page Language="C#"  MasterPageFile="~/Modules/MasterPage.Master" AutoEventWireup="true" CodeBehind="frmInfogesGSOSSupervisores.aspx.cs" Inherits="InfogesEmape.Modules.Forms.Seguimiento.frmInfogesGSOSSupervisores" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">                                                 
     <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" AutoPostBack="true"
            ActiveTabIndex="0" Height="300%" TabSpacing="3px"  Font-Size="X-Small" 
            Width="100%">
	        <ActiveTabStyle Font-Bold="True" Font-Size="Small">
	        </ActiveTabStyle>                        
	        <TabPages >   
		        <dx:TabPage Text="REGISTRO DE PROYECTO.">
			        <ContentCollection>
				        <dx:ContentControl ID="ContentControl13" runat="server">	
<table>
   <tr>
     <td>
<dx:ASPxGridView ID="GridProyectoContrato" runat="server"  Width="100%"  Visible="true" KeyFieldName="IDCONTRATO"
    OnLoad="OnLoadProyectoContrato" Theme="Office2010Blue" >
    <Columns> 
    <dx:GridViewDataTextColumn FieldName="CONTRATO_NUMERO" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="80px"
    Caption="NÚMERO CONTRATO" VisibleIndex="1" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  >
<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>

<CellStyle HorizontalAlign="Right"></CellStyle>
    </dx:GridViewDataTextColumn> 
    <dx:GridViewBandColumn  Caption="EMPRESA"  VisibleIndex="2" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" >
<HeaderStyle HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>
    <Columns>
    <dx:GridViewDataTextColumn FieldName="RUC" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="80px"
    Caption="RUC" VisibleIndex="2" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  >
<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>

<CellStyle HorizontalAlign="Right"></CellStyle>
    </dx:GridViewDataTextColumn> 
    <dx:GridViewDataTextColumn FieldName="EMPRESA" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="680px"
    Caption="NOMBRE" VisibleIndex="3" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  >
<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>

<CellStyle HorizontalAlign="Right"></CellStyle>
    </dx:GridViewDataTextColumn> 
    </Columns>
    </dx:GridViewBandColumn>
    <dx:GridViewBandColumn Caption="CONTRATO"  VisibleIndex="3" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" >
<HeaderStyle HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>
    <Columns>
    <dx:GridViewDataDateColumn FieldName="FECHA_CONTRATO" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="100px"
    Caption="FECHA CONTRATO" VisibleIndex="4" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>

<CellStyle HorizontalAlign="Right"></CellStyle>
    </dx:GridViewDataDateColumn>
    <dx:GridViewDataTextColumn FieldName="MONTO_OBRA" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="100px"
    Caption="IMPORTE OBRA" VisibleIndex="5" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>

<CellStyle HorizontalAlign="Right"></CellStyle>
    </dx:GridViewDataTextColumn>
    <dx:GridViewDataTextColumn FieldName="PLAZO_EJECUCION_OBRA" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="100px"
    Caption="PLAZO EJECUCIÓN" VisibleIndex="6" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>

<CellStyle HorizontalAlign="Right"></CellStyle>
    </dx:GridViewDataTextColumn>
    <dx:GridViewBandColumn Caption="INICIO DE OBRA"  VisibleIndex="4" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" >
<HeaderStyle HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>
    <Columns>
    <dx:GridViewDataDateColumn FieldName="FECHA_INICIO_OBRA" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="100px"
    Caption="FECHA INI. OBR." VisibleIndex="7" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>

<CellStyle HorizontalAlign="Right"></CellStyle>
    </dx:GridViewDataDateColumn>
    <dx:GridViewDataDateColumn FieldName="FECHA_INICIO_OBRA_MAXIMO" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="100px"
    Caption="FECHA INI. OBR. MAX." VisibleIndex="8" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>

<CellStyle HorizontalAlign="Right"></CellStyle>
    </dx:GridViewDataDateColumn>
    </Columns>
    </dx:GridViewBandColumn>
    </Columns>
    </dx:GridViewBandColumn>
    <dx:GridViewBandColumn   Caption="ENTREGA DE TERRENO"  VisibleIndex="4" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  HeaderStyle-Wrap="True">
<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>
    <Columns>
    <dx:GridViewDataDateColumn FieldName="FECHA_ENTREGA_TERRENO" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="100px"
    Caption="FECHA ENT. TERRE." VisibleIndex="15" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>

<CellStyle HorizontalAlign="Right"></CellStyle>
    </dx:GridViewDataDateColumn>
    <dx:GridViewDataDateColumn   visible="false" FieldName="FECHA_ENTREGA_TERRENO_LIMITE" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="100px"
    Caption="FECHA ENT. TERR. LIM." VisibleIndex="16" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>

<CellStyle HorizontalAlign="Right"></CellStyle>
    </dx:GridViewDataDateColumn>
    <dx:GridViewDataComboBoxColumn Caption="ESTADO CONTRATO" FieldName="DESCRIPCION_ESTADO_CONTRATO" VisibleIndex="17" HeaderStyle-HorizontalAlign="Center"  Width="100px"
            Settings-AllowSort="False" Settings-AllowDragDrop="False" Settings-FilterMode="Value" EditFormSettings-Visible="True">
        <PropertiesComboBox TextField="DESCRIPCION_ESTADO_CONTRATO" ValueField="IDESTADO_CONTRATO" ></PropertiesComboBox>

<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<EditFormSettings Visible="True"></EditFormSettings>

        <HeaderStyle HorizontalAlign="Center" />
    </dx:GridViewDataComboBoxColumn>
    </Columns>
    </dx:GridViewBandColumn>
    </Columns>
    <SettingsBehavior AllowFocusedRow="True" />
    <SettingsEditing Mode="PopupEditForm" EditFormColumnCount="2" />
    </dx:ASPxGridView>

		 </td></tr>
	<tr><td><br /><asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Export V.Sup PDF" CssClass="btn btn-success btn-xs" /><dx:ASPxGridViewExporter ID="exporterValorizacionSup" runat="server" GridViewID="GridProyectoContratoSup" Landscape="True" MaxColumnWidth="100" PaperKind="A3">
        <Styles>
            <Cell Font-Size="Smaller">
            </Cell>
        </Styles>
    </dx:ASPxGridViewExporter><br /><br /><br />
<dx:ASPxGridView ID="GridProyectoContratoSup" runat="server" KeyFieldName="IDCONTRATOSEGUIMIENTO" OnLoad="OnloadProyectoContratoSup" Visible="true" Width="100%" AutoGenerateColumns="False" OnHtmlCommandCellPrepared="comando" Theme="Office2010Blue" OnRowUpdating="GridContratoSupValorizacionDet_RowUpdating">
		<Columns>
			<dx:GridViewCommandColumn VisibleIndex="0" Width="50px" />			
			<dx:GridViewDataTextColumn Caption="N#" CellStyle-HorizontalAlign="Right" EditFormSettings-Visible="False" FieldName="SEGUIMIENTO_CRONOGRAMA" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True" PropertiesTextEdit-DisplayFormatString="##" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False" VisibleIndex="1" Width="50px">
				<PropertiesTextEdit DisplayFormatString="##"></PropertiesTextEdit>
				<Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
				<EditFormSettings Visible="True" />
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
				<CellStyle HorizontalAlign="Right">
				</CellStyle>
			</dx:GridViewDataTextColumn>
			<dx:GridViewDataDateColumn Caption="FECHA" CellStyle-HorizontalAlign="Right" FieldName="SEGUIMIENTO_FECHA" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False" VisibleIndex="2" Width="60px">
				<Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
				<CellStyle HorizontalAlign="Right">
				</CellStyle>
			</dx:GridViewDataDateColumn>
			<dx:GridViewDataTextColumn Caption="%" CellStyle-HorizontalAlign="Right" FieldName="AVANCE" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True" PropertiesTextEdit-DisplayFormatString="{0}%" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False" VisibleIndex="3" Width="60px">
				<PropertiesTextEdit DisplayFormatString="{0}%"></PropertiesTextEdit>
				<Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
				<EditFormSettings Visible="False" />
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
				<CellStyle HorizontalAlign="Right">
				</CellStyle>
			</dx:GridViewDataTextColumn>
			<dx:GridViewDataCheckColumn Caption="APROBADO" FieldName="APROBADO" VisibleIndex="5" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False" Width="60px" Visible="False">
			    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
			</dx:GridViewDataCheckColumn>
			<dx:GridViewDataTextColumn Caption="MONTO" FieldName="MONTO_OBRA" VisibleIndex="4" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center">
				<EditFormSettings Visible="False" />
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
			</dx:GridViewDataTextColumn>

			<dx:GridViewDataTextColumn Caption="FP" FieldName="SEGUIMIENTO_CRONOGRAMA" VisibleIndex="6" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center">
                <EditFormSettings Visible="False" />
                <DataItemTemplate>
                            <dx:ASPxHyperLink ID="hyperLink" runat="server" OnInit="hyperLink_Init">
                            </dx:ASPxHyperLink>
                        </DataItemTemplate>
            	<HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
            </dx:GridViewDataTextColumn>

            <dx:GridViewDataTextColumn Caption="RESUMEN" FieldName="SEGUIMIENTO_CRONOGRAMA" VisibleIndex="7" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center">
                <EditFormSettings Visible="False" />
                <DataItemTemplate>
                            <dx:ASPxHyperLink ID="hyperLink_resumen" runat="server" OnInit="hyperLink_Init_resumen">
                            </dx:ASPxHyperLink>
                        </DataItemTemplate>
            	<HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="CURVA S" FieldName="SEGUIMIENTO_CRONOGRAMA" VisibleIndex="9" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center">
                <EditFormSettings Visible="False" />
                <DataItemTemplate>
                            <dx:ASPxHyperLink ID="hyperLink_curva_s" runat="server" OnInit="hyperLink_Init_curva_s">
                            </dx:ASPxHyperLink>
                        </DataItemTemplate>
            	<HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
            </dx:GridViewDataTextColumn>

			<dx:GridViewDataTextColumn Caption="IDCONTRATOSEGUIMIENTO" FieldName="IDCONTRATOSEGUIMIENTO" Visible="False" VisibleIndex="8">
			</dx:GridViewDataTextColumn>

		    <dx:GridViewDataTextColumn FieldName="TOTALPRESUPUESTO" Visible="False" VisibleIndex="10">
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>

		</Columns>
		<SettingsDetail ShowDetailRow="True" AllowOnlyOneMasterRowExpanded="True" ExportIndex="1" ExportMode="All" />
		<Templates>
			<DetailRow>
				<dx:ASPxGridView ID="GridContratoValorizacionDet" runat="server" AutoGenerateColumns="False" OnLoad="GridContratoValorizacionDetSup_Load" OnCustomUnboundColumnData="detailGrid_CustomUnboundColumnData" EnableRowsCache="False" KeyFieldName="IDCONTRATOVALORIZACIONDET" OnRowUpdating="GridContratoSupValorizacionDet_RowUpdating" OnCustomSummaryCalculate="GridContratoValorizacionDet_CustomSummaryCalculate" OnRowValidating="GridContratoValorizacionDet_RowValidating" ClientInstanceName="GridContratoValorizacionDet" Theme="Office2010Blue" CssClass="ocultar" OnSummaryDisplayText="GridContratoValorizacionDet_SummaryDisplayText" OnHtmlRowPrepared="GridContratoValorizacionDet_HtmlRowPrepared" OnHtmlDataCellPrepared="GridContratoValorizacionDet_HtmlDataCellPrepared">
					<Columns>
						<dx:GridViewDataTextColumn Caption="#" FieldName="IDCONTRATOVALORIZACIONDET" VisibleIndex="0">
							<EditFormSettings Visible="False" />
						</dx:GridViewDataTextColumn>
						<dx:GridViewDataTextColumn Caption="DESCRIPCION" FieldName="PARTIDA" VisibleIndex="2">
							<EditFormSettings Visible="False" />
							<HeaderStyle Font-Bold="True" />
							<CellStyle Font-Bold="False">
							</CellStyle>
						</dx:GridViewDataTextColumn>
					    <dx:GridViewDataTextColumn Caption="Saldo Anterior" FieldName="SALDO_OLD" VisibleIndex="12" ShowInCustomizationForm="True" Visible="False">
                            <EditFormSettings Visible="False" />
                        	<CellStyle Font-Bold="True">
							</CellStyle>
                        </dx:GridViewDataTextColumn>
					    <dx:GridViewDataTextColumn Caption="ITEM" FieldName="CODIGO" ShowInCustomizationForm="True" VisibleIndex="1">
                            <EditFormSettings Visible="False" />
                        	<HeaderStyle Font-Bold="True" />
							<CellStyle Font-Bold="False">
							</CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="LEV1" FieldName="LEV1" GroupIndex="1" ShowInCustomizationForm="True" SortIndex="1" SortOrder="Ascending" VisibleIndex="13">
                        	<CellStyle Font-Bold="True">
							</CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="LEV2" FieldName="LEV2" GroupIndex="0" ShowInCustomizationForm="True" SortIndex="0" SortOrder="Ascending" VisibleIndex="14">
                        	<CellStyle Font-Bold="True">
							</CellStyle>
                        </dx:GridViewDataTextColumn>
					    <dx:GridViewDataTextColumn Caption="ACUMULADO_TOTALPRECIO" FieldName="ACUMULADO_TOTALPRECIO" VisibleIndex="15" UnboundType="Decimal" Visible="False">
                        	<CellStyle Font-Bold="True">
							</CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="ACUMULADO_TOTALPRESUPUESTO" FieldName="ACUMULADO_TOTALPRESUPUESTO" VisibleIndex="16" UnboundType="Decimal" Visible="False">
                            <EditFormSettings Visible="False" />                            
                        	<CellStyle Font-Bold="True">
							</CellStyle>
                        </dx:GridViewDataTextColumn>
						<dx:GridViewDataTextColumn Caption="_" FieldName="SALDO_OLD_" VisibleIndex="18">														
							<CellStyle Font-Bold="True">
							</CellStyle>
						</dx:GridViewDataTextColumn>
						<dx:GridViewBandColumn Caption="PRESUPUESTO" VisibleIndex="3">
							<HeaderStyle HorizontalAlign="Center" Font-Bold="True" />
							<Columns>
								<dx:GridViewDataTextColumn Caption="UND" FieldName="MEDIDA" ShowInCustomizationForm="True" VisibleIndex="0">
									<EditFormSettings Visible="False" />
								</dx:GridViewDataTextColumn>
								<dx:GridViewDataTextColumn Caption="PRECIO UNT." FieldName="PRECIO" ShowInCustomizationForm="True" VisibleIndex="2" Width="40px">
									<EditFormSettings Visible="False" />
								</dx:GridViewDataTextColumn>
								<dx:GridViewDataTextColumn Caption="CANT./ MTS" FieldName="CANTIDADTOTAL" ShowInCustomizationForm="True" VisibleIndex="1">
									<EditFormSettings Visible="False" />
									<CellStyle BackColor="#EFEFED" HorizontalAlign="Center">
									</CellStyle>
								</dx:GridViewDataTextColumn>
								<dx:GridViewDataTextColumn Caption="PRECIO PAR." FieldName="PRESUPUESTO_PARCIAL" VisibleIndex="3" UnboundType="Decimal">
									<EditFormSettings Visible="False" />
									<HeaderStyle HorizontalAlign="Center" />
								</dx:GridViewDataTextColumn>
							</Columns>
						</dx:GridViewBandColumn>
						<dx:GridViewBandColumn Caption="ACUMULADO ANTERIOR" VisibleIndex="4">
							<HeaderStyle HorizontalAlign="Center" Font-Bold="True" />
							<Columns>
								<dx:GridViewDataTextColumn Caption="METRADO" FieldName="ACUMULADO" ShowInCustomizationForm="True" VisibleIndex="0">
									<EditFormSettings Visible="False" />
								</dx:GridViewDataTextColumn>
								<dx:GridViewDataTextColumn Caption="PARCIAL" FieldName="ACUMULADO_ANTERIOR_PARCIAL" VisibleIndex="1" UnboundType="Decimal">
									<EditFormSettings Visible="False" />
								</dx:GridViewDataTextColumn>
								<dx:GridViewDataTextColumn Caption="% AVANCE" FieldName="ACUMULADO_ANTERIOR_PORCENTAJE" VisibleIndex="2" UnboundType="Decimal">
									<EditFormSettings Visible="False" />
								</dx:GridViewDataTextColumn>
							</Columns>
						</dx:GridViewBandColumn>
						<dx:GridViewBandColumn Caption="AVANCE ACTUAL" VisibleIndex="5">
							<HeaderStyle HorizontalAlign="Center" Font-Bold="True" />
							<Columns>
								<dx:GridViewDataTextColumn Caption="METRADO" FieldName="CANTIDAD" ShowInCustomizationForm="True" VisibleIndex="0" Width="40px">
									<PropertiesTextEdit>
										<Style Font-Bold="True">
										</Style>
									</PropertiesTextEdit>
									<CellStyle BackColor="#D0EBFB" Font-Bold="False">
									</CellStyle>
								</dx:GridViewDataTextColumn>
								<dx:GridViewDataTextColumn Caption="% AVANCE" FieldName="PORCENTAJE" ShowInCustomizationForm="True" VisibleIndex="2" Width="50px">
									<EditFormSettings Visible="False" />
								</dx:GridViewDataTextColumn>
								<dx:GridViewDataTextColumn Caption="PARCIAL" FieldName="TOTAL" ShowInCustomizationForm="True" UnboundType="Decimal" VisibleIndex="1" Width="20px">
									<EditFormSettings Visible="False" />
									<CellStyle HorizontalAlign="Center">
									</CellStyle>
								</dx:GridViewDataTextColumn>
							</Columns>
						</dx:GridViewBandColumn>
						<dx:GridViewBandColumn Caption="ACUMULADO ACTUAL" VisibleIndex="6">
							<HeaderStyle HorizontalAlign="Center" Font-Bold="True" />
							<Columns>
								<dx:GridViewDataTextColumn Caption="METRADO" FieldName="ACUMULADO_TOTAL" ShowInCustomizationForm="True" UnboundType="Decimal" VisibleIndex="0" Width="20px">
									<EditFormSettings Visible="False" />
									<CellStyle HorizontalAlign="Center">
									</CellStyle>
								</dx:GridViewDataTextColumn>
								<dx:GridViewDataTextColumn Caption="% AVANCE" FieldName="SALDOACUMULADO" ShowInCustomizationForm="True" UnboundType="Decimal" VisibleIndex="2">
									<PropertiesTextEdit>
										<Style Font-Bold="True">
										</Style>
									</PropertiesTextEdit>
									<EditFormSettings Visible="False" />
									<CellStyle BackColor="#D0EBFB" Font-Bold="False" HorizontalAlign="Center">
									</CellStyle>
								</dx:GridViewDataTextColumn>
								<dx:GridViewDataTextColumn Caption="PARCIAL" FieldName="ACUMULADO_TOTAL_PARCIAL" VisibleIndex="1" UnboundType="Decimal">
									<EditFormSettings Visible="False" />
								</dx:GridViewDataTextColumn>
							</Columns>
						</dx:GridViewBandColumn>
						<dx:GridViewBandColumn Caption="SALDO POR EJECUTAR" VisibleIndex="7">
							<HeaderStyle HorizontalAlign="Center" Font-Bold="True" />
							<Columns>
								<dx:GridViewDataTextColumn Caption="METRADO" FieldName="SALDO_POR_EJECUTAR" VisibleIndex="0" UnboundType="Decimal">
									<EditFormSettings Visible="False" />
									<HeaderStyle HorizontalAlign="Center" />
								</dx:GridViewDataTextColumn>
								<dx:GridViewDataTextColumn Caption="VALORIZADO" FieldName="SALDO_POR_EJECUTAR_VALORIZADO" VisibleIndex="1" UnboundType="Decimal">
									<EditFormSettings Visible="False" />
									<HeaderStyle HorizontalAlign="Center" />
								</dx:GridViewDataTextColumn>
							</Columns>
						</dx:GridViewBandColumn>
					</Columns>
					<Settings VerticalScrollableHeight="594" GroupFormat="{1} {2}" />
					<SettingsEditing Mode="Batch" />
					<Settings ShowFooter="True" />
                    <SettingsDetail ExportMode="All" />
                    <SettingsPager EnableAdaptivity="true" />                                        
                    <Styles Header-Wrap="True">
                    	<Header Wrap="True">
						</Header>
						<Footer BackColor="#D0EBFB" Font-Bold="True" Font-Italic="False" Font-Names="Calibri" Font-Size="14px" Font-Strikeout="False" Font-Underline="False">
							<Paddings PaddingTop="5px" />
						</Footer>
					</Styles>
                    <TotalSummary>
                        <dx:ASPxSummaryItem FieldName="CompanyName" SummaryType="Count" />                        
                        <dx:ASPxSummaryItem FieldName="TOTAL" ShowInColumn="SALDO_OLD_"  SummaryType="Sum" DisplayFormat="C. Directo = {0:c}"/>												
						<dx:ASPxSummaryItem FieldName="TOTAL" ShowInColumn="SALDO_OLD_" SummaryType="Custom" DisplayFormat="G. Generales = {0:c}" Tag="1" />
						<dx:ASPxSummaryItem FieldName="TOTAL" ShowInColumn="SALDO_OLD_" SummaryType="Custom" DisplayFormat="Utilidad = {0:c}" Tag="2" />
						<dx:ASPxSummaryItem FieldName="TOTAL" ShowInColumn="SALDO_OLD_" SummaryType="Custom" DisplayFormat="Subtotal = {0:c}" Tag="3" />						
						<dx:ASPxSummaryItem FieldName="TOTAL" ShowInColumn="PARTIDA" SummaryType="Custom" DisplayFormat="Adelanto Dir. = {0:c}" Tag="4" />
						<dx:ASPxSummaryItem FieldName="TOTAL" ShowInColumn="PARTIDA" SummaryType="Custom" DisplayFormat="Adelanto Mat. = {0:c}" Tag="5" />
						<dx:ASPxSummaryItem FieldName="TOTAL" ShowInColumn="PARTIDA" SummaryType="Custom" DisplayFormat="Adelanto Otr. = {0:c}" Tag="6" />
						<dx:ASPxSummaryItem FieldName="TOTAL" ShowInColumn="SALDO_OLD_" SummaryType="Custom" DisplayFormat="Total Adelantos = {0:c}" Tag="7" />
						<dx:ASPxSummaryItem FieldName="TOTAL" ShowInColumn="SALDO_OLD_" SummaryType="Custom" DisplayFormat="Total = {0:c}" Tag="8" />
						<dx:ASPxSummaryItem FieldName="TOTAL" ShowInColumn="SALDO_OLD_" SummaryType="Custom" DisplayFormat="Igv = {0:c}" Tag="9" />
						<dx:ASPxSummaryItem FieldName="TOTAL" ShowInColumn="SALDO_OLD_" SummaryType="Custom" DisplayFormat="Total = {0:c}" Tag="10" />

						<dx:ASPxSummaryItem FieldName="ACUMULADO_TOTAL" ShowInColumn="SALDO_OLD_"  SummaryType="Sum" DisplayFormat="ACUM = {0:c}" Tag="11" Visible="false"/>						
						<dx:ASPxSummaryItem FieldName="CANTIDADTOTAL" ShowInColumn="SALDO_OLD_"  SummaryType="Sum" DisplayFormat="ACUM = {0:c}" Tag="12" Visible="False"/>
                        <dx:ASPxSummaryItem FieldName="ACUMULADO_TOTALPRECIO" ShowInColumn="SALDO_OLD_"  SummaryType="Sum" DisplayFormat="ACUM = {0:c}" Tag="13" Visible="false"/>	
                        <dx:ASPxSummaryItem FieldName="ACUMULADO_TOTALPRESUPUESTO" ShowInColumn="SALDO_OLD_"  SummaryType="Sum" DisplayFormat="ACUM = {0:c}" Tag="14" Visible="false"/>	
						<dx:ASPxSummaryItem FieldName="CANTIDADTOTAL" ShowInColumn="SALDO_OLD_" SummaryType="Custom" DisplayFormat="%A = {0}%" Tag="15" />						                        
                    </TotalSummary>
				</dx:ASPxGridView>
			</DetailRow>
		</Templates>
		<Settings ShowTitlePanel="true" />
		<SettingsText Title="SUPERVISOR" />
	    <FormatConditions>
            <dx:GridViewFormatConditionHighlight FieldName="CONDITION">
            </dx:GridViewFormatConditionHighlight>
        </FormatConditions>
		<Styles>
			<DetailRow Font-Names="Arial Narrow">
			</DetailRow>
			<DetailCell Font-Names="Arial Narrow">
			</DetailCell>
			<Footer Font-Bold="True">
			</Footer>
		</Styles>
	</dx:ASPxGridView>

        <dx:ASPxPopupControl ID="popupControl" runat="server" ClientInstanceName="clientPopupControl" CloseAction="CloseButton" Height="700px" Modal="True" Width="850px" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter">
            <ContentCollection>
                <dx:PopupControlContentControl runat="server">
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>

		</td></tr></table>

</dx:ContentControl>
			        </ContentCollection>
		        </dx:TabPage>                                             
            </TabPages>
        </dx:ASPxPageControl>           
</asp:Content>