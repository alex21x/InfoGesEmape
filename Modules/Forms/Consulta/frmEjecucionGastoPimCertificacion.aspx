<%@ Page Language="C#" MasterPageFile="~/Modules/MasterPage.Master" AutoEventWireup="true" 
    CodeBehind="frmEjecucionGastoPimCertificacion.aspx.cs" Inherits="InfoGesRegional.Modules.Forms.Consulta.frmEjecucionGastoPimCertificacion" 
    Title="InfoGesRegional" %>

<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dxpc" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView.Export" tagprefix="dxwgv" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            height: 28px;
        }
    </style>
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
            <dxe:ASPxComboBox ID="CboEjecutora" runat="server" style="vertical-align: middle" AutoPostBack="true"  Font-Size="XX-Small"  ForeColor="Green"
            SelectedIndex="0" ValueType="System.String" Width="800px" OnSelectedIndexChanged="OnSelectedindexChangedEjecutora" >
            </dxe:ASPxComboBox>
        </td>        
        </tr>
        <tr><td align="right"><asp:Label ID="Label2" runat="server" Text="Año :" CssClass="sys-font-body-Text" Width="100%"></asp:Label></td>
            <td align="left">
            <dxe:ASPxComboBox ID="CboPeriodo" runat="server" style="vertical-align: middle" AutoPostBack="true" Font-Size="XX-Small"  ForeColor="Green"
            SelectedIndex="0" ValueType="System.String" Width="800px" OnSelectedIndexChanged="OnSelectedindexChangedPeriodo"  OnValueChanged="OnSelectedindexChangedPeriodo" >
            </dxe:ASPxComboBox>
        </td>    
        </tr>
