<%@ Page Language="C#" MasterPageFile="~/Modules/MasterPage.Master" AutoEventWireup="true" 
    CodeBehind="frmDinamicaSiaf.aspx.cs" Inherits="InfoGesRegional.Modules.Forms.Consulta.frmDinamicaSiaf" 
    Title="InfoGesConsultas" %>

<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView.Export" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTabControl" tagprefix="dxtc" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.XtraCharts.v13.1.Web, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts.Web" tagprefix="dxchartsui" %>
<%@ Register assembly="DevExpress.XtraCharts.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="dxcharts" %>


<%@ Register assembly="DevExpress.XtraCharts.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="cc1" %>

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
 
     <div id="principal" >

<table>
<tr>
<td>
<table><tr>
<td class="style19">
<dxtc:ASPxTabControl ID="ASPxTabControleJEjecutora" runat="server" AutoPostBack="True" 
        DataSourceID="XmlDataSource2"  
        OnActiveTabChanged="ASPxPageControl1_ActiveTabChanged1"
        ActiveTabStyle-Font-Size="Large" TabStyle-Wrap="True" Width="248px" 
        CssFilePath="~/App_Themes/Glass/Web/styles.css" CssPostfix="Glass" >
<Paddings Padding="0" />

<ActiveTabStyle Font-Size="Large" Wrap="True"></ActiveTabStyle>

<TabStyle Wrap="True"></TabStyle>
    </dxtc:ASPxTabControl>
<asp:XmlDataSource ID="XmlDataSource2" runat="server" DataFile=""  XPath="//ejecutora" EnableCaching="false"></asp:XmlDataSource>
</td>
<td align="right" class="style18">
<dxtc:ASPxTabControl ID="tcDemos" runat="server" DataSourceID="XmlDataSource1"  AutoPostBack="true" 
        OnActiveTabChanged="ASPxPageControl1_ActiveTabChanged" 
        ActiveTabStyle-Font-Size="XX-Large" TabIndex="0" CssFilePath="~/App_Themes/Glass/Web/styles.css" 
        CssPostfix="Glass" EnableDefaultAppearance="False" RightToLeft="True" 
        Width="193px">
<Paddings Padding="0" />
    </dxtc:ASPxTabControl>
<asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile=""  XPath="//product"  ></asp:XmlDataSource>
</td>
</tr></table>
</td>
</tr>
<tr>
<td>
<table>
<tr>
<td style="padding-right: 4px">
                <dx:ASPxButton ID="btnXlsExport" runat="server" Text="Exportar  XLS" UseSubmitBehavior="False"
                    OnClick="btnXlsExport_Click" 
                    CssFilePath="~/App_Themes/Glass/Editors/styles.css"  CssPostfix="Glass" /></td>
<td><dx:ASPxButton runat="server" ID="btnCollapse" Text="Collapse All Rows" UseSubmitBehavior="false"
    AutoPostBack="false">
    <ClientSideEvents Click="function() { ASPxGridInfoGes.CollapseAll() }" />
</dx:ASPxButton>
</td>
<td>
<dx:ASPxButton runat="server" ID="btnExpand" Text="Expand All Rows" UseSubmitBehavior="false"
    AutoPostBack="false">
    <ClientSideEvents Click="function() { ASPxGridInfoGes.ExpandAll() }" />
