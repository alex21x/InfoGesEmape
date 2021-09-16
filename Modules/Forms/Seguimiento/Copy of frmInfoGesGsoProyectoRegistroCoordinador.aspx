<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Modules/MasterPage.Master"
CodeBehind="frmInfoGesGsoProyectoRegistroCoordinador.aspx.cs" Inherits="InfoGesRegional.Modules.Forms.Seguimiento.frmInfoGesGsoProyectoRegistroCoordinador" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height:900px; width:1050px; overflow:scroll;">
        <asp:ScriptManager ID="ScriptManager1" runat="server" >
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Always">
        <ContentTemplate>          
        <asp:UpdateProgress ID="UpdateProgress1" runat="server"  AssociatedUpdatePanelID="UpdatePanel4" DisplayAfter="0">
        <ProgressTemplate>
            <img alt="procesando..."  src="../../../Images/ajax-loader.gif"/></ProgressTemplate>
         </asp:UpdateProgress>  
                             
<table>

<tr><td colspan="6"> <br> </td></tr>

<tr>
<td colspan="6">
<div>
<table>
<tr>
<td><dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="CUI : "  Font-Size="Large"> </dx:ASPxLabel></td>
<td><dx:ASPxTextBox ID="txtCUI" runat="server" Width="80px"  Font-Size="Large"> </dx:ASPxTextBox></td>
<td><dx:ASPxTextBox ID="txtDescripcion" runat="server" Width="600px" Height="16px" Font-Size="Large" > </dx:ASPxTextBox>
</td>
</tr>
</table>

</div>
</td>
</tr>
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
<tr>


<td colspan="6" align="center">
    <dx:ASPxGridView ID="GridProyectoMeta" runat="server" Width="1000px" Visible="false" KeyFieldName="IDPROYECTO_DETALLE" 
    OnLoad="OnLoadProyectoMeta" OnRowUpdating="OnRowUpdatingProyectoMeta" OnRowInserting="OnRowInsertingProyectoMeta">
    <Columns>
    <dx:GridViewCommandColumn ShowNewButton="true" ShowEditButton="true" VisibleIndex="0" Width="60px"/>
    <dx:GridViewDataTextColumn FieldName="PERIODO" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  PropertiesTextEdit-Width="30%" 
    Caption="PERIODO" VisibleIndex="1" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  PropertiesTextEdit-DisplayFormatString="#,#">
    <EditCellStyle HorizontalAlign="Right"></EditCellStyle>
    </dx:GridViewDataTextColumn>  
    <dx:GridViewBandColumn Caption="META POR PERIODO"  VisibleIndex="2" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" >
    <Columns>
    <dx:GridViewDataTextColumn FieldName="META_OBRA" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="80px" PropertiesTextEdit-Width="50%" 
    Caption="OBRA" VisibleIndex="3" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  PropertiesTextEdit-DisplayFormatString="#,#">
    </dx:GridViewDataTextColumn>  
    <dx:GridViewDataTextColumn FieldName="META_SUPERVISION" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="80px" PropertiesTextEdit-Width="50%"
    Caption="SUPERVISION" VisibleIndex="3" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  PropertiesTextEdit-DisplayFormatString="#,#"  >
    </dx:GridViewDataTextColumn>  
    <dx:GridViewDataTextColumn FieldName="META_EXP_TECNICO" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="80px" PropertiesTextEdit-Width="50%"
    Caption="EXP. TÉCNICO" VisibleIndex="3" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  PropertiesTextEdit-DisplayFormatString="#,#"  >
    </dx:GridViewDataTextColumn>  
    <dx:GridViewDataTextColumn FieldName="META_INTERFERENCIA" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="80px" PropertiesTextEdit-Width="50%"
    Caption="INTERFERENCIA" VisibleIndex="3" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  PropertiesTextEdit-DisplayFormatString="#,#"  >
    </dx:GridViewDataTextColumn>  
    <dx:GridViewDataTextColumn FieldName="META_GESTION_PROYECTO" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="80px" PropertiesTextEdit-Width="50%"
    Caption="GESTION PROYECTO" VisibleIndex="3" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  PropertiesTextEdit-DisplayFormatString="#,#"  >
    </dx:GridViewDataTextColumn>  
    <dx:GridViewDataTextColumn FieldName="META_TERRENO" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="80px" PropertiesTextEdit-Width="50%"
    Caption="TERRENO" VisibleIndex="3" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  PropertiesTextEdit-DisplayFormatString="#,#"  >
    </dx:GridViewDataTextColumn>  
    <dx:GridViewDataTextColumn FieldName="META_MOBILIARIO" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="80px" PropertiesTextEdit-Width="50%"
    Caption="MOBILIARIO" VisibleIndex="3" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  PropertiesTextEdit-DisplayFormatString="#,#"  >
    </dx:GridViewDataTextColumn>  
    <dx:GridViewDataTextColumn FieldName="META_MITIGACION_AMBIENTAL" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="80px" PropertiesTextEdit-Width="50%"
    Caption="MITIGACIÓN AMBIENTAL" VisibleIndex="3" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  PropertiesTextEdit-DisplayFormatString="#,#"  >
    </dx:GridViewDataTextColumn>  
    <dx:GridViewDataTextColumn FieldName="META_FISICA_PROYECTADA" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="80px" PropertiesTextEdit-Width="50%"
    Caption="FISICA PROYECTADA" VisibleIndex="3" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  PropertiesTextEdit-DisplayFormatString="#,#"  >
    </dx:GridViewDataTextColumn> 
    </Columns>
    </dx:GridViewBandColumn>
      </Columns>