<%--        <tr><td align="right"><asp:Label ID="Label4" runat="server" Text="Centro de Costo :" CssClass="sys-font-body-Text" Width="100%"></asp:Label></td>
        <td align="left">        
            <dxe:ASPxComboBox ID="CboCentroCosto" runat="server" style="vertical-align: middle" AutoPostBack="true"  Font-Size="XX-Small"  ForeColor="Green"
            SelectedIndex="0" ValueType="System.String" Width="800px"  OnSelectedIndexChanged="OnSelectedindexChangedCentroCosto">
            </dxe:ASPxComboBox>
        </td>        
        </tr>--%>
        <tr><td align="right"><asp:Label ID="Label1" runat="server" Text="Cadena Funcional :" CssClass="sys-font-body-Text" Width="100%"></asp:Label></td>
        <td align="left">        
            <dxe:ASPxComboBox ID="CboCadFuncional" runat="server" style="vertical-align: middle" AutoPostBack="true"  Font-Size="XX-Small"  ForeColor="Green"
            SelectedIndex="0" ValueType="System.String" Width="800px"  OnSelectedIndexChanged="OnSelectedindexChangedSec_Func">
            </dxe:ASPxComboBox>
        </td>        
        </tr>
        <tr><td align="right"><asp:Label ID="Label5" runat="server" Text="Tipo de Saldos" CssClass="sys-font-body-Text" Width="100%"></asp:Label></td>
        <td  align="left"><dxe:ASPxComboBox ID="CboSaldoNegativos" runat="server" style="vertical-align: middle" AutoPostBack="true"  Font-Size="XX-Small"  ForeColor="Green"
            SelectedIndex="0" ValueType="System.String" Width="800px"  OnSelectedIndexChanged="OnSelectedindexChangedSaldoNegativos">
            <Items>
                <dxe:ListEditItem Text="TODOS" Value="0" />
                <dxe:ListEditItem Text="SALDO NEGATIVOS" Value="1" />
                <dxe:ListEditItem Text="SALDO POSITIVOS" Value="2" />
            </Items>
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
            UseSubmitBehavior="false" OnClick="OnClikVisualizacionMeses"/>

        </td></tr></table>
        </td></tr>
            <tr><td>
            <dxwgv:ASPxGridView ID="ASPxGridviewConsultaSnipFinanciero"  runat="server" Width="100%" 
            ClientInstanceName="ASPxGridviewConsultaSnipFinanciero" OnLoad="LoadProyectoSnipSiaf" OnHtmlDataCellPrepared="grid_HtmlDataCellPrepared"
            AutoGenerateColumns="false"  Font-Size="XX-Small" KeyFieldName="IDSECUENCIA">
            <Columns>
                <dxwgv:GridViewDataTextColumn FieldName="SEC_FUNC_NOMBRE" Caption="Meta" SortOrder="Ascending" Visible="false"
                    VisibleIndex="1" HeaderStyle-Wrap="True" Width="30px"  Settings-AllowSort="False" Settings-AllowDragDrop="False"
                    HeaderStyle-HorizontalAlign="Center"  >
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                    <HeaderStyle HorizontalAlign="Center" Wrap="True" ></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>       
                <dxwgv:GridViewDataTextColumn FieldName="FUENTE_FINANC_NOMBRE" Caption="Fuen" SortOrder="Ascending" Visible="false"
                    VisibleIndex="1" HeaderStyle-Wrap="True" Width="30px"  Settings-AllowSort="False" Settings-AllowDragDrop="False"
                    HeaderStyle-HorizontalAlign="Center"  >
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                    <HeaderStyle HorizontalAlign="Center" Wrap="True" ></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>                                                              
                <dxwgv:GridViewDataTextColumn FieldName="CLASIFICADOR" Caption="Especifica de Gasto" SortOrder="Ascending"
                    VisibleIndex="1" HeaderStyle-Wrap="True" Width="350px"  Settings-AllowSort="False" Settings-AllowDragDrop="False"
                    HeaderStyle-HorizontalAlign="Center"  >
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                    <HeaderStyle HorizontalAlign="Center" Wrap="True" ></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="PIM" Caption="Pim" VisibleIndex="2" HeaderStyle-Wrap="True" Width="80px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False" >
                    <PropertiesTextEdit DisplayFormatString="c" ></PropertiesTextEdit>
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="COMPROMETIDO_ANUAL" Caption="Certificado" VisibleIndex="3" HeaderStyle-Wrap="True" Width="80px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False" >
                    <PropertiesTextEdit DisplayFormatString="c" ></PropertiesTextEdit>
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="SALDO_PIM_COMPROMETIDO" Caption="Saldo Certificado" VisibleIndex="4" HeaderStyle-Wrap="True" Width="120px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False" HeaderStyle-Font-Bold="true"> 
                    <PropertiesTextEdit DisplayFormatString="c" Style-Font-Bold="true" ><Style Font-Bold="True"></Style></PropertiesTextEdit>
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                    <CellStyle BackColor="LightYellow" Font-Bold="true"></CellStyle>
                <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="ENERO" Caption="enero" VisibleIndex="5" HeaderStyle-Wrap="True" Width="80px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False" Visible="false" >
                    <PropertiesTextEdit DisplayFormatString="c" ></PropertiesTextEdit>
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="FEBRERO" Caption="Febrero" VisibleIndex="6" HeaderStyle-Wrap="True" Width="80px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False"  Visible="false">
                    <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="MARZO" Caption="Marzo" VisibleIndex="7" HeaderStyle-Wrap="True" Width="80px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False"  Visible="false">
                    <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="ABRIL" Caption="Abril" VisibleIndex="8" HeaderStyle-Wrap="True" Width="80px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False"  Visible="false">
                    <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="MAYO" Caption="Mayo" VisibleIndex="9" HeaderStyle-Wrap="True" Width="80px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False"  Visible="false">
                    <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="JUNIO" Caption="Junio" VisibleIndex="10" HeaderStyle-Wrap="True" Width="80px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False"  Visible="false">
                    <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="JULIO" Caption="Julio" VisibleIndex="11" HeaderStyle-Wrap="True" Width="80px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False"  Visible="false">
                    <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="AGOSTO" Caption="Agosto" VisibleIndex="12" HeaderStyle-Wrap="True" Width="80px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False"  Visible="false">
                    <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="SETIEMBRE" Caption="Setiembre" VisibleIndex="13" HeaderStyle-Wrap="True" Width="80px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False"  Visible="false">
                    <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="OCTUBRE" Caption="Octubre" VisibleIndex="14" HeaderStyle-Wrap="True" Width="80px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False"  Visible="false">
                    <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="NOVIEMBRE" Caption="Noviembre" VisibleIndex="15" HeaderStyle-Wrap="True" Width="80px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False"  Visible="false">
                    <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="DICIEMBRE" Caption="Diciembre" VisibleIndex="16" HeaderStyle-Wrap="True" Width="80px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False"  Visible="false">
                    <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="EJECUCION" Caption="Ejecución" VisibleIndex="17" HeaderStyle-Wrap="True" Width="80px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False" >
                    <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="SALDO_EJECUCION" Caption="Saldo Ejecución" VisibleIndex="18" HeaderStyle-Wrap="True" Width="120px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False"  HeaderStyle-Font-Bold="true">
                    <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                    <CellStyle BackColor="LightYellow" Font-Bold="true"></CellStyle>
                <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>            
               </Columns>    
            <SettingsLoadingPanel Mode="ShowOnStatusBar"></SettingsLoadingPanel>
            <SettingsPager Mode="ShowAllRecords"></SettingsPager>
            <Settings  ShowFooter="true" ShowGroupFooter="VisibleAlways" ShowTitlePanel="true" VerticalScrollableHeight="600" />    
            <SettingsText Title="EJECUCION DEL GASTO : PIM VS CERTIFICADO, PIM VS COMPROMISO MENSUAL" />
            <SettingsLoadingPanel Mode="ShowOnStatusBar" />
                <Images>
                    <CollapsedButton Url="~/Images/radio_normal.png" />
                    <ExpandedButton Url="~/Images/radio_select.png" />
                </Images>
                <TotalSummary>
                <dxwgv:ASPxSummaryItem FieldName="EJECUCION" SummaryType="Sum" DisplayFormat="c"/>
                <dxwgv:ASPxSummaryItem FieldName="PIM" SummaryType="Sum" DisplayFormat="c"/>
                <dxwgv:ASPxSummaryItem FieldName="COMPROMETIDO_ANUAL" SummaryType="Sum" DisplayFormat="c"/>
                <dxwgv:ASPxSummaryItem FieldName="SALDO_PIM_COMPROMETIDO" SummaryType="Sum" DisplayFormat="c"/>
                <dxwgv:ASPxSummaryItem FieldName="SALDO_EJECUCION" SummaryType="Sum" DisplayFormat="c"/>
                </TotalSummary>
                

            <GroupSummary>
                <dxwgv:ASPxSummaryItem FieldName="PIM" SummaryType="Sum" DisplayFormat="c" ShowInGroupFooterColumn="PIM"/>
                <dxwgv:ASPxSummaryItem FieldName="COMPROMETIDO_ANUAL" SummaryType="Sum" DisplayFormat="c" ShowInGroupFooterColumn="COMPROMETIDO_ANUAL"/>
                <dxwgv:ASPxSummaryItem FieldName="SALDO_PIM_COMPROMETIDO" SummaryType="Sum" DisplayFormat="c" ShowInGroupFooterColumn="SALDO_PIM_COMPROMETIDO"/>
                <dxwgv:ASPxSummaryItem FieldName="ENERO" SummaryType="Sum" DisplayFormat="c" ShowInGroupFooterColumn="ENERO"/>
                <dxwgv:ASPxSummaryItem FieldName="FEBRERO" SummaryType="Sum" DisplayFormat="c"  ShowInGroupFooterColumn="FEBRERO"/>
                <dxwgv:ASPxSummaryItem FieldName="MARZO" SummaryType="Sum" DisplayFormat="c"  ShowInGroupFooterColumn="MARZO"/>
                <dxwgv:ASPxSummaryItem FieldName="ABRIL" SummaryType="Sum" DisplayFormat="c"  ShowInGroupFooterColumn="ABRIL"/>
                <dxwgv:ASPxSummaryItem FieldName="MAYO" SummaryType="Sum" DisplayFormat="c"  ShowInGroupFooterColumn="MAYO"/>
                <dxwgv:ASPxSummaryItem FieldName="JUNIO" SummaryType="Sum" DisplayFormat="c"  ShowInGroupFooterColumn="JUNIO"/>
                <dxwgv:ASPxSummaryItem FieldName="JULIO" SummaryType="Sum" DisplayFormat="c"  ShowInGroupFooterColumn="JULIO"/>
                <dxwgv:ASPxSummaryItem FieldName="AGOSTO" SummaryType="Sum" DisplayFormat="c"  ShowInGroupFooterColumn="AGOSTO"/>
                <dxwgv:ASPxSummaryItem FieldName="SETIEMBRE" SummaryType="Sum" DisplayFormat="c"  ShowInGroupFooterColumn="SETIEMBRE"/>
                <dxwgv:ASPxSummaryItem FieldName="OCTUBRE" SummaryType="Sum" DisplayFormat="c"  ShowInGroupFooterColumn="OCTUBRE"/>
                <dxwgv:ASPxSummaryItem FieldName="NOVIEMBRE" SummaryType="Sum" DisplayFormat="c"  ShowInGroupFooterColumn="NOVIEMBRE"/>
                <dxwgv:ASPxSummaryItem FieldName="DICIEMBRE" SummaryType="Sum" DisplayFormat="c"  ShowInGroupFooterColumn="DICIEMBRE"/>
                <dxwgv:ASPxSummaryItem FieldName="EJECUCION" SummaryType="Sum" DisplayFormat="c"  ShowInGroupFooterColumn="EJECUCION"/>
                <dxwgv:ASPxSummaryItem FieldName="SALDO_EJECUCION" SummaryType="Sum" DisplayFormat="c"  ShowInGroupFooterColumn="SALDO_EJECUCION"/>
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
