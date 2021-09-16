<%@ Page CodeBehind="AccountsUsers_List.aspx.cs" Language="c#" AutoEventWireup="false" Inherits="AdieraManager.Modules.MainData.AccountsUsers_List" %>
<HTML>
	<HEAD>
		<link REL="stylesheet" type="text/css" href="/AdieraManager/styles/scanner.css">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<span class="sys-font-heading3 sys-rhp-color-title"><img border="0" src="/AdieraManager/images/Subscriber_List2.gif" width="30" height="30">&nbsp;Accounts&nbsp;Usuarios</span>
			<br>
			<br>
			<table border="0" width="100%">
				<tr>
					<td width="70%" align="left"><span class="sys-font-body-Text">Escoge un usuario para modificar su informacion o borrarlo.</span></td>
					<td width="30%" align="right"><font color="#ffffff" face="Tahoma" size="2"><b><a href="/AdieraManager/Modules/MainData/AccountsUsers_Create.aspx">Crear Nuevo Usuario</a></b></font></td>
				</tr>
			</table>
			<br>
			<table border="1" HEIGHT="200" width="100%" bordercolor="#000000" cellspacing="0" cellpadding="0">
				<tbody>
					<tr>
						<td width="48%" bgcolor="#90b64a" height="15"><font face="Tahoma" size="2" color="#ffffff"><b>Usuarios 
									Disponibles</b></font></td>
						<td width="52%" bgcolor="#90b64a" align="right" height="15">&nbsp;</td>
					</tr>
					<tr>
						<td width="100%" colspan="2">
							<div class="sys-gridpanel-bgcolor sys-gridpanel-body">
								<asp:DataGrid id="grdData" runat="server" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
									BackColor="White" CellPadding="3" GridLines="Vertical" ForeColor="Black" ShowHeader="False"
									Font-Size="8pt" Font-Names="Tahoma" AutoGenerateColumns="False" Width="100%">
									<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#000099"></SelectedItemStyle>
									<AlternatingItemStyle BackColor="WhiteSmoke"></AlternatingItemStyle>
									<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Black"></HeaderStyle>
									<FooterStyle BackColor="#CCCCCC"></FooterStyle>
									<Columns>
										<asp:HyperLinkColumn DataNavigateUrlField="user_id" DataNavigateUrlFormatString="AccountsUsers_Edit.aspx?vntUserId={0}"
											DataTextField="user_name" NavigateUrl="/AdieraManager/Modules/MainData/">
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
						<td width="100%" colspan="2" bgcolor="#90b64a" height="22">
							<p align="right"><font face="Tahoma" size="2" color="#ffffff"><b>Total&nbsp;de 
										Usuarios&nbsp;:
										<asp:Label id="lblTotal" runat="server">0</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b></font></p>
						</td>
					</tr>
				</tbody>
			</table>
		</form>
	</body>
</HTML>
