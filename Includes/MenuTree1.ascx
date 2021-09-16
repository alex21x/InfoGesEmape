<%@ Control Language="C#" CodeBehind="MenuTree1.ascx.cs" Inherits="InfoGesRegional.Includes.MenuTree11" %>

<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRoundPanel" tagprefix="dxrp" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxMenu" tagprefix="dxm" %>

<%@ Register Assembly="DevExpress.Web.v13.1" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<dxrp:ASPxRoundPanel ShowHeader="False" Width="100%" ID="ASPxRoundPanel1" 
    runat="server" EnableTheming="False" BackColor="White" Height="62px">
    <bottomrightcorner height="5px" url="../Images/TabbedMenu/rpBottomRight.png" width="5px"></bottomrightcorner>
    <noheadertoprightcorner height="5px" url="../Images/TabbedMenu/rpTopRight.png" width="5px"></noheadertoprightcorner>
    <noheadertopleftcorner height="5px" url="../Images/TabbedMenu/rpTopLeft.png" width="5px"></noheadertopleftcorner>
    <bottomleftcorner height="5px" url="~/Images/TabbedMenu/rpBottomLeft.png" width="5px"></bottomleftcorner>
    <PanelCollection>
        <dxrp:PanelContent ID="PanelContent2" runat="server">
        
<%-- EndRegion --%>
<%-- BeginRegion Static Html --%>
        <div style="height: 30px;">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td valign="top" class="TabbedMenuSideBorders">
                            <div class="Spacer" style="width: 10px;"></div>
                        </td>
                        <td valign="top">
                            <div class="TabbedMenuTableSide"></div>
                        </td>
                        <td valign="top">
<%-- EndRegion --%>
<dxm:ASPxMenu EnableTheming="False" ID="ASPxMenu1" CssClass="TabbedMenu" runat="server" AppearAfter="0" DataSourceID="XmlDataSource1" ItemSpacing="0px" SeparatorHeight="28px" SeparatorWidth="1px" ShowSubMenuShadow="False" BorderBetweenItemAndSubMenu="HideRootOnly" Font-Names="Tahoma" Font-Size="8pt" Font-Underline="False" ForeColor="Black" AutoPostBack="True" SyncSelectionMode="None" EnableDefaultAppearance="False" ClientInstanceName="tabbedMenu" AllowSelectItem="True" SelectParentItem="True">
    <ItemStyle CssClass="rootItem" Wrap="False">
        <BackgroundImage ImageUrl="~/Images/TabbedMenu/RootItemSeparator.gif" Repeat="NoRepeat" HorizontalPosition="right" />
        <Paddings Padding="0px" />
        <HoverStyle CssClass="rootItemHover">
        </HoverStyle>
        <SelectedStyle CssClass="rootItemSelected">
        </SelectedStyle>
    </ItemStyle>
    <Paddings Padding="0px" />
    <Border BorderStyle="None" />
    <RootItemSubMenuOffset X="-1" Y="-2" FirstItemX="-1" FirstItemY="-2" LastItemX="-1"
        LastItemY="-2" />
    <SubMenuStyle GutterWidth="0px" ItemSpacing="0px" BackColor="White" CssClass="menu">
        <Paddings Padding="1px" />
        <Border BorderColor="#919191" BorderStyle="Solid" BorderWidth="1px" />
    </SubMenuStyle>
    <SubMenuItemStyle Wrap="False">
    <HoverStyle BackColor="#EDEDED">
                <Border BorderWidth="0px" />
    </HoverStyle>
            <Paddings Padding="5px" PaddingLeft="7px" PaddingRight="7px" />
    </SubMenuItemStyle>
    <VerticalPopOutImage Height="5px" Url="~/Images/TabbedMenu/ItemArrow.gif" Width="4px" />
    <ItemSubMenuOffset X="-1" Y="-2" FirstItemY="-3" LastItemY="-2" />
    <LinkStyle Color="Black">
        <Font Underline="False"></Font>
    </LinkStyle>
    <RootItemTextTemplate>
            <div><table cellpadding="0" cellspacing="0" border="0">
            <tr><th class="WhiteBorderRight">
            <dxe:ASPxLabel ID="lblText" runat="server" EnableTheming="False" EnableDefaultAppearance="False" Text='<%# Eval("Text") %>' NavigateUrl='<%# Eval("NavigateUrl") %>' />
            </th></tr>
            </table>
            </div>
    </RootItemTextTemplate>
</dxm:ASPxMenu>
<%-- BeginRegion DataSource --%>
<asp:XmlDataSource ID="XmlDataSource1" runat="server" EnableCaching="false"  XPath="/mainmenu/item" />                            
<%-- EndRegion --%>
<%-- BeginRegion Static Html --%>
                        </td>
                        <td valign="top" class="TabbedMenuSideBorders">
                            <div class="Spacer" style="width: 10px;"></div>
                        </td>
                    </tr>
                </table>
        </div>
<%-- EndRegion --%>
<%-- BeginRegion ASPxRoundPanel --%>
        </dxrp:PanelContent>
</PanelCollection>
</dxrp:ASPxRoundPanel>
<%-- EndRegion --%>