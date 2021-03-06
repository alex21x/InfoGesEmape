<%@ Page Language="C#" MasterPageFile="~/Modules/MasterPage.Master" AutoEventWireup="true" 
    CodeBehind="frmDinamicaExpediente.aspx.cs" Inherits="InfoGesRegional.Modules.Forms.Consulta.frmDinamicaExpediente" 
    Title="InfoGesConsultas" %>

<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView.Export" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTabControl" tagprefix="dxtc" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxClasses" tagprefix="dxw" %>


<%@ Register assembly="DevExpress.XtraCharts.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="cc1" %>

<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Data.Linq" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script type="text/javascript">
        // <![CDATA[
         var CustomPager = {
             gotoBox_Init: function (s, e) {
                 s.SetText(1 + ASPxGridInfoGes.GetPageIndex());
             },
             gotoBox_KeyPress: function (s, e) {
                 if (e.htmlEvent.keyCode != 13)
                     return;
                 ASPxClientUtils.PreventEventAndBubble(e.htmlEvent);
                 CustomPager.applyGotoBoxValue(s);
             },
             gotoBox_ValueChanged: function (s, e) {
                 CustomPager.applyGotoBoxValue(s);
             },
             applyGotoBoxValue: function (textBox) {
                 if (ASPxGridInfoGes.InCallback())
                     return;
                 var pageIndex = parseInt(textBox.GetText()) - 1;
                 if (pageIndex < 0)
                     pageIndex = 0;
                 ASPxGridInfoGes.GotoPage(pageIndex);
             },
             combo_SelectedIndexChanged: function (s, e) {
                 ASPxGridInfoGes.PerformCallback(s.GetSelectedItem().text);
             }
         };

         function button1_Click(s, e) {
             if (ASPxGridInfoGes.IsCustomizationWindowVisible())
                 ASPxGridInfoGes.HideCustomizationWindow();
             else
                 ASPxGridInfoGes.ShowCustomizationWindow();
             UpdateButtonText();
         }
         function grid_CustomizationWindowCloseUp(s, e) {
             UpdateButtonText();
         }
         function UpdateButtonText() {
             var text = ASPxGridInfoGes.IsCustomizationWindowVisible() ? "Hide" : "Show";
             text += " Personalizar Ventana";
             button1.SetText(text);
         };
        // ]]>
        </script>
     <div id="principal" >

<table>
<tr>
<td>
<table><tr>
<td class="style19">
<dxtc:ASPxTabControl ID="ASPxTabControleJEjecutora" runat="server" AutoPostBack="True" 
        DataSourceID="XmlDataSource2"  EnableHierarchyRecreation="True"
        OnActiveTabChanged="ASPxPageControl1_ActiveTabChanged" EnableDefaultAppearance="False" 
        ActiveTabStyle-Font-Size="Large" TabStyle-Wrap="True" Width="248px" 
        CssFilePath="~/App_Themes/Glass/Web/styles.css" CssPostfix="Glass" >
<Paddings Padding="0" />

<ActiveTabStyle Font-Size="Large" Wrap="True"></ActiveTabStyle>

<TabStyle Wrap="True"></TabStyle>
    </dxtc:ASPxTabControl>
<asp:XmlDataSource ID="XmlDataSource2" runat="server" DataFile=""  XPath="//ejecutora" EnableCaching="false"></asp:XmlDataSource>
</td>
</tr>
<tr>
<td align="left" class="style18">
<dxtc:ASPxTabControl ID="tcDemos" runat="server" DataSourceID="XmlDataSource1"  AutoPostBack="true"
        OnActiveTabChanged="ASPxPageControl1_ActiveTabChanged"   EnableDefaultAppearance="False"
        ActiveTabStyle-Font-Size="XX-Large" TabIndex="0" CssFilePath="~/App_Themes/Glass/Web/styles.css" 
        CssPostfix="Glass" RightToLeft="True" 
        Width="1200px" EnableTabScrolling="true" >
<Paddings Padding="0" />
    </dxtc:ASPxTabControl>
<asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile=""  XPath="//product"  ></asp:XmlDataSource>
</td>
</tr></table>
</td>

</tr>
<tr>
<td>
<table>
<tr>
<td style="padding-right: 4px">
                <dx:ASPxButton ID="btnXlsExport" runat="server" Text="Exportar  XLS" UseSubmitBehavior="False"
                    OnClick="btnXlsExport_Click" /></td>