<SettingsBehavior AllowFocusedRow="True" />
<SettingsEditing Mode="PopupEditForm" EditFormColumnCount="2" />
    </dx:ASPxGridView>
</td>
</tr>
<tr><td colspan="6"> <br> </td></tr>
<tr><td colspan="6" bgcolor="#0099CC"> <br> </td></tr>
<tr><td colspan="6"> <br> </td></tr>

<tr>
<td colspan="6" align="center">
    <dx:ASPxGridView ID="GridProyectoComponente" runat="server"  Width="1000px"  Visible="false"  KeyFieldName="IDPROYECTOCOMPONENTE"
    OnLoad="OnLoadProyectoComponente" 
    OnRowValidating="OnRowProyectoComponenteValidating"
    OnStartRowEditing="OnStartRowEditingProyectoComponente"
    OnRowInserting="OnRowInsertingProyectoComponente"
    OnRowUpdating="OnRowUpdatingProyectoComponente"  
    OnCellEditorInitialize="EditorInitializeProyectoComponente">
    <Columns>
    <dx:GridViewCommandColumn ShowNewButton="true"  ShowEditButton="true" VisibleIndex="0"  Width="80px"/>
    <dx:GridViewDataComboBoxColumn Caption="COMPONENTE" FieldName="DESCRIPCION_COMPONENTE" VisibleIndex="1" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False" Settings-FilterMode="Value" EditFormSettings-Visible="True">
        <PropertiesComboBox TextField="DESCRIPCION_COMPONENTE" ValueField="IDCOMPONENTE" >
        </PropertiesComboBox>
        <HeaderStyle HorizontalAlign="Center" />
    </dx:GridViewDataComboBoxColumn>
    <dx:GridViewBandColumn Caption="FECHA DE LOS PROCESOS"  VisibleIndex="2" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" >
    <Columns>
    <dx:GridViewDataDateColumn FieldName="FECHA_CONVOCATORIA" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="80px"
    Caption="CONVOCATORIA" VisibleIndex="2" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
    </dx:GridViewDataDateColumn>
    <dx:GridViewDataDateColumn FieldName="FECHA_ESTIMADA_BUENA_PRO" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="80px"
    Caption="ESTIMADA BUENA PRO" VisibleIndex="3" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
    </dx:GridViewDataDateColumn>
    <dx:GridViewDataDateColumn FieldName="FECHA_CONSENTIMIENTO_BUENA_PRO" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="80px"
    Caption="ESTIMADA CONSENTIMIENTO" VisibleIndex="4" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
    </dx:GridViewDataDateColumn>
    <dx:GridViewDataDateColumn FieldName="FECHA_ESTIMADA_CONTRATO" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="80px"
    Caption="ESTIMADA CONTRATO" VisibleIndex="5" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
    </dx:GridViewDataDateColumn>
    <dx:GridViewDataDateColumn FieldName="FECHA_ESTIMADA_INICIO" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="80px"
    Caption="ESTIMADA INICIO" VisibleIndex="5" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
    </dx:GridViewDataDateColumn>
    <dx:GridViewDataDateColumn FieldName="FECHA_ENTREGA_TERRENO" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="80px"
    Caption="ENTREGA DE TERRENO" VisibleIndex="5" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
    </dx:GridViewDataDateColumn>
    </Columns>
    </dx:GridViewBandColumn>
    <dx:GridViewDataTextColumn FieldName="TIEMPO_EJECUCION" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="80px"
    Caption="TIEMPO DE EJECUCIÓN" VisibleIndex="6" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  >
    </dx:GridViewDataTextColumn> 
    <dx:GridViewDataComboBoxColumn Caption="ESTADO REGISTRO" FieldName="DESCRIPCION_ESTADO_COMPONENTE" VisibleIndex="7" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False" Settings-AllowDragDrop="False" Settings-FilterMode="Value" EditFormSettings-Visible="True">
        <PropertiesComboBox TextField="DESCRIPCION_ESTADO_COMPONENTE" ValueField="IDESTADO_COMPONENTE" >
        </PropertiesComboBox>
        <HeaderStyle HorizontalAlign="Center" />
    </dx:GridViewDataComboBoxColumn>
    </Columns>
