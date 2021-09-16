<%@ Page Language="C#" MasterPageFile="~/Modules/MasterPage.Master" AutoEventWireup="true" 
    CodeBehind="frmInfoGesGSOProyecto.aspx.cs" Inherits="InfogesEmape.Modules.Forms.Seguimiento.frmInfoGesGSOProyecto" 
    Title="InfoGesConsultas" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.XtraReports.v17.1.Web, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Dashboard.v17.1.Web, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"  Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
        .style4
        {
            width: 309px;
        }
        .style5
        {
            width: 168px;
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
     <div id="principal"  class="inner">

<table>
<tr><td>
<table>
<tr>
<td>        <dx:ASPxButton ID="btn" runat="server" Text="Estado de los Proyectos" AutoPostBack="false" Font-Size="Small" >
            <ClientSideEvents Click="function (s,e) {popup.Show();}" />
        </dx:ASPxButton></td>
</tr>
</table>


</td>
</tr>
<tr>
<td>

        <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" AutoPostBack="true"
            ActiveTabIndex="0" Height="300%" TabSpacing="3px"  Font-Size="X-Small"   TabStyle-VerticalAlign="Bottom"  TabAlign="Justify" 
            Width="100%" >
	        <ActiveTabStyle Font-Bold="True" Font-Size="Small">
	        </ActiveTabStyle>                        
	        <TabPages >   
		        <dx:TabPage Text="REGISTRO DE PROYECTO." >
			        <ContentCollection>
				        <dx:ContentControl ID="ContentControl13" runat="server">	
                            <table>
                                <tr>
                                    <td >
                                    <dx:ASPxGridView ID="ASPxGridviewProyecto"  runat="server" Width="100%" 
                                        ClientInstanceName="ASPxGridviewProyecto"
                                        KeyFieldName="ACT_PROY"
                                        OnLoad="LoadProyecto" 
                                        OnRowDeleting="Delete_ASPxGridviewProyecto" 
                                        AutoGenerateColumns="False" OnRowCommand="EvtRowCommand" Font-Size="Small">
                                    <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True"/>
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="ACT_PROY" Caption="Reporte"  Visible="true" FixedStyle="Left" CellStyle-BackColor="#ffffd6"
                                            VisibleIndex="9" HeaderStyle-Wrap="True" Width="40px"  Settings-AllowSort="False" Settings-AllowDragDrop="False"
                                            HeaderStyle-HorizontalAlign="Center"  >
                                            <DataItemTemplate>
                                                <dx:ASPxHyperLink ID="hyperLink1" runat="server" OnInit="hyperLink_InitPROYECTOSNIP" Font-Size="X-Small" >
                                                </dx:ASPxHyperLink>
                                            </DataItemTemplate>    
                                            <Settings AllowDragDrop="False" AllowHeaderFilter="False" AllowSort="False"></Settings>
                                            <HeaderStyle HorizontalAlign="Center" Wrap="True" ></HeaderStyle>
                                            <CellStyle BackColor="#FFFFD6"></CellStyle>
                                        </dx:GridViewDataTextColumn>    
                                        <dx:GridViewDataTextColumn VisibleIndex="1" Caption="CUI" FieldName="ACT_PROY" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  CellStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains" >
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <DataItemTemplate>
                                                <a id="LinkButton1"  href="frmInfoGesGsoProyectoRegistro.aspx?pOpera=edit&amp;pId=<%# Container.KeyValue%>"><%# Eval("ACT_PROY").ToString()%></a>                                    
                                            </DataItemTemplate>
                                       </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ACT_PROY" Caption="PDF" SortOrder="Ascending" FixedStyle="Left" CellStyle-BackColor="#ffffd6"
                                    VisibleIndex="10" HeaderStyle-Wrap="True" Width="30px"  Settings-AllowSort="False" Settings-AllowDragDrop="False" Visible="false"
                                    HeaderStyle-HorizontalAlign="Center"  >
                                        <DataItemTemplate>
                                            <dx:ASPxHyperLink ID="hyperLink1" runat="server" OnInit="hyperLinkInitAvancePDF" Font-Size="X-Small" >
                                            </dx:ASPxHyperLink>
                                        </DataItemTemplate>
                                        <Settings AllowDragDrop="False" AllowSort="False" AutoFilterCondition="Contains"></Settings>
                                        <HeaderStyle HorizontalAlign="Center" Wrap="True" ></HeaderStyle>
                                        <CellStyle BackColor="#FFFFD6"></CellStyle>
                                </dx:GridViewDataTextColumn>    
                                         <dx:GridViewDataTextColumn FieldName="NOMBRE_BANCO_PROYECTO"  HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" Caption="DESCRIPCION" VisibleIndex="2" CellStyle-HorizontalAlign="Justify"  
                                         Settings-AutoFilterCondition="Contains"  >
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="ABREVIATURA"  HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Caption="ABREVIATURA" VisibleIndex="3" CellStyle-HorizontalAlign="Justify" Settings-AutoFilterCondition="Contains"   >
                                        </dx:GridViewDataTextColumn>
                                       <dx:GridViewBandColumn Caption="PRE-INVERSION" VisibleIndex="4" HeaderStyle-HorizontalAlign="Center"  HeaderStyle-Font-Bold="true">
                                        <Columns>
                                        <dx:GridViewDataTextColumn FieldName="FECHA_PREINVERSION"  HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" Caption="FECHA" VisibleIndex="3" CellStyle-HorizontalAlign="Center"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  >
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="MONTO_PREINVERSION"  HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  PropertiesTextEdit-DisplayFormatString="#,#"
                                        Caption="IMPORTE" VisibleIndex="3" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  >
                                        </dx:GridViewDataTextColumn>                                        
                                        </Columns>
                                        </dx:GridViewBandColumn>
                                        <dx:GridViewBandColumn Caption="INVERSION" VisibleIndex="5" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true">
                                        <Columns>
                                        <dx:GridViewDataTextColumn FieldName="FECHA_INVERSION" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" Caption="FECHA" VisibleIndex="3" CellStyle-HorizontalAlign="Center"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False" >
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="MONTO_INVERSION" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" 
                                        Caption="IMPORTE" VisibleIndex="3" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  PropertiesTextEdit-DisplayFormatString="#,#"  >
                                        </dx:GridViewDataTextColumn>                                        
                                        </Columns>
                                        </dx:GridViewBandColumn>
                                        <dx:GridViewDataDateColumn FieldName="FECHA_INICIO"  HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" Caption="Inicio" VisibleIndex="6" CellStyle-HorizontalAlign="Center"  Settings-AllowAutoFilter="False"  Settings-AllowHeaderFilter="False">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        </dx:GridViewDataDateColumn>
                                        <dx:GridViewDataDateColumn FieldName="FECHA_FIN"  HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" Caption="Fin" VisibleIndex="7" CellStyle-HorizontalAlign="Center"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        </dx:GridViewDataDateColumn>
                        
                                    </Columns> 
                                    <Settings ShowFooter="True" />
                                    <SettingsBehavior AllowDragDrop="False" />
                                    <SettingsPager Mode="ShowPager"/>
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




</td>
</tr>
</table>
</div>    
</asp:Content>
