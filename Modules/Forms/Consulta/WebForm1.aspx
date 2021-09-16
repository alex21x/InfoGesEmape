<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="InfoGesRegional.Modules.Forms.Consulta.WebForm1" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

<dx:aspxgridview ID="ASPxGridInfoGes"  
    ClientInstanceName="ASPxGridInfoGes" runat="server" KeyFieldName="EXPEDIENTE" ContentPlaceHolderID="ContentHolder"
    AutoGenerateColumns="False"  UseSubmitBehavior="False" EnablePagingGestures="False"  OnLoad="LoadInfo_Exp_x_Gasto" 
    Font-Size="X-Small" OnBeforeGetCallbackResult="gridView2_BeforeGetCallbackResult"
    Width="100%">
<GroupSummary>
    <dx:ASPxSummaryItem FieldName="EJECUCION" ShowInGroupFooterColumn="EJECUCION" SummaryType="Sum" DisplayFormat="c"/>
</GroupSummary>
<Columns>
<dx:GridViewDataTextColumn FieldName="EXPEDIENTE" VisibleIndex="0"  Caption="EXP."   HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6" Settings-AutoFilterCondition="Contains" />
<dx:GridViewDataTextColumn FieldName="EXPEDIENTE_SECUENCIA" VisibleIndex="1"  Caption="SEC."  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6" Settings-AutoFilterCondition="Contains" />
<dx:GridViewDataTextColumn FieldName="EXPEDIENTE_CORRELATIVO" VisibleIndex="2"  Caption="CORRE"   HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6" Settings-AutoFilterCondition="Contains" />
<dx:GridViewDataColumn  FieldName="CICLO" VisibleIndex="3"  Caption="C"   HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6" />
<dx:GridViewDataTextColumn FieldName="FASE" VisibleIndex="3"  Caption="F"  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6" />
<dx:GridViewDataTextColumn FieldName="FASE_CONTRACTUAL" VisibleIndex="3"  Caption="FASE CONTRAC."  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6" HeaderStyle-Wrap="True" />
<dx:GridViewDataTextColumn FieldName="ACT_PROY" VisibleIndex="4"  Caption="PROYECTO" HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6" />
<dx:GridViewDataTextColumn FieldName="FUENTE_FINANC" VisibleIndex="4"  Caption="RUBRO"  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6" />
<dx:GridViewDataTextColumn FieldName="TIPO_OPERACION" VisibleIndex="5"  Caption="TO"  HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6" />
<dx:GridViewDataTextColumn FieldName="TIPO_RECURSO" VisibleIndex="5"  Caption="TR"   HeaderStyle-HorizontalAlign="Center" FixedStyle="Left" CellStyle-BackColor="#ffffd6" />
<dx:GridViewBandColumn Caption="DOCUMENTO A" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="6">
<Columns>
    <dx:GridViewDataTextColumn FieldName="COD_DOC" VisibleIndex="1" Caption="COD."  HeaderStyle-HorizontalAlign="Center"  Settings-AutoFilterCondition="Contains"/> 
    <dx:GridViewDataTextColumn FieldName="NUM_DOC" VisibleIndex="2" Caption="NUM."  HeaderStyle-HorizontalAlign="Center"  Settings-AutoFilterCondition="Contains"/>
    <dx:GridViewDataDateColumn FieldName="FECHA" VisibleIndex="3" Caption="FECHA"  HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains"/>
    <dx:GridViewDataTextColumn FieldName="MES_EJE" VisibleIndex="4" Caption="MES"  HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains"/>
    </Columns>
</dx:GridViewBandColumn>
<dx:GridViewBandColumn Caption="CTA CTE" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="6">
<Columns>
    <dx:GridViewDataTextColumn FieldName="ANO_CTA_CTE"  VisibleIndex="1" Caption="AÑO"  HeaderStyle-HorizontalAlign="Center"  Settings-AutoFilterCondition="Contains"/> 
    <dx:GridViewDataTextColumn FieldName="BANCO" VisibleIndex="2" Caption="BCO" HeaderStyle-HorizontalAlign="Center"  Settings-AutoFilterCondition="Contains"/>
    <dx:GridViewDataTextColumn FieldName="CTA_CTE" VisibleIndex="3" Caption="CTA" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains"/>
    </Columns>
</dx:GridViewBandColumn>

<dx:GridViewDataTextColumn Settings-AllowHeaderFilter="False" FieldName="DOCUMENTOB" Width="60%" VisibleIndex="7" Caption="DOC. B" HeaderStyle-HorizontalAlign="Center"  Settings-AutoFilterCondition="Contains"/> 
<dx:GridViewDataTextColumn  FieldName="CERTIFICADO" VisibleIndex="8"  Caption="CERT."  HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True"/>
<dx:GridViewDataTextColumn  FieldName="ESPECIFICA_DET" VisibleIndex="9"  Caption="CLASIF."  HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True" />
<dx:GridViewDataTextColumn  FieldName="SEC_FUNC" VisibleIndex="10"   Caption="SEC. FUNC."  HeaderStyle-HorizontalAlign="Center"  HeaderStyle-Wrap="True" />
<dx:GridViewDataTextColumn  FieldName="NOMBRE_RUC" VisibleIndex="11"   Caption=" NOMBRE" HeaderStyle-HorizontalAlign="Center"  HeaderStyle-Wrap="True" Settings-AllowDragDrop="False" Settings-AllowSort="False" Settings-AutoFilterCondition="Contains"  Visible="false"/>
<dx:GridViewDataTextColumn  FieldName="RUC_NOMBRE" VisibleIndex="11" Caption="RUC" HeaderStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Contains"/>
<dx:GridViewDataTextColumn  FieldName="NOTAS" VisibleIndex="12"   Caption="NOTAS"  Width="100%" HeaderStyle-HorizontalAlign="Center"  HeaderStyle-Wrap="True" Settings-AllowDragDrop="False" Settings-AllowSort="False" Settings-AutoFilterCondition="Contains"/>
<dx:GridViewDataTextColumn  FieldName="EJECUCION" VisibleIndex="13" UnboundType="Decimal"  Caption="EJECUCION" HeaderStyle-HorizontalAlign="Center" PropertiesTextEdit-DisplayFormatString="c" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"/>
<dx:GridViewDataTextColumn  FieldName="ESTADO" VisibleIndex="14"  Caption="E"  HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True"/>
<dx:GridViewDataTextColumn  FieldName="ESTADO_ENVIO" VisibleIndex="15"  Caption="ER."  HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True"/>
<dx:GridViewCommandColumn  ShowClearFilterButton="true" ShowApplyFilterButton="true" VisibleIndex="15">
</dx:GridViewCommandColumn>

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




<Settings ShowFilterRow="True"     ShowGroupPanel="True"/>

<SettingsText Title="CONSULTA EXPEDIENTE"  />
<SettingsLoadingPanel Mode="ShowAsPopup" />
<SettingsBehavior EnableCustomizationWindow="true" />
<SettingsLoadingPanel Mode="ShowAsPopup" />
<Settings VerticalScrollableHeight="300" />
<%--    <SettingsPager PageSize="20">
        <PageSizeItemSettings Visible="true" ShowAllItem="true" />
    </SettingsPager>--%>
</dx:aspxgridview> 

    </div>
    </form>
</body>
</html>