<SettingsBehavior AllowFocusedRow="True" />
<SettingsEditing Mode="PopupEditForm" EditFormColumnCount="2" />
    </dx:ASPxGridView>
</td>
</tr>
<tr><td colspan="6"> <br> </td></tr>
<tr><td colspan="6" bgcolor="#0099CC"> <br> </td></tr>
<tr><td colspan="6"> <br> </td></tr>
<tr>
<td  colspan="6" align="center">
    <dx:ASPxGridView ID="GridProyectoContrato" runat="server"  Width="1000px"  Visible="false" KeyFieldName="IDCONTRATO"
    OnLoad="OnLoadProyectoContrato" OnRowInserting="OnRowInsertingProyectoContrato" OnRowUpdating="OnRowUpdatingProyectoContrato" 
    OnRowDeleting="OnRowDeletingProyectoContrato"  >
    <Columns> 
    <dx:GridViewCommandColumn ShowNewButton="true"  ShowEditButton="true" ShowDeleteButton="true" VisibleIndex="0"  Width="80px"/>
    <dx:GridViewDataTextColumn FieldName="CONTRATO_NUMERO" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="80px"
    Caption="NÚMERO CONTRATO" VisibleIndex="1" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  >
    </dx:GridViewDataTextColumn> 
    <dx:GridViewBandColumn  Caption="EMPRESA"  VisibleIndex="2" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" >
    <Columns>
    <dx:GridViewDataTextColumn FieldName="RUC" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="80px"
    Caption="RUC" VisibleIndex="2" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  >
    </dx:GridViewDataTextColumn> 
    <dx:GridViewDataTextColumn FieldName="EMPRESA" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="80px"
    Caption="NOMBRE" VisibleIndex="3" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  >
    </dx:GridViewDataTextColumn> 
    </Columns>
    </dx:GridViewBandColumn>
    <dx:GridViewBandColumn Caption="CONTRATO"  VisibleIndex="3" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" >
    <Columns>
    <dx:GridViewDataDateColumn FieldName="FECHA_CONTRATO" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"
    Caption="FECHA CONTRATO" VisibleIndex="4" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
    </dx:GridViewDataDateColumn>
    <dx:GridViewDataTextColumn FieldName="MONTO_OBRA" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="80px"
    Caption="IMPORTE OBRA" VisibleIndex="5" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
    </dx:GridViewDataTextColumn>
    <dx:GridViewDataTextColumn FieldName="PLAZO_EJECUCION_OBRA" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"
    Caption="PLAZO EJECUCIÓN" VisibleIndex="6" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
    </dx:GridViewDataTextColumn>
    <dx:GridViewBandColumn Caption="INICIO DE OBRA"  VisibleIndex="4" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" >
    <Columns>
    <dx:GridViewDataDateColumn FieldName="FECHA_INICIO_OBRA" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"
    Caption="FECHA INI. OBR." VisibleIndex="7" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
    </dx:GridViewDataDateColumn>
    <dx:GridViewDataDateColumn FieldName="FECHA_INICIO_OBRA_MAXIMO" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"
    Caption="FECHA INI. OBR. MAX." VisibleIndex="8" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
    </dx:GridViewDataDateColumn>
    </Columns>
    </dx:GridViewBandColumn>
    </Columns>
    </dx:GridViewBandColumn>
    <dx:GridViewBandColumn  Caption="ADELANTO"  VisibleIndex="4" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" >
    <Columns>
    <dx:GridViewDataDateColumn FieldName="FECHA_ADELANTO_DIRECTO" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"
    Caption="FECHA ADE. DIR." VisibleIndex="9" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
    </dx:GridViewDataDateColumn>
    <dx:GridViewDataDateColumn visible="false" FieldName="FECHA_ADELANTO_DIRECTO_MAX" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"
    Caption="FECHA ADE. DIR. MAX." VisibleIndex="10" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
    </dx:GridViewDataDateColumn>
    </Columns>
    </dx:GridViewBandColumn>
    <dx:GridViewBandColumn   Caption="ADELANTO DE MATERIALES"  VisibleIndex="4" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  HeaderStyle-Wrap="True">
    <Columns>
    <dx:GridViewDataTextColumn FieldName="MONTO_ADELANTO_MATERIALES" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="80px"
    Caption="MONTO ADE. MAT." VisibleIndex="11" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  PropertiesTextEdit-DisplayFormatString="#,#"  >
    </dx:GridViewDataTextColumn> 
    <dx:GridViewDataDateColumn  visible="false" FieldName="FECHA_ADELANTO_MAXIMO_MATERIALES" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"
    Caption="FECHA ADE. MAT. MAX." VisibleIndex="12" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
    </dx:GridViewDataDateColumn>
    </Columns>
    </dx:GridViewBandColumn>
    <dx:GridViewBandColumn   Caption="ADELANTO DE INSTALACION"  VisibleIndex="4" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" HeaderStyle-Wrap="True" >
    <Columns>
    <dx:GridViewDataTextColumn FieldName="MONTO_ADELANTO_INSTALACION" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="80px"
    Caption="MONTO ADE. INST." VisibleIndex="13" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  PropertiesTextEdit-DisplayFormatString="#,#"  >
    </dx:GridViewDataTextColumn> 
    <dx:GridViewDataDateColumn  visible="false" FieldName="FECHA_ADELANTO_MAXIMO_INSTALACION" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"
    Caption="FECHA AD. INST MAX." VisibleIndex="14" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
    </dx:GridViewDataDateColumn>
    </Columns>
    </dx:GridViewBandColumn>
    <dx:GridViewBandColumn   Caption="ENTREGA DE TERRENO"  VisibleIndex="4" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  HeaderStyle-Wrap="True">
    <Columns>
    <dx:GridViewDataDateColumn FieldName="FECHA_ENTREGA_TERRENO" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"
    Caption="FECHA ENT. TERRE." VisibleIndex="15" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
    </dx:GridViewDataDateColumn>
    <dx:GridViewDataDateColumn   visible="false" FieldName="FECHA_ENTREGA_TERRENO_LIMITE" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"
    Caption="FECHA ENT. TERR. LIM." VisibleIndex="16" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
    </dx:GridViewDataDateColumn>
    </Columns>
    </dx:GridViewBandColumn>
    </Columns>
    <SettingsBehavior AllowFocusedRow="True" />
    <SettingsEditing Mode="PopupEditForm" EditFormColumnCount="2" />
    </dx:ASPxGridView>
