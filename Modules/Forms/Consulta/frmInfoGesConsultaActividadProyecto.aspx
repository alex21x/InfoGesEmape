<%@ Page Language="C#" MasterPageFile="~/Modules/MasterPage.Master" AutoEventWireup="true" 
    CodeBehind="frmInfoGesConsultaActividadProyecto.aspx.cs" Inherits="InfoGesRegional.Modules.Forms.Consulta.frmInfoGesConsultaActividadProyecto" 
    Title="InfoGesConsultas" %>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073"
    Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dxwtl" %>


<%@ Register assembly="DevExpress.Web.ASPxGridView.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>

<%@ Register assembly="DevExpress.Web.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073" namespace="DevExpress.Web.ASPxTabControl" tagprefix="dxtc" %>
<%@ Register assembly="DevExpress.Web.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073" namespace="DevExpress.Web.ASPxClasses" tagprefix="dxw" %>

<%@ Register Assembly="DevExpress.Web.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073" Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.XtraCharts.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073" Namespace="DevExpress.XtraCharts" TagPrefix="cc1" %>
<%@ Register Assembly="DevExpress.XtraCharts.v8.3.Web, Version=8.3.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073" Namespace="DevExpress.XtraCharts.Web" TagPrefix="dxchartsui" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v8.3.Export , Version=8.3.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073" Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dxwgv" %>

