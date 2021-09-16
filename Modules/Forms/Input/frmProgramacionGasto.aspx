<%@ Page Language="C#" MasterPageFile="~/Modules/MasterPage.Master" AutoEventWireup="true" 
    CodeBehind="frmProgramacionGasto.aspx.cs" Inherits="InfoGesRegional.Modules.Forms.Input.frmProgramacionGasto" 
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
            SelectedIndex="0" ValueType="System.String" Width="800px" OnSelectedIndexChanged="OnSelectedindexChangedEjecutora" >
            </dxe:ASPxComboBox>
        </td>        
        </tr>        
        <tr><td align="right"><asp:Label ID="Label2" runat="server" Text="Centro de Costo :" CssClass="sys-font-body-Text" Width="100%"></asp:Label></td>
        <td align="left">
            <dxe:ASPxComboBox ID="CboCentroCosto" runat="server" style="vertical-align: middle" AutoPostBack="true"  Font-Size="XX-Small"  ForeColor="Blue"
            SelectedIndex="0" ValueType="System.String" Width="800px" OnSelectedIndexChanged="OnSelectedindexChangedCentroCosto" >
            </dxe:ASPxComboBox>
        </td>        
        </tr>    
        <tr><td align="right"><asp:Label ID="Label1" runat="server" Text="Sec. Func. :" CssClass="sys-font-body-Text" Width="100%"></asp:Label></td>
        <td align="left">
            <dxe:ASPxComboBox ID="CboSecFunc" runat="server" style="vertical-align: middle" AutoPostBack="true"  Font-Size="XX-Small"  ForeColor="Blue"
            SelectedIndex="0" ValueType="System.String" Width="800px" OnSelectedIndexChanged="OnSelectedindexChangedSecFunc" >
            </dxe:ASPxComboBox>
        </td>        
        </tr>  
        </table>


    </td>
    <td>
        <dxwgv:ASPxGridView ID="ASPxGridviewParOpeProgramacion"  runat="server" Width="80%" 
            ClientInstanceName="ASPxGridviewParOpeProgramacion" AutoGenerateColumns="false"  Font-Size="X-Small" OnLoad="LoadParOpeProgramacion">
            <Columns>    
            <dxwgv:GridViewDataTextColumn FieldName="MES_EJE" Caption="Mes" VisibleIndex="0" HeaderStyle-Wrap="True" Width="100px"
             HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False">
            </dxwgv:GridViewDataTextColumn> 
            <dxwgv:GridViewDataDateColumn FieldName="FECHA_PROGRAMACION" Caption="Fecha Maxima de Programación" VisibleIndex="0"  Width="120px" HeaderStyle-Wrap="True" 
             HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False">
            </dxwgv:GridViewDataDateColumn> 
            <dxwgv:GridViewDataTextColumn FieldName="CIERRE_PROGRAMACION" Caption="CIERRE" VisibleIndex="0" HeaderStyle-Wrap="True" Width="50px"
             HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False">
            </dxwgv:GridViewDataTextColumn>
                                    </Columns>
            <Settings  ShowFooter="true" ShowTitlePanel="true" VerticalScrollableHeight="50"  ShowVerticalScrollBar="True" ShowGroupPanel="false"    />    
            <SettingsPager Mode="ShowAllRecords"></SettingsPager>
            <SettingsText Title="Fecha de Programación"  />
            </dxwgv:ASPxGridView>
    </td>
    </tr>
    </table>


   <table cellpadding="0" cellspacing="0" >
        <tr><td align="left">
        </td></tr>
            <tr><td>
            <dxwgv:ASPxGridView ID="ASPxGridviewProgramacionGasto"  runat="server" Width="100%" 
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
                    VisibleIndex="1" HeaderStyle-Wrap="True" Width="100%" 
                    HeaderStyle-HorizontalAlign="Center"  >
                    <Settings AutoFilterCondition="Contains"></Settings>
                    <HeaderStyle HorizontalAlign="Center" Wrap="True" ></HeaderStyle>
                    <PropertiesTextEdit Width="120%" Style-Font-Size="XX-Small"></PropertiesTextEdit> 
                </dxwgv:GridViewDataTextColumn>             
                <dxwgv:GridViewDataTextColumn FieldName="ESPECIFICA_DET_NOMBRE" Caption="Clasificador de Gasto" SortOrder="Ascending"
                    VisibleIndex="2" HeaderStyle-Wrap="True" Width="70%" 
                    HeaderStyle-HorizontalAlign="Center"  >
                    <Settings AutoFilterCondition="Contains"></Settings>
                    <PropertiesTextEdit Width="120%" Style-Font-Size="XX-Small"></PropertiesTextEdit> 
                    <HeaderStyle HorizontalAlign="Center" Wrap="True" ></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>             
                <dxwgv:GridViewDataTextColumn FieldName="PIM" Caption="PIM" VisibleIndex="3" Width="100%"  ShowInCustomizationForm="true"   HeaderStyle-HorizontalAlign="Center"  Settings-AllowSort="False" Settings-AllowDragDrop="False"  CellStyle-Font-Bold="true"> 
                    <PropertiesTextEdit DisplayFormatString="c" Width="50%" Style-Font-Size="XX-Small"></PropertiesTextEdit> 
                </dxwgv:GridViewDataTextColumn> 
                <dxwgv:GridViewDataTextColumn FieldName="TOTAL"  Caption="TOTAL PROGRAMACION" VisibleIndex="4" UnboundType="Decimal" HeaderStyle-HorizontalAlign="Center"  Settings-AllowSort="False" Settings-AllowDragDrop="False" HeaderStyle-Wrap="True" CellStyle-Font-Bold="true">
                    <FooterCellStyle ForeColor="Brown" />
                    <PropertiesTextEdit DisplayFormatString="c" />
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="SALDOPROGRAMACION"  Caption="SALDO" VisibleIndex="4" UnboundType="Decimal" HeaderStyle-HorizontalAlign="Center"  Settings-AllowSort="False" Settings-AllowDragDrop="False" HeaderStyle-Wrap="True"  CellStyle-Font-Bold="true">
                    <FooterCellStyle ForeColor="Brown" />
                    <PropertiesTextEdit DisplayFormatString="c" />
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="PROGRAMACION_01" Caption="ENERO" VisibleIndex="5" Width="100%"  ShowInCustomizationForm="true"   HeaderStyle-HorizontalAlign="Center"  Settings-AllowSort="False" Settings-AllowDragDrop="False"> 
                    <PropertiesTextEdit DisplayFormatString="c" Width="50%" ></PropertiesTextEdit> 
                </dxwgv:GridViewDataTextColumn> 
                <dxwgv:GridViewDataTextColumn FieldName="PROGRAMACION_02" Caption="FEBRERO" VisibleIndex="6" Width="100%"  ShowInCustomizationForm="true"   HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False"> 
                    <PropertiesTextEdit DisplayFormatString="c" Width="50%"></PropertiesTextEdit> 
                </dxwgv:GridViewDataTextColumn> 
                <dxwgv:GridViewDataTextColumn FieldName="PROGRAMACION_03" Caption="MARZO" VisibleIndex="7" Width="100%"  ShowInCustomizationForm="true"   HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False"> 
                    <PropertiesTextEdit DisplayFormatString="c" Width="50%"></PropertiesTextEdit> 
                </dxwgv:GridViewDataTextColumn> 
                <dxwgv:GridViewDataTextColumn FieldName="PROGRAMACION_04" Caption="ABRIL" VisibleIndex="8" Width="100%"  ShowInCustomizationForm="true"   HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False"> 
                    <PropertiesTextEdit DisplayFormatString="c" Width="50%"></PropertiesTextEdit> 
                </dxwgv:GridViewDataTextColumn> 
                <dxwgv:GridViewDataTextColumn FieldName="PROGRAMACION_05" Caption="MAYO" VisibleIndex="9" Width="100%"  ShowInCustomizationForm="true"   HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False"> 
                    <PropertiesTextEdit DisplayFormatString="c" Width="50%"></PropertiesTextEdit> 
                </dxwgv:GridViewDataTextColumn> 
                <dxwgv:GridViewDataTextColumn FieldName="PROGRAMACION_06" Caption="JUNIO" VisibleIndex="10" Width="100%"  ShowInCustomizationForm="true"   HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False"> 
                    <PropertiesTextEdit DisplayFormatString="c" Width="50%"></PropertiesTextEdit> 
                </dxwgv:GridViewDataTextColumn> 
                <dxwgv:GridViewDataTextColumn FieldName="PROGRAMACION_07" Caption="JULIO" VisibleIndex="11" Width="100%"  ShowInCustomizationForm="true"   HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False"> 
                    <PropertiesTextEdit DisplayFormatString="c" Width="50%"></PropertiesTextEdit> 
                </dxwgv:GridViewDataTextColumn> 
                <dxwgv:GridViewDataTextColumn FieldName="PROGRAMACION_08" Caption="AGOSTO" VisibleIndex="12" Width="100%"  ShowInCustomizationForm="true"   HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False"> 
                    <PropertiesTextEdit DisplayFormatString="c" Width="50%"></PropertiesTextEdit> 
                </dxwgv:GridViewDataTextColumn> 
                <dxwgv:GridViewDataTextColumn FieldName="PROGRAMACION_09" Caption="SETIEMBRE" VisibleIndex="13" Width="100%"  ShowInCustomizationForm="true"   HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False"> 
                    <PropertiesTextEdit DisplayFormatString="c" Width="50%"></PropertiesTextEdit> 
                </dxwgv:GridViewDataTextColumn> 
                <dxwgv:GridViewDataTextColumn FieldName="PROGRAMACION_10" Caption="OCTUBRE" VisibleIndex="14" Width="100%"  ShowInCustomizationForm="true"   HeaderStyle-HorizontalAlign="Center"  Settings-AllowSort="False" Settings-AllowDragDrop="False"> 
                    <PropertiesTextEdit DisplayFormatString="c" Width="50%"></PropertiesTextEdit> 
                </dxwgv:GridViewDataTextColumn> 
                <dxwgv:GridViewDataTextColumn FieldName="PROGRAMACION_11" Caption="NOVIEMBRE" VisibleIndex="15" Width="100%"  ShowInCustomizationForm="true"   HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False"> 
                    <PropertiesTextEdit DisplayFormatString="c" Width="50%"></PropertiesTextEdit> 
                </dxwgv:GridViewDataTextColumn> 
                <dxwgv:GridViewDataTextColumn FieldName="PROGRAMACION_12" Caption="DICIEMBRE" VisibleIndex="16" Width="100%"  ShowInCustomizationForm="true"   HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False"> 
                    <PropertiesTextEdit DisplayFormatString="c" Width="50%"></PropertiesTextEdit> 
                </dxwgv:GridViewDataTextColumn> 

               </Columns> 
                <GroupSummary>
                <dxwgv:ASPxSummaryItem FieldName="PIM" SummaryType="Sum" DisplayFormat="c" ShowInGroupFooterColumn="PIM"/>  
               <dxwgv:ASPxSummaryItem FieldName="PROGRAMACION_01" SummaryType="Sum" DisplayFormat="c" ShowInGroupFooterColumn="PROGRAMACION_01"/>  
               <dxwgv:ASPxSummaryItem FieldName="PROGRAMACION_02" SummaryType="Sum" DisplayFormat="c" ShowInGroupFooterColumn="PROGRAMACION_02"/>  
               <dxwgv:ASPxSummaryItem FieldName="PROGRAMACION_03" SummaryType="Sum" DisplayFormat="c" ShowInGroupFooterColumn="PROGRAMACION_03"/>  
               <dxwgv:ASPxSummaryItem FieldName="PROGRAMACION_04" SummaryType="Sum" DisplayFormat="c" ShowInGroupFooterColumn="PROGRAMACION_04"/>  
               <dxwgv:ASPxSummaryItem FieldName="PROGRAMACION_05" SummaryType="Sum" DisplayFormat="c" ShowInGroupFooterColumn="PROGRAMACION_05"/>  
               <dxwgv:ASPxSummaryItem FieldName="PROGRAMACION_06" SummaryType="Sum" DisplayFormat="c" ShowInGroupFooterColumn="PROGRAMACION_06"/>  
               <dxwgv:ASPxSummaryItem FieldName="PROGRAMACION_07" SummaryType="Sum" DisplayFormat="c" ShowInGroupFooterColumn="PROGRAMACION_07"/>  
               <dxwgv:ASPxSummaryItem FieldName="PROGRAMACION_08" SummaryType="Sum" DisplayFormat="c" ShowInGroupFooterColumn="PROGRAMACION_08"/>  
               <dxwgv:ASPxSummaryItem FieldName="PROGRAMACION_09" SummaryType="Sum" DisplayFormat="c" ShowInGroupFooterColumn="PROGRAMACION_09"/>  
               <dxwgv:ASPxSummaryItem FieldName="PROGRAMACION_10" SummaryType="Sum" DisplayFormat="c" ShowInGroupFooterColumn="PROGRAMACION_10"/>  
               <dxwgv:ASPxSummaryItem FieldName="PROGRAMACION_11" SummaryType="Sum" DisplayFormat="c" ShowInGroupFooterColumn="PROGRAMACION_11"/>  
               <dxwgv:ASPxSummaryItem FieldName="PROGRAMACION_12" SummaryType="Sum" DisplayFormat="c" ShowInGroupFooterColumn="PROGRAMACION_12"/>  
               <dxwgv:ASPxSummaryItem FieldName="TOTAL" SummaryType="Sum" DisplayFormat="c" ShowInGroupFooterColumn="TOTAL"/>
               <dxwgv:ASPxSummaryItem FieldName="SALDOPROGRAMACION" SummaryType="Sum" DisplayFormat="c" ShowInGroupFooterColumn="SALDOPROGRAMACION"/>                 
                </GroupSummary>            
                <TotalSummary>
                <dxwgv:ASPxSummaryItem FieldName="PIM" SummaryType="Sum" DisplayFormat="c"/>
                <dxwgv:ASPxSummaryItem FieldName="PROGRAMACION_01" SummaryType="Sum" DisplayFormat="c"/>
                <dxwgv:ASPxSummaryItem FieldName="PROGRAMACION_02" SummaryType="Sum" DisplayFormat="c"/>
                <dxwgv:ASPxSummaryItem FieldName="PROGRAMACION_03" SummaryType="Sum" DisplayFormat="c"/>
                <dxwgv:ASPxSummaryItem FieldName="PROGRAMACION_04" SummaryType="Sum" DisplayFormat="c"/>
                <dxwgv:ASPxSummaryItem FieldName="PROGRAMACION_05" SummaryType="Sum" DisplayFormat="c"/>
                <dxwgv:ASPxSummaryItem FieldName="PROGRAMACION_06" SummaryType="Sum" DisplayFormat="c"/>
                <dxwgv:ASPxSummaryItem FieldName="PROGRAMACION_07" SummaryType="Sum" DisplayFormat="c"/>
                <dxwgv:ASPxSummaryItem FieldName="PROGRAMACION_08" SummaryType="Sum" DisplayFormat="c"/>
                <dxwgv:ASPxSummaryItem FieldName="PROGRAMACION_09" SummaryType="Sum" DisplayFormat="c"/>
                <dxwgv:ASPxSummaryItem FieldName="PROGRAMACION_10" SummaryType="Sum" DisplayFormat="c"/>
                <dxwgv:ASPxSummaryItem FieldName="PROGRAMACION_11" SummaryType="Sum" DisplayFormat="c"/>
                <dxwgv:ASPxSummaryItem FieldName="PROGRAMACION_12" SummaryType="Sum" DisplayFormat="c"/>
                <dxwgv:ASPxSummaryItem FieldName="TOTAL" SummaryType="Sum" DisplayFormat="c"/>
                <dxwgv:ASPxSummaryItem FieldName="SALDOPROGRAMACION" SummaryType="Sum" DisplayFormat="c"/>
                </TotalSummary>
            <SettingsPager Mode="ShowAllRecords"></SettingsPager>
            <Settings  ShowFooter="true" ShowGroupFooter="VisibleAlways" ShowTitlePanel="true" VerticalScrollableHeight="600"  ShowGroupPanel="true"   />    
            <SettingsText Title="EJECUCION DEL GASTO : EJECUCION VS MONTO DE INVERSION"  />
            <SettingsEditing Mode="PopupEditForm" EditFormColumnCount="3" PopupEditFormWidth="800px" PopupEditFormVerticalAlign="WindowCenter" />
        </dxwgv:ASPxGridView>
        <dxwgv:ASPxGridViewExporter ID="gridExport" runat="server" GridViewID="ASPxGridviewSeguimientoSNIP"></dxwgv:ASPxGridViewExporter>

    </td></tr>
    </table> 
  </div>    
</asp:Content>
