<%@ Page Language="C#" MasterPageFile="~/Modules/MasterPage.Master" AutoEventWireup="true" 
    CodeBehind="frmCuadros2.aspx.cs" Inherits="InfoGesRegional.Modules.Forms.Consulta.frmCuadros2" 
    Title="InfoGesConsultas" %>



    
<%@ Register assembly="DevExpress.XtraCharts.v17.1.Web, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts.Web" tagprefix="dxchartsui" %>
<%@ Register assembly="DevExpress.XtraCharts.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="cc1" %>

<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxClasses" tagprefix="dxw" %>

<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.ASPxPivotGrid.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPivotGrid" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTabControl" tagprefix="dxtc" %>        

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPivotGrid.Export" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
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
<table>
<tr>
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
        CssPostfix="Glass" EnableDefaultAppearance="False" RightToLeft="True"  
        Width="1083px" EnableTabScrolling="true">
<Paddings Padding="0" />
    </dxtc:ASPxTabControl>
<asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile=""  XPath="//product"  ></asp:XmlDataSource>
</td>
</tr>
</table>
</td>
</tr>


<tr>
<td>
        <dxtc:ASPxPageControl ID="ASPxPageControl1" runat="server" 
        ActiveTabIndex="0" CssFilePath="~/App_Themes/Glass/Editors/styles.css" 
            CssPostfix="Glass" Height="300%" LoadingPanelText="" TabSpacing="3px" 
        Width="1079px" >
			<ContentStyle VerticalAlign="Top">
			<Border BorderColor="#AECAF0" BorderStyle="Solid" BorderWidth="1px" />
            <Border BorderStyle="Solid" BorderColor="#AECAF0" BorderWidth="1px"></Border>
			</ContentStyle>     
			<ActiveTabStyle Font-Bold="True" Font-Size="Small">
			</ActiveTabStyle>                        
			<TabPages >   
				<dxtc:TabPage Text="Resumen" >
					<ContentCollection>
						<dxw:ContentControl ID="ContentControl1" runat="server">	


                        <table>
                        <tr><td>
                        <table>
                        <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>

                        </tr>
                        </table>
                        </td>
                        </tr>
                        <tr align="center">
                        <td valign="top">
                        <dx:ASPxLabel ID="ASPxLabel12" runat="server" Text="ESTADO SITUACIONAL DEL PRESUPUESTO" Font-Size="Large" Font-Underline="true" 
                            Font-Names="Times New Roman" Font-Bold="False">
                        </dx:ASPxLabel>                         
                        </td>
                        </tr>
                        <tr>
                        <td>
                        <table>
                        <tr>
                        <td align="center">
                            <asp:CheckBox ID="chkColumnMarco" runat="server"  Text="Visualizar Columnas de Marco" Font-Size="Small"   OnCheckedChanged="chkColumnMarco_CheckedChanged" AutoPostBack="true" />                      
                        </td>
                        <td align="center">
                            <dx:ASPxCheckBox runat="server" ID="chkColumnSaldo" Text="Visualizar Columna de Saldos" AutoPostBack="true" />                       
                        </td>
                        </tr>
                        </table>
</td></tr>
                        <tr valign="top">
                        <td align="center">
                                <dxwgv:ASPxGridView ID="ASPxGridviewPresupuesto"  runat="server"    
                                    ClientInstanceName="ASPxGridviewPresupuesto" AutoGenerateColumns="False" Font-Size="X-Small">
                                    <Settings GridLines="Vertical" ShowFooter="True" />
                                    <SettingsPager Mode="ShowAllRecords"></SettingsPager>
                                     <Columns>
                                        <dxwgv:GridViewBandColumn Caption="PRESUPUESTO" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="1" >
                                        <Columns>
                                        <dxwgv:GridViewBandColumn Caption="PRESUPUESTO INICIAL" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="2" HeaderStyle-Wrap="True" >
                                        <Columns>
                                        <dxwgv:GridViewDataTextColumn FieldName="PIA" Caption="(A)" VisibleIndex="2" 
                                                HeaderStyle-HorizontalAlign="Center" Settings-AllowDragDrop="False" 
                                                Settings-AllowSort="False" PropertiesTextEdit-DisplayFormatString="c">
<PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>

<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            </dxwgv:GridViewDataTextColumn>
                                        </Columns>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>
                                        </dxwgv:GridViewBandColumn>
                                        <dxwgv:GridViewBandColumn Caption="MODIFICACIONES" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="3" HeaderStyle-Wrap="True"  >
                                        <Columns>
                                        <dxwgv:GridViewDataTextColumn FieldName="MODIFICACION" Caption="(B)" 
                                                VisibleIndex="3" HeaderStyle-HorizontalAlign="Center" 
                                                Settings-AllowDragDrop="False" Settings-AllowSort="False"  
                                                PropertiesTextEdit-DisplayFormatString="c">
<PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>