</td>
</tr>
<tr><td colspan="6"> <br> </td></tr>
<tr><td colspan="6" bgcolor="#0099CC"> <br> </td></tr>
<tr><td colspan="6"> <br> </td></tr>



<tr>
<td colspan='6'>
<table>
<tr>
<td align="left" valign="top"> 
    <dx:ASPxGridView ID="GridProyectoProgramacion" runat="server"   Visible="false"  
    OnLoad="OnLoadContratoProgramacion" KeyFieldName="IDCONTRATOCRONOGRAMA" 
    OnRowInserting="OnRowInsertingContratoProgramacion"     
    OnRowUpdating="OnRowUpdatingContratoProgramacion"
    OnRowDeleting="OnRowDeletingContratoProgramacion"  Width="95%">
    <Columns>
    <dx:GridViewCommandColumn ShowDeleteButton="true" ShowNewButtonInHeader="true" ShowEditButton="true" VisibleIndex="0"  Width="50px"/>
    <dx:GridViewDataTextColumn FieldName="CRONOGRAMA" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="30px"
    Caption="N#" VisibleIndex="1" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  PropertiesTextEdit-DisplayFormatString="##">
    </dx:GridViewDataTextColumn>
    <dx:GridViewDataDateColumn FieldName="CRONOGRAMA_FECHA" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"
    Caption="FECHA" VisibleIndex="2" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
    </dx:GridViewDataDateColumn>
    <dx:GridViewDataTextColumn FieldName="AVANCE" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"
    Caption="%" VisibleIndex="3" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  PropertiesTextEdit-DisplayFormatString="{0}%">
    </dx:GridViewDataTextColumn>
    </Columns>
    <Settings ShowTitlePanel="true" />
    <SettingsText Title="PROGRAMACION" />     
    </dx:ASPxGridView>
