<%@ Page Language="C#" MasterPageFile="~/Modules/MasterPage.Master" AutoEventWireup="true" CodeBehind="frmMenu.aspx.cs" Inherits="InfoGesRegional.Modules.Forms.Seguimiento.frmMenu" Title="Untitled Page" %>



<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <script language="javascript">
        function OnLinkClick(id, visibleIndex) {
                if(confirm('Desea eliminar el Registro ID = ' + id + '?'))
                    ASPxGridviewProyecto.DeleteRow(visibleIndex);
            }
    
        </script>
  <div id="principal">
    <table width="100%"><tr><td><p align="justify" style="font-family : Tahoma; font-size : 10pt;">Se muestra la relacion de los Ejecutora, usted debe
    seleccionar una ejecutora para continuar.</p>
    </td></tr></table>
    <table width="100%"><tr><td>
        <asp:Label ID="lblMensaje" Visible="False" runat="server" 
            Text="Debera de seleccionar un Operador !!!" Font-Bold="True" Font-Size="Small" 
            ForeColor="#CC3300"></asp:Label></td></tr></table>
    <br />
    <table width="100%">
        <tr>
            <td width="99%" align="center" valign="top">

                    <div class="divGray">
                    
                        <dxwgv:ASPxGridView ID="ASPxGridviewEjecutora"  runat="server" Width="648px" 
                            ClientInstanceName="ASPxGridviewEjecutora"
                            KeyFieldName="SEC_EJEC"
                            OnLoad="LoadASPxGridviewEjecutora" 
                            AutoGenerateColumns="False" OnRowCommand="EvtRowCommand" Font-Size="X-Small">
                        <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True"/>
                        <Columns>
                            <dxwgv:GridViewDataTextColumn Caption="Activar" Name="colAction" VisibleIndex="0"  CellStyle-HorizontalAlign="Center">
                                <HeaderStyle HorizontalAlign="Center" />
                                <DataItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" CommandArgument='<%# Eval("SEC_EJEC") %>' CommandName="Select" runat="server">Activar</asp:LinkButton>
                                </DataItemTemplate>
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn FieldName="NOMBRE" Caption="EJECUTORA" VisibleIndex="1" CellStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center" />
                            </dxwgv:GridViewDataTextColumn>
                        </Columns> 
                        <Settings ShowFooter="True" />
                        <SettingsBehavior AllowDragDrop="False" />
                        <SettingsPager Mode="ShowAllRecords"/>
                        <Settings ShowTitlePanel="true" />
                        <SettingsText Title="SELECCION DE EJECUTORA" />                        
                    </dxwgv:ASPxGridView>
                    </div>

            </td>
        </tr>
    </table>
  </div>    
    <br />
</asp:Content>

