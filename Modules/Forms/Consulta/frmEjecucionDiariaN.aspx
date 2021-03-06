<%@ Page Language="C#" MasterPageFile="~/Modules/MasterPage.Master" AutoEventWireup="true" 
    CodeBehind="frmEjecucionDiariaN.aspx.cs" Inherits="InfoGesRegional.Modules.Forms.Consulta.frmEjecucionDiariaN" 
    Title="InfoGesConsultas" %>


<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dxpc" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTabControl" tagprefix="dxtc" %>
<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dxwpg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script  language="javascript" type="text/javascript">
        function OnMoreInfoClick(contentUrl) {
            clientPopupControl.SetContentUrl(contentUrl);
            clientPopupControl.Show();
        }
    </script>
    <div id="principal" >
   <table cellpadding="0" cellspacing="0" >
        <tr>
        <td>
        <table>
        <tr>
        <td>
        <dxtc:ASPxTabControl ID="ASPxTabControleJEjecutora" runat="server" AutoPostBack="True" 
                DataSourceID="XmlDataSource2"  
                OnActiveTabChanged="ASPxPageControl1_ActiveTabChanged1"
                ActiveTabStyle-Font-Size="Large" TabStyle-Wrap="True" Width="248px" 
                CssFilePath="~/App_Themes/Glass/Web/styles.css" 
                CssPostfix="Glass" >
        <Paddings Padding="0" />

        <ActiveTabStyle Font-Size="Large" Wrap="True"></ActiveTabStyle>

        <TabStyle Wrap="True"></TabStyle>
            </dxtc:ASPxTabControl>
        <asp:XmlDataSource ID="XmlDataSource2" runat="server" DataFile=""  XPath="//ejecutora" EnableCaching="false"></asp:XmlDataSource>
        </td>
        </tr>
        <tr>
        <td align="right" class="style18">
        <dxtc:ASPxTabControl ID="tcDemos" runat="server" DataSourceID="XmlDataSource1"  AutoPostBack="true" 
                OnActiveTabChanged="ASPxPageControl1_ActiveTabChanged" 
                ActiveTabStyle-Font-Size="XX-Large" TabIndex="0" 
                CssFilePath="~/App_Themes/Glass/Web/styles.css" 
                CssPostfix="Glass" EnableDefaultAppearance="False" RightToLeft="True" 
                 Width="1200px" EnableTabScrolling="true" >
        <Paddings Padding="0" />
            </dxtc:ASPxTabControl>
        <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile=""  XPath="//product"  ></asp:XmlDataSource>
        </td>
        </tr>
        </table>
        </td>
        </tr>
        <tr>
        <td>
            <a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a><a target="_search"  href='http://apps2.mef.gob.pe/siafcut/login.jsp'>Saldo Banco</a>
        </td>
        <tr>
        <td>
        <table>
        <tr>
        <td  valign="top">
        <dxwgv:ASPxGridView ID="ASPxGridviewFechaEjecucion"  runat="server"
                KeyFieldName="FECHA_DOC" AutoPostBack="true" OnLoad="Load_Fecha_Ejecutora"  
            ClientInstanceName="ASPxGridviewFechaEjecucion" 
                AutoGenerateColumns="False" Width="100%">
            <SettingsBehavior AllowFocusedRow="True" AllowClientEventsOnLoad="False"/>
            <ClientSideEvents FocusedRowChanged="UpdateDetailGrid" />
            <Settings ShowFooter="True" ShowTitlePanel="true" 
                    ShowHeaderFilterButton="true" ShowGroupFooter="VisibleAlways"
                    ShowVerticalScrollBar="True" VerticalScrollableHeight="425" />

            <SettingsBehavior AllowFocusedRow="True"></SettingsBehavior>
            <SettingsPager Mode="ShowAllRecords"></SettingsPager>
            <Settings VerticalScrollBarMode="Visible" />
            <SettingsText Title="LISTADO DE GASTO DIARIO" />
             <Columns>
                <dxwgv:GridViewDataTextColumn FieldName="FECHA_DOC" Caption="FECHA" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"  Width="80px">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    <DataItemTemplate>
                        <dx:ASPxHyperLink ID="hyperLink1" runat="server" OnInit="hyperLink_InitDetailCaja" Font-Size="XX-Small" >
                        </dx:ASPxHyperLink>
                    </DataItemTemplate>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewBandColumn Caption="EJECUCION" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center"   VisibleIndex="2" >
                <Columns>
                    <dxwgv:GridViewDataTextColumn FieldName="EJECUCION_G" Caption="DEL" VisibleIndex="2" HeaderStyle-HorizontalAlign="Center" Width="140px">
                    <PropertiesTextEdit DisplayFormatString="c" ></PropertiesTextEdit><Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewDataTextColumn FieldName="EJECUCION_GA" Caption="AL" VisibleIndex="3"  HeaderStyle-HorizontalAlign="Center"  HeaderStyle-Wrap="True" Width="140px">
                        <PropertiesTextEdit DisplayFormatString="c" ></PropertiesTextEdit><Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </dxwgv:GridViewDataTextColumn>
                </Columns>
                </dxwgv:GridViewBandColumn>
                <dxwgv:GridViewBandColumn  Caption="RECAUDADO" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center"   VisibleIndex="3" >
                <Columns>
                    <dxwgv:GridViewDataTextColumn FieldName="EJECUCION_R" Caption="DEL" VisibleIndex="3" HeaderStyle-HorizontalAlign="Center" Width="140px">
                    <PropertiesTextEdit DisplayFormatString="c" ></PropertiesTextEdit><Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </dxwgv:GridViewDataTextColumn>
                    <dxwgv:GridViewDataTextColumn FieldName="EJECUCION_RA" Caption="AL " VisibleIndex="3"  HeaderStyle-HorizontalAlign="Center"  HeaderStyle-Wrap="True" Width="140px">
                        <PropertiesTextEdit DisplayFormatString="c" ></PropertiesTextEdit><Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </dxwgv:GridViewDataTextColumn>
                </Columns>
                 </dxwgv:GridViewBandColumn>
            </Columns> 
        <Styles CssFilePath="~/App_Themes/Glass/GridView/styles.css" CssPostfix="Glass"></Styles>
        <SettingsPager Mode="ShowPager" PageSize="60"></SettingsPager>
        </dxwgv:ASPxGridView>
        <dxpc:ASPxPopupControl ID="popupControl" runat="server" 
                    ClientInstanceName="clientPopupControl"  CloseAction="CloseButton" 
                    Height="620px" Modal="True" Width="100%" PopupHorizontalAlign="RightSides"
                    PopupVerticalAlign="Middle" HeaderText="Expediente SIAF" ScrollBars="Auto">
        <ContentCollection>
            <dxpc:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
            </dxpc:PopupControlContentControl>
        </ContentCollection>                    
        </dxpc:ASPxPopupControl>
        </td>
         <td valign="top"">
            <dxwpg:ASPxPivotGrid id="ASPxPivotGridEjecucionAcumulada" runat="server"  
                onLoad="LoadEjecuci?nAcumulada"  CustomizationFieldsLeft="600" Font-Size="X-Small"
                CustomizationFieldsTop="400"  ClientInstanceName="pivotGrid" Width="500%" 
                ClientIDMode="AutoID" EnableCallbackAnimation="True" Height="550px">
             <Fields>
                <dxwpg:PivotGridField Area="RowArea" AreaIndex="0" FieldName="FTE_FTO_NOMBRE" 
                     Caption="FTE. FTO." ID="IdFteFto"
                     HeaderStyle-BackgroundImage-HorizontalPosition="center" 
                     Options-AllowSort="False" HeaderStyle-Wrap="True">
                <HeaderStyle  BackgroundImage-HorizontalPosition="center">
                    <BackgroundImage HorizontalPosition="center" />
                    </HeaderStyle>
                </dxwpg:PivotGridField>
               <dxwpg:PivotGridField Area="ColumnArea" AreaIndex="0" FieldName="DESCRIPCION" 
                     Caption="MES" ID="IdMes"  
                     HeaderStyle-BackgroundImage-HorizontalPosition="center" 
                     Options-AllowSort="Default" KPIGraphic="ServerDefined" 
                     SortOrder="Descending">
                <HeaderStyle BackgroundImage-HorizontalPosition="center" Wrap="True" >
                    <BackgroundImage HorizontalPosition="center" />
                    </HeaderStyle>
                </dxwpg:PivotGridField>   
                <dxwpg:PivotGridField ID="IdEjecucionRArea" Area="DataArea" AreaIndex="0" 
                        FieldName="EJECUCION_R1" Caption="RECAUDADO DEL" > 
                </dxwpg:PivotGridField>
                <dxwpg:PivotGridField ID="IdEjecucionGArea" Area="DataArea" AreaIndex="1"
                        FieldName="EJECUCION_G1" Caption="GIRADO DEL" 
                     ValueFormat-FormatType="Numeric" ValueFormat-FormatString="C">
                </dxwpg:PivotGridField>
                <dxwpg:PivotGridField ID="IdEjecucionRTArea" Area="DataArea" AreaIndex="2"
                        FieldName="EJECUCION_RT" Caption="RECAUDADO AL" 
                     ValueFormat-FormatType="Numeric" ValueFormat-FormatString="C">
                </dxwpg:PivotGridField>
                <dxwpg:PivotGridField ID="IdEjecucionGTArea" Area="DataArea" AreaIndex="3"
                        FieldName="EJECUCION_GT" Caption="GIRADO AL" 
                     ValueFormat-FormatType="Numeric" ValueFormat-FormatString="C">
                </dxwpg:PivotGridField>
            </Fields>
            <OptionsPager RowsPerPage="20"></OptionsPager >
            <OptionsView   ShowRowGrandTotals="False"  DataHeadersDisplayMode="Popup" DataHeadersPopupMinCount="3" ShowColumnTotals="False" ShowColumnGrandTotals="False"
                        ShowCustomTotalsForSingleValues="false" ShowFilterHeaders="False" 
                    ShowHorizontalScrollBar="True" />
               
            <Styles CssFilePath="~/App_Themes/Glass/PivotGrid/styles.css" 
                CssPostfix="Glass">
            </Styles>
            </dxwpg:ASPxPivotGrid>
        </td>
        </tr>
        </table>
        </td>
        </tr>
    </table> 
  </div>    
</asp:Content>
