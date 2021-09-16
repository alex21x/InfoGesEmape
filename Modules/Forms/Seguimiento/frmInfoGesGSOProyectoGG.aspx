<%@ Page Language="C#" MasterPageFile="../../MasterPage.Master" AutoEventWireup="true"  CodeBehind="frmInfoGesGSOProyectoGG.aspx.cs" Inherits="InfogesEmape.Modules.Forms.Seguimiento.frmInfoGesGSOProyectoGG" 
    Title="InfoGesConsultas" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.XtraReports.v17.1.Web, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Dashboard.v17.1.Web, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"  Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <script type="text/javascript">
        function OnMoreInfoClick(contentUrl) {
            clientPopupControl.SetContentUrl(contentUrl);
            clientPopupControl.Show();
        }
        function OnMoreInfoClick1(contentUrl) {
            popupPDF.SetContentUrl(contentUrl);
            popupPDF.Show();
        };
     </script>

    <style type="text/css">  
        div.customFont table {  
            font-size: 10px;  
        }  
        .dx-pivotgrid
        {
        font-size: 10px ;
        height :auto;
        }
        .dx-Gauge
        {
        font-size: 10px ;
        }    
        .dx-pivot-item,
        .dx-pivot-item-content {
          width: 100%;
          height: 100%;
        }
        
        .dx-treelist-container .dx-sort-up {
          font: 10px/1 DXIcons;
        }
        .dx-list-item
        {
            font: 8px/1 DXIcons;
        }   
        .dx-dashboard-item-header {  
            height:auto;
            font-size: 10px;
            font-style: italic;
            font-family: Times New Roman;
            font-weight: bold;
        }  
        .dx-dashboard-title {  
            font-size: 20px;  
            padding-top: 10px;  
            padding-bottom: 10px;  
        }  

    </style>  
    <style type="text/css">  
        div.customFont table {  
            font-size: 10px;  
        }  
        .dx-pivotgrid
        {
        font-size: 10px ;
        height :auto;
        }
        .dx-Gauge
        {
        font-size: 10px ;
        }    
        .dx-pivot-item,
        .dx-pivot-item-content {
          width: 100%;
          height: 100%;
        }
        
        .dx-treelist-container .dx-sort-up {
          font: 10px/1 DXIcons;
        }
        .dx-list-item
        {
            font: 8px/1 DXIcons;
        }   
        .dx-dashboard-item-header {  
            height:auto;
            font-size: 10px;
            font-style: italic;
            font-family: Times New Roman;
            font-weight: bold;
        }  
        .dx-dashboard-title {  
            font-size: 20px;  
            padding-top: 10px;  
            padding-bottom: 10px;  
        }  

    </style>  
    <script type="text/javascript">

        function ItemWidgetCreatedHandle(e) 
        {
            if (e.ItemName == "gridDashboardItem1") 
            {
                var grid = e.GetWidget();
                grid.element()[0].style.fontSize = "10px";
            }
		if ((e.ItemName == 'chartDashboardItem1') || (e.ItemName == 'chartDashboardItem2') || (e.ItemName == 'chartDashboardItem3') )
        {
			var chart = e.GetWidget();
			var chartOptions = chart.option();
			$.each(chartOptions.series, function (_, series) {
				if (series.label != undefined) {
					series.label.border = {  visible: true, width: 1 };
					series.label.backgroundColor = 'transparent';
					series.label.font = { color: series.color , size: 10 };


				}
			});
			chartOptions.valueAxis[0].label.font = { size: 8};

			chart.option(chartOptions);
			chart.option({ 
				argumentAxis: { label: { font: { size: 8}}}, 

			});
		}

</script>
    <style type="text/css">  
        div.customFont table {  
            font-size: 8px;  
        }  
        .dx-pivotgrid .dx-word-wrap .dx-pivotgrid-area .dx-pivotgrid-vertical-headers span {  
        white-space:nowrap;|
        } 
    </style> 
    <style type="text/css">
        body
        {
            
        }
        .outer
        {
            width: 100%;
            border: solid 1px gray;
            padding: 1px;
        }
        .inner
        {
            border: solid 1px gray;
            width: 90%;
            margin-left: auto;
            margin-right: auto;
        }
    </style>

<div id="principal" class="inner">

<table>

<tr>
<td>
<table width="100%">
<tr>
<td valign="top" align="center">
<asp:Label ID="Label3" runat="server" Text="DISTRITO" CssClass="sys-font-body-Text" Width="100%"></asp:Label>
</td>
<td valign="top" align="center">
<asp:Label ID="Label1" runat="server" Text="ACTIVIDAD" CssClass="sys-font-body-Text" Width="100%"></asp:Label>
</td>
<td valign="top" align="center">
<asp:Label ID="Label2" runat="server" Text="TIPO PROYECTO" CssClass="sys-font-body-Text" Width="100%"></asp:Label>
</td>
</tr>
<tr>
<td valign="top" align="center">
<dx:ASPxComboBox ID="CboDistrito" runat="server" style="vertical-align: middle" AutoPostBack="true"  Font-Size="Small"  
SelectedIndex="0" ValueType="System.String" Width="80%"  >
</dx:ASPxComboBox>
</td>
<td valign="top" align="center">
<dx:ASPxComboBox ID="CboActividad" runat="server" style="vertical-align: middle" AutoPostBack="true"  Font-Size="Small" 
SelectedIndex="0" ValueType="System.String" Width="80%"  >
</dx:ASPxComboBox>
</td>
<td valign="top" align="center">
<dx:ASPxComboBox ID="CboTipoProyecto" runat="server" style="vertical-align: middle" AutoPostBack="true"  Font-Size="Small" 
SelectedIndex="0" ValueType="System.String" Width="80%"  >
</dx:ASPxComboBox>
</td>
</tr>
</table>
</td>
</tr>
<tr>
<td>

        <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" AutoPostBack="true"
            ActiveTabIndex="0" Height="300%" TabSpacing="3px"  Font-Size="Small"   TabStyle-VerticalAlign="Bottom"  TabAlign="Justify" 
            Width="100%" >
	        <ActiveTabStyle Font-Bold="True" Font-Size="Medium">
	        </ActiveTabStyle>                        
	        <TabPages >   
		        <dx:TabPage Text="LISTA DE PROYECTO ACTIVOS." >
			        <ContentCollection>
				        <dx:ContentControl ID="ContentControl13" runat="server">	
                            <table>
                                <tr>
                                    <td >
                                    <dx:ASPxGridView ID="ASPxGridviewProyecto"  runat="server" Width="100%" 
                                        ClientInstanceName="ASPxGridviewProyecto"
                                        KeyFieldName="ACT_PROY"
                                        OnLoad="LoadProyecto" 
                                        AutoGenerateColumns="False" OnRowCommand="EvtRowCommand" Font-Size="X-Small">
                                    <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True"/>
                                    <TotalSummary>
                                    <dx:ASPxSummaryItem FieldName="ACT_PROY"  SummaryType="Count"/>
                                    <dx:ASPxSummaryItem FieldName="MONTO_OBRA" SummaryType="Sum" DisplayFormat="c"/>
                                    <dx:ASPxSummaryItem FieldName="VALORIZACION_IMPORTE" SummaryType="Sum" DisplayFormat="c"/>
                                    <dx:ASPxSummaryItem FieldName="ADELANTO_IMPORTE" SummaryType="Sum" DisplayFormat="c"/>
                                    <dx:ASPxSummaryItem FieldName="SALDO" SummaryType="Sum" DisplayFormat="c"/>
                                    </TotalSummary>
                                    <Columns>

                                    <dx:GridViewDataTextColumn FieldName="ACT_PROY" Caption="CUI"  Visible="true" FixedStyle="Left" CellStyle-BackColor="#ffffd6"
                                        VisibleIndex="1" HeaderStyle-Wrap="True" Settings-AllowSort="False" Settings-AllowDragDrop="False"
                                        HeaderStyle-HorizontalAlign="Center"  >
                                        <DataItemTemplate>
                                            <dx:ASPxHyperLink ID="hyperLink1" runat="server" OnInit="hyperLink_InitPROYECTOSNIP" >
                                            </dx:ASPxHyperLink>
                                        </DataItemTemplate>    
                                        <Settings AllowDragDrop="False" AllowHeaderFilter="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>

<CellStyle BackColor="#FFFFD6"></CellStyle>
                                    </dx:GridViewDataTextColumn>    
                                    <dx:GridViewDataTextColumn FieldName="DESCRIPCION" FixedStyle="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Caption="DESCRIPCION" VisibleIndex="2"  Settings-AutoFilterCondition="Contains"   >
<Settings AutoFilterCondition="Contains"></Settings>

<HeaderStyle HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataDateColumn FieldName="FECHA_INICIO_OBRA_MAXIMO"  FixedStyle="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" Caption="INICIO" VisibleIndex="3" CellStyle-HorizontalAlign="Center"  Settings-AllowAutoFilter="False"  Settings-AllowHeaderFilter="False" >
<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>

                                    <HeaderStyle HorizontalAlign="Center" />

<CellStyle HorizontalAlign="Center"></CellStyle>
                                    </dx:GridViewDataDateColumn>
                                    <dx:GridViewDataDateColumn FieldName="FECHA_FIN_OBRA"   FixedStyle="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" Caption="FIN" VisibleIndex="4" CellStyle-HorizontalAlign="Center"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>

                                    <HeaderStyle HorizontalAlign="Center" />

<CellStyle HorizontalAlign="Center"></CellStyle>
                                    </dx:GridViewDataDateColumn>
                                    <dx:GridViewDataDateColumn FieldName="RESTO"  FixedStyle="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" Caption="DIAS" VisibleIndex="4" CellStyle-HorizontalAlign="Center"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>

                                    <HeaderStyle HorizontalAlign="Center" />

<CellStyle HorizontalAlign="Center"></CellStyle>
                                    </dx:GridViewDataDateColumn>
                                    <dx:GridViewDataTextColumn FieldName="AVANCE"  FixedStyle="Left"  HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Caption="AVANCE" VisibleIndex="5" CellStyle-HorizontalAlign="Justify"  Settings-AllowAutoFilter="False"  Settings-AllowHeaderFilter="False"  >
<%--                                        <DataItemTemplate>
                                            <table style="width:100%">
                                                <tr>
                                                    <td>
                                                        <div style="float:left">
                                                            <dx:ASPxImage ID="image" runat="server" OnInit="image_Init"></dx:ASPxImage>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <%# Eval("AVANCE") %>
                                                    </td>
                                                </tr>
                                            </table>
                                        </DataItemTemplate>--%>
<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>

<HeaderStyle HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>

<CellStyle HorizontalAlign="Justify"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="ALERTA" VisibleIndex="6" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" Width="60px" FixedStyle="Left" HeaderStyle-Wrap="True">
                                    <Settings AllowDragDrop="False" AllowSort="False"  AllowAutoFilter="True"></Settings>
                                    <DataItemTemplate >
                                        <img id="Img1" runat="server" src='<%# GetImageName(Eval("SEMAFORO")) %>' />
                                    </DataItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewBandColumn Caption="IMPORTES" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" VisibleIndex="7" >
<HeaderStyle HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>
                                    <Columns>
                                    <dx:GridViewDataTextColumn FieldName="MONTO_OBRA" PropertiesTextEdit-DisplayFormatString="c" UnboundType="Decimal"  HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Caption="CONTRATO" VisibleIndex="3" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False"  Settings-AllowHeaderFilter="False"  >
<PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>

<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>

<HeaderStyle HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>

<CellStyle HorizontalAlign="Right"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="VALORIZACION_IMPORTE" PropertiesTextEdit-DisplayFormatString="c" UnboundType="Decimal"  HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Caption="VALORIZACION" VisibleIndex="3" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False"  Settings-AllowHeaderFilter="False"  >
<PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>

<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>

<HeaderStyle HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>

<CellStyle HorizontalAlign="Right"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="ADELANTO_IMPORTE" PropertiesTextEdit-DisplayFormatString="c" UnboundType="Decimal"  HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Caption="ADELANTOS" VisibleIndex="3" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False"  Settings-AllowHeaderFilter="False"  >
<PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>

<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>

<HeaderStyle HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>

<CellStyle HorizontalAlign="Right"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="SALDO"  PropertiesTextEdit-DisplayFormatString="c" UnboundType="Decimal"  HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Caption="SALDO" VisibleIndex="3" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False"  Settings-AllowHeaderFilter="False"  >
<PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>

<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>

<HeaderStyle HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>

<CellStyle HorizontalAlign="Right"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    </Columns>
                                    </dx:GridViewBandColumn>
                                   

                                    <dx:GridViewBandColumn Caption="OBRASEMP" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" VisibleIndex="8" >
<HeaderStyle HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>
                                    <Columns>
                                    <dx:GridViewDataTextColumn FieldName="DESCRIPCION_ESTADO_CONTRATO"  HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Caption="ESTADO" VisibleIndex="3" CellStyle-HorizontalAlign="Justify" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True" >
<Settings AutoFilterCondition="Contains"></Settings>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>

<CellStyle HorizontalAlign="Justify"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="DESCRIPCION_TIPO_OBRA"  VISIBLE="false" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Caption="TIPO" VisibleIndex="3" CellStyle-HorizontalAlign="Justify" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True" >
<Settings AutoFilterCondition="Contains"></Settings>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>

<CellStyle HorizontalAlign="Justify"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="DESCRIPCION_ACTIVIDAD_PROYECTO"  HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Caption="ACTIVIDAD" VisibleIndex="3" CellStyle-HorizontalAlign="Justify" Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True" >
<Settings AutoFilterCondition="Contains"></Settings>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>

<CellStyle HorizontalAlign="Justify"></CellStyle>
                                    </dx:GridViewDataTextColumn>

                                    </Columns>
                                    </dx:GridViewBandColumn>
                                    </Columns> 
                                    <FormatConditions>
                                        <dx:GridViewFormatConditionIconSet FieldName="AVANCE" Format="Quarters5" />                                    
                                    </FormatConditions>
                                    <Settings ShowFooter="True" GridLines="Vertical"  />
                                    <SettingsBehavior AllowDragDrop="False" />
                                    <SettingsPager Mode="ShowPager">
<PageSizeItemSettings ShowAllItem="True" Visible="True"></PageSizeItemSettings>
                                        </SettingsPager>
                                    <Settings ShowTitlePanel="true" />
                                    <SettingsText Title="PROYECTOS" />     
                                    <Settings ShowFilterRow="True" ShowHeaderFilterButton="true"    ShowGroupPanel="True"/>   
                                      
                                <Settings VerticalScrollableHeight="300" />
                                    <SettingsPager PageSize="10">
                                        <PageSizeItemSettings Visible="true" ShowAllItem="true" />
                                    </SettingsPager>     
                                </dx:ASPxGridView>
                                    </td>
                                </tr>
                            </table>
 				        </dx:ContentControl>
			        </ContentCollection>
		        </dx:TabPage> 
              
                               
            </TabPages>

<TabStyle VerticalAlign="Bottom"></TabStyle>

        </dx:ASPxPageControl>
        <dx:ASPxPopupControl ID="popupControl" runat="server" 
                    ClientInstanceName="clientPopupControl"  CloseAction="CloseButton" 
                    Height="620px" Modal="True" Width="990px" PopupHorizontalAlign="RightSides"
                    PopupVerticalAlign="Middle" HeaderText="Reporte." ScrollBars="Auto">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
            </dx:PopupControlContentControl>
        </ContentCollection>                    
        </dx:ASPxPopupControl>

        <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" ClientInstanceName="popup" PopupElementID="btn"
            DragElement="Window" HeaderText="Emape" MaxHeight="1000px"
            MaxWidth="1000px" MinHeight="100px" MinWidth="210px" CloseAction="MouseOut" PopupAction="MouseOver" 
            AppearAfter="4000" DisappearAfter="4000" Top="20" Left="80" AllowResize="true" AllowDragging="true"
            ResizingMode="Postponed" SaveStateToCookies="true">

            <CloseButtonImage Url="~/Images/close.png" AlternateText="No image" />
            <ContentStyle ForeColor="#666677" Font-Names="Tahoma" Font-Size="10px" />
            <ContentCollection>
                <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server">
                    <div>
                    <dx:ASPxDocumentViewer runat="server" ID="documentViewer" Width="900px" 
                        EnableViewState="False">
                                            
                        <StylesSplitter SidePaneWidth="345px" />
                    </dx:ASPxDocumentViewer>
                    </div>
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>


        <dx:ASPxPopupControl ID="ASPxPopupControl3" runat="server" ClientInstanceName="popup1" PopupElementID="btn"
            DragElement="Window" HeaderText="Emape" MaxHeight="1000px"
            MaxWidth="1000px" MinHeight="100px" MinWidth="210px" CloseAction="MouseOut" PopupAction="MouseOver" 
            AppearAfter="4000" DisappearAfter="4000" Top="20" Left="80" AllowResize="true" AllowDragging="true"
            ResizingMode="Postponed" SaveStateToCookies="true">

            <CloseButtonImage Url="~/Images/close.png" AlternateText="No image" />
            <ContentStyle ForeColor="#666677" Font-Names="Tahoma" Font-Size="10px" />
            <ContentCollection>
                <dx:PopupControlContentControl ID="PopupControlContentControl4" runat="server">
                    <div>
                    <dx:ASPxDocumentViewer runat="server" ID="documentViewer1" Width="1000px" 
                        EnableViewState="False">
                                            
                        <StylesSplitter SidePaneWidth="345px" />
                    </dx:ASPxDocumentViewer>
                    </div>
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>

 </td>
</tr>
</table>
</div>    
</asp:Content>
