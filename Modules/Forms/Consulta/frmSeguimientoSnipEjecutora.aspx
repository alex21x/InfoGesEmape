<%@ Page Language="C#" MasterPageFile="~/Modules/SecondMasterPage.Master" AutoEventWireup="true" 
    CodeBehind="frmSeguimientoSnipEjecutora.aspx.cs" Inherits="InfoGesRegional.Modules.Forms.Consulta.frmSeguimientoSnipEjecutora" 
    Title="InfoGesConsultas" %>


<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxDataView" tagprefix="dxdv" %>
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

        <table>
        <tr><td align="left">
           <dxe:ASPxButton ID="btnXlsExport" runat="server" Text="Export to XLS" UseSubmitBehavior="False" OnClick="btnXlsExport_Click" /> 
        </td></tr>
            <tr><td>
            <dxwgv:ASPxGridView ID="ASPxGridviewConsultaSnipFinanciero"  runat="server" Width="100%" 
            ClientInstanceName="ASPxGridviewConsultaSnipFinanciero" OnLoad="LoadProyectoSnipSiaf" 
            AutoGenerateColumns="false"  Font-Size="X-Small">
            <Columns>
                <dxwgv:GridViewDataTextColumn FieldName="PROYECTO_SNIP" Caption="Proyecto SNIP" SortOrder="Ascending" Visible="false"
                    VisibleIndex="1" HeaderStyle-Wrap="True" Width="30px"  Settings-AllowSort="False" Settings-AllowDragDrop="False"
                    HeaderStyle-HorizontalAlign="Center"  >
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                    <HeaderStyle HorizontalAlign="Center" Wrap="True" ></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>       
                <dxwgv:GridViewDataTextColumn FieldName="FUENTE_FINANC" Caption="Proyecto SNIP" SortOrder="Ascending" Visible="false"
                    VisibleIndex="1" HeaderStyle-Wrap="True" Width="30px"  Settings-AllowSort="False" Settings-AllowDragDrop="False"
                    HeaderStyle-HorizontalAlign="Center"  >
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                    <HeaderStyle HorizontalAlign="Center" Wrap="True" ></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>                                                              
                <dxwgv:GridViewDataTextColumn FieldName="ID_CLASIFICADOR" Caption="IDCLASIFICADOR" SortOrder="Ascending" Visible="false"
                    VisibleIndex="1" HeaderStyle-Wrap="True" Width="30px"  Settings-AllowSort="False" Settings-AllowDragDrop="False"
                    HeaderStyle-HorizontalAlign="Center"  >
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                    <HeaderStyle HorizontalAlign="Center" Wrap="True" ></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>                                 
                <dxwgv:GridViewDataTextColumn FieldName="PROYECTO_SNIP_NOMBRE" Caption="Proyecto SNIP" SortOrder="Ascending"
                    VisibleIndex="1" HeaderStyle-Wrap="True"   Settings-AllowSort="False" Settings-AllowDragDrop="False"
                    HeaderStyle-HorizontalAlign="Center"  >
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                    <HeaderStyle HorizontalAlign="Center" Wrap="True" ></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="FUENTE_FINANC_NOMBRE" Caption="Fuente de Financiamiento" SortOrder="Ascending"
                    VisibleIndex="1" HeaderStyle-Wrap="True" Width="100px"  Settings-AllowSort="False" Settings-AllowDragDrop="False"
                    HeaderStyle-HorizontalAlign="Center"  >
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                    <HeaderStyle HorizontalAlign="Center" Wrap="True" ></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="ESPECIFICA_DET_NOMBRE" Caption="Especifica de Gasto" SortOrder="Ascending"
                    VisibleIndex="1" HeaderStyle-Wrap="True" Width="180px"  Settings-AllowSort="False" Settings-AllowDragDrop="False"
                    HeaderStyle-HorizontalAlign="Center"  >
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                    <HeaderStyle HorizontalAlign="Center" Wrap="True" ></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="EJECUTORA_NOMBRE" Caption="Ejecutora" SortOrder="Ascending"
                    VisibleIndex="1" HeaderStyle-Wrap="True" Width="180px"  Settings-AllowSort="False" Settings-AllowDragDrop="False"
                    HeaderStyle-HorizontalAlign="Center"  >
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                    <HeaderStyle HorizontalAlign="Center" Wrap="True" ></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="ANO_EJE" Caption="Año"
                    VisibleIndex="2" HeaderStyle-Wrap="True" Width="30px"  Settings-AllowSort="False" Settings-AllowDragDrop="False"
                    HeaderStyle-HorizontalAlign="Center" >
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                    <HeaderStyle HorizontalAlign="Center" Wrap="True" ></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="ENERO" Caption="enero" VisibleIndex="2" HeaderStyle-Wrap="True" Width="80px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False" >
                    <DataItemTemplate> 
                        <dxe:ASPxHyperLink ID="hyperLink" runat="server" OnInit="hyperLink_InitEnero" Font-Size="XX-Small">
                        </dxe:ASPxHyperLink>
                    </DataItemTemplate>                                                        
                    <PropertiesTextEdit DisplayFormatString="c" ></PropertiesTextEdit>
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="FEBRERO" Caption="Febrero" VisibleIndex="2" HeaderStyle-Wrap="True" Width="80px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False">
                    <DataItemTemplate>
                        <dxe:ASPxHyperLink ID="hyperLink1" runat="server" OnInit="hyperLink_InitFebrero" Font-Size="XX-Small" >
                        </dxe:ASPxHyperLink>
                    </DataItemTemplate>                                                        
                    <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="MARZO" Caption="Marzo" VisibleIndex="2" HeaderStyle-Wrap="True" Width="80px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False">
                    <DataItemTemplate>
                        <dxe:ASPxHyperLink ID="hyperLink1" runat="server" OnInit="hyperLink_InitMarzo" Font-Size="XX-Small" >
                        </dxe:ASPxHyperLink>
                    </DataItemTemplate>                                                        
                    <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="ABRIL" Caption="Abril" VisibleIndex="2" HeaderStyle-Wrap="True" Width="80px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False">
                    <DataItemTemplate>
                        <dxe:ASPxHyperLink ID="hyperLink1" runat="server" OnInit="hyperLink_InitAbril" Font-Size="XX-Small" >
                        </dxe:ASPxHyperLink>
                    </DataItemTemplate>                                                        
                    <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="MAYO" Caption="Mayo" VisibleIndex="2" HeaderStyle-Wrap="True" Width="80px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False">
                    <DataItemTemplate>
                        <dxe:ASPxHyperLink ID="hyperLink1" runat="server" OnInit="hyperLink_InitMayo" Font-Size="XX-Small" >
                        </dxe:ASPxHyperLink>
                    </DataItemTemplate>                                                        
                    <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="JUNIO" Caption="Junio" VisibleIndex="2" HeaderStyle-Wrap="True" Width="80px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False">
                    <DataItemTemplate>
                        <dxe:ASPxHyperLink ID="hyperLink1" runat="server" OnInit="hyperLink_InitJunio" Font-Size="XX-Small" >
                        </dxe:ASPxHyperLink>
                    </DataItemTemplate>                                                        
                    <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="JULIO" Caption="Julio" VisibleIndex="2" HeaderStyle-Wrap="True" Width="80px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False">
                    <DataItemTemplate>
                        <dxe:ASPxHyperLink ID="hyperLink1" runat="server" OnInit="hyperLink_InitJulio" Font-Size="XX-Small" >
                        </dxe:ASPxHyperLink>
                    </DataItemTemplate>                                                        
                    <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="AGOSTO" Caption="Agosto" VisibleIndex="2" HeaderStyle-Wrap="True" Width="80px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False">
                    <DataItemTemplate>
                        <dxe:ASPxHyperLink ID="hyperLink1" runat="server" OnInit="hyperLink_InitAgosto" Font-Size="XX-Small" >
                        </dxe:ASPxHyperLink>
                    </DataItemTemplate>                                                        
                    <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="SETIEMBRE" Caption="Setiembre" VisibleIndex="2" HeaderStyle-Wrap="True" Width="80px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False">
                    <DataItemTemplate>
                        <dxe:ASPxHyperLink ID="hyperLink1" runat="server" OnInit="hyperLink_InitSetiembre" Font-Size="XX-Small" >
                        </dxe:ASPxHyperLink>
                    </DataItemTemplate>                                                        
                    <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="OCTUBRE" Caption="Octubre" VisibleIndex="2" HeaderStyle-Wrap="True" Width="80px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False">
                    <DataItemTemplate>
                        <dxe:ASPxHyperLink ID="hyperLink1" runat="server" OnInit="hyperLink_InitOctubre" Font-Size="XX-Small" >
                        </dxe:ASPxHyperLink>
                    </DataItemTemplate>                                                        
                    <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="NOVIEMBRE" Caption="Noviembre" VisibleIndex="2" HeaderStyle-Wrap="True" Width="80px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False">
                    <DataItemTemplate>
                        <dxe:ASPxHyperLink ID="hyperLink1" runat="server" OnInit="hyperLink_InitNoviembre" Font-Size="XX-Small" >
                        </dxe:ASPxHyperLink>
                    </DataItemTemplate>                                                        
                    <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="DICIEMBRE" Caption="Diciembre" VisibleIndex="2" HeaderStyle-Wrap="True" Width="80px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False">
                    <DataItemTemplate>
                        <dxe:ASPxHyperLink ID="hyperLink1" runat="server" OnInit="hyperLink_InitDiciembre" Font-Size="XX-Small" >
                        </dxe:ASPxHyperLink>
                    </DataItemTemplate>                                                        
                    <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn FieldName="TOTAL_EJECUTADO" Caption="Total" VisibleIndex="2" HeaderStyle-Wrap="True" Width="80px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False">
                    <DataItemTemplate>
                        <dxe:ASPxHyperLink ID="hyperLink1" runat="server" OnInit="hyperLink_InitTotal" Font-Size="XX-Small" >
                        </dxe:ASPxHyperLink>
                    </DataItemTemplate>                                                         
                    <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>
                    <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
                </dxwgv:GridViewDataTextColumn>
            </Columns>    
            <SettingsText Title="EJECUCION DEL GASTO POR PROYECTO SNIP " />
            <Settings  ShowFooter="true" ShowGroupFooter="VisibleAlways" ShowTitlePanel="true" ShowVerticalScrollBar="True" VerticalScrollableHeight="600"/>    

            <SettingsPager Mode="ShowAllRecords"/>
            <SettingsLoadingPanel Mode="ShowOnStatusBar" />
            <GroupSummary>
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
                <dxwgv:ASPxSummaryItem FieldName="TOTAL_EJECUTADO" SummaryType="Sum" DisplayFormat="c"  ShowInGroupFooterColumn="TOTAL_EJECUTADO"/>
            </GroupSummary>
                <TotalSummary>
                <dxwgv:ASPxSummaryItem FieldName="PROYECTO_SNIP_NOMBRE"  SummaryType="Count"/>
                <dxwgv:ASPxSummaryItem FieldName="TOTAL_EJECUTADO" SummaryType="Sum" DisplayFormat="c"/>
                </TotalSummary>
        </dxwgv:ASPxGridView>
        <dxwgv:ASPxGridViewExporter ID="gridExport" runat="server" GridViewID="ASPxGridviewConsultaSnipFinanciero"></dxwgv:ASPxGridViewExporter>
        <dxpc:ASPxPopupControl ID="popupControl" runat="server" ClientInstanceName="clientPopupControl"  
            CloseAction="CloseButton" Height="400px"   ScrollBars="Auto"
            Modal="True" Width="950px" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"   HeaderText="Información del Registro Administrativo - SIAF">
        <ContentCollection>
            <dxpc:PopupControlContentControl runat="server">
            </dxpc:PopupControlContentControl>
        </ContentCollection>                    
        </dxpc:ASPxPopupControl>
        </td></tr>
        </table>

  </div>    
</asp:Content>
