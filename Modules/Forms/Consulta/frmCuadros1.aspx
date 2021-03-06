<%@ Page Language="C#" MasterPageFile="~/Modules/MasterPage.Master" AutoEventWireup="true" 
    CodeBehind="frmCuadros1.aspx.cs" Inherits="InfoGesRegional.Modules.Forms.Consulta.frmCuadros1
    " 
    Title="InfoGesConsultas" %>



    
<%@ Register assembly="DevExpress.XtraCharts.v17.1.Web, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts.Web" tagprefix="dxchartsui" %>
<%@ Register assembly="DevExpress.XtraCharts.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="dxcharts" %>

<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxClasses" tagprefix="dxw" %>

<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>

<%@ Register assembly="DevExpress.Web.ASPxPivotGrid.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPivotGrid" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTabControl" tagprefix="dxtc" %>        

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPivotGrid.Export" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style8
        {
            width: 298px;
        }
        .style9
        {
            width: 395px;
        }
        .style10
        {
            width: 522px;
        }
        .style11
        {
            width: 261px;
        }
        .style12
        {
            width: 273px;
        }
        .style13
        {
            width: 522px;
            height: 51px;
        }
        .style14
        {
            width: 395px;
            height: 51px;
        }
        .style15
        {
            width: 298px;
            height: 51px;
        }
        .style16
        {
            width: 261px;
            height: 51px;
        }
        .style17
        {
            width: 273px;
            height: 51px;
        }
        .style18
        {
            width: 737px;
        }
        .style19
        {
            width: 310px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
</tr>
<tr>
<td align="left" class="style18">
<dxtc:ASPxTabControl ID="tcDemos" runat="server" DataSourceID="XmlDataSource1"  AutoPostBack="true" 
        OnActiveTabChanged="ASPxPageControl1_ActiveTabChanged" 
        ActiveTabStyle-Font-Size="XX-Large" TabIndex="0" CssFilePath="~/App_Themes/Glass/Web/styles.css" 
        CssPostfix="Glass" EnableDefaultAppearance="False" RightToLeft="True"  Width="1200px" EnableTabScrolling="true">
<Paddings Padding="0" />
    </dxtc:ASPxTabControl>
<asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile=""  XPath="//product"  ></asp:XmlDataSource>
</td>
</tr></table>
</td>
</tr>
<tr>
<td align="center">
<table style="width: 1217px"  >
<tr>
<td class="style13" bgcolor="#E2F1FE">
    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="PRESUPUESTO(PIM)" Font-Size="X-Large" 
        Font-Names="Times New Roman" Font-Bold="False">
    </dx:ASPxLabel>
</td>
<td class="style14" bgcolor="#E2F1FE">
    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="COMPROMISO" 
        CssFilePath="~/App_Themes/Glass/ASPxLabel.skin"  Font-Size="X-Large" 
        Font-Names="Times New Roman" Font-Bold="False">
    </dx:ASPxLabel>
</td>
<td  class="style15" align="right" bgcolor="#E2F1FE">
    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="DEVENGADO" 
        CssFilePath="~/App_Themes/Glass/ASPxLabel.skin"  Font-Size="X-Large" 
        Font-Names="Times New Roman" Font-Bold="False">
    </dx:ASPxLabel>

</td>
<td align="left" class="style16" bgcolor="#E2F1FE">
    <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="   (%)" 
        CssFilePath="~/App_Themes/Glass/ASPxLabel.skin"  Font-Size="X-Large" 
        Font-Names="Times New Roman" Font-Bold="False">
    </dx:ASPxLabel>
</td>
<td class="style17" bgcolor="#E2F1FE">
    <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="GIRADO" 
        CssFilePath="~/App_Themes/Glass/ASPxLabel.skin"  Font-Size="X-Large" 
        Font-Names="Times New Roman" Font-Bold="False">
    </dx:ASPxLabel>
</td>
</tr>
<tr>
<td class="style10" bgcolor="#E2F1FE">
    <dx:ASPxLabel ID="ASPxLbPresupuesto" runat="server" Text="ASPxLabel"  
        CssFilePath="~/App_Themes/Glass/ASPxLabel.skin" Font-Size="X-Large" 
        Font-Names="Times New Roman" Font-Underline="True" Font-Bold="True">
    </dx:ASPxLabel>
</td>
<td class="style9" bgcolor="#E2F1FE">
    <dx:ASPxLabel ID="ASPxLbCompromiso" runat="server" Text="ASPxLabel"  
        CssFilePath="~/App_Themes/Glass/ASPxLabel.skin" Font-Size="X-Large" 
        Font-Names="Times New Roman" Font-Underline="True" Font-Bold="True" 
        Font-Italic="False">
    </dx:ASPxLabel>
</td>
<td class="style8" align="right" bgcolor="#E2F1FE">
    <dx:ASPxLabel ID="ASPxLbDevengado" runat="server" Text="ASPxLabel"  
        CssFilePath="~/App_Themes/Glass/ASPxLabel.skin" Font-Size="X-Large" 
        Font-Names="Times New Roman" Font-Underline="True" Font-Bold="True">
    </dx:ASPxLabel>
</td>
<td align="left" class="style11" bgcolor="#E2F1FE">
    <dx:ASPxLabel ID="ASPxPorcentaje" runat="server" Text="ASPxLabel"  
        CssFilePath="~/App_Themes/Glass/ASPxLabel.skin" Font-Size="X-Large" 
        Font-Names="Times New Roman" Font-Underline="True" Font-Bold="True">
    </dx:ASPxLabel>
</td>
<td align="left" class="style12" bgcolor="#E2F1FE">
    <dx:ASPxLabel ID="ASPxLbGirado" runat="server" Text="ASPxLabel"  
        CssFilePath="~/App_Themes/Glass/ASPxLabel.skin" Font-Size="X-Large" 
        Font-Names="Times New Roman" Font-Underline="True" Font-Bold="True">
    </dx:ASPxLabel>
</td>

</tr>
</table>
</td>
</tr>
<tr>
<td>

        <dxtc:ASPxPageControl ID="ASPxPageControl1" runat="server" 
        ActiveTabIndex="1" CssFilePath="~/App_Themes/Glass/Editors/styles.css" 
            CssPostfix="Glass" Height="300%" LoadingPanelText="" TabSpacing="3px" 
        Width="1079px" onactivetabchanged="ASPxPageControl1_ActiveTabChanged2" >
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

                        <table>
                        <tr>
                        <td>
                        <dxe:ASPxComboBox ID="ChartType" runat="server" OnValueChanged="ChartTypeChangedGenerica" AutoPostBack="True" ValueType="System.String" />
                        <dxchartsui:WebChartControl ID="WebChart" runat="server" DataSourceID="ASPxPivotGenerica"
                            Width="830px" Height="500px" SeriesDataMember="Series" CssClass="TopMargin" 
                                        CrosshairEnabled="True">
                            <fillstyle>
                                <OptionsSerializable>
                                    <dxcharts:SolidFillOptions />
                                </OptionsSerializable>
                            </fillstyle>
                            <legend maxhorizontalpercentage="30" />
                            <borderoptions visible="False" />
                            <BorderOptions Visible="False"></BorderOptions>
                            <diagramserializable>
                                <dxcharts:XYDiagram>
                                    <axisx visibleinpanesserializable="-1" title-text="PERIODO MES">
                                        <label staggered="True" />
                                        <range sidemarginsenabled="True" />
                                    </axisx>
                                    <axisy visibleinpanesserializable="-1" 
                                        title-text="GIRADO ACUM. C. DIRECTO ACUM. C.TOTAL ACUM.">
                                        <range sidemarginsenabled="True" />
                                    </axisy>
                                </dxcharts:XYDiagram>
                            </diagramserializable>
                            <Legend MaxHorizontalPercentage="30"></Legend>
                            <seriestemplate argumentdatamember="Arguments" 
                                valuedatamembersserializable="Values" argumentscaletype="Qualitative">
                                <ViewSerializable>
                                    <dxcharts:SideBySideBarSeriesView />
                                </ViewSerializable>
                                <LabelSerializable>
                                    <dxcharts:SideBySideBarSeriesLabel LineVisible="True">

                                    </dxcharts:SideBySideBarSeriesLabel>
                                </LabelSerializable>
                                <LegendPointOptionsSerializable>
                                    <dxcharts:PointOptions />
                                </LegendPointOptionsSerializable>
                            </seriestemplate>
                        </dxchartsui:WebChartControl>
                        </td>
                        <td>
                        </td>
                        </tr>
                        </table>

						</dxw:ContentControl>
					</ContentCollection>
				</dxtc:TabPage>   
				<dxtc:TabPage Text="Resumen" >
					<ContentCollection>
						<dxw:ContentControl ID="ContentControl1" runat="server">	
                            <table>
                            <tr><td align="center">
                                    <dx:ASPxLabel ID="ASPxLabel12" runat="server" Text="ESTADO SITUACIONAL DEL PRESUPUESTO" Font-Size="Large" Font-Underline="true" 
                                        Font-Names="Times New Roman" Font-Bold="False">
                                    </dx:ASPxLabel> 
                            </td>
                            </tr>
                            <tr><td>
                                <table>
                                <tr>
                                <td align="center">
                                    <dx:ASPxLabel ID="ASPxLabel6" runat="server" Text="PRESUPUESTO" Font-Size="Large" 
                                        Font-Names="Times New Roman" Font-Bold="False">
                                    </dx:ASPxLabel>
                                </td>
                                <td  align="center">
                                     <dx:ASPxLabel ID="ASPxLabel7" runat="server" Text="EJECUCION" Font-Size="Large" 
                                        Font-Names="Times New Roman" Font-Bold="False">
                                    </dx:ASPxLabel>                                           
                                </td>
                                </tr>
                                <tr valign="top">
                                <td align="center">
                                <dx:ASPxPivotGrid ID="ASPxPivotGridPresupuesto" runat="server" Visible="true" Font-Size="X-Small" 
                                onLoad="LoadASPxPivotGridPresupuesto" ClientIDMode="AutoID"  EnablePagingGestures="False"  >
                                <OptionsView ShowHorizontalScrollBar="True" ShowDataHeaders="False" ShowColumnHeaders="False" ShowRowHeaders="False"
                                            ShowFilterHeaders="False" ShowColumnGrandTotalHeader="False" ShowRowTotals="False" ShowColumnGrandTotals="True"/>
                                <Fields>
                                    <dx:PivotGridField Area="RowArea" AreaIndex="1" FieldName="ANO_EJE" 
                                            Caption="PERIODO" ID="IdAnoEje"  
                                            HeaderStyle-BackgroundImage-HorizontalPosition="center" 
                                            Options-AllowSort="False" HeaderStyle-Wrap="True">
                                    </dx:PivotGridField>
                                    <dx:PivotGridField Area="DataArea" AreaIndex="1" FieldName="PIA" 
                                            Caption="PIA" ID="IdPia"  
                                            HeaderStyle-BackgroundImage-HorizontalPosition="center" 
                                            Options-AllowSort="False" >
                                    </dx:PivotGridField> 
                                    <dx:PivotGridField Area="DataArea " AreaIndex="2" FieldName="MODIFICACION" 
                                            Caption="MODIFICACION" ID="IdModificacion"  
                                            HeaderStyle-BackgroundImage-HorizontalPosition="center" 
                                            Options-AllowSort="False" >
                                    </dx:PivotGridField> 
                                    <dx:PivotGridField Area="DataArea " AreaIndex="3" FieldName="PIM" 
                                            Caption="PIM" ID="PivotGridField1"  
                                            HeaderStyle-BackgroundImage-HorizontalPosition="center" 
                                            Options-AllowSort="False" >
                                    </dx:PivotGridField>                                      
                                </Fields>
                                </dx:ASPxPivotGrid>
                                </td>
                                <td>
                                     <dx:ASPxPivotGrid ID="ASPxPivotGridEjecucion" runat="server" Visible="true" Font-Size="X-Small"
                                    onLoad="LoadASPxPivotGridEjecucion" ClientIDMode="AutoID"  EnablePagingGestures="False" Width="800px"  >
                                    <OptionsView ShowHorizontalScrollBar="True" ShowDataHeaders="False" ShowColumnHeaders="False" ShowRowHeaders="False"
                                                ShowFilterHeaders="False" ShowColumnGrandTotals="False" />
                                    <Fields>
                                        <dx:PivotGridField Area="RowArea" AreaIndex="1" FieldName="ANO_EJE" 
                                                Caption="PERIODO" ID="PivotGridField2"  
                                                HeaderStyle-BackgroundImage-HorizontalPosition="center" 
                                                Options-AllowSort="False" HeaderStyle-Wrap="True">
                                        </dx:PivotGridField>
                                        <dx:PivotGridField Area="ColumnArea" AreaIndex="1" FieldName="MES_EJE" 
                                                Caption="MES" ID="PivotGridField3"  
                                                HeaderStyle-BackgroundImage-HorizontalPosition="center" 
                                                Options-AllowSort="False" >
                                        </dx:PivotGridField> 
                                        <dx:PivotGridField Area="DataArea" AreaIndex="2" FieldName="EJECUCION" 
                                                Caption="EJECUCION" ID="PivotGridField5"  
                                                HeaderStyle-BackgroundImage-HorizontalPosition="center" 
                                                Options-AllowSort="False" >
                                        </dx:PivotGridField>                                      
                                    </Fields>
                                    </dx:ASPxPivotGrid>                               
                                </td>
                                </tr>
                                <tr>
                                <td colspan="2">
                                <table>
                                <tr>
                                <td>
                                <dx:ASPxPivotGrid ID="ASPxPivotGenerica" runat="server" Visible="true" Font-Size="X-Small" 
                                onLoad="LoadGenerica" ClientIDMode="AutoID"  EnablePagingGestures="False"  >
                                <OptionsView ShowHorizontalScrollBar="True" ShowDataHeaders="False" ShowColumnHeaders="False" ShowRowHeaders="False"
                                            ShowFilterHeaders="False" ShowColumnGrandTotalHeader="False" ShowRowTotals="False" ShowColumnGrandTotals="True"/>
                                <Fields>
                                    <dx:PivotGridField Area="RowArea" AreaIndex="1" FieldName="GENERICA" 
                                            Caption="GENERICA" ID="PivotGridField4"  
                                            HeaderStyle-BackgroundImage-HorizontalPosition="center" 
                                            Options-AllowSort="False" HeaderStyle-Wrap="True">
                                    </dx:PivotGridField>
                                    <dx:PivotGridField Area="DataArea" AreaIndex="1" FieldName="EJECUCION" 
                                            Caption="EJECUCION" ID="PivotGridField6"  
                                            HeaderStyle-BackgroundImage-HorizontalPosition="center" 
                                            Options-AllowSort="False" >
                                    </dx:PivotGridField> 
                                    <dx:PivotGridField Area="DataArea " AreaIndex="2" FieldName="EJECUCIONPROMEDIO" 
                                            Caption="PROMEDIO MENSUAL" ID="PivotGridField7"  
                                            HeaderStyle-BackgroundImage-HorizontalPosition="center" 
                                            Options-AllowSort="False" >
                                    </dx:PivotGridField> 
                                    
                                </Fields>
                                </dx:ASPxPivotGrid>
                                </td>
                                </tr>
                                </table>
                                </td>
                                </tr>
                                </table>
                            </td></tr>

                            </table>
						</dxw:ContentControl>                        	
					</ContentCollection>
				</dxtc:TabPage>   
            </TabPages>
	    </dxtc:ASPxPageControl> 						

</td>
</tr>
</table>


</asp:Content>
