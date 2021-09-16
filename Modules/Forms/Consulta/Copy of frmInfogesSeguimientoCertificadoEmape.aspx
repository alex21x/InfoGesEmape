<%@ Page Language="C#" MasterPageFile="~/Modules/MasterPage.Master" AutoEventWireup="true" 
    CodeBehind="frmInfogesSeguimientoCertificadoEmape.aspx.cs" Inherits="InfoGesRegional.Modules.Forms.Consulta.frmDinamicaSiaf" 
    Title="InfoGesConsultas" %>

<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<%@ Register Assembly="DevExpress.Xpo.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Xpo" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Data.Linq" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style4
        {
            width: 309px;
        }
        .style5
        {
            width: 168px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
      <script type="text/javascript">

       </script>



     <div id="principal" >

<table>
<tr>
<td>
<table>
<tr>
<td class="style19">
<dx:ASPxTabControl ID="ASPxTabControleJEjecutora" runat="server" AutoPostBack="True"  Font-Size="Small"
        DataSourceID="XmlDataSource2"    EnableHierarchyRecreation="True"
        OnActiveTabChanged="ASPxPageControl1_ActiveTabChanged1" 
        ActiveTabStyle-Font-Size="Large" TabStyle-Wrap="True" Width="248px" 
          >
<Paddings Padding="0" />

<ActiveTabStyle Font-Size="Large" Wrap="True"></ActiveTabStyle>

<TabStyle Wrap="True"></TabStyle>
    </dx:ASPxTabControl>
<asp:XmlDataSource ID="XmlDataSource2" runat="server" DataFile=""  XPath="//ejecutora" EnableCaching="false"></asp:XmlDataSource>
</td>
</tr>
<tr>
<td align="right">
<dx:ASPxTabControl ID="tcDemos" runat="server" DataSourceID="XmlDataSource1"  AutoPostBack="true" 
        OnActiveTabChanged="ASPxPageControl1_ActiveTabChanged"   EnableHierarchyRecreation="True"  Font-Size="Large"
        ActiveTabStyle-Font-Size="X-Large" TabIndex="0"  
           RightToLeft="True" EnableTabScrolling="true"
        Width="1200px">
<Paddings Padding="0" />
    </dx:ASPxTabControl>
<asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile=""  XPath="//product"  EnableCaching="false"></asp:XmlDataSource>
</td>
</tr></table>
</td>
</tr>
<tr>
<td>

        <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" AutoPostBack="true"
            ActiveTabIndex="0" Height="300%" TabSpacing="3px"  Font-Size="X-Small" Width="100%" >
	        <ContentStyle VerticalAlign="Top">
	        <Border BorderColor="#AECAF0" BorderStyle="Solid" BorderWidth="1px" />
            <Border BorderStyle="Solid" BorderColor="#AECAF0" BorderWidth="1px"></Border>
	        </ContentStyle>     
	        <ActiveTabStyle Font-Bold="True" Font-Size="Small">
	        </ActiveTabStyle>                        
	        <TabPages >   
		        <dx:TabPage Text="CONTROL DE CERTIFICADOS PRESUPUESTARIOS" >
			        <ContentCollection>
				        <dx:ContentControl ID="ContentControl13" runat="server">	


                            <table>
                                <tr align="left">
                                <td>
                                    <table><tr>
                                    <td style="padding-right: 4px">
                                                    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Exportar  XLS" UseSubmitBehavior="False"  Font-Size="X-Small"
                                                        OnClick="btnXlsExport_Click1"/></td>
                                    <td><dx:ASPxButton runat="server" ID="ASPxButton2" Text="Collapse All Rows" UseSubmitBehavior="false" OnCheckedChanged="chkSingleCollapse_CheckedChanged"
                                        AutoPostBack="false"  Font-Size="X-Small">
                                        <ClientSideEvents Click="function(s, e) { AspxgridviewCertificadoxIdClasificador.CollapseAllDetailRows(); }" />
                                    </dx:ASPxButton>
                                    </td>
                                    <td>
                                    <dx:ASPxButton runat="server" ID="ASPxButton3" Text="Expand All Rows" UseSubmitBehavior="false" OnCheckedChanged="chkSingleExpanded_CheckedChanged"
                                        AutoPostBack="false"  Font-Size="X-Small">
                                        <ClientSideEvents Click="function(s, e) { AspxgridviewCertificadoxIdClasificador.ExpandAllDetailRows(); }" />
                                    </dx:ASPxButton>
                                    </td>

                                    </tr>
                                    </table>

                                </td>
                                </tr>
                                <tr>
                                    <td colspan="3">

                                            <dx:aspxgridview ID="AspxgridviewCertificadoxIdClasificador" EnableRowsCache="false"
                                                        ClientInstanceName="AspxgridviewCertificadoxIdClasificador" OnAfterPerformCallback="grid_AfterPerformCallback"
                                                        runat="server"  KeyFieldName="KEY1"
                                                        AutoGenerateColumns="False" 
                                                        DataSourceID="XpoDataSource1"
                                                        Font-Size="X-Small"
                                                        Width="100%" >

                                                <TotalSummary>
                                                    <dx:ASPxSummaryItem FieldName="CERTIFICADO" SummaryType="Count"/>
                                                    <dx:ASPxSummaryItem FieldName="SEC_FUNC" SummaryType="Count"/>
                                                    <dx:ASPxSummaryItem FieldName="MONTO_CERTIFICADO" SummaryType="Sum" DisplayFormat="c"/>
                                                    <dx:ASPxSummaryItem FieldName="MONTO_COMPROMISO_ANUAL" SummaryType="Sum" DisplayFormat="c"/>
                                                    <dx:ASPxSummaryItem FieldName="COMPROMISO" SummaryType="Sum" DisplayFormat="c"/>
                                                    <dx:ASPxSummaryItem FieldName="DEVENGADO" SummaryType="Sum" DisplayFormat="c"/>
                                                    <dx:ASPxSummaryItem FieldName="GIRADO" SummaryType="Sum" DisplayFormat="c"/>
                                                    <dx:ASPxSummaryItem FieldName="SALDO_CERTIFICADO" SummaryType="Sum" DisplayFormat="c"/>
                                                    <dx:ASPxSummaryItem FieldName="SALDO_COMPROMISO_ANUAL" SummaryType="Sum" DisplayFormat="c"/>
                                                </TotalSummary>

                                                <GroupSummary>
                                                    <dx:ASPxSummaryItem FieldName="MONTO_CERTIFICADO" ShowInGroupFooterColumn="MONTO_CERTIFICADO" SummaryType="Sum" DisplayFormat="c"/>
                                                    <dx:ASPxSummaryItem FieldName="MONTO_COMPROMISO_ANUAL" ShowInGroupFooterColumn="MONTO_COMPROMISO_ANUAL" SummaryType="Sum" DisplayFormat="c"/>
                                                    <dx:ASPxSummaryItem FieldName="COMPROMISO" ShowInGroupFooterColumn="COMPROMISO" SummaryType="Sum" DisplayFormat="c"/>
                                                    <dx:ASPxSummaryItem FieldName="DEVENGADO" ShowInGroupFooterColumn="DEVENGADO" SummaryType="Sum" DisplayFormat="c"/>
                                                    <dx:ASPxSummaryItem FieldName="GIRADO" ShowInGroupFooterColumn="GIRADO" SummaryType="Sum" DisplayFormat="c"/>
                                                    <dx:ASPxSummaryItem FieldName="SALDO_CERTIFICADO" ShowInGroupFooterColumn="SALDO_CERTIFICADO" SummaryType="Sum" DisplayFormat="c"/>
                                                    <dx:ASPxSummaryItem FieldName="SALDO_COMPROMISO_ANUAL" ShowInGroupFooterColumn="SALDO_COMPROMISO_ANUAL" SummaryType="Sum" DisplayFormat="c"/>
                                                </GroupSummary>
                                                <Columns>
                                                    <dx:GridViewDataTextColumn FieldName="GLOSA" VisibleIndex="0"  Caption="TIPO DE SALDO" Width="50%"  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6"   HeaderStyle-Wrap="True"/>
                                                    <dx:GridViewDataTextColumn FieldName="GENERICA_NOMBRE" VisibleIndex="0"  Caption="GENÉRICA" Width="80px"  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6" />
                                                    <dx:GridViewDataTextColumn FieldName="FUENTE_FINANC_NOMBRE" VisibleIndex="0"  Caption="RUBRO" Width="50%"  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6" Settings-AutoFilterCondition="Contains">
                                                        <PropertiesTextEdit>
                                                        <ValidationSettings Display="Dynamic" RequiredField-IsRequired="true" />
                                                        </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                    
                                                    <dx:GridViewDataTextColumn FieldName="CERTIFICADO" VisibleIndex="1"  Caption="CERTIFICADO" Width="50%"  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6"  Settings-AutoFilterCondition="Contains" >
                                                    <DataItemTemplate>
                                                        <dx:ASPxHyperLink ID="hyperLink1" runat="server" OnDataBinding="hyperLink_InitPROYECTOSNIP" Font-Size="XX-Small" >
                                                        </dx:ASPxHyperLink>
                                                    </DataItemTemplate>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="EMAPE_COMPONENTE" VisibleIndex="1"  Caption="COMPONENTE OBRA" Width="50%"  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6"  Settings-AutoFilterCondition="Contains" />
                                                    <dx:GridViewDataTextColumn FieldName="ACT_PROY" VisibleIndex="1"  Caption="PROYECTO" Width="50%"  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6"  Settings-AutoFilterCondition="Contains" />
                                                    <dx:GridViewDataTextColumn FieldName="SEC_FUNCD" VisibleIndex="1"  Caption="SEC.FUNC" Width="80%"  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6"  Settings-AutoFilterCondition="Contains" />
                                                    <dx:GridViewDataTextColumn FieldName="ESPECIFICA_NOMBRE" VisibleIndex="1"  Caption="PARTIDA" Width="70%"  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6"  Settings-AutoFilterCondition="Contains" />
                                                    <dx:GridViewBandColumn Caption="DOCUMENTO" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" >
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn FieldName="COD_DOC"      VisibleIndex="0" Caption="COD."     Width="50%" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" />
                                                        <dx:GridViewDataTextColumn FieldName="NUM_DOC"      VisibleIndex="1" Caption="NUM."     Width="40%" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" />
                                                        <dx:GridViewDataTextColumn FieldName="FECHA_DOC"    VisibleIndex="2" Caption="FECHA"    Width="40%" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains"/>
                                                        <dx:GridViewDataTextColumn FieldName="NOTAS"        VisibleIndex="3" Caption="NOTA"     Width="70%" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains"/>
                                                    </Columns>
                                                        </dx:GridViewBandColumn>
                                                    <dx:GridViewBandColumn Caption="PRESUPUESTO" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="5" >
                                                    <Columns>
                                                        <dx:GridViewBandColumn Caption="CERTIFICADO" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="1" >
                                                            <Columns>
                                                            <dx:GridViewDataColumn Settings-AllowAutoFilter="False"  Settings-AllowHeaderFilter="False" Caption="(a)" FieldName="MONTO_CERTIFICADO" VisibleIndex="3" UnboundType="Decimal" Width="55%"  HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True"/>
                                                            </Columns>
                                                        </dx:GridViewBandColumn>
                                                        <dx:GridViewBandColumn Caption="COMPROMISO ANUAL" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="1" HeaderStyle-Wrap="True" >
                                                            <Columns>
                                                                <dx:GridViewDataTextColumn Settings-AllowAutoFilter="False" PropertiesTextEdit-DisplayFormatString="c"  Settings-AllowHeaderFilter="False" Caption="(b)" FieldName="MONTO_COMPROMISO_ANUAL" VisibleIndex="3" UnboundType="Decimal" Width="55%"  HeaderStyle-HorizontalAlign="Center"/>
                                                            </Columns>
                                                        </dx:GridViewBandColumn>
                                                    </Columns>
                                                    </dx:GridViewBandColumn>
                                                    <dx:GridViewBandColumn Caption="EJECUCION" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center"  VisibleIndex="6"  >
                                                    <Columns>
                                                        <dx:GridViewBandColumn Caption="COMPROMISO" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="1" >
                                                        <Columns>
                                                            <dx:GridViewDataTextColumn Settings-AllowAutoFilter="False"  Settings-AllowHeaderFilter="False" Caption="(c)" FieldName="COMPROMISO"  PropertiesTextEdit-DisplayFormatString="c" VisibleIndex="1" UnboundType="Decimal" Width="60%"  HeaderStyle-HorizontalAlign="Center"/>
                                                        </Columns>
                                                        </dx:GridViewBandColumn>
                                                        <dx:GridViewBandColumn Caption="DEVENGADO" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="1" >
                                                            <Columns>
                                                                <dx:GridViewDataTextColumn Settings-AllowAutoFilter="False"  Settings-AllowHeaderFilter="False" Caption="(d)" FieldName="DEVENGADO" VisibleIndex="2" UnboundType="Decimal"  Width="55%"  HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-DisplayFormatString="c"/>
                                                            </Columns>
                                                        </dx:GridViewBandColumn>
                                                        <dx:GridViewBandColumn Caption="GIRADO" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="1" >
                                                        <Columns>
                                                            <dx:GridViewDataTextColumn Settings-AllowAutoFilter="False"  Settings-AllowHeaderFilter="False" Caption="(e)" FieldName="GIRADO" VisibleIndex="2" UnboundType="Decimal" Width="55%"  HeaderStyle-HorizontalAlign="Center"  PropertiesTextEdit-DisplayFormatString="c"/>
                                                        </Columns>
                                                        </dx:GridViewBandColumn>
                                                    </Columns>
                                                    </dx:GridViewBandColumn>
                                                    <dx:GridViewBandColumn Caption="SALDO" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center"  VisibleIndex="7" >
                                                    <Columns>
                                                        <dx:GridViewBandColumn Caption="(a) - (b)" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="1" >
                                                        <Columns>
                                                        <dx:GridViewDataTextColumn Settings-AllowAutoFilter="False"  Settings-AllowHeaderFilter="False" Caption="CERTIFICADO" FieldName="SALDO_CERTIFICADO" VisibleIndex="2" UnboundType="Decimal" Width="50%"  HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-DisplayFormatString="c"/>
                                                        </Columns>
                                                        </dx:GridViewBandColumn>
                                                        <dx:GridViewBandColumn Caption="(b) - (c)" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="1" >
                                                        <Columns>
                                                            <dx:GridViewDataTextColumn Settings-AllowAutoFilter="False"  Settings-AllowHeaderFilter="False" Caption="COMPROMISO ANUAL" FieldName="SALDO_COMPROMISO_ANUAL" VisibleIndex="2" UnboundType="Decimal"  Width="50%"  HeaderStyle-HorizontalAlign="Center"  HeaderStyle-Wrap="True" PropertiesTextEdit-DisplayFormatString="c"/>
                                                        </Columns>
                                                        </dx:GridViewBandColumn>
                                                    </Columns>
                                                    </dx:GridViewBandColumn>

                                                    <dx:GridViewDataTextColumn FieldName="ESTADO_REGISTRO" VisibleIndex="8" Caption="ER" Width="20%" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains"/>
                                                    <dx:GridViewDataTextColumn FieldName="ESTADO_ENVIO" VisibleIndex="9" Caption="EE" Width="20%" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains"/>
                                                    </Columns>

                                                <Templates>
                                                    <DetailRow>

                                                    <dx:aspxgridview ID="AspxgridviewExpedienteXCertificado"  
                                                        ClientInstanceName="AspxgridviewExpedienteXCertificado" 
                                                        runat="server" OnBeforePerformDataSelect="detailGrid_BeforePerformDataSelect"
                                                        AutoGenerateColumns="False" 
                                                        Font-Size="X-Small"
                                                        Width="100%">
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn FieldName="EXPEDIENTE" VisibleIndex="0"  Caption="EXPEDIENTE" Width="60px"  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6" Settings-AutoFilterCondition="Contains" />
                                                        <dx:GridViewDataTextColumn FieldName="EXPEDIENTE_SECUENCIA" VisibleIndex="1"  Caption="SECUENCIA" Width="50px"  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6" Settings-AutoFilterCondition="Contains" />
                                                        <dx:GridViewDataTextColumn FieldName="EXPEDIENTE_CORRELATIVO" VisibleIndex="2"  Caption="CORRELATIVO" Width="50px"  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6" Settings-AutoFilterCondition="Contains" />
                                                        <dx:GridViewDataTextColumn FieldName="CICLO" VisibleIndex="3"  Caption="CICLO" Width="40px"  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6" />
                                                        <dx:GridViewDataTextColumn FieldName="FASE" VisibleIndex="3"  Caption="FASE" Width="40px"  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6" />
                                                        <dx:GridViewDataTextColumn FieldName="ACT_PROY" VisibleIndex="4"  Caption="PROYECTO" Width="200px"  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6" />
                                                        <dx:GridViewDataTextColumn FieldName="FUENTE_FINANC" VisibleIndex="4"  Caption="RUBRO" Width="120px"  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6" />
                                                        <dx:GridViewDataTextColumn FieldName="TIPO_OPERACION" VisibleIndex="5"  Caption="TO" Width="30px"  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6" />
                                                        <dx:GridViewBandColumn Caption="DOCUMENTO A" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="6">
                                                            <Columns>
                                                                <dx:GridViewDataTextColumn Settings-AllowHeaderFilter="False" FieldName="COD_DOC" VisibleIndex="1" Caption="COD." Width="30px" HeaderStyle-HorizontalAlign="Center"  Settings-AutoFilterCondition="Contains"/> 
                                                                <dx:GridViewDataTextColumn FieldName="NUM_DOC" VisibleIndex="2" Caption="NUM." Width="40px" HeaderStyle-HorizontalAlign="Center"  Settings-AutoFilterCondition="Contains"/>
                                                                <dx:GridViewDataTextColumn FieldName="FECHA_DOC" VisibleIndex="3" Caption="FECHA" Width="40px" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains"/>
                                                            </Columns>
                                                        </dx:GridViewBandColumn>
                                                        <dx:GridViewDataTextColumn Settings-AllowHeaderFilter="False" FieldName="DOCUMENTOB" VisibleIndex="7" Caption="DOCUMENTO B" Width="300px" HeaderStyle-HorizontalAlign="Center"  Settings-AutoFilterCondition="Contains"/> 
                                                        <dx:GridViewDataTextColumn  FieldName="SEC_FUNC" VisibleIndex="10"   Caption="SEC. FUNC" Width="30px" HeaderStyle-HorizontalAlign="Center"  HeaderStyle-Wrap="True" />
                                                        <dx:GridViewDataTextColumn  FieldName="NOMBRE_RUC" VisibleIndex="11"   Caption=" NOMBRE" Width="200px" HeaderStyle-HorizontalAlign="Center"  HeaderStyle-Wrap="True" Settings-AllowDragDrop="False" Settings-AllowSort="False" Settings-AutoFilterCondition="Contains"/>
                                                        <dx:GridViewDataTextColumn  FieldName="NOTAS" VisibleIndex="12"   Caption="NOTAS" Width="300px" HeaderStyle-HorizontalAlign="Center"  HeaderStyle-Wrap="True" Settings-AllowDragDrop="False" Settings-AllowSort="False" Settings-AutoFilterCondition="Contains"/>
                                                        <dx:GridViewDataTextColumn  FieldName="EJECUCION" VisibleIndex="13" UnboundType="Decimal"  Caption="EJECUCION" Width="150px" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-DisplayFormatString="c" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"/>
                                                        </Columns>
                                                        <Settings ShowFooter="True" ShowTitlePanel="true"  />
                                                        <SettingsText Title="CONSULTA EXPEDIENTE"  />
                                                        <Styles  >
                                                            <CommandColumn Paddings-Padding="1">
                                                                <Paddings Padding="1px" />
                                                            </CommandColumn>
                                                        </Styles>
                                                    </dx:aspxgridview> 


                                                    </DetailRow>                
                                                </Templates>
                                                <SettingsBehavior AllowFocusedRow="True" />
                                                <SettingsDetail ShowDetailRow="true" />
                                                <SettingsText Title="CERTIFICADO X ESPECIFICA"  />
                                            </dx:aspxgridview> 
                                            <dx:ASPxGridViewExporter ID="gridExport1" runat="server" GridViewID="AspxgridviewCertificadoxIdClasificador"></dx:ASPxGridViewExporter>

                                            </td>
                                            </tr>
                            </table>
 


				        </dx:ContentControl>
			        </ContentCollection>
		        </dx:TabPage> 

		        <dx:TabPage Text="CONTROL POR META" >
			        <ContentCollection>
				        <dx:ContentControl ID="ContentControl1" runat="server">	

                        <table>
                        <tr>
                        <td>
                        <table>
                        <tr>
                        <td style="padding-right: 4px"> <dx:ASPxButton ID="btnXlsExport" runat="server" Text="Exportar  XLS" UseSubmitBehavior="False" OnClick="btnXlsExport_Click" /></td>
                        <td><dx:ASPxButton runat="server" ID="btnCollapse" Text="Collapse All Rows" UseSubmitBehavior="false" AutoPostBack="false">
                            <ClientSideEvents Click="function() { ASPxGridInfoGesxMeta.CollapseAll() }" />
                        </dx:ASPxButton> </td>
                        <td><dx:ASPxButton runat="server" ID="btnExpand" Text="Expand All Rows" UseSubmitBehavior="false" AutoPostBack="false">
                            <ClientSideEvents Click="function() { ASPxGridInfoGesxMeta.ExpandAll() }" />
                        </dx:ASPxButton> </td>                        

                        </tr>
                        </table>
                        </td>

                        </tr>
                        <tr>
                        <td>
                        <dx:aspxgridview ID="ASPxGridInfoGesxMeta"  ClientInstanceName="ASPxGridInfoGesxMeta"  DataSourceID="XpoDataSource2"  OnAfterPerformCallback="grid_AfterPerformCallback1"
                            runat="server"    KeyFieldName="CADENAKEY" AutoGenerateColumns="False" Font-Size="X-Small" Width="1320px"
                            OnCustomUnboundColumnData="grid_CustomUnboundColumnData" OnHeaderFilterFillItems="grid_HeaderFilterFillItems" >
                            <Settings ShowGroupPanel="True" ShowFooter="True" ShowHeaderFilterButton="true" ShowGroupFooter="VisibleAlways" ShowVerticalScrollBar="True" VerticalScrollableHeight="400" />
                            <TotalSummary>
                                <dx:ASPxSummaryItem FieldName="SEC_FUNC" SummaryType="Count"/>
                                <dx:ASPxSummaryItem FieldName="PIA" SummaryType="Sum" DisplayFormat="c" />
                                <dx:ASPxSummaryItem FieldName="PIM" SummaryType="Sum" DisplayFormat="c"/>
                                <dx:ASPxSummaryItem FieldName="CERTIFICADO" SummaryType="Sum" DisplayFormat="c"/>
                                <dx:ASPxSummaryItem FieldName="COMPROMISO_ANUAL" SummaryType="Sum" DisplayFormat="c"/>
                                <dx:ASPxSummaryItem FieldName="COMPROMISO" SummaryType="Sum" DisplayFormat="c"/>
                                <dx:ASPxSummaryItem FieldName="DEVENGADO" SummaryType="Sum" DisplayFormat="c"/>
                                <dx:ASPxSummaryItem FieldName="GIRADO" SummaryType="Sum" DisplayFormat="c"/>
                                <dx:ASPxSummaryItem FieldName="SALDO_MARCO" SummaryType="Sum" DisplayFormat="c"/>
                                <dx:ASPxSummaryItem FieldName="SALDO_COMPROMISO_ANUAL" SummaryType="Sum" DisplayFormat="c"/>
                                <dx:ASPxSummaryItem FieldName="SALDO_COMPROMISO" SummaryType="Sum" DisplayFormat="c"/>
                                <dx:ASPxSummaryItem FieldName="SALDO_DEVENGADO" SummaryType="Sum" DisplayFormat="c"/>
                            </TotalSummary>
                            <GroupSummary>
                                <dx:ASPxSummaryItem FieldName="PIA" ShowInGroupFooterColumn="PIA" SummaryType="Sum" DisplayFormat="{0:c}" />
                                <dx:ASPxSummaryItem FieldName="PIM" ShowInGroupFooterColumn="PIM" SummaryType="Sum" DisplayFormat="c"/>
                                <dx:ASPxSummaryItem FieldName="CERTIFICADO" ShowInGroupFooterColumn="CERTIFICADO" SummaryType="Sum" DisplayFormat="c"/>
                                <dx:ASPxSummaryItem FieldName="COMPROMISO_ANUAL" ShowInGroupFooterColumn="COMPROMISO_ANUAL" SummaryType="Sum" DisplayFormat="c"/>
                                <dx:ASPxSummaryItem FieldName="COMPROMISO" ShowInGroupFooterColumn="COMPROMISO" SummaryType="Sum" DisplayFormat="c"/>
                                <dx:ASPxSummaryItem FieldName="DEVENGADO" ShowInGroupFooterColumn="DEVENGADO" SummaryType="Sum" DisplayFormat="c"/>
                                <dx:ASPxSummaryItem FieldName="GIRADO" ShowInGroupFooterColumn="GIRADO" SummaryType="Sum" DisplayFormat="c"/>
                                <dx:ASPxSummaryItem FieldName="SALDO_CERTIFICADO" ShowInGroupFooterColumn="SALDO_CERTIFICADO" SummaryType="Sum" DisplayFormat="c"/>
                                <dx:ASPxSummaryItem FieldName="SALDO_COMPROMISO_ANUAL" ShowInGroupFooterColumn="SALDO_COMPROMISO_ANUAL" SummaryType="Sum" DisplayFormat="c"/>
                                <dx:ASPxSummaryItem FieldName="SALDO_COMPROMISO" ShowInGroupFooterColumn="SALDO_COMPROMISO" SummaryType="Sum" DisplayFormat="c"/>
                                <dx:ASPxSummaryItem FieldName="SALDO_DEVENGADO" ShowInGroupFooterColumn="SALDO_DEVENGADO" SummaryType="Sum" DisplayFormat="c"/>
                            </GroupSummary>
                                                 
                                                  
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="GLOSA" VisibleIndex="0"  Caption="TIPO DE SALDO" Width="60px"  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6"   HeaderStyle-Wrap="True"/>
                                <dx:GridViewDataTextColumn FieldName="GENERICA_NOMBRE" VisibleIndex="0"  Caption="GENÉRICA" Width="80px"  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6"/>
                                <dx:GridViewDataTextColumn FieldName="SEC_FUNC" VisibleIndex="0"  Caption="META" Width="200px"  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6"    Settings-AutoFilterCondition="Contains"/> 
                                <dx:GridViewDataTextColumn FieldName="ACT_PROY" VisibleIndex="0"  Caption="PROYECTO" Width="100px"  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6"    Settings-AutoFilterCondition="Contains"/> 
                                <dx:GridViewDataTextColumn FieldName="PROGRAMA_NOMBRE" VisibleIndex="0"  Caption="PROGRAMA" Width="100px"  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6"    Settings-AutoFilterCondition="Contains"/> 
                                <dx:GridViewDataTextColumn FieldName="ESPECIFICA_DET_NOMBRE" VisibleIndex="0"  Caption="ESPECIFICA" Width="130px"  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6"    Settings-AutoFilterCondition="Contains"/> 
                                <dx:GridViewDataTextColumn FieldName="FUENTE_FINANC_NOMBRE" VisibleIndex="1"  Caption="RUBRO" Width="100px"  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6"/>

                                <dx:GridViewBandColumn Caption="MARCO DE GASTO" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" >
                                    <Columns>
                                        <dx:GridViewDataTextColumn Settings-AllowHeaderFilter="False" FieldName="PIA" VisibleIndex="3" UnboundType="Decimal"  Caption="PIA" Width="100px"  HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-DisplayFormatString="c"/>
                                        <dx:GridViewDataTextColumn Settings-AllowHeaderFilter="False" FieldName="PIM" VisibleIndex="5" UnboundType="Decimal"  Caption="PIM" Width="100px"  HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-DisplayFormatString="c"/>
                                    </Columns>
                                </dx:GridViewBandColumn>
                                <dx:GridViewBandColumn Caption="EJECUCION" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" >
                                    <Columns>
                                    <dx:GridViewDataTextColumn Settings-AllowHeaderFilter="False" Settings-AllowAutoFilter="False" VisibleIndex="6"  UnboundType="Decimal"  Width="100px" HeaderStyle-HorizontalAlign="Center"   PropertiesTextEdit-DisplayFormatString="c" HeaderStyle-Wrap="True" FieldName="CERTIFICADO"         Caption="CERTIFICADO"      />
                                    <dx:GridViewDataTextColumn Settings-AllowHeaderFilter="False" Settings-AllowAutoFilter="False" VisibleIndex="7"  UnboundType="Decimal"  Width="100px" HeaderStyle-HorizontalAlign="Center"   PropertiesTextEdit-DisplayFormatString="c" HeaderStyle-Wrap="True" FieldName="COMPROMISO_ANUAL"    Caption="COMPROMISO ANUAL" />
                                    <dx:GridViewDataTextColumn Settings-AllowHeaderFilter="False" Settings-AllowAutoFilter="False" VisibleIndex="8"  UnboundType="Decimal"  Width="100px" HeaderStyle-HorizontalAlign="Center"   PropertiesTextEdit-DisplayFormatString="c" HeaderStyle-Wrap="True" FieldName="COMPROMISO"          Caption="COMPROMISO"/>
                                    <dx:GridViewDataTextColumn Settings-AllowHeaderFilter="False" Settings-AllowAutoFilter="False" VisibleIndex="9"  UnboundType="Decimal"  Width="100px" HeaderStyle-HorizontalAlign="Center"   PropertiesTextEdit-DisplayFormatString="c" HeaderStyle-Wrap="True" FieldName="DEVENGADO"           Caption="DEVENGADO"  />
                                    <dx:GridViewDataTextColumn Settings-AllowHeaderFilter="False" Settings-AllowAutoFilter="False" VisibleIndex="10" UnboundType="Decimal"  Width="100px" HeaderStyle-HorizontalAlign="Center"   PropertiesTextEdit-DisplayFormatString="c" HeaderStyle-Wrap="True" FieldName="GIRADO"              Caption="GIRADO" />
                                    </Columns>
                                </dx:GridViewBandColumn>
                                <dx:GridViewBandColumn Caption="SALDO" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" >
                                    <Columns>
                                    <dx:GridViewDataTextColumn Settings-AllowHeaderFilter="False" Settings-AllowAutoFilter="False" VisibleIndex="11" UnboundType="Decimal" Width="100px" HeaderStyle-HorizontalAlign="Center"   PropertiesTextEdit-DisplayFormatString="c" HeaderStyle-Wrap="True" FieldName="SALDO_MARCO"   Caption="CERTIFICADO."/>
                                    <dx:GridViewDataTextColumn Settings-AllowHeaderFilter="False" Settings-AllowAutoFilter="False" VisibleIndex="12" UnboundType="Decimal" Width="100px" HeaderStyle-HorizontalAlign="Center"   PropertiesTextEdit-DisplayFormatString="c" HeaderStyle-Wrap="True" FieldName="SALDO_COMPROMISO_ANUAL"  Caption="COMPROMISO ANUAL."/>
                                    <dx:GridViewDataTextColumn Settings-AllowHeaderFilter="False" Settings-AllowAutoFilter="False" VisibleIndex="13" UnboundType="Decimal" Width="100px" HeaderStyle-HorizontalAlign="Center"   PropertiesTextEdit-DisplayFormatString="c" HeaderStyle-Wrap="True" FieldName="SALDO_COMPROMISO" Caption="COMPROMISO."/>
                                    <dx:GridViewDataTextColumn Settings-AllowHeaderFilter="False" Settings-AllowAutoFilter="False" VisibleIndex="14" UnboundType="Decimal" Width="100px" HeaderStyle-HorizontalAlign="Center"   PropertiesTextEdit-DisplayFormatString="c" HeaderStyle-Wrap="True" FieldName="SALDO_DEVENGADO"  Caption="DEVENGADO."/>
                                    </Columns>
                                </dx:GridViewBandColumn>
                                </Columns>


                                <Templates>
                                <DetailRow>


                                <dx:aspxgridview ID="AspxgridviewCertificadoxIdClasificador1" ClientInstanceName="AspxgridviewCertificadoxIdClasificador1" runat="server"  KeyFieldName="CADENAKEY" AutoGenerateColumns="False" Font-Size="X-Small" Width="100%">

                                <TotalSummary>
                                    <dx:ASPxSummaryItem FieldName="CERTIFICADO" SummaryType="Count"/>
                                    <dx:ASPxSummaryItem FieldName="SEC_FUNC" SummaryType="Count"/>
                                    <dx:ASPxSummaryItem FieldName="MONTO_CERTIFICADO" SummaryType="Sum" DisplayFormat="c"/>
                                    <dx:ASPxSummaryItem FieldName="MONTO_COMPROMISO_ANUAL" SummaryType="Sum" DisplayFormat="c"/>
                                    <dx:ASPxSummaryItem FieldName="COMPROMISO" SummaryType="Sum" DisplayFormat="c"/>
                                    <dx:ASPxSummaryItem FieldName="DEVENGADO" SummaryType="Sum" DisplayFormat="c"/>
                                    <dx:ASPxSummaryItem FieldName="GIRADO" SummaryType="Sum" DisplayFormat="c"/>
                                    <dx:ASPxSummaryItem FieldName="SALDO_CERTIFICADO" SummaryType="Sum" DisplayFormat="c"/>
                                    <dx:ASPxSummaryItem FieldName="SALDO_COMPROMISO_ANUAL" SummaryType="Sum" DisplayFormat="c"/>
                                </TotalSummary>

                                <GroupSummary>
                                    <dx:ASPxSummaryItem FieldName="MONTO_CERTIFICADO" ShowInGroupFooterColumn="MONTO_CERTIFICADO" SummaryType="Sum" DisplayFormat="c"/>
                                    <dx:ASPxSummaryItem FieldName="MONTO_COMPROMISO_ANUAL" ShowInGroupFooterColumn="MONTO_COMPROMISO_ANUAL" SummaryType="Sum" DisplayFormat="c"/>
                                    <dx:ASPxSummaryItem FieldName="COMPROMISO" ShowInGroupFooterColumn="COMPROMISO" SummaryType="Sum" DisplayFormat="c"/>
                                    <dx:ASPxSummaryItem FieldName="DEVENGADO" ShowInGroupFooterColumn="DEVENGADO" SummaryType="Sum" DisplayFormat="c"/>
                                    <dx:ASPxSummaryItem FieldName="GIRADO" ShowInGroupFooterColumn="GIRADO" SummaryType="Sum" DisplayFormat="c"/>
                                    <dx:ASPxSummaryItem FieldName="SALDO_CERTIFICADO" ShowInGroupFooterColumn="SALDO_CERTIFICADO" SummaryType="Sum" DisplayFormat="c"/>
                                    <dx:ASPxSummaryItem FieldName="SALDO_COMPROMISO_ANUAL" ShowInGroupFooterColumn="SALDO_COMPROMISO_ANUAL" SummaryType="Sum" DisplayFormat="c"/>
                                </GroupSummary>
                                                 
                                                  
                                <Columns>
                                    <dx:GridViewDataTextColumn FieldName="GLOSA" VisibleIndex="0" Visible="false" Caption="TIPO DE SALDO DE CERTIFICADO" Width="60%" HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6"   HeaderStyle-Wrap="True" />
                                    <dx:GridViewDataTextColumn FieldName="FUENTE_FINANC_NOMBRE" VisibleIndex="0"  Caption="RUBRO" Width="50%"  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6" Settings-AutoFilterCondition="Contains" />

                                    <dx:GridViewDataTextColumn FieldName="CERTIFICADO" VisibleIndex="1"  Caption="CERTIFI" Width="50%"  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6"  Settings-AutoFilterCondition="Contains" >
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <CellStyle BackColor="#FFFFD6"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="ACT_PROY" VisibleIndex="1"  Caption="PROYECTO" Width="60%"  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6"  Settings-AutoFilterCondition="Contains" >
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <CellStyle BackColor="#FFFFD6"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewBandColumn Caption="DOCUMENTO" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" >
                                        <Columns>
                                        <dx:GridViewDataTextColumn FieldName="COD_DOC"   VisibleIndex="0" Caption="COD." Width="50%"  HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains"/>
                                        <dx:GridViewDataTextColumn FieldName="NUM_DOC"   VisibleIndex="1" Caption="NUM." Width="40%"  HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains"/>
                                        <dx:GridViewDataTextColumn FieldName="FECHA_DOC" VisibleIndex="2" Caption="FECHA" Width="50%" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains"/>
                                        <dx:GridViewDataTextColumn FieldName="NOTAS"     VisibleIndex="3" Caption="NOTA" Width="50%"  HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains"/>
                                        </Columns>
                                    </dx:GridViewBandColumn>

                                    <dx:GridViewDataTextColumn FieldName="SEC_FUNCD" VisibleIndex="3"  Caption="SEC.FUNC" Width="80%"  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6"  Settings-AutoFilterCondition="Contains" />
                                    <dx:GridViewDataTextColumn FieldName="ESPECIFICA_NOMBRE" VisibleIndex="4"  Caption="PARTIDA" Width="70%"  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6"  Settings-AutoFilterCondition="Contains"/>
                                    <dx:GridViewBandColumn Caption="PRESUPUESTO" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="5" >
                                    <Columns>
                                        <dx:GridViewBandColumn Caption="CERTIFICADO" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="1" >
                                            <Columns>
                                            <dx:GridViewDataTextColumn Settings-AllowAutoFilter="False"  Settings-AllowHeaderFilter="False" Caption="(a)" FieldName="MONTO_CERTIFICADO" VisibleIndex="3" UnboundType="Decimal" Width="55%"  HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True" PropertiesTextEdit-DisplayFormatString="c"/>
                                            </Columns>
                                        </dx:GridViewBandColumn>
                                        <dx:GridViewBandColumn Caption="COMPROMISO ANUAL" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="1" HeaderStyle-Wrap="True" >
                                            <Columns>
                                            <dx:GridViewDataTextColumn Settings-AllowAutoFilter="False"  Settings-AllowHeaderFilter="False" Caption="(b)" FieldName="MONTO_COMPROMISO_ANUAL" VisibleIndex="3" UnboundType="Decimal" Width="55%"  HeaderStyle-HorizontalAlign="Center"  PropertiesTextEdit-DisplayFormatString="c"/>
                                            </Columns>
                                        </dx:GridViewBandColumn>
                                    </Columns>
                                    </dx:GridViewBandColumn>

                                    <dx:GridViewBandColumn Caption="EJECUCION" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center"  VisibleIndex="6"  >
                                    <Columns>
                                        <dx:GridViewBandColumn Caption="COMPROMISO" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="1" >
                                        <Columns>
                                            <dx:GridViewDataTextColumn Settings-AllowAutoFilter="False"  Settings-AllowHeaderFilter="False" Caption="(c)" FieldName="COMPROMISO" VisibleIndex="1" UnboundType="Decimal" Width="60%"  HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-DisplayFormatString="c"/>
                                        </Columns>
                                        </dx:GridViewBandColumn>
                                        <dx:GridViewBandColumn Caption="DEVENGADO" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="1" >
                                        <Columns>
                                            <dx:GridViewDataTextColumn Settings-AllowAutoFilter="False"  Settings-AllowHeaderFilter="False" Caption="(d)" FieldName="DEVENGADO" VisibleIndex="2" UnboundType="Decimal"  Width="55%"  HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-DisplayFormatString="c"/>
                                        </Columns>
                                        </dx:GridViewBandColumn>
                                        <dx:GridViewBandColumn Caption="GIRADO" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="1" >
                                        <Columns>
                                            <dx:GridViewDataTextColumn Settings-AllowAutoFilter="False"  Settings-AllowHeaderFilter="False" Caption="(e)" FieldName="GIRADO" VisibleIndex="2" UnboundType="Decimal" Width="55%"  HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-DisplayFormatString="c"/>
                                        </Columns>
                                        </dx:GridViewBandColumn>
                                    </Columns>
                                    </dx:GridViewBandColumn>

                                    <dx:GridViewBandColumn Caption="SALDO" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center"  VisibleIndex="7" >
                                    <Columns>
                                        <dx:GridViewBandColumn Caption="(a) - (b)" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="1" >
                                        <Columns>
                                        <dx:GridViewDataTextColumn Settings-AllowAutoFilter="False"  Settings-AllowHeaderFilter="False" Caption="CERTIFICADO" FieldName="SALDO_CERTIFICADO" VisibleIndex="2" UnboundType="Decimal" Width="55%"  HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-DisplayFormatString="c"/>
                                        </Columns>
                                        </dx:GridViewBandColumn>
                                        <dx:GridViewBandColumn Caption="(b) - (e)" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="1" >
                                        <Columns>
                                            <dx:GridViewDataTextColumn Settings-AllowAutoFilter="False"  Settings-AllowHeaderFilter="False" Caption="COMPROMISO ANUAL" FieldName="SALDO_COMPROMISO_ANUAL" VisibleIndex="2" UnboundType="Decimal"  Width="55%"  HeaderStyle-HorizontalAlign="Center"  HeaderStyle-Wrap="True" PropertiesTextEdit-DisplayFormatString="c"/>
                                        </Columns>
                                        </dx:GridViewBandColumn>
                                    </Columns>
                                    </dx:GridViewBandColumn>

                                    <dx:GridViewDataTextColumn FieldName="ESTADO_REGISTRO" VisibleIndex="8" Caption="ER" Width="20%" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains"/>
                                    <dx:GridViewDataTextColumn FieldName="ESTADO_ENVIO" VisibleIndex="9" Caption="EE" Width="20%" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains"/>
                                    </Columns>
                                    <Settings ShowFooter="True" ShowFilterRow="True" 
                                        ShowHeaderFilterButton="true" ShowTitlePanel="true"  
                                        ShowVerticalScrollBar="True" VerticalScrollableHeight="400" />
                                    <SettingsDetail ShowDetailRow="true" ExportMode="Expanded"/>
                                    <SettingsPager Mode="ShowPager" PageSize="60"></SettingsPager>
                                    <Settings ShowFilterBar="Visible" />
                                    <SettingsText Title="CERTIFICADO X ESPECIFICA"  />
                                                 
                                                 
                                        <Styles>
                                            <CommandColumn Paddings-Padding="1">
                                                <Paddings Padding="1px" />
                                            </CommandColumn>
                                        </Styles>

                                </dx:aspxgridview> 

                                </DetailRow>
                                </Templates>

                                <Settings ShowFilterBar="Visible" HorizontalScrollBarMode="Auto" />    
                                <SettingsPager Mode="ShowPager" PageSize="30"></SettingsPager>
                                <Settings ShowFilterRow="True" ShowTitlePanel="true"   />
                                <SettingsText Title="CONSULTA META X RUBRO X  GENERICA"  />
                                <SettingsDetail ShowDetailRow="true" ExportMode="Expanded"/>
                                         
                                <Styles>
                                    <CommandColumn Paddings-Padding="1">
                                        <Paddings Padding="1px" />
                                    </CommandColumn>
                                </Styles>

                        </dx:aspxgridview> 
                        <dx:ASPxGridViewExporter ID="gridExport" runat="server" GridViewID="ASPxGridInfoGesxMeta"></dx:ASPxGridViewExporter>
                        </td>
                        </tr>
                        </table>


				        </dx:ContentControl>
			        </ContentCollection>
		        </dx:TabPage>                       
            </TabPages>
        </dx:ASPxPageControl>   
</td>
</tr>
</table>
<dx:XpoDataSource ID="XpoDataSource1" runat="server" 
             TypeName="PersistenObjectsCertificado.infoges_control_certificado" 
             ServerMode="true" >

</dx:XpoDataSource>
<dx:XpoDataSource ID="XpoDataSource11" runat="server" 
             TypeName="PersistenObjects.infoges_exp" ServerMode="true" 
             DefaultSorting="EXPEDIENTE" 
             Criteria="[ANO_EJE] = '?' And [SEC_EJEC] = '?' And [CERTIFICADO] = '?'" >
    <CriteriaParameters>
        <asp:SessionParameter Name="newparameter" SessionField="pAnoEje" />
        <asp:SessionParameter Name="newparameter" SessionField="pSecEjec" />
        <asp:SessionParameter Name="newparameter" SessionField="pCertificado" />
    </CriteriaParameters>
</dx:XpoDataSource>
<dx:XpoDataSource ID="XpoDataSource2" runat="server"  Criteria = "[ANO_EJE] = ? AND [SEC_EJEC] = ?" TypeName="PersistenObjectsCertificado.infoges_control_certificado" ServerMode="true" DefaultSorting="" >
</dx:XpoDataSource>
</div>    
</asp:Content>