<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            </dxwgv:GridViewDataTextColumn>
                                        </Columns>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>
                                        </dxwgv:GridViewBandColumn>
                                        <dxwgv:GridViewBandColumn Caption="PIM" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="4" HeaderStyle-Wrap="True"  >
                                        <Columns>
                                        <dxwgv:GridViewDataTextColumn FieldName="PIM" Caption="(C)" VisibleIndex="4" 
                                                HeaderStyle-HorizontalAlign="Center" Settings-AllowDragDrop="False" 
                                                Settings-AllowSort="False"  PropertiesTextEdit-DisplayFormatString="c">
<PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>

<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            </dxwgv:GridViewDataTextColumn>
                                        </Columns>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>
                                        </dxwgv:GridViewBandColumn>
                                        </Columns>

<HeaderStyle HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>
                                        </dxwgv:GridViewBandColumn>
                                        <dxwgv:GridViewBandColumn Caption="FASE" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="5" >
                                        <Columns>
                                           <dxwgv:GridViewDataTextColumn FieldName="COMPROMISO" Caption="COMPROMISO" 
                                                HeaderStyle-Font-Bold="true" VisibleIndex="7" 
                                                HeaderStyle-HorizontalAlign="Center" Settings-AllowDragDrop="False" 
                                                Settings-AllowSort="False"  PropertiesTextEdit-DisplayFormatString="c">
<PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>

<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>
                                            </dxwgv:GridViewDataTextColumn>
                                           <dxwgv:GridViewDataTextColumn FieldName="DEVENGADO" Caption="DEVENGADO" 
                                                HeaderStyle-Font-Bold="true" VisibleIndex="7" 
                                                HeaderStyle-HorizontalAlign="Center" Settings-AllowDragDrop="False" 
                                                Settings-AllowSort="False"  PropertiesTextEdit-DisplayFormatString="c">
<PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>

<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>
                                            </dxwgv:GridViewDataTextColumn>
                                           <dxwgv:GridViewDataTextColumn FieldName="GIRADO" Caption="GIRADO" 
                                                HeaderStyle-Font-Bold="true" VisibleIndex="7" 
                                                HeaderStyle-HorizontalAlign="Center" Settings-AllowDragDrop="False" 
                                                Settings-AllowSort="False"  PropertiesTextEdit-DisplayFormatString="c">

<PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>

<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>
                                            </dxwgv:GridViewDataTextColumn>

                                        </Columns>

<HeaderStyle HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>
                                        </dxwgv:GridViewBandColumn>

                                        <dxwgv:GridViewBandColumn Caption="EJECUCION" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="5" >
                                        <Columns>
                                            <dxwgv:GridViewBandColumn Caption="ACUMULADA" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="6" HeaderStyle-Wrap="True"  >
                                            <Columns>
                                            <dxwgv:GridViewDataTextColumn FieldName="DEVENGADO" Caption="(D)" VisibleIndex="7" 
                                                    HeaderStyle-HorizontalAlign="Center" Settings-AllowDragDrop="False" 
                                                    Settings-AllowSort="False"  PropertiesTextEdit-DisplayFormatString="c">
<PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>

<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </dxwgv:GridViewDataTextColumn>
                                            <dxwgv:GridViewDataTextColumn FieldName="PORCENTAJE_EJECUCION" Caption="%" PropertiesTextEdit-Style-Font-Bold="true" PropertiesTextEdit-Style-ForeColor="Red"
                                                    HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="Red" VisibleIndex="7" 
                                                    HeaderStyle-HorizontalAlign="Center" Settings-AllowDragDrop="False" 
                                                    Settings-AllowSort="False">
<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center" Font-Bold="True" ForeColor="Red"></HeaderStyle>
                                                </dxwgv:GridViewDataTextColumn>
                                            </Columns>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>
                                            </dxwgv:GridViewBandColumn>
                                            <dxwgv:GridViewBandColumn Caption="PROMEDIO MENSUAL" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="8" HeaderStyle-Wrap="True"  >
                                            <Columns>
                                            <dxwgv:GridViewDataTextColumn FieldName="PROMEDIO_MENSUAL" Caption="(E)" 
                                                    VisibleIndex="9" HeaderStyle-HorizontalAlign="Center" 
                                                    Settings-AllowDragDrop="False" Settings-AllowSort="False"  
                                                    PropertiesTextEdit-DisplayFormatString="c">
<PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>

<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </dxwgv:GridViewDataTextColumn>
                                            <dxwgv:GridViewDataTextColumn FieldName="PORCENTAJE_MENSUAL" Caption="%" 
                                                    VisibleIndex="9" HeaderStyle-HorizontalAlign="Center" 
                                                    Settings-AllowDragDrop="False" Settings-AllowSort="False">
<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </dxwgv:GridViewDataTextColumn>
                                            </Columns>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>
                                            </dxwgv:GridViewBandColumn>


                                        </Columns>

<HeaderStyle HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>
                                        </dxwgv:GridViewBandColumn>
                                        <dxwgv:GridViewBandColumn Caption="SALDOS" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="10" >
                                        <Columns>
                                            <dxwgv:GridViewBandColumn Caption="MARCO" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="11" HeaderStyle-Wrap="True"  >
                                            <Columns>
                                            <dxwgv:GridViewDataTextColumn FieldName="SALDO_PIM" Caption="F=(C-D)" 
                                                    VisibleIndex="12" HeaderStyle-HorizontalAlign="Center" 
                                                    Settings-AllowDragDrop="False" Settings-AllowSort="False"  
                                                    PropertiesTextEdit-DisplayFormatString="c">
<PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>

<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </dxwgv:GridViewDataTextColumn>
                                            <dxwgv:GridViewDataTextColumn FieldName="PORCENTAJE_PIM" Caption="%" 
                                                    VisibleIndex="12" HeaderStyle-HorizontalAlign="Center" 
                                                    Settings-AllowDragDrop="False" Settings-AllowSort="False" >
<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </dxwgv:GridViewDataTextColumn>
                                            </Columns>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>
                                            </dxwgv:GridViewBandColumn>
                                            <dxwgv:GridViewBandColumn Caption="PROYECTADO" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="13" HeaderStyle-Wrap="True"  >
                                            <Columns>
                                            <dxwgv:GridViewDataTextColumn FieldName="SALDO_PROYECTADO" Caption="(F-E)" 
                                                    VisibleIndex="14" HeaderStyle-HorizontalAlign="Center" 
                                                    Settings-AllowDragDrop="False" Settings-AllowSort="False"  
                                                    PropertiesTextEdit-DisplayFormatString="c">
<PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>

<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </dxwgv:GridViewDataTextColumn>
                                            <dxwgv:GridViewDataTextColumn FieldName="PORCENTAJE_PROYECTADO" Caption="%" 
                                                    VisibleIndex="14" HeaderStyle-HorizontalAlign="Center" 
                                                    Settings-AllowDragDrop="False" Settings-AllowSort="False">
<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </dxwgv:GridViewDataTextColumn>
                                            </Columns>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>
                                            </dxwgv:GridViewBandColumn>

                                        </Columns>

<HeaderStyle HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>
                                        </dxwgv:GridViewBandColumn>
                                    </Columns> 
                                </dxwgv:ASPxGridView>
                        </td>
                            </tr>
                        <tr>
                        <td>
                                <dx:ASPxPivotGrid ID="ASPxPivotGridEjecucion" runat="server" Font-Size="X-Small" Visible="false"
                            onLoad="LoadASPxPivotGridEjecucion" ClientIDMode="AutoID"  EnablePagingGestures="False" Width="110%"  >
                            <OptionsView ShowHorizontalScrollBar="True" ShowDataHeaders="False" ShowColumnHeaders="False" ShowRowHeaders="False"
                                        ShowFilterHeaders="False" ShowColumnGrandTotals="False" />
                            <Fields>
                                <dx:PivotGridField Area="RowArea" AreaIndex="1" FieldName="ANO_EJE" 
                                        Caption="PERIODO" ID="PivotGridField2" Visible="False"
                                        HeaderStyle-BackgroundImage-HorizontalPosition="center" 
                                        Options-AllowSort="False" HeaderStyle-Wrap="True">
<HeaderStyle Wrap="True">
<BackgroundImage HorizontalPosition="center"></BackgroundImage>
</HeaderStyle>
                                </dx:PivotGridField>
                                <dx:PivotGridField Area="ColumnArea" AreaIndex="1" FieldName="MES_EJE" 
                                        Caption="MES" ID="PivotGridField3"  
                                        HeaderStyle-BackgroundImage-HorizontalPosition="center" 
                                        Options-AllowSort="False" > 
<HeaderStyle>
<BackgroundImage HorizontalPosition="center"></BackgroundImage>
</HeaderStyle>
                                </dx:PivotGridField>
                                <dx:PivotGridField Area="DataArea" AreaIndex="2" FieldName="EJECUCION" 
                                        Caption="EJECUCION" ID="PivotGridField5"  
                                        HeaderStyle-BackgroundImage-HorizontalPosition="center" 
                                        Options-AllowSort="False">                                      