</dx:ASPxButton>
</td>
</tr>
</table>
</td>
</tr>
<tr>
<td>
<table>
<tr>
<td>
<dxwgv:aspxgridview ID="ASPxGridInfoGes"  
            ClientInstanceName="ASPxGridInfoGes" 
            runat="server" 
            AutoGenerateColumns="False" 
            OnLoad="LoadInfo_Meta_x_Gasto"  
            Font-Size="X-Small" 
            Width="100%"
            OnCustomUnboundColumnData="grid_CustomUnboundColumnData" 
        OnHeaderFilterFillItems="grid_HeaderFilterFillItems">
                <Settings ShowGroupPanel="True" ShowFooter="True"
                        ShowHeaderFilterButton="true" ShowGroupFooter="VisibleAlways"
                        ShowVerticalScrollBar="True" VerticalScrollableHeight="300" />
                <TotalSummary>
                <dxwgv:ASPxSummaryItem FieldName="SEC_FUNC" SummaryType="Count"/>
                <dxwgv:ASPxSummaryItem FieldName="PIA" SummaryType="Sum" DisplayFormat="c" />
                <dxwgv:ASPxSummaryItem FieldName="PIM" SummaryType="Sum" DisplayFormat="c"/>
                <dxwgv:ASPxSummaryItem FieldName="CERTIFICADO" SummaryType="Sum" DisplayFormat="c"/>
                <dxwgv:ASPxSummaryItem FieldName="COMPROMISO_ANUAL" SummaryType="Sum" DisplayFormat="c"/>
                <dxwgv:ASPxSummaryItem FieldName="COMPROMISO" SummaryType="Sum" DisplayFormat="c"/>
                <dxwgv:ASPxSummaryItem FieldName="DEVENGADO" SummaryType="Sum" DisplayFormat="c"/>
                <dxwgv:ASPxSummaryItem FieldName="GIRADO" SummaryType="Sum" DisplayFormat="c"/>
                <dxwgv:ASPxSummaryItem FieldName="SALDO_CERTIFICADO" SummaryType="Sum" DisplayFormat="c"/>
                <dxwgv:ASPxSummaryItem FieldName="SALDO_COMPROMISO_ANUAL" SummaryType="Sum" DisplayFormat="c"/>
                <dxwgv:ASPxSummaryItem FieldName="SALDO_COMPROMISO" SummaryType="Sum" DisplayFormat="c"/>
                <dxwgv:ASPxSummaryItem FieldName="SALDO_DEVENGADO" SummaryType="Sum" DisplayFormat="c"/>
                </TotalSummary>

                <GroupSummary>
                <dxwgv:ASPxSummaryItem FieldName="PIA" ShowInGroupFooterColumn="PIA" SummaryType="Sum" DisplayFormat="{0:c}" />
                <dxwgv:ASPxSummaryItem FieldName="PIM" ShowInGroupFooterColumn="PIM" SummaryType="Sum" DisplayFormat="c"/>
                <dxwgv:ASPxSummaryItem FieldName="CERTIFICADO" ShowInGroupFooterColumn="CERTIFICADO" SummaryType="Sum" DisplayFormat="c"/>
                <dxwgv:ASPxSummaryItem FieldName="COMPROMISO_ANUAL" ShowInGroupFooterColumn="COMPROMISO_ANUAL" SummaryType="Sum" DisplayFormat="c"/>
                <dxwgv:ASPxSummaryItem FieldName="COMPROMISO" ShowInGroupFooterColumn="COMPROMISO" SummaryType="Sum" DisplayFormat="c"/>
                <dxwgv:ASPxSummaryItem FieldName="DEVENGADO" ShowInGroupFooterColumn="DEVENGADO" SummaryType="Sum" DisplayFormat="c"/>
                <dxwgv:ASPxSummaryItem FieldName="GIRADO" ShowInGroupFooterColumn="GIRADO" SummaryType="Sum" DisplayFormat="c"/>
                <dxwgv:ASPxSummaryItem FieldName="SALDO_CERTIFICADO" ShowInGroupFooterColumn="SALDO_CERTIFICADO" SummaryType="Sum" DisplayFormat="c"/>
                <dxwgv:ASPxSummaryItem FieldName="SALDO_COMPROMISO_ANUAL" ShowInGroupFooterColumn="SALDO_COMPROMISO_ANUAL" SummaryType="Sum" DisplayFormat="c"/>
                <dxwgv:ASPxSummaryItem FieldName="SALDO_COMPROMISO" ShowInGroupFooterColumn="SALDO_COMPROMISO" SummaryType="Sum" DisplayFormat="c"/>
                <dxwgv:ASPxSummaryItem FieldName="SALDO_DEVENGADO" ShowInGroupFooterColumn="SALDO_DEVENGADO" SummaryType="Sum" DisplayFormat="c"/>
 
                </GroupSummary>
                                                 
                                                  
            <Columns>
                <dxwgv:GridViewDataTextColumn FieldName="SEC_FUNC" VisibleIndex="0"  
                    Caption="META" Width="200px"  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left"
                CellStyle-BackColor="#ffffd6" >
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<CellStyle BackColor="#FFFFD6"></CellStyle>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="FUENTE_FINANC_NOMBRE" 
                    VisibleIndex="1"  Caption="RUBRO" Width="200px"  
                    HeaderStyle-HorizontalAlign="Center" FixedStyle="Left"
                CellStyle-BackColor="#ffffd6" >
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<CellStyle BackColor="#FFFFD6"></CellStyle>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="GENERICA_NOMBRE" VisibleIndex="2"  
                    Caption="GENÉRICA" Width="200px"  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left"
                CellStyle-BackColor="#ffffd6" >
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<CellStyle BackColor="#FFFFD6"></CellStyle>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewBandColumn Caption="MARCO DE GASTO" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" >
                <Columns>
                    <dxwgv:GridViewDataTextColumn Settings-AllowHeaderFilter="False" FieldName="PIA" VisibleIndex="3" UnboundType="Decimal"  Caption="PIA" Width="100px"  HeaderStyle-HorizontalAlign="Center">
                        <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit><Settings AllowHeaderFilter="False" AllowAutoFilter="False" />

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </dxwgv:GridViewDataTextColumn> 
                    <dxwgv:GridViewDataTextColumn Settings-AllowHeaderFilter="False" FieldName="PIM" VisibleIndex="5" UnboundType="Decimal"  Caption="PIM" Width="100px"  HeaderStyle-HorizontalAlign="Center">
                        <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit><Settings AllowHeaderFilter="False" AllowAutoFilter="False" />

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </dxwgv:GridViewDataTextColumn> 
                </Columns>

