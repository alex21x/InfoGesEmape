<%@ Page Language="C#" MasterPageFile="~/Modules/MasterPage.Master" AutoEventWireup="true" 
    CodeBehind="frmCuadrosComparativos.aspx.cs" Inherits="InfoGesRegional.Modules.Forms.Consulta.frmCuadrosComparativos" 
    Title="InfoGesConsultas" %>





<%@ Register assembly="DevExpress.XtraCharts.v17.1.Web, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts.Web" tagprefix="dxchartsui" %>
<%@ Register assembly="DevExpress.XtraCharts.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="cc1" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>

<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxClasses" tagprefix="dxw" %>

<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.ASPxPivotGrid.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPivotGrid" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTabControl" tagprefix="dxtc" %>        




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style8
        {
            width: 366px;
        }
        .style9
        {
            width: 464px;
        }
        .style10
        {
            width: 522px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table>
<tr>
<td align="center">
<dxtc:ASPxTabControl ID="ASPxTabControleJEjecutora" runat="server" AutoPostBack="true" 
        DataSourceID="XmlDataSource2"  
        OnActiveTabChanged="ASPxPageControl1_ActiveTabChanged1" 
        ActiveTabStyle-Font-Size="Large" TabStyle-Wrap="True" Width="1000px" 
         CssFilePath="~/App_Themes/Glass/Web/styles.css" CssPostfix="Glass" TabIndex="0" >
<Paddings Padding="0" />
    </dxtc:ASPxTabControl>
<asp:XmlDataSource ID="XmlDataSource2" runat="server" DataFile=""  XPath="//ejecutora" EnableCaching="false"></asp:XmlDataSource>

</td>
</tr>
<tr>
<td align="center">
<dxtc:ASPxTabControl ID="tcDemos" runat="server" DataSourceID="XmlDataSource1"  AutoPostBack="true" 
        OnActiveTabChanged="ASPxPageControl1_ActiveTabChanged" 
        ActiveTabStyle-Font-Size="XX-Large"  CssFilePath="~/App_Themes/Glass/Web/styles.css" CssPostfix="Glass" TabIndex="0" Visible="false" ToolTip="false"> 
<Paddings Padding="0" />
    </dxtc:ASPxTabControl>
<asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile=""  XPath="//product"  ></asp:XmlDataSource>
</td>
</tr>
<tr>
<td align="center">
<table style="width: 1217px"  >
<tr>
<td class="style10">
    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="PRESUPUESTO" 
        CssFilePath="~/App_Themes/Glass/Web/styles.css" Font-Size="X-Large" 
        Font-Names="Times New Roman" Font-Bold="False">
    </dx:ASPxLabel>
</td>
<td class="style9">
    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="COMPROMISO" 
        CssFilePath="~/App_Themes/Glass/Web/styles.css"  Font-Size="X-Large" 
        Font-Names="Times New Roman" Font-Bold="True">
    </dx:ASPxLabel>
</td>
<td  class="style8">
    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="GIRADO" 
        CssFilePath="~/App_Themes/Glass/Web/styles.css"  Font-Size="X-Large" 
        Font-Names="Times New Roman" Font-Bold="True">
    </dx:ASPxLabel>
</td>
</tr>
<tr>
<td class="style10">
    <dx:ASPxLabel ID="ASPxLbPresupuesto" runat="server" Text="ASPxLabel"  
        CssFilePath="~/App_Themes/Glass/Web/styles.css" Font-Size="X-Large" 
        Font-Names="Times New Roman" Font-Underline="True" Font-Bold="True">
    </dx:ASPxLabel>
</td>
<td class="style9">
    <dx:ASPxLabel ID="ASPxLbCompromiso" runat="server" Text="ASPxLabel"  
        CssFilePath="~/App_Themes/Glass/Web/styles.css" Font-Size="X-Large" 
        Font-Names="Times New Roman" Font-Underline="True" Font-Bold="True" 
        Font-Italic="False">
    </dx:ASPxLabel>
</td>
<td>
    <dx:ASPxLabel ID="ASPxLbEjecucion" runat="server" Text="ASPxLabel"  
        CssFilePath="~/App_Themes/Glass/Web/styles.css" Font-Size="X-Large" 
        Font-Names="Times New Roman" Font-Underline="True" Font-Bold="True">
    </dx:ASPxLabel>
</td>
</tr>
</table>
</td>
</tr>





<tr>
<td>



        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
            <ContentTemplate>
        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Always">
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server"  AssociatedUpdatePanelID="UpdatePanel4" runat="server" DisplayAfter="0">
                    <ProgressTemplate>
                        <img alt="procesando..."  src="%2520"/></ProgressTemplate>
                </asp:UpdateProgress>    
            </ContentTemplate>                 
        </asp:UpdatePanel>    
			
            <dxtc:ASPxPageControl ID="ASPxPageControl1" runat="server" 
        ActiveTabIndex="0" CssFilePath="~/App_Themes/Glass/Web/styles.css" CssPostfix="Glass"
        CssPostfix="Aqua" Height="300%" LoadingPanelText="" TabSpacing="3px" 
        Width="1079px">
				<ContentStyle VerticalAlign="Top">
				<Border BorderColor="#AECAF0" BorderStyle="Solid" BorderWidth="1px" />
<Border BorderStyle="Solid" BorderColor="#AECAF0" BorderWidth="1px"></Border>
				</ContentStyle>     
				<ActiveTabStyle Font-Bold="True" Font-Size="Small">
				</ActiveTabStyle>                        
				<TabPages >   
					<dxtc:TabPage Text="Graficos" >
						<ContentCollection>
							<dxw:ContentControl ID="ContentControl13" runat="server">						
								
		
	
<table title="verde"><tr valign="top"><td>
<table title="rojo1">
<tr valign="top"><td align="center">
<table title="celeste1">
<tr><td>


<dxchartsui:webchartcontrol  ID="WebChartControlGastoG"  runat="server" ToolTipEnabled="False" EnableClientSideAPI="True" ClientInstanceName="chart"
                CrosshairEnabled="false" Height="800px" SideBySideEqualBarWidth="True" CssClass="AlignCenter TopLargeMargin"
                Width="941px"  CssFilePath="~/App_Themes/Glass/Web/styles.css" CssPostfix="Glass">
</dxchartsui:webchartcontrol>


</td>
</tr>
</table>
</td></tr>

</table>
</td>
</tr>
<tr>
<td>
<dxchartsui:WebChartControl ID="WebChartControl1" runat="server" 
    CrosshairEnabled="True" DataSourceID="ASPxPivotGrid1" EnableViewState="False" 
    Height="200px" SideBySideEqualBarWidth="True" Width="300px" 
        AppearanceNameSerializable="Pastel Kit" Visible="false">
    <diagramserializable>
        <cc1:XYDiagram>
            <axisx visibleinpanesserializable="-1">
                <range alwaysshowzerolevel="True" sidemarginsenabled="True" />
            </axisx>
            <axisy visibleinpanesserializable="-1">
                <label>
                    <numericoptions format="Number" />
                </label>
                <range alwaysshowzerolevel="True" sidemarginsenabled="True" />
            </axisy>
        </cc1:XYDiagram>
    </diagramserializable>
<FillStyle><OptionsSerializable>
    <cc1:SolidFillOptions />
</OptionsSerializable>
</FillStyle>

    <legend AlignmentHorizontal="Center" AlignmentVertical="BottomOutside" 
        MaxVerticalPercentage="30"></legend>

<SeriesTemplate argumentdatamember="Arguments" argumentscaletype="Qualitative" 
        valuedatamembersserializable="Values" synchronizepointoptions="False"><ViewSerializable>
        <cc1:PieSeriesView RuntimeExploding="False">
            <titles>
                <cc1:SeriesTitle />
            </titles>
        </cc1:PieSeriesView>
</ViewSerializable>
<LabelSerializable>
    <cc1:PieSeriesLabel LineVisible="True" Position="TwoColumns">
        <fillstyle>
            <optionsserializable>
                <cc1:SolidFillOptions />
            </optionsserializable>
        </fillstyle>
        <pointoptionsserializable>
            <cc1:PiePointOptions>
                <valuenumericoptions format="Number" />
<ValueNumericOptions Format="Number"></ValueNumericOptions>
            </cc1:PiePointOptions>
        </pointoptionsserializable>
    </cc1:PieSeriesLabel>
</LabelSerializable>
<LegendPointOptionsSerializable>
    <cc1:PiePointOptions PointView="Argument">
        <valuenumericoptions format="Number" />
<ValueNumericOptions Format="Number"></ValueNumericOptions>
    </cc1:PiePointOptions>
</LegendPointOptionsSerializable>
</SeriesTemplate>

    <titles>
        <cc1:ChartTitle />
    </titles>

<CrosshairOptions><CommonLabelPositionSerializable>
<cc1:CrosshairMousePosition></cc1:CrosshairMousePosition>
</CommonLabelPositionSerializable>
</CrosshairOptions>

<ToolTipOptions><ToolTipPositionSerializable>
<cc1:ToolTipMousePosition></cc1:ToolTipMousePosition>
</ToolTipPositionSerializable>
</ToolTipOptions>
</dxchartsui:WebChartControl>
<dx:ASPxPivotGrid ID="ASPxPivotGrid1" runat="server" ClientIDMode="AutoID" Visible="false">
</dx:ASPxPivotGrid>
<asp:AccessDataSource ID="AccessDataSource1" runat="server">
</asp:AccessDataSource>
</td>
</tr>
</table>    
    	
		
		
							</dxw:ContentControl>
						</ContentCollection>
					</dxtc:TabPage>    
                </TabPages>
	        </dxtc:ASPxPageControl> 						
			</ContentTemplate>


</td>
</tr>
</table>


</asp:Content>
