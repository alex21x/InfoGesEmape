<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmInfoGesGSOProyectoCheckListDet.aspx.cs" Inherits="InfoGesRegional.Modules.Forms.Seguimiento.frmInfoGesGSOProyectoCheckListDet" 
    Title="InfoGesEmape" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <form id="form1" runat="server">
   <script  language="javascript" type="text/javascript">
        function UpdateDetailGrid(s, e) {
            ASPxGridViewContratoCheckListDet.PerformCallback();
        }
        </script>
    <div>

        <table>
        <tr>
        <td>
        <table>
        <tr align="center">
        <td align="center" valign="top" >
            <dx:ASPxGridView ID="ASPxGridViewContratoCheckList" runat="server"    
            OnLoad="OnLoadContratoCheckList"   
            KeyFieldName="IDCONTRATOCHEKLIST"     
            Width="50%"  Font-Size="Small">
            <Columns>
            <dx:GridViewDataTextColumn FieldName="CHECKLIST_SEMANA" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"
            Caption="SEMANA DE INSPECCIÓN" VisibleIndex="3" Settings-AllowSort="True"  Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False" >
            </dx:GridViewDataTextColumn>
            </Columns>
            <SettingsBehavior AllowFocusedRow="true" />
            <ClientSideEvents FocusedRowChanged="UpdateDetailGrid" />
            <Settings VerticalScrollBarMode="Visible" VerticalScrollableHeight="80" />
            </dx:ASPxGridView>
        <td align="center" valign="top"  >
            <dx:ASPxGridView ID="ASPxGridViewContratoActividad" runat="server"    
            KeyFieldName="IDCONTRATOCHEKLIST"     
            Width="50%"  Font-Size="Small" Visible="false">
            <Columns>
            <dx:GridViewDataTextColumn FieldName="IDCHECKLIST" visible="false" >
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CHECKLIST_DESCRIPCION" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="60px"
            Caption="TIPOLOGIA DE LA INSPECCIÓN" VisibleIndex="3"  Settings-AllowSort="True" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False" >
            </dx:GridViewDataTextColumn>
            </Columns>
            <SettingsBehavior AllowFocusedRow="true"  />
            <Settings VerticalScrollBarMode="Visible" VerticalScrollableHeight="80" />
            </dx:ASPxGridView>

        </td>
        </tr>
        </table>
        </td>
        </tr>
        <tr>
        <td>
            <dx:ASPxGridView ID="ASPxGridViewContratoCheckListDet" runat="server"      ClientInstanceName="ASPxGridViewContratoCheckListDet"
             OnCustomCallback="gvDetail_CustomCallbackGD"    AutoGenerateColumns="False" KeyFieldName="IDCONTRATOCHECKLISTDET"  Width="100%"  Font-Size="Small">
            <Columns>

            <dx:GridViewDataTextColumn FieldName="CHECKLIST_DESCRIPCION" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="40%" EditFormSettings-Visible="False"
            Caption="DESCRIPCION CHECKLIST" VisibleIndex="3"  Settings-AllowSort="True" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False" CellStyle-ForeColor="BlanchedAlmond" CellStyle-Font-Bold="true" >
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CHECKLIST_ACTIVIDAD_DESCRIPCION" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"  Width="40%" EditFormSettings-Visible="False"
            Caption="ELEMENTOS A INSPECCIONAR" VisibleIndex="3"  Settings-AllowSort="True" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False" >
            </dx:GridViewDataTextColumn>
    <dx:GridViewBandColumn  Caption="GRADO DE CUMPLIMIENTO"  VisibleIndex="4" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true">
    <Columns>
            <dx:GridViewDataCheckColumn FieldName="LIKERT1"  Caption="Muy bajo (20%)"  VisibleIndex="7" Width="3%" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center"  HeaderStyle-VerticalAlign="Bottom"/>
            <dx:GridViewDataCheckColumn FieldName="LIKERT2"  Caption="Bajo (40%)"  VisibleIndex="7" Width="3%" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center"  HeaderStyle-VerticalAlign="Bottom"/>
            <dx:GridViewDataCheckColumn FieldName="LIKERT3"  Caption="Moderado atrasado (60%)"  VisibleIndex="7" Width="3.3%" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center"  HeaderStyle-VerticalAlign="Bottom"/>
            <dx:GridViewDataCheckColumn FieldName="LIKERT4"  Caption="Buen avance (80%)"  VisibleIndex="7" Width="3%" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center"  HeaderStyle-VerticalAlign="Bottom"/>
            <dx:GridViewDataCheckColumn FieldName="LIKERT5"  Caption="Muy buen avance (100%)"  VisibleIndex="7" Width="3%" Settings-AllowAutoFilter="False" Settings-AllowHeaderFilter="False" HeaderStyle-Wrap="True" HeaderStyle-HorizontalAlign="Center"  HeaderStyle-VerticalAlign="Bottom"/>
    </Columns>
    </dx:GridViewBandColumn>

            </Columns>
            <SettingsBehavior AllowFocusedRow="true"/>
            <Settings ShowGroupPanel="True" VerticalScrollBarMode="Visible" VerticalScrollableHeight="300" />
            <SettingsEditing Mode="Batch" />
            <Settings VerticalScrollableHeight="300" />
                <SettingsPager Mode="ShowAllRecords">
                    <PageSizeItemSettings Visible="true" ShowAllItem="true" />
                </SettingsPager>   
            </dx:ASPxGridView>

        </td>
        </tr>
        </table>

    </div>
    </form>
</body>
</html>