<HeaderStyle HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>
                </dxwgv:GridViewBandColumn>
                <dxwgv:GridViewBandColumn Caption="EJECUCION" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" >
                <Columns>
                <dxwgv:GridViewDataTextColumn Settings-AllowHeaderFilter="False" FieldName="CERTIFICADO" VisibleIndex="6" UnboundType="Decimal"  Caption="CERTIFICADO" Width="100px" HeaderStyle-HorizontalAlign="Center" >
                    <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit><Settings AllowHeaderFilter="False" AllowAutoFilter="False" />

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>             
                <dxwgv:GridViewDataTextColumn Settings-AllowHeaderFilter="False" FieldName="COMPROMISO_ANUAL" VisibleIndex="7" UnboundType="Decimal"  Caption="COMPROMISO ANUAL" Width="100px" HeaderStyle-HorizontalAlign="Center"  HeaderStyle-Wrap="True">
                    <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit><Settings AllowHeaderFilter="False" AllowAutoFilter="False" />

<HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>             
                <dxwgv:GridViewDataTextColumn Settings-AllowHeaderFilter="False" FieldName="COMPROMISO" VisibleIndex="8" UnboundType="Decimal"  Caption="COMPROMISO" Width="100px" HeaderStyle-HorizontalAlign="Center" >
                    <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit><Settings AllowHeaderFilter="False" AllowAutoFilter="False" />

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>             
                <dxwgv:GridViewDataTextColumn Settings-AllowHeaderFilter="False" FieldName="DEVENGADO" VisibleIndex="9" UnboundType="Decimal"  Caption="DEVENGADO" Width="100px" HeaderStyle-HorizontalAlign="Center" >
                    <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit><Settings AllowHeaderFilter="False" AllowAutoFilter="False" />

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>             
                <dxwgv:GridViewDataTextColumn Settings-AllowHeaderFilter="False" FieldName="GIRADO" VisibleIndex="10" UnboundType="Decimal"  Caption="GIRADO" Width="100px" HeaderStyle-HorizontalAlign="Center" >
                    <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit><Settings AllowHeaderFilter="False" AllowAutoFilter="False"/>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>             
                </Columns>

<HeaderStyle HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>
                </dxwgv:GridViewBandColumn>

                <dxwgv:GridViewBandColumn Caption="SALDO" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" >
                <Columns>
                <dxwgv:GridViewDataTextColumn Settings-AllowHeaderFilter="False" FieldName="SALDO_CERTIFICADO" VisibleIndex="11" UnboundType="Decimal"  Caption="S.CERTIFICADO" Width="100px" HeaderStyle-HorizontalAlign="Center" >
                    <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit><Settings AllowHeaderFilter="False" AllowAutoFilter="False" />

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>             
                <dxwgv:GridViewDataTextColumn Settings-AllowHeaderFilter="False" FieldName="SALDO_COMPROMISO_ANUAL" VisibleIndex="12" UnboundType="Decimal"  Caption="S.COMPROMISO ANUAL" Width="100px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True">
                    <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit><Settings AllowHeaderFilter="False" AllowAutoFilter="False" />

<HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>             
                <dxwgv:GridViewDataTextColumn Settings-AllowHeaderFilter="False" FieldName="SALDO_COMPROMISO" VisibleIndex="13" UnboundType="Decimal"  Caption="S.COMPROMISO" Width="100px" HeaderStyle-HorizontalAlign="Center" >
                    <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit><Settings AllowHeaderFilter="False" AllowAutoFilter="False" />

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>             
                <dxwgv:GridViewDataTextColumn Settings-AllowHeaderFilter="False" FieldName="SALDO_DEVENGADO" VisibleIndex="14" UnboundType="Decimal"  Caption="S.DEVENGADO" Width="100px" HeaderStyle-HorizontalAlign="Center" >
                    <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit><Settings AllowHeaderFilter="False" AllowAutoFilter="False" />

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>             
          
                </Columns>

