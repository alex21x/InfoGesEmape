<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="InfogesEmape.Includes.Header" %>


<%@ Register src="MenuTree.ascx" tagname="MenuTree" tagprefix="uc4" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dxm" %>
<%@ Register Assembly="DevExpress.Web.v17.1" Namespace="DevExpress.Web" TagPrefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/3.3.1/css/bootstrap.min.css" />

        <style type="text/css">									    
			.customBGVbackcolor td {
				background-color: lightslategray !important;
			}    
            .style1
            {
                width: 316px;
            }
            .style3
            {
                width: 29px;
            }
            .style4
            {
                width: 56px;
            }
        	.auto-style1 {
				width: 56px;
				height: 70px;
			}
			.auto-style2 {
				height: 70px;
			}
        </style>
        <table style="width: 100%; height: 72px;">
            <tr>
                <td class="auto-style1">
                    <asp:Image ID="IdLogo"  runat="server" Height="61px"  
                        Width="68px" /></td>
                <td align="center" valign="top" class="auto-style2">
                <table>
                <tr>
                <td align="center"><asp:Label CssClass="labelHeader" ID="lblOperador" runat="server" Text="Pliego : [MUN. DIST. NUEVO CHIMBOTE]" ForeColor="Black"></asp:Label>
                    <br />
                </td>
                </tr>
                <tr>
                <td valign="bottom">   
                
<%-- EndRegion --%>
<%-- BeginRegion Static Html --%>
        <div style="height: 30px;">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>

                        <td valign="top">
<%-- EndRegion --%>

            <dxm:ASPxMenu ID="ASPxMenu2" SkinID="None" runat="server" AutoSeparators="RootOnly"
                ItemLinkMode="TextOnly" Font-Names="Tahoma" Font-Size="10px"
                Font-Underline="False" ForeColor="#162436" SeparatorColor="#5386CB" SeparatorHeight="12px"
                SeparatorWidth="1px" SyncSelectionMode="None">
                <Paddings Padding="0px" />
                <SeparatorPaddings PaddingLeft="14px" PaddingRight="14px" PaddingTop="1px" />
                <LinkStyle>
                    <HoverFont Underline="True" />
                </LinkStyle>
            </dxm:ASPxMenu>
<%-- BeginRegion Static Html --%>
                        </td>
                        <td valign="top" class="TabbedMenuSideBorders">
                        </td>
                    </tr>
                </table>
        </div>
<%-- EndRegion --%>
<%-- BeginRegion ASPxRoundPanel --%>
             
                           
                </td>
                </tr>
                </table>
                </td>
                <td align="right" valign="top" class="auto-style2">
                <asp:Label CssClass="labelHeader" ID="lblUser" runat="server" Text="Usuario : Amerika" Font-Size="X-Small" Visible="false"></asp:Label>
                <asp:LinkButton Font-Size="X-Small" ID="LinkButton1" runat="server" CssClass="lnkText" onclick="LinkButton1_Click" ForeColor="Black">Cerrar Sessión</asp:LinkButton>
                </td>
            </tr>
        </table>

<script type="text/javascript" >
    function OnMoreInfoClick(contentUrl) {
        clientPopupControl.SetContentUrl(contentUrl);
        clientPopupControl.Show();
    }
</script>