<%@ Page Language="C#" MasterPageFile="~/Modules/MasterPage.Master" AutoEventWireup="true" CodeBehind="frmInfoGesGSOSAmortizacion.aspx.cs" Inherits="InfogesEmape.Modules.Forms.Seguimiento.frmInfoGesGSOSAmortizacion" %>


<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>


<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    
     <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" AutoPostBack="true"
            ActiveTabIndex="0" Height="300%" TabSpacing="3px"  Font-Size="X-Small" 
            Width="100%">
	        <ActiveTabStyle Font-Bold="True" Font-Size="Small">
	        </ActiveTabStyle>                        
	        <TabPages >   
		        <dx:TabPage Text="REGISTRO DE PROYECTO." >
			        <ContentCollection>
				        <dx:ContentControl ID="ContentControl13" runat="server">	
                            <table>
                                <tr>
                                    <td >

                        <dx:ASPxGridView ID="GridProyectoContrato" runat="server"  Width="100%"  Visible="true" KeyFieldName="IDCONTRATO"
    OnLoad="OnLoadProyectoContrato" >
    <Columns> 
    <dx:GridViewDataTextColumn FieldName="CONTRATO_NUMERO" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="80px"
    Caption="NÚMERO CONTRATO" VisibleIndex="0" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  >
<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>

<CellStyle HorizontalAlign="Right"></CellStyle>
    </dx:GridViewDataTextColumn> 
    <dx:GridViewBandColumn  Caption="EMPRESA"  VisibleIndex="1" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" >
<HeaderStyle HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>
    <Columns>
    <dx:GridViewDataTextColumn FieldName="RUC" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="80px"
    Caption="RUC" VisibleIndex="2" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  >
<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>

<CellStyle HorizontalAlign="Right"></CellStyle>
    </dx:GridViewDataTextColumn> 
    <dx:GridViewDataTextColumn FieldName="EMPRESA" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="680px"
    Caption="NOMBRE" VisibleIndex="3" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  >
<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>

<CellStyle HorizontalAlign="Center"></CellStyle>
    </dx:GridViewDataTextColumn> 
    </Columns>
    </dx:GridViewBandColumn>
    <dx:GridViewBandColumn Caption="CONTRATO"  VisibleIndex="2" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" >
<HeaderStyle HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>
    <Columns>
    <dx:GridViewDataDateColumn FieldName="FECHA_CONTRATO" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="100px"
    Caption="FECHA CONTRATO" VisibleIndex="4" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>

<CellStyle HorizontalAlign="Right"></CellStyle>
    </dx:GridViewDataDateColumn>
    <dx:GridViewDataTextColumn FieldName="MONTO_OBRA" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="100px"
    Caption="IMPORTE OBRA" VisibleIndex="6" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>

<CellStyle HorizontalAlign="Right"></CellStyle>
    </dx:GridViewDataTextColumn>
    <dx:GridViewDataTextColumn FieldName="PLAZO_EJECUCION_OBRA" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="100px"
    Caption="PLAZO EJECUCIÓN" VisibleIndex="7" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>

<CellStyle HorizontalAlign="Right"></CellStyle>
    </dx:GridViewDataTextColumn>
    <dx:GridViewBandColumn Caption="INICIO DE OBRA"  VisibleIndex="5" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" >
<HeaderStyle HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>
    <Columns>
    <dx:GridViewDataDateColumn FieldName="FECHA_INICIO_OBRA" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="100px"
    Caption="FECHA INI. OBR." VisibleIndex="7" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>

<CellStyle HorizontalAlign="Right"></CellStyle>
    </dx:GridViewDataDateColumn>
    <dx:GridViewDataDateColumn FieldName="FECHA_INICIO_OBRA_MAXIMO" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="100px"
    Caption="FECHA INI. OBR. MAX." VisibleIndex="8" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>

<CellStyle HorizontalAlign="Right"></CellStyle>
    </dx:GridViewDataDateColumn>
    </Columns>
    </dx:GridViewBandColumn>
    </Columns>
    </dx:GridViewBandColumn>
    <dx:GridViewBandColumn   Caption="ENTREGA DE TERRENO"  VisibleIndex="3" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  HeaderStyle-Wrap="True">
<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>
    <Columns>
    <dx:GridViewDataDateColumn FieldName="FECHA_ENTREGA_TERRENO" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"
    Caption="FECHA ENT. TERRE." VisibleIndex="15" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>

<CellStyle HorizontalAlign="Right"></CellStyle>
    </dx:GridViewDataDateColumn>
    <dx:GridViewDataDateColumn   visible="false" FieldName="FECHA_ENTREGA_TERRENO_LIMITE" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"
    Caption="FECHA ENT. TERR. LIM." VisibleIndex="16" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
<Settings AllowAutoFilter="False" AllowHeaderFilter="False"></Settings>

<HeaderStyle HorizontalAlign="Center" Wrap="True" Font-Bold="True"></HeaderStyle>

<CellStyle HorizontalAlign="Right"></CellStyle>
    </dx:GridViewDataDateColumn>
    <dx:GridViewDataComboBoxColumn Caption="ESTADO CONTRATO" FieldName="DESCRIPCION_ESTADO_CONTRATO" VisibleIndex="17" HeaderStyle-HorizontalAlign="Center"  Width="60px"
            Settings-AllowSort="False" Settings-AllowDragDrop="False" Settings-FilterMode="Value" EditFormSettings-Visible="True">
        <PropertiesComboBox TextField="DESCRIPCION_ESTADO_CONTRATO" ValueField="IDESTADO_CONTRATO" ></PropertiesComboBox>

<Settings AllowDragDrop="False" AllowSort="False"></Settings>

