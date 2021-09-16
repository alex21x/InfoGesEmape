<%@ Page Language="C#" MasterPageFile="~/Modules/MasterPage.Master" AutoEventWireup="true" 
    CodeBehind="frmInfoGesGSOS.aspx.cs" Inherits="InfoGesRegional.Modules.Forms.Seguimiento.frmInfoGesGSOS" 
    Title="InfoGesConsultas" %>

<%@ Register Assembly="DevExpress.XtraReports.v17.1.Web, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<%@ Register Assembly="DevExpress.Xpo.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Xpo" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Data.Linq" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxPivotGrid.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPivotGrid" tagprefix="dx" %>
<%@ Register Assembly="DevExpress.XtraCharts.v17.1.Web, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"  Namespace="DevExpress.XtraCharts.Web" TagPrefix="dxchartsui" %>
<%@ Register assembly="DevExpress.XtraCharts.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="dxcharts" %>
<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPivotGrid.Export" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Dashboard.v17.1.Web, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"  Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
    </asp:Content>
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
        function OnMoreInfoClick(contentUrl) {
            clientPopupControl.SetContentUrl(contentUrl);
            clientPopupControl.Show();
        }
        function UpdateDetailGrid(s, e) {
            AspxGridViewCoordinadorContrato.PerformCallback();
        }
        fu
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




     <div id="principal" >

