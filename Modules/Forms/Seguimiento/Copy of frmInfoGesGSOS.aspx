<%@ Page Language="C#" MasterPageFile="~/Modules/MasterPage.Master" AutoEventWireup="true" 
    CodeBehind="frmInfoGesGSOS.aspx.cs" Inherits="InfoGesRegional.Modules.Forms.Seguimiento.frmInfoGesGSOS" 
    Title="InfoGesConsultas" %>

<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<%@ Register Assembly="DevExpress.Xpo.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Xpo" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Data.Linq" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxPivotGrid.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPivotGrid" tagprefix="dx" %>
<%@ Register Assembly="DevExpress.XtraCharts.v17.1.Web, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"  Namespace="DevExpress.XtraCharts.Web" TagPrefix="dxchartsui" %>
<%@ Register assembly="DevExpress.XtraCharts.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="dxcharts" %>
<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPivotGrid.Export" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style4
        {
            width: 309px;
        }
        .style5
        {
            width: 168px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
      <script type="text/javascript">

       </script>



     <div id="principal" >

<table>
<tr>
<td>

        <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" AutoPostBack="true"
            ActiveTabIndex="0" Height="300%" TabSpacing="3px"  Font-Size="X-Small" 
            Width="100%" onactivetabchanged="ASPxPageControl1_ActiveTabChanged" >
	        <ActiveTabStyle Font-Bold="True" Font-Size="Small">
	        </ActiveTabStyle>                        
	        <TabPages >   
		        <dx:TabPage Text="VALORIZACION" >
			        <ContentCollection>
				        <dx:ContentControl ID="ContentControl13" runat="server">	


                            <table>
                                <tr align="left">
                                <td>
                                    <table><tr>
                                    <td style="padding-right: 4px">
                                                    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Exportar  XLS" UseSubmitBehavior="False"  Font-Size="X-Small"
                                                        OnClick="btnXlsExport_Click"/></td>
                                    <td><dx:ASPxButton runat="server" ID="ASPxButton2" Text="Collapse All Rows" UseSubmitBehavior="false" OnCheckedChanged="chkSingleCollapse_CheckedChanged"
                                        AutoPostBack="false"  Font-Size="X-Small">
                                        <ClientSideEvents Click="function(s, e) { AspxgridviewCertificadoxIdClasificador.CollapseAllDetailRows(); }" />
                                    </dx:ASPxButton>
                                    </td>
                                    <td>
                                    <dx:ASPxButton runat="server" ID="ASPxButton3" Text="Expand All Rows" UseSubmitBehavior="false" OnCheckedChanged="chkSingleExpanded_CheckedChanged"
                                        AutoPostBack="false"  Font-Size="X-Small">
                                        <ClientSideEvents Click="function(s, e) { AspxgridviewCertificadoxIdClasificador.ExpandAllDetailRows(); }" />
                                    </dx:ASPxButton>
                                    </td>

                                    </tr>
                                    </table>

                                </td>
                                </tr>
                                <tr>
                                    <td>
                                    <dx:ASPxComboBox ID="CboSemana" runat="server" style="vertical-align: middle" AutoPostBack="true" 
                                    SelectedIndex="0" ValueType="System.String" Width="400px" OnSelectedIndexChanged="OnSelectedindexChangedGrid" >
                                    </dx:ASPxComboBox>
                                    <dx:aspxgridview ID="AspxGridGsoAvance" EnableRowsCache="false"
                                                ClientInstanceName="AspxGridGsoAvance"
                                                runat="server"  KeyFieldName="ABREVIATURA" OnBatchUpdate="ASPxCardView1_BatchUpdate" 
                                                AutoGenerateColumns="False" 
                                                Font-Size="X-Small"
                                                Width="100%" 
                                                OnLoad="Load_Gso_Avance">
                                                <Columns>
                                                <dx:GridViewDataTextColumn FieldName="IDAVANCE" Caption="IDGSOSITUACION" 
                                                    VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"  Settings-AllowSort="False" EditFormSettings-Visible="False" Visible="false"
                                                    Settings-AllowDragDrop="False"  Settings-AllowHeaderFilter="False"  CellStyle-BackColor="LightYellow" />
                                                <dx:GridViewDataTextColumn FieldName="IDGSOSITUACION" Caption="IDGSOSITUACION" 
                                                    VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"  Settings-AllowSort="False" EditFormSettings-Visible="False" Visible="false"
                                                    Settings-AllowDragDrop="False"  Settings-AllowHeaderFilter="False"  CellStyle-BackColor="LightYellow" />
                                               <dx:GridViewDataTextColumn FieldName="IDSEMANA" Caption="IDSEMANA" 
                                                    VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"  Settings-AllowSort="False" EditFormSettings-Visible="False" Visible="false"
                                                    Settings-AllowDragDrop="False"  Settings-AllowHeaderFilter="False"  CellStyle-BackColor="LightYellow" />
                                                <dx:GridViewDataTextColumn FieldName="ABREVIATURA" Caption="PROYECTO" 
                                                    VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"  Settings-AllowSort="False" EditFormSettings-Visible="False"
                                                    Settings-AllowDragDrop="False"  Settings-AllowHeaderFilter="False"  CellStyle-BackColor="LightYellow" />
                                                <dx:GridViewDataTextColumn FieldName="ACTIVIDAD" Caption="ACTIVIDAD" 
                                                    VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"  Settings-AllowSort="False" EditFormSettings-Visible="False"
                                                    Settings-AllowDragDrop="False"  Settings-AllowHeaderFilter="False"  CellStyle-BackColor="LightYellow"/>  
                                                <dx:GridViewDataTextColumn FieldName="SEMANA" Caption="SEMANA" 
                                                    VisibleIndex="1" HeaderStyle-HorizontalAlign="Center"  Settings-AllowSort="False" EditFormSettings-Visible="False"
                                                    Settings-AllowDragDrop="False"  Settings-AllowHeaderFilter="False"  CellStyle-BackColor="LightYellow" />                                                                                      
                                                <dx:GridViewDataTextColumn FieldName="OBRA" Caption="OBRA" VisibleIndex="8"  HeaderStyle-HorizontalAlign="Center" Width="120px" HeaderStyle-Wrap="True" Settings-AllowSort="False" Settings-AllowDragDrop="False"  Settings-AllowHeaderFilter="False">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <PropertiesTextEdit DisplayFormatString="{0}%" >  
                                                         <MaskSettings Mask="<0..100>.<00..99> " IncludeLiterals="DecimalSymbol" />
                                                    </PropertiesTextEdit>  
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="SUPERVISION" Caption="SUPERVISION" VisibleIndex="8"  HeaderStyle-HorizontalAlign="Center" Width="120px" HeaderStyle-Wrap="True" Settings-AllowSort="False" Settings-AllowDragDrop="False"  Settings-AllowHeaderFilter="False">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <PropertiesTextEdit DisplayFormatString="{0}%" >  
                                                         <MaskSettings Mask="<0..100>.<00..99> " IncludeLiterals="DecimalSymbol" />
                                                    </PropertiesTextEdit>  
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="GESTION_PROYECTO" Caption="GESTION DE PROYECTO" VisibleIndex="8"  HeaderStyle-HorizontalAlign="Center" Width="120px" HeaderStyle-Wrap="True" Settings-AllowSort="False" Settings-AllowDragDrop="False"  Settings-AllowHeaderFilter="False">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <PropertiesTextEdit DisplayFormatString="{0}%" >  
                                                         <MaskSettings Mask="<0..100>.<00..99> " IncludeLiterals="DecimalSymbol" />
                                                    </PropertiesTextEdit>  
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="INTERFERENCIA" Caption="INTERFERENCIA" VisibleIndex="8"  HeaderStyle-HorizontalAlign="Center" Width="120px" HeaderStyle-Wrap="True" Settings-AllowSort="False" Settings-AllowDragDrop="False"  Settings-AllowHeaderFilter="False">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <PropertiesTextEdit DisplayFormatString="{0}%" >  
                                                         <MaskSettings Mask="<0..100>.<00..99> " IncludeLiterals="DecimalSymbol" /> 
                                                    </PropertiesTextEdit>  

                                                </dx:GridViewDataTextColumn>

                                                </Columns>
                                                <SettingsEditing Mode="Batch" />
                                   </dx:aspxgridview>
                                    <dx:aspxgridview ID="AspxgridviewCertificadoxIdClasificador" EnableRowsCache="false"
                                                ClientInstanceName="AspxgridviewCertificadoxIdClasificador" OnAfterPerformCallback="grid_AfterPerformCallback"
                                                runat="server"  KeyFieldName="Oid"
                                                AutoGenerateColumns="False" 
                                                DataSourceID="XpoDataSource1"
                                                Font-Size="X-Small"
                                                Width="100%" >
                                        <Columns>
                                            <dx:GridViewDataTextColumn FieldName="PAQUETE" Caption="PAQUETE" 
                                                VisibleIndex="1"  Width="15%" HeaderStyle-HorizontalAlign="Center" 
                                                CellStyle-BackColor="#ffffd6" HeaderStyle-Wrap="True" >
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DESCRIPCION" Caption="PROYECTO" 
                                                VisibleIndex="2" Width="100%" HeaderStyle-HorizontalAlign="Center" 
                                                CellStyle-BackColor="#ffffd6" Settings-AutoFilterCondition="Contains" 
                                                HeaderStyle-Wrap="True">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="ACT_PROY"  Caption="CUI" VisibleIndex="3" 
                                                Width="20%"  HeaderStyle-HorizontalAlign="Center" CellStyle-BackColor="#ffffd6" 
                                                Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DISTRITO"  Caption="DISTRITO" 
                                                VisibleIndex="4" Width="20%"  HeaderStyle-HorizontalAlign="Center" 
                                                CellStyle-BackColor="#ffffd6" Settings-AutoFilterCondition="Contains" 
                                                HeaderStyle-Wrap="True">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="FECHA_ENTREGA_TERRENO"  
                                                Caption="FECHA ENTREGA TERRENO" VisibleIndex="2" Width="20%"  
                                                HeaderStyle-HorizontalAlign="Center" CellStyle-BackColor="#ffffd6" 
                                                Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="FECHA_INICIO_OBRA"  
                                                Caption="FECHA INICIO DE OBRA" VisibleIndex="5" Width="20%"  
                                                HeaderStyle-HorizontalAlign="Center" CellStyle-BackColor="#ffffd6" 
                                                Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="ESTADO_OBRA"  Caption="ESTADO DE LA OBRA" 
                                                VisibleIndex="6" Width="20%"  HeaderStyle-HorizontalAlign="Center" 
                                                CellStyle-BackColor="#ffffd6" Settings-AutoFilterCondition="Contains" 
                                                HeaderStyle-Wrap="True">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="PLAZO_EJECUCION"  
                                                Caption="PLAZO DE EJECUCION" VisibleIndex="7" Width="20%"  
                                                HeaderStyle-HorizontalAlign="Center" CellStyle-BackColor="#ffffd6" 
                                                Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="FECHA_CULMINACION"  
                                                Caption="FECHA DE EJECUCION" VisibleIndex="8" Width="20%"  
                                                HeaderStyle-HorizontalAlign="Center" CellStyle-BackColor="#ffffd6" 
                                                Settings-AutoFilterCondition="Contains" HeaderStyle-Wrap="True">
                                            </dx:GridViewDataTextColumn>
                                            </Columns>
                                        <SettingsBehavior AllowFocusedRow="True" />
                                        <SettingsDetail ShowDetailRow="true" />
                                        <SettingsText Title="ESTADO SITUACION DE LAS OBRAS SOCIALES - PRIMER PAQUETE"  />
                                        <SettingsPager Mode="ShowAllRecords"/>
                                        <Settings VerticalScrollableHeight="300" VerticalScrollBarMode="Visible" />
                                    </dx:aspxgridview> 
                                    <dx:ASPxGridViewExporter ID="gridExport" runat="server" GridViewID="AspxgridviewCertificadoxIdClasificador"></dx:ASPxGridViewExporter>
 
                                            </td>
                                            </tr>
                            </table>
 


				        </dx:ContentControl>
			        </ContentCollection>
		        </dx:TabPage> 
                <dx:TabPage Text="ESTADO SITUACIONAL DE LAS OBRAS SOCIALES">
                <ContentCollection>
                <dx:ContentControl ID="ContentControl14" runat="server">
                <table>
                <tr><td>
                
        <dx:ASPxPivotGrid ID="pivotGrid" runat="server" onLoad="LoadASPxPivotGrid"  Font-Size="XX-Small"
                Width="100%">
                <Fields>
                    <dx:PivotGridField Area="RowArea" AreaIndex="0" FieldName="IDGSOSITUACION" 
                        visible="False" HeaderStyle-Wrap="True" />
                    <dx:PivotGridField Area="RowArea" AreaIndex="1" Caption="PAQ." 
                        FieldName="PAQUETE" HeaderStyle-Wrap="True"  Visible="False" />
                    <dx:PivotGridField Area="RowArea" AreaIndex="2" Caption="ABREVIATURA" 
                        FieldName="ABREVIATURA" HeaderStyle-Wrap="True"  />
                    <dx:PivotGridField Area="RowArea" AreaIndex="3" Caption="PROYECTO" 
                        FieldName="ACT_PROY" HeaderStyle-Wrap="True" Visible="False" />
                    <dx:PivotGridField Area="RowArea" AreaIndex="4" Caption="DISTRITO" 
                        FieldName="DISTRITO" HeaderStyle-Wrap="True" />
                    <dx:PivotGridField Area="RowArea" AreaIndex="5" Caption="ACTIVIDAD" 
                        FieldName="ACTIVIDAD" HeaderStyle-Wrap="True" />
                    <dx:PivotGridField Area="RowArea" AreaIndex="6" Caption="ENTR. TERRE." 
                        FieldName="FECHA_ENTREGA_TERRENO" HeaderStyle-Wrap="True" />
                    <dx:PivotGridField Area="RowArea" AreaIndex="7" Caption="INICIO DE OBRA" 
                        FieldName="FECHA_INICIO_OBRA" HeaderStyle-Wrap="True"  />
                    <dx:PivotGridField Area="RowArea" AreaIndex="8" Caption="ESTADO" 
                        FieldName="ESTADO_OBRA" HeaderStyle-Wrap="True" />
                    <dx:PivotGridField Area="RowArea" AreaIndex="9" Caption="PLAZO EJE." 
                        FieldName="PLAZO_EJECUCION" HeaderStyle-Wrap="True" />
                    <dx:PivotGridField Area="RowArea" AreaIndex="10" Caption="FECHA CULMI." 
                        FieldName="FECHA_CULMINACION" HeaderStyle-Wrap="True" />
                    <dx:PivotGridField Area="ColumnArea" AreaIndex="11" Caption="SEMANA" 
                        FieldName="SEMANA" HeaderStyle-Wrap="True" />
                    <dx:PivotGridField Area="ColumnArea" AreaIndex="12" Caption="TIPO DE AVANCE" 
                        FieldName="TIPO_AVANCE" HeaderStyle-Wrap="True" />
                    <dx:PivotGridField Area="DataArea" AreaIndex="13" Caption="AVANCE" 
                        FieldName="AVANCE" HeaderStyle-Wrap="True" CellFormat-FormatString="##.##%"  />

                </Fields>
                <OptionsView ShowFilterHeaders="true"  VerticalScrollBarMode="Visible"  />
                <OptionsData DataProcessingEngine="LegacyOptimized" />
                <OptionsView ShowColumnTotals="False" />
                <OptionsPager RowsPerPage="10" ColumnsPerPage="12" />
                <OptionsFilter ShowHiddenItems="true" ShowOnlyAvailableItems="true" />
            </dx:ASPxPivotGrid>

            <dxchartsui:WebChartControl ID="WebChartControl1" runat="server" 
                DataSourceID="pivotGrid" Height="356px" Width="942px" 
                SeriesDataMember="Series">
                <SeriesTemplate ArgumentDataMember="Arguments" ValueDataMembersSerializable="Values" >
            <ViewSerializable>
                <dxcharts:SideBySideBarSeriesView />
            </ViewSerializable>
            <LabelSerializable>
                <dxcharts:SideBySideBarSeriesLabel>
                    <FillStyle>
                        <OptionsSerializable>
                            <dxcharts:SolidFillOptions />
                        </OptionsSerializable>
                    </FillStyle>
                    <PointOptionsSerializable>
                        <dxcharts:PointOptions />
                    </PointOptionsSerializable>
                </dxcharts:SideBySideBarSeriesLabel>
            </LabelSerializable>
        </SeriesTemplate>
                <DiagramSerializable>
                    <dxcharts:XYDiagram>
                        <AxisX VisibleInPanesSerializable="-1">
                        </AxisX>
                        <AxisY VisibleInPanesSerializable="-1">
                        </AxisY>
                    </dxcharts:XYDiagram>
                </DiagramSerializable>
                <Legend Name="Default Legend"></Legend>
            </dxchartsui:WebChartControl>

                </td></tr>
                </table>
                </dx:ContentControl>
                </ContentCollection>
                </dx:TabPage>
                   
            </TabPages>
        </dx:ASPxPageControl>   
</td>
</tr>
</table>
<dx:XpoDataSource ID="XpoDataSource1" runat="server" 
             TypeName="PersistentObjects.gso_estado_situacional" 
             ServerMode="true"/>
</div>    
</asp:Content>