<HeaderStyle>
<BackgroundImage HorizontalPosition="center"></BackgroundImage>
</HeaderStyle>
                                </dx:PivotGridField>
                            </Fields>

                            </dx:ASPxPivotGrid>                               
                        </td>
                        </tr>
                        <tr>
                        <td>
                        <table>
                        <tr>
                            <td align="center">                                    
                                <dx:ASPxLabel ID="ASPxLabel8" runat="server" Text="POR CONCEPTO" Font-Size="Large" Font-Names="Times New Roman" Font-Bold="False" AutoPostBack="true">
                                </dx:ASPxLabel></td>
                            <td align="center">                                    
                                <dx:ASPxLabel ID="ASPxLabel9" runat="server" Text="POR FUNCION" Font-Size="Large" Font-Names="Times New Roman" Font-Bold="False">
                                </dx:ASPxLabel></td>
                        </tr>
                        <tr><td valign="top">
                                <dxwgv:ASPxGridView ID="ASPxGridviewPorconcepto"  runat="server"    
                                    ClientInstanceName="ASPxGridviewPorconcepto" AutoGenerateColumns="False" Font-Size="X-Small">
                                    <Settings GridLines="Vertical" ShowFooter="True" />
                                    <SettingsPager Mode="ShowAllRecords"></SettingsPager>
                                    <TotalSummary>
                                    <dxwgv:ASPxSummaryItem FieldName="DEVENGADO" SummaryType="Sum" DisplayFormat="c"/>
                                    <dxwgv:ASPxSummaryItem FieldName="PROMEDIO_MENSUAL" SummaryType="Sum" DisplayFormat="c"/>
                                    <dxwgv:ASPxSummaryItem FieldName="SALDO_PIM" SummaryType="Sum" DisplayFormat="c"/>
                                    <dxwgv:ASPxSummaryItem FieldName="PIM" SummaryType="Sum" DisplayFormat="c"/>
                                    <dxwgv:ASPxSummaryItem FieldName="SALDO_PROYECTADO" SummaryType="Sum" DisplayFormat="c"/>
                                    </TotalSummary>
                                     <Columns>
                                       <dxwgv:GridViewDataTextColumn FieldName="ESPECIFICA_DET_NOMBRE" 
                                             Caption="CONCEPTO" VisibleIndex="0" HeaderStyle-HorizontalAlign="Center" 
                                             Settings-AllowDragDrop="False" Settings-AllowSort="False" Width="80%" >

                                         </dxwgv:GridViewDataTextColumn>
                                        <dxwgv:GridViewBandColumn Caption="PRESUPUESTO" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="1"  Visible="false">
                                        <Columns>
                                        <dxwgv:GridViewBandColumn Caption="PIM" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="4" HeaderStyle-Wrap="True"  >
                                        <Columns>
                                        <dxwgv:GridViewDataTextColumn FieldName="PIM" Caption="(C)" VisibleIndex="4" 
                                                HeaderStyle-HorizontalAlign="Center" Settings-AllowDragDrop="False" 
                                                Settings-AllowSort="False"  PropertiesTextEdit-DisplayFormatString="c">
                                            </dxwgv:GridViewDataTextColumn>
                                        </Columns>
                                        </dxwgv:GridViewBandColumn>
                                        </Columns>

                                        </dxwgv:GridViewBandColumn>
                                        <dxwgv:GridViewBandColumn Caption="EJECUCION" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="5" >
                                        <Columns>
                                            <dxwgv:GridViewBandColumn Caption="ACUMULADA" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="6" HeaderStyle-Wrap="True"  >
                                            <Columns>
                                            <dxwgv:GridViewDataTextColumn FieldName="DEVENGADO" Caption="(D)" VisibleIndex="7" 
                                                    HeaderStyle-HorizontalAlign="Center" Settings-AllowDragDrop="False" 
                                                    Settings-AllowSort="False"  PropertiesTextEdit-DisplayFormatString="c">
<PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>

<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </dxwgv:GridViewDataTextColumn>
                                            <dxwgv:GridViewDataTextColumn FieldName="PORCENTAJE_EJECUCION" Caption="%" 
                                                    VisibleIndex="7" HeaderStyle-HorizontalAlign="Center" 
                                                    Settings-AllowDragDrop="False" Settings-AllowSort="False">
<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </dxwgv:GridViewDataTextColumn>
                                            </Columns>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>
                                            </dxwgv:GridViewBandColumn>
                                            <dxwgv:GridViewBandColumn Caption="PROMEDIO MENSUAL" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="8" HeaderStyle-Wrap="True"  >
                                            <Columns>
                                            <dxwgv:GridViewDataTextColumn FieldName="PROMEDIO_MENSUAL" Caption="(E)" 
                                                    VisibleIndex="9" HeaderStyle-HorizontalAlign="Center" 
                                                    Settings-AllowDragDrop="False" Settings-AllowSort="False"  
                                                    PropertiesTextEdit-DisplayFormatString="c">
<PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>

<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </dxwgv:GridViewDataTextColumn>
                                            <dxwgv:GridViewDataTextColumn FieldName="PORCENTAJE_MENSUAL" Caption="%" 
                                                    VisibleIndex="9" HeaderStyle-HorizontalAlign="Center" 
                                                    Settings-AllowDragDrop="False" Settings-AllowSort="False">
<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </dxwgv:GridViewDataTextColumn>
                                            </Columns>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>
                                            </dxwgv:GridViewBandColumn>

                                        </Columns>

                                        </dxwgv:GridViewBandColumn>
                                        <dxwgv:GridViewBandColumn Caption="SALDOS" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="10" visible="false">
                                        <Columns>
                                            <dxwgv:GridViewBandColumn Caption="MARCO" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="11" HeaderStyle-Wrap="True"  >
                                            <Columns>
                                            <dxwgv:GridViewDataTextColumn FieldName="SALDO_PIM" Caption="F=(C-D)" 
                                                    VisibleIndex="12" HeaderStyle-HorizontalAlign="Center" 
                                                    Settings-AllowDragDrop="False" Settings-AllowSort="False"  
                                                    PropertiesTextEdit-DisplayFormatString="c">
<PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>

<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </dxwgv:GridViewDataTextColumn>
                                            <dxwgv:GridViewDataTextColumn FieldName="PORCENTAJE_PIM" Caption="%" 
                                                    VisibleIndex="12" HeaderStyle-HorizontalAlign="Center" 
                                                    Settings-AllowDragDrop="False" Settings-AllowSort="False" >
