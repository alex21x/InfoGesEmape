<%@ Page Language="C#" MasterPageFile="~/Modules/MasterPage.Master" AutoEventWireup="true" 
    CodeBehind="frmInfoGesGSOSContratoCheckList.aspx.cs" Inherits="InfoGesRegional.Modules.Forms.Seguimiento.frmInfoGesGSOSContratoCheckList" 
    Title="InfoGesConsultas" %>

<%@ Register Assembly="DevExpress.XtraReports.v17.1.Web, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>


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

    <script type="text/javascript">
            function UpdateDetailGrid(s, e) {
                AspxGridViewCoordinadorContrato.PerformCallback();
            }

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
                 <dx:TabPage Text="RELACION CONTRATO X CHECLIST" >
			        <ContentCollection>
				        <dx:ContentControl ID="ContentControl3" runat="server">	
                        <table>
                        <tr>
                        <td valign="top">
                        <dx:aspxgridview ID="AspxGridGsoContrato" OnLoad="OnLoadContrato"
                            ClientInstanceName="AspxGridGsoContrato" 
                            OnRowInserting="InsertRowContrato" 
                            OnRowDeleting="DeletedRowContrato"  
                            OnRowUpdating="UpdatedRowContrato" 
                            OnRowValidating="grid_RowValidating"
                            OnStartRowEditing="grid_StartRowEditing"
                            runat="server"  KeyFieldName="IDCONTRATO"
                            AutoGenerateColumns="False" 
                            Font-Size="Small"
                            Width="100%">
                            <Columns>
                            <dx:GridViewDataTextColumn FieldName="CUI" Caption="CUI" Settings-AutoFilterCondition="Contains"
                                VisibleIndex="1" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False"  Settings-AllowHeaderFilter="False" />
                            <dx:GridViewDataTextColumn FieldName="ABREVIATURA" Caption="ABREVIATURA" Settings-AutoFilterCondition="Contains"
                                VisibleIndex="2" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False"  Settings-AllowHeaderFilter="False" />
                            <dx:GridViewDataTextColumn FieldName="CONTRATO_NUMERO" Caption="Nº DE CONTRATO" Settings-AutoFilterCondition="Contains"
                                VisibleIndex="3" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False"  Settings-AllowHeaderFilter="False" />
                            <dx:GridViewDataTextColumn FieldName="COMPONENTE_OBRA" Caption="COMPONENTE" Settings-AutoFilterCondition="Contains"
                                VisibleIndex="4" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False"  Settings-AllowHeaderFilter="False" />

                            </Columns>
                                <Settings ShowFilterRow="True"  />

                                <SettingsPopup>
                                    <EditForm Width="600" />
                                </SettingsPopup>
                               <Settings ShowHeaderFilterButton="true" ShowColumnHeaders="true" />
                                <SettingsEditing Mode="PopupEditForm" EditFormColumnCount="2" />
                                <SettingsText Title="RELACION DE CONTRATOS" />
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
                                Settings-AllowDragDrop="False"  Width="40px"/>
                            <dx:GridViewDataComboBoxColumn Caption="ABREVIATURA" FieldName="ABREVIATURA" VisibleIndex="2" HeaderStyle-HorizontalAlign="Center"  Width="100px"  Settings-AllowAutoFilter="False" >
                                <PropertiesComboBox TextField="ACT_PROY" ValueField="ACT_PROY"  EnableSynchronization="False" IncrementalFilteringMode="StartsWith">
                                </PropertiesComboBox>
                                <HeaderStyle HorizontalAlign="Center" />
                            </dx:GridViewDataComboBoxColumn>   
                            <dx:GridViewDataTextColumn FieldName="DESCRIPCION" Caption="DESCRIPCION"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"
                                VisibleIndex="3" HeaderStyle-HorizontalAlign="Center"  EditFormSettings-Visible="False" 
                                    Settings-AllowSort="False"  
                                Settings-AllowDragDrop="False"  Width="300px"/>
                             <dx:GridViewDataCheckColumn FieldName="ESRESPONSABLE"  Caption="ASIGNADO"  VisibleIndex="4" Width="20px" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"/>
                             <dx:GridViewDataCheckColumn FieldName="INSERTAR" Caption="INS." VisibleIndex="4" Width="20px" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"/>
                             <dx:GridViewDataCheckColumn FieldName="ACTUALIZAR" Caption="UPD." VisibleIndex="5" Width="20px" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"/>
                             <dx:GridViewDataCheckColumn FieldName="ELIMINAR" Caption="DEL" VisibleIndex="6" Width="20px" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"/>
                             <dx:GridViewDataCheckColumn FieldName="CONSULTA"  Caption="QRY."  VisibleIndex="7" Width="20px" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"/>
                             <dx:GridViewDataCheckColumn FieldName="CIERRE"  Caption="CIERRE"  VisibleIndex="7" Width="20px" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"/>
                             <dx:GridViewDataCheckColumn FieldName="SUPERVISION"  Caption="SUPERVISION"  VisibleIndex="7" Width="20px" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"/>
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
</td>
</tr>
</table>
</div>    
</asp:Content>
