<%@ Page Language="C#" MasterPageFile="~/Modules/MasterPage.Master" AutoEventWireup="true" CodeBehind="frmInfoGesGSOSResumen.aspx.cs" Inherits="InfogesEmape.Modules.Forms.Seguimiento.frmInfoGesGSOSResumen" %>

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
                                    <td>

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
									<td><br /><br /><br />
										<table class="table table-streap">

											<tr>
												<th rowspan="2">DESCRIPCION</th>
												<th rowspan="2">MONTO CONTRATADO</th>
												<th colspan="3" style="text-align:center">VALORIZACION</th>
												<th rowspan="2">% AVANCE ACUMULADO</th>												
												<th rowspan="2">SALDO POR VALORIZAR</th>												
											</tr>
											<tr>												
												<td>ANTERIOR</td>
												<td>ACTUAL</td>
												<td>ACUMULADO</td>												
											</tr>
											<tr>
												<th>
													VALORIZACION (V)
												</th>
												<td><asp:Label ID="LBLMONTOCONTRADO" runat="server"></asp:Label></td>
												<td><asp:Label ID="LBLVALORIZACION_ANTERIOR" runat="server"></asp:Label></td>
												<td><asp:Label ID="LBLVALORIZACION_ACTUAL" runat="server"></asp:Label></td>	
												<td><asp:Label ID="LBLVALORIZACION_ACUMULADA" runat="server" Text="Label"></asp:Label></td>
												<td><asp:Label ID="AVANCEACUMULADO" runat="server"></asp:Label></td>
												<td><asp:Label ID="SALDOPORVALORIZAR" runat="server"></asp:Label></td>
											</tr>
											<tr>
												<th>
													TOTAL CONTRACTUAL
												</th>
												<td></td>
												<td><asp:Label ID="LBLVALORIZACIONANTERIORPORCENTAJE" runat="server" Text="Label">%</asp:Label></td>
												<td><asp:Label ID="LBLVALORIZACIONACTUALPORCENTAJE" runat="server" Text="Label">%</asp:Label></td>
												<td><asp:Label ID="LBLVALORIZACIONACUMULADAPORCENTAJE" runat="server" Text="Label">%</asp:Label></td>
												<td></td>
												<td></td>
											</tr>
											<tr>
												<th>
													REAJUSTES (R)
												</th>
												<td></td>
												<td></td>
												<td></td>
												<td></td>
												<td></td>
												<td></td>
											</tr>
											<tr>
												<th>
													DEDUCCIONES
												</th>
												<td></td>
												<td></td>
												<td></td>
												<td></td>
												<td></td>
												<td></td>
											</tr>
											<tr>
												<th>
													VALORIZACION BRUTA
												</th>
												<td></td>
												<td><asp:Label ID="LBLVALORIZACIONANTERIORBRUTA" runat="server" Text="Label"></asp:Label></td>
												<td><asp:Label ID="LBLVALORIZACIONACTUALBRUTA" runat="server" Text="Label"></asp:Label></td>
												<td><asp:Label ID="LBLVALORIZACIONACUMULADABRUTA" runat="server" Text="Label"></asp:Label></td>
												<td></td>
												<td></td>
											</tr>
											<tr>
												<th>
													ADELTANTO DIRECTO
												</th>
												<td></td>
												<td><asp:Label ID="LBLADELANTODIRECTOANTERIOR" runat="server" Text="Label"></asp:Label></td>
												<td><asp:Label ID="LBLADELANTODIRECTOACTUAL" runat="server" Text="Label"></asp:Label></td>
												<td><asp:Label ID="LBLADELANTODIRECTOACUMULADO" runat="server" Text="Label"></asp:Label></td>
												<td></td>
												<td></td>
											</tr>
											<tr>
												<th>
													ADELANTO MATERIALES
												</th>
												<td></td>
												<td><asp:Label ID="LBLADELANTOMATERIALESANTERIOR" runat="server" Text="Label"></asp:Label></td>
												<td><asp:Label ID="LBLADELANTOMATERIALESACTUAL" runat="server" Text="Label"></asp:Label></td>
												<td><asp:Label ID="LBLADELANTOMATERIALESACUMULADO" runat="server" Text="Label"></asp:Label></td>
												<td></td>
												<td></td>
											</tr>
											<tr>
												<th>
													AMORTIZACION TOTAL
												</th>
												<td></td>
												<td><asp:Label ID="LBLTOTALAMORTIZACIONANTERIOR" runat="server" Text="Label"></asp:Label></td>
												<td><asp:Label ID="LBLTOTALAMORTIZACIONACTUAL" runat="server" Text="Label"></asp:Label></td>
												<td><asp:Label ID="LBLTOTALAMORTIZACIONACUMULADO" runat="server" Text="Label"></asp:Label></td>
												<td></td>
												<td></td>
											</tr>
											<tr>
												<th>
													VALORIZACION NETA
												</th>
												<td></td>
												<td><asp:Label ID="LBLVALORIZACIONNETAANTERIOR" runat="server" Text="Label"></asp:Label></td>
												<td><asp:Label ID="LBLVALORIZACIONNETAACTUAL" runat="server" Text="Label"></asp:Label></td>
												<td><asp:Label ID="LBLVALORIZACIONNETAACUMULADA" runat="server" Text="Label"></asp:Label></td>
												<td></td>
												<td></td>
											</tr>
											<tr>
												<th>
													MONTO A PAGAR AL CONTRATISTA
												</th>
												<td></td>
												<td><asp:Label ID="LBLMONTOSUBTOTALANTERIOR" runat="server" Text="Label"></asp:Label></td>
												<td><asp:Label ID="LBLMONTOSUBTOTALACTUAL" runat="server" Text="Label"></asp:Label></td>
												<td><asp:Label ID="LBLMONTOSUBTOTALACUMULADO" runat="server" Text="Label"></asp:Label></td>
												<td></td>
												<td></td>
											</tr>
											<tr>
												<th>
													IGV
												</th>
												<td></td>
												<td><asp:Label ID="LBLIGVANTERIOR" runat="server" Text="Label"></asp:Label></td>
												<td><asp:Label ID="LBLIGVACTUAL" runat="server" Text="Label"></asp:Label></td>
												<td><asp:Label ID="LBLIGVACUMULADO" runat="server" Text="Label"></asp:Label></td>
												<td></td>
												<td></td>
											</tr>
											<tr>
												<th>
													TOTAL CON IGV
												</th>
												<td></td>
												<td><asp:Label ID="LBLTOTALANTERIOR" runat="server" Text="Label"></asp:Label></td>
												<td><asp:Label ID="LBLTOTALACTUAL" runat="server" Text="Label"></asp:Label></td>
												<td><asp:Label ID="LBLTOTALACUMULADO" runat="server" Text="Label"></asp:Label></td>
												<td></td>
												<td></td>
											</tr>

											<tr>
												<th>
													TOTAL COMPROMISO DE PAGO
												</th>
												<td></td>
												<td></td>
												<td><asp:Label ID="LBLTOTALCOMPROMISOPAGO" runat="server" Text="Label"></asp:Label></td>
												<td></td>
												<td></td>
												<td></td>
											</tr>											
										</table>
									</td>
								</tr>
                                </table>
                            </dx:ContentControl>
			        </ContentCollection>
		        </dx:TabPage>                                             
            </TabPages>
        </dx:ASPxPageControl>     
</asp:Content>