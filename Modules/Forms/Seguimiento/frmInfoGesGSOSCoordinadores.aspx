<%@ Page Language="C#" MasterPageFile="~/Modules/MasterPage.Master" AutoEventWireup="true" 
    CodeBehind="frmInfoGesGSOSCoordinadores.aspx.cs" Inherits="InfogesEmape.Modules.Forms.Seguimiento.frmInfoGesGSOSCoordinadores" 
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
            background-color :White;
            width: 90%;
            margin-left: auto;
            margin-right: auto;
        }
    </style>


     <div id="principal"  class="inner" >

<table>
<tr><td>
<dx:ASPxButton ID="btn" runat="server" Text="Relación de Coordinadores." AutoPostBack="false" Font-Size="Small" OnClick="btn_Click">
            <ClientSideEvents Click="function (s,e) {popup.Show();}" />
</dx:ASPxButton></td>
</td>
</tr>
<tr>
<td>

        <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" AutoPostBack="true"
            ActiveTabIndex="0" Height="300%" TabSpacing="3px"  Font-Size="X-Small" 
            Width="100%" onactivetabchanged="ASPxPageControl1_ActiveTabChanged" >
	        <ActiveTabStyle Font-Bold="True" Font-Size="Small">
	        </ActiveTabStyle>                        
	        <TabPages >   
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
                            <dx:GridViewCommandColumn ShowEditButton="true" ShowNewButtonInHeader="true" ShowDeleteButton="true" VisibleIndex="0" Width="100px" />
                            <dx:GridViewDataTextColumn FieldName="DOCUMENTO" Caption="DOCUMENTO" Width="80px"  Settings-AutoFilterCondition="Contains"
                                VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"  
                                    Settings-AllowSort="False" PropertiesTextEdit-MaskSettings-Mask="99999999"
                                Settings-AllowDragDrop="False"  Settings-AllowHeaderFilter="False" >
                                
<PropertiesTextEdit>
<MaskSettings Mask="99999999"></MaskSettings>
</PropertiesTextEdit>

<Settings AllowDragDrop="False" AutoFilterCondition="Contains" AllowHeaderFilter="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
								</dx:GridViewDataTextColumn>
                                
                            <dx:GridViewDataTextColumn FieldName="NOMBRE" Caption="NOMBRE"  Settings-AllowHeaderFilter="False"  Settings-AutoFilterCondition="Contains"
                                VisibleIndex="2" HeaderStyle-HorizontalAlign="Center"  
                                    Settings-AllowSort="False"  
                                Settings-AllowDragDrop="False"  Width="100%">

<Settings AllowDragDrop="False" AutoFilterCondition="Contains" AllowHeaderFilter="False" AllowSort="False"></Settings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
								</dx:GridViewDataTextColumn>

                            	<dx:GridViewDataComboBoxColumn Caption="ROLE" FieldName="ROLE" ShowInCustomizationForm="True" VisibleIndex="3" Width="50px">
									<PropertiesComboBox TextField="ROLE_ID" ValueField="ROLE_ID">
									</PropertiesComboBox>
									<Settings AllowAutoFilter="False" />
								</dx:GridViewDataComboBoxColumn>

                            </Columns>
                                <Settings ShowFilterRow="True"  />

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
                        <dx:aspxgridview runat="server" KeyFieldName="IDCOORDINADORCONTRATO" ID="AspxGridViewCoordinadorContrato" 
                            OnLoad="OnLoadCoordinadorContrato"
                            OnRowInserting="InsertRowCoordinadorContrato" 
                            OnRowDeleting="DeletedRowCoordinadorContrato" 
                            OnRowUpdating="UpdatedRowCoordinadorContrato" 
                            OnCustomCallback="gvDetail_CustomCallbackG"
                            OnCellEditorInitialize="EditorInitialize_Combo"
                            ClientInstanceName="AspxGridViewCoordinadorContrato"
                            AutoGenerateColumns="False"   
                            Font-Size="X-Small"
                            Width="800px">
                            <Columns>
                            <dx:GridViewCommandColumn ShowNewButtonInHeader="true" ShowEditButton="true" ShowDeleteButton="true" VisibleIndex="0" Width="100px" />
                                
                            <dx:GridViewDataTextColumn FieldName="ACT_PROY" Caption="CUI" Settings-AutoFilterCondition="Contains"
                                VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"  EditFormSettings-Visible="False" 
                                    Settings-AllowSort="False"  
                                Settings-AllowDragDrop="False"  Width="40px">
