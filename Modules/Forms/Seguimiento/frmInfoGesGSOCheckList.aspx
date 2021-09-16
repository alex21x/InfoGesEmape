<%@ Page Language="C#" MasterPageFile="~/Modules/MasterPage.Master" AutoEventWireup="true" 
    CodeBehind="frmInfoGesGSOCheckList.aspx.cs" Inherits="InfoGesRegional.Modules.Forms.Seguimiento.frmInfoGesGSOCheckList" 
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
            AspxGridViewCheckListActividad.PerformCallback();
        }

        function UpdateDetailGrid1(s, e) {
            AspxGridViewCheckListxTipo.PerformCallback();
        }

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
            width: 80%;
            margin-left: auto;
            margin-right: auto;
        }
    </style>


     <div id="principal"  class="inner" >

        <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" AutoPostBack="true"
            ActiveTabIndex="0" Height="300%" TabSpacing="3px"  Font-Size="Small"  TabStyle-VerticalAlign="Bottom"  TabAlign="Justify" Width="100%">
	        <ActiveTabStyle Font-Bold="True" Font-Size="Medium" HorizontalAlign="Center">
	        </ActiveTabStyle>                        
	        <TabPages >   
                 <dx:TabPage Text="MANTENIMIENTO DE CHECKLIST" >
			        <ContentCollection>
				        <dx:ContentControl ID="ContentControl3" runat="server">	
                        <table>
                        <tr align="center">
                        <td valign="top" >
                        <dx:aspxgridview ID="AspxGridGsoCheckList" OnLoad="OnLoadCheckList"
                            ClientInstanceName="AspxGridGsoCheckList" 
                            OnRowInserting="InsertRowCheckList" 
                            OnRowDeleting="DeletedRowCheckList"  
                            OnRowUpdating="UpdatedRowCheckList" 
                            OnRowValidating="grid_RowValidating"
                            OnStartRowEditing="grid_StartRowEditing"
                            runat="server"  KeyFieldName="IDCHECKLIST"
                            AutoGenerateColumns="False" 
                            Font-Size="Small"
                            Width="100%">
 
                            <Toolbars>
                                <dx:GridViewToolbar ItemAlign="Right">
                                    <Items>
                                        <dx:GridViewToolbarItem Command="New" />
                                        <dx:GridViewToolbarItem Command="Edit" Enabled="false" />
                                        <dx:GridViewToolbarItem Command="Delete" />
                                    </Items>
                                </dx:GridViewToolbar>
                            </Toolbars>
                             <Columns>
                             <dx:GridViewDataTextColumn FieldName="CHECKLIST_DESCRIPCION" Caption="CHECKLIST"  Settings-AllowHeaderFilter="False"  Settings-AutoFilterCondition="Contains"
                                VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"  
                                    Settings-AllowSort="False"  
                                Settings-AllowDragDrop="False"  Width="100%"/>

                            </Columns>
                                <Settings ShowFilterRow="True"  />

                                <SettingsPopup>
                                    <EditForm Width="600" />
                                </SettingsPopup>
                               <Settings ShowHeaderFilterButton="true" ShowColumnHeaders="true" />
                                <SettingsEditing Mode="PopupEditForm" EditFormColumnCount="2" />
                                <SettingsText Title="CHECKLIST" />
                                <SettingsBehavior AllowFocusedRow="True" />
                                <Settings ShowFooter="True" ShowTitlePanel="true"  />
                                <ClientSideEvents FocusedRowChanged="UpdateDetailGrid" />
                            </dx:aspxgridview>
                
                        </td>
                        <td valign="top">
                        <dx:aspxgridview runat="server" KeyFieldName="IDCHECKLIST_ACTIVIDAD" ID="AspxGridViewCheckListActividad" 
                            OnLoad="OnLoadCheckListActividades"
                            OnRowInserting="InsertRowCheckListActividades" 
                            OnRowDeleting="DeletedRowCheckListActividades" 
                            OnRowUpdating="UpdatedRowCheckListActividades" 
                            ClientInstanceName="AspxGridViewCheckListActividad"
                            AutoGenerateColumns="False"   
                            Font-Size="Small"
                            Width="800px">
 
                             <Toolbars>
                                <dx:GridViewToolbar ItemAlign="Right">
                                    <Items>
                                        <dx:GridViewToolbarItem Command="New" />
                                        <dx:GridViewToolbarItem Command="Edit" Enabled="false" />
                                        <dx:GridViewToolbarItem Command="Delete" />
                                    </Items>
                                </dx:GridViewToolbar>
                            </Toolbars>
                            <Columns>
                             <dx:GridViewDataTextColumn FieldName="CHECKLIST_ACTIVIDAD_DESCRIPCION" Caption="ACTIVIDAD"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"
                                VisibleIndex="3" HeaderStyle-HorizontalAlign="Center"  
                                    Settings-AllowSort="False"  
                                Settings-AllowDragDrop="False" />
                            </Columns>
                                <Settings ShowFilterRow="True" ShowHeaderFilterButton="true"     />
                                <SettingsPopup>
                                    <EditForm Width="600" />
                                </SettingsPopup>
                                 <Settings ShowFooter="True" ShowTitlePanel="true"  />
                                <SettingsEditing Mode="PopupEditForm" EditFormColumnCount="1" />
                                <SettingsBehavior AllowFocusedRow="True" />
                                <SettingsText Title="RELACION DE ACTIVIDADES POR CHECKLIST"  />
                            </dx:aspxgridview>
                       
                        </td>
                        </tr>
                        </table>
				        </dx:ContentControl>
			        </ContentCollection>
		        </dx:TabPage>                 
                <dx:TabPage  Text="MANTENIMIENTO DE TIPO DE TOPOLOGIA">
                <ContentCollection>
                <dx:ContentControl ID="ContentControl1" runat="server">
                <table>
                <tr>
                <td valign="top">
                    <dx:aspxgridview ID="AspxGridGsoTipologia" OnLoad="OnLoadTipologia"
                        ClientInstanceName="AspxGridGsoTipologia" 
                        OnRowInserting="InsertRowTipologia" 
                        OnRowDeleting="DeletedRowTipologia"  
                        OnRowUpdating="UpdatedRowTipologia" 
                        OnRowValidating="grid_RowValidatingTipologia"
                        OnStartRowEditing="grid_StartRowEditingTipologia"
                        runat="server"  KeyFieldName="IDTIPOLOGIA"
                        AutoGenerateColumns="False" 
                        Font-Size="Small"
                        Width="100%">
                        <Columns>
                        <dx:GridViewCommandColumn ShowEditButton="true" ShowNewButtonInHeader="true" ShowDeleteButton="true" VisibleIndex="0" Width="200px" />
                        <dx:GridViewDataTextColumn FieldName="TIPOLOGIA_DESCRIPCION" Caption="TIPOLOGIA"  Settings-AllowHeaderFilter="False"  Settings-AutoFilterCondition="Contains"
                            VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"  
                                Settings-AllowSort="False"  
                            Settings-AllowDragDrop="False"  Width="100%"/>

                        </Columns>
                            <Settings ShowFilterRow="True"  />

                            <SettingsPopup>
                                <EditForm Width="400" />
                            </SettingsPopup>
                            <Settings ShowHeaderFilterButton="true" ShowColumnHeaders="true" />
                            <SettingsEditing Mode="PopupEditForm" EditFormColumnCount="1" />
                            <SettingsText Title="MANTENIMIENTO DE TIPOLOGIA" />
                            <SettingsBehavior AllowFocusedRow="True" />
                            <Settings ShowFooter="True" ShowTitlePanel="true"  />
                            <ClientSideEvents FocusedRowChanged="UpdateDetailGrid1" />
                        </dx:aspxgridview>
                </td>
                <td valign="top">
                        <dx:aspxgridview runat="server" KeyFieldName="IDSEC" ID="AspxGridViewCheckListxTipo" 
                            OnLoad="OnLoadCheckListxTipo"
                            OnRowInserting="InsertRowCheckListxTipo" 
                            OnRowDeleting="DeletedRowCheckListxTipo" 
                            OnRowUpdating="UpdatedRowCheckListxTipo" 
                            ClientInstanceName="AspxGridViewCheckListxTipo"
                            AutoGenerateColumns="False"   
                            Font-Size="Small"
                            Width="800px">
                            <Columns>
                            <dx:GridViewCommandColumn ShowNewButtonInHeader="true" ShowEditButton="true" ShowDeleteButton="true" VisibleIndex="0" Width="100px" />
                            <dx:GridViewDataComboBoxColumn Caption="CHECKLIST" FieldName="CHECKLIST_DESCRIPCION" VisibleIndex="2" HeaderStyle-HorizontalAlign="Center"  Settings-AllowAutoFilter="False" >
                                <PropertiesComboBox TextField="CHECKLIST_DESCRIPCION" ValueField="IDCHECKLIST"  EnableSynchronization="False" IncrementalFilteringMode="StartsWith">
                                </PropertiesComboBox>
                                <HeaderStyle HorizontalAlign="Center" />
                            </dx:GridViewDataComboBoxColumn>  
                            </Columns>
                                <Settings ShowFilterRow="True" ShowHeaderFilterButton="true"     />
                                <SettingsPopup>
                                    <EditForm Width="600" />
                                </SettingsPopup>
                                 <Settings ShowFooter="True" ShowTitlePanel="true"  />
                                <SettingsEditing Mode="PopupEditForm" EditFormColumnCount="1" />
                                <SettingsBehavior AllowFocusedRow="True" />
                                <SettingsText Title="CHECKLIST DE LA TIPOLOGIA"  />
                            </dx:aspxgridview>                
                </td>
                </tr>
                </table>
                </dx:ContentControl>
                </ContentCollection>
                </dx:TabPage>      
                <dx:TabPage  Text="EXPORT">
                <ContentCollection>
                <dx:ContentControl ID="ContentControl2" runat="server">
                <dx:ASPxButton ID="btn" runat="server" Text="Relación de CheckListes." AutoPostBack="false" Font-Size="Small">
                <ClientSideEvents Click="function (s,e) {popup.Show();}" />
                </dx:ASPxButton>

                </dx:ContentControl>
                </ContentCollection>
                </dx:TabPage>                         
            </TabPages>
        </dx:ASPxPageControl>
</div>    
</asp:Content>
