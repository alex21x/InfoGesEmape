<%@ Page Language="C#"  MasterPageFile="~/Modules/MasterPage.Master"  AutoEventWireup="true"  Title="InfoGesConsultas"
 CodeBehind="InfoGesDashBoardObrasGG.aspx.cs" Inherits="InfogesEmape.Modules.Forms.Consulta.InfoGesDashBoardObrasGG" %>

<%@ Register Assembly="DevExpress.Dashboard.v17.1.Web, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"  Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<%@ Register Assembly="DevExpress.XtraReports.v17.1.Web, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>


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
        }


</script>
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






<table width="100%">
<tr>
<td>
<table>
<tr>
<td>
<dx:ASPxButton ID="btn" runat="server" Text="Estado Situacional." AutoPostBack="false" Font-Size="Small">
            <ClientSideEvents Click="function (s,e) {popup.Show();}" /></dx:ASPxButton>
</td>
<td>        <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Avance por Coordinador" AutoPostBack="false" Font-Size="Small" >
            <ClientSideEvents Click="function (s,e) {popup2.Show();}" />
        </dx:ASPxButton></td>
</table>        
</td>
</tr>
<tr>
<td>

        <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" AutoPostBack="true" 
            ActiveTabIndex="0" Height="200%" TabSpacing="3px"    TabStyle-VerticalAlign="Bottom"  TabAlign="Justify"  Width="100%" >
	        <ContentStyle VerticalAlign="Top">
	        <Border BorderColor="#AECAF0" BorderStyle="Solid" BorderWidth="1px" />
            <Border BorderStyle="Solid" BorderColor="#AECAF0" BorderWidth="1px"></Border>
	        </ContentStyle>     
	        <ActiveTabStyle Font-Bold="True" Font-Size="Medium">
	        </ActiveTabStyle>         


	        <TabPages >   
		        <dx:TabPage Text="ESTADO SITUACIONAL" >
			        <ContentCollection>
				        <dx:ContentControl ID="ContentControl4" runat="server">

                             <dx:ASPxDashboardViewer  ID="ASPxDashboard1" runat="server"
                                    DashboardXmlFile = "~/xml/OBRAS_TABLERO_MANDO.xml" RegisterJQuery="True"
                                    HandleServerErrors="true" Width="91%" Font-Size="X-Small" Font-Strikeout="False"  
                                    Height="1100px" PdfExportOptions-PaperKind="A4" OnConfigureDataConnection="ASPxDashboardViewer1_ConfigureDataConnection" 
                                    PdfExportOptions-ScaleMode="AutoFitToPageWidth" Cursor="pointer">
                                                <ClientSideEvents ItemWidgetCreated="function(s,e){ItemWidgetCreatedHandle(e);}" />
                            <%--                    <ClientSideEvents ItemWidgetCreated="dashboardWidgetCreatead" />--%>
                            </dx:ASPxDashboardViewer>

                        </dx:ContentControl>                           
                    </ContentCollection>
                </dx:TabPage>


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

                               
            </TabPages>
        </dx:ASPxPageControl>   
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

<%--        <dx:ASPxPopupControl ID="ASPxPopupControl2" runat="server" ClientInstanceName="popup1" PopupElementID="btn"
            DragElement="Window" HeaderText="Emape" MaxHeight="1000px"
            MaxWidth="1000px" MinHeight="100px" MinWidth="210px" CloseAction="MouseOut" PopupAction="MouseOver" 
            AppearAfter="4000" DisappearAfter="4000" Top="20" Left="80" AllowResize="true" AllowDragging="true"
            ResizingMode="Postponed" SaveStateToCookies="true">

            <CloseButtonImage Url="~/Images/close.png" AlternateText="No image" />
            <ContentStyle ForeColor="#666677" Font-Names="Tahoma" Font-Size="10px" />
            <ContentCollection>
                <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                    <div>
                    <dx:ASPxDocumentViewer runat="server" ID="documentViewer1" Width="900px" 
                        EnableViewState="False">
                                            
                        <StylesSplitter SidePaneWidth="345px" />
                    </dx:ASPxDocumentViewer>
                    </div>
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>--%>
        <dx:ASPxPopupControl ID="ASPxPopupControl3" runat="server" ClientInstanceName="popup2" PopupElementID="btn"
            DragElement="Window" HeaderText="Emape" MaxHeight="1000px"
            MaxWidth="1000px" MinHeight="100px" MinWidth="210px" CloseAction="MouseOut" PopupAction="MouseOver" 
            AppearAfter="4000" DisappearAfter="4000" Top="20" Left="80" AllowResize="true" AllowDragging="true"
            ResizingMode="Postponed" SaveStateToCookies="true">

            <CloseButtonImage Url="~/Images/close.png" AlternateText="No image" />
            <ContentStyle ForeColor="#666677" Font-Names="Tahoma" Font-Size="10px" />
            <ContentCollection>
                <dx:PopupControlContentControl ID="PopupControlContentControl3" runat="server">
                    <div>
                    <dx:ASPxDocumentViewer runat="server" ID="documentViewer2" Width="900px" 
                        EnableViewState="False">
                                            
                        <StylesSplitter SidePaneWidth="345px" />
                    </dx:ASPxDocumentViewer>
                    </div>
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>
<%--        <dx:ASPxPopupControl ID="ASPxPopupControl4" runat="server" ClientInstanceName="popup3" PopupElementID="btn"
            DragElement="Window" HeaderText="Emape" MaxHeight="1000px"
            MaxWidth="1000px" MinHeight="100px" MinWidth="210px" CloseAction="MouseOut" PopupAction="MouseOver" 
            AppearAfter="4000" DisappearAfter="4000" Top="20" Left="80" AllowResize="true" AllowDragging="true"
            ResizingMode="Postponed" SaveStateToCookies="true">

            <CloseButtonImage Url="~/Images/close.png" AlternateText="No image" />
            <ContentStyle ForeColor="#666677" Font-Names="Tahoma" Font-Size="10px" />
            <ContentCollection>
                <dx:PopupControlContentControl ID="PopupControlContentControl4" runat="server">
                    <div>
                    <dx:ASPxDocumentViewer runat="server" ID="documentViewer3" Width="900px" 
                        EnableViewState="False">
                                            
                        <StylesSplitter SidePaneWidth="345px" />
                    </dx:ASPxDocumentViewer>
                    </div>
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>--%>
</td>
</tr>
</table>
 <%-- oncustomparameters="ASPxDashboardViewer1_CustomParameters"--%>
 </div>


</asp:Content>