<%@ Register assembly="DevExpress.Web.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dxpc" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script language="javascript" type="text/javascript">
       // <![CDATA[
       function UpdateCustomizationWindowValueValorizacion() {
           var element = document.getElementById("btnCustWindow1");
           if (element == null) return;
           element.value = (ASPxGridviewConsultaAvanceProyecto.IsCustomizationWindowVisible() ? "Ocultar" : "Mostrar") + " personalización de la ventana";
       }
       function ShowHideCustomizationWindowValorizacion() {
           if (ASPxGridviewConsultaAvanceProyecto.IsCustomizationWindowVisible())
               ASPxGridviewConsultaAvanceProyecto.HideCustomizationWindow();
           else ASPxGridviewConsultaAvanceProyecto.ShowCustomizationWindow();
           UpdateCustomizationWindowValueValorizacion();
       } 
           
    function OnMoreInfoClick(contentUrl) {
        clientPopupControl.SetContentUrl(contentUrl);
        clientPopupControl.Show();
    }
              
    </script>       

  <div id="principal" >
       <dxtc:ASPxPageControl ID="ASPxPageControl1" runat="server" ActiveTabIndex="0" 
            CssFilePath="~/App_Themes/Glass/ASPxPageControl.skin"          
              ImageFolder="~/App_Themes/Aqua/{0}/" 
                TabSpacing="4px" Width="100%"  >
            <ContentStyle VerticalAlign="Top">
                <Border BorderColor="#AECAF0" BorderStyle="Solid" BorderWidth="4px" />
            </ContentStyle>
            <ActiveTabStyle Font-Bold="True" Font-Size="Smaller">
            </ActiveTabStyle>                        
            <TabPages >
                <dxtc:TabPage Text="Ejecución">
                    <ContentCollection>
                    <dxw:ContentControl ID="ContentControl1" runat="server">
                    <table width="100%"  class="sys-gridpanel-bgcolor">
                        <tr>
                            <td align="center" colspan="2" valign="top">
                                    <dxwgv:ASPxGridView ID="ASPxGridviewConsultaSnipFinanciero" runat="server" 
                                        AutoGenerateColumns="False" 
                                        ClientInstanceName="ASPxGridviewConsultaSnipFinanciero" Font-Size="X-Small" 
                                        OnLoad="LoadActProySiaf" Width="100%">
                                        <TotalSummary>
                                            <dxwgv:ASPxSummaryItem FieldName="ACT_PROY_NOMBRE" SummaryType="Count" />
                                            <dxwgv:ASPxSummaryItem DisplayFormat="c" FieldName="TOTAL_EJECUTADO" 
                                                SummaryType="Sum" />
                                        </TotalSummary>
                                        <GroupSummary>
                                            <dxwgv:ASPxSummaryItem DisplayFormat="c" FieldName="PIM" 
                                                ShowInGroupFooterColumn="PIM" SummaryType="Sum" />
                                            <dxwgv:ASPxSummaryItem DisplayFormat="c" FieldName="ENERO" 
                                                ShowInGroupFooterColumn="ENERO" SummaryType="Sum" />
                                            <dxwgv:ASPxSummaryItem DisplayFormat="c" FieldName="FEBRERO" 
                                                ShowInGroupFooterColumn="FEBRERO" SummaryType="Sum" />
                                            <dxwgv:ASPxSummaryItem DisplayFormat="c" FieldName="MARZO" 
                                                ShowInGroupFooterColumn="MARZO" SummaryType="Sum" />
                                            <dxwgv:ASPxSummaryItem DisplayFormat="c" FieldName="ABRIL" 
                                                ShowInGroupFooterColumn="ABRIL" SummaryType="Sum" />
                                            <dxwgv:ASPxSummaryItem DisplayFormat="c" FieldName="MAYO" 
                                                ShowInGroupFooterColumn="MAYO" SummaryType="Sum" />
                                            <dxwgv:ASPxSummaryItem DisplayFormat="c" FieldName="JUNIO" 
                                                ShowInGroupFooterColumn="JUNIO" SummaryType="Sum" />
                                            <dxwgv:ASPxSummaryItem DisplayFormat="c" FieldName="JULIO" 
                                                ShowInGroupFooterColumn="JULIO" SummaryType="Sum" />
                                            <dxwgv:ASPxSummaryItem DisplayFormat="c" FieldName="AGOSTO" 
                                                ShowInGroupFooterColumn="AGOSTO" SummaryType="Sum" />
                                            <dxwgv:ASPxSummaryItem DisplayFormat="c" FieldName="SETIEMBRE" 
                                                ShowInGroupFooterColumn="SETIEMBRE" SummaryType="Sum" />
                                            <dxwgv:ASPxSummaryItem DisplayFormat="c" FieldName="OCTUBRE" 
                                                ShowInGroupFooterColumn="OCTUBRE" SummaryType="Sum" />
                                            <dxwgv:ASPxSummaryItem DisplayFormat="c" FieldName="NOVIEMBRE" 
                                                ShowInGroupFooterColumn="NOVIEMBRE" SummaryType="Sum" />
                                            <dxwgv:ASPxSummaryItem DisplayFormat="c" FieldName="DICIEMBRE" 
                                                ShowInGroupFooterColumn="DICIEMBRE" SummaryType="Sum" />
                                            <dxwgv:ASPxSummaryItem DisplayFormat="c" FieldName="TOTAL_EJECUTADO" 
                                                ShowInGroupFooterColumn="TOTAL_EJECUTADO" SummaryType="Sum" />
                                        </GroupSummary>
                                        <Columns>
                                            <dxwgv:GridViewDataTextColumn Caption="Actividad o Proyecto" FieldName="ACT_PROY" 
                                                ShowInCustomizationForm="True" SortIndex="1" SortOrder="Ascending" 
                                                Visible="False" Width="30px">
                                                <Settings AllowDragDrop="False" AllowSort="False" />
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                            </dxwgv:GridViewDataTextColumn>
                                            <dxwgv:GridViewDataTextColumn Caption="Nombre" 
                                                FieldName="ACT_PROY_NOMBRE" ShowInCustomizationForm="True" SortIndex="0" 
                                                SortOrder="Ascending" VisibleIndex="14" Width="30px">
                                                <Settings AllowDragDrop="False" AllowSort="False" />
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                            </dxwgv:GridViewDataTextColumn>
                                            <dxwgv:GridViewDataTextColumn Caption="Año" FieldName="ANO_EJE" 
                                                ShowInCustomizationForm="True" VisibleIndex="0" Width="30px">
                                                <Settings AllowDragDrop="False" AllowSort="False" />
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                            </dxwgv:GridViewDataTextColumn>
                                            <dxwgv:GridViewDataTextColumn Caption="Marco" FieldName="PIM" 
                                                ShowInCustomizationForm="True" VisibleIndex="1" Width="100%">
                                                <PropertiesTextEdit DisplayFormatString="c">
                                                </PropertiesTextEdit>
                                                <Settings AllowDragDrop="False" AllowSort="False" />
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                            </dxwgv:GridViewDataTextColumn>
                                            <dxwgv:GridViewDataTextColumn Caption="enero" FieldName="ENERO" 
                                                ShowInCustomizationForm="True" VisibleIndex="1" Width="100%">
                                                <PropertiesTextEdit DisplayFormatString="c">
                                                </PropertiesTextEdit>
                                                <Settings AllowDragDrop="False" AllowSort="False" />
                                                <DataItemTemplate>
                                                    <dxe:ASPxHyperLink ID="hyperLink" runat="server" Font-Size="XX-Small" 
                                                        OnInit="hyperLink_InitEnero">
                                                    </dxe:ASPxHyperLink>
                                                </DataItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                            </dxwgv:GridViewDataTextColumn>
                                            <dxwgv:GridViewDataTextColumn Caption="Febrero" FieldName="FEBRERO" 
                                                ShowInCustomizationForm="True" VisibleIndex="2" Width="100%">
                                                <PropertiesTextEdit DisplayFormatString="c">
                                                </PropertiesTextEdit>
                                                <Settings AllowDragDrop="False" AllowSort="False" />
                                                <DataItemTemplate>
                                                    <dxe:ASPxHyperLink ID="hyperLink1" runat="server" Font-Size="XX-Small" 
                                                        OnInit="hyperLink_InitFebrero">
                                                    </dxe:ASPxHyperLink>
                                                </DataItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                            </dxwgv:GridViewDataTextColumn>
                                            <dxwgv:GridViewDataTextColumn Caption="Marzo" FieldName="MARZO" 
                                                ShowInCustomizationForm="True" VisibleIndex="3" Width="100%">
                                                <PropertiesTextEdit DisplayFormatString="c">
                                                </PropertiesTextEdit>
                                                <Settings AllowDragDrop="False" AllowSort="False" />
                                                <DataItemTemplate>
                                                    <dxe:ASPxHyperLink ID="hyperLink1" runat="server" Font-Size="XX-Small" 
                                                        OnInit="hyperLink_InitMarzo">
                                                    </dxe:ASPxHyperLink>
                                                </DataItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                            </dxwgv:GridViewDataTextColumn>
                                            <dxwgv:GridViewDataTextColumn Caption="Abril" FieldName="ABRIL" 
                                                ShowInCustomizationForm="True" VisibleIndex="4" Width="100%">
                                                <PropertiesTextEdit DisplayFormatString="c">
                                                </PropertiesTextEdit>
                                                <Settings AllowDragDrop="False" AllowSort="False" />
                                                <DataItemTemplate>
                                                    <dxe:ASPxHyperLink ID="hyperLink1" runat="server" Font-Size="XX-Small" 
                                                        OnInit="hyperLink_InitAbril">
                                                    </dxe:ASPxHyperLink>
                                                </DataItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                            </dxwgv:GridViewDataTextColumn>
                                            <dxwgv:GridViewDataTextColumn Caption="Mayo" FieldName="MAYO" 
                                                ShowInCustomizationForm="True" VisibleIndex="5" Width="100%">
                                                <PropertiesTextEdit DisplayFormatString="c">
                                                </PropertiesTextEdit>
                                                <Settings AllowDragDrop="False" AllowSort="False" />
                                                <DataItemTemplate>
                                                    <dxe:ASPxHyperLink ID="hyperLink1" runat="server" Font-Size="XX-Small" 
                                                        OnInit="hyperLink_InitMayo">
                                                    </dxe:ASPxHyperLink>
                                                </DataItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                            </dxwgv:GridViewDataTextColumn>
                                            <dxwgv:GridViewDataTextColumn Caption="Junio" FieldName="JUNIO" 
                                                ShowInCustomizationForm="True" VisibleIndex="6" Width="100%">
                                                <PropertiesTextEdit DisplayFormatString="c">
                                                </PropertiesTextEdit>
                                                <Settings AllowDragDrop="False" AllowSort="False" />
                                                <DataItemTemplate>
                                                    <dxe:ASPxHyperLink ID="hyperLink1" runat="server" Font-Size="XX-Small" 
                                                        OnInit="hyperLink_InitJunio">
                                                    </dxe:ASPxHyperLink>
                                                </DataItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                            </dxwgv:GridViewDataTextColumn>
                                            <dxwgv:GridViewDataTextColumn Caption="Julio" FieldName="JULIO" 
                                                ShowInCustomizationForm="True" VisibleIndex="7" Width="100%">
                                                <PropertiesTextEdit DisplayFormatString="c">
                                                </PropertiesTextEdit>
                                                <Settings AllowDragDrop="False" AllowSort="False" />
                                                <DataItemTemplate>
                                                    <dxe:ASPxHyperLink ID="hyperLink1" runat="server" Font-Size="XX-Small" 
                                                        OnInit="hyperLink_InitJulio">
                                                    </dxe:ASPxHyperLink>
                                                </DataItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                            </dxwgv:GridViewDataTextColumn>
                                            <dxwgv:GridViewDataTextColumn Caption="Agosto" FieldName="AGOSTO" 
                                                ShowInCustomizationForm="True" VisibleIndex="8" Width="100%">
                                                <PropertiesTextEdit DisplayFormatString="c">
                                                </PropertiesTextEdit>
                                                <Settings AllowDragDrop="False" AllowSort="False" />
                                                <DataItemTemplate>
                                                    <dxe:ASPxHyperLink ID="hyperLink1" runat="server" Font-Size="XX-Small" 
                                                        OnInit="hyperLink_InitAgosto">
                                                    </dxe:ASPxHyperLink>
                                                </DataItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                            </dxwgv:GridViewDataTextColumn>
                                            <dxwgv:GridViewDataTextColumn Caption="Setiembre" FieldName="SETIEMBRE" 
                                                ShowInCustomizationForm="True" VisibleIndex="9" Width="100%">
                                                <PropertiesTextEdit DisplayFormatString="c">
                                                </PropertiesTextEdit>
                                                <Settings AllowDragDrop="False" AllowSort="False" />
                                                <DataItemTemplate>
                                                    <dxe:ASPxHyperLink ID="hyperLink1" runat="server" Font-Size="XX-Small" 
                                                        OnInit="hyperLink_InitSetiembre">
                                                    </dxe:ASPxHyperLink>
                                                </DataItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                            </dxwgv:GridViewDataTextColumn>
                                            <dxwgv:GridViewDataTextColumn Caption="Octubre" FieldName="OCTUBRE" 
                                                ShowInCustomizationForm="True" VisibleIndex="10" Width="100%">
                                                <PropertiesTextEdit DisplayFormatString="c">
                                                </PropertiesTextEdit>
                                                <Settings AllowDragDrop="False" AllowSort="False" />
                                                <DataItemTemplate>
                                                    <dxe:ASPxHyperLink ID="hyperLink1" runat="server" Font-Size="XX-Small" 
                                                        OnInit="hyperLink_InitOctubre">
                                                    </dxe:ASPxHyperLink>
                                                </DataItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                            </dxwgv:GridViewDataTextColumn>
                                            <dxwgv:GridViewDataTextColumn Caption="Noviembre" FieldName="NOVIEMBRE" 
                                                ShowInCustomizationForm="True" VisibleIndex="11" Width="100%">
                                                <PropertiesTextEdit DisplayFormatString="c">
                                                </PropertiesTextEdit>
                                                <Settings AllowDragDrop="False" AllowSort="False" />
                                                <DataItemTemplate>
                                                    <dxe:ASPxHyperLink ID="hyperLink1" runat="server" Font-Size="XX-Small" 
                                                        OnInit="hyperLink_InitNoviembre">
                                                    </dxe:ASPxHyperLink>
                                                </DataItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                            </dxwgv:GridViewDataTextColumn>
                                            <dxwgv:GridViewDataTextColumn Caption="Diciembre" FieldName="DICIEMBRE" 
                                                ShowInCustomizationForm="True" VisibleIndex="12" Width="100%">
                                                <PropertiesTextEdit DisplayFormatString="c">
                                                </PropertiesTextEdit>
                                                <Settings AllowDragDrop="False" AllowSort="False" />
                                                <DataItemTemplate>
                                                    <dxe:ASPxHyperLink ID="hyperLink1" runat="server" Font-Size="XX-Small" 
                                                        OnInit="hyperLink_InitDiciembre">
                                                    </dxe:ASPxHyperLink>
                                                </DataItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                            </dxwgv:GridViewDataTextColumn>
                                            <dxwgv:GridViewDataTextColumn Caption="Total" FieldName="TOTAL_EJECUTADO" 
                                                ShowInCustomizationForm="True" VisibleIndex="13" Width="100%">
                                                <PropertiesTextEdit DisplayFormatString="c">
                                                </PropertiesTextEdit>
                                                <Settings AllowDragDrop="False" AllowSort="False" />
                                                <DataItemTemplate>
                                                    <dxe:ASPxHyperLink ID="hyperLink1" runat="server" Font-Size="XX-Small" 
                                                        OnInit="hyperLink_InitTotal">
                                                    </dxe:ASPxHyperLink>
                                                </DataItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                            </dxwgv:GridViewDataTextColumn>
                                        </Columns>
                                        <SettingsPager Mode="ShowPager"></SettingsPager>
                                        <Settings ShowFooter="True" ShowGroupFooter="VisibleAlways" 
                                            ShowTitlePanel="True" ShowVerticalScrollBar="True" 
                                            VerticalScrollableHeight="600" />
                                        <SettingsText Title="EJECUCION DEL GASTO POR ACTIVIDAD / PROYECTO " />
                                        <SettingsLoadingPanel Mode="ShowOnStatusBar" />
                                    </dxwgv:ASPxGridView>
                                    <dxpc:ASPxPopupControl ID="popupControl" runat="server" 
                                        ClientInstanceName="clientPopupControl" CloseAction="CloseButton" 
                                        Height="400px" Modal="True" PopupHorizontalAlign="WindowCenter" 
                                        PopupVerticalAlign="WindowCenter" Width="950px">
                                        <ContentCollection>
                                            <dxpc:PopupControlContentControl runat="server">
                                            </dxpc:PopupControlContentControl>
                                        </ContentCollection>
                                    </dxpc:ASPxPopupControl>
                            </td>
                        </tr>
                     </table>
                    
                    </dxw:ContentControl>
                    </ContentCollection>
                </dxtc:TabPage>
            </TabPages>
        </dxtc:ASPxPageControl>

         



   
   

  </div>    
    <br />
</asp:Content>