<HeaderStyle HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>
                </dxwgv:GridViewBandColumn>
                </Columns>
                <SettingsPager Mode="ShowAllRecords">
            </SettingsPager>
                <Settings ShowFilterRow="True" ShowTitlePanel="true"   />
                <SettingsText Title="CONSULTA META X RUBRO X  GENERICA"  />
                                                 
                                                 
                <Styles>
                    <CommandColumn Paddings-Padding="1">
                        <Paddings Padding="1px" />
                    </CommandColumn>
                </Styles>

</dxwgv:aspxgridview> 
<dxwgv:ASPxGridViewExporter ID="gridExport" runat="server" GridViewID="ASPxGridInfoGes"></dxwgv:ASPxGridViewExporter>

</td></tr>
</table>
</td></tr>
</table>
<table>
<tr>
<td>
<dxchartsui:webchartcontrol  ID="WebChartControlGastoG" runat="server" ToolTipEnabled="False"
                CrosshairEnabled="false" Height="337px" SideBySideEqualBarWidth="True" 
                Width="408px" CssFilePath="~/App_Themes/Glass/Web/styles.css" CssPostfix="Glass" Visible="false">
  <SeriesSerializable>
    <dxcharts:Series Name="1998" LabelsVisibility="True">
        <Points>
            <dxcharts:SeriesPoint Values="423.721" ArgumentSerializable="Illinois"></dxcharts:SeriesPoint>
            <dxcharts:SeriesPoint Values="178.719" ArgumentSerializable="Indiana"></dxcharts:SeriesPoint>
            <dxcharts:SeriesPoint Values="308.845" ArgumentSerializable="Michigan"></dxcharts:SeriesPoint>
            <dxcharts:SeriesPoint Values="348.555" ArgumentSerializable="Ohio"></dxcharts:SeriesPoint>
            <dxcharts:SeriesPoint Values="160.274" ArgumentSerializable="Wisconsin"></dxcharts:SeriesPoint>
        </Points>
        <ViewSerializable>
            <dxcharts:SideBySideBarSeriesView>
            </dxcharts:SideBySideBarSeriesView>
        </ViewSerializable>
        <LabelSerializable>
            <dxcharts:SideBySideBarSeriesLabel LineVisible="True"      ResolveOverlappingMode="Default">
                <FillStyle>
                    <OptionsSerializable>
                        <dxcharts:SolidFillOptions></dxcharts:SolidFillOptions>
                    </OptionsSerializable>
                </FillStyle>
                <PointOptionsSerializable>
                    <dxcharts:PointOptions>
                        <ValueNumericOptions Format="FixedPoint"></ValueNumericOptions>
                    </dxcharts:PointOptions>
                </PointOptionsSerializable>
            </dxcharts:SideBySideBarSeriesLabel>
        </LabelSerializable>
        <LegendPointOptionsSerializable>
            <dxcharts:PointOptions>
                <ValueNumericOptions Format="FixedPoint"></ValueNumericOptions>
            </dxcharts:PointOptions>
        </LegendPointOptionsSerializable>
    </dxcharts:Series>
<dxcharts:Series Name="2001" LabelsVisibility="True"><Points>
<dxcharts:SeriesPoint Values="476.851" ArgumentSerializable="Illinois"></dxcharts:SeriesPoint>
<dxcharts:SeriesPoint Values="195.769" ArgumentSerializable="Indiana"></dxcharts:SeriesPoint>
<dxcharts:SeriesPoint Values="335.793" ArgumentSerializable="Michigan"></dxcharts:SeriesPoint>
<dxcharts:SeriesPoint Values="374.771" ArgumentSerializable="Ohio"></dxcharts:SeriesPoint>
<dxcharts:SeriesPoint Values="182.373" ArgumentSerializable="Wisconsin"></dxcharts:SeriesPoint>
</Points>
<ViewSerializable>
<dxcharts:SideBySideBarSeriesView></dxcharts:SideBySideBarSeriesView>
</ViewSerializable>
<LabelSerializable>
<dxcharts:SideBySideBarSeriesLabel LineVisible="True"
        ResolveOverlappingMode="Default">
