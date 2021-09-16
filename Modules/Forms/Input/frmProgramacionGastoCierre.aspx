<%@ Page Language="C#" MasterPageFile="~/Modules/MasterPage.Master" AutoEventWireup="true" 
    CodeBehind="frmProgramacionGastoCierre.aspx.cs" Inherits="InfoGesRegional.Modules.Forms.Input.frmProgramacionGastoCierre" 
    Title="InfoGesRegional" %>


<%@ Register assembly="DevExpress.Web.ASPxEditors.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073" namespace="DevExpress.Web.ASPxDataView" tagprefix="dxdv" %>
<%@ Register assembly="DevExpress.Web.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dxpc" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v8.3.Export , Version=8.3.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073" Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dxwgv" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="principal" >
   <table cellpadding="0" cellspacing="0" >
        <tr><td align="left">
        </td></tr>
            <tr><td>
            <dxwgv:ASPxGridView ID="ASPxGridviewProgramacionGastoCierre"  runat="server" Width="100%" 
            ClientInstanceName="ASPxGridviewProgramacionGastoCierre" OnLoad="LoadProgramacionGasto" 
            KeyFieldName="ID_PROGRAMACION"
            OnRowUpdating="Updated_Programacion_Gasto_Cierre" 
            AutoGenerateColumns="false"  Font-Size="X-Small">
            <Columns>
                <dxwgv:GridViewCommandColumn VisibleIndex="16" Caption="Botones de Edición" HeaderStyle-HorizontalAlign="Center" Width="100px" CellStyle-Font-Size="X-Small" >
                    <EditButton     Visible="True" Text="Edición" ></EditButton>
                    <HeaderStyle HorizontalAlign="Center" />
                    <CellStyle Font-Size="X-Small">
                    </CellStyle>
                </dxwgv:GridViewCommandColumn>   
                <dxwgv:GridViewDataTextColumn FieldName="ANO_EJE" Caption="año" SortOrder="Ascending"
                    VisibleIndex="1" HeaderStyle-Wrap="True" Width="100%"  Settings-AllowSort="False" Settings-AllowDragDrop="False"
                    HeaderStyle-HorizontalAlign="Center"  >
                    <Settings AllowDragDrop="False" AllowSort="False" AutoFilterCondition="Contains"></Settings>
                    <HeaderStyle HorizontalAlign="Center" Wrap="True" ></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>      
                <dxwgv:GridViewDataDateColumn FieldName="CIERRE_PROGRAMACION" Caption="Fecha Cierre de Programación" HeaderStyle-Wrap="True"
                    VisibleIndex="6" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False"  Settings-AllowHeaderFilter="False" > 
                    <HeaderStyle HorizontalAlign="Center" />
                </dxwgv:GridViewDataDateColumn >
                <dxwgv:GridViewDataComboBoxColumn FieldName="ESTADO_PROGRAMACION" Caption="ESTADO PROGRAMACION_DESCRIPCION"  HeaderStyle-Wrap="True" 
                    VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"  Settings-AllowSort="False" Settings-AllowDragDrop="False" >
                    <PropertiesComboBox TextField="ESTADO PROGRAMACION_DESCRIPCION" ValueField="ESTADO PROGRAMACION" >
                    </PropertiesComboBox>
                    <HeaderStyle HorizontalAlign="Center" />
                </dxwgv:GridViewDataComboBoxColumn>                                    
                       
               </Columns>    
            <SettingsPager Mode="ShowPager" ></SettingsPager>
            <Settings  ShowFooter="true" ShowGroupFooter="VisibleAlways" ShowTitlePanel="true" VerticalScrollableHeight="600"    />    
            <SettingsText Title="CIERRE DE PROGRAMACION DE GASTO...."  />
            <SettingsEditing Mode="PopupEditForm" EditFormColumnCount="3" PopupEditFormWidth="800px" PopupEditFormVerticalAlign="WindowCenter" />
        </dxwgv:ASPxGridView>
        <dxwgv:ASPxGridViewExporter ID="gridExport" runat="server" GridViewID="ASPxGridviewProgramacionGastoCierre"></dxwgv:ASPxGridViewExporter>

    </td></tr>
    </table> 
  </div>    
</asp:Content>
