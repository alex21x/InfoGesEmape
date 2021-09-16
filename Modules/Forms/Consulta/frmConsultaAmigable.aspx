<%@ Page Language="C#" MasterPageFile="~/Modules/MasterPage.Master" AutoEventWireup="true" 
    CodeBehind="frmConsultaAmigable.aspx.cs" Inherits="InfoGesRegional.Modules.Forms.Consulta.frmConsultaAmigable" 
    Title="InfoGesRegional" %>


<%@ Register assembly="DevExpress.Web.ASPxEditors.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073" namespace="DevExpress.Web.ASPxDataView" tagprefix="dxdv" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style4
        {
            width: 330px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript">

              
    </script>  

    <div id="principal" >
   <table cellpadding="0" cellspacing="0" width="100%">
   <tr>
   <td>
   <table width="100%">
    <tr valign="top" >
        <td align="center"><asp:Label ID="Label3" runat="server" Text="Quien Gasta?" CssClass="sys-font-body-Text" Width="100%"></asp:Label></td>
        <td align="center" class="style4"><asp:Label ID="Label7" runat="server" Text="En que se Gasta?" CssClass="sys-font-body-Text" Width="100%"></asp:Label></td>
        <td align="center"><asp:Label ID="Label1" runat="server" Text="Financiamiento del Gasto?" CssClass="sys-font-body-Text" Width="100%"></asp:Label></td>
        <td align="center"><asp:Label ID="Label2" runat="server" Text="Como se Estructura el Gasto?" CssClass="sys-font-body-Text" Width="100%"></asp:Label></td>
        <td align="center"><asp:Label ID="Label4" runat="server" Text="Donde Se Gasta ?" CssClass="sys-font-body-Text" Width="100%"></asp:Label></td>
        <td align="center"><asp:Label ID="Label8" runat="server" Text="Cuando se hizo el Gasto?" CssClass="sys-font-body-Text" Width="100%"></asp:Label></td>
    </tr>
    <tr valign="top" >
        <td align="center"><dxe:ASPxButton ID="btnEjecutora" runat="server" Font-Size="XX-Small"
                Text="Ejecutoras" UseSubmitBehavior="False" ToolTip="Pruebas" Wrap="True" 
                CssClass="buttonAction" OnClick="btnProcesarClick1" Height="16px"   />
                
                </td>
        <td align="center" class="style4">
            <table>
            <tr>
            <td><dxe:ASPxButton ID="btn1" runat="server" Font-Size="XX-Small" 
                Text="Categoria Presupuestal" UseSubmitBehavior="False" ToolTip="Pruebas" Wrap="True" 
                CssClass="buttonAction" OnClick="btnProcesarClick2" Height="16px"   /></td>
            <td><dxe:ASPxButton ID="btn2" runat="server"  Font-Size="XX-Small"
                Text="Función" UseSubmitBehavior="False" ToolTip="Pruebas" Wrap="True" 
                CssClass="buttonAction" OnClick="btnProcesarClick3" Height="10px" 
                    Width="98px"   /></td>
            </tr></table></td>
        <td align="center"></td>
        <td align="center"></td>
        <td align="center"></td>
        <td align="center"></td>
    </tr>
   </table>
   </td>
   </tr>
   <tr>
   <td>
        <dxwgv:ASPxGridView ID="ASPxGridConsulta" runat="server" Width="100%" ClientInstanceName="ASPxGridConsulta" AutoGenerateColumns="False"  
            Font-Size="X-Small" Settings-ShowColumnHeaders="false" KeyFieldName="CONDICION">
            <Columns>
                <dxwgv:GridViewDataTextColumn FieldName="DESCRIPCION" Caption="Descripcion" VisibleIndex="3" Width="600px"/>
                <dxwgv:GridViewDataTextColumn FieldName="PIA" Caption="PIA" VisibleIndex="3" Width="200px">
                <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit></dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="PIM" Caption="PIM" VisibleIndex="3" Width="200px">
                <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit></dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="COMPROMISOANUAL" Caption="PIM" VisibleIndex="3" Width="200px">
                <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit></dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="COMPROMISO" Caption="Compromiso Mensual" VisibleIndex="3" Width="200px">
                <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit></dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="DEVENGADO" Caption="Devengado" VisibleIndex="3" Width="200px">
                <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit></dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="GIRADO" Caption="Girado" VisibleIndex="3" Width="200px">
                <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit></dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="AVANCE" Caption="Avance %" VisibleIndex="3" Width="200px">
                <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit></dxwgv:GridViewDataTextColumn>
            </Columns> 
        </dxwgv:ASPxGridView> 
   </td>
   </tr>
   <tr><td>
        <dxwgv:ASPxGridView ID="ASPxGridSeleccion" runat="server" Width="100%" KeyFieldName="CONDICION"
                ClientInstanceName="ASPxGridSeleccion" AutoGenerateColumns="False"  Font-Size="X-Small" >
            <Columns>
                <dxwgv:GridViewDataCheckColumn Caption="Selección" FieldName="IsSelected" VisibleIndex="0">
                      <DataItemTemplate>
                        <input id="Radio" type="radio" value='<%# GetFieldValue(Container.DataItem) %>' <%#GetFieldChecked(Container.DataItem)%> name="IsSelected"/>    
                    </DataItemTemplate>
                </dxwgv:GridViewDataCheckColumn>
                <dxwgv:GridViewDataTextColumn FieldName="DESCRIPCION" Caption="Descripcion" VisibleIndex="1" Width="800px"/>
                <dxwgv:GridViewDataTextColumn FieldName="PIA" Caption="PIA" VisibleIndex="3" Width="200px">
                <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit></dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="PIM" Caption="PIM" VisibleIndex="3" Width="200px">
                <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit></dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="COMPROMISOANUAL" Caption="PIM" VisibleIndex="4" Width="200px">
                <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit></dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="COMPROMISO" Caption="Compromiso Mensual" VisibleIndex="5" Width="200px">
                <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit></dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="DEVENGADO" Caption="Devengado" VisibleIndex="6" Width="200px">
                <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit></dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="GIRADO" Caption="Girado" VisibleIndex="7" Width="200px">
                <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit></dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="AVANCE" Caption="Avance %" VisibleIndex="8" Width="200px"></dxwgv:GridViewDataTextColumn>


            </Columns> 
            <SettingsBehavior AllowFocusedRow="True" />
                        <ClientSideEvents FocusedRowChanged="function(s, e) {
                            var row = s.GetRow(s.GetFocusedRowIndex());
                            if(__aspxIE)
                                row.cells[0].childNodes[0].checked = true;
                            else
                                row.cells[0].childNodes[1].checked = true;                
            }" />
        </dxwgv:ASPxGridView> 
   </td></tr>
   </table> 
  </div>    
</asp:Content>
