<%@ Page Language="C#" MasterPageFile="~/Modules/MasterPage.Master" AutoEventWireup="true" 
    CodeBehind="frmInfoGesConsultaAvanceObra.aspx.cs" Inherits="InfoGesRegional.Modules.Forms.Consulta.frmInfoGesConsultaAvanceObra" 
    Title="InfoGesConsultas" %>

<%@ Register Assembly="DevExpress.XtraCharts.v17.1.Web, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"  Namespace="DevExpress.XtraCharts.Web" TagPrefix="dxchartsui" %>
<%@ Register assembly="DevExpress.XtraCharts.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="dxcharts" %>

<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dxe" %>

<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dxpc" %>
<%@ Register assembly="DevExpress.XtraCharts.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="cc1" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dxw" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dxwpg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    &nbsp;<script language="javascript" type="text/javascript">
       // <![CDATA[

              
    </script>
    <div id="principal" >
    <table cellpadding="0" cellspacing="0" >
        <tr><td colspan="4">
        <table width="100%">
        <tr><td align="center" colspan="6" valign="top">
        <asp:Label ID="Label7" runat="server" Text="Curva 'S' de Avance de Obras" CssClass="divGray" Width="100%" Visible="true" Font-Size="Larger" ForeColor="Green" Font-Bold="true"></asp:Label>
        </td></tr>
        <tr>
        <td align="center"><asp:Label ID="Label2" runat="server" Text="Proyecto" CssClass="sys-font-body-Text" Width="100%"></asp:Label></td>
        <td align="center"><asp:Label ID="Label3" runat="server" Text="Grupo de la Obra" CssClass="sys-font-body-Text" Width="100%"></asp:Label></td>
        <td align="center"><asp:Label ID="Label4" runat="server" Text="Componente de la Obra" CssClass="sys-font-body-Text" Width="100%" Visible="false"></asp:Label></td >
        <td align="center"><asp:Label ID="Label5" runat="server" Text="Provincia de la Obra" CssClass="sys-font-body-Text" Width="100%" Visible="false"></asp:Label></td>
        <td align="center"><asp:Label ID="Label6" runat="server" Text="Distrito de la Obras" CssClass="sys-font-body-Text" Width="100%" Visible="false"></asp:Label></td>
        <td align="center"><asp:Label ID="Label1" runat="server" Text="Estado Registro" CssClass="sys-font-body-Text" Width="100%"></asp:Label></td>
        </tr>
        <tr> 
        <td align="center">
            <dxe:ASPxComboBox ID="CboProyecto" runat="server" 
                style="vertical-align: middle" AutoPostBack="true" Font-Size="XX-Small"  ForeColor="Blue"
            SelectedIndex="0" ValueType="System.String" Width="800px" 
                OnSelectedIndexChanged="OnSelectedindexChangedGrupo"  
                OnValueChanged="OnSelectedindexChangedGrupo" Height="21px">
            </dxe:ASPxComboBox>
        </td>
        <td align="center">
            <dxe:ASPxComboBox ID="CboGrupo" runat="server" style="vertical-align: middle" 
                AutoPostBack="true"  Font-Size="XX-Small"  ForeColor="Blue"
            SelectedIndex="0" ValueType="System.String" Width="225px" 
                OnSelectedIndexChanged="OnSelectedindexChangedComponente" Height="16px" 
                >
            </dxe:ASPxComboBox>
        </td>
        <td  align="center">
            <dxe:ASPxComboBox ID="CboComponente" runat="server" 
                style="vertical-align: middle" AutoPostBack="true"  Font-Size="XX-Small"  ForeColor="Blue" Visible="false"
            SelectedIndex="0" ValueType="System.String" Width="225px" 
                OnSelectedIndexChanged="OnSelectedindexChangedProvincia">
            </dxe:ASPxComboBox>
        </td>
        <td  align="center">
            <dxe:ASPxComboBox ID="CboProvincia" runat="server" 
                style="vertical-align: middle" AutoPostBack="true"  Font-Size="XX-Small"  ForeColor="Blue" Visible="false"
            SelectedIndex="0" ValueType="System.String" Width="225px"  
                OnSelectedIndexChanged="OnSelectedindexChangedDistrito">
            </dxe:ASPxComboBox>
        </td>
        <td  align="center">
            <dxe:ASPxComboBox ID="CboDistrito" runat="server" 
                style="vertical-align: middle" AutoPostBack="true"  Font-Size="XX-Small"  ForeColor="Blue" Visible="false"
            SelectedIndex="0" ValueType="System.String" Width="225px"  
                OnSelectedIndexChanged="OnSelectedindexChangedGrid" >
            </dxe:ASPxComboBox>
        </td>
        <td align="center">        
            <dxe:ASPxComboBox ID="CboEstadoRegistro" runat="server" 
                style="vertical-align: middle" AutoPostBack="true" ForeColor="Green" 
            SelectedIndex="0" ValueType="System.String" Width="150px" 
                OnSelectedIndexChanged="OnSelectedindexChangedEstadoRegistro" >
            </dxe:ASPxComboBox>
        </td>        
        </tr>
        </table>        
        </td>
        </tr>   
        </table>    
    <table width="100%"  class="sys-gridpanel-bgcolor">
        <tr>
        <td colspan="2"> 
        <table><tr>
            <td  CssClass="divGray">
            <dxe:ASPxButton ID="btnPdfExport" runat="server" Text="Informe Curva S [PDF] " UseSubmitBehavior="False" Visible="false"
                onclick="btnPreviewCurvaS_Click">
            </dxe:ASPxButton>
        </td>
        <td  CssClass="divGray">
            <dxe:ASPxButton ID="btnXlsExport" runat="server" Text="Ejecución SIAF" UseSubmitBehavior="False" onclick="btnPreviewSnipPopUp"  Visible="false">
                 <ClientSideEvents Click="function (s,e) {popup.Show();}" />
            </dxe:ASPxButton>
        </td>                           
        </tr>
        </table>
        </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                <dxwpg:ASPxPivotGrid id="ASPxPivotGridEjecucionAcumulada" runat="server"  Visible="false" 
                    CustomizationFieldsLeft="600" Font-Size="X-Small" OnLoad="LoadEjecuciónAcumulada" 
                    CustomizationFieldsTop="400" ClientInstanceName="pivotGrid" Width="500px" 
                    ClientIDMode="AutoID" >
                    <Fields>
                    <dxwpg:PivotGridField Area="RowArea" AreaIndex="0" FieldName="ANO_EJE"
                            Caption="PERIODO" ID="IdAnoEje"  
                            HeaderStyle-BackgroundImage-HorizontalPosition="center" 
                            Options-AllowSort="False" HeaderStyle-Wrap="True">
                    <HeaderStyle  BackgroundImage-HorizontalPosition="center">
                        <BackgroundImage HorizontalPosition="center" />
                        </HeaderStyle>
                    </dxwpg:PivotGridField>
                    <dxwpg:PivotGridField Area="RowArea" AreaIndex="1" FieldName="MES_EJE"
                            Caption="MES" ID="IdMesEje"    
                            HeaderStyle-BackgroundImage-HorizontalPosition="center" 
                            Options-AllowSort="False" HeaderStyle-Wrap="True">
                    <HeaderStyle  BackgroundImage-HorizontalPosition="center">
                        <BackgroundImage HorizontalPosition="center" />
                        </HeaderStyle>
                    </dxwpg:PivotGridField>
                    <dxwpg:PivotGridField ID="IdEjecucion" Area="DataArea" AreaIndex="0" 
                            FieldName="EJECUCIONT" Caption="GIRADO ACUM." > 
                    </dxwpg:PivotGridField>
                    <dxwpg:PivotGridField ID="IdCostoDirecto" Area="DataArea" AreaIndex="1" 
                            FieldName="COSTODIRECTOT" Caption="C. DIRECTO ACUM."  > 
                    </dxwpg:PivotGridField>
                    <dxwpg:PivotGridField ID="IdCostoTotal" Area="DataArea" AreaIndex="2" 
                            FieldName="COSTOTOTALT" Caption="C.TOTAL ACUM." > 
                    </dxwpg:PivotGridField>
                </Fields>
                            <OptionsPager RowsPerPage="100"></OptionsPager >
                <OptionsView ShowRowTotals="False"   ShowRowGrandTotals="False"  DataHeadersDisplayMode="Popup" ShowColumnTotals="False" ShowColumnGrandTotals="False" 
                            ShowCustomTotalsForSingleValues="false" ShowFilterHeaders="False" ShowHorizontalScrollBar="True" />
                <Styles CssFilePath="~/App_Themes/Glass/PivotGrid/styles.css" CssPostfix="Glass">  </Styles>
                </dxwpg:ASPxPivotGrid>												
  
            </td>
            <td  align="center" valign="top">
                <dxe:ASPxComboBox ID="ChartType" runat="server" OnValueChanged="ChartType_ValueChanged"
                    AutoPostBack="True" ValueType="System.String" />
    <dxchartsui:WebChartControl ID="WebChart" runat="server" DataSourceID="ASPxPivotGridEjecucionAcumulada"
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
                    <FillStyle>
                        <OptionsSerializable>
                            <dxcharts:SolidFillOptions />
                        </OptionsSerializable>
                    </FillStyle>
                    <PointOptionsSerializable>
                        <dxcharts:PointOptions />
                    </PointOptionsSerializable>
                </dxcharts:SideBySideBarSeriesLabel>
            </LabelSerializable>
            <LegendPointOptionsSerializable>
                <dxcharts:PointOptions />
            </LegendPointOptionsSerializable>
        </seriestemplate>
    </dxchartsui:WebChartControl>
                          
            </td>

        </tr>

        </table>
  </div>    
</asp:Content>
