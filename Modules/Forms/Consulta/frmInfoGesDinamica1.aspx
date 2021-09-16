<%@ Page Language="C#" MasterPageFile="~/Modules/MasterPage.Master" AutoEventWireup="true" 
    CodeBehind="frmInfoGesDinamica1.aspx.cs" Inherits="InfoGesRegional.Modules.Forms.Consulta.frmInfoGesDinamica1" 
    Title="InfoGesRegional" %>


<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dxe" %>

<%@ Register assembly="DevExpress.Web.ASPxPivotGrid.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPivotGrid" tagprefix="dx" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPivotGrid.Export" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dxtc" %>

<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dxw" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style4
        {
            width: 309px;
        }
        .style5
        {
            width: 67px;
        }
        .style9
        {
            width: 212px;
        }
        .style10
        {
            width: 177px;
        }
        .style12
        {
            width: 236px;
        }
        .style13
        {
            width: 169px;
        }
        .style14
        {
            width: 148px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
     <div id="principal" >
<table dir="ltr">
<tr>
<td>
	<table>
		<tr>
		<td >
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
        </tr>
	</table>
</td>
</tr>
<tr>
<td>


        <dxtc:ASPxPageControl ID="ASPxPageControl1" runat="server" AutoPostBack="true"
        ActiveTabIndex="0" CssFilePath="~/App_Themes/Glass/Editors/styles.css" 
            CssPostfix="Glass" Height="300%" LoadingPanelText="" TabSpacing="3px" Width="1079px" OnActiveTabChanged="ASPxPageControl1auc" >
			<ContentStyle VerticalAlign="Top">
			<Border BorderColor="#AECAF0" BorderStyle="Solid" BorderWidth="1px" />
            <Border BorderStyle="Solid" BorderColor="#AECAF0" BorderWidth="1px"></Border>
			</ContentStyle>     
			<ActiveTabStyle Font-Bold="True" Font-Size="Small">
			</ActiveTabStyle>                        
			<TabPages >   
				<dxtc:TabPage Text="GASTOS" >
					<ContentCollection>
						<dxw:ContentControl ID="ContentControl13" runat="server">	

                            <dxe:ASPxLabel ID="ASPxLabel6" runat="server" Text="Fase"  Font-Bold="true"></dxe:ASPxLabel>
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server"
                                    Font-Size="X-Small" RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="C">COMPROMISO</asp:ListItem>
                                    <asp:ListItem Value="D">DEVENGADO</asp:ListItem>
                                    <asp:ListItem Value="G">GIRADO</asp:ListItem>
                                </asp:RadioButtonList>

						</dxw:ContentControl>
					</ContentCollection>
				</dxtc:TabPage> 
				<dxtc:TabPage Text="INGRESOS" >
					<ContentCollection>
						<dxw:ContentControl ID="ContentControl1" runat="server">	
												
						</dxw:ContentControl>
					</ContentCollection>
				</dxtc:TabPage>                       
				<dxtc:TabPage Text="MARCO" >
					<ContentCollection>
						<dxw:ContentControl ID="ContentControl2" runat="server">	
												
						</dxw:ContentControl>
					</ContentCollection>
				</dxtc:TabPage>                       
            </TabPages>
	    </dxtc:ASPxPageControl> 	
        					

	

    <table cellpadding="0" cellspacing="0" >
        <tr >
           <td style="border-style: groove" class="style5" ><dxe:ASPxLabel ID="ASPxLabel1" runat="server" Text="Tiempo"></dxe:ASPxLabel></td>
           <td style="border-style: groove" class="style12">
               <dxe:ASPxLabel ID="ASPxLabel2" runat="server" Text="FuncionalProgramático"></dxe:ASPxLabel></td>
           <td style="border-style: groove" class="style9" ><dxe:ASPxLabel ID="ASPxLabel3" runat="server" Text="Fuente de Financiamiento"></dxe:ASPxLabel></td>
           <td style="border-style: groove" class="style10" ><dxe:ASPxLabel ID="ASPxLabel4" runat="server" Text="Clasificador"></dxe:ASPxLabel></td>
           <td style="border-style: groove" ><dxe:ASPxLabel ID="ASPxLabel5" runat="server" Text="Ubigeo"></dxe:ASPxLabel></td>
       </tr>
        <tr>
        <td><asp:CheckBox ID="ASPxCheckPeriodo" runat="server" 
                Text="Periodo" Font-Size="Small"/></td>
        <td class="style12"><asp:CheckBox ID="ASPxCheckFuncion" runat="server" 
                Text="Función"  Font-Size="Small"/></td>
        <td class="style9"><asp:CheckBox ID="ASPxCheckRubro" runat="server" Text="Rubro"  Font-Size="Small"/></td>
        <td class="style10"><asp:CheckBox ID="ASPxCheckGenerica" runat="server" Text="Genérica"  Font-Size="Small"/></td>
        <td><asp:CheckBox ID="ASPxCheckDepartamento" runat="server" Text="Departamento"  Font-Size="Small"/></td>
        </tr>
        <tr>
        <td><asp:CheckBox ID="ASPxCheckMes" runat="server" Text="Mes"  Font-Size="Small" /></td>
        <td class="style12"><asp:CheckBox ID="ASPxCheckDFuncional" runat="server" 
                Text="División Funcional" Font-Size="Small"/></td>
        <td class="style9"></td>
        <td class="style10"><asp:CheckBox ID="ASPxCheckSGenerica" runat="server" Text="SubGenerica"  Font-Size="Small"/></td>
        <td><asp:CheckBox ID="ASPxCheckProvincia" runat="server" Text="Provincia"  Font-Size="Small"/></td>
        </tr>
        <tr>
        <td></td>
        <td class="style12"><asp:CheckBox ID="ASPxCheckGFuncional" runat="server" Text="Grupo Funcional"  Font-Size="Small"/></td>
        <td class="style9"></td>
        <td class="style10"><asp:CheckBox ID="ASPxCheckSGenericaDet" runat="server" Text="SubGenérica Det"  Font-Size="Small"/></td>
        <td><asp:CheckBox ID="ASPxCheckDistrito" runat="server" Text="Distrito"  Font-Size="Small"/></td>
        </tr>
        <tr>
        <td></td>
        <td class="style12"><asp:CheckBox ID="ASPxCheckCFuncional" runat="server" Text="Categoría Funcional"  Font-Size="Small"/></td>
        <td class="style9"></td>
        <td class="style10"><asp:CheckBox ID="ASPxCheckEspecifica" runat="server" Text="Específica"  Font-Size="Small"/></td>
        <td></td>
        </tr>
        <tr>
        <td></td>
        <td class="style12"><asp:CheckBox ID="ASPxCheckPProyecto" runat="server" Text="Producto / Proyecto"  Font-Size="Small"/></td>
        <td class="style9"></td>
        <td class="style10"><asp:CheckBox ID="ASPxCheckEspecificaD" runat="server" Text="Especifica Det"  Font-Size="Small"/></td>
        <td></td>
        </tr>
        <tr>
        <td></td>
        <td class="style12"><asp:CheckBox ID="ASPxCheckAAObra" runat="server" Text="Act./Acción de inv / Obra" Font-Size="Small"/>
        </td><td class="style9">
        </td><td class="style10">
        </td>
        <td></td></tr>
    </table>

</td>
</tr>
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
</td>
</tr>
<tr>
<td>
    <table cellpadding="0" cellspacing="0" >
        <tr>
        <td align="left">
            <dxe:ASPxButton ID="btnProcesar" runat="server" Text="Procesar Consulta" UseSubmitBehavior="False" ToolTip="Pruebas" Wrap="True" CssClass="buttonAction" OnClick="btnProcesarClick" Height="16px"   />
        </td>
        </tr>
    </table>
</td>
</tr>

<tr>
<td>
    <table><tr><td>
        <dx:ASPxPivotGrid ID="ASPxPivotGridDinamica" runat="server" Visible="False" onLoad="LoadASPxPivotGrid" ClientIDMode="AutoID"  EnablePagingGestures="False"  >
        <OptionsPager RowsPerPage="30" />
        <OptionsView ShowHorizontalScrollBar="True" ShowFilterHeaders="False" />
        </dx:ASPxPivotGrid>
        <dx:ASPxPivotGridExporter ID="ASPxPivotGridExporter1" runat="server" ASPxPivotGridID="ASPxPivotGridDinamica" Visible="False" OptionsPrint-MergeRowFieldValues="True" />
    </td></tr>
    </table>
</td>
</tr>
</table>  </div>    
</asp:Content>
