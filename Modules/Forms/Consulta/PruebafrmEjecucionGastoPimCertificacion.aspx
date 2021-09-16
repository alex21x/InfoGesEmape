<%@ Page Language="C#" MasterPageFile="~/Modules/MasterPage.Master" AutoEventWireup="true" 
    CodeBehind="PruebafrmEjecucionGastoPimCertificacion.aspx.cs" Inherits="InfoGesRegional.Modules.Forms.Consulta.PruebafrmEjecucionGastoPimCertificacion" 
    Title="InfoGesRegional" %>


<%@ Register assembly="DevExpress.Web.ASPxEditors.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<%@ Register assembly="DevExpress.Web.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073" namespace="DevExpress.Web.ASPxDataView" tagprefix="dxdv" %>
<%@ Register assembly="DevExpress.Web.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dxpc" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript">
       // <![CDATA[
        function OnMoreInfoClick(contentUrl) {
            clientPopupControl.SetContentUrl(contentUrl);
            clientPopupControl.Show();
        }
              
    </script>  

    <div id="principal" >
   <table cellpadding="0" cellspacing="0" >
        <tr><td colspan="4">
        <table width="100%">
        <tr><td align="right"><asp:Label ID="Label3" runat="server" Text="Ejecutora :" CssClass="sys-font-body-Text" Width="100%"></asp:Label></td>
        <td align="left">
            <dxe:ASPxComboBox ID="CboEjecutora" runat="server" style="vertical-align: middle" AutoPostBack="true"  Font-Size="XX-Small"  ForeColor="Blue"
            SelectedIndex="0" ValueType="System.String" Width="800px" OnSelectedIndexChanged="OnSelectedindexChangedEjecutora" >
            </dxe:ASPxComboBox>
        </td>        
        </tr>
        <tr><td align="right"><asp:Label ID="Label2" runat="server" Text="Año :" CssClass="sys-font-body-Text" Width="100%"></asp:Label></td>
            <td align="left">
            <dxe:ASPxComboBox ID="CboPeriodo" runat="server" style="vertical-align: middle" AutoPostBack="true" Font-Size="XX-Small"  ForeColor="Blue"
            SelectedIndex="0" ValueType="System.String" Width="800px" OnSelectedIndexChanged="OnSelectedindexChangedPeriodo"  OnValueChanged="OnSelectedindexChangedPeriodo" >
            </dxe:ASPxComboBox>
        </td>    
        </tr>
        <tr><td align="right"><asp:Label ID="Label4" runat="server" Text="Centro de Costo :" CssClass="sys-font-body-Text" Width="100%"></asp:Label></td>
        <td align="left">        
            <dxe:ASPxComboBox ID="CboCentroCosto" runat="server" style="vertical-align: middle" AutoPostBack="true"  Font-Size="XX-Small"  ForeColor="Blue"
            SelectedIndex="0" ValueType="System.String" Width="800px"  OnSelectedIndexChanged="OnSelectedindexChangedCentroCosto">
            </dxe:ASPxComboBox>
        </td>        
        </tr>
        <tr><td align="right"><asp:Label ID="Label1" runat="server" Text="Cadena Funcional :" CssClass="sys-font-body-Text" Width="100%"></asp:Label></td>
        <td align="left">        
            <dxe:ASPxComboBox ID="CboCadFuncional" runat="server" style="vertical-align: middle" AutoPostBack="true"  Font-Size="XX-Small"  ForeColor="Blue"
            SelectedIndex="0" ValueType="System.String" Width="800px"  OnSelectedIndexChanged="OnSelectedindexChangedSec_Func">
            </dxe:ASPxComboBox>
        </td>        
        </tr>
        </table>        
        </td>
        </tr>   
        <tr><td>
        <table>
        <tr><td align="left">
           <dxe:ASPxButton ID="btnXlsExport" runat="server" Text="Export to XLS" UseSubmitBehavior="False" OnClick="btnXlsExport_Click" /> 
        </td></tr>
            <tr><td>
            
        <dxwtl:ASPxTreeList ID="ASPxGridviewConsultaSnipFinanciero" runat="server" AutoGenerateColumns="False" OnLoad="LoadProyectoSnipSiaf"
        Width="100%" Font-Size="X-Small"
        KeyFieldName="SEC_FUNC_NOMBRE" ParentFieldName="FUENTE_FINANC_NOMBRE">
         <Columns>
            <dxwtl:TreeListDataColumn FieldName="SEC_FUNC_NOMBRE" VisibleIndex="0" />
            <dxwtl:TreeListDataColumn FieldName="FUENTE_FINANC_NOMBRE" VisibleIndex="1" />
            <dxwtl:TreeListDataColumn FieldName="CLASIFICADOR" VisibleIndex="1" />
            <dxwtl:TreeListDataColumn FieldName="PIM" VisibleIndex="1" DisplayFormat="{0:C}" />
        </Columns>
        <SettingsBehavior ExpandCollapseAction="NodeDblClick" />
        </dxwtl:ASPxTreeList>


        <dxpc:ASPxPopupControl ID="popupControl" runat="server" ClientInstanceName="clientPopupControl"  CloseAction="CloseButton" Height="400px" Modal="True" Width="950px" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter">
        <ContentCollection>
            <dxpc:PopupControlContentControl runat="server">
            </dxpc:PopupControlContentControl>
        </ContentCollection>                    
        </dxpc:ASPxPopupControl>
        </td></tr>
        </table>
    </td></tr>
    </table> 
  </div>    
</asp:Content>
