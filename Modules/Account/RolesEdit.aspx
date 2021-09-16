<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/MasterPage.Master" AutoEventWireup="true" CodeBehind="RolesEdit.aspx.cs" Inherits="InfogesEmape.Modules.Account.RolesEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
			<br />
			<table border="0" width="100%">
				<tr>
					<td width="100%" align="left"><span class="labelTitleNormal">Puedes asignar los permisos disponibles para 
el usuario. Selecciona un elemento y luego presiona el botón &lt;&lt; o elimina el 
				permiso de la lista presionando el botón &gt;&gt;.</span></td>
				</tr>
			</table>
			<br />
			<table width="100%" border="1" class="labelTitleNormal" bordercolor="#9e9e8f">
				<tr>
					<td width="45%"><span class="labelTitle">Permisos del Rol</span></td>
					<td width="10%">&nbsp;</td>
					<td width="45%"><span class="labelTitle">Permisos Disponibles</span></td>
				</tr>
				<tr>
					<td width="45%" valign="top">
					    <asp:TreeView ID="trwRoleDestiny" runat="server" ImageSet="Simple2" MaxDataBindDepth="5" DataSourceID="XmlDataSource1" >
                            <ParentNodeStyle Font-Bold="False" Width="100px" />
                            <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                            <SelectedNodeStyle Font-Bold="true" Font-Size="Small" Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px" VerticalPadding="0px" />
                            <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" HorizontalPadding="0px" NodeSpacing="0px" VerticalPadding="0px" />
                            <Databindings>
                                    <asp:TreeNodeBinding DataMember="menutree" Text="Menu Principal" SelectAction="None" />
                                    <asp:TreeNodeBinding DataMember="level1" ValueField="Name" TextField="Title" SelectAction="None" />
                                    <asp:TreeNodeBinding DataMember="level2" ValueField="Name" TextField="Title" SelectAction="None" />
                                    <asp:TreeNodeBinding DataMember="level3" ValueField="Name" TextField="Title" SelectAction="SelectExpand" />
                            </Databindings>        
                        </asp:TreeView>
                        <asp:XmlDataSource EnableCaching="false" ID="XmlDataSource1" runat="server" DataFile=""></asp:XmlDataSource>
					</td>
					<td width="10%" valign="middle" align="center">
						<table>
							<tr>
								<td><asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="<<" CssClass="buttonDefault" /></td>
							</tr>
							<tr>
								<td><asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text=">>"  CssClass="buttonDefault" /></td>
							</tr>
						</table>
					</td>
					<td width="45%" valign="top">
					    <asp:TreeView ID="trwRoleSource" runat="server" ImageSet="Simple2" MaxDataBindDepth="5" DataSourceID="XmlDataSource2" >
                            <ParentNodeStyle Font-Bold="False" Width="100px" />
                            <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                            <SelectedNodeStyle Font-Bold="true" Font-Size="Small" Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px" VerticalPadding="0px" />
                            <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" HorizontalPadding="0px" NodeSpacing="0px" VerticalPadding="0px" />
                            <Databindings>
                                    <asp:TreeNodeBinding DataMember="menutree" Text="Menu Principal" SelectAction="None" />
                                    <asp:TreeNodeBinding DataMember="level1" ValueField="Name" TextField="Title" SelectAction="None" />
                                    <asp:TreeNodeBinding DataMember="level2" ValueField="Name" TextField="Title" SelectAction="None" />
                                    <asp:TreeNodeBinding DataMember="level3" ValueField="Name" TextField="Title" SelectAction="SelectExpand" />
                            </Databindings>        
                        </asp:TreeView>
                        <asp:XmlDataSource EnableCaching="false" ID="XmlDataSource2" runat="server" DataFile=""></asp:XmlDataSource>
					</td>
				</tr>
			</table>
			<br />
			<table width="100%" class="labelTitleNormal"><tr>
			    <td align="left">Tambien puedes seleccionar&nbsp;un rol y borrarlo&nbsp;presionando el botón</td>
			    <td align="right">
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" CssClass="buttonDefault" Text="Borrar" />&nbsp;&nbsp;<asp:Button ID="Button4" runat="server" onclick="Button4_Click" CssClass="buttonDefault" Text="Cerrar" />
                </td>
			</tr></table>
			<br />
        </ContentTemplate>
    </asp:UpdatePanel>   
</asp:Content>
