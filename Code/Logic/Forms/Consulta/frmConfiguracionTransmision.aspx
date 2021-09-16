<%@ Page Language="C#" MasterPageFile="~/Modules/MasterPage.Master" AutoEventWireup="true" 
    CodeBehind="frmConfiguracionTransmision.aspx.cs" Inherits="InfoGesRegional.Modules.Forms.Consulta.frmConfiguracionTransmision" 
    Title="InfoGesRegional" %>


<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>

<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dxcp" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v13.1.Export , Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dxpc" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
     <div id="principal" >
    <table width="100%">
    <tr><td>
        <dxwgv:ASPxGridView ID="ASPxGridview1"  runat="server" Width="1000px"
            ClientInstanceName="ASPxGridview1" KeyFieldName="ID_PAR_OPE"
            OnLoad="LoadASPxGridview" 
            AutoGenerateColumns="false"  Font-Size="X-Small">
        <Columns>
            <dxwgv:GridViewDataTextColumn FieldName="SEC_EJEC" Caption="Sec. Ejec"  Visible="true"  VisibleIndex="1"  SortOrder="Ascending" Width="100px" />        
            <dxwgv:GridViewDataTextColumn FieldName="NOMBRE" Caption="Ejecutora" Visible="true" VisibleIndex="2"   SortOrder="Ascending" Width="100%" />        
            <dxwgv:GridViewDataTextColumn FieldName="INTERVALO" Caption="Intervalo" VisibleIndex="3" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" Width="100px"  >
                <PropertiesTextEdit DisplayFormatString="c" ></PropertiesTextEdit>
                <Settings AllowDragDrop="False" AllowSort="False"  AllowAutoFilter="False"></Settings>
            <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataSpinEditColumn FieldName="INTERVALO" Caption="INTERVALO SPINNER"></dxwgv:GridViewDataSpinEditColumn>

            </Columns> 

        <SettingsPager Mode="ShowAllRecords"/>
        <SettingsLoadingPanel Mode="ShowAsPopup"/>
        <Settings  ShowTitlePanel="true" ShowVerticalScrollBar="True" />    
     </dxwgv:ASPxGridView>
     
    </td>
    </tr>
    </table>
  </div>    
</asp:Content>
