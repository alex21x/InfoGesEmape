<%@ Page Language="C#" MasterPageFile="~/Modules/MasterPage.Master" AutoEventWireup="true" 
    CodeBehind="frmInfoGesDinamica.aspx.cs" Inherits="InfoGesRegional.Modules.Forms.Consulta.frmInfoGesDinamica" 
    Title="InfoGesConsultas" %>


<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>

<%@ Register assembly="DevExpress.Web.ASPxPivotGrid.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPivotGrid" tagprefix="dx" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPivotGrid.Export" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTabControl" tagprefix="dxtc" %>    

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style4
        {
            width: 309px;
        }
        .style5
        {
            width: 88px;
        }
        .style8
        {
            width: 195px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
     <div id="principal" >

     <table>
<tr>
<td>
<table><tr>
<td class="style19">
<dxtc:ASPxTabControl ID="ASPxTabControleJEjecutora" runat="server" AutoPostBack="True" 
        DataSourceID="XmlDataSource2"  
        OnActiveTabChanged="ASPxPageControl1_ActiveTabChanged1"
        ActiveTabStyle-Font-Size="Large" TabStyle-Wrap="True" Width="248px" 
        CssFilePath="~/App_Themes/Glass/Web/styles.css" CssPostfix="Glass" >
<Paddings Padding="0" />

<ActiveTabStyle Font-Size="Large" Wrap="True"></ActiveTabStyle>

<TabStyle Wrap="True"></TabStyle>
    </dxtc:ASPxTabControl>
<asp:XmlDataSource ID="XmlDataSource2" runat="server" DataFile=""  XPath="//ejecutora" EnableCaching="false"></asp:XmlDataSource>
</td>
<td align="right" class="style18">
<dxtc:ASPxTabControl ID="tcDemos" runat="server" DataSourceID="XmlDataSource1"  AutoPostBack="true" 
        OnActiveTabChanged="ASPxPageControl1_ActiveTabChanged" 
        ActiveTabStyle-Font-Size="XX-Large" TabIndex="0" CssFilePath="~/App_Themes/Glass/Web/styles.css" 
        CssPostfix="Glass" EnableDefaultAppearance="False" RightToLeft="True" 
        Width="193px">
<Paddings Padding="0" />
    </dxtc:ASPxTabControl>
<asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile=""  XPath="//product"  ></asp:XmlDataSource>
</td>
</tr></table>
</td>
</tr>
</table>


   <table cellpadding="0" cellspacing="0" width="100%" >
   <tr align="center">
   <td style="border-style: groove" class="style5" ><dxe:ASPxLabel ID="ASPxLabel1" runat="server" Text="Tiempo"></dxe:ASPxLabel></td>
   <td style="border-style: groove" class="style8">
       <dxe:ASPxLabel ID="ASPxLabel2" runat="server" Text="Gasto"></dxe:ASPxLabel></td>
   <td style="border-style: groove" ><dxe:ASPxLabel ID="ASPxLabel3" runat="server" Text="Financiamiento"></dxe:ASPxLabel></td>
   <td style="border-style: groove" ><dxe:ASPxLabel ID="ASPxLabel4" runat="server" Text="Estructura"></dxe:ASPxLabel></td>
   <td style="border-style: groove" ><dxe:ASPxLabel ID="ASPxLabel5" runat="server" Text="Donde"></dxe:ASPxLabel></td>
   </tr>
        <tr>
        <td class="style5">
            <dxe:ASPxCheckBox ID="ASPxCheckPeriodo" runat="server" 
                Text="Periodo">
                </dxe:ASPxCheckBox></td>
        <td class="style8">
            <dxe:ASPxCheckBox ID="ASPxCheckFuncion" runat="server" 
                Text="Función" CheckState="Unchecked"></dxe:ASPxCheckBox></td>
        <td><dxe:ASPxCheckBox ID="ASPxCheckRubro" runat="server" Text="Rubro"></dxe:ASPxCheckBox></td>
        <td><dxe:ASPxCheckBox ID="ASPxCheckGenerica" runat="server" Text="Genérica"></dxe:ASPxCheckBox></td>
        <td><dxe:ASPxCheckBox ID="ASPxCheckDepartamento" runat="server" 
                Text="Departamento"></dxe:ASPxCheckBox></td>
        </tr>
        <tr>
        <td class="style5">
            <dxe:ASPxCheckBox ID="ASPxCheckMes" runat="server" Text="Mes"></dxe:ASPxCheckBox></td>
        <td class="style8">
            <dxe:ASPxCheckBox ID="ASPxCheckDFuncional" runat="server" 
                Text="División Funcional"></dxe:ASPxCheckBox></td>
        <td></td>
        <td><dxe:ASPxCheckBox ID="ASPxCheckSGenerica" runat="server" Text="SubGenerica"></dxe:ASPxCheckBox></td>
        <td><dxe:ASPxCheckBox ID="ASPxCheckProvincia" runat="server" Text="Provincia"></dxe:ASPxCheckBox></td>
        </tr>
        <tr>
        <td class="style5"></td>
        <td class="style8">
            <dxe:ASPxCheckBox ID="ASPxCheckGFuncional" runat="server" 
                Text="Grupo Funcional"></dxe:ASPxCheckBox></td>
        <td></td>
        <td><dxe:ASPxCheckBox ID="ASPxCheckSGenericaDet" runat="server" 
                Text="SubGenérica Det"></dxe:ASPxCheckBox></td>
        <td><dxe:ASPxCheckBox ID="ASPxCheckDistrito" runat="server" Text="Distrito"></dxe:ASPxCheckBox></td>
        </tr>
        <tr>
        <td class="style5"></td>
        <td class="style8">
            <dxe:ASPxCheckBox ID="ASPxCheckCFuncional" runat="server" 
                Text="Categoría Funcional"></dxe:ASPxCheckBox></td>
        <td></td>
        <td><dxe:ASPxCheckBox ID="ASPxCheckEspecifica" runat="server" Text="Específica"></dxe:ASPxCheckBox></td>
        <td></td>
        </tr>
        <tr>
        <td class="style5"></td>
        <td class="style8">
            <dxe:ASPxCheckBox ID="ASPxCheckPProyecto" runat="server" 
                Text="Producto / Proyecto"></dxe:ASPxCheckBox></td>
        <td></td>
        <td><dxe:ASPxCheckBox ID="ASPxCheckEspecificaD" runat="server" 
                Text="Especifica Det"></dxe:ASPxCheckBox></td>
        <td></td>
        </tr>
        <tr>
        <td class="style5"></td>
        <td class="style8">
            <dxe:ASPxCheckBox ID="ASPxCheckAAObra" runat="server" 
                Text="Act./Acción de inv / Obra"></dxe:ASPxCheckBox>
        </td><td>
        </td><td>
        </td><td>
        </td></tr>
    </table>
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
       <table cellpadding="0" cellspacing="0" >
        <tr><td align="left">
            <dxe:ASPxButton ID="btnProcesar" runat="server" Text="Procesar Consulta" UseSubmitBehavior="False" ToolTip="Pruebas" Wrap="True" CssClass="buttonAction" OnClick="btnProcesarClick" Height="16px"   />
        </td></tr></table>
        <table><tr><td>
            <dx:ASPxPivotGrid ID="ASPxPivotGridDinamica" runat="server" Visible="false" 
                onLoad="LoadASPxPivotGrid" >
                <Styles CssFilePath="~/App_Themes/Glass/PivotGrid/styles.css" 
                    CssPostfix="Glass">
                </Styles>
            </dx:ASPxPivotGrid>
            <dx:ASPxPivotGridExporter ID="ASPxPivotGridExporter1" runat="server" ASPxPivotGridID="ASPxPivotGridDinamica" Visible="False" />
        </td></tr></table>
  </div>    
</asp:Content>
