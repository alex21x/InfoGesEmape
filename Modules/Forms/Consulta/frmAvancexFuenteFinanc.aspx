<%@ Page Language="C#" MasterPageFile="~/Modules/MasterPage.Master" AutoEventWireup="true" 
    CodeBehind="frmAvancexFuenteFinanc.aspx.cs" Inherits="InfoGesRegional.Modules.Forms.Consulta.frmAvancexFuenteFinanc" 
    Title="InfoGesRegional" %>

<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dxpc" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView.Export" tagprefix="dxwgv" %>


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

        <tr><td align="right"><asp:Label ID="Label2" runat="server" Text="Año :" CssClass="sys-font-body-Text" Width="100%"></asp:Label></td>
            <td align="left">
            <dxe:ASPxComboBox ID="CboPeriodo" runat="server" style="vertical-align: middle" AutoPostBack="true" Font-Size="XX-Small"  ForeColor="Green"
            SelectedIndex="0" ValueType="System.String" Width="800px" OnSelectedIndexChanged="OnSelectedindexChangedPeriodo"  OnValueChanged="OnSelectedindexChangedPeriodo" >
            </dxe:ASPxComboBox>
        </td>    
        </tr>
        </tr>
        <tr><td align="right"><asp:Label ID="Label1" runat="server" Text="ACTIVIDAD O PROYECTO :" CssClass="sys-font-body-Text" Width="100%"></asp:Label></td>
            <td align="left">
            <dxe:ASPxComboBox ID="CboActividadProyecto" runat="server" style="vertical-align: middle" AutoPostBack="true" Font-Size="XX-Small"  ForeColor="Green"
            SelectedIndex="0" ValueType="System.String" Width="800px" OnSelectedIndexChanged="OnSelectedindexChangedActProy"  OnValueChanged="OnSelectedindexChangedActProy">
            </dxe:ASPxComboBox>
        </td>    
        </tr>
        </table>        
        </td>
        </tr>   
        <tr><td>
        <table>
        <tr><td align="left">
        <table><tr><td>
           <dxe:ASPxButton ID="btnXlsExport" runat="server" Text="Export to XLS" UseSubmitBehavior="False" OnClick="btnXlsExport_Click" /> 
        </td><td>            
        <dxe:ASPxButton runat="server" ID="btnVisualizarMeses" Text="Visualizar la ejecución del gasto mensual a nivel de compromiso"
            UseSubmitBehavior="false" OnClick="OnClikVisualizacionMeses" Visible="false"/>

        </td></tr></table>
        </td></tr>
            <tr><td>
            <dxwgv:ASPxGridView ID="ASPxGridviewConsultaSnipFinanciero"  runat="server" Width="100%" 
            ClientInstanceName="ASPxGridviewConsultaSnipFinanciero" OnLoad="LoadEjecucionMensual" OnHtmlDataCellPrepared="grid_HtmlDataCellPrepared"
            AutoGenerateColumns="false"  Font-Size="XX-Small" >
            <Columns>
                <dxwgv:GridViewDataTextColumn FieldName="NOMBRE" Caption="EJECUTORA" VisibleIndex="1" HeaderStyle-Wrap="True" Width="60%" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False" >
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>                    
                <dxwgv:GridViewDataTextColumn FieldName="FUENTE_FINANC_NOMBRE" Caption="FUENTE_FINANC" VisibleIndex="1" HeaderStyle-Wrap="True" Width="80%" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False" >
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>   
                <dxwgv:GridViewDataTextColumn FieldName="PIA" Caption="PIA" VisibleIndex="5" HeaderStyle-Wrap="True" Width="80px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False" >
                    <PropertiesTextEdit DisplayFormatString="c" ></PropertiesTextEdit>
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>                    
                <dxwgv:GridViewDataTextColumn FieldName="PIM" Caption="PIM" VisibleIndex="5" HeaderStyle-Wrap="True" Width="80px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False" >
                    <PropertiesTextEdit DisplayFormatString="c" ></PropertiesTextEdit>
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>                                                              
                <dxwgv:GridViewDataTextColumn FieldName="EJECUCION" Caption="EJECUCION" VisibleIndex="5" HeaderStyle-Wrap="True" Width="80px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False" >
                    <PropertiesTextEdit DisplayFormatString="c" ></PropertiesTextEdit>
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="PORCENTAJE_AVANCE" Caption="% DE AVANCE" VisibleIndex="6" HeaderStyle-Wrap="True" Width="80px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False">
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="EJECUCION_SALDO" Caption="SALDO EJECUCION" VisibleIndex="7" HeaderStyle-Wrap="True" Width="80px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False">
                    <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>

      
               </Columns>    
            <SettingsLoadingPanel Mode="ShowOnStatusBar"></SettingsLoadingPanel>
            <SettingsPager Mode="ShowAllRecords"></SettingsPager>
            <Settings  ShowFooter="true" ShowGroupFooter="VisibleAlways" ShowTitlePanel="true" VerticalScrollableHeight="600" />    
            <SettingsText Title="EJECUCION POR FUENTE DE FINANCIAMIENTO PLIEGO" />
            <SettingsLoadingPanel Mode="ShowOnStatusBar" />
                <Images>
                    <CollapsedButton Url="~/Images/radio_normal.png" />
                    <ExpandedButton Url="~/Images/radio_select.png" />
                </Images>
                <TotalSummary>
                <dxwgv:ASPxSummaryItem FieldName="PIA" SummaryType="Sum" DisplayFormat="c"/>
                <dxwgv:ASPxSummaryItem FieldName="EJECUCION" SummaryType="Sum" DisplayFormat="c"/>
                <dxwgv:ASPxSummaryItem FieldName="PIM" SummaryType="Sum" DisplayFormat="c"/>
                <dxwgv:ASPxSummaryItem FieldName="EJECUCION_SALDO" SummaryType="Sum" DisplayFormat="c"/>
                </TotalSummary>
                

            <GroupSummary>
                <dxwgv:ASPxSummaryItem FieldName="PIA" SummaryType="Sum" DisplayFormat="c" ShowInGroupFooterColumn="PIA"/>
                <dxwgv:ASPxSummaryItem FieldName="PIM" SummaryType="Sum" DisplayFormat="c" ShowInGroupFooterColumn="PIM"/>
                <dxwgv:ASPxSummaryItem FieldName="EJECUCION" SummaryType="Sum" DisplayFormat="c" ShowInGroupFooterColumn="EJECUCION"/>
                <dxwgv:ASPxSummaryItem FieldName="EJECUCION_SALDO" SummaryType="Sum" DisplayFormat="c"  ShowInGroupFooterColumn="EJECUCION_SALDO"/>
            </GroupSummary>

        </dxwgv:ASPxGridView>
        <dxwgv:ASPxGridViewExporter ID="gridExport" runat="server" GridViewID="ASPxGridviewConsultaSnipFinanciero"></dxwgv:ASPxGridViewExporter>
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
