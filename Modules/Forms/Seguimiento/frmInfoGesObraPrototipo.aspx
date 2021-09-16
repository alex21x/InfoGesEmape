<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="frmInfoGesObraPrototipo.aspx.cs" Inherits="InfogesEmape.Modules.Forms.Seguimiento.frmInfoGesObraPrototipo" 
    Title="InfoGesConsultas" %>

<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<%@ Register Assembly="DevExpress.Xpo.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Xpo" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Data.Linq" tagprefix="dx" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">





<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Consulta Expediente Administrativo SIAF</title>
</head>
<body>
    <form id="form1" runat="server">
	<script type="text/javascript">
	    function onFocusedCellChanging(s, e) 
        {
//	        if (e.cellInfo.column.fieldName != 'MODIFICADO' && s.batchEditApi.GetCellValue(e.cellInfo.rowVisibleIndex, 'ESEDITABLE') != 2)
//	            e.cancel = true;
	        if (s.batchEditApi.GetCellValue(e.cellInfo.rowVisibleIndex, 'ESEDITABLE') != '1')
	            e.cancel = true;
	    }
	</script>
    <div>

<table>
<tr>
<td>

        <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" AutoPostBack="true"
            ActiveTabIndex="0" Height="300%" TabSpacing="3px"  Font-Size="X-Small" Width="100%" >
	        <ActiveTabStyle Font-Bold="True" Font-Size="Small">
	        </ActiveTabStyle>                        
	        <TabPages >   
		        <dx:TabPage Text="VALORIZACION" >
			        <ContentCollection>
				        <dx:ContentControl ID="ContentControl13" runat="server">	


                            <table>
                                <tr>
                                    <td colspan="3">

                                            <dx:aspxgridview ID="AspxgridviewValorizacioncontrato"
                                                        ClientInstanceName="AspxgridviewValorizacioncontrato"  OnLoad="OnLoadValorizacionContrato" 
                                                        runat="server"  KeyFieldName="IDCONTRATOPRESUPUESTO"  OnBatchUpdate="ASPxGridView1_BatchUpdate"
                                                        AutoGenerateColumns="False" 
                                                        Font-Size="Small"
                                                        Width="100%" >
                                                  <SettingsEditing Mode="Batch" />
                                                <Columns>
                                                   <dx:GridViewDataTextColumn FieldName="ESEDITABLE" VisibleIndex="1"  Width="20%" Caption="ESEDITABLE"  EditFormSettings-Visible="False"  HeaderStyle-Wrap="True"
                                                        HeaderStyle-HorizontalAlign="Center" CellStyle-BackColor="#ffffd6"  FixedStyle="Left" />
                                                    <dx:GridViewDataTextColumn FieldName="ITEM" VisibleIndex="2"  Width="50%" Caption="ITEM"  EditFormSettings-Visible="False"  HeaderStyle-Wrap="True"
                                                        HeaderStyle-HorizontalAlign="Center" CellStyle-BackColor="#ffffd6"  FixedStyle="Left" />
                                                    <dx:GridViewDataTextColumn FieldName="DESCRIPCION" VisibleIndex="3" Width="100%" Caption="DESCRIPCION"  EditFormSettings-Visible="False"  HeaderStyle-Wrap="True"
                                                        HeaderStyle-HorizontalAlign="Center" CellStyle-BackColor="#ffffd6"  FixedStyle="Left" 
                                                        Settings-AutoFilterCondition="Contains">
                                                        </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="UNIDAD_MEDIDA" VisibleIndex="3" Caption="UNIDAD MEDIDA" Width="60px"  EditFormSettings-Visible="False"  HeaderStyle-Wrap="True"
                                                        HeaderStyle-HorizontalAlign="Center"  CellStyle-BackColor="#ffffd6"  FixedStyle="Left" />
                                                    <dx:GridViewDataTextColumn FieldName="METRADO" VisibleIndex="4" Caption="METRADO"  Width="120px"  HeaderStyle-Wrap="True"   FixedStyle="Left"
                                                        HeaderStyle-HorizontalAlign="Center" />
                                                    <dx:GridViewDataTextColumn FieldName="PRECIO" VisibleIndex="5" Caption="PRECIO" Width="60%"  HeaderStyle-Wrap="True"  FixedStyle="Left"
                                                        HeaderStyle-HorizontalAlign="Center"  
                                                        Settings-AutoFilterCondition="Contains" />
                                                   <dx:GridViewDataTextColumn FieldName="TOTAL" VisibleIndex="6" Caption="TOTAL"  Width="60%"  HeaderStyle-Wrap="True"  
                                                        HeaderStyle-HorizontalAlign="Center" />
                                                    <dx:GridViewDataTextColumn FieldName="MODIFICADO" VisibleIndex="6" Caption="MODIFICADO"  Width="120px"  HeaderStyle-Wrap="True"  
                                                        HeaderStyle-HorizontalAlign="Center" />
                                                    <dx:GridViewDataTextColumn FieldName="SALDO" VisibleIndex="6" Caption="SALDO"  Width="120px"  HeaderStyle-Wrap="True"  
                                                        HeaderStyle-HorizontalAlign="Center" />
                                                   </Columns>
                                                <SettingsBehavior AllowFocusedRow="True" />
                                                <SettingsText Title="VALORIZACION"  />
                                                <SettingsPager Mode="ShowAllRecords"/>
                                                <Settings VerticalScrollableHeight="300" VerticalScrollBarMode="Visible" />
                                                <ClientSideEvents  FocusedCellChanging="onFocusedCellChanging" />
                                            </dx:aspxgridview> 
                                            <dx:ASPxGridViewExporter ID="gridExport" runat="server" GridViewID="AspxgridviewValorizacioncontrato"></dx:ASPxGridViewExporter>
 
                                            </td>
                                            </tr>
                            </table>
 


				        </dx:ContentControl>
			        </ContentCollection>
		        </dx:TabPage> 

                   
            </TabPages>
        </dx:ASPxPageControl>   
    <dx:ASPxUploadControl ID="ASPxUploadControl1" runat="server" UploadMode="Auto" up
        ShowProgressPanel="true" ShowUploadButton="false">
        <AdvancedModeSettings EnableMultiSelect="false" EnableFileList="false" EnableDragAndDrop="True" />
        <ValidationSettings MaxFileSize="4194304" AllowedFileExtensions=".Xls,.XlsX" />
    </dx:ASPxUploadControl>

</td>
    <dx:ASPxGridView ID="ASPxGridView1" runat="server">
    </dx:ASPxGridView>
</tr>
</table>
<dx:XpoDataSource ID="XpoDataSource1"  runat="server" ServerMode="True" TypeName="Dv"/>
</div>
</form>
</body>
</html>
    