<table>
<tr>
<td>

        <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" AutoPostBack="true"
            ActiveTabIndex="0" Height="300%" TabSpacing="3px"  Font-Size="X-Small" 
            Width="100%" onactivetabchanged="ASPxPageControl1_ActiveTabChanged" >
	        <ActiveTabStyle Font-Bold="True" Font-Size="Small">
	        </ActiveTabStyle>                        
	        <TabPages >   
		        <dx:TabPage Text="REGISTRO DE AVANCE." >
			        <ContentCollection>
				        <dx:ContentControl ID="ContentControl13" runat="server">	
                            <table>
                                <tr align="left">
                                <td colspan="2">
                                    <table><tr>
                                    <td style="padding-right: 4px">
                                                    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Exportar  XLS" UseSubmitBehavior="False"  Font-Size="X-Small"
                                                        OnClick="btnXlsExport_Click"/></td>
                                    </tr>
                                    </table>

                                </td>
                                </tr>
                                <tr><td>
                                <table>
                                <tr>
                                <td><dx:ASPxLabel ID="ASPxLabel1" runat="server" EnableTheming="False" Text="Coordinador" /></td>
                                <td><dx:ASPxLabel ID="lblText" runat="server" EnableTheming="False" Text="Semana" /></td>
                                <td><dx:ASPxLabel ID="ASPxLabel2" runat="server" EnableTheming="False" Text="Contraseña" /></td>
                                <td></td>
                                </tr>
                                <tr>
                                <td align="left">
                                    <dx:ASPxComboBox ID="CboCoordinador" runat="server" style="vertical-align: middle" AutoPostBack="true"  Font-Size="Small"
                                    SelectedIndex="0" ValueType="System.String" Width="300px" >
                                    </dx:ASPxComboBox>
                                </td>
                                <td>
                                       <dx:ASPxComboBox ID="CboSemana" runat="server" style="vertical-align: middle" AutoPostBack="true"   Font-Size="Small"
                                    SelectedIndex="0" ValueType="System.String" Width="50px"  >
                                    </dx:ASPxComboBox>
                                </td>
                                <td>
                                <dx:ASPxTextBox runat="server" ID="txtPassword"  Font-Size="Small">
                                </dx:ASPxTextBox>
                                </td>
                                <td>
                                    <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Buscar" UseSubmitBehavior="False"  Font-Size="Small" OnClick="OnSelectedindexChangedGrid"/>
                                </td>
                                </tr>
                                </table>
                                </td>
                                </tr>
                                <tr>
                                    <td >

                                    <dx:aspxgridview ID="AspxGridGsoAvance" 
                                                ClientInstanceName="AspxGridGsoAvance" OnRowUpdating="AvanceOnRowUpdating" 
                                                runat="server"  KeyFieldName="IDAVANCE"
                                                AutoGenerateColumns="False" 
                                                Font-Size="X-Small"
                                                Width="100%" 
                                                OnLoad="Load_Gso_Avance">
                                                <Columns>
                                                <dx:GridViewCommandColumn ShowEditButton="true" VisibleIndex="0" />
                                                <dx:GridViewDataTextColumn FieldName="IDAVANCE" Caption="IDGSOSITUACION" 
                                                    VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"  
                                                        Settings-AllowSort="False" EditFormSettings-Visible="False" Visible="false"
                                                    Settings-AllowDragDrop="False"  Settings-AllowHeaderFilter="False"  
                                                        CellStyle-BackColor="LightYellow" />
                                                <dx:GridViewDataTextColumn FieldName="IDGSOSITUACION" Caption="IDGSOSITUACION" 
                                                    VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"  
                                                        Settings-AllowSort="False" EditFormSettings-Visible="False" Visible="false"
                                                    Settings-AllowDragDrop="False"  Settings-AllowHeaderFilter="False"  
                                                        CellStyle-BackColor="LightYellow"/>
                                               <dx:GridViewDataTextColumn FieldName="IDSEMANA" Caption="IDSEMANA" 
                                                    VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"  
                                                        Settings-AllowSort="False" EditFormSettings-Visible="False" Visible="false"
                                                    Settings-AllowDragDrop="False"  Settings-AllowHeaderFilter="False"  
                                                        CellStyle-BackColor="LightYellow"/>
                                                <dx:GridViewDataTextColumn FieldName="ABREVIATURA" Caption="PROYECTO" 
                                                    VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"  
                                                        Settings-AllowSort="False" EditFormSettings-Visible="False"
                                                    Settings-AllowDragDrop="False"  Settings-AllowHeaderFilter="False"  
                                                        CellStyle-BackColor="LightYellow"/>
                                                <dx:GridViewDataTextColumn FieldName="ACTIVIDAD" Caption="ACTIVIDAD" 
                                                    VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"  
                                                        Settings-AllowSort="False" EditFormSettings-Visible="False"
                                                    Settings-AllowDragDrop="False"  Settings-AllowHeaderFilter="False"  
                                                        CellStyle-BackColor="LightYellow"/>
                                                <dx:GridViewDataTextColumn FieldName="SEMANA" Caption="SEMANA" 
                                                    VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"  
                                                        Settings-AllowSort="False" EditFormSettings-Visible="False"
                                                    Settings-AllowDragDrop="False"  Settings-AllowHeaderFilter="False"  
                                                        CellStyle-BackColor="LightYellow"/>
                                                <dx:GridViewDataTextColumn FieldName="OBRA" Caption="OBRA" VisibleIndex="8"  
                                                HeaderStyle-HorizontalAlign="Center" Width="120px" HeaderStyle-Wrap="True" PropertiesTextEdit-Width="50%" 
                                                Settings-AllowSort="False" Settings-AllowDragDrop="False"  Settings-AllowHeaderFilter="False">
                                                    <PropertiesTextEdit DisplayFormatString="{0}%" >  
                                                         <MaskSettings Mask="<0..100>.<00..99> " IncludeLiterals="DecimalSymbol" />
                                                    </PropertiesTextEdit>  

<Settings AllowDragDrop="False" AllowHeaderFilter="False" AllowSort="False"></Settings>

                                                    <EditFormSettings VisibleIndex="5" />

<HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="SUPERVISION" Caption="SUPERVISION" VisibleIndex="8"  PropertiesTextEdit-Width="50%"
                                                 HeaderStyle-HorizontalAlign="Center" Width="120px" HeaderStyle-Wrap="True" Settings-AllowSort="False" 
                                                 Settings-AllowDragDrop="False"  Settings-AllowHeaderFilter="False">
                                                    <PropertiesTextEdit DisplayFormatString="{0}%" >  
                                                         <MaskSettings Mask="<0..100>.<00..99> " IncludeLiterals="DecimalSymbol" />
                                                    </PropertiesTextEdit>  