<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </dxwgv:GridViewDataTextColumn>
                                            </Columns>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>
                                            </dxwgv:GridViewBandColumn>
                                            <dxwgv:GridViewBandColumn Caption="PROYECTADO" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="13" HeaderStyle-Wrap="True"  >
                                            <Columns>
                                            <dxwgv:GridViewDataTextColumn FieldName="SALDO_PROYECTADO" Caption="(F-E)" 
                                                    VisibleIndex="14" HeaderStyle-HorizontalAlign="Center" 
                                                    Settings-AllowDragDrop="False" Settings-AllowSort="False"  
                                                    PropertiesTextEdit-DisplayFormatString="c">
<PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>

<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </dxwgv:GridViewDataTextColumn>
                                            <dxwgv:GridViewDataTextColumn FieldName="PORCENTAJE_PROYECTADO" Caption="%" 
                                                    VisibleIndex="14" HeaderStyle-HorizontalAlign="Center" 
                                                    Settings-AllowDragDrop="False" Settings-AllowSort="False">
<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </dxwgv:GridViewDataTextColumn>
                                            </Columns>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>
                                            </dxwgv:GridViewBandColumn>

                                        </Columns>

<HeaderStyle HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>
                                        </dxwgv:GridViewBandColumn>
                                    </Columns> 
                                </dxwgv:ASPxGridView>
                        </td>
                        <td valign="top">
                                <dxwgv:ASPxGridView ID="ASPxGridviewPorFuncion"  runat="server"    
                                    ClientInstanceName="ASPxGridviewPorFuncion" AutoGenerateColumns="False" Font-Size="X-Small">
                                    <Settings GridLines="Vertical" ShowFooter="True" />
                                    <SettingsPager Mode="ShowAllRecords"></SettingsPager>
                                     <Columns>
                                       <dxwgv:GridViewDataTextColumn FieldName="FUNCION_NOMBRE" Caption="FUNCION" 
                                             VisibleIndex="0" HeaderStyle-HorizontalAlign="Center" 
                                             Settings-AllowDragDrop="False" Settings-AllowSort="False" Width="80%" >
                                         </dxwgv:GridViewDataTextColumn>
                                        <dxwgv:GridViewBandColumn Caption="PRESUPUESTO" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="1">
                                        <Columns>
                                        <dxwgv:GridViewBandColumn Caption="PIM" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="4" HeaderStyle-Wrap="True"  >
                                        <Columns>
                                        <dxwgv:GridViewDataTextColumn FieldName="PIM" Caption="(C)" VisibleIndex="4" 
                                                HeaderStyle-HorizontalAlign="Center" Settings-AllowDragDrop="False" 
                                                Settings-AllowSort="False"  PropertiesTextEdit-DisplayFormatString="c">
                                            </dxwgv:GridViewDataTextColumn>
                                        </Columns>
                                        </dxwgv:GridViewBandColumn>
                                        </Columns>
                                        </dxwgv:GridViewBandColumn>
                                        <dxwgv:GridViewBandColumn Caption="EJECUCION" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="5" >
                                        <Columns>
                                            <dxwgv:GridViewBandColumn Caption="ACUMULADA" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="6" HeaderStyle-Wrap="True"  >
                                            <Columns>
                                            <dxwgv:GridViewDataTextColumn FieldName="DEVENGADO" Caption="(D)" VisibleIndex="7" 
                                                    HeaderStyle-HorizontalAlign="Center" Settings-AllowDragDrop="False" 
                                                    Settings-AllowSort="False"  PropertiesTextEdit-DisplayFormatString="c">
                                                </dxwgv:GridViewDataTextColumn>
                                            <dxwgv:GridViewDataTextColumn FieldName="PORCENTAJE_EJECUCION" Caption="%" 
                                                    VisibleIndex="7" HeaderStyle-HorizontalAlign="Center" 
                                                    Settings-AllowDragDrop="False" Settings-AllowSort="False">
                                                </dxwgv:GridViewDataTextColumn>
                                            </Columns>
                                            </dxwgv:GridViewBandColumn>
                                            <dxwgv:GridViewBandColumn Caption="PROMEDIO MENSUAL" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="8" HeaderStyle-Wrap="True"  >
                                            <Columns>
                                            <dxwgv:GridViewDataTextColumn FieldName="PROMEDIO_MENSUAL" Caption="(E)" 
                                                    VisibleIndex="9" HeaderStyle-HorizontalAlign="Center" 
                                                    Settings-AllowDragDrop="False" Settings-AllowSort="False"  
                                                    PropertiesTextEdit-DisplayFormatString="c">
                                                </dxwgv:GridViewDataTextColumn>
                                            <dxwgv:GridViewDataTextColumn FieldName="PORCENTAJE_MENSUAL" Caption="%" 
                                                    VisibleIndex="9" HeaderStyle-HorizontalAlign="Center" 
                                                    Settings-AllowDragDrop="False" Settings-AllowSort="False">
                                                </dxwgv:GridViewDataTextColumn>
                                            </Columns>
                                            </dxwgv:GridViewBandColumn>

                                        </Columns>
                                        </dxwgv:GridViewBandColumn>
                                        <dxwgv:GridViewBandColumn Caption="SALDOS" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="10"  visible="false">
                                        <Columns>
                                            <dxwgv:GridViewBandColumn Caption="MARCO" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="11" HeaderStyle-Wrap="True"  >
                                            <Columns>
                                            <dxwgv:GridViewDataTextColumn FieldName="SALDO_PIM" Caption="F=(C-D)" 
                                                    VisibleIndex="12" HeaderStyle-HorizontalAlign="Center" 
                                                    Settings-AllowDragDrop="False" Settings-AllowSort="False"  
                                                    PropertiesTextEdit-DisplayFormatString="c">
                                                </dxwgv:GridViewDataTextColumn>
                                            <dxwgv:GridViewDataTextColumn FieldName="PORCENTAJE_PIM" Caption="%" 
                                                    VisibleIndex="12" HeaderStyle-HorizontalAlign="Center" 
                                                    Settings-AllowDragDrop="False" Settings-AllowSort="False" >
                                                </dxwgv:GridViewDataTextColumn>
                                            </Columns>
                                            </dxwgv:GridViewBandColumn>
                                            <dxwgv:GridViewBandColumn Caption="PROYECTADO" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="13" HeaderStyle-Wrap="True"  >
                                            <Columns>
                                            <dxwgv:GridViewDataTextColumn FieldName="SALDO_PROYECTADO" Caption="(F-E)" 
                                                    VisibleIndex="14" HeaderStyle-HorizontalAlign="Center" 
                                                    Settings-AllowDragDrop="False" Settings-AllowSort="False"  
                                                    PropertiesTextEdit-DisplayFormatString="c">
                                                </dxwgv:GridViewDataTextColumn>
                                            <dxwgv:GridViewDataTextColumn FieldName="PORCENTAJE_PROYECTADO" Caption="%" 
                                                    VisibleIndex="14" HeaderStyle-HorizontalAlign="Center" 
                                                    Settings-AllowDragDrop="False" Settings-AllowSort="False">
                                                </dxwgv:GridViewDataTextColumn>
                                            </Columns>

                                            </dxwgv:GridViewBandColumn>

                                        </Columns>
                                        </dxwgv:GridViewBandColumn>
                                    </Columns> 
                                </dxwgv:ASPxGridView>                        
                        </td>
                        </tr>
                        </table>
                        </td>
                        </tr>
                        <tr><td>
                        <table>
                         <tr>
                            <td align="center">                                    
                                <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="POR GENERICA" Font-Size="Large" Font-Names="Times New Roman" Font-Bold="False">
                                </dx:ASPxLabel></td>
                            <td align="center">                                    
                                <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="POR RUBRO" Font-Size="Large" Font-Names="Times New Roman" Font-Bold="False">
                                </dx:ASPxLabel></td>
                        </tr>                       
                        <tr>
                        <td valign="top">
                                <dxwgv:ASPxGridView ID="ASPxGridviewPorGenerica"  runat="server"    
                                    ClientInstanceName="ASPxGridviewPorGenerica" AutoGenerateColumns="False" Font-Size="X-Small">
                                    <Settings GridLines="Vertical" ShowFooter="True" />
                                    <SettingsPager Mode="ShowAllRecords"></SettingsPager>
                                     <Columns>
                                       <dxwgv:GridViewDataTextColumn FieldName="GENERICA" Caption="GENERICA" 
                                             VisibleIndex="0" HeaderStyle-HorizontalAlign="Center" 
                                             Settings-AllowDragDrop="False" Settings-AllowSort="False" Width="80%" >