<td><dx:ASPxButton runat="server" ID="btnCollapse" Text="Collapse All Rows" UseSubmitBehavior="false"
    AutoPostBack="false">
    <ClientSideEvents Click="function() { ASPxGridInfoGes.CollapseAll() }" />
</dx:ASPxButton>
</td>
<td>
<dx:ASPxButton runat="server" ID="btnExpand" Text="Expand All Rows" UseSubmitBehavior="false"
    AutoPostBack="false">
    <ClientSideEvents Click="function() { ASPxGridInfoGes.ExpandAll() }" />
</dx:ASPxButton>
</td>
</tr>
</table>
</td>
</tr>
<tr>
<td>
<table>
<tr>
<td>
<dxtc:ASPxPageControl ID="ASPxPageControl1" runat="server" AutoPostBack="true"
ActiveTabIndex="0" CssFilePath="~/App_Themes/Glass/Editors/styles.css" 
    CssPostfix="Glass" Height="300%" LoadingPanelText="" TabSpacing="3px" 
        Width="1079px" OnActiveTabChanged="ASPxPageControl1auc" >
	<ContentStyle VerticalAlign="Top">
	<Border BorderColor="#AECAF0" BorderStyle="Solid" BorderWidth="1px" />
    <Border BorderStyle="Solid" BorderColor="#AECAF0" BorderWidth="1px"></Border>
	</ContentStyle>     
	<ActiveTabStyle Font-Bold="True" Font-Size="Small">
	</ActiveTabStyle>                        
	<TabPages >   
		<dxtc:TabPage Text="EXPEDIENTE" >
			<ContentCollection>
				<dxw:ContentControl ID="ContentControl13" runat="server">	


				</dxw:ContentControl>
			</ContentCollection>
		</dxtc:TabPage> 
		<dxtc:TabPage Text="FONDOS POR RENDIR" >
			<ContentCollection>
				<dxw:ContentControl ID="ContentControl1" runat="server">	
												
				</dxw:ContentControl>
			</ContentCollection>
		</dxtc:TabPage>                       
		<dxtc:TabPage Text="DEVENGADOS SIN GIROS" >
			<ContentCollection>
				<dxw:ContentControl ID="ContentControl2" runat="server">	
												
				</dxw:ContentControl>
			</ContentCollection>
		</dxtc:TabPage> 
    </TabPages>
</dxtc:ASPxPageControl> 
 <dx:ASPxButton runat="server" ID="button1" ClientInstanceName="button1" Text="Personalizar Ventana" Visible="false"
        UseSubmitBehavior="false" AutoPostBack="false">
        <ClientSideEvents Click="button1_Click" />
    </dx:ASPxButton>
<asp:XmlDataSource ID="XmlDataSource3" runat="server" DataFile=""  XPath="//Table"  ></asp:XmlDataSource>
<dxwgv:aspxgridview ID="ASPxGridInfoGes"   
    ClientInstanceName="ASPxGridInfoGes" runat="server" KeyFieldName="EXPEDIENTE" ContentPlaceHolderID="ContentHolder"
    AutoGenerateColumns="False"  UseSubmitBehavior="False" EnablePagingGestures="False"
    OnCustomCallback="Grid_CustomCallback"  OnLoad="LoadInfo_Exp_x_Gasto"
    Font-Size="X-Small"
    Width="100%">