<FillStyle><OptionsSerializable>
<dxcharts:SolidFillOptions></dxcharts:SolidFillOptions>
</OptionsSerializable>
</FillStyle>
<PointOptionsSerializable>
<dxcharts:PointOptions>
<ValueNumericOptions Format="FixedPoint"></ValueNumericOptions>
</dxcharts:PointOptions>
</PointOptionsSerializable>
</dxcharts:SideBySideBarSeriesLabel>
</LabelSerializable>
<LegendPointOptionsSerializable>
<dxcharts:PointOptions>
<ValueNumericOptions Format="FixedPoint"></ValueNumericOptions>
</dxcharts:PointOptions>
</LegendPointOptionsSerializable>
</dxcharts:Series>
<dxcharts:Series Name="2004" LabelsVisibility="True"><Points>
<dxcharts:SeriesPoint Values="528.904" ArgumentSerializable="Illinois"></dxcharts:SeriesPoint>
<dxcharts:SeriesPoint Values="227.271" ArgumentSerializable="Indiana"></dxcharts:SeriesPoint>
<dxcharts:SeriesPoint Values="372.576" ArgumentSerializable="Michigan"></dxcharts:SeriesPoint>
<dxcharts:SeriesPoint Values="418.258" ArgumentSerializable="Ohio"></dxcharts:SeriesPoint>
<dxcharts:SeriesPoint Values="211.727" ArgumentSerializable="Wisconsin"></dxcharts:SeriesPoint>
</Points>
<ViewSerializable>
<dxcharts:SideBySideBarSeriesView></dxcharts:SideBySideBarSeriesView>
</ViewSerializable>
<LabelSerializable>
<dxcharts:SideBySideBarSeriesLabel LineVisible="True"
        ResolveOverlappingMode="Default">
<FillStyle><OptionsSerializable>
<dxcharts:SolidFillOptions></dxcharts:SolidFillOptions>
</OptionsSerializable>
</FillStyle>
<PointOptionsSerializable>
<dxcharts:PointOptions>
<ValueNumericOptions Format="FixedPoint"></ValueNumericOptions>
</dxcharts:PointOptions>
</PointOptionsSerializable>
</dxcharts:SideBySideBarSeriesLabel>
</LabelSerializable>
<LegendPointOptionsSerializable>
<dxcharts:PointOptions>
<ValueNumericOptions Format="FixedPoint"></ValueNumericOptions>
</dxcharts:PointOptions>
</LegendPointOptionsSerializable>
</dxcharts:Series>
</SeriesSerializable>
                                                <SeriesTemplate
                                                    ><ViewSerializable>
<dxcharts:SideBySideBarSeriesView></dxcharts:SideBySideBarSeriesView>
</ViewSerializable>
<LabelSerializable>
<dxcharts:SideBySideBarSeriesLabel LineVisible="True">
<FillStyle><OptionsSerializable>
<dxcharts:SolidFillOptions></dxcharts:SolidFillOptions>
</OptionsSerializable>
</FillStyle>
<PointOptionsSerializable>
<dxcharts:PointOptions></dxcharts:PointOptions>
</PointOptionsSerializable>
</dxcharts:SideBySideBarSeriesLabel>
</LabelSerializable>
<LegendPointOptionsSerializable>
<dxcharts:PointOptions></dxcharts:PointOptions>
</LegendPointOptionsSerializable>
</SeriesTemplate>
                                                <FillStyle ><OptionsSerializable>
<dxcharts:SolidFillOptions></dxcharts:SolidFillOptions>
</OptionsSerializable>
</FillStyle>
                                                <BorderOptions Visible="False" />
                                                <Titles>
<dxcharts:ChartTitle Text="Great Lakes Gross State Product"></dxcharts:ChartTitle>
<dxcharts:ChartTitle Dock="Bottom" Alignment="Far" Text="From www.bea.gov" Font="Tahoma, 8pt" TextColor="Gray"></dxcharts:ChartTitle>
</Titles>
                                                <DiagramSerializable>
<dxcharts:XYDiagram>
<AxisX VisibleInPanesSerializable="-1">
<Range SideMarginsEnabled="True"></Range>
</AxisX>
<AxisY Title-Text="Millions of Dollars" Title-Visible="True" VisibleInPanesSerializable="-1" GridSpacingAuto="False" GridSpacing="75" Interlaced="True">
<Range SideMarginsEnabled="True"></Range>
</AxisY>
</dxcharts:XYDiagram>
</DiagramSerializable>
<ToolTipOptions><ToolTipPositionSerializable>
<dxcharts:ToolTipMousePosition></dxcharts:ToolTipMousePosition>
</ToolTipPositionSerializable>
</ToolTipOptions>
                
            </dxchartsui:webchartcontrol>
</td>
</tr>
</table>
  </div>    
</asp:Content>
