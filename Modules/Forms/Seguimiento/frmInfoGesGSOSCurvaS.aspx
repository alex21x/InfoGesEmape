<%@ Page Language="C#" MasterPageFile="~/Modules/MasterPage.Master" AutoEventWireup="true" CodeBehind="frmInfoGesGSOSCurvaS.aspx.cs" Inherits="InfogesEmape.Modules.Forms.Seguimiento.frmInfoGesGSOSCurvaS" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.XtraCharts.v17.1.Web, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts.Web" tagprefix="dx" %>
<%@ Register assembly="DevExpress.XtraCharts.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.ASPxPivotGrid.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPivotGrid" tagprefix="dx" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>    

    <asp:Panel runat="server" ID="panelPDF">
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
                                    <td colspan ="2" >

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
    Caption="FECHA CONTRATO" VisibleIndex="2" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>

<CellStyle HorizontalAlign="Right"></CellStyle>
    </dx:GridViewDataDateColumn>
    <dx:GridViewDataTextColumn FieldName="MONTO_OBRA" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="100px"
    Caption="IMPORTE OBRA" VisibleIndex="4" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>

<CellStyle HorizontalAlign="Right"></CellStyle>
    </dx:GridViewDataTextColumn>
    <dx:GridViewDataTextColumn FieldName="PLAZO_EJECUCION_OBRA" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="100px"
    Caption="PLAZO EJECUCIÓN" VisibleIndex="5" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>

<CellStyle HorizontalAlign="Right"></CellStyle>
    </dx:GridViewDataTextColumn>
    <dx:GridViewBandColumn Caption="INICIO DE OBRA"  VisibleIndex="3" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" >
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
        <dx:GridViewDataTextColumn Caption="SUPERVISOR" FieldName="RAZON_SOCIAL_SUPERVISOR" ShowInCustomizationForm="True" VisibleIndex="6">
            <HeaderStyle Font-Bold="True" />
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn Caption="RUC SUPERVISOR" FieldName="RUC_SUPERVISOR" ShowInCustomizationForm="True" VisibleIndex="7">
            <HeaderStyle Font-Bold="True" />
        </dx:GridViewDataTextColumn>
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
                                         <td  colspan="2" >
                                        <br />
                                        <asp:Button ID="Button3" runat="server" CssClass="btn btn-primary btn-xs" OnClick="Button1_Click" Text="Export to PDF"  />
                                        <asp:Button ID="Button4" runat="server" CssClass="btn btn-success btn-xs" OnClick="Button2_Click" Text="Export to EXCEL"  />
                                    </td> 
                                   
                                    
                                    
            
                                
                                </tr>
                                <tr>
                                    <td><br /><br />
                                        <dx:WebChartControl ID="WebChartControl2" runat="server" AppearanceNameSerializable="Gray" CrosshairEnabled="True" Height="350px" Width="700px" ClientInstanceName="chat1">
                                            <Legend Name="Default Legend"></Legend>
                                        </dx:WebChartControl>

                                        
                                    </td>
                                    <td><br /><br />
                                       <dx:WebChartControl ID="WebChartControl3" runat="server" CrosshairEnabled="True" Height="350px" Width="699px">
                                            <Legend Name="Default Legend"></Legend>
                                        </dx:WebChartControl>
                                    </td>                     
                                    
                                </tr>
                                <tr>

                                    <td colspan="2"><br /><br />
                                        
                                       
                                        <dx:ASPxGridView ID="GridProyectoContratoResumen" runat="server" CssClass="auto-style4" AutoGenerateColumns="False">
                                            <Columns>
                                                <dx:GridViewBandColumn Caption="     " ShowInCustomizationForm="True" VisibleIndex="0">
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn Caption="FECHA " ShowInCustomizationForm="True" VisibleIndex="0">
                                                            <HeaderStyle Font-Bold="True" />
                                                            <CellStyle Font-Bold="True">
                                                            </CellStyle>
                                                        </dx:GridViewDataTextColumn>
                                                    </Columns>
                                                </dx:GridViewBandColumn>
                                                <dx:GridViewBandColumn Caption="VALORIZACION PROGRAMA SIN IGV" ShowInCustomizationForm="True" VisibleIndex="1">
                                                    <HeaderStyle Border-BorderStyle="Solid" Font-Bold="True" />
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn Caption="PARCIAL (S/.)" ShowInCustomizationForm="True" VisibleIndex="2" FieldName="MONTO_OBRA">
                                                            <HeaderStyle Font-Bold="True" />
                                                            <CellStyle Font-Bold="True">
                                                            </CellStyle>
                                                            <ExportCellStyle Font-Bold="True">
                                                            </ExportCellStyle>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="MES PROGRAMADO %" ShowInCustomizationForm="True" VisibleIndex="0" FieldName="CRONOGRAMA_FECHA">
                                                            <HeaderStyle Font-Bold="True" />
                                                            <ExportCellStyle Font-Bold="True">
                                                            </ExportCellStyle>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="ACUMULADO PROGRAMADO %" ShowInCustomizationForm="True" VisibleIndex="1" FieldName="AVANCE_CRONOGRAMA">
                                                            <HeaderStyle Font-Bold="True" />
                                                            <ExportCellStyle Font-Bold="True">
                                                            </ExportCellStyle>
                                                        </dx:GridViewDataTextColumn>
                                                    </Columns>
                                                </dx:GridViewBandColumn>
                                                <dx:GridViewBandColumn Caption="VALORIZACION REAL SIN IGV" ShowInCustomizationForm="True" VisibleIndex="2">
                                                    <HeaderStyle Font-Bold="True" />
                                                    <ExportCellStyle Font-Bold="True">
                                                    </ExportCellStyle>
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn Caption="PARCIAL (S/.)" ShowInCustomizationForm="True" VisibleIndex="2" FieldName="MONTOVALORIZACION">
                                                            <HeaderStyle Font-Bold="True" />
                                                            <ExportCellStyle Font-Bold="True">
                                                            </ExportCellStyle>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="MES REAL %" ShowInCustomizationForm="True" VisibleIndex="0" FieldName="SEGUIMIENTO_FECHA">
                                                            <HeaderStyle Font-Bold="True" />
                                                            <ExportCellStyle Font-Bold="True">
                                                            </ExportCellStyle>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="ACUMULADO REAL %" ShowInCustomizationForm="True" VisibleIndex="1" FieldName="AVANCE_VALORIZACION">
                                                            <HeaderStyle Font-Bold="True" />
                                                            <ExportCellStyle Font-Bold="True">
                                                            </ExportCellStyle>
                                                        </dx:GridViewDataTextColumn>
                                                    </Columns>
                                                </dx:GridViewBandColumn>
                                            </Columns>
                                        </dx:ASPxGridView>
                                       
                                        <dx:ASPxGridViewExporter ID="ASPxGridViewExporter2" runat="server" ExportedRowType="All" GridViewID="GridProyectoContrato">
                                        </dx:ASPxGridViewExporter>
                                        <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" ExportedRowType="All" GridViewID="GridProyectoContratoResumen">
                                        </dx:ASPxGridViewExporter>
                                    </td>
                                 </tr>
                              
                                </table>
                            </dx:ContentControl>
			        </ContentCollection>
		        </dx:TabPage>                                             
            </TabPages>
        </dx:ASPxPageControl>     
        </asp:Panel>

</asp:Content>

                                        
                                
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style4 {
            margin-top: 24px;
        }
    </style>
    
</asp:Content>