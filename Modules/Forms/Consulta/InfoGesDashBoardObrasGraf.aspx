<%@ Page Language="C#"  MasterPageFile="~/Modules/MasterPage.Master"  AutoEventWireup="true"  Title="InfoGesConsultas"
 CodeBehind="InfoGesDashBoardObrasGraf.aspx.cs" Inherits="InfoGesRegional.Modules.Forms.Consulta.InfoGesDashBoardObrasGraf" %>

<%@ Register Assembly="DevExpress.Dashboard.v17.1.Web, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"  Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">  
        div.customFont table {  
           font-size: 11px;  
           font-family: Arial;
           font-weight: bold;
         }  
        .dx-pivotgrid
        {
        font-size: 11px ;
        height :auto;
        }
        .dx-Gauge
        {
        font-size: 11px ;
        }    
        .dx-pivot-item,
        .dx-pivot-item-content {
          width: 100%;
          height: 100%;
        }
        
        .dx-treelist-container .dx-sort-up {
          font: 11px/1 DXIcons;
        }
        .dx-list-item
        {
            font: 11px/0.5 DXIcons;
        }   
        .dx-dashboard-item-header {  
            height:auto;
            font-size: 9px/0 ;
            font-family: Arial;
            font-weight: bold;
            text-align: center;
            background-color : ActiveBorder;
        }  
        .dx-dashboard-title {  
            font-size: 15px;
            color :Highlight;
            padding-top: 11px;  
            padding-bottom: 11px;  
            font-weight: bold;
       }
        .dx-checkbox-icon {
            width: 20px;
            height: 20px;
            font-size:12px;
            line-height :inherit;
        }
        .dx-box-item-content {
          font-size: 20px;
        }    
        .dx-list-item-badge-container {
          display: table-cell;
          width: 20px;
          text-align: right;
          vertical-align: middle;
          padding-right: 11px;
        }      
        div.customFont table {  
            font-size: 8px;  
            font-weight: bold;
        }  
        .dx-pivotgrid .dx-word-wrap .dx-pivotgrid-area .dx-pivotgrid-vertical-headers span {  
        white-space:nowrap;
        } 
    </style> 
    <script type="text/javascript">

        function ItemWidgetCreatedHandle(e) 
        {
            if (e.ItemName == "gridDashboardItem1") 
            {
                var grid = e.GetWidget();
                grid.element()[0].style.fontSize = "11px";
            }
           if (e.ItemName == "gridDashboardItem6") 
            {
                var grid = e.GetWidget();
                grid.element()[0].style.fontSize = "11px";
            }
            if (e.ItemName == "gridDashboardItem2") 
            {
                var grid = e.GetWidget();
                grid.element()[0].style.fontSize = "11px";
            }
            if (e.ItemName == "gridDashboardItem3") 
            {
                var grid = e.GetWidget();
                grid.element()[0].style.fontSize = "11px";
            }
            if (e.ItemName == "gridDashboardItem4") 
            {
                var grid = e.GetWidget();
                grid.element()[0].style.fontSize = "11px";
            }
            if (e.ItemName == "gridDashboardItem5") 
            {
                var grid = e.GetWidget();
                grid.element()[0].style.fontSize = "11px";
            }
            if (e.ItemName == "pivotDashboardItem1") 
            {
                var grid = e.GetWidget();
                grid.element()[0].style.fontSize = "11px";
            }
            if (e.ItemName == "pivotDashboardItem2") 
            {
                var grid = e.GetWidget();
                grid.element()[0].style.fontSize = "11px";
            }
            if (e.ItemName == "gaugeDashboardItem1") 
            {
                var grid = e.GetWidget();
                grid.element()[0].style.fontSize = "11px";
            }            
            if (e.ItemName == "treeViewDashboardItem1") 
            {
                var grid = e.GetWidget();
                grid.element()[0].style.fontSize = "11px";
            }            
            if (e.ItemName == "pieDashboardItem1") 
            {
                var grid = e.GetWidget();
                grid.element()[0].style.fontSize = "11px";

            }            
//            if (e.ItemName == "comboBoxDashboardItem1") 
//            {
//                var grid = e.GetWidget();
//                grid.element()[0].style.fontSize = "11px";
//                grid.element()[0].item.fontSize = "11px";

            //            }


//		    if ((e.ItemName == 'chartDashboardItem1') || (e.ItemName == 'chartDashboardItem2') || (e.ItemName == 'chartDashboardItem3') )
//            {
//			    var chart = e.GetWidget();
//			    var chartOptions = chart.option();
//			    $.each(chartOptions.series, function (_, series) {
//				    if (series.label != undefined) {
//			            series.label.border = { color: series.color, visible: true, width: 1 };
//					    series.label.border = {  visible: true, width: 1 };
//				        series.label.backgroundColor  'transparent';
//					    series.label.font = { color: series.color , size: 10};


//				    }
//			    });
//			    chartOptions.valueAxis[0].label.font = { size: 10};

//			    chart.option(chartOptions);
//			    chart.option({ 
//				    argumentAxis: { label: { font: { size: 10}}}, 

//			    });
//		    }


//            if (e.ItemName.match(/pieDashboardItem2/)) {  
////            var chartWidgets = e.GetWidget();  
//            $.each(chartWidgets, function (_, chart) {  
//                var chartOptions = chart.option();  
//                $.each(chartOptions.series, function (_, series) {  
//                    if (series.label != undefined) {  
//                        series.label.font = { color: 'black', size: 9 };  
//                    }  
//                });  
//            chart.option(chartOptions);  
//            });  
//            }  
        }


