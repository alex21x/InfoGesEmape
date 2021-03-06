<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmInfoGesConsultaEjecutoraClasif.aspx.cs" Inherits="InfoGesRegional.Modules.Forms.Consulta.frmInfoGesConsultaEjecutoraClasif" %>


<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dxcp" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v13.1.Export , Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dxpc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Consulta Expediente Administrativo SIAF</title>
</head>
<body>
    <form id="form1" runat="server">
    <script language="javascript" type="text/javascript">
 
    function OnMoreInfoClick(contentUrl) {
        clientPopupControlExpediente.SetContentUrl(contentUrl);
        clientPopupControlExpediente.Show();
    }             
    </script>     
    <div>
<dxe:ASPxButton ID="btnXlsExport" runat="server" Text="Export to XLS" UseSubmitBehavior="False"
                    OnClick="btnXlsExport_Click" />    
        <dxwgv:ASPxGridView ID="ASPxGridview1"  runat="server" Width="1400px" 
            ClientInstanceName="ASPxGridview1"
            OnLoad="LoadASPxGridview" 
            AutoGenerateColumns="false"  Font-Size="X-Small">
        <Columns>
            <dxwgv:GridViewDataTextColumn FieldName="SEC_EJEC" Visible="false" />    
            <dxwgv:GridViewDataTextColumn FieldName="ANO_EJE"  Visible="false" />                                                              
            <dxwgv:GridViewDataTextColumn FieldName="ACT_PROY" Visible="false" />        
            <dxwgv:GridViewDataTextColumn FieldName="FASE" Visible="false" />        
            <dxwgv:GridViewDataTextColumn FieldName="FUENTE_FINANC" Visible="false" />        
            <dxwgv:GridViewDataTextColumn FieldName="ID_CLASIFICADOR" Visible="false" /> 
            <dxwgv:GridViewDataTextColumn FieldName="FUENTE_FINANC_NOMBRE" Caption="Fuente Financiamiento" SortOrder="Ascending"
                VisibleIndex="1" HeaderStyle-Wrap="True" Width="300px"  Settings-AllowSort="False" Settings-AllowDragDrop="False" 
                HeaderStyle-HorizontalAlign="Center"  >
                <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                <HeaderStyle HorizontalAlign="Center" Wrap="True" ></HeaderStyle>
            </dxwgv:GridViewDataTextColumn>                   
            <dxwgv:GridViewDataTextColumn FieldName="ESPECIFICA_DET" Caption="Especifica de Gasto" SortOrder="Ascending"
                VisibleIndex="1" HeaderStyle-Wrap="True" Width="300px"  Settings-AllowSort="False" Settings-AllowDragDrop="False"
                HeaderStyle-HorizontalAlign="Center"  >
                <Settings AllowDragDrop="False" AllowSort="False"></Settings>
                <HeaderStyle HorizontalAlign="Center" Wrap="True" ></HeaderStyle>
            </dxwgv:GridViewDataTextColumn>               
            <dxwgv:GridViewDataTextColumn FieldName="ENERO" Caption="enero" VisibleIndex="2" HeaderStyle-Wrap="True" Width="90px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False" >
                <DataItemTemplate> 
                    <dxe:ASPxHyperLink ID="hyperLink" runat="server" OnInit="hyperLink_InitEnero" Font-Size="XX-Small">
                    </dxe:ASPxHyperLink>
                </DataItemTemplate>                                                        
                <PropertiesTextEdit DisplayFormatString="c" ></PropertiesTextEdit>
                <Settings AllowDragDrop="False" AllowSort="False"></Settings>
            <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="FEBRERO" Caption="Febrero" VisibleIndex="2" HeaderStyle-Wrap="True" Width="90px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False">
                <DataItemTemplate>
                    <dxe:ASPxHyperLink ID="hyperLink1" runat="server" OnInit="hyperLink_InitFebrero" Font-Size="XX-Small" >
                    </dxe:ASPxHyperLink>
                </DataItemTemplate>                                                        
                <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>
                <Settings AllowDragDrop="False" AllowSort="False"></Settings>
            <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="MARZO" Caption="Marzo" VisibleIndex="2" HeaderStyle-Wrap="True" Width="90px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False">
                <DataItemTemplate>
                    <dxe:ASPxHyperLink ID="hyperLink1" runat="server" OnInit="hyperLink_InitMarzo" Font-Size="XX-Small" >
                    </dxe:ASPxHyperLink>
                </DataItemTemplate>                                                        
                <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>
                <Settings AllowDragDrop="False" AllowSort="False"></Settings>
            <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="ABRIL" Caption="Abril" VisibleIndex="2" HeaderStyle-Wrap="True" Width="90px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False">
                <DataItemTemplate>
                    <dxe:ASPxHyperLink ID="hyperLink1" runat="server" OnInit="hyperLink_InitAbril" Font-Size="XX-Small" >
                    </dxe:ASPxHyperLink>
                </DataItemTemplate>                                                        
                <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>
                <Settings AllowDragDrop="False" AllowSort="False"></Settings>
            <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="MAYO" Caption="Mayo" VisibleIndex="2" HeaderStyle-Wrap="True" Width="90px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False">
                <DataItemTemplate>
                    <dxe:ASPxHyperLink ID="hyperLink1" runat="server" OnInit="hyperLink_InitMayo" Font-Size="XX-Small" >
                    </dxe:ASPxHyperLink>
                </DataItemTemplate>                                                        
                <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>
                <Settings AllowDragDrop="False" AllowSort="False"></Settings>
            <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="JUNIO" Caption="Junio" VisibleIndex="2" HeaderStyle-Wrap="True" Width="90px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False">
                <DataItemTemplate>
                    <dxe:ASPxHyperLink ID="hyperLink1" runat="server" OnInit="hyperLink_InitJunio" Font-Size="XX-Small" >
                    </dxe:ASPxHyperLink>
                </DataItemTemplate>                                                        
                <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>
                <Settings AllowDragDrop="False" AllowSort="False"></Settings>
            <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="JULIO" Caption="Julio" VisibleIndex="2" HeaderStyle-Wrap="True" Width="90px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False">
                <DataItemTemplate>
                    <dxe:ASPxHyperLink ID="hyperLink1" runat="server" OnInit="hyperLink_InitJulio" Font-Size="XX-Small" >
                    </dxe:ASPxHyperLink>
                </DataItemTemplate>                                                        
                <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>
                <Settings AllowDragDrop="False" AllowSort="False"></Settings>
            <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="AGOSTO" Caption="Agosto" VisibleIndex="2" HeaderStyle-Wrap="True" Width="90px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False">
                <DataItemTemplate>
                    <dxe:ASPxHyperLink ID="hyperLink1" runat="server" OnInit="hyperLink_InitAgosto" Font-Size="XX-Small" >
                    </dxe:ASPxHyperLink>
                </DataItemTemplate>                                                        
                <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>
                <Settings AllowDragDrop="False" AllowSort="False"></Settings>
            <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="SETIEMBRE" Caption="Setiembre" VisibleIndex="2" HeaderStyle-Wrap="True" Width="90px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False">
                <DataItemTemplate>
                    <dxe:ASPxHyperLink ID="hyperLink1" runat="server" OnInit="hyperLink_InitSetiembre" Font-Size="XX-Small" >
                    </dxe:ASPxHyperLink>
                </DataItemTemplate>                                                        
                <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>
                <Settings AllowDragDrop="False" AllowSort="False"></Settings>
            <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="OCTUBRE" Caption="Octubre" VisibleIndex="2" HeaderStyle-Wrap="True" Width="90px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False">
                <DataItemTemplate>
                    <dxe:ASPxHyperLink ID="hyperLink1" runat="server" OnInit="hyperLink_InitOctubre" Font-Size="XX-Small" >
                    </dxe:ASPxHyperLink>
                </DataItemTemplate>                                                        
                <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>
                <Settings AllowDragDrop="False" AllowSort="False"></Settings>
            <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="NOVIEMBRE" Caption="Noviembre" VisibleIndex="2" HeaderStyle-Wrap="True" Width="90px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False">
                <DataItemTemplate>
                    <dxe:ASPxHyperLink ID="hyperLink1" runat="server" OnInit="hyperLink_InitNoviembre" Font-Size="XX-Small" >
                    </dxe:ASPxHyperLink>
                </DataItemTemplate>                                                        
                <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>
                <Settings AllowDragDrop="False" AllowSort="False"></Settings>
            <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="DICIEMBRE" Caption="Diciembre" VisibleIndex="2" HeaderStyle-Wrap="True" Width="90px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False">
                <DataItemTemplate>
                    <dxe:ASPxHyperLink ID="hyperLink1" runat="server" OnInit="hyperLink_InitDiciembre" Font-Size="XX-Small" >
                    </dxe:ASPxHyperLink>
                </DataItemTemplate>                                                        
                <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>
                <Settings AllowDragDrop="False" AllowSort="False"></Settings>
            <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="TOTAL_EJECUTADO" Caption="Total" VisibleIndex="2" HeaderStyle-Wrap="True" Width="90px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False">
                <DataItemTemplate>
                    <dxe:ASPxHyperLink ID="hyperLink1" runat="server" OnInit="hyperLink_InitTotal" Font-Size="XX-Small" >
                    </dxe:ASPxHyperLink>
                </DataItemTemplate>                                                         
                <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit>
                <Settings AllowDragDrop="False" AllowSort="False"></Settings>
            <HeaderStyle HorizontalAlign="Center" Wrap="True"></HeaderStyle>
            </dxwgv:GridViewDataTextColumn>
        </Columns> 
        <SettingsPager Mode="ShowAllRecords"/>
        <SettingsLoadingPanel Mode="ShowAsPopup"/>
        <Settings  ShowFooter="true" ShowGroupFooter="VisibleAlways" ShowTitlePanel="true" ShowVerticalScrollBar="True" VerticalScrollableHeight="600"/>    
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
        <dxwgv:ASPxSummaryItem FieldName="ENERO" SummaryType="Sum" DisplayFormat="c"/>
        <dxwgv:ASPxSummaryItem FieldName="FEBRERO" SummaryType="Sum" DisplayFormat="c"/>
        <dxwgv:ASPxSummaryItem FieldName="MARZO" SummaryType="Sum" DisplayFormat="c"/>
        <dxwgv:ASPxSummaryItem FieldName="ABRIL" SummaryType="Sum" DisplayFormat="c"/>
        <dxwgv:ASPxSummaryItem FieldName="MAYO" SummaryType="Sum" DisplayFormat="c"/>
        <dxwgv:ASPxSummaryItem FieldName="JUNIO" SummaryType="Sum" DisplayFormat="c"/>
        <dxwgv:ASPxSummaryItem FieldName="JULIO" SummaryType="Sum" DisplayFormat="c"/>
        <dxwgv:ASPxSummaryItem FieldName="AGOSTO" SummaryType="Sum" DisplayFormat="c"/>
        <dxwgv:ASPxSummaryItem FieldName="SETIEMBRE" SummaryType="Sum" DisplayFormat="c"/>
        <dxwgv:ASPxSummaryItem FieldName="OCTUBRE" SummaryType="Sum" DisplayFormat="c"/>
        <dxwgv:ASPxSummaryItem FieldName="NOVIEMBRE" SummaryType="Sum" DisplayFormat="c"/>
        <dxwgv:ASPxSummaryItem FieldName="DICIEMBRE" SummaryType="Sum" DisplayFormat="c"/>
        <dxwgv:ASPxSummaryItem FieldName="TOTAL_EJECUTADO" SummaryType="Sum" DisplayFormat="c"/>
        </TotalSummary>        
     </dxwgv:ASPxGridView>
    <dxpc:ASPxPopupControl ID="popupControl" runat="server" ClientInstanceName="clientPopupControlExpediente"  
        CloseAction="CloseButton" Height="400px" Modal="True" Width="950px" 
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" HeaderText="Expediente Administrativo">
    <ContentCollection>
        <dxpc:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
        </dxpc:PopupControlContentControl>
    </ContentCollection>                    
    </dxpc:ASPxPopupControl>
      <dxwgv:ASPxGridViewExporter ID="gridExport" runat="server" GridViewID="ASPxGridview1"></dxwgv:ASPxGridViewExporter>                  
    </div>
    </form>
</body>
</html>
