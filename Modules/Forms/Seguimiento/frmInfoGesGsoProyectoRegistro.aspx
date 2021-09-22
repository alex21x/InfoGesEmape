<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Modules/MasterPage.Master"
CodeBehind="frmInfoGesGsoProyectoRegistro.aspx.cs" Inherits="InfogesEmape.Modules.Forms.Seguimiento.frmInfoGesGsoProyectoRegistro" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.XtraReports.v17.1.Web, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript">
        function OnMoreInfoClick(contentUrl) {
            clientPopupControl.SetContentUrl(contentUrl);
            clientPopupControl.Show();
        }
    </script>  
    <style type="text/css">
        body
        {
            
        }
        .outer
        {
            width: 100%;
            border: solid 1px gray;
            padding: 1px;
        }
        .inner
        {
            border: solid 1px gray;
            width: 70%;
            margin-left: auto;
            margin-right: auto;
        }
        .auto-style3 {
            width: 565px;
        }
        .auto-style5 {
            height: 346px;
        }
        .auto-style6 {
            width: 565px;
            height: 22px;
        }
        .auto-style7 {
            height: 22px;
        }
        .auto-style9 {
            width: 152px;
        }
        .auto-style12 {
            width: 124px;
        }
    </style>
     <div id="principal"  class="inner">
        <asp:ScriptManager ID="ScriptManager1" runat="server" >
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Always">
        <ContentTemplate>          
        <asp:UpdateProgress ID="UpdateProgress1" runat="server"  AssociatedUpdatePanelID="UpdatePanel4" DisplayAfter="0">
        <ProgressTemplate>
            <img alt="procesando..."  src="../../../Images/ajax-loader.gif"/></ProgressTemplate>
         </asp:UpdateProgress>  
        <table>
        <tr>
        <td>
        <table>
        <tr>
        <td><dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="CUI : "  Font-Size="Large"> </dx:ASPxLabel></td>
        <td><dx:ASPxTextBox ID="txtCUI" runat="server" Width="80px"  Font-Size="Large"> </dx:ASPxTextBox></td>
        <td><dx:ASPxMemo ID="txtDescripcion" runat="server" Font-Size="Large" AutoResizeWithContainer="true" Width="420%"></dx:ASPxMemo></td>
        </tr>
        </table>
        </td>
        </tr>
        <tr>
        <td>

        <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" AutoPostBack="True" 
                ActiveTabIndex="3" Height="100%" TabSpacing="3px"  Font-Size="Medium" 
                Width="100%" TabStyle-VerticalAlign="Bottom"  TabAlign="Justify" OnActiveTabChanged="ASPxPageControl1_ActiveTabChanged" >
	        <ActiveTabStyle Font-Bold="True" Font-Size="Large" ForeColor="Azure" >
	        </ActiveTabStyle>                        
	        <TabPages >   
		        <dx:TabPage Text="REGISTRO CONTRATO."  Name="Page1">
			        <ContentCollection>
				        <dx:ContentControl ID="ContentControl13" runat="server">	
                        <table>
                            <tr><td colspan="6"> <br> </td></tr>
                            <tr>
                            <td align="center"><dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="ABREVIATURA"/> </td>
                            <td align="center"><dx:ASPxLabel ID="ASPxLabel11" runat="server" Text="PAQUETE"/></td>
                            <td align="center"><dx:ASPxLabel ID="ASPxLabel17" runat="server" Text="ACTIVIDAD"/></td>
                            <td align="center"><dx:ASPxLabel ID="ASPxLabel18" runat="server" Text="TIPO PROYECTO EMAPE" Wrap="True"/></td>
                            <td align="center"><dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="EXP. TECNICO"></dx:ASPxLabel></td>
                            <td></td>
                            </tr>
                            <tr>
                            <td align="center"><dx:ASPxTextBox ID="txtAbreviatura" runat="server" Width="140px"></dx:ASPxTextBox></td>
                            <td align="center"><dx:ASPxComboBox ID="CboPaquete" runat="server" ValueType="System.String"  Width="140px"> </dx:ASPxComboBox> </td>
                            <td align="center"><dx:ASPxComboBox ID="CboActividad" runat="server" ValueType="System.String"  Width="140px"> </dx:ASPxComboBox></td>
                            <td align="center"><dx:ASPxComboBox ID="CboTipoProyecto" runat="server" ValueType="System.String" Width="160px"> </dx:ASPxComboBox></td>
                            <td align="center"><dx:ASPxTextBox ID="txtExpedienteTecnico" runat="server" Width="140px"  HorizontalAlign="Right" ></dx:ASPxTextBox></td>
                            <td></td>

                            </tr>
                            <tr><td colspan="6"> <br> </td></tr>
                            <tr>

                            <td align="center"><dx:ASPxLabel ID="ASPxLabel6" runat="server" Text="MONTO DE OBRA"></dx:ASPxLabel></td>
                            <td align="center"><dx:ASPxLabel ID="ASPxLabel7" runat="server" Text="SUPERVISIÓN"></dx:ASPxLabel></td>
                            <td align="center"><dx:ASPxLabel ID="ASPxLabel8" runat="server" Text="INTERFERENCIA"></dx:ASPxLabel></td>
                            <td align="center"><dx:ASPxLabel ID="ASPxLabel9" runat="server" Text="GESTION PROYECTO"></dx:ASPxLabel></td>
                            <td align="center"><dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="TERRENO"></dx:ASPxLabel></td>
                            <td align="center"><dx:ASPxLabel ID="ASPxLabel10" runat="server" Text="MOBILIARIO"></dx:ASPxLabel></td>
                            </tr>
                            <tr>
                            <td align="center"><dx:ASPxTextBox ID="txtObra" runat="server" Width="140px" HorizontalAlign="Right"></dx:ASPxTextBox></td>
                            <td align="center"><dx:ASPxTextBox ID="txtSupervision" runat="server" Width="140px" HorizontalAlign="Right"></dx:ASPxTextBox></td>
                            <td align="center"><dx:ASPxTextBox ID="txtInterferencia" runat="server" Width="140px"  HorizontalAlign="Right"></dx:ASPxTextBox></td>
                            <td align="center"><dx:ASPxTextBox ID="txtGestionProyecto" runat="server" Width="140px"  HorizontalAlign="Right"></dx:ASPxTextBox></td>
                            <td align="center"><dx:ASPxTextBox ID="txtTerreno" runat="server" Width="140px"  HorizontalAlign="Right"></dx:ASPxTextBox></td>
                            <td align="center"><dx:ASPxTextBox ID="txtMobiliario" runat="server" Width="140px"  HorizontalAlign="Right"></dx:ASPxTextBox></td>
                            </tr>
                            <tr><td colspan="6"> <br> </td></tr>


                            <tr>
                            <td align="center"><dx:ASPxLabel ID="ASPxLabel12" runat="server" Text="COORD. INICIO NORTE"></dx:ASPxLabel></td>
                            <td align="center"><dx:ASPxLabel ID="ASPxLabel13" runat="server" Text="COORD. INICIO ESTE"></dx:ASPxLabel></td>
                            <td align="center"><dx:ASPxLabel ID="ASPxLabel14" runat="server" Text="COORD. FIN NORTE"></dx:ASPxLabel></td>
                            <td align="center"><dx:ASPxLabel ID="ASPxLabel15" runat="server" Text="COORD. FIN ESTE"></dx:ASPxLabel></td>
                            <td align="center"><dx:ASPxLabel ID="ASPxLabel16" runat="server" Text="DISTRITO"></dx:ASPxLabel></td>
                            <td align="center"></td>
                            <td></td>
                            </tr>
                            <tr>
                            <td align="center"><dx:ASPxTextBox ID="txtCoorInicionorte" runat="server" Width="140px"  HorizontalAlign="Right"></dx:ASPxTextBox></td>
                            <td align="center"><dx:ASPxTextBox ID="txtcoorInicioEste" runat="server" Width="140px"  HorizontalAlign="Right"></dx:ASPxTextBox></td>
                            <td align="center"><dx:ASPxTextBox ID="txtCoorFinNorte" runat="server" Width="140px"  HorizontalAlign="Right"></dx:ASPxTextBox></td>
                            <td align="center"><dx:ASPxTextBox ID="txtCoorFinEste" runat="server" Width="140px"  HorizontalAlign="Right"></dx:ASPxTextBox></td>
                            <td align="center"><dx:ASPxTextBox ID="txtDistrito" runat="server" Width="140px"  HorizontalAlign="Left"></dx:ASPxTextBox></td>
                            <td align="center">
                                <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Grabar"  OnClick="btnSave_Click">
                                </dx:ASPxButton>
                                <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Cerrar"  OnClick="btnClose_Click">
                                </dx:ASPxButton>
                            </td>
                            </tr>
                            <tr><td colspan="6"> <br> </td></tr>
                            <tr><td colspan="6" bgcolor="#0099CC"> <br> </td></tr>
                            <tr><td colspan="6"> <br> </td></tr>
                        </table>
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
		        <dx:TabPage Text="META ANUAL." Visible="false"   Name="Page2" >
			        <ContentCollection>
				        <dx:ContentControl ID="ContentControl2" runat="server">	
                        <table>
                        <tr>

                            <td colspan="6" align="center">
                                <dx:ASPxGridView ID="GridProyectoMeta" runat="server" Visible="false" KeyFieldName="IDPROYECTO_DETALLE"
                                OnLoad="OnLoadProyectoMeta" OnRowUpdating="OnRowUpdatingProyectoMeta" OnRowInserting="OnRowInsertingProyectoMeta" Width="100%">
                                <Columns>
                                <dx:GridViewCommandColumn ShowNewButton="true" ShowEditButton="true" VisibleIndex="0" Width="60px"/>
                                <dx:GridViewDataTextColumn FieldName="PERIODO" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  PropertiesTextEdit-Width="30%" 
                                Caption="PERIODO" VisibleIndex="1" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  PropertiesTextEdit-DisplayFormatString="#,#">
                                    <PropertiesTextEdit DisplayFormatString="#,#" Width="30%">
                                    </PropertiesTextEdit>
                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                <EditCellStyle HorizontalAlign="Right"></EditCellStyle>
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
                                </dx:GridViewDataTextColumn>  
                                <dx:GridViewBandColumn Caption="META POR PERIODO"  VisibleIndex="2" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" >
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
                                <Columns>
                                <dx:GridViewDataTextColumn FieldName="META_OBRA" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="80px" PropertiesTextEdit-Width="50%" 
                                Caption="OBRA" VisibleIndex="3" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  PropertiesTextEdit-DisplayFormatString="#,#">
                                    <PropertiesTextEdit DisplayFormatString="#,#" Width="50%">
                                    </PropertiesTextEdit>
                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </dx:GridViewDataTextColumn>  
                                <dx:GridViewDataTextColumn FieldName="META_SUPERVISION" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="80px" PropertiesTextEdit-Width="50%"
                                Caption="SUPERVISION" VisibleIndex="3" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  PropertiesTextEdit-DisplayFormatString="#,#"  >
                                    <PropertiesTextEdit DisplayFormatString="#,#" Width="50%">
                                    </PropertiesTextEdit>
                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </dx:GridViewDataTextColumn>  
                                <dx:GridViewDataTextColumn FieldName="META_EXP_TECNICO" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="80px" PropertiesTextEdit-Width="50%"
                                Caption="EXP. TÉCNICO" VisibleIndex="3" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  PropertiesTextEdit-DisplayFormatString="#,#"  >
                                    <PropertiesTextEdit DisplayFormatString="#,#" Width="50%">
                                    </PropertiesTextEdit>
                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </dx:GridViewDataTextColumn>  
                                <dx:GridViewDataTextColumn FieldName="META_INTERFERENCIA" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="80px" PropertiesTextEdit-Width="50%"
                                Caption="INTERFERENCIA" VisibleIndex="3" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  PropertiesTextEdit-DisplayFormatString="#,#"  >
                                    <PropertiesTextEdit DisplayFormatString="#,#" Width="50%">
                                    </PropertiesTextEdit>
                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </dx:GridViewDataTextColumn>  
                                <dx:GridViewDataTextColumn FieldName="META_GESTION_PROYECTO" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="80px" PropertiesTextEdit-Width="50%"
                                Caption="GESTION PROYECTO" VisibleIndex="3" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  PropertiesTextEdit-DisplayFormatString="#,#"  >
                                    <PropertiesTextEdit DisplayFormatString="#,#" Width="50%">
                                    </PropertiesTextEdit>
                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </dx:GridViewDataTextColumn>  
                                <dx:GridViewDataTextColumn FieldName="META_TERRENO" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="80px" PropertiesTextEdit-Width="50%"
                                Caption="TERRENO" VisibleIndex="3" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  PropertiesTextEdit-DisplayFormatString="#,#"  >
                                    <PropertiesTextEdit DisplayFormatString="#,#" Width="50%">
                                    </PropertiesTextEdit>
                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </dx:GridViewDataTextColumn>  
                                <dx:GridViewDataTextColumn FieldName="META_MOBILIARIO" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="80px" PropertiesTextEdit-Width="50%"
                                Caption="MOBILIARIO" VisibleIndex="3" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  PropertiesTextEdit-DisplayFormatString="#,#"  >
                                    <PropertiesTextEdit DisplayFormatString="#,#" Width="50%">
                                    </PropertiesTextEdit>
                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </dx:GridViewDataTextColumn>  
                                <dx:GridViewDataTextColumn FieldName="META_MITIGACION_AMBIENTAL" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="80px" PropertiesTextEdit-Width="50%"
                                Caption="MITIGACIÓN AMBIENTAL" VisibleIndex="3" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  PropertiesTextEdit-DisplayFormatString="#,#"  >
                                    <PropertiesTextEdit DisplayFormatString="#,#" Width="50%">
                                    </PropertiesTextEdit>
                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </dx:GridViewDataTextColumn>  
                                <dx:GridViewDataTextColumn FieldName="META_FISICA_PROYECTADA" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="80px" PropertiesTextEdit-Width="50%"
                                Caption="FISICA PROYECTADA" VisibleIndex="3" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  PropertiesTextEdit-DisplayFormatString="#,#"  >
                                    <PropertiesTextEdit DisplayFormatString="#,#" Width="50%">
                                    </PropertiesTextEdit>
                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </dx:GridViewDataTextColumn> 
                                </Columns>
                                </dx:GridViewBandColumn>
                                  </Columns>
                            <SettingsBehavior AllowFocusedRow="True" />
                            <SettingsEditing Mode="PopupEditForm" EditFormColumnCount="2" />
                                </dx:ASPxGridView>
                            </td>
                            </tr>
                        </table>

                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
		        <dx:TabPage Text="COMPONENTE DE OBRA"  Name="Page3" >
			        <ContentCollection>
				        <dx:ContentControl ID="ContentControl4" runat="server">	
                        <table>
                        
                                <tr>
                                    <td align="center">
                                        <dx:ASPxGridView ID="GridProyectoComponente" runat="server" 
                                            AutoGenerateColumns="False" KeyFieldName="IDPROYECTOCOMPONENTE" 
                                            OnCellEditorInitialize="EditorInitializeProyectoComponente" 
                                            OnLoad="OnLoadProyectoComponente" 
                                            OnRowInserting="OnRowInsertingProyectoComponente" 
                                            OnRowUpdating="OnRowUpdatingProyectoComponente" 
                                            OnRowValidating="OnRowProyectoComponenteValidating" 
                                            OnStartRowEditing="OnStartRowEditingProyectoComponente" Visible="False" 
                                            Width="100%">
                                            <SettingsEditing Mode="PopupEditForm">
                                            </SettingsEditing>
                                             <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True"/>
                                            <Columns>
                                                <dx:GridViewCommandColumn ShowEditButton="True" ShowInCustomizationForm="True"  Visible="false"
                                                    ShowNewButton="True" VisibleIndex="0" Width="80px">
                                                </dx:GridViewCommandColumn>
                                                <dx:GridViewDataComboBoxColumn Caption="COMPONENTE" 
                                                    FieldName="DESCRIPCION_COMPONENTE" ShowInCustomizationForm="True" 
                                                    VisibleIndex="1">
                                                    <PropertiesComboBox TextField="DESCRIPCION_COMPONENTE" 
                                                        ValueField="IDCOMPONENTE">
                                                    </PropertiesComboBox>
                                                    <Settings AllowDragDrop="False" AllowSort="False" />
                                                    <EditFormSettings Visible="True" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </dx:GridViewDataComboBoxColumn>
                                                <dx:GridViewBandColumn Caption="FECHA DE LOS PROCESOS" 
                                                    ShowInCustomizationForm="True" VisibleIndex="2">
                                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
                                                    <Columns>
                                                        <dx:GridViewDataDateColumn Caption="CONVOCATORIA" 
                                                            FieldName="FECHA_CONVOCATORIA" ShowInCustomizationForm="True" VisibleIndex="2" 
                                                            Width="80px">
                                                            <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                                            <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                        </dx:GridViewDataDateColumn>
                                                        <dx:GridViewDataDateColumn Caption="ESTIMADA BUENA PRO" 
                                                            FieldName="FECHA_ESTIMADA_BUENA_PRO" ShowInCustomizationForm="True" 
                                                            VisibleIndex="3" Width="80px">
                                                            <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                                            <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                        </dx:GridViewDataDateColumn>
                                                        <dx:GridViewDataDateColumn Caption="ESTIMADA CONSENTIMIENTO" 
                                                            FieldName="FECHA_CONSENTIMIENTO_BUENA_PRO" ShowInCustomizationForm="True" 
                                                            VisibleIndex="4" Width="80px">
                                                            <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                                            <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                        </dx:GridViewDataDateColumn>
                                                        <dx:GridViewDataDateColumn Caption="ESTIMADA CONTRATO" 
                                                            FieldName="FECHA_ESTIMADA_CONTRATO" ShowInCustomizationForm="True" 
                                                            VisibleIndex="5" Width="80px">
                                                            <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                                            <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                        </dx:GridViewDataDateColumn>
                                                        <dx:GridViewDataDateColumn Caption="ESTIMADA INICIO" 
                                                            FieldName="FECHA_ESTIMADA_INICIO" ShowInCustomizationForm="True" 
                                                            VisibleIndex="5" Width="80px">
                                                            <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                                            <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                        </dx:GridViewDataDateColumn>
                                                        <dx:GridViewDataDateColumn Caption="ENTREGA DE TERRENO" 
                                                            FieldName="FECHA_ENTREGA_TERRENO" ShowInCustomizationForm="True" 
                                                            VisibleIndex="5" Width="80px">
                                                            <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                                            <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                        </dx:GridViewDataDateColumn>
                                                    </Columns>
                                                </dx:GridViewBandColumn>
                                                <dx:GridViewDataTextColumn Caption="TIEMPO DE EJECUCIÓN" 
                                                    FieldName="TIEMPO_EJECUCION" ShowInCustomizationForm="True" VisibleIndex="6" 
                                                    Width="80px">
                                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                                    <CellStyle HorizontalAlign="Right">
                                                    </CellStyle>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataComboBoxColumn Caption="ESTADO REGISTRO" 
                                                    FieldName="DESCRIPCION_ESTADO_COMPONENTE" ShowInCustomizationForm="True" 
                                                    VisibleIndex="7">
                                                    <PropertiesComboBox TextField="DESCRIPCION_ESTADO_COMPONENTE" 
                                                        ValueField="IDESTADO_COMPONENTE">
                                                    </PropertiesComboBox>
                                                    <Settings AllowDragDrop="False" AllowSort="False" />
                                                    <EditFormSettings Visible="True" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </dx:GridViewDataComboBoxColumn>
                                                <dx:GridViewDataTextColumn Caption="ABREVIATURA" FieldName="ABREVIATURA" 
                                                    ShowInCustomizationForm="True" VisibleIndex="8" Width="100px">
                                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                                    <CellStyle HorizontalAlign="Right">
                                                    </CellStyle>
                                                </dx:GridViewDataTextColumn>
                                            </Columns>
                                            <Toolbars>
                                                <dx:GridViewToolbar ItemAlign="Right">
                                                    <Items>
                                                        <dx:GridViewToolbarItem Command="New">
                                                        </dx:GridViewToolbarItem>
                                                        <dx:GridViewToolbarItem Command="Edit">
                                                        </dx:GridViewToolbarItem>
                                                        <dx:GridViewToolbarItem Command="Delete">
                                                        </dx:GridViewToolbarItem>
                                                    </Items>
                                                </dx:GridViewToolbar>
                                            </Toolbars>
                                        </dx:ASPxGridView>
                                    </td>
                        </table>
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
		        <dx:TabPage Text="CONTRATO."   Name="Page4">
			        <ContentCollection>
				        <dx:ContentControl ID="ContentControl1" runat="server">	
                        <table>
                            <tr>
                            <td align="center">
                                <dx:ASPxGridView ID="GridProyectoContrato" runat="server" Visible="false" KeyFieldName="IDCONTRATO"  Width="100%" AutoGenerateColumns="False"
                                OnLoad="OnLoadProyectoContrato" 
                                OnRowInserting="OnRowInsertingProyectoContrato" 
                                OnRowUpdating="OnRowUpdatingProyectoContrato" OnCellEditorInitialize="EditorInitializeProyectoContrato"
                                OnRowDeleting="OnRowDeletingProyectoContrato"   ConfirmDelete="True">
                                <Toolbars>
                                    <dx:GridViewToolbar ItemAlign="Right">
                                        <Items>
                                            <dx:GridViewToolbarItem Command="New" />
                                            <dx:GridViewToolbarItem Command="Edit" />
                                            <dx:GridViewToolbarItem Command="Delete" />
                                            <dx:GridViewToolbarItem Text="Export to" Image-IconID="actions_download_16x16office2013" BeginGroup="true">
                                                <Items>
                                                    <dx:GridViewToolbarItem Name="ExportToPDF" Text="PDF" 
                                                        Image-IconID="export_exporttopdf_16x16office2013" >
                                                        <Image IconID="export_exporttopdf_16x16office2013">
                                                        </Image>
                                                    </dx:GridViewToolbarItem>
                                                    <dx:GridViewToolbarItem Name="ExportToXLSX" Text="XLSX" 
                                                        Image-IconID="export_exporttoxlsx_16x16office2013" >
                                                        <Image IconID="export_exporttoxlsx_16x16office2013">
                                                        </Image>
                                                    </dx:GridViewToolbarItem>
                                                    <dx:GridViewToolbarItem Name="ExportToXLS" Text="XLS" 
                                                        Image-IconID="export_exporttoxls_16x16office2013" >
                                                        <Image IconID="export_exporttoxls_16x16office2013">
                                                        </Image>
                                                    </dx:GridViewToolbarItem>
                                                </Items>
                                                <Image IconID="actions_download_16x16office2013">
                                                </Image>
                                            </dx:GridViewToolbarItem>
                                        </Items>
                                    </dx:GridViewToolbar>
                                </Toolbars>
                                <Columns> 
                                <dx:GridViewDataTextColumn FieldName="CONTRATO_NUMERO" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="80px"
                                Caption="NÚMERO CONTRATO" VisibleIndex="0" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  >
                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </dx:GridViewDataTextColumn> 
                                <dx:GridViewBandColumn  Caption="EMPRESA"  VisibleIndex="1" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" >
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
                                <Columns>
                                <dx:GridViewDataTextColumn FieldName="RUC" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="80px"
                                Caption="RUC" VisibleIndex="2" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  >
                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </dx:GridViewDataTextColumn> 
                                <dx:GridViewDataTextColumn FieldName="EMPRESA" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="80px"
                                Caption="NOMBRE" VisibleIndex="3" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  >
                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </dx:GridViewDataTextColumn> 
                                </Columns>
                                </dx:GridViewBandColumn>
                                <dx:GridViewBandColumn Caption="CONTRATO"  VisibleIndex="3" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" >
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
                                <Columns>
                                <dx:GridViewDataDateColumn FieldName="FECHA_CONTRATO" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"
                                Caption="FECHA CONTRATO" VisibleIndex="2" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn FieldName="MONTO_OBRA" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="80px"
                                Caption="IMPORTE OBRA" VisibleIndex="4" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="PLAZO_EJECUCION_OBRA" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"
                                Caption="PLAZO EJECUCIÓN" VisibleIndex="5" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewBandColumn Caption="INICIO DE OBRA"  VisibleIndex="3" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" >
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
                                <Columns>
                                <dx:GridViewDataDateColumn FieldName="FECHA_INICIO_OBRA" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"
                                Caption="FECHA INI. OBR." VisibleIndex="7" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataDateColumn FieldName="FECHA_INICIO_OBRA_MAXIMO" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"
                                Caption="FECHA INI. OBR. MAX." VisibleIndex="8" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </dx:GridViewDataDateColumn>
                                </Columns>
                                </dx:GridViewBandColumn>
                                    <dx:GridViewDataTextColumn Caption="SUPERVISOR" FieldName="RAZON_SOCIAL_SUPERVISOR" ShowInCustomizationForm="True" VisibleIndex="6">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="RUC SUPERVISOR" FieldName="RUC_SUPERVISOR" ShowInCustomizationForm="True" VisibleIndex="7">
                                    </dx:GridViewDataTextColumn>
                                </Columns>
                                </dx:GridViewBandColumn>
                                <dx:GridViewBandColumn  Caption="ADELANTO"  VisibleIndex="4" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" visible="false" >
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
                                <Columns>
                                <dx:GridViewDataDateColumn FieldName="FECHA_ADELANTO_DIRECTO" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px" EditFormSettings-Visible="False"
                                Caption="FECHA ADE. DIR." VisibleIndex="9" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                    <EditFormSettings Visible="False" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataDateColumn visible="false" FieldName="FECHA_ADELANTO_DIRECTO_MAX" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px" EditFormSettings-Visible="False"
                                Caption="FECHA ADE. DIR. MAX." VisibleIndex="10" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                    <EditFormSettings Visible="False" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </dx:GridViewDataDateColumn>
                                </Columns>
                                </dx:GridViewBandColumn>
                                <dx:GridViewBandColumn   Caption="ADELANTO DE MATERIALES"  VisibleIndex="5" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  HeaderStyle-Wrap="True"  visible="false">
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                <Columns>
                                <dx:GridViewDataTextColumn FieldName="MONTO_ADELANTO_MATERIALES" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="80px" EditFormSettings-Visible="False"
                                Caption="MONTO ADE. MAT." VisibleIndex="11" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  PropertiesTextEdit-DisplayFormatString="#,#"  >
                                    <PropertiesTextEdit DisplayFormatString="#,#">
                                    </PropertiesTextEdit>
                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                    <EditFormSettings Visible="False" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </dx:GridViewDataTextColumn> 
                                <dx:GridViewDataDateColumn  visible="false" FieldName="FECHA_ADELANTO_MAXIMO_MATERIALES" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px" EditFormSettings-Visible="False"
                                Caption="FECHA ADE. MAT. MAX." VisibleIndex="12" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                    <EditFormSettings Visible="False" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </dx:GridViewDataDateColumn>
                                </Columns>
                                </dx:GridViewBandColumn>
                                <dx:GridViewBandColumn   Caption="ADELANTO DE INSTALACION"  VisibleIndex="6" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" HeaderStyle-Wrap="True" visible="false">
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                <Columns>
                                <dx:GridViewDataTextColumn FieldName="MONTO_ADELANTO_INSTALACION" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="80px" EditFormSettings-Visible="False"
                                Caption="MONTO ADE. INST." VisibleIndex="13" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  PropertiesTextEdit-DisplayFormatString="#,#"  >
                                    <PropertiesTextEdit DisplayFormatString="#,#">
                                    </PropertiesTextEdit>
                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                    <EditFormSettings Visible="False" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </dx:GridViewDataTextColumn> 
                                <dx:GridViewDataDateColumn  visible="false" FieldName="FECHA_ADELANTO_MAXIMO_INSTALACION" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px" EditFormSettings-Visible="False"
                                Caption="FECHA AD. INST MAX." VisibleIndex="14" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                    <EditFormSettings Visible="False" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </dx:GridViewDataDateColumn>
                                </Columns>
                                </dx:GridViewBandColumn>
                                <dx:GridViewBandColumn   Caption="ENTREGA DE TERRENO"  VisibleIndex="7" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  HeaderStyle-Wrap="True">
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                <Columns>
                                <dx:GridViewDataDateColumn FieldName="FECHA_ENTREGA_TERRENO" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"
                                Caption="FECHA ENT. TERRE." VisibleIndex="15" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataDateColumn   visible="false" FieldName="FECHA_ENTREGA_TERRENO_LIMITE" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"
                                Caption="FECHA ENT. TERR. LIM." VisibleIndex="16" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </dx:GridViewDataDateColumn>
                                </Columns>
                                </dx:GridViewBandColumn>
                                <dx:GridViewDataComboBoxColumn Caption="ESTADO CONTRATO" FieldName="DESCRIPCION_ESTADO_CONTRATO" VisibleIndex="17" HeaderStyle-HorizontalAlign="Center"  Width="60px"
                                        Settings-AllowSort="False" Settings-AllowDragDrop="False" Settings-FilterMode="Value" EditFormSettings-Visible="True">
                                    <PropertiesComboBox TextField="DESCRIPCION_ESTADO_CONTRATO" ValueField="IDESTADO_CONTRATO" >
                                   </PropertiesComboBox>
                                    <Settings AllowDragDrop="False" AllowSort="False" />
                                    <EditFormSettings Visible="True" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </dx:GridViewDataComboBoxColumn>
                                </Columns>
                                 <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True"/>
                                <SettingsEditing Mode="PopupEditForm" EditFormColumnCount="2" />
                                </dx:ASPxGridView>
                            </td>
                            </tr>
                        
                        </table>
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
               
            	<dx:TabPage Name="Page7" Text="PARTIDAS.">
					<ContentCollection>
						<dx:ContentControl runat="server">
							<table>
								<tr>
									<td class="auto-style5">										
										<dx:ASPxGridView ID="GridPartida" runat="server" AutoGenerateColumns="False" OnLoad="OnLoadPartida" OnRowInserting="OnRowInsertingPartida" Width="100%" OnRowUpdating="OnRowUpdatingPartida" OnRowDeleting="GridPartida_RowDeleting">
											<Columns>
												<dx:GridViewCommandColumn ShowClearFilterButton="True" ShowInCustomizationForm="True" VisibleIndex="0">
												</dx:GridViewCommandColumn>
												<dx:GridViewDataTextColumn Caption="NOMBRE" FieldName="PAR_NOMBRE" ShowInCustomizationForm="True" VisibleIndex="2">
													<Settings AllowDragDrop="False" AllowHeaderFilter="False" AllowSort="False" AutoFilterCondition="Contains" />
												</dx:GridViewDataTextColumn>
												<dx:GridViewDataComboBoxColumn Caption="MEDIDA" FieldName="PAR_MEDIDA" ShowInCustomizationForm="True" VisibleIndex="3" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">													
													<Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
												</dx:GridViewDataComboBoxColumn>
											    <dx:GridViewDataTextColumn Caption="ID" FieldName="IDPARTIDA" ShowInCustomizationForm="True" VisibleIndex="1" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
                                                    <Settings AllowHeaderFilter="False" />
                                                    <EditFormSettings Visible="False" />
                                                </dx:GridViewDataTextColumn>
											</Columns>											
											<Toolbars>
												<dx:GridViewToolbar>
													<Items>
														<dx:GridViewToolbarItem Command="New">
														</dx:GridViewToolbarItem>
														<dx:GridViewToolbarItem Command="Edit">
														</dx:GridViewToolbarItem>
														<dx:GridViewToolbarItem Command="Delete">
														</dx:GridViewToolbarItem>
													</Items>
												</dx:GridViewToolbar>
											</Toolbars>	
											<Settings ShowHeaderFilterButton="true" ShowColumnHeaders="true" ShowFilterRow="True" />
											<SettingsEditing Mode="PopupEditForm" EditFormColumnCount="2" />
											<SettingsText Title="MANTENIMIENTO DE PARTIDAS" />
											<SettingsBehavior AllowFocusedRow="True" />
											<Settings ShowFooter="True" ShowTitlePanel="true"  />
										</dx:ASPxGridView>
									</td>
									<td class="auto-style5"><br /><br />
                                        <table style="width: 100%;margin:2px 2px;text-align:left">
                                            <tr>
                                                <td class="auto-style12"><asp:Button ID="Button1" runat="server" Text="Export to PDF" CssClass="btn btn-primary btn-xs" OnClick="Button1_Click" /></td>
                                                <td class="auto-style9"><asp:Button ID="Button2" runat="server" Text="Export to EXCEL" CssClass="btn btn-success btn-xs" OnClick="Button2_Click" /></td>                                                
                                                <td>
													<!--<asp:Button ID="Button5" runat="server" Text="Button" OnClick="Button5_Click" />
													<asp:TextBox ID="txtCode" runat="server"></asp:TextBox>	
													<img runat="server" id="imgCtrl" />
												
													&nbsp;</img>&nbsp;</img>&nbsp;</img></img></img></img></img></img></img>&nbsp;</img>-->                                                    
                                                </td>
                                            </tr>                                            
                                        </table>                                                                                                                      		
									<dx:ASPxGridView ID="GridContratoPartida" runat="server" AutoGenerateColumns="False" Width="900px" KeyFieldName="IDCONTRATOPARTIDA" OnLoad="OnLoadContratoPartida" OnRowInserting="OnRowInsertingContratoPartida" OnRowUpdating="OnRowUpdatingContratoPartida" OnCustomUnboundColumnData="GridContratoPartida_CustomUnboundColumnData" OnCustomSummaryCalculate="GridContratoPartida_CustomSummaryCalculate" EnableTheming="True" Theme="Glass" ClientInstanceName="GridContratoPartida" OnSummaryDisplayText="GridContratoPartida_SummaryDisplayText" OnRowDeleting="GridContratoPartida_RowDeleting" OnHtmlDataCellPrepared="GridContratoPartida_HtmlDataCellPrepared" OnHtmlRowPrepared="GridContratoPartida_HtmlRowPrepared">                                       
										<SettingsEditing Mode="PopupEditForm">
										</SettingsEditing>
										<Columns>
											<dx:GridViewDataTextColumn Caption="MEDIDA" FieldName="PAR_MEDIDA" ShowInCustomizationForm="True" VisibleIndex="3">
											    <EditFormSettings Visible="False" />
											</dx:GridViewDataTextColumn>
											<dx:GridViewDataTextColumn Caption="PRECIO" FieldName="PAR_PRECIO" ShowInCustomizationForm="True" VisibleIndex="5">
											</dx:GridViewDataTextColumn>
											<dx:GridViewDataComboBoxColumn Caption="DESCRIPCION" FieldName="PAR_NOMBRE" ShowInCustomizationForm="True" VisibleIndex="2" Width="600px">
											</dx:GridViewDataComboBoxColumn>
											<dx:GridViewDataTextColumn Caption="METRADO" FieldName="PAR_CANTIDAD" ShowInCustomizationForm="True" VisibleIndex="4">
											</dx:GridViewDataTextColumn>
											<dx:GridViewDataTextColumn Caption="TOTAL" FieldName="TOTAL" VisibleIndex="6" UnboundType="Decimal">
											    <EditFormSettings Visible="False" />
											</dx:GridViewDataTextColumn>
											<dx:GridViewDataTextColumn Caption="CODIGO" FieldName="CTP_CODIGO" ShowInCustomizationForm="True" VisibleIndex="1">
											    <EditFormSettings Visible="True" />
											</dx:GridViewDataTextColumn>
										    <dx:GridViewDataTextColumn Caption="LEV1" FieldName="LEV1" ShowInCustomizationForm="True" VisibleIndex="7" GroupIndex="1" SortIndex="1" SortOrder="Ascending">
                                                <EditFormSettings Visible="False" />
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="LEV2" FieldName="LEV2" ShowInCustomizationForm="True" VisibleIndex="8" GroupIndex="0" SortIndex="0" SortOrder="Ascending">
                                                <EditFormSettings Visible="False" />
                                            </dx:GridViewDataTextColumn>
										    <dx:GridViewDataCheckColumn Caption="APROBADO" FieldName="APROBADO" ShowInCustomizationForm="True" VisibleIndex="9">
                                                <EditFormSettings Visible="False" />
                                            </dx:GridViewDataCheckColumn>
										</Columns>
										<Toolbars>
											<dx:GridViewToolbar>
												<Items>
													<dx:GridViewToolbarItem Command="New" Name="New"></dx:GridViewToolbarItem>
													<dx:GridViewToolbarItem Command="Edit"></dx:GridViewToolbarItem>
													<dx:GridViewToolbarItem Command="Delete"></dx:GridViewToolbarItem>
                                                    
												</Items>
											</dx:GridViewToolbar>
										</Toolbars>
										<Settings ShowHeaderFilterButton="True" GroupFormat="{1} {2}" ShowGroupPanel="False" />
										<SettingsEditing Mode="PopupEditForm" EditFormColumnCount="2" />
										<SettingsText Title="ASOCIACION DE PARTIDAS CON CONTRATO" />
										<SettingsBehavior AllowFocusedRow="True" />
										<Settings ShowFooter="True" ShowTitlePanel="true"  />
										<Settings ShowFooter="True" />
										<SettingsPager EnableAdaptivity="true" PageSize="40" />										
										<GroupSummary>											
											<dx:ASPxSummaryItem FieldName="TOTAL" SummaryType="SUM" ShowInGroupFooterColumn="TOTAL" DisplayFormat="Total Partida = {0:c}" />
										</GroupSummary>
										<Styles Header-Wrap="True">
											<Header Wrap="True">
											</Header>
											<GroupFooter CssClass="table table-streap">
											</GroupFooter>
										</Styles>
										<TotalSummary>
											<dx:ASPxSummaryItem FieldName="CompanyName" SummaryType="Count" />
											<dx:ASPxSummaryItem FieldName="TOTAL" ShowInColumn="TOTAL" SummaryType="Sum" DisplayFormat="COSTO DIRECTO = {0:c}"/>
											<dx:ASPxSummaryItem FieldName="TOTAL" ShowInColumn="TOTAL" SummaryType="Custom" DisplayFormat="G. Generales = {0:c}" Tag="1" />
						                    <dx:ASPxSummaryItem FieldName="TOTAL" ShowInColumn="TOTAL" SummaryType="Custom" DisplayFormat="Utilidad = {0:c}" Tag="2" />
											<dx:ASPxSummaryItem FieldName="TOTAL" ShowInColumn="TOTAL" SummaryType="Custom" DisplayFormat="Otros = {0:c}" Tag="3" />
						                    <dx:ASPxSummaryItem FieldName="TOTAL" ShowInColumn="TOTAL" SummaryType="Custom" DisplayFormat="Subtotal = {0:c}" Tag="4" />
						                    <dx:ASPxSummaryItem FieldName="TOTAL" ShowInColumn="TOTAL" SummaryType="Custom" DisplayFormat="Igv = {0:c}" Tag="5" />
						                    <dx:ASPxSummaryItem FieldName="TOTAL" ShowInColumn="TOTAL" SummaryType="Custom" DisplayFormat="Total = {0:c}" Tag="6" />
											<dx:ASPxSummaryItem FieldName="TOTAL" ShowInColumn="TOTAL" SummaryType="Custom" DisplayFormat="Total-A = {0:c}" Tag="7" Visible="False" />
										</TotalSummary>										
									</dx:ASPxGridView>
								
                                       									
								    </td>									
								</tr>
                                <caption>
                                    <br />
                                    <br />
                                    <tr>
                                        <td>
                                            <dx:ASPxGridViewExporter ID="gridExporter" runat="server" ExportedRowType="All" GridViewID="GridContratoPartida">
                                            </dx:ASPxGridViewExporter>
                                        </td>
                                        <td style="margin-left:400px; text-align:right;">
                                            <table style="font-size:12px;margin-top:20px;font-weight:bold" width="100%" class="table table-streap">
                                                <tr style="display:none">
                                                    <td class="auto-style3">SUBTOTAL</td>
                                                    <td>
                                                        <asp:Label ID="LBLSUBTOTAL" runat="server" Text="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style6">% Gastos Generales 
                                                    </td>
                                                    <td class="auto-style7">
														<asp:TextBox ID="TxtGastosGenerales" runat="server" OnTextChanged="TxtGastosGenerales_TextChanged" Width="50px"></asp:TextBox>                                                        
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style3">% Utilidad 
                                                    </td>
                                                    <td>
														<asp:TextBox ID="TXTUTILIDAD" runat="server" OnTextChanged="TXTUTILIDAD_TextChanged" Width="50px"></asp:TextBox>                                                        
                                                        <br />
                                                    </td>
                                                </tr>
												<tr>
                                                    <td class="auto-style3">% Gastos Otros 
                                                    </td>
                                                    <td>
														<asp:TextBox ID="TXTGASTOSOTROS" runat="server" AutoPostBack="True" OnTextChanged="TXTGASTOSOTROS_TextChanged" Width="50px"></asp:TextBox>                                                        
                                                        <br />
                                                    </td>
                                                </tr>
												<tr>
                                                    <td class="auto-style3">% Adelanto Directo 
                                                    </td>
                                                    <td>
														<asp:TextBox ID="TXTADELANTODIRECTO" runat="server" Width="50px"></asp:TextBox>                                                        
                                                        <br />
                                                    </td>
                                                </tr>
												<tr>
                                                    <td class="auto-style3">% Adelanto de Materiales 
                                                    </td>
                                                    <td>
														<asp:TextBox ID="TXTADELANTOMATERIALES" AutoPostBack="True" runat="server" Width="50px" OnTextChanged="TXTADELANTOMATERIALES_TextChanged"></asp:TextBox>                                                        
                                                        <br />
                                                    </td>
                                                </tr>
												<tr>
                                                    <td class="auto-style3">% Adelanto Otros 
                                                    </td>
                                                    <td>
														<asp:TextBox ID="TXTADELANTOOTROS" AutoPostBack="True" runat="server" Width="50px" OnTextChanged="TXTADELANTOMATERIALES_TextChanged"></asp:TextBox>                                                        
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr style="display:none">
                                                    <td class="auto-style3">SUBTOTAL</td>
                                                    <td>
                                                        <asp:Label ID="LBLSUB" runat="server" Text="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr style="display:none">
                                                    <td class="auto-style3">IGV 18%</td>
                                                    <td>
                                                        <asp:Label ID="LBLIGV" runat="server" Text="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr style="display:none">
                                                    <td class="auto-style3">TOTAL</td>
                                                    <td>
                                                        <asp:Label ID="LBLTOTAL" runat="server" Text="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>                                                                      
                                </caption>
							</table>
						</dx:ContentControl>
					</ContentCollection>
				</dx:TabPage>

		        <dx:TabPage Text="REAJUSTE">
					<ContentCollection>
						<dx:ContentControl runat="server">
							<table>
								<tr>
									<td>									
										<dx:ASPxGridView ID="GridPolinomica" runat="server" AutoGenerateColumns="False" KeyFieldName="POL_ID" OnLoad="GridPolinomica_Load" OnRowInserting="GridPolinomica_RowInserting" OnRowUpdating="GridPolinomica_RowUpdating">
											<SettingsContextMenu EnableGroupPanelMenu="True">
											</SettingsContextMenu>
											<SettingsEditing Mode="PopupEditForm">
											</SettingsEditing>
											<Settings ShowTitlePanel="True" />
											<SettingsBehavior AllowFocusedRow="True" />
											<SettingsText Title="POLINOMICA" />
											<Columns>
												<dx:GridViewDataTextColumn Caption="N#" FieldName="POL_ID" ShowInCustomizationForm="True" VisibleIndex="0">
												</dx:GridViewDataTextColumn>
												<dx:GridViewDataTextColumn Caption="INDICE" FieldName="POL_INDICE" ShowInCustomizationForm="True" VisibleIndex="1">
													<EditFormSettings Visible="False" />
													<EditFormSettings Visible="True" />
												</dx:GridViewDataTextColumn>
												<dx:GridViewDataTextColumn Caption="NOMBRE" FieldName="POL_NOMBRE" ShowInCustomizationForm="True" VisibleIndex="2">
												</dx:GridViewDataTextColumn>
											</Columns>
											<Toolbars>
												<dx:GridViewToolbar>
													<Items>
														<dx:GridViewToolbarItem Command="New">
														</dx:GridViewToolbarItem>
														<dx:GridViewToolbarItem Command="Edit">
														</dx:GridViewToolbarItem>
														<dx:GridViewToolbarItem Command="Delete">
														</dx:GridViewToolbarItem>
													</Items>
												</dx:GridViewToolbar>
											</Toolbars>											
											
										</dx:ASPxGridView>
									</td>
									<td>
										<br /><br />

										<table style="width: 100%;margin:2px 2px;text-align:left">
                                            <tr>
                                                <td class="auto-style12"><asp:Button ID="Button3" runat="server" Text="Export to PDF" CssClass="btn btn-primary btn-xs" OnClick="Button3_Click" /></td>
                                                <td class="auto-style9"><asp:Button ID="Button4" runat="server" Text="Export to EXCEL" CssClass="btn btn-success btn-xs" OnClick="Button4_Click" /></td>                                                
                                                <td>&nbsp;</td>
                                            </tr>                                            
                                        </table>     
										<dx:ASPxGridView ID="GridContratoReajuste" runat="server" AutoGenerateColumns="False" KeyFieldName="CPL_ID" OnLoad="GridContratoReajuste_Load" OnRowInserting="GridContratoReajuste_RowInserting" OnRowUpdating="GridContratoReajuste_RowUpdating">
											<SettingsEditing Mode="PopupEditForm">
											</SettingsEditing>
											<Settings ShowTitlePanel="True" />
											<SettingsBehavior AllowFocusedRow="True" />
											<SettingsText Title="CONTRATO POLINOMICA" />
											<Columns>
												<dx:GridViewDataTextColumn Caption="N#" FieldName="CPL_ID" ShowInCustomizationForm="True" VisibleIndex="0">
													<EditFormSettings Visible="False" />
												</dx:GridViewDataTextColumn>
												<dx:GridViewDataTextColumn Caption="INDICE" FieldName="CPL_INDICE" ShowInCustomizationForm="True" VisibleIndex="1">
													<EditFormSettings Visible="False" />
												</dx:GridViewDataTextColumn>
												<dx:GridViewDataTextColumn Caption="FACTOR" FieldName="CPL_FACTOR" ShowInCustomizationForm="True" VisibleIndex="4">
												</dx:GridViewDataTextColumn>
												<dx:GridViewDataTextColumn Caption="VALOR" FieldName="CPL_INDICE_VALOR" ShowInCustomizationForm="True" VisibleIndex="5">
												</dx:GridViewDataTextColumn>
												<dx:GridViewDataComboBoxColumn Caption="NOMBRE" FieldName="CPL_POL_ID" ShowInCustomizationForm="True" VisibleIndex="3">
												</dx:GridViewDataComboBoxColumn>
											</Columns>
											<Toolbars>
												<dx:GridViewToolbar>
													<Items>
														<dx:GridViewToolbarItem Command="New">
														</dx:GridViewToolbarItem>
														<dx:GridViewToolbarItem Command="Edit">
														</dx:GridViewToolbarItem>
														<dx:GridViewToolbarItem Command="Delete">
														</dx:GridViewToolbarItem>
													</Items>
												</dx:GridViewToolbar>
											</Toolbars>
										</dx:ASPxGridView>										
									</td>
								</tr>
							</table>
						</dx:ContentControl>
					</ContentCollection>
				</dx:TabPage>

		        <dx:TabPage Text="AVANCE." Name="Page5"  >
			        <ContentCollection>
				        <dx:ContentControl ID="ContentControl3" runat="server">	
                            <table >
                            <tr>
                            <td align="center" valign="top"> 
                                <dx:ASPxGridView ID="GridProyectoProgramacion" runat="server"   Visible="false"  
                                OnLoad="OnLoadContratoProgramacion" KeyFieldName="IDCONTRATOCRONOGRAMA" 
                                OnRowInserting="OnRowInsertingContratoProgramacion"     
                                OnRowUpdating="OnRowUpdatingContratoProgramacion"
                                OnRowDeleting="OnRowDeletingContratoProgramacion"  Width="95%">