<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                         </dxwgv:GridViewDataTextColumn>
                                        <dxwgv:GridViewBandColumn Caption="PRESUPUESTO" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="1"  visible="false" >
                                        <Columns>
                                        <dxwgv:GridViewBandColumn Caption="PIM" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="4" HeaderStyle-Wrap="True"  >
                                        <Columns>
                                        <dxwgv:GridViewDataTextColumn FieldName="PIM" Caption="(C)" VisibleIndex="4" 
                                                HeaderStyle-HorizontalAlign="Center" Settings-AllowDragDrop="False" 
                                                Settings-AllowSort="False"  PropertiesTextEdit-DisplayFormatString="c">
<PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>

<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            </dxwgv:GridViewDataTextColumn>
                                        </Columns>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>
                                        </dxwgv:GridViewBandColumn>
                                        </Columns>

<HeaderStyle HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>
                                        </dxwgv:GridViewBandColumn>
                                        <dxwgv:GridViewBandColumn Caption="EJECUCION" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="5" >
                                        <Columns>
                                            <dxwgv:GridViewBandColumn Caption="ACUMULADA" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="6" HeaderStyle-Wrap="True"  >
                                            <Columns>
                                            <dxwgv:GridViewDataTextColumn FieldName="DEVENGADO" Caption="(D)" VisibleIndex="7" 
                                                    HeaderStyle-HorizontalAlign="Center" Settings-AllowDragDrop="False" 
                                                    Settings-AllowSort="False"  PropertiesTextEdit-DisplayFormatString="c">
<PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>