<Columns>
<dxwgv:GridViewDataTextColumn FieldName="EXPEDIENTE" VisibleIndex="0"  Caption="EXP." Width="50%"  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6" Settings-AutoFilterCondition="Contains" />
<dxwgv:GridViewDataTextColumn FieldName="EXPEDIENTE_SECUENCIA" VisibleIndex="1"  Caption="SEC." Width="35%"  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6" Settings-AutoFilterCondition="Contains" />
<dxwgv:GridViewDataTextColumn FieldName="EXPEDIENTE_CORRELATIVO" VisibleIndex="2"  Caption="CORRE" Width="50%"  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6" Settings-AutoFilterCondition="Contains" />
<dxwgv:GridViewDataColumn  FieldName="CICLO" VisibleIndex="3"  Caption="C" Width="20%"  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6" />
<dxwgv:GridViewDataTextColumn FieldName="FASE" VisibleIndex="3"  Caption="F" Width="20%"  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6" />
<dxwgv:GridViewDataTextColumn FieldName="ACT_PROY" VisibleIndex="4"  Caption="PROYECTO" Width="60%"  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6" />
<dxwgv:GridViewDataTextColumn FieldName="FUENTE_FINANC" VisibleIndex="4"  Caption="RUBRO" Width="60%"  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6" />
<dxwgv:GridViewDataTextColumn FieldName="TIPO_OPERACION" VisibleIndex="5"  Caption="TO" Width="30%"  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6" />
<dxwgv:GridViewDataTextColumn FieldName="TIPO_RECURSO" VisibleIndex="5"  Caption="TR" Width="30%"  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6" />
<dxwgv:GridViewBandColumn Caption="DOCUMENTO A" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="6">
<Columns>
    <dxwgv:GridViewDataTextColumn FieldName="COD_DOC" VisibleIndex="1" Caption="COD." Width="40%" HeaderStyle-HorizontalAlign="Center"  Settings-AutoFilterCondition="Contains"/> 
    <dxwgv:GridViewDataTextColumn FieldName="NUM_DOC" VisibleIndex="2" Caption="NUM." Width="40%" HeaderStyle-HorizontalAlign="Center"  Settings-AutoFilterCondition="Contains"/>
    <dxwgv:GridViewDataDateColumn FieldName="FECHA_DOC" VisibleIndex="3" Caption="FECHA" Width="50%" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains"/>
    <dxwgv:GridViewDataTextColumn FieldName="MES_EJE" VisibleIndex="4" Caption="MES" Width="50%" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains"/>
    </Columns>
</dxwgv:GridViewBandColumn>
<dxwgv:GridViewBandColumn Caption="CTA CTE" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="6">
<Columns>
    <dxwgv:GridViewDataTextColumn FieldName="ANO_CTA_CTE"  VisibleIndex="1" Caption="A?O" Width="40%" HeaderStyle-HorizontalAlign="Center"  Settings-AutoFilterCondition="Contains"/> 
    <dxwgv:GridViewDataTextColumn FieldName="BANCO" VisibleIndex="2" Caption="BCO" Width="40%" HeaderStyle-HorizontalAlign="Center"  Settings-AutoFilterCondition="Contains"/>
    <dxwgv:GridViewDataTextColumn FieldName="CTA_CTE" VisibleIndex="3" Caption="CTA" Width="40%" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains"/>
    </Columns>
</dxwgv:GridViewBandColumn>
<dxwgv:GridViewDataTextColumn  FieldName="CERTIFICADO" VisibleIndex="8"  Caption="CERT." Width="50%" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True"/>
<dxwgv:GridViewDataTextColumn  FieldName="ESPECIFICA_DET" VisibleIndex="9"  Caption="CLASIF." Width="30%" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True" />
<dxwgv:GridViewDataTextColumn  FieldName="SEC_FUNC" VisibleIndex="10"   Caption="SEC. FUNC." Width="45%" HeaderStyle-HorizontalAlign="Center"  HeaderStyle-Wrap="True" />
<dxwgv:GridViewDataTextColumn  FieldName="NOMBRE_RUC" VisibleIndex="11"   Caption=" NOMBRE" Width="80%" HeaderStyle-HorizontalAlign="Center"  HeaderStyle-Wrap="True" Settings-AllowDragDrop="False" Settings-AllowSort="False" Settings-AutoFilterCondition="Contains"  Visible="false"/>
<dxwgv:GridViewDataTextColumn  FieldName="RUC_NOMBRE" VisibleIndex="11" Caption="RUC" Width="100%" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains"/>
<dxwgv:GridViewDataTextColumn  FieldName="EJECUCION" VisibleIndex="13" UnboundType="Decimal"  Caption="EJECUCION" Width="60%" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-DisplayFormatString="c" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"/>
<dxwgv:GridViewDataTextColumn  FieldName="ESTADO" VisibleIndex="14"  Caption="E" Width="30%" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True"/>
<dxwgv:GridViewDataTextColumn  FieldName="ESTADO_ENVIO" VisibleIndex="15"  Caption="ER." Width="30%" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True"/>

</Columns>