<Settings AllowDragDrop="False" AllowHeaderFilter="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="GESTION_PROYECTO" Caption="GESTION DE PROYECTO" VisibleIndex="8" PropertiesTextEdit-Width="50%"  
                                                HeaderStyle-HorizontalAlign="Center" Width="120px" HeaderStyle-Wrap="True" Settings-AllowSort="False" 
                                                Settings-AllowDragDrop="False"  Settings-AllowHeaderFilter="False">

<Settings AllowDragDrop="False" AllowHeaderFilter="False" AllowSort="False"></Settings>

                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <PropertiesTextEdit DisplayFormatString="{0}%" >  
                                                         <MaskSettings Mask="<0..100>.<00..99> " IncludeLiterals="DecimalSymbol" />
                                                    </PropertiesTextEdit>  
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="INTERFERENCIA" Caption="INTERFERENCIA" VisibleIndex="8"  PropertiesTextEdit-Width="50%" 
                                                HeaderStyle-HorizontalAlign="Center" Width="120px" HeaderStyle-Wrap="True" Settings-AllowSort="False" 
                                                Settings-AllowDragDrop="False"  Settings-AllowHeaderFilter="False">

<Settings AllowDragDrop="False" AllowHeaderFilter="False" AllowSort="False"></Settings>

                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <PropertiesTextEdit DisplayFormatString="{0}%" >  
                                                         <MaskSettings Mask="<0..100>.<00..99> " IncludeLiterals="DecimalSymbol" /> 
                                                    </PropertiesTextEdit>  

                                                </dx:GridViewDataTextColumn>
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
                                                </Columns>
                                                   <SettingsPopup>
                                                        <EditForm Width="600" />
                                                    </SettingsPopup>
                                                    <SettingsEditing Mode="PopupEditForm" EditFormColumnCount="2" />
                                       </dx:aspxgridview>
                                        <dx:ASPxGridViewExporter ID="gridExport" runat="server" GridViewID="AspxGridGsoAvance"></dx:ASPxGridViewExporter>

 
                                    </td>
                                </tr>
                            </table>
 				        </dx:ContentControl>
			        </ContentCollection>
		        </dx:TabPage> 
                <dx:TabPage Text="ESTADO SITUACIONAL DE LAS OBRAS SOCIALES">
                <ContentCollection>
                <dx:ContentControl ID="ContentControl14" runat="server">
                <table>
                <tr><td>
                
        <dx:ASPxPivotGrid ID="pivotGrid" runat="server" onLoad="LoadASPxPivotGrid"  Font-Size="XX-Small"
                Width="100%">
                <Fields>
                    <dx:PivotGridField Area="RowArea" AreaIndex="0" FieldName="IDGSOSITUACION" 
                        visible="False" HeaderStyle-Wrap="True" >
<HeaderStyle Wrap="True"></HeaderStyle>
                    </dx:PivotGridField>
                    <dx:PivotGridField Area="RowArea" AreaIndex="1" Caption="PAQ." 
                        FieldName="PAQUETE" HeaderStyle-Wrap="True"  Visible="False" >
<HeaderStyle Wrap="True"></HeaderStyle>
                    </dx:PivotGridField>
                    <dx:PivotGridField Area="RowArea" AreaIndex="2" Caption="ABREVIATURA" 
                        FieldName="ABREVIATURA" HeaderStyle-Wrap="True"  >
<HeaderStyle Wrap="True"></HeaderStyle>
                    </dx:PivotGridField>
                    <dx:PivotGridField Area="RowArea" AreaIndex="3" Caption="PROYECTO" 
                        FieldName="ACT_PROY" HeaderStyle-Wrap="True" Visible="False" >
<HeaderStyle Wrap="True"></HeaderStyle>
                    </dx:PivotGridField>
                    <dx:PivotGridField Area="RowArea" AreaIndex="4" Caption="DISTRITO" 
                        FieldName="DISTRITO" HeaderStyle-Wrap="True" >
<HeaderStyle Wrap="True"></HeaderStyle>
                    </dx:PivotGridField>
                    <dx:PivotGridField Area="RowArea" AreaIndex="5" Caption="ACTIVIDAD" 
                        FieldName="ACTIVIDAD" HeaderStyle-Wrap="True" >
