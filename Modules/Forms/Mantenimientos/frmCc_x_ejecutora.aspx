<%@ Page Language="C#" MasterPageFile="~/Modules/MasterPage.Master" AutoEventWireup="true" 
    CodeBehind="frmCc_x_ejecutora.aspx.cs" Inherits="InfoGesRegional.Modules.Forms.Mantenimientos.frmCc_x_ejecutora" 
    Title="Untitled Page" %>



<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <div id="principal">
    <table width="100%"><tr><td><p align="justify" style="font-family : Tahoma; font-size : 10pt;">
    En esta opción podra crear Centro de Costo que seran usados en las diferentes Unidades Ejecutoras...</p>
    </td></tr></table>
    <table width="100%"><tr><td>
        <asp:Label ID="lblMensaje" Visible="False" runat="server" 
            Text="Debera de seleccionar un Insertar / Modificar / Eliminar !!!" Font-Bold="True" Font-Size="Small" 
            ForeColor="#CC3300"></asp:Label></td></tr></table>
    <br />
    <table width="90%">
        <tr><td>
        <table><tr>
        <td align="left"><asp:Label ID="Label3" runat="server" Text="Ejecutora :" CssClass="sys-font-body-Text" Width="100%"></asp:Label></td>
    <td>
            <dxe:ASPxComboBox ID="CboEjecutora" runat="server" style="vertical-align: middle" AutoPostBack="true"  Font-Size="XX-Small"  ForeColor="Green"
            SelectedIndex="0" ValueType="System.String" Width="800px" OnSelectedIndexChanged="OnSelectedindexChangedEjecutora" >
            </dxe:ASPxComboBox>
    </td>
        </tr></table>
        </td>
        

    </tr>
        <tr>
            <td width="99%"valign="top">

                    <div class="divGray">
                        <dxwgv:ASPxGridView ID="ASPxGridviewCentroCostoEjec"  runat="server" Width="100%" 
                            ClientInstanceName="ASPxGridviewCentroCostoEjec"
                            KeyFieldName="ID_CENTRO_COSTO_X_EJECUTORA"
                            OnCellEditorInitialize="EditorInitializeCentroCostoejec"
                            OnLoad="LoadCentroCostoEjec" 
                            OnRowInserting="InsertCentroCostoEjec" 
                            OnRowUpdating="UpdatedCentroCostoEjec" 
                            OnRowDeleting="DeleteCentroCostoEjec"
                            AutoGenerateColumns="False"  Font-Size="X-Small">
                        <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True"/>
                        <Columns>
                            <dxwgv:GridViewCommandColumn VisibleIndex="0" Caption="Botones de Edición" HeaderStyle-HorizontalAlign="Center">
                                <EditButton     Visible="True" Text="Edición" ></EditButton>
                                <NewButton      Visible="True" Text="Nuevo"></NewButton>
                                <DeleteButton   Visible="true" Text="Eliminar"></DeleteButton>
                                <UpdateButton   Visible="true" Text="Grabar"></UpdateButton>
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </dxwgv:GridViewCommandColumn>   
                            <dxwgv:GridViewDataTextColumn Caption="Descripcion" FieldName="DESCRIPCION" HeaderStyle-HorizontalAlign="Center" VisibleIndex="1" Width="50%"  >
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataComboBoxColumn Caption="CENTRO DE COSTO" FieldName="DESCRIPCION_CENTRO_COSTO" VisibleIndex="2" HeaderStyle-HorizontalAlign="Center"  Width="100%" >
                                <PropertiesComboBox TextField="DESCRIPCION_CENTRO_COSTO" ValueField="ID_CENTRO_COSTO" >
                                </PropertiesComboBox>
                                <HeaderStyle HorizontalAlign="Center" />
                            </dxwgv:GridViewDataComboBoxColumn>    
                        </Columns> 
                        <Settings ShowFooter="True" />
                        <SettingsEditing Mode="Inline" PopupEditFormWidth="320px"/>
                        <SettingsBehavior AllowDragDrop="False" />
                        <SettingsPager Mode="ShowAllRecords"/>
                        <Settings ShowTitlePanel="true" />
                        <SettingsText Title="Mantenimiento : CENTRO DE COSTO X EJECUTORA" PopupEditFormCaption="Mantenimiento : CENTRO DE COSTO X EJECUTORA" />
                    </dxwgv:ASPxGridView>
                    </div>

            </td>
        </tr>
    </table>
  </div>    
    <br />
</asp:Content>
