<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/MasterPage.Master" AutoEventWireup="true" CodeBehind="Roles.aspx.cs" Inherits="InfogesEmape.Modules.Account.Roles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
			<br/>
			<table border="0" width="100%">
				<tr>
					<td width="100%" align="left"><span class="labelTitleNormal"> Aquí&nbsp;puedes escoger un rol para&nbsp;modificar sus opciones o borrarlo.</span></td>
				</tr>
			</table>
			<br>
			<table border="1" HEIGHT="200" width="100%" bordercolor="#000000" cellspacing="0" cellpadding="0">
				<tbody>
					<tr>
						<td width="48%" valign="top" bgcolor="#E0EEE0" height="30"><font face="Tahoma" size="2"><b>Roles Disponibles</b></font></td>
						<td width="52%" valign="top" bgcolor="#E0EEE0" align="center" height="30"><FONT face="Tahoma" size="2"><B>Crear Nuevo Rol</B></FONT></td>
					</tr>
					<tr>
						<td width="48%" valign="top">
							<div class="sys-gridpanel-bgcolor sys-gridpanel-body">
								<asp:DataGrid id="grdData" runat="server" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
									BackColor="White" CellPadding="3" GridLines="Vertical" ForeColor="Black" ShowHeader="False"
									Font-Size="8pt" Font-Names="Tahoma" AutoGenerateColumns="False" Width="100%">
									<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#000099"></SelectedItemStyle>
									<AlternatingItemStyle BackColor="WhiteSmoke"></AlternatingItemStyle>
									<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Black"></HeaderStyle>
									<FooterStyle BackColor="#CCCCCC"></FooterStyle>
									<Columns>
										<asp:HyperLinkColumn DataNavigateUrlField="role_id" DataNavigateUrlFormatString="RolesEdit.aspx?pId={0}"
											DataTextField="description" NavigateUrl="~/Modules/Account/">
											<HeaderStyle Width="100%"></HeaderStyle>
										</asp:HyperLinkColumn>
									</Columns>
									<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999"></PagerStyle>
								</asp:DataGrid>
							</div>
						</td>
						<td width="52%" valign="top">
							<table border="0" width="100%" class="labelTitleNormal" cellspacing="4">
								<tr>
									<td colspan="2"><span class="labelTitleNormal">
											Puedes crear un nuevo rol, ingresa la descripción y luego has click en el botón 
											Guardar. Después puedes asignar los permisos para el rol creado.</span><br /><br />
									</td>
								</tr>
								<tr>
									<td width="20%">Nombre</td>
									<td width="80%"><asp:TextBox id="txtRole" runat="server" class="textDefault" Width="200px" Height="20px"></asp:TextBox></td>
								</tr>
								<TR>
									<TD></TD>
									<TD align="right">
										<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Se requiere una Descripción para el Rol"
											ControlToValidate="txtRole"></asp:RequiredFieldValidator>&nbsp;<asp:Button D="Button1" runat="server" onclick="Button1_Click" Text="Grabar" CssClass="buttonDefault"  />&nbsp;
                                    </TD>
								</TR>
							</table>
						</td>
					</tr>
					<tr>
						<td colspan="2" height="30" align="left" bgcolor="#e0eee0">
							<FONT face="Tahoma" size="2"><B>Total roles :</B></FONT>&nbsp;&nbsp;&nbsp;<asp:Label id="lblTotal" runat="server">0</asp:Label>&nbsp;
						</td>
					</tr>
				</tbody>
			</table>
			<br />
        </ContentTemplate>
    </asp:UpdatePanel>    
			
</asp:Content>