<HeaderStyle Wrap="True"></HeaderStyle>
                    </dx:PivotGridField>
                    <dx:PivotGridField Area="RowArea" AreaIndex="6" Caption="ENTR. TERRE." 
                        FieldName="FECHA_ENTREGA_TERRENO" HeaderStyle-Wrap="True" >
<HeaderStyle Wrap="True"></HeaderStyle>
                    </dx:PivotGridField>
                    <dx:PivotGridField Area="RowArea" AreaIndex="7" Caption="INICIO DE OBRA" 
                        FieldName="FECHA_INICIO_OBRA" HeaderStyle-Wrap="True"  >
<HeaderStyle Wrap="True"></HeaderStyle>
                    </dx:PivotGridField>
                    <dx:PivotGridField Area="RowArea" AreaIndex="8" Caption="ESTADO" 
                        FieldName="ESTADO_OBRA" HeaderStyle-Wrap="True" >
<HeaderStyle Wrap="True"></HeaderStyle>
                    </dx:PivotGridField>
                    <dx:PivotGridField Area="RowArea" AreaIndex="9" Caption="PLAZO EJE." 
                        FieldName="PLAZO_EJECUCION" HeaderStyle-Wrap="True" >
<HeaderStyle Wrap="True"></HeaderStyle>
                    </dx:PivotGridField>
                    <dx:PivotGridField Area="RowArea" AreaIndex="10" Caption="FECHA CULMI." 
                        FieldName="FECHA_CULMINACION" HeaderStyle-Wrap="True" >
<HeaderStyle Wrap="True"></HeaderStyle>
                    </dx:PivotGridField>
                    <dx:PivotGridField Area="ColumnArea" AreaIndex="11" Caption="SEMANA" 
                        FieldName="SEMANA" HeaderStyle-Wrap="True" >
<HeaderStyle Wrap="True"></HeaderStyle>
                    </dx:PivotGridField>
                    <dx:PivotGridField Area="ColumnArea" AreaIndex="12" Caption="COMPONENTE" 
                        FieldName="COMPONENTE" HeaderStyle-Wrap="True" >
<HeaderStyle Wrap="True"></HeaderStyle>
                    </dx:PivotGridField>
                    <dx:PivotGridField Area="DataArea" AreaIndex="13" Caption="AVANCE" 
                        FieldName="PORCENTAJE" HeaderStyle-Wrap="True" 
                        CellFormat-FormatString="##.##%"  >

<HeaderStyle Wrap="True"></HeaderStyle>
                    </dx:PivotGridField>

                </Fields>
                <OptionsView ShowFilterHeaders="true"  VerticalScrollBarMode="Visible"  />
                <OptionsData DataProcessingEngine="LegacyOptimized" />
                <OptionsView ShowColumnTotals="False" ShowRowGrandTotals="False" />
                <OptionsPager RowsPerPage="10" ColumnsPerPage="12" />
                <OptionsFilter ShowHiddenItems="true" ShowOnlyAvailableItems="true" />
            </dx:ASPxPivotGrid>

                </td></tr>
                </table>
                </dx:ContentControl>
                </ContentCollection>
                </dx:TabPage>
 		        <dx:TabPage Text="CUADRO 1" >
			        <ContentCollection>
				        <dx:ContentControl ID="ContentControl1" runat="server">	
                         <dx:ASPxDashboardViewer  ID="ASPxDashboard1" runat="server"
                                DashboardXmlFile = "~/xml/GsoObraContador.xml" RegisterJQuery="True"
                                HandleServerErrors="true" Width="91%" Font-Size="XX-Small" 
                                 DashboardTheme="Light" Font-Strikeout="False"  
                                Height="1200px" PdfExportOptions-PaperKind="A4" OnConfigureDataConnection="ASPxDashboardViewer1_ConfigureDataConnection" 
                                PdfExportOptions-ScaleMode="AutoFitToPageWidth" Cursor="pointer" 
                                ColorScheme="dark">
