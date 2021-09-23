<%@ Page Language="C#" MasterPageFile="~/Modules/MasterPage.Master" AutoEventWireup="true" CodeBehind="frmInfoGesGSOPresupuesto.aspx.cs" Inherits="InfogesEmape.Modules.Forms.Seguimiento.frmInfoGesGSOPresupuesto" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">        
     <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" AutoPostBack="true"
            ActiveTabIndex="0" Height="300%" TabSpacing="3px"  Font-Size="X-Small" 
            Width="100%">
	        <ActiveTabStyle Font-Bold="True" Font-Size="Small">
	        </ActiveTabStyle>                        
	        <TabPages >   
		        <dx:TabPage Text="REGISTRO DE PROYECTO." >
			        <ContentCollection>
				        <dx:ContentControl ID="ContentControl13" runat="server">	
                            <table>
                                <tr>
                                    <td >

                        <dx:ASPxGridView ID="GridProyectoContrato" runat="server"  Width="100%"  Visible="true" KeyFieldName="IDCONTRATO"
    OnLoad="OnLoadProyectoContrato" >
    <Columns> 
    <dx:GridViewDataTextColumn FieldName="CONTRATO_NUMERO" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="80px"
    Caption="NÚMERO CONTRATO" VisibleIndex="0" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  >
<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>

<CellStyle HorizontalAlign="Right"></CellStyle>
    </dx:GridViewDataTextColumn> 
    <dx:GridViewBandColumn  Caption="EMPRESA"  VisibleIndex="1" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" >
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

<CellStyle HorizontalAlign="Center"></CellStyle>
    </dx:GridViewDataTextColumn> 
    </Columns>
    </dx:GridViewBandColumn>
    <dx:GridViewBandColumn Caption="CONTRATO"  VisibleIndex="2" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" >
<HeaderStyle HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>
    <Columns>
    <dx:GridViewDataDateColumn FieldName="FECHA_CONTRATO" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="100px"
    Caption="FECHA CONTRATO" VisibleIndex="4" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>

<CellStyle HorizontalAlign="Right"></CellStyle>
    </dx:GridViewDataDateColumn>
    <dx:GridViewDataTextColumn FieldName="MONTO_OBRA" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="100px"
    Caption="IMPORTE OBRA" VisibleIndex="6" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>

<CellStyle HorizontalAlign="Right"></CellStyle>
    </dx:GridViewDataTextColumn>
    <dx:GridViewDataTextColumn FieldName="PLAZO_EJECUCION_OBRA" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="100px"
    Caption="PLAZO EJECUCIÓN" VisibleIndex="7" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>

<CellStyle HorizontalAlign="Right"></CellStyle>
    </dx:GridViewDataTextColumn>
    <dx:GridViewBandColumn Caption="INICIO DE OBRA"  VisibleIndex="5" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" >
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
    <dx:GridViewBandColumn   Caption="ENTREGA DE TERRENO"  VisibleIndex="3" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  HeaderStyle-Wrap="True">
<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>
    <Columns>
    <dx:GridViewDataDateColumn FieldName="FECHA_ENTREGA_TERRENO" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"
    Caption="FECHA ENT. TERRE." VisibleIndex="15" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>

<CellStyle HorizontalAlign="Right"></CellStyle>
    </dx:GridViewDataDateColumn>
    <dx:GridViewDataDateColumn   visible="false" FieldName="FECHA_ENTREGA_TERRENO_LIMITE" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"
    Caption="FECHA ENT. TERR. LIM." VisibleIndex="16" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>

<CellStyle HorizontalAlign="Right"></CellStyle>
    </dx:GridViewDataDateColumn>
    <dx:GridViewDataComboBoxColumn Caption="ESTADO CONTRATO" FieldName="DESCRIPCION_ESTADO_CONTRATO" VisibleIndex="17" HeaderStyle-HorizontalAlign="Center"  Width="60px"
            Settings-AllowSort="False" Settings-AllowDragDrop="False" Settings-FilterMode="Value" EditFormSettings-Visible="True">
        <PropertiesComboBox TextField="DESCRIPCION_ESTADO_CONTRATO" ValueField="IDESTADO_CONTRATO" ></PropertiesComboBox>

