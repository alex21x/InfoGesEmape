<%@ Control Language="C#" CodeBehind="MenuTreeMovil.ascx.cs" Inherits="InfogesEmape.Includes.MenuTreeMovil" %>

<asp:TreeView ID="TreeView1" runat="server" ImageSet="Simple2" 
    MaxDataBindDepth="5" DataSourceID="XmlDataSource12">
    <ParentNodeStyle Font-Bold="False" Width="100px" />
    <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
    <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" 
        HorizontalPadding="0px" VerticalPadding="0px" />
    <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" 
        HorizontalPadding="0px" NodeSpacing="0px" VerticalPadding="0px" />
    <Databindings>
            <asp:TreeNodeBinding DataMember="menutree" Text="Menu Principal" NavigateUrl="~/Modules/Content.aspx" />
            <asp:TreeNodeBinding DataMember="level1" TextField="Title" SelectAction="None" />
            <asp:TreeNodeBinding DataMember="level2" TextField="Title" SelectAction="None" />
            <asp:TreeNodeBinding DataMember="level3" TextField="Title" NavigateUrlField="Link" />
    </Databindings>        
</asp:TreeView>
<asp:XmlDataSource ID="XmlDataSource12" runat="server" EnableCaching="false" DataFile=""></asp:XmlDataSource>