<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </dxwgv:GridViewDataTextColumn>
                                            <dxwgv:GridViewDataTextColumn FieldName="PORCENTAJE_EJECUCION" Caption="%" 
                                                    VisibleIndex="7" HeaderStyle-HorizontalAlign="Center" 
                                                    Settings-AllowDragDrop="False" Settings-AllowSort="False">
<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </dxwgv:GridViewDataTextColumn>
                                            </Columns>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>
                                            </dxwgv:GridViewBandColumn>
                                            <dxwgv:GridViewBandColumn Caption="PROMEDIO MENSUAL" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="8" HeaderStyle-Wrap="True"  >
                                            <Columns>
                                            <dxwgv:GridViewDataTextColumn FieldName="PROMEDIO_MENSUAL" Caption="(E)" 
                                                    VisibleIndex="9" HeaderStyle-HorizontalAlign="Center" 
                                                    Settings-AllowDragDrop="False" Settings-AllowSort="False"  
                                                    PropertiesTextEdit-DisplayFormatString="c">
<PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>

<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </dxwgv:GridViewDataTextColumn>
                                            <dxwgv:GridViewDataTextColumn FieldName="PORCENTAJE_MENSUAL" Caption="%" 
                                                    VisibleIndex="9" HeaderStyle-HorizontalAlign="Center" 
                                                    Settings-AllowDragDrop="False" Settings-AllowSort="False">
<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </dxwgv:GridViewDataTextColumn>
                                            </Columns>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>
                                            </dxwgv:GridViewBandColumn>

                                        </Columns>

<HeaderStyle HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>
                                        </dxwgv:GridViewBandColumn>
                                        <dxwgv:GridViewBandColumn Caption="SALDOS" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="10"  visible="false" >
                                        <Columns>
                                            <dxwgv:GridViewBandColumn Caption="MARCO" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="11" HeaderStyle-Wrap="True"  >
                                            <Columns>
                                            <dxwgv:GridViewDataTextColumn FieldName="SALDO_PIM" Caption="F=(C-D)" 
                                                    VisibleIndex="12" HeaderStyle-HorizontalAlign="Center" 
                                                    Settings-AllowDragDrop="False" Settings-AllowSort="False"  
                                                    PropertiesTextEdit-DisplayFormatString="c">
<PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>

<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </dxwgv:GridViewDataTextColumn>
                                            <dxwgv:GridViewDataTextColumn FieldName="PORCENTAJE_PIM" Caption="%" 
                                                    VisibleIndex="12" HeaderStyle-HorizontalAlign="Center" 
                                                    Settings-AllowDragDrop="False" Settings-AllowSort="False" >
<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </dxwgv:GridViewDataTextColumn>
                                            </Columns>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>
                                            </dxwgv:GridViewBandColumn>
                                            <dxwgv:GridViewBandColumn Caption="PROYECTADO" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="13" HeaderStyle-Wrap="True"  >
                                            <Columns>
                                            <dxwgv:GridViewDataTextColumn FieldName="SALDO_PROYECTADO" Caption="(F-E)" 
                                                    VisibleIndex="14" HeaderStyle-HorizontalAlign="Center" 
                                                    Settings-AllowDragDrop="False" Settings-AllowSort="False"  
                                                    PropertiesTextEdit-DisplayFormatString="c">
<PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>

<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </dxwgv:GridViewDataTextColumn>
                                            <dxwgv:GridViewDataTextColumn FieldName="PORCENTAJE_PROYECTADO" Caption="%" 
                                                    VisibleIndex="14" HeaderStyle-HorizontalAlign="Center" 
                                                    Settings-AllowDragDrop="False" Settings-AllowSort="False">
<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </dxwgv:GridViewDataTextColumn>
                                            </Columns>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>
                                            </dxwgv:GridViewBandColumn>

                                        </Columns>

<HeaderStyle HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>
                                        </dxwgv:GridViewBandColumn>
                                    </Columns> 
                                </dxwgv:ASPxGridView>  

                        </td>
                        <td valign="top">
                                <dxwgv:ASPxGridView ID="ASPxGridviewPorRubro"  runat="server"    
                                    ClientInstanceName="ASPxGridviewPorRubro" AutoGenerateColumns="False" Font-Size="X-Small">
                                    <Settings GridLines="Vertical" ShowFooter="True" />
                                    <SettingsPager Mode="ShowAllRecords"></SettingsPager>
                                     <Columns>
                                       <dxwgv:GridViewDataTextColumn FieldName="FUENTE_FINANC" Caption="RUBRO" 
                                             VisibleIndex="0" HeaderStyle-HorizontalAlign="Center" 
                                             Settings-AllowDragDrop="False" Settings-AllowSort="False" Width="80%" >
<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                         </dxwgv:GridViewDataTextColumn>
                                        <dxwgv:GridViewBandColumn Caption="PRESUPUESTO" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="1"  visible="false">
                                        <Columns>
                                        <dxwgv:GridViewBandColumn Caption="PIM" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="4" HeaderStyle-Wrap="True"  >
                                        <Columns>
                                        <dxwgv:GridViewDataTextColumn FieldName="PIM" Caption="(C)" VisibleIndex="4" 
                                                HeaderStyle-HorizontalAlign="Center" Settings-AllowDragDrop="False" 
                                                Settings-AllowSort="False"  PropertiesTextEdit-DisplayFormatString="c">
<PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>

<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            </dxwgv:GridViewDataTextColumn>
                                        </Columns>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>
                                        </dxwgv:GridViewBandColumn>
                                        </Columns>

<HeaderStyle HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>
                                        </dxwgv:GridViewBandColumn>
                                        <dxwgv:GridViewBandColumn Caption="EJECUCION" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="5" >
                                        <Columns>
                                            <dxwgv:GridViewBandColumn Caption="ACUMULADA" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="6" HeaderStyle-Wrap="True"  >
                                            <Columns>
                                            <dxwgv:GridViewDataTextColumn FieldName="DEVENGADO" Caption="(D)" VisibleIndex="7" 
                                                    HeaderStyle-HorizontalAlign="Center" Settings-AllowDragDrop="False" 
                                                    Settings-AllowSort="False"  PropertiesTextEdit-DisplayFormatString="c">
<PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>

<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </dxwgv:GridViewDataTextColumn>
                                            <dxwgv:GridViewDataTextColumn FieldName="PORCENTAJE_EJECUCION" Caption="%" 
                                                    VisibleIndex="7" HeaderStyle-HorizontalAlign="Center" 
                                                    Settings-AllowDragDrop="False" Settings-AllowSort="False">
<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </dxwgv:GridViewDataTextColumn>
                                            </Columns>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>
                                            </dxwgv:GridViewBandColumn>
                                            <dxwgv:GridViewBandColumn Caption="PROMEDIO MENSUAL" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="8" HeaderStyle-Wrap="True"  >
                                            <Columns>
                                            <dxwgv:GridViewDataTextColumn FieldName="PROMEDIO_MENSUAL" Caption="(E)" 
                                                    VisibleIndex="9" HeaderStyle-HorizontalAlign="Center" 
                                                    Settings-AllowDragDrop="False" Settings-AllowSort="False"  
                                                    PropertiesTextEdit-DisplayFormatString="c">
<PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>

<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </dxwgv:GridViewDataTextColumn>
                                            <dxwgv:GridViewDataTextColumn FieldName="PORCENTAJE_MENSUAL" Caption="%" 
                                                    VisibleIndex="9" HeaderStyle-HorizontalAlign="Center" 
                                                    Settings-AllowDragDrop="False" Settings-AllowSort="False">
<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </dxwgv:GridViewDataTextColumn>
                                            </Columns>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>
                                            </dxwgv:GridViewBandColumn>

                                        </Columns>

<HeaderStyle HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>
                                        </dxwgv:GridViewBandColumn>
                                        <dxwgv:GridViewBandColumn Caption="SALDOS" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="10"  visible="false" >
                                        <Columns>
                                            <dxwgv:GridViewBandColumn Caption="MARCO" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="11" HeaderStyle-Wrap="True"  >
                                            <Columns>
                                            <dxwgv:GridViewDataTextColumn FieldName="SALDO_PIM" Caption="F=(C-D)" 
                                                    VisibleIndex="12" HeaderStyle-HorizontalAlign="Center" 
                                                    Settings-AllowDragDrop="False" Settings-AllowSort="False"  
                                                    PropertiesTextEdit-DisplayFormatString="c">
<PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>

<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </dxwgv:GridViewDataTextColumn>
                                            <dxwgv:GridViewDataTextColumn FieldName="PORCENTAJE_PIM" Caption="%" 
                                                    VisibleIndex="12" HeaderStyle-HorizontalAlign="Center" 
                                                    Settings-AllowDragDrop="False" Settings-AllowSort="False" >
<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </dxwgv:GridViewDataTextColumn>
                                            </Columns>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>
                                            </dxwgv:GridViewBandColumn>
                                            <dxwgv:GridViewBandColumn Caption="PROYECTADO" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="13" HeaderStyle-Wrap="True"  >
                                            <Columns>
                                            <dxwgv:GridViewDataTextColumn FieldName="SALDO_PROYECTADO" Caption="(F-E)" 
                                                    VisibleIndex="14" HeaderStyle-HorizontalAlign="Center" 
                                                    Settings-AllowDragDrop="False" Settings-AllowSort="False"  
                                                    PropertiesTextEdit-DisplayFormatString="c">
<PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>

<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </dxwgv:GridViewDataTextColumn>
                                            <dxwgv:GridViewDataTextColumn FieldName="PORCENTAJE_PROYECTADO" Caption="%" 
                                                    VisibleIndex="14" HeaderStyle-HorizontalAlign="Center" 
                                                    Settings-AllowDragDrop="False" Settings-AllowSort="False">
<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </dxwgv:GridViewDataTextColumn>
                                            </Columns>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>
                                            </dxwgv:GridViewBandColumn>

                                        </Columns>

<HeaderStyle HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>
                                        </dxwgv:GridViewBandColumn>
                                    </Columns> 
                                </dxwgv:ASPxGridView>  


                        </td>
                        </tr>
                        </table>
                                                
                        </td>
                        </tr>
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