<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<EditFormSettings Visible="True"></EditFormSettings>

        <HeaderStyle HorizontalAlign="Center" />
    </dx:GridViewDataComboBoxColumn>
    </Columns>
    </dx:GridViewBandColumn>
        <dx:GridViewDataTextColumn Caption="LINK" FieldName="CONTRATO_NUMERO" ShowInCustomizationForm="True" VisibleIndex="4" Visible="False">
            <HeaderStyle HorizontalAlign="Center" />
            <DataItemTemplate>
                <a id="LinkButton1"  href="frmInfoGesGsoProyectoRegistroCoordinador.aspx?pOpera=edit&amp;pId=<%# Session["pIdProyecto"]%>">IR A VALORIZACIÓN</a>												
            </DataItemTemplate>
        </dx:GridViewDataTextColumn>
    </Columns>
    <SettingsBehavior AllowFocusedRow="True" />
    <SettingsEditing Mode="PopupEditForm" EditFormColumnCount="2" />
    </dx:ASPxGridView>                    	
        </td>
             </tr>
    <tr>
        <td><br /><br />

             <table style="width: 100%;margin:2px 2px;text-align:right">
                                            <tr>
                                                <td class="auto-style12">
                                                    <asp:Button ID="Button1" runat="server" Text="Export to PDF" CssClass="btn btn-primary btn-xs" OnClick="Button1_Click" />&nbsp;&nbsp;<asp:Button ID="Button3" runat="server" Text="Export to EXCEL" CssClass="btn btn-success btn-xs" OnClick="Button2_Click" /></td>
                                                <td class="auto-style9">&nbsp;</td>                                                
                                                <td>&nbsp;</td>
                                            </tr>                                            
                                        </table>

            <dx:ASPxGridView ID="GridContratoPartida" runat="server" AutoGenerateColumns="False" Width="100%" KeyFieldName="IDCONTRATOPARTIDA" OnLoad="OnLoadContratoPartida" OnCustomUnboundColumnData="GridContratoPartida_CustomUnboundColumnData" OnCustomSummaryCalculate="GridContratoPartida_CustomSummaryCalculate" EnableTheming="True" Theme="Glass" ClientInstanceName="GridContratoPartida" OnSummaryDisplayText="GridContratoPartida_SummaryDisplayText" OnRowUpdating="OnRowUpdatingContratoPartida" OnHtmlDataCellPrepared="GridContratoPartida_HtmlDataCellPrepared" OnHtmlRowPrepared="GridContratoPartida_HtmlRowPrepared" OnHtmlRowCreated="GridContratoPartida_HtmlRowCreated">                                       
										<SettingsEditing Mode="PopupEditForm">
										</SettingsEditing>
										<Columns>
											<dx:GridViewDataTextColumn Caption="MEDIDA" FieldName="PAR_MEDIDA" ShowInCustomizationForm="True" VisibleIndex="2">
											    <EditFormSettings Visible="False" />
											</dx:GridViewDataTextColumn>
											<dx:GridViewDataTextColumn Caption="PRECIO" FieldName="PAR_PRECIO" ShowInCustomizationForm="True" VisibleIndex="4">
											    <EditFormSettings Visible="False" />
											</dx:GridViewDataTextColumn>
											<dx:GridViewDataComboBoxColumn Caption="DESCRIPCION" FieldName="PAR_NOMBRE" ShowInCustomizationForm="True" VisibleIndex="1" Width="500px">
											    <EditFormSettings Visible="False" />
											</dx:GridViewDataComboBoxColumn>
											<dx:GridViewDataTextColumn Caption="METRADO" FieldName="PAR_CANTIDAD" ShowInCustomizationForm="True" VisibleIndex="3">
											    <EditFormSettings Visible="False" />
											</dx:GridViewDataTextColumn>
											<dx:GridViewDataTextColumn Caption="TOTAL" FieldName="TOTAL" VisibleIndex="5" UnboundType="Decimal">
											    <EditFormSettings Visible="False" />
											</dx:GridViewDataTextColumn>
											<dx:GridViewDataTextColumn Caption="CODIGO" FieldName="CTP_CODIGO" ShowInCustomizationForm="True" VisibleIndex="0">
											    <EditFormSettings Visible="False" />
											</dx:GridViewDataTextColumn>
										    <dx:GridViewDataCheckColumn Caption="APROBADO" FieldName="APROBADO" ShowInCustomizationForm="True" VisibleIndex="8">                                                
                                            </dx:GridViewDataCheckColumn>                                            
										</Columns>
										<Toolbars>
											<dx:GridViewToolbar>
												<Items>
													<dx:GridViewToolbarItem Command="New" Name="New"></dx:GridViewToolbarItem>
													<dx:GridViewToolbarItem Command="Edit"></dx:GridViewToolbarItem>
													<dx:GridViewToolbarItem Command="Delete"></dx:GridViewToolbarItem>
                                                    
												</Items>
											</dx:GridViewToolbar>
										</Toolbars>
										<Settings ShowHeaderFilterButton="true" ShowColumnHeaders="true"  GroupFormat="{1} {2}" ShowGroupPanel="False" />
                                        <SettingsEditing Mode="Batch" />					                                                                                                                  										
										<SettingsText Title="ASOCIACION DE PARTIDAS CON CONTRATO" />
										<SettingsBehavior AllowFocusedRow="True" />
										<Settings ShowFooter="True" ShowTitlePanel="true"  />
										<Settings ShowFooter="True" />
										<SettingsPager EnableAdaptivity="true" PageSize="40" />										
										<GroupSummary>											
											<dx:ASPxSummaryItem FieldName="TOTAL" SummaryType="SUM" ShowInGroupFooterColumn="TOTAL" DisplayFormat="Total Partida = {0:c}" />
										</GroupSummary>
										<Styles Header-Wrap="True">
											<Header Wrap="True">
											</Header>
											<GroupFooter CssClass="table table-streap">
											</GroupFooter>
										</Styles>
										<TotalSummary>
											<dx:ASPxSummaryItem FieldName="CompanyName" SummaryType="Count" />
											<dx:ASPxSummaryItem FieldName="TOTAL" ShowInColumn="TOTAL" SummaryType="Sum" DisplayFormat="COSTO DIRECTO = {0:c}"/>
											<dx:ASPxSummaryItem FieldName="TOTAL" ShowInColumn="TOTAL" SummaryType="Custom" DisplayFormat="G. Generales = {0:c}" Tag="1" />
						                    <dx:ASPxSummaryItem FieldName="TOTAL" ShowInColumn="TOTAL" SummaryType="Custom" DisplayFormat="Utilidad = {0:c}" Tag="2" />
											<dx:ASPxSummaryItem FieldName="TOTAL" ShowInColumn="TOTAL" SummaryType="Custom" DisplayFormat="Otros = {0:c}" Tag="3" />
						                    <dx:ASPxSummaryItem FieldName="TOTAL" ShowInColumn="TOTAL" SummaryType="Custom" DisplayFormat="Subtotal = {0:c}" Tag="4" />
						                    <dx:ASPxSummaryItem FieldName="TOTAL" ShowInColumn="TOTAL" SummaryType="Custom" DisplayFormat="Igv = {0:c}" Tag="5" />
						                    <dx:ASPxSummaryItem FieldName="TOTAL" ShowInColumn="TOTAL" SummaryType="Custom" DisplayFormat="Total = {0:c}" Tag="6" />
											<dx:ASPxSummaryItem FieldName="TOTAL" ShowInColumn="TOTAL" SummaryType="Custom" DisplayFormat="Total-A = {0:c}" Tag="7" Visible="False" />
											<dx:ASPxSummaryItem FieldName="APROBADO" ShowInColumn="APROBADO" SummaryType="Custom" />
										</TotalSummary>										
									</dx:ASPxGridView>
        </td>
    </tr>

                                <tr>                                        
                                        <dx:ASPxGridViewExporter ID="gridExporter" runat="server" ExportedRowType="All" GridViewID="GridContratoPartida" PaperKind="A4"></dx:ASPxGridViewExporter>
                                            
                                        <td style="margin-left:400px; text-align:right;">
                                            <table style="font-size:12px;margin-top:20px;font-weight:bold" width="100%" class="table table-streap">												
                                                <tr style="display:none">
                                                    <td class="auto-style3">SUBTOTAL</td>
                                                    <td>
                                                        <asp:Label ID="LBLSUBTOTAL" runat="server" Text="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style6">% Gastos Generales 
                                                    </td>
                                                    <td class="auto-style7">
														<asp:TextBox ID="TxtGastosGenerales" runat="server" OnTextChanged="TxtGastosGenerales_TextChanged" Width="50px" ReadOnly="true"></asp:TextBox>                                                        
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style3">% Utilidad 
                                                    </td>
                                                    <td>
														<asp:TextBox ID="TXTUTILIDAD" runat="server" AutoPostBack="True" OnTextChanged="TXTUTILIDAD_TextChanged" Width="50px" ReadOnly="true"></asp:TextBox>                                                        
                                                        <br />
                                                    </td>
                                                </tr>
												<tr>
                                                    <td class="auto-style3">% Gastos Otros 
                                                    </td>
                                                    <td>
														<asp:TextBox ID="TXTGASTOSOTROS" runat="server" AutoPostBack="True" OnTextChanged="TXTGASTOSOTROS_TextChanged" Width="50px" ReadOnly="true"></asp:TextBox>                                                        
                                                        <br />
                                                    </td>
                                                </tr>
												<tr>
                                                    <td class="auto-style3">% Adelanto Directo 
                                                    </td>
                                                    <td>
														<asp:TextBox ID="TXTADELANTODIRECTO" runat="server" Width="50px" ReadOnly="true"></asp:TextBox>                                                        
                                                        <br />
                                                    </td>
                                                </tr>
												<tr>
                                                    <td class="auto-style3">% Adelanto de Materiales 
                                                    </td>
                                                    <td>
														<asp:TextBox ID="TXTADELANTOMATERIALES" AutoPostBack="True" runat="server" Width="50px" OnTextChanged="TXTADELANTOMATERIALES_TextChanged" ReadOnly="true"></asp:TextBox>                                                        
                                                        <br />
                                                    </td>
                                                </tr>
												<tr>
                                                    <td class="auto-style3">% Adelanto Otros 
                                                    </td>
                                                    <td>
														<asp:TextBox ID="TXTADELANTOOTROS" AutoPostBack="True" runat="server" Width="50px" OnTextChanged="TXTADELANTOMATERIALES_TextChanged" ReadOnly="true"></asp:TextBox>                                                        
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr style="display:none">
                                                    <td class="auto-style3">SUBTOTAL</td>
                                                    <td>
                                                        <asp:Label ID="LBLSUB" runat="server" Text="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr style="display:none">
                                                    <td class="auto-style3">IGV 18%</td>
                                                    <td>
                                                        <asp:Label ID="LBLIGV" runat="server" Text="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr style="display:none">
                                                    <td class="auto-style3">TOTAL</td>
                                                    <td>
                                                        <asp:Label ID="LBLTOTAL" runat="server" Text="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>                                
                                <tr><td colspan="2" style="font-size:12px;font-weight:bold"><br /><br />

                                        Este documento tiene carácter de declaración jurada y la información está protegida por la Ley N° 29733 - Ley de protección de datos personales.
                                        </td></tr>
                            </table>
 				        </dx:ContentControl>
			        </ContentCollection>
		        </dx:TabPage>                                             
            </TabPages>
        </dx:ASPxPageControl>



</asp:Content>



