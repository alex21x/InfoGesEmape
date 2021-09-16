<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmSeguimientosLiquidacion.aspx.cs" Inherits="InfoGesRegional.Modules.Forms.Consulta.frmSeguimientosLiquidacion" %>


<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Consulta Expediente Administrativo SIAF</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
   

<table>
<tr>
<td style="padding-right: 4px">
<dx:ASPxButton ID="btnXlsExport" runat="server" Text="Export to XLS" UseSubmitBehavior="False" Font-Size="Small"
                    OnClick="btnXlsExport_Click" /> </td>
<td><dx:ASPxButton runat="server" ID="btnCollapse" Text="Collapse All Rows" UseSubmitBehavior="false"  Font-Size="Small"
    AutoPostBack="false">
    <ClientSideEvents Click="function() { ASPxGridview1.CollapseAll() }" />
</dx:ASPxButton>
</td>
<td>
<dx:ASPxButton runat="server" ID="btnExpand" Text="Expand All Rows" UseSubmitBehavior="false"  Font-Size="Small"
    AutoPostBack="false">
    <ClientSideEvents Click="function() { ASPxGridview1.ExpandAll() }" />
</dx:ASPxButton>
</td>
</tr>
</table>

        <dx:ASPxGridView ID="ASPxGridview1"  runat="server" Width="95%" 
            ClientInstanceName="ASPxGridview1"
            OnLoad="LoadASPxGridview" 
            AutoGenerateColumns="false"  Font-Size="X-Small">
        <Columns>
            <dx:GridViewDataTextColumn FieldName="ANO_EJE" Caption="Periodo" VisibleIndex="1"  width="80px" />                            
            <dx:GridViewDataTextColumn FieldName="FASE_CONTRACTUAL" Caption="FASE CONTRACTUAL" VisibleIndex="1"  width="60px" HeaderStyle-Wrap="True"/>                            
            <dx:GridViewDataTextColumn FieldName="SEC_FUNC" Caption="Sec. Func." VisibleIndex="3"  width="40px" HeaderStyle-Wrap="True" />                            
            <dx:GridViewDataTextColumn FieldName="FUENTE_FINANC_NOMBRE" Caption="Fte. Fto." VisibleIndex="3"  width="80px" />                            
            <dx:GridViewDataTextColumn FieldName="ESPECIFICA_DET_NOMBRE" Caption="Partida" VisibleIndex="4"   width="130px"/>                            
            <dx:GridViewDataTextColumn FieldName="EXPEDIENTE" Caption="Exp." VisibleIndex="5"   width="65px"/>                            
            <dx:GridViewDataTextColumn FieldName="EXPEDIENTE_SECUENCIA"  Caption="SEC." VisibleIndex="5"   width="30px"/>                            
            <dx:GridViewDataTextColumn FieldName="EXPEDIENTE_CORRELATIVO" Caption="COR." VisibleIndex="5"   width="30px"/>                            
            <dx:GridViewDataTextColumn FieldName="CICLO" Caption="C." VisibleIndex="5"   width="20px"/>                            
            <dx:GridViewDataTextColumn FieldName="FASE" Caption="F." VisibleIndex="5"   width="20px"/>                            
            <dx:GridViewBandColumn  Caption="DOCUMENTO" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center" VisibleIndex="6">
            <Columns>
                <dx:GridViewDataDateColumn FieldName="COD_DOC" Caption="Cod." VisibleIndex="6"    width="80px"/>
                <dx:GridViewDataTextColumn FieldName="NUM_DOC" Caption="Num." VisibleIndex="7" width="40px"/>
                <dx:GridViewDataDateColumn FieldName="FECHA_DOC" Caption="Fecha" VisibleIndex="8" width="60px"/>
            </Columns>
            </dx:GridViewBandColumn>
            <dx:GridViewDataTextColumn FieldName="EJECUCION" Caption="Ejecución" VisibleIndex="9" width="80px">
                <PropertiesTextEdit DisplayFormatString="c">
                 </PropertiesTextEdit>            
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="RUC" Caption="Ruc" VisibleIndex="10" Width="60px" />
            <dx:GridViewDataTextColumn FieldName="NOMBRE_RUC" Caption="Nombre Ruc" VisibleIndex="11" Width="120px" />
            <dx:GridViewDataTextColumn FieldName="NOTAS" Caption="Notas" VisibleIndex="12" Width="200px" />
        </Columns> 
            <SettingsPager Mode="ShowAllRecords"></SettingsPager>
            <Settings  ShowGroupPanel="True" ShowFooter="true" ShowGroupFooter="VisibleAlways" VerticalScrollBarMode="Visible"  VerticalScrollableHeight="360"/>    
     </dx:ASPxGridView>
      <dx:ASPxGridViewExporter ID="gridExport" runat="server" GridViewID="ASPxGridview1"></dx:ASPxGridViewExporter>                  
    </div>
    </form>
</body>
</html>