<PdfExportOptions PaperKind="A4" ScaleMode="AutoFitToPageWidth"></PdfExportOptions>

                                            <ClientSideEvents ItemWidgetCreated="function(s,e){ItemWidgetCreatedHandle(e);}" />
                        <%--                    <ClientSideEvents ItemWidgetCreated="dashboardWidgetCreatead" />--%>
                        </dx:ASPxDashboardViewer>
				        </dx:ContentControl>
			        </ContentCollection>
		        </dx:TabPage> 
		        <dx:TabPage Text="CUADRO 2" >
			        <ContentCollection>
				        <dx:ContentControl ID="ContentControl2" runat="server">	
                         <dx:ASPxDashboardViewer  ID="ASPxDashboardViewer1" runat="server"
                                DashboardXmlFile = "~/xml/GsoObraChart01.xml" RegisterJQuery="True"
                                HandleServerErrors="true" Width="91%" Font-Size="XX-Small" 
                                 DashboardTheme="Light" Font-Strikeout="False"  
                                Height="1200px" PdfExportOptions-PaperKind="A4" OnConfigureDataConnection="ASPxDashboardViewer1_ConfigureDataConnection" 
                                PdfExportOptions-ScaleMode="AutoFitToPageWidth" Cursor="pointer" 
                                ColorScheme="dark">
<PdfExportOptions PaperKind="A4" ScaleMode="AutoFitToPageWidth"></PdfExportOptions>

                                            <ClientSideEvents ItemWidgetCreated="function(s,e){ItemWidgetCreatedHandle(e);}" />
                        <%--                    <ClientSideEvents ItemWidgetCreated="dashboardWidgetCreatead" />--%>
                        </dx:ASPxDashboardViewer>
				        </dx:ContentControl>
			        </ContentCollection>
		        </dx:TabPage> 
                <dx:TabPage Text="CUADRO 3" >
			        <ContentCollection>
				        <dx:ContentControl ID="ContentControl15" runat="server">	

                         <dx:ASPxDashboardViewer  ID="ASPxDashboard3" runat="server"
                                DashboardXmlFile = "~/xml/GsoObraChart01fecha.xml" RegisterJQuery="True"
                                HandleServerErrors="true" Width="91%" Font-Size="XX-Small" 
                                 DashboardTheme="Light" Font-Strikeout="False"  
                                Height="1200px" PdfExportOptions-PaperKind="A4" OnConfigureDataConnection="ASPxDashboardViewer1_ConfigureDataConnection" 
                                PdfExportOptions-ScaleMode="AutoFitToPageWidth" Cursor="pointer" 
                                ColorScheme="dark">
