<%@ Page Language="C#" MasterPageFile="~/Modules/MasterPage.Master" AutoEventWireup="true" 
    CodeBehind="frmCentro_Costo.aspx.cs" Inherits="InfoGesRegional.Modules.Forms.Mantenimientos.frmCentro_Costo" 
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
        <tr>
            <td width="99%" align="center" valign="top">

                    <div class="divGray">
                        <dxwgv:ASPxGridView ID="ASPxGridviewCentroCosto"  runat="server" Width="60%" 
                            ClientInstanceName="ASPxGridviewCentroCosto"
                            KeyFieldName="ID_CENTRO_COSTO"
                            OnLoad="LoadCentroCosto" 
                            OnRowInserting="InsertCentroCosto" 
                            OnRowUpdating="UpdatedCentroCosto" 
                            OnRowDeleting="DeleteCentrocosto"
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
                            <dxwgv:GridViewDataTextColumn Caption="Centro de Costo" FieldName="DESCRIPCION_CENTRO_COSTO" HeaderStyle-HorizontalAlign="Center" VisibleIndex="5" Width="100%"  >
                            </dxwgv:GridViewDataTextColumn>
                        </Columns> 
                        <Settings ShowFooter="True" />
                        <SettingsEditing Mode="Inline" PopupEditFormWidth="320px"/>
                        <SettingsBehavior AllowDragDrop="False" />
                        <SettingsPager Mode="ShowAllRecords"/>
                        <Settings ShowTitlePanel="true" />
                        <SettingsText Title="Mantenimiento : CENTRO DE COSTO" PopupEditFormCaption="Mantenimiento : CENTRO DE COSTO" />
                    </dxwgv:ASPxGridView>
                    </div>

            </td>
        </tr>
    </table>
  </div>    
    <br />
</asp:Content>