</script>









<table width="90%">
<tr>
<td>

        <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" AutoPostBack="true" 
            ActiveTabIndex="0" Height="200%" TabSpacing="3px"  Font-Size="X-Small" Width="100%" >
	        <ContentStyle VerticalAlign="Top">
	        <Border BorderColor="#AECAF0" BorderStyle="Solid" BorderWidth="1px" />
            <Border BorderStyle="Solid" BorderColor="#AECAF0" BorderWidth="1px"></Border>
	        </ContentStyle>     
	        <ActiveTabStyle Font-Bold="True" Font-Size="Small">
	        </ActiveTabStyle>                        
	        <TabPages >   
		        <dx:TabPage Text="POR DISTRITO" >
			        <ContentCollection>
				        <dx:ContentControl ID="ContentControl13" runat="server">	
                                 <dx:ASPxDashboardViewer  ID="ASPxDashboardViewer1" runat="server"
                                        DashboardXmlFile = "~/xml/OBRAS_TABLERO_MANDO_GRAFICO.xml" RegisterJQuery="True"
                                        HandleServerErrors="true" Width="99%" Font-Strikeout="False"  
                                        Height="800px" PdfExportOptions-PaperKind="A4" OnConfigureDataConnection="ASPxDashboardViewer1_ConfigureDataConnection" 
                                        PdfExportOptions-ScaleMode="AutoFitToPageWidth" Cursor="pointer">
<PdfExportOptions PaperKind="A4" ScaleMode="AutoFitToPageWidth"></PdfExportOptions>

                                                    <ClientSideEvents ItemWidgetCreated="function(s,e){ItemWidgetCreatedHandle(e);}" />
                                <%--                    <ClientSideEvents ItemWidgetCreated="dashboardWidgetCreatead" />--%>
                                </dx:ASPxDashboardViewer>

 				        </dx:ContentControl>
			        </ContentCollection>
		        </dx:TabPage> 
		        <dx:TabPage Text="POR ACTIVIDAD REALIZADA" >
			        <ContentCollection>
				        <dx:ContentControl ID="ContentControl1" runat="server">	

                                 <dx:ASPxDashboardViewer  ID="ASPxDashboardViewer2" runat="server"
                                        DashboardXmlFile = "~/xml/Obra_tablero_mando_distrito.xml" RegisterJQuery="True"
                                        HandleServerErrors="true" Width="99%"  Font-Strikeout="False"  
                                        Height="1000px" PdfExportOptions-PaperKind="A4" OnConfigureDataConnection="ASPxDashboardViewer1_ConfigureDataConnection" 
                                        PdfExportOptions-ScaleMode="AutoFitToPageWidth" Cursor="pointer">
<PdfExportOptions PaperKind="A4" ScaleMode="AutoFitToPageWidth"></PdfExportOptions>

                                                    <ClientSideEvents ItemWidgetCreated="function(s,e){ItemWidgetCreatedHandle(e);}" />
                                <%--                    <ClientSideEvents ItemWidgetCreated="dashboardWidgetCreatead" />--%>
                                </dx:ASPxDashboardViewer>
 				        </dx:ContentControl>
			        </ContentCollection>
		        </dx:TabPage> 
		        <dx:TabPage Text="ACUMULADOS" >
			        <ContentCollection>
				        <dx:ContentControl ID="ContentControl2" runat="server">	

                                 <dx:ASPxDashboardViewer  ID="ASPxDashboardViewer3" runat="server"
                                        DashboardXmlFile = "~/xml/Obra_tablero_mando_acumulado.xml" RegisterJQuery="True"
                                        HandleServerErrors="true" Width="99%"  Font-Strikeout="False"  
                                        Height="1000px" PdfExportOptions-PaperKind="A4" OnConfigureDataConnection="ASPxDashboardViewer1_ConfigureDataConnection" 
                                        PdfExportOptions-ScaleMode="AutoFitToPageWidth" Cursor="pointer">
