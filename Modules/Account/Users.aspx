<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/MasterPage.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="InfogesEmape.Modules.Account.Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<br />
	<table border="0" width="100%">
		<tr>
			<td width="70%" align="left"><span class="labelTitleNormal">Escoge un usuario para modificar su informacion o borrarlo.</span></td>
			<td width="30%" align="right"><font color="#ffffff" face="Tahoma" size="2"><b><a href="<%=ResolveUrl("~")%>Modules/Account/UsersCreate.aspx">Crear Nuevo Usuario</a></b></font></td>
		</tr>
	</table>
	<br>
	<table border="1" height="200" width="100%" bordercolor="#000000" cellspacing="0" cellpadding="0">
		<tbody>
			<tr>
				<td width="48%" bgcolor="#E0EEE0" height="30"><font face="Tahoma" size="2"><b>Usuarios Disponibles</b></font></td>
				<td width="52%" bgcolor="#E0EEE0" align="right" height="30">&nbsp;</td>
			</tr>
			<tr>
				<td width="100%" colspan="2" valign="top">
					<div class="sys-gridpanel-bgcolor sys-gridpanel-body">
						<asp:DataGrid id="grdData" runat="server" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
							BackColor="White" CellPadding="3" GridLines="Vertical" ForeColor="Black" ShowHeader="False"
							Font-Size="8pt" Font-Names="Tahoma" AutoGenerateColumns="False" Width="100%">
							<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#000099"></SelectedItemStyle>
							<AlternatingItemStyle BackColor="WhiteSmoke"></AlternatingItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Black"></HeaderStyle>
							<FooterStyle BackColor="#CCCCCC"></FooterStyle>
							<Columns>
								<asp:HyperLinkColumn DataNavigateUrlField="user_id" DataNavigateUrlFormatString="UsersEdit.aspx?pId={0}"
									DataTextField="user_name" NavigateUrl="~/Modules/Account/">
									<HeaderStyle Width="20%"></HeaderStyle>
								</asp:HyperLinkColumn>
								<asp:BoundColumn DataField="description">
									<HeaderStyle Width="50%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="status">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="email_address">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999"></PagerStyle>
						</asp:DataGrid>
					</div>
				</td>
			</tr>
			<tr>
				<td width="100%" colspan="2" bgcolor="#E0EEE0" height="30">
					<p align="right"><font face="Tahoma" size="2"><b>Total&nbsp;de Usuarios&nbsp;:<asp:Label id="lblTotal" runat="server">0</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b></font></p>
				</td>
			</tr>
		</tbody>
	</table>
</asp:Content>