<PdfExportOptions PaperKind="A4" ScaleMode="AutoFitToPageWidth"></PdfExportOptions>

                                            <ClientSideEvents ItemWidgetCreated="function(s,e){ItemWidgetCreatedHandle(e);}" />
                        <%--                    <ClientSideEvents ItemWidgetCreated="dashboardWidgetCreatead" />--%>
                        </dx:ASPxDashboardViewer>
				        </dx:ContentControl>
			        </ContentCollection>
		        </dx:TabPage>    
                 <dx:TabPage Text="MANTENIMIENTO DE COORDINADOR" >
			        <ContentCollection>
				        <dx:ContentControl ID="ContentControl3" runat="server">	
                        <table>
                        <tr>
                        <td valign="top">
                        <dx:aspxgridview ID="AspxGridGsoCoordinador" OnLoad="OnLoadCoordinador"
                            ClientInstanceName="AspxGridGsoCoordinador" 
                            OnRowInserting="InsertRowCoordinador" 
                            OnRowDeleting="DeletedRowCoordinador"  
                            OnRowUpdating="UpdatedRowCoordinador" 
                            OnRowValidating="grid_RowValidating"
                            OnStartRowEditing="grid_StartRowEditing"
                            runat="server"  KeyFieldName="IDPERSONA"
                            AutoGenerateColumns="False" 
                            Font-Size="X-Small"
                            Width="100%">
                            <Columns>
                            <dx:GridViewCommandColumn ShowEditButton="true" ShowNewButton="true" ShowDeleteButton="true" VisibleIndex="0" Width="100px" />
                            <dx:GridViewDataTextColumn FieldName="DOCUMENTO" Caption="DOCUMENTO" Width="80px"
                                VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"  
                                    Settings-AllowSort="False" PropertiesTextEdit-MaskSettings-Mask="99999999"
                                Settings-AllowDragDrop="False"  Settings-AllowHeaderFilter="False" />
                                
                            <dx:GridViewDataTextColumn FieldName="NOMBRE" Caption="NOMBRE" 
                                VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"  
                                    Settings-AllowSort="False"  
                                Settings-AllowDragDrop="False"  Width="100%"/>

                            </Columns>
                                <SettingsPopup>
                                    <EditForm Width="600" />
                                </SettingsPopup>
                               <Settings ShowHeaderFilterButton="true" ShowColumnHeaders="true" />
                                <SettingsEditing Mode="PopupEditForm" EditFormColumnCount="2" />
                                <SettingsText Title="MANTENIMIENTO DE COORDINADORES" />
                                <SettingsBehavior AllowFocusedRow="True" />
                                <Settings ShowFooter="True" ShowTitlePanel="true"  />
                                <ClientSideEvents FocusedRowChanged="UpdateDetailGrid" />
                            </dx:aspxgridview>
                
                        </td>
                        <td valign="top">
                        <dx:aspxgridview runat="server" KeyFieldName="ACT_PROY" ID="AspxGridViewCoordinadorContrato"
                            OnRowInserting="InsertRowCoordinadorContrato" 
                            OnRowDeleting="DeletedRowCoordinadorContrato"  
                            OnCustomCallback="gvDetail_CustomCallbackG"
                            OnCellEditorInitialize="EditorInitialize_Combo"
                            ClientInstanceName="AspxGridViewCoordinadorContrato"
                            AutoGenerateColumns="False" 
                            Font-Size="X-Small"
                            Width="800px">
                            <Columns>
                            <dx:GridViewCommandColumn  ShowNewButton="true" ShowDeleteButton="true" VisibleIndex="0" Width="100px" />
                                
                            <dx:GridViewDataTextColumn FieldName="ACT_PROY" Caption="CUI" 
                                VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"  EditFormSettings-Visible="False" 
                                    Settings-AllowSort="False"  
                                Settings-AllowDragDrop="False"  Width="40px"/>
                            <dx:GridViewDataComboBoxColumn Caption="ABREVIATURA" FieldName="ABREVIATURA" VisibleIndex="2" HeaderStyle-HorizontalAlign="Center"  Width="100px" >
                                <PropertiesComboBox TextField="ABREVIATURA" ValueField="ACT_PROY" >
                                </PropertiesComboBox>
                                <HeaderStyle HorizontalAlign="Center" />
                            </dx:GridViewDataComboBoxColumn>   
                            <dx:GridViewDataTextColumn FieldName="DESCRIPCION" Caption="DESCRIPCION" 
                                VisibleIndex="3" HeaderStyle-HorizontalAlign="Center"  EditFormSettings-Visible="False" 
                                    Settings-AllowSort="False"  
                                Settings-AllowDragDrop="False"  Width="100px"/>
                                             


                            </Columns>
                                <SettingsPopup>
                                    <EditForm Width="600" />
                                </SettingsPopup>
                                 <Settings ShowFooter="True" ShowTitlePanel="true"  />
                                <SettingsEditing Mode="PopupEditForm" EditFormColumnCount="1" />
                                <SettingsBehavior AllowFocusedRow="True" />
                                <SettingsText Title="ASOCIACION DE COORDINADORES CON CONTRATO"  />
                            </dx:aspxgridview>
                       
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
            <dx:PopupControlContentControl runat="server">
            </dx:PopupControlContentControl>
        </ContentCollection>                    
        </dx:ASPxPopupControl>
</td>
</tr>
</table>
<dx:XpoDataSource ID="XpoDataSource1" runat="server" 
             TypeName="PersistentObjects.gso_estado_situacional" 
             ServerMode="true"/>
</div>    
</asp:Content>