</td>
<td align="center" valign="top">
     <dx:ASPxGridView ID="GridProyectoSupervision" runat="server"   Visible="false"   OnLoad="OnLoadContratoSupervision"  KeyFieldName="IDCONTRATOSEGUIMIENTO"     
    OnRowInserting="OnRowInsertingContratoSupervision"     
    OnRowUpdating="OnRowUpdatingContratoSupervision"
    OnRowDeleting="OnRowDeletingContratoSupervision"  Width="95%">
    <Columns>
    <dx:GridViewCommandColumn ShowDeleteButton="true" ShowNewButtonInHeader="true" ShowEditButton="true" VisibleIndex="0"  Width="50px"/>
    <dx:GridViewDataTextColumn FieldName="SEGUIMIENTO_CRONOGRAMA" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="50px"
    Caption="N#" VisibleIndex="1" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  PropertiesTextEdit-DisplayFormatString="##">
    </dx:GridViewDataTextColumn>
    <dx:GridViewDataDateColumn FieldName="SEGUIMIENTO_FECHA" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"
    Caption="FECHA" VisibleIndex="2" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
    </dx:GridViewDataDateColumn>
    <dx:GridViewDataTextColumn FieldName="AVANCE" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"
    Caption="%" VisibleIndex="3" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  PropertiesTextEdit-DisplayFormatString="{0}%">
    </dx:GridViewDataTextColumn>
    </Columns>
    <Settings ShowTitlePanel="true" />
    <SettingsText Title="SUPERVISION" />     
    </dx:ASPxGridView></td>
<td  align="right" valign="top"> 
    <dx:ASPxGridView ID="GridProyectoValorizacion" runat="server"  Visible="false"  OnLoad="OnLoadContratoValorizacion"   KeyFieldName="IDCONTRATOVALORIZACION"     
    OnRowInserting="OnRowInsertingContratoValorizacion"     
    OnRowUpdating="OnRowUpdatingContratoValorizacion"
    OnRowDeleting="OnRowDeletingContratoValorizacion"  Width="95%">
    <Columns>
    <dx:GridViewCommandColumn ShowDeleteButton="true" ShowNewButtonInHeader="true"  ShowEditButton="true" VisibleIndex="0"  Width="50px"/>
    <dx:GridViewDataTextColumn FieldName="VALORIZACION_NUMERO" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="50px"
    Caption="N#" VisibleIndex="1" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  PropertiesTextEdit-DisplayFormatString="##">
    </dx:GridViewDataTextColumn>
    <dx:GridViewDataDateColumn FieldName="VALORIZACION_FECHA" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"
    Caption="FECHA" VisibleIndex="2" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
    </dx:GridViewDataDateColumn>
    <dx:GridViewDataTextColumn FieldName="VALORIZACION_IMPORTE" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"
    Caption="IMPORTE" VisibleIndex="3" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  PropertiesTextEdit-DisplayFormatString="#,#">
    </dx:GridViewDataTextColumn>
    </Columns>
    <Settings ShowTitlePanel="true" />
    <SettingsText Title="VALORIZACION" />     
    </dx:ASPxGridView>
</td>
<td   align="right" valign="top">
    <dx:ASPxGridView ID="GridProyectoAdelanto" runat="server"    OnLoad="OnLoadContratoAdelanto"   KeyFieldName="IDCONTRATOADELANTO"     
     OnRowInserting="OnRowInsertingContratoAdelanto"     
    OnRowUpdating="OnRowUpdatingContratoAdelanto"
    OnRowDeleting="OnRowDeletingContratoAdelanto" Width="95%">
    <Columns>
    <dx:GridViewCommandColumn ShowDeleteButton="true" ShowNewButtonInHeader="true" ShowEditButton="true" VisibleIndex="0"  Width="50px"/>
    <dx:GridViewDataTextColumn FieldName="ADELANTO_NUMERO" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="30px"
    Caption="N#" VisibleIndex="1" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  PropertiesTextEdit-DisplayFormatString="##">
    </dx:GridViewDataTextColumn>
    <dx:GridViewDataTextColumn FieldName="TIPO_ADELANTO" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"
    Caption="A/M" VisibleIndex="3" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False" >
    </dx:GridViewDataTextColumn>
    <dx:GridViewDataDateColumn FieldName="ADELANTO_FECHA" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"
    Caption="FECHA" VisibleIndex="2" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
    </dx:GridViewDataDateColumn>
    <dx:GridViewDataTextColumn FieldName="ADELANTO_IMPORTE" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"
    Caption="IMPORTE" VisibleIndex="3" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False"  PropertiesTextEdit-DisplayFormatString="#,#">
    </dx:GridViewDataTextColumn>
    </Columns>
    <Settings ShowTitlePanel="true" />
    <SettingsText Title="ADELANTO" />     
    </dx:ASPxGridView>

</td>
</tr>
</table>

</td>
</tr>
</table>


 

        </ContentTemplate>
        </asp:UpdatePanel>   
</div>

</asp:Content>