<Templates>
    <PagerBar>
        <table class="OptionsTable" style="width: 100%">
            <tr>
                <td>
                    <dx:ASPxButton runat="server" ID="FirstButton" Text="First" Enabled="<%# ASPxGridInfoGes.PageIndex > 0 %>"
                        AutoPostBack="false" UseSubmitBehavior="false">
                        <ClientSideEvents Click="function() { ASPxGridInfoGes.GotoPage(0) }" />
                    </dx:ASPxButton>
                </td>
                <td>
                    <dx:ASPxButton runat="server" ID="PrevButton" Text="Prev" Enabled="<%# ASPxGridInfoGes.PageIndex > 0 %>"
                        AutoPostBack="false" UseSubmitBehavior="false">
                        <ClientSideEvents Click="function() { ASPxGridInfoGes.PrevPage() }" />
                    </dx:ASPxButton>
                </td>
                <td>
                    <dx:ASPxTextBox runat="server" ID="GotoBox" Width="30">
                        <ClientSideEvents Init="CustomPager.gotoBox_Init" ValueChanged="CustomPager.gotoBox_ValueChanged"
                            KeyPress="CustomPager.gotoBox_KeyPress" />
                    </dx:ASPxTextBox>
                </td>
                <td>
                    <span style="white-space: nowrap">
                        of <%# ASPxGridInfoGes.PageCount %>
                    </span>
                </td>
                <td>
                    <dx:ASPxButton runat="server" ID="NextButton" Text="Next" Enabled="<%# ASPxGridInfoGes.PageIndex < ASPxGridInfoGes.PageCount - 1 %>"
                        AutoPostBack="false" UseSubmitBehavior="false">
                        <ClientSideEvents Click="function() { ASPxGridInfoGes.NextPage() }" />
                    </dx:ASPxButton>
                </td>
                <td>
                    <dx:ASPxButton runat="server" ID="LastButton" Text="Last" Enabled="<%# ASPxGridInfoGes.PageIndex < ASPxGridInfoGes.PageCount - 1 %>"
                        AutoPostBack="false" UseSubmitBehavior="false">
                        <ClientSideEvents Click="function() { ASPxGridInfoGes.GotoPage(ASPxGridInfoGes.GetPageCount() - 1); }" />
                    </dx:ASPxButton>
                </td>
                <td style="width: 100%"></td>
                <td style="white-space: nowrap">
                    <span style="white-space: nowrap">
                        Records per page:
                    </span>
                </td>
                <td>
                    <dx:ASPxComboBox runat="server" ID="Combo" Width="50" DropDownWidth="50" ValueType="System.Int32"
                        OnLoad="PagerCombo_Load">
                        <Items>
                            <dx:ListEditItem Value="20" />
                            <dx:ListEditItem Value="40" />
                            <dx:ListEditItem Value="60" />
                        </Items>
                        <ClientSideEvents SelectedIndexChanged="CustomPager.combo_SelectedIndexChanged" />
                    </dx:ASPxComboBox>
                </td>
            </tr>
        </table>
    </PagerBar>
</Templates>
    <Settings ShowFooter="True" ShowFilterRow="True" 
        ShowHeaderFilterButton="true" ShowTitlePanel="true"  
        ShowVerticalScrollBar="True" VerticalScrollableHeight="300"/>
    <SettingsBehavior AllowFocusedRow="True" />
    <SettingsPager Mode="ShowPager" PageSize="20"></SettingsPager>
    <SettingsText Title="CONSULTA EXPEDIENTE"  />
    <Settings ShowFilterBar="Visible" />
    
    <Settings ShowGroupPanel="True" />
    <SettingsLoadingPanel Mode="ShowAsPopup" />
    <SettingsBehavior EnableCustomizationWindow="true" />
    <ClientSideEvents CustomizationWindowCloseUp="grid_CustomizationWindowCloseUp" />


    <Styles CssFilePath="~/App_Themes/Glass/GridView/styles.css" CssPostfix="Glass">
        <CommandColumn Paddings-Padding="1">
            <Paddings Padding="1px" />
        </CommandColumn>
    </Styles>
</dxwgv:aspxgridview> 
<dxwgv:ASPxGridViewExporter ID="gridExport" runat="server" GridViewID="ASPxGridInfoGes"></dxwgv:ASPxGridViewExporter>

</td></tr>
</table>
</td></tr>
</table>
  </div>    
</asp:Content>
