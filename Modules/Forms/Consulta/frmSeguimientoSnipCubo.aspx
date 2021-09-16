<%@ Page Language="C#" MasterPageFile="~/Modules/MasterPage.Master" AutoEventWireup="true" 
    CodeBehind="frmSeguimientoSnipCubo.aspx.cs" Inherits="InfoGesRegional.Modules.Forms.Consulta.frmSeguimientoSnipCubo" 
    Title="InfoGesConsultas"  %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPivotGrid.Export" TagPrefix="dx" %>


<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dxe" %>

<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dxtc" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dxw" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dxwgv" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dxwpg" %>






<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script language="javascript" type="text/javascript">
       // <![CDATA[
             
    </script>       

  <div id="principal" >
    <table>
    <tr>
    <td>





    <table border="0" cellpadding="3" cellspacing="0">
        <tr>
            <td>
				<strong>Export to:</strong>
            </td>
            <td>
                <dxe:ASPxComboBox ID="listExportFormat" runat="server" style="vertical-align: middle" SelectedIndex="0" ValueType="System.String" Width="61px">
                <Items>
                    <dxe:ListEditItem Text="Excel" Value="0"/>
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

 
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
            <ContentTemplate>

                <div class="RptItem">
                <table width="100%">
                <tr><td>
                <dxtc:ASPxPageControl ID="ASPxPageControl2" runat="server" ActiveTabIndex="0" 
                    Height="300%"         
                    LoadingPanelText=""
                    TabSpacing="3px" Width="600px">
                <ContentStyle VerticalAlign="Top">
                    <Border BorderColor="#AECAF0" BorderStyle="Solid" BorderWidth="1px" />
                </ContentStyle>     
                <ActiveTabStyle Font-Bold="True" Font-Size="Small">
                </ActiveTabStyle>                        
                    <TabPages >   
                    <dxtc:TabPage Text="Filtros de Seguimiento" >
                        <ContentCollection>
                            <dxw:ContentControl ID="ContentControl13" runat="server">
                                <div class="divGray" >
                                    <table style="border-style: none; border-color: inherit; border-width: 0; width: 1200px;" >
                                    <tr>
                                    <td>
                                     <dxwpg:ASPxPivotGrid id="ASPxPivotGridConsultaObraxValorizacion" runat="server" 
                                            onLoad="LoadAvanceObra" CustomizationFieldsLeft="600" 
                                            CustomizationFieldsTop="400" ClientInstanceName="pivotGrid">
                                         <Fields>
                                                
                                         <dxwpg:PivotGridField Area="RowArea" AreaIndex="0" FieldName="SEC_EJEC_NOMBRE" Caption="EJECUTORA" ID="IdEjecutora" HeaderStyle-BackgroundImage-HorizontalPosition="center" Options-AllowSort="False" HeaderStyle-Wrap="True">
                                             <HeaderStyle Wrap="True">
                                             <BackgroundImage HorizontalPosition="center" />
                                             </HeaderStyle>
                                         </dxwpg:PivotGridField>
                                         <dxwpg:PivotGridField Area="RowArea" AreaIndex="1" FieldName="ACTIVIDAD_PROYECTO" Caption="TIPO DE ACT/PROY" ID="PivotGridField5"  HeaderStyle-BackgroundImage-HorizontalPosition="center" Options-AllowSort="False" HeaderStyle-Wrap="True">
                                         <HeaderStyle  BackgroundImage-HorizontalPosition="center">
                                             <BackgroundImage HorizontalPosition="center" />
                                             </HeaderStyle>
                                         </dxwpg:PivotGridField>

                                         <dxwpg:PivotGridField Area="ColumnArea" AreaIndex="2" 
                                                 FieldName="CATEGORIA_GASTO_NOMBRE" Caption="CATEGORIA DE GASTO" 
                                                 ID="IdCategoriaGasto"  HeaderStyle-BackgroundImage-HorizontalPosition="center" 
                                                 Options-AllowSort="False" >
                                         <HeaderStyle BackgroundImage-HorizontalPosition="center" Wrap="True" >
                                             <BackgroundImage HorizontalPosition="center" />
                                             </HeaderStyle>
                                         </dxwpg:PivotGridField>    
                                         <dxwpg:PivotGridField Area="ColumnArea" AreaIndex="1" FieldName="FUENTE_FINANC_NOMBRE" Caption="FTE. FTO" ID="IdFuente_financ"  HeaderStyle-BackgroundImage-HorizontalPosition="center" Options-AllowSort="False" >
                                         <HeaderStyle BackgroundImage-HorizontalPosition="center" Wrap="True" >
                                             <BackgroundImage HorizontalPosition="center" />
                                             </HeaderStyle>
                                         </dxwpg:PivotGridField>    
                                         <dxwpg:PivotGridField Area="ColumnArea" AreaIndex="0" FieldName="ANO_EJE" Caption="PERIODO" ID="IdAno_Eje"  HeaderStyle-BackgroundImage-HorizontalPosition="center" Options-AllowSort="False" >
                                         <HeaderStyle BackgroundImage-HorizontalPosition="center"  >
                                             <BackgroundImage HorizontalPosition="center" />
                                             </HeaderStyle>
                                         <CellStyle BackColor="AliceBlue" />
                                         </dxwpg:PivotGridField>    
                                         <dxwpg:PivotGridField ID="PivotGridField3" Area="DataArea" AreaIndex="0" 
                                                 FieldName="EJECUCION" Caption="EJECUCION" >
                                         </dxwpg:PivotGridField>
                                         </Fields>
                                          <OptionsPager RowsPerPage="60"></OptionsPager>
                                         <OptionsView   ShowRowGrandTotals="true"  DataHeadersDisplayMode="Popup" DataHeadersPopupMinCount="3"
                                                        ShowCustomTotalsForSingleValues="false" />
                                         <Styles CssFilePath="~/App_Themes/Glass/PivotGrid/styles.css" 
                                             CssPostfix="Glass">
                                         </Styles>
                                     </dxwpg:ASPxPivotGrid>
                                    <dx:ASPxPivotGridExporter ID="ASPxPivotGridExporter1" runat="server" ASPxPivotGridID="ASPxPivotGridConsultaObraxValorizacion" Visible="False" />

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


</td>
</tr>
</table>


                            


         



   
   

  </div>    
    <br />
</asp:Content>


