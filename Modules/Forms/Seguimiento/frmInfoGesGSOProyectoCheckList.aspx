<%@ Page Language="C#" MasterPageFile="~/Modules/MasterPage.Master" AutoEventWireup="true" 
    CodeBehind="frmInfoGesGSOProyectoCheckList.aspx.cs" Inherits="InfoGesRegional.Modules.Forms.Seguimiento.frmInfoGesGSOProyectoCheckList" 
    Title="InfoGesConsultas" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function OnMoreInfoClick(contentUrl) {
            clientPopupControl.SetContentUrl(contentUrl);
            clientPopupControl.Show();
        }
     </script>

    <style type="text/css">  
        div.customFont table {  
            font-size: 8px;  
        }  
        .dx-pivotgrid .dx-word-wrap .dx-pivotgrid-area .dx-pivotgrid-vertical-headers span {  
        white-space:nowrap;|
        } 
    </style> 
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
            width: 80%;
            margin-left: auto;
            margin-right: auto;
        }
    </style>
     <div id="principal"  class="inner" >


        <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" AutoPostBack="true"   Font-Size="Small"  TabStyle-VerticalAlign="Bottom"  TabAlign="Justify"
            ActiveTabIndex="0" TabSpacing="3px"  
            Width="100%" >
	        <ActiveTabStyle Font-Bold="True" Font-Size="Large">
	        </ActiveTabStyle>                        
	        <TabPages >   
		        <dx:TabPage Text="CUI X CHECKLIST" >
			        <ContentCollection>
				        <dx:ContentControl ID="ContentControl13" runat="server">	
                            <table>
                                <tr>
                                    <td >
                                    <dx:ASPxGridView ID="ASPxGridviewProyecto"  runat="server" Width="100%" 
                                        ClientInstanceName="ASPxGridviewProyecto"
                                        KeyFieldName="IDCONTRATO"
                                        OnLoad="LoadProyecto" 
                                        AutoGenerateColumns="False" OnRowCommand="EvtRowCommand" Font-Size="Small">
                                    <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True"/>
                                    <Settings VerticalScrollBarMode="Visible" VerticalScrollableHeight="500" />
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="CUI" Caption="CUI"  Visible="true" FixedStyle="Left" CellStyle-BackColor="#ffffd6" 
                                            VisibleIndex="1" HeaderStyle-Wrap="True" Width="20%"  Settings-AllowSort="False" Settings-AllowDragDrop="False"
                                            >
                                            <DataItemTemplate>
                                                <dx:ASPxHyperLink ID="hyperLink1" runat="server" OnInit="hyperLink_InitPROYECTOSNIP" Font-Size="Small" Width="20%" >
                                                </dx:ASPxHyperLink>
                                            </DataItemTemplate>    
                                            <Settings AllowDragDrop="False" AllowHeaderFilter="False" AllowSort="False"></Settings>
                                            <HeaderStyle HorizontalAlign="Center" Wrap="True" ></HeaderStyle>
                                            <CellStyle BackColor="#FFFFD6"></CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Abreviatura" FieldName="DESCRIPCION" SortOrder="Ascending" FixedStyle="Left"  Settings-AutoFilterCondition="Contains"
                                                VisibleIndex="2" HeaderStyle-Wrap="True" Width="100%"  Settings-AllowSort="False" Settings-AllowDragDrop="False" 
                                                HeaderStyle-HorizontalAlign="Center" />
                                            <dx:GridViewDataTextColumn Caption="Abreviatura" FieldName="ABREVIATURA" SortOrder="Ascending" FixedStyle="Left"  Settings-AutoFilterCondition="Contains"
                                                VisibleIndex="3" HeaderStyle-Wrap="True" Width="20%"  Settings-AllowSort="False" Settings-AllowDragDrop="False" 
                                                HeaderStyle-HorizontalAlign="Center" />
                                            <dx:GridViewDataTextColumn Caption="ULT.FECHA" FieldName="ULTIMA_FECHA" SortOrder="Ascending" FixedStyle="Left"  Settings-AutoFilterCondition="Contains"
                                                VisibleIndex="4" HeaderStyle-Wrap="True" Width="10%"  Settings-AllowSort="true" Settings-AllowDragDrop="False" 
                                                HeaderStyle-HorizontalAlign="Center" />
                                            <dx:GridViewDataTextColumn Caption="COMPONENTE" FieldName="COMPONENTE_OBRA" SortOrder="Ascending" FixedStyle="Left" Settings-AutoFilterCondition="Contains"
                                                VisibleIndex="5" HeaderStyle-Wrap="True" Width="10%"  Settings-AllowSort="False" Settings-AllowDragDrop="False" 
                                                HeaderStyle-HorizontalAlign="Center" />                        
                                            <dx:GridViewDataTextColumn Caption="CONTROL" FieldName="NCHECKLIST" SortOrder="Ascending" FixedStyle="Left"  Settings-AutoFilterCondition="Contains"
                                                VisibleIndex="6" HeaderStyle-Wrap="True" Width="10%"  Settings-AllowSort="False" Settings-AllowDragDrop="False" 
                                                HeaderStyle-HorizontalAlign="Center" />                                         
                                            </Columns> 
                                                <Settings ShowFooter="True" />
                                                <SettingsBehavior AllowDragDrop="False" />
                                                <SettingsPager Mode="ShowPager"/>
                                                <Settings ShowTitlePanel="true" />
                                                <SettingsText Title="PROYECTOS" />     
                                                <Settings ShowFilterRow="True" ShowHeaderFilterButton="true" />     
                                            <Settings VerticalScrollableHeight="300" />
                                                <SettingsPager Mode="ShowAllRecords">
                                                    <PageSizeItemSettings Visible="true" ShowAllItem="true" />
                                                </SettingsPager>            
                                       </dx:ASPxGridView>
                                    </td>
                                </tr>
                            </table>
 				        </dx:ContentControl>
			        </ContentCollection>
		        </dx:TabPage> 
              
                               
            </TabPages>

        </dx:ASPxPageControl>
        <dx:ASPxPopupControl ID="popupControl" runat="server" 
                    ClientInstanceName="clientPopupControl"  CloseAction="CloseButton" 
                    Height="600px" Modal="True" Width="1200px" PopupHorizontalAlign="Center" 
                    PopupVerticalAlign="WindowCenter" HeaderText="CHECKLIST DE ACTIVIDADES" ScrollBars="Auto">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
            </dx:PopupControlContentControl>
        </ContentCollection>                    
        </dx:ASPxPopupControl>

     </div>


</asp:Content>
