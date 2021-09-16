<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderPeriodo.ascx.cs" Inherits="InfogesEmape.Includes.HeaderPeriodo" %>

<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<table style="width: 91%; height: 72px;">
    <tr>
        <td align="right" valign="top">
            <dx:ASPxTabControl ID="tcDemos" runat="server" DataSourceID="XmlDataSource1"  AutoPostBack="true"  
                    OnActiveTabChanged="ASPxPageControl1_ActiveTabChanged" Font-Size="Large"
                    ActiveTabStyle-Font-Size="X-Large" TabIndex="0" 
                        Width="1200px" 
                        RightToLeft="True"    EnableTabScrolling="true">
            <Paddings Padding="0" />
	                    <ActiveTabStyle Font-Bold="True" Font-Size="X-Large">
	                    </ActiveTabStyle>
                </dx:ASPxTabControl>
            <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile=""  XPath="//product"  EnableCaching="false"></asp:XmlDataSource>
        </td>
    </tr>
</table>