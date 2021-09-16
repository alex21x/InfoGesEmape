<%@ Page Language="C#" MasterPageFile="~/Modules/MasterPage.Master" AutoEventWireup="true" 
    CodeBehind="frmAnulacionCreditoGasto.aspx.cs" Inherits="InfoGesRegional.Modules.Forms.Input.frmAnulacionCreditoGasto" 
    Title="InfoGesRegional" %>


<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView.Export" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dxpc" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="principal" >
    <table>
    <tr>
    <td>

        <table>
        <tr><td align="right"><asp:Label ID="Label3" runat="server" Text="Ejecutora :" CssClass="sys-font-body-Text" Width="100%"></asp:Label></td>
        <td align="left">
            <dxe:ASPxComboBox ID="CboEjecutora" runat="server" style="vertical-align: middle" AutoPostBack="true"  Font-Size="XX-Small"  ForeColor="Blue"
            SelectedIndex="0" ValueType="System.String" Width="400px" OnSelectedIndexChanged="OnSelectedindexChangedEjecutora" >
            </dxe:ASPxComboBox>
        </td>        
        </tr>        
        <tr><td align="right"><asp:Label ID="Label2" runat="server" Text="Centro de Costo :" CssClass="sys-font-body-Text" Width="100%"></asp:Label></td>
        <td align="left">
            <dxe:ASPxComboBox ID="CboCentroCosto" runat="server" style="vertical-align: middle" AutoPostBack="true"  Font-Size="XX-Small"  ForeColor="Blue"
            SelectedIndex="0" ValueType="System.String" Width="400px" OnSelectedIndexChanged="OnSelectedindexChangedCentroCosto" >
            </dxe:ASPxComboBox>
        </td>        
        </tr>    
        <tr><td align="right"><asp:Label ID="Label1" runat="server" Text="Sec. Func. :" CssClass="sys-font-body-Text" Width="100%"></asp:Label></td>
        <td align="left">
            <dxe:ASPxComboBox ID="CboSecFunc" runat="server" style="vertical-align: middle" AutoPostBack="true"  Font-Size="XX-Small"  ForeColor="Blue"
            SelectedIndex="0" ValueType="System.String" Width="400px" OnSelectedIndexChanged="OnSelectedindexChangedSecFunc" >
            </dxe:ASPxComboBox>
        </td>        
        </tr>  
        </table>


    </td>
    <td>
        <dxwgv:ASPxGridView ID="ASPxGridviewParOpeProgramacion"  runat="server" Width="400px" 
            ClientInstanceName="ASPxGridviewParOpeProgramacion" AutoGenerateColumns="false"  Font-Size="X-Small" OnLoad="LoadParOpeProgramacion">
            <Columns>    
            <dxwgv:GridViewDataTextColumn FieldName="MES_EJE" Caption="Mes" VisibleIndex="0" HeaderStyle-Wrap="True" Width="100px"
             HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False">
            </dxwgv:GridViewDataTextColumn> 
            <dxwgv:GridViewDataDateColumn FieldName="FECHA_PROGRAMACION" Caption="Fecha Maxima de egistro" VisibleIndex="0"  Width="120px" HeaderStyle-Wrap="True" 
             HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False">
            </dxwgv:GridViewDataDateColumn> 
            <dxwgv:GridViewDataTextColumn FieldName="CIERRE_PROGRAMACION" Caption="CIERRE" VisibleIndex="0" HeaderStyle-Wrap="True" Width="50px"
             HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False">
            </dxwgv:GridViewDataTextColumn>
                                    </Columns>
            <Settings  ShowFooter="true" ShowTitlePanel="true" VerticalScrollableHeight="50"  ShowVerticalScrollBar="True" ShowGroupPanel="false"    />    
            <SettingsPager Mode="ShowAllRecords"></SettingsPager>
            <SettingsText Title="Fecha de Nota Credito - Anulación"  />
            </dxwgv:ASPxGridView>
    </td>
    </tr>
    </table>


   <table cellpadding="0" cellspacing="0" >
        <tr><td align="left">
        </td></tr>
            <tr><td>
            <dxwgv:ASPxGridView ID="ASPxGridviewProgramacionGasto"  runat="server" Width="1000px" 
            ClientInstanceName="ASPxGridviewProgramacionGasto" OnLoad="LoadProgramacionGasto"
            KeyFieldName="IDKEY"
            OnRowUpdating="Updated_Programacion_gasto"  OnCustomUnboundColumnData="grid_CustomUnboundColumnData"
            OnHtmlRowPrepared="ASPxGridAreaOrganico_HtmlRowPrepared" OnHtmlDataCellPrepared="grvProduct_HtmlDataCellPrepared"
            
            AutoGenerateColumns="false"  Font-Size="X-Small">
            <Columns>
                <dxwgv:GridViewCommandColumn VisibleIndex="17" Caption="Botones de Edición" HeaderStyle-HorizontalAlign="Center" Width="100px" CellStyle-Font-Size="X-Small" >
                    <EditButton     Visible="True" Text="Edición" ></EditButton>
                    <HeaderStyle HorizontalAlign="Center" />
                    <CellStyle Font-Size="X-Small">
                    </CellStyle>
                </dxwgv:GridViewCommandColumn>   
                <dxwgv:GridViewDataTextColumn FieldName="FUENTE_FINANC_NOMBRE" Caption="Rubro" SortOrder="Ascending"
                    VisibleIndex="1" HeaderStyle-Wrap="True" Width="200px" 
                    HeaderStyle-HorizontalAlign="Center"  >
                    <Settings AutoFilterCondition="Contains"> </Settings>
                    <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                    <PropertiesTextEdit Width="200px" Style-Font-Size="XX-Small"></PropertiesTextEdit> 
                </dxwgv:GridViewDataTextColumn>             
                <dxwgv:GridViewDataTextColumn FieldName="ESPECIFICA_DET_NOMBRE" Caption="Clasificador de Gasto" SortOrder="Ascending"
                    VisibleIndex="2" HeaderStyle-Wrap="True" Width="400px" 
                    HeaderStyle-HorizontalAlign="Center"  >
                    <Settings AutoFilterCondition="Contains"></Settings>
                    <PropertiesTextEdit Width="300px" Style-Font-Size="XX-Small"></PropertiesTextEdit> 
                    <HeaderStyle HorizontalAlign="Center" Wrap="True" ></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>             
                <dxwgv:GridViewDataTextColumn FieldName="PIM" Caption="PIM" VisibleIndex="3" Width="120px"  ShowInCustomizationForm="true"   HeaderStyle-HorizontalAlign="Center"  Settings-AllowSort="False" Settings-AllowDragDrop="False"  CellStyle-Font-Bold="true"> 
                    <PropertiesTextEdit DisplayFormatString="c" Width="50%" Style-Font-Size="XX-Small"></PropertiesTextEdit> 
                </dxwgv:GridViewDataTextColumn> 
                <dxwgv:GridViewDataTextColumn FieldName="CREDITO" Caption="CREDITO" VisibleIndex="4" Width="120px"  ShowInCustomizationForm="true"   HeaderStyle-HorizontalAlign="Center"  Settings-AllowSort="False" Settings-AllowDragDrop="False"> 
                    <PropertiesTextEdit DisplayFormatString="c" Width="50%" ></PropertiesTextEdit> 
                </dxwgv:GridViewDataTextColumn> 
                <dxwgv:GridViewDataTextColumn FieldName="ANULACION" Caption="ANULACION" VisibleIndex="5" Width="120px"  ShowInCustomizationForm="true"   HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False"> 
                    <PropertiesTextEdit DisplayFormatString="c" Width="50%"></PropertiesTextEdit> 
                </dxwgv:GridViewDataTextColumn> 
                <dxwgv:GridViewDataTextColumn FieldName="SALDOANULACIONCREDITO"  Caption="SALDO"  Width="120px" VisibleIndex="7" UnboundType="Decimal" HeaderStyle-HorizontalAlign="Center"  Settings-AllowSort="False" Settings-AllowDragDrop="False" HeaderStyle-Wrap="True"  CellStyle-Font-Bold="true">
                    <FooterCellStyle ForeColor="Brown" />
                    <PropertiesTextEdit DisplayFormatString="c" />
                </dxwgv:GridViewDataTextColumn>
               </Columns> 
                <GroupSummary>
                <dxwgv:ASPxSummaryItem FieldName="PIM" SummaryType="Sum" DisplayFormat="c" ShowInGroupFooterColumn="PIM"/>  
               <dxwgv:ASPxSummaryItem FieldName="ANULACION" SummaryType="Sum" DisplayFormat="c" ShowInGroupFooterColumn="ANULACION"/>  
               <dxwgv:ASPxSummaryItem FieldName="CREDITO" SummaryType="Sum" DisplayFormat="c" ShowInGroupFooterColumn="CREDITO"/>  
               <dxwgv:ASPxSummaryItem FieldName="SALDOANULACIONCREDITO" SummaryType="Sum" DisplayFormat="c" ShowInGroupFooterColumn="SALDOANULACIONCREDITO"/>                 
                </GroupSummary>            
                <TotalSummary>
                <dxwgv:ASPxSummaryItem FieldName="PIM" SummaryType="Sum" DisplayFormat="c"/>
                <dxwgv:ASPxSummaryItem FieldName="ANULACION" SummaryType="Sum" DisplayFormat="c"/>
                <dxwgv:ASPxSummaryItem FieldName="CREDITO" SummaryType="Sum" DisplayFormat="c"/>
                <dxwgv:ASPxSummaryItem FieldName="SALDOANULACIONCREDITO" SummaryType="Sum" DisplayFormat="c"/>
                </TotalSummary>
            <SettingsPager Mode="ShowAllRecords"></SettingsPager>
            <Settings  ShowFooter="true" ShowGroupFooter="VisibleAlways"  ShowTitlePanel="true" VerticalScrollableHeight="600"  ShowGroupPanel="true"   />    
            <SettingsText Title="NOTA MODIFICATORIA : CREDITOS Y ANULACIONES"  />
            <SettingsEditing Mode="PopupEditForm" EditFormColumnCount="3" PopupEditFormWidth="800px" PopupEditFormVerticalAlign="WindowCenter" />
        </dxwgv:ASPxGridView>
        <dxwgv:ASPxGridViewExporter ID="gridExport" runat="server" GridViewID="ASPxGridviewSeguimientoSNIP"></dxwgv:ASPxGridViewExporter>

    </td></tr>
    </table> 
  </div>    
</asp:Content>