<Settings AllowDragDrop="False" AutoFilterCondition="Contains" AllowSort="False"></Settings>

<EditFormSettings Visible="False"></EditFormSettings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
								</dx:GridViewDataTextColumn>
                            <dx:GridViewDataComboBoxColumn Caption="ABREVIATURA" FieldName="ABREVIATURA" VisibleIndex="2" HeaderStyle-HorizontalAlign="Center"  Width="100px"  Settings-AllowAutoFilter="False" >
                                <PropertiesComboBox TextField="ACT_PROY" ValueField="ACT_PROY"  EnableSynchronization="False" IncrementalFilteringMode="StartsWith">
                                </PropertiesComboBox>

<Settings AllowAutoFilter="False"></Settings>

                                <HeaderStyle HorizontalAlign="Center" />
                            </dx:GridViewDataComboBoxColumn>   
                            <dx:GridViewDataTextColumn FieldName="DESCRIPCION" Caption="DESCRIPCION"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"
                                VisibleIndex="3" HeaderStyle-HorizontalAlign="Center"  EditFormSettings-Visible="False" 
                                    Settings-AllowSort="False"  
                                Settings-AllowDragDrop="False"  Width="300px">
<Settings AllowDragDrop="False" AllowAutoFilter="False" AllowHeaderFilter="False" AllowSort="False"></Settings>

<EditFormSettings Visible="False"></EditFormSettings>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
								</dx:GridViewDataTextColumn>
                             <dx:GridViewDataCheckColumn FieldName="ESRESPONSABLE"  Caption="ASIGNADO"  VisibleIndex="4" Width="20px" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>
								</dx:GridViewDataCheckColumn>
                             <dx:GridViewDataCheckColumn FieldName="INSERTAR" Caption="INS." VisibleIndex="4" Width="20px" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>
								</dx:GridViewDataCheckColumn>
                             <dx:GridViewDataCheckColumn FieldName="ACTUALIZAR" Caption="UPD." VisibleIndex="5" Width="20px" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>
								</dx:GridViewDataCheckColumn>
                             <dx:GridViewDataCheckColumn FieldName="ELIMINAR" Caption="DEL" VisibleIndex="6" Width="20px" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>
								</dx:GridViewDataCheckColumn>
                             <dx:GridViewDataCheckColumn FieldName="CONSULTA"  Caption="QRY."  VisibleIndex="7" Width="20px" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>
								</dx:GridViewDataCheckColumn>
                             <dx:GridViewDataCheckColumn FieldName="CIERRE"  Caption="CIERRE"  VisibleIndex="7" Width="20px" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>
								</dx:GridViewDataCheckColumn>
                             <dx:GridViewDataCheckColumn FieldName="SUPERVISION"  Caption="SUPERVISION"  VisibleIndex="7" Width="20px" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>
								</dx:GridViewDataCheckColumn>
                            </Columns>
                                <Settings ShowFilterRow="True" ShowHeaderFilterButton="true"     />

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
            	<asp:HiddenField ID="btnRole_id" runat="server" Value="6" />
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
                    	<dx:ASPxWebDocumentViewer ID="ASPxWebDocumentViewer1" runat="server" Width="900px">
						</dx:ASPxWebDocumentViewer>
                    </div>
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
