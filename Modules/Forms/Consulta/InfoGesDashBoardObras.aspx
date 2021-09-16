<%@ Page Language="C#"  MasterPageFile="~/Modules/MasterPage.Master"  AutoEventWireup="true"  Title="InfoGesConsultas"
 CodeBehind="InfoGesDashBoardObras.aspx.cs" Inherits="InfoGesRegional.Modules.Forms.Consulta.InfoGesDashBoardObras" %>

<%@ Register Assembly="DevExpress.Dashboard.v17.1.Web, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"  Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">  
        div.customFont table {  
            font-size: 12px/0.5;  
            font-weight: bold;
        }  
        .dx-pivotgrid
        {
        font-size: 12px/0.5 ;
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
          font-size: 12px/0.5 ;
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
            font-size: 12px/0;
            font-family: Arial;
            font-weight: bold;
            text-align: center;
            background-color : ActiveCaption;
        }  
        .dx-dashboard-title {  
            font-size: 15px;
            color :Highlight;
            padding-top: 10px;  
            padding-bottom: 10px;  
            font-weight: bold;
       }


    </style>  


    <style type="text/css">  
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
                grid.element()[0].style.fontSize = "12px";
            }
           if (e.ItemName == "gridDashboardItem6") 
            {
                var grid = e.GetWidget();
                grid.element()[0].style.fontSize = "12px";
            }
            if (e.ItemName == "gridDashboardItem2") 
            {
                var grid = e.GetWidget();
                grid.element()[0].style.fontSize = "12px";
            }
            if (e.ItemName == "gridDashboardItem3") 
            {
                var grid = e.GetWidget();
                grid.element()[0].style.fontSize = "12px";
            }
            if (e.ItemName == "gridDashboardItem4") 
            {
                var grid = e.GetWidget();
                grid.element()[0].style.fontSize = "12px";
            }
            if (e.ItemName == "gridDashboardItem5") 
            {
                var grid = e.GetWidget();
                grid.element()[0].style.fontSize = "12px";
            }
            if (e.ItemName == "pivotDashboardItem1") 
            {
                var grid = e.GetWidget();
                grid.element()[0].style.fontSize = "12px";
            }
            if (e.ItemName == "pivotDashboardItem2") 
            {
                var grid = e.GetWidget();
                grid.element()[0].style.fontSize = "12px";
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
			        series.label.border = { color: series.color, visible: true, width: 1 };
					series.label.border = {  visible: true, width: 1 };
//					series.label.backgroundColor = 'transparent';
					series.label.font = { color: series.color , size: 12};


				}
			});
			chartOptions.valueAxis[0].label.font = { size: 12};

			chart.option(chartOptions);
			chart.option({ 
				argumentAxis: { label: { font: { size: 12}}}, 

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

        <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" AutoPostBack="true" 
            ActiveTabIndex="0" Height="300%" TabSpacing="3px"  Font-Size="X-Small" Width="100%" >
	        <ContentStyle VerticalAlign="Top">
	        <Border BorderColor="#AECAF0" BorderStyle="Solid" BorderWidth="1px" />
            <Border BorderStyle="Solid" BorderColor="#AECAF0" BorderWidth="1px"></Border>
	        </ContentStyle>     
	        <ActiveTabStyle Font-Bold="True" Font-Size="Small">
	        </ActiveTabStyle>                        
	        <TabPages >   
		        <dx:TabPage Text="SITUACION" >
			        <ContentCollection>
				        <dx:ContentControl ID="ContentControl13" runat="server">	
<dx:ASPxButton ID="btnDashBoard" runat="server" Text="DashBoard - Grafico" UseSubmitBehavior="False" OnClick="btnDashBoard_Click" Font-Size="Small"  />

 				        </dx:ContentControl>
			        </ContentCollection>
		        </dx:TabPage> 
            </TabPages>
        </dx:ASPxPageControl>   
</td>
</tr>
</table>




 <dx:ASPxDashboardViewer  ID="ASPxDashboard1" runat="server"
        DashboardXmlFile = "~/xml/OBRAS_TABLERO_MANDO.xml" RegisterJQuery="True"
        HandleServerErrors="true" Width="91%" Font-Size="X-Small" Font-Strikeout="False"  
        Height="1100px" PdfExportOptions-PaperKind="A4" OnConfigureDataConnection="ASPxDashboardViewer1_ConfigureDataConnection" 
        PdfExportOptions-ScaleMode="AutoFitToPageWidth" Cursor="pointer">
                    <ClientSideEvents ItemWidgetCreated="function(s,e){ItemWidgetCreatedHandle(e);}" />
<%--                    <ClientSideEvents ItemWidgetCreated="dashboardWidgetCreatead" />--%>
</dx:ASPxDashboardViewer>
<%-- oncustomparameters="ASPxDashboardViewer1_CustomParameters"--%>


</asp:Content>

