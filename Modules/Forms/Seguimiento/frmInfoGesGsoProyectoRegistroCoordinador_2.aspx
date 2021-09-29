<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Modules/MasterPage.Master"
CodeBehind="frmInfoGesGsoProyectoRegistroCoordinador_2.aspx.cs" Inherits="InfogesEmape.Modules.Forms.Seguimiento.frmInfoGesGsoProyectoRegistroCoordinador_2" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height:500px; width:1200px; overflow:scroll;">
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
<table width="100%">
<tr>
<td  colspan="5" valign="top" align="center"><dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="PROYECTO"  Font-Size="X-Large" Font-Bold="true" ForeColor="Blue"> </dx:ASPxLabel></td>
<td align="right">
    <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Cerrar"  OnClick="btnClose_Click">
    </dx:ASPxButton>

</td>
</tr>
<tr>
<td colspan="6" align="right">
        <dx:ASPxMemo ID="ASPxMemo1"  Width="100%" runat="server" Enabled="false" Font-Size="Large" ReadOnlyStyle-ForeColor="Black">
        </dx:ASPxMemo>

</td>
</tr>
</table>


<tr>
<td  colspan="6" align="center">
    <dx:ASPxGridView ID="GridProyectoContrato" runat="server"  Width="100%"  Visible="false" KeyFieldName="IDCONTRATO"
    OnLoad="OnLoadProyectoContrato" >
    <Columns> 
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
    <dx:GridViewBandColumn   Caption="ENTREGA DE TERRENO"  VisibleIndex="4" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  HeaderStyle-Wrap="True">
    <Columns>
    <dx:GridViewDataDateColumn FieldName="FECHA_ENTREGA_TERRENO" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"
    Caption="FECHA ENT. TERRE." VisibleIndex="15" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
    </dx:GridViewDataDateColumn>
    <dx:GridViewDataDateColumn   visible="false" FieldName="FECHA_ENTREGA_TERRENO_LIMITE" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"
    Caption="FECHA ENT. TERR. LIM." VisibleIndex="16" CellStyle-HorizontalAlign="Right"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False">
    </dx:GridViewDataDateColumn>
    <dx:GridViewDataComboBoxColumn Caption="ESTADO CONTRATO" FieldName="DESCRIPCION_ESTADO_CONTRATO" VisibleIndex="17" HeaderStyle-HorizontalAlign="Center"  Width="60px"
            Settings-AllowSort="False" Settings-AllowDragDrop="False" Settings-FilterMode="Value" EditFormSettings-Visible="True">
        <PropertiesComboBox TextField="DESCRIPCION_ESTADO_CONTRATO" ValueField="IDESTADO_CONTRATO" >
        </PropertiesComboBox>
        <HeaderStyle HorizontalAlign="Center" />
    </dx:GridViewDataComboBoxColumn>
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
    OnCellEditorInitialize="GridProyectoProgramacion_CellEditorInitialize"
    OnRowInserting="OnRowInsertingContratoProgramacion"      
    OnRowUpdating="OnRowUpdatingContratoProgramacion"
    OnRowDeleting="OnRowDeletingContratoProgramacion"
    OnHtmlRowPrepared="GridProyectoProgramacion_HtmlRowPrepared" OnRowValidating="GridProyectoProgramacion_RowValidating" OnStartRowEditing="GridProyectoProgramacion_StartRowEditing"
    Width="95%">
    <Columns>
    <dx:GridViewCommandColumn ShowDeleteButton="true" ShowNewButtonInHeader="true" ShowEditButton="true" VisibleIndex="0"  Width="50px"/>
    <dx:GridViewDataTextColumn FieldName="CRONOGRAMA" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="30px" EditFormSettings-Visible="False"
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
    OnHtmlRowPrepared="GridProyectoSupervision_HtmlRowPrepared" OnRowValidating="GridProyectoSupervision_RowValidating" OnStartRowEditing="GridProyectoSupervision_StartRowEditing"
    OnRowDeleting="OnRowDeletingContratoSupervision"  Width="95%" >
    <Columns>
    <dx:GridViewCommandColumn ShowDeleteButton="true" ShowNewButtonInHeader="true" ShowEditButton="true" VisibleIndex="0"  Width="50px" />
    <dx:GridViewDataTextColumn FieldName="SEGUIMIENTO_CRONOGRAMA" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="50px"  EditFormSettings-Visible="False"
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
    OnRowDeleting="OnRowDeletingContratoValorizacion"  
    OnHtmlRowPrepared="GridProyectoValorizacion_HtmlRowPrepared" OnRowValidating="GridProyectoValorizacion_RowValidating" OnStartRowEditing="GridProyectoValorizacion_StartRowEditing"
    Width="95%">
    <Columns>
    <dx:GridViewCommandColumn ShowDeleteButton="true" ShowNewButtonInHeader="true"  ShowEditButton="true" VisibleIndex="0"  Width="50px" />
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
    <dx:ASPxGridView ID="GridProyectoAdelanto" runat="server"  Visible="false"    OnLoad="OnLoadContratoAdelanto"   KeyFieldName="IDCONTRATOADELANTO"     
     OnRowInserting="OnRowInsertingContratoAdelanto"       
    OnRowUpdating="OnRowUpdatingContratoAdelanto"
    OnRowDeleting="OnRowDeletingContratoAdelanto" 
    OnHtmlRowPrepared="GridProyectoAdelanto_HtmlRowPrepared" OnRowValidating="GridProyectoAdelanto_RowValidating" OnStartRowEditing="GridProyectoAdelanto_StartRowEditing"
    Width="95%">
    <Columns>
    <dx:GridViewCommandColumn ShowDeleteButton="true" ShowNewButtonInHeader="true" ShowEditButton="true" VisibleIndex="0"  Width="50px" />
    <dx:GridViewDataTextColumn FieldName="ADELANTO_NUMERO" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="30px"  EditFormSettings-Visible="False"
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
         
</td>
</tr>
         
</div>

</asp:Content>
