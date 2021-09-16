<%@ Page Language="C#" MasterPageFile="~/Modules/MasterPage.Master" AutoEventWireup="true"
     CodeBehind="frmConsultasClasificadorxActProy.aspx.cs" Inherits="InfoGesConsultas.Modules.Forms.Consulta.frmConsultasClasificadorxActProy"
    Title="INFOGES - Informado para Gestionar" %>
    
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>    

<%@ Register assembly="DevExpress.Web.ASPxEditors.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>

<%@ Register assembly="DevExpress.Web.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>

<%@ Register assembly="DevExpress.Web.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073" namespace="DevExpress.Web.ASPxTabControl" tagprefix="dxtc" %>

<%@ Register assembly="DevExpress.Web.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073" namespace="DevExpress.Web.ASPxClasses" tagprefix="dxw" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073" Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dxwpg" %>

<%@ Register Assembly="DevExpress.Web.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073" Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v8.3.Export,  Version=8.3.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073" Namespace="DevExpress.XtraPivotGrid.Web"  TagPrefix="dxpgex" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style6
        {
        }
        .style18
        {
            width: 176px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<script type="text/javascript"><!--
    
    }    
//--></script>

    <div id="principal">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
     
        
        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Always">
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server"  AssociatedUpdatePanelID="UpdatePanel4" runat="server" DisplayAfter="0">
                    <ProgressTemplate>
                        <img alt="procesando..."  src="../../Images/ajax-loader.gif"/></ProgressTemplate>
                </asp:UpdateProgress>    
            </ContentTemplate>                 
        </asp:UpdatePanel>                      

        <dxrp:aspxroundpanel ID="ASPxRoundPanel2" runat="server" ShowHeader="False">
            <panelcollection>
            <dxrp:PanelContent ID="PanelContent1" runat="server">
                <table border="0" cellpadding="3" cellspacing="0">
                    <tr>
                        <td>
							<strong>Export to:</strong>
                        </td>
                        <td>
                            <dxe:ASPxComboBox ID="listExportFormat" runat="server" style="vertical-align: middle" SelectedIndex="0" ValueType="System.String" Width="61px">
                            <Items>
								<dxe:ListEditItem Text="Pdf" Value="0"/>
                                <dxe:ListEditItem Text="Excel" Value="1"/>
                                <dxe:ListEditItem Text="Mht" Value="2"/>
                                <dxe:ListEditItem Text="Rtf" Value="3"/>
                                <dxe:ListEditItem Text="Text" Value="4"/>
                                <dxe:ListEditItem Text="Html" Value="5"/>
                            </Items>
                            </dxe:ASPxComboBox>
						</td>
						<td>
							<dxe:ASPxButton ID="buttonSaveAs" runat="server" ToolTip="Export and save" style="vertical-align: middle;" OnClick="buttonSaveAs_Click" Text="Save" Width="51px" >
							</dxe:ASPxButton>
						</td>
						<td>
							<dxe:ASPxButton ID="buttonOpen" runat="server" ToolTip="Export and open" style="vertical-align: middle" OnClick="buttonOpen_Click" Text="Open" Width="51px">
							</dxe:ASPxButton>
						</td>
                    </tr>
                </table>
                <table border="0" cellpadding="3" cellspacing="0">
                    <tr>
                        <td rowspan="5" valign="top" style="width: 106px">
                            <strong>Export Options: </strong></td>
                        <td style="width: 180px">
                            <asp:CheckBox ID="checkPrintHeadersOnEveryPage" runat="server" Text="Print headers on every page"/></td>
                    </tr>
                    <tr>
                        <td style="width: 180px">
                            <asp:CheckBox ID="checkPrintFilterHeaders" runat="server" Text="Print filter headers" Checked="True" /></td>
                    </tr>
                    <tr>
                        <td style="width: 180px">
                            <asp:CheckBox ID="checkPrintColumnHeaders" runat="server" Text="Print column headers" Checked="True" /></td>
                    </tr>
                    <tr>
                        <td style="width: 180px">
                            <asp:CheckBox ID="checkPrintRowHeaders" runat="server" Text="Print row headers" Checked="True" /></td>
                    </tr>
                    <tr>
                        <td style="width: 180px">
                            <asp:CheckBox ID="checkPrintDataHeaders" runat="server" Text="Print data headers" Checked="True" /></td>
                    </tr>
                </table>
            </dxrp:PanelContent>
        </panelcollection>
        </dxrp:aspxroundpanel>    

        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
            <ContentTemplate>

                <div class="RptItem">
                <table width="100%">
                <tr><td>
                <dxtc:ASPxPageControl ID="ASPxPageControl1" runat="server" ActiveTabIndex="0" 
                    CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" Height="300%"         
                      ImageFolder="~/App_Themes/Aqua/{0}/" LoadingPanelText=""
                        TabSpacing="3px" Width="600px" 
                        onactivetabchanged="ASPxPageControl1_ActiveTabChanged" >
                <ContentStyle VerticalAlign="Top">
                    <Border BorderColor="#AECAF0" BorderStyle="Solid" BorderWidth="1px" />
                </ContentStyle>     
                <ActiveTabStyle Font-Bold="True" Font-Size="Small">
                </ActiveTabStyle>                        
                    <TabPages >   
                    <dxtc:TabPage Text="Datos Generales Filtros" >
                        <ContentCollection>
                            <dxw:ContentControl ID="ContentControl13" runat="server">
                                <div class="divGray" >
                                    <table style="border-style: none; border-color: inherit; border-width: 0; width: 1200px;" >
                                    <tr>
                                    <td>
 
                                     <dxwpg:ASPxPivotGrid id="pivotGrid" runat="server" 
                                            OnLoad="LoadAvanceDeObra" Font-Size="XX-Small"
                                            CustomizationFieldsLeft="600" CustomizationFieldsTop="400" ClientInstanceName="pivotGrid"
                                            oncustomcelldisplaytext="ASPxPivotGrid1_CustomCellDisplayText"  
                                            onhtmlfieldvalueprepared="ASPxPivotGrid1_HtmlFieldValuePrepared"
                                            OnCustomCellStyle="CustomCellStyle"
                                            OptionsView-ShowHorizontalScrollBar="true" >
                                         <Fields>
                                                
                                         <dxwpg:PivotGridField Area="RowArea" AreaIndex="3" FieldName="TIPO_COSTO" Caption="Tipo costo" ID="IdTipoCosto">
                                         </dxwpg:PivotGridField>
                                         <dxwpg:PivotGridField Area="RowArea" AreaIndex="2" FieldName="TIPO_AVANCE" Caption="Tipo Avance" ID="IdTipoAvance"  >
                                         </dxwpg:PivotGridField>                                                  
                                         <dxwpg:PivotGridField Area="RowArea" AreaIndex="1" FieldName="DISTRITO" Caption="Distrito" ID="IdDistrito" >
                                         </dxwpg:PivotGridField>
                                         <dxwpg:PivotGridField Area="RowArea" AreaIndex="0" FieldName="COMPONENTE" Caption="Componente" ID="IdComponente"  >
                                         </dxwpg:PivotGridField>
                          
                                         <dxwpg:PivotGridField Area="ColumnArea" AreaIndex="0" FieldName="FECHA" Caption="Año"
                                             GroupInterval="DateYear" ID="IdYear" >
                                         </dxwpg:PivotGridField>

                                         <dxwpg:PivotGridField Area="ColumnArea" AreaIndex="2" FieldName="FECHA" Caption="Mes"
                                             GroupInterval="DateMonth" ID="IdMonth">
                                         </dxwpg:PivotGridField>    
                                         <dxwpg:PivotGridField ID="IdMonto" Area="DataArea" AreaIndex="0" FieldName="MONTO"   >
                                         </dxwpg:PivotGridField>
                                         </Fields>
                                          <OptionsPager RowsPerPage="60"></OptionsPager>
                                         <OptionsView   ShowRowGrandTotals="false"  DataHeadersDisplayMode="Popup" DataHeadersPopupMinCount="3"
                                                        ShowColumnTotals="false" ShowRowTotals="false" ShowColumnGrandTotals="false"
                                                        ShowCustomTotalsForSingleValues="false"  
                                                        />
                                     </dxwpg:ASPxPivotGrid>
                                        <dxpgex:ASPxPivotGridExporter ID="ASPxPivotGridExporter1" runat="server" ASPxPivotGridID="pivotGrid" Visible="False" />
                                     
                                    </td>
                                    </tr>    
                                    </table>
                                </div>                        
                            </dxw:ContentControl>
                        </ContentCollection>
                    </dxtc:TabPage>    
                    </TabPages>
                     
                </dxtc:ASPxPageControl>                                            
                </td></tr></table>
            </ContentTemplate>
        </asp:UpdatePanel>
        
        </div>
</asp:Content>                    
                