<%@ Page Language="C#"  MasterPageFile="~/Modules/MasterPage.Master"  AutoEventWireup="true"  Title="InfoGesConsultas"
 CodeBehind="InfoGesDashBoard.aspx.cs" Inherits="InfoGesRegional.Modules.Forms.Consulta.InfoGesDashBoard" %>

<%@ Register Assembly="DevExpress.Dashboard.v17.1.Web, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"  Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
            font-size: 8px;  
        }  
        .dx-pivotgrid .dx-word-wrap .dx-pivotgrid-area .dx-pivotgrid-vertical-headers span {  
        white-space:nowrap;|
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
//                    if (e.ItemName == "gridDashboardItem1") {
//                        var grid = e.GetWidget();
//                        grid.element()[0].style.fontSize = "20px";
//                    }

		if ((e.ItemName == 'chartDashboardItem1') || (e.ItemName == 'chartDashboardItem2') || (e.ItemName == 'chartDashboardItem3') )
        {
			var chart = e.GetWidget();
			var chartOptions = chart.option();
			$.each(chartOptions.series, function (_, series) {
				if (series.label != undefined) {
//					        series.label.border = { color: series.color, visible: true, width: 1 };
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

//        if (e.ItemName == "pieDashboardItem1") 
//        {  
//            var pie = args.GetWidget()[0];  
//            pie.option({  
//                legend: {  
//                    visible: true,  
//                    border: {  
//                        visible: true  
//                    }  
//                }  
//            });  
//        }  

        }



//        function dashboardWidgetCreatead(s, e) {
//		if ((e.ItemName == 'chartDashboardItem1') || (e.ItemName == 'chartDashboardItem2') || (e.ItemName == 'chartDashboardItem3') )
//        {
//			var chart = e.GetWidget();
//			var chartOptions = chart.option();
//			$.each(chartOptions.series, function (_, series) {
//				if (series.label != undefined) {
//					series.label.border = { color: series.color, visible: true, width: 1 };
//					series.label.backgroundColor = 'transparent';
//					series.label.font = { color: series.color };

//				}
//			});
//			chartOptions.valueAxis[0].label.font = { size: 8};

//			chart.option(chartOptions);
//			chart.option({ 
//				argumentAxis: { label: { font: { size: 8}}}, 

//			});
//		}

////        if (e.ItemName == "pieDashboardItem1") 
////        {  
////            var pie = args.GetWidget()[0];  
////            pie.option({  
////                legend: {  
////                    visible: true,  
////                    border: {  
////                        visible: true  
////                    }  
////                }  
////            });  
////        }  

//	}
</script>









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
        ActiveTabStyle-Font-Size="X-Large" TabIndex="0" Width="1200px" RightToLeft="True" EnableTabScrolling="true">
<Paddings Padding="0" />
    </dx:ASPxTabControl>
<asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile=""  XPath="//product"  EnableCaching="false"></asp:XmlDataSource>
</td>
</tr></table>
</td>
</tr>
<tr>
<td>

        <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" AutoPostBack="true" OnActiveTabChanged="ASPxPageControl1_ActiveTabChangedDashBoard"
            ActiveTabIndex="0" Height="300%" TabSpacing="3px"  Font-Size="X-Small" Width="100%" >
	        <ContentStyle VerticalAlign="Top">
	        <Border BorderColor="#AECAF0" BorderStyle="Solid" BorderWidth="1px" />
            <Border BorderStyle="Solid" BorderColor="#AECAF0" BorderWidth="1px"></Border>
	        </ContentStyle>     
	        <ActiveTabStyle Font-Bold="True" Font-Size="Small">
	        </ActiveTabStyle>                        
	        <TabPages >   
		        <dx:TabPage Text="PRESUPUESTO" >
			        <ContentCollection>
				        <dx:ContentControl ID="ContentControl13" runat="server">	
                            <table>
                            </table>
 				        </dx:ContentControl>
			        </ContentCollection>
		        </dx:TabPage> 

		        <dx:TabPage Text="GENERICA" >
			        <ContentCollection>
				        <dx:ContentControl ID="ContentControl1" runat="server">	
                        <table>
                        </table>
				        </dx:ContentControl>
			        </ContentCollection>
		        </dx:TabPage>                       
		        <dx:TabPage Text="FUENTE FINANCIAMIENTO" >
			        <ContentCollection>
				        <dx:ContentControl ID="ContentControl2" runat="server">	
                        <table>
                        </table>
				        </dx:ContentControl>
			        </ContentCollection>
		        </dx:TabPage>                       
            </TabPages>
        </dx:ASPxPageControl>   
</td>
</tr>
</table>
 <dx:ASPxDashboardViewer  ID="ASPxDashboard1" runat="server"
        DashboardXmlFile = "~/xml/xmlDashboardPresupuesto.xml" RegisterJQuery="True"
        HandleServerErrors="true" Width="91%" Font-Size="XX-Small" 
         DashboardTheme="Light" Font-Strikeout="False"  
         OnCustomFilterExpression="ASPxDashboardViewer1_CustomFilterExpression"
        Height="800px" PdfExportOptions-PaperKind="A4" OnConfigureDataConnection="ASPxDashboardViewer1_ConfigureDataConnection" 
        PdfExportOptions-ScaleMode="AutoFitToPageWidth" Cursor="pointer" 
        ColorScheme="dark">
                    <ClientSideEvents ItemWidgetCreated="function(s,e){ItemWidgetCreatedHandle(e);}" />
<%--                    <ClientSideEvents ItemWidgetCreated="dashboardWidgetCreatead" />--%>
</dx:ASPxDashboardViewer>
<%-- oncustomparameters="ASPxDashboardViewer1_CustomParameters"--%>

</asp:Content>