<EditFormSettings Visible="True"></EditFormSettings>

        <HeaderStyle HorizontalAlign="Center" />
    </dx:GridViewDataComboBoxColumn>
    </Columns>
    </dx:GridViewBandColumn>
        <dx:GridViewDataTextColumn Caption="LINK" FieldName="CONTRATO_NUMERO" ShowInCustomizationForm="True" VisibleIndex="4" Visible="False">
            <HeaderStyle HorizontalAlign="Center" />
            <DataItemTemplate>
                <a id="LinkButton1"  href="frmInfoGesGsoProyectoRegistroCoordinador.aspx?pOpera=edit&amp;pId=<%# Session["pIdProyecto"]%>">IR A VALORIZACIÓN</a>												
            </DataItemTemplate>
        </dx:GridViewDataTextColumn>
    </Columns>
    <SettingsBehavior AllowFocusedRow="True" />
    <SettingsEditing Mode="PopupEditForm" EditFormColumnCount="2" />
    </dx:ASPxGridView>  
    

 </td>
             </tr>
                                <tr>
                                    <td><br /><br />

        <dx:ASPxGridView ID="GridProyectoContratoCon" runat="server" KeyFieldName="IDCONTRATOSEGUIMIENTO" OnHtmlRowPrepared="GridProyectoContratoCon_HtmlRowPrepared" OnLoad="OnloadProyectoContratoCon" OnRowUpdating="OnRowUpdatingProyectoContratoCon" OnRowValidating="GridProyectoProyectoContratoCon_RowValidating" OnStartRowEditing="GridProyectoContratoCon_StartRowEditing" Width="100%" AutoGenerateColumns="False" OnHtmlCommandCellPrepared="comando" Theme="Office2010Blue">
		<Columns>
			<dx:GridViewCommandColumn ShowEditButton="true" VisibleIndex="0" Width="50px" >			
				<HeaderStyle Font-Bold="False" />
			</dx:GridViewCommandColumn>
			<dx:GridViewDataTextColumn Caption="N#" CellStyle-HorizontalAlign="Right" EditFormSettings-Visible="False" FieldName="SEGUIMIENTO_CRONOGRAMA" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True" PropertiesTextEdit-DisplayFormatString="##" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False" VisibleIndex="1" Width="50px">
				<PropertiesTextEdit DisplayFormatString="##"></PropertiesTextEdit>
				<Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
				<EditFormSettings Visible="True" />
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
				<CellStyle HorizontalAlign="Right">
				</CellStyle>
			</dx:GridViewDataTextColumn>
			<dx:GridViewDataDateColumn Caption="FECHA" CellStyle-HorizontalAlign="Right" FieldName="SEGUIMIENTO_FECHA" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False" VisibleIndex="2" Width="60px">
				<Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
				<CellStyle HorizontalAlign="Right">
				</CellStyle>
			</dx:GridViewDataDateColumn>
			<dx:GridViewDataTextColumn Caption="%" CellStyle-HorizontalAlign="Right" FieldName="AVANCE" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True" PropertiesTextEdit-DisplayFormatString="{0}%" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False" VisibleIndex="3" Width="60px">
				<PropertiesTextEdit DisplayFormatString="{0}%"></PropertiesTextEdit>
				<Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
				<EditFormSettings Visible="False" />
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
				<CellStyle HorizontalAlign="Right">
				</CellStyle>
			</dx:GridViewDataTextColumn>
			<dx:GridViewDataCheckColumn Caption="APROBADO" FieldName="APROBADO" VisibleIndex="7" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="True" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False" Width="60px" Visible="False">
			    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
			</dx:GridViewDataCheckColumn>
			<dx:GridViewDataTextColumn Caption="MONTO" FieldName="MONTO_OBRA" VisibleIndex="4" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center">
				<EditFormSettings Visible="False" />
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
			</dx:GridViewDataTextColumn>

			<dx:GridViewDataTextColumn Caption="FP" FieldName="SEGUIMIENTO_CRONOGRAMA" VisibleIndex="8" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center">
                <EditFormSettings Visible="False" />
                
            	<HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
            </dx:GridViewDataTextColumn>

			<dx:GridViewDataTextColumn Caption="IDCONTRATOSEGUIMIENTO" FieldName="IDCONTRATOSEGUIMIENTO" Visible="False" VisibleIndex="9">
			</dx:GridViewDataTextColumn>

		    <dx:GridViewDataTextColumn FieldName="TOTALPRESUPUESTO" Visible="False" VisibleIndex="10">
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>

			<dx:GridViewDataTextColumn Caption="A. DIRECTO" FieldName="ADELANTO_DIRECTO" ShowInCustomizationForm="True" VisibleIndex="5">
				<HeaderStyle Font-Bold="True" />
				<CellStyle Font-Bold="True">
				</CellStyle>
			</dx:GridViewDataTextColumn>
			<dx:GridViewDataTextColumn Caption="A. MATERIALES" FieldName="ADELANTO_MATERIALES" ShowInCustomizationForm="True" VisibleIndex="6">
				<HeaderStyle Font-Bold="True" />
				<CellStyle Font-Bold="True">
				</CellStyle>
			</dx:GridViewDataTextColumn>

		</Columns>		
                                            
		
		<Settings ShowTitlePanel="true" />
		<SettingsText Title="CONTRATISTA" />
        </dx:ASPxGridView>                                            

                                    </td>
                                </tr>
                                </table>
                            </dx:ContentControl>
			        </ContentCollection>
		        </dx:TabPage>                                             
            </TabPages>
        </dx:ASPxPageControl>     

</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style3 {
            margin-left: 0px;
        }
    </style>
</asp:Content>