<PdfExportOptions PaperKind="A4" ScaleMode="AutoFitToPageWidth"></PdfExportOptions>

                                                    <ClientSideEvents ItemWidgetCreated="function(s,e){ItemWidgetCreatedHandle(e);}" />
                                <%--                    <ClientSideEvents ItemWidgetCreated="dashboardWidgetCreatead" />--%>
                                </dx:ASPxDashboardViewer>
 				        </dx:ContentControl>
			        </ContentCollection>
		        </dx:TabPage> 
                <dx:TabPage  Text="PENDIENTE DE GIROS">
			        <ContentCollection>
				        <dx:ContentControl ID="ContentControl3" runat="server">
                        <table>
                        <tr>
                        <td>
                            <dx:ASPxButton ID="btnXlsExport" runat="server" Text="Exportar  XLS" UseSubmitBehavior="False"  Font-Size="Small"
                                OnClick="btnXlsExport_Click" /></td>                        
                        </td>
                        </tr>
                        <tr>
                        <td>
                        
                            <dx:ASPxGridView ID="ASPxGridviewRuc"  runat="server" Width="100%" KeyFieldName="RUC"
                                ClientInstanceName="ASPxGridviewRuc"  EnablePagingGestures="False"
                                OnLoad="Load_AcumuladoRuc" Visible="True" Font-Size="Small" >
                                <TotalSummary>
                                    <dx:ASPxSummaryItem FieldName="EJECUCION" SummaryType="Sum" DisplayFormat="c"/>
                                    </TotalSummary>
	                            <GroupSummary>
		                            <dx:ASPxSummaryItem FieldName="EJECUCION" ShowInGroupFooterColumn="EJECUCION" SummaryType="Sum" DisplayFormat="{0:c}" />
	                            </GroupSummary>
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="CUI" Caption="CUI" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"  Width="70px" >
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="NOMBRE_PROYECTO" Caption="PROYECTO" VisibleIndex="2" HeaderStyle-HorizontalAlign="Center" Width="400px" >
                                        <Settings AllowDragDrop="False" AllowSort="False" AutoFilterCondition="Contains"></Settings>
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ACTIVIDAD_PROYECTO" Caption="ACTIVIDAD" VisibleIndex="2" HeaderStyle-HorizontalAlign="Center" Width="300px">
                                        <Settings AllowDragDrop="False" AllowSort="False" AutoFilterCondition="Contains"></Settings>
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="PAQUETE" Caption="PAQUETE" VisibleIndex="2" HeaderStyle-HorizontalAlign="Center"  Width="100px">
                                        <Settings AllowDragDrop="False" AllowSort="False" AutoFilterCondition="Contains"></Settings>
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="EXPEDIENTE" Caption="EXPEDIENTE SIAF" VisibleIndex="2" HeaderStyle-HorizontalAlign="Center"  Width="100px">
                                        <Settings AllowDragDrop="False" AllowSort="False" AutoFilterCondition="Contains"></Settings>
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="RUC" Caption="RUC" VisibleIndex="2" HeaderStyle-HorizontalAlign="Center" Width="100px">
                                        <Settings AllowDragDrop="False" AllowSort="False" AutoFilterCondition="Contains"></Settings>
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="NOMBRE_RUC" Caption="NOMBRE_RUC" VisibleIndex="2" HeaderStyle-HorizontalAlign="Center">
                                        <Settings AllowDragDrop="False" AllowSort="False" AutoFilterCondition="Contains"></Settings>
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="CICLO" Caption="C" VisibleIndex="2" HeaderStyle-HorizontalAlign="Center"   Width="30px">
                                        <Settings AllowDragDrop="False" AllowSort="False" AllowHeaderFilter="False" AllowAutoFilter="False"></Settings>
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="FASE" Caption="F" VisibleIndex="2" HeaderStyle-HorizontalAlign="Center"   Width="30px">
                                        <Settings AllowDragDrop="False" AllowSort="False" AllowHeaderFilter="False" AllowAutoFilter="False"></Settings>
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="EJECUCION" Caption="EJECUCION" VisibleIndex="3"  HeaderStyle-HorizontalAlign="Center"  HeaderStyle-Wrap="True">
                                    <PropertiesTextEdit DisplayFormatString="c" ></PropertiesTextEdit><Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </dx:GridViewDataTextColumn>
                            </Columns> 


                            <SettingsBehavior AllowFocusedRow="True" />
                            <Settings ShowGroupPanel="True" ShowFooter="True"   ShowFilterRow="True"
                                    ShowHeaderFilterButton="true" ShowGroupFooter="VisibleAlways"
                                    ShowVerticalScrollBar="True" VerticalScrollableHeight="300" />
                            <Settings ShowTitlePanel="true" VerticalScrollBarMode="Visible"  ShowFooter="true" />
                            <SettingsPager Mode="ShowPager" PageSize="60"></SettingsPager>
                            <Settings ShowFilterBar="Visible" />
                            <SettingsText Title="LISTADO DE DEVENGADOS SIN GIRO" />
                            </dx:ASPxGridView> 
                            <dx:ASPxGridViewExporter ID="gridExport" runat="server" GridViewID="ASPxGridviewRuc"></dx:ASPxGridViewExporter>


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
 <%-- oncustomparameters="ASPxDashboardViewer1_CustomParameters"--%>

</asp:Content>