<%--                                <SettingsSearchPanel CustomEditorID="tbToolbarSearch" />--%>
<%--                                <ClientSideEvents ToolbarItemClick="OnToolbarItemClick" />  --%>                               
                                 <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True"/>
                                <Settings ShowTitlePanel="true" />
                                <SettingsBehavior AllowFocusedRow="true" />
                                <SettingsText Title="PROGRAMACION" />    
                                <Columns>
                                <dx:GridViewDataTextColumn FieldName="CRONOGRAMA" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="30px"
                                Caption="N#" VisibleIndex="0" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  PropertiesTextEdit-DisplayFormatString="##">
                                    <PropertiesTextEdit DisplayFormatString="##">
                                    </PropertiesTextEdit>
                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn FieldName="CRONOGRAMA_FECHA" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"
                                Caption="FECHA" VisibleIndex="1" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn FieldName="AVANCE" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"
                                Caption="%" VisibleIndex="2" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  PropertiesTextEdit-DisplayFormatString="{0}%">
                                    <PropertiesTextEdit DisplayFormatString="{0}%">
                                    </PropertiesTextEdit>
                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </dx:GridViewDataTextColumn>
                                	<dx:GridViewDataTextColumn Caption="MONTO" FieldName="MONTO_OBRA" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"  ShowInCustomizationForm="True" VisibleIndex="3">
										<EditFormSettings Visible="False" />
										<HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
									</dx:GridViewDataTextColumn>
                                </Columns>
                                <Toolbars>
                                    <dx:GridViewToolbar ItemAlign="Right">
                                        <Items>
                                            <dx:GridViewToolbarItem Command="New" />
                                            <dx:GridViewToolbarItem Command="Edit" />
                                            <dx:GridViewToolbarItem Command="Delete" />
                                        </Items>
                                    </dx:GridViewToolbar>
                                </Toolbars>
                                </dx:ASPxGridView>
                            </td>
							<td align="center" valign="top">
								<dx:ASPxGridView ID="GridProyectoContratoSup" runat="server" AutoGenerateColumns="False" OnRowInserting="OnRowInsertingProyectoContratoSup" Width="80%" KeyFieldName="IDCONTRATOSEGUIMIENTO" OnLoad="OnloadProyectoContratoSup" OnRowDeleting="OnRowDeletingProyectoContratoSup" OnRowUpdating="OnRowUpdatingProyectoContratoSup" Visible="false">
								    <Settings ShowTitlePanel="True" />
									<SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" />
									<SettingsText Title="SUPERVISOR" />
									<Columns>
										<dx:GridViewDataDateColumn Caption="FECHA" FieldName="SEGUIMIENTO_FECHA" ShowInCustomizationForm="True" VisibleIndex="1" Width="60px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true">
											<Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
											<HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
										</dx:GridViewDataDateColumn>
										<dx:GridViewDataTextColumn FieldName="AVANCE" ShowInCustomizationForm="True" VisibleIndex="2" Caption="%" Width="60px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true">
											<HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
										</dx:GridViewDataTextColumn>
										<dx:GridViewDataTextColumn Caption="N#" FieldName="SEGUIMIENTO_CRONOGRAMA" ShowInCustomizationForm="True" VisibleIndex="0" Width="50px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true">
											<PropertiesTextEdit DisplayFormatString="##">
											</PropertiesTextEdit>
											<Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
											<HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
										</dx:GridViewDataTextColumn>
										<dx:GridViewDataTextColumn Caption="MONTO" FieldName="MONTO_OBRA" ShowInCustomizationForm="True" VisibleIndex="3" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true">
											<EditFormSettings Visible="False" />
											<HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
										</dx:GridViewDataTextColumn>
									</Columns>
									<Toolbars>
										<dx:GridViewToolbar>
											<Items>
												<dx:GridViewToolbarItem Command="New">
												</dx:GridViewToolbarItem>
												<dx:GridViewToolbarItem Command="Edit">
												</dx:GridViewToolbarItem>
												<dx:GridViewToolbarItem Command="Delete">
												</dx:GridViewToolbarItem>
											</Items>
										</dx:GridViewToolbar>
									</Toolbars>
								 </dx:ASPxGridView>
							</td>
								<td align="center" valign="top">
								<dx:ASPxGridView ID="GridProyectoContratoCon" runat="server" AutoGenerateColumns="False" OnRowInserting="OnRowInsertingProyectoContratoCon" Width="80%" KeyFieldName="IDCONTRATOSEGUIMIENTO" OnLoad="OnloadProyectoContratoCon" OnRowDeleting="OnRowDeletingProyectoContratoCon" OnRowUpdating="OnRowUpdatingProyectoContratoCon" Visible="false">
								    <Settings ShowTitlePanel="True" />
									<SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" />
									<SettingsText Title="CONTRATISTA" />
									<Columns>
										<dx:GridViewDataDateColumn Caption="FECHA" FieldName="SEGUIMIENTO_FECHA" ShowInCustomizationForm="True" VisibleIndex="1" Width="60px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true">
											<Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
											<HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
										</dx:GridViewDataDateColumn>
										<dx:GridViewDataTextColumn FieldName="AVANCE" ShowInCustomizationForm="True" VisibleIndex="2" Caption="%" Width="60px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true">
											<HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
										</dx:GridViewDataTextColumn>
										<dx:GridViewDataTextColumn Caption="N#" FieldName="SEGUIMIENTO_CRONOGRAMA" ShowInCustomizationForm="True" VisibleIndex="0" Width="50px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true">
											<PropertiesTextEdit DisplayFormatString="##">
											</PropertiesTextEdit>
											<Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
											<HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
										</dx:GridViewDataTextColumn>
									    <dx:GridViewDataCheckColumn Caption="APROBADO" FieldName="APROBADO" ShowInCustomizationForm="True" VisibleIndex="4" Width="40px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true">
                                        	<HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
                                        </dx:GridViewDataCheckColumn>
										<dx:GridViewDataTextColumn Caption="MONTO" FieldName="MONTO_OBRA" ShowInCustomizationForm="True" VisibleIndex="3" Width="40px" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true">
											<EditFormSettings Visible="False" />
											<HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
										</dx:GridViewDataTextColumn>
									</Columns>
									<Toolbars>
										<dx:GridViewToolbar>
											<Items>
												<dx:GridViewToolbarItem Command="New">
												</dx:GridViewToolbarItem>
												<dx:GridViewToolbarItem Command="Edit">
												</dx:GridViewToolbarItem>
												<dx:GridViewToolbarItem Command="Delete">
												</dx:GridViewToolbarItem>
											</Items>
										</dx:GridViewToolbar>
									</Toolbars>
								 </dx:ASPxGridView>
							</td>					
                            <td align="center" valign="top">                                 
                                 <dx:ASPxGridView ID="GridProyectoSupervision" runat="server"   Visible="false"   OnLoad="OnLoadContratoSupervision"  KeyFieldName="IDCONTRATOSEGUIMIENTO"     
                                OnRowInserting="OnRowInsertingContratoSupervision"     
                                OnRowUpdating="OnRowUpdatingContratoSupervision"
                                OnRowDeleting="OnRowDeletingContratoSupervision"  Width="95%">
                                <Toolbars>
                                    <dx:GridViewToolbar ItemAlign="Right">
                                        <Items>
                                            <dx:GridViewToolbarItem Command="New" />
                                            <dx:GridViewToolbarItem Command="Edit" />
                                            <dx:GridViewToolbarItem Command="Delete" />
                                        </Items>
                                    </dx:GridViewToolbar>
                                </Toolbars>
                                <Columns>
                                <dx:GridViewDataTextColumn FieldName="SEGUIMIENTO_CRONOGRAMA" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="50px"
                                Caption="N#" VisibleIndex="1" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  PropertiesTextEdit-DisplayFormatString="##">
                                    <PropertiesTextEdit DisplayFormatString="##">
                                    </PropertiesTextEdit>
                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn FieldName="SEGUIMIENTO_FECHA" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"
                                Caption="FECHA" VisibleIndex="2" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn FieldName="AVANCE" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"
                                Caption="%" VisibleIndex="3" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  PropertiesTextEdit-DisplayFormatString="{0}%">
                                    <PropertiesTextEdit DisplayFormatString="{0}%">
                                    </PropertiesTextEdit>
                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </dx:GridViewDataTextColumn>
                                </Columns>
                                <Settings ShowTitlePanel="true" />
                                <SettingsText Title="COORDINADOR" />     
                                 <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True"/>
                                </dx:ASPxGridView></td>
                            <td  align="center" valign="top"> 
                                <dx:ASPxGridView ID="GridProyectoValorizacion" runat="server"  Visible="false"  OnLoad="OnLoadContratoValorizacion"   KeyFieldName="IDCONTRATOVALORIZACION"     
                                OnRowInserting="OnRowInsertingContratoValorizacion"     
                                OnRowUpdating="OnRowUpdatingContratoValorizacion"
                                OnRowDeleting="OnRowDeletingContratoValorizacion"  Width="95%">
                                <Toolbars>
                                    <dx:GridViewToolbar ItemAlign="Right">
                                        <Items>
                                            <dx:GridViewToolbarItem Command="New" />
                                            <dx:GridViewToolbarItem Command="Edit" Enabled="false" />
                                            <dx:GridViewToolbarItem Command="Delete" />
                                         </Items>
                                    </dx:GridViewToolbar>
                                </Toolbars>
                                <Columns>
                                <dx:GridViewDataTextColumn FieldName="VALORIZACION_NUMERO" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="50px"
                                Caption="N#" VisibleIndex="1" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  PropertiesTextEdit-DisplayFormatString="##">
                                    <PropertiesTextEdit DisplayFormatString="##">
                                    </PropertiesTextEdit>
                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                    <DataItemTemplate>
                                        <dx:ASPxHyperLink ID="hyperLink1" runat="server" OnInit="hyperLink_IniValContrato" Font-Size="Small" >
                                        </dx:ASPxHyperLink>
                                    </DataItemTemplate>    
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn FieldName="VALORIZACION_FECHA" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"
                                Caption="FECHA" VisibleIndex="2" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn FieldName="VALORIZACION_IMPORTE" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"
                                Caption="IMPORTE" VisibleIndex="3" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  PropertiesTextEdit-DisplayFormatString="#,#">
                                    <PropertiesTextEdit DisplayFormatString="#,#">
                                    </PropertiesTextEdit>
                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </dx:GridViewDataTextColumn>
                                </Columns>
                                <Settings ShowTitlePanel="true" />
                                <SettingsText Title="VALORIZACION" />     
                                 <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True"/>
                                </dx:ASPxGridView>
                            </td>
                            <td   align="center" valign="top">
                                <dx:ASPxGridView ID="GridProyectoAdelanto" runat="server"    OnLoad="OnLoadContratoAdelanto"   KeyFieldName="IDCONTRATOADELANTO"     
                                OnRowInserting="OnRowInsertingContratoAdelanto"     
                                OnRowUpdating="OnRowUpdatingContratoAdelanto"
                                OnRowDeleting="OnRowDeletingContratoAdelanto" Width="95%">
                                <Toolbars>
                                    <dx:GridViewToolbar ItemAlign="Right">
                                        <Items>
                                            <dx:GridViewToolbarItem Command="New" />
                                            <dx:GridViewToolbarItem Command="Edit" Enabled="false"/>
                                            <dx:GridViewToolbarItem Command="Delete" />
                                        </Items>
                                    </dx:GridViewToolbar>
                                </Toolbars>
                                <Columns>
                                <dx:GridViewDataTextColumn FieldName="ADELANTO_NUMERO" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="30px"
                                Caption="N#" VisibleIndex="1" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  PropertiesTextEdit-DisplayFormatString="##">
                                    <PropertiesTextEdit DisplayFormatString="##">
                                    </PropertiesTextEdit>
                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="TIPO_ADELANTO" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"
                                Caption="A/M" VisibleIndex="3" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False" >
                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn FieldName="ADELANTO_FECHA" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"
                                Caption="FECHA" VisibleIndex="2" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn FieldName="ADELANTO_IMPORTE" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"
                                Caption="IMPORTE" VisibleIndex="3" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  PropertiesTextEdit-DisplayFormatString="#,#">
                                    <PropertiesTextEdit DisplayFormatString="#,#">
                                    </PropertiesTextEdit>
                                    <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Wrap="True" />
                                    <CellStyle HorizontalAlign="Right">
                                    </CellStyle>
                                </dx:GridViewDataTextColumn>
                                </Columns>
                                <Settings ShowTitlePanel="true" />
                                <SettingsText Title="ADELANTO" />     
                                 <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True"/>
                                </dx:ASPxGridView>

                            </td>
                            <td align="center"  valign="top" >
                                <dx:ASPxGridView ID="ASPxGridViewContratoTipologia" runat="server"    
                                OnLoad="OnLoadContratoTipologia"   
                                OnRowInserting="OnRowInsertingContratoTipologia" OnRowDeleting="OnRowDeletingContratoTipologia" 
                                KeyFieldName="IDCONTRATOTIPOLOGIA"     
                                Width="95%">
                                <Toolbars>
                                    <dx:GridViewToolbar ItemAlign="Right">
                                        <Items>
                                            <dx:GridViewToolbarItem Command="New" />
                                            <dx:GridViewToolbarItem Command="Edit" Enabled="false" />
                                            <dx:GridViewToolbarItem Command="Delete" />
                                        </Items>
                                    </dx:GridViewToolbar>
                                </Toolbars>
                                <Columns>
                                <dx:GridViewDataComboBoxColumn Caption="TIPOLOGIA" FieldName="TIPOLOGIA_DESCRIPCION" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"  Width="100%"
                                        Settings-AllowSort="False" Settings-AllowDragDrop="False" Settings-FilterMode="Value" EditFormSettings-Visible="True">
                                    <PropertiesComboBox TextField="TIPOLOGIA_DESCRIPCION" ValueField="IDTIPOLOGIA" >
                                   </PropertiesComboBox>
                                    <Settings AllowDragDrop="False" AllowSort="False" />
                                    <EditFormSettings Visible="True" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </dx:GridViewDataComboBoxColumn>
                                </Columns>
                                 <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True"/>
                                <Settings ShowTitlePanel="true" />
                                <SettingsText Title="TIPOLOGIA" />     
                                </dx:ASPxGridView>
                            </td>
                            </tr>
                            </table>
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
            <dx:TabPage Text="DOCUMENTO DE INTERES" Name="Page6" >
            	<ContentCollection>
                        <dx:ContentControl ID="ContentControl5" runat="server">
                        <table>
                        <tr><td>
                                        <dx:ASPxButton ID="btnXlsExport" runat="server" Text="Descargar Contrato" UseSubmitBehavior="False"
                    OnClick="btnDescargarArchivo"  Font-Size="Small" />
                        </td>
                        </tr>
                        </table>


                        </dx:ContentControl>
                </ContentCollection>           
            </dx:TabPage>
            </TabPages>
            <TabStyle VerticalAlign="Bottom">
            </TabStyle>
        </dx:ASPxPageControl>

        
        </td>
        </tr>
        </table>
                    
                                                     
        </ContentTemplate>
        </asp:UpdatePanel>   
        <dx:ASPxPopupControl ID="popupControl" runat="server" 
                    ClientInstanceName="clientPopupControl"  CloseAction="CloseButton" 
                    Height="620px" Modal="True" Width="990px" PopupHorizontalAlign="RightSides"
                    PopupVerticalAlign="Middle" HeaderText="Valorizaciones" ScrollBars="Auto">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
            	<dx:ASPxGridViewExporter ID="gridExporter02" runat="server" ExportedRowType="All" GridViewID="GridContratoReajuste">
				</dx:ASPxGridViewExporter>
            </dx:PopupControlContentControl>
        </ContentCollection>                    
        </dx:ASPxPopupControl>
     </div>

</asp:Content>
