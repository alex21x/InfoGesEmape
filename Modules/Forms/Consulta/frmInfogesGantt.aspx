<%@ Page Language="C#" MasterPageFile="~/Modules/MasterPage.Master" AutoEventWireup="true" 
    CodeBehind="frmInfogesGantt.aspx.cs" Inherits="InfoGesRegional.Modules.Forms.Consulta.frmDinamicaRuc" 
    Title="InfoGesConsultas" %>

<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dxtc" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style4
        {
            width: 309px;
        }
        .style5
        {
            width: 168px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <script type="text/javascript">
        // <![CDATA[
          var CustomPager = {
              gotoBox_Init: function (s, e) {
                  s.SetText(1 + ASPxGridviewRuc.GetPageIndex());
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
                  if (ASPxGridviewRuc.InCallback())
                      return;
                  var pageIndex = parseInt(textBox.GetText()) - 1;
                  if (pageIndex < 0)
                      pageIndex = 0;
                  ASPxGridviewRuc.GotoPage(pageIndex);
              },
              combo_SelectedIndexChanged: function (s, e) {
                  ASPxGridviewRuc.PerformCallback(s.GetSelectedItem().text);
              }
          };
        // ]]>
        </script> 
     <div id="principal" >

<table>
<tr>
<td>
<table>
<tr>
<td align="center">
<dxtc:ASPxTabControl ID="ASPxTabControleJEjecutora" runat="server"  AutoPostBack="true"
        DataSourceID="XmlDataSource2"  
        OnActiveTabChanged="ASPxPageControl1_ActiveTabChanged1" 
        EnableHierarchyRecreation="True" OnLoad="Load_Xml_Ejecutora" 
        ActiveTabStyle-Font-Size="Large" TabStyle-Wrap="True" Width="1000px" >
<Paddings Padding="0" />
    </dxtc:ASPxTabControl>
<asp:XmlDataSource ID="XmlDataSource2" runat="server" DataFile=""  XPath="//ejecutora" EnableCaching="false"></asp:XmlDataSource>
</td>
</tr>
</table>
</td></tr>
<tr>
<td>
<table>
<tr>
<td style="padding-right: 4px">
                <dx:ASPxButton ID="btnXlsExport" runat="server" Text="Exportar  XLS" UseSubmitBehavior="False"  Font-Size="Small"
                    OnClick="btnXlsExport_Click" /></td>

</tr>
</table>
</td>
</tr>
<tr>
<td>
<table>
<tr>
<td>
<dxwgv:ASPxGridView ID="ASPxGridviewRuc"  runat="server" Width="100%" KeyFieldName="RUC"
    ClientInstanceName="ASPxGridviewRuc"  EnablePagingGestures="False" OnCustomCallback="Grid_CustomCallback"
    OnLoad="Load_AcumuladoRuc" Visible="True" Font-Size="Small" >

    <TotalSummary>
        <dxwgv:ASPxSummaryItem FieldName="EJECUCION_2013" SummaryType="Sum" DisplayFormat="c"/>
        <dxwgv:ASPxSummaryItem FieldName="EJECUCION_2014" SummaryType="Sum" DisplayFormat="c"/>
        <dxwgv:ASPxSummaryItem FieldName="EJECUCION_2015" SummaryType="Sum" DisplayFormat="c"/>
        <dxwgv:ASPxSummaryItem FieldName="EJECUCION_2016" SummaryType="Sum" DisplayFormat="c"/>
        <dxwgv:ASPxSummaryItem FieldName="EJECUCION_2017" SummaryType="Sum" DisplayFormat="c"/>
        <dxwgv:ASPxSummaryItem FieldName="EJECUCION_2018" SummaryType="Sum" DisplayFormat="c"/>
        <dxwgv:ASPxSummaryItem FieldName="EJECUCION_2019" SummaryType="Sum" DisplayFormat="c"/>
        <dxwgv:ASPxSummaryItem FieldName="EJECUCION_2020" SummaryType="Sum" DisplayFormat="c"/>
        <dxwgv:ASPxSummaryItem FieldName="EJECUCION_TOTAL" SummaryType="Sum" DisplayFormat="c"/>
     </TotalSummary>
        <GroupSummary>
        <dxwgv:ASPxSummaryItem FieldName="EJECUCION_2013" ShowInGroupFooterColumn="EJECUCION_2013" SummaryType="Sum" DisplayFormat="{0:c}" />
        <dxwgv:ASPxSummaryItem FieldName="EJECUCION_2014" ShowInGroupFooterColumn="EJECUCION_2014" SummaryType="Sum" DisplayFormat="{0:c}" />
        <dxwgv:ASPxSummaryItem FieldName="EJECUCION_2015" ShowInGroupFooterColumn="EJECUCION_2015" SummaryType="Sum" DisplayFormat="{0:c}" />
        <dxwgv:ASPxSummaryItem FieldName="EJECUCION_2016" ShowInGroupFooterColumn="EJECUCION_2016" SummaryType="Sum" DisplayFormat="{0:c}" />
        <dxwgv:ASPxSummaryItem FieldName="EJECUCION_2017" ShowInGroupFooterColumn="EJECUCION_2017" SummaryType="Sum" DisplayFormat="{0:c}" />
        <dxwgv:ASPxSummaryItem FieldName="EJECUCION_2018" ShowInGroupFooterColumn="EJECUCION_2018" SummaryType="Sum" DisplayFormat="{0:c}" />
        <dxwgv:ASPxSummaryItem FieldName="EJECUCION_2019" ShowInGroupFooterColumn="EJECUCION_2019" SummaryType="Sum" DisplayFormat="{0:c}" />
        <dxwgv:ASPxSummaryItem FieldName="EJECUCION_2020" ShowInGroupFooterColumn="EJECUCION_2020" SummaryType="Sum" DisplayFormat="{0:c}" />
        <dxwgv:ASPxSummaryItem FieldName="EJECUCION_TOTAL" ShowInGroupFooterColumn="EJECUCION_TOTAL" SummaryType="Sum" DisplayFormat="{0:c}" />
        </GroupSummary>
<Columns>
    <dxwgv:GridViewDataTextColumn FieldName="RUC" Caption="RUC" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center">
    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
    </dxwgv:GridViewDataTextColumn>
    <dxwgv:GridViewDataTextColumn FieldName="NOMBRE_RUC" Caption="NOMBRE" VisibleIndex="2" HeaderStyle-HorizontalAlign="Center"  Width="20%">
         <Settings AllowDragDrop="False" AllowSort="False" AutoFilterCondition="Contains"></Settings>
        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
    </dxwgv:GridViewDataTextColumn>
    <dxwgv:GridViewDataTextColumn FieldName="EJECUCION_TOTAL" Caption="TOTAL" VisibleIndex="3"  HeaderStyle-HorizontalAlign="Center"  HeaderStyle-Wrap="True">
        <PropertiesTextEdit DisplayFormatString="c" ></PropertiesTextEdit><Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
    </dxwgv:GridViewDataTextColumn>
    <dxwgv:GridViewBandColumn Caption="EJECUCION" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center"   VisibleIndex="4" >
    <Columns>
        <dxwgv:GridViewDataTextColumn FieldName="EJECUCION_2013" Caption="2013" VisibleIndex="2" HeaderStyle-HorizontalAlign="Center"  HeaderStyle-Wrap="True">
            <PropertiesTextEdit DisplayFormatString="c" ></PropertiesTextEdit><Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
        </dxwgv:GridViewDataTextColumn>
        <dxwgv:GridViewDataTextColumn FieldName="EJECUCION_2014" Caption="2014" VisibleIndex="2"  HeaderStyle-HorizontalAlign="Center"  HeaderStyle-Wrap="True">
            <PropertiesTextEdit DisplayFormatString="c" ></PropertiesTextEdit><Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
        </dxwgv:GridViewDataTextColumn>
        <dxwgv:GridViewDataTextColumn FieldName="EJECUCION_2015" Caption="2015" VisibleIndex="2"  HeaderStyle-HorizontalAlign="Center"  HeaderStyle-Wrap="True">
            <PropertiesTextEdit DisplayFormatString="c" ></PropertiesTextEdit><Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
        </dxwgv:GridViewDataTextColumn>
        <dxwgv:GridViewDataTextColumn FieldName="EJECUCION_2016" Caption="2016" VisibleIndex="2" HeaderStyle-HorizontalAlign="Center"  HeaderStyle-Wrap="True">
            <PropertiesTextEdit DisplayFormatString="c" ></PropertiesTextEdit><Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
        </dxwgv:GridViewDataTextColumn>
        <dxwgv:GridViewDataTextColumn FieldName="EJECUCION_2017" Caption="2017" VisibleIndex="2" HeaderStyle-HorizontalAlign="Center"  HeaderStyle-Wrap="True">
            <PropertiesTextEdit DisplayFormatString="c" ></PropertiesTextEdit><Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
        </dxwgv:GridViewDataTextColumn>
        <dxwgv:GridViewDataTextColumn FieldName="EJECUCION_2018" Caption="2018" VisibleIndex="2" HeaderStyle-HorizontalAlign="Center"  HeaderStyle-Wrap="True">
            <PropertiesTextEdit DisplayFormatString="c" ></PropertiesTextEdit><Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
        </dxwgv:GridViewDataTextColumn>
        <dxwgv:GridViewDataTextColumn FieldName="EJECUCION_2019" Caption="2019" VisibleIndex="2" HeaderStyle-HorizontalAlign="Center"  HeaderStyle-Wrap="True">
            <PropertiesTextEdit DisplayFormatString="c" ></PropertiesTextEdit><Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
        </dxwgv:GridViewDataTextColumn>
        <dxwgv:GridViewDataTextColumn FieldName="EJECUCION_2020" Caption="2020" VisibleIndex="2" HeaderStyle-HorizontalAlign="Center"  HeaderStyle-Wrap="True">
            <PropertiesTextEdit DisplayFormatString="c" ></PropertiesTextEdit><Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
        </dxwgv:GridViewDataTextColumn>

    </Columns>

    </dxwgv:GridViewBandColumn>

</Columns> 


<Templates>
<DetailRow>


        <dxwgv:ASPxGridView ID="ASPxGridviewRucDet"  runat="server" Width="100%"  OnLoad="LoadRucDet"
            ClientInstanceName="ASPxGridviewRucDet"   AutoGenerateColumns="false"  Font-Size="Small"  >
            <Columns>
            <dxwgv:GridViewDataTextColumn FieldName="ANO_EJE" Caption="AÑO SIAF" VisibleIndex="0" HeaderStyle-Wrap="True" Width="40px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="EXPEDIENTE" Caption="EXP.SIAF" VisibleIndex="0" HeaderStyle-Wrap="True" Width="40px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="RUC" Caption="RUC" VisibleIndex="0" HeaderStyle-Wrap="True" Width="60px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False" Settings-AutoFilterCondition="Contains">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="NOMBRE_RUC" Caption="NOMBRE" VisibleIndex="0" HeaderStyle-Wrap="True" Width="80px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False" Settings-AutoFilterCondition="Contains">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="FECHA_DOC" Caption="FECHA.DOC" VisibleIndex="0" HeaderStyle-Wrap="True" Width="40px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="NUM_DOC" Caption="DOCUMENTO" VisibleIndex="0" HeaderStyle-Wrap="True" Width="60px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="NOTAS" Caption="GLOSA" VisibleIndex="0" HeaderStyle-Wrap="True" Width="400px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="EJECUCION" Caption="GIRADO" VisibleIndex="0" HeaderStyle-Wrap="True" Width="60px" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False">
            <PropertiesTextEdit DisplayFormatString="c"></PropertiesTextEdit><Settings AllowHeaderFilter="False" AllowAutoFilter="False" />
            </dxwgv:GridViewDataTextColumn>
            </Columns>
                        <Settings  ShowFooter="true" />
            <TotalSummary>
                <dxwgv:ASPxSummaryItem FieldName="EJECUCION" SummaryType="Sum" DisplayFormat="c"/>
             </TotalSummary>
         </dxwgv:ASPxGridView>

</DetailRow>

<PagerBar>
    <table class="OptionsTable" style="width: 100%">
        <tr>
            <td>
                <dx:ASPxButton runat="server" ID="FirstButton" Text="First" Enabled="<%# ASPxGridviewRuc.PageIndex > 0 %>"
                    AutoPostBack="false" UseSubmitBehavior="false">
                    <ClientSideEvents Click="function() { ASPxGridviewRuc.GotoPage(0) }" />
                </dx:ASPxButton>
            </td>
            <td>
                <dx:ASPxButton runat="server" ID="PrevButton" Text="Prev" Enabled="<%# ASPxGridviewRuc.PageIndex > 0 %>"
                    AutoPostBack="false" UseSubmitBehavior="false">
                    <ClientSideEvents Click="function() { ASPxGridviewRuc.PrevPage() }" />
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
                    of <%# ASPxGridviewRuc.PageCount %>
                </span>
            </td>
            <td>
                <dx:ASPxButton runat="server" ID="NextButton" Text="Next" Enabled="<%# ASPxGridviewRuc.PageIndex < ASPxGridviewRuc.PageCount - 1 %>"
                    AutoPostBack="false" UseSubmitBehavior="false">
                    <ClientSideEvents Click="function() { ASPxGridviewRuc.NextPage() }" />
                </dx:ASPxButton>
            </td>
            <td>
                <dx:ASPxButton runat="server" ID="LastButton" Text="Last" Enabled="<%# ASPxGridviewRuc.PageIndex < ASPxGridviewRuc.PageCount - 1 %>"
                    AutoPostBack="false" UseSubmitBehavior="false">
                    <ClientSideEvents Click="function() { ASPxGridviewRuc.GotoPage(ASPxGridviewRuc.GetPageCount() - 1); }" />
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
                        <dx:ListEditItem Value="60" />
                        <dx:ListEditItem Value="90" />
                        <dx:ListEditItem Value="120" />
                    </Items>
                    <ClientSideEvents SelectedIndexChanged="CustomPager.combo_SelectedIndexChanged" />
                </dx:ASPxComboBox>
            </td>
        </tr>
    </table>
</PagerBar>
</Templates>
<SettingsBehavior AllowFocusedRow="True" />
<Settings ShowGroupPanel="True" ShowFooter="True"   ShowFilterRow="True"
        ShowHeaderFilterButton="true" ShowGroupFooter="VisibleAlways"
        ShowVerticalScrollBar="True" VerticalScrollableHeight="300" />
<SettingsDetail ShowDetailRow="true" ExportMode="Expanded"/>
<Settings ShowTitlePanel="true" VerticalScrollBarMode="Visible"  ShowFooter="true" />
<SettingsPager Mode="ShowPager" PageSize="60"></SettingsPager>
<Settings ShowFilterBar="Visible" />
<SettingsText Title="LISTADO DE RUC GIRADOS" />
</dxwgv:ASPxGridView> 
<dxwgv:ASPxGridViewExporter ID="gridExport" runat="server" GridViewID="ASPxGridviewRuc"></dxwgv:ASPxGridViewExporter>

</td></tr>
</table>
</td></tr>
</table>

  </div>    
</asp:Content>
